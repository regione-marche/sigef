using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.admin
{
    public partial class MandatiImpresaUtente : SiarLibrary.Web.PrivatePage
    {
        private int _idProfiloConsulete = int.Parse(System.Configuration.ConfigurationManager.AppSettings["Profilo_Consulente"]);

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "mandati_impresa_utente";
            base.OnPreInit(e);
        }

        SiarBLL.MandatiImpresaCollectionProvider mandati_provider = new SiarBLL.MandatiImpresaCollectionProvider();
        SiarLibrary.Utenti utente_selezionato;

        protected void Page_Load(object sender, EventArgs e)
        {
            // imposto di default l'utente corrente
            utente_selezionato = ((SiarLibrary.Web.MasterPage)Master).Operatore.Utente;
            int id_utente;
            // se non e' un consulente permetto di editare l'utente in querystring
            if (int.TryParse(Request.QueryString["idt"], out id_utente) && utente_selezionato.IdProfilo != _idProfiloConsulete)
                utente_selezionato = new SiarBLL.UtentiCollectionProvider().GetById(id_utente);
        }

        protected override void OnPreRender(EventArgs e)
        {
            txtDataInizio.Text = DateTime.Now.ToString("yyyy-MM-dd");
            if (utente_selezionato != null)
            {
                txtNominativoOperatore.Text = utente_selezionato.Nominativo;
                txtCFOperatore.Text = utente_selezionato.CfUtente;
                txtRuoloOperatore.Text = utente_selezionato.Profilo;
                txtEnteOperatore.Text = utente_selezionato.Ente;
                string cuaa = null, piva = null, ragione_sociale = null;
                if (!string.IsNullOrEmpty(txtRicercaCuaa.Text))
                {
                    if (txtRicercaCuaa.Text.Length == 16) cuaa = txtRicercaCuaa.Text;
                    else if (txtRicercaCuaa.Text.Length == 11) piva = txtRicercaCuaa.Text;
                }
                if (!string.IsNullOrEmpty(txtRicercaRagioneSociale.Text)) ragione_sociale = "%" + txtRicercaRagioneSociale.Text + "%";

                SiarLibrary.MandatiImpresaCollection mandati_utente = mandati_provider.Find(null, cuaa, piva, ragione_sociale, utente_selezionato.IdUtente,
                    null, null, "PSR", null);
                dgMandati.DataSource = mandati_utente;
                dgMandati.ItemDataBound += new DataGridItemEventHandler(dgMandati_ItemDataBound);
                lblNumeroAbilitati.Text = mandati_utente.Count.ToString();
                dgMandati.DataBind();
            }
            txtCFabilitato.AddJSAttribute("onblur", "ctrlCuaa(this,event);");
            base.OnPreRender(e);
        }

        void dgMandati_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.MandatiImpresa m = (SiarLibrary.MandatiImpresa)e.Item.DataItem;
                if (m.RagioneSociale == null)
                {
                    e.Item.HorizontalAlign = HorizontalAlign.Center;
                    e.Item.Cells[3].Text = "<input type='Button' class='btn btn-secondary py-1' value='Scarica anagrafica impresa' onclick='scaricaDatiImpresa("
                    + m.IdImpresa + ");' />";
                }
                if (m.Attivo) e.Item.Cells[5].Text = "<input type='Button' class='btn btn-secondary py-1' value='Revoca mandato' onclick='revocaMandato(" + m.Id + ");' />";
                else
                {
                    e.Item.Cells[5].Text = "SCADUTO/REVOCATO";
                    e.Item.BackColor = System.Drawing.Color.FromArgb(204, 204, 179);
                }
            }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime data_inizio, data_fine;
                if (!DateTime.TryParse(txtDataInizio.Text, out data_inizio)) throw new Exception("Digitare una data di inizio valida.");
                if (!DateTime.TryParse(txtDataFV.Text, out data_fine) || data_fine < DateTime.Now) throw new Exception("Digitare una data di fine validità coerente.");
                int id_impresa;
                if (!int.TryParse(hdnIdImpresa.Value, out id_impresa)) throw new Exception("Impresa non trovata o Partita iva/Codice fiscale non valida.");
                if (utente_selezionato != null)
                {
                    if (mandati_provider.Find(id_impresa, null, null, null, utente_selezionato.IdUtente, null, null, "PSR", true).Count > 0)
                        throw new Exception("Il mandato dell'impresa è già stato registrato.");

                    SiarLibrary.MandatiImpresa mandato = new SiarLibrary.MandatiImpresa();
                    mandato.IdImpresa = id_impresa;
                    mandato.IdUtenteAbilitato = utente_selezionato.IdUtente;
                    mandato.TipoMandato = "PSR";
                    mandato.Attivo = true;
                    mandato.DataInizioValidita = data_inizio;
                    mandato.DataFineValidita = data_fine;
                    mandato.IdOperatoreInizio = ((SiarLibrary.Web.MasterPage)Master).Operatore.Utente.IdUtente;
                    mandati_provider.Save(mandato);
                    ShowMessage("Mandato aziendale registrato correttamente.");
                    hdnIdImpresa.Value = null;
                    txtRagSociale.Text = null;
                    txtCFabilitato.Text = null;
                    txtDataFV.Text = null;
                }
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnScaricaAT_Click(object sender, EventArgs e)
        {
            try
            {
                if (utente_selezionato != null)
                {
                    //SiarLibrary.DbStaticProvider.isCuaa(txtCFabilitato.Text);
                    SiarBLL.ImpresaCollectionProvider impresaColl = new SiarBLL.ImpresaCollectionProvider();
                    SiarLibrary.Impresa impresa = impresaColl.GetByCuaa(txtCFabilitato.Text.ToUpper());
                    if (impresa == null)
                    {
                        SianWebSrv.TraduzioneSianToSiar trad = new SianWebSrv.TraduzioneSianToSiar();
                        //trad.ScaricaDatiAzienda(txtCFabilitato.Text.ToUpper(), null, utente_selezionato.CfUtente);
                        //trad.ScaricaDatiAzienda(txtCFabilitato.Text.ToUpper(), null, ((SiarLibrary.Web.MasterPage)Page.Master).Operatore.Utente.CfUtente);
                        if (System.Configuration.ConfigurationManager.AppSettings["ScaricaImpresa_CFOperatore"] != "")
                            trad.ScaricaDatiAzienda(txtCFabilitato.Text.ToUpper(), null, System.Configuration.ConfigurationManager.AppSettings["ScaricaImpresa_CFOperatore"]);
                        else
                            trad.ScaricaDatiAzienda(txtCFabilitato.Text.ToUpper(), null, ((SiarLibrary.Web.MasterPage)Page.Master).Operatore.Utente.CfUtente);
                    }
                    impresa = impresaColl.GetByCuaa(txtCFabilitato.Text.ToUpper());
                    if (impresa == null) throw new Exception("L`impresa cercata non è stata trovata.");
                    hdnIdImpresa.Value = impresa.IdImpresa;
                    txtRagSociale.Text = impresa.RagioneSociale;
                }
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnRevocaMandato_Click(object sender, EventArgs e)
        {
            try
            {
                int id_mandato;
                if (!int.TryParse(hdnIdMandato.Value, out id_mandato)) throw new Exception("Nessun mandato da revocare trovato. Impossibile Continuare.");
                if (utente_selezionato == null) throw new Exception("Nessun operatore trovato. Impossibile Continuare.");

                SiarLibrary.MandatiImpresa mandato = mandati_provider.GetById(id_mandato);
                if (mandato == null) throw new Exception("Nessun mandato da revocare trovato. Impossibile Continuare.");
                mandato.Attivo = false;
                mandato.DataFineValidita = DateTime.Now;
                mandato.IdOperatoreFine = ((SiarLibrary.Web.MasterPage)Master).Operatore.Utente.IdUtente;
                mandati_provider.Save(mandato);
                ShowMessage("Mandato aziendale revocato correttamente.");

            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnRicerca_Click(object sender, EventArgs e)
        {

        }

        // : aggiunta la ricerca
        protected void btCercaOperatore_Click(object sender, EventArgs e)
        {
            try {
                SiarLibrary.UtentiCollection UtenteSel = new SiarBLL.UtentiCollectionProvider().Find(txtCercaOperatore.Text, null, null, null, null, null, true);
                if (UtenteSel.Count > 0)
                {
                    SiarLibrary.UtentiStoricoCollection usrConsulente = new SiarBLL.UtentiStoricoCollectionProvider().Find(UtenteSel[0].IdUtente, null, _idProfiloConsulete,true);
                    if (usrConsulente.Count > 0)
                    {
                        Response.Redirect(Request.Url.AbsolutePath + "?idt=" + usrConsulente[0].IdUtente.ToString());
                    }
                    else
                        throw new Exception("L'utente selezionato non ha il ruolo Consulente abilitato.");
                }
                else
                    throw new Exception("Utente non inserito in anagrafica.");

            }
            catch (Exception ex){ShowError(ex);}

        }
    }
}
