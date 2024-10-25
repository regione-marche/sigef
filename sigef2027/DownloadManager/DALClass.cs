using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace DownloadManager
{
    internal partial class DALClass
    {
        private string connectionString;

        internal DALClass()
        {
            ConnectionStringSettings css = ConfigurationManager.ConnectionStrings["DB_SIGEF"];
            if (css == null || string.IsNullOrEmpty(css.ConnectionString))
                throw new ConfigurationErrorsException(string.Format("ConnectionString 'DB' mancante nel file di configurazione."));

            connectionString = css.ConnectionString;
        }


        internal DownloadRequest GetDownloadRequest(int idTicket)
        {
            string sql = string.Format(@"SELECT 
                                           r.ID_PROGETTO,
                                           r.ID_DOMANDA_PAGAMENTO,
                                           r.ID_INTEGRAZIONE, 
                                           r.SEGNATURA,
                                           r.ID_TICKET                         
                                           FROM
                                           DOWNLOAD_MASSIVO_RICHIESTE r
                                           WHERE
                                           r.ID_TICKET = {0} 
                                           ", idTicket.ToString());

            var sqlCmd = new SqlCommand
            {
                CommandText = sql,
                CommandType = CommandType.Text
            };

            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new DownloadRequest()
                                                          {
                                                              IdProgetto = (int)reader["ID_PROGETTO"],
                                                              IdDomandaPagamento = Convert.IsDBNull(reader["ID_DOMANDA_PAGAMENTO"]) ? (int?)null : (int)reader["ID_DOMANDA_PAGAMENTO"],
                                                              IdIntegrazione = Convert.IsDBNull(reader["ID_INTEGRAZIONE"]) ? (int?)null : (int)reader["ID_INTEGRAZIONE"],
                                                              IdTicket = (int)reader["ID_TICKET"],
                                                              Segnatura = Convert.ToString(reader["SEGNATURA"]),
                                                          };
                                                          return o;
                                                      });
                if (list.Any())
                {
                    var tp = list[0];
                    return tp;
                }

                return null;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione della ricerca di richiesta ticket: {0}", ex.Message);
                //System.Diagnostics.Trace.WriteLine(msg,"Error");
                throw new Exception(msg, ex);
            }
        }

        internal List<DownloadRequest> GetOpenDownloadRequests()
        {
            string sql = @"SELECT 
                            r.ID_PROGETTO,
                            r.ID_DOMANDA_PAGAMENTO,
                            r.ID_INTEGRAZIONE, 
                            r.SEGNATURA,
                            r.ID_TICKET                         
                            FROM
                            DOWNLOAD_MASSIVO_RICHIESTE r
                            WHERE
                            r.ESEGUITO = 0  
                            ";

            var sqlCmd = new SqlCommand
            {
                CommandText = sql,
                CommandType = CommandType.Text
            };

            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new DownloadRequest()
                                                          {
                                                              IdProgetto = (int)reader["ID_PROGETTO"],
                                                              IdDomandaPagamento = Convert.IsDBNull(reader["ID_DOMANDA_PAGAMENTO"]) ? (int?)null : (int)reader["ID_DOMANDA_PAGAMENTO"],
                                                              IdIntegrazione = Convert.IsDBNull(reader["ID_INTEGRAZIONE"]) ? (int?)null : (int)reader["ID_INTEGRAZIONE"],
                                                              IdTicket = (int)reader["ID_TICKET"],
                                                              Segnatura = Convert.ToString(reader["SEGNATURA"]),
                                                          };
                                                          return o;
                                                      });
                if (list.Any())
                {
                    //var tp = list[0];
                    return list;
                }

                return null;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione della ricerca di richiesta ticket: {0}", ex.Message);
                //System.Diagnostics.Trace.WriteLine(msg,"Error");
                throw new Exception(msg, ex);
            }
        }


        internal void UpdateTicketStatus(int idTicket, DateTime? dataInizioEstrazione, decimal size)
        {
            string sql = string.Format(@"UPDATE
                                         DOWNLOAD_MASSIVO_RICHIESTE
                                         SET 
                                         ESEGUITO = 1,
                                         DATA_INIZIO_ESTRAZIONE = '{0}',
                                         DATA_FINE_ESTRAZIONE = GETDATE(),
                                         DATA_AGGIORNAMENTO = GETDATE(),
                                         DIMENSIONE_FILE = {2}
                                         WHERE ID_TICKET = {1}", dataInizioEstrazione.Value.ToString("yyyy-MM-dd HH:mm:ss.fff"), idTicket.ToString(), size.ToString().Replace(',','.'));

            var sqlCmd = new SqlCommand
            {
                CommandText = sql,
                CommandType = CommandType.Text
            };

            try
            {
                SqlHelper.ExecuteNonQueryCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'aggiornamento stato per il ticket {0}: {1}", idTicket, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal void UpdateDeletedStatus(int idTicket)
        {
            string sql = string.Format(@"UPDATE
                                         DOWNLOAD_MASSIVO_RICHIESTE
                                         SET 
                                         ELIMINATO = 1
                                         WHERE ID_TICKET = {0}", idTicket.ToString());

            var sqlCmd = new SqlCommand
            {
                CommandText = sql,
                CommandType = CommandType.Text
            };

            try
            {
                SqlHelper.ExecuteNonQueryCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'aggiornamento stato per il ticket {0}: {1}", idTicket, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal List<int> GetOldArchives(int days)
        {
            string sql = string.Format(@"SELECT  ID_TICKET
                                        FROM DOWNLOAD_MASSIVO_RICHIESTE
                                        WHERE   
                                        DATEDIFF(day, DATA_FINE_ESTRAZIONE, GETDATE()) >= {0} 
                                        AND 
                                        ESEGUITO = 1
                                        AND ELIMINATO = 0", days.ToString());

            var sqlCmd = new SqlCommand
            {
                CommandText = sql,
                CommandType = CommandType.Text
            };

            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = (int)reader["ID_TICKET"];
                                                          return o;
                                                      });
                if (list.Any())
                {
                    //var tp = list[0];
                    return list;
                }

                return null;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante la cancellazione dei vecchi ticket: {0}", ex.Message);
                throw new Exception(msg, ex);
            }
        }
    }
}
