using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace web.Private.admin
{
    public partial class GestioneEnte : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "gestione_ente";
            base.OnPreInit(e);
        }

        SiarLibrary.Utenti utente;
        SiarBLL.UtentiCollectionProvider utenti_provider = new SiarBLL.UtentiCollectionProvider();
        //SiarBLL.CfAbilitatiXUtenteCollectionProvider cf_provider = new SiarBLL.CfAbilitatiXUtenteCollectionProvider();
        int progetti_provvisori = 0, progetti_definitivi = 0, pagamenti_provvisori = 0, pagamenti_definitivi = 0,
            varianti_provvisorie = 0, varianti_definitive = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            utente = Operatore.Utente;
        }

        protected override void OnPreRender(EventArgs e)
        {
            lstProvincia.CodRegione = "11";
            lstProvincia.DataBind();
            txtNomeEnte.Text = utente.Ente;
            if (utente.Provincia != null)
            {
                lstProvincia.SelectedValue = utente.Provincia;
                lstProvincia.Enabled = false;
            }
            else lstProvincia.Attributes.Add("onchange", "document.getElementById('ctl00_cphContenuto_btnPost').click();");

            SiarLibrary.UtentiCollection utenti;
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    tabCuaa.Visible = false;
                    tabStatistiche.Visible = false;
                    ucSiarNewTab.Width = tabOperatori.Width;
                    txtCodFiscale.AddJSAttribute("onblur", "ctrlCF();");
                    lstProfilo.CodTipoEnte = Operatore.Utente.CodTipoEnte;
                    lstProfilo.DataBind();
                    utenti = utenti_provider.Find(null, null, null, utente.CodEnte, null, null, null);
                    if (!string.IsNullOrEmpty(lstProvincia.SelectedValue))
                        utenti = utenti.FiltroProvincia(lstProvincia.SelectedValue, null, null);
                    lblNumeroOperatori.Text = utenti.Count.ToString();
                    dgUtenti.DataSource = utenti;
                    if (AbilitaModifica) dgUtenti.ItemDataBound += new DataGridItemEventHandler(dgUtenti_ItemDataBound);
                    dgUtenti.DataBind();
                    break;
                case 3:
                    tabOperatori.Visible = false;
                    tabStatistiche.Visible = false;
                    ucSiarNewTab.Width = tabCuaa.Width;
                    if (string.IsNullOrEmpty(txtDataFV.Text)) txtDataFV.Text = "31/12/2013";
                    if (string.IsNullOrEmpty(txtDataInizio.Text)) txtDataInizio.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtCFabilitato.AddJSAttribute("onblur", "ctrlCUAA();");
                    //SiarLibrary.CfAbilitatiXUtenteCollection cf_abilitati = cf_provider.Find(null, utente.CodEnte, null, null, null);
                    //lblNumeroCuaaAbilitati.Text = cf_abilitati.Count.ToString();
                    //dgCuaaAbilitati.DataSource = cf_abilitati;
                    //if (AbilitaModifica) dgCuaaAbilitati.ItemDataBound += new DataGridItemEventHandler(dgCuaaAbilitati_ItemDataBound);
                    //dgCuaaAbilitati.DataBind();
                    break;
                default:
                    tabOperatori.Visible = false;
                    tabCuaa.Visible = false;
                    ucSiarNewTab.Width = tabStatistiche.Width;
                    utenti = utenti_provider.GetStatisticaOperatoriEnte(utente.CodEnte, lstProvincia.SelectedValue);

                    int numero_operatori = 0, numero_coordinatori = 0;
                    foreach (SiarLibrary.Utenti u in utenti)
                    {
                        if (u.IdProfilo == 2) numero_coordinatori++;
                        else numero_operatori++;
                    }
                    txtNumeroCoordinatori.Text = numero_coordinatori.ToString();
                    txtNumeroOperatori.Text = numero_operatori.ToString();
                    //utenti.Sort("Nominativo, DataFineValidita DESC");
                    dgStatistiche.DataSource = utenti;
                    dgStatistiche.ItemDataBound += new DataGridItemEventHandler(dgStatistiche_ItemDataBound);
                    dgStatistiche.ShowFooter = true;
                    dgStatistiche.DataBind();
                    break;
            }
            base.OnPreRender(e);
        }

        #region statistiche

        void dgStatistiche_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[4].Text = progetti_provvisori.ToString();
                e.Item.Cells[5].Text = progetti_definitivi.ToString();
                e.Item.Cells[6].Text = pagamenti_provvisori.ToString();
                e.Item.Cells[7].Text = pagamenti_definitivi.ToString();
                e.Item.Cells[8].Text = varianti_provvisorie.ToString();
                e.Item.Cells[9].Text = varianti_definitive.ToString();
            }
            else if (e.Item.ItemType != ListItemType.Header)
            {
                SiarLibrary.Utenti u = (SiarLibrary.Utenti)e.Item.DataItem;
                e.Item.Cells[4].Text = u.AdditionalAttributes["ProgettiProvvisori"];
                e.Item.Cells[5].Text = u.AdditionalAttributes["ProgettiDefinitivi"];
                e.Item.Cells[6].Text = u.AdditionalAttributes["PagamentiProvvisori"];
                e.Item.Cells[7].Text = u.AdditionalAttributes["PagamentiDefinitivi"];
                e.Item.Cells[8].Text = u.AdditionalAttributes["VariantiProvvisorie"];
                e.Item.Cells[9].Text = u.AdditionalAttributes["VariantiDefinitive"];
                progetti_provvisori += int.Parse(u.AdditionalAttributes["ProgettiProvvisori"]);
                progetti_definitivi += int.Parse(u.AdditionalAttributes["ProgettiDefinitivi"]);
                pagamenti_provvisori += int.Parse(u.AdditionalAttributes["PagamentiProvvisori"]);
                pagamenti_definitivi += int.Parse(u.AdditionalAttributes["PagamentiDefinitivi"]);
                varianti_provvisorie += int.Parse(u.AdditionalAttributes["VariantiProvvisorie"]);
                varianti_definitive += int.Parse(u.AdditionalAttributes["VariantiDefinitive"]);

                if (!u.Attivo) e.Item.BackColor = System.Drawing.Color.FromArgb(215, 215, 210);
            }
        }

        #endregion

        #region operatori

        void dgUtenti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                SiarLibrary.Utenti u = (SiarLibrary.Utenti)e.Item.DataItem;
                e.Item.Cells[6].Text = "<input type='button' class='ButtonGrid' style='width:110px' value='Elimina operatore' onclick=\"delUtente("
                    + u.IdUtente + ");\" />";
            }
        }

        protected void btnDelUtente_Click(object sender, EventArgs e)
        {
            try
            {
                //int userId;
                //if (!int.TryParse(hdnIdOperatore.Text, out userId))
                //    throw new Exception("Operatore selezionato non valido");
                //SiarLibrary.Utenti u = utenti_provider.GetById(userId);
                //u.DataFineValidita = DateTime.Now;
                //u.OperatoreFineValidita = utente.CfUtente;
                //utenti_provider.Save(u);
                //System.Threading.Thread.Sleep(1000);
                //ShowMessage("Utente eliminato.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnNuovoOperatore_Click(object sender, EventArgs e)
        {
            try
            {
                //int id_persona;
                //if (!int.TryParse(hdnIdPersona.Text, out id_persona))
                //    throw new Exception("Persona fisica non valida. Occorre richiamare di nuovo l`anagrafe tributaria.");
                //SiarLibrary.Utenti u = new SiarLibrary.Utenti();
                //u.CfUtente = txtCodFiscale.Text.ToUpper();
                //u.Nominativo = txtCognome.Text.ToUpper() + " " + txtNome.Text.ToUpper();
                //u.IdProfilo = lstProfilo.SelectedValue;
                //u.CodEnte = utente.CodEnte;
                //u.Provincia = lstProvincia.SelectedValue;
                //u.DataFineValidita = txtDataFVOperatore.Text + " 23:59:59";
                //u.OperatoreInserimento = utente.CfUtente;
                //u.IdPersonaFisica = id_persona;
                //utenti_provider.Save(u);
                //ShowMessage("Utente inserito correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnScarica_Click(object sender, EventArgs e)
        {
            try
            {
                SianWebSrv.TraduzioneSianToSiar trad = new SianWebSrv.TraduzioneSianToSiar();
                SiarLibrary.PersonaFisica persona = trad.ScaricaDatiPersonaFisica(txtCodFiscale.Text.ToUpper(),
                    utente.CfUtente);
                txtCognome.Text = persona.Cognome;
                txtNome.Text = persona.Nome;
                hdnIdPersona.Text = persona.IdPersona;
                ShowMessage("Persona fisica registrata correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        #endregion

        #region cuaa

        void dgCuaaAbilitati_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                //SiarLibrary.CfAbilitatiXUtente u = (SiarLibrary.CfAbilitatiXUtente)e.Item.DataItem;
                //e.Item.Cells[4].Text = "<input type='button' class='ButtonGrid' style='width:110px' value='Elimina' onclick=\"delCuaa("
                //    + u.IdAbilitato + ");\" />";
            }
        }

        protected void btnNuovoCuaa_Click(object sender, EventArgs e)
        {
            try
            {
                //if (DateTime.Parse(txtDataInizio.Text) < DateTime.Now.Date)
                //    throw new Exception("Data di inizio validità anteriore alla data corrente. Impossibile continuare.");
                //if (cf_provider.Find(null, utente.CodEnte, null, txtCFabilitato.Text, null).Count > 0)
                //    throw new Exception("Il CUAA è già abilitato.");

                //SianWebSrv.TraduzioneSianToSiar trad = new SianWebSrv.TraduzioneSianToSiar();
                //trad.ScaricaDatiAzienda(txtCFabilitato.Text.ToUpper(), null, utente.CfUtente);
                //SiarBLL.ImpresaCollectionProvider impresaColl = new SiarBLL.ImpresaCollectionProvider();
                //SiarLibrary.Impresa impresa = impresaColl.GetByCuaa(txtCFabilitato.Text.ToUpper());
                //txtRagSociale.Text = impresa.RagioneSociale;

                //SiarLibrary.CfAbilitatiXUtente ca = new SiarLibrary.CfAbilitatiXUtente();
                //ca.CodEnte = utente.CodEnte;
                //ca.CfAbilitato = txtCFabilitato.Text.ToUpper();
                //ca.DataInizioValidita = txtDataInizio.Text;
                //ca.DataFineValidita = txtDataFV.Text + " 23:59:59";
                //ca.OperatoreInserimento = utente.CfUtente;
                //cf_provider.Save(ca);
                //ShowMessage("CUAA registrato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnDelCuaa_Click(object sender, EventArgs e)
        {
            try
            {
                //int id_abilitato;
                //if (!int.TryParse(hdnDelCuaa.Text, out id_abilitato))
                //    throw new Exception("Cuaa non esistente. Impossibile continuare.");
                //SiarLibrary.CfAbilitatiXUtente cf = cf_provider.GetById(id_abilitato);
                //if (cf == null) throw new Exception("Cuaa non esistente. Impossibile continuare.");
                //cf.DataFineValidita = DateTime.Now;
                //cf.OperatoreFineValidita = utente.CfUtente;
                //cf_provider.Save(cf);
                //ShowMessage("CUAA eliminato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        #endregion

        protected void btnPost_Click(object sender, EventArgs e)
        {
            //utilizzato per il post sulla selezione della provincia            
        }


    }
}