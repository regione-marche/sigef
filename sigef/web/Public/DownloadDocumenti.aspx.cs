using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Net;

namespace web.Public
{
    public partial class DownloadDocumenti : SiarLibrary.Web.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "public_documenti";
            base.OnPreInit(e);
        }

        SiarBLL.FileDocumentoCollectionProvider file_provider = new SiarBLL.FileDocumentoCollectionProvider();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnPreRender(EventArgs e)
        {
            SiarLibrary.DocumentiCollection docs = new SiarBLL.DocumentiCollectionProvider().GetDocumentiPubblici(txtCercaDescrizione.Text);
            dgDocumenti.DataSource = docs;
            dgDocumenti.ItemDataBound += new DataGridItemEventHandler(dgDocumenti_ItemDataBound);
            dgDocumenti.DataBind();
            base.OnPreRender(e);
        }

        void dgDocumenti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.Documenti d = (SiarLibrary.Documenti)e.Item.DataItem;
                SiarLibrary.FileDocumentoCollection files = file_provider.Find(d.IdDocumento);

                HtmlTable tb = new HtmlTable();
                tb.Style.Add("width", "100%");
                tb.Style.Add("margin", "5px");
                HtmlTableRow tr1 = new HtmlTableRow();
                HtmlTableCell td1 = new HtmlTableCell();
                td1.Style.Add("font-weight", "bold");
                td1.Style.Add("font-size", "12px");
                td1.Style.Add("width", "100%");
                td1.Style.Add("border", "0");
                td1.InnerText = d.Titolo;
                tr1.Cells.Add(td1);

                HtmlTableRow tr2 = new HtmlTableRow();
                HtmlTableCell td2 = new HtmlTableCell();
                td2.Style.Add("width", "100%");
                td2.Style.Add("border", "0");
                td2.Style.Add("padding-top", "5px");
                td2.Style.Add("padding-bottom", "10px");
                td2.InnerText = d.Descrizione;
                tr2.Cells.Add(td2);

                HtmlTableRow tr3 = new HtmlTableRow();
                HtmlTableCell td3 = new HtmlTableCell();
                td3.Style.Add("width", "100%");
                td3.Style.Add("border", "0");
                if (files.Count == 0) td3.InnerText = " - Nessun file allegato.";
                else
                {
                    // tabella nodificata per i file
                    HtmlTable tbf = new HtmlTable();
                    tbf.Style.Add("width", "100%");
                    for (int i = 0; i < files.Count; i = i + 2)
                    {
                        HtmlTableRow trf = new HtmlTableRow();
                        HtmlTableCell tdf = new HtmlTableCell();
                        tdf.Style.Add("width", "50%");
                        tdf.Style.Add("border", "0");
                        tdf.InnerHtml = manuale(files[i]);
                        trf.Cells.Add(tdf);

                        HtmlTableCell tdf2 = new HtmlTableCell();
                        tdf2.Style.Add("width", "50%");
                        tdf2.Style.Add("border", "0");
                        if (i + 1 < files.Count) tdf2.InnerHtml = manuale(files[i + 1]);
                        trf.Cells.Add(tdf2);

                        //tr.Height = "45px";
                        //table1.Rows.Add(tr);
                        tbf.Rows.Add(trf);
                    }
                    td3.Controls.Add(tbf);
                }
                tr3.Cells.Add(td3);
                tb.Rows.Add(tr1);
                tb.Rows.Add(tr2);
                tb.Rows.Add(tr3);
                e.Item.Cells[1].Controls.Add(tb);
            }
        }

        private string manuale(SiarLibrary.FileDocumento f)
        {
            string fsize_str = "";
            decimal fsize = f.SizeFile;
            if (fsize > 1048576) fsize_str = Math.Round(fsize / 1048576, 1).ToString() + " Mb";
            else if (fsize > 1024) fsize_str = Math.Round(fsize / 1024, 0).ToString() + " Kb";
            else fsize_str = fsize.ToString() + " bytes";
            string img = "explorer";
            switch (f.Tipo)
            {
                case "pdf":
                    img = "acrobat";
                    break;
                case "doc":
                case "docx":
                case "rtf":
                    img = "word";
                    break;
                case "ppt":
                    img = "powerpoint";
                    break;
                case "xls":
                case "xlsx":
                    img = "excel";
                    break;
            }
            return "&nbsp;  - <em> " + f.Descrizione + " : <br/>&nbsp;&nbsp;<a href='javascript:visualizzaFile(" + f.IdFile + ");'><img src='../images/"
                + img + ".gif' /></a>&nbsp;&nbsp;&nbsp;( documento " + f.Tipo + " - " + fsize_str + " )";
        }

        protected void btnCerca_Click(object sender, EventArgs e)
        {

        }

        protected void btnVisualizzaFile_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.FileDocumento file_selezionato = null;
                int id_file;
                if (int.TryParse(hdnIdFile.Value, out id_file))
                    file_selezionato = file_provider.GetById(id_file);
                if (file_selezionato == null) throw new Exception("Il file selezionato non è valido.");
                string url_location = "";
                if (file_selezionato.IdArchivioFile == null) // file vecchi
                {
                    // piglio il file da download dir
                    url_location = System.Configuration.ConfigurationManager.AppSettings["DownloadDir"] + file_selezionato.Nome;
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url_location);
                    req.AllowAutoRedirect = false;
                    try
                    {
                        HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                        if (res.StatusCode == HttpStatusCode.OK) url_location = "'" + url_location + "'";
                        else throw new Exception("");
                    }
                    catch { throw new Exception("Il file cercato non esiste."); }
                }
                else
                {
                    // i file nuovi vengono salvati su db
                    SiarLibrary.ArchivioFile af = new SiarBLL.ArchivioFileCollectionProvider().GetById(file_selezionato.IdArchivioFile);
                    if (af == null) throw new Exception("Il file selezionato non è valido.");
                    SiarLibrary.ArchivioFileCollection docs = new SiarLibrary.ArchivioFileCollection();
                    docs.Add(af);
                    Session["siar_view_file"] = docs;
                    url_location = "getBaseUrl()+'VisualizzaDocumento.aspx'";
                }                
                RegisterClientScriptBlock("window.open(" + url_location + ");");
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}
