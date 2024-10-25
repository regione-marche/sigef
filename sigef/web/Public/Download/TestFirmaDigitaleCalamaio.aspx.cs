using SiarLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Public.Download
{
    public partial class TestFirmaDigitaleCalamaio : SiarLibrary.Web.Page
    {

        protected string dataToSign { get; set; }

        string PATH_PUBLIC_DOWNLOAD = VirtualPathUtility.ToAbsolute("~/Public/Download/");

        protected void Page_Load(object sender, EventArgs e)
        {
            ControllaFirmaInCorso();
        }

        private void ControllaFirmaInCorso()
        {
            if (hdnFirmaInCorso.Value == null || hdnFirmaInCorso.Value == "")
            { 
                var file = File.ReadAllBytes(Server.MapPath("~") + "/Public/Download/Documento_test_firma_digitale.pdf");
                dataToSign = CalamaioUtility.GetDataToSign(file, null, "Documento_test_firma_digitale");
                byte[] byt = System.Text.Encoding.UTF8.GetBytes(dataToSign);
                hdnDataToSign.Value = Convert.ToBase64String(byt);
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
                string xmlstring = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(hdnSignedData.Value));
                var signedFile = CalamaioUtility.ExtractSignedDataCalamaio1(xmlstring);

                foreach (SignInfo data in signedFile)
                {
                    //File.WriteAllBytes(@"C:\test\" + data.DocumentIdentifier + "_firmato.pdf", Convert.FromBase64String(data.SignedData)); //salvataggio file per test

                    //Visualizzo il report in un altra pagina
                    byte[] report = Convert.FromBase64String(data.SignedData);
                    Session["doc"] = report;
                    RegisterClientScriptBlock("window.open('../../VisualizzaDocumento.aspx');");
                }

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
    }
}