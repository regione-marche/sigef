using System;
using System.Net;
using System.Web.UI.WebControls;

namespace web.Private.admin
{
    public partial class DocumentiBackhand : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "documenti_back_hand";
            base.OnPreInit(e);
        }

        SiarBLL.DocumentiCollectionProvider doc_provider = new SiarBLL.DocumentiCollectionProvider();
        SiarBLL.FileDocumentoCollectionProvider file_provider;
        SiarLibrary.Documenti documento_selezionato;

        protected void Page_Load(object sender, EventArgs e)
        {
            file_provider = new SiarBLL.FileDocumentoCollectionProvider(doc_provider.DbProviderObj);
        }

        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    tbElenco.Visible = false;
                    txtTitolo.MaxLength = 255;
                    txtDescrizioneLunga.MaxLength = 1000;
                    int id_documento;
                    if (int.TryParse(hdnIdDocumento.Value, out id_documento))
                        documento_selezionato = doc_provider.GetById(id_documento);

                    if (documento_selezionato == null)
                    {
                        txtTitolo.Text = txtDescrizioneLunga.Text = txtDescFile.Text = null;
                        txtDataFineValidita.Text = new SiarLibrary.NullTypes.DatetimeNT(DateTime.Now.AddYears(1));
                    }
                    else
                    {
                        txtDataFineValidita.Text = documento_selezionato.DataFineValidita;
                        txtTitolo.Text = documento_selezionato.Titolo;
                        txtDescrizioneLunga.Text = documento_selezionato.Descrizione;

                        SiarLibrary.FileDocumentoCollection files = file_provider.Find(documento_selezionato.IdDocumento);
                        if (files.Count == 0) dgFiles.Titolo = "Nessun elemento trovato.";
                        dgFiles.DataSource = files;
                        dgFiles.DataBind();
                    }
                    break;
                default:
                    tbDettaglio.Visible = false;
                    SiarLibrary.DocumentiCollection docs = doc_provider.Find(null, null, null);
                    dgDocumenti.DataSource = docs;
                    dgDocumenti.Titolo = "Elementi trovati: " + docs.Count.ToString();
                    dgDocumenti.ItemDataBound += new DataGridItemEventHandler(dgDocumenti_ItemDataBound);
                    dgDocumenti.DataBind();
                    break;
            }
            ucSNCUploadFileControl.AbilitaModifica = btnElimina.Enabled = AbilitaModifica && documento_selezionato != null;
            txtDescFile.ReadOnly = !btnElimina.Enabled;
            base.OnPreRender(e);
        }

        void dgDocumenti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.Documenti d = (SiarLibrary.Documenti)e.Item.DataItem;
                e.Item.Cells[1].Text = "<table width='100%'><tr><td style='font-weight:bold;border-right:0'>" + d.Titolo + "</td></tr><tr><td style='border:0;padding-top:5px'>" + d.Descrizione + "</td></tr></table>";
            }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                doc_provider.DbProviderObj.BeginTran();
                int id_documento;
                if (int.TryParse(hdnIdDocumento.Value, out id_documento))
                    documento_selezionato = doc_provider.GetById(id_documento);
                if (documento_selezionato == null) documento_selezionato = new SiarLibrary.Documenti();
                documento_selezionato.Titolo = txtTitolo.Text;
                documento_selezionato.Descrizione = txtDescrizioneLunga.Text;
                documento_selezionato.Operatore = Operatore.Utente.CfUtente;
                documento_selezionato.DataFineValidita = txtDataFineValidita.Text;
                documento_selezionato.DataModifica = DateTime.Now;
                doc_provider.Save(documento_selezionato);
                if (ucSNCUploadFileControl.IdFile != null)
                {
                    if (string.IsNullOrEmpty(txtDescFile.Text))
                        throw new Exception("E' obbligatorio digitare una breve descrizione del file che si sta allegando.");
                    SiarLibrary.ArchivioFile af = new SiarBLL.ArchivioFileCollectionProvider(doc_provider.DbProviderObj).GetById(ucSNCUploadFileControl.IdFile);
                    if (af == null) throw new Exception("Il file selezionato non è valido.");
                    SiarLibrary.FileDocumento f = new SiarLibrary.FileDocumento();
                    f.IdDocumento = documento_selezionato.IdDocumento;
                    f.Descrizione = txtDescFile.Text;
                    f.SizeFile = af.Dimensione;
                    f.Tipo = System.IO.Path.GetExtension(af.NomeFile).ToLower().Replace(".", "");
                    f.IdArchivioFile = ucSNCUploadFileControl.IdFile;
                    file_provider.Save(f);
                }
                doc_provider.DbProviderObj.Commit();
                hdnIdDocumento.Value = documento_selezionato.IdDocumento;
                ShowMessage("Documento salvato correttamente.");
            }
            catch (Exception ex) { doc_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                int id_documento;
                if (int.TryParse(hdnIdDocumento.Value, out id_documento))
                    documento_selezionato = doc_provider.GetById(id_documento);
                if (documento_selezionato == null || documento_selezionato.IdDocumento == null) throw new Exception("Il documento selezionato non è valido.");
                doc_provider.DbProviderObj.BeginTran();
                file_provider.DeleteCollection(file_provider.Find(documento_selezionato.IdDocumento));
                doc_provider.Delete(documento_selezionato);
                doc_provider.DbProviderObj.Commit();
                pulisciClassi();
                ShowMessage("Documento eliminato correttamente.");
            }
            catch (Exception ex) { doc_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnNuovo_Click(object sender, EventArgs e)
        {
            pulisciClassi();
        }

        private void pulisciClassi()
        {
            hdnIdDocumento.Value = null;
            hdnIdFile.Value = null;
            documento_selezionato = null;
        }

        protected void btnEliminaFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                SiarLibrary.FileDocumento file_selezionato = null;
                int id_file, id_documento;
                if (int.TryParse(hdnIdDocumento.Value, out id_documento))
                    documento_selezionato = doc_provider.GetById(id_documento);
                if (documento_selezionato == null) throw new Exception("Il documento selezionato non è valido.");
                if (int.TryParse(hdnIdFile.Value, out id_file))
                    file_selezionato = file_provider.GetById(id_file);
                if (file_selezionato == null) throw new Exception("Il file selezionato non è valido.");
                file_provider.Delete(file_selezionato);
                ShowMessage("Il file allegato è stato eliminato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
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

        #region old code
        //private void fileUpload()      
        //{
        //    if (upFile.PostedFile != null && upFile.PostedFile.ContentLength > 0)
        //    {
        //        file_provider.DbProviderObj.BeginTran();
        //        try
        //        {
        //            string nomefile = System.IO.Path.GetFileName(upFile.PostedFile.FileName).Replace(" ","_");
        //            string SaveLocation = Server.MapPath("~/..") + "\\Public\\Download\\" + nomefile;
        //            if (System.IO.File.Exists(SaveLocation)) throw new Exception("Il file è già stato caricato.");
        //            upFile.PostedFile.SaveAs(SaveLocation);
        //            SiarLibrary.FileDocumento file = new SiarLibrary.FileDocumento();
        //            file.IdDocumento = hdnIdDocumento.Text;
        //            file.Descrizione = txtDescFile.Text;
        //            file.Nome = nomefile;
        //            file.SizeFile = upFile.PostedFile.ContentLength;
        //            file.Tipo = System.IO.Path.GetExtension(upFile.PostedFile.FileName).ToLower().Replace(".","");// upFile.PostedFile.ContentType;
        //            file_provider.Save(file);
        //            file_provider.DbProviderObj.Commit();
        //        }
        //        catch (Exception ex) { file_provider.DbProviderObj.Rollback(); ShowError(ex); }
        //    }        
        //}

        //private void eliminaFile(SiarLibrary.FileDocumento file)
        //{
        //    file_provider.DbProviderObj.BeginTran();
        //    try
        //    {
        //        string SaveLocation = Server.MapPath("~/..") + "\\Public\\Download\\" + file.Nome;
        //        if (System.IO.File.Exists(SaveLocation)) System.IO.File.Delete(SaveLocation);
        //        file_provider.Delete(file);
        //        file_provider.DbProviderObj.Commit();
        //    }
        //    catch (Exception ex) { file_provider.DbProviderObj.Rollback(); ShowError(ex); }        
        //}
        #endregion
    }
}