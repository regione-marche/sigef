using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;

namespace web.Private.IPagamento
{
    public partial class IstruttoriaCorrettivaRendicontazione : SiarLibrary.Web.IstruttoriaPagamentoPage
    {
        System.Web.Script.Serialization.JavaScriptSerializer jsser = new System.Web.Script.Serialization.JavaScriptSerializer();
        SiarBLL.PianoInvestimentiCollectionProvider investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider();
        SiarBLL.CorrettivaRendicontazioneCollectionProvider correttiva_provider;
        SiarBLL.CorrettivaRendicontazioneSpostamentiCollectionProvider spostamenti_provider;
        SiarBLL.PagamentiRichiestiCollectionProvider prichiesti_provider;
        SiarBLL.PagamentiBeneficiarioCollectionProvider pbeneficiario_provider;
        SiarLibrary.PianoInvestimenti investimento_di_partenza, investimento_di_arrivo;
        SiarLibrary.CorrettivaRendicontazione correttiva_selezionata;
        SpostamentoJson SPS;

        protected void Page_Load(object sender, EventArgs e)
        {
            correttiva_provider = new SiarBLL.CorrettivaRendicontazioneCollectionProvider(PagamentoProvider.DbProviderObj);
            spostamenti_provider = new SiarBLL.CorrettivaRendicontazioneSpostamentiCollectionProvider(PagamentoProvider.DbProviderObj);
            prichiesti_provider = new SiarBLL.PagamentiRichiestiCollectionProvider(PagamentoProvider.DbProviderObj);
            pbeneficiario_provider = new SiarBLL.PagamentiBeneficiarioCollectionProvider(PagamentoProvider.DbProviderObj);
            SiarLibrary.CorrettivaRendicontazioneCollection correttive_pagamento = correttiva_provider.Find(DomandaPagamento.IdDomandaPagamento, null, null);
            if (correttive_pagamento.Count > 0) correttiva_selezionata = correttive_pagamento[0];
        }

        protected override void OnPreRender(EventArgs e)
        {
            SiarLibrary.CorrettivaRendicontazioneCollection correttive = new SiarLibrary.CorrettivaRendicontazioneCollection();
            if (correttiva_selezionata == null) { tableCorrettiva.Visible = false; btnNuovoSpostamento.Disabled = true; }
            else
            {
                tableCorrettiva.Visible = true;
                txtDescrizioneLungaCorrettiva.Text = correttiva_selezionata.Note;

                if (SPS == null)
                    try { SPS = jsser.Deserialize<SpostamentoJson>(hdnJsonDatiSpostamento.Value); }
                    catch { ShowError("Non è stato possibile caricare la correttiva selezionata."); }

                if (SPS == null)
                {
                    SiarLibrary.CorrettivaRendicontazioneSpostamentiCollection spostamenti = spostamenti_provider.Find(correttiva_selezionata.Id,
                        null, null, null, null);
                    if (spostamenti.Count > 0)
                    {
                        tableSpostamentoSelezionato.Visible = false;
                        dgSpostamenti.DataSource = spostamenti;
                        dgSpostamenti.ItemDataBound += new DataGridItemEventHandler(dgSpostamenti_ItemDataBound);
                        dgSpostamenti.DataBind();
                    }
                    else SPS = new SpostamentoJson();
                }
                if (SPS != null)
                {
                    tableElencoSpostamenti.Visible = false;
                    if (SPS.IdSpostamento > 0)
                    {
                        SiarLibrary.CorrettivaRendicontazioneSpostamenti sp = spostamenti_provider.GetById(SPS.IdSpostamento);
                        txtDescrizioneSpostamento.Text = sp.Descrizione;
                        txtStatoSpostamento.Text = (sp.Annullato ? "ANNULLATO" : (sp.Concluso ? "CONCLUSO" : "IN LAVORAZIONE"));
                        btnChiudiSpostamento.Enabled = btnAnnullaSpostamento.Enabled = AbilitaModifica;

                        btnSalvaSpostamento.Enabled = btnChiudiSpostamento.Enabled = AbilitaModifica && !sp.Annullato && !sp.Concluso;
                        btnAnnullaSpostamento.Enabled = AbilitaModifica && !sp.Annullato;
                    }
                    else { btnChiudiSpostamento.Enabled = btnAnnullaSpostamento.Enabled = false; btnSalvaSpostamento.Enabled = AbilitaModifica; }
                    // popolo gli investimenti                    
                    if (SPS.PagamentoDa.IdInvestimento > 0)
                    {
                        investimento_di_partenza = investimenti_provider.GetById(SPS.PagamentoDa.IdInvestimento);
                        if (investimento_di_partenza != null)
                        {
                            txtIPTOTCostoInvestimento.Text = investimento_di_partenza.CostoInvestimento;
                            txtIPTOTSpeseTecniche.Text = investimento_di_partenza.SpeseGenerali;
                            txtIPTOTContributo.Text = investimento_di_partenza.ContributoRichiesto;
                            txtIPTOTQuota.Text = investimento_di_partenza.QuotaContributoRichiesto;
                            if (investimento_di_partenza.Mobile != null && !investimento_di_partenza.Mobile)
                            {
                                txtIPPRComputoMetrico.ReadOnly = false;
                                txtIPPRComputoMetrico.AddJSAttribute("onblur", "ricalcola_pagamenti_richiesti=true;popolaPagamentiBeneficiarioPartenza();");
                            }
                            popolaSpostamentoDatiPartenza();
                        }
                    }
                    if (SPS.PagamentoA.IdInvestimento > 0)
                    {
                        investimento_di_arrivo = investimenti_provider.GetById(SPS.PagamentoA.IdInvestimento);
                        if (investimento_di_arrivo != null)
                        {
                            txtIATOTCostoInvestimento.Text = investimento_di_arrivo.CostoInvestimento;
                            txtIATOTSpeseTecniche.Text = investimento_di_arrivo.SpeseGenerali;
                            txtIATOTContributo.Text = investimento_di_arrivo.ContributoRichiesto;
                            txtIATOTQuota.Text = investimento_di_arrivo.QuotaContributoRichiesto;
                            if (investimento_di_arrivo.Mobile != null && !investimento_di_arrivo.Mobile)
                            {
                                txtIAPRComputoMetrico.ReadOnly = false;
                                txtIAPRComputoMetrico.AddJSAttribute("onblur", "ricalcola_pagamenti_richiesti=true;popolaPagamentiBeneficiarioArrivo();");
                            }
                            popolaSpostamentoDatiArrivo();
                        }
                    }
                    hdnJsonDatiSpostamento.Value = jsser.Serialize(SPS);
                    RegisterClientScriptBlock("loadSpostamentoJson();");
                }
            }
            base.OnPreRender(e);
        }

        private void popolaSpostamentoDatiPartenza()
        {
            if (SPS.IdSpostamento == 0)
            {
                SPS.PagamentoDa.IdInvestimento = investimento_di_partenza.IdInvestimento;
                SPS.PagamentoDa.ContributoInvestimento = investimento_di_partenza.ContributoRichiesto;
                SPS.PagamentoDa.QuotaContributoInvestimento = investimento_di_partenza.QuotaContributoRichiesto;
                SPS.PagamentoDa.InvestimentoMobile = investimento_di_partenza.Mobile;

                SiarLibrary.PagamentiRichiestiCollection prichiesto_di_partenza = prichiesti_provider.Find(null, investimento_di_partenza.IdInvestimento,
                    null, DomandaPagamento.IdDomandaPagamento);
                if (prichiesto_di_partenza.Count > 0)
                {
                    SPS.PagamentoDa.IdPagamentoRichiesto = prichiesto_di_partenza[0].IdPagamentoRichiesto;
                    SPS.PagamentoDa.ImportoRichiesto = prichiesto_di_partenza[0].ImportoRichiesto;
                    SPS.PagamentoDa.ImportoRichiesto_BK = prichiesto_di_partenza[0].ImportoRichiesto;
                    if (prichiesto_di_partenza[0].ImportoComputoMetrico != null)
                    {
                        SPS.PagamentoDa.ImportoComputoMetrico = prichiesto_di_partenza[0].ImportoComputoMetrico;
                        SPS.PagamentoDa.ImportoComputoMetrico_BK = prichiesto_di_partenza[0].ImportoComputoMetrico;
                    }
                    SPS.PagamentoDa.ContributoRichiesto = prichiesto_di_partenza[0].ContributoRichiesto;
                    SPS.PagamentoDa.ContributoRichiesto_BK = prichiesto_di_partenza[0].ContributoRichiesto;

                    SiarLibrary.PagamentiBeneficiarioCollection pbcollection = pbeneficiario_provider.Find(prichiesto_di_partenza[0].IdPagamentoRichiesto,
                        null, null, null, null, null);
                    SPS.PagamentoDa.PB = new PagamentiBeneficiarioJson[pbcollection.Count];
                    for (int i = 0; i < pbcollection.Count; i++) SPS.PagamentoDa.PB[i] = getPagamentiJson(pbcollection[i]);
                }
            }
        }

        private void popolaSpostamentoDatiArrivo()
        {
            if (SPS.IdSpostamento == 0)
            {
                SPS.PagamentoA.IdInvestimento = investimento_di_arrivo.IdInvestimento;
                SPS.PagamentoA.ContributoInvestimento = investimento_di_arrivo.ContributoRichiesto;
                SPS.PagamentoA.QuotaContributoInvestimento = investimento_di_arrivo.QuotaContributoRichiesto;
                SPS.PagamentoA.InvestimentoMobile = investimento_di_arrivo.Mobile;

                SiarLibrary.PagamentiRichiestiCollection prichiesto_di_arrivo = prichiesti_provider.Find(null, investimento_di_arrivo.IdInvestimento,
                    null, DomandaPagamento.IdDomandaPagamento);
                if (prichiesto_di_arrivo.Count > 0)
                {
                    SPS.PagamentoA.IdPagamentoRichiesto = prichiesto_di_arrivo[0].IdPagamentoRichiesto;
                    SPS.PagamentoA.ImportoRichiesto = prichiesto_di_arrivo[0].ImportoRichiesto;
                    SPS.PagamentoA.ImportoRichiesto_BK = prichiesto_di_arrivo[0].ImportoRichiesto;
                    if (prichiesto_di_arrivo[0].ImportoComputoMetrico != null)
                    {
                        SPS.PagamentoA.ImportoComputoMetrico = prichiesto_di_arrivo[0].ImportoComputoMetrico;
                        SPS.PagamentoA.ImportoComputoMetrico_BK = prichiesto_di_arrivo[0].ImportoComputoMetrico;
                    }
                    SPS.PagamentoA.ContributoRichiesto = prichiesto_di_arrivo[0].ContributoRichiesto;
                    SPS.PagamentoA.ContributoRichiesto_BK = prichiesto_di_arrivo[0].ContributoRichiesto;

                    SiarLibrary.PagamentiBeneficiarioCollection pbcollection = pbeneficiario_provider.Find(prichiesto_di_arrivo[0].IdPagamentoRichiesto,
                        null, null, null, null, null);
                    SPS.PagamentoA.PB = new PagamentiBeneficiarioJson[pbcollection.Count];
                    for (int i = 0; i < pbcollection.Count; i++) SPS.PagamentoA.PB[i] = getPagamentiJson(pbcollection[i]);
                }
            }
        }

        void dgSpostamenti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.CorrettivaRendicontazioneSpostamenti s = (SiarLibrary.CorrettivaRendicontazioneSpostamenti)e.Item.DataItem;
                e.Item.Cells[5].Text = "<input type=button class='ButtonGrid' value='Seleziona' onclick='selezionaSpostamento(" + s.Id + ");' />";
                e.Item.Cells[4].Text = (s.Concluso ? "CONCLUSO" : "in lavorazione");
                if (s.Annullato)
                {
                    e.Item.Cells[4].Text = "ANNULLATO";
                    e.Item.Cells[2].Style.Add("text-decoration", "line-through");
                }
            }
        }

        public class SpostamentoJson
        {
            public int IdSpostamento;
            public SpostamentoJson() { PagamentoDa = new PagamentiJson(); PagamentoA = new PagamentiJson(); }
            public PagamentiJson PagamentoDa, PagamentoA;
        }

        public class PagamentiJson
        {
            public int IdInvestimento, IdPagamentoRichiesto;
            public bool InvestimentoMobile;
            public decimal ContributoInvestimento, QuotaContributoInvestimento, ImportoFatture, ImportoLavoriEconomia, ImportoRichiesto, ImportoRichiesto_BK,
                ImportoComputoMetrico, ImportoComputoMetrico_BK, ContributoRichiesto, ContributoRichiesto_BK, ImportoSpeseTecnicheRichieste;
            public PagamentiBeneficiarioJson[] PB;
        }

        public class PagamentiBeneficiarioJson
        {
            public long IdPagamentoBeneficiario;
            public int IdPagBenOriginale, IdPagamentoRichiesto, IdGiustificativo;
            public decimal ImportoRichiesto, Imponibile, ImportoSpostato;
            public string Numero, TipoGiustificativo, Data, NumeroDoctrasporto, DataDoctrasporto, Descrizione;
            public bool SpesaTecnicaRichiesta, LavoriInEconomia, Modificato;
        }

        private PagamentiBeneficiarioJson getPagamentiJson(SiarLibrary.PagamentiBeneficiario pb)
        {
            PagamentiBeneficiarioJson pj = new PagamentiBeneficiarioJson();
            pj.IdPagamentoBeneficiario = pb.IdPagamentoBeneficiario;
            pj.IdPagBenOriginale = 0;
            pj.IdPagamentoRichiesto = pb.IdPagamentoRichiesto;
            pj.IdGiustificativo = pb.IdGiustificativo;
            pj.ImportoRichiesto = pb.ImportoRichiesto;
            pj.Imponibile = pb.Imponibile;
            pj.ImportoSpostato = 0;
            pj.Numero = pb.Numero;
            pj.TipoGiustificativo = pb.TipoGiustificativo;
            pj.Data = pb.Data;
            pj.NumeroDoctrasporto = pb.NumeroDoctrasporto;
            pj.DataDoctrasporto = pb.DataDoctrasporto;
            pj.Descrizione = pb.Descrizione;
            pj.SpesaTecnicaRichiesta = pb.SpesaTecnicaRichiesta;
            pj.LavoriInEconomia = pb.LavoriInEconomia;
            return pj;
        }

        protected void btnSalvaCorrettiva_Click(object sender, EventArgs e)
        {
            try
            {
                if (correttiva_selezionata == null)
                {
                    correttiva_selezionata = new SiarLibrary.CorrettivaRendicontazione();
                    correttiva_selezionata.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                }
                SiarBLL.NoteCollectionProvider note_provider = new SiarBLL.NoteCollectionProvider();
                SiarLibrary.Note n;
                if (correttiva_selezionata.IdNote != null) n = note_provider.GetById(correttiva_selezionata.IdNote);
                else n = new SiarLibrary.Note();
                n.Testo = txtDescrizioneLungaCorrettiva.Text;
                note_provider.Save(n);

                correttiva_selezionata.IdUtente = Operatore.Utente.IdUtente;
                correttiva_selezionata.Data = DateTime.Now;
                correttiva_selezionata.IdNote = n.Id;
                correttiva_provider.Save(correttiva_selezionata);
                correttiva_selezionata = correttiva_provider.GetById(correttiva_selezionata.Id);
                ShowMessage("Correttiva salvata correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            try
            {
                int id_spostamento;
                if (int.TryParse(hdnIdSpostamentoSelezionato.Value, out id_spostamento))
                {
                    SiarLibrary.CorrettivaRendicontazioneSpostamenti sp = spostamenti_provider.GetById(id_spostamento);
                    if (sp != null)
                    {
                        SiarLibrary.Note n = new SiarBLL.NoteCollectionProvider().GetById(sp.IdJsonLog);
                        if (n != null) SPS = jsser.Deserialize<SpostamentoJson>(n.Testo);
                    }
                    if (SPS == null) ShowError("Lo spostamento di rendicontazione selezionato non è valido.");
                }
                else if (hdnIdSpostamentoSelezionato.Value == "NuovoSpostamento")
                {
                    SPS = new SpostamentoJson();
                    hdnIdSpostamentoSelezionato.Value = null;
                }
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnAnnullaSpostamento_Click(object sender, EventArgs e)
        {

            try
            {
                if (correttiva_selezionata == null) throw new Exception("Per continuare è necessario selezionare una correttiva.");
                try { SPS = jsser.Deserialize<SpostamentoJson>(hdnJsonDatiSpostamento.Value); }
                catch { throw new Exception("Lo spostamento selezionato non è valido."); }
                if (SPS == null || SPS.IdSpostamento <= 0) throw new Exception("Lo spostamento selezionato non è valido.");

                SiarLibrary.CorrettivaRendicontazioneSpostamentiCollection spostamenti = spostamenti_provider.Find(correttiva_selezionata.Id, null, null, null, false);
                SiarLibrary.CorrettivaRendicontazioneSpostamenti spostamento_selezionato = spostamenti.CollectionGetById(SPS.IdSpostamento);
                if (spostamento_selezionato == null || spostamento_selezionato.Annullato || spostamento_selezionato.IdInvestimentoA == null
                    || spostamento_selezionato.IdInvestimentoDa == null) throw new Exception("Lo spostamento selezionato non è valido.");

                bool chiudi_correttiva = true;
                foreach (SiarLibrary.CorrettivaRendicontazioneSpostamenti s in spostamenti)
                {
                    if (s.Id != spostamento_selezionato.Id && chiudi_correttiva && !s.Concluso) chiudi_correttiva = false;
                    if (s.Id != spostamento_selezionato.Id && s.Data > spostamento_selezionato.Data &&
                        (s.IdInvestimentoDa == spostamento_selezionato.IdInvestimentoDa || s.IdInvestimentoDa == spostamento_selezionato.IdInvestimentoA ||
                        s.IdInvestimentoA == spostamento_selezionato.IdInvestimentoDa || s.IdInvestimentoA == spostamento_selezionato.IdInvestimentoA))
                        throw new Exception("Per annullare uno spostamento di rendicontazione è necessario annullare tutti quelli effettuati successivamente che interessano l`investimento di partenza o di arrivo.");
                }
                PagamentoProvider.DbProviderObj.BeginTran();
                SiarLibrary.PagamentiRichiesti prichiesto_di_partenza = prichiesti_provider.Find(null, spostamento_selezionato.IdInvestimentoDa,
                    null, DomandaPagamento.IdDomandaPagamento)[0], prichiesto_di_arrivo = prichiesti_provider.Find(null, spostamento_selezionato.IdInvestimentoA,
                    null, DomandaPagamento.IdDomandaPagamento)[0];

                prichiesto_di_partenza.ImportoRichiesto = SPS.PagamentoDa.ImportoRichiesto_BK;
                prichiesto_di_partenza.ImportoComputoMetrico = SPS.PagamentoDa.ImportoComputoMetrico_BK;
                prichiesto_di_partenza.ContributoRichiesto = SPS.PagamentoDa.ContributoRichiesto_BK;
                prichiesti_provider.Save(prichiesto_di_partenza);

                prichiesto_di_arrivo.ImportoRichiesto = SPS.PagamentoA.ImportoRichiesto_BK;
                prichiesto_di_arrivo.ImportoComputoMetrico = SPS.PagamentoA.ImportoComputoMetrico_BK;
                prichiesto_di_arrivo.ContributoRichiesto = SPS.PagamentoA.ContributoRichiesto_BK;
                prichiesti_provider.Save(prichiesto_di_arrivo);

                // pben partenza
                SiarLibrary.PagamentiBeneficiarioCollection pb_partenza = pbeneficiario_provider.Find(prichiesto_di_partenza.IdPagamentoRichiesto,
                    null, null, null, null, null);
                foreach (PagamentiBeneficiarioJson pb in SPS.PagamentoDa.PB)
                {
                    if (pb.Modificato) foreach (SiarLibrary.PagamentiBeneficiario p in pb_partenza)
                            if (p.IdPagamentoBeneficiario == (int)pb.IdPagamentoBeneficiario)
                            {
                                p.ImportoRichiesto += pb.ImportoSpostato;
                                break;
                            }
                }
                pbeneficiario_provider.SaveCollection(pb_partenza);

                // pben arrivo
                SiarLibrary.PagamentiBeneficiarioCollection pb_arrivo = pbeneficiario_provider.Find(prichiesto_di_arrivo.IdPagamentoRichiesto,
                    null, null, null, null, null);
                foreach (PagamentiBeneficiarioJson pb in SPS.PagamentoA.PB)
                {
                    if (pb.Modificato) foreach (SiarLibrary.PagamentiBeneficiario p in pb_arrivo)
                            if (p.IdPagamentoBeneficiario == (int)pb.IdPagamentoBeneficiario)
                            {
                                p.MarkForDeletion();
                                break;
                            }
                }
                pbeneficiario_provider.SaveCollection(pb_arrivo);

                spostamento_selezionato.Annullato = true;
                spostamento_selezionato.IdUtente = Operatore.Utente.IdUtente;
                spostamento_selezionato.Data = DateTime.Now;
                spostamenti_provider.Save(spostamento_selezionato);

                correttiva_selezionata.IdUtente = Operatore.Utente.IdUtente;
                correttiva_selezionata.Data = DateTime.Now;
                if (chiudi_correttiva) correttiva_selezionata.Conclusa = true;
                correttiva_provider.Save(correttiva_selezionata);
                PagamentoProvider.DbProviderObj.Commit();
                ShowMessage("Spostamento di rendicontazione annullato correttamente.");
            }
            catch (Exception ex) { PagamentoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnSalvaSpostamento_Click(object sender, EventArgs e)
        {
            try
            {
                salvaSpostamento(false);
                ShowMessage("Spostamento di rendicontazione salvato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnChiudiSpostamento_Click(object sender, EventArgs e)
        {
            try
            {
                salvaSpostamento(true);
                ShowMessage("Spostamento di rendicontazione chiuso correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }

        }

        private void salvaSpostamento(bool chiudi_spostamento)
        {
            try
            {
                if (correttiva_selezionata == null) throw new Exception("Nessuna correttiva di rendicontazione selezionata. Impossibile continuare.");
                try { SPS = jsser.Deserialize<SpostamentoJson>(hdnJsonDatiSpostamento.Value); }
                catch { throw new Exception("Lo spostamento selezionato non è valido."); }
                if (SPS == null) throw new Exception("Lo spostamento selezionato non è valido.");
                if (SPS.PagamentoDa.IdInvestimento < 1) throw new Exception("Selezionare l`investimento di partenza.");
                if (SPS.PagamentoA.IdInvestimento < 1) throw new Exception("Selezionare l`investimento di arrivo.");

                SiarLibrary.CorrettivaRendicontazioneSpostamenti spostamento_selezionato = null;
                if (SPS.IdSpostamento > 0)
                {
                    spostamento_selezionato = spostamenti_provider.GetById(SPS.IdSpostamento);
                    foreach (SiarLibrary.CorrettivaRendicontazioneSpostamenti sp in spostamenti_provider.Find(correttiva_selezionata.Id, null, null, false, false))
                        if (sp.Id != SPS.IdSpostamento) throw new Exception("Per registrare un nuovo spostamento è necessario completare le modifiche su quelli ancora in lavorazione.");
                }
                else if (spostamenti_provider.Find(correttiva_selezionata.Id, null, null, false, false).Count > 0)
                    throw new Exception("Per registrare un nuovo spostamento è necessario completare le modifiche su quelli ancora in lavorazione.");

                SiarLibrary.PagamentiRichiesti prichiesto_di_partenza = null;
                if (SPS.PagamentoDa.IdPagamentoRichiesto > 0) prichiesto_di_partenza = prichiesti_provider.GetById(SPS.PagamentoDa.IdPagamentoRichiesto);
                else throw new Exception("L`investimento di partenza non è valido. Impossibile continuare.");

                SiarLibrary.PagamentiRichiesti prichiesto_di_arrivo = null;
                if (SPS.PagamentoA.IdPagamentoRichiesto > 0) prichiesto_di_arrivo = prichiesti_provider.GetById(SPS.PagamentoA.IdPagamentoRichiesto);
                else
                {
                    prichiesto_di_arrivo = new SiarLibrary.PagamentiRichiesti();
                    prichiesto_di_arrivo.IdInvestimento = SPS.PagamentoA.IdInvestimento;
                    prichiesto_di_arrivo.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                    prichiesto_di_arrivo.DataRichiestaPagamento = DateTime.Now;
                }

                // effettuare qui i controlli sugli importi
                controllaImportiPagamento(ref SPS.PagamentoDa);
                controllaImportiPagamento(ref SPS.PagamentoA);

                PagamentoProvider.DbProviderObj.BeginTran();
                // richiesto di partenza
                prichiesto_di_partenza.ImportoAmmesso = prichiesto_di_partenza.ImportoComputoMetricoAmmesso = prichiesto_di_partenza.ContributoAmmesso = 0;
                //prichiesto_di_partenza.Ammesso = false;
                if (!SPS.PagamentoDa.InvestimentoMobile) //investimento_di_partenza.Mobile == null || !investimento_di_partenza.Mobile)
                    prichiesto_di_partenza.ImportoComputoMetrico = SPS.PagamentoDa.ImportoComputoMetrico;
                prichiesto_di_partenza.ImportoRichiesto = SPS.PagamentoDa.ImportoRichiesto;
                prichiesto_di_partenza.ContributoRichiesto = SPS.PagamentoDa.ContributoRichiesto;
                prichiesti_provider.Save(prichiesto_di_partenza);
                // richiesto di arrivo               
                prichiesto_di_arrivo.ImportoAmmesso = prichiesto_di_arrivo.ImportoComputoMetricoAmmesso = prichiesto_di_arrivo.ContributoAmmesso = 0;
                //prichiesto_di_arrivo.Ammesso = false;
                if (!SPS.PagamentoA.InvestimentoMobile)  //investimento_di_arrivo.Mobile == null || !investimento_di_arrivo.Mobile)
                    prichiesto_di_arrivo.ImportoComputoMetrico = SPS.PagamentoA.ImportoComputoMetrico;
                prichiesto_di_arrivo.ImportoRichiesto = SPS.PagamentoA.ImportoRichiesto;
                prichiesto_di_arrivo.ContributoRichiesto = SPS.PagamentoA.ContributoRichiesto;
                prichiesti_provider.Save(prichiesto_di_arrivo);
                if (SPS.PagamentoA.IdPagamentoRichiesto < 1) SPS.PagamentoA.IdPagamentoRichiesto = prichiesto_di_arrivo.IdPagamentoRichiesto;

                // pagamenti beneficiario di partenza                
                SiarLibrary.PagamentiBeneficiarioCollection pben_partenza = pbeneficiario_provider.Find(prichiesto_di_partenza.IdPagamentoRichiesto, null,
                    null, null, null, null);
                foreach (PagamentiBeneficiarioJson pb in SPS.PagamentoDa.PB)
                {
                    if (pb.Modificato)
                    {
                        SiarLibrary.PagamentiBeneficiario pben = pben_partenza.CollectionGetById((int)pb.IdPagamentoBeneficiario);
                        pben.ImportoRichiesto = pb.ImportoRichiesto;
                        pben.ImportoAmmesso = 0;
                    }
                }
                pbeneficiario_provider.SaveCollection(pben_partenza);

                // pagamenti beneficiario di arrivo                
                SiarLibrary.PagamentiBeneficiarioCollection pben_arrivo = pbeneficiario_provider.Find(prichiesto_di_arrivo.IdPagamentoRichiesto, null,
                    null, null, null, null);
                // elimino quelli che non sono piu' presenti nel json, e' il caso dei pagamenti prima spostati in arrivo e poi annullati
                foreach (SiarLibrary.PagamentiBeneficiario pben in pben_arrivo)
                {
                    bool pagben_da_eliminare = true;
                    foreach (PagamentiBeneficiarioJson pb in SPS.PagamentoA.PB)
                        if (pb.IdPagamentoBeneficiario == (int)pben.IdPagamentoBeneficiario) { pagben_da_eliminare = false; break; }
                    if (pagben_da_eliminare) pben.MarkForDeletion();
                }
                pbeneficiario_provider.SaveCollection(pben_arrivo);

                // salvo i nuovi pagamenti beneficiario di arrivo
                decimal importo_spostato = 0;
                foreach (PagamentiBeneficiarioJson pb in SPS.PagamentoA.PB)
                {
                    if (pb.Modificato)
                    {
                        SiarLibrary.PagamentiBeneficiario pben;
                        bool nuovo_pben = false;
                        string id_string = pb.IdPagamentoBeneficiario.ToString(), id_originale_string = pb.IdPagBenOriginale.ToString() + "000";
                        if (id_string.StartsWith(id_originale_string) && id_string.Length == id_originale_string.Length + 4)
                        {
                            nuovo_pben = true;
                            pben = pbeneficiario_provider.GetById(pb.IdPagBenOriginale);
                            pben.MarkAsNew();
                            pben.IdPagamentoBeneficiario = null;
                            pben.IdPagamentoRichiesto = prichiesto_di_arrivo.IdPagamentoRichiesto;
                            pben.CodRiduzione = pben.CodRiduzioneContr = null;
                            pben.MotivazioneRiduzione = pben.MotivazioneRiduzioneContr = null;
                        }
                        else pben = pben_arrivo.CollectionGetById((int)pb.IdPagamentoBeneficiario);
                        pben.ImportoRichiesto = pb.ImportoRichiesto;
                        importo_spostato += pb.ImportoSpostato;
                        pben.ImportoAmmesso = 0;
                        pbeneficiario_provider.Save(pben);
                        if (nuovo_pben) pb.IdPagamentoBeneficiario = pben.IdPagamentoBeneficiario;
                    }
                }

                if (spostamento_selezionato == null)
                {
                    spostamento_selezionato = new SiarLibrary.CorrettivaRendicontazioneSpostamenti();
                    spostamento_selezionato.IdCorrettiva = correttiva_selezionata.Id;
                    spostamento_selezionato.IdInvestimentoDa = SPS.PagamentoDa.IdInvestimento;
                    spostamento_selezionato.IdInvestimentoA = SPS.PagamentoA.IdInvestimento;
                }
                spostamento_selezionato.ImportoSpostato = importo_spostato;
                spostamento_selezionato.Concluso = chiudi_spostamento;
                spostamento_selezionato.IdUtente = Operatore.Utente.IdUtente;
                spostamento_selezionato.Data = DateTime.Now;
                spostamento_selezionato.Descrizione = txtDescrizioneSpostamento.Text;
                spostamenti_provider.Save(spostamento_selezionato);
                if (SPS.IdSpostamento < 1) SPS.IdSpostamento = spostamento_selezionato.Id;

                SiarBLL.NoteCollectionProvider note_provider = new SiarBLL.NoteCollectionProvider(PagamentoProvider.DbProviderObj);
                SiarLibrary.Note json_log;
                if (spostamento_selezionato.IdJsonLog != null) json_log = note_provider.GetById(spostamento_selezionato.IdJsonLog);
                else json_log = new SiarLibrary.Note();
                json_log.Testo = jsser.Serialize(SPS);
                note_provider.Save(json_log);

                if (spostamento_selezionato.IdJsonLog == null)
                {
                    spostamento_selezionato.IdJsonLog = json_log.Id;
                    spostamenti_provider.Save(spostamento_selezionato);
                }

                correttiva_selezionata.Data = DateTime.Now;
                correttiva_selezionata.IdUtente = Operatore.Utente.IdUtente;
                correttiva_selezionata.Conclusa = chiudi_spostamento;
                correttiva_provider.Save(correttiva_selezionata);

                PagamentoProvider.DbProviderObj.Commit();
            }
            catch (Exception ex) { PagamentoProvider.DbProviderObj.Rollback(); throw ex; }
        }

        private void controllaImportiPagamento(ref PagamentiJson pj)
        {
            SiarLibrary.PianoInvestimenti _investimento = investimenti_provider.GetById(pj.IdInvestimento);
            if (_investimento == null) throw new Exception("Almeno uno dei due investimenti selezionati non è valido.");
            decimal importo_investimento = pj.ImportoFatture, importo_spese_tecniche = pj.ImportoSpeseTecnicheRichieste, importo_lavori_in_economia = 0;
            if (!pj.InvestimentoMobile && pj.ImportoFatture > pj.ImportoComputoMetrico) importo_investimento = pj.ImportoComputoMetrico;

            // suddivido il contributo tra costo investimento e spese tecniche (mutuo 112 niente spese tecniche)
            decimal contributo_spese_tecniche_richiesto = 0;
            if (_investimento.SpeseGenerali != null && importo_spese_tecniche > _investimento.SpeseGenerali) importo_spese_tecniche = _investimento.SpeseGenerali;
            if (_investimento.CodTipoInvestimento != 2 && _investimento.QuotaSpeseGenerali != null && _investimento.QuotaSpeseGenerali > 0)
            {
                decimal max_spese_tecniche_investimento = (_investimento.CostoInvestimento * _investimento.QuotaSpeseGenerali / 100);
                if (importo_spese_tecniche > max_spese_tecniche_investimento) importo_spese_tecniche = max_spese_tecniche_investimento;
                contributo_spese_tecniche_richiesto = Math.Round(importo_spese_tecniche * _investimento.QuotaContributoRichiesto / 100, 2, MidpointRounding.AwayFromZero);
            }
            // tronco l'importo su cui calcolare il contributo per evitare che prenda anche la capienza delle spese tecniche
            if (importo_investimento > _investimento.CostoInvestimento) importo_investimento = _investimento.CostoInvestimento;
            decimal contributo_costo_investimento_calcolato = Math.Round(importo_investimento * _investimento.QuotaContributoRichiesto / 100, 2, MidpointRounding.AwayFromZero);
            decimal contributo_calcolato = contributo_costo_investimento_calcolato + contributo_spese_tecniche_richiesto;

            // controllo il disponibile per l'investimento
            decimal contributo_disponibile = _investimento.ContributoRichiesto.Value - SiarLibrary.DbStaticProvider.GetAmmontareErogatoInvestimento(
                _investimento.IdInvestimento, DomandaPagamento.IdDomandaPagamento, PagamentoProvider.DbProviderObj);
            if (contributo_disponibile < 0) contributo_disponibile = 0;
            if (contributo_calcolato > contributo_disponibile) contributo_calcolato = contributo_disponibile;
            if (contributo_calcolato > 0)
            {
                //controllo disponibile di progetto correlato 
                decimal contributo_disponibile_domanda = PagamentoProvider.CalcoloContributoRichiestoDisponibilePagamento(_investimento.IdProgetto,
                    DomandaPagamento.IdDomandaPagamento, _investimento.CodTipoInvestimento, pj.IdPagamentoRichiesto);
                if (contributo_calcolato > contributo_disponibile_domanda) contributo_calcolato = contributo_disponibile_domanda;
            }

            // controllo quota dei lavori in economia (contributo richiesto<=importo_computo_metrico-importo lav in economia)
            foreach (PagamentiBeneficiarioJson pb in pj.PB) if (pb.LavoriInEconomia) importo_lavori_in_economia += pb.ImportoRichiesto;
            if (importo_lavori_in_economia > 0)
            {
                //L`ammontare dei lavori in economia è maggiore della differenza tra importo da computo metrico e contributo. Impossibile continuare.
                decimal importo_fatturato_effettivo = importo_investimento + importo_spese_tecniche - importo_lavori_in_economia;
                if (contributo_calcolato > importo_fatturato_effettivo) contributo_calcolato = importo_fatturato_effettivo;
                if (contributo_calcolato < 0) contributo_calcolato = 0;
            }
            pj.ContributoRichiesto = contributo_calcolato;
        }
    }
}