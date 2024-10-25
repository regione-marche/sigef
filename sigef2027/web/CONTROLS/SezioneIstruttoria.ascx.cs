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
    public partial class SezioneIstruttoria : System.Web.UI.UserControl
    {
        public string DomandePresentate { get { return lblNumeroPresentate.Text; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page is SiarLibrary.Web.IstruttoriaPage)
            {
                SiarLibrary.Bando bando = ((SiarLibrary.Web.IstruttoriaPage)Page).Bando;
                lblDataScadenzaIstruttoria.Text = bando.DataScadenza.Value.AddDays(120).ToString("dd/MM/yyyy");
                lblNumeroPresentate.Text = ((SiarLibrary.Web.IstruttoriaPage)Page).DomandePresentate;
                lblScadenza.Text = bando.DataScadenza;
                lblDesc.Text = bando.Descrizione;
                lblImporto.Text = string.Format("{0:c}", bando.Importo);
                lnkDocumentiBando.HRef = "javascript:mostraPopupDocumentiBando(" + bando.IdBando + ")";
            }
        }
    }
}
