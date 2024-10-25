using System;

namespace web.CONTROLS
{
    public partial class SNCRicercaImpresa : System.Web.UI.UserControl
    {
        public string TestoCustom
        {
            set { lblSNCRITestoCustom.Text = value; }
        }

        public SiarLibrary.NullTypes.IntNT IdImpresa
        {
            get { return hdnSNCRIIdImpresa.Value; }
            set { hdnSNCRIIdImpresa.Value = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            btnSNCRICercaImpresa.Attributes.Add("onclick", "SNCCercaImpresa('" + this.UniqueID.Replace("$", "_") + "');");
        }

        protected override void OnPreRender(EventArgs e)
        {
            SiarLibrary.Impresa impresa = null;
            int id_impresa;
            if (int.TryParse(hdnSNCRIIdImpresa.Value, out id_impresa))
            {
                impresa = new SiarBLL.ImpresaCollectionProvider().GetById(id_impresa);
                if (impresa != null)
                {
                    txtSNCRICuaa.Text = impresa.Cuaa;
                    txtSNCRIRagioneSociale.Text = impresa.RagioneSociale;
                }
            }
            base.OnPreRender(e);
        }

        public void ClearSelection()
        {
            hdnSNCRIIdImpresa.Value = null;
            txtSNCRICuaa.Text = null;
            txtSNCRIRagioneSociale.Text = null;
        }
    }
}