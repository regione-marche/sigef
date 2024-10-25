using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarLibrary;
using SiarLibrary.Web;
using SiarBLL;
using SiarLibrary.NullTypes;

namespace web.Private.Controlli
{
    public partial class RicercaIrregolaritaErroriRinunce : IrregolaritaErroriRinuncePage
    {
        BandoCollectionProvider bando_provider;
        ProgettoCollectionProvider progetto_provider;
        ImpresaCollectionProvider impresa_provider;
        IrregolaritaCollectionProvider irregolarita_provider;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected override void OnPreRender(EventArgs e)
        {
            InizializzaProvider();
            CaricaImmagini();
            CaricaComboBox();

            CaricaIrregolarita();

            base.OnPreRender(e);
        }

        private void InizializzaProvider()
        {
            bando_provider = new BandoCollectionProvider();
            progetto_provider = new ProgettoCollectionProvider();
            impresa_provider = new ImpresaCollectionProvider();
            irregolarita_provider = new IrregolaritaCollectionProvider();
        }

        private void CaricaImmagini()
        {
            imgSearchFiltraRicercaIrregolarita.Attributes.Add("src", PATH_IMAGES + "lente24.png");
        }

        private void CaricaComboBox()
        {
            lstRicercaStatoProgetto.Items.Add(new ListItem("", ""));
            lstRicercaImpresaProgetto.Items.Add(new ListItem("", ""));

            lstRicercaSegnalazioneOlaf.Items.Add(new ListItem("", ""));
            lstRicercaSegnalazioneOlaf.Items.Add(new ListItem("Sì", "Sì"));
            lstRicercaSegnalazioneOlaf.Items.Add(new ListItem("No", "No"));
        }

        private void CaricaIrregolarita()
        {
            var irregolarita_coll = irregolarita_provider.Find(null, null, null, 1, null);

            if (irregolarita_coll.Count > 0)
            {
                lblNumIrregolarita.Text = string.Format("Visualizzate {0} righe", irregolarita_coll.Count.ToString());

                dgIrregolarita.DataSource = irregolarita_coll;
                dgIrregolarita.ItemDataBound += new DataGridItemEventHandler(dgIrregolarita_ItemDataBound);
                dgIrregolarita.DataBind();
            }
            else
            {
                lblNumIrregolarita.Text = "Nessuna spesa trovata";
            }
        }

        #region ItemDataBound

        void dgIrregolarita_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            int col_DatiBando = 0,
                col_DatiProgetto = 1,
                col_Id = 2,
                col_TipoIrregolarita = 3,
                col_ControlloOrigine = 4,
                col_DataCostatazioneAmministrativa = 5,
                col_SospettoFrode = 6,
                col_ImportoDaRecuperare = 7,
                col_SegnalazioneOlaf = 8,
                col_VaiA = 9;

            DataGridItem dgi = (DataGridItem)e.Item;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var irr = (Irregolarita)dgi.DataItem;

                if (irr.IdBando != null)
                {
                    var bando = bando_provider.GetById(irr.IdBando);

                    dgi.Cells[col_DatiBando].Text =
                        @"Id: <b>" + bando.IdBando + "</b><br/>" +
                        "Descrizione: <b>" + bando.Descrizione + "</b><br/>" +
                        "Data scadenza: <b>" + bando.DataScadenza + "</b>";
                }

                if (irr.IdProgetto != null)
                {
                    var progetto = progetto_provider.GetById(irr.IdProgetto);
                    var impresa = impresa_provider.GetById(progetto.IdImpresa);

                    dgi.Cells[col_DatiProgetto].Text =
                        @"Id: <b>" + progetto.IdProgetto + "</b><br/>" +
                        "Stato: <b>" + progetto.Stato + "</b><br/>" +
                        "Impresa: <b>" + impresa.CodiceFiscale + " - " + impresa.RagioneSociale + "</b>";

                    var statoProgettoAttuale = new ListItem(progetto.Stato, progetto.Stato);
                    if (!lstRicercaStatoProgetto.Items.Contains(statoProgettoAttuale))
                        lstRicercaStatoProgetto.Items.Add(statoProgettoAttuale);

                    var impresaAttuale = new ListItem(impresa.CodiceFiscale + " - " + impresa.RagioneSociale, impresa.CodiceFiscale);
                    if (!lstRicercaImpresaProgetto.Items.Contains(impresaAttuale))
                        lstRicercaImpresaProgetto.Items.Add(impresaAttuale);
                }

                if (irr.SospettoFrode)
                    dgi.Cells[col_SospettoFrode].Text = dgi.Cells[col_SospettoFrode].Text.Replace("<input", "<input checked");
                else
                    dgi.Cells[col_SospettoFrode].Text = dgi.Cells[col_SospettoFrode].Text.Replace("checked", "");

                if (irr.ImportoIrregolareDaRecuperare)
                    dgi.Cells[col_ImportoDaRecuperare].Text = dgi.Cells[col_ImportoDaRecuperare].Text.Replace("<input", "<input checked");
                else
                    dgi.Cells[col_ImportoDaRecuperare].Text = dgi.Cells[col_ImportoDaRecuperare].Text.Replace("checked", "");

                if (irr.SegnalazioneOlaf)
                    dgi.Cells[col_SegnalazioneOlaf].Text = dgi.Cells[col_SegnalazioneOlaf].Text.Replace("<input", "<input checked");
                else
                    dgi.Cells[col_SegnalazioneOlaf].Text = dgi.Cells[col_SegnalazioneOlaf].Text.Replace("checked", "");

                if (irr.TipoIrregolarita != null)
                    dgi.Cells[col_VaiA].Text = dgi.Cells[col_VaiA].Text.Replace("elemento", irr.TipoIrregolarita);

                //var tipologiaAttuale = new ListItem(irr.TipoIrregolarita, irr.TipoIrregolarita);
                //if (!lstRicercaTipologiaIrregolarita.Items.Contains(tipologiaAttuale))
                //    lstRicercaTipologiaIrregolarita.Items.Add(tipologiaAttuale);
            }
        }

        #endregion

        #region Button Click 

        protected void btnVisualizzaIrregolarita_Click(object sender, EventArgs e)
        {
            try
            {
                InizializzaProvider();

                int id_irregolarita;
                if (int.TryParse(hdnIdIrregolarita.Value, out id_irregolarita))
                {
                    var irregolarita = irregolarita_provider.GetById(id_irregolarita);
                    var progetto = progetto_provider.GetById(irregolarita.IdProgetto);
                    Session["_irregolarita"] = irregolarita;
                    Session["_progetto"] = progetto;

                    Redirect(PATH_CONTROLLI + "IrregolaritaErroriRinunce.aspx");
                }
                else
                    throw new Exception("Nessuna irregolarita selezionata.");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        #endregion
    }
}