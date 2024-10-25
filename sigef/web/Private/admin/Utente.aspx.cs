using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace web.Private.admin
{
    /// <summary>
    /// Summary description for Utente.
    /// </summary>
    public partial class Utente : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "Utenti";
            base.OnPreInit(e);
        }

        SiarBLL.UtentiCollectionProvider utenti_provider = new SiarBLL.UtentiCollectionProvider();
        SiarBLL.UtentiStoricoCollectionProvider storico_provider = new SiarBLL.UtentiStoricoCollectionProvider();
        SiarLibrary.Utenti utente_selezionato;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            AbilitaModifica = Operatore.Utente.CodTipoEnte == "%";
        }

        protected override void OnPreRender(EventArgs e)
        {
            txtRicercaCF.AddJSAttribute("onblur", "ctrlCF(this,event);");
            txtCodFiscale.AddJSAttribute("onblur", "ctrlCF(this,event);");
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    tbElenco.Visible = false;
                    tbDettaglioRuolo.Visible = false;
                    lstProvincia.DataBind();
                    SiarLibrary.UtentiStoricoCollection storico_utente = null;
                    int id_utente;
                    if (int.TryParse(hdnIdUtente.Value, out id_utente))
                        utente_selezionato = utenti_provider.GetById(id_utente);
                    if (utente_selezionato != null)
                    {
                        bool? attivo = null;
                        if (chkAttivo.Checked) attivo = true;
                        storico_utente = new SiarBLL.UtentiStoricoCollectionProvider().Find(utente_selezionato.IdUtente, null, null, attivo);
                        txtCodFiscale.Text = utente_selezionato.CfUtente;
                        txtNominativo.Text = utente_selezionato.Nominativo;
                        //if (string.IsNullOrEmpty(ucProfilo.CodEnte))
                        //    ucProfilo.CodEnte = utente_selezionato.CodEnte;
                        //if (string.IsNullOrEmpty(ucProfilo.IdProfilo))
                        //    ucProfilo.IdProfilo = utente_selezionato.IdProfilo;
                        hdnIdPersonaFisica.Value = utente_selezionato.IdPersonaFisica;
                        //if (string.IsNullOrEmpty(lstProvincia.SelectedValue))
                        //    lstProvincia.SelectedValue = utente_selezionato.Provincia;
                        //chkAttivo.Checked = utente_selezionato.Attivo;
                        //txtAttivo.Text = (utente_selezionato.Attivo ? "Attivo" : " Non attivo");
                        btnScarica.Enabled = false;
                        btnSalva.Enabled = false;
                        //if (!utente_selezionato.Attivo)
                        //{
                        //    btnSalva.Text = "Riabilita operatore";
                        //    btnDisabilita.Enabled = false;
                        //}
                    }
                    else
                    {
                        btnSalva.Enabled = true;
                    }
                    if (storico_utente == null) storico_utente = new SiarLibrary.UtentiStoricoCollection();
                    dgUtentiStorico.DataSource = storico_utente;
                    if (storico_utente.Count == 0) dgUtentiStorico.Titolo = "Nessun elemento trovato.";
                    dgUtentiStorico.DataBind();
                    break;
                case 3:
                    tbElenco.Visible = false;
                    tbDettaglio.Visible = false;
                    int id_utente_storico;
                    if (int.TryParse(hdnIdUtenteStorico.Value, out id_utente_storico))
                    {
                        tbRuoloNuovo.Visible = false;
                        tbRuoloEsistente.Visible = true;
                        SiarLibrary.UtentiStorico storico_u = null;
                        storico_u = new SiarBLL.UtentiStoricoCollectionProvider().GetById(id_utente_storico);
                        txtNominativoDett.Text = utenti_provider.GetById(storico_u.IdUtente).Nominativo;
                        txtEnteDett.Text = storico_u.Ente;
                        txtRuoloDett.Text = storico_u.Profilo;
                        txtRuoloProv.Text = storico_u.Provincia;
                        txtEmailRO.Text = storico_u.Email;
                        if (storico_u.Attivo)
                        { 
                            btnDisabilita.Visible = true;
                            btnRiabilita.Visible = false;
                            btnAggiornaEmail.Visible = true;
                            txtEmailRO.ReadOnly = false;
                        }
                        else
                        {
                            btnDisabilita.Visible = false;
                            btnRiabilita.Visible = true;
                            btnAggiornaEmail.Visible = false;
                        }
                        
                    }
                    else
                    {
                        tbRuoloNuovo.Visible = true;
                        tbRuoloEsistente.Visible = false;
                        ucProfilo.AbilitaModifica = true; // in caso di inerimento nuovo utente faccio selezionare solo gli enti attivi
                        lstProvincia.DataBind();
                        int id_utenteN;
                        if (int.TryParse(hdnIdUtente.Value, out id_utenteN))
                        {
                            //btnSalvaRuolo.Enabled = true;
                            SiarLibrary.Utenti ut = utenti_provider.GetById(id_utenteN);
                            txtNominativoDett.Text = ut.Nominativo;
                        }
                        else
                            btnSalvaRuolo.Enabled = false;
                    }
                    break;
                default:
                    tbDettaglio.Visible = false;
                    tbDettaglioRuolo.Visible = false;
                    lstRicercaProfilo.DataBind();
                    lstRicercaEnte.DataBind();
                    string nominativo_like_this = null;
                    if (!string.IsNullOrEmpty(txtRicercaNominativo.Text)) nominativo_like_this = "%" + txtRicercaNominativo.Text + "%";
                    SiarLibrary.UtentiCollection utenti = utenti_provider.Find(txtRicercaCF.Text, null, nominativo_like_this, lstRicercaEnte.SelectedValue,
                        lstRicercaProfilo.SelectedValue, null, null);
                    lblNrUtenti.Text = utenti.Count.ToString();
                    dgUtenti.DataSource = utenti;
                    dgUtenti.DataBind();
                    hdnIdUtente.Value = null;
                    hdnIdPersonaFisica.Value = null;
                    hdnIdUtenteStorico.Value = null;
                    break;
            }
            base.OnPreRender(e);
        }

        protected void btnCerca_Click(object sender, EventArgs e)
        {

        }

        protected void btnScarica_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodFiscale.Text) || txtCodFiscale.Text.Length != 16)
                    throw new Exception("Digitare un codice fiscale valido.");
                SiarLibrary.PersonaFisica pf;
                SiarLibrary.PersonaFisicaCollection persone_trovate = new SiarBLL.PersonaFisicaCollectionProvider().Find(txtCodFiscale.Text);
                if (persone_trovate.Count > 0 && persone_trovate[0].Nome != null) pf = persone_trovate[0];
                else
                {
                    SianWebSrv.TraduzioneSianToSiar trad = new SianWebSrv.TraduzioneSianToSiar();
                    pf = trad.ScaricaDatiPersonaFisica(txtCodFiscale.Text, Operatore.Utente.CfUtente);
                }
                if (pf == null) throw new Exception("Il codice fiscale non corrisponde a nessuna persona fisica conosciuta.");
                hdnIdPersonaFisica.Value = pf.IdPersona;
                txtNominativo.Text = pf.Cognome + " " + pf.Nome;
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalva_Click(object sender, System.EventArgs e)
        {
            try
            {
                int id_persona_fisica;
                if (!int.TryParse(hdnIdPersonaFisica.Value, out id_persona_fisica))
                    throw new Exception("E` necessario scaricare i dati anagrafici per l`operatore selezionato.");
                //if (!string.IsNullOrEmpty(ucProfilo.CodEnte))
                //{
                //    SiarLibrary.Ente ente = new SiarBLL.EnteCollectionProvider().GetById(ucProfilo.CodEnte);
                //    if (ente != null && ente.CodTipoEnte == "CAA") throw new Exception("Utenti di tipo CAA possono essere salvati/abilitati solo attraverso la VALIDAZIONE CAA.");
                //}
                SiarLibrary.Utenti u = null;
                SiarLibrary.UtentiCollection uu = utenti_provider.Find(null, id_persona_fisica, null, null, null, null, null);
                if (uu.Count > 0) throw new Exception("Utente già esistente.");
                
                u = new SiarLibrary.Utenti();
                u.IdPersonaFisica = id_persona_fisica;
                utenti_provider.Save(u);

                
                SiarLibrary.UtentiStorico us = new SiarLibrary.UtentiStorico();
                us.IdUtente = u.IdUtente;
                us.IdProfilo = 42;
                us.CodEnte = null;
                us.Provincia = null;
                us.Attivo = true;
                us.Operatore = Operatore.Utente.IdUtente;
                us.Data = DateTime.Today;
                storico_provider.Save(us);
                u.IdStoricoUltimo = us.Id;
                utenti_provider.Save(u);
                hdnIdUtente.Value = u.IdUtente;
                ShowMessage("Dati operatore salvati correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnDisabilita_Click(object sender, EventArgs e)
        {
            try
            {
                int id_utente_storico;
                if (!int.TryParse(hdnIdUtenteStorico.Value, out id_utente_storico)) throw new Exception("Nessun ruolo selezionato.");
                SiarLibrary.UtentiStorico us = storico_provider.GetById(id_utente_storico);
                SiarLibrary.Utenti utente = utenti_provider.GetById(us.IdUtente);

                //controllo se è l unico ruolo attivo
                SiarLibrary.UtentiStoricoCollection us_coll = storico_provider.Find(us.IdUtente, null,null,true);
                if (us_coll.Count == 1) throw new Exception("Impossibili disabilitare l'unico ruolo attivo per l'utente.");
                
                us.Attivo = false;
                storico_provider.Save(us);

                //imposto l'id_storico_ultimo al ruolo piu recente
                if (utente.IdStoricoUltimo == us.Id)
                {
                    us_coll = storico_provider.Find(us.IdUtente, null, null, true);
                    int id_max = 0;
                    foreach (SiarLibrary.UtentiStorico us_temp in us_coll)
                    { 
                        if(id_max< us_temp.Id )
                            id_max = us_temp.Id;
                    }
                    utente.IdStoricoUltimo = id_max;
                    utenti_provider.Save(utente);
                }

                ShowMessage("Operatore disabilitato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnNuovo_Click(object sender, EventArgs e)
        {
            hdnIdPersonaFisica.Value = null;
            hdnIdUtente.Value = null;
            hdnIdUtenteStorico.Value = null;
            txtCodFiscale.Text = null;
            txtNominativo.Text = null;
            //ucProfilo.PulisciCampi();
            //hdnIdPersonaFisica.Value = null;
            //lstProvincia.ClearSelection();
            //txtAttivo.Text = null;
            //chkAttivo.Checked = false;
        }

        protected void btnRiabilita_Click(object sender, EventArgs e)
        {
            try
            {
                int id_utente_storico;
                if (!int.TryParse(hdnIdUtenteStorico.Value, out id_utente_storico)) throw new Exception("Nessun ruolo selezionato.");
                SiarLibrary.UtentiStorico us = storico_provider.GetById(id_utente_storico);
                us.Attivo = true;
                storico_provider.Save(us);
                ShowMessage("Operatore abilitato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnFiltra_Click(object sender, EventArgs e)
        {
            dgUtentiStorico.SetPageIndex(0);
        }

        protected void btnSalvaRuolo_click(object sender, EventArgs e)
        {
            try
            {
                int id_utente;
                if (int.TryParse(hdnIdUtente.Value, out id_utente))
                    utente_selezionato = utenti_provider.GetById(id_utente);
                else
                    throw new Exception("Utente non selezionato.");
                SiarLibrary.UtentiStoricoCollection us_coll_esistenti = storico_provider.Find(id_utente, ucProfilo.CodEnte, ucProfilo.IdProfilo,null);
                if (us_coll_esistenti.Count > 0) throw new Exception("Ruolo dell'utente già esistente.");
                SiarLibrary.UtentiStorico us = new SiarLibrary.UtentiStorico();
                us.IdUtente = utente_selezionato.IdUtente;
                us.IdProfilo = ucProfilo.IdProfilo;
                us.CodEnte = ucProfilo.CodEnte;
                us.Provincia = lstProvincia.SelectedValue;
                us.Attivo = true;
                us.Operatore = Operatore.Utente.IdUtente;
                us.Data = DateTime.Today;
                if (txtEmail.Text != null && txtEmail.Text != "")
                    us.Email = txtEmail.Text;
                storico_provider.Save(us);
                utente_selezionato.IdStoricoUltimo = us.Id;
                utenti_provider.Save(utente_selezionato);
                hdnIdUtente.Value = utente_selezionato.IdUtente;
                btnSalvaRuolo.Enabled = false;
                ShowMessage("Ruolo salvato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnAggiornaEmail_click(object sender, EventArgs e)
        {
            try
            {
                int id_utente_storico;
                if (!int.TryParse(hdnIdUtenteStorico.Value, out id_utente_storico)) throw new Exception("Nessun ruolo selezionato.");
                if (txtEmailRO.Text == "" || txtEmailRO.Text == null) throw new Exception("Nessuna email inserita.");
                SiarLibrary.UtentiStorico us = storico_provider.GetById(id_utente_storico);
                us.Email = txtEmailRO.Text;
                storico_provider.Save(us);
                ShowMessage("Indirizzo email aggiornato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

    }
}
