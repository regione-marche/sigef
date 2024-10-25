using System;

namespace web.Private.regione
{
    /// <summary>
    /// Summary description for Step.
    /// </summary>
    public partial class Step : SiarLibrary.Web.PrivatePage
    {

        private SiarBLL.StepCollectionProvider stepPro = new SiarBLL.StepCollectionProvider();

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "Step";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {

            if (IsPostBack && Request.Form["__EVENTTARGET"] != null)
            {
                if (Request.Form["__EVENTTARGET"] == "modifica_step")
                {
                    SiarLibrary.Step step = stepPro.GetById(hdnEdit.Value);
                    _dataSource = step;
                    TAB1.Select(1);
                    txtIdStepSel.Text = step.IdStep;
                    txtQueryLungaSQL.Text = step.QuerySql;
                    txtQueryPost.Text = step.QuerySqlPost;
                    chkAutomatico.Checked = step.Automatico;
                    txtMisura.Text = step.Misura;
                    ControlloStep(step.IdStep);
                    TAB1.DataBind();
                    lstFaseProcedurale.Items.Clear();
                    lstFase.SelectedValue = step.CodFase;
                }
            }
            if (lstFase.SelectedIndex == -1)
            { lstFase.DataBind(); }

            lstFaseProcedurale.DataBind();
        }

        private void ControlloStep(SiarLibrary.NullTypes.IntNT idStep)
        {
            // controllo se lo step è associato ad una CheckList di un bando pubblicato
            SiarLibrary.DbProvider db = new SiarLibrary.DbProvider();
            System.Data.IDbCommand cmd = db.GetCommand();

            cmd.CommandText = "SELECT STEP.ID_STEP, B.COD_STATO "
                              + "  FROM STEP INNER JOIN"
                              + "  CHECK_LIST_X_STEP ON STEP.ID_STEP = CHECK_LIST_X_STEP.ID_STEP INNER JOIN"
                              + "  STEP_X_BANDO ON CHECK_LIST_X_STEP.ID_CHECK_LIST = STEP_X_BANDO.ID_CHECK_LIST INNER JOIN"
                              + "  VBANDO B ON STEP_X_BANDO.ID_BANDO = B.ID_BANDO"
                              + "  WHERE (STEP.ID_STEP = " + idStep + ")";
            db.InitDatareader(cmd);

            while (db.DataReader.Read())
            {
                SiarLibrary.NullTypes.StringNT cod_stato = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO"]);
                if (cod_stato != "P")
                {
                    AbilitaModifica = false;
                    ShowMessage("Impossibile modificare lo step perchè associato alla Checklist di un bando pubblicato.");
                    break;
                }
            }
            db.Close();
        }


        protected override void OnPreRender(EventArgs e)
        {
            SiarLibrary.StepCollection stepColl = stepPro.Find(txtIdStep.Text == "" ? null: txtIdStep.Text, null, lstFaseProcedurale.SelectedValue);
            stepColl = stepColl.FiltroMisura(txtFiltroMisura.Text != null ? "%" + txtFiltroMisura.Text.Replace(")", "") + "%" : txtFiltroMisura.Text);
            dg.DataSource = stepColl;
            dg.DataBind();
            dg.Titolo = "Elementi trovati: " + stepColl.Count;
            if (string.IsNullOrEmpty(hdnEdit.Value)) btnElimina.Enabled = false;
            base.OnPreRender(e);
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion


        protected void btnSalva_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDescrizione.Text)) throw new Exception("La descrizione dello step è obbligatoria. Impossibile continuare");
                if (string.IsNullOrEmpty(lstFase.SelectedValue)) throw new Exception("La fase procedurale dello step è obbligatoria. Impossibile continuare");
                
                SiarLibrary.Step step = new SiarLibrary.Step();
                int id_step;
                if (int.TryParse(hdnEdit.Value, out id_step))
                { step = stepPro.GetById(id_step); }
                
                step.Descrizione = txtDescrizione.Text;
                step.Misura = (txtMisura.Text != null ? txtMisura.Text.Replace(")", "") : txtMisura.Text);
                step.CodFase = lstFase.SelectedValue;
                step.Automatico = chkAutomatico.Checked;
                step.QuerySql = txtQueryLungaSQL.Text.Replace("`", "\'");
                step.Url = txtUrl.Text;
                step.CodeMethod = txtCode.Text;
                step.QuerySqlPost = txtQueryPost.Text;
                step.ValMinimo = txtValoreMinimo.Text;
                step.ValMassimo = txtValoreMassimo.Text;
                stepPro.Save(step);
                TAB1.Select(0);
                ShowMessage("Salvataggio completato");
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }

        }
        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                stepPro.Delete(stepPro.GetById(hdnEdit.Value));
                ShowMessage("Step eliminato.");
                hdnEdit.Value = string.Empty;
                TAB1.Select(0);
                txtDescrizione.Text = string.Empty;
                lstFase.SelectedValue = "";
                txtValoreMassimo.Text = string.Empty;
                txtValoreMinimo.Text = string.Empty;
                chkAutomatico.Checked = false;
                txtQueryPost.Text = string.Empty;
                txtQueryLungaSQL.Text = string.Empty;
                txtUrl.Text = string.Empty;
                txtCode.Text = string.Empty;

            }
            catch
            {
                this.ShowError("Impossibile eliminare lo step", "Esistono correlazioni nella Checklist");
            }
        }
    }
}

