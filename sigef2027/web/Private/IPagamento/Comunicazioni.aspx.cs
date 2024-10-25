using SiarBLL;
using System;
using System.Web.UI;

namespace web.Private.IPagamento
{
    public partial class Comunicazioni : SiarLibrary.Web.IstruttoriaPagamentoPage
    {
        SiarBLL.DomandaDiPagamentoSegnatureCollectionProvider segnature_provider;
        SiarLibrary.DomandaDiPagamentoSegnatureCollection segnature_domanda;
        bool responsabile = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            segnature_provider = new SiarBLL.DomandaDiPagamentoSegnatureCollectionProvider(PagamentoProvider.DbProviderObj);
            ucFirmaDocumento.DocumentoFirmatoEvent = btnComunicazionePost_Click;
            responsabile = new SiarBLL.BandoResponsabiliCollectionProvider().Find(Progetto.IdBando, Operatore.Utente.IdUtente,
                Progetto.ProvinciaDiPresentazione, null, true).Count > 0;
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (DomandaPagamento.Annullata) txtSegnaturaAnnullamento.Text = DomandaPagamento.SegnaturaAnnullamento;
            else
            {
                if (segnature_domanda == null) segnature_domanda = segnature_provider.Find(DomandaPagamento.IdDomandaPagamento, null, null);
                SiarLibrary.DomandaDiPagamentoSegnatureCollection filtrosegnature = segnature_domanda.FiltroTipo("CEI", null);
                if (filtrosegnature.Count > 0)
                {
                    txtSegnaturaComunicazione.Text = filtrosegnature[0].Segnatura;
                    btnStampaComunicazione.Disabled = false;
                    btnStampaComunicazione.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + filtrosegnature[0].Segnatura + "');");
                }
                else
                {
                    btnFirmaComunicazione.Enabled = DomandaPagamento.Approvata != null;
                    txtSegnaturaComunicazione.Text = "documento non ancora firmato.";
                }

                btnAccettaRiesame.Enabled = responsabile && DomandaPagamento.Approvata != null;
                btnRifiutaRiesame.Enabled = responsabile && DomandaPagamento.Approvata != null;
                filtrosegnature = segnature_domanda.FiltroTipo("RIP", null);
                if (filtrosegnature.Count > 0)
                {
                    txtMotivazioneRiesameLunga.Text = filtrosegnature[0].Motivazione;
                    txtSegnaturaRiesame.Text = filtrosegnature[0].Segnatura;
                    txtSegnaturaRiesame.ReadOnly = true;
                    btnRifiutaRiesame.Visible = false;
                    btnAccettaRiesame.Enabled = responsabile;
                    btnAccettaRiesame.Text = "Modifica le motivazioni";
                    txtEsitoRichiestaRiesame.Text = (filtrosegnature[0].RiapriDomanda ? "ACCOLTA." : "NEGATA.");
                    btnFirmaComunicazione.Enabled = false;
                }
                else btnAnnullamento.Enabled = (TipoModifica == 3 || responsabile) && DomandaPagamento.SegnaturaApprovazione == null;
            }
            base.OnPreRender(e);
        }

        #region comunicazione CEI

        protected void btnComunicazionePost_Click(object sender, EventArgs e)
        {
            try
            {
                //if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (string.IsNullOrEmpty(ucFirmaDocumento.FileFirmato))
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk e segnalare il problema.");
                SiarLibrary.Impresa impresa = new SiarBLL.ImpresaCollectionProvider().GetById(Progetto.IdImpresa);
                if (impresa != null)
                {
                    SiarLibrary.Protocollo comunicazione = new SiarLibrary.Protocollo(Bando.CodEnte);
                    comunicazione.setCorrispondente(impresa, Progetto.IdProgetto, "destinatario");
                    comunicazione.setDocumento("comunicazione_esito_istruttorio_idpag_" + DomandaPagamento.IdDomandaPagamento + "_iddom_"
                        + DomandaPagamento.IdProgetto + ".pdf", Convert.FromBase64String(ucFirmaDocumento.FileFirmato));

                    string[] ss = new SiarBLL.BandoCollectionProvider().GetDatiXProtocollazione(Progetto.IdBando, Progetto.ProvinciaDiPresentazione);
                    string oggetto = "Comunicazione di esito istruttorio di " + DomandaPagamento.Descrizione.Value.ToUpper()
                        + " domanda di aiuto nr. " + Progetto.IdProgetto + " in risposta al bando: " + ss[0] + " del " + ss[1] + " con scadenza: " + ss[2] + "\n" + ss[3]
                        + "\n Partita iva/Codice fiscale: " + impresa.Cuaa
                        + "\n Ragione sociale: " + impresa.RagioneSociale;
                    string segnatura = comunicazione.ProtocolloUscita(oggetto, ss[4], true);
                    try
                    {
                        SiarLibrary.DomandaDiPagamentoSegnature segnatura_comunicazione = new SiarLibrary.DomandaDiPagamentoSegnature();
                        segnatura_comunicazione.Segnatura = segnatura;
                        segnatura_comunicazione.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                        segnatura_comunicazione.Data = DateTime.Now;
                        segnatura_comunicazione.CodTipo = "CEI";
                        segnatura_comunicazione.Operatore = Operatore.Utente.CfUtente;
                        segnatura_comunicazione.RiapriDomanda = false;
                        segnature_provider.Save(segnatura_comunicazione);
                        ShowMessage("Comunicazione di esito istruttorio di " + DomandaPagamento.Descrizione + " firmata e protocollata correttamente.");
                    }
                    catch (Exception ex)
                    {
                        string oggettoEmail = "Errore durante la comunicazione";
                        string testEmail = "Id domanda: " + Progetto.IdProgetto + "\nId pagamento: "
                            + DomandaPagamento.IdDomandaPagamento + "\nSegnatura: " + segnatura + "\n\n" + ex.Message;
                        EmailUtility.SendEmailToTeamSigef(ex, oggettoEmail, testEmail);
                        ShowError(ex);
                    }
                }
                else ShowError("L'impresa titolare della domanda è inesistente. Impossibile continuare.");
            }
            catch (Exception exc) { ShowError(exc); }
            finally { ucFirmaDocumento.FileFirmato = null; }
        }

        #endregion

        #region riesame

        protected void btnAmmettiRiesame_Click(object sender, EventArgs e) { RegistraRiesame(true); }

        protected void btnRifiutaRiesame_Click(object sender, EventArgs e) { RegistraRiesame(false); }

        private void RegistraRiesame(bool ammetti)
        {
            try
            {
                //if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                PagamentoProvider.DbProviderObj.BeginTran();

                string messaggio = "Motivazioni dell'esito del riesame salvate correttamente.";
                SiarLibrary.DomandaDiPagamentoSegnature richiesta_riesame = segnature_provider.GetById(DomandaPagamento.IdDomandaPagamento, "RIP");
                if (richiesta_riesame == null)
                {
                    //controllo che il beneficiario non abbia presentato domande di pagamento posteriori all'approvazione di questa                             
                    foreach (SiarLibrary.DomandaDiPagamento d in PagamentoProvider.Find(null, null, DomandaPagamento.IdProgetto, null))
                        if (d.IdDomandaPagamento > DomandaPagamento.IdDomandaPagamento)
                            throw new Exception("Non è possibile accogliere la richiesta di riesame perchè il beneficiario ha presentato una domanda di pagamento successiva a questa.");
                    //controllo che il beneficiario non abbia presentato domande di varianti/at posteriori all'approvazione di questa                            
                    foreach (SiarLibrary.Varianti v in new SiarBLL.VariantiCollectionProvider(PagamentoProvider.DbProviderObj).Find(null,
                        DomandaPagamento.IdProgetto, null))
                        if (v.DataInserimento > DomandaPagamento.DataApprovazione)
                            throw new Exception("Non è possibile accogliere la richiesta di riesame perchè il beneficiario ha presentato una domanda di variante/a.t. successiva a tale variante.");
                    
                    //controllo che non sia in revisione
                    var revisioni = new SiarBLL.TestataValidazioneCollectionProvider(PagamentoProvider.DbProviderObj)
                        .GetUltimaRevisioneDomandaValida(DomandaPagamento.IdDomandaPagamento);
                    if (revisioni.Count > 0 && revisioni[0].IdLotto != null)
                        throw new Exception("Non è possibile accogliere la richiesta di riesame perchè la domanda di pagamento è inclusa in un lotto di revisione.");

                    SiarLibrary.Protocollo p = new SiarLibrary.Protocollo();
                    byte[] doc = p.RicercaProtocollo(txtSegnaturaRiesame.Text, true);

                    richiesta_riesame = new SiarLibrary.DomandaDiPagamentoSegnature();
                    richiesta_riesame.CodTipo = "RIP";
                    richiesta_riesame.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                    richiesta_riesame.Segnatura = txtSegnaturaRiesame.Text;
                    richiesta_riesame.RiapriDomanda = ammetti;
                    messaggio = "Richiesta di riesame registrata correttamente con esito " + (ammetti ?
                        "positivo. La domanda di pagamento viene riaperta in istruttoria." : "negativo.");

                    if (ammetti)
                    {
                        SiarLibrary.DomandaDiPagamentoSegnature backup_segnatura_precedente = new SiarLibrary.DomandaDiPagamentoSegnature();
                        backup_segnatura_precedente.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                        backup_segnatura_precedente.CodTipo = "APP";
                        backup_segnatura_precedente.Data = DomandaPagamento.DataApprovazione;
                        backup_segnatura_precedente.Segnatura = DomandaPagamento.SegnaturaApprovazione;
                        backup_segnatura_precedente.Operatore = DomandaPagamento.CfIstruttore;
                        backup_segnatura_precedente.RiapriDomanda = DomandaPagamento.Approvata;//mi registro l'esito dell'istruttoria (precauzione)
                        backup_segnatura_precedente.Motivazione = "Record inserito automaticamente dopo accoglimento della richiesta di riesame. Backup dell`esito dell`istruttoria precedente: domanda di pagamento "
                            + (DomandaPagamento.Approvata ? "" : "NON") + " approvata.";
                        segnature_provider.Save(backup_segnatura_precedente);

                        if (DomandaPagamento.Approvata || DomandaPagamento.CodTipo == "SLD")
                        {
                            //annullo il cambiamento di stato dovuto all'istruttoria positiva della domanda di pagamento
                            if (Progetto.IdProgIntegrato == null)
                                new SiarBLL.ProgettoCollectionProvider(PagamentoProvider.DbProviderObj).AnnullaUltimoCambioStatoProgetto(Progetto, false);
                            else
                            {
                                SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider(PagamentoProvider.DbProviderObj);
                                foreach (SiarLibrary.Progetto prj in progetto_provider.Find(null, null, Progetto.IdProgetto, null, null, null, null))
                                    progetto_provider.AnnullaUltimoCambioStatoProgetto(prj, false);
                            }
                        }
                        //aggiorno la domanda di pagamento
                        DomandaPagamento.Approvata = null;
                        DomandaPagamento.SegnaturaApprovazione = null;
                        PagamentoProvider.Save(DomandaPagamento);
                    }
                }
                richiesta_riesame.Data = DateTime.Now;
                richiesta_riesame.Operatore = Operatore.Utente.CfUtente;
                richiesta_riesame.Motivazione = txtMotivazioneRiesameLunga.Text;
                segnature_provider.Save(richiesta_riesame);
                PagamentoProvider.DbProviderObj.Commit();
                ucIDomandaPagamento.loadData();
                ShowMessage(messaggio);
            }
            catch (Exception ex) { PagamentoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        #endregion

        protected void btnAnnullamento_Click(object sender, EventArgs e)
        {
            try
            {
                //if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (string.IsNullOrEmpty(txtSegnaturaAnnullamento.Text)) throw new Exception("Non è stata inserita la Segnatura della richiesta di Annuallamento. Impossibile continuare.");
                SiarLibrary.Protocollo richiesta = new SiarLibrary.Protocollo();
                byte[] doc = richiesta.RicercaProtocollo(txtSegnaturaAnnullamento.Text, true);

                //se la domanda è in integrazione, rimuovo prima tutti i flag della domanda
                if(DomandaPagamento.InIntegrazione)
                {
                    var integrazioni_provider = new SiarBLL.IntegrazioniPerDomandaDiPagamentoCollectionProvider();
                    var integrazioni_non_completate_coll = integrazioni_provider
                        .Find(null, DomandaPagamento.IdDomandaPagamento, false, DomandaPagamento.IdProgetto);

                    //verifico che l'integrazione della domanda sia effettivamente non risolta prima di togliere i flag
                    if(integrazioni_non_completate_coll.Count > 0)
                    {
                        SiarBLL.IntegrazioniDomandaPagamentoUtility.togliTuttiFlagInIntegrazione(DomandaPagamento);
                        DomandaPagamento.InIntegrazione = false;
                    }
                }

                DomandaPagamento.SegnaturaAnnullamento = txtSegnaturaAnnullamento.Text;
                DomandaPagamento.CfOperatoreAnnullamento = Operatore.Utente.CfUtente;
                DomandaPagamento.DataAnnullamento = DateTime.Now;
                DomandaPagamento.Annullata = true;
                PagamentoProvider.Save(DomandaPagamento);
                ucIDomandaPagamento.loadData();
                btnAnnullamento.Enabled = false;
                ShowMessage("Richiesta di annullamento della presente domanda di " + DomandaPagamento.Descrizione + " registrata correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnFirmaComunicazione_Click(object sender, EventArgs e)
        {
            try
            {
                //if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (DomandaPagamento.Approvata == null) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.GenericoConLink);                    
                SiarLibrary.DomandaDiPagamentoSegnatureCollection segnature = segnature_provider.Find(DomandaPagamento.IdDomandaPagamento, "CEI", null);
                if (segnature.Count > 0) throw new Exception("Il documento è già stato firmato. Impossibile continuare.");
                if (!responsabile)
                    throw new Exception("Solo il responsabile provinciale di istruttoria è abilitato alla firma del documento.");
                ucFirmaDocumento.loadDocumento(((SiarLibrary.Web.MasterPage)Master).Operatore.Utente.CfUtente, DomandaPagamento.IdDomandaPagamento);
            }
            catch (Exception ex) { ShowError(ex); }

        }
    }
}