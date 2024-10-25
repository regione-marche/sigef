using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace RnaManager
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

        internal static byte[] DecryptString(string PASSWORD, byte[] encryptedBytes)
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

        internal DataSet GetAiuto(int idProgetto)
        {
            var result = new DataSet();

            var sqlCmd = new SqlCommand
            {
                CommandText = "RnaInvioRichiestaAiuto",
                CommandType = CommandType.StoredProcedure
            };

            SqlConnection conn = new SqlConnection(this.connectionString);

            try
            {
                sqlCmd.Parameters.AddWithValue2("@ID_PROGETTO", idProgetto);
                SqlDataAdapter da = new SqlDataAdapter("RnaInvioRichiestaAiuto", this.connectionString);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue2("@ID_PROGETTO", idProgetto);
                //da.SelectCommand = sqlCmd;
                da.Fill(result);

                return result;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal DataSet GetAiutoSingolaImpresa(int idProgetto, int idImpresa, bool produzione)
        {
            var result = new DataSet();

            var sqlCmd = new SqlCommand
            {
                CommandText = "RnaInvioRichiestaAiuto",
                CommandType = CommandType.StoredProcedure
            };

            SqlConnection conn = new SqlConnection(this.connectionString);

            try
            {
                sqlCmd.Parameters.AddWithValue2("@ID_PROGETTO", idProgetto);
                sqlCmd.Parameters.AddWithValue2("@PRODUZIONE", produzione);
                SqlDataAdapter da = new SqlDataAdapter("RnaInvioRichiestaAiuto", this.connectionString);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue2("@ID_PROGETTO", idProgetto);
                da.SelectCommand.Parameters.AddWithValue2("@ID_IMPRESA", idImpresa);
                da.SelectCommand.Parameters.AddWithValue2("@PRODUZIONE", produzione);
                //da.SelectCommand = sqlCmd;
                da.Fill(result);

                return result;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal DataSet GetAiutoSingolaImpresaCovid(int idProgetto, int idImpresa, bool produzione)
        {
            var result = new DataSet();

            var sqlCmd = new SqlCommand
            {
                CommandText = "RnaInvioRichiestaAiutoCovid",
                CommandType = CommandType.StoredProcedure
            };

            SqlConnection conn = new SqlConnection(this.connectionString);

            try
            {
                sqlCmd.Parameters.AddWithValue2("@ID_PROGETTO", idProgetto);
                sqlCmd.Parameters.AddWithValue2("@PRODUZIONE", produzione);
                SqlDataAdapter da = new SqlDataAdapter("RnaInvioRichiestaAiutoCovid", this.connectionString);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue2("@ID_PROGETTO", idProgetto);
                da.SelectCommand.Parameters.AddWithValue2("@ID_IMPRESA", idImpresa);
                da.SelectCommand.Parameters.AddWithValue2("@PRODUZIONE", produzione);
                //da.SelectCommand = sqlCmd;
                da.Fill(result);

                return result;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        #region metodi visure
        internal void InsertRnaLogVisura(RnaLogVisura LogVisura)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zRnaInsertLogVisura",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@IdProgetto", LogVisura.ID_PROGETTO);
                sqlCmd.Parameters.AddWithValue2("@IdImpresa", LogVisura.ID_IMPRESA);
                sqlCmd.Parameters.AddWithValue2("@IdFiscaleImpresa", LogVisura.ID_FISCALE_IMPRESA);
                sqlCmd.Parameters.AddWithValue2("@IdRichiesta", LogVisura.ID_RICHIESTA);
                sqlCmd.Parameters.AddWithValue2("@TipoVisura", LogVisura.TIPO_VISURA);
                sqlCmd.Parameters.AddWithValue2("@CodiceEsito", LogVisura.CODICE_ESITO);
                sqlCmd.Parameters.AddWithValue2("@DescrizioneEsito", LogVisura.DESCRIZIONE_ESITO);
                sqlCmd.Parameters.AddWithValue2("@DataRichiesta", LogVisura.DATA_RICHIESTA);
                sqlCmd.Parameters.AddWithValue2("@IdOperatore", LogVisura.ID_OPERATORE);
                

                LogVisura.ID_RNA_LOG_VISURA = (int)SqlHelper.ExecuteScalarCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }


        internal void UpdateRnaLogVisura(RnaLogVisura LogVisura)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zRnaUpdateLogVisura",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@IdRnaLogVisura", LogVisura.ID_RNA_LOG_VISURA);
                sqlCmd.Parameters.AddWithValue2("@CodiceStatoRichiesta", LogVisura.CODICE_STATO_RICHIESTA);
                sqlCmd.Parameters.AddWithValue2("@DescrizioneStatoRichiesta", LogVisura.DESCRIZIONE_STATO_RICHIESTA);
                sqlCmd.Parameters.AddWithValue2("@DataStatoRichiesta", LogVisura.DATA_STATO_RICHIESTA);
                sqlCmd.Parameters.AddWithValue2("@IdOperatore", LogVisura.ID_OPERATORE);


                SqlHelper.ExecuteNonQueryCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }


        internal RnaLogVisura GetRnaLogVisuraById(int IdRnaLogVisura)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zRnaGetLogVisuraById",
                CommandType = CommandType.StoredProcedure
            };
            sqlCmd.Parameters.AddWithValue2("@IdRnaLogVisura", IdRnaLogVisura);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new RnaLogVisura()
                                                          {
                                                              ID_RNA_LOG_VISURA = int.Parse(reader["ID_RNA_LOG_VISURA"].ToString()),
                                                              ID_PROGETTO = Convert.IsDBNull(reader["ID_PROGETTO"]) ? (int?)null : (int)reader["ID_PROGETTO"],
                                                              ID_IMPRESA = int.Parse(reader["ID_IMPRESA"].ToString()),
                                                              ID_FISCALE_IMPRESA = Convert.ToString(reader["ID_FISCALE_IMPRESA"]),
                                                              ID_RICHIESTA = Convert.ToString(reader["ID_RICHIESTA"]),
                                                              TIPO_VISURA = Convert.ToString(reader["TIPO_VISURA"]),
                                                              CODICE_ESITO = int.Parse(reader["CODICE_ESITO"].ToString()),
                                                              DESCRIZIONE_ESITO = Convert.ToString(reader["DESCRIZIONE_ESITO"]),
                                                              DATA_RICHIESTA = Convert.ToDateTime(reader["DATA_RICHIESTA"]),
                                                              CODICE_STATO_RICHIESTA = Convert.IsDBNull(reader["CODICE_STATO_RICHIESTA"]) ? (int?)null : (int)reader["CODICE_STATO_RICHIESTA"],
                                                              DESCRIZIONE_STATO_RICHIESTA = Convert.ToString(reader["DESCRIZIONE_STATO_RICHIESTA"]),
                                                              DATA_STATO_RICHIESTA = Convert.IsDBNull(reader["DATA_STATO_RICHIESTA"]) ? (DateTime?)null : Convert.ToDateTime(reader["DATA_STATO_RICHIESTA"]),
                                                              ID_OPERATORE = (int)reader["ID_OPERATORE"],
                                                              DATA_INSERIMENTO = Convert.ToDateTime(reader["DATA_INSERIMENTO"]),
                                                              DATA_AGGIORNAMENTO = Convert.ToDateTime(reader["DATA_AGGIORNAMENTO"]),
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


        internal RnaLogVisura GetRnaLogVisuraByIdRichiesta(string IdRichiesta)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zRnaGetLogVisuraByIdRichiesta",
                CommandType = CommandType.StoredProcedure
            };
            sqlCmd.Parameters.AddWithValue2("@IdRichiesta", IdRichiesta);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new RnaLogVisura()
                                                          {
                                                              ID_RNA_LOG_VISURA = int.Parse(reader["ID_RNA_LOG_VISURA"].ToString()),
                                                              ID_PROGETTO = Convert.IsDBNull(reader["ID_PROGETTO"]) ? (int?)null : (int)reader["ID_PROGETTO"],
                                                              ID_IMPRESA = int.Parse(reader["ID_IMPRESA"].ToString()),
                                                              ID_FISCALE_IMPRESA = Convert.ToString(reader["ID_FISCALE_IMPRESA"]),
                                                              ID_RICHIESTA = Convert.ToString(reader["ID_RICHIESTA"]),
                                                              TIPO_VISURA = Convert.ToString(reader["TIPO_VISURA"]),
                                                              CODICE_ESITO = int.Parse(reader["CODICE_ESITO"].ToString()),
                                                              DESCRIZIONE_ESITO = Convert.ToString(reader["DESCRIZIONE_ESITO"]),
                                                              DATA_RICHIESTA = Convert.ToDateTime(reader["DATA_RICHIESTA"]),
                                                              CODICE_STATO_RICHIESTA = Convert.IsDBNull(reader["CODICE_STATO_RICHIESTA"]) ? (int?)null : (int)reader["CODICE_STATO_RICHIESTA"],
                                                              DESCRIZIONE_STATO_RICHIESTA = Convert.ToString(reader["DESCRIZIONE_STATO_RICHIESTA"]),
                                                              DATA_STATO_RICHIESTA = Convert.IsDBNull(reader["DATA_STATO_RICHIESTA"]) ? (DateTime?)null : Convert.ToDateTime(reader["DATA_STATO_RICHIESTA"]),
                                                              ID_OPERATORE = (int)reader["ID_OPERATORE"],
                                                              DATA_INSERIMENTO = Convert.ToDateTime(reader["DATA_INSERIMENTO"]),
                                                              DATA_AGGIORNAMENTO = Convert.ToDateTime(reader["DATA_AGGIORNAMENTO"]),
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

        #endregion


        internal void InsertRnaLogConcessione(RnaLogConcessione LogConcessione)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zRnaInsertLogConcessione",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@IdProgetto", LogConcessione.ID_PROGETTO);
                sqlCmd.Parameters.AddWithValue2("@IdProgettoRna", LogConcessione.ID_PROGETTO_RNA);
                sqlCmd.Parameters.AddWithValue2("@IdImpresa", LogConcessione.ID_IMPRESA);
                sqlCmd.Parameters.AddWithValue2("@IdFiscaleImpresa", LogConcessione.ID_FISCALE_IMPRESA);
                sqlCmd.Parameters.AddWithValue2("@IdRichiesta", LogConcessione.ID_RICHIESTA);
                //sqlCmd.Parameters.AddWithValue2("@Metodo", LogConcessione.METODO);
                sqlCmd.Parameters.AddWithValue2("@DataRichiesta", LogConcessione.DATA_RICHIESTA);
                sqlCmd.Parameters.AddWithValue2("@IstanzaRichiesta", LogConcessione.ISTANZA_RICHIESTA);
                sqlCmd.Parameters.AddWithValue2("@IstanzaRisposta", LogConcessione.ISTANZA_RISPOSTA);
                sqlCmd.Parameters.AddWithValue2("@Cor", LogConcessione.COR);
                sqlCmd.Parameters.AddWithValue2("@CodiceEsito", LogConcessione.CODICE_ESITO);
                sqlCmd.Parameters.AddWithValue2("@DescrizioneEsito", LogConcessione.DESCRIZIONE_ESITO);
                //sqlCmd.Parameters.AddWithValue2("@TipoRisposta", LogConcessione.TIPO_RISPOSTA);
                //sqlCmd.Parameters["@FileInvio"].SqlDbType = SqlDbType.VarBinary;
                sqlCmd.Parameters.AddWithValue2("@IdOperatoreRegAiuto", LogConcessione.ID_OPERATORE_REG_AIUTO);
                sqlCmd.Parameters.AddWithValue2("@Produzione", LogConcessione.PRODUZIONE);


                LogConcessione.ID_RNA_LOG_CONCESSIONE = (int)SqlHelper.ExecuteScalarCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }


        internal void UpdateRnaLogConcessione(RnaLogConcessione LogConcessione)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zRnaUpdateLogConcessione",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@IdRnaLogConcessione", LogConcessione.ID_RNA_LOG_CONCESSIONE);
                sqlCmd.Parameters.AddWithValue2("@IdProgetto", LogConcessione.ID_PROGETTO);
                sqlCmd.Parameters.AddWithValue2("@IdProgettoRna", LogConcessione.ID_PROGETTO_RNA);
                sqlCmd.Parameters.AddWithValue2("@IdImpresa", LogConcessione.ID_IMPRESA);
                sqlCmd.Parameters.AddWithValue2("@IdFiscaleImpresa", LogConcessione.ID_FISCALE_IMPRESA);
                sqlCmd.Parameters.AddWithValue2("@IdRichiesta", LogConcessione.ID_RICHIESTA);
                sqlCmd.Parameters.AddWithValue2("@IdOperatoreRegAiuto", LogConcessione.ID_OPERATORE_REG_AIUTO);
                //sqlCmd.Parameters.AddWithValue2("@Metodo", LogConcessione.METODO);
                sqlCmd.Parameters.AddWithValue2("@DataRichiesta", LogConcessione.DATA_RICHIESTA);
                sqlCmd.Parameters.AddWithValue2("@IstanzaRichiesta", LogConcessione.ISTANZA_RICHIESTA);
                sqlCmd.Parameters.AddWithValue2("@IstanzaRisposta", LogConcessione.ISTANZA_RISPOSTA);
                sqlCmd.Parameters.AddWithValue2("@Cor", LogConcessione.COR);
                sqlCmd.Parameters.AddWithValue2("@CodiceEsito", LogConcessione.CODICE_ESITO);
                sqlCmd.Parameters.AddWithValue2("@DescrizioneEsito", LogConcessione.DESCRIZIONE_ESITO);
                //sqlCmd.Parameters.AddWithValue2("@TipoRisposta", LogConcessione.TIPO_RISPOSTA);
                sqlCmd.Parameters.AddWithValue2("@CodiceEsitoStatoRichiesta", LogConcessione.CODICE_ESITO_STATO_RICHIESTA);
                sqlCmd.Parameters.AddWithValue2("@DescrizioneEsitoStatoRichiesta", LogConcessione.DESCRIZIONE_ESITO_STATO_RICHIESTA);
                sqlCmd.Parameters.AddWithValue2("@IdOperatoreStatoRichiesta", LogConcessione.ID_OPERATORE_STATO_RICHIESTA);
                sqlCmd.Parameters.AddWithValue2("@DataStatoRichiesta", LogConcessione.DATA_STATO_RICHIESTA);
                sqlCmd.Parameters.AddWithValue2("@Errore", LogConcessione.ERRORE);
                sqlCmd.Parameters.AddWithValue2("@Produzione", LogConcessione.PRODUZIONE);
                //sqlCmd.Parameters["@FileInvio"].SqlDbType = SqlDbType.VarBinary;



                SqlHelper.ExecuteNonQueryCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }


        internal RnaLogConcessione GetRnaLogConcessioneByIdRichiesta(string IdRichiesta, bool GetXmlRequest, bool GetXmlResponse)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zRnaGetLogConcessioneByIdRichiesta",
                CommandType = CommandType.StoredProcedure
            };
            sqlCmd.Parameters.AddWithValue2("@IdRichiesta", IdRichiesta);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new RnaLogConcessione()
                                                          {
                                                              ID_RNA_LOG_CONCESSIONE = int.Parse(reader["ID_RNA_LOG_CONCESSIONE"].ToString()),
                                                              ID_PROGETTO = Convert.IsDBNull(reader["ID_PROGETTO"]) ? (int?)null : (int)reader["ID_PROGETTO"],
                                                              ID_PROGETTO_RNA = Convert.ToString(reader["ID_PROGETTO_RNA"]),
                                                              ID_IMPRESA = int.Parse(reader["ID_IMPRESA"].ToString()),
                                                              ID_FISCALE_IMPRESA = Convert.ToString(reader["ID_FISCALE_IMPRESA"]),
                                                              ID_RICHIESTA = Convert.ToString(reader["ID_RICHIESTA"]),
                                                              DATA_RICHIESTA = Convert.ToDateTime(reader["DATA_RICHIESTA"]),
                                                              ID_OPERATORE_REG_AIUTO = (int)reader["ID_OPERATORE_REG_AIUTO"],
                                                              CODICE_ESITO = int.Parse(reader["CODICE_ESITO"].ToString()),
                                                              DESCRIZIONE_ESITO = Convert.ToString(reader["DESCRIZIONE_ESITO"]),
                                                              ISTANZA_RICHIESTA = GetXmlRequest? Convert.ToString(reader["ISTANZA_RICHIESTA"]) : null,
                                                              ISTANZA_RISPOSTA = GetXmlResponse ? Convert.ToString(reader["ISTANZA_RISPOSTA"]) : null,
                                                              CODICE_ESITO_STATO_RICHIESTA = Convert.IsDBNull(reader["CODICE_ESITO_STATO_RICHIESTA"]) ? (int?)null : (int)reader["CODICE_ESITO_STATO_RICHIESTA"],
                                                              DESCRIZIONE_ESITO_STATO_RICHIESTA = Convert.ToString(reader["DESCRIZIONE_ESITO_STATO_RICHIESTA"]),
                                                              ID_OPERATORE_STATO_RICHIESTA = Convert.IsDBNull(reader["ID_OPERATORE_STATO_RICHIESTA"]) ? (int?)null : (int)reader["ID_OPERATORE_STATO_RICHIESTA"],
                                                              DATA_STATO_RICHIESTA = Convert.IsDBNull(reader["DATA_STATO_RICHIESTA"]) ? (DateTime?)null : Convert.ToDateTime(reader["DATA_STATO_RICHIESTA"]),
                                                              DATA_INSERIMENTO = Convert.ToDateTime(reader["DATA_INSERIMENTO"]),
                                                              DATA_AGGIORNAMENTO = Convert.ToDateTime(reader["DATA_AGGIORNAMENTO"]),
                                                              //proprietà che probabilmente non serviranno
                                                              COR = Convert.ToString(reader["COR"]),
                                                              //METODO = Convert.ToString(reader["METODO"]),
                                                              ERRORE = Convert.ToString(reader["ERRORE"]),
                                                              //TIPO_RISPOSTA = Convert.ToString(reader["TIPO_RISPOSTA"]),
                                                              //PAYLOAD = Convert.IsDBNull(reader["PAYLOAD"])? null : (byte[])reader["PAYLOAD"],
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

        internal RnaLogConcessione GetRnaLogConcessioneById(int IdRnaLogConcessione, bool GetXmlRequest, bool GetXmlResponse)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zRnaGetLogConcessioneById",
                CommandType = CommandType.StoredProcedure
            };
            sqlCmd.Parameters.AddWithValue2("@IdRnaLogConcessione", IdRnaLogConcessione);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new RnaLogConcessione()
                                                          {
                                                              ID_RNA_LOG_CONCESSIONE = int.Parse(reader["ID_RNA_LOG_CONCESSIONE"].ToString()),
                                                              ID_PROGETTO = Convert.IsDBNull(reader["ID_PROGETTO"]) ? (int?)null : (int)reader["ID_PROGETTO"],
                                                              ID_IMPRESA = int.Parse(reader["ID_IMPRESA"].ToString()),
                                                              ID_FISCALE_IMPRESA = Convert.ToString(reader["ID_FISCALE_IMPRESA"]),
                                                              ID_RICHIESTA = Convert.ToString(reader["ID_RICHIESTA"]),
                                                              DATA_RICHIESTA = Convert.ToDateTime(reader["DATA_RICHIESTA"]),
                                                              ID_OPERATORE_REG_AIUTO = (int)reader["ID_OPERATORE_REG_AIUTO"],
                                                              CODICE_ESITO = int.Parse(reader["CODICE_ESITO"].ToString()),
                                                              DESCRIZIONE_ESITO = Convert.ToString(reader["DESCRIZIONE_ESITO"]),
                                                              ISTANZA_RICHIESTA = GetXmlRequest ? Convert.ToString(reader["ISTANZA_RICHIESTA"]) : null,
                                                              ISTANZA_RISPOSTA = GetXmlResponse ? Convert.ToString(reader["ISTANZA_RISPOSTA"]) : null,
                                                              CODICE_ESITO_STATO_RICHIESTA = Convert.IsDBNull(reader["CODICE_ESITO_STATO_RICHIESTA"]) ? (int?)null : (int)reader["CODICE_STATO_RICHIESTA"],
                                                              DESCRIZIONE_ESITO_STATO_RICHIESTA = Convert.ToString(reader["DESCRIZIONE_ESITO_STATO_RICHIESTA"]),
                                                              ID_OPERATORE_STATO_RICHIESTA = Convert.IsDBNull(reader["ID_OPERATORE_STATO_RICHIESTA"]) ? (int?)null : (int)reader["ID_OPERATORE_STATO_RICHIESTA"],
                                                              DATA_STATO_RICHIESTA = Convert.IsDBNull(reader["DATA_STATO_RICHIESTA"]) ? (DateTime?)null : Convert.ToDateTime(reader["DATA_STATO_RICHIESTA"]),
                                                              DATA_INSERIMENTO = Convert.ToDateTime(reader["DATA_INSERIMENTO"]),
                                                              DATA_AGGIORNAMENTO = Convert.ToDateTime(reader["DATA_AGGIORNAMENTO"]),
                                                              //proprietà che probabilmente non serviranno
                                                              COR = Convert.ToString(reader["COR"]),
                                                              //METODO = Convert.ToString(reader["METODO"]),
                                                              ERRORE = Convert.ToString(reader["ERRORE"]),
                                                              //TIPO_RISPOSTA = Convert.ToString(reader["TIPO_RISPOSTA"]),
                                                              //PAYLOAD = (byte[])reader["PAYLOAD"],
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

        internal void InsertRnaProgettoCor(RnaProgettoCor ProgettoCor)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zRnaInsertProgettoCor",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@IdProgetto", ProgettoCor.ID_PROGETTO);
                sqlCmd.Parameters.AddWithValue2("@IdProgettoRna", ProgettoCor.ID_PROGETTO_RNA);
                sqlCmd.Parameters.AddWithValue2("@IdImpresa", ProgettoCor.ID_IMPRESA);
                sqlCmd.Parameters.AddWithValue2("@IdFiscaleImpresa", ProgettoCor.ID_FISCALE_IMPRESA);
                sqlCmd.Parameters.AddWithValue2("@IdRichiesta", ProgettoCor.ID_RICHIESTA);
                sqlCmd.Parameters.AddWithValue2("@IdOperatoreAssegnazioneCor", ProgettoCor.ID_OPERATORE_ASSEGNAZIONE_COR);
                sqlCmd.Parameters.AddWithValue2("@Cor", ProgettoCor.COR);
                sqlCmd.Parameters.AddWithValue2("@StatoConcessione", ProgettoCor.STATO_CONCESSIONE);
                sqlCmd.Parameters.AddWithValue2("@DataAssegnazioneCor", ProgettoCor.DATA_ASSEGNAZIONE_COR);
                sqlCmd.Parameters.AddWithValue2("@IdOperatoreConfermaConcessione", ProgettoCor.ID_OPERATORE_CONFERMA_CONCESSIONE);
                sqlCmd.Parameters.AddWithValue2("@DataConfermaConcessione", ProgettoCor.DATA_CONFERMA_CONCESSIONE);
                sqlCmd.Parameters.AddWithValue2("@Annullato", ProgettoCor.ANNULLATO);
                sqlCmd.Parameters.AddWithValue2("@IdOperatoreAnnullamento", ProgettoCor.ID_OPERATORE_ANNULLAMENTO);
                sqlCmd.Parameters.AddWithValue2("@DataAnnullamento", ProgettoCor.DATA_ANNULLAMENTO);
                //sqlCmd.Parameters["@FileInvio"].SqlDbType = SqlDbType.VarBinary;



                ProgettoCor.ID_RNA_PROGETTO_COR = (int)SqlHelper.ExecuteScalarCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }


        internal void UpdateRnaProgettoCor(RnaProgettoCor ProgettoCor)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zRnaUpdateProgettoCor",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@IdRnaProgettoCor", ProgettoCor.ID_RNA_PROGETTO_COR);
                sqlCmd.Parameters.AddWithValue2("@StatoConcessione", ProgettoCor.STATO_CONCESSIONE);
                //sqlCmd.Parameters.AddWithValue2("@DataAssegnazioneCor", ProgettoCor.DATA_ASSEGNAZIONE_COR);
                sqlCmd.Parameters.AddWithValue2("@Confermato", ProgettoCor.CONFERMATO);
                sqlCmd.Parameters.AddWithValue2("@IdOperatoreConfermaConcessione", ProgettoCor.ID_OPERATORE_CONFERMA_CONCESSIONE);
                sqlCmd.Parameters.AddWithValue2("@DataConfermaConcessione", ProgettoCor.DATA_CONFERMA_CONCESSIONE);
                sqlCmd.Parameters.AddWithValue2("@Annullato", ProgettoCor.ANNULLATO);
                sqlCmd.Parameters.AddWithValue2("@IdOperatoreAnnullamento", ProgettoCor.ID_OPERATORE_ANNULLAMENTO);
                sqlCmd.Parameters.AddWithValue2("@DataAnnullamento", ProgettoCor.DATA_ANNULLAMENTO);
                sqlCmd.Parameters.AddWithValue2("@CodiceEsitoConferma", ProgettoCor.CODICE_ESITO_CONFERMA);
                sqlCmd.Parameters.AddWithValue2("@DescrizioneEsitoConferma", ProgettoCor.DESCRIZIONE_ESITO_CONFERMA);


                SqlHelper.ExecuteNonQueryCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }


        internal RnaProgettoCor GetRnaProgettoCorByIdRichiesta(string IdRichiesta)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zRnaGetProgettoCorByIdRichiesta",
                CommandType = CommandType.StoredProcedure
            };
            sqlCmd.Parameters.AddWithValue2("@IdRichiesta", IdRichiesta);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new RnaProgettoCor()
                                                          {
                                                              ID_RNA_PROGETTO_COR = int.Parse(reader["ID_RNA_PROGETTO_COR"].ToString()),
                                                              ID_PROGETTO = (int)reader["ID_PROGETTO"],
                                                              ID_PROGETTO_RNA = Convert.ToString(reader["ID_PROGETTO_RNA"]),
                                                              ID_IMPRESA = int.Parse(reader["ID_IMPRESA"].ToString()),
                                                              ID_FISCALE_IMPRESA = Convert.ToString(reader["ID_FISCALE_IMPRESA"]),
                                                              ID_RICHIESTA = Convert.ToString(reader["ID_RICHIESTA"]),
                                                              ID_OPERATORE_ASSEGNAZIONE_COR = (int)reader["ID_OPERATORE_ASSEGNAZIONE_COR"],
                                                              COR = Convert.ToString(reader["COR"]),
                                                              STATO_CONCESSIONE = Convert.ToString(reader["STATO_CONCESSIONE"]),
                                                              CONFERMATO = (bool)reader["CONFERMATO"],
                                                              DATA_ASSEGNAZIONE_COR = Convert.ToDateTime(reader["DATA_ASSEGNAZIONE_COR"]),
                                                              ID_OPERATORE_CONFERMA_CONCESSIONE = Convert.IsDBNull(reader["ID_OPERATORE_CONFERMA_CONCESSIONE"]) ? (int?)null : (int)reader["ID_OPERATORE_CONFERMA_CONCESSIONE"],
                                                              DATA_CONFERMA_CONCESSIONE = Convert.IsDBNull(reader["DATA_CONFERMA_CONCESSIONE"]) ? (DateTime?)null : Convert.ToDateTime(reader["DATA_CONFERMA_CONCESSIONE"]),
                                                              ANNULLATO = Convert.IsDBNull(reader["ANNULLATO"]) ? (bool?)null : (bool)reader["ANNULLATO"],
                                                              ID_OPERATORE_ANNULLAMENTO = Convert.IsDBNull(reader["ID_OPERATORE_ANNULLAMENTO"]) ? (int?)null : (int)reader["ID_OPERATORE_ANNULLAMENTO"],
                                                              DATA_INSERIMENTO = Convert.ToDateTime(reader["DATA_INSERIMENTO"]),
                                                              DATA_AGGIORNAMENTO = Convert.ToDateTime(reader["DATA_AGGIORNAMENTO"]),
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

        internal RnaProgettoCor GetRnaProgettoCorByCor(string Cor)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zRnaGetProgettoCorByCor",
                CommandType = CommandType.StoredProcedure
            };
            sqlCmd.Parameters.AddWithValue2("@Cor", Cor);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new RnaProgettoCor()
                                                          {
                                                              ID_RNA_PROGETTO_COR = int.Parse(reader["ID_RNA_PROGETTO_COR"].ToString()),
                                                              ID_PROGETTO = (int)reader["ID_PROGETTO"],
                                                              ID_PROGETTO_RNA = Convert.ToString(reader["ID_PROGETTO_RNA"]),
                                                              ID_IMPRESA = int.Parse(reader["ID_IMPRESA"].ToString()),
                                                              ID_FISCALE_IMPRESA = Convert.ToString(reader["ID_FISCALE_IMPRESA"]),
                                                              ID_RICHIESTA = Convert.ToString(reader["ID_RICHIESTA"]),
                                                              ID_OPERATORE_ASSEGNAZIONE_COR = (int)reader["ID_OPERATORE_ASSEGNAZIONE_COR"],
                                                              COR = Convert.ToString(reader["COR"]),
                                                              STATO_CONCESSIONE = Convert.ToString(reader["STATO_CONCESSIONE"]),
                                                              CONFERMATO = (bool)reader["CONFERMATO"],
                                                              DATA_ASSEGNAZIONE_COR = Convert.ToDateTime(reader["DATA_ASSEGNAZIONE_COR"]),
                                                              ID_OPERATORE_CONFERMA_CONCESSIONE = Convert.IsDBNull(reader["ID_OPERATORE_CONFERMA_CONCESSIONE"]) ? (int?)null : (int)reader["ID_OPERATORE_CONFERMA_CONCESSIONE"],
                                                              DATA_CONFERMA_CONCESSIONE = Convert.IsDBNull(reader["DATA_CONFERMA_CONCESSIONE"]) ? (DateTime?)null : Convert.ToDateTime(reader["DATA_CONFERMA_CONCESSIONE"]),
                                                              ANNULLATO = Convert.IsDBNull(reader["ANNULLATO"]) ? (bool?)null : (bool)reader["ANNULLATO"],
                                                              ID_OPERATORE_ANNULLAMENTO = Convert.IsDBNull(reader["ID_OPERATORE_ANNULLAMENTO"]) ? (int?)null : (int)reader["ID_OPERATORE_ANNULLAMENTO"],
                                                              DATA_INSERIMENTO = Convert.ToDateTime(reader["DATA_INSERIMENTO"]),
                                                              DATA_AGGIORNAMENTO = Convert.ToDateTime(reader["DATA_AGGIORNAMENTO"]),
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


        internal RnaProgettoCor GetRnaProgettoCorById(int IdRnaProgettoCor)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zRnaGetProgettoCorById",
                CommandType = CommandType.StoredProcedure
            };
            sqlCmd.Parameters.AddWithValue2("@IdRnaProgettoCor", IdRnaProgettoCor);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new RnaProgettoCor()
                                                          {
                                                              ID_RNA_PROGETTO_COR = int.Parse(reader["ID_RNA_PROGETTO_COR"].ToString()),
                                                              ID_PROGETTO = (int)reader["ID_PROGETTO"],
                                                              ID_PROGETTO_RNA = Convert.ToString(reader["ID_PROGETTO_RNA"]),
                                                              ID_IMPRESA = int.Parse(reader["ID_IMPRESA"].ToString()),
                                                              ID_FISCALE_IMPRESA = Convert.ToString(reader["ID_FISCALE_IMPRESA"]),
                                                              ID_RICHIESTA = Convert.ToString(reader["ID_RICHIESTA"]),
                                                              ID_OPERATORE_ASSEGNAZIONE_COR = (int)reader["ID_OPERATORE_ASSEGNAZIONE_COR"],
                                                              COR = Convert.ToString(reader["COR"]),
                                                              STATO_CONCESSIONE = Convert.ToString(reader["STATO_CONCESSIONE"]),
                                                              CONFERMATO = (bool)reader["CONFERMATO"],
                                                              DATA_ASSEGNAZIONE_COR = Convert.ToDateTime(reader["DATA_ASSEGNAZIONE_COR"]),
                                                              ID_OPERATORE_CONFERMA_CONCESSIONE = Convert.IsDBNull(reader["ID_OPERATORE_CONFERMA_CONCESSIONE"]) ? (int?)null : (int)reader["ID_OPERATORE_CONFERMA_CONCESSIONE"],
                                                              DATA_CONFERMA_CONCESSIONE = Convert.IsDBNull(reader["DATA_CONFERMA_CONCESSIONE"]) ? (DateTime?)null : Convert.ToDateTime(reader["DATA_CONFERMA_CONCESSIONE"]),
                                                              ANNULLATO = Convert.IsDBNull(reader["ANNULLATO"]) ? (bool?)null : (bool)reader["ANNULLATO"],
                                                              ID_OPERATORE_ANNULLAMENTO = Convert.IsDBNull(reader["ID_OPERATORE_ANNULLAMENTO"]) ? (int?)null : (int)reader["ID_OPERATORE_ANNULLAMENTO"],
                                                              DATA_INSERIMENTO = Convert.ToDateTime(reader["DATA_INSERIMENTO"]),
                                                              DATA_AGGIORNAMENTO = Convert.ToDateTime(reader["DATA_AGGIORNAMENTO"]),
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
        internal void getCredenziali(int idRnaEnte, out string username, out string cryptedPsw, out bool produzione)
        {
            try
            {
                SiarBLL.RnaEntiCollectionProvider rnaEntiCollectionProvider = new SiarBLL.RnaEntiCollectionProvider();
                SiarLibrary.RnaEntiCollection rnaEntiCollection = new SiarLibrary.RnaEntiCollection();
                rnaEntiCollection = rnaEntiCollectionProvider.Select(idRnaEnte, null, null, null, null, null, null, null, null);
                if (rnaEntiCollection.Count == 0)
                    throw new Exception("Ente non inserito nel sistema RNA");
                if (rnaEntiCollection.Count > 1)
                    throw new Exception("Credenziali duplicate nell'Ente RNA, contattare l'Helpdesk");
                if(rnaEntiCollection[0].Abilitato )
                    if(!rnaEntiCollection[0].CredenzialiProduzione)
                        throw new Exception("Comunicare le credenziali di produzione del Web Service RNA all'Helpdesk");
                username = rnaEntiCollection[0].Username;
                cryptedPsw = rnaEntiCollection[0].PasswordCrypted;
                produzione = rnaEntiCollection[0].Abilitato;
                return;
            }
            catch (Exception e)
            { throw new Exception(e.Message); }
        }
    }
}
