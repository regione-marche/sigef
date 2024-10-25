using System;
using System.Web.UI.WebControls;

namespace web.Public
{
    public partial class NewsComunicazioniAgid : SiarLibrary.Web.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "public_news_agid";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            SiarLibrary.NewsCollection news = new SiarBLL.NewsCollectionProvider().GetUltimeNews(3);
            rptNews.DataSource = news;
            rptNews.DataBind();
        }

        protected override void OnPreRender(EventArgs e)
        {
            SiarBLL.NewsCollectionProvider news_provider = new SiarBLL.NewsCollectionProvider();
            SiarLibrary.NewsCollection news = new SiarLibrary.NewsCollection();
            if (string.IsNullOrEmpty(txtTestoLibero.Text)) news.AddCollection(news_provider.Find(null, null, null));
            else
            {   // ricerco sia su titolo che su testo
                news.AddCollection(news_provider.Find("%" + txtTestoLibero.Text + "%", null, null));
                news.AddCollection(news_provider.Find(null, "%" + txtTestoLibero.Text + "%", null));
            }
            //dg.DataSource = news;
            //dg.Titolo = "Elementi trovati: " + news.Count.ToString();
            //dg.ItemDataBound += new DataGridItemEventHandler(dg_ItemDataBound);
            //dg.DataBind();
            rptNewsComplete.DataSource = news;
            rptNewsComplete.DataBind();
            base.OnPreRender(e);
        }

        void dg_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                SiarLibrary.News n = (SiarLibrary.News)e.Item.DataItem;
                e.Item.Cells[0].Text = "<div class='newsTitle'>" + n.Titolo + "</div><div class='newsBody' style='text-indent:1em'>" + n.Testo + "</div><div class='newsFooter'>"
                    + (!string.IsNullOrEmpty(n.Url) ? "<a href='" + n.Url + "' target=_blank style='margin-right:20px'>Segui il link</a>" : "&nbsp;") + n.Data + "</div>";
            }
        }

        protected void btnCerca_Click(object sender, EventArgs e)
        {

        }
    }
}
