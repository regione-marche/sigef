using System;
using System.Web.UI.WebControls;

namespace web.CONTROLS
{
    public partial class GroupBoxProfilo : System.Web.UI.UserControl
    {
        public bool AbilitaModifica
        {
            set { lstGBPEnte.AbilitaModifica = value; }
        }

        public string CodEnte
        {
            get { return lstGBPEnte.SelectedValue; }
            set { lstGBPEnte.SelectedValue = value; }
        }

        public string IdProfilo
        {
            get { return lstGBPRuolo.SelectedValue; }
            set { lstGBPRuolo.SelectedValue = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPreRender(EventArgs e)
        {            
            lstGBPEnte.DataBind();
            lstGBPEnte.Attributes.Add("onchange", "$('#" + btnGBPPost.UniqueID.Replace("$", "_") + "').click();");// "provaGBPchange('" + btnGBPPost.UniqueID.Replace("$", "_") + "');");
            lstGBPRuoloBind();
            base.OnPreRender(e);
        }

        protected void btnGBPPost_Click(object sender, EventArgs e)
        {
            lstGBPRuolo.SelectedValue = null;
        }

        private void lstGBPRuoloBind()
        {
            lstGBPRuolo.Items.Clear();
            lstGBPRuolo.Items.Add("");
            foreach (SiarLibrary.Profili p in new SiarBLL.ProfiliCollectionProvider().FindByCodEnte(lstGBPEnte.SelectedValue))
                lstGBPRuolo.Items.Add(new ListItem(p.Descrizione, p.IdProfilo));
            foreach(ListItem li in lstGBPRuolo.Items)
                if (li.Value == lstGBPRuolo.SelectedValue) { li.Selected = true; break; }
        }

        public void PulisciCampi()
        {
            lstGBPEnte.ClearSelection();
            lstGBPRuolo.ClearSelection();
        }
    }
}