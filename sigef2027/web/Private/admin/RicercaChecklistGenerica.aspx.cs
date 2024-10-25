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
    public partial class RicercaChecklistGenerica : ChecklistGenericaClassPage
    {
        ChecklistGenericaCollectionProvider checklist_provider;
        VoceXChecklistGenericaCollectionProvider voci_x_chk_provider;
        SchedaXChecklistCollectionProvider schede_x_chk_provider;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            InizializzaProvider();
            CaricaImmagini();
            DataBindCampiRicerca();

            CaricaChecklist();

            base.OnPreRender(e);
        }

        private void InizializzaProvider()
        {
            checklist_provider = new ChecklistGenericaCollectionProvider();
            voci_x_chk_provider = new VoceXChecklistGenericaCollectionProvider();
            schede_x_chk_provider = new SchedaXChecklistCollectionProvider();
        }

        private void CaricaImmagini()
        {
            //imgMostraElencoChecklist.Attributes.Add("src", PATH_IMAGES + "ArrowUpSolid.png");

            //imgSearchFiltraRicercaChecklist.Attributes.Add("src", PATH_IMAGES + "lente24.png");
        }

        protected void DataBindCampiRicerca()
        {
            //lstRicercaTipo.Items.Clear();
            //lstRicercaTipo.Items.Add(new ListItem("", ""));
            //lstRicercaFiltro.Items.Clear();
            //lstRicercaFiltro.Items.Add(new ListItem("", ""));
            lstRicercaTipo.DataBind();
            lstRicercaFiltro.DataBind();
            lstRicercaTemplate.Items.Add(new ListItem("", ""));
            lstRicercaTemplate.Items.Add(new ListItem("No", "No"));
            lstRicercaTemplate.Items.Add(new ListItem("Sì", "Sì"));
        }

        private void CaricaChecklist()
        {
            if (IsPostBack)
            {
                var ricerca_id_checklist = txtRicercaIdChecklist.Text;
                var tipo_selezionato = lstRicercaTipo.SelectedItem;
                var ricerca_tipo = tipo_selezionato != null ? tipo_selezionato.Text : null;
                var ricerca_descrizione = "%" + txtRicercaDescrizione.Text + "%";
                var filtro_selezionato = lstRicercaFiltro.SelectedItem;
                var ricerca_filtro = filtro_selezionato != null ? filtro_selezionato.Text : null;
                BoolNT ricerca_template = null;
                if (lstRicercaTemplate.SelectedValue != null && lstRicercaTemplate.SelectedValue == "Sì")
                    ricerca_template = true;
                else if (lstRicercaTemplate.SelectedValue != null && lstRicercaTemplate.SelectedValue == "Sì")
                    ricerca_template = false;

                //var checklist_coll = checklist_provider.Find(null, null);
                var checklist_coll = checklist_provider.RicercaChecklist(ricerca_id_checklist, ricerca_tipo, ricerca_descrizione, ricerca_filtro, ricerca_template);
                var checklist_list = checklist_coll.ToArrayList<ChecklistGenerica>();

                if (checklist_coll.Count > 0)
                {
                    lblNumChecklist.Text = string.Format("Visualizzate {0} righe", checklist_coll.Count.ToString());

                    dgChecklist.DataSource = checklist_coll;
                    dgChecklist.ItemDataBound += new DataGridItemEventHandler(dgChecklist_ItemDataBound);
                    dgChecklist.DataBind();
                }
                else
                {
                    lblNumChecklist.Text = "Nessuna checklist trovata";
                }
            }
        }

        #region ButtonClick

        protected void btnInserisciChecklist_Click(object sender, EventArgs e)
        {
            InizializzaProvider();

            try
            {
                ChecklistGenerica = null;
                Redirect(PATH_ADMIN + "ChecklistGenericaPage.aspx");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnSelezionaChecklist_Click(object sender, EventArgs e)
        {
            try
            {
                int id_checklist;
                if (int.TryParse(hdnIdChecklist.Value, out id_checklist))
                {
                    var checklist = new ChecklistGenericaCollectionProvider().GetById(id_checklist);

                    ChecklistGenerica = checklist ?? throw new Exception("Checklist generica non esistente");
                    Redirect(PATH_ADMIN + "ChecklistGenericaPage.aspx");
                }
                else
                    throw new Exception("Checklist generica non selezionata");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnFiltraRicercaChecklist_Click(object sender, EventArgs e) { }

        #endregion

        #region ItemDataBound

        void dgChecklist_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            int col_IdChecklist = 0,
                col_Tipo = 1,
                col_Descrizione = 2,
                col_Filtro = 3,
                col_Template = 4,
                col_NumVoci = 5,
                col_Seleziona = 6;

            DataGridItem dgi = (DataGridItem)e.Item;

            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var checklist = (ChecklistGenerica)dgi.DataItem;

                if (checklist.FlagTemplate != null && checklist.FlagTemplate)
                    dgi.Cells[col_Template].Text = dgi.Cells[col_Template].Text.Replace("<input", "<input checked");
                else
                    dgi.Cells[col_Template].Text = dgi.Cells[col_Template].Text.Replace("checked", "");

                if (checklist.ContieneVociTipo)
                    dgi.Cells[col_NumVoci].Text = voci_x_chk_provider.FindGenerica(null, checklist.IdChecklistGenerica, null).Count.ToString();
                else
                    dgi.Cells[col_NumVoci].Text = schede_x_chk_provider.Find(null, checklist.IdChecklistGenerica, null).Count.ToString();

                //var tipo_item = new ListItem(checklist.DescrizioneTipo, checklist.DescrizioneTipo);
                //if (!lstRicercaTipo.Items.Contains(tipo_item))
                //    lstRicercaTipo.Items.Add(tipo_item);

                //var filtro_item = new ListItem(checklist.DescrizioneFiltro, checklist.DescrizioneFiltro);
                //if (!lstRicercaFiltro.Items.Contains(filtro_item))
                //    lstRicercaFiltro.Items.Add(filtro_item);
            }
        }

        #endregion
    }
}