using System;
using SiarLibrary;
using SiarLibrary.Web;
using SiarBLL;
using System.Web.UI.WebControls;
using SiarLibrary.NullTypes;

namespace web.Private.COVID
{
    public partial class RicercaPreDomande : PrivatePage
    {
        CovidAutodichiarazioneCollectionProvider covid_prov;
        BandoCollectionProvider bando_provider;
        PianoInvestimentiCollectionProvider investimenti_provider;

        #region Indici colonne

        private int col_Id = 0,
            col_Impresa = 1,
            col_Bando = 2,
            col_Definitiva = 3,
            col_Anagrafica = 4,
            col_DichiarazioniRequisiti = 5,
            col_Investimenti = 6,
            col_File = 7;

        #endregion

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "ricerca_predomande_covid";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["id_progetto_covid"] = null;
            Session["id_bando_covid"] = null;

            InizializzaProvider();
        }

        protected override void OnPreRender(EventArgs e)
        {
            try
            {
                var autocert_coll = new CovidAutodichiarazioneCollection();

                //autocert_coll = covid_prov.Find(Operatore.Utente.IdUtente, null, null, null, null, null, null);
                if (IsPostBack)
                {
                    IntNT id_predomanda = null;
                    string ragione_sociale = null;
                    string piva = null;
                    string cf = null;
                    IntNT id_bando = null;
                    string descr_bando = null;

                    if (txtIdPreDomanda.Text != null && txtIdPreDomanda.Text != "")
                        id_predomanda = txtIdPreDomanda.Text;
                    if (txtRagioneSocialeImpresa.Text != null && txtRagioneSocialeImpresa.Text != "")
                        ragione_sociale = txtRagioneSocialeImpresa.Text;
                    if (txtPivaImpresa.Text != null && txtPivaImpresa.Text != "")
                        piva = txtPivaImpresa.Text;
                    if (txtCfImpresa.Text != null && txtCfImpresa.Text != "")
                        cf = txtCfImpresa.Text;
                    if (txtIdBando.Text != null && txtIdBando.Text != "")
                        id_bando = txtIdBando.Text;
                    if (txtDescrizioneBando.Text != null && txtDescrizioneBando.Text != "")
                        descr_bando = txtDescrizioneBando.Text;

                    autocert_coll = covid_prov.RicercaAmministratori(
                        id_predomanda,
                        ragione_sociale,
                        piva,
                        cf,
                        id_bando,
                        descr_bando);
                }

                dgPreDomande.DataSource = autocert_coll;
                dgPreDomande.SetTitoloNrElementi();
                dgPreDomande.ItemDataBound += new DataGridItemEventHandler(dgPreDomande_ItemDataBound);
                dgPreDomande.DataBind();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }

            base.OnPreRender(e);
        }

        protected void InizializzaProvider()
        {
            covid_prov = new CovidAutodichiarazioneCollectionProvider();
            bando_provider = new BandoCollectionProvider();
            investimenti_provider = new PianoInvestimentiCollectionProvider();
        }

        void dgPreDomande_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            var dgi = e.Item;

            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var autocert = (CovidAutodichiarazione)dgi.DataItem;
                var bando = bando_provider.GetById(autocert.IdBando);

                dgi.Cells[col_Impresa].Text = "<b>Ragione Sociale: </b>" + autocert.RagioneSociale + "<br/>"
                    + "<b>P. IVA: </b>" + autocert.PartitaIva + "<br/>"
                    + "<b>Codice Fiscale: </b>" + autocert.CodiceFiscale;

                dgi.Cells[col_Bando].Text = "<b>Id Bando: </b>" + bando.IdBando + "<br/>" 
                    + "<b>Descrizione: </b>" + bando.Descrizione;

                if (autocert.Definitiva)
                    dgi.Cells[col_Definitiva].Text = "<img src='" + Request.ApplicationPath + "/images/visto.gif'>";

                if (autocert.IdProgetto == null || investimenti_provider.Find(null, autocert.IdProgetto, null, null, null, null, null).Count == 0)
                    dgi.Cells[col_Investimenti].Text = "";

                if (autocert.IdFileDomanda == null)
                    dgi.Cells[col_File].Text = "";
            }
        }

        #region Click

        protected void btnAnagrafica_Click(object sender, EventArgs e)
        {
            int IdPreDomanda;
            if (int.TryParse(hdnIdPreDomanda.Value, out IdPreDomanda))
            {
                var aut = covid_prov.GetById(IdPreDomanda);

                Session.Add("id_bando_covid", aut.IdBando.ToString());
                Session.Add("id_progetto_covid", aut.IdProgetto.ToString());

                Redirect(PATH_COVID + "Autocertificazione.aspx");
            }
        }

        protected void btnDichiarazioniRequisiti_Click(object sender, EventArgs e)
        {
            int IdPreDomanda;
            if (int.TryParse(hdnIdPreDomanda.Value, out IdPreDomanda))
            {
                var aut = covid_prov.GetById(IdPreDomanda);

                Session.Add("id_bando_covid", aut.IdBando.ToString());
                Session.Add("id_progetto_covid", aut.IdProgetto.ToString());

                Redirect(PATH_COVID + "RequisitiCovid.aspx");
            }
        }

        protected void btnPianoInvestimenti_Click(object sender, EventArgs e)
        {
            int IdPreDomanda;
            if (int.TryParse(hdnIdPreDomanda.Value, out IdPreDomanda))
            {
                var aut = covid_prov.GetById(IdPreDomanda);

                Session.Add("id_bando_covid", aut.IdBando.ToString());
                Session.Add("id_progetto_covid", aut.IdProgetto.ToString());

                Redirect(PATH_COVID + "ProgettoCovid.aspx");
            }
        }

        protected void btnRicercaPreDomande_Click(object sender, EventArgs e) { }

        #endregion
    }
}