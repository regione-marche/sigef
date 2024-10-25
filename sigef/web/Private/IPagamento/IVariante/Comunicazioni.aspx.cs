using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarBLL;
using SiarLibrary.Extensions;

namespace web.Private.IPagamento.IVariante
{
    public partial class Comunicazioni : SiarLibrary.Web.IstruttoriaVariantePage
    {
        SiarBLL.VariantiSegnatureCollectionProvider segnature_provider = new SiarBLL.VariantiSegnatureCollectionProvider();
        SiarLibrary.VariantiSegnatureCollection segnature_varianti;
        SiarLibrary.Atti decreto_variante;
        bool Organismi_intermedi = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            ucFirmaDocumento.DocumentoFirmatoEvent = btnComunicazionePost_Click;
            if (Variante.CodTipo.FindValueIn("VI", "AR")) Redirect("firmarichiesta.aspx",
                "La pagina delle comunicazioni non è accessibile in quanto non previste per Variazioni Accertate in fase istruttoria ne per Acquisizioni di Esito di Ricorso.", true);
            string Str_Organismi_intermedi = "";
            Str_Organismi_intermedi = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_OrganismiIntermedi(Progetto.IdBando);
            if (Str_Organismi_intermedi == "True")
                Organismi_intermedi = true;
        }

        protected override void OnPreRender(EventArgs e)
        {
            txtSegnaturaAnnullamento.Text = Variante.SegnaturaAnnullamento;
            if (segnature_varianti == null) segnature_varianti = segnature_provider.Find(Variante.IdVariante, null, null);
            SiarLibrary.VariantiSegnatureCollection filtrosegnature = segnature_varianti.FiltroTipo("CEI", null);
            if (filtrosegnature.Count > 0)
            {
                txtSegnaturaComunicazione.Text = filtrosegnature[0].Segnatura;
                btnStampaComunicazione.Enabled = true;
            }
            else
            {
                btnFirmaComunicazione.Enabled = true;
                txtSegnaturaComunicazione.Text = "documento non ancora firmato.";
            }

            btnAccettaRiesame.Enabled = false;
            btnRifiutaRiesame.Enabled = false;
            lblEsitoRiesame.Text = "nessuna";
            if (Variante.SegnaturaApprovazione != null)
            {
                btnAccettaRiesame.Enabled = true;
                btnRifiutaRiesame.Enabled = true;
            }
            filtrosegnature = segnature_varianti.FiltroTipo("RIV", null);
            if (filtrosegnature.Count > 0)
            {
                txtMotivazioneRiesame.Text = filtrosegnature[0].Motivazione;
                txtSegnaturaRiesame.Text = filtrosegnature[0].Segnatura;
                txtSegnaturaRiesame.ReadOnly = true;
                btnRifiutaRiesame.Visible = false;
                btnAccettaRiesame.Enabled = true;
                btnAccettaRiesame.Text = "Modifica le motivazioni";
                lblEsitoRiesame.Text = (filtrosegnature[0].RiapriVariante ? "ACCOLTA." : "NEGATA.");
            }
            btnAnnullamento.Enabled = AbilitaModifica && !Variante.Annullata && Variante.DataApprovazione == null;

            lstAttoDefinizione.DataBind();
            lstAttoRegistro.DataBind();
            
            if(!Organismi_intermedi)
            {
                trDecreto.Visible = true;
                trDecretoOrg.Visible = false;
            }
            else
            {
                trDecreto.Visible = false;
                trDecretoOrg.Visible = true;
            }


            if (Variante.IdAttoApprovazione != null)
            {
                decreto_variante = new SiarBLL.AttiCollectionProvider().GetById(Variante.IdAttoApprovazione);
                compilaCampiDecreto();
            }

            // evento ricerca
            int id_decreto;
            if (decreto_variante == null && int.TryParse(hdnIdAtto.Value, out id_decreto))
                decreto_variante = new SiarBLL.AttiCollectionProvider().GetById(id_decreto);
            // bind dei campi
            if (decreto_variante != null)
                compilaCampiDecreto();
            else
                pulisciCampiDecreto();

            base.OnPreRender(e);
        }

        protected void compilaCampiDecreto()
        {
            if(!Organismi_intermedi)
            {
                hdnIdAtto.Value = decreto_variante.IdAtto;
                txtAttoData.Text = decreto_variante.Data;
                txtAttoNumero.Text = decreto_variante.Numero;
                txtAttoDescrizione.Text = decreto_variante.Descrizione;
                foreach (ListItem l in lstAttoRegistro.Items)
                    if (l.Value.StartsWith(decreto_variante.Registro))
                    {
                        l.Selected = true;
                        break;
                    }

                btnVidualizzaDecreto.Disabled = false;
                btnVidualizzaDecreto.Attributes.Add("onclick", "visualizzaAtto(" + decreto_variante.IdAtto + ");");
            }
            else
            {
                hdnIdAtto.Value = decreto_variante.IdAtto;
                txtDataDecretoOrg.Text = decreto_variante.Data;
                txtNumeroDecretoOrg.Text = decreto_variante.Numero;
                txtDescrizioneDecretoOrg.Text = decreto_variante.Descrizione;
                txtLinkEst.Text = decreto_variante.LinkEsterno;
                btnVisualizzaAttoOrg.Disabled = false;
                btnVisualizzaAttoOrg.Attributes.Add("onclick", "visualizzaAttoOrg('" + decreto_variante.LinkEsterno + "');");
            }
        }

        protected void pulisciCampiDecreto()
        {
            txtAttoData.Text = "";
            txtAttoNumero.Text = "";
            lstAttoRegistro.ClearSelection();
            txtAttoDescrizione.Text = "";
            hdnIdAtto.Value = "";
        }

        #region riesame

        protected void btnAmmettiRiesame_Click(object sender, EventArgs e) { RegistraRiesame(true); }

        protected void btnRifiutaRiesame_Click(object sender, EventArgs e) { RegistraRiesame(false); }

        private void RegistraRiesame(bool ammetti)
        {
            try
            {
                VarianteProvider.DbProviderObj.BeginTran();
                segnature_provider = new SiarBLL.VariantiSegnatureCollectionProvider(VarianteProvider.DbProviderObj);

                string messaggio = "Motivazioni dell'esito del riesame salvate correttamente.";
                SiarLibrary.VariantiSegnature richiesta_riesame = segnature_provider.GetById(Variante.IdVariante, "RIV");
                if (richiesta_riesame == null)
                {
                    //controllo che il beneficiario non abbia presentato domande di pagamento posteriori all'approvazione di questa variante                            
                    foreach (SiarLibrary.DomandaDiPagamento d in new SiarBLL.DomandaDiPagamentoCollectionProvider().Find(null,
                        null, Variante.IdProgetto, null))
                        if (d.DataInserimento > Variante.DataApprovazione)
                            throw new Exception("Non è possibile accogliere la richiesta di riesame perchè il beneficiario ha presentato una domanda di pagamento successiva a tale variante.");

                    //controllo che il beneficiario non abbia presentato domande di varianti/at posteriori all'approvazione di questa variante                            
                    foreach (SiarLibrary.Varianti v in VarianteProvider.Find(null, Variante.IdProgetto, null))
                        if (v.IdVariante > Variante.IdVariante)
                            throw new Exception("Non è possibile accogliere la richiesta di riesame perchè il beneficiario ha presentato una domanda di variante/a.t. successiva a tale variante.");

                    SiarLibrary.Protocollo p = new SiarLibrary.Protocollo();
                    byte[] doc = p.RicercaProtocollo(txtSegnaturaRiesame.Text, true);

                    richiesta_riesame = new SiarLibrary.VariantiSegnature();
                    richiesta_riesame.CodTipo = "RIV";
                    richiesta_riesame.IdVariante = Variante.IdVariante;
                    richiesta_riesame.Segnatura = txtSegnaturaRiesame.Text;
                    richiesta_riesame.RiapriVariante = ammetti;
                    messaggio = "Richiesta di riesame registrata correttamente con esito " + (ammetti ?
                        "positivo. La variante/a.t. viene riaperta in istruttoria." : "negativo.");

                    if (ammetti)
                    {
                        SiarLibrary.VariantiSegnature backup_segnatura_precedente = new SiarLibrary.VariantiSegnature();
                        backup_segnatura_precedente.IdVariante = Variante.IdVariante;
                        backup_segnatura_precedente.CodTipo = "APV";
                        backup_segnatura_precedente.Data = Variante.DataApprovazione;
                        backup_segnatura_precedente.Segnatura = Variante.SegnaturaApprovazione;
                        backup_segnatura_precedente.Operatore = Variante.Istruttore;
                        backup_segnatura_precedente.RiapriVariante = Variante.Approvata;//mi registro l'esito dell'istruttoria (precauzione)
                        backup_segnatura_precedente.Motivazione = "Record inserito automaticamente dopo accoglimento della richiesta di riesame. Backup dell`esito dell`istruttoria precedente: variante/a.t. "
                            + (Variante.Approvata ? "" : "NON") + " approvata.";
                        segnature_provider.Save(backup_segnatura_precedente);

                        Variante.Approvata = null;
                        Variante.SegnaturaApprovazione = null;
                        VarianteProvider.Save(Variante);
                        ucIVariantiControl.loadData();
                    }
                }
                richiesta_riesame.Data = DateTime.Now;
                richiesta_riesame.Operatore = Operatore.Utente.CfUtente;
                richiesta_riesame.Motivazione = txtMotivazioneRiesame.Text;
                segnature_provider.Save(richiesta_riesame);
                VarianteProvider.DbProviderObj.Commit();
                ShowMessage(messaggio);
            }
            catch (Exception ex) { VarianteProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        #endregion

        protected void btnAnnullamento_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.Protocollo richiesta = new SiarLibrary.Protocollo();
                byte[] doc = richiesta.RicercaProtocollo(txtSegnaturaAnnullamento.Text, true);
                Variante.SegnaturaAnnullamento = txtSegnaturaAnnullamento.Text;
                Variante.CfOperatoreAnnullamento = Operatore.Utente.CfUtente;
                Variante.DataAnnullamento = DateTime.Now;
                Variante.Annullata = true;
                VarianteProvider.Save(Variante);
                ucIVariantiControl.loadData();
                btnAnnullamento.Enabled = false;
                ShowMessage("Richiesta di annullamento della presente " + Variante.TipoVariante + " registrata correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnCercaDecreto_Click(object sender, EventArgs e)
        {
            try
            {
                //if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

                if ((new SiarBLL.CollaboratoriXBandoCollectionProvider().Find(null, Variante.IdProgetto, Operatore.Utente.IdUtente, null, true).Count == 0) &&
                    (new SiarBLL.BandoResponsabiliCollectionProvider().Find(Progetto.IdBando, Operatore.Utente.IdUtente, null, true, true).Count == 0))
                    throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

                int numero;
                int.TryParse(txtAttoNumero.Text, out numero);
                DateTime data;
                DateTime.TryParse(txtAttoData.Text, out data);
                string registro = lstAttoRegistro.SelectedValue;
                
                if (!string.IsNullOrEmpty(lstAttoRegistro.SelectedValue) && lstAttoRegistro.SelectedValue.IndexOf("|") > 0)
                    registro = lstAttoRegistro.SelectedValue.Substring(0, lstAttoRegistro.SelectedValue.IndexOf("|"));
                
                // controllo che l'atto sia registrato su db, altrimenti lo importo
                var atti_provider = new SiarBLL.AttiCollectionProvider();
                SiarLibrary.AttiCollection atti_trovati = atti_provider.Find(numero, data, lstAttoDefinizione.SelectedValue, registro);
                
                if (atti_trovati.Count == 0)
                {
                    atti_trovati = atti_provider.ImportaAtto(numero, data, lstAttoDefinizione.SelectedValue, lstAttoRegistro.SelectedValue);
                    if (atti_trovati.Count > 0) 
                        atti_provider.Save(atti_trovati[0]);
                }

                if (atti_trovati.Count > 0)
                {
                    decreto_variante = atti_trovati[0];
                    hdnIdAtto.Value = decreto_variante.IdAtto;
                }
                else ShowError("La ricerca non ha prodotto nessun risultato.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnAssociaDecreto_Click(object sender, EventArgs e)
        {
            try
            {
                
                //if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if ( (new SiarBLL.CollaboratoriXBandoCollectionProvider().Find(null, Variante.IdProgetto, Operatore.Utente.IdUtente, null, true).Count == 0) &&
                    (new SiarBLL.BandoResponsabiliCollectionProvider().Find(Progetto.IdBando, Operatore.Utente.IdUtente, null, true, true).Count == 0))
                    throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

                var atti_provider = new SiarBLL.AttiCollectionProvider();
                int id_decreto;
                if (int.TryParse(hdnIdAtto.Value, out id_decreto))
                    decreto_variante = atti_provider.GetById(id_decreto);

                if (decreto_variante == null) throw new Exception("Per proseguire è necessario specificare l'atto di riferimento.");
                if (Variante == null) throw new Exception("Per proseguire è necessario specificare la variante di riferimento.");

                string messaggio;
                if (Variante.IdAttoApprovazione != null)
                    messaggio = "Decreto aggiornato correttamente";
                else
                    messaggio = "Decreto associato correttamente";
                    
                Variante.IdAttoApprovazione = id_decreto;
                new SiarBLL.VariantiCollectionProvider().Save(Variante);
                ShowMessage(messaggio);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnAssociaDecretoOrg_Click(object sender, EventArgs e)
        {
            try
            {

                //if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if ((new SiarBLL.CollaboratoriXBandoCollectionProvider().Find(null, Variante.IdProgetto, Operatore.Utente.IdUtente, null, true).Count == 0) &&
                    (new SiarBLL.BandoResponsabiliCollectionProvider().Find(Progetto.IdBando, Operatore.Utente.IdUtente, null, true, true).Count == 0))
                    throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

                var atti_provider = new SiarBLL.AttiCollectionProvider();
                SiarLibrary.Atti decreto = new SiarLibrary.Atti();
                decreto.CodTipo = "A";
                decreto.CodDefinizione = "D";
                decreto.CodOrganoIstituzionale = "OI";
                decreto.Numero = new SiarLibrary.NullTypes.IntNT(txtNumeroDecretoOrg.Text);
                decreto.Data = txtDataDecretoOrg.Text;
                decreto.Descrizione = txtDescrizioneDecretoOrg.Text;
                decreto.LinkEsterno = txtLinkEst.Text;
                atti_provider.Save(decreto);
                
                if (Variante == null) throw new Exception("Per proseguire è necessario specificare la variante di riferimento.");

                string messaggio;
                if (Variante.IdAttoApprovazione != null)
                    messaggio = "Decreto aggiornato correttamente";
                else
                    messaggio = "Decreto associato correttamente";

                Variante.IdAttoApprovazione = decreto.IdAtto;
                new SiarBLL.VariantiCollectionProvider().Save(Variante);
                ShowMessage(messaggio);
            }
            catch (Exception ex) { ShowError(ex); }
        }
       

        #region comunicazione esito istruttorio

        protected void btnFirmaComunicazione_Click(object sender, EventArgs e)
        {
            try
            {
                if (Variante.Approvata == null || Variante.SegnaturaApprovazione == null)
                    throw new Exception("La variante non è stata chiusa correttamente. Si prega di contattare l'helpdesk per risolvere il problema.");
                SiarLibrary.VariantiSegnatureCollection filtrosegnature = segnature_provider.Find(Variante.IdVariante, "CEI", null);
                if (filtrosegnature.Count > 0) throw new Exception("Il documento è già stato firmato. Impossibile continuare.");
                string cf_utente = Operatore.Utente.CfUtente;

                //Ora solo il dirigente della PF può firmare e comunicare
                var profilo = new SiarBLL.ProfiliCollectionProvider().GetById(Operatore.Utente.IdProfilo);
                if (!profilo.Descrizione.Like("%Dirigente della P.F.%"))
                        throw new Exception("Solo il Dirigente della P.F. è abilitato alla firma del documento.");

                //if (new SiarBLL.BandoResponsabiliCollectionProvider().Find(Progetto.IdBando, Operatore.Utente.IdUtente, Progetto.ProvinciaDiPresentazione, null, true).Count == 0)
                    //throw new Exception("Solo il responsabile provinciale di istruttoria è abilitato alla firma del documento.");

                //if (new SiarBLL.ResponsabiliXBandoCollectionProvider().Find(null, Progetto.IdBando, cf_utente,
                //    null, null).FiltroProvincia(Progetto.ProvinciaDiPresentazione, null).Count == 0)
                //    throw new Exception("Solo il responsabile provinciale di istruttoria è abilitato alla firma del documento.");

                System.Collections.ArrayList parametri = new System.Collections.ArrayList();
                parametri.Add(Variante.IdVariante.ToString());
                parametri.Add(Variante.IdProgetto.ToString());
                ucFirmaDocumento.loadDocumento(cf_utente, (string[])parametri.ToArray(typeof(string)));
                //ucFirmaDocumento.loadDocumento(cf_utente, Variante.IdVariante);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnComunicazionePost_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ucFirmaDocumento.FileFirmato))
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk e segnalare il problema.");
                if (ucIVariantiControl.Impresa != null)
                {
                    SiarBLL.BandoCollectionProvider bando_provider = new SiarBLL.BandoCollectionProvider();
                    SiarLibrary.Bando b = bando_provider.GetById(Progetto.IdBando);
                    if (b == null) throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk e segnalare il problema.");

                    SiarLibrary.Protocollo comunicazione = new SiarLibrary.Protocollo(b.CodEnte);
                    comunicazione.setCorrispondente(ucIVariantiControl.Impresa,Progetto.IdProgetto, "destinatario");
                    comunicazione.setDocumento("comunicazione_esito_istruttorio_idvar_" + Variante.IdVariante + "_iddom_"
                        + Variante.IdProgetto + ".pdf", Convert.FromBase64String(ucFirmaDocumento.FileFirmato));
                    string[] ss = bando_provider.GetDatiXProtocollazione(Progetto.IdBando, Progetto.ProvinciaDiPresentazione);
                    string oggetto = "Comunicazione di esito istruttorio di " + Variante.TipoVariante.Value.ToUpper()
                        + " domanda di aiuto nr. " + Progetto.IdProgetto + " in risposta al bando: " + ss[0] + " del " + ss[1] + " con scadenza: "
                        + ss[2] + "\n" + ss[3] 
                        + "\n Partita iva/Codice fiscale: " + ucIVariantiControl.Impresa.Cuaa
                        + "\n Ragione sociale: " + ucIVariantiControl.Impresa.RagioneSociale;
                    string segnatura = comunicazione.ProtocolloUscita(oggetto, ss[4], true);
                    try
                    {
                        SiarLibrary.VariantiSegnature segnatura_comunicazione = new SiarLibrary.VariantiSegnature();
                        segnatura_comunicazione.Segnatura = segnatura;
                        segnatura_comunicazione.IdVariante = Variante.IdVariante;
                        segnatura_comunicazione.Data = DateTime.Now;
                        segnatura_comunicazione.CodTipo = "CEI";
                        segnatura_comunicazione.Operatore = Operatore.Utente.CfUtente;
                        segnatura_comunicazione.RiapriVariante = false;
                        segnature_provider.Save(segnatura_comunicazione);
                        ShowMessage("Comunicazione di esito istruttorio di " + Variante.TipoVariante + " firmata e protocollata correttamente.");
                    }
                    catch (Exception ex)
                    {
                        string oggettoEmail = "Errore durante la comunicazione";
                        string testEmail = "Id domanda: " + Progetto.IdProgetto + "\nId variante: "
                            + Variante.IdVariante + "\nSegnatura: " + segnatura + "\n\n" + ex.Message;
                        EmailUtility.SendEmailToTeamSigef(ex, oggettoEmail, testEmail);
                        ShowError(ex);
                    }
                }
                else ShowError("L'impresa titolare della domanda è inesistente. Impossibile continuare.");
            }
            catch (Exception exc) { ShowError(exc); }
            finally { ucFirmaDocumento.FileFirmato = null; }
        }

        protected void btnStampaComunicazione_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.Protocollo doc = new SiarLibrary.Protocollo();
                byte[] report = doc.RicercaProtocollo(txtSegnaturaComunicazione.Text, true);
                Session["doc"] = report;
                RegisterClientScriptBlock("window.open('../../../VisualizzaDocumento.aspx');");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        #endregion
    }
}