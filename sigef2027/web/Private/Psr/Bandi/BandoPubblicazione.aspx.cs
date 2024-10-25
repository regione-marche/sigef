using System;
using System.Web.UI.WebControls;

namespace web.Private.Psr.Bandi
{

    public partial class BandoPubblicazione : SiarLibrary.Web.BandoPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "riepilogo_bando";
            base.OnPreInit(e);
        }

        SiarLibrary.CheckListCollection checklist_datasource;
        SiarBLL.CheckListCollectionProvider cheklist_provider = new SiarBLL.CheckListCollectionProvider();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack && !string.IsNullOrEmpty(hdnIdChecklist.Value)) btnVisualizzachecklist_Click(sender, e);
            if (IsPostBack && !string.IsNullOrEmpty(hdnIdscheda.Value)) btnVisualizzaScheda_Click(sender, e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            lstSchedaValutazione.DataBind();
            if (!IsPostBack) lstSchedaValutazione.SelectedValue = Bando.IdSchedaValutazione;

            checklist_datasource = cheklist_provider.Find(null, false);
            dgChecklist.DataSource = new SiarBLL.StepXBandoCollectionProvider().FindCheckListFasi(Bando.IdBando);
            dgChecklist.ItemDataBound += new DataGridItemEventHandler(dgChecklist_ItemDataBound);
            dgChecklist.DataBind();
            base.OnPreRender(e);
        }

        void dgChecklist_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                SiarLibrary.StepXBando step = (SiarLibrary.StepXBando)e.Item.DataItem;
                SiarLibrary.Web.Combo cmb = new SiarLibrary.Web.Combo();               
                cmb.Items.Clear();
                checklist_datasource = cheklist_provider.FindFASE(step.CodFase, false);
                if (checklist_datasource.Count == 0) { cmb.Items.Add(new ListItem("Nessuna Checklist per la fase.", "")); cmb.Enabled = false; }
                else { cmb.Items.Add(new ListItem("", "")); }
                foreach (SiarLibrary.CheckList chk in checklist_datasource)
                {
                    ListItem li = new ListItem();
                    li.Value = chk.IdCheckList;
                    li.Text = chk.Descrizione;
                    if (step.IdCheckList == chk.IdCheckList) li.Selected = true;
                    cmb.Items.Add(li);
                }
                cmb.ID = "lstCheckList_Fase" + step.CodFase;
                e.Item.Cells[2].Controls.Add(cmb);
                string testo = " onclick=\"alert('Nessuna checklist associata per la fase selezionata.')\" ";
                if (step.IdCheckList != null) testo = "onclick=\"mostraChecklist(" + step.IdCheckList + ")\" ";
                e.Item.Cells[3].Text = "<input type='button' class='btn btn-primary py-1' " + testo + " value='Visualizza' />";

            }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                SiarBLL.StepXBandoCollectionProvider stepxbando_provider = new SiarBLL.StepXBandoCollectionProvider(BandoProvider.DbProviderObj);
                BandoProvider.DbProviderObj.BeginTran();
                SiarLibrary.StepXBandoCollection checklists = new SiarBLL.StepXBandoCollectionProvider().FindCheckListFasi(Bando.IdBando);
                foreach (SiarLibrary.StepXBando chk in checklists)
                {
                    string nome_combo = "lstCheckList_Fase" + chk.CodFase;
                    int id_checklist = 0;
                    foreach (string s in Request.Form.AllKeys)
                        if (s.EndsWith(nome_combo)) { int.TryParse(Request.Form[s], out id_checklist); break; }
                    if (id_checklist > 0)
                    {
                        if (chk.IdCheckList == null)
                        {
                            chk.MarkAsNew();
                            chk.IdCheckList = id_checklist;
                            chk.IdBando = Bando.IdBando;
                        }
                        else if (chk.IdCheckList != id_checklist)
                        {
                            //devo eliminarlo perche' id_checklist e' chiave primaria
                            chk.MarkForDeletion();

                            SiarLibrary.StepXBando chk_new = new SiarLibrary.StepXBando();
                            chk_new.IdBando = Bando.IdBando;
                            chk_new.IdCheckList = id_checklist;
                            chk_new.CodFase = chk.CodFase;
                            stepxbando_provider.Save(chk_new);
                        }
                    }
                    else if (chk.IdBando != null) chk.MarkForDeletion();
                }
                stepxbando_provider.SaveCollection(checklists);
                Bando.IdSchedaValutazione = lstSchedaValutazione.SelectedValue;
                BandoProvider.Save(Bando);
                AggiornaLogModifica(null);
                BandoProvider.DbProviderObj.Commit();
                ShowMessage("Salvataggio completato.");
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnVisualizzaScheda_Click(object sender, EventArgs e)
        {
            SiarBLL.SchedaXPrioritaCollectionProvider scheda_provider = new SiarBLL.SchedaXPrioritaCollectionProvider();
            try
            {
                int idscheda;
                if (!int.TryParse(hdnIdscheda.Value, out idscheda)) throw new Exception("Si è verificato un errore nella procedura.");
                SiarLibrary.SchedaValutazione s = new SiarBLL.SchedaValutazioneCollectionProvider().GetById(idscheda);
                txtScheda.Text = s.Descrizione;
                SiarLibrary.SchedaXPrioritaCollection priorita = scheda_provider.Find(idscheda, null, null, null, null);
                dgPriorita.DataSource = priorita; dgPriorita.DataBind();
                dgPriorita.Titolo = "Elementi trovati: " + priorita.Count;
                RegisterClientScriptBlock("mostraPopupTemplate('divSchedaForm','divBKGMessaggio');");
            }
            catch (Exception ex) { ShowError(ex); RegisterClientScriptBlock("chiudiPopup();"); }
        }

        protected void btnVisualizzachecklist_Click(object sender, EventArgs e)
        {
            SiarBLL.CheckListXStepCollectionProvider cprovider = new SiarBLL.CheckListXStepCollectionProvider();
            try
            {
                int idcheck;
                if (!int.TryParse(hdnIdChecklist.Value, out idcheck)) throw new Exception("Si è verificato un errore nella procedura.");

                SiarLibrary.CheckListXStepCollection c = cprovider.Find(idcheck, null, null, null, null, null, null);
                if (c == null) throw new Exception("Si è verificato un errore nella procedura.");
                CaricaChecklist(c);
            }
            catch (Exception ex) { ShowError(ex); RegisterClientScriptBlock("chiudiPopup();"); }
        }

        private void CaricaChecklist(SiarLibrary.CheckListXStepCollection cs)
        {
            if (cs.Count > 0)
            {
                txtDescrizione.Text = cs[0].CheckList;
                //txtFase.Text =  cs[0].FaseProcedurale;
            }
            dgStep.DataSource = cs;
            dgStep.DataBind();
            lblNumeroStep.Text = cs.Count.ToString();
            RegisterClientScriptBlock("mostraPopupTemplate('divCheckListForm','divBKGMessaggio');");

        }
    }
}