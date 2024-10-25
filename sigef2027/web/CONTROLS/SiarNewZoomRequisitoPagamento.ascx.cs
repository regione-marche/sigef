using System;

namespace web.CONTROLS
{
    public partial class SiarNewZoomRequisitoPagamento : System.Web.UI.UserControl
    {
        private SiarLibrary.RequisitiPagamentoPlurivalore _valoreSelezionato;
        public SiarLibrary.RequisitiPagamentoPlurivalore ValoreSelezionato { set { _valoreSelezionato = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.HiddenField hdnIdDisposizioniAttuative = new System.Web.UI.WebControls.HiddenField();
            hdnIdDisposizioniAttuative.ID = "hdnZoomIdRequistoDispAttuative" + _valoreSelezionato.IdRequisito;
            hdnIdDisposizioniAttuative.Value = _valoreSelezionato.AdditionalAttributes["IdDisposizioniAttuative"];
            tdSeleziona.Controls.Add(hdnIdDisposizioniAttuative);

            System.Web.UI.WebControls.HiddenField hdnIdValoreRequisito = new System.Web.UI.WebControls.HiddenField();
            hdnIdValoreRequisito.ID = "hdnZoomIdValoreRequisito" + _valoreSelezionato.IdRequisito;
            if (_valoreSelezionato.IdValore != null) hdnIdValoreRequisito.Value = _valoreSelezionato.IdValore;
            tdSeleziona.Controls.Add(hdnIdValoreRequisito);

            System.Web.UI.HtmlControls.HtmlImage img = new System.Web.UI.HtmlControls.HtmlImage();
            img.Src = Request.ApplicationPath + "/images/folderopen.png";
            img.Alt = "Mostra elenco";
            tdSeleziona.Controls.Add(img);
            tdSeleziona.Attributes.Add("onclick", "runZoomRequisitoPagamentoSearch(" + _valoreSelezionato.IdRequisito + ")");

            System.Web.UI.HtmlControls.HtmlImage img2 = new System.Web.UI.HtmlControls.HtmlImage();
            img2.Src = Request.ApplicationPath + "/images/xdel.gif";
            img2.Alt = "Deseleziona";
            img2.Width = 12;
            img2.Height = 12;
            tdDeseleziona.Controls.Add(img2);
            tdDeseleziona.Attributes.Add("onclick", "deselectZoomRequisitoValore(" + _valoreSelezionato.IdRequisito + ")");
    
        }
    }
}