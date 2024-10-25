using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace web.Private.IPagamento
{
    public partial class IstruttoriaFidejussione : SiarLibrary.Web.IstruttoriaPagamentoPage
    {
        SiarLibrary.Fidejussioni fidejussione;
        SiarBLL.FidejussioniCollectionProvider fprovider;
        SiarBLL.DomandaPagamentoFidejussioneCollectionProvider dompag_fidej_prov = new SiarBLL.DomandaPagamentoFidejussioneCollectionProvider();
        SiarBLL.DomandaPagamentoFidejussioneImpresaCollectionProvider dompag_fidej_imp_prov = new SiarBLL.DomandaPagamentoFidejussioneImpresaCollectionProvider();
        SiarLibrary.DomandaPagamentoFidejussione testa_fidej = null;
        SiarLibrary.DomandaPagamentoFidejussioneImpresa impresa_fidej = null;
        SiarBLL.ImpresaCollectionProvider impresa_prov = new SiarBLL.ImpresaCollectionProvider();
        SiarLibrary.Impresa impresa_selezionata = null;
        bool boolAggregazione = false;
        decimal ammontare_richiesto, ammontare_garantito;
        SiarBLL.AggregazioneCollectionProvider aggregazione_prov = new SiarBLL.AggregazioneCollectionProvider();


        protected void Page_Load(object sender, EventArgs e)
        {
            fprovider = new SiarBLL.FidejussioniCollectionProvider(PagamentoProvider.DbProviderObj);
            if (DomandaPagamento.IdFidejussione != null) testa_fidej = dompag_fidej_prov.GetById(DomandaPagamento.IdFidejussione);
            if (testa_fidej == null) Redirect("CheckListPagamento.aspx", "La Domanda di Pagamento in oggetto non ha polizze fidejussorie da convalidare.", true);
            int id_impresa;

            SiarLibrary.Bando bando = null;
            SiarBLL.BandoCollectionProvider bando_prov = new SiarBLL.BandoCollectionProvider();
            bando = bando_prov.GetById(Progetto.IdBando);
            if (bando.Aggregazione)
            {
                SiarBLL.ProgettoNaturaSoggettoCollectionProvider natura_sogg_prov = new SiarBLL.ProgettoNaturaSoggettoCollectionProvider();
                SiarLibrary.ProgettoNaturaSoggettoCollection natura_coll = natura_sogg_prov.Find(Progetto.IdProgetto, null, null);
                if (natura_coll[0].TipoNaturaSoggetto == "Aggregata")
                    boolAggregazione = true;
                else
                    boolAggregazione = false;
            }
            else
                boolAggregazione = aggregazione_prov.VerificaAggregazione(Progetto.IdProgetto);
            if (boolAggregazione)
            {
                if (int.TryParse(hdnIdImpresa.Value, out id_impresa))
                {
                    impresa_selezionata = impresa_prov.GetById(id_impresa);
                    if (testa_fidej != null)
                    {
                        SiarLibrary.DomandaPagamentoFidejussioneImpresaCollection imp_fid_coll = dompag_fidej_imp_prov.Find(testa_fidej.IdDomandaPagamentoFidejussione, DomandaPagamento.IdDomandaPagamento, DomandaPagamento.IdProgetto, id_impresa);
                        if (imp_fid_coll.Count > 0)
                        {
                            impresa_fidej = imp_fid_coll[0];
                        }
                    }
                }
            }
            else
            {
                hdnIdImpresa.Value = Progetto.IdImpresa.ToString();
                impresa_selezionata = impresa_prov.GetById(Progetto.IdImpresa);
                if (testa_fidej != null)
                {
                    SiarLibrary.DomandaPagamentoFidejussioneImpresaCollection imp_fid_coll = dompag_fidej_imp_prov.Find(testa_fidej.IdDomandaPagamentoFidejussione, DomandaPagamento.IdDomandaPagamento, DomandaPagamento.IdProgetto, null);
                    if (imp_fid_coll.Count > 0)
                    {
                        impresa_fidej = imp_fid_coll[0];
                    }
                }
            }

        }

        protected override void OnPreRender(EventArgs e)
        {
            if (Request.QueryString["redir"] == "revisione") btnBack.Attributes["onclick"] = "location='Revisionedomande.aspx?&idpag="
                + DomandaPagamento.IdDomandaPagamento + "'";
            SiarLibrary.DbStaticProvider.CalcolaImportoGarantitoFidejussione(DomandaPagamento.IdDomandaPagamento, out ammontare_garantito, out ammontare_richiesto,
                    PagamentoProvider.DbProviderObj);


            if (boolAggregazione)
            {
                SiarLibrary.ImpresaCollection imp_coll = new SiarLibrary.ImpresaCollection();
                SiarLibrary.DomandaPagamentoFidejussioneImpresaCollection imp_fidej_coll = dompag_fidej_imp_prov.Find(testa_fidej.IdDomandaPagamentoFidejussione, DomandaPagamento.IdDomandaPagamento, Progetto.IdProgetto, null);
                foreach(SiarLibrary.DomandaPagamentoFidejussioneImpresa imp_fidej in imp_fidej_coll)
                {
                    SiarLibrary.Impresa i = impresa_prov.GetById(imp_fidej.IdImpresa);
                    imp_coll.Add(i);
                }
                dgImprese.DataSource = imp_coll;
                dgImprese.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgImprese_ItemDataBound);
                dgImprese.DataBind();

                txtImportoTotaleGarantito.Text = string.Format("{0:N}", Math.Round(ammontare_richiesto, 2, MidpointRounding.AwayFromZero));
                txtImportoTotale.Text = string.Format("{0:N}", Math.Round(ammontare_garantito, 2, MidpointRounding.AwayFromZero));
                if (impresa_selezionata != null)
                {
                    if (impresa_fidej.Esente)
                    {
                        tbEsente.Visible = true;
                        tbNoAnticipo.Visible = false;
                        tbFidejussione.Visible = false;
                    }
                    else if (impresa_fidej.NoAnticipo)
                    {
                        tbEsente.Visible = false;
                        tbNoAnticipo.Visible = true;
                        tbFidejussione.Visible = false;
                    }
                    else
                    {
                        tbFidejussione.Visible = true;
                        tbNoAnticipo.Visible = false;
                        tbEsente.Visible = false;
                    }
                    tbImprea.Visible = true;
                    txtImpresaSelezionata.Text = impresa_selezionata.RagioneSociale;
                    txtPartitaIvaImpresaSelezionata.Text = impresa_selezionata.Cuaa;
                }
                else
                {
                    tbFidejussione.Visible = false;
                    tbEsente.Visible = false;
                    tbNoAnticipo.Visible = false;
                }
            }
            else
            {

                tbElencoImprese.Visible = false;
                tbImprea.Visible = false;
                if (impresa_fidej.Esente)
                {
                    tbEsente.Visible = true;
                    tbNoAnticipo.Visible = false;
                    tbFidejussione.Visible = false;
                }
                else if (impresa_fidej.NoAnticipo)
                {
                    tbEsente.Visible = false;
                    tbNoAnticipo.Visible = true;
                    tbFidejussione.Visible = false;
                }
                else
                {
                    tbFidejussione.Visible = true;
                    tbNoAnticipo.Visible = false;
                    tbEsente.Visible = false;
                }
            }

            bindControlli();
            base.OnPreRender(e);
        }


        decimal importo_anticipo_tot = 0;
        void dgImprese_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.Impresa impresa = (SiarLibrary.Impresa)e.Item.DataItem;
                SiarLibrary.DomandaPagamentoFidejussioneCollection fidej_coll = dompag_fidej_prov.Find(DomandaPagamento.IdDomandaPagamento, DomandaPagamento.IdProgetto);
                if (fidej_coll.Count > 0)
                {
                    SiarLibrary.DomandaPagamentoFidejussioneImpresaCollection imp_fid_coll = dompag_fidej_imp_prov.Find(fidej_coll[0].IdDomandaPagamentoFidejussione, DomandaPagamento.IdDomandaPagamento, DomandaPagamento.IdProgetto, impresa.IdImpresa);
                    if (imp_fid_coll.Count > 0)
                    {
                        importo_anticipo_tot += imp_fid_coll[0].AmmontareRichiesto;
                        if (imp_fid_coll[0].Esente)
                            e.Item.Cells[3].Text = "ESENTE";
                        else if (imp_fid_coll[0].NoAnticipo)
                            e.Item.Cells[3].Text = "NON RICHIEDENTE ANTICIPO";
                        else
                            e.Item.Cells[3].Text = string.Format("{0:c}", imp_fid_coll[0].AmmontareRichiesto);
                    }
                    else
                        e.Item.Cells[3].Text = string.Format("{0:c}", 0);
                }
                else
                    e.Item.Cells[3].Text = string.Format("{0:c}", 0);



                //SiarLibrary.ContrattiFemCollection contratti_fem = new SiarBLL.ContrattiFemCollectionProvider().Find(p.IdBando, p.IdProgetto);
                //if (contratti_fem.Count > 0)
                //{
                //    if (contratti_fem[0].Segnatura != null)
                //        e.Item.Cells[3].Text = contratti_fem[0].Segnatura;
                //}
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[3].Text = string.Format("{0:c}", importo_anticipo_tot);
            }
        }

        protected void btnSelezionaImpresa_Click(object sender, EventArgs e)
        { }



        private void bindControlli()
        {
            
            
            trLuogo.Visible = true;
            trDatiHeader.Visible = true;
            trDatiBody.Visible = true;
            

            if (impresa_fidej != null)
            {
                txtCF.AddJSAttribute("onblur", "return ctrlCF(this,ctrlCodiceFiscale,event);");
                txtPiva.AddJSAttribute("onblur", "return ctrlCF(this,ctrlPIVA,event);");
                txtLuogo.Text = impresa_fidej.LuogoSottoscrizione;
                txtPiva.Text = impresa_fidej.PivaGarante;
                txtDenominazione.Text = impresa_fidej.RagioneSocialeGarante;
                txtLocalita.Text = impresa_fidej.LocalitaGarante;
                txtNumeroRegistro.Text = impresa_fidej.NumeroRegistroImprese;
                txtCognome.Text = impresa_fidej.CognomeRapplegale;
                txtNome.Text = impresa_fidej.NomeRapplegale;
                txtDataNascita.Text = impresa_fidej.DataNascitaRapplegale;
                txtCF.Text = impresa_fidej.CfRapplegale;
                txtNumero.Text = impresa_fidej.Numero;
                txtDataSottoscrizione.Text = impresa_fidej.DataSottoscrizione;
                txtAmmontareRichiesto.Text = impresa_fidej.AmmontareRichiesto;
                txtImporto.Text = impresa_fidej.Importo;
                txtDataFineLavori.Text = impresa_fidej.DataFineLavori;
                txtDataScadenza.Text = impresa_fidej.DataScadenza;
            }
        }

        //protected void btnConvalida_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        PagamentoProvider.DbProviderObj.BeginTran();
        //        if (fidejussione.CodTipo == "F3G")
        //        {
        //            if (string.IsNullOrEmpty(txtNumero.Text) || string.IsNullOrEmpty(txtDataSottoscrizione.Text))
        //                throw new Exception("Specificare il numero e la data della delibera dell`ente.");
        //            fidejussione.DataRicevimentoValidita = DateTime.Now;
        //            fidejussione.Numero = txtNumero.Text;
        //            fidejussione.DataSottoscrizione = txtDataSottoscrizione.Text;
        //        }
        //        else
        //        {
        //            fidejussione.DataRichiestaValidita = txtDataRichiestaConferma.Text;
        //            fidejussione.DataRicevimentoValidita = txtDataRicevimentoConferma.Text;
        //            fidejussione.ProtocolloFaxValidita = txtProtocolloRicevimento.Text;
        //            fidejussione.DataDecorrenzaGaranzia = txtDataDecorrenza.Text;
        //            fidejussione.CodiceAbiEnteGarante = txtAbi.Text;
        //            fidejussione.CodiceCabEnteGarante = txtCab.Text;
        //        }
        //        fprovider.Save(fidejussione);
        //        PagamentoProvider.AggiornaDomandaDiPagamentoIstruttore(DomandaPagamento, Operatore);
        //        PagamentoProvider.DbProviderObj.Commit();
        //        ShowMessage("Dati di conferma della convalida salvati correttamente.");
        //    }
        //    catch (Exception ex) { PagamentoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        //}

        protected void btnStampa_Click(object sender, EventArgs e)
        {
            try
            {
                if (new SiarBLL.CollaboratoriXBandoCollectionProvider().Find(Bando.IdBando, Progetto.IdProgetto, Operatore.Utente.IdUtente, null, true).Count > 0)
                {
                    testa_fidej.OperatoreIstruttore = Operatore.Utente.IdUtente;
                    testa_fidej.DataModificaIstruttore = DateTime.Today;
                    dompag_fidej_prov.Save(testa_fidej);
                }
                RegisterClientScriptBlock("SNCVisualizzaReport('rptRichiestaValiditaGaranziaImpresa',1,'IdDomandaPagamento=" + DomandaPagamento.IdDomandaPagamento + "|IdImpresa=" + impresa_fidej.IdImpresa + "');");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                
                PagamentoProvider.DbProviderObj.BeginTran();
                impresa_fidej.AmmontareRichiesto = txtAmmontareRichiesto.Text;
                impresa_fidej.Importo = txtImporto.Text;
                impresa_fidej.DataFineLavori = txtDataFineLavori.Text;
                impresa_fidej.DataScadenza = txtDataScadenza.Text;
                impresa_fidej.Numero = txtNumero.Text;
                impresa_fidej.DataSottoscrizione = txtDataSottoscrizione.Text;
                impresa_fidej.LuogoSottoscrizione = txtLuogo.Text;
                impresa_fidej.PivaGarante = txtPiva.Text;
                impresa_fidej.RagioneSocialeGarante = txtDenominazione.Text;
                impresa_fidej.LocalitaGarante = txtLocalita.Text;
                impresa_fidej.NumeroRegistroImprese = txtNumeroRegistro.Text;
                impresa_fidej.CognomeRapplegale = txtCognome.Text;
                impresa_fidej.NomeRapplegale = txtNome.Text;
                impresa_fidej.DataNascitaRapplegale = txtDataNascita.Text;
                impresa_fidej.CfRapplegale = txtCF.Text;
                dompag_fidej_imp_prov.Save(impresa_fidej);

                testa_fidej.OperatoreIstruttore = Operatore.Utente.IdUtente;
                testa_fidej.DataModificaIstruttore = DateTime.Today;
                dompag_fidej_prov.Save(testa_fidej);

                PagamentoProvider.AggiornaDomandaDiPagamentoIstruttore(DomandaPagamento, Operatore);
                PagamentoProvider.DbProviderObj.Commit();
                ShowMessage("Dati di dettaglio della fidejussione salvati correttamente.");
            }
            catch (Exception ex) { PagamentoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        //protected void btnSalvaDatiApprovazione_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int num_atto;
        //        if (fidejussione.CodTipo != "F3G") throw new Exception("Operazione non valida per il tipo di Polizza");
        //        if (!int.TryParse(txtNumAttoApprovazioneProgetto.Text, out num_atto))
        //            throw new Exception("Attenzione! Selezionare tutti i dati richiesti per l'approvazione della domanda.");
        //        if (string.IsNullOrEmpty(txtUfficioApprovazioneProgetto.Text) || string.IsNullOrEmpty(txtNumAttoApprovazioneProgetto.Text)
        //            || string.IsNullOrEmpty(txtDataAttoApprovazioneProgetto.Text))
        //            throw new Exception("Attenzione! Selezionare tutti i dati richiesti per l'approvazione della domanda.");
        //        PagamentoProvider.DbProviderObj.BeginTran();
        //        fidejussione.DataDecretoApprovazione = txtDataAttoApprovazioneProgetto.Text;
        //        fidejussione.NumDecretoApprovazione = num_atto;
        //        fidejussione.UfficioApprovazione = txtUfficioApprovazioneProgetto.Text;
        //        fprovider.Save(fidejussione);
        //        PagamentoProvider.AggiornaDomandaDiPagamentoIstruttore(DomandaPagamento, Operatore);
        //        PagamentoProvider.DbProviderObj.Commit();
        //        ShowMessage("Dati di approvazione della domanda salvati correttamente.");

        //    }
        //    catch (Exception ex) { PagamentoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        //}
    }
}