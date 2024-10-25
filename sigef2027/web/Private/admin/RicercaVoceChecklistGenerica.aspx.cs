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

namespace web.Private.admin
{
    public partial class RicercaVoceChecklist : VoceGenericaPage
    {
        VoceGenericaCollectionProvider voci_provider;
        VoceXChecklistGenericaCollectionProvider voci_x_chk_provider;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            InizializzaProvider();
            CaricaImmagini();
            DataBindCampiRicerca();

            CaricaVoci();

            base.OnPreRender(e);
        }

        private void InizializzaProvider()
        {
            voci_provider = new VoceGenericaCollectionProvider();
            voci_x_chk_provider = new VoceXChecklistGenericaCollectionProvider();
        }

        private void CaricaImmagini()
        {
            //imgMostraElencoVoci.Attributes.Add("src", PATH_IMAGES + "ArrowUpSolid.png");

            //imgSearchFiltraRicercaVoce.Attributes.Add("src", PATH_IMAGES + "lente24.png");
        }

        protected void DataBindCampiRicerca()
        {
            //lstRicercaFiltro.Items.Clear();
            //lstRicercaFiltro.Items.Add(new ListItem("", ""));
            lstRicercaFiltro.DataBind();
            lstRicercaAutomatico.Items.Clear();
            lstRicercaAutomatico.Items.Add(new ListItem("", ""));
            lstRicercaAutomatico.Items.Add(new ListItem("No", "No"));
            lstRicercaAutomatico.Items.Add(new ListItem("Sì", "Sì"));
        }

        private void CaricaVoci()
        {
            if (IsPostBack)
            {
                var ricerca_id_voce = txtRicercaIdVoce.Text;
                var filtro_selezionato = lstRicercaFiltro.SelectedItem;
                var ricerca_filtro = filtro_selezionato != null ? filtro_selezionato.Text : null;
                var ricerca_descrizione = "%" + txtRicercaDescrizione.Text + "%";
                var ricerca_val_minimo = txtRicercaValoreMinimo.Text;
                var ricerca_val_max = txtRicercaValoreMassimo.Text;
                BoolNT ricerca_automatico = null;
                if (lstRicercaAutomatico.SelectedValue != null && lstRicercaAutomatico.SelectedValue == "Sì")
                    ricerca_automatico = true;
                else if (lstRicercaAutomatico.SelectedValue != null && lstRicercaAutomatico.SelectedValue == "Sì")
                    ricerca_automatico = false;
                //var ricerca_num_utilizzi_max = txtRicercaNumUtilizziMassimo.Text;

                var voci_coll = voci_provider.RicercaVoci(ricerca_id_voce, ricerca_filtro, ricerca_descrizione, ricerca_val_minimo, ricerca_val_max, ricerca_automatico, null);

                if (voci_coll.Count > 0)
                {
                    lblNumVoci.Text = string.Format("Visualizzate {0} righe", voci_coll.Count.ToString());

                    dgVoci.DataSource = voci_coll;
                    dgVoci.ItemDataBound += new DataGridItemEventHandler(dgVoci_ItemDataBound);
                    dgVoci.DataBind();
                }
                else
                {
                    lblNumVoci.Text = "Nessuna voce trovata";
                }
            }
        }

        #region ButtonClick

        protected void btnInserisciVoce_Click(object sender, EventArgs e)
        {
            InizializzaProvider();

            try
            {
                VoceGenerica = null;
                Redirect(PATH_ADMIN + "VoceGenericaChecklist.aspx");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnSelezionaVoce_Click(object sender, EventArgs e)
        {
            try
            {
                int id_voce;
                if (int.TryParse(hdnIdVoce.Value, out id_voce))
                {
                    var voce = new VoceGenericaCollectionProvider().GetById(id_voce);

                    VoceGenerica = voce ?? throw new Exception("Voce checklist generica non esistente");
                    Redirect(PATH_ADMIN + "VoceGenericaChecklist.aspx");
                }
                else
                    throw new Exception("Voce checklist generica non selezionata");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnFiltraRicercaVoci_Click(object sender, EventArgs e) { }

        #endregion

        #region ItemDataBound

        void dgVoci_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            int col_IdVoce = 0,
                col_FaseProcedurale = 1,
                col_Descrizione = 2,
                col_ValMinimo = 3,
                col_ValMassimo = 4,
                col_Automatico = 5,
                col_NumUtilizzi = 6,
                col_Seleziona = 7;

            DataGridItem dgi = (DataGridItem)e.Item;

            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var voce = (VoceGenerica)dgi.DataItem;

                if (voce.Titolo)
                    dgi.Cells[col_Descrizione].Text = "<b>" + dgi.Cells[col_Descrizione].Text + "</b>";

                if (voce.Automatico != null && voce.Automatico)
                    dgi.Cells[col_Automatico].Text = dgi.Cells[col_Automatico].Text.Replace("<input", "<input checked");
                else
                    dgi.Cells[col_Automatico].Text = dgi.Cells[col_Automatico].Text.Replace("checked", "");

                dgi.Cells[col_NumUtilizzi].Text = voci_x_chk_provider.FindGenerica(null, null, voce.IdVoceGenerica).Count.ToString();

                //var filtro_item = new ListItem(voce.DescrizioneFiltro, voce.DescrizioneFiltro);
                //if (!lstRicercaFiltro.Items.Contains(filtro_item))
                //    lstRicercaFiltro.Items.Add(filtro_item);
            }
        }

        #endregion
    }
}