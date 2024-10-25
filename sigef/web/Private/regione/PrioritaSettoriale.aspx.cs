using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;



namespace web.Private.regione
{

    public partial class PrioritaSettoriale : SiarLibrary.Web.PrivatePage
    {
        private SiarBLL.PrioritaSettorialiCollectionProvider priosettPro = new SiarBLL.PrioritaSettorialiCollectionProvider();
        private SiarLibrary.PrioritaSettoriali prioSett;
 
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "priorita_settoriali";
            base.OnPreInit(e);
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack && Request.Form["__EVENTTARGET"] == "Modifica")
            {
                hdnEdit.Value = Request.Form["__EVENTARGUMENT"];
                TAB1.Select(1);
                prioSett = priosettPro.GetById(hdnEdit.Value);
                txtDescrizione.Text = prioSett.Descrizione;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            
            if ( string.IsNullOrEmpty ( hdnEdit.Value) )
            {
                btnElimina.Enabled = false;
               
            }
            SiarLibrary.PrioritaSettorialiCollection priosetcoll = priosettPro.Find(null,null);

            dgPrioSett.DataSource = priosetcoll;
            dgPrioSett.Titolo = "Elementi trovati: " + priosetcoll.Count;
            dgPrioSett.DataBind();

            base.OnPreRender(e);
        }




        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.PrioritaSettoriali sp = new SiarLibrary.PrioritaSettoriali();
                if (!string.IsNullOrEmpty(hdnEdit.Value)) sp = priosettPro.GetById(hdnEdit.Value);

                sp.Descrizione = txtDescrizione.Text;
                priosettPro.Save(sp);
                hdnEdit.Value = sp.IdPrioritaSettoriale;
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
                priosettPro.DbProviderObj.BeginTran();

                priosettPro.Delete(priosettPro.GetById(hdnEdit.Value));
                ShowMessage("Priorità settoriale eliminata correttamente.");
                TAB1.Select(0);
                priosettPro.DbProviderObj.Commit();
            }
            catch
            {
                priosettPro.DbProviderObj.Rollback();
                this.ShowError("Attenzione", "Impossibile eliminare la priorità settoriale perche' associata al bando.");
            }
            finally
            {
                txtDescrizione.Text = "";
                hdnEdit.Value = "";
            }
        }
        protected void txtNuovo_Click(object sender, EventArgs e)
        {
            hdnEdit.Value = "";
            txtDescrizione.Text = "";
        }



    }
}