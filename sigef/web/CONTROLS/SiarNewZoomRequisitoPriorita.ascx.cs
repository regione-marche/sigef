using System;

namespace web.CONTROLS
{
    public partial class SiarNewZoomRequisitoPriorita : System.Web.UI.UserControl
    {
        private SiarLibrary.ValoriPriorita _valoreSelezionato;
        public SiarLibrary.ValoriPriorita ValoreSelezionato { set { _valoreSelezionato = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.HiddenField hdnIdDisposizioniAttuative = new System.Web.UI.WebControls.HiddenField();
            hdnIdDisposizioniAttuative.ID = "hdnZoomIdPrioritaDispAttuative" + _valoreSelezionato.IdPriorita;
            hdnIdDisposizioniAttuative.Value = _valoreSelezionato.AdditionalAttributes["IdDisposizioniAttuative"];
            tdSeleziona.Controls.Add(hdnIdDisposizioniAttuative);

            System.Web.UI.WebControls.HiddenField hdnIdValorePriorita = new System.Web.UI.WebControls.HiddenField();
            hdnIdValorePriorita.ID = "hdnZoomIdValorePriorita" + _valoreSelezionato.IdPriorita;
            if (_valoreSelezionato.IdValore != null) hdnIdValorePriorita.Value = _valoreSelezionato.IdValore;
            tdSeleziona.Controls.Add(hdnIdValorePriorita);

            System.Web.UI.HtmlControls.HtmlImage img = new System.Web.UI.HtmlControls.HtmlImage();
            img.Src = Request.ApplicationPath + "/images/folderopen.png";
            img.Alt = "Mostra elenco";
            tdSeleziona.Controls.Add(img);
            tdSeleziona.Attributes.Add("onclick", "runZoomPrioritaSearch(" + _valoreSelezionato.IdPriorita + ")");

            System.Web.UI.HtmlControls.HtmlImage img2 = new System.Web.UI.HtmlControls.HtmlImage();
            img2.Src = Request.ApplicationPath + "/images/xdel.gif";
            img2.Alt = "Deseleziona";
            img2.Width = 12;
            img2.Height = 12;
            tdDeseleziona.Controls.Add(img2);
            tdDeseleziona.Attributes.Add("onclick", "deselectZoomPrioritaValore(" + _valoreSelezionato.IdPriorita + ")");
        }
    }
}