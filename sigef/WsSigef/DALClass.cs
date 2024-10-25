using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using SiarLibrary;
using System.Transactions;
using SiarBLL;
using System.Web.UI;
using SiarLibrary.Extensions;
using SiarLibrary.NullTypes;
using System.Runtime.InteropServices.WindowsRuntime;

namespace WsSigef
{
    internal partial class DALClass
    {
        private string connectionString;
        private int idStandardChecklist;
        private int idQuadroPianoInvestimenti;
        private int idQuadroMonitoraggio;
        private int idQuadroLocalizzazione;
        private List<int> idPrioritaSetMinimoSingole;
        private List<int> idPrioritaSetMinimoGruppi;
        private int idSchedaValutazioneSingole;
        private int idSchedaValutazioneGruppi;
        private List<int> idRequisitiSetMinimoAnticipo;
        private List<int> idRequisitiSetMinimoSal;
        private List<int> idRequisitiSetMinimoSaldo;
        private List<int> idRequisitiSetMinimoVariante;
        private int idRequisitoControllo;
        private int idRequisitoVarianteControllo;
        private List<int> idRequisitiVarianteControllo;
        //private int idModelloDomanda;

        internal DALClass()
        {
            ConnectionStringSettings css = ConfigurationManager.ConnectionStrings["DB_SIGEF"];
            if (css == null || string.IsNullOrEmpty(css.ConnectionString))
                throw new ConfigurationErrorsException(string.Format("ConnectionString 'DB' mancante nel file di configurazione."));

            connectionString = css.ConnectionString;
            idStandardChecklist = int.Parse(ConfigurationManager.AppSettings["id_standard_checklist"].ToString());
            idQuadroPianoInvestimenti = int.Parse(ConfigurationManager.AppSettings["id_quadro_investimenti"].ToString());
            idQuadroMonitoraggio = int.Parse(ConfigurationManager.AppSettings["id_quadro_monitoraggio"].ToString());
            idQuadroLocalizzazione = int.Parse(ConfigurationManager.AppSettings["id_quadro_localizzazione"].ToString());
            string idPrioritaSingole = ConfigurationManager.AppSettings["id_priorita_set_minimo_singole"].ToString();
            string idPrioritaGruppi = ConfigurationManager.AppSettings["id_priorita_set_minimo_gruppi"].ToString();
            string idRequisitiAnticipo = ConfigurationManager.AppSettings["id_requisiti_pag_anticipo"].ToString();
            string idRequisitiSal = ConfigurationManager.AppSettings["id_requisiti_pag_sal"].ToString();
            string idRequisitiSaldo = ConfigurationManager.AppSettings["id_requisiti_pag_saldo"].ToString();
            string idRequisitiVariante = ConfigurationManager.AppSettings["id_requisiti_variante"].ToString();
            string idRequisitiVarControllo = ConfigurationManager.AppSettings["id_requisiti_var_controllo"].ToString();
            idPrioritaSetMinimoSingole = idPrioritaSingole.Split(',').Select(i => int.Parse(i)).ToList();
            idPrioritaSetMinimoGruppi = idPrioritaGruppi.Split(',').Select(i => int.Parse(i)).ToList();
            idSchedaValutazioneSingole = int.Parse(ConfigurationManager.AppSettings["id_scheda_valutazione_singole"].ToString());
            idSchedaValutazioneGruppi = int.Parse(ConfigurationManager.AppSettings["id_scheda_valutazione_gruppi"].ToString());
            idRequisitiSetMinimoAnticipo = idRequisitiAnticipo.Split(',').Select(i => int.Parse(i)).ToList();
            idRequisitiSetMinimoSal = idRequisitiSal.Split(',').Select(i => int.Parse(i)).ToList();
            idRequisitiSetMinimoSaldo = idRequisitiSaldo.Split(',').Select(i => int.Parse(i)).ToList();
            idRequisitoControllo = int.Parse(ConfigurationManager.AppSettings["id_requisito_pag_controllo"].ToString());
            idRequisitiSetMinimoVariante = idRequisitiVariante.Split(',').Select(i => int.Parse(i)).ToList();
            idRequisitoVarianteControllo = int.Parse(ConfigurationManager.AppSettings["id_requisito_var_controllo"].ToString());
            idRequisitiVarianteControllo = idRequisitiVarControllo.Split(',').Select(i => int.Parse(i)).ToList();
            //idModelloDomanda = int.Parse(ConfigurationManager.AppSettings["id_modello_domanda"].ToString());
        }

        #region metodi CRUD per log progetti

        internal void InsertImportServiceLogProgetti(ImportServiceLogProgetto importServiceLogProgetto)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zImportServiceInsertLogProgetti",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@SistemaMittente", importServiceLogProgetto.SistemaMittente);
                sqlCmd.Parameters.AddWithValue2("@IstanzaRichiesta", importServiceLogProgetto.IstanzaRichiesta);
                sqlCmd.Parameters.AddWithValue2("@IstanzaRisposta", importServiceLogProgetto.IstanzaRisposta);
                sqlCmd.Parameters.AddWithValue2("@Esito", importServiceLogProgetto.Esito);
                sqlCmd.Parameters.AddWithValue2("@Errore", importServiceLogProgetto.Errore);
                sqlCmd.Parameters.AddWithValue2("@DataRichiesta", importServiceLogProgetto.DataRichiesta);
                sqlCmd.Parameters.AddWithValue2("@DataRisposta", importServiceLogProgetto.DataRisposta);
                sqlCmd.Parameters.AddWithValue2("@Importato", importServiceLogProgetto.Importato);
                sqlCmd.Parameters.AddWithValue2("@DataAcquisizione", importServiceLogProgetto.DataAcquisizione);
                sqlCmd.Parameters.AddWithValue2("@IdProgetto", importServiceLogProgetto.IdProgetto);

                importServiceLogProgetto.IdImportServiceLogProgetto = (int)SqlHelper.ExecuteScalarCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal void UpdateImportServiceLogProgetti(ImportServiceLogProgetto importServiceLogProgetto)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zImportServiceUpdateLogProgetti",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@IdImportServiceLogProgetto", importServiceLogProgetto.IdImportServiceLogProgetto);
                sqlCmd.Parameters.AddWithValue2("@SistemaMittente", importServiceLogProgetto.SistemaMittente);
                sqlCmd.Parameters.AddWithValue2("@IstanzaRichiesta", importServiceLogProgetto.IstanzaRichiesta);
                sqlCmd.Parameters.AddWithValue2("@IstanzaRisposta", importServiceLogProgetto.IstanzaRisposta);
                sqlCmd.Parameters.AddWithValue2("@Esito", importServiceLogProgetto.Esito);
                sqlCmd.Parameters.AddWithValue2("@Errore", importServiceLogProgetto.Errore);
                sqlCmd.Parameters.AddWithValue2("@DataRichiesta", importServiceLogProgetto.DataRichiesta);
                sqlCmd.Parameters.AddWithValue2("@DataRisposta", importServiceLogProgetto.DataRisposta);
                sqlCmd.Parameters.AddWithValue2("@Importato", importServiceLogProgetto.Importato);
                sqlCmd.Parameters.AddWithValue2("@DataAcquisizione", importServiceLogProgetto.DataAcquisizione);
                sqlCmd.Parameters.AddWithValue2("@IdProgetto", importServiceLogProgetto.IdProgetto);

                SqlHelper.ExecuteNonQueryCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal void DeleteImportServiceLogProgetti(int idImportServiceLogProgetto)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zImportServiceDeleteLogProgetti",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@IdImportServiceLogProgetto", idImportServiceLogProgetto);

                SqlHelper.ExecuteNonQueryCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {

                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal ImportServiceLogProgetto GetLogProgettoById(int idImportServiceLogProgetto, bool getXmlRequest, bool getXmlResponse)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zImportServiceGetLogProgettiById",
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.AddWithValue2("@IdImportServiceLogProgetto", idImportServiceLogProgetto);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new ImportServiceLogProgetto()
                                                          {
                                                              SistemaMittente = SqlHelper.GetValueOrDefault<string>(reader["SISTEMA_MITTENTE"]),
                                                              IstanzaRichiesta = getXmlRequest ? SqlHelper.GetValueOrDefault<string>(reader["ISTANZA_RICHIESTA"]) : null,
                                                              IstanzaRisposta = getXmlResponse ? SqlHelper.GetValueOrDefault<string>(reader["ISTANZA_RISPOSTA"]) : null,
                                                              Esito = SqlHelper.GetValueOrDefault<string>(reader["ESITO"]),
                                                              Errore = SqlHelper.GetValueOrDefault<string>(reader["ERRORE"]),
                                                              DataRichiesta = SqlHelper.GetValueOrDefault<DateTime?>(reader["DATA_RICHIESTA"]),
                                                              DataRisposta = SqlHelper.GetValueOrDefault<DateTime?>(reader["DATA_RISPOSTA"]),
                                                              Importato = SqlHelper.GetValueOrDefault<bool>(reader["IMPORTATO"]),
                                                              DataAcquisizione = SqlHelper.GetValueOrDefault<DateTime?>(reader["DATA_ACQUISIZIONE"]),
                                                              IdProgetto = SqlHelper.GetValueOrDefault<int?>(reader["ID_PROGETTO"]),
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

                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione della richiesta: {0}", ex.Message);
                throw new Exception(msg, ex);
            }

        }

        internal List<ImportServiceLogProgetto> GetLogProgettoByIdProgetto(int idProgetto, bool getXmlRequest, bool getXmlResponse)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zImportServiceGetLogProgettiByIdProgetto",
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.AddWithValue2("@IdProgetto", idProgetto);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new ImportServiceLogProgetto()
                                                          {
                                                              SistemaMittente = SqlHelper.GetValueOrDefault<string>(reader["SISTEMA_MITTENTE"]),
                                                              IstanzaRichiesta = getXmlRequest ? SqlHelper.GetValueOrDefault<string>(reader["ISTANZA_RICHIESTA"]) : null,
                                                              IstanzaRisposta = getXmlResponse ? SqlHelper.GetValueOrDefault<string>(reader["ISTANZA_RISPOSTA"]) : null,
                                                              Esito = SqlHelper.GetValueOrDefault<string>(reader["ESITO"]),
                                                              Errore = SqlHelper.GetValueOrDefault<string>(reader["ERRORE"]),
                                                              DataRichiesta = SqlHelper.GetValueOrDefault<DateTime?>(reader["DATA_RICHIESTA"]),
                                                              DataRisposta = SqlHelper.GetValueOrDefault<DateTime?>(reader["DATA_RISPOSTA"]),
                                                              Importato = SqlHelper.GetValueOrDefault<bool>(reader["IMPORTATO"]),
                                                              DataAcquisizione = SqlHelper.GetValueOrDefault<DateTime?>(reader["DATA_ACQUISIZIONE"]),
                                                              IdProgetto = SqlHelper.GetValueOrDefault<int?>(reader["ID_PROGETTO"]),
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

                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione della richiesta: {0}", ex.Message);
                throw new Exception(msg, ex);
            }
        }

        #endregion

        #region metodi CRUD per log bandi

        internal void InsertImportServiceLogBandi(ImportServiceLogBando importServiceLogBando)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zImportServiceInsertLogBandi",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@SistemaMittente", importServiceLogBando.SistemaMittente);
                sqlCmd.Parameters.AddWithValue2("@IstanzaRichiesta", importServiceLogBando.IstanzaRichiesta);
                sqlCmd.Parameters.AddWithValue2("@IstanzaRisposta", importServiceLogBando.IstanzaRisposta);
                sqlCmd.Parameters.AddWithValue2("@Esito", importServiceLogBando.Esito);
                sqlCmd.Parameters.AddWithValue2("@Errore", importServiceLogBando.Errore);
                sqlCmd.Parameters.AddWithValue2("@DataRichiesta", importServiceLogBando.DataRichiesta);
                sqlCmd.Parameters.AddWithValue2("@DataRisposta", importServiceLogBando.DataRisposta);
                sqlCmd.Parameters.AddWithValue2("@Importato", importServiceLogBando.Importato);
                sqlCmd.Parameters.AddWithValue2("@DataAcquisizione", importServiceLogBando.DataAcquisizione);
                sqlCmd.Parameters.AddWithValue2("@IdBando", importServiceLogBando.IdBando);

                importServiceLogBando.IdImportServiceLogBando = (int)SqlHelper.ExecuteScalarCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal void UpdateImportServiceLogBandi(ImportServiceLogBando importServiceLogBando)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zImportServiceUpdateLogBandi",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@IdImportServiceLogBando", importServiceLogBando.IdImportServiceLogBando);
                sqlCmd.Parameters.AddWithValue2("@SistemaMittente", importServiceLogBando.SistemaMittente);
                sqlCmd.Parameters.AddWithValue2("@IstanzaRichiesta", importServiceLogBando.IstanzaRichiesta);
                sqlCmd.Parameters.AddWithValue2("@IstanzaRisposta", importServiceLogBando.IstanzaRisposta);
                sqlCmd.Parameters.AddWithValue2("@Esito", importServiceLogBando.Esito);
                sqlCmd.Parameters.AddWithValue2("@Errore", importServiceLogBando.Errore);
                sqlCmd.Parameters.AddWithValue2("@DataRichiesta", importServiceLogBando.DataRichiesta);
                sqlCmd.Parameters.AddWithValue2("@DataRisposta", importServiceLogBando.DataRisposta);
                sqlCmd.Parameters.AddWithValue2("@Importato", importServiceLogBando.Importato);
                sqlCmd.Parameters.AddWithValue2("@DataAcquisizione", importServiceLogBando.DataAcquisizione);
                sqlCmd.Parameters.AddWithValue2("@IdBando", importServiceLogBando.IdBando);

                SqlHelper.ExecuteNonQueryCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal void DeleteImportServiceLogBandi(int idImportServiceLogBando)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zImportServiceDeleteLogBandi",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@IdImportServiceLogBando", idImportServiceLogBando);

                SqlHelper.ExecuteNonQueryCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {

                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal ImportServiceLogBando GetLogBandoById(int idImportServiceLogBando, bool getXmlRequest, bool getXmlResponse)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zImportServiceGetLogBandiById",
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.AddWithValue2("@IdImportServiceLogBando", idImportServiceLogBando);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new ImportServiceLogBando()
                                                          {
                                                              SistemaMittente = SqlHelper.GetValueOrDefault<string>(reader["SISTEMA_MITTENTE"]),
                                                              IstanzaRichiesta = getXmlRequest ? SqlHelper.GetValueOrDefault<string>(reader["ISTANZA_RICHIESTA"]) : null,
                                                              IstanzaRisposta = getXmlResponse ? SqlHelper.GetValueOrDefault<string>(reader["ISTANZA_RISPOSTA"]) : null,
                                                              Esito = SqlHelper.GetValueOrDefault<string>(reader["ESITO"]),
                                                              Errore = SqlHelper.GetValueOrDefault<string>(reader["ERRORE"]),
                                                              DataRichiesta = SqlHelper.GetValueOrDefault<DateTime?>(reader["DATA_RICHIESTA"]),
                                                              DataRisposta = SqlHelper.GetValueOrDefault<DateTime?>(reader["DATA_RISPOSTA"]),
                                                              Importato = SqlHelper.GetValueOrDefault<bool>(reader["IMPORTATO"]),
                                                              DataAcquisizione = SqlHelper.GetValueOrDefault<DateTime?>(reader["DATA_ACQUISIZIONE"]),
                                                              IdBando = SqlHelper.GetValueOrDefault<int?>(reader["ID_BANDO"]),
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

                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione della richiesta: {0}", ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal List<ImportServiceLogBando> GetLogBandoByIdBando(int idBando, bool getXmlRequest, bool getXmlResponse)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zImportServiceGetLogBandiByIdBando",
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.AddWithValue2("@IdBando", idBando);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new ImportServiceLogBando()
                                                          {
                                                              SistemaMittente = SqlHelper.GetValueOrDefault<string>(reader["SISTEMA_MITTENTE"]),
                                                              IstanzaRichiesta = getXmlRequest ? SqlHelper.GetValueOrDefault<string>(reader["ISTANZA_RICHIESTA"]) : null,
                                                              IstanzaRisposta = getXmlResponse ? SqlHelper.GetValueOrDefault<string>(reader["ISTANZA_RISPOSTA"]) : null,
                                                              Esito = SqlHelper.GetValueOrDefault<string>(reader["ESITO"]),
                                                              Errore = SqlHelper.GetValueOrDefault<string>(reader["ERRORE"]),
                                                              DataRichiesta = SqlHelper.GetValueOrDefault<DateTime?>(reader["DATA_RICHIESTA"]),
                                                              DataRisposta = SqlHelper.GetValueOrDefault<DateTime?>(reader["DATA_RISPOSTA"]),
                                                              Importato = SqlHelper.GetValueOrDefault<bool>(reader["IMPORTATO"]),
                                                              DataAcquisizione = SqlHelper.GetValueOrDefault<DateTime?>(reader["DATA_ACQUISIZIONE"]),
                                                              IdBando = SqlHelper.GetValueOrDefault<int?>(reader["ID_BANDO"]),
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

                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione della richiesta: {0}", ex.Message);
                throw new Exception(msg, ex);
            }
        }
        #endregion

        #region metodi CRUD per log domande pagamento

        internal void InsertImportServiceLogDomandePagamento(ImportServiceLogDomandaPagamento importServiceLogDomandaPagamento)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zImportServiceInsertLogDomandePagamento",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@SistemaMittente", importServiceLogDomandaPagamento.SistemaMittente);
                sqlCmd.Parameters.AddWithValue2("@IstanzaRichiesta", importServiceLogDomandaPagamento.IstanzaRichiesta);
                sqlCmd.Parameters.AddWithValue2("@IstanzaRisposta", importServiceLogDomandaPagamento.IstanzaRisposta);
                sqlCmd.Parameters.AddWithValue2("@Esito", importServiceLogDomandaPagamento.Esito);
                sqlCmd.Parameters.AddWithValue2("@Errore", importServiceLogDomandaPagamento.Errore);
                sqlCmd.Parameters.AddWithValue2("@DataRichiesta", importServiceLogDomandaPagamento.DataRichiesta);
                sqlCmd.Parameters.AddWithValue2("@DataRisposta", importServiceLogDomandaPagamento.DataRisposta);
                sqlCmd.Parameters.AddWithValue2("@Importato", importServiceLogDomandaPagamento.Importato);
                sqlCmd.Parameters.AddWithValue2("@DataAcquisizione", importServiceLogDomandaPagamento.DataAcquisizione);
                sqlCmd.Parameters.AddWithValue2("@IdDomandaPagamento", importServiceLogDomandaPagamento.IdDomandaPagamento);

                importServiceLogDomandaPagamento.IdImportServiceLogDomandaPagamento = (int)SqlHelper.ExecuteScalarCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal void UpdateImportServiceLogDomandePagamento(ImportServiceLogDomandaPagamento importServiceLogDomandaPagamento)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zImportServiceUpdateLogDomandePagamento",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@IdImportServiceLogDomandaPagamento", importServiceLogDomandaPagamento.IdImportServiceLogDomandaPagamento);
                sqlCmd.Parameters.AddWithValue2("@SistemaMittente", importServiceLogDomandaPagamento.SistemaMittente);
                sqlCmd.Parameters.AddWithValue2("@IstanzaRichiesta", importServiceLogDomandaPagamento.IstanzaRichiesta);
                sqlCmd.Parameters.AddWithValue2("@IstanzaRisposta", importServiceLogDomandaPagamento.IstanzaRisposta);
                sqlCmd.Parameters.AddWithValue2("@Esito", importServiceLogDomandaPagamento.Esito);
                sqlCmd.Parameters.AddWithValue2("@Errore", importServiceLogDomandaPagamento.Errore);
                sqlCmd.Parameters.AddWithValue2("@DataRichiesta", importServiceLogDomandaPagamento.DataRichiesta);
                sqlCmd.Parameters.AddWithValue2("@DataRisposta", importServiceLogDomandaPagamento.DataRisposta);
                sqlCmd.Parameters.AddWithValue2("@Importato", importServiceLogDomandaPagamento.Importato);
                sqlCmd.Parameters.AddWithValue2("@DataAcquisizione", importServiceLogDomandaPagamento.DataAcquisizione);
                sqlCmd.Parameters.AddWithValue2("@IdDomandaPagamento", importServiceLogDomandaPagamento.IdDomandaPagamento);

                SqlHelper.ExecuteNonQueryCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal void DeleteImportServiceLogDomandePagamento(int idImportServiceLogDomandaPagamento)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zImportServiceDeleteLogDomandePagamento",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@IdImportServiceLogDomandaPagamento", idImportServiceLogDomandaPagamento);

                SqlHelper.ExecuteNonQueryCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {

                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal ImportServiceLogDomandaPagamento GetLogDomandaPagamentoById(int idImportServiceLogDomandaPagamento, bool getXmlRequest, bool getXmlResponse)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zImportServiceGetLogDomandePagamentoById",
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.AddWithValue2("@IdImportServiceLogDomandaPagamento", idImportServiceLogDomandaPagamento);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new ImportServiceLogDomandaPagamento()
                                                          {
                                                              SistemaMittente = SqlHelper.GetValueOrDefault<string>(reader["SISTEMA_MITTENTE"]),
                                                              IstanzaRichiesta = getXmlRequest ? SqlHelper.GetValueOrDefault<string>(reader["ISTANZA_RICHIESTA"]) : null,
                                                              IstanzaRisposta = getXmlResponse ? SqlHelper.GetValueOrDefault<string>(reader["ISTANZA_RISPOSTA"]) : null,
                                                              Esito = SqlHelper.GetValueOrDefault<string>(reader["ESITO"]),
                                                              Errore = SqlHelper.GetValueOrDefault<string>(reader["ERRORE"]),
                                                              DataRichiesta = SqlHelper.GetValueOrDefault<DateTime?>(reader["DATA_RICHIESTA"]),
                                                              DataRisposta = SqlHelper.GetValueOrDefault<DateTime?>(reader["DATA_RISPOSTA"]),
                                                              Importato = SqlHelper.GetValueOrDefault<bool>(reader["IMPORTATO"]),
                                                              DataAcquisizione = SqlHelper.GetValueOrDefault<DateTime?>(reader["DATA_ACQUISIZIONE"]),
                                                              IdDomandaPagamento = SqlHelper.GetValueOrDefault<int?>(reader["ID_DOMANDA_PAGAMENTO"]),
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

                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione della richiesta: {0}", ex.Message);
                throw new Exception(msg, ex);
            }

        }

        internal List<ImportServiceLogDomandaPagamento> GetLogDomandaPagamentoByIdDomandaPagamento(int idDomandaPagamento, bool getXmlRequest, bool getXmlResponse)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zImportServiceGetLogDomandePagamentoByIdDomandaPagamento",
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.AddWithValue2("@IdDomandaPagamento", idDomandaPagamento);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new ImportServiceLogDomandaPagamento()
                                                          {
                                                              SistemaMittente = SqlHelper.GetValueOrDefault<string>(reader["SISTEMA_MITTENTE"]),
                                                              IstanzaRichiesta = getXmlRequest ? SqlHelper.GetValueOrDefault<string>(reader["ISTANZA_RICHIESTA"]) : null,
                                                              IstanzaRisposta = getXmlResponse ? SqlHelper.GetValueOrDefault<string>(reader["ISTANZA_RISPOSTA"]) : null,
                                                              Esito = SqlHelper.GetValueOrDefault<string>(reader["ESITO"]),
                                                              Errore = SqlHelper.GetValueOrDefault<string>(reader["ERRORE"]),
                                                              DataRichiesta = SqlHelper.GetValueOrDefault<DateTime?>(reader["DATA_RICHIESTA"]),
                                                              DataRisposta = SqlHelper.GetValueOrDefault<DateTime?>(reader["DATA_RISPOSTA"]),
                                                              Importato = SqlHelper.GetValueOrDefault<bool>(reader["IMPORTATO"]),
                                                              DataAcquisizione = SqlHelper.GetValueOrDefault<DateTime?>(reader["DATA_ACQUISIZIONE"]),
                                                              IdDomandaPagamento = SqlHelper.GetValueOrDefault<int?>(reader["ID_DOMANDA_PAGAMENTO"]),
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

                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione della richiesta: {0}", ex.Message);
                throw new Exception(msg, ex);
            }
        }


        #endregion

        #region metodi CRUD per log varianti

        internal void InsertImportServiceLogVarianti(ImportServiceLogVariante importServiceLogVariante)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zImportServiceInsertLogVarianti",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@SistemaMittente", importServiceLogVariante.SistemaMittente);
                sqlCmd.Parameters.AddWithValue2("@IstanzaRichiesta", importServiceLogVariante.IstanzaRichiesta);
                sqlCmd.Parameters.AddWithValue2("@IstanzaRisposta", importServiceLogVariante.IstanzaRisposta);
                sqlCmd.Parameters.AddWithValue2("@Esito", importServiceLogVariante.Esito);
                sqlCmd.Parameters.AddWithValue2("@Errore", importServiceLogVariante.Errore);
                sqlCmd.Parameters.AddWithValue2("@DataRichiesta", importServiceLogVariante.DataRichiesta);
                sqlCmd.Parameters.AddWithValue2("@DataRisposta", importServiceLogVariante.DataRisposta);
                sqlCmd.Parameters.AddWithValue2("@Importato", importServiceLogVariante.Importato);
                sqlCmd.Parameters.AddWithValue2("@DataAcquisizione", importServiceLogVariante.DataAcquisizione);
                sqlCmd.Parameters.AddWithValue2("@IdVariante", importServiceLogVariante.IdVariante);

                importServiceLogVariante.IdImportServiceLogVariante = (int)SqlHelper.ExecuteScalarCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal void UpdateImportServiceLogVarianti(ImportServiceLogVariante importServiceLogVariante)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zImportServiceUpdateLogVarianti",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@IdImportServiceLogVariante", importServiceLogVariante.IdImportServiceLogVariante);
                sqlCmd.Parameters.AddWithValue2("@SistemaMittente", importServiceLogVariante.SistemaMittente);
                sqlCmd.Parameters.AddWithValue2("@IstanzaRichiesta", importServiceLogVariante.IstanzaRichiesta);
                sqlCmd.Parameters.AddWithValue2("@IstanzaRisposta", importServiceLogVariante.IstanzaRisposta);
                sqlCmd.Parameters.AddWithValue2("@Esito", importServiceLogVariante.Esito);
                sqlCmd.Parameters.AddWithValue2("@Errore", importServiceLogVariante.Errore);
                sqlCmd.Parameters.AddWithValue2("@DataRichiesta", importServiceLogVariante.DataRichiesta);
                sqlCmd.Parameters.AddWithValue2("@DataRisposta", importServiceLogVariante.DataRisposta);
                sqlCmd.Parameters.AddWithValue2("@Importato", importServiceLogVariante.Importato);
                sqlCmd.Parameters.AddWithValue2("@DataAcquisizione", importServiceLogVariante.DataAcquisizione);
                sqlCmd.Parameters.AddWithValue2("@IdVariante", importServiceLogVariante.IdVariante);

                SqlHelper.ExecuteNonQueryCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal void DeleteImportServiceLogVarianti(int idImportServiceLogVariante)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zImportServiceDeleteLogVarianti",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@IdImportServiceLogVariante", idImportServiceLogVariante);

                SqlHelper.ExecuteNonQueryCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {

                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal ImportServiceLogVariante GetLogVarianteById(int idImportServiceLogVariante, bool getXmlRequest, bool getXmlResponse)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zImportServiceGetLogVariantiById",
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.AddWithValue2("@IdImportServiceLogVariante", idImportServiceLogVariante);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new ImportServiceLogVariante()
                                                          {
                                                              SistemaMittente = SqlHelper.GetValueOrDefault<string>(reader["SISTEMA_MITTENTE"]),
                                                              IstanzaRichiesta = getXmlRequest ? SqlHelper.GetValueOrDefault<string>(reader["ISTANZA_RICHIESTA"]) : null,
                                                              IstanzaRisposta = getXmlResponse ? SqlHelper.GetValueOrDefault<string>(reader["ISTANZA_RISPOSTA"]) : null,
                                                              Esito = SqlHelper.GetValueOrDefault<string>(reader["ESITO"]),
                                                              Errore = SqlHelper.GetValueOrDefault<string>(reader["ERRORE"]),
                                                              DataRichiesta = SqlHelper.GetValueOrDefault<DateTime?>(reader["DATA_RICHIESTA"]),
                                                              DataRisposta = SqlHelper.GetValueOrDefault<DateTime?>(reader["DATA_RISPOSTA"]),
                                                              Importato = SqlHelper.GetValueOrDefault<bool>(reader["IMPORTATO"]),
                                                              DataAcquisizione = SqlHelper.GetValueOrDefault<DateTime?>(reader["DATA_ACQUISIZIONE"]),
                                                              IdVariante = SqlHelper.GetValueOrDefault<int?>(reader["ID_VARIANTE"]),
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

                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione della richiesta: {0}", ex.Message);
                throw new Exception(msg, ex);
            }

        }

        internal List<ImportServiceLogVariante> GetLogVarianteByIdVariante(int idVariante, bool getXmlRequest, bool getXmlResponse)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zImportServiceGetLogVariantiByIdVariante",
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.AddWithValue2("@IdVariante", idVariante);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new ImportServiceLogVariante()
                                                          {
                                                              SistemaMittente = SqlHelper.GetValueOrDefault<string>(reader["SISTEMA_MITTENTE"]),
                                                              IstanzaRichiesta = getXmlRequest ? SqlHelper.GetValueOrDefault<string>(reader["ISTANZA_RICHIESTA"]) : null,
                                                              IstanzaRisposta = getXmlResponse ? SqlHelper.GetValueOrDefault<string>(reader["ISTANZA_RISPOSTA"]) : null,
                                                              Esito = SqlHelper.GetValueOrDefault<string>(reader["ESITO"]),
                                                              Errore = SqlHelper.GetValueOrDefault<string>(reader["ERRORE"]),
                                                              DataRichiesta = SqlHelper.GetValueOrDefault<DateTime?>(reader["DATA_RICHIESTA"]),
                                                              DataRisposta = SqlHelper.GetValueOrDefault<DateTime?>(reader["DATA_RISPOSTA"]),
                                                              Importato = SqlHelper.GetValueOrDefault<bool>(reader["IMPORTATO"]),
                                                              DataAcquisizione = SqlHelper.GetValueOrDefault<DateTime?>(reader["DATA_ACQUISIZIONE"]),
                                                              IdVariante = SqlHelper.GetValueOrDefault<int?>(reader["ID_VARIANTE"]),
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

                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione della richiesta: {0}", ex.Message);
                throw new Exception(msg, ex);
            }
        }

        #endregion



        internal ImportServiceSistemaCensito GetSistemaCensitoByCodice(string codiceSistema)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zImportServiceGetSistemaCensitoByCodice",
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.AddWithValue2("@CodiceSistema", codiceSistema);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new ImportServiceSistemaCensito()
                                                          {
                                                              IdImportServiceSistemaCensito = SqlHelper.GetValueOrDefault<int>(reader["ID_IMPORT_SERVICE_SISTEMA_CENSITO"]),
                                                              CodiceSistema = SqlHelper.GetValueOrDefault<string>(reader["CODICE_SISTEMA"]),
                                                              DataInizioValidita = SqlHelper.GetValueOrDefault<DateTime?>(reader["DATA_INIZIO_VALIDITA"]),
                                                              DataFineValidita = SqlHelper.GetValueOrDefault<DateTime?>(reader["DATA_FINE_VALIDITA"]),
                                                              FlagAbilitato = SqlHelper.GetValueOrDefault<bool?>(reader["FLAG_ABILITATO"]),
                                                              DataInserimento = SqlHelper.GetValueOrDefault<DateTime?>(reader["DATA_INSERIMENTO"]),
                                                              DataAggiornamento = SqlHelper.GetValueOrDefault<DateTime?>(reader["DATA_AGGIORNAMENTO"]),
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

                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione della richiesta: {0}", ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal PrioritaCollection GetSetMinimo(List<int> ids)
        {
            SiarBLL.PrioritaCollectionProvider priorita_provider = new PrioritaCollectionProvider();
            PrioritaCollection setMinimo = new PrioritaCollection();

            try
            {
                foreach (int idPriorita in ids)
                {
                    var priorita = priorita_provider.GetById(idPriorita);
                    setMinimo.Add(priorita);
                }

                return setMinimo;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato un errore nel controllo dei requisiti: {0}", ex.Message);
                throw new Exception(msg, ex);
            }           
            
        }

        internal RequisitiPagamentoCollection GetSetMinimoDomandaPagamento(string tipoDomanda)
        {
            SiarBLL.RequisitiPagamentoCollectionProvider requisiti_provider = new RequisitiPagamentoCollectionProvider();
            RequisitiPagamentoCollection setMinimo = new RequisitiPagamentoCollection();

            List<int> ids = new List<int>();

            switch (tipoDomanda)
            {
                case "ANT":
                    ids = idRequisitiSetMinimoAnticipo;
                    break;

                case "SAL":
                    ids = idRequisitiSetMinimoSal;
                    break;

                case "SLD":
                    ids = idRequisitiSetMinimoSaldo;
                    break;

                default:
                    break;
            }

            try
            {
                foreach (int idRequisito in ids)
                {
                    var requisito = requisiti_provider.GetById(idRequisito);
                    setMinimo.Add(requisito);
                }

                return setMinimo;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato un errore nel controllo dei requisiti: {0}", ex.Message);
                throw new Exception(msg, ex);
            }

        }

        internal RequisitiVarianteCollection GetSetMinimoVariante(List<int> ids)
        {
            SiarBLL.RequisitiVarianteCollectionProvider requisitiVarianteprovider = new RequisitiVarianteCollectionProvider();
            RequisitiVarianteCollection setMinimo = new RequisitiVarianteCollection();
           

            try
            {
                foreach (int idRequisito in ids)
                {
                    var requisito = requisitiVarianteprovider.GetById(idRequisito);
                    setMinimo.Add(requisito);
                }

                return setMinimo;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato un errore nel controllo dei requisiti: {0}", ex.Message);
                throw new Exception(msg, ex);
            }

        }

        internal bool CheckSetMinimo(ProceduraAttivazioneConfigurazioneProceduraAttivazioneRequisitiSoggettiviProcedura requisiti, PrioritaCollection priorita)
        {
            bool result = false;
            int count = 0;
            
            if (requisiti.RequisitoSoggettivo == null)
                return false;

            try
            {
                var setMinimo = priorita.ToArrayList<Priorita>();
                foreach (RequisitoSoggettivoType requisito in requisiti.RequisitoSoggettivo)
                {
                    if (setMinimo.FindAll(x => x.Descrizione == requisito.ChiaveDescrizione).FirstOrDefault() != null)
                        count++;
                }
                result = count == priorita.Count;
                return result;
            }
            catch (Exception ex)
            {

                var msg = string.Format("Si è verificato un errore nel controllo dei requisiti: {0}", ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal bool CheckSetMinimoProgetto(List<RequisitoType> requisiti, PrioritaCollection priorita)
        {
            bool result = false;
            int count = 0;

            if (requisiti == null)
                return false;

            try
            {
                var setMinimo = priorita.ToArrayList<Priorita>();
                foreach (RequisitoType requisito in requisiti)
                {
                    if (setMinimo.FindAll(x => x.Descrizione == requisito.ChiaveDescrizione).FirstOrDefault() != null)
                        count++;
                }
                result = count == priorita.Count;
                return result;
            }
            catch (Exception ex)
            {

                var msg = string.Format("Si è verificato un errore nel controllo dei requisiti di progetto: {0}", ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal bool CheckSetMinimoProgetto(List<RequisitoType> requisiti, PrioritaCollection priorita, string tipo)
        {
            bool result = false;
            int count = 0;

            if (requisiti == null)
                return false;

            try
            {
                var setMinimo = priorita.ToArrayList<Priorita>().FindAll(p => p.CodLivello == tipo);
                foreach (RequisitoType requisito in requisiti)
                {
                    if (setMinimo.FindAll(x => x.Descrizione == requisito.ChiaveDescrizione).FirstOrDefault() != null)
                        count++;
                }
                result = count == priorita.Count;
                return result;
            }
            catch (Exception ex)
            {

                var msg = string.Format("Si è verificato un errore nel controllo dei requisiti di progetto: {0}", ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal bool CheckSetMinimoProgetto(List<string> requisiti, PrioritaCollection priorita, string tipo)
        {
            bool result = false;
            int count = 0;

            if (requisiti == null)
                return false;

            try
            {
                var setMinimo = priorita.ToArrayList<Priorita>().FindAll(p => p.CodLivello == tipo);
                foreach (Priorita requisito in setMinimo)
                {
                    if (setMinimo.Select(x => x.Descrizione.ToString()).Intersect(requisiti).Any())
                        count++;
                }
                result = count == setMinimo.Count;
                return result;
            }
            catch (Exception ex)
            {

                var msg = string.Format("Si è verificato un errore nel controllo dei requisiti di progetto: {0}", ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal bool CheckSetMinimoDomandaPagamento(List<string> requisiti, RequisitiPagamentoCollection requisitiPagamento)
        {
            bool result = false;
            int count = 0;

            if (requisiti == null)
                return false;

            try
            {
                var setMinimo = requisitiPagamento.ToArrayList<RequisitiPagamento>();
                foreach (RequisitiPagamento requisito in setMinimo)
                {
                    if (setMinimo.Select(x => x.Descrizione.ToString()).Intersect(requisiti).Any())
                        count++;
                }
                result = count == setMinimo.Count;
                return result;
            }
            catch (Exception ex)
            {

                var msg = string.Format("Si è verificato un errore nel controllo dei requisiti della domanda di pagamento: {0}", ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal bool CheckSetMinimoVariante(List<string> requisiti, RequisitiVarianteCollection requisitiVariante)
        {
            bool result = false;
            int count = 0;

            if (requisiti == null)
                return false;

            try
            {
                var setMinimo = requisitiVariante.ToArrayList<RequisitiVariante>();
                foreach (RequisitiVariante requisito in setMinimo)
                {
                    if (setMinimo.Select(x => x.Descrizione.ToString()).Intersect(requisiti).Any())
                        count++;
                }
                result = count == setMinimo.Count;
                return result;
            }
            catch (Exception ex)
            {

                var msg = string.Format("Si è verificato un errore nel controllo dei requisiti della variante: {0}", ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal bool CheckSetRequisitiBandoPagamento(RequisitiPagamentoCollection setRequisiti, int idBando, string tipoDomanda)
        {
            bool result = false;
            var count = 0;

            var bandoRequisitiProvider = new BandoRequisitiPagamentoCollectionProvider();
            var requisitiBando = bandoRequisitiProvider.FindByIdBandoTipo(idBando, tipoDomanda).ToArrayList<BandoRequisitiPagamento>();
            if (requisitiBando == null)
                return false;
                       
            try
            {
                foreach (RequisitiPagamento requisito in setRequisiti)
                {
                    if (setRequisiti.ToArrayList<RequisitiPagamento>().Select(x => x.IdRequisito).Intersect(requisitiBando.Select(p => p.IdRequisito)).Any())
                        count++;
                }
                result = count == setRequisiti.Count;
                return result;
            }
            catch (Exception ex)
            {

                var msg = string.Format("Si è verificato un errore nella verifica dei requisiti di pagamento per il bando: {0}", ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal AuthInfo GetCredentials(string username, string password)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zImportServiceGetCredentials",
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.AddWithValue2("@username", username);
            sqlCmd.Parameters.AddWithValue2("@password", password);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                  reader =>
                                                  {
                                                      var o = new AuthInfo()
                                                      {
                                                          CodiceSistema = SqlHelper.GetValueOrDefault<string>(reader["CODICE_SISTEMA"]),
                                                          Username = SqlHelper.GetValueOrDefault<string>(reader["USERNAME"]),
                                                          Password = SqlHelper.GetValueOrDefault<string>(reader["PASSWORD"]),
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

                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione della richiesta: {0}", ex.Message);
                throw new Exception(msg, ex);
            }
        }
        

        internal int? GetUnitaDiMisura(string codice)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "SELECT ID_UNITA_MISURA FROM UNITA_DI_MISURA WHERE DESCRIZIONE = '" + codice + "'",
                CommandType = CommandType.Text
            };

            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd, 
                                                        reader =>
                                                        {
                                                            var o = SqlHelper.GetValueOrDefault<int?>(reader["ID_UNITA_MISURA"]);
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
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione della richiesta: {0}", ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal int? GetDug(string Descrizione)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "select ID_DUG FROM TIPO_DUG WHERE ATTIVO=1 AND Descrizione ='" + Descrizione + "'",
                CommandType = CommandType.Text
            };

            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                        reader =>
                                                        {
                                                            var o = SqlHelper.GetValueOrDefault<int?>(reader["ID_DUG"]);
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
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione della richiesta: {0}", ex.Message);
                throw new Exception(msg, ex);
            }
        }

        internal string GetRegistriAtti(string ente)
        {

            var sqlCmd = new SqlCommand
            {
                CommandText = "SELECT VALORE=CODICE+CASE WHEN OPEN_ACT=1 THEN '|'+CONVERT(CHAR(10),DATA_AVVIO_OPEN_ACT,103) ELSE '' END FROM ATTI_REGISTRI WHERE CODICE='" + ente + "'",
                CommandType = CommandType.Text
            };

            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                        reader =>
                                                        {
                                                            var o = SqlHelper.GetValueOrDefault<string>(reader["VALORE"]);
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
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione della richiesta: {0}", ex.Message);
                throw new Exception(msg, ex);
            }

        }

        internal int InsertProceduraAttivazioneByService(ProceduraAttivazione proceduraAttivazione)
        {
            //Inserimento dati procedura di attivazione
            SiarBLL.UtentiCollectionProvider utenti_provider = new UtentiCollectionProvider();
            SiarBLL.ZprogrammazioneCollectionProvider interventi_provider = new ZprogrammazioneCollectionProvider();
            BandoCollectionProvider bandoProv = new SiarBLL.BandoCollectionProvider();
            ZprogrammazioneCollectionProvider interventiProv = new ZprogrammazioneCollectionProvider();
            var intervento = interventiProv.Find(proceduraAttivazione.DatiGenerali.Programmazione.Interventi.Intervento.First().CodiceIntervento, null, proceduraAttivazione.DatiGenerali.Programmazione.Fondo, null, null, null)[0];
            var interventoPadre = interventiProv.GetById(intervento.IdPadre);
            SiarBLL.BandoCollectionProvider bando_provider = new SiarBLL.BandoCollectionProvider();
            SiarBLL.BandoStoricoCollectionProvider storico_provider = new SiarBLL.BandoStoricoCollectionProvider(bando_provider.DbProviderObj);
            SiarBLL.BandoIntegrazioniCollectionProvider integrazioni_provider = new SiarBLL.BandoIntegrazioniCollectionProvider(bando_provider.DbProviderObj);
            SiarBLL.BandoProgrammazioneCollectionProvider progbando_provider = new SiarBLL.BandoProgrammazioneCollectionProvider(bando_provider.DbProviderObj);
            SiarBLL.FascicoloPaleoCollectionProvider fasc_prov = new SiarBLL.FascicoloPaleoCollectionProvider(bando_provider.DbProviderObj);
            SiarBLL.BandoTipoInvestimentiCollectionProvider tipo_investimenti_provider = new SiarBLL.BandoTipoInvestimentiCollectionProvider(bando_provider.DbProviderObj);
            SiarBLL.BandoMassimaliCollectionProvider massimali_provider = new SiarBLL.BandoMassimaliCollectionProvider(bando_provider.DbProviderObj);
            SiarBLL.BandoRelazioneTecnicaCollectionProvider relazione_provider = new SiarBLL.BandoRelazioneTecnicaCollectionProvider(bando_provider.DbProviderObj);
            SiarBLL.CodificaInvestimentoCollectionProvider codifica_provider = new SiarBLL.CodificaInvestimentoCollectionProvider(bando_provider.DbProviderObj);
            SiarBLL.DettaglioInvestimentiCollectionProvider dettaglio_investimenti_provider = new DettaglioInvestimentiCollectionProvider(bando_provider.DbProviderObj);
            SiarBLL.SpecificaInvestimentiCollectionProvider specifica_provider = new SiarBLL.SpecificaInvestimentiCollectionProvider(bando_provider.DbProviderObj);
            SiarBLL.CatalogoDichiarazioniCollectionProvider catalogo_provider = new CatalogoDichiarazioniCollectionProvider(bando_provider.DbProviderObj);
            SiarBLL.DichiarazioniXDomandaCollectionProvider dichiarazioniDomanda_provider = new DichiarazioniXDomandaCollectionProvider(bando_provider.DbProviderObj);
            SiarBLL.AttiCollectionProvider atti_provider = new AttiCollectionProvider(bando_provider.DbProviderObj);
            SiarBLL.StepXBandoCollectionProvider step_bando_provider = new StepXBandoCollectionProvider(bando_provider.DbProviderObj);
            SiarBLL.ModelloDomandaCollectionProvider modello_provider = new ModelloDomandaCollectionProvider(bando_provider.DbProviderObj);
            SiarBLL.BusinessPlanCollectionProvider business_plan_provider = new BusinessPlanCollectionProvider(bando_provider.DbProviderObj);
            SiarBLL.PrioritaCollectionProvider priorita_provider = new PrioritaCollectionProvider(bando_provider.DbProviderObj);
            SiarBLL.SchedaValutazioneCollectionProvider schedaValutazione_provider = new SchedaValutazioneCollectionProvider(bando_provider.DbProviderObj);
            SiarBLL.SchedaXPrioritaCollectionProvider schedaXPriorita_provider = new SchedaXPrioritaCollectionProvider(bando_provider.DbProviderObj);
            RequisitiPagamentoCollectionProvider requisitiPagamentoProvider = new RequisitiPagamentoCollectionProvider(bando_provider.DbProviderObj);
            BandoRequisitiPagamentoCollectionProvider bandoRequisitiProvider = new BandoRequisitiPagamentoCollectionProvider(bando_provider.DbProviderObj);
            BandoTipoPagamentoCollectionProvider bandoTipoPagamentoProvider = new BandoTipoPagamentoCollectionProvider(bando_provider.DbProviderObj);
            RequisitiVarianteCollectionProvider requisitiVarianteProvider = new RequisitiVarianteCollectionProvider(bando_provider.DbProviderObj);
            BandoRequisitiVarianteCollectionProvider bandoRequisitiVarianteProvider = new BandoRequisitiVarianteCollectionProvider(bando_provider.DbProviderObj);
            BandoTipoVariantiCollectionProvider bandoTipoVariantiProvider = new BandoTipoVariantiCollectionProvider(bando_provider.DbProviderObj);

            try
            {
                //recupero gli interventi del Sigef
                var lInterventi = proceduraAttivazione.DatiGenerali.Programmazione.Interventi.Intervento;
                var interventiSigef = new List<Zprogrammazione>();
                for (int j = 0; j < lInterventi.Count; j++)
                {
                    var interventoSigef = interventiProv.Find(lInterventi[j].CodiceIntervento, null, proceduraAttivazione.DatiGenerali.Programmazione.Fondo, null, null, null).ToArrayList<Zprogrammazione>().FirstOrDefault();
                    interventiSigef.Add(interventoSigef);
                }

                bando_provider.DbProviderObj.BeginTran();

                SiarLibrary.Bando b = new SiarLibrary.Bando();
                b.CodEnte = proceduraAttivazione.DatiGenerali.CodiceStruttura;
                b.Descrizione = proceduraAttivazione.DatiGenerali.Descrizione;
                b.DataInserimento = DateTime.Now;
                b.DataApertura = proceduraAttivazione.DatiGenerali.DataOraApertura;
                b.DisposizioniAttuative = false;
                b.IdProgrammazione = interventoPadre.Id;
                b.Multiprogetto = false;
                b.Multimisura = false;
                b.FascicoloRichiesto = false;
                b.Aggregazione = proceduraAttivazione.DatiGenerali.IsAmmessaAggregazione;
                b.FascicoloRichiesto = proceduraAttivazione.DatiGenerali.Fascicolo == null;
                bando_provider.Save(b);

                //atto pubblicazione
                string numeroAtto = proceduraAttivazione.DatiGenerali.DatiProtocollo.Atto.NumeroAtto;
                DateTime dataAtto = proceduraAttivazione.DatiGenerali.DatiProtocollo.Atto.DataAtto;
                string codRegistro = proceduraAttivazione.DatiGenerali.DatiProtocollo.Atto.CodiceStruttura;
                int? idAtto = null;
                string enteAtto = codRegistro.Split('_')[1];
                string registroAtto = GetRegistriAtti(enteAtto);
                if (string.IsNullOrEmpty(registroAtto))
                    throw new Exception("L'ente associato all'atto non è configurato per la ricerca in OpenAct");
                var attiSigef = atti_provider.Find(numeroAtto, dataAtto, "D", enteAtto);
                if(attiSigef == null || attiSigef.Count == 0)
                {
                    var atti = atti_provider.ImportaAtto(numeroAtto, dataAtto, "D", registroAtto).ToArrayList<Atti>();
                    
                    if (atti != null && atti.Count > 0)
                    {
                        idAtto = atti_provider.Save(atti.First());

                    }
                    else
                    {
                        bando_provider.DbProviderObj.Rollback();
                        throw new Exception("l'atto presente nel tracciato non è stato trovato in OpenAct");
                    }
                }
                else
                {
                    idAtto = attiSigef.ToArrayList<Atti>().FirstOrDefault().IdAtto;
                }
                //var atti = atti_provider.ImportaAtto(numeroAtto, dataAtto, "D", codRegistro).ToArrayList<Atti>();
                //int? idAtto = null;
                //if (atti != null && atti.Count > 0)
                //{
                //    idAtto = atti_provider.Save(atti.First());

                //}
                //else
                //{
                //    bando_provider.DbProviderObj.Rollback();
                //    throw new Exception("l'atto presente nel tracciato non è stato trovato in OpenAct");
                //}

                // storico
                SiarLibrary.BandoStorico sp = new SiarLibrary.BandoStorico();
                sp.IdBando = b.IdBando;
                sp.CodStato = "P";
                sp.Data = DateTime.Now;
                sp.Operatore = 1;
                storico_provider.Save(sp);
                SiarLibrary.BandoStorico sl = new SiarLibrary.BandoStorico();
                sl.IdBando = b.IdBando;
                sl.CodStato = "L";
                sl.Data = DateTime.Now;
                sl.Operatore = 1;
                sl.IdAtto = idAtto;
                storico_provider.Save(sl);

                // integrazioni
                SiarLibrary.BandoIntegrazioni i = new SiarLibrary.BandoIntegrazioni();
                i.IdBando = b.IdBando;
                i.Data = DateTime.Now;
                i.Operatore = 1;
                i.DataScadenza = proceduraAttivazione.DatiGenerali.DataOraScadenza.Date;
                string ora_scadenza = proceduraAttivazione.DatiGenerali.DataOraScadenza.ToString("HH:mm");
                if (string.IsNullOrEmpty(ora_scadenza)) ora_scadenza = "23:59";
                i.DataScadenza.AddHour(int.Parse(ora_scadenza.Substring(0, 2)), int.Parse(ora_scadenza.Substring(3, 2)), 00);
                i.Importo = proceduraAttivazione.DatiGenerali.Importo;
                i.ImportoDiMisura = 0;
                i.QuotaRiserva = 0;
                i.IdAtto = idAtto;
                integrazioni_provider.Save(i);
                // aggiorno il bando
                b.IdIntegrazioneUltima = i.Id;
                b.IdStoricoUltimo = sl.Id;
                bando_provider.Save(b);

                // responsabile regionale
                var utente = utenti_provider.Find(proceduraAttivazione.DatiGenerali.CodiceFiscaleResponsabileProcedura, null, null, null, null, null, null).ToArrayList<Utenti>().FirstOrDefault();
                if (utente == null)
                {
                    throw new Exception("Il responsabile del bando indicato non è presente in banca dati.");
                }
                SiarLibrary.BandoResponsabili rr = new SiarLibrary.BandoResponsabili();
                rr.IdBando = b.IdBando;
                rr.IdUtente = utente.IdUtente;
                rr.Attivo = true;
                rr.Data = DateTime.Now;
                rr.Operatore = utente.IdUtente;
                new SiarBLL.BandoResponsabiliCollectionProvider(bando_provider.DbProviderObj).Save(rr);

                //responsabile provinciale
                SiarLibrary.BandoResponsabili rr_prov = new SiarLibrary.BandoResponsabili();
                rr_prov.IdUtente = utente.IdUtente;
                rr_prov.IdBando = b.IdBando;
                rr_prov.Attivo = true;
                rr_prov.Data = DateTime.Now;
                rr_prov.Operatore = utente.IdUtente;
                rr_prov.Provincia = "AN";
                new SiarBLL.BandoResponsabiliCollectionProvider(bando_provider.DbProviderObj).Save(rr_prov);

                //Fascicolo 
                string fascicolo = proceduraAttivazione.DatiGenerali.Fascicolo;
                if (fascicolo != "" && fascicolo != null)
                {
                    string[] ss = bando_provider.GetFascicolo(b.IdBando);
                    if (ss[0] != null && ss[0] != "")
                    {

                        SiarLibrary.FascicoloPaleo Fascicolo = fasc_prov.GetById(Convert.ToInt32(ss[0]));
                        if (Fascicolo != null)
                        {
                            Fascicolo.Fascicolo = fascicolo;
                            fasc_prov.Save(Fascicolo);
                        }
                    }
                    else
                    {
                        SiarLibrary.FascicoloPaleo Fascicolo = new SiarLibrary.FascicoloPaleo();
                        Fascicolo.Anno = DateTime.Today.Year;
                        SiarLibrary.Zprogrammazione progr = new SiarBLL.ZprogrammazioneCollectionProvider().GetById(b.IdProgrammazione);
                        Fascicolo.CodTipo = progr.CodTipo + " " + progr.Codice + " " + b.IdBando.ToString();
                        Fascicolo.Fascicolo = fascicolo;
                        Fascicolo.Provincia = "AN";
                        Fascicolo.CodEnte = b.CodEnte;
                        Fascicolo.Attivo = true;
                        Fascicolo.DataInizioValidita = DateTime.Parse(Convert.ToString(DateTime.Today.Year) + "-01-01");
                        fasc_prov.Save(Fascicolo);
                    }
                }

                //programmazione bando
                for (int j = 0; j < lInterventi.Count; j++)
                {                    
                    var interventoSigef = interventiSigef.First(x => x.Codice == lInterventi[j].CodiceIntervento);
                    SiarLibrary.BandoProgrammazione pb = new SiarLibrary.BandoProgrammazione();
                    pb.IdBando = b.IdBando;
                    pb.IdProgrammazione = interventoSigef.Id;
                    pb.MisuraPrevalente = j == 0;
                    progbando_provider.Save(pb);
                }

                //bando tipo investimenti
                SiarLibrary.BandoTipoInvestimenti t = new SiarLibrary.BandoTipoInvestimenti();
                t.IdBando = b.IdBando;
                t.CodTipoInvestimento = "1";
                t.ImportoMax = proceduraAttivazione.DatiGenerali.ImportoMassimoSpesa;
                t.ImportoMin = proceduraAttivazione.DatiGenerali.ImportoMinimoSpesa;
                if (t.ImportoMax != null && t.ImportoMin != null && t.ImportoMax > 0 && t.ImportoMax < t.ImportoMin)
                    throw new Exception("L`importo massimo non può essere minore del minimo.");
                t.Note = "Note" + t.CodTipoInvestimento + "_text";
                t.Premio = false;
                tipo_investimenti_provider.Save(t);


                SiarLibrary.BandoTipoInvestimenti s = new SiarLibrary.BandoTipoInvestimenti();
                s.IdBando = b.IdBando;
                s.CodTipoInvestimento = "7";
                s.ImportoMax = proceduraAttivazione.DatiGenerali.ImportoMassimoContributo;
                s.ImportoMin = proceduraAttivazione.DatiGenerali.ImportoMinimoContributo;
                if (s.ImportoMax != null && s.ImportoMin != null && s.ImportoMax > 0 && s.ImportoMax < s.ImportoMin)
                    throw new Exception("L`importo massimo non può essere minore del minimo.");
                s.Note = "Note" + s.CodTipoInvestimento + "_text";
                s.Premio = false;
                tipo_investimenti_provider.Save(s);
                
                //bando massimali
                for (int j = 0; j < lInterventi.Count; j++)
                {
                    var interventoSigef = interventiSigef.First(x => x.Codice == lInterventi[j].CodiceIntervento);
                    SiarLibrary.BandoMassimali bm = new SiarLibrary.BandoMassimali();
                    decimal? importo, quota;
                    importo = lInterventi[j].ImportoMassimale;
                    quota = lInterventi[j].QuotaImporto;
                    if (importo < 0 || quota < 0) throw new Exception("Non è possibile specificare importi negativi per i massimali.");
                    if (importo + quota <= 0) throw new Exception("Per ogni massimale è obbligatorio specificare almeno una voce tra importo e quota.");
                    bm.IdBando = b.IdBando;
                    bm.IdProgrammazione = interventoSigef.Id;
                    bm.Importo = importo;
                    bm.Quota = quota;
                    massimali_provider.Save(bm);
                }

                //relazione tecnica               
                var paragrafi = proceduraAttivazione.ConfigurazioneProceduraAttivazione.RelazioneTecnicaProcedura.Paragrafo;
                for (int k = 0; k < paragrafi.Count; k++)
                {
                    SiarLibrary.BandoRelazioneTecnica r = new SiarLibrary.BandoRelazioneTecnica(); ;
                    r.Titolo = paragrafi[k].Titolo;
                    r.Descrizione = paragrafi[k].Descrizione;
                    r.Ordine = paragrafi[k].IsTitoloProgetto ? 1 : paragrafi[k].IsDescrizioneProgetto ? 2 : paragrafi[k].Ordine == null ? k +10: paragrafi[k].Ordine + 10;
                    r.IdBando = b.IdBando;
                    relazione_provider.Save(r);
                }

                //requisiti soggettivi e set minimo scheda valutazione
                var schedaValutazione = new SchedaValutazione();
                var flagRaggruppamento = proceduraAttivazione.DatiGenerali.IsAmmessaAggregazione;
                var setMinimo = flagRaggruppamento ? idPrioritaSetMinimoGruppi : idPrioritaSetMinimoSingole;
                var idSchedaMinima = flagRaggruppamento ? idSchedaValutazioneGruppi : idSchedaValutazioneSingole;
                var requisiti = proceduraAttivazione.ConfigurazioneProceduraAttivazione.RequisitiSoggettiviProcedura;

                var priorita = GetSetMinimo(setMinimo);
                if (!CheckSetMinimo(requisiti, priorita))
                    throw new Exception("E' assente o incompleto il set minimo di requisiti soggettivi previsto per i progetti FESR");

                //se il set di requisiti corrisponde al set minimo, salvo direttamente l'id scheda valutazione corrispondente nel bando               
                var nomiPriorita = priorita.ToArrayList<Priorita>().Select(x => x.Descrizione.ToString()).ToArray();
                var nomiRequisiti = requisiti.RequisitoSoggettivo.Select(x => x.ChiaveDescrizione).ToArray();
                bool areEqual = nomiPriorita.OrderBy(a => a).SequenceEqual(nomiRequisiti.OrderBy(a => a));

                if (areEqual)
                {
                    b.IdSchedaValutazione = idSchedaMinima;
                }
                else
                {
                    foreach (var requisito in requisiti.RequisitoSoggettivo)
                    {
                        if(!priorita.ToArrayList<Priorita>().Any(x => x.Descrizione == requisito.ChiaveDescrizione))
                        {
                            var p = new Priorita();
                            p.Descrizione = requisito.ChiaveDescrizione;
                            p.FlagManuale = true;
                            p.CodLivello = "D"; //per le priorità aggiuntive metto sempre livello domanda
                            string tipo = Enum.GetName(typeof(RequisitoSoggettivoTypeTipoValore), requisito.TipoValore);
                            p.Datetime = tipo == "date";
                            p.InputNumerico = tipo == "number";
                            p.TestoSemplice = tipo == "string";
                            p.PluriValore = false;
                            p.PluriValoreSql = false;
                            p.IsDirty = false;
                            priorita.Add(p);
                            
                        }
                    }

                    priorita_provider.SaveCollection(priorita);

                    schedaValutazione.Descrizione = "scheda valutazione per bando ws id:" + b.IdBando;
                    schedaValutazione.FlagTemplate = false;
                    schedaValutazione.ValoreMax = 100;
                    schedaValutazione.ParoleChiave = "ws_import_" + b.IdBando;
                    schedaValutazione_provider.Save(schedaValutazione);

                    int ordine = 10;

                    var schedaPrioritaCollection = new SchedaXPrioritaCollection();

                    foreach(Priorita p in priorita)
                    {
                        var schedaXPriorita = new SchedaXPriorita();
                        schedaXPriorita.IdPriorita = p.IdPriorita;
                        schedaXPriorita.IdSchedaValutazione = schedaValutazione.IdSchedaValutazione;
                        schedaXPriorita.Ordine = ordine++;
                        schedaXPriorita.Selezionabile = true;
                        schedaPrioritaCollection.Add(schedaXPriorita);
                    }

                    schedaXPriorita_provider.SaveCollection(schedaPrioritaCollection);
                    b.IdSchedaValutazione = schedaValutazione.IdSchedaValutazione;

                }

                bando_provider.Save(b);

                //configurazione domande di pagamento
                var configurazioniPagamenti = proceduraAttivazione.ConfigurazioneProceduraAttivazione.ConfigurazioneDomandePagamento.ConfigurazioneDomandaPagamento;
                foreach(var config in configurazioniPagamenti)
                {
                    var bandoTipoPagamento = new BandoTipoPagamento();
                    string  tipoP = Enum.GetName(typeof(ConfigurazioneDomandaPagamentoTypeTipoPagamento), config.TipoPagamento);
                    bandoTipoPagamento.CodTipo = tipoP;
                    bandoTipoPagamento.IdBando = b.IdBando;
                    bandoTipoPagamento.QuotaMax = config.QuotaMax;
                    bandoTipoPagamento.QuotaMin = config.QuotaMin;
                    bandoTipoPagamento.ImportoMax = config.ImportoMax;
                    bandoTipoPagamento.ImportoMin = config.ImportoMin;
                    bandoTipoPagamento.Numero = config.NumeroTipoPagamento;
                    bandoTipoPagamento.CodTipoPolizza = tipoP == "ANT" ? "F1F" : "F0N";

                    bandoTipoPagamentoProvider.Save(bandoTipoPagamento);
                }


                //requisiti soggettivi domanda di pagamento
                var requisitiPagamento = proceduraAttivazione.ConfigurazioneProceduraAttivazione.RequisitiSoggettiviProceduraPagamento.RequisitoSoggettivoPagamento;
                var tipiPagamento = requisitiPagamento.Select(q => q.TipoPagamento.ToString()).Distinct().ToList();
                foreach (string tipoPag in tipiPagamento)
                {
                    var setMinimoP = GetSetMinimoDomandaPagamento(tipoPag);

                    var requisitiPagamentoDesc = requisitiPagamento
                                                .FindAll(a1 => Enum.GetName(typeof(RequisitoSoggettivoPagamentoTypeTipoPagamento), a1.TipoPagamento) == tipoPag)
                                                .Select(r1 => r1.ChiaveDescrizione).ToList();
                    if (!CheckSetMinimoDomandaPagamento(requisitiPagamentoDesc, setMinimoP))
                        throw new Exception("E' assente o incompleto il set minimo di requisiti previsto per le domande di pagamento FESR di tipo " + tipoPag);

                    var requisitiPagamentoPag = requisitiPagamento.FindAll(c => Enum.GetName(typeof(RequisitoSoggettivoPagamentoTypeTipoPagamento), c.TipoPagamento) == tipoPag);
                    bool newRequisiti = false;
                    foreach (var requisitoPagamento in requisitiPagamentoPag)
                    {
                        if (!setMinimoP.ToArrayList<RequisitiPagamento>().Any(x => x.Descrizione == requisitoPagamento.ChiaveDescrizione))
                        {
                            var rp = new RequisitiPagamento();
                            rp.Descrizione = requisitoPagamento.ChiaveDescrizione;
                            string tipo = Enum.GetName(typeof(RequisitoSoggettivoPagamentoTypeTipoValore), requisitoPagamento.TipoValore);
                            rp.Datetime = tipo == "date";
                            rp.Numerico = tipo == "number";
                            rp.TestoSemplice = tipo == "string";
                            rp.TestoArea = false;
                            rp.IsDirty = false;
                            setMinimoP.Add(rp);
                            newRequisiti = true;

                        }
                    }

                    if(newRequisiti)
                        requisitiPagamentoProvider.SaveCollection(setMinimoP);

                    //associazione requisiti pagamento con il bando
                    int ordinePB = 10;
                    foreach (RequisitiPagamento requisitoP in setMinimoP)
                    {
                        var bandoRequisito = new BandoRequisitiPagamento();
                        bandoRequisito.IdBando = b.IdBando;
                        bandoRequisito.CodTipo = tipoPag;
                        bandoRequisito.IdRequisito = requisitoP.IdRequisito;
                        bandoRequisito.Obbligatorio = true;
                        bandoRequisito.RequisitoDiInserimento = requisitoP.IdRequisito != idRequisitoControllo;
                        bandoRequisito.RequisitoDiControllo = requisitoP.IdRequisito == idRequisitoControllo;
                        ordinePB += 10;
                        bandoRequisito.Ordine = ordinePB;
                        bandoRequisitiProvider.Save(bandoRequisito);
                    }

                }

                //requisiti variante
                var requisitiVariante = proceduraAttivazione.ConfigurazioneProceduraAttivazione.RequisitiSoggettiviVariante.RequisitoSoggettivoVariante;
                var setMinimoV = GetSetMinimoVariante(idRequisitiSetMinimoVariante);
                var requisitiVarianteDesc = requisitiVariante.Select(r1 => r1.ChiaveDescrizione).ToList();
                bool newRequisitiV = false;
                foreach (var requisitoVariante in requisitiVariante)
                {
                    if (!setMinimoV.ToArrayList<RequisitiVariante>().Any(x => x.Descrizione == requisitoVariante.ChiaveDescrizione))
                    {
                        var rv = new RequisitiVariante();
                        rv.Descrizione = requisitoVariante.ChiaveDescrizione;
                        rv.Automatico = false;
                        setMinimoV.Add(rv);
                        newRequisitiV = true;
                    }

                    if (newRequisitiV)
                        requisitiVarianteProvider.SaveCollection(setMinimoV);

                }

                //associazione bando tipo varianti
                var bandoTipoVariante = new BandoTipoVarianti();
                bandoTipoVariante.IdBando = b.IdBando;
                bandoTipoVariante.CodTipo = "VA";
                bandoTipoVariante.NumeroMassimo = 1;
                bandoTipoVariantiProvider.Save(bandoTipoVariante);

                //associazione requisiti variante con il bando
                int ordineRV = 10;
                foreach (RequisitiVariante requisitoV in setMinimoV)
                {
                    var varianteRequisito = new BandoRequisitiVariante();
                    varianteRequisito.IdBando = b.IdBando;
                    varianteRequisito.IdRequisito = requisitoV.IdRequisito;
                    varianteRequisito.CodTipo = "VA";
                    varianteRequisito.Obbligatorio = true;
                    varianteRequisito.RequisitoDiIstruttoria = idRequisitiVarianteControllo.Any(v => v == requisitoV.IdRequisito);
                    varianteRequisito.RequisitoDiPresentazione = !varianteRequisito.RequisitoDiIstruttoria;
                    ordineRV += 10;
                    varianteRequisito.Ordine = ordineRV;
                    bandoRequisitiVarianteProvider.Save(varianteRequisito);
                }

                //Modello domanda
                var modello = new ModelloDomanda();
                modello.IdBando = b.IdBando;
                string descrizione = "Modello import per bando: " + b.Descrizione;
                modello.Descrizione = descrizione;
                modello.Denominazione = "Import bando " + b.IdBando.ToString();
                modello_provider.Save(modello);
                //aggiorno il bando
                b.IdModelloDomanda = modello.IdDomanda;
                bando_provider.Save(b);

                //dichiarazioni
                var dichiarazioni = proceduraAttivazione.ConfigurazioneProceduraAttivazione.DichiarazioniProcedura.DichiarazioneProcedura;

                foreach(DichiarazioneProceduraType item in dichiarazioni)
                {
                    var dichiarazione = new CatalogoDichiarazioni();
                    dichiarazione.Descrizione = item.DescrizioneDichiarazione;
                    catalogo_provider.Save(dichiarazione);
                    var dichiarazione_domanda = new DichiarazioniXDomanda();
                    dichiarazione_domanda.IdDichiarazione = dichiarazione.IdDichiarazione;
                    dichiarazione_domanda.IdDomanda = modello.IdDomanda; //182; //impostare un id fisso da web.config
                    dichiarazione_domanda.Ordine = item.Ordine;
                    dichiarazione_domanda.Obbligatorio = true;
                    dichiarazioniDomanda_provider.Save(dichiarazione_domanda);
                }

                //codifica e dettaglio investimenti
                var codifiche = proceduraAttivazione.Investimenti.CodificaInvestimento;
                foreach(CodificaInvestimentoType item in codifiche)
                {
                    SiarLibrary.CodificaInvestimento codifica_investimento = new CodificaInvestimento();
                    codifica_investimento.IdBando = b.IdBando;
                    codifica_investimento.IdIntervento = interventiSigef.First(x => x.Codice == item.Intervento.CodiceIntervento).Id;
                    codifica_investimento.Descrizione = item.DescrizioneInvestimento;
                    codifica_investimento.Codice = item.CodiceInvestimento;
                    codifica_investimento.AiutoMinimo = item.QuotaPercentuale;
                    codifica_investimento.CodTp = null;
                    codifica_investimento.IsMax = false;
                    int idCodifica = codifica_provider.Save(codifica_investimento);
                    foreach(DettaglioInvestimentoType dItem in item.DettagliInvestimento.DettaglioInvestimento)
                    {
                        var dettaglio_investimento = new SiarLibrary.DettaglioInvestimenti();
                        dettaglio_investimento.IdCodificaInvestimento = codifica_investimento.IdCodificaInvestimento;
                        dettaglio_investimento.CodDettaglio = dItem.CodiceDettaglioInvestimento;
                        dettaglio_investimento.Mobile = 1;
                        dettaglio_investimento.RichiediParticella = 0;
                        dettaglio_investimento.QuotaSpeseGenerali = 0;
                        //dettaglio_investimento.IdUdm = GetUnitaDiMisura(dItem.UDM);
                        dettaglio_investimento.Descrizione = dItem.DescrizioneDettaglioInvestimento;
                        dettaglio_investimenti_provider.Save(dettaglio_investimento);

                        if(dItem.SpecificheInvestimento != null)
                        {
                            if (!(dItem.SpecificheInvestimento.SpecificaInvestimento?.Any() ?? false))
                            {
                                foreach (SpecificaInvestimentoType sItem in dItem.SpecificheInvestimento.SpecificaInvestimento)
                                {
                                    var specifica_investimento = new SiarLibrary.SpecificaInvestimenti();
                                    specifica_investimento.IdDettaglioInvestimento = dettaglio_investimento.IdDettaglioInvestimento;
                                    specifica_investimento.CodSpecifica = sItem.CodiceSpecificaInvestimento;
                                    specifica_investimento.Descrizione = sItem.DescrizioneSpecificaInvestimento;
                                    specifica_provider.Save(specifica_investimento);
                                }
                            }
                            
                        }                      
                    }

                }

                //scheda bando
                var stepBando = new StepXBando();
                stepBando.IdBando = b.IdBando;
                stepBando.IdCheckList = idStandardChecklist; //246; //Spostare questo parametro sul config
                stepBando.CodFase = "P";
                step_bando_provider.Save(stepBando);

                //Quadri business plan
                var bpCollection = new BusinessPlanCollection();

                var bpMonitoraggio = new BusinessPlan();
                bpMonitoraggio.IdBando = b.IdBando;
                bpMonitoraggio.IdQuadro = idQuadroMonitoraggio;
                bpMonitoraggio.Ordine = 1;
                bpCollection.Add(bpMonitoraggio);

                var bpLocalizzazione = new BusinessPlan();
                bpLocalizzazione.IdBando = b.IdBando;
                bpLocalizzazione.IdQuadro = idQuadroLocalizzazione;
                bpLocalizzazione.Ordine = 2;
                bpCollection.Add(bpLocalizzazione);

                var bpPianoInvestimenti = new BusinessPlan();
                bpPianoInvestimenti.IdBando = b.IdBando;
                bpPianoInvestimenti.IdQuadro = idQuadroPianoInvestimenti;
                bpPianoInvestimenti.Ordine = 3;
                bpCollection.Add(bpPianoInvestimenti);

                business_plan_provider.SaveCollection(bpCollection);


                //commit finale
                bando_provider.DbProviderObj.Commit();
                return b.IdBando;
            }

            catch (Exception ex)
            {
                bando_provider.DbProviderObj.Rollback();
                throw ex;
            }
        }

        internal int InsertProgettoByService(Progetto progetto)
        {
            SiarBLL.BandoRelazioneTecnicaCollectionProvider bando_relazione_provider = new BandoRelazioneTecnicaCollectionProvider();
            SiarBLL.ComuniCollectionProvider comuni_provider = new ComuniCollectionProvider();
            SiarBLL.ZprogrammazioneCollectionProvider interventi_provider = new ZprogrammazioneCollectionProvider();
            SiarBLL.ZdimensioniXProgrammazioneCollectionProvider zdimensioni_prog_provider = new ZdimensioniXProgrammazioneCollectionProvider();
            SiarBLL.ZdimensioniCollectionProvider zdimensioni_provider = new ZdimensioniCollectionProvider();
            SiarBLL.CodificaInvestimentoCollectionProvider cod_investimenti_provider = new CodificaInvestimentoCollectionProvider();
            SiarBLL.SpecificaInvestimentiCollectionProvider spec_investimenti_provider = new SpecificaInvestimentiCollectionProvider();
            SiarBLL.DettaglioInvestimentiCollectionProvider dettaglio_investimenti_provider = new DettaglioInvestimentiCollectionProvider();
            SiarBLL.BandoCollectionProvider bando_provider = new BandoCollectionProvider();
            SiarBLL.SchedaValutazioneCollectionProvider scheda_provider = new SchedaValutazioneCollectionProvider();
            SiarBLL.SchedaXPrioritaCollectionProvider schedaXPriorita_provider = new SchedaXPrioritaCollectionProvider();
            SiarBLL.PrioritaCollectionProvider priorita_provider = new PrioritaCollectionProvider();
            SiarBLL.ValoriPrioritaCollectionProvider valori_priorita_provider = new ValoriPrioritaCollectionProvider();

            SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider();
            SiarBLL.ProgettoStoricoCollectionProvider storico_provider = new SiarBLL.ProgettoStoricoCollectionProvider(progetto_provider.DbProviderObj);
            SiarBLL.ProgettoRelazioneTecnicaCollectionProvider progetto_relazione_provider = new ProgettoRelazioneTecnicaCollectionProvider(progetto_provider.DbProviderObj);
            SiarBLL.DatiMonitoraggioFESRCollectionProvider dati_monitoraggio_provider = new DatiMonitoraggioFESRCollectionProvider(progetto_provider.DbProviderObj);
            SiarBLL.LocalizzazioneProgettoCollectionProvider localizzazione_provider = new LocalizzazioneProgettoCollectionProvider(progetto_provider.DbProviderObj);
            SiarBLL.ProgettoIndicatoriCollectionProvider progetto_indicatori_provider = new ProgettoIndicatoriCollectionProvider(progetto_provider.DbProviderObj);
            SiarBLL.PianoInvestimentiCollectionProvider piano_investimenti_provider = new PianoInvestimentiCollectionProvider(progetto_provider.DbProviderObj);
            SiarBLL.ProgettoNaturaSoggettoCollectionProvider progetto_natura_soggetto_provider = new ProgettoNaturaSoggettoCollectionProvider(progetto_provider.DbProviderObj);
            SiarBLL.ImpresaCollectionProvider impresa_provider = new ImpresaCollectionProvider(progetto_provider.DbProviderObj);
            SiarBLL.CheckListXStepCollectionProvider checklist_step_provider = new CheckListXStepCollectionProvider();
            SiarBLL.IterProgettoCollectionProvider iter_provider = new IterProgettoCollectionProvider(progetto_provider.DbProviderObj);
            SiarBLL.PersonaFisicaCollectionProvider persona_fisica_provider = new PersonaFisicaCollectionProvider(progetto_provider.DbProviderObj);
            SiarBLL.PersoneXImpreseCollectionProvider persone_imprese_provider = new PersoneXImpreseCollectionProvider(progetto_provider.DbProviderObj);
            SiarBLL.IndirizzoCollectionProvider indirizzo_provider = new IndirizzoCollectionProvider(progetto_provider.DbProviderObj);
            SiarBLL.IndirizzarioCollectionProvider indirizzario_provider = new IndirizzarioCollectionProvider(progetto_provider.DbProviderObj);
            SiarBLL.ContoCorrenteCollectionProvider conto_corrente_provider = new ContoCorrenteCollectionProvider(progetto_provider.DbProviderObj);
            SiarBLL.PrioritaXImpresaCollectionProvider priorita_impresa_provider = new PrioritaXImpresaCollectionProvider(progetto_provider.DbProviderObj);
            SiarBLL.PrioritaXProgettoCollectionProvider priorita_progetto_provider = new PrioritaXProgettoCollectionProvider(progetto_provider.DbProviderObj);
            SiarBLL.PrioritaXInvestimentiCollectionProvider priorita_investimento_provider = new PrioritaXInvestimentiCollectionProvider(progetto_provider.DbProviderObj);
            SiarBLL.ImpresaStoricoCollectionProvider impresa_storico_prov = new ImpresaStoricoCollectionProvider(progetto_provider.DbProviderObj);
            SiarBLL.ImportServiceProgressivoInvestimentiCollectionProvider progressivo_provider = new ImportServiceProgressivoInvestimentiCollectionProvider(progetto_provider.DbProviderObj); 

            try
            {
                //dati per inserimento requisiti soggettivi
                var bando = bando_provider.GetById(progetto.DatiGenerali.IdBandoSigef);
                //var schedaValutazione = scheda_provider.GetById(bando.IdSchedaValutazione);
                var flagRaggruppamento = bando.Aggregazione;
                var setMinimo = flagRaggruppamento ? idPrioritaSetMinimoGruppi : idPrioritaSetMinimoSingole;
                var prioritaSetMinimo = GetSetMinimo(setMinimo);

                //inizio transazione
                progetto_provider.DbProviderObj.BeginTran();

                //beneficiari
                int? idImpresaPrincipale = null;
                SiarLibrary.ProgettoNaturaSoggetto progSogg = new ProgettoNaturaSoggetto();
                var requisitiImpresaColl = new PrioritaXImpresaCollection();
                Dictionary<int, string> impreseDictionary = new Dictionary<int, string>();
                //progSogg.IdProgetto = p.IdProgetto;
                var impresa = new SiarLibrary.Impresa();
                if (progetto.Beneficiari.Beneficiario.Count == 1)
                {
                    progSogg.TipoNaturaSoggetto = "Singola";
                    //var impresa = new SiarLibrary.Impresa();
                    var beneficiario = progetto.Beneficiari.Beneficiario.FirstOrDefault();
                    impresa = impresa_provider.Find(null, beneficiario.PartitaIva, null).ToArrayList<Impresa>().FirstOrDefault();
                    if (impresa != null)
                    {
                        impreseDictionary.Add(impresa.IdImpresa, beneficiario.PartitaIva);
                        idImpresaPrincipale = impresa.IdImpresa;

                        var impresaStorico = new ImpresaStorico();
                        impresaStorico.RagioneSociale = beneficiario.RagioneSociale;
                        impresaStorico.DataInizioValidita = DateTime.Now;
                        impresaStorico.RegistroImpreseNumero = beneficiario.NumeroRegistroImprese;
                        impresaStorico.ReaNumero = beneficiario.NumeroREA;
                        impresaStorico.ReaAnno = beneficiario.AnnoIscrizioneREA;
                        impresaStorico.CodAteco2007 = beneficiario.CodiceATECO2007;
                        impresaStorico.IdDimensione = beneficiario.DimensioneImpresa;
                        impresaStorico.CodFormaGiuridica = beneficiario.CodiceFormaGiuridica;
                        impresaStorico.IdImpresa = impresa.IdImpresa;
                        impresa_storico_prov.Save(impresaStorico);
                        impresa.IdStoricoUltimo = impresaStorico.IdStoricoImpresa;
                        impresa_provider.Save(impresa);

                        //Aggiorno la sede precedente
                        var indirizzarioOld = indirizzario_provider.GetById(impresa.IdSedelegaleUltimo);
                        indirizzarioOld.FlagAttivo = false;
                        indirizzario_provider.Save(indirizzarioOld);
                        //nuova sede
                        var sedeLegale = new Indirizzo();
                        string istatProvSL = beneficiario.SedeLegale.ISTAT6.Substring(0, 3);
                        string istatComuneSL = beneficiario.SedeLegale.ISTAT6.Substring(3, 3);
                        int idComuneSL = comuni_provider.Find(null, istatProvSL, null, null, null, istatComuneSL, null, null).ToArrayList<Comuni>().FirstOrDefault().IdComune;
                        sedeLegale.IdComune = idComuneSL;
                        sedeLegale.Via = beneficiario.SedeLegale.Indirizzo;
                        indirizzo_provider.Save(sedeLegale);
                        var indirizzario = new Indirizzario();
                        indirizzario.IdImpresa = idImpresaPrincipale;
                        indirizzario.IdIndirizzo = sedeLegale.IdIndirizzo;
                        indirizzario.DataInizioValidita = DateTime.Now;
                        indirizzario.CodTipoSede = "S";
                        indirizzario.FlagAttivo = true;
                        indirizzario.Email = beneficiario.Email;
                        indirizzario.Pec = beneficiario.Pec;
                        indirizzario.Telefono = beneficiario.Telefono;
                        indirizzario_provider.Save(indirizzario);
                        impresa.IdSedelegaleUltimo = indirizzario.IdIndirizzario;
                        impresa_provider.Save(impresa);

                        //aggiorno il rappresentante legale
                        var rappresentanteLegaleColl = persona_fisica_provider.Find(beneficiario.RappresentanteLegale.CodiceFiscale).ToArrayList<PersonaFisica>();
                        if (rappresentanteLegaleColl.Any()) //la persona fisica esiste in banca dati
                        {
                            var personaImpresa = persone_imprese_provider.GetById(impresa.IdRapprlegaleUltimo);
                            var rappresentanteLegale = rappresentanteLegaleColl.FirstOrDefault();
                            if (personaImpresa.IdPersona != rappresentanteLegale.IdPersona)
                            {
                                //aggiorno il precedente rapp. legale
                                personaImpresa.Attivo = false;
                                persone_imprese_provider.Save(personaImpresa);
                                var personeXImprese = new PersoneXImprese();
                                personeXImprese.IdImpresa = idImpresaPrincipale;
                                personeXImprese.IdPersona = rappresentanteLegale.IdPersona;
                                personeXImprese.Attivo = true;
                                personeXImprese.CodRuolo = "R";
                                personeXImprese.DataInizio = DateTime.Now;
                                personeXImprese.Ammesso = true;
                                persone_imprese_provider.Save(personeXImprese);
                                impresa.IdRapprlegaleUltimo = personeXImprese.IdPersoneXImprese;
                                impresa_provider.Save(impresa);
                            }

                        }
                        else
                        {
                            //aggiorno il precedente rapp. legale
                            var personaImpresa = persone_imprese_provider.GetById(impresa.IdRapprlegaleUltimo);
                            personaImpresa.Attivo = false;
                            persone_imprese_provider.Save(personaImpresa);
                            //nuovo rapp. legale
                            var rappresentanteLegale = new PersonaFisica();
                            var personeXImprese = new PersoneXImprese();
                            rappresentanteLegale.Nome = beneficiario.RappresentanteLegale.Nome;
                            rappresentanteLegale.Cognome = beneficiario.RappresentanteLegale.Cognome;
                            rappresentanteLegale.DataNascita = beneficiario.RappresentanteLegale.DataNascita;
                            string belfiore = beneficiario.RappresentanteLegale.CodiceFiscale.Substring(11, 4);
                            int idComune;
                            if (belfiore.StartsWith("Z"))
                            {
                                idComune = comuni_provider.Find(belfiore, null, null, null, null, null, null, null).ToArrayList<Comuni>().FirstOrDefault().IdComune;
                            }
                            else
                            {
                                string istatProv = beneficiario.RappresentanteLegale.ISTAT6Nascita.Substring(0, 3);
                                string istatComune = beneficiario.RappresentanteLegale.ISTAT6Nascita.Substring(3, 3);
                                idComune = comuni_provider.Find(null, istatProv, null, null, null, istatComune, null, null).ToArrayList<Comuni>().FirstOrDefault().IdComune;
                            }
                            rappresentanteLegale.IdComuneNascita = idComune;
                            rappresentanteLegale.CodiceFiscale = beneficiario.RappresentanteLegale.CodiceFiscale;
                            persona_fisica_provider.Save(rappresentanteLegale);
                            personeXImprese.IdImpresa = idImpresaPrincipale;
                            personeXImprese.IdPersona = rappresentanteLegale.IdPersona;
                            personeXImprese.Attivo = true;
                            personeXImprese.CodRuolo = "R";
                            personeXImprese.DataInizio = DateTime.Now;
                            personeXImprese.Ammesso = true;
                            persone_imprese_provider.Save(personeXImprese);
                            impresa.IdRapprlegaleUltimo = personeXImprese.IdPersoneXImprese;
                            impresa_provider.Save(impresa);
                        }


                    }
                    else //nuova impresa
                    {
                        impresa.Cuaa = beneficiario.CodiceFiscale;
                        impresa.CodiceFiscale = beneficiario.PartitaIva;
                        impresa.DataInizioAttivita = beneficiario.DataInizioAttivita;
                        impresa_provider.Save(impresa);
                        impreseDictionary.Add(impresa.IdImpresa, beneficiario.PartitaIva);

                        var impresaStorico = new ImpresaStorico();
                        impresaStorico.RagioneSociale = beneficiario.RagioneSociale;
                        impresaStorico.DataInizioValidita = DateTime.Now;
                        impresaStorico.RegistroImpreseNumero = beneficiario.NumeroRegistroImprese;
                        impresaStorico.ReaNumero = beneficiario.NumeroREA;
                        impresaStorico.ReaAnno = beneficiario.AnnoIscrizioneREA;
                        impresaStorico.CodAteco2007 = beneficiario.CodiceATECO2007;
                        impresaStorico.IdDimensione = beneficiario.DimensioneImpresa;
                        impresaStorico.CodFormaGiuridica = beneficiario.CodiceFormaGiuridica;
                        impresaStorico.IdImpresa = impresa.IdImpresa;
                        impresa_storico_prov.Save(impresaStorico);
                        impresa.IdStoricoUltimo = impresaStorico.IdStoricoImpresa;
                        impresa_provider.Save(impresa);

                        idImpresaPrincipale = impresa.IdImpresa;

                        var rappresentanteLegaleColl = persona_fisica_provider.Find(beneficiario.RappresentanteLegale.CodiceFiscale).ToArrayList<PersonaFisica>();
                        if (rappresentanteLegaleColl.Any()) //la persona fisica esiste in banca dati
                        {
                            var rappresentanteLegale = rappresentanteLegaleColl.FirstOrDefault();
                            var personeXImprese = new PersoneXImprese();
                            personeXImprese.IdImpresa = idImpresaPrincipale;
                            personeXImprese.IdPersona = rappresentanteLegale.IdPersona;
                            personeXImprese.Attivo = true;
                            personeXImprese.Ruolo = "R";
                            personeXImprese.DataInizio = DateTime.Now;
                            personeXImprese.Ammesso = true;
                            persone_imprese_provider.Save(personeXImprese);
                            impresa.IdRapprlegaleUltimo = personeXImprese.IdPersoneXImprese;
                            impresa_provider.Save(impresa);
                        }
                        else
                        {
                            //Rappresentante Legale non presente in banca dati
                            var rappresentanteLegale = new PersonaFisica();
                            var personeXImprese = new PersoneXImprese();
                            rappresentanteLegale.Nome = beneficiario.RappresentanteLegale.Nome;
                            rappresentanteLegale.Cognome = beneficiario.RappresentanteLegale.Cognome;
                            rappresentanteLegale.DataNascita = beneficiario.RappresentanteLegale.DataNascita;
                            string belfiore = beneficiario.RappresentanteLegale.CodiceFiscale.Substring(11, 4);
                            int idComune;
                            if (belfiore.StartsWith("Z"))
                            {
                                idComune = comuni_provider.Find(belfiore, null, null, null, null, null, null, null).ToArrayList<Comuni>().FirstOrDefault().IdComune;
                            }
                            else
                            {
                                string istatProv = beneficiario.RappresentanteLegale.ISTAT6Nascita.Substring(0, 3);
                                string istatComune = beneficiario.RappresentanteLegale.ISTAT6Nascita.Substring(3, 3);
                                idComune = comuni_provider.Find(null, istatProv, null, null, null, istatComune, null, null).ToArrayList<Comuni>().FirstOrDefault().IdComune;
                            }
                            rappresentanteLegale.IdComuneNascita = idComune;
                            rappresentanteLegale.CodiceFiscale = beneficiario.RappresentanteLegale.CodiceFiscale;
                            persona_fisica_provider.Save(rappresentanteLegale);
                            personeXImprese.IdImpresa = idImpresaPrincipale;
                            personeXImprese.IdPersona = rappresentanteLegale.IdPersona;
                            personeXImprese.Attivo = true;
                            personeXImprese.Ruolo = "R";
                            personeXImprese.DataInizio = DateTime.Now;
                            personeXImprese.Ammesso = true;
                            persone_imprese_provider.Save(personeXImprese);
                            impresa.IdRapprlegaleUltimo = personeXImprese.IdPersoneXImprese;
                            impresa_provider.Save(impresa);
                        }
                                         

                        //sede legale
                        var sedeLegale = new Indirizzo();
                        string istatProvSL = beneficiario.SedeLegale.ISTAT6.Substring(0, 3);
                        string istatComuneSL = beneficiario.SedeLegale.ISTAT6.Substring(3, 3);
                        int idComuneSL = comuni_provider.Find(null, istatProvSL, null, null, null, istatComuneSL, null, null).ToArrayList<Comuni>().FirstOrDefault().IdComune;
                        sedeLegale.IdComune = idComuneSL;
                        sedeLegale.Via = beneficiario.SedeLegale.Indirizzo;
                        indirizzo_provider.Save(sedeLegale);
                        var indirizzario = new Indirizzario();
                        indirizzario.IdImpresa = idImpresaPrincipale;
                        indirizzario.IdIndirizzo = sedeLegale.IdIndirizzo;
                        indirizzario.DataInizioValidita = DateTime.Now;
                        indirizzario.CodTipoSede = "S";
                        indirizzario.FlagAttivo = true;
                        indirizzario.Email = beneficiario.Email;
                        indirizzario.Pec = beneficiario.Pec;
                        indirizzario.Telefono = beneficiario.Telefono;
                        indirizzario_provider.Save(indirizzario);
                        impresa.IdSedelegaleUltimo = indirizzario.IdIndirizzario;
                        impresa_provider.Save(impresa);

                    }

                    if (string.IsNullOrEmpty(beneficiario.IBAN))
                        throw new Exception("IBAN dell'impresa non presente");

                    //inserimento conto corrente
                    var conto = new ContoCorrente();
                    string iban = beneficiario.IBAN;
                    conto.IdImpresa = idImpresaPrincipale;
                    conto.CodPaese = iban.Substring(0, 2);
                    conto.CinEuro = iban.Substring(2, 2);
                    conto.Cin = iban.Substring(4, 1);
                    conto.Abi = iban.Substring(5, 5);
                    conto.Cab = iban.Substring(10, 5);
                    conto.Numero = iban.Substring(15);
                    Dictionary<string, object> dt = SiarLibrary.DbStaticProvider.GetDatiBancaByCC(conto.Abi, conto.Cab);
                    conto.Istituto = dt["Istituto"].ToString();
                    conto.Agenzia = dt["Agenzia"].ToString();
                    conto.IdComune = dt["IdComune"].ToString();
                    conto_corrente_provider.Save(conto);
                    impresa.IdContoCorrenteUltimo = conto.IdContoCorrente;
                    impresa_provider.Save(impresa);


                    //inserimento requisiti soggettivi impresa
                    var requisitiImpresa = beneficiario.RequisitiImpresa.RequisitoImpresa;
                    var requisitiImpresaDesc = beneficiario.RequisitiImpresa.RequisitoImpresa.Select(i => i.ChiaveDescrizione).ToList();

                    if (!CheckSetMinimoProgetto(requisitiImpresaDesc, prioritaSetMinimo, "P"))
                        throw new Exception("E' assente o incompleto il set minimo di requisiti soggettivi previsto per le imprese nei progetti FESR");

                    var prioritaxImpresa = schedaXPriorita_provider.Find(bando.IdSchedaValutazione, null, null, null, null).ToArrayList<SchedaXPriorita>().FindAll(n => n.CodLivello == "P");

                    foreach (SchedaXPriorita prioritaScheda in prioritaxImpresa)
                    {
                        //inserisco in prioritaximpresa tipo P
                        var prioritaImpresa = new PrioritaXImpresa();
                        var prProgetto = priorita_provider.GetById(prioritaScheda.IdPriorita);
                        var reqProgetto = requisitiImpresa.FindAll(x => x.ChiaveDescrizione == prProgetto.Descrizione).FirstOrDefault();
                        var idImpresa = impresa.IdImpresa;

                        prioritaImpresa.IdPriorita = prioritaScheda.IdPriorita;
                        prioritaImpresa.IdImpresa = idImpresa;
                        //prioritaImpresa.IdProgetto = p.IdProgetto;

                        if (prProgetto.Datetime)
                            prioritaImpresa.ValData = DateTime.Parse(reqProgetto.Valore);

                        if (prProgetto.PluriValore)
                        {
                            var valorePriorita = valori_priorita_provider.Find(null, prProgetto.IdPriorita, null).ToArrayList<ValoriPriorita>().FindAll(v => v.Descrizione == reqProgetto.Valore).FirstOrDefault();
                            if (valorePriorita != null)
                            {
                                prioritaImpresa.IdValore = valorePriorita.IdValore;
                            }
                        }

                        if (prProgetto.InputNumerico)
                            prioritaImpresa.Valore = Decimal.Parse(reqProgetto.Valore);

                        if (prProgetto.TestoSemplice)
                            prioritaImpresa.ValTesto = reqProgetto.Valore;

                        //priorita_impresa_provider.Save(prioritaImpresa);
                        requisitiImpresaColl.Add(prioritaImpresa);

                    }

                }
                else //Inserimento Aggregazione di imprese
                {
                    SiarBLL.AggregazioneCollectionProvider aggregazione_provider = new AggregazioneCollectionProvider(progetto_provider.DbProviderObj);
                    SiarBLL.ImpresaAggregazioneCollectionProvider impresa_aggregazione_provider = new ImpresaAggregazioneCollectionProvider(progetto_provider.DbProviderObj);

                    //int? idImpresaPrincipale = null;
                    var aggregazione = new Aggregazione();
                    aggregazione.Denominazione = "aggregazione per import progetto bando " + progetto.DatiGenerali.IdBandoSigef.ToString();
                    aggregazione.CodTipoAggregazione = progetto.DatiGenerali.TipoAggregazione.ToString();
                    aggregazione.DataInizio = progetto.DatiGenerali.DataPresentazione;
                    aggregazione.DataFine = progetto.DatiGenerali.DataPresentazione.AddYears(5);
                    aggregazione.Attivo = true;
                    aggregazione.OperatoreInizio = 1;
                    aggregazione_provider.Save(aggregazione);

                    progSogg.TipoNaturaSoggetto = "Aggregata";
                    progSogg.IdAggregazione = aggregazione.Id;

                    //SiarLibrary.ImpresaAggregazione impAgg = new ImpresaAggregazione();
                    foreach (BeneficiarioType item in progetto.Beneficiari.Beneficiario)
                    {
                        SiarLibrary.ImpresaAggregazione impAgg = new ImpresaAggregazione();
                        impresa = impresa_provider.Find(null, item.PartitaIva, null).ToArrayList<Impresa>().FirstOrDefault();
                        if (impresa != null) //impresa già presente
                        {
                            impAgg.IdImpresa = impresa.IdImpresa;
                            impreseDictionary.Add(impresa.IdImpresa, item.PartitaIva);

                            var impresaStorico = new ImpresaStorico();
                            impresaStorico.RagioneSociale = item.RagioneSociale;
                            impresaStorico.DataInizioValidita = DateTime.Now;
                            impresaStorico.RegistroImpreseNumero = item.NumeroRegistroImprese;
                            impresaStorico.ReaNumero = item.NumeroREA;
                            impresaStorico.ReaAnno = item.AnnoIscrizioneREA;
                            impresaStorico.CodAteco2007 = item.CodiceATECO2007;
                            impresaStorico.IdDimensione = item.DimensioneImpresa;
                            impresaStorico.CodFormaGiuridica = item.CodiceFormaGiuridica;
                            impresaStorico.IdImpresa = impresa.IdImpresa;
                            impresa_storico_prov.Save(impresaStorico);
                            impresa.IdStoricoUltimo = impresaStorico.IdStoricoImpresa;
                            impresa_provider.Save(impresa);

                            //Aggiorno la sede precedente
                            var indirizzarioOld = indirizzario_provider.GetById(impresa.IdSedelegaleUltimo);
                            indirizzarioOld.FlagAttivo = false;
                            indirizzario_provider.Save(indirizzarioOld);
                            //nuova sede
                            var sedeLegale = new Indirizzo();
                            string istatProvSL = item.SedeLegale.ISTAT6.Substring(0, 3);
                            string istatComuneSL = item.SedeLegale.ISTAT6.Substring(3, 3);
                            int idComuneSL = comuni_provider.Find(null, istatProvSL, null, null, null, istatComuneSL, null, null).ToArrayList<Comuni>().FirstOrDefault().IdComune;
                            sedeLegale.IdComune = idComuneSL;
                            sedeLegale.Via = item.SedeLegale.Indirizzo;
                            indirizzo_provider.Save(sedeLegale);
                            var indirizzario = new Indirizzario();
                            indirizzario.IdImpresa = idImpresaPrincipale;
                            indirizzario.IdIndirizzo = sedeLegale.IdIndirizzo;
                            indirizzario.DataInizioValidita = DateTime.Now;
                            indirizzario.CodTipoSede = "S";
                            indirizzario.FlagAttivo = true;
                            indirizzario.Email = item.Email;
                            indirizzario.Pec = item.Pec;
                            indirizzario.Telefono = item.Telefono;
                            indirizzario_provider.Save(indirizzario);
                            impresa.IdSedelegaleUltimo = indirizzario.IdIndirizzario;
                            impresa_provider.Save(impresa);

                            //aggiorno il rappresentante legale
                            var rappresentanteLegaleColl = persona_fisica_provider.Find(item.RappresentanteLegale.CodiceFiscale).ToArrayList<PersonaFisica>();
                            if (rappresentanteLegaleColl.Any()) //persona fisica esistente in banca dati
                            {
                                var personaImpresa = persone_imprese_provider.GetById(impresa.IdRapprlegaleUltimo);
                                var rappresentanteLegale = rappresentanteLegaleColl.FirstOrDefault();
                                if (personaImpresa.IdPersona != rappresentanteLegale.IdPersona)
                                {
                                    //aggiorno il precedente rapp. legale
                                    personaImpresa.Attivo = false;
                                    persone_imprese_provider.Save(personaImpresa);
                                    var personeXImprese = new PersoneXImprese();
                                    personeXImprese.IdImpresa = idImpresaPrincipale;
                                    personeXImprese.IdPersona = rappresentanteLegale.IdPersona;
                                    personeXImprese.Attivo = true;
                                    personeXImprese.CodRuolo = "R";
                                    personeXImprese.DataInizio = DateTime.Now;
                                    personeXImprese.Ammesso = true;
                                    persone_imprese_provider.Save(personeXImprese);
                                    impresa.IdRapprlegaleUltimo = personeXImprese.IdPersoneXImprese;
                                    impresa_provider.Save(impresa);
                                }
                            }
                            else //il rapp. legale non esiste in banca dati
                            {
                                //aggiorno il precedente rapp. legale
                                var personaImpresa = persone_imprese_provider.GetById(impresa.IdRapprlegaleUltimo);
                                personaImpresa.Attivo = false;
                                persone_imprese_provider.Save(personaImpresa);
                                //nuovo rapp. legale
                                var rappresentanteLegale = new PersonaFisica();
                                var personeXImprese = new PersoneXImprese();
                                rappresentanteLegale.Nome = item.RappresentanteLegale.Nome;
                                rappresentanteLegale.Cognome = item.RappresentanteLegale.Cognome;
                                rappresentanteLegale.DataNascita = item.RappresentanteLegale.DataNascita;
                                string belfiore = item.RappresentanteLegale.CodiceFiscale.Substring(11, 4);
                                int idComune;
                                if (belfiore.StartsWith("Z"))
                                {
                                    idComune = comuni_provider.Find(belfiore, null, null, null, null, null, null, null).ToArrayList<Comuni>().FirstOrDefault().IdComune;
                                }
                                else
                                {
                                    string istatProv = item.RappresentanteLegale.ISTAT6Nascita.Substring(0, 3);
                                    string istatComune = item.RappresentanteLegale.ISTAT6Nascita.Substring(3, 3);
                                    idComune = comuni_provider.Find(null, istatProv, null, null, null, istatComune, null, null).ToArrayList<Comuni>().FirstOrDefault().IdComune;
                                }
                                rappresentanteLegale.IdComuneNascita = idComune;
                                rappresentanteLegale.IdComuneNascita = idComune;
                                rappresentanteLegale.CodiceFiscale = item.RappresentanteLegale.CodiceFiscale;
                                persona_fisica_provider.Save(rappresentanteLegale);
                                personeXImprese.IdImpresa = idImpresaPrincipale;
                                personeXImprese.IdPersona = rappresentanteLegale.IdPersona;
                                personeXImprese.Attivo = true;
                                personeXImprese.CodRuolo = "R";
                                personeXImprese.DataInizio = DateTime.Now;
                                personeXImprese.Ammesso = true;
                                persone_imprese_provider.Save(personeXImprese);
                                impresa.IdRapprlegaleUltimo = personeXImprese.IdPersoneXImprese;
                                impresa_provider.Save(impresa);
                            }
                        }
                        else //nuova impresa
                        {
                            impresa = new Impresa();
                            impresa.Cuaa = item.CodiceFiscale;
                            impresa.CodiceFiscale = item.PartitaIva;
                            impresa_provider.Save(impresa);
                            impreseDictionary.Add(impresa.IdImpresa, item.PartitaIva);

                            var impresaStorico = new ImpresaStorico();
                            impresaStorico.RagioneSociale = item.RagioneSociale;
                            impresaStorico.DataInizioValidita = DateTime.Now;
                            impresaStorico.RegistroImpreseNumero = item.NumeroRegistroImprese;
                            impresaStorico.ReaNumero = item.NumeroREA;
                            impresaStorico.ReaAnno = item.AnnoIscrizioneREA;
                            impresaStorico.CodAteco2007 = item.CodiceATECO2007;
                            impresaStorico.IdDimensione = item.DimensioneImpresa;
                            impresaStorico.CodFormaGiuridica = item.CodiceFormaGiuridica;
                            impresaStorico.IdImpresa = impresa.IdImpresa;
                            impresa_storico_prov.Save(impresaStorico);
                            
                            impresa.IdStoricoUltimo = impresaStorico.IdStoricoImpresa;
                            impresa_provider.Save(impresa);

                            impAgg.IdImpresa = impresa.IdImpresa;

                            //rappresentante legale
                            var rappresentanteLegaleColl = persona_fisica_provider.Find(item.RappresentanteLegale.CodiceFiscale).ToArrayList<PersonaFisica>();
                            if (rappresentanteLegaleColl.Any())
                            {
                                var rappresentanteLegale = rappresentanteLegaleColl.FirstOrDefault();
                                var personeXImprese = new PersoneXImprese();
                                personeXImprese.IdImpresa = idImpresaPrincipale;
                                personeXImprese.IdPersona = rappresentanteLegale.IdPersona;
                                personeXImprese.Attivo = true;
                                personeXImprese.CodRuolo = "R";
                                personeXImprese.DataInizio = DateTime.Now;
                                personeXImprese.Ammesso = true;
                                persone_imprese_provider.Save(personeXImprese);
                                impresa.IdRapprlegaleUltimo = personeXImprese.IdPersoneXImprese;
                                impresa_provider.Save(impresa);
                            }
                            else //il rapp. legale non esiste in banca dati
                            {
                                //nuovo Rappresentante Legale
                                var rappresentanteLegale = new PersonaFisica();
                                var personeXImprese = new PersoneXImprese();
                                rappresentanteLegale.Nome = item.RappresentanteLegale.Nome;
                                rappresentanteLegale.Cognome = item.RappresentanteLegale.Cognome;
                                rappresentanteLegale.DataNascita = item.RappresentanteLegale.DataNascita;
                                string belfiore = item.RappresentanteLegale.CodiceFiscale.Substring(11, 4);
                                int idComune;
                                if (belfiore.StartsWith("Z"))
                                {
                                    idComune = comuni_provider.Find(belfiore, null, null, null, null, null, null, null).ToArrayList<Comuni>().FirstOrDefault().IdComune;
                                }
                                else
                                {
                                    string istatProv = item.RappresentanteLegale.ISTAT6Nascita.Substring(0, 3);
                                    string istatComune = item.RappresentanteLegale.ISTAT6Nascita.Substring(3, 3);
                                    idComune = comuni_provider.Find(null, istatProv, null, null, null, istatComune, null, null).ToArrayList<Comuni>().FirstOrDefault().IdComune;
                                }
                                rappresentanteLegale.IdComuneNascita = idComune;
                                rappresentanteLegale.CodiceFiscale = item.RappresentanteLegale.CodiceFiscale;
                                persona_fisica_provider.Save(rappresentanteLegale);
                                personeXImprese.IdImpresa = idImpresaPrincipale;
                                personeXImprese.IdPersona = rappresentanteLegale.IdPersona;
                                personeXImprese.Attivo = true;
                                personeXImprese.CodRuolo = "R";
                                personeXImprese.DataInizio = DateTime.Now;
                                personeXImprese.Ammesso = true;
                                persone_imprese_provider.Save(personeXImprese);
                                impresa.IdRapprlegaleUltimo = personeXImprese.IdPersoneXImprese;
                                impresa_provider.Save(impresa);
                            }


                            var sedeLegale = new Indirizzo();
                            string istatProvSL = item.SedeLegale.ISTAT6.Substring(0, 3);
                            string istatComuneSL = item.SedeLegale.ISTAT6.Substring(3, 3);
                            int idComuneSL = comuni_provider.Find(null, istatProvSL, null, null, null, istatComuneSL, null, null).ToArrayList<Comuni>().FirstOrDefault().IdComune;
                            sedeLegale.IdComune = idComuneSL;
                            sedeLegale.Via = item.SedeLegale.Indirizzo;
                            indirizzo_provider.Save(sedeLegale);
                            var indirizzario = new Indirizzario();
                            indirizzario.IdImpresa = idImpresaPrincipale;
                            indirizzario.IdIndirizzo = sedeLegale.IdIndirizzo;
                            indirizzario.DataInizioValidita = DateTime.Now;
                            indirizzario.CodTipoSede = "S";
                            indirizzario.FlagAttivo = true;
                            indirizzario.Email = item.Email;
                            indirizzario.Pec = item.Pec;
                            indirizzario.Telefono = item.Telefono;
                            indirizzario_provider.Save(indirizzario);
                            impresa.IdSedelegaleUltimo = indirizzario.IdIndirizzario;
                            impresa_provider.Save(impresa);

                        }


                        if (item.IsSoggettoPrincipale && string.IsNullOrEmpty(item.IBAN))
                            throw new Exception("IBAN dell'impresa principale non presente");

                        //inserimento conto corrente
                        string iban = item.IBAN;
                        if (!string.IsNullOrEmpty(item.IBAN))
                        {
                            var conto = new ContoCorrente();
                            conto.IdImpresa = idImpresaPrincipale;
                            conto.CodPaese = iban.Substring(0, 2);
                            conto.CinEuro = iban.Substring(2, 2);
                            conto.Cin = iban.Substring(4, 1);
                            conto.Abi = iban.Substring(5, 5);
                            conto.Cab = iban.Substring(10, 5);
                            conto.Numero = iban.Substring(15);
                            Dictionary<string, object> dt = SiarLibrary.DbStaticProvider.GetDatiBancaByCC(conto.Abi, conto.Cab);
                            conto.Istituto = dt["Istituto"].ToString();
                            conto.Agenzia = dt["Agenzia"].ToString();
                            conto.IdComune = dt["IdComune"].ToString();
                            conto_corrente_provider.Save(conto);
                            impresa.IdContoCorrenteUltimo = conto.IdContoCorrente;
                            impresa_provider.Save(impresa);
                        }
                        

                        //inserimento requisiti soggettivi impresa
                        var requisitiImpresa = item.RequisitiImpresa.RequisitoImpresa;
                        var requisitiImpresaDesc = item.RequisitiImpresa.RequisitoImpresa.Select(i => i.ChiaveDescrizione).ToList();

                        if (!CheckSetMinimoProgetto(requisitiImpresaDesc, prioritaSetMinimo, "P"))
                            throw new Exception("E' assente o incompleto il set minimo di requisiti soggettivi previsto per le imprese nei progetti FESR");

                        var prioritaxImpresa = schedaXPriorita_provider.Find(bando.IdSchedaValutazione, null, null, null, null).ToArrayList<SchedaXPriorita>().FindAll(n => n.CodLivello == "P");

                        foreach (SchedaXPriorita prioritaScheda in prioritaxImpresa)
                        {
                            //inserisco in prioritaximpresa tipo P
                            var prioritaImpresa = new PrioritaXImpresa();
                            var prProgetto = priorita_provider.GetById(prioritaScheda.IdPriorita);
                            var reqProgetto = requisitiImpresa.FindAll(x => x.ChiaveDescrizione == prProgetto.Descrizione).FirstOrDefault();
                            var idImpresa = impresa.IdImpresa;

                            prioritaImpresa.IdPriorita = prioritaScheda.IdPriorita;
                            prioritaImpresa.IdImpresa = idImpresa;

                            if (prProgetto.Datetime)
                                prioritaImpresa.ValData = DateTime.Parse(reqProgetto.Valore);

                            if (prProgetto.PluriValore)
                            {
                                var valorePriorita = valori_priorita_provider.Find(null, prProgetto.IdPriorita, null).ToArrayList<ValoriPriorita>().FindAll(v => v.Descrizione == reqProgetto.Valore).FirstOrDefault();
                                if (valorePriorita != null)
                                {
                                    prioritaImpresa.IdValore = valorePriorita.IdValore;
                                }
                            }

                            if (prProgetto.InputNumerico)
                                prioritaImpresa.Valore = Decimal.Parse(reqProgetto.Valore);

                            if (prProgetto.TestoSemplice)
                                prioritaImpresa.ValTesto = reqProgetto.Valore;

                            requisitiImpresaColl.Add(prioritaImpresa);

                        }


                        impAgg.IdAggregazione = aggregazione.Id;
                        impAgg.CodRuolo = item.IsSoggettoPrincipale ? "C" : "P";
                        impAgg.Attivo = true;
                        impAgg.DataInizio = aggregazione.DataInizio;
                        impAgg.OperatoreInizio = 1;
                        impresa_aggregazione_provider.Save(impAgg);
                        if (item.IsSoggettoPrincipale)
                        {
                            idImpresaPrincipale = impresa.IdImpresa;
                        }
                    }
                }

                SiarLibrary.Progetto p = new SiarLibrary.Progetto();
                p.FlagDefinitivo = true;
                p.FlagPreadesione = false;
                p.IdBando = progetto.DatiGenerali.IdBandoSigef;
                p.DataCreazione = DateTime.Now;
                p.OperatoreCreazione = 1;
                p.IdImpresa = idImpresaPrincipale;
                progetto_provider.Save(p);

                //aggiorno ProgettoNaturaSoggetto
                progSogg.IdProgetto = p.IdProgetto;
                progetto_natura_soggetto_provider.Save(progSogg);

                //progetto storico
                SiarLibrary.ProgettoStorico s = new SiarLibrary.ProgettoStorico();
                s.IdProgetto = p.IdProgetto;
                s.CodStato = "P";
                s.Data = progetto.DatiGenerali.DataPresentazione;
                s.Operatore = 1;
                SiarLibrary.ProgettoStorico l = new SiarLibrary.ProgettoStorico();
                l.IdProgetto = p.IdProgetto;
                l.CodStato = "L";
                l.Data = progetto.DatiGenerali.DataPresentazione;
                l.Segnatura = progetto.DatiGenerali.SegnaturaProtocollo;
                l.Operatore = 1;
                SiarLibrary.ProgettoStorico si = new SiarLibrary.ProgettoStorico();
                si.IdProgetto = p.IdProgetto;
                si.CodStato = "I";
                si.Data = progetto.DatiGenerali.DataPresentazione;
                si.Segnatura = progetto.DatiGenerali.SegnaturaProtocollo;
                si.Operatore = 1;

                storico_provider.Save(s);
                storico_provider.Save(l);
                storico_provider.Save(si);
                p.IdStoricoUltimo = si.Id;
                progetto_provider.Save(p);

                //aggiorno requisiti per impresa
                foreach(PrioritaXImpresa prioritaImpresa in requisitiImpresaColl)
                {
                    prioritaImpresa.IdProgetto = p.IdProgetto;
                }

                priorita_impresa_provider.SaveCollection(requisitiImpresaColl);


                //relazione tecnica
                var bandoRelazioneTecnica = bando_relazione_provider.Find(progetto.DatiGenerali.IdBandoSigef).ToArrayList<BandoRelazioneTecnica>();
                foreach(ProgettoRelazioneTecnicaCompilazione item in progetto.RelazioneTecnica.Compilazione)
                {
                    var progParagrafo = new SiarLibrary.ProgettoRelazioneTecnica();
                    var bt = bandoRelazioneTecnica.FindAll(x => x.Titolo == item.Paragrafo.Titolo).FirstOrDefault();
                    if(bt == null)
                    {
                        throw new Exception("Non è stata trovata corrispondenza tra il paragrafo: " + item.Paragrafo.Titolo + " e la configurazione del bando");
                    }
                    progParagrafo.IdParagrafo = bt.IdParagrafo;
                    progParagrafo.IdBando = progetto.DatiGenerali.IdBandoSigef;
                    progParagrafo.Testo = item.Contenuto;
                    progParagrafo.IdProgetto = p.IdProgetto;
                    progetto_relazione_provider.Save(progParagrafo);
                }

                //dati monitoraggio
                var dmfr = new DatiMonitoraggioFESR();
                dmfr.IdCUPCategoria = progetto.DatiMonitoraggio.ClassificazioneCUP;
                dmfr.IdCUPCategoriaSoggetto = progetto.DatiMonitoraggio.CategoriaSoggettoCUP;
                dmfr.IdTemaPrioritario = progetto.DatiMonitoraggio.TemaPrioritario;
                dmfr.IdAteco2007 = progetto.DatiMonitoraggio.CodiceATECO2007;
                dmfr.IdAttivitaEcon = progetto.DatiMonitoraggio.AttivitaEconomica;
                dmfr.IdCPTSettore = progetto.DatiMonitoraggio.SettoreCPT;
                dmfr.IdDimensioneTerr = progetto.DatiMonitoraggio.DimensioneTerritoriale;
                dmfr.IdCUPNatura = progetto.DatiMonitoraggio.CodiceNaturaCUP.Substring(0, 2);
                dmfr.IdCUPCategoriaTipoOperazione = progetto.DatiMonitoraggio.CodiceNaturaCUP;
                dmfr.IdProgetto = p.IdProgetto;
                dati_monitoraggio_provider.Save(dmfr);

                //requisiti soggettivi
                var requisiti = progetto.RequisitiProgetto.RequisitoSoggettivo;
                var requisitiDesc = progetto.RequisitiProgetto.RequisitoSoggettivo.Select(d => d.ChiaveDescrizione).ToList();

                if (!CheckSetMinimoProgetto(requisitiDesc, prioritaSetMinimo, "D"))
                    throw new Exception("E' assente o incompleto il set minimo di requisiti soggettivi previsto per i progetti FESR");

                var prioritaProgetto = schedaXPriorita_provider.Find(bando.IdSchedaValutazione, null, null, null, null).ToArrayList<SchedaXPriorita>().FindAll(n => n.CodLivello == "D");

                //inserisco in prioritaxprogetto tipo D
                foreach (SchedaXPriorita prioritaScheda in prioritaProgetto)
                {
                    var prioritaxProgetto = new PrioritaXProgetto();
                    var prProgetto = priorita_provider.GetById(prioritaScheda.IdPriorita);
                    var reqProgetto = requisiti.FindAll(x => x.ChiaveDescrizione == prProgetto.Descrizione).FirstOrDefault();

                    prioritaxProgetto.IdPriorita = prioritaScheda.IdPriorita;
                    prioritaxProgetto.IdProgetto = p.IdProgetto;

                    if (prProgetto.Datetime)
                        prioritaxProgetto.ValData = DateTime.Parse(reqProgetto.Valore);

                    if (prProgetto.PluriValore)
                    {
                        var valorePriorita = valori_priorita_provider.Find(null, prProgetto.IdPriorita, null).ToArrayList<ValoriPriorita>().FindAll(v => v.Descrizione == reqProgetto.Valore).FirstOrDefault();
                        if (valorePriorita != null)
                        {
                            prioritaxProgetto.IdValore = valorePriorita.IdValore;
                        }
                    }

                    if (prProgetto.InputNumerico)
                        prioritaxProgetto.Valore = Decimal.Parse(reqProgetto.Valore);

                    if (prProgetto.TestoSemplice)
                        prioritaxProgetto.ValTesto = reqProgetto.Valore;

                    priorita_progetto_provider.Save(prioritaxProgetto);

                }

                //piano investimenti
                foreach (InvestimentoType item in progetto.PianoInvestimenti.Investimento)
                {
                    SiarLibrary.PianoInvestimenti investimento = new PianoInvestimenti();
                    var intervento = interventi_provider.Find(item.CodiceProgrammazione, null, progetto.DatiGenerali.CodiceFondo, null, null, null)[0];
                    investimento.IdProgetto = p.IdProgetto;
                    investimento.IdProgrammazione = intervento.Id;
                    investimento.CodTipoInvestimento = 1;

                    var dettaglioInvestimentoColl = dettaglio_investimenti_provider.FindByIdBando(bando.IdBando, null).ToArrayList<DettaglioInvestimenti>();
                    var dettInvestimento = dettaglioInvestimentoColl.FindAll(di => di.CodDettaglio.ToString().Trim() == item.CodiceDettaglioInvestimento).FirstOrDefault();
                    var specInvestimento = spec_investimenti_provider.Find(dettInvestimento.IdDettaglioInvestimento, item.CodiceSpecificaInvestimento)
                        .ToArrayList<SpecificaInvestimenti>()
                        .FirstOrDefault();
                    investimento.IdCodificaInvestimento = dettInvestimento.IdCodificaInvestimento;
                    investimento.IdDettaglioInvestimento = dettInvestimento.IdDettaglioInvestimento;
                    investimento.IdSpecificaInvestimento = specInvestimento != null ? specInvestimento.IdSpecificaInvestimento : null;
                    investimento.IdUnitaMisura = 8;
                    investimento.Quantita = 1;
                    investimento.CodStp = item.CodiceSottotipologiaCUP;
                    investimento.SpeseGenerali = 0;
                    investimento.ContributoRichiesto = item.ContributoRichiesto;
                    investimento.CostoInvestimento = item.CostoInvestimento;
                    investimento.QuotaContributoRichiesto = item.QuotaContributoRIchiesto;
                    investimento.Descrizione = item.DescrizioneInvestimento;

                    Dictionary<string, int> reverseLookup = impreseDictionary.ToDictionary(kv => kv.Value, kv => kv.Key);
                    var idImpresaInvestimento = reverseLookup[item.PartitaIvaImpresa];

                    if (flagRaggruppamento && progetto.Beneficiari.Beneficiario.Count > 1)
                    {
                        investimento.IdImpresaAggregazione = idImpresaInvestimento;
                    }
                    piano_investimenti_provider.Save(investimento);

                    //creo i cloni degli investimenti e delle priorità
                    investimento.MarkAsNew();
                    investimento.IdInvestimentoOriginale = investimento.IdInvestimento;
                    investimento.Ammesso = false;
                    investimento.IdInvestimento = null;
                    piano_investimenti_provider.Save(investimento);

                    //inserimento progressivi investimento
                    var progressivo = new ImportServiceProgressivoInvestimenti();
                    progressivo.Progressivo = item.ProgressivoInvestimento;
                    progressivo.IdProgetto = p.IdProgetto;
                    progressivo.IdInvestimento = investimento.IdInvestimento;
                    progressivo_provider.Save(progressivo);

                    SiarLibrary.PrioritaXInvestimentiCollection priorita = priorita_investimento_provider.Find(null, investimento.IdInvestimentoOriginale, null, null);
                    foreach (SiarLibrary.PrioritaXInvestimenti pr in priorita)
                    {
                        pr.MarkAsNew();
                        pr.IdInvestimento = investimento.IdInvestimento;
                        priorita_investimento_provider.Save(pr);
                    }

                    //inserimento priorità investimento
                    var requisitiInvestimento = item.RequisitiInvestimento.RequisitoInvestimento;
                    var requisitiInvestimentoDesc = item.RequisitiInvestimento.RequisitoInvestimento.Select(i => i.ChiaveDescrizione).ToList();

                    if (!CheckSetMinimoProgetto(requisitiInvestimentoDesc, prioritaSetMinimo, "I"))
                        throw new Exception("E' assente o incompleto il set minimo di requisiti soggettivi previsto per gli investimenti nei progetti FESR");

                    var prioritaInvestimento = schedaXPriorita_provider.Find(bando.IdSchedaValutazione, null, null, null, null).ToArrayList<SchedaXPriorita>().FindAll(n => n.CodLivello == "I");

                    //inserisco in prioritaxinvestimenti tipo I
                    foreach (SchedaXPriorita prioritaScheda in prioritaInvestimento)
                    {
                        var prioritaxInvestimento = new PrioritaXInvestimenti();
                        var prInvestimento = priorita_provider.GetById(prioritaScheda.IdPriorita);
                        var reqInvestimento = requisitiInvestimento.FindAll(x => x.ChiaveDescrizione == prInvestimento.Descrizione).FirstOrDefault();

                        prioritaxInvestimento.IdPriorita = prioritaScheda.IdPriorita;
                        prioritaxInvestimento.IdInvestimento = investimento.IdInvestimentoOriginale;

                        if (prInvestimento.Datetime)
                            prioritaxInvestimento.ValData = DateTime.Parse(reqInvestimento.Valore);

                        if (prInvestimento.PluriValore)
                        {
                            var valorePriorita = valori_priorita_provider.Find(null, prInvestimento.IdPriorita, null).ToArrayList<ValoriPriorita>().FindAll(v => v.Descrizione == reqInvestimento.Valore).FirstOrDefault();
                            if (valorePriorita != null)
                            {
                                prioritaxInvestimento.IdValore = valorePriorita.IdValore;
                            }
                        }

                        if (prInvestimento.InputNumerico)
                            prioritaxInvestimento.Valore = Decimal.Parse(reqInvestimento.Valore);

                        if (prInvestimento.TestoSemplice)
                            prioritaxInvestimento.ValTesto = reqInvestimento.Valore;

                        priorita_investimento_provider.Save(prioritaxInvestimento);

                        //clono le priorità 
                        prioritaxInvestimento.MarkAsNew();
                        prioritaxInvestimento.IdInvestimento = investimento.IdInvestimento;
                        priorita_investimento_provider.Save(prioritaxInvestimento);
                    }

                }

                //localizzazione
                foreach(LocalizzazioneType item in progetto.Localizzazioni.Localizzazione)
                {
                    string istatProv = item.ISTAT6.Substring(0, 3);
                    string istatComune = item.ISTAT6.Substring(3, 3);
                    var localizzazione = new SiarLibrary.LocalizzazioneProgetto();
                    int idComune = comuni_provider.Find(null, istatProv, null, null, null, istatComune, null, null).ToArrayList<Comuni>().FirstOrDefault().IdComune;
                    var imp = impresa_provider.Find(null, item.PartitaIvaImpresa, null).ToArrayList<Impresa>().FirstOrDefault();
                    localizzazione.IdProgetto = p.IdProgetto;
                    localizzazione.IdImpresa = imp.IdImpresa;
                    localizzazione.IdComune = idComune;
                    localizzazione.Cap = item.CAP;
                    localizzazione.Via = item.Indirizzo;
                    localizzazione.Dug = GetDug(item.DUG);
                    localizzazione.Num = item.Numero;
                    localizzazione.Quota = 100;
                    localizzazione_provider.Save(localizzazione);
                }

                //indicatori monitoraggio
                foreach(IndicatoreType item in progetto.IndicatoriMonitoraggio.Indicatore)
                {
                    var progettoIndicatori = new SiarLibrary.ProgettoIndicatori();
                    var intervento = interventi_provider.Find(item.CodiceProgrammazione, null, progetto.DatiGenerali.CodiceFondo, null, null, null).ToArrayList<Zprogrammazione>().FirstOrDefault();
                    var ind = zdimensioni_provider.GetByIdProgramCodiceInd(intervento.Id, item.Codice).ToArrayList<Zdimensioni>().FirstOrDefault();
                    var dimProg = zdimensioni_prog_provider.Select(intervento.Id, ind.Id, null).ToArrayList<ZdimensioniXProgrammazione>().FirstOrDefault();
                    progettoIndicatori.IdProgetto = p.IdProgetto;
                    progettoIndicatori.IdDimXProgrammazione = dimProg.IdDimXProgrammazione;
                    progettoIndicatori.CodTipo = "DOMANDA";
                    progettoIndicatori.ValoreProgrammatoRichiesto = item.Valore;
                    progettoIndicatori.ValoreRealizzatoRichiesto = item.Valore;
                    progettoIndicatori.DataRegistrazione = DateTime.Now;
                    progettoIndicatori.Operatore = 1;

                    progetto_indicatori_provider.Save(progettoIndicatori);                   
                }

                //iter progetto
                var checklistSteps = checklist_step_provider.Find(idStandardChecklist, null, null, null, null, null, null);
                foreach(CheckListXStep item in checklistSteps)
                {
                    var iterProgetto = new IterProgetto();
                    iterProgetto.IdProgetto = p.IdProgetto;
                    iterProgetto.IdStep = item.IdStep;
                    iterProgetto.CodEsito = "SI";
                    iterProgetto.Data = progetto.DatiGenerali.DataPresentazione;
                    iterProgetto.CfOperatore = null;
                    iter_provider.Save(iterProgetto);
                }


                progetto_provider.DbProviderObj.Commit();
                return p.IdProgetto;
            }
            catch (Exception ex)
            {
                progetto_provider.DbProviderObj.Rollback();
                throw ex;
            }

        }

        internal int InsertDomandaPagamentoByService(DomandaPagamento domandaPagamento)
        {
            ImportServiceProgressivoInvestimentiCollectionProvider progressivoInvestimentiProvider = new ImportServiceProgressivoInvestimentiCollectionProvider();
            ZprogrammazioneCollectionProvider interventiProvider = new ZprogrammazioneCollectionProvider();
            ZdimensioniCollectionProvider zdimensioniProvider = new ZdimensioniCollectionProvider();
            ZdimensioniXProgrammazioneCollectionProvider zdimensioniProgProvider = new ZdimensioniXProgrammazioneCollectionProvider();
            ProgettoCollectionProvider progettoProvider = new ProgettoCollectionProvider();
            BandoRequisitiPagamentoCollectionProvider bandoRequisitiProvider = new BandoRequisitiPagamentoCollectionProvider();

            DomandaDiPagamentoCollectionProvider domandaPagamentoProvider = new DomandaDiPagamentoCollectionProvider();
            DomandaDiPagamentoEsportazioneCollectionProvider domandaPagamentoEsportazioneProvider = new DomandaDiPagamentoEsportazioneCollectionProvider(domandaPagamentoProvider.DbProviderObj);
            GiustificativiCollectionProvider giustificativiProvider = new GiustificativiCollectionProvider(domandaPagamentoProvider.DbProviderObj);
            SpeseSostenuteCollectionProvider speseSostenuteProvider = new SpeseSostenuteCollectionProvider(domandaPagamentoProvider.DbProviderObj);
            PagamentiBeneficiarioCollectionProvider pagamentiBeneficiarioProvider = new PagamentiBeneficiarioCollectionProvider(domandaPagamentoProvider.DbProviderObj);
            PagamentiRichiestiCollectionProvider pagamentiRichiestiProvider = new PagamentiRichiestiCollectionProvider(domandaPagamentoProvider.DbProviderObj);
            ProgettoIndicatoriCollectionProvider progettoIndicatoriProvider = new ProgettoIndicatoriCollectionProvider(domandaPagamentoProvider.DbProviderObj);
            RequisitiPagamentoCollectionProvider requisitiPagamentoProvider = new RequisitiPagamentoCollectionProvider(domandaPagamentoProvider.DbProviderObj);       
            DomandaPagamentoRequisitiCollectionProvider requisitiDomandaPagamentoProvider = new DomandaPagamentoRequisitiCollectionProvider(domandaPagamentoProvider.DbProviderObj);
            ProgettoCollectionProvider progettoUpdateProvider = new ProgettoCollectionProvider(domandaPagamentoProvider.DbProviderObj);
            ProgettoStoricoCollectionProvider progettoStoricoProvider = new ProgettoStoricoCollectionProvider(domandaPagamentoProvider.DbProviderObj);


            try
            {
                //inizio transazione
                domandaPagamentoProvider.DbProviderObj.BeginTran();

                //domanda di pagamento
                var dpagamento = new DomandaDiPagamento();
                dpagamento.Segnatura = domandaPagamento.DatiGenerali.SegnaturaProtocollo;
                dpagamento.IdProgetto = domandaPagamento.DatiGenerali.IdProgettoSigef;
                dpagamento.CodTipo = Enum.GetName(typeof(DatiGeneraliDomandaPagamentoTypeTipoDomanda), domandaPagamento.DatiGenerali.TipoDomanda);
                dpagamento.CfOperatore = "";
                dpagamento.DataInserimento = domandaPagamento.DatiGenerali.DataPresentazione;
                dpagamento.DataModifica = domandaPagamento.DatiGenerali.DataPresentazione;
                dpagamento.FirmaPredisposta = false;

                domandaPagamentoProvider.Save(dpagamento);
                int idDomandaPagamento = dpagamento.IdDomandaPagamento;

                //domanda di pagamento esportazione
                var dpagamentoExp = new DomandaDiPagamentoEsportazione();
                dpagamentoExp.IdDomandaPagamento = idDomandaPagamento;
                dpagamentoExp.IdProgetto = dpagamento.IdProgetto;
                dpagamentoExp.Barcode = idDomandaPagamento.ToString() + dpagamento.IdProgetto.ToString();
                dpagamentoExp.MisuraPrevalente = true;
                dpagamentoExp.ImportoAmmissibile = domandaPagamento.DatiGenerali.ImportoDomandaPagamento;
                dpagamentoExp.ImportoSanzione = 0;
                dpagamentoExp.ImportoRecuperoAnticipo = 0;
                dpagamentoExp.FlagLiquidato = 0;

                domandaPagamentoEsportazioneProvider.Save(dpagamentoExp);

                //Giustificativi
                foreach(var voceSpesa in domandaPagamento.Rendicontazione.VoceSpesa)
                {
                    //pagamento richiesto
                    var pagamentoRichiesto = new PagamentiRichiesti();
                    pagamentoRichiesto.IdDomandaPagamento = dpagamento.IdDomandaPagamento;
                    var progressivoInvestimentiColl = progressivoInvestimentiProvider.Find(null, null, dpagamento.IdProgetto, null);
                    var progressivo = progressivoInvestimentiColl.Filter(voceSpesa.ProgressivoInvestimento)
                        .ToArrayList<ImportServiceProgressivoInvestimenti>()
                        .FirstOrDefault();

                    pagamentoRichiesto.IdInvestimento = progressivo.IdInvestimento;
                    pagamentoRichiesto.ImportoRichiesto = voceSpesa.ImportoPagamentoRichiestoVoceSpesa;
                    pagamentoRichiesto.ContributoRichiesto = voceSpesa.ImportoContributoRichiestoVoceSpesa;
                    pagamentoRichiesto.ImportoDisavanzoCostiAmmessi = 0;
                    pagamentoRichiesto.ContributoDisavanzoCostiAmmessi = 0;
                    pagamentoRichiesto.Ammesso = 0;
                    pagamentoRichiesto.DataRichiestaPagamento = domandaPagamento.DatiGenerali.DataPresentazione;

                    pagamentiRichiestiProvider.Save(pagamentoRichiesto);
                    
                    foreach(var giustificativoDomanda in voceSpesa.Giustificativi.Giustificativo)
                    {
                        var giustificativo = new Giustificativi();
                        giustificativo.Numero = giustificativoDomanda.Numero;
                        giustificativo.Data = giustificativoDomanda.Data;
                        giustificativo.CfFornitore = giustificativoDomanda.CodiceFiscaleFornitore;
                        giustificativo.DescrizioneFornitore = giustificativoDomanda.DescrizioneFornitore;
                        giustificativo.Descrizione = giustificativoDomanda.Descrizione;
                        giustificativo.IvaNonRecuperabile = giustificativoDomanda.FlagIvaNonRecuperabile;                       
                        giustificativo.Imponibile = giustificativoDomanda.ImportoImponibile;
                        giustificativo.Iva = giustificativoDomanda.IVA;
                        giustificativo.IdProgetto = domandaPagamento.DatiGenerali.IdProgettoSigef;
                        giustificativo.CodTipo = giustificativoDomanda.TipoGiustificativo;
                        giustificativo.InIntegrazione = false;

                        giustificativiProvider.Save(giustificativo);
                        //elencoGiustificativi.Add(giustificativo);
                        //gestione file in una rev successiva
                        //***
                        //

                        //spese associate
                        foreach(var spesaAssociata in giustificativoDomanda.SpeseSostenute.SpesaSostenuta)
                        {
                            var spesa = new SpeseSostenute();
                            spesa.IdDomandaPagamento = dpagamento.IdDomandaPagamento;
                            spesa.IdProgetto = dpagamento.IdProgetto;
                            spesa.IdGiustificativo = giustificativo.IdGiustificativo;
                            spesa.CodTipo = spesaAssociata.TipoSpesa;
                            spesa.Netto = spesaAssociata.ImportoNettoSpesaSostenuta;
                            spesa.Importo = spesaAssociata.ImportoSpesaSostenuta;
                            spesa.Data = spesaAssociata.DataSpesaSostenuta;
                            spesa.Estremi = spesaAssociata.EstremiSpesaSostenuta;

                            //gestione file in una rev successiva
                            //***
                            //
                            speseSostenuteProvider.Save(spesa);
                        }

                        //pagamento beneficiario
                        var pagamentoBeneficiario = new PagamentiBeneficiario();
                        pagamentoBeneficiario.IdGiustificativo = giustificativo.IdGiustificativo;
                        pagamentoBeneficiario.ImportoRichiesto = giustificativoDomanda.ImportoRichiestoGiustificativo;
                        pagamentoBeneficiario.SpesaTecnicaAmmessa = 0;
                        pagamentoBeneficiario.SpesaTecnicaAmmessaContr = 0;
                        pagamentoBeneficiario.SpesaTecnicaRichiesta = 0;
                        pagamentoBeneficiario.CostituisceVariante = false;
                        pagamentoBeneficiario.IdPagamentoRichiesto = pagamentoRichiesto.IdPagamentoRichiesto;
                        pagamentiBeneficiarioProvider.Save(pagamentoBeneficiario);
                        
                    }
                   
                }

                //requisiti domanda pagamento
                var idBando = progettoProvider.GetById(dpagamento.IdProgetto).IdBando;
                var setMinimo = GetSetMinimoDomandaPagamento(dpagamento.CodTipo);
                var requisitiPagamentoDesc = domandaPagamento.RequisitiDomandaPagamento.RequisitoDomandaPagamento.Select(i => i.ChiaveDescrizione).ToList();
                var requisitiBando = bandoRequisitiProvider.Find(idBando, dpagamento.CodTipo, null).ToArrayList<BandoRequisitiPagamento>();

                if (!CheckSetMinimoDomandaPagamento(requisitiPagamentoDesc, setMinimo))
                    throw new Exception("E' assente o incompleto il set minimo di requisiti previsto per le domande di pagamento FESR");

                foreach(var requisito in requisitiBando)
                {
                    var requisitoDomanda = new DomandaPagamentoRequisiti();
                    requisitoDomanda.IdDomandaPagamento = dpagamento.IdDomandaPagamento;
                    requisitoDomanda.IdRequisito = requisito.IdRequisito;
                    var d = domandaPagamento.RequisitiDomandaPagamento.RequisitoDomandaPagamento.FindAll(c => c.ChiaveDescrizione == requisito.Requisito).FirstOrDefault();

                    if (requisito.Datetime)
                        requisitoDomanda.ValData = DateTime.Parse(d.Valore);

                    if (requisito.Numerico)
                        requisitoDomanda.ValNumerico = Decimal.Parse(d.Valore);

                    if (requisito.TestoSemplice)
                        requisitoDomanda.ValTesto = d.Valore;

                    if (requisito.IdRequisito == idRequisitoControllo)
                    {
                        requisitoDomanda.Esito = d.Valore;
                        requisitoDomanda.DataEsito = domandaPagamento.DatiGenerali.DataPresentazione;
                    }
                    requisitiDomandaPagamentoProvider.Save(requisitoDomanda);
                }


                //indicatori monitoraggio
                foreach (IndicatoreDPType item in domandaPagamento.IndicatoriMonitoraggio.Indicatore)
                {
                    var progettoIndicatori = new ProgettoIndicatori();
                    var intervento = interventiProvider.Find(item.CodiceProgrammazione, null, domandaPagamento.DatiGenerali.CodiceFondo, null, null, null).ToArrayList<Zprogrammazione>().FirstOrDefault();
                    var ind = zdimensioniProvider.GetByIdProgramCodiceInd(intervento.Id, item.Codice).ToArrayList<Zdimensioni>().FirstOrDefault();
                    var dimProg = zdimensioniProgProvider.Select(intervento.Id, ind.Id, null).ToArrayList<ZdimensioniXProgrammazione>().FirstOrDefault();
                    progettoIndicatori.IdProgetto = dpagamento.IdProgetto;
                    progettoIndicatori.IdDomandaPagamento = dpagamento.IdDomandaPagamento;
                    progettoIndicatori.IdDimXProgrammazione = dimProg.IdDimXProgrammazione;
                    progettoIndicatori.CodTipo = "PAGAMENTO";
                    progettoIndicatori.ValoreProgrammatoRichiesto = item.Valore;
                    progettoIndicatori.ValoreRealizzatoRichiesto = item.Valore;
                    progettoIndicatori.DataRegistrazione = DateTime.Now;
                    progettoIndicatori.Operatore = 1;

                    progettoIndicatoriProvider.Save(progettoIndicatori);
                }

                //aggiornamento stato progetto
                var progettoStorico = new ProgettoStorico();
                
                progettoStorico.Segnatura = domandaPagamento.DatiGenerali.SegnaturaProtocollo;
                progettoStorico.Data = domandaPagamento.DatiGenerali.DataPresentazione;
                progettoStorico.IdProgetto = domandaPagamento.DatiGenerali.IdProgettoSigef;
                progettoStorico.Operatore = 1;

                if (dpagamento.CodTipo == "ANT")
                    progettoStorico.CodStato = "V";
                else
                    progettoStorico.CodStato = "S";

                progettoStoricoProvider.Save(progettoStorico);

                var progetto = progettoUpdateProvider.GetById(dpagamento.IdProgetto);
                progetto.IdStoricoUltimo = progettoStorico.Id;
                progettoUpdateProvider.Save(progetto);

                domandaPagamentoProvider.DbProviderObj.Commit();
                return dpagamento.IdDomandaPagamento;
            }
            catch (Exception ex)
            {
                domandaPagamentoProvider.DbProviderObj.Rollback();
                throw ex;
            }
        }


        internal int InsertDomandaPagamentoAnticipoByService(DomandaAnticipo domandaPagamento)
        {
            ZprogrammazioneCollectionProvider interventiProvider = new ZprogrammazioneCollectionProvider();
            ZdimensioniCollectionProvider zdimensioniProvider = new ZdimensioniCollectionProvider();
            ZdimensioniXProgrammazioneCollectionProvider zdimensioniProgProvider = new ZdimensioniXProgrammazioneCollectionProvider();
            BandoRequisitiPagamentoCollectionProvider bandoRequisitiProvider = new BandoRequisitiPagamentoCollectionProvider();
            ProgettoCollectionProvider progettoProvider = new ProgettoCollectionProvider();
            ImpresaCollectionProvider impresa_provider = new ImpresaCollectionProvider();

            DomandaDiPagamentoCollectionProvider domandaPagamentoProvider = new DomandaDiPagamentoCollectionProvider();
            DomandaDiPagamentoEsportazioneCollectionProvider domandaPagamentoEsportazioneProvider = new DomandaDiPagamentoEsportazioneCollectionProvider(domandaPagamentoProvider.DbProviderObj);
            DomandaPagamentoFidejussioneCollectionProvider domandaPagamentoFidejussioneProvider = new DomandaPagamentoFidejussioneCollectionProvider(domandaPagamentoProvider.DbProviderObj);
            DomandaPagamentoFidejussioneImpresaCollectionProvider domandaPagamentoFidejussioneImpresaProvider = new DomandaPagamentoFidejussioneImpresaCollectionProvider(domandaPagamentoProvider.DbProviderObj);
            ProgettoIndicatoriCollectionProvider progettoIndicatoriProvider = new ProgettoIndicatoriCollectionProvider(domandaPagamentoProvider.DbProviderObj);
            RequisitiPagamentoCollectionProvider requisitiPagamentoProvider = new RequisitiPagamentoCollectionProvider(domandaPagamentoProvider.DbProviderObj);
            DomandaPagamentoRequisitiCollectionProvider requisitiDomandaPagamentoProvider = new DomandaPagamentoRequisitiCollectionProvider(domandaPagamentoProvider.DbProviderObj);
            AnticipiRichiestiCollectionProvider anticipiRichiestiProvider = new AnticipiRichiestiCollectionProvider(domandaPagamentoProvider.DbProviderObj);
            ProgettoCollectionProvider progettoUpdateProvider = new ProgettoCollectionProvider(domandaPagamentoProvider.DbProviderObj);
            ProgettoStoricoCollectionProvider progettoStoricoProvider = new ProgettoStoricoCollectionProvider(domandaPagamentoProvider.DbProviderObj);

            try
            {
                //inizio transazione
                domandaPagamentoProvider.DbProviderObj.BeginTran();

                //domanda di pagamento
                var dpagamento = new DomandaDiPagamento();
                dpagamento.Segnatura = domandaPagamento.DatiGenerali.SegnaturaProtocollo;
                dpagamento.IdProgetto = domandaPagamento.DatiGenerali.IdProgettoSigef;
                dpagamento.CodTipo = "ANT";
                dpagamento.CfOperatore = "";
                dpagamento.DataInserimento = domandaPagamento.DatiGenerali.DataPresentazione;
                dpagamento.DataModifica = domandaPagamento.DatiGenerali.DataPresentazione;
                dpagamento.FirmaPredisposta = false;

                domandaPagamentoProvider.Save(dpagamento);
                int idDomandaPagamento = dpagamento.IdDomandaPagamento;

                //domanda di pagamento esportazione
                var dpagamentoExp = new DomandaDiPagamentoEsportazione();
                dpagamentoExp.IdDomandaPagamento = idDomandaPagamento;
                dpagamentoExp.IdProgetto = dpagamento.IdProgetto;
                dpagamentoExp.Barcode = idDomandaPagamento.ToString() + dpagamento.IdProgetto.ToString();
                dpagamentoExp.MisuraPrevalente = true;
                dpagamentoExp.ImportoAmmissibile = domandaPagamento.DatiGenerali.ImportoAnticipo;
                dpagamentoExp.ImportoSanzione = 0;
                dpagamentoExp.ImportoRecuperoAnticipo = 0;
                dpagamentoExp.FlagLiquidato = 0;

                domandaPagamentoEsportazioneProvider.Save(dpagamentoExp);

                //anticipi richiesti
                var anticipo = new AnticipiRichiesti();
                anticipo.IdDomandaPagamento = dpagamento.IdDomandaPagamento;
                var prg = progettoProvider.GetById(domandaPagamento.DatiGenerali.IdProgettoSigef);
                anticipo.IdBando = prg.IdBando;
                anticipo.DataRichiesta = domandaPagamento.DatiGenerali.DataPresentazione;
                anticipo.ContributoRichiesto = domandaPagamento.DatiGenerali.ImportoAnticipo;
                anticipiRichiestiProvider.Save(anticipo);

                //fidejussioni
                if (!domandaPagamento.FidejussioniImpresa.FidejussioneImpresa.Any())
                    throw new Exception("non è presente nessuna fidejussione nel tracciato");
                                
                //Domanda pagamento fidejussione
                var fidejussionePag = new DomandaPagamentoFidejussione();
                fidejussionePag.IdDomandaPagamento = dpagamento.IdDomandaPagamento;
                fidejussionePag.IdProgetto = domandaPagamento.DatiGenerali.IdProgettoSigef;
                fidejussionePag.DataCreazione = domandaPagamento.DatiGenerali.DataPresentazione;
                fidejussionePag.OperatoreCreazione = 1;
                domandaPagamentoFidejussioneProvider.Save(fidejussionePag);
                dpagamento.IdFidejussione = fidejussionePag.IdDomandaPagamentoFidejussione;
                domandaPagamentoProvider.Save(dpagamento);

                //Domanda pagamento fidejussione impresa
                foreach (DomandaAnticipoFidejussioniImpresaFidejussioneImpresa itemFidejussione in domandaPagamento.FidejussioniImpresa.FidejussioneImpresa)
                {
                    var fidejussioneImpresa = new DomandaPagamentoFidejussioneImpresa();
                    fidejussioneImpresa.IdDomandaPagamentoFidejussione = fidejussionePag.IdDomandaPagamentoFidejussione;
                    fidejussioneImpresa.IdDomandaPagamento = dpagamento.IdDomandaPagamento;
                    fidejussioneImpresa.IdProgetto = domandaPagamento.DatiGenerali.IdProgettoSigef;
                    var impresa = impresa_provider.Find(null, itemFidejussione.PartitaIvaImpresa, null).ToArrayList<Impresa>().FirstOrDefault();
                    if (impresa == null)
                        throw new Exception("l'impresa " + itemFidejussione.PartitaIvaImpresa + " associata alla fidejussione numero non è presente in banca dati");

                    fidejussioneImpresa.IdImpresa = impresa.IdImpresa;
                    fidejussioneImpresa.Importo = itemFidejussione.FlagRichiestaAnticipo ? itemFidejussione.Fidejussione.Importo : 0;
                    fidejussioneImpresa.AmmontareRichiesto = itemFidejussione.FlagRichiestaAnticipo ? itemFidejussione.Fidejussione.AmmontareRichiesto : 0;
                    fidejussioneImpresa.DataFineLavori = itemFidejussione.FlagRichiestaAnticipo ? itemFidejussione.Fidejussione.DataFineLavori : (DateTime?)null;
                    fidejussioneImpresa.DataScadenza = itemFidejussione.FlagRichiestaAnticipo ? itemFidejussione.Fidejussione.DataScadenza : (DateTime?)null;
                    fidejussioneImpresa.Stampato = true;
                    fidejussioneImpresa.Numero = itemFidejussione.FlagRichiestaAnticipo ? itemFidejussione.Fidejussione.Numero : null;
                    fidejussioneImpresa.DataSottoscrizione = itemFidejussione.FlagRichiestaAnticipo ? itemFidejussione.Fidejussione.DataSottoscrizione : (DateTime?)null;
                    fidejussioneImpresa.LuogoSottoscrizione = itemFidejussione.FlagRichiestaAnticipo ? itemFidejussione.Fidejussione.LuogoSottoscrizione : null;
                    fidejussioneImpresa.PivaGarante = itemFidejussione.FlagRichiestaAnticipo ? itemFidejussione.Fidejussione.PartitaIvaGarante : null;
                    fidejussioneImpresa.RagioneSocialeGarante = itemFidejussione.FlagRichiestaAnticipo ? itemFidejussione.Fidejussione.RagioneSocialeGarante : null;
                    fidejussioneImpresa.LocalitaGarante = itemFidejussione.FlagRichiestaAnticipo ? itemFidejussione.Fidejussione.LocalitaGarante : null;
                    fidejussioneImpresa.CognomeRapplegale = itemFidejussione.FlagRichiestaAnticipo ? itemFidejussione.Fidejussione.CognomeRappresentanteLegaleGarante : null;
                    fidejussioneImpresa.NomeRapplegale = itemFidejussione.FlagRichiestaAnticipo ? itemFidejussione.Fidejussione.NomeRappresentanteLegaleGarante : null;
                    fidejussioneImpresa.CfRapplegale = itemFidejussione.FlagRichiestaAnticipo ? itemFidejussione.Fidejussione.CodiceFiscaleRappresentanteLegaleGarante : null;
                    fidejussioneImpresa.DataNascitaRapplegale = itemFidejussione.FlagRichiestaAnticipo ? itemFidejussione.Fidejussione.DataNascitaRappresentanteLegaleGarante : (DateTime?)null;
                    fidejussioneImpresa.Esente = false;
                    fidejussioneImpresa.NoAnticipo = !itemFidejussione.FlagRichiestaAnticipo;
                    domandaPagamentoFidejussioneImpresaProvider.Save(fidejussioneImpresa);

                }
                

                //requisiti domanda pagamento
                var idBando = progettoProvider.GetById(dpagamento.IdProgetto).IdBando;
                var setMinimo = GetSetMinimoDomandaPagamento(dpagamento.CodTipo);
                var requisitiPagamentoDesc = domandaPagamento.RequisitiDomandaAnticipo.RequisitoDomandaAnticipo.Select(i => i.ChiaveDescrizione).ToList();
                var requisitiBando = bandoRequisitiProvider.Find(idBando, dpagamento.CodTipo, null).ToArrayList<BandoRequisitiPagamento>();

                if (!CheckSetMinimoDomandaPagamento(requisitiPagamentoDesc, setMinimo))
                    throw new Exception("E' assente o incompleto il set minimo di requisiti previsto per le domande di pagamento FESR");

                foreach (var requisito in requisitiBando)
                {
                    var requisitoDomanda = new DomandaPagamentoRequisiti();
                    requisitoDomanda.IdDomandaPagamento = dpagamento.IdDomandaPagamento;
                    requisitoDomanda.IdRequisito = requisito.IdRequisito;
                    var d = domandaPagamento.RequisitiDomandaAnticipo.RequisitoDomandaAnticipo.FindAll(c => c.ChiaveDescrizione == requisito.Requisito).FirstOrDefault();

                    if (requisito.Datetime)
                        requisitoDomanda.ValData = DateTime.Parse(d.Valore);

                    if (requisito.Numerico)
                        requisitoDomanda.ValNumerico = Decimal.Parse(d.Valore);

                    if (requisito.TestoSemplice)
                        requisitoDomanda.ValTesto = d.Valore;

                    if(requisito.IdRequisito == idRequisitoControllo)
                    {
                        requisitoDomanda.Esito = d.Valore;
                        requisitoDomanda.DataEsito = domandaPagamento.DatiGenerali.DataPresentazione;
                    } 
                    requisitiDomandaPagamentoProvider.Save(requisitoDomanda);
                }


                //indicatori monitoraggio
                foreach (IndicatoreDAType item in domandaPagamento.IndicatoriMonitoraggio.Indicatore)
                {
                    var progettoIndicatori = new ProgettoIndicatori();
                    var intervento = interventiProvider.Find(item.CodiceProgrammazione, null, domandaPagamento.DatiGenerali.CodiceFondo, null, null, null).ToArrayList<Zprogrammazione>().FirstOrDefault();
                    var ind = zdimensioniProvider.GetByIdProgramCodiceInd(intervento.Id, item.Codice).ToArrayList<Zdimensioni>().FirstOrDefault();
                    var dimProg = zdimensioniProgProvider.Select(intervento.Id, ind.Id, null).ToArrayList<ZdimensioniXProgrammazione>().FirstOrDefault();
                    progettoIndicatori.IdProgetto = dpagamento.IdProgetto;
                    progettoIndicatori.IdDomandaPagamento = dpagamento.IdDomandaPagamento;
                    progettoIndicatori.IdDimXProgrammazione = dimProg.IdDimXProgrammazione;
                    progettoIndicatori.CodTipo = "PAGAMENTO";
                    progettoIndicatori.ValoreProgrammatoRichiesto = item.Valore;
                    progettoIndicatori.ValoreRealizzatoRichiesto = item.Valore;
                    progettoIndicatori.DataRegistrazione = DateTime.Now;
                    progettoIndicatori.Operatore = 1;

                    progettoIndicatoriProvider.Save(progettoIndicatori);
                }

                //aggiornamento stato progetto
                var progettoStorico = new ProgettoStorico();

                progettoStorico.Segnatura = domandaPagamento.DatiGenerali.SegnaturaProtocollo;
                progettoStorico.Data = domandaPagamento.DatiGenerali.DataPresentazione;
                progettoStorico.IdProgetto = domandaPagamento.DatiGenerali.IdProgettoSigef;
                progettoStorico.Operatore = 1;

                if (dpagamento.CodTipo == "ANT")
                    progettoStorico.CodStato = "V";
                else
                    progettoStorico.CodStato = "S";

                progettoStoricoProvider.Save(progettoStorico);

                var progetto = progettoUpdateProvider.GetById(dpagamento.IdProgetto);
                progetto.IdStoricoUltimo = progettoStorico.Id;
                progettoUpdateProvider.Save(progetto);


                domandaPagamentoProvider.DbProviderObj.Commit();
                return dpagamento.IdDomandaPagamento;
            }
            catch (Exception ex)
            {
                domandaPagamentoProvider.DbProviderObj.Rollback();
                throw ex;
            }
            
        }


        internal int InsertDomandaVarianteByService(Variante domandaVariante)
        {
            ComuniCollectionProvider comuni_provider = new ComuniCollectionProvider();
            ZdimensioniCollectionProvider zdimensioniProvider = new ZdimensioniCollectionProvider();
            ZdimensioniXProgrammazioneCollectionProvider zdimensioniProgProvider = new ZdimensioniXProgrammazioneCollectionProvider();
            ZprogrammazioneCollectionProvider interventiProvider = new ZprogrammazioneCollectionProvider();
            BandoRequisitiVarianteCollectionProvider bandoRequisitiVarianteProvider = new BandoRequisitiVarianteCollectionProvider();
            ProgettoCollectionProvider progettoProvider = new ProgettoCollectionProvider();
            ImpresaCollectionProvider impProvider = new ImpresaCollectionProvider();
            
            VariantiCollectionProvider varianteProvider = new VariantiCollectionProvider();
            ImpresaCollectionProvider impresa_provider = new ImpresaCollectionProvider(varianteProvider.DbProviderObj);
            ImpresaStoricoCollectionProvider impresa_storico_prov = new ImpresaStoricoCollectionProvider(varianteProvider.DbProviderObj);
            IndirizzarioCollectionProvider indirizzario_provider = new IndirizzarioCollectionProvider(varianteProvider.DbProviderObj);
            IndirizzoCollectionProvider indirizzo_provider = new IndirizzoCollectionProvider(varianteProvider.DbProviderObj);
            PersonaFisicaCollectionProvider persona_fisica_provider = new PersonaFisicaCollectionProvider(varianteProvider.DbProviderObj);
            PersoneXImpreseCollectionProvider persone_imprese_provider = new PersoneXImpreseCollectionProvider(varianteProvider.DbProviderObj);
            ContoCorrenteCollectionProvider conto_corrente_provider = new ContoCorrenteCollectionProvider(varianteProvider.DbProviderObj);
            ProgettoIndicatoriCollectionProvider progettoIndicatoriProvider = new ProgettoIndicatoriCollectionProvider(varianteProvider.DbProviderObj);
            LocalizzazioneProgettoCollectionProvider localizzazione_provider = new LocalizzazioneProgettoCollectionProvider(varianteProvider.DbProviderObj);
            VariantiEsitiRequisitiCollectionProvider variantiEsitiRequisitiProvider = new VariantiEsitiRequisitiCollectionProvider(varianteProvider.DbProviderObj);

            try
            {
                varianteProvider.DbProviderObj.BeginTran();

                //variante
                var variante = new Varianti();
                variante.IdProgetto = domandaVariante.DatiGenerali.IdProgettoSigef;
                variante.CodTipo = "VA";
                variante.DataInserimento = domandaVariante.DatiGenerali.DataPresentazione;
                variante.Operatore = "";
                variante.DataModifica = domandaVariante.DatiGenerali.DataPresentazione;
                variante.Descrizione = domandaVariante.DatiGenerali.DescrizioneVariante;
                variante.Segnatura = domandaVariante.DatiGenerali.SegnaturaProtocollo;
                variante.FirmaPredisposta = false;
                variante.FirmaPredispostaRup = false;
                varianteProvider.Save(variante);

                //localizzazioni
                if(domandaVariante.Localizzazioni != null)
                {
                    //Elimino tutte le localizzazioni presenti
                    //Inserisco tutte le localizzazione
                    foreach (LocalizzazioneVType item in domandaVariante.Localizzazioni.Localizzazione)
                    {
                        string istatProv = item.ISTAT6.Substring(0, 3);
                        string istatComune = item.ISTAT6.Substring(3, 3);
                        var localizzazione = new SiarLibrary.LocalizzazioneProgetto();
                        int idComune = comuni_provider.Find(null, istatProv, null, null, null, istatComune, null, null).ToArrayList<Comuni>().FirstOrDefault().IdComune;
                        var imp = impresa_provider.Find(null, item.PartitaIvaImpresa, null).ToArrayList<Impresa>().FirstOrDefault();
                        localizzazione.IdProgetto = domandaVariante.DatiGenerali.IdProgettoSigef;
                        localizzazione.IdImpresa = imp.IdImpresa;
                        localizzazione.IdComune = idComune;
                        localizzazione.Cap = item.CAP;
                        localizzazione.Via = item.Indirizzo;
                        localizzazione.Dug = GetDug(item.DUG);
                        localizzazione.Num = item.Numero;
                        localizzazione.Quota = 100;
                        localizzazione_provider.Save(localizzazione);
                    }
                }
                

                //cambio beneficiario
                if(domandaVariante.CambioBeneficario != null)
                {
                    var impresa = new SiarLibrary.Impresa();
                    int? idImpresaPrincipale = null;
                    Dictionary<int, string> impreseDictionary = new Dictionary<int, string>();
                    var beneficiario = domandaVariante.CambioBeneficario.BeneficiarioEntrante;

                    impresa = impresa_provider.Find(null, beneficiario.PartitaIva, null).ToArrayList<Impresa>().FirstOrDefault();
                    if (impresa != null)
                    {
                        impreseDictionary.Add(impresa.IdImpresa, beneficiario.PartitaIva);
                        idImpresaPrincipale = impresa.IdImpresa;

                        var impresaStorico = new ImpresaStorico();
                        impresaStorico.RagioneSociale = beneficiario.RagioneSociale;
                        impresaStorico.DataInizioValidita = DateTime.Now;
                        impresaStorico.RegistroImpreseNumero = beneficiario.NumeroRegistroImprese;
                        impresaStorico.ReaNumero = beneficiario.NumeroREA;
                        impresaStorico.ReaAnno = beneficiario.AnnoIscrizioneREA;
                        impresaStorico.CodAteco2007 = beneficiario.CodiceATECO2007;
                        impresaStorico.IdDimensione = beneficiario.DimensioneImpresa;
                        impresaStorico.CodFormaGiuridica = beneficiario.CodiceFormaGiuridica;
                        impresaStorico.IdImpresa = impresa.IdImpresa;
                        impresa_storico_prov.Save(impresaStorico);
                        impresa.IdStoricoUltimo = impresaStorico.IdStoricoImpresa;
                        impresa_provider.Save(impresa);

                        //Aggiorno la sede precedente
                        var indirizzarioOld = indirizzario_provider.GetById(impresa.IdSedelegaleUltimo);
                        indirizzarioOld.FlagAttivo = false;
                        indirizzario_provider.Save(indirizzarioOld);
                        //nuova sede
                        var sedeLegale = new Indirizzo();
                        string istatProvSL = beneficiario.SedeLegale.ISTAT6.Substring(0, 3);
                        string istatComuneSL = beneficiario.SedeLegale.ISTAT6.Substring(3, 3);
                        int idComuneSL = comuni_provider.Find(null, istatProvSL, null, null, null, istatComuneSL, null, null).ToArrayList<Comuni>().FirstOrDefault().IdComune;
                        sedeLegale.IdComune = idComuneSL;
                        sedeLegale.Via = beneficiario.SedeLegale.Indirizzo;
                        indirizzo_provider.Save(sedeLegale);
                        var indirizzario = new Indirizzario();
                        indirizzario.IdImpresa = idImpresaPrincipale;
                        indirizzario.IdIndirizzo = sedeLegale.IdIndirizzo;
                        indirizzario.DataInizioValidita = DateTime.Now;
                        indirizzario.CodTipoSede = "S";
                        indirizzario.FlagAttivo = true;
                        indirizzario.Email = beneficiario.Email;
                        indirizzario.Pec = beneficiario.Pec;
                        indirizzario.Telefono = beneficiario.Telefono;
                        indirizzario_provider.Save(indirizzario);
                        impresa.IdSedelegaleUltimo = indirizzario.IdIndirizzario;
                        impresa_provider.Save(impresa);

                        //aggiorno il rappresentante legale
                        var rappresentanteLegaleColl = persona_fisica_provider.Find(beneficiario.RappresentanteLegale.CodiceFiscale).ToArrayList<PersonaFisica>();
                        if (rappresentanteLegaleColl.Any()) //la persona fisica esiste in banca dati
                        {
                            var personaImpresa = persone_imprese_provider.GetById(impresa.IdRapprlegaleUltimo);
                            var rappresentanteLegale = rappresentanteLegaleColl.FirstOrDefault();
                            if (personaImpresa.IdPersona != rappresentanteLegale.IdPersona)
                            {
                                //aggiorno il precedente rapp. legale
                                personaImpresa.Attivo = false;
                                persone_imprese_provider.Save(personaImpresa);
                                var personeXImprese = new PersoneXImprese();
                                personeXImprese.IdImpresa = idImpresaPrincipale;
                                personeXImprese.IdPersona = rappresentanteLegale.IdPersona;
                                personeXImprese.Attivo = true;
                                personeXImprese.Ruolo = "R";
                                personeXImprese.DataInizio = DateTime.Now;
                                personeXImprese.Ammesso = true;
                                persone_imprese_provider.Save(personeXImprese);
                                impresa.IdRapprlegaleUltimo = personeXImprese.IdPersoneXImprese;
                                impresa_provider.Save(impresa);
                            }

                        }
                        else
                        {
                            //aggiorno il precedente rapp. legale
                            var personaImpresa = persone_imprese_provider.GetById(impresa.IdRapprlegaleUltimo);
                            personaImpresa.Attivo = false;
                            persone_imprese_provider.Save(personaImpresa);
                            //nuovo rapp. legale
                            var rappresentanteLegale = new PersonaFisica();
                            var personeXImprese = new PersoneXImprese();
                            rappresentanteLegale.Nome = beneficiario.RappresentanteLegale.Nome;
                            rappresentanteLegale.Cognome = beneficiario.RappresentanteLegale.Cognome;
                            rappresentanteLegale.DataNascita = beneficiario.RappresentanteLegale.DataNascita;
                            string belfiore = beneficiario.RappresentanteLegale.CodiceFiscale.Substring(11, 4);
                            int idComune;
                            if (belfiore.StartsWith("Z"))
                            {
                                idComune = comuni_provider.Find(belfiore, null, null, null, null, null, null, null).ToArrayList<Comuni>().FirstOrDefault().IdComune;
                            }
                            else
                            {
                                string istatProv = beneficiario.RappresentanteLegale.ISTAT6Nascita.Substring(0, 3);
                                string istatComune = beneficiario.RappresentanteLegale.ISTAT6Nascita.Substring(3, 3);
                                idComune = comuni_provider.Find(null, istatProv, null, null, null, istatComune, null, null).ToArrayList<Comuni>().FirstOrDefault().IdComune;
                            }
                            rappresentanteLegale.IdComuneNascita = idComune;
                            rappresentanteLegale.CodiceFiscale = beneficiario.RappresentanteLegale.CodiceFiscale;
                            persona_fisica_provider.Save(rappresentanteLegale);
                            personeXImprese.IdImpresa = idImpresaPrincipale;
                            personeXImprese.IdPersona = rappresentanteLegale.IdPersona;
                            personeXImprese.Attivo = true;
                            personeXImprese.Ruolo = "R";
                            personeXImprese.DataInizio = DateTime.Now;
                            personeXImprese.Ammesso = true;
                            persone_imprese_provider.Save(personeXImprese);
                            impresa.IdRapprlegaleUltimo = personeXImprese.IdPersoneXImprese;
                            impresa_provider.Save(impresa);
                        }


                    }
                    else //nuova impresa
                    {
                        impresa = new Impresa();
                        impresa.Cuaa = beneficiario.CodiceFiscale;
                        impresa.CodiceFiscale = beneficiario.PartitaIva;
                        impresa.DataInizioAttivita = beneficiario.DataInizioAttivita;
                        impresa_provider.Save(impresa);
                        impreseDictionary.Add(impresa.IdImpresa, beneficiario.PartitaIva);

                        var impresaStorico = new ImpresaStorico();
                        impresaStorico.RagioneSociale = beneficiario.RagioneSociale;
                        impresaStorico.DataInizioValidita = DateTime.Now;
                        impresaStorico.RegistroImpreseNumero = beneficiario.NumeroRegistroImprese;
                        impresaStorico.ReaNumero = beneficiario.NumeroREA;
                        impresaStorico.ReaAnno = beneficiario.AnnoIscrizioneREA;
                        impresaStorico.CodAteco2007 = beneficiario.CodiceATECO2007;
                        impresaStorico.IdDimensione = beneficiario.DimensioneImpresa;
                        impresaStorico.CodFormaGiuridica = beneficiario.CodiceFormaGiuridica;
                        impresaStorico.IdImpresa = impresa.IdImpresa;
                        impresa_storico_prov.Save(impresaStorico);
                        impresa.IdStoricoUltimo = impresaStorico.IdStoricoImpresa;
                        impresa_provider.Save(impresa);

                        idImpresaPrincipale = impresa.IdImpresa;

                        var rappresentanteLegaleColl = persona_fisica_provider.Find(beneficiario.RappresentanteLegale.CodiceFiscale).ToArrayList<PersonaFisica>();
                        if (rappresentanteLegaleColl.Any()) //la persona fisica esiste in banca dati
                        {
                            var rappresentanteLegale = rappresentanteLegaleColl.FirstOrDefault();
                            var personeXImprese = new PersoneXImprese();
                            personeXImprese.IdImpresa = idImpresaPrincipale;
                            personeXImprese.IdPersona = rappresentanteLegale.IdPersona;
                            personeXImprese.Attivo = true;
                            personeXImprese.CodRuolo = "R";
                            personeXImprese.DataInizio = DateTime.Now;
                            personeXImprese.Ammesso = true;
                            persone_imprese_provider.Save(personeXImprese);
                            impresa.IdRapprlegaleUltimo = personeXImprese.IdPersoneXImprese;
                            impresa_provider.Save(impresa);
                        }
                        else
                        {
                            //Rappresentante Legale non presente in banca dati
                            var rappresentanteLegale = new PersonaFisica();
                            var personeXImprese = new PersoneXImprese();
                            rappresentanteLegale.Nome = beneficiario.RappresentanteLegale.Nome;
                            rappresentanteLegale.Cognome = beneficiario.RappresentanteLegale.Cognome;
                            rappresentanteLegale.DataNascita = beneficiario.RappresentanteLegale.DataNascita;
                            string belfiore = beneficiario.RappresentanteLegale.CodiceFiscale.Substring(11, 4);
                            int idComune;
                            if (belfiore.StartsWith("Z"))
                            {
                                idComune = comuni_provider.Find(belfiore, null, null, null, null, null, null, null).ToArrayList<Comuni>().FirstOrDefault().IdComune;
                            }
                            else
                            {
                                string istatProv = beneficiario.RappresentanteLegale.ISTAT6Nascita.Substring(0, 3);
                                string istatComune = beneficiario.RappresentanteLegale.ISTAT6Nascita.Substring(3, 3);
                                idComune = comuni_provider.Find(null, istatProv, null, null, null, istatComune, null, null).ToArrayList<Comuni>().FirstOrDefault().IdComune;
                            }
                            rappresentanteLegale.IdComuneNascita = idComune;
                            rappresentanteLegale.CodiceFiscale = beneficiario.RappresentanteLegale.CodiceFiscale;
                            persona_fisica_provider.Save(rappresentanteLegale);
                            personeXImprese.IdImpresa = idImpresaPrincipale;
                            personeXImprese.IdPersona = rappresentanteLegale.IdPersona;
                            personeXImprese.Attivo = true;
                            personeXImprese.CodRuolo = "R";
                            personeXImprese.DataInizio = DateTime.Now;
                            personeXImprese.Ammesso = true;
                            persone_imprese_provider.Save(personeXImprese);
                            impresa.IdRapprlegaleUltimo = personeXImprese.IdPersoneXImprese;
                            impresa_provider.Save(impresa);
                        }


                        //sede legale
                        var sedeLegale = new Indirizzo();
                        string istatProvSL = beneficiario.SedeLegale.ISTAT6.Substring(0, 3);
                        string istatComuneSL = beneficiario.SedeLegale.ISTAT6.Substring(3, 3);
                        int idComuneSL = comuni_provider.Find(null, istatProvSL, null, null, null, istatComuneSL, null, null).ToArrayList<Comuni>().FirstOrDefault().IdComune;
                        sedeLegale.IdComune = idComuneSL;
                        sedeLegale.Via = beneficiario.SedeLegale.Indirizzo;
                        indirizzo_provider.Save(sedeLegale);
                        var indirizzario = new Indirizzario();
                        indirizzario.IdImpresa = idImpresaPrincipale;
                        indirizzario.IdIndirizzo = sedeLegale.IdIndirizzo;
                        indirizzario.DataInizioValidita = DateTime.Now;
                        indirizzario.CodTipoSede = "S";
                        indirizzario.FlagAttivo = true;
                        indirizzario.Email = beneficiario.Email;
                        indirizzario.Pec = beneficiario.Pec;
                        indirizzario.Telefono = beneficiario.Telefono;
                        indirizzario_provider.Save(indirizzario);
                        impresa.IdSedelegaleUltimo = indirizzario.IdIndirizzario;
                        impresa_provider.Save(impresa);

                    }

                    if (string.IsNullOrEmpty(beneficiario.IBAN))
                        throw new Exception("IBAN dell'impresa non presente");

                    //inserimento conto corrente
                    var conto = new ContoCorrente();
                    string iban = beneficiario.IBAN;
                    conto.IdImpresa = idImpresaPrincipale;
                    conto.CodPaese = iban.Substring(0, 2);
                    conto.CinEuro = iban.Substring(2, 2);
                    conto.Cin = iban.Substring(4, 1);
                    conto.Abi = iban.Substring(5, 5);
                    conto.Cab = iban.Substring(10, 5);
                    conto.Numero = iban.Substring(15);
                    Dictionary<string, object> dt = SiarLibrary.DbStaticProvider.GetDatiBancaByCC(conto.Abi, conto.Cab);
                    conto.Istituto = dt["Istituto"].ToString();
                    conto.Agenzia = dt["Agenzia"].ToString();
                    conto.IdComune = dt["IdComune"].ToString();
                    conto_corrente_provider.Save(conto);
                    impresa.IdContoCorrenteUltimo = conto.IdContoCorrente;
                    impresa_provider.Save(impresa);

                    variante.CuaaEntrante = beneficiario.PartitaIva;
                    variante.CuaaUscente = domandaVariante.CambioBeneficario.PartitaIvaBeneficiarioUscente;
                    varianteProvider.Save(variante);
                }
            


                //requisiti variante
                var idBando = progettoProvider.GetById(variante.IdProgetto).IdBando;
                var setMinimo = GetSetMinimoVariante(idRequisitiSetMinimoVariante);
                var requisitiVarianteDesc = domandaVariante.RequisitiVariante.RequisitoVariante.Select(i => i.ChiaveDescrizione).ToList();
                var requisitiBando = bandoRequisitiVarianteProvider.Find(idBando, "VA").ToArrayList<BandoRequisitiVariante>();

                if (!CheckSetMinimoVariante(requisitiVarianteDesc, setMinimo))
                    throw new Exception("E' assente o incompleto il set minimo di requisiti previsto per le varianti");

                foreach (var requisito in requisitiBando)
                {
                    var requisitoVariante = new VariantiEsitiRequisiti();
                    requisitoVariante.IdVariante = variante.IdVariante;
                    requisitoVariante.IdRequisito = requisito.IdRequisito;

                    requisitoVariante.Esito = idRequisitiVarianteControllo.Any(v => v != requisito.IdRequisito) ? "SI" : null;
                    requisitoVariante.Data = idRequisitiVarianteControllo.Any(v => v != requisito.IdRequisito) ? domandaVariante.DatiGenerali.DataPresentazione : (DateTime?)null;
                    requisitoVariante.EscludiDaComunicazione = false;
                    variantiEsitiRequisitiProvider.Save(requisitoVariante);
                }

                //indicatori monitoraggio
                foreach (IndicatoreVType item in domandaVariante.IndicatoriMonitoraggio.Indicatore)
                {
                    var progettoIndicatori = new ProgettoIndicatori();
                    var intervento = interventiProvider.Find(item.CodiceProgrammazione, null, domandaVariante.DatiGenerali.CodiceFondo, null, null, null).ToArrayList<Zprogrammazione>().FirstOrDefault();
                    var ind = zdimensioniProvider.GetByIdProgramCodiceInd(intervento.Id, item.Codice).ToArrayList<Zdimensioni>().FirstOrDefault();
                    var dimProg = zdimensioniProgProvider.Select(intervento.Id, ind.Id, null).ToArrayList<ZdimensioniXProgrammazione>().FirstOrDefault();
                    progettoIndicatori.IdProgetto = variante.IdProgetto;
                    progettoIndicatori.IdVariante = variante.IdVariante;
                    progettoIndicatori.IdDimXProgrammazione = dimProg.IdDimXProgrammazione;
                    progettoIndicatori.CodTipo = "VARIANTE";
                    progettoIndicatori.ValoreProgrammatoRichiesto = item.Valore;
                    progettoIndicatori.ValoreRealizzatoRichiesto = item.Valore;
                    progettoIndicatori.DataRegistrazione = DateTime.Now;
                    progettoIndicatori.Operatore = 1;

                    progettoIndicatoriProvider.Save(progettoIndicatori);
                }

                varianteProvider.DbProviderObj.Commit();
                return variante.IdVariante;
            }
            catch (Exception ex)
            {
                varianteProvider.DbProviderObj.Rollback();
                throw ex;
            }
        }

    }
}