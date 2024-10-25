using System;
using System.Web;
using System.IO;
using SiarBLL;

namespace web.Public.Download
{
    public partial class TestFirmaDigitaleRemota : SiarLibrary.Web.Page
    {
        //protected string dataToSign { get; set; }

        string PATH_PUBLIC_DOWNLOAD = VirtualPathUtility.ToAbsolute("~/Public/Download/");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFirmaRemota_Click(object sender, EventArgs e)
        {
            var file = File.ReadAllBytes(Server.MapPath("~") + "/Public/Download/Documento_test_firma_digitale.pdf");
            var rsclient = new FirmaRemotaManager.FirmaRemotaOperazioni();
            var request = new FirmaRemotaManager.FirmaRemotaRequest();
            try
            {
                
                request.CfFirmatario = txtUsernameRS.Value;
                request.Pin = txtPasswordRS.Value;
                request.Otp = txtOtpRS.Value;
                if (!string.IsNullOrEmpty(txtDominioRS.Value) || !string.IsNullOrWhiteSpace(txtDominioRS.Value))
                {
                    request.Domain = txtDominioRS.Value;
                }

                if (file == null || file.Length == 0) throw new Exception("Il documento da firmare non è presente");
                request.File = file;
                var response = rsclient.ArubaSingleRemoteSign(request);

                if (!string.IsNullOrEmpty(response.ErrorCode))
                {
                    throw new Exception("errore codice: " + response.ErrorCode + ": " + response.ErrorDescription);
                }

                hdnSignedData.Value = Convert.ToBase64String(response.SignedFile);
                divBottoni.Visible=true;
            }
            catch (Exception ex)
            {

                ShowError(ex.Message);
            }
        }

        private void SvuotaCampiHidden()
        {
            hdnFirmaInCorso.Value = null;
            hdnSignedData.Value = null;
        }

        protected void btnSALVA_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] report = Convert.FromBase64String(hdnSignedData.Value);
                Session["doc"] = report;
                RegisterClientScriptBlock("window.open('../../VisualizzaDocumento.aspx');");

                ShowMessage("File firmato correttamente.");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            finally
            {
                SvuotaCampiHidden();
            }
        }

        protected void btnScaricaDocumentoFirmaEsterna_Click(object sender, EventArgs e)
        {
            try
            {
                var firmaEsternaAruba = new FirmaRemotaManager.FirmaEsternaAruba();
                var file = File.ReadAllBytes(Server.MapPath("~") + "/Public/Download/Documento_test_firma_digitale.pdf");
                var file_restituito = firmaEsternaAruba.FirmaAutomaticaTest(file);

                Session["doc"] = file_restituito;
                RegisterClientScriptBlock("window.open('../../VisualizzaDocumento.aspx');");

                ShowMessage("File preparato correttamente.");
            } catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnFirmaEsternaVerifica_Click(object sender, EventArgs e)
        {
            try
            {
                if (ufDocumento.IdFile == null)
                    throw new Exception("Caricare prima il file");

                var firmaEsternaAruba = new FirmaRemotaManager.FirmaEsternaAruba();
                var file = new ArchivioFileCollectionProvider().GetById(ufDocumento.IdFile);
                string esito;
                var estensione_file = Path.GetExtension(file.NomeFile);
                if (estensione_file == ".pdf")
                    esito = firmaEsternaAruba.VerificaFileFirmatoUtentePostFirmaAutomaticaTest(file.Contenuto, file.NomeFile);
                else
                    throw new Exception("Estensione file " + estensione_file + " non accettata, si accettano solo file .pdf");

                if (esito == "OK")
                    ShowMessage("File firmato correttamente");
                else 
                    ShowError(esito);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
    }
}