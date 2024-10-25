using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.PDomanda
{
    public partial class SelezioneAzienda : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "progetto_ricerca";
            base.OnPreInit(e);
        }

        SiarLibrary.Bando bando;
        SiarBLL.ImpresaCollectionProvider impresa_provider = new SiarBLL.ImpresaCollectionProvider();

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_bando;
            if (int.TryParse(Request.QueryString["idb"], out id_bando)) 
                bando = new SiarBLL.BandoCollectionProvider().GetById(id_bando);
            if (bando == null) 
                Redirect("../../Public/Bandi.aspx", "Per proseguire è necessario selezionare il bando desiderato.", true);

            ucImpresaControl.AbilitaModifica = AbilitaModifica;
            ucImpresaControl.AnagrafeEdit = true;
            ucImpresaControl.ContoCorrenteObbligatorio = true;
        }

        protected override void OnPreRender(EventArgs e)
        {
            txtCuaaRicerca.AddJSAttribute("onblur", "return ctrlCuaaDitta(event);");
            int id_impresa;
            if (!IsPostBack && int.TryParse(Request.QueryString["idimp"], out id_impresa))
                BindData(impresa_provider.RicercaImpresaSenzaUtente(id_impresa, null, null));
            if (IsPostBack)
            {
                try
                {
                    BindData(impresa_provider.RicercaImpresaSenzaUtente(null, txtCuaaRicerca.Text, txtRagSociale.Text));
                }
                catch (Exception ex) { ShowError(ex); }
            }
            else
                btnInserisciImpresa.Visible = false;
            base.OnPreRender(e);
        }

        protected void BindData(SiarLibrary.ImpresaCollection imprese)
        {
            dg.DataSource = imprese;
            dg.ItemDataBound += new DataGridItemEventHandler(dg_ItemDataBound);
            dg.Titolo = "Elementi trovati: " + imprese.Count;
            dg.DataBind();

            if (imprese.Count == 0)
            {
                btnInserisciImpresa.Visible = true;
                dg.Titolo = "Impresa non trovata: provare a ricercare per codice fiscale o ragione sociale oppure inserire una nuova impresa e ricercarla nuovamente";
            }
                
        }

        void dg_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                SiarLibrary.Impresa i = (SiarLibrary.Impresa)e.Item.DataItem;
                if (!i.Attiva) e.Item.BackColor = System.Drawing.Color.FromArgb(204, 204, 185);
                else if (i.RagioneSociale == i.Cuaa || i.RagioneSociale == i.CodiceFiscale)
                    e.Item.Cells[4].Text = "<input type='button' style='width:120px' class='btn btn-primary py-1' value='Scarica anagrafica' onclick=\"scaricaAnagrafica('"
                        + i.Cuaa + "');\" />";
                else e.Item.Cells[4].Text = "<input type='button' style='width:120px' class='btn btn-primary py-1' value='Seleziona' onclick=\"location='../impresa/nuovadomanda.aspx?idimp="
                    + i.IdImpresa + "&idb=" + bando.IdBando + "'\" />";
            }
        }

        protected void btnCercaDB_Click(object sender, EventArgs e)
        {

        }

        protected void btnInserisciNuovaImpresa_Click(object sender, EventArgs e)
        {

        }

        protected void btnCercaWS_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCuaaRicerca.Text)) ShowError("Inserire una Partita iva/Codice fiscale valida per la ricerca.");
            else
            {
                string cuaa_selezionato = txtCuaaRicerca.Text;
                string CFScaricaDatiAnagrafe = Operatore.Utente.CfUtente;
                SianWebSrv.TraduzioneSianToSiar traduzione = new SianWebSrv.TraduzioneSianToSiar();

                string bandoAnagrafeEditabile = null;
                if (bando != null)
                {
                    bandoAnagrafeEditabile = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_EditImpresa(bando.IdBando);
                }

                if (!string.IsNullOrEmpty(bandoAnagrafeEditabile) && bandoAnagrafeEditabile == "True")
                {
                    var impresa = traduzione.ScaricaDatiAziendaEdit2(cuaa_selezionato, null, CFScaricaDatiAnagrafe, Operatore);

                    if (impresa.RagioneSociale != " ")
                        ShowMessage("Dati anagrafici presenti in anagrafica locale, sarà possibile aggiornarli manualmente all'interno della domanda");
                    else
                        ShowMessage("I dati anagrafici potranno essere inseriti manualmente all'interno della domanda");
                }
                else
                {
                    // : modificato per far operare i consulenti ed i rappresentanti legali non abilitati ad anagrafe tributaria
                    // possono fare solo il primo scaricamento, nel caso in cui l'impresa non sia già nel DB
                    // se: 
                    //    utente cerca in anagrafe tributaria per una sepcifica P.IVA
                    //    utente corrente è un consulente oppure utente singolo
                    //    SE ho impresa nel DB locale --> non faccio nulla
                    //    ELSE -->  scarica dati usando CF impostato nel web.config con parametro ScaricaImpresa_CFOperatore
                    string[] profiliPrimaVolta = System.Configuration.ConfigurationManager.AppSettings["ScaricaImpresa_ProfiliPrimavolta"].Split(new char[] { ',' });
                    if (!string.IsNullOrEmpty(cuaa_selezionato) && Array.IndexOf(profiliPrimaVolta, ((SiarLibrary.Web.MasterPage)Page.Master).Operatore.Utente.IdProfilo.ToString()) >= 0)
                    {
                        // devo poter scaricare imprese la prima volta
                        SiarLibrary.Impresa impresaPerPIVA = impresa_provider.GetByCuaa(cuaa_selezionato);
                        // se non ho impresa in DB --> la scarico, ovvero uso CF che può leggere tutte le imprese
                        if (impresaPerPIVA == null)
                            CFScaricaDatiAnagrafe = System.Configuration.ConfigurationManager.AppSettings["ScaricaImpresa_CFOperatore"];
                        else
                        {
                            ShowError("Ricerca in anagrafe tributaria non eseguita: impresa già presente nel DB locale.");
                            CFScaricaDatiAnagrafe = "";
                        }
                    }
                    // : fine parte aggiunta 

                    try
                    {
                        // : aggiunto if
                        if (!string.IsNullOrEmpty(CFScaricaDatiAnagrafe))
                        {
                            // : sostituita la riga
                            //traduzione.ScaricaDatiAzienda(cuaa_selezionato, null, Operatore.Utente.CfUtente);
                            // se il bando ha il parametro per inserire le aziende senza scarico uso un nuovo metodo, altrimenti il solito
                            traduzione.ScaricaDatiAzienda(cuaa_selezionato, null, CFScaricaDatiAnagrafe);

                            SiarLibrary.ImpresaCollection imprese = impresa_provider.RicercaImpresa(Operatore.Utente.IdUtente, null, cuaa_selezionato, null, "PSR");
                            if (imprese.Count == 0)
                                ShowError("L`operatore non è abilitato a lavorare per l`impresa selezionata.");
                            else
                                ShowMessage("Dati anagrafici scaricati correttamente.");
                        }
                    }
                    catch (Exception ex) { ShowError(ex); }
                }
            }
        }
    }
}