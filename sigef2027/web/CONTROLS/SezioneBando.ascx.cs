using System;
using System.Web.UI;

namespace web.CONTROLS
{
    public partial class SezioneBando : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SiarLibrary.Web.PrivatePage)Page).RegisterClientScriptBlock("highlightTdMenu();");
        }

        protected override void OnPreRender(EventArgs e)
        {
            loadData();
            base.OnPreRender(e);
        }

        public void loadData()
        {
            if (Page is SiarLibrary.Web.BandoPage)
            {
                SiarLibrary.Bando bando = ((SiarLibrary.Web.BandoPage)Page).Bando;
                lblId.Text = bando.IdBando;
                lblEnte.Text = bando.Ente;
                lblDesc.Text = bando.Descrizione;
                lblScadenza.Text = bando.DataScadenza;
                lblImporto.Text = String.Format("{0:c}", bando.Importo);
                lblStato.Text = bando.Stato;
                if (bando.CodStato != "P")
                {
                    SiarLibrary.BandoStoricoCollection ss = new SiarBLL.BandoStoricoCollectionProvider().Find(bando.IdBando, "L");
                    if (ss.Count > 0)
                    {
                        lblDataAtto.Text = ss[0].DataAtto;
                        lblNumAtto.Text = ss[0].NumeroAtto;
                    }
                }
                lnkDocumentiBando.HRef = "javascript:mostraPopupDocumentiBando(" + bando.IdBando + ")";
                string url = "location='../../istruttoria/statistiche.aspx'";
                if (bando.InteresseFiliera) url = "location='../../ManifInteresse/istruttoria/Collaboratori.aspx'";
                btnSezioneIstruttoria.Attributes.Add("onclick", url);
            }
        }
    }
}