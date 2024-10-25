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

namespace web.CONTROLS
{
    public partial class ILottoRevisioneControl : System.Web.UI.UserControl
    {
        private SiarLibrary.LottoDiRevisione _lotto;

        public SiarLibrary.LottoDiRevisione Lotto
        {
            get { return _lotto; }
            set { _lotto = value; }        
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            if (_lotto != null)
            {
                trDati.Cells[0].InnerText = _lotto.IdLotto;
                trDati.Cells[1].InnerText = _lotto.Provincia;
                trDati.Cells[2].InnerText = _lotto.DataCreazione;
                trDati.Cells[3].InnerText = _lotto.Operatore;
                trDati.Cells[4].InnerText = (_lotto.RevisioneConclusa ? "Conclusa" : "In corso");
                trDati.Cells[5].InnerText = _lotto.NumeroDomandeAssegnate;
                trDati.Cells[6].InnerText = _lotto.NumeroDomandeEstratte;
                trDati.Cells[7].InnerText = _lotto.NumeroEstrazioni;
            }
            base.OnPreRender(e);
        }
    }
}