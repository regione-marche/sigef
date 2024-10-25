using SiarLibrary.NullTypes;
using SiarLibrary;
using SiarLibrary.Web;
using SiarBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.IPagamento
{
    public partial class IntegrazioniDomandaPagamento : IstruttoriaPagamentoPage
    {
        IntegrazioniPerDomandaDiPagamentoCollectionProvider integrazione_provider;
        IntegrazioniPerDomandaDiPagamento integrazione_selezionata = null;
        IntegrazioneSingolaDiDomandaCollectionProvider integrazione_singola_provider;
        IntegrazioneSingolaDiDomanda integrazione_singola_selezionata = null;
        int id_integrazione_di_domanda_selezionata, id_integrazione_di_domanda_singola;

        DomandaDiPagamentoCollectionProvider pagamento_provider;
        //DomandaDiPagamento domanda_selezionata = null;
        //int id_domanda_selezionata;

        protected void Page_Load(object sender, EventArgs e)
        {
            ucFirmaComunicazione.DocumentoFirmatoEvent = btnPostBack_Click;

            integrazione_singola_provider = new IntegrazioneSingolaDiDomandaCollectionProvider();
            integrazione_provider = new IntegrazioniPerDomandaDiPagamentoCollectionProvider();
            pagamento_provider = new DomandaDiPagamentoCollectionProvider();

            //aggiorno la domanda di pagamento in sessione per evitare possibili bug di integrazione o altri dati non aggiornati
            DomandaPagamento = pagamento_provider.GetById(DomandaPagamento.IdDomandaPagamento);

            ucChecklist.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
            ucChecklist.Fase = DomandaPagamento.CodFase;
            ucChecklist.Progetto = Progetto;

            ucIDomandaPagamento.loadData();

            if (int.TryParse(hdnIdIntegrazioneDomandaDiPagamentoSelezionato.Value, out id_integrazione_di_domanda_selezionata))
            {
                integrazione_selezionata = integrazione_provider.GetById(id_integrazione_di_domanda_selezionata);

                if (int.TryParse(hdnIdIntegrazioneSingolaSelezionata.Value, out id_integrazione_di_domanda_singola))
                {
                    integrazione_singola_selezionata = integrazione_singola_provider.GetById(id_integrazione_di_domanda_singola);

                    UcVisualizzaIntegrazioneSingola.IntegrazioneSingola = integrazione_singola_selezionata;
                    UcVisualizzaIntegrazioneSingola.PerBeneficiario = false;
                }
            }
        }


        protected override void OnPreRender(EventArgs e)
        {
            System.Collections.ArrayList link_veloci = ucChecklist.StepDiReindirizzamento;
            if (link_veloci.Count == 0) tbLinkVeloci.Visible = false;
            else
            {
                foreach (string url in link_veloci)
                {
                    string testo_bottone = url.Substring(url.LastIndexOf("/") + 1).Replace(".aspx?", "").Replace("Istruttoria", "");
                    if (testo_bottone == "Allegati" || testo_bottone == "SpeseSostenute" || testo_bottone == "PianoInvestimenti")
                    {
                        string button = "<input type=button class='btn btn-secondary py-1' value='" + testo_bottone + "' onclick=\"location='" +
                            url.Replace("~", HttpContext.Current.Request.ApplicationPath) + "&iddom=" + DomandaPagamento.IdProgetto + "'\" />";
                        tbLinkVeloci.Controls.Add(new LiteralControl(button));
                    }
                }
            }

            ucChecklist.Visible = false;

            var integrazioni_collection = integrazione_provider.Find(null, DomandaPagamento.IdDomandaPagamento, null, null);
            if (integrazione_selezionata != null)
                integrazioni_collection = integrazioni_collection.SubSelect(id_integrazione_di_domanda_selezionata, null, null, null, null, null, null, null, null, null, null, null);

            dgIntegrazioniDomanda.DataSource = integrazioni_collection;
            dgIntegrazioniDomanda.SetTitoloNrElementi();
            dgIntegrazioniDomanda.ItemDataBound += new DataGridItemEventHandler(dgIntegrazioniDomanda_ItemDataBound);
            dgIntegrazioniDomanda.DataBind();

            if (integrazione_selezionata != null)
            {
                trElencoIntegrazioniIncluse.Visible = true;
                riempiCampiInteraIntegrazione();

                BoolNT soloNonCompletatiIstruttore = null;
                if (checkNonCompletateIstruttore.Checked)
                    soloNonCompletatiIstruttore = false; //per la find per filtrare non completati

                BoolNT soloNonCompletatiBenefeciari = null;
                if (checkNonCompletateBeneficiario.Checked)
                    soloNonCompletatiBenefeciari = false; //per la find per filtrare non completati

                var integrazioni_singole_collection = integrazione_singola_provider.Find(
                    null, 
                    integrazione_selezionata.IdIntegrazioneDomandaDiPagamento, 
                    null,
                    soloNonCompletatiIstruttore,
                    soloNonCompletatiBenefeciari, 
                    null);

                if (integrazione_singola_selezionata != null)
                    integrazioni_singole_collection = integrazioni_singole_collection.SubSelect(id_integrazione_di_domanda_singola, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);

                dgIntegrazioni.DataSource = integrazioni_singole_collection;
                dgIntegrazioni.SetTitoloNrElementi();
                dgIntegrazioni.ItemDataBound += new DataGridItemEventHandler(dgIntegrazioni_ItemDataBound);
                dgIntegrazioni.DataBind();
            }

            base.OnPreRender(e);
        }

        void dgIntegrazioniDomanda_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            int col_Id = 0,
                col_DataRichiesta = 1,
                col_Note = 2,
                col_SegnaturaIstruttore = 3,
                col_SegnaturaBeneficiario = 4,
                col_DataConclusione = 5,
                col_IntegrazioneCompleta = 6,
                col_Visualizza = 7;

            var dgi = e.Item;
            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var d = (IntegrazioniPerDomandaDiPagamento)dgi.DataItem;

                if (d.SegnaturaIstruttore != null && !d.SegnaturaIstruttore.Equals(""))
                {
                    var segnaturaIstruttore = d.SegnaturaIstruttore.ToString().Replace("R_MARCHE|", "R_MARCHE|\n");
                    //dgi.Cells[col_SegnaturaIstruttore].Text = "<a href=\"javascript:sncAjaxCallVisualizzaProtocollo('" + d.SegnaturaIstruttore + "');\">" + segnaturaIstruttore + "</a>";
                    dgi.Cells[col_SegnaturaIstruttore].Text = "<a href=\"javascript:MostraProtocolloNew('" + d.SegnaturaIstruttore + "');\">" + segnaturaIstruttore + "</a>";
                }

                if (d.SegnaturaBeneficiario != null && !d.SegnaturaBeneficiario.Equals(""))
                {
                    var segnaturaBeneficiario = d.SegnaturaBeneficiario.ToString().Replace("R_MARCHE|", "R_MARCHE|\n");
                    //dgi.Cells[col_SegnaturaBeneficiario].Text = "<a href=\"javascript:sncAjaxCallVisualizzaProtocollo('" + d.SegnaturaBeneficiario + "');\">" + segnaturaBeneficiario + "</a>";
                    dgi.Cells[col_SegnaturaBeneficiario].Text = "<a href=\"javascript:MostraProtocolloNew('" + d.SegnaturaBeneficiario + "');\">" + segnaturaBeneficiario + "</a>";
                }

                if (d.IntegrazioneCompleta != null && d.IntegrazioneCompleta == true)
                    dgi.Cells[col_IntegrazioneCompleta].Text = "<div class=\"positivo\">SI</div>";
                else
                    dgi.Cells[col_IntegrazioneCompleta].Text = "<div class=\"negativo\">NO</div>";

                if (integrazione_selezionata != null && d.IdIntegrazioneDomandaDiPagamento == integrazione_selezionata.IdIntegrazioneDomandaDiPagamento)
                    dgi.Cells[col_Visualizza].Text = dgi.Cells[col_Visualizza].Text.Replace("Visualizza", "Torna elenco");
            }
        }

        void dgIntegrazioni_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            int col_Id = 0,
                col_DataRichiesta = 1,
                col_TipoIntegrazione = 2,
                col_CompletataIntegrazione = 3,
                col_DataRilascioBeneficiario = 4,
                col_CompletataBeneficiario = 5,
                col_DatiGiustificativo = 6,
                col_DatiPagamento = 7,
                col_Apri = 8;

            var dgi = e.Item;
            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var d = (IntegrazioneSingolaDiDomanda)dgi.DataItem;

                if (d.SingolaIntegrazioneCompletataIstruttore != null && d.SingolaIntegrazioneCompletataIstruttore == true)
                    dgi.Cells[col_CompletataIntegrazione].Text = "<div class=\"positivo\">SI</div>";
                else
                    dgi.Cells[col_CompletataIntegrazione].Text = "<div class=\"negativo\">NO</div>";

                if (d.SingolaIntegrazioneCompletataBeneficiario != null && d.SingolaIntegrazioneCompletataBeneficiario == true)
                    dgi.Cells[col_CompletataBeneficiario].Text = "<div class=\"positivo\">SI</div>";
                else
                    dgi.Cells[col_CompletataBeneficiario].Text = "<div class=\"negativo\">NO</div>";

                if ((d.DescrizioneTipoIntegrazione != null)
                    && (d.DescrizioneTipoIntegrazione.Equals("Spese sostenute giustificativo") || d.DescrizioneTipoIntegrazione.Equals("Spese sostenute pagamento")))
                {
                    if (d.DescrizioneTipoIntegrazione.Equals("Spese sostenute giustificativo"))
                    {
                        var giustificativo = new GiustificativiCollectionProvider().GetById(d.IdGiustificativo);
                        dgi.Cells[col_DatiGiustificativo].Text = "<b>Numero:</b> " + giustificativo.Numero + "<br /><b>Data:</b> " + giustificativo.Data + "<br /><b>Ragione sociale:</b> " + giustificativo.DescrizioneFornitore + "<br /><b>Oggetto:</b> " + giustificativo.Descrizione;
                        dgi.Cells[col_DatiPagamento].Text = "";
                    }
                    else
                    {
                        var spesa = new SpeseSostenuteCollectionProvider().GetById(d.IdSpesa);
                        dgi.Cells[col_DatiGiustificativo].Text = "<b>Numero:</b> " + spesa.Numero + "<br /><b>Data:</b> " + spesa.Data + "<br /><b>Ragione sociale:</b> " + spesa.DescrizioneFornitore + "<br /><b>Oggetto:</b> " + spesa.Descrizione;
                        dgi.Cells[col_DatiPagamento].Text = "<b>Tipo:</b> " + spesa.TipoPagamento + "<br /><b>Estremi:</b> " + spesa.Estremi;
                    }
                }
                else
                {
                    dgi.Cells[col_DatiGiustificativo].Text = "";
                    dgi.Cells[col_DatiPagamento].Text = "";
                }

                if (integrazione_singola_selezionata != null && d.IdSingolaIntegrazione == integrazione_singola_selezionata.IdSingolaIntegrazione)
                    dgi.Cells[col_Apri].Text = dgi.Cells[col_Apri].Text.Replace("Apri", "Torna elenco");
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            dgIntegrazioni.SetPageIndex(0);
            dgIntegrazioniDomanda.SetPageIndex(0);
        }

        protected void btnSalvaDatiTuttaIntegrazione_Click(object sender, EventArgs e)
        {
            string messaggio = "";
            BoolNT newValue = comboCompletataTuttaIntegrazioneDomandaIstruttore.SelectedValue;
            // 06/09/2023 Rimosso controllo su richiesta Funzionalita' #196669
            //if (newValue)
            //    messaggio = IntegrazioniDomandaPagamentoUtility.verificaSeIntegrazioneChiudibile(integrazione_selezionata);
            
            if(messaggio.Equals(""))
            {
                messaggio = IntegrazioniDomandaPagamentoUtility.salvaInteraIntegrazioneIstruttore(integrazione_selezionata, txtNoteIntegrazioneDomandaDiPagamento.Text, newValue, txtDataConclusioneTuttaIntegrazione.Text);

                var domanda_provider = new SiarBLL.DomandaDiPagamentoCollectionProvider();
                var domanda_integrazione = domanda_provider.GetById(integrazione_selezionata.IdDomandaPagamento);
                DomandaPagamento = domanda_integrazione;

                if (messaggio.StartsWith("Integrazione"))
                    ShowMessage(messaggio);
                else
                    ShowError(messaggio);
            }
            else
                ShowError(messaggio);
        }

        protected void riempiCampiInteraIntegrazione()
        {
            //Campi intera integrazione
            txtNoteIntegrazioneDomandaDiPagamento.Text = integrazione_selezionata.NoteIntegrazioneDomanda;
            comboCompletataTuttaIntegrazioneDomandaIstruttore.ClearSelection();
            string val_intera_completa = "false";
            if (integrazione_selezionata.IntegrazioneCompleta != null && integrazione_selezionata.IntegrazioneCompleta)
                val_intera_completa = "true";
            comboCompletataTuttaIntegrazioneDomandaIstruttore.Items.FindByValue(val_intera_completa).Selected = true;
            txtDataConclusioneTuttaIntegrazione.Text = new SiarLibrary.NullTypes.DatetimeNT(DateTime.Now);

            if (integrazione_selezionata != null && integrazione_selezionata.SegnaturaIstruttore != null)
            {
                btnEliminaInteraIntegrazione.Enabled = false;
                btnInviaIntegrazione.Enabled = false;
            }

            if (integrazione_selezionata != null && integrazione_selezionata.IntegrazioneCompleta)
            {
                btnEliminaInteraIntegrazione.Enabled = false;
                btnInviaIntegrazione.Enabled = false;
                btnSalvaDatiTuttaIntegrazione.Enabled = false;
                txtDataConclusioneTuttaIntegrazione.Enabled = false;
                comboCompletataTuttaIntegrazioneDomandaIstruttore.Enabled = false;
                txtNoteIntegrazioneDomandaDiPagamento.Enabled = false;
            }

            if (integrazione_selezionata != null && integrazione_selezionata.SegnaturaBeneficiario != null && !integrazione_selezionata.IntegrazioneCompleta)
            {
                //SiarLibrary.AllegatiProtocollatiCollection apcCheck = new SiarBLL.AllegatiProtocollatiCollectionProvider().Find(null, null, null, integrazione_selezionata.IdIntegrazioneDomandaDiPagamento, null, null, null, null);
                //int numeroAllegati = apcCheck.Count;
                //bool allegatiProtocollatiOk = checkAllegatiProtocollati(numeroAllegati, integrazione_selezionata.SegnaturaBeneficiario);
                bool allegatiProtocollatiOk = new SiarBLL.AllegatiProtocollatiCollectionProvider().CheckAllegatiProtocollati(SiarBLL.AllegatiProtocollatiCollectionProvider.TipoCheck.IntegrazioneDiDomandaPagamento, integrazione_selezionata.IdIntegrazioneDomandaDiPagamento, integrazione_selezionata.SegnaturaBeneficiario);
                if (!allegatiProtocollatiOk)
                {
                    string tooltipText = "Attenzione: non tutti gli allegati sono stati inviati al protocollo dal beneficiario";

                    //Campi intera integrazione
                    btnEliminaInteraIntegrazione.Enabled = false;
                    btnEliminaInteraIntegrazione.ToolTip = tooltipText;
                    btnInviaIntegrazione.Enabled = false;
                    btnInviaIntegrazione.ToolTip = tooltipText;
                    btnSalvaDatiTuttaIntegrazione.Enabled = false;
                    btnSalvaDatiTuttaIntegrazione.ToolTip = tooltipText;
                    txtDataConclusioneTuttaIntegrazione.Enabled = false;
                    txtDataConclusioneTuttaIntegrazione.ToolTip = tooltipText;
                    comboCompletataTuttaIntegrazioneDomandaIstruttore.Enabled = false;
                    comboCompletataTuttaIntegrazioneDomandaIstruttore.ToolTip = tooltipText;
                    txtNoteIntegrazioneDomandaDiPagamento.Enabled = false;
                    txtNoteIntegrazioneDomandaDiPagamento.ToolTip = tooltipText;
                }
            }

            //if ((DomandaPagamento.SegnaturaApprovazione != null && !DomandaPagamento.SegnaturaApprovazione.Equals(""))
            //    || DomandaPagamento.SegnaturaAnnullamento != null && !DomandaPagamento.SegnaturaAnnullamento.Equals(""))
            //{
            //    btnInviaIntegrazione.Enabled = false;
            //    btnInviaIntegrazione.ToolTip = "Non è possibile inviare una richiesta integrazioni in quanto la domanda di pagamento è già stata istruita o annullata.";
            //}
        }

        protected void btnEliminaSingolaIntegrazione_Click(object sender, EventArgs e)
        {
            var domanda_provider = new DomandaDiPagamentoCollectionProvider();
            DomandaDiPagamento domanda_integrazione = null;
            int? id_domanda_pagamento = null;
            if (integrazione_selezionata != null && integrazione_selezionata.IdDomandaPagamento != null)
            {
                id_domanda_pagamento = integrazione_selezionata.IdDomandaPagamento;
                domanda_integrazione = domanda_provider.GetById(id_domanda_pagamento);
            }

            string message = IntegrazioniDomandaPagamentoUtility.eliminaIntegrazioneSingola(integrazione_singola_selezionata);

            if (message.StartsWith("Integrazione"))
            {
                ShowMessage(message);
                hdnIdIntegrazioneSingolaSelezionata = null;
                integrazione_singola_selezionata = null;

                //Aggiorno la domanda pagamento in sessione
                if (id_domanda_pagamento != null)
                {
                    domanda_integrazione = domanda_provider.GetById(id_domanda_pagamento);
                    DomandaPagamento = domanda_integrazione;
                }
            }
            else
                ShowError(message);
        }

        protected void btnEliminaInteraIntegrazione_Click(object sender, EventArgs e)
        {
            var domanda_provider = new SiarBLL.DomandaDiPagamentoCollectionProvider();
            DomandaDiPagamento domanda_integrazione = null;
            int? id_domanda_pagamento = null;
            if (integrazione_selezionata != null && integrazione_selezionata.IdDomandaPagamento != null)
            {
                id_domanda_pagamento = integrazione_selezionata.IdDomandaPagamento;
                domanda_integrazione = domanda_provider.GetById(id_domanda_pagamento);
            }

            string message = SiarBLL.IntegrazioniDomandaPagamentoUtility.eliminaIntegrazioneIntera(integrazione_selezionata);

            if (message.StartsWith("Integrazione"))
            {
                ShowMessage(message);
                hdnIdIntegrazioneDomandaDiPagamentoSelezionato = null;
                hdnIdIntegrazioneSingolaSelezionata = null;
                integrazione_selezionata = null;
                integrazione_singola_selezionata = null;

                //Aggiorno la domanda pagamento in sessione
                if (id_domanda_pagamento != null)
                {
                    domanda_integrazione = domanda_provider.GetById(id_domanda_pagamento);
                    DomandaPagamento = domanda_integrazione;
                }
            }
            else
                ShowError(message);
        }

        protected void btnInviaIntegrazione_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(DomandaPagamento.IdProgetto))
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk per segnalare il problema.");
                var respo_provider = new SiarBLL.BandoResponsabiliCollectionProvider();
                var respo_collection = respo_provider.Find(Bando.IdBando, Operatore.Utente.IdUtente, null, null, true);
                if (respo_collection.Count > 0 || (chkAbilitaPreview != null && chkAbilitaPreview.Checked))
                {
                    System.Collections.ArrayList parametri = new System.Collections.ArrayList();
                    parametri.Add(DomandaPagamento.IdProgetto.ToString());
                    parametri.Add(integrazione_selezionata.IdIntegrazioneDomandaDiPagamento.ToString());
                    ucFirmaComunicazione.Preview = chkAbilitaPreview.Checked;
                    ucFirmaComunicazione.loadDocumento(((SiarLibrary.Web.MasterPage)Master).Operatore.Utente.CfUtente, (string[])parametri.ToArray(typeof(string)));
                }
                else
                    ShowError("Solamente il responsabile del procedimento può firmare e inviare la richiesta di integrazioni.");
            }
            catch (Exception ex) { ShowError(ex); }

        }

        protected void btnPostBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ucFirmaComunicazione.FileFirmato))
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk per segnalare il problema.");

                Progetto progetto = new ProgettoCollectionProvider().GetById(DomandaPagamento.IdProgetto);
                if (progetto != null)
                {
                    SiarLibrary.Impresa impresa = new ImpresaCollectionProvider().GetById(progetto.IdImpresa);
                    if (impresa != null)
                    {
                        Protocollo comunicazione = new Protocollo(Bando.CodEnte);
                        comunicazione.setCorrispondente(impresa, progetto.IdProgetto, "destinatario");
                        comunicazione.setDocumento("comunicazione_richiesta_integrazioni_domanda_nr_" + progetto.IdProgetto + ".pdf", Convert.FromBase64String(ucFirmaComunicazione.FileFirmato));

                        string[] ss = new BandoCollectionProvider().GetDatiXProtocollazione(Bando.IdBando, progetto.ProvinciaDiPresentazione);
                        string oggetto = "Comunicazione per richiesta di integrazioni domanda di aiuto nr. " + progetto.IdProgetto
                            + " in risposta al bando: " + ss[0] + " del " + ss[1] + " con scadenza: "
                            + Bando.DataScadenza + "\n" + ss[3] 
                            + "\n Partita iva/Codice fiscale: " + impresa.Cuaa
                            + "\n Ragione sociale: " + impresa.RagioneSociale;
                        string segnatura = comunicazione.ProtocolloUscita(oggetto, ss[4], true);
                        try
                        {
                            integrazione_provider = new IntegrazioniPerDomandaDiPagamentoCollectionProvider();
                            integrazione_selezionata.SegnaturaIstruttore = segnatura;
                            integrazione_provider.Save(integrazione_selezionata);
                            ShowMessage("Comunicazione di richiesta integrazione firmata e protocollata correttamente.");
                        }
                        catch (Exception ex)
                        {
                            string oggettoEmail = "Errore durante la comunicazione di richiesta integrazioni";
                            string testEmail = "Domanda: " + progetto.IdProgetto + "\nSegnatura: " + segnatura + "\n\n" + ex.Message;
                            EmailUtility.SendEmailToTeamSigef(ex, oggettoEmail, testEmail);
                            ShowError(ex);
                        }
                    }
                    else ShowError("L'impresa titolare della domanda è inesistente. Impossibile continuare.");
                }
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnVisualizzaIntegrazione_Click(object sender, EventArgs e)
        {
            try
            {
                string pagina_risoluzione = "../IPagamento/";
                string link_spese_sostenute = "IstruttoriaSpeseSostenute.aspx?idpag=" + integrazione_selezionata.IdDomandaPagamento;
                string link_piano_investimenti = "IstruttoriaPianoInvestimenti.aspx?idpag=" + integrazione_selezionata.IdDomandaPagamento;
                string link_allegati = "IstruttoriaAllegati.aspx?idpag=" + integrazione_selezionata.IdDomandaPagamento;

                switch (integrazione_singola_selezionata.DescrizioneTipoIntegrazione)
                {
                    case "Spese sostenute pagamento":
                        pagina_risoluzione += link_spese_sostenute;
                        Session["id_spesa_integrazione"] = integrazione_singola_selezionata.IdSpesa;
                        break;
                    case "Spese sostenute giustificativo":
                        pagina_risoluzione += link_spese_sostenute;
                        Session["id_giustificativo_integrazione"] = integrazione_singola_selezionata.IdGiustificativo;
                        break;
                    case "Piano investimenti":
                        pagina_risoluzione += link_piano_investimenti;
                        break;
                    case "Allegati":
                        pagina_risoluzione += link_allegati;
                        break;
                    default: throw new Exception("Errore di tipologia");
                }

                Response.Redirect(pagina_risoluzione);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void checkNonCompletateBeneficiario_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void checkNonCompletateIstruttore_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnMostraProtocollo_Click(object sender, EventArgs e)
        {
            try
            {
                string segnatura = hdnSegnatura.Value;
                if (string.IsNullOrEmpty(segnatura) || segnatura == "undefined")
                    throw new Exception("Segnatura vuota");

                modaleMostraProtocollo.Segnatura = segnatura;
                RegisterClientScriptBlock(modaleMostraProtocollo.Mostra);
            }
            catch (Exception ex)
            {
                RegisterClientScriptBlock("chiudiPopupTemplate();");
                ShowError(ex.Message);
            }
        }
    }
}
