using SiarBLL;
using SiarLibrary;
using SiarLibrary.Web;
using System;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace web.Private.admin
{
    public partial class RicercaAziendeAnagrafe : PrivatePage
    {
        #region Indici colonne Datagrid

        private int col_IdRicerca = 0,
            col_PivaControllo = 1,
            col_Impresa = 2,
            col_DataUltimoControllo = 3,
            col_DaControllare = 4,
            col_Esito = 5;

        #endregion

        private ImpresaCollectionProvider impresaProvider = new ImpresaCollectionProvider();
        private PersoneXImpreseCollectionProvider personeXImpreseProvider = new PersoneXImpreseCollectionProvider();
        IndirizzarioCollectionProvider indirizzarioProvider = new IndirizzarioCollectionProvider();

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "RicercaAziendeAnagrafe";

            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            txtPivaInserimento.AddJSAttribute("onblur", "ctrlCuaaDitta();");
        }

        protected override void OnPreRender(EventArgs e)
        {
            var ricercaAziendaSianCollectionProvider = new RicercaAziendaSianCollectionProvider();
            var ricercaCollection = ricercaAziendaSianCollectionProvider.FindDaControllare(null, true);

            if (ricercaCollection.Count > 0)
            {
                lblNrRecordRicerche.Text = string.Format("Visualizzate {0} righe", ricercaCollection.Count.ToString());

                dgElencoRicerche.DataSource = ricercaCollection;
                dgElencoRicerche.ItemDataBound += new DataGridItemEventHandler(dgElencoRicerche_ItemDataBound);
                dgElencoRicerche.DataBind();
            }
            else
            {
                dgElencoRicerche.Visible = false;
                lblNrRecordRicerche.Text = "Nessuna piva da ricercare.";
            }

            base.OnPreRender(e);
        }

        //Parzialmente ricavata dal controllo presente sul Main.js, controlla solo se la piva è estera o lunga 11 o 16
        private static bool VerificaPartitaIvaBase(string piva)
        {
            if (VerificaPartitaIvaEstera(piva))
                return true;

            if (piva.Length == 11
                || piva.Length == 16)
                return true;
            else
                return false;
        }

        private static bool VerificaPartitaIvaEstera(string piva)
        {
            if (piva.Length < 9)
                return false;

            var ctrlPE = piva.Substring(0, 3);

            if (ctrlPE == "DE "
                || ctrlPE == "GB "
                || ctrlPE == "FR "
                || ctrlPE == "BE "
                || ctrlPE == "AT "
                || ctrlPE == "NL "
                || ctrlPE == "DK "
                || ctrlPE == "ES "
                || ctrlPE == "CH "
                || ctrlPE == "IE "
                || ctrlPE == "CZ "
                || ctrlPE == "PL "
                || ctrlPE == "HU "
                || ctrlPE == "BE "
                || ctrlPE == "MT "
                || ctrlPE == "RO ")
                return true;

            return false;
        }

        private void VerificaSingolaPiva(RicercaAziendaSianCollectionProvider ricercaAziendaSianCollectionProvider, RicercaAziendaSian ricerca, string CFScaricaDatiAnagrafe)
        {
            SianWebSrv.TraduzioneSianToSiar traduzione = new SianWebSrv.TraduzioneSianToSiar();

            try
            {
                var esito = traduzione.ScaricaDatiAziendaConEsito(ricerca.PivaControllo, null, CFScaricaDatiAnagrafe);

                int idImpresa;
                if (int.TryParse(esito, out idImpresa))
                {
                    ricerca.IdImpresa = idImpresa;
                    ricerca.Esito = "OK";
                }
                else
                {
                    ricerca.Esito = esito;
                }

                ricerca.DataUltimoControllo = DateTime.Now;
                if (ricercaAziendaSianCollectionProvider != null)
                    ricercaAziendaSianCollectionProvider.Save(ricerca);
                else
                    new RicercaAziendaSianCollectionProvider().Save(ricerca);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void VerificaElenco(bool soloSenzaImpresa)
        {
            try
            {
                var ricercaAziendaSianCollectionProvider = new RicercaAziendaSianCollectionProvider();
                var ricercaCollectionAppoggio = ricercaAziendaSianCollectionProvider.FindDaControllare(null, true);
                if (ricercaCollectionAppoggio.Count == 0)
                    throw new Exception("Nessun elenco da controllare");

                RicercaAziendaSianCollection ricercaCollection = new RicercaAziendaSianCollection();
                if (soloSenzaImpresa)
                {
                    foreach (RicercaAziendaSian elemento in ricercaCollectionAppoggio)
                    {
                        if (elemento.IdImpresa == null)
                            ricercaCollection.Add(elemento);
                    }
                }
                else
                    ricercaCollection = ricercaCollectionAppoggio;

                string CFScaricaDatiAnagrafe = "";

                switch (rblCfRichiesta.SelectedValue)
                {
                    case "0": // CF da Web Config
                        CFScaricaDatiAnagrafe = System.Configuration.ConfigurationManager.AppSettings["ScaricaImpresa_CFOperatore"];
                        break;
                    case "1": // CF operatore
                        CFScaricaDatiAnagrafe = Operatore.Utente.CfUtente;
                        break;
                    default:
                        throw new Exception("Cf da usare non selezionato");
                }

                if (!string.IsNullOrEmpty(CFScaricaDatiAnagrafe))
                {
                    foreach (RicercaAziendaSian elemento in ricercaCollection)
                    {
                        VerificaSingolaPiva(ricercaAziendaSianCollectionProvider, elemento, CFScaricaDatiAnagrafe);
                    }
                }
                else
                    throw new Exception("CF per scaricare dall'anagrafe assente nel config");

                ShowMessage("Elenco controllato, è possibile visualizzare l'esito sottostante");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        void dgElencoRicerche_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var ricercaPiva = (RicercaAziendaSian)dgi.DataItem;

                if (ricercaPiva.IdImpresa != null)
                {
                    var impresa = impresaProvider.GetById(ricercaPiva.IdImpresa);

                    if (impresa == null)
                        dgi.Cells[col_Impresa].Text = "Impresa con id " + ricercaPiva.IdImpresa + " non trovata";
                    else
                    {
                        string testo = "<b>Id Impresa:</b> " + ricercaPiva.IdImpresa + "<br /><b>Ragione sociale:</b> " + ricercaPiva.RagioneSociale;

                        if (impresa.IdRapprlegaleUltimo != null)
                        {
                            var rappLegale = personeXImpreseProvider.GetById(impresa.IdRapprlegaleUltimo);
                            testo += "<br /><b>Rappresentante legale: </b>" + rappLegale.Cognome + " " + rappLegale.Nome;
                        }

                        if (impresa.IdSedelegaleUltimo != null)
                        {
                            var indirizzario = indirizzarioProvider.GetById(impresa.IdSedelegaleUltimo);
                            testo += "<br /><b>Sede legale: </b>" + indirizzario.Via + ", " + indirizzario.Comune + " (" + indirizzario.Sigla + ")";
                        }

                        dgi.Cells[col_Impresa].Text = testo;
                    }
                }

                if (ricercaPiva.DataUltimoControllo != null)
                    dgi.Cells[col_DataUltimoControllo].Text = ricercaPiva.DataUltimoControllo.ToFullDate();

                if (ricercaPiva.DaControllare == null || !ricercaPiva.DaControllare)
                    dgi.Cells[col_DaControllare].Text = dgi.Cells[col_DaControllare].Text.Replace("checked", "");
                else
                    dgi.Cells[col_DaControllare].Text = dgi.Cells[col_DaControllare].Text.Replace("input ", "input checked ");
            }
        }

        protected void btnInserisciPiva_Click(object sender, EventArgs e) 
        {
            var piva = txtPivaInserimento.Text;

            try
            {
                if (!VerificaPartitaIvaBase(piva))
                    throw new Exception("Partita Iva " + piva + " non corretta: si prega di verificare");

                var ricercaAziendaSianCollectionProvider = new RicercaAziendaSianCollectionProvider();
                var ricercaCollection = ricercaAziendaSianCollectionProvider.FindDaControllare(piva, true);
                if (ricercaCollection.Count > 0)
                    throw new Exception("Partita Iva " + piva + " già presente in elenco da controllare");

                var nuovoElemento = new RicercaAziendaSian();
                nuovoElemento.OperatoreInserimento = Operatore.Utente.IdUtente;
                nuovoElemento.DataInserimento = DateTime.Now;
                nuovoElemento.PivaControllo = piva;
                nuovoElemento.DaControllare = true;
                ricercaAziendaSianCollectionProvider.Save(nuovoElemento);

                ShowMessage("P.Iva aggiunta correttamente");
            }
            catch(Exception ex)
            {
                ShowError(ex.Message);
            }
            finally
            {
                txtPivaInserimento.Text = "";
            }
        }

        protected void btnControllaElenco_Click(object sender, EventArgs e) 
        {
            VerificaElenco(false);
        }

        protected void btnControllaElencoSenzaImpresa_Click(object sender, EventArgs e)
        {
            VerificaElenco(true);
        }

        protected void btnSvuotaElenco_Click(object sender, EventArgs e) 
        {
            try
            {
                var ricercaAziendaSianCollectionProvider = new RicercaAziendaSianCollectionProvider();
                var ricercaCollection = ricercaAziendaSianCollectionProvider.FindDaControllare(null, true);
                if (ricercaCollection.Count == 0)
                    throw new Exception("Nessun elenco da svuotare");

                ricercaAziendaSianCollectionProvider.DeleteCollection(ricercaCollection);
                ShowMessage("Elenco svuotato correttamente");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnPostEliminaRicerca_Click(object sender, EventArgs e)
        {
            try
            {
                var ricercaAziendaSianCollectionProvider = new RicercaAziendaSianCollectionProvider();
                RicercaAziendaSian ricercaEliminazione = null;

                int id_ricerca;
                if (int.TryParse(hdnIdRicercaEliminazione.Value, out id_ricerca))
                    ricercaEliminazione = ricercaAziendaSianCollectionProvider.GetById(id_ricerca);
                else
                    throw new Exception("Nessuna ricerca selezionata");

                if (ricercaEliminazione == null)
                    throw new Exception("Nessuna ricerca selezionata");

                ricercaAziendaSianCollectionProvider.Delete(ricercaEliminazione);

                hdnIdRicercaEliminazione.Value = null;
                Redirect("RicercaAziendeAnagrafe.aspx", "Ricerca eliminata correttamente.", false);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnPostRicercaSingola_Click(object sender, EventArgs e)
        {
            try
            {
                var ricercaAziendaSianCollectionProvider = new RicercaAziendaSianCollectionProvider();
                RicercaAziendaSian ricercaSingola = null;

                int id_ricerca;
                if (int.TryParse(hdnIdRicercaSingola.Value, out id_ricerca))
                    ricercaSingola = ricercaAziendaSianCollectionProvider.GetById(id_ricerca);
                else
                    throw new Exception("Nessuna ricerca selezionata");

                if (ricercaSingola == null)
                    throw new Exception("Nessuna ricerca selezionata");

                string CFScaricaDatiAnagrafe = "";

                switch (rblCfRichiesta.SelectedValue)
                {
                    case "0": // CF da Web Config
                        CFScaricaDatiAnagrafe = System.Configuration.ConfigurationManager.AppSettings["ScaricaImpresa_CFOperatore"];
                        break;
                    case "1": // CF operatore
                        CFScaricaDatiAnagrafe = Operatore.Utente.CfUtente;
                        break;
                    default:
                        throw new Exception("Cf da usare non selezionato");
                }


                if (!string.IsNullOrEmpty(CFScaricaDatiAnagrafe))
                    VerificaSingolaPiva(ricercaAziendaSianCollectionProvider, ricercaSingola, CFScaricaDatiAnagrafe);
                else
                    throw new Exception("CF per scaricare dall'anagrafe assente nel config");

                ShowMessage("P.Iva controllata, è possibile visualizzare l'esito nell'elenco");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
    }
}