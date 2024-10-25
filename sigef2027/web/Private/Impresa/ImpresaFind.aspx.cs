using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.Impresa
{
    public partial class ImpresaFind : SiarLibrary.Web.PrivatePage
    {
        SiarBLL.ImpresaCollectionProvider impresa_provider = new SiarBLL.ImpresaCollectionProvider();

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "impresa_ricerca";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                switch (Request.QueryString["action"])
                {
                    case "non_abilitato":
                        ShowError("Utente non abilitato alla visualizzazione dei dati dell'impresa indicata.");
                        break;
                    case "operatori_diversi":
                        ShowError("La domanda non è visibile da operatori diversi da quelli che l'hanno inserita.");
                        break;
                    case "impresa_non_valida":
                        ShowError("La Partita iva/Codice fiscale selezionata non è valida oppure l`impresa è inesistente.");
                        break;
                    case "not_in_session":
                        ShowError("Per proseguire è necessario selezionare l'impresa.");
                        break;
                }
            }
            Form.DefaultButton = btnCercaDB.UniqueID;
            txtCuaaRicerca.AddJSAttribute("onblur", "ctrlCuaaDitta();");

            ucImpresaControl.AbilitaModifica = AbilitaModifica;
            ucImpresaControl.AnagrafeEdit = true;
        }

        protected override void OnPreRender(EventArgs e)
        {           
            int id_impresa;
            if (!IsPostBack && int.TryParse(Request.QueryString["idimp"], out id_impresa))
                BindData(impresa_provider.RicercaImpresa(Operatore.Utente.IdUtente, id_impresa, null, null, null));
            if (IsPostBack)
            {
                try
                {
                    BindData(impresa_provider.RicercaImpresa(Operatore.Utente.IdUtente, null, txtCuaaRicerca.Text,
                        txtRagSociale.Text, null));
                }
                catch (Exception ex) { ShowError(ex); }
            }

            if (Operatore.Utente.Profilo == "Amministratore")
                btnInserisciImpresa.Visible = true;

            base.OnPreRender(e);
        }

        void dg_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.Impresa i = (SiarLibrary.Impresa)e.Item.DataItem;
                if (i.RagioneSociale == i.Cuaa || i.RagioneSociale == i.CodiceFiscale)
                    e.Item.Cells[4].Text = "<input type='button' class='btn btn-primary py-1' value='Scarica anagrafica' onclick=\"scaricaAnagrafica('"
                        + i.Cuaa + "');\" />";
                else e.Item.Cells[4].Text = "<input type='button' class='btn btn-primary py-1' value='Seleziona' onclick=\"location='ImpresaRiepilogo.aspx?idimp="
                    + i.IdImpresa + "'\" />";
                if (!i.Attiva) e.Item.BackColor = System.Drawing.Color.FromArgb(204, 204, 185);
            }
        }

        protected void BindData(SiarLibrary.ImpresaCollection imprese)
        {
            try
            {
                dg.DataSource = imprese;
                dg.ItemDataBound += new DataGridItemEventHandler(dg_ItemDataBound);
                dg.DataBind();
                lblRisultato.Text = imprese.Count.ToString();
            }
            catch (Exception ex) { lblRisultato.Text = "0"; ShowError(ex); }
        }

        protected void btnCercaDB_Click(object sender, EventArgs e)
        {

        }

        protected void btnInserisciImpresa_Click(object sender, EventArgs e)
        {

        }

        protected void btnCercaWS_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCuaaRicerca.Text)) ShowError("Inserire una Partita iva/Codice fiscale valida per la ricerca.");
            else
            {
                string cuaa_selezionato = txtCuaaRicerca.Text;
                
                // : modificato per far operare i consulenti ed i rappresentanti legali non abilitati ad anagrafe tributaria
                // a) possono fare solo il primo scaricamento, nel caso in cui l'impresa non sia già nel DB
                // se: 
                //    utente cerca in anagrafe tributaria per una sepcifica P.IVA
                //    utente corrente è un consulente oppure utente singolo
                //    SE ho impresa nel DB locale --> non faccio nulla
                //    ELSE -->  scarica dati usando CF impostato nel web.config con parametro ScaricaImpresa_CFOperatore
                string CFScaricaDatiAnagrafe = ((SiarLibrary.Web.MasterPage)Page.Master).Operatore.Utente.CfUtente;
                string[] profiliPrimaVolta = System.Configuration.ConfigurationManager.AppSettings["ScaricaImpresa_ProfiliPrimavolta"].Split(new char[] { ',' });
                if (!string.IsNullOrEmpty(cuaa_selezionato) && Array.IndexOf(profiliPrimaVolta, ((SiarLibrary.Web.MasterPage)Page.Master).Operatore.Utente.IdProfilo.ToString()) >= 0)
                {
                    // devo poter scaricare imprese la prima volta
                    SiarLibrary.Impresa impresaPerPIVA = impresa_provider.GetByCuaa(cuaa_selezionato);
                    // se non ho impresa in DB --> la scarico, ovvero uso CF che può leggere tutte le imprese
                    if (impresaPerPIVA == null)
                        CFScaricaDatiAnagrafe = System.Configuration.ConfigurationManager.AppSettings["ScaricaImpresa_CFOperatore"];
                    else { 
                        ShowError("Ricerca in anagrafe tributaria non eseguita: impresa già presente nel DB locale.");
                        CFScaricaDatiAnagrafe = "";
                    }
                }
                // : fine parte aggiunta 

                SianWebSrv.TraduzioneSianToSiar traduzione = new SianWebSrv.TraduzioneSianToSiar();
                try
                {
                    // : aggiunto if
                    if (!string.IsNullOrEmpty(CFScaricaDatiAnagrafe))
                    {
                        // : sostituita la riga
                        //traduzione.ScaricaDatiAzienda(cuaa_selezionato, null, ((SiarLibrary.Web.MasterPage)Page.Master).Operatore.Utente.CfUtente);
                        traduzione.ScaricaDatiAzienda(cuaa_selezionato, null, CFScaricaDatiAnagrafe);
                        SiarLibrary.ImpresaCollection imprese = impresa_provider.RicercaImpresa(((SiarLibrary.Web.MasterPage)Page.Master).Operatore.Utente.IdUtente, null, cuaa_selezionato, null, null);
                        if (imprese.Count == 0) ShowError("L`operatore non è abilitato a lavorare per l`impresa selezionata. Controllare di aver inserito il CF corretto.");
                        else ShowMessage("Dati anagrafici scaricati correttamente.");
                    }
                }
                catch (Exception ex) { ShowError(ex); }
            }
        }
    }
}