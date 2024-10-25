using SiarBLL;
using System;
using System.Web.UI;

namespace web.Private.Istruttoria
{
    public partial class ChecklistRicevibilita : SiarLibrary.Web.IstruttoriaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "ricevibilita_domande";
            base.OnPreInit(e);
        }

        SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider();
        SiarLibrary.Progetto _progetto = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id_progetto;
                if (int.TryParse(Request.QueryString["iddom"], out id_progetto)) _progetto = progetto_provider.GetById(id_progetto);
                bindControlli();
                ucFirmaRicevibilita.DocumentoFirmatoEvent = btnProtocolla_Click;
            }
            catch (Exception ex) { Redirect("Ricevibilita.aspx", ex.Message, true); }
        }

        private void bindControlli()
        {
            if (_progetto == null || _progetto.IdBando != Bando.IdBando || (_progetto.IdProgIntegrato != null && _progetto.IdProgIntegrato != _progetto.IdProgetto))
                throw new Exception("La domanda di aiuto selezionata non è valida.");
            ucChecklist.Progetto = ucInfoDomanda.Progetto = _progetto;
            controlloOperatoreStatoProgetto();
            if (_progetto.CodStato == "Q") btnAmmissibilita.Disabled = false;
            else btnAmmissibilita.Attributes.Add("onclick", "location='ChecklistAmmissibilita.aspx?iddom=" + _progetto.IdProgetto + "'");
        }

        private void controlloOperatoreStatoProgetto()
        {
            AbilitaModifica = AbilitaModifica && _progetto.CodStato == "L";
            SiarLibrary.CollaboratoriXBandoCollection collaboratore = new SiarBLL.CollaboratoriXBandoCollectionProvider().Find(Bando.IdBando,
                _progetto.IdProgetto, null, null, true);
            if (collaboratore.Count > 0)
            {
                txtIstruttore.Text = collaboratore[0].Nominativo;
                if (collaboratore[0].IdUtente != Operatore.Utente.IdUtente) AbilitaModifica = false;
            }
            else { txtIstruttore.Text = "Nessun istruttore assegnato."; AbilitaModifica = false; }
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (!IsPostBack) txtSegnatura.Text = _progetto.SegnaturaAllegati;

            //pregresso
            bool Pregresso = false;
            string StPregresso = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_PregressoRicevibilita(_progetto.IdBando);
            if (StPregresso == "True")
                Pregresso = true;
            if (Pregresso)
            {
                btnInserisciSegnatura.Visible = true;
                btnRendiDefinitiva.Visible = false;
                ckAttivo.Attributes.Add("onchange", "DisabilitaLabel();");
            }
            else
            {
                btnInserisciSegnatura.Visible = false;
                btnRendiDefinitiva.Visible = true;
            }


            SiarLibrary.ProgettoStoricoCollection storico = new SiarBLL.ProgettoStoricoCollectionProvider().Find(_progetto.IdProgetto, null, "R");
            if (storico.Count > 0)
            {
                btnStampa.Disabled = false;
                btnStampa.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + storico[0].Segnatura + "');");
            }
            base.OnPreRender(e);
        }

        protected void btnVerifica_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                string esito = ucChecklist.VerificaChecklist();
                if (!string.IsNullOrEmpty(txtSegnatura.Text))
                {
                    _progetto.SegnaturaAllegati = txtSegnatura.Text;
                    progetto_provider.Save(_progetto);
                }
                switch (esito)
                {
                    case "SI":
                        ShowMessage("Checklist verificata correttamente. La domanda soddisfa tutti i requisiti necessari per essere RICEVIBILE.");
                        btnRendiDefinitiva.Enabled = true;
                        btnInserisciSegnatura.Enabled = true;
                        break;
                    case "NO":
                        ShowError("La domanda non soddisfa tutti i requisiti obbligatori imposti dalla checklist.");
                        btnRendiDefinitiva.Enabled = true;
                        btnInserisciSegnatura.Enabled = true;
                        break;
                    default:
                        ShowError(esito);
                        break;
                }
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnRendiDefinitiva_Click(object sender, EventArgs e)
        {
            try
            {
                //SiarLibrary.AllegatiProtocollatiCollection allegati = new SiarBLL.AllegatiProtocollatiCollectionProvider().Find(_progetto.IdProgetto, null, null, null, null, null, null, null);
                //int numeroAllegati = allegati.Count;
                //bool allegatiProtocollatiOk = checkAllegatiProtocollati(_progetto, numeroAllegati);
                bool allegatiProtocollatiOk = new SiarBLL.AllegatiProtocollatiCollectionProvider().CheckAllegatiProtocollati(SiarBLL.AllegatiProtocollatiCollectionProvider.TipoCheck.Progetto, _progetto.IdProgetto, _progetto.Segnatura);

                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (_progetto.CodStato != "L") throw new Exception("La domanda in esame non si trova nello stato procedurale idoneo. Impossibile continuare.");
                //  if (_progetto.SegnaturaAllegati == null) throw new Exception("Per continuare occorre digitare la segnatura degli allegati.");
                if (!allegatiProtocollatiOk) throw new Exception("Non sono stati protocollati tutti gli allegati della domanda. Impossibile continuare. Comunicare al beneficiario di completare la protocollazione dei documenti.");
                string esito = ucChecklist.VerificaChecklist();
                if (esito != "SI" && esito != "NO") throw new Exception(esito);

                ucFirmaRicevibilita.loadDocumento(Operatore.Utente.CfUtente, ucInfoDomanda.Progetto.IdProgetto, "R");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnProtocolla_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (string.IsNullOrEmpty(ucFirmaRicevibilita.FileFirmato)) throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk per segnalare il problema.");
                //if (_progetto.SegnaturaAllegati == null) throw new Exception("Digitare la segnatura degli allegati.");

                string esito = ucChecklist.VerificaChecklist();
                if (esito != "SI" && esito != "NO") throw new Exception(esito);

                SiarLibrary.Protocollo documento_interno = new SiarLibrary.Protocollo(Bando.CodEnte);
                documento_interno.setDocumento("checklist_ricevibilita_domanda_" + _progetto.IdProgetto + ".pdf", Convert.FromBase64String(ucFirmaRicevibilita.FileFirmato));

                string[] ss = new SiarBLL.BandoCollectionProvider().GetDatiXProtocollazione(Bando.IdBando, _progetto.ProvinciaDiPresentazione);
                string oggetto = "Checklist RICEVIBILITA per il bando: " + ss[0] + " del " + ss[1] + "\n" + ss[3] + "\nAnno: " + DateTime.Now.Year
                    + "\n CF: " + ucInfoDomanda.Impresa.Cuaa 
                    + "\n Ragione sociale: " + ucInfoDomanda.Impresa.RagioneSociale
                    + "\n N° Domanda: " + _progetto.IdProgetto;
                string identificativo_paleo = documento_interno.DocumentoInterno(oggetto, ss[4]);

                progetto_provider.DbProviderObj.BeginTran();
                try
                {
                    string stato = (esito == "SI" ? "I" : "Q");
                    progetto_provider.CambioStatoProgetto(_progetto, stato, identificativo_paleo, Operatore);
                    if (_progetto.IdProgIntegrato != null)
                    {
                        SiarLibrary.ProgettoCollection progetti_correlati = progetto_provider.Find(null, null, _progetto.IdProgIntegrato, null, null, false, true);
                        foreach (SiarLibrary.Progetto p in progetti_correlati)
                            if (p.IdProgetto != p.IdProgIntegrato) progetto_provider.CambioStatoProgetto(p, stato, Operatore);
                    }
                    progetto_provider.DbProviderObj.Commit();
                    _progetto = progetto_provider.GetById(ucChecklist.Progetto.IdProgetto);
                    bindControlli();
                    ucInfoDomanda.loadData();
                    btnVerifica.Enabled = false;
                    ShowMessage("Checklist di ricevibilità firmata e protocollata correttamente.<br /> La domanda è ora " + _progetto.Stato.Value.ToUpper());
                }
                catch (Exception exc)
                {
                    progetto_provider.DbProviderObj.Rollback();
                    string oggettoEmail = "Errore nel cambio di stato del progetto nr." + _progetto.IdProgetto;
                    string testEmail = "Segnatura documento interno protocollato: " + identificativo_paleo +
                        "\nErrore: " + exc.Message;
                    EmailUtility.SendEmailToTeamSigef(exc, oggettoEmail, testEmail);
                    throw;
                }
            }
            catch (Exception ex) { ShowError(ex); }
            finally { ucFirmaRicevibilita.FileFirmato = null; }
        }
        protected void btnInserisciSegnatura_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (_progetto.CodStato != "L") throw new Exception("La domanda in esame non si trova nello stato procedurale idoneo. Impossibile continuare.");
                //  if (_progetto.SegnaturaAllegati == null) throw new Exception("Per continuare occorre digitare la segnatura degli allegati.");
                string esito = ucChecklist.VerificaChecklist();
                if (esito != "SI" && esito != "NO") throw new Exception(esito);
                RegisterClientScriptBlock("mostraPopupTemplate('divPregresso','divBKGMessaggio');");

            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalvaSegnatura_Click(object sender, EventArgs e)
        {
            try
            {
                if (((txtData.Text == "" || txtData.Text == null) && (txtSegnaturaIns.Text == null || txtSegnaturaIns.Text == "")) || ((txtData.Text == "" || txtData.Text == null) && !ckAttivo.Checked)) throw new Exception("Inserire la data e la segnatura se disponibile");
                if (!ckAttivo.Checked)
                {
                    if (!new SiarLibrary.Protocollo().ProtocolloEsistente(txtSegnaturaIns.Text))
                        throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.DocumentoNonValido);
                }
                string esito = ucChecklist.VerificaChecklist();
                if (esito != "SI" && esito != "NO") throw new Exception(esito);
                progetto_provider.DbProviderObj.BeginTran();
                string stato = (esito == "SI" ? "I" : "Q");
                progetto_provider.CambioStatoProgettoPregresso(_progetto, stato, ckAttivo.Checked ? "ND" : txtSegnaturaIns.Text, Convert.ToDateTime(txtData.Text), Operatore, false, false, false);
                if (_progetto.IdProgIntegrato != null)
                {
                    SiarLibrary.ProgettoCollection progetti_correlati = progetto_provider.Find(null, null, _progetto.IdProgIntegrato, null, null, false, true);
                    foreach (SiarLibrary.Progetto p in progetti_correlati)
                        if (p.IdProgetto != p.IdProgIntegrato) progetto_provider.CambioStatoProgettoPregresso(p, stato,null, Convert.ToDateTime(txtData.Text), Operatore, false, false, false);
                }
                progetto_provider.DbProviderObj.Commit();
                _progetto = progetto_provider.GetById(ucChecklist.Progetto.IdProgetto);
                bindControlli();
                ucInfoDomanda.loadData();
                btnVerifica.Enabled = false;
                RegisterClientScriptBlock("chiudiPopupTemplate();");
                ShowMessage("La Data e la segnatura dell'istruttoria di ricevibilità sono state salvate correttamente.<br /> La domanda è ora " + _progetto.Stato.Value.ToUpper());

            }
            catch (Exception ex) {
                btnInserisciSegnatura_Click(sender, e);
                ShowError("Attenzione! " + ex.Message); 
            }
        }
            
    }
}

