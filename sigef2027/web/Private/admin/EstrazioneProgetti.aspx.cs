using System;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Collections;
namespace web.Private.admin
{
    public partial class EstrazioneProgetti : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "estrazione_progetti";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnScarica_Click(object sender, EventArgs e)
        {
            ArrayList appo = new ArrayList();
            appo.Add(2568);

            foreach (int x in appo)
            {
                try
                {
                    // Specify a "currently active folder"
                    string activeDir = @"c:\vsprojects";

                    //Create a new subfolder under the current active folder
                    string newPath = Path.Combine(activeDir, "import");

                    bool exists = Directory.Exists(newPath);

                    if (!exists)
                    {
                        // Create the subfolder
                        Directory.CreateDirectory(newPath);
                    }

                    string strQuery = @"select p.IdProgettoDocumentoSpesaBeneficiario, p.NomeDocumentoOriginale, p.ScansioneDocumentoOriginale 
                                    from [dbo].[ProgettiDocumentiSpeseBeneficiari] p 
                                    where 
                                    p.TDataFine is null and 
                                    p.TCancellato = 0 and 
                                    p.IdProgettoPacchettoRendicontazione is not null and 
                                    p.IdProgettoDocumentoSpesaBeneficiario  = p.IsProgettoDocumentoSpesaBeneficiario and
                                    p.IdProgetto = " + x.ToString();
                    SqlCommand cmd = new SqlCommand(strQuery);
                    DataTable dt = GetData(cmd);
                    if (dt != null)
                    {
                        //Create a new subfolder under the current active folder
                        string pathProgetto = Path.Combine(newPath, x.ToString());

                        bool existsProgetto = Directory.Exists(pathProgetto);

                        if (!existsProgetto)
                        {
                            // Create the subfolder
                            Directory.CreateDirectory(pathProgetto);
                        }

                        string pathFatture = Path.Combine(pathProgetto, "Fatture");

                        bool existsFattura = Directory.Exists(pathFatture);

                        if (!existsFattura)
                        {
                            // Create the subfolder
                            Directory.CreateDirectory(pathFatture);
                        }

                        string pathGiustificativo = Path.Combine(pathProgetto, "Giustificativi");

                        bool existsGiustificativo = Directory.Exists(pathGiustificativo);

                        if (!existsGiustificativo)
                        {
                            // Create the subfolder
                            Directory.CreateDirectory(pathGiustificativo);
                        }

                        foreach (DataRow row in dt.Rows)
                        {
                            string strQuery2 = @"select p.IdProgettoDocumentoSpesaBeneficiarioPagamento, p.NomeDocumento, p.ScansioneDocumento 
                                            from [dbo].[ProgettiDocumentiSpeseBeneficiariPagamenti] p 
                                            where 
                                            p.TDataFine is null and 
                                            p.TCancellato = 0 and 
                                            p.IdProgettoPacchettoRendicontazione is not null and 
                                            p.IdProgettoDocumentoSpesaBeneficiarioPagamento  = p.IsProgettoDocumentoSpesaBeneficiarioPagamento and
                                            p.IdProgettoDocumentoSpesaBeneficiario = " + row["IdProgettoDocumentoSpesaBeneficiario"];
                            SqlCommand cmd2 = new SqlCommand(strQuery2);
                            DataTable dt2 = GetData(cmd2);
                            if (dt2 != null)
                            {
                                foreach (DataRow row2 in dt2.Rows)
                                {
                                    download2(row2, pathGiustificativo);
                                }
                            }
                            download(row, pathFatture);
                        }
                    }

                }
                catch (Exception ex) { ShowError(ex); }
            }
        }

        private DataTable GetData(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            String strConnString = System.Configuration.ConfigurationManager
            .ConnectionStrings["DB_SIGFRIDO"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            try
            {
                con.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
                sda.Dispose();
                con.Dispose();
            }
        }

        private void download(DataRow dr, string path)
        {
            Byte[] bytes = (Byte[])dr["ScansioneDocumentoOriginale"];
            File.WriteAllBytes(path + "//" + dr["IdProgettoDocumentoSpesaBeneficiario"] + "_" + dr["NomeDocumentoOriginale"].ToString(), bytes);
        }

        private void download2(DataRow dr, string path)
        {
            Byte[] bytes = (Byte[])dr["ScansioneDocumento"];
            File.WriteAllBytes(path + "//" + dr["IdProgettoDocumentoSpesaBeneficiarioPagamento"] + "_" + dr["NomeDocumento"].ToString(), bytes);
        }
    }
}
