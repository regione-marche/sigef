using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace PucManager
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

        internal int InsertDatiMonitoraggio(DateTime? DataDa, DateTime? DataA, string NomeFile, int IdInvio, int? rNumber, string codiceFondo)
        {
            string spFondo = "";
            switch(codiceFondo)
            {
                case "ITIAILS20142020": //Fondo ITI
                    spFondo = "zIgrueInsertLSMonit";
                    break;
                case "FESR20142020": //Fondo FESR
                    spFondo = "zIgrueInsertMonit"; 
                    break;
                case "PSCMARCHE": //Fondo PSC
                    spFondo = "zIgrueInsertPSCMonit";
                    break;
                case "POCMARCHE": //Fondo POC
                    spFondo = "zIgrueInsertPOCMonit";
                    break;
            }

            var sqlCmd = new SqlCommand
            {
                CommandText = spFondo + NomeFile,
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.AddWithValue2("@DataDa", DataDa);
            sqlCmd.Parameters.AddWithValue2("@DataA", DataA);
            sqlCmd.Parameters.AddWithValue2("@IdInvio", IdInvio);
            sqlCmd.Parameters.AddWithValue2("@rNumber", rNumber);

            try
            {
                //SqlHelper.ExecuteNonQueryCmd(connectionString, sqlCmd);
                int res = (int)SqlHelper.ExecuteScalarCmd(connectionString, sqlCmd);
                return res;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal int InsertDatiMonitoraggio(DateTime? DataDa, DateTime? DataA, string NomeFile, int IdInvio, int? rNumber, string IdProgetti, string codiceFondo)
        {
            string spFondo = "";
            switch (codiceFondo)
            {
                case "ITIAILS20142020": //Fondo ITI
                    spFondo = "zIgrueInsertLSMonitS";
                    break;
                case "FESR20142020": //Fondo FESR
                    spFondo = "zIgrueInsertMonitS";
                    break;
                case "PSCMARCHE": //Fondo PSC
                    spFondo = "zIgrueInsertPSCMonitS";
                    break;
                case "POCMARCHE": //Fondo POC
                    spFondo = "zIgrueInsertPOCMonitS";
                    break;
            }

            var sqlCmd = new SqlCommand
            {
                CommandText = spFondo + NomeFile,
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.AddWithValue2("@DataDa", DataDa);
            sqlCmd.Parameters.AddWithValue2("@DataA", DataA);
            sqlCmd.Parameters.AddWithValue2("@IdInvio", IdInvio);
            sqlCmd.Parameters.AddWithValue2("@rNumber", rNumber);
            sqlCmd.Parameters.AddWithValue2("@IdProgetti", string.IsNullOrEmpty(IdProgetti) ? null : IdProgetti);

            try
            {
                //SqlHelper.ExecuteNonQueryCmd(connectionString, sqlCmd);
                int res = (int)SqlHelper.ExecuteScalarCmd(connectionString, sqlCmd);
                return res;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal void InsertInvioMonitoraggio(IgrueInvio Invio)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zIgrueInsertInvio",
                CommandType = CommandType.StoredProcedure
            };
            
            try
            {
                sqlCmd.Parameters.AddWithValue2("@IdTicket", Invio.ID_TICKET);
                sqlCmd.Parameters.AddWithValue2("@DataInvio", DateTime.Now);
                sqlCmd.Parameters.AddWithValue2("@DataDa", Invio.DATA_DA);
                sqlCmd.Parameters.AddWithValue2("@DataA", Invio.DATA_A);
                sqlCmd.Parameters.AddWithValue2("@FileInvio", Invio.FILE_INVIO);
                sqlCmd.Parameters["@FileInvio"].SqlDbType = SqlDbType.VarBinary;
                sqlCmd.Parameters.AddWithValue2("@IdOperatore", Invio.ID_OPERATORE);
                sqlCmd.Parameters.AddWithValue2("@TipoFile", Invio.TIPO_FILE);
                sqlCmd.Parameters.AddWithValue2("@CodiceFondo", Invio.CODICE_FONDO);

                Invio.ID_INVIO = (int)SqlHelper.ExecuteScalarCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal void UpdateInvioMonitoraggio(IgrueInvio Invio)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zIgrueUpdateInvio",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@IdInvio", Invio.ID_INVIO);
                sqlCmd.Parameters.AddWithValue2("@IdTicket", Invio.ID_TICKET);
                sqlCmd.Parameters.AddWithValue2("@DataInvio", Invio.DATA_INVIO);
                sqlCmd.Parameters.AddWithValue2("@DataDa", Invio.DATA_DA);
                sqlCmd.Parameters.AddWithValue2("@DataA", Invio.DATA_A);
                sqlCmd.Parameters.AddWithValue2("@FileInvio", Invio.FILE_INVIO);
                sqlCmd.Parameters["@FileInvio"].SqlDbType = SqlDbType.VarBinary;
                sqlCmd.Parameters.AddWithValue2("@IdOperatore", Invio.ID_OPERATORE);
                sqlCmd.Parameters.AddWithValue2("@CodiceEsito", Invio.CODICE_ESITO);
                sqlCmd.Parameters.AddWithValue2("@DescrizioneEsito", Invio.DESCRIZIONE_ESITO);
                sqlCmd.Parameters.AddWithValue2("@DettaglioEsito", Invio.DETTAGLIO_ESITO);
                sqlCmd.Parameters.AddWithValue2("@TimeStampEsito", Invio.TIMESTAMP_ESITO);
                sqlCmd.Parameters.AddWithValue2("@TipoFile", Invio.TIPO_FILE);
                sqlCmd.Parameters.AddWithValue2("@CodiceFondo", Invio.CODICE_FONDO);

                SqlHelper.ExecuteNonQueryCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal void InsertLogErrori(IgrueLogErrori LogErrori)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zIgrueInsertLogErrori",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@IdInvio", LogErrori.ID_INVIO);
                sqlCmd.Parameters.AddWithValue2("@IdTicket", LogErrori.ID_TICKET);
                sqlCmd.Parameters.AddWithValue2("@DataRichiesta", LogErrori.DATA_RICHIESTA);
                sqlCmd.Parameters.AddWithValue2("@FileErrori", LogErrori.FILE_ERRORI);
                sqlCmd.Parameters["@FileErrori"].SqlDbType = SqlDbType.VarBinary;
                sqlCmd.Parameters.AddWithValue2("@IstanzaErrori", LogErrori.ISTANZA_ERRORI);
                sqlCmd.Parameters.AddWithValue2("@IdOperatore", LogErrori.ID_OPERATORE);
                sqlCmd.Parameters.AddWithValue2("@CodiceEsito", LogErrori.CODICE_ESITO);
                sqlCmd.Parameters.AddWithValue2("@DescrizioneEsito", LogErrori.DESCRIZIONE_ESITO);
                sqlCmd.Parameters.AddWithValue2("@DettaglioEsito", LogErrori.DETTAGLIO_ESITO);
                sqlCmd.Parameters.AddWithValue2("@TimeStampEsito", LogErrori.TIMESTAMP_ESITO);
                sqlCmd.Parameters.AddWithValue2("@TipoFile", LogErrori.TIPO_FILE);
                sqlCmd.Parameters.AddWithValue2("@CodiceFondo", LogErrori.CODICE_FONDO);

                LogErrori.ID_IGRUE_LOG_ERRORI = (int)SqlHelper.ExecuteScalarCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal void UpdateLogErrori(IgrueLogErrori LogErrori)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zIgrueUpdateLogErrori",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@IdIgrueLogErrori", LogErrori.ID_IGRUE_LOG_ERRORI);
                sqlCmd.Parameters.AddWithValue2("@IdInvio", LogErrori.ID_INVIO);
                sqlCmd.Parameters.AddWithValue2("@IdTicket", LogErrori.ID_TICKET);
                sqlCmd.Parameters.AddWithValue2("@DataRichiesta", LogErrori.DATA_RICHIESTA);
                sqlCmd.Parameters.AddWithValue2("@FileErrori", LogErrori.FILE_ERRORI);
                sqlCmd.Parameters["@FileErrori"].SqlDbType = SqlDbType.VarBinary;
                sqlCmd.Parameters.AddWithValue2("@IstanzaErrori", LogErrori.ISTANZA_ERRORI);
                sqlCmd.Parameters.AddWithValue2("@IdOperatore", LogErrori.ID_OPERATORE);
                sqlCmd.Parameters.AddWithValue2("@CodiceEsito", LogErrori.CODICE_ESITO);
                sqlCmd.Parameters.AddWithValue2("@DescrizioneEsito", LogErrori.DESCRIZIONE_ESITO);
                sqlCmd.Parameters.AddWithValue2("@DettaglioEsito", LogErrori.DETTAGLIO_ESITO);
                sqlCmd.Parameters.AddWithValue2("@TimeStampEsito", LogErrori.TIMESTAMP_ESITO);
                sqlCmd.Parameters.AddWithValue2("@TipoFile", LogErrori.TIPO_FILE);
                sqlCmd.Parameters.AddWithValue2("@CodiceFondo", LogErrori.CODICE_FONDO);

                SqlHelper.ExecuteNonQueryCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal IgrueInvio GetInvioMonitoraggioById(int IdInvio)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zIgrueGetInvioMonitoraggioById",
                CommandType = CommandType.StoredProcedure
            };
            sqlCmd.Parameters.AddWithValue2("@IdInvio", IdInvio);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new IgrueInvio()
                                                          {
                                                              ID_INVIO = int.Parse(reader["ID_INVIO"].ToString()),
                                                              ID_TICKET = Convert.ToString(reader["ID_TICKET"]),
                                                              DATA_DA = Convert.IsDBNull(reader["DATA_DA"]) ? (DateTime?)null : Convert.ToDateTime(reader["DATA_DA"]),//Convert.ToDateTime(reader["DATA_DA"]),
                                                              DATA_A = Convert.IsDBNull(reader["DATA_A"]) ? (DateTime?)null : Convert.ToDateTime(reader["DATA_A"]),//Convert.ToDateTime(reader["DATA_A"]),
                                                              //DATA_DA = Convert.ToDateTime(reader["DATA_DA"]),
                                                              //DATA_A = Convert.ToDateTime(reader["DATA_A"]),
                                                              FILE_INVIO = (byte[])reader["FILE_INVIO"],
                                                              ID_OPERATORE = Convert.IsDBNull(reader["ID_OPERATORE"]) ? (int?)null : (int)reader["ID_OPERATORE"],
                                                              CODICE_ESITO = Convert.IsDBNull(reader["CODICE_ESITO"]) ? (int?)null : (int)reader["CODICE_ESITO"],
                                                              DESCRIZIONE_ESITO = Convert.ToString(reader["DESCRIZIONE_ESITO"]),
                                                              DETTAGLIO_ESITO = Convert.ToString(reader["DETTAGLIO_ESITO"]),
                                                              TIMESTAMP_ESITO = Convert.ToDateTime(reader["TIMESTAMP_ESITO"]),
                                                              TIPO_FILE = Convert.ToString(reader["TIPO_FILE"]),
                                                              CODICE_FONDO = Convert.ToString(reader["CODICE_FONDO"])
                                                          };
                                                          return o;
                                                      });
                if (list.Any())
                {
                    return list[0];
                }

                return null;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
            
        }

        internal IgrueInvio GetInvioMonitoraggioByIdTicket(string IdTicket)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zIgrueGetInvioMonitoraggioByIdTicket",
                CommandType = CommandType.StoredProcedure
            };
            sqlCmd.Parameters.AddWithValue2("@IdTicket", IdTicket);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new IgrueInvio()
                                                          {
                                                              ID_INVIO = int.Parse(reader["ID_INVIO"].ToString()),
                                                              ID_TICKET = Convert.ToString(reader["ID_TICKET"]),
                                                              DATA_DA = Convert.IsDBNull(reader["DATA_DA"]) ? (DateTime?)null :  Convert.ToDateTime(reader["DATA_DA"]),//Convert.ToDateTime(reader["DATA_DA"]),
                                                              DATA_A = Convert.IsDBNull(reader["DATA_A"]) ? (DateTime?)null : Convert.ToDateTime(reader["DATA_A"]),//Convert.ToDateTime(reader["DATA_A"]),
                                                              FILE_INVIO = (byte[])reader["FILE_INVIO"],
                                                              ID_OPERATORE = Convert.IsDBNull(reader["ID_OPERATORE"]) ? (int?)null : (int)reader["ID_OPERATORE"],
                                                              CODICE_ESITO = Convert.IsDBNull(reader["CODICE_ESITO"]) ? (int?)null : (int)reader["CODICE_ESITO"],
                                                              DESCRIZIONE_ESITO = Convert.ToString(reader["DESCRIZIONE_ESITO"]),
                                                              DETTAGLIO_ESITO = Convert.ToString(reader["DETTAGLIO_ESITO"]),
                                                              TIMESTAMP_ESITO = Convert.ToDateTime(reader["TIMESTAMP_ESITO"]),
                                                              TIPO_FILE = Convert.ToString(reader["TIPO_FILE"]),
                                                              CODICE_FONDO = Convert.ToString(reader["CODICE_FONDO"])
                                                          };
                                                          return o;
                                                      });
                if (list.Any())
                {
                    return list[0];
                }

                return null;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }

        }

        internal IgrueLogErrori GetLogErroriById(int IdLogErrori)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zIgrueGetLogErroriById",
                CommandType = CommandType.StoredProcedure
            };
            sqlCmd.Parameters.AddWithValue2("@IdIgrueLogErrori", IdLogErrori);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new IgrueLogErrori()
                                                          {
                                                              ID_IGRUE_LOG_ERRORI = int.Parse(reader["ID_IGRUE_LOG_ERRORI"].ToString()),
                                                              ID_INVIO = int.Parse(reader["ID_INVIO"].ToString()),
                                                              ID_TICKET = Convert.ToString(reader["ID_TICKET"]),
                                                              DATA_RICHIESTA = Convert.ToDateTime(reader["DATA_RICHIESTA"]),
                                                              FILE_ERRORI = (byte[])reader["FILE_ERRORI"],
                                                              ISTANZA_ERRORI = Convert.ToString(reader["ISTANZA_ERRORI"]),
                                                              ID_OPERATORE = Convert.IsDBNull(reader["ID_OPERATORE"]) ? (int?)null : (int)reader["ID_OPERATORE"],
                                                              CODICE_ESITO = Convert.IsDBNull(reader["CODICE_ESITO"]) ? (int?)null : (int)reader["CODICE_ESITO"],
                                                              DESCRIZIONE_ESITO = Convert.ToString(reader["DESCRIZIONE_ESITO"]),
                                                              DETTAGLIO_ESITO = Convert.ToString(reader["DETTAGLIO_ESITO"]),
                                                              TIMESTAMP_ESITO = Convert.ToDateTime(reader["TIMESTAMP_ESITO"]),
                                                              TIPO_FILE = Convert.ToString(reader["TIPO_FILE"]),
                                                              CODICE_FONDO = Convert.ToString(reader["CODICE_FONDO"])
                                                          };
                                                          return o;
                                                      });
                if (list.Any())
                {
                    return list[0];
                }

                return null;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }

        }

        internal IgrueLogErrori GetLogErroriByIdTicket(string IdTicket)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zIgrueGetLogErroriByIdTicket",
                CommandType = CommandType.StoredProcedure
            };
            sqlCmd.Parameters.AddWithValue2("@IdTicket", IdTicket);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new IgrueLogErrori()
                                                          {
                                                              ID_IGRUE_LOG_ERRORI = int.Parse(reader["ID_IGRUE_LOG_ERRORI"].ToString()),
                                                              ID_INVIO = int.Parse(reader["ID_INVIO"].ToString()),
                                                              ID_TICKET = Convert.ToString(reader["ID_TICKET"]),
                                                              DATA_RICHIESTA = Convert.ToDateTime(reader["DATA_RICHIESTA"]),
                                                              FILE_ERRORI = Convert.IsDBNull(reader["FILE_ERRORI"]) ? (byte[])null : (byte[])reader["FILE_ERRORI"],
                                                              ISTANZA_ERRORI = Convert.ToString(reader["ISTANZA_ERRORI"]),
                                                              ID_OPERATORE = Convert.IsDBNull(reader["ID_OPERATORE"]) ? (int?)null : (int)reader["ID_OPERATORE"],
                                                              CODICE_ESITO = Convert.IsDBNull(reader["CODICE_ESITO"]) ? (int?)null : (int)reader["CODICE_ESITO"],
                                                              DESCRIZIONE_ESITO = Convert.ToString(reader["DESCRIZIONE_ESITO"]),
                                                              DETTAGLIO_ESITO = Convert.ToString(reader["DETTAGLIO_ESITO"]),
                                                              TIMESTAMP_ESITO = Convert.ToDateTime(reader["TIMESTAMP_ESITO"]),
                                                              TIPO_FILE = Convert.ToString(reader["TIPO_FILE"]),
                                                              CODICE_FONDO = Convert.ToString(reader["CODICE_FONDO"])
                                                          };
                                                          return o;
                                                      });
                if (list.Any())
                {
                    return list.OrderByDescending(p => p.TIMESTAMP_ESITO).FirstOrDefault();
                }

                return null;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }

        }

        internal void UpdateFileInvioMonitoraggio(byte[] FileInvio, int IdInvio)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zIgrueUpdateFileInvio",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@IdInvio", IdInvio);
                sqlCmd.Parameters.AddWithValue2("@FileInvio", FileInvio);
                sqlCmd.Parameters["@FileInvio"].SqlDbType = SqlDbType.VarBinary;
                SqlHelper.ExecuteNonQueryCmd(connectionString, sqlCmd);
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal void UpdateTicketInvioMonitoraggio(string IdTicket, int IdInvio)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zIgrueUpdateTicketInvio",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@IdInvio", IdInvio);
                sqlCmd.Parameters.AddWithValue2("@IdTicket", IdTicket);

                SqlHelper.ExecuteNonQueryCmd(connectionString, sqlCmd);
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal List<IgruePA00> GetIgruePA00(int IdInvio)
        {
            //var result = new List<IgruePA00>();
            var sqlCmd = new SqlCommand
            {
                CommandText = "zIgrueGetIgruePA00",
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.AddWithValue2("@IdInvio", IdInvio);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new IgruePA00()
                                                          {
                                                              COD_PROC_ATT = Convert.ToString(reader["COD_PROC_ATT"]),
                                                              COD_PROC_ATT_LOCALE = Convert.ToString(reader["COD_PROC_ATT_LOCALE"]),
                                                              COD_AIUTO_RNA = Convert.ToString(reader["COD_AIUTO_RNA"]),
                                                              TIP_PROCEDURA_ATT = Convert.ToString(reader["TIP_PROCEDURA_ATT"]),
                                                              FLAG_AIUTI = Convert.ToString(reader["FLAG_AIUTI"]),
                                                              DESCR_PROCEDURA_ATT = Convert.ToString(reader["DESCR_PROCEDURA_ATT"]),
                                                              COD_TIPO_RESP_PROC = Convert.ToString(reader["COD_TIPO_RESP_PROC"]),
                                                              DENOM_RESP_PROC = Convert.ToString(reader["DENOM_RESP_PROC"]),
                                                              DATA_AVVIO_PROCEDURA = Convert.ToString(reader["DATA_AVVIO_PROCEDURA"]),
                                                              DATA_FINE_PROCEDURA = Convert.ToString(reader["DATA_FINE_PROCEDURA"]),
                                                              FLG_CANCELLAZIONE = Convert.ToString(reader["FLG_CANCELLAZIONE"]),
                                                              OPERAZIONE = Convert.ToString(reader["OPERAZIONE"]),
                                                              ID_INVIO = int.Parse(reader["ID_INVIO"].ToString()),
                                                              NR_RIGA_INVIO = int.Parse(reader["NR_RIGA_INVIO"].ToString()),
                                                          };
                                                          return o;
                                                      });
                if (list.Any())
                {                  
                    return list;
                }

                return null;
            }
            catch (Exception ex)
            {               
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal DataTable GetDatiTabellaIgrue(string NomeTabella, int IdInvio, string CodiceFondo)
        {
            var result = new List<object>();

            var sqlCmd = new SqlCommand
            {
                CommandText = "zIgrueGetTabella",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@NomeTabella", NomeTabella);
                sqlCmd.Parameters.AddWithValue2("@IdInvio", IdInvio);
                sqlCmd.Parameters.AddWithValue2("@CodiceFondo", CodiceFondo);
                var table = SqlHelper.ExecuteReaderTableCmd(connectionString, sqlCmd);
                if (table.Rows.Count > 0)
                {
                    return table;
                }              
                return null;
            }           
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal DataTable GetDatiTabellaIgrue(string NomeTabella, int IdInvio, int RowNumber, string CodiceFondo)
        {
            var result = new List<object>();

            var sqlCmd = new SqlCommand
            {
                CommandText = "zIgrueFindTabella",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@NomeTabella", NomeTabella);
                sqlCmd.Parameters.AddWithValue2("@IdInvio", IdInvio);
                sqlCmd.Parameters.AddWithValue2("@RowNumber", RowNumber);
                sqlCmd.Parameters.AddWithValue2("@CodiceFondo", CodiceFondo);
                var table = SqlHelper.ExecuteReaderTableCmd(connectionString, sqlCmd);
                if (table.Rows.Count > 0)
                {
                    return table;
                }
                return null;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal List<string> GetColumnNames(string NomeTabella)
        {
            var result = new List<object>();

            var sqlCmd = new SqlCommand
            {
                CommandText = "zIgrueGetColumnNames",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@NomeTabella", NomeTabella);
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd, reader =>
                    {
                        string o = reader[0].ToString();
                        return o;
                    });
                if (list.Any())
                {
                    return list;
                }
                return null;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        //Metodi per l'inserimento dei codici di attivazione dei bandi nella tabella di appoggio
        internal void InsertCodProceduraAttivazione(int IdBando, string CodProceduraAttivazione, DateTime? DataAssegnazione)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zIgrueInsertCodProcAttivazione",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@IdBando", IdBando);
                sqlCmd.Parameters.AddWithValue2("@CodProceduraAttivazione", CodProceduraAttivazione);
                sqlCmd.Parameters.AddWithValue2("@DataAssegnazione", DataAssegnazione);
                SqlHelper.ExecuteNonQueryCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal void UpdateCodProceduraAttivazione(int IdBando, string CodProceduraAttivazione)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zIgrueUpdateCodProcAttivazione",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@IdBando", IdBando);
                sqlCmd.Parameters.AddWithValue2("@CodProceduraAttivazione", CodProceduraAttivazione);
                SqlHelper.ExecuteNonQueryCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal BandoCodiciAttivazione GetCodProceduraAttivazioneByCodProcAttivazione(string CodProcedura)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zIgrueGetCodProcAttivazioneByCodProcAtt",
                CommandType = CommandType.StoredProcedure
            };
            sqlCmd.Parameters.AddWithValue2("@CodProcedura", CodProcedura);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new BandoCodiciAttivazione()
                                                          {
                                                              ID_BANDO = int.Parse(reader["ID_BANDO"].ToString()),
                                                              COD_PROCEDURA_ATTIVAZIONE = Convert.ToString(reader["COD_PROCEDURA_ATTIVAZIONE"]),
                                                          };
                                                          return o;
                                                      });
                if (list.Any())
                {
                    return list[0];
                }

                return null;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }

        }

        internal int InsertProgettiCancellazione(int IdInvio, string NomeFile, int IdInvioDelete, int? rNumber)
        {
            var columns = this.GetColumnNames(NomeFile);
            var tableName = "IGRUE_" + NomeFile;
            var cmd = "";
            cmd += "INSERT INTO IGRUE_MONIT.dbo." + tableName + " (";
            foreach (string column in columns)
            {
                cmd += column + (columns.IndexOf(column) == (columns.Count - 1) ? ") " : ",");
            }

            cmd += "SELECT ";

            foreach (string column in columns)
            {
                switch (column)
                {
                    case "FLG_CANCELLAZIONE":
                        cmd += "'S',";
                        break;
                    case "ID_INVIO":
                        cmd += IdInvio.ToString() + ",";
                        break;
                    case "NR_RIGA_INVIO":
                        cmd += "ISNULL(@rNumber, 0) + ROW_NUMBER() OVER(ORDER BY COD_LOCALE_PROGETTO ASC) AS NR_RIGA_INVIO,";
                        break;
                    default:
                        cmd += column + (columns.IndexOf(column) == (columns.Count - 1) ? " " : ",");
                        break;
                }
            }

            cmd += "FROM IGRUE_MONIT.dbo." + tableName + " WHERE COD_LOCALE_PROGETTO IN (SELECT ID_PROGETTO FROM IGRUE_MONIT.dbo.APPO_DELETE WHERE IGRUE_MONIT.dbo.APPO_DELETE.ID_INVIO=" + IdInvioDelete.ToString() + ") AND  IGRUE_MONIT.dbo." + tableName + ".ID_INVIO = " + IdInvioDelete.ToString();
            cmd += " SELECT ISNULL(MAX(NR_RIGA_INVIO),0) FROM IGRUE_MONIT.dbo." + tableName + " WHERE ID_INVIO = " + IdInvio.ToString();

            var sqlCmd = new SqlCommand
            {
                CommandText = cmd,
                CommandType = CommandType.Text
            };

            sqlCmd.Parameters.AddWithValue2("@rNumber", rNumber);

            try
            {
                int res = (int)SqlHelper.ExecuteScalarCmd(connectionString, sqlCmd);
                return res;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }

        }

        internal int InsertProgettiCancellazione(int IdInvio, string NomeFile, int IdInvioDelete, string[] IdProgetti, int? rNumber)
        {
            var IdProgClause = " WHERE COD_LOCALE_PROGETTO IN (";
            var lprog = IdProgetti.ToList();
            var lprogCount = lprog.Count;
            foreach (string prog in lprog)
            {
                IdProgClause += prog + (lprog.IndexOf(prog) != lprogCount - 1 ? "," : ")");
            }
            var columns = this.GetColumnNames(NomeFile);
            var tableName = "IGRUE_" + NomeFile;
            var cmd = "";
            cmd += "INSERT INTO IGRUE_MONIT.dbo." + tableName + " (";
            foreach (string column in columns)
            {
                cmd += column + (columns.IndexOf(column) == (columns.Count - 1) ? ") " : ",");
            }

            cmd += "SELECT ";

            foreach (string column in columns)
            {
                switch (column)
                {
                    case "FLG_CANCELLAZIONE":
                        cmd += "'S',";
                        break;
                    case "ID_INVIO":
                        cmd += IdInvio.ToString() + ",";
                        break;
                    case "NR_RIGA_INVIO":
                        cmd += "ISNULL(@rNumber, 0) + ROW_NUMBER() OVER(ORDER BY COD_LOCALE_PROGETTO ASC) AS NR_RIGA_INVIO,";
                        break;
                    default:
                        cmd += column + (columns.IndexOf(column) == (columns.Count - 1) ? " " : ",");
                        break;
                }
            }

            cmd += "FROM IGRUE_MONIT.dbo." + tableName + IdProgClause + " AND  IGRUE_MONIT.dbo." + tableName + ".ID_INVIO = " + IdInvioDelete.ToString();
            cmd += " SELECT ISNULL(MAX(NR_RIGA_INVIO),0) FROM IGRUE_MONIT.dbo." + tableName + " WHERE ID_INVIO = " + IdInvio.ToString();

            var sqlCmd = new SqlCommand
            {
                CommandText = cmd,
                CommandType = CommandType.Text
            };

            sqlCmd.Parameters.AddWithValue2("@rNumber", rNumber);

            try
            {
                int res = (int)SqlHelper.ExecuteScalarCmd(connectionString, sqlCmd);
                return res;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }

        }

        internal int InsertProgettiCancellazione(int IdInvio, string NomeFile, int IdInvioDelete, string[] IdProgetti, string[] RowNumbers, int? rNumber)
        {
            var IdProgClause = " COD_LOCALE_PROGETTO IN (";
            var lprog = IdProgetti.ToList();
            var lprogCount = lprog.Count;
            foreach (string prog in lprog)
            {
                IdProgClause += prog + (lprog.IndexOf(prog) != lprogCount - 1 ? "," : ")");
            }
            var RowNumClause = " NR_RIGA_INVIO IN (";
            var lrow = RowNumbers.ToList();
            var lrowCount = lrow.Count;
            foreach (string rown in lrow)
            {
                RowNumClause += rown + (lrow.IndexOf(rown) != lrowCount - 1 ? "," : ")");
            }

            string conditionClause = "";
            if (IdProgetti.Count() > 0)
            {
                conditionClause += " AND" + IdProgClause;
            }
            if (RowNumbers.Count() > 0)
            {
                conditionClause += " AND" + RowNumClause;
            }

            var columns = this.GetColumnNames(NomeFile);
            var tableName = "IGRUE_" + NomeFile;
            var cmd = "";
            cmd += "INSERT INTO IGRUE_MONIT.dbo." + tableName + " (";
            foreach (string column in columns)
            {
                cmd += column + (columns.IndexOf(column) == (columns.Count - 1) ? ") " : ",");
            }

            cmd += "SELECT ";

            foreach (string column in columns)
            {
                switch (column)
                {
                    case "FLG_CANCELLAZIONE":
                        cmd += "'S',";
                        break;
                    case "ID_INVIO":
                        cmd += IdInvio.ToString() + ",";
                        break;
                    case "NR_RIGA_INVIO":
                        cmd += "ISNULL(@rNumber, 0) + ROW_NUMBER() OVER(ORDER BY COD_LOCALE_PROGETTO ASC) AS NR_RIGA_INVIO,";
                        break;
                    default:
                        cmd += column + (columns.IndexOf(column) == (columns.Count - 1) ? " " : ",");
                        break;
                }
            }

            cmd += "FROM IGRUE_MONIT.dbo." + tableName + " WHERE  IGRUE_MONIT.dbo." + tableName + ".ID_INVIO = " + IdInvioDelete.ToString() + conditionClause;
            cmd += " SELECT ISNULL(MAX(NR_RIGA_INVIO),0) FROM IGRUE_MONIT.dbo." + tableName + " WHERE ID_INVIO = " + IdInvio.ToString();

            var sqlCmd = new SqlCommand
            {
                CommandText = cmd,
                CommandType = CommandType.Text
            };

            sqlCmd.Parameters.AddWithValue2("@rNumber", rNumber);

            try
            {
                int res = (int)SqlHelper.ExecuteScalarCmd(connectionString, sqlCmd);//0;//
                return res;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }

        }

        internal int InsertProgettiCancellazione(int IdInvio, string NomeFile, int IdInvioDelete, string FilterClause, int? rNumber)
        {
            string conditionClause = " AND " + FilterClause;

            var columns = this.GetColumnNames(NomeFile);
            var tableName = "IGRUE_" + NomeFile;
            var cmd = "";
            cmd += "INSERT INTO IGRUE_MONIT.dbo." + tableName + " (";
            foreach (string column in columns)
            {
                cmd += column + (columns.IndexOf(column) == (columns.Count - 1) ? ") " : ",");
            }

            cmd += "SELECT ";

            foreach (string column in columns)
            {
                switch (column)
                {
                    case "FLG_CANCELLAZIONE":
                        cmd += "'S',";
                        break;
                    case "ID_INVIO":
                        cmd += IdInvio.ToString() + ",";
                        break;
                    case "NR_RIGA_INVIO":
                        cmd += "ISNULL(@rNumber, 0) + ROW_NUMBER() OVER(ORDER BY COD_LOCALE_PROGETTO ASC) AS NR_RIGA_INVIO,";
                        break;
                    default:
                        cmd += column + (columns.IndexOf(column) == (columns.Count - 1) ? " " : ",");
                        break;
                }
            }

            cmd += "FROM IGRUE_MONIT.dbo." + tableName + " WHERE  IGRUE_MONIT.dbo." + tableName + ".ID_INVIO = " + IdInvioDelete.ToString() + conditionClause;
            cmd += " SELECT ISNULL(MAX(NR_RIGA_INVIO),0) FROM IGRUE_MONIT.dbo." + tableName + " WHERE ID_INVIO = " + IdInvio.ToString();

            var sqlCmd = new SqlCommand
            {
                CommandText = cmd,
                CommandType = CommandType.Text
            };

            sqlCmd.Parameters.AddWithValue2("@rNumber", rNumber);

            try
            {
                int res = (int)SqlHelper.ExecuteScalarCmd(connectionString, sqlCmd);//0;//
                return res;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }

        }

        internal List<BandoInfo> CheckBandiAttivazione(string CodiceFondo)
        {
            string cmd = "";
            if (CodiceFondo == "FESR20142020")
                CodiceFondo = "POR20142020";

            cmd = String.Format(@"SELECT
                            B.ID_BANDO,
                            B.DESCRIZIONE,
                            B.COD_STATO,
                            P.COD_TIPO,
                            BCA.COD_PROCEDURA_ATTIVAZIONE 
                            from vBANDO B
                            inner join zPROGRAMMAZIONE P ON
                            B.ID_PROGRAMMAZIONE = P.ID
                            LEFT OUTER JOIN 
                            BANDO_CODICI_ATTIVAZIONE BCA ON
                            B.ID_BANDO = BCA.ID_BANDO
                            WHERE P.COD_TIPO LIKE '{0}%'
                            AND 
                            B.COD_STATO <> 'P'
                            AND B.DISPOSIZIONI_ATTUATIVE <> 1
                            AND
                            BCA.COD_PROCEDURA_ATTIVAZIONE IS NULL", CodiceFondo);

            var sqlCmd = new SqlCommand
            {
                CommandText = cmd,
                CommandType = CommandType.Text
            };

            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new BandoInfo()
                                                          {
                                                              ID_BANDO = int.Parse(reader["ID_BANDO"].ToString()),
                                                              COD_PROCEDURA_ATTIVAZIONE = Convert.ToString(reader["COD_PROCEDURA_ATTIVAZIONE"]),
                                                              DESCRIZIONE = Convert.ToString(reader["DESCRIZIONE"]),
                                                          };
                                                          return o;
                                                      });
                if (list.Any())
                {
                    return list;
                }

                return null;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione della verifica codici di attivazione: {0}", ex.Message);
                throw new Exception(msg, ex);
            }

        }
    }
}
