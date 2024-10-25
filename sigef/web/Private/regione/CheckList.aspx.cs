using System;
using System.Web.UI.WebControls;

namespace web.Private.regione
{
    /// <summary>
    /// Summary description for CheckList.
    /// </summary>
    public partial class CheckList : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "CheckList";
            base.OnPreInit(e);
        }

        SiarBLL.CheckListCollectionProvider ckl_provider = new SiarBLL.CheckListCollectionProvider();
        SiarBLL.CheckListXStepCollectionProvider step_provider = new SiarBLL.CheckListXStepCollectionProvider();
        SiarLibrary.CheckList ckl_selezionata;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            int id_ckl, id_ckl_qs;
            if (!IsPostBack &&  Request.QueryString["action"] == "visualizza")
                if (int.TryParse(Request.QueryString["id"], out id_ckl_qs))
                {
                    hdnIdChecklist.Value = id_ckl_qs.ToString();
                    ucSiarNewTab.TabSelected = 2;
                }
                else ShowError("Attenzione! Non è possibile visualizzare la checklist selezionata.");


            if (int.TryParse(hdnIdChecklist.Value, out id_ckl) && AbilitaModifica)
            {
                AbilitaModifica = new SiarBLL.StepXBandoCollectionProvider().CheckModificaChecklist(id_ckl);
                if (!AbilitaModifica)
                    tdAvvisoModifica.InnerText = "Attenzione! Non è possibile modificare la checklist selezionata perché associata ad un bando pubblicato.";
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    tbElenco.Visible = false;
                    ucSiarNewTab.Width = tbModifica.Width;
                    lstFaseProgetto.DataBind();
                    lstModelloChecklist.Template = true;
                    lstModelloChecklist.DataBind();

                    int id_ckl;
                    if (int.TryParse(hdnIdChecklist.Value, out id_ckl)) ckl_selezionata = ckl_provider.GetById(id_ckl);
                    SiarLibrary.CheckListXStepCollection step;
                    string ricerca_x_misura = (string.IsNullOrEmpty(txtFiltroMisura.Text) ? null : "%" + txtFiltroMisura.Text + "%");
                    string ricerca_x_descrizione = (string.IsNullOrEmpty(txtFiltroDescrizione.Text) ? null : "%" + txtFiltroDescrizione.Text + "%");

                    if (ckl_selezionata == null)
                    {
                        tbStep.Visible = false;
                        txtDescrizione.Text = null;
                        chkTemplate.Checked = false;
                        btnElimina.Enabled = btnNuova.Enabled = false;
                    }
                    else
                    {
                        txtDescrizione.Text = ckl_selezionata.Descrizione;
                        chkTemplate.Checked = ckl_selezionata.FlagTemplate;
                        int id_ricerca_checklist;


                        //il modello deve essere della stessa fase della CheckList
                        if (!int.TryParse(lstModelloChecklist.SelectedValue, out id_ricerca_checklist)) id_ricerca_checklist = ckl_selezionata.IdCheckList;

                        step = step_provider.Find(id_ricerca_checklist, null, null, null, null, null, null);
                        if (step.Count > 0) { lstFaseProgetto.SelectedValue = step[0].CodFase; lstFaseProgetto.Enabled = false; }

                        step = step_provider.GetStepByChecklist(id_ricerca_checklist, lstFaseProgetto.SelectedValue, ricerca_x_misura , ricerca_x_descrizione);
                        System.Collections.ArrayList al_selezionati = new System.Collections.ArrayList(), al_obbligatori = new System.Collections.ArrayList(),
                            al_verbale = new System.Collections.ArrayList();
                        foreach (SiarLibrary.CheckListXStep s in step)
                        {
                            if (s.IdCheckList != null)
                            {
                                al_selezionati.Add(s.IdStep);
                                if (s.Obbligatorio) al_obbligatori.Add(s.IdStep);
                                if (s.IncludiVerbaleVis) al_verbale.Add(s.IdStep);
                            }
                        }

                        ((SiarLibrary.Web.CheckColumn)dgStep.Columns[6]).SetSelected(al_obbligatori);
                        ((SiarLibrary.Web.CheckColumn)dgStep.Columns[7]).SetSelected(al_verbale);
                        ((SiarLibrary.Web.CheckColumn)dgStep.Columns[9]).SetSelected(al_selezionati);

                        dgStep.DataSource = step;
                        dgStep.Titolo = "Elementi trovati: " + step.Count;
                        dgStep.ItemDataBound += new DataGridItemEventHandler(dgStep_ItemDataBound);
                        dgStep.DataBind();
                    }
                    break;
                default:
                    tbModifica.Visible = false;
                    string ricerca_descrizione = null;
                    if (!string.IsNullOrEmpty(txtDescrizioneRicerca.Text)) ricerca_descrizione = "%" + txtDescrizioneRicerca.Text + "%";
                    SiarLibrary.CheckListCollection ckl = new SiarBLL.CheckListCollectionProvider().Find(ricerca_descrizione, null);
                    dg.DataSource = ckl;
                    dg.Titolo = "Elementi trovati: " + ckl.Count.ToString();
                    dg.DataBind();
                    break;
            }
            base.OnPreRender(e);
        }

        protected void dgStep_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[0].RowSpan = 2;
                e.Item.Cells[1].RowSpan = 2;
                e.Item.Cells[2].RowSpan = 2;
                e.Item.Cells[3].RowSpan = 2;
                e.Item.Cells[4].RowSpan = 2;
                e.Item.Cells[5].RowSpan = 2;
                e.Item.Cells[8].RowSpan = 2;
                e.Item.Cells[9].Text = "Includi</td></tr><tr class='TESTA'><td>Selez. tutti<input id='chkSelezTutti' type='checkbox' onclick=\"selezionaTutti($(this),'chkObb');\" /></td><td>Selez. tutti<input id='chkSelezTutti' type='checkbox' onclick=\"selezionaTutti($(this),'chkVisita');\" /></td><td>Selez. tutti<input id='chkSelezTutti' type='checkbox' onclick=\"selezionaTutti($(this),'chkInclusione');\" />";
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            // usata sia per click su riga checklist che per post sulla ricerca per misura
            ucSiarNewTab.TabSelected = 2;
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {

        }

        protected void btnNuova_Click(object sender, EventArgs e)
        {
            hdnIdChecklist.Value = null;
            ckl_selezionata = null;
            ucSiarNewTab.TabSelected = 2;
            tdAvvisoModifica.InnerText = "";
            btnSalva.Enabled = true;
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                int id_checklist;
                if (int.TryParse(hdnIdChecklist.Value, out id_checklist)) ckl_selezionata = ckl_provider.GetById(id_checklist);
                if (ckl_selezionata == null) { ShowError("Per continuare è necessario selezionare la checklist desiderata."); return; }
                step_provider.DbProviderObj = ckl_provider.DbProviderObj;
                ckl_provider.DbProviderObj.BeginTran();

                // CheckListXStep
                // elimino i vecchi step
                step_provider.DeleteCollection(step_provider.Find(ckl_selezionata.IdCheckList, null, null, null, null, null, null));
                ckl_provider.Delete(ckl_selezionata);
                ckl_provider.DbProviderObj.Commit();
                btnNuova_Click(sender, e);
                ShowMessage("Checklist eliminata correttamente.");
            }
            catch (Exception ex) { ckl_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnSalva_Click(object sender, System.EventArgs e)
        {
            try
            {
                step_provider.DbProviderObj = ckl_provider.DbProviderObj;
                ckl_provider.DbProviderObj.BeginTran();
                int id_checklist;
                if (int.TryParse(hdnIdChecklist.Value, out id_checklist)) ckl_selezionata = ckl_provider.GetById(id_checklist);
                if (ckl_selezionata == null) ckl_selezionata = new SiarLibrary.CheckList();
                ckl_selezionata.Descrizione = txtDescrizione.Text;
                ckl_selezionata.FlagTemplate = chkTemplate.Checked;
                ckl_selezionata.DataModifica = DateTime.Now;
                ckl_selezionata.Operatore = ((SiarLibrary.Web.MasterPage)Master).Operatore.Utente.CfUtente;
                ckl_provider.Save(ckl_selezionata);


                // CheckListXStep
                // elimino i vecchi step
                step_provider.DeleteCollection(step_provider.Find(ckl_selezionata.IdCheckList, null, null, null, null, null, null));

                string[] step_obbligatori = ((SiarLibrary.Web.CheckColumn)dgStep.Columns[6]).GetSelected();
                string[] step_verbale = ((SiarLibrary.Web.CheckColumn)dgStep.Columns[7]).GetSelected();
                string[] step_selezionati = ((SiarLibrary.Web.CheckColumn)dgStep.Columns[9]).GetSelected();

                if (step_selezionati.Length > 0)
                {
                    for (int i = 0; i < step_selezionati.Length; i++)
                    {
                        SiarLibrary.CheckListXStep step = new SiarLibrary.CheckListXStep();
                        step.IdStep = step_selezionati[i];
                        step.IdCheckList = ckl_selezionata.IdCheckList;
                        step.Peso = 1;
                        // obbligatori
                        step.Obbligatorio = false;
                        for (int j = 0; j < step_obbligatori.Length; j++)
                            if (int.Parse(step_obbligatori[j]) == step.IdStep)
                            {
                                step.Obbligatorio = true;
                                break;
                            }
                        // con verbale
                        step.IncludiVerbaleVis = false;
                        for (int k = 0; k < step_verbale.Length; k++)
                            if (int.Parse(step_verbale[k]) == step.IdStep)
                            {
                                step.IncludiVerbaleVis = true;
                                break;
                            }
                        // ordine
                        int ordine_step;
                        int.TryParse(Request.Form["Ordine" + step.IdStep + "_text"], out ordine_step);
                        step.Ordine = (ordine_step > 0 ? ordine_step : i + 1);
                        step_provider.Save(step);
                    }
                }
                ckl_provider.DbProviderObj.Commit();
                hdnIdChecklist.Value = ckl_selezionata.IdCheckList;
                lstModelloChecklist.ClearSelection();
                ShowMessage("Checklist salvata correttamente.");
            }
            catch (Exception ex) { ckl_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnCaricaModello_Click(object sender, EventArgs e)
        {
            // lstFaseProgetto.ClearSelection();
        }

        protected void btnCaricaFaseProcedurale_Click(object sender, EventArgs e)
        {
            lstModelloChecklist.ClearSelection();
        }
    }
}
