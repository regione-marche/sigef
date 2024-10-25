using System;

namespace web.CONTROLS
{
    public partial class SNCCercaPersonaFisica : System.Web.UI.UserControl
    {
        public SiarLibrary.NullTypes.IntNT IdPersonaFisica
        {
            get { return new SiarLibrary.NullTypes.IntNT(hdnSNCCPFIdPersona.Value); }
            set { hdnSNCCPFIdPersona.Value = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //string id_parent_control = this.UniqueID.Replace("$", "_");
            //hdnSNCCPFIdPersona.Attributes.Add("ParentControl", id_parent_control);
            //txtSNCCPFCF.AddJSAttribute("ParentControl", id_parent_control);
            //txtSNCCPFNominativo.AddJSAttribute("ParentControl", id_parent_control);
            btnSNCCPFCerca.Attributes.Add("onclick", "SNCCercaPersonaFisica('" + this.UniqueID.Replace("$", "_") + "'); return false;");
        }

        protected override void OnPreRender(EventArgs e)
        {
            int id_persona_fisica;
            if (int.TryParse(hdnSNCCPFIdPersona.Value, out id_persona_fisica))
            {
                SiarLibrary.PersonaFisica pf = new SiarBLL.PersonaFisicaCollectionProvider().GetById(id_persona_fisica);
                if (pf != null)
                {
                    txtSNCCPFCF.Text = pf.CodiceFiscale;
                    txtSNCCPFNominativo.Text = pf.Cognome + " " + pf.Nome;
                }
            }
            base.OnPreRender(e);
        }
    }
}