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
using TelegramBot;
using System.Threading;

namespace web.Private.regione
{
    public partial class News : SiarLibrary.Web.PrivatePage
    {
        SiarBLL.NewsCollectionProvider news_provider = new SiarBLL.NewsCollectionProvider();
        SiarLibrary.News news_selezionata;

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "news_back_hand";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_news;
            if (int.TryParse(hdnIdNews.Value, out id_news)) news_selezionata = news_provider.GetById(id_news);
        }

        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    tbNews.Visible = false;
                    if (news_selezionata == null) btnElimina.Enabled = false;
                    chkInvioTelegram.Checked = false;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scriptinterruzione" + DateTime.Now.Millisecond.ToString()
                        , @"$(document).ready(function(){bindEventi();});", true);
                    break;
                default:
                    tbNuovo.Visible = false;
                    SiarLibrary.NewsCollection newscollection = news_provider.Find(null, null, null);
                    dgNews.DataSource = newscollection;
                    dgNews.ItemDataBound += new DataGridItemEventHandler(dgNews_ItemDataBound);
                    if (newscollection.Count == 0) dgNews.Titolo = "Nessuna news/comunicazione inserita.";
                    dgNews.Titolo = "Elementi trovati: " + newscollection.Count.ToString();
                    dgNews.DataBind();
                    break;
            }
            base.OnPreRender(e);
        }

        public void MostraMessaggio(string messaggio, bool errore)
        {
            string fn = "";
            if (errore)
                fn = "mostraPopupMessaggio('" + messaggio + "', 1)";
            else
                fn = "mostraPopupMessaggio('" + messaggio + "', 0)";

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "myJsFn", fn, true);
        }

        void dgNews_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                SiarLibrary.News n = (SiarLibrary.News)e.Item.DataItem;
                e.Item.Cells[1].Text = "<div style='line-height:18px'><b>" + n.Titolo + "</b></div>" + n.Testo
                    + "<div style='width:98%;text-align:right'><b>" + n.Data
                    + "&nbsp;&nbsp; - &nbsp;&nbsp;<a " + (!string.IsNullOrEmpty(n.Url) ? "href='" + n.Url + "' target=_blank" : "") + ">Apri il link</a></b></div>";
                e.Item.Cells[2].Text = "<input type=button class='btn btn-primary py-1' style='width:100px' onclick='modificaNews(" + n.IdNews + ")' value=Modifica />";
            }
        }

        protected async void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (news_selezionata == null)
                    news_selezionata = new SiarLibrary.News();

                string titolo = txtTitolo.Text;
                string testo = txtNewsLunga.Text;
                news_selezionata.Titolo = titolo;
                news_selezionata.Url = txtUrl.Text;
                news_selezionata.Testo = testo;
                news_selezionata.Data = DateTime.Now;
                news_selezionata.InterruzioneSistema = chkInterruzione.Checked;
                if (chkInterruzione.Checked)
                {
                    news_selezionata.DataInizio = txtDataInterruzione.Text + " " + txtOraInizio.Text + ":" + txtMinutiInizio.Text + ":00";
                    if (news_selezionata.DataInizio == null) throw new Exception("Data inizio non valida. Salvataggio fallito.");
                    news_selezionata.DataFine = txtDataInterruzione.Text + " " + txtOraFine.Text + ":" + txtMinutiFine.Text + ":00";
                    if (news_selezionata.DataFine == null) throw new Exception("Data fine non valida. Salvataggio fallito.");
                }
                news_selezionata.Operatore = Operatore.Utente.CfUtente;
                news_provider.Save(news_selezionata);
                hdnIdNews.Value = news_selezionata.IdNews;
                
                if (chkInvioTelegram.Checked)
                {
                    string news = "<b>" + titolo + "</b> \n\n"
                        + "<i>" + testo + "</i>";

                    var esitoTelegram = await new TelegramBotClass().SendMessageAsync(Operatore.Utente.CfUtente, null, news);

                    if (esitoTelegram == "")
                        MostraMessaggio("Salvataggio completato correttamente e notifica Telegram inviata correttamente.", false);
                    else
                        MostraMessaggio("Salvataggio completato correttamente e notifica Telegram NON inviata correttamente: " + esitoTelegram, false);
                }
                else
                    ShowMessage("Salvataggio completato correttamente.");
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (news_selezionata == null) throw new Exception("Nessuna news selezionata.");                
                news_provider.Delete(news_selezionata);
                ShowMessage("News/Comunicazione eliminata correttamente.");
                txtNewsLunga.Text = string.Empty;
                txtUrl.Text = string.Empty;
                txtTitolo.Text = string.Empty;
                hdnIdNews.Value = string.Empty;
                chkInterruzione.Checked = false;
                txtDataInterruzione.Text = "";
                txtOraFine.Text = "";
                txtMinutiFine.Text = "";
                txtOraInizio.Text = "";
                txtMinutiInizio.Text = "";
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            if (news_selezionata != null)
            {
                txtTitolo.Text=news_selezionata.Titolo;
                txtUrl.Text=news_selezionata.Url;
                txtNewsLunga.Text=news_selezionata.Testo;
                if (news_selezionata.DataInizio != null)
                    txtDataInterruzione.Text = news_selezionata.DataInizio.ToStringAgid();
                chkInterruzione.Checked=news_selezionata.InterruzioneSistema;
                if (news_selezionata.InterruzioneSistema)
                {
                    if (news_selezionata.DataInizio != null)
                    {
                        txtOraInizio.Text = news_selezionata.DataInizio.Value.Hour.ToString();
                        txtMinutiInizio.Text = news_selezionata.DataInizio.Value.Minute.ToString();
                    }
                    if (news_selezionata.DataFine != null)
                    {
                        txtOraFine.Text = news_selezionata.DataFine.Value.Hour.ToString();
                        txtMinutiFine.Text = news_selezionata.DataFine.Value.Minute.ToString();
                    }
                }
                ucSiarNewTab.TabSelected = 2;
            }
        }
    }
}