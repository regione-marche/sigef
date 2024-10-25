using System;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;

namespace web.Private.PPagamento
{
    public partial class PagamentoInvestimento : SiarLibrary.Web.DomandaPagamentoPage
    {
        decimal importo_investimento_richiesto = 0, importo_spese_richieste = 0, importo_investimento_ammesso = 0,
            importo_spese_ammesse = 0;
        SiarLibrary.PianoInvestimenti _investimento;
        SiarLibrary.PagamentiRichiesti prichiesto;
        SiarLibrary.PagamentiBeneficiarioCollection pbeneficiario_attuali;
        SiarBLL.PagamentiRichiestiCollectionProvider prichiesti_provider;
        SiarBLL.PagamentiBeneficiarioCollectionProvider pbeneficiario_provider;
        bool AltreFonti;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.VworkflowPagamentoCollection workflow = new SiarBLL.VworkflowPagamentoCollectionProvider().Find(null, "PINVE", null, null);
                ucWorkflowPagamento.WorkflowCorrente = workflow[0];
                ucWorkflowPagamento.ProseguiUrl = workflow[0].Url;
                prichiesti_provider = new SiarBLL.PagamentiRichiestiCollectionProvider(PagamentoProvider.DbProviderObj);
                pbeneficiario_provider = new SiarBLL.PagamentiBeneficiarioCollectionProvider(PagamentoProvider.DbProviderObj);
                ucZoomLoaderGiustificativiPagati.KeySearch += "|IdDomandaPagamento:" + DomandaPagamento.IdDomandaPagamento + ":h";
                int id_investimento = 0;
                if (int.TryParse(Request.QueryString["idinv"], out id_investimento))
                    _investimento = new SiarBLL.PianoInvestimentiCollectionProvider().GetById(id_investimento);
                if (_investimento == null) throw new Exception("L'investimento selezionato non è valido.");
                ctrlSessione();
                if (_investimento.CodTipoInvestimento == 2 && _investimento.CostoInvestimento > 0) //vedi nota (*)
                    _investimento.QuotaContributoRichiesto = Math.Round(100 * _investimento.ContributoRichiesto / _investimento.CostoInvestimento, 2, MidpointRounding.AwayFromZero);
                AbilitaModifica = AbilitaModifica && DomandaPagamento.IdFidejussione == null;
                imgDettaglioInvestimento.Attributes.Add("onclick", "SNCVisualizzaReport('rptInvestimentoOriginale',1,'IdInvestimento="
                    + _investimento.IdInvestimento + "');");

                if (DomandaPagamento.TpAppaltoStrumentiFinanziari)
                    AltreFonti = true;
                else
                    AltreFonti = false;

                if (AltreFonti)
                {
                    tdRichiestoAltreFonti.Visible = true;
                    tdAmmessoAltreFonti.Visible = true;
                }
                else
                {
                    tdRichiestoAltreFonti.Visible = false;
                    tdAmmessoAltreFonti.Visible = false;
                }

                if (DomandaPagamento.InIntegrazione != null && DomandaPagamento.InIntegrazione)
                    ucWorkflowPagamento.InIntegrazione = true;
            }
            catch (Exception ex) { Redirect("PianoInvestimenti.aspx", ex.Message, true); }
        }

        private void ctrlSessione()
        {
            if (_investimento.IdProgetto != Progetto.IdProgetto)
            {
                SiarLibrary.Progetto p = new SiarBLL.ProgettoCollectionProvider().GetById(_investimento.IdProgetto);
                if (p == null || p.IdProgIntegrato != Progetto.IdProgetto) throw new Exception("L'investimento selezionato non è valido.");
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            SiarLibrary.PagamentiRichiestiCollection prichiesti = prichiesti_provider.Find(null, _investimento.IdInvestimento, null, DomandaPagamento.IdDomandaPagamento);
            if (prichiesti.Count > 0) prichiesto = prichiesti[0];
            if (prichiesto != null)
            {
                pbeneficiario_attuali = pbeneficiario_provider.Find(prichiesto.IdPagamentoRichiesto, null, null, null, null, null);
                dgPagamenti.DataSource = pbeneficiario_attuali;
                lblNumeroPagamenti.Text = pbeneficiario_attuali.Count.ToString();
                dgPagamenti.ItemDataBound += new DataGridItemEventHandler(dgPagamenti_ItemDataBound);

                bool in_integrazione = false;
                foreach (SiarLibrary.PagamentiBeneficiario pag in pbeneficiario_attuali)
                {
                    var giustificativo = new SiarBLL.GiustificativiCollectionProvider().GetById(pag.IdGiustificativo);
                    if (giustificativo != null && giustificativo.InIntegrazione != null && giustificativo.InIntegrazione)
                    {
                        in_integrazione = true;
                        break;
                    }
                }

                if (in_integrazione)
                    dgPagamenti.Columns[10].Visible = true;
                else
                    dgPagamenti.Columns[10].Visible = false;
            }
            else
            {
                dgPagamenti.Titolo = "Pagamento non ancora richiesto.";
                lblNumeroPagamenti.Text = "0";
            }
            dgPagamenti.DataBind();
            popolaInvestimento();
            if ((AbilitaModifica && TipoModifica == 2) || (DomandaPagamento.InIntegrazione != null && DomandaPagamento.InIntegrazione))
            {
                lnkNuovoGiustificativo.HRef = "javascript:" + ucZoomLoaderGiustificativiPagati.SearchFunction;
                lnkLavoroInEconomia.HRef = "javascript:mostraPopupLavoriInEconomia();";
            }
            else
            {
                lnkNuovoGiustificativo.HRef = "javascript:alert('Modifica della domanda di pagamento disabilitata.');";
                lnkLavoroInEconomia.HRef = "javascript:alert('Modifica della domanda di pagamento disabilitata.');";
            }
            if (prichiesto != null && prichiesto.Ammesso && DomandaPagamento.Approvata != null)
            {
                tableValutazione.Visible = true;
                txtValutazioneLunga.Text = prichiesto.NoteIstruttore;
            }

            base.OnPreRender(e);
        }

        decimal tot_imponibile = 0, tot_Importo_richiesto = 0, tot_contributo_richiesto = 0, tot_importo_ammesso = 0, tot_contributo_ammesso = 0;

        void dgPagamenti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType == ListItemType.Header)
            {
                dgi.Cells[0].RowSpan = 2;
                dgi.Cells[1].ColumnSpan = 3;
                dgi.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                dgi.Cells[1].Text += "GIUSTIFICATIVO</th><th colspan=3 align=center>PAGAMENTO RICHIESTO</th><th align=center colspan=2>PAGAMENTO AMMESSO</th><th colspan=2></th></tr><tr class=TESTA><th>Riferimenti";
            }
            else if (e.Item.ItemType != ListItemType.Footer)
            {
                SiarLibrary.PagamentiBeneficiario pag = (SiarLibrary.PagamentiBeneficiario)dgi.DataItem;
                //if (pag.CostituisceVariante) dgi.Cells[6].Text = "(V)";
                if (pag.LavoriInEconomia) dgi.Cells[1].Text = "<b>Tipo:</b> " + pag.TipoGiustificativo + " <BR /><b>Descrizione:</b> " + pag.Descrizione;
                else
                {
                    // visualizzo il dettaglio solo se giustificativo reale e non lavori in economia
                    dgi.Cells[1].Text = "<b>Tipo:</b> " + pag.TipoGiustificativo + " nr. " + pag.Numero + " data: " + pag.Data
                       + "<BR /><b>D.D.T:</b> nr." + pag.NumeroDoctrasporto + " data: " + pag.DataDoctrasporto
                       + " <BR /><b>Oggetto spesa:</b> " + pag.Descrizione;
                                                               
                    dgi.Cells[2].Text = "<svg class='icon icon-secondary me-1' aria-hidden='true' src='../../images/acrobat.gif' alt='Visualizza documento' title='Visualizza documento'"
                          + "style='cursor:pointer' onclick=\"" + (pag.IdFile == null ? "SNCVisualizzaReport('rptGiustificativo',1,'IdGiustificativo=" + pag.IdGiustificativo + "');"
                        : "SNCUFVisualizzaFile(" + pag.IdFile + ");") + "\"><use href='/web/bootstrap-italia/svg/sprites.svg#it-file-pdf-ext'></use></svg>";
                }

                if (pag.SpesaTecnicaRichiesta) importo_spese_richieste += pag.ImportoRichiesto;
                else importo_investimento_richiesto += pag.ImportoRichiesto;
                if (pag.ImportoAmmesso != null)
                {
                    //totale 
                    tot_importo_ammesso += pag.ImportoAmmesso;

                    if (pag.SpesaTecnicaAmmessa != null && pag.SpesaTecnicaAmmessa) importo_spese_ammesse += pag.ImportoAmmesso;
                    else importo_investimento_ammesso += pag.ImportoAmmesso;
                    decimal contributo_ammesso = Math.Round(pag.ImportoAmmesso.Value * _investimento.QuotaContributoRichiesto.Value / 100, 2, MidpointRounding.AwayFromZero);
                    if (pag.ContributoAmmesso == null)
                    {
                        dgi.Cells[8].Text = string.Format("{0:c}", contributo_ammesso);
                        tot_contributo_ammesso += contributo_ammesso;
                    }
                    else
                        tot_contributo_ammesso += pag.ContributoAmmesso;
                }

                decimal contributo_calcolato = Math.Round(pag.ImportoRichiesto.Value * _investimento.QuotaContributoRichiesto.Value / 100, 2, MidpointRounding.AwayFromZero);
                dgi.Cells[5].Text = string.Format("{0:c}", contributo_calcolato);

                //CheckBox chkRichiesta = new CheckBox(), chkAmmessa = new CheckBox();
                //chkRichiesta.ID = "chkSpesaTecnicaRichiesta" + pag.IdPagamentoBeneficiario;
                //chkRichiesta.Checked = pag.SpesaTecnicaRichiesta;
                //chkRichiesta.Enabled = false;
                //dgi.Cells[6].Controls.Add(chkRichiesta);
                //chkAmmessa.ID = "chkSpesaTecnicaAmmessa" + pag.IdPagamentoBeneficiario;
                //chkAmmessa.Checked = (pag.SpesaTecnicaAmmessa != null && pag.SpesaTecnicaAmmessa);
                //chkAmmessa.Enabled = false;
                //dgi.Cells[10].Controls.Add(chkAmmessa);
                dgi.Cells[9].Text = "<input type='button' class='btn btn-secondary py-1' onclick=\"mostraPagamento("
                    + pag.IdPagamentoBeneficiario + ")\" value='" + (AbilitaModifica && TipoModifica == 2 ? "Modifica" : "Visualizza") + "' />";

                var giustificativo = new SiarBLL.GiustificativiCollectionProvider().GetById(pag.IdGiustificativo);
                if (giustificativo != null && (giustificativo.InIntegrazione == null || !giustificativo.InIntegrazione))
                    dgi.Cells[10].Text = "";

                //calcolo totali
                tot_imponibile += pag.Imponibile;
                tot_Importo_richiesto += pag.ImportoRichiesto;
                tot_contributo_richiesto += contributo_calcolato;
            }
            else
            {
                e.Item.Cells[3].Text = string.Format("{0:c}", tot_imponibile);
                e.Item.Cells[4].Text = string.Format("{0:c}", tot_Importo_richiesto);
                e.Item.Cells[5].Text = string.Format("{0:c}", tot_contributo_richiesto);
                e.Item.Cells[7].Text = string.Format("{0:c}", tot_importo_ammesso);
                e.Item.Cells[8].Text = string.Format("{0:c}", tot_contributo_ammesso);
            }
        }

        private void popolaInvestimento()
        {
            // investimento
            //if (_investimento.IdPrioritaSettoriale != null)
            //    tbInvestimento.Rows[0].Cells[1].InnerHtml += "<img src='../../images/star_red.gif' />";
            if (_investimento.CodVariazione != null)
            {
                //tbInvestimento.Rows[0].Cells[2].InnerHtml += "<b>(" + _investimento.CodVariazione + ")</b>";
                lblVariazione.Text = _investimento.CodVariazione;
            }
            else
                lblVariazione.Text = "nessuna";
            SiarLibrary.Zprogrammazione intervento = new SiarBLL.ZprogrammazioneCollectionProvider().GetById(_investimento.IdProgrammazione);
            //tbInvestimento.Rows[0].Cells[3].InnerHtml = "<b>Intervento " + intervento.Codice + "</b>";
            lblIntervento.Text = intervento.Codice;
            //if (_investimento.SettoreProduttivo != null) tbInvestimento.Rows[1].Cells[0].InnerHtml += "<b>Settore produttivo: </b>"
            //    + _investimento.SettoreProduttivo.ToString().ToUpper();
            //tbInvestimento.Rows[2].Cells[0].InnerHtml = "<b>Codifica: </b>" + _investimento.CodificaInvestimento;
            lblCodifica.Text = _investimento.CodificaInvestimento;
            //tbInvestimento.Rows[3].Cells[0].InnerHtml = "<b>Dettaglio: </b>" + _investimento.DettaglioInvestimenti;
            lblDettaglio.Text  = _investimento.DettaglioInvestimenti;
            //tbInvestimento.Rows[4].Cells[0].InnerHtml = "<b>Descrizione: </b>" + _investimento.Descrizione;
            lblDescrizione.Text = _investimento.Descrizione;

            if (_investimento.IdImpresaAggregazione != null)
            {
                SiarLibrary.Impresa impresa_aggr = new SiarBLL.ImpresaCollectionProvider().GetById(_investimento.IdImpresaAggregazione);
                //tbInvestimento.Rows[5].Cells[0].InnerHtml = "<b>Impresa: </b>" + impresa_aggr.RagioneSociale + " - " + impresa_aggr.CodiceFiscale;
                investimentoAggregazione.Visible = true;
                lblImpresaInvestimento.Text = impresa_aggr.RagioneSociale + " - " + impresa_aggr.CodiceFiscale;
            }

            //personalizzazione bando ID 39 -  6.2
            //if (Progetto.IdBando == 39)
            //{
            //    string linea_intervento = "";
            //    linea_intervento = new SiarBLL.PianoInvestimentiCollectionProvider().GetLineaInterventoInvestimento(_investimento.IdInvestimento);
            //    if (linea_intervento != null && linea_intervento != "")
            //        tbInvestimento.Rows[6].Cells[0].InnerHtml = "<b>" + linea_intervento+ "</b>";
            //}
            
            lblSpeseTecniche.Text = "Spese tecniche:";

            txtCostoInvestimento.Text = _investimento.CostoInvestimento;
            txtSpeseTecniche.Text = _investimento.SpeseGenerali;
            if (_investimento.CodTipoInvestimento == 2)
            {
                lblSpeseTecniche.Text = "Ammontare del mutuo:";
                txtCostoInvestimento.Text = _investimento.SpeseGenerali;
                txtSpeseTecniche.Text = _investimento.CostoInvestimento;
                lblFormulaCompletamento.Text = "(C/B)";
            }
            txtContributoAmmesso.Text = _investimento.ContributoRichiesto;
            txtQuotaAiuto.Text = _investimento.QuotaContributoRichiesto;
            //if (_investimento.Mobile == null || _investimento.Mobile) txtImportoComputoMetrico.ReadOnly = true;
            //else btnSalva.OnClientClick = "if(document.getElementById('ctl00_cphContenuto_txtImportoComputoMetrico_text').value==''){alert(\'Importo computo metrico obbligatorio.\');return stopEvent(event);}";

            //totali richiesti fino ad ora
            decimal storico_contributo_richiesto = SiarLibrary.DbStaticProvider.GetStoricoContributoRichiestoInvestimento(_investimento.IdInvestimento,
                DomandaPagamento.IdDomandaPagamento, PagamentoProvider.DbProviderObj),
                storico_importo_richiesto = SiarLibrary.DbStaticProvider.GetStoricoImportoRichiestoInvestimento(_investimento.IdInvestimento,
                DomandaPagamento.IdDomandaPagamento, PagamentoProvider.DbProviderObj);
            txtStoricoContributoRichiesto.Text = string.Format("{0:n}", storico_contributo_richiesto);
            txtStoricoImportoRichiesto.Text = string.Format("{0:n}", storico_importo_richiesto);
            if (storico_importo_richiesto > 0)
            {
                txtStoricoRichiestoQuota.Text = string.Format("{0:n}", 100 * storico_contributo_richiesto / storico_importo_richiesto);
                decimal spese_generali = _investimento.SpeseGenerali != null && /*nota (*)*/_investimento.CodTipoInvestimento != 2 ? _investimento.SpeseGenerali.Value : 0;
                if (_investimento.CostoInvestimento + spese_generali > 0)
                    txtCompletamentoInvestimento.Text = string.Format("{0:n}", 100 * storico_importo_richiesto / (_investimento.CostoInvestimento.Value + spese_generali));
                else txtCompletamentoInvestimento.Text = "0";
            }

            if (prichiesto != null)
            {
                decimal ammontare_richiesto_lavori_in_economia = 0, ammontare_ammesso_lavori_in_economia = 0;
                foreach (SiarLibrary.PagamentiBeneficiario pb in pbeneficiario_attuali)
                {
                    if (pb.CodTipo == "LEC")
                    {
                        ammontare_richiesto_lavori_in_economia += pb.ImportoRichiesto;
                        if (prichiesto.Ammesso && pb.ImportoAmmesso != null) ammontare_ammesso_lavori_in_economia += pb.ImportoAmmesso;
                    }
                }
                txtImportoRichiestoLavoriInEconomia.Text = string.Format("{0:N}", Math.Round(ammontare_richiesto_lavori_in_economia, 2, MidpointRounding.AwayFromZero));
                if (prichiesto.ImportoRichiesto > 0) txtQuotaRichiestoLavoriInEconomia.Text = string.Format("{0:N}", Math.Round(100 *
                       ammontare_richiesto_lavori_in_economia / prichiesto.ImportoRichiesto, 2, MidpointRounding.AwayFromZero));
                txtImportoComputoMetrico.Text = prichiesto.ImportoComputoMetrico;
                txtImportoTotaleRichiesto.Text = prichiesto.ImportoRichiesto;
                txtContributoTotaleRichiesto.Text = prichiesto.ContributoRichiesto;
                txtImportoInvestimento.Text = string.Format("{0:N}", Math.Round(importo_investimento_richiesto, 2, MidpointRounding.AwayFromZero));
                txtImportoSpeseTecniche.Text = string.Format("{0:N}", Math.Round(importo_spese_richieste, 2, MidpointRounding.AwayFromZero));

                txtContributoRichiestoAltreFonti.Text = prichiesto.ContributoRichiestoAltreFonti;
                txtContributoAmmessoAltreFonti.Text = prichiesto.ContributoAmmessoAltreFonti;

                if (prichiesto.Ammesso)
                {
                    //tbInvestimento.Rows[0].Cells[0].InnerHtml += "<img src='../../images/visto.gif' />";                    
                    imgAmmesso.InnerHtml += "<svg class='icon icon-secondary me-1' aria-hidden='true'><use href='/web/bootstrap-italia/svg/sprites.svg#it-check'></use></svg>";
                    txtImportoComputoMetricoAmmesso.Text = prichiesto.ImportoComputoMetricoAmmesso;
                    txtImportoTotaleAmmesso.Text = prichiesto.ImportoAmmesso;
                    txtContributoTotaleAmmesso.Text = prichiesto.ContributoAmmesso;
                    txtImportoInvestimentoAmmesso.Text = string.Format("{0:N}", Math.Round(importo_investimento_ammesso, 2, MidpointRounding.AwayFromZero));
                    txtImportoSpeseTecnicheAmmesse.Text = string.Format("{0:N}", Math.Round(importo_spese_ammesse, 2, MidpointRounding.AwayFromZero));
                    txtImportoAmmessoLavoriInEconomia.Text = string.Format("{0:N}", Math.Round(ammontare_ammesso_lavori_in_economia, 2, MidpointRounding.AwayFromZero));
                    if (prichiesto.ImportoAmmesso > 0)
                        txtQuotaAmmessoLavoriInEconomia.Text = string.Format("{0:N}", Math.Round(100 * ammontare_ammesso_lavori_in_economia /
                            prichiesto.ImportoAmmesso, 2, MidpointRounding.AwayFromZero));
                }
            }
            else
            {
                txtImportoComputoMetrico.Text = null;
                txtImportoTotaleRichiesto.Text = null;
                txtContributoTotaleRichiesto.Text = null;
                txtImportoRichiestoLavoriInEconomia.Text = null;
                txtQuotaRichiestoLavoriInEconomia.Text = null;
                txtImportoInvestimento.Text = null;
                txtImportoSpeseTecniche.Text = null;
            }
            btnSalva.Enabled = (AbilitaModifica && prichiesto != null);
        }

        /// <summary>
        /// ritorna l'id dell'attuale pagamento richiesto se non esiste lo crea
        /// </summary>
        /// <returns></returns>
        private int getPagamentoRichiesto()
        {
            SiarLibrary.PagamentiRichiestiCollection prichiesti = prichiesti_provider.Find(null, _investimento.IdInvestimento,
                    null, DomandaPagamento.IdDomandaPagamento);
            if (prichiesti.Count > 0) prichiesto = prichiesti[0];
            else
            {
                prichiesto = new SiarLibrary.PagamentiRichiesti();
                prichiesto.IdInvestimento = _investimento.IdInvestimento;
                prichiesto.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                prichiesto.DataRichiestaPagamento = DateTime.Now;
                prichiesto.ImportoRichiesto = 0;
                prichiesto.ContributoRichiesto = 0;
                prichiesti_provider.Save(prichiesto);
            }
            return prichiesto.IdPagamentoRichiesto;
        }

        /// <summary>
        /// inserimento nuovo giustificativo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPost_Click(object sender, EventArgs e)
        {
            try
            {
                int id_giustificativo;
                if (int.TryParse(ucZoomLoaderGiustificativiPagati.SelectedValue, out id_giustificativo))
                {
                    SiarBLL.GiustificativiCollectionProvider giust_provider = new SiarBLL.GiustificativiCollectionProvider(PagamentoProvider.DbProviderObj);
                    SiarLibrary.Giustificativi giustificativo = giust_provider.GetById(id_giustificativo);

                    // -- OLD
                    //decimal importo_disponibile_giustificativo = SiarLibrary.DbStaticProvider.GetAmmontareDisponibileGiustificativo(
                    //    giustificativo.IdGiustificativo,
                    //    giustificativo.Imponibile +
                    //        (giustificativo.IvaNonRecuperabile ?
                    //            Math.Round(giustificativo.Imponibile.Value * giustificativo.Iva.Value / 100, 2, MidpointRounding.AwayFromZero)
                    //            : 0),
                    //    false,
                    //    PagamentoProvider.DbProviderObj);

                    // -- NEW
                    //decimal importo_disponibile_giustificativo = SiarLibrary.DbStaticProvider.GetAmmontarePagamentiGiustificativo(giustificativo.IdGiustificativo,
                    //    PagamentoProvider.DbProviderObj);
                    decimal importo_disponibile_giustificativo = giustificativo.Imponibile +
                            (giustificativo.IvaNonRecuperabile ?
                                Math.Round(giustificativo.Imponibile.Value * giustificativo.Iva.Value / 100, 2, MidpointRounding.AwayFromZero)
                                : 0);
                    decimal importo_pagamenti_giustificativo_ass = SiarLibrary.DbStaticProvider.GetAmmontarePagamentiGiustificativoAssociatiPiano(giustificativo.IdGiustificativo,
                        null, PagamentoProvider.DbProviderObj);
                    importo_disponibile_giustificativo -= importo_pagamenti_giustificativo_ass;

                    PagamentoProvider.DbProviderObj.BeginTran();

                    SiarLibrary.PagamentiBeneficiario pagben = new SiarLibrary.PagamentiBeneficiario();
                    pagben.IdGiustificativo = giustificativo.IdGiustificativo;
                    pagben.IdPagamentoRichiesto = getPagamentoRichiesto();
                    pagben.ImportoRichiesto = importo_disponibile_giustificativo;
                    pbeneficiario_provider.Save(pagben);

                    SalvaPagamentoRichiesto();
                    PagamentoProvider.AggiornaDomandaDiPagamento(DomandaPagamento, ((SiarLibrary.Web.MasterPage)Master).Operatore);
                    PagamentoProvider.DbProviderObj.Commit();
                    //ShowMessage("Dati di richiesta pagamento salvati correttamente.");
                    ucZoomLoaderGiustificativiPagati.UnselectItem();
                    hdnIdPagamentoBeneficiario.Value = pagben.IdPagamentoBeneficiario;
                    btnMostraPagamento_Click(sender, e);
                }
            }
            catch (Exception ex) { PagamentoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        /// <summary>
        /// salvataggio pagamento beneficiario
        /// </summary>
        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    string messaggio = "Importo richiesto del pagamento salvato correttamente.";
        //    try
        //    {
        //        int check;
        //        if (!int.TryParse(hdnIdPagamentoBeneficiario.Value, out check)) throw new Exception("Si è verificato un errore nella procedura.");
        //        SiarLibrary.PagamentiBeneficiario pagben = pbeneficiario_provider.GetById(check);
        //        prichiesto = prichiesti_provider.GetById(pagben.IdPagamentoRichiesto);
        //        if (prichiesto == null) throw new Exception("Si è verificato un errore nella procedura.");

        //        decimal old_importo = pagben.ImportoRichiesto;
        //        decimal importo_giustificativo = pagben.Imponibile + (pagben.IvaNonRecuperabile ? Math.Round(pagben.Imponibile.Value *
        //            pagben.Iva / 100, 2, MidpointRounding.AwayFromZero) : 0);
        //        decimal new_importo;
        //        decimal.TryParse(txtIPImportoRichiesto.Text, out new_importo);

        //        if (new_importo > importo_giustificativo)
        //            throw new Exception("Importo richiesto non valido perchè maggiore dell`imponibile del giustificativo.");
        //        bool spesa_tecnica_check = chkIPSpesaTecnicaRichiesta.Checked;

        //        decimal importo_disponibile_giustificativo = SiarLibrary.DbStaticProvider.GetAmmontareDisponibileGiustificativo(
        //            pagben.IdGiustificativo, importo_giustificativo + old_importo, false, PagamentoProvider.DbProviderObj);
        //        if (new_importo > importo_disponibile_giustificativo)
        //        {
        //            new_importo = importo_disponibile_giustificativo;
        //            messaggio = "L`importo inserito supera l`ammontare disponibile per il giustificativo selezionato, è stato troncato. ";
        //        }

        //        // TRONCO L'IMPORTO SE STA CHIEDENDO PIU' DI QUANTO EFFETTIVAMENTE PAGATO
        //        decimal importo_pagamenti_giustificativo = SiarLibrary.DbStaticProvider.GetAmmontarePagamentiGiustificativo(pagben.IdGiustificativo,
        //            PagamentoProvider.DbProviderObj);
        //        decimal importo_pagamenti_giustificativo_ass = SiarLibrary.DbStaticProvider.GetAmmontarePagamentiGiustificativoAssociatiPiano(pagben.IdGiustificativo,
        //            pagben.IdPagamentoBeneficiario, PagamentoProvider.DbProviderObj);
        //        if (new_importo > importo_pagamenti_giustificativo - importo_pagamenti_giustificativo_ass)
        //        {
        //            new_importo = importo_pagamenti_giustificativo - importo_pagamenti_giustificativo_ass;
        //            messaggio = "L`importo inserito supera l`ammontare delle spese sostenute per il giustificativo selezionato, è stato troncato.";
        //        }

        //        if (new_importo <= 0)
        //            throw new Exception("Importo richiesto non valido.");

        //        PagamentoProvider.DbProviderObj.BeginTran();
        //        pagben.ImportoRichiesto = new_importo;
        //        pagben.SpesaTecnicaRichiesta = spesa_tecnica_check;
        //        pagben.CostituisceVariante = chkIPVariazione.Checked;
        //        pbeneficiario_provider.Save(pagben);

        //        SalvaPagamentoRichiesto();
        //        PagamentoProvider.AggiornaDomandaDiPagamento(DomandaPagamento, Operatore);
        //        PagamentoProvider.DbProviderObj.Commit();
        //    }
        //    catch (Exception ex) { PagamentoProvider.DbProviderObj.Rollback(); messaggio = "Attenzione! " + ex.Message.ToCleanJsString(); }
        //    finally
        //    {
        //        btnMostraPagamento_Click(sender, e);
        //        //RegisterClientScriptBlock("alert('" + messaggio + "');"); }
        //        if (messaggio.Equals("Importo richiesto del pagamento salvato correttamente."))
        //            ShowMessage(messaggio);
        //        else
        //            ShowError(messaggio);
        //    }
        //}

        /// <summary>
        /// eliminazione pagamento beneficiario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                int check;
                if (!int.TryParse(hdnIdPagamentoBeneficiario.Value, out check)) throw new Exception("Si è verificato un errore nella procedura.");
                SiarLibrary.PagamentiBeneficiario pagben = pbeneficiario_provider.GetById(check);
                prichiesto = prichiesti_provider.GetById(pagben.IdPagamentoRichiesto);
                if (prichiesto == null) throw new Exception("Si è verificato un errore nella procedura.");

                PagamentoProvider.DbProviderObj.BeginTran();
                pbeneficiario_provider.Delete(pagben);
                if (pbeneficiario_provider.Find(prichiesto.IdPagamentoRichiesto, null, null, null, null, null).Count == 0)
                {
                    prichiesti_provider.Delete(prichiesto);
                    prichiesto = null;
                }
                else SalvaPagamentoRichiesto();
                PagamentoProvider.AggiornaDomandaDiPagamento(DomandaPagamento, Operatore);
                PagamentoProvider.DbProviderObj.Commit();
                RegisterClientScriptBlock("chiudiPopup();");
                ShowMessage("La spesa selezionata è stata eliminata correttamente.");
            }
            catch (Exception ex) { PagamentoProvider.DbProviderObj.Rollback(); RegisterClientScriptBlock("chiudiPopup();"); ShowError(ex); }
        }

        /// <summary>
        /// bottone salva generale
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveRichiesto_Click(object sender, EventArgs e)
        {
            try
            {
                PagamentoProvider.DbProviderObj.BeginTran();
                SiarLibrary.PagamentiRichiestiCollection prichiesti = prichiesti_provider.Find(null, _investimento.IdInvestimento, null,
                    DomandaPagamento.IdDomandaPagamento);
                if (prichiesti.Count > 0) prichiesto = prichiesti[0];
                if (prichiesto == null) throw new Exception("Si è verificato un errore nella procedura.");

                SalvaPagamentoRichiesto();
                PagamentoProvider.AggiornaDomandaDiPagamento(DomandaPagamento, ((SiarLibrary.Web.MasterPage)Master).Operatore);
                PagamentoProvider.DbProviderObj.Commit();
                ShowMessage("Dati di richiesta pagamento salvati correttamente.");
            }
            catch (Exception ex) { PagamentoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        private void SalvaPagamentoRichiesto()
        {
            decimal importo_investimento = 0, importo_spese_tecniche = 0, impcomputometrico = 1000000000, importo_lavori_in_economia = 0;
            //if (_investimento.Mobile != null && !_investimento.Mobile)
            //{
            //    decimal.TryParse(txtImportoComputoMetrico.Text, out impcomputometrico);
            //    prichiesto.ImportoComputoMetrico = impcomputometrico;
            //}
            if (prichiesto.IdPagamentoRichiesto != null)
            {
                pbeneficiario_attuali = pbeneficiario_provider.Find(prichiesto.IdPagamentoRichiesto, null, null, null, null, null);
                foreach (SiarLibrary.PagamentiBeneficiario pb in pbeneficiario_attuali)
                {
                    if (pb.SpesaTecnicaRichiesta) importo_spese_tecniche += pb.ImportoRichiesto;
                    else importo_investimento += pb.ImportoRichiesto;
                    if (pb.CodTipo == "LEC") importo_lavori_in_economia += pb.ImportoRichiesto;
                }
            }
            // controllo su computo metrico
            //if (importo_investimento > impcomputometrico) importo_investimento = impcomputometrico;
            // memorizzo il richiesto non troncato
            prichiesto.ImportoRichiesto = importo_investimento + importo_spese_tecniche;

            #region calcolo il contributo
            //suddivido il contributo tra costo investimento e spese tecniche (mutuo 112 niente spese tecniche)
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

            //// Questo controllo non serve pi?, il contributo dell'investimento va considerato per intero altrimenti in istruttoria potrebbe essere troncato 
            //if (contributo_calcolato > 0)
            //{
            //    //controllo disponibile di progetto correlato 
            //    decimal contributo_disponibile_domanda = PagamentoProvider.CalcoloContributoRichiestoDisponibilePagamento(_investimento.IdProgetto,
            //        DomandaPagamento.IdDomandaPagamento, _investimento.CodTipoInvestimento, (prichiesto != null ? prichiesto.IdPagamentoRichiesto : null));
            //    if (contributo_calcolato > contributo_disponibile_domanda) contributo_calcolato = contributo_disponibile_domanda;
            //}

            // controllo quota dei lavori in economia (contributo richiesto<=importo_computo_metrico-importo lav in economia)
            //if (importo_lavori_in_economia > 0)
            //{
            //    if (string.IsNullOrEmpty(txtImportoComputoMetrico.Text) || impcomputometrico == 0)
            //        throw new Exception("Per richiedere il pagamento dei lavori in economia è necessario specificare l`importo da computo metrico.");
            //    //L`ammontare dei lavori in economia è maggiore della differenza tra importo da computo metrico e contributo. Impossibile continuare.
            //    decimal importo_fatturato_effettivo = Math.Min(impcomputometrico, importo_investimento) + importo_spese_tecniche - importo_lavori_in_economia;
            //    if (contributo_calcolato > importo_fatturato_effettivo) contributo_calcolato = importo_fatturato_effettivo;
            //    if (contributo_calcolato < 0) contributo_calcolato = 0;
            //}

            #endregion

            //ContributoAltre Fonti
            if (AltreFonti)
                prichiesto.ContributoRichiestoAltreFonti = Math.Round(prichiesto.ImportoRichiesto * (_investimento.QuotaContributoAltreFonti != null ? _investimento.QuotaContributoAltreFonti/100 : 0), 2, MidpointRounding.AwayFromZero);
            else
                prichiesto.ContributoRichiestoAltreFonti = null;
            
            prichiesto.ContributoRichiesto = contributo_calcolato;
            prichiesto.DataRichiestaPagamento = DateTime.Now;
            prichiesti_provider.Save(prichiesto);
        }

        protected void btnMostraPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                int check;
                if (!int.TryParse(hdnIdPagamentoBeneficiario.Value, out check)) throw new Exception("Si è verificato un errore nella procedura.");
                SiarLibrary.PagamentiBeneficiario pagben = pbeneficiario_provider.GetById(check);
                if (pagben == null) throw new Exception("Si è verificato un errore nella procedura.");
                CaricaDatiPagamento(pagben);
            }
            catch (Exception ex) { ShowError(ex); RegisterClientScriptBlock("chiudiPopup();"); }
        }

        private void CaricaDatiPagamento(SiarLibrary.PagamentiBeneficiario pagben)
        {
            System.Collections.Generic.Dictionary<string, string> tipi_riduzione = SiarLibrary.DbStaticProvider.
                GetTipiRiduzionePagamento(true, pagben.CodTipo == "LEC");
            SiarLibrary.Note motivazioni = null;
            if (pagben.MotivazioneRiduzione != null)
                motivazioni = new SiarBLL.NoteCollectionProvider().GetById(pagben.MotivazioneRiduzione);

            if (pagben.CodTipo == "LEC")
            {
                txtLECDescrizione.Text = pagben.Descrizione;
                txtLECImportoRichiesto.Text = pagben.ImportoRichiesto;
                decimal contributo_richiesto = Math.Round(pagben.ImportoRichiesto.Value * _investimento.QuotaContributoRichiesto / 100, 2, MidpointRounding.AwayFromZero);
                txtLECContributoRichiesto.Text = contributo_richiesto.ToString();
                if (pagben.ImportoAmmesso != null)
                {
                    txtLECImportoAmmesso.Text = pagben.ImportoAmmesso;
                    decimal contributo_ammesso = Math.Round(pagben.ImportoAmmesso.Value * _investimento.QuotaContributoRichiesto / 100, 2, MidpointRounding.AwayFromZero);
                    txtLECContributoAmmesso.Text = contributo_ammesso.ToString();
                }
                chkLECVariazioneInvestimento.Checked = pagben.CostituisceVariante;
                txtLECNoteAggiuntive.Text = null;
                chklLECMotivazioniRiduzione.BindItems(tipi_riduzione);
                chklLECMotivazioniRiduzione.SelectedValue = pagben.CodRiduzione;
                if (motivazioni != null) txtLECNoteAggiuntive.Text = motivazioni.Testo;
                RegisterClientScriptBlock("mostraPopupTemplate('divLavoriInEconomia','divBKGMessaggio');");
            }
            else
            {
                //txtGSData.Text = pagben.Data;
                //txtGSNumero.Text = pagben.Numero;
                //txtGSImponibile.Text = pagben.Imponibile;
                //txtGSOggetto.Text = pagben.Descrizione;
                //txtIPImportoRichiesto.Text = pagben.ImportoRichiesto;
                //decimal contributo_richiesto = Math.Round(pagben.ImportoRichiesto.Value * _investimento.QuotaContributoRichiesto / 100, 2, MidpointRounding.AwayFromZero);
                //txtIPContributoRichiesto.Text = contributo_richiesto.ToString();
                //chkIPSpesaTecnicaRichiesta.Checked = pagben.SpesaTecnicaRichiesta;
                //chkIPVariazione.Checked = pagben.CostituisceVariante;
                //chklIPMotivazioniRiduzione.BindItems(tipi_riduzione);
                //chklIPMotivazioniRiduzione.SelectedValue = pagben.CodRiduzione;
                //txtIPNoteAggiuntive.Text = null;
                //if (motivazioni != null) txtIPNoteAggiuntive.Text = motivazioni.Testo;

                //if (pagben.ImportoAmmesso != null)
                //{
                //    txtIPImportoAmmesso.Text = pagben.ImportoAmmesso;
                //    chkIPSpesaTecnica.Checked = (pagben.SpesaTecnicaAmmessa != null && pagben.SpesaTecnicaAmmessa);
                //    decimal contributo_ammesso = 0;
                //    if (pagben.ContributoAmmesso != null)
                //        contributo_ammesso = pagben.ContributoAmmesso;
                //    else
                //        contributo_ammesso = Math.Round(pagben.ImportoAmmesso.Value * _investimento.QuotaContributoRichiesto / 100, 2, MidpointRounding.AwayFromZero);
                //    txtIPContributoAmmesso.Text = string.Format("{0:N}", contributo_ammesso);
                //    if (pagben.QuotaContributoAmmesso != null)
                //        txtIPContributoQuota.Text = pagben.QuotaContributoAmmesso;
                //    else
                //        txtIPContributoQuota.Text = string.Format("{0:N}", _investimento.QuotaContributoRichiesto);
                //    decimal importo_nonammesso = pagben.ImportoRichiesto - pagben.ImportoAmmesso;
                //    txtIPImportoNonAmmesso.Text = string.Format("{0:N}", importo_nonammesso);
                //    txtIPContributoNonAmmesso.Text = string.Format("{0:N}", contributo_richiesto - contributo_ammesso);
                //    if (pagben.ImportoNonammNonresp != null)
                //    {
                //        txtIPImportoNonresp.Text = pagben.ImportoNonammNonresp;
                //        txtIPContributoNonresp.Text = string.Format("{0:N}", Math.Round(pagben.ImportoNonammNonresp * _investimento.QuotaContributoRichiesto / 100, 2, MidpointRounding.AwayFromZero));
                //    }
                //    else { txtIPImportoNonresp.Text = ""; txtIPContributoNonresp.Text = ""; }
                //}
                //else
                //{
                //    txtIPImportoAmmesso.Text = txtIPImportoNonAmmesso.Text = txtIPContributoAmmesso.Text = txtIPContributoNonAmmesso.Text =
                //        txtIPImportoNonresp.Text = txtIPContributoNonresp.Text = txtIPContributoQuota.Text = "";
                //    chkIPSpesaTecnica.Checked = false;
                //}

                /* 25/02/2015 commentata perche per ora non visibile
                if (pagben.ImportoAmmessoContr != null)
                {
                    txtIPImportoAmmessoInLoco.Text = pagben.ImportoAmmessoContr;
                    chkIPSpesaTecnicaInLoco.Checked = (pagben.SpesaTecnicaAmmessaContr != null && pagben.SpesaTecnicaAmmessaContr);
                    decimal contributo_ammesso_inloco = Math.Round(pagben.ImportoAmmessoContr.Value * _investimento.QuotaContributoRichiesto.Value / 100, 2, MidpointRounding.AwayFromZero);
                    txtIPContributoAmmessoInLoco.Text = string.Format("{0:N}", contributo_ammesso_inloco);
                    decimal importo_nonammesso_inloco = pagben.ImportoRichiesto - pagben.ImportoAmmessoContr;
                    txtIPImportoNonAmmessoContr.Text = string.Format("{0:N}", importo_nonammesso_inloco);
                    txtIPContributoNonAmmessoContr.Text = string.Format("{0:N}", contributo_richiesto - contributo_ammesso_inloco);
                    if (pagben.ImportoNonammContrNonresp != null)
                    {
                        txtIPImportoNonrespInLoco.Text = pagben.ImportoNonammContrNonresp;
                        txtIPContributoNonrespInLoco.Text = string.Format("{0:N}",
                            Math.Round(pagben.ImportoNonammContrNonresp * _investimento.QuotaContributoRichiesto.Value / 100, 2, MidpointRounding.AwayFromZero));
                    }
                    else { txtIPImportoNonrespInLoco.Text = ""; txtIPContributoNonrespInLoco.Text = ""; }
                }*/

                //Controlli richiesta integrazione
                if (DomandaPagamento.InIntegrazione != null && DomandaPagamento.InIntegrazione)
                {
                    if (pagben.IdGiustificativo != null)
                    {
                        var giustificativo = new SiarBLL.GiustificativiCollectionProvider().GetById(pagben.IdGiustificativo);

                        //if (giustificativo != null && giustificativo.InIntegrazione != null && giustificativo.InIntegrazione)
                        //    btnSave.Enabled = true;
                    }
                }

                //RegisterClientScriptBlock("mostraPopupTemplate('divIstPagForm','divBKGMessaggio');");
                var giu = new SiarBLL.GiustificativiCollectionProvider().GetById(pagben.IdGiustificativo);
                modalePagamento.Utente = Operatore.Utente;
                modalePagamento.Domanda = DomandaPagamento;
                modalePagamento.Giustificativo = giu;
                modalePagamento.PagamentoBeneficiario = pagben;
                modalePagamento.PianoInvestimento = _investimento;
                modalePagamento.PercentualeContributo = _investimento.QuotaContributoRichiesto;
                RegisterClientScriptBlock(modalePagamento.Mostra);
            }
        }

        protected void btnSalvaLavoriInEconomia_Click(object sender, EventArgs e)
        {
            string messaggio = "Lavoro in economia salvato correttamente.";
            try
            {
                if (_investimento.Mobile == null || _investimento.Mobile) throw new Exception("Non è consentito rendicontare costi per lavori in economia su investimenti mobili.");
                SiarLibrary.PagamentiBeneficiario pagben = null;
                int check;
                if (int.TryParse(hdnIdPagamentoBeneficiario.Value, out check)) pagben = pbeneficiario_provider.GetById(check);
                SalvaLavoriInEconomia(pagben);
            }
            catch (Exception ex) { messaggio = "Attenzione! " + ex.Message.ToCleanJsString(); }
            finally { btnMostraPagamento_Click(sender, e); RegisterClientScriptBlock("alert('" + messaggio + "');"); }
        }

        private void SalvaLavoriInEconomia(SiarLibrary.PagamentiBeneficiario pagben)
        {
            try
            {
                SiarBLL.GiustificativiCollectionProvider giust_provider = new SiarBLL.GiustificativiCollectionProvider(PagamentoProvider.DbProviderObj);
                PagamentoProvider.DbProviderObj.BeginTran();

                SiarLibrary.Giustificativi giustificativo;
                if (pagben == null)
                {
                    giustificativo = new SiarLibrary.Giustificativi();
                    pagben = new SiarLibrary.PagamentiBeneficiario();
                }
                else giustificativo = giust_provider.GetById(pagben.IdGiustificativo);
                if (giustificativo == null) throw new Exception("Si è verificato un errore nella procedura.");
                giustificativo.IdProgetto = Progetto.IdProgetto;
                giustificativo.Data = DateTime.Now;
                giustificativo.Imponibile = txtLECImportoRichiesto.Text;
                giustificativo.CfFornitore = new SiarBLL.ImpresaCollectionProvider().GetById(Progetto.IdImpresa).CodiceFiscale;
                giustificativo.CodTipo = "LEC";
                giustificativo.Descrizione = txtLECDescrizione.Text;
                giust_provider.Save(giustificativo);

                pagben.IdGiustificativo = giustificativo.IdGiustificativo;
                pagben.IdPagamentoRichiesto = getPagamentoRichiesto();
                pagben.ImportoRichiesto = txtLECImportoRichiesto.Text;
                pagben.SpesaTecnicaRichiesta = false;
                pagben.CostituisceVariante = chkLECVariazioneInvestimento.Checked;
                pbeneficiario_provider.Save(pagben);

                SalvaPagamentoRichiesto();
                PagamentoProvider.AggiornaDomandaDiPagamento(DomandaPagamento, Operatore);
                PagamentoProvider.DbProviderObj.Commit();
                hdnIdPagamentoBeneficiario.Value = pagben.IdPagamentoBeneficiario;
            }
            catch (Exception ex) { PagamentoProvider.DbProviderObj.Rollback(); throw ex; }
        }
    }
}
/* NOTA:
 (*)se si tratta di mutuo la quota contributo non e' + _investimento.QuotaContributoRichiesto ma mi calcolo la %
    effettiva dividendo importo con contributo dell'investimento
*/