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
                tdAggregazione.Visible = true;
                //btnPrev.Value = "<<< (1/7)";
                //btnCurrent.Value = "(2/7)";
                //btnGo.Value = "(3/7) >>>";
            }
            else
                tdAggregazione.Visible = false;

        }
    }
}