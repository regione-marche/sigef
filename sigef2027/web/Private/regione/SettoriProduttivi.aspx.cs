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

    public partial class SettoriProduttivi : SiarLibrary.Web.PrivatePage
    {
        private SiarBLL.SettoriProduttiviCollectionProvider setpro = new SiarBLL.SettoriProduttiviCollectionProvider();
         private SiarLibrary.SettoriProduttivi sett;

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "settori_produttivi";
            base.OnPreInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack && Request.Form["__EVENTTARGET"] == "Modifica")
            {
                hdnEdit.Value = Request.Form["__EVENTARGUMENT"];
                TAB1.Select(1);
                sett = setpro.GetById(hdnEdit.Value);
                txtDescrizione.Text = sett.Descrizione;
            }

        }

        protected override void OnPreRender(EventArgs e)
        {
            
            if ( string.IsNullOrEmpty ( hdnEdit.Value) )
            {
                btnElimina.Enabled = false;
               
            }
            SiarLibrary.SettoriProduttiviCollection setcoll = setpro.Find(null,null);

            dgSettore.DataSource = setcoll;
            dgSettore.Titolo = "Elementi trovati: " + setcoll.Count;
            dgSettore.DataBind();

            base.OnPreRender(e);
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.SettoriProduttivi sp = new SiarLibrary.SettoriProduttivi();
                if (!string.IsNullOrEmpty(hdnEdit.Value)) 
                    sp = setpro.GetById(hdnEdit.Value);
                sp.Descrizione = txtDescrizione.Text;
                setpro.Save(sp);
                hdnEdit.Value = sp.IdSettoreProduttivo;
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
                setpro.DbProviderObj.BeginTran();
               
                setpro.Delete(setpro.GetById(hdnEdit.Value));
                ShowMessage("Settore produttivo eliminato.");
                TAB1.Select(0);
                setpro.DbProviderObj.Commit();
            }
            catch
            {
                setpro.DbProviderObj.Rollback();
                this.ShowError("Attenzione", "Impossibile eliminare il settore produttivo perche' associato al bando.");
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
