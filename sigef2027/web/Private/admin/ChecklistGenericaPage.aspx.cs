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
    public partial class ChecklistGenericaPage : ChecklistGenericaClassPage
    {
        ChecklistGenericaCollectionProvider checklist_provider;
        VoceXChecklistGenericaCollectionProvider voci_x_checklist_provider;
        VoceGenericaCollectionProvider voci_provider;
        SchedaXChecklistCollectionProvider schede_x_checklist_provider;

        #region Indici colonne

        //colonne voci
        private int col_VoceOrdina = 0,
            col_VoceIdVoceXChecklist = 1,
            col_VoceIdVoce = 2,
            col_VoceDescrizione = 3,
            col_VoceAutomatico = 4,
            col_VoceOrdine = 5,
            col_VoceObbligatorio = 6,
            col_VocePeso = 7,
            col_VoceIncludi = 8;

        //colonne schede
        private int col_SchedaOrdina = 0,
            col_SchedaIdChecklist = 1,
            col_SchedaDescrizione = 2,
            col_SchedaTemplate = 3,
            col_SchedaOrdine = 4,
            col_SchedaObbligatorio = 5,
            col_SchedaPeso = 6,
            col_SchedaIncludi = 7;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            lstTipoChecklist.DataBind();
            lstFiltro.DataBind();
        }

        protected override void OnPreRender(EventArgs e)
        {
            InizializzaProvider();

            RiempiFormChecklist();
            RiempiFormVociChecklist();
            RiempiFormSchedeChecklist();

            base.OnPreRender(e);
        }

        private void InizializzaProvider()
        {
            checklist_provider = new ChecklistGenericaCollectionProvider();
            voci_x_checklist_provider = new VoceXChecklistGenericaCollectionProvider();
            voci_provider = new VoceGenericaCollectionProvider();
            schede_x_checklist_provider = new SchedaXChecklistCollectionProvider();
        }

        private void RiempiFormChecklist()
        {
            if (ChecklistGenerica != null && ChecklistGenerica.IdChecklistGenerica != null)
            {
                //mi aggiorno la checklist in sessione per caricare eventuali campi presi da vista
                ChecklistGenerica = checklist_provider.GetById(ChecklistGenerica.IdChecklistGenerica);

                txtDescrizioneChecklistGenerica.Text = ChecklistGenerica.Descrizione;
                chkTemplate.Checked = ChecklistGenerica.FlagTemplate ?? false;
                lstTipoChecklist.SelectedValue = ChecklistGenerica.IdTipo;
                lstFiltro.SelectedValue = ChecklistGenerica.IdFiltro;
            }
            else
            {
                txtDescrizioneChecklistGenerica.Text = null;
                chkTemplate.Checked = false;
                lstTipoChecklist.SelectedValue = null;
                lstFiltro.SelectedValue = null;
            }
        }

        private void PopolaChecklist(ref ChecklistGenerica checklist)
        {
            checklist.Descrizione = txtDescrizioneChecklistGenerica.Text;
            checklist.FlagTemplate = chkTemplate.Checked;
            checklist.IdTipo = lstTipoChecklist.SelectedValue;
            checklist.IdFiltro = lstFiltro.SelectedValue;
        }

        private void RiempiFormVociChecklist()
        {

            if (ChecklistGenerica != null && ChecklistGenerica.IdChecklistGenerica != null && ChecklistGenerica.ContieneVociTipo)
            {
                var voci_generiche_coll = new VoceGenericaCollection();

                //aggiungo prima le voci associate (indipendentemente dal tipo, così non perdo nulla) e poi le altre voci che potrebbe associare con lo stesso filtro
                var voci_presenti_coll = voci_provider.GetVociByIdChecklist(ChecklistGenerica.IdChecklistGenerica);
                var voci_non_presenti_coll = voci_provider.GetVociNotInIdChecklist(ChecklistGenerica.IdChecklistGenerica, ChecklistGenerica.IdFiltro);

                voci_generiche_coll.AddCollection(voci_presenti_coll);
                voci_generiche_coll.AddCollection(voci_non_presenti_coll);

                dgVociChecklist.DataSource = voci_generiche_coll;
                dgVociChecklist.ItemDataBound += new DataGridItemEventHandler(dgVociChecklist_ItemDataBound);
                dgVociChecklist.DataBind();
            }
            else
            {
                divVociAssociateChecklist.Visible = false;
            }
        }

        private void RiempiFormSchedeChecklist()
        {
            if (ChecklistGenerica != null && ChecklistGenerica.IdChecklistGenerica != null && !ChecklistGenerica.ContieneVociTipo)
            {
                var schede_coll = new SchedaXChecklistCollection();

                //aggiungo prima le schede collegate per mantenere l'ordine
                var schede_presenti = checklist_provider.GetSchedeByIdChecklist(ChecklistGenerica.IdChecklistGenerica);
                var schede_non_presenti = checklist_provider.GetSchedeNotInIdChecklist(ChecklistGenerica.IdChecklistGenerica);

                schede_coll.AddCollection(schede_presenti);
                schede_coll.AddCollection(schede_non_presenti);

                dgSchede.DataSource = schede_coll;
                dgSchede.ItemDataBound += new DataGridItemEventHandler(dgSchede_ItemDataBound);
                dgSchede.DataBind();
            }
            else
            {
                divSchedeAssociateChecklist.Visible = false;
            }
        }

        #region Button Click

        protected void btnSalvaChecklistGenerica_Click(object sender, EventArgs e)
        {
            try
            {
                checklist_provider = new ChecklistGenericaCollectionProvider();
                checklist_provider.DbProviderObj.BeginTran();

                ChecklistGenerica checklist;
                if (ChecklistGenerica == null)
                {
                    checklist = new ChecklistGenerica();
                    checklist.CfInserimento = Operatore.Utente.CfUtente;
                    checklist.DataInserimento = DateTime.Now;
                }
                else
                    checklist = ChecklistGenerica;

                checklist.CfModifica = Operatore.Utente.CfUtente;
                checklist.DataModifica = DateTime.Now;

                PopolaChecklist(ref checklist);

                checklist_provider.Save(checklist);
                checklist_provider.DbProviderObj.Commit();
                ChecklistGenerica = checklist;
                ShowMessage("Checklist salvata correttamente");
            }
            catch (Exception ex)
            {
                ChecklistGenerica = null;
                checklist_provider.DbProviderObj.Rollback();
                ShowError(ex.Message);
            }
        }

        protected void btnEliminaChecklistGenerica_Click(object sender, EventArgs e)
        {
            try
            {
                checklist_provider = new ChecklistGenericaCollectionProvider();
                checklist_provider.DbProviderObj.BeginTran();

                if (ChecklistGenerica != null && ChecklistGenerica.IdChecklistGenerica != null)
                {
                    var voci_checklist_coll = new VoceXChecklistGenericaCollectionProvider().FindGenerica(null, ChecklistGenerica.IdChecklistGenerica, null);
                    if (voci_checklist_coll.Count > 0)
                        throw new Exception("La checklist ha " + voci_checklist_coll.Count + " voci associate: non è possibile eliminarla");

                    var schede_checklist_coll = new SchedaXChecklistCollectionProvider().Find(null, ChecklistGenerica.IdChecklistGenerica, null);
                    if (schede_checklist_coll.Count > 0)
                        throw new Exception("La checklist ha " + schede_checklist_coll.Count + " schede associate: non è possibile eliminarla");

                    checklist_provider.Delete(ChecklistGenerica);

                    checklist_provider.DbProviderObj.Commit();
                    Redirect(PATH_ADMIN + "RicercaChecklistGenerica.aspx", "Checklist eliminata correttamente", false);
                }
                else
                    throw new Exception("Checklist non salvata");
            }
            catch (Exception ex)
            {
                checklist_provider.DbProviderObj.Rollback();
                ShowError(ex.Message);
            }
        }

        protected void btnSalvaVociChecklist_Click(object sender, EventArgs e)
        {
            try
            {
                checklist_provider = new ChecklistGenericaCollectionProvider();
                checklist_provider.DbProviderObj.BeginTran();
                voci_x_checklist_provider = new VoceXChecklistGenericaCollectionProvider(checklist_provider.DbProviderObj);

                if (ChecklistGenerica != null && ChecklistGenerica.IdChecklistGenerica != null)
                {
                    //elimino le voci già presenti e le ricreo
                    var voci_vecchie = voci_x_checklist_provider.FindGenerica(null, ChecklistGenerica.IdChecklistGenerica, null);
                    voci_x_checklist_provider.DeleteCollection(voci_vecchie);

                    string[] voci_obbligatorie = ((CheckColumn)dgVociChecklist.Columns[col_VoceObbligatorio]).GetSelected();
                    List<string> voci_obbligatorie_list = voci_obbligatorie.ToList<string>();
                    string[] voci_selezionate = ((CheckColumn)dgVociChecklist.Columns[col_VoceIncludi]).GetSelected();

                    if (voci_selezionate.Length > 0)
                    {
                        for (int i = 0; i < voci_selezionate.Length; i++)
                        {
                            var id_voce = int.Parse(voci_selezionate[i]);

                            var vxc = new VoceXChecklistGenerica();
                            vxc.IdVoceGenerica = id_voce;
                            vxc.IdChecklistGenerica = ChecklistGenerica.IdChecklistGenerica;
                            vxc.CfInserimento = Operatore.Utente.CfUtente;
                            vxc.DataInserimento = DateTime.Now;
                            vxc.CfModifica = Operatore.Utente.CfUtente;
                            vxc.DataModifica = DateTime.Now;

                            var peso = Request.Form["VocePeso" + id_voce + "_text"];
                            vxc.Peso = (peso == null || peso == "") ? 1 : decimal.Parse(peso);

                            if (voci_obbligatorie_list.Contains(voci_selezionate[i]))
                                vxc.Obbligatorio = true;
                            else
                                vxc.Obbligatorio = false;

                            vxc.Ordine = i + 1;

                            voci_x_checklist_provider.Save(vxc);
                        }
                    }

                    checklist_provider.DbProviderObj.Commit();
                    ShowMessage("Checklist salvata correttamente.");

                }
                else
                    throw new Exception("Checklist non salvata");
            }
            catch (Exception ex)
            {
                checklist_provider.DbProviderObj.Rollback();
                ShowError(ex.Message);
            }
        }

        protected void btnAnnullaCambiamentiVociChecklist_Click(object sender, EventArgs e) { }

        protected void btnSalvaSchedeChecklist_Click(object sender, EventArgs e)
        {
            try
            {
                checklist_provider = new ChecklistGenericaCollectionProvider();
                checklist_provider.DbProviderObj.BeginTran();
                schede_x_checklist_provider = new SchedaXChecklistCollectionProvider(checklist_provider.DbProviderObj);

                if (ChecklistGenerica != null && ChecklistGenerica.IdChecklistGenerica != null)
                {
                    //elimino le schede già presenti e le ricreo 
                    var schede_checklist_vecchie = new SchedaXChecklistCollectionProvider().Find(null, ChecklistGenerica.IdChecklistGenerica, null);
                    schede_x_checklist_provider.DeleteCollection(schede_checklist_vecchie);

                    string[] schede_obbligatorie = ((CheckColumn)dgSchede.Columns[col_SchedaObbligatorio]).GetSelected();
                    List<string> schede_obbligatorie_list = schede_obbligatorie.ToList<string>();
                    string[] schede_selezionate = ((CheckColumn)dgSchede.Columns[col_SchedaIncludi]).GetSelected();

                    if (schede_selezionate.Length > 0)
                    {
                        for (int i = 0; i < schede_selezionate.Length; i++)
                        {
                            var id_scheda = int.Parse(schede_selezionate[i]);

                            var sxc = new SchedaXChecklist();
                            sxc.IdChecklistFiglio = id_scheda;
                            sxc.IdChecklistPadre = ChecklistGenerica.IdChecklistGenerica;
                            sxc.CfInserimento = Operatore.Utente.CfUtente;
                            sxc.DataInserimento = DateTime.Now;
                            sxc.CfModifica = Operatore.Utente.CfUtente;
                            sxc.DataModifica = DateTime.Now;

                            var peso = Request.Form["SchedaPeso" + id_scheda + "_text"];
                            sxc.Peso = (peso == null || peso == "") ? 1 : decimal.Parse(peso);

                            if (schede_obbligatorie_list.Contains(schede_selezionate[i]))
                                sxc.Obbligatorio = true;
                            else
                                sxc.Obbligatorio = false;

                            sxc.Ordine = i + 1;

                            schede_x_checklist_provider.Save(sxc);
                        }
                    }

                    checklist_provider.DbProviderObj.Commit();
                    ShowMessage("Checklist salvata correttamente.");

                }
                else
                    throw new Exception("Checklist non salvata");
            }
            catch (Exception ex)
            {
                checklist_provider.DbProviderObj.Rollback();
                ShowError(ex.Message);
            }
        }

        protected void btnAnnullaCambiamentiSchedeChecklist_Click(object sender, EventArgs e) { }

        #endregion

        #region ItemDataBound

        void dgVociChecklist_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;

            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var voce = (VoceGenerica)dgi.DataItem;
                var voce_x_checklist_coll = voci_x_checklist_provider.FindGenerica(null, ChecklistGenerica.IdChecklistGenerica, voce.IdVoceGenerica);

                if (voce.Titolo)
                    dgi.Cells[col_VoceDescrizione].Text = "<b>" + dgi.Cells[col_VoceDescrizione].Text + "</b>";

                if (voce_x_checklist_coll.Count > 0)
                {
                    var vxc = voce_x_checklist_coll[0];

                    dgi.Cells[col_VoceIdVoceXChecklist].Text = vxc.IdVoceXChecklistGenerica;
                    dgi.Cells[col_VoceOrdine].Text = vxc.Ordine;
                    dgi.Cells[col_VocePeso].Text = @"<span id='Peso" + vxc.IdVoceGenerica + "' class='IntegerBox' nocurrency='true'><input type='text' id='VocePeso" + vxc.IdVoceGenerica + "_text' name='VocePeso" + vxc.IdVoceGenerica + "_text' value='" + vxc.Peso + "' style='text-align:right;width:60px' class=''></span>";

                    if (vxc.AutomaticoVoce != null && vxc.AutomaticoVoce)
                        dgi.Cells[col_VoceAutomatico].Text = dgi.Cells[col_VoceAutomatico].Text.Replace("<input", "<input checked");
                    else
                        dgi.Cells[col_VoceAutomatico].Text = dgi.Cells[col_VoceAutomatico].Text.Replace("checked", "");

                    if (vxc.Obbligatorio != null && vxc.Obbligatorio)
                        dgi.Cells[col_VoceObbligatorio].Text = dgi.Cells[col_VoceObbligatorio].Text.Replace("<input", "<input checked");
                    else
                        dgi.Cells[col_VoceObbligatorio].Text = dgi.Cells[col_VoceObbligatorio].Text.Replace("checked", "");

                    dgi.Cells[col_VoceIncludi].Text = "<span class='check'><input type='checkbox' id='chkVoceIncludi' name='chkVoceIncludi' value='" + vxc.IdVoceGenerica + "' checked=''></span>";
                }
                else
                {
                    dgi.Cells[col_VoceIdVoceXChecklist].Text = null;
                    dgi.Cells[col_VoceOrdine].Text = null;
                    dgi.Cells[col_VocePeso].Text = @"<span id='Peso" + voce.IdVoceGenerica + "' class='IntegerBox' nocurrency='true'><input type='text' id='VocePeso" + voce.IdVoceGenerica + "_text' name='VocePeso" + voce.IdVoceGenerica + "_text' value='' style='text-align:right;width:60px' class=''></span>";

                    if (voce.Automatico != null && voce.Automatico)
                        dgi.Cells[col_VoceAutomatico].Text = dgi.Cells[col_VoceAutomatico].Text.Replace("<input", "<input checked");
                    else
                        dgi.Cells[col_VoceAutomatico].Text = dgi.Cells[col_VoceAutomatico].Text.Replace("checked", "");
                    
                    dgi.Cells[col_VoceObbligatorio].Text = dgi.Cells[col_VoceObbligatorio].Text.Replace("checked", "");
                    dgi.Cells[col_VoceIncludi].Text = "<span class='check'><input type='checkbox' id='chkVoceIncludi' name='chkVoceIncludi' value='" + voce.IdVoceGenerica + "'></span>";
                }
            }
        }

        void dgSchede_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;

            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var scheda = (ChecklistGenerica)dgi.DataItem;
                var scheda_x_checklist_coll = schede_x_checklist_provider.Find(null, ChecklistGenerica.IdChecklistGenerica, scheda.IdChecklistGenerica);

                if (scheda_x_checklist_coll.Count > 0)
                {
                    var sxc = scheda_x_checklist_coll[0];

                    dgi.Cells[col_SchedaOrdine].Text = sxc.Ordine;

                    if (sxc.Obbligatorio != null && sxc.Obbligatorio)
                        dgi.Cells[col_SchedaObbligatorio].Text = dgi.Cells[col_SchedaObbligatorio].Text.Replace("<input", "<input checked");
                    else
                        dgi.Cells[col_SchedaObbligatorio].Text = dgi.Cells[col_SchedaObbligatorio].Text.Replace("checked", "");

                    dgi.Cells[col_SchedaPeso].Text = @"<span id='SchedaPeso" + sxc.IdChecklistFiglio + "' class='IntegerBox' nocurrency='true'><input type='text' id='SchedaPeso" + sxc.IdChecklistFiglio + "_text' name='SchedaPeso" + sxc.IdChecklistFiglio + "_text' value='" + sxc.Peso + "' style='text-align:right;width:60px' class=''></span>";

                    dgi.Cells[col_SchedaIncludi].Text = "<span class='check'><input type='checkbox' id='chkSchedaIncludi' name='chkSchedaIncludi' value='" + scheda.IdChecklistGenerica + "' checked=''></span>";
                }
                else
                {
                    dgi.Cells[col_SchedaOrdine].Text = null;
                    dgi.Cells[col_SchedaObbligatorio].Text = dgi.Cells[col_SchedaObbligatorio].Text.Replace("checked", "");
                    dgi.Cells[col_SchedaPeso].Text = @"<span id='SchedaPeso" + scheda.IdChecklistGenerica + "' class='IntegerBox' nocurrency='true'><input type='text' id='SchedaPeso" + scheda.IdChecklistGenerica + "_text' name='SchedaPeso" + scheda.IdChecklistGenerica + "_text' value='' style='text-align:right;width:60px' class=''></span>";
                    dgi.Cells[col_SchedaIncludi].Text = "<span class='check'><input type='checkbox' id='chkSchedaIncludi' name='chkSchedaIncludi' value='" + scheda.IdChecklistGenerica + "'></span>";
                }

                if (scheda.FlagTemplate != null && scheda.FlagTemplate)
                    dgi.Cells[col_SchedaTemplate].Text = dgi.Cells[col_SchedaTemplate].Text.Replace("<input", "<input checked");
                else
                    dgi.Cells[col_SchedaTemplate].Text = dgi.Cells[col_SchedaTemplate].Text.Replace("checked", "");
            }
        }

        #endregion
    }
}