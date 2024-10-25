using System;

namespace web.Private.PDomanda
{
    public partial class Anagrafica : SiarLibrary.Web.ProgettoPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ucImpresaControl.AbilitaModifica = AbilitaModifica;
            ucImpresaControl.Impresa = new SiarBLL.ImpresaCollectionProvider().GetById(Progetto.IdImpresa);
            ucImpresaControl.Progetto = new SiarBLL.ProgettoCollectionProvider().GetById(Progetto.IdProgetto);
            ucImpresaControl.ContoCorrenteObbligatorio = true;

            if (Bando.Aggregazione)
            {
                btnPrev.Value = "<<< (1/8)";
                btnCurrent.Value = "(2/8)";
                btnGo.Value = "(3/8) >>>";
            }

        }
    }
}