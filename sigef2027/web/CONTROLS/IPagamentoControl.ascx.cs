using System;
using System.Web.UI;

namespace web.CONTROLS
{
    public partial class IPagamentoControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private SiarLibrary.Bando bando
        {
            get { return (SiarLibrary.Bando)Session["_bando"]; }
        }

        private string DomandePresentate
        {
            get
            {
                if (Page is SiarLibrary.Web.IstruttoriaPage) return ((SiarLibrary.Web.IstruttoriaPage)Page).DomandePresentate;
                else if (Page is SiarLibrary.Web.IstruttoriaPagamentoPage) return ((SiarLibrary.Web.IstruttoriaPagamentoPage)Page).DomandePresentate;
                return null;
            }
        }


        public void loadData()
        {
            if (Page is SiarLibrary.Web.IstruttoriaPage || Page is SiarLibrary.Web.IstruttoriaPagamentoPage)
            {
                lblScadenza.Text = bando.DataScadenza;
                lblDesc.Text = bando.Descrizione;
                lblImporto.Text = String.Format("{0:c}", bando.Importo);
                if (bando.CodStato != "P")
                {
                    SiarLibrary.BandoStoricoCollection ss = new SiarBLL.BandoStoricoCollectionProvider().Find(bando.IdBando, "L");
                    if (ss.Count > 0)
                    {
                        lblDataAtto.Text = ss[0].DataAtto;
                        lblNumAtto.Text = ss[0].NumeroAtto;
                    }
                }
                lblDomandePresentate.Text = DomandePresentate;
                lnkDocumentiBando.HRef = "javascript:mostraPopupDocumentiBando(" + bando.IdBando + ")";
            }
            ((SiarLibrary.Web.PrivatePage)Page).RegisterClientScriptBlock("highlightTdMenu();");
        }
    }
}