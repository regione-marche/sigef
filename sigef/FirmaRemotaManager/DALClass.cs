using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FirmaRemotaManager
{
    internal partial class DALClass
    {
        private string connectionString;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        internal DALClass()
        {
            /*
            ConnectionStringSettings css = ConfigurationManager.ConnectionStrings["DB_SIGEF"];
            if (css == null || string.IsNullOrEmpty(css.ConnectionString))
                throw new ConfigurationErrorsException(string.Format("ConnectionString 'DB' mancante nel file di configurazione."));

            connectionString = css.ConnectionString;
            */

            try
            {
                ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings["DB_SIGEF"];
#if(DEBUG)
                connectionString = cs.ConnectionString;
#else
                try { connectionString = System.Text.Encoding.UTF8.GetString(DecryptString("df_5OFI*xcI,", Convert.FromBase64String(cs.ConnectionString))); }
                catch { connectionString = cs.ConnectionString; }
#endif
                //int ctimeout;
                //if (int.TryParse(ConfigurationSettings.AppSettings["DB_SIGEF" + ".CommandTimeout"], out ctimeout))
                //    _commandTimeout = ctimeout;
            }
            catch (Exception ex) { throw ex; }
        }

        public static byte[] DecryptString(string PASSWORD, byte[] encryptedBytes)
        {
            try
            {
                System.Security.Cryptography.TripleDESCryptoServiceProvider des = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
                des.IV = new byte[8];
                System.Security.Cryptography.PasswordDeriveBytes pdb = new System.Security.Cryptography.PasswordDeriveBytes(PASSWORD, new byte[0]);
                des.Key = pdb.CryptDeriveKey("RC2", "MD5", 128, new byte[8]);
                //string prova=Encoding.ASCII.GetString(des.Key);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(encryptedBytes.Length);
                System.Security.Cryptography.CryptoStream decStream = new System.Security.Cryptography.CryptoStream(ms, des.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
                decStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                decStream.FlushFinalBlock();
                byte[] plainBytes = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(plainBytes, 0, (int)ms.Length);
                decStream.Close();
                return plainBytes;
            }
            catch { throw new Exception("Password errata."); }
        }

        internal void InsertLog(LogInfo logInfo)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zInsertLogFirma",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@TipoDocumento", logInfo.TipoDocumento);
                sqlCmd.Parameters.AddWithValue2("@ParametriDocumento", logInfo.ParametriDocumento);
                sqlCmd.Parameters.AddWithValue2("@Operatore", logInfo.Operatore);
                sqlCmd.Parameters.AddWithValue2("@TipoFirma", logInfo.TipoFirma);
                sqlCmd.Parameters.AddWithValue2("@DominioFirma", logInfo.DominioFirma);
                sqlCmd.Parameters.AddWithValue2("@Esito", logInfo.Esito);
                sqlCmd.Parameters.AddWithValue2("@DettaglioEsito", logInfo.DettaglioEsito);
                sqlCmd.Parameters.AddWithValue2("@DataFirma", logInfo.DataFirma);
                sqlCmd.Parameters.AddWithValue2("@DownloadDocumentoCertificato", logInfo.DownloadDocumentoCertificato);

                logInfo.IdLogFirma = (int)SqlHelper.ExecuteScalarCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal int CountLogDocumentoScaricatoOk(string tipoDocumento, string parametriDocumento)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "spCountLogDocumentoScaricatoOk",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@TipoDocumento", tipoDocumento);
                sqlCmd.Parameters.AddWithValue2("@ParametriDocumento", parametriDocumento);

                var scaricamenti = (int)SqlHelper.ExecuteScalarCmd(connectionString, sqlCmd);
                return scaricamenti;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }
    }
}
