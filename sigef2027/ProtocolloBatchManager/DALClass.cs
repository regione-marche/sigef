using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ProtocolloBatchManager
{
    internal partial class DALClass : IDisposable
    {
        private string connectionString;

        internal DALClass()
        {
            ConnectionStringSettings css = ConfigurationManager.ConnectionStrings["DB_SIGEF"];
            if (css == null || string.IsNullOrEmpty(css.ConnectionString))
                throw new ConfigurationErrorsException(string.Format("ConnectionString 'DB' mancante nel file di configurazione."));

            connectionString = css.ConnectionString;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


        internal List<ProgettoProtocollabile> GetProgettiProtocollabili(int idBando)
        {
            string sql = string.Format(@"SELECT 
                                           p.ID_PROGETTO, 
                                           ca.ID AS ID_ISTANZA,                          
                                           PS.SEGNATURA                          
                                           FROM
                                           vPROGETTO p
                                           inner join 
                                           vBANDO b on 
                                           p.ID_BANDO = b.ID_BANDO 
                                           INNER JOIN 
                                           vzPROGRAMMAZIONE z ON 
                                           B.ID_PROGRAMMAZIONE=z.ID
                                           INNER JOIN 
                                           FASCICOLO_PALEO F ON 
                                           F.COD_TIPO=z.COD_TIPO+' '+z.CODICE+' '+CAST(B.ID_BANDO AS VARCHAR(10)) 
                                           AND 
                                           F.ATTIVO=1 
                                           AND 
                                           B.COD_ENTE=F.COD_ENTE 
                                           AND 
                                           F.PROVINCIA='AN'
                                           INNER JOIN 
                                           BANDO_STORICO S ON 
                                           B.ID_BANDO=S.ID_BANDO 
                                           AND 
                                           S.COD_STATO <>'P'
                                           INNER JOIN 
                                           ATTI A ON 
                                           S.ID_ATTO=A.ID_ATTO
                                           INNER JOIN 
                                           BANDO_INTEGRAZIONI I ON 
                                           B.ID_INTEGRAZIONE_ULTIMA=I.ID
                                           LEFT JOIN PROGETTO_STORICO PS ON 
                                           p.ID_PROGETTO = PS.ID_PROGETTO
                                           AND
                                           PS.COD_STATO = 'L'
                                           INNER JOIN 
                                           COVID_AUTODICHIARAZIONE ca ON
                                           p.ID_PROGETTO = ca.ID_PROGETTO
                                           AND
                                           ca.DEFINITIVA = 1
                                           WHERE 
                                           p.COD_STATO = 'A'
                                           AND
                                           (PS.SEGNATURA IS NULL OR PS.SEGNATURA = '')
                                           AND
                                           b.ID_BANDO = {0} 
                                           ORDER BY 
                                           --p.ID_PROGETTO,
                                           PS.DATA ", idBando);

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
                                                          var o = new ProgettoProtocollabile()
                                                          {
                                                              IdProgetto = (int)reader["ID_PROGETTO"],
                                                              IdIstanza = (int)reader["ID_ISTANZA"],
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
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione della ricerca progetti protocollabili: {0}", ex.Message);
                //System.Diagnostics.Trace.WriteLine(msg,"Error");
                throw new Exception(msg, ex);
            }
        }


        public List<Bando> GetBandi()
        {
            string sql = @"SELECT 
                           B.ID_BANDO,
                           B.DESCRIZIONE
                           FROM vBANDO B 
                           LEFT JOIN 
                           BANDO_STORICO S ON 
                           B.ID_BANDO=S.ID_BANDO 
                           AND 
                           S.COD_STATO ='L'
                           LEFT JOIN BANDO_CONFIG BC ON
                           B.ID_BANDO = BC.ID_BANDO 
                           WHERE 
                           B.DISPOSIZIONI_ATTUATIVE=0 
                           AND
                           BC.COD_TIPO = 'BANDOCOVID' 
                           AND
                           BC.ATTIVO = 1
                           AND
                           BC.VALORE = 'True'
                           ORDER BY B.DATA_SCADENZA DESC";

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
                                                          var o = new Bando()
                                                          {
                                                              IdBando = (int)reader["ID_BANDO"],
                                                              Descrizione = Convert.ToString(reader["DESCRIZIONE"]),
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

                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione della ricerca bandi: {0}", ex.Message);
                //System.Diagnostics.Trace.WriteLine(msg,"Error");
                throw new Exception(msg, ex);
            }
        }


        internal Istanza GetProgettoById(int idProgetto)
        {
            string sql = string.Format(@"SELECT 
                                         p.ID_PROGETTO, 
                                         ca.ID AS ID_ISTANZA,
                                         ca.RAGIONE_SOCIALE,
                                         ca.PARTITA_IVA,
                                         ca.NOMINATIVO_RAPPRESENTANTE_LEGALE,
                                         af.CONTENUTO AS FILE_DOCUMENTO,
                                         ca.TOKEN_COHESION,
                                         PS.DATA AS DATA_CONFERMA,
                                         PS.SEGNATURA,
                                         p.COD_STATO, 
                                         b.ID_BANDO, 
                                         b.DESCRIZIONE AS DESCRIZIONE_BANDO,
                                         b.COD_ENTE,
                                         A.NUMERO AS NUMERO_ATTO,
                                         A.DATA AS DATA_ATTO,
                                         I.DATA_SCADENZA,
                                         z.TIPO+' '+z.CODICE AS PROGRAMMAZIONE,
                                         F.FASCICOLO
                                         from
                                         vPROGETTO p
                                         inner join 
                                         vBANDO b on 
                                         p.ID_BANDO = b.ID_BANDO 
                                         INNER JOIN 
                                         vzPROGRAMMAZIONE z ON 
                                         B.ID_PROGRAMMAZIONE=z.ID
                                         INNER JOIN 
                                         FASCICOLO_PALEO F ON 
                                         F.COD_TIPO=z.COD_TIPO+' '+z.CODICE+' '+CAST(B.ID_BANDO AS VARCHAR(10)) 
                                         AND 
                                         F.ATTIVO=1 
                                         AND 
                                         B.COD_ENTE=F.COD_ENTE 
                                         AND 
                                         F.PROVINCIA='AN'
                                         INNER JOIN 
                                         BANDO_STORICO S ON 
                                         B.ID_BANDO=S.ID_BANDO 
                                         AND 
                                         S.COD_STATO <>'P'
                                         INNER JOIN 
                                         ATTI A ON 
                                         S.ID_ATTO=A.ID_ATTO
                                         INNER JOIN 
                                         BANDO_INTEGRAZIONI I ON 
                                         B.ID_INTEGRAZIONE_ULTIMA=I.ID
                                         LEFT JOIN PROGETTO_STORICO PS ON 
                                         p.ID_PROGETTO = PS.ID_PROGETTO
                                         AND
                                         PS.COD_STATO = 'L'
                                         INNER JOIN 
                                         COVID_AUTODICHIARAZIONE ca ON
                                         p.ID_PROGETTO = ca.ID_PROGETTO
                                         AND
                                         ca.DEFINITIVA = 1
                                         LEFT JOIN 
                                         ARCHIVIO_FILE af ON
                                         ca.ID_FILE_DOMANDA = af.ID
                                         WHERE 
                                         p.COD_STATO = 'A'
                                         AND
                                         p.ID_PROGETTO = {0} 
                                         --ORDER BY 
                                         --b.ID_BANDO,
                                         --PS.DATA ", idProgetto);

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
                                                          var o = new Istanza()
                                                          {
                                                              IdIstanza = (int)reader["ID_ISTANZA"],
                                                              IdProgetto = (int)reader["ID_PROGETTO"],
                                                              RagioneSociale = Convert.ToString(reader["RAGIONE_SOCIALE"]),
                                                              PartitaIva = Convert.ToString(reader["PARTITA_IVA"]),
                                                              RappresentanteLegale = Convert.ToString(reader["NOMINATIVO_RAPPRESENTANTE_LEGALE"]),
                                                              FileDocumento = (byte[])reader["FILE_DOCUMENTO"],
                                                              TokenCohesion = Convert.ToString(reader["TOKEN_COHESION"]),
                                                              DataConferma = Convert.ToDateTime(reader["DATA_CONFERMA"]),
                                                              Segnatura = Convert.ToString(reader["SEGNATURA"]),
                                                              CodiceStatoProgetto = Convert.ToString(reader["COD_STATO"]),
                                                              IdBando = (int)reader["ID_BANDO"],
                                                              DescrizioneBando = Convert.ToString(reader["DESCRIZIONE_BANDO"]),
                                                              CodiceEnte = Convert.ToString(reader["COD_ENTE"]),
                                                              NumeroAtto = Convert.ToString(reader["NUMERO_ATTO"]),
                                                              DataAtto = Convert.ToDateTime(reader["DATA_ATTO"]),
                                                              DataScadenza = Convert.ToDateTime(reader["DATA_SCADENZA"]),
                                                              Programmazione = Convert.ToString(reader["PROGRAMMAZIONE"]),
                                                              Fascicolo = Convert.ToString(reader["FASCICOLO"]),
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
                var msg = string.Format("Si è verificato il seguente errore durante la ricerca del progetto {0}: {1}", idProgetto.ToString(), ex.Message);
                //System.Diagnostics.Trace.WriteLine(msg,"Error");
                throw new Exception(msg, ex);
            }
        }


        internal void InsertSegnaturaProgetto(int idProgetto, string segnatura)
        {
            string sql = string.Format(@"UPDATE
                                         PROGETTO_STORICO
                                         SET SEGNATURA = '{0}'
                                         WHERE ID_PROGETTO = {1}
                                         AND COD_STATO IN ('L','I','A')", segnatura, idProgetto);

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
                var msg = string.Format("Si è verificato il seguente errore durante l'inserimento della segnatura per il progetto {0}: {1}", idProgetto, ex.Message);
                throw new Exception(msg, ex);
            }
        }


        internal void InserLogProtocollo(ProtocolloLog protocolloLog)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zInsertProtocolloLog",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@IdProgetto", protocolloLog.IdProgetto);
                sqlCmd.Parameters.AddWithValue2("@Segnatura", protocolloLog.Segnatura);
                sqlCmd.Parameters.AddWithValue2("@DataRichiesta", protocolloLog.DataRichiesta);
                sqlCmd.Parameters.AddWithValue2("@DataRisposta", protocolloLog.DataRisposta);
                sqlCmd.Parameters.AddWithValue2("@Esito", protocolloLog.Esito);
                sqlCmd.Parameters.AddWithValue2("@DescrizioneEsito", protocolloLog.DescrizioneEsito);

                protocolloLog.IdProtocolloLog = (int)SqlHelper.ExecuteScalarCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }
    }
}
