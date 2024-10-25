using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace CupManager
{
    internal partial class DALClass : IDisposable
    {
        private string connectionString;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        internal DALClass()
        {
            ConnectionStringSettings css = ConfigurationManager.ConnectionStrings["DB_SIGEF"];
            if (css == null || string.IsNullOrEmpty(css.ConnectionString))
                throw new ConfigurationErrorsException(string.Format("ConnectionString 'DB' mancante nel file di configurazione."));

            connectionString = css.ConnectionString;
        }

        internal DatiGeneraliRichiestaCUP GetDatiGeneraliRichiestaCUP(int idProgetto)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zCUPGetDatiGeneraliRichiesta",
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.AddWithValue2("@IdProgetto", idProgetto);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new DatiGeneraliRichiestaCUP()
                                                          {
                                                              id_progetto = (int)reader["id_progetto"],
                                                              anno_decisione = Convert.ToString(reader["anno_decisione"]),
                                                              natura = Convert.ToString(reader["natura"]),
                                                              tipologia = Convert.ToString(reader["tipologia"]),
                                                              settore = Convert.ToString(reader["settore"]),
                                                              sottosettore = Convert.ToString(reader["sottosettore"]),
                                                              categoria = Convert.ToString(reader["categoria"]),
                                                              stato = Convert.ToString(reader["stato"]),
                                                              regione = Convert.ToString(reader["regione"]),
                                                              provincia = Convert.ToString(reader["provincia"]),
                                                              sigla = Convert.ToString(reader["sigla"]),
                                                              comune = Convert.ToString(reader["comune"]),
                                                              indirizzo = Convert.ToString(reader["indirizzo"]),
                                                              cap = Convert.ToString(reader["cap"]),
                                                              numero = Convert.ToString(reader["numero"]),
                                                              codice_ateco = Convert.ToString(reader["codice_ateco"]),
                                                              sezione_ateco = Convert.ToString(reader["sezione_ateco"]),
                                                              divisione_ateco = Convert.ToString(reader["divisione_ateco"]),
                                                              gruppo_ateco = Convert.ToString(reader["gruppo_ateco"]),
                                                              classe_ateco = Convert.ToString(reader["classe_ateco"]),
                                                              categoria_ateco = Convert.ToString(reader["categoria_ateco"]),
                                                              sottocategoria_ateco = Convert.ToString(reader["sottocategoria_ateco"]),
                                                              costo_progetto = Convert.ToDecimal(reader["costo_progetto"]),
                                                              finanziamento_progetto = Convert.ToDecimal(reader["finanziamento_progetto"]),
                                                              check_quota_reg = Convert.ToBoolean(reader["check_quota_reg"]),
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
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                //System.Diagnostics.Trace.WriteLine(msg,"Error");
                throw new Exception(msg, ex);
            }

        }


        internal DescrizioneCupAcquistoBeni GetDescrizioneCUPAcquistoBeni(int idProgetto)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zCUPGetDescrizioneAcquistoBeni",
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.AddWithValue2("@IdProgetto", idProgetto);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new DescrizioneCupAcquistoBeni()
                                                          {
                                                              id_progetto = (int)reader["id_progetto"],
                                                              nome_stru_infrastr = Convert.ToString(reader["nome_stru_infrastr"]),
                                                              partita_iva = Convert.ToString(reader["partita_iva"]),
                                                              bene = Convert.ToString(reader["bene"]),
                                                              ind_area_rif = Convert.ToString(reader["ind_area_rif"]),
                                                              cap_area_rif = Convert.ToString(reader["cap_area_rif"]),
                                                              numero_area_rif = Convert.ToString(reader["numero_area_rif"]),
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
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                //System.Diagnostics.Trace.WriteLine(msg,"Error");
                throw new Exception(msg, ex);
            }

        }


        internal DescrizioneCupConcessioneContributiNoUnitaProduttive GetDescrizioneCUPConcessioneContributiNoUnitaProduttive(int idProgetto)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zCUPGetDescrizioneConcessioneContributiNoUnitaProduttive",
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.AddWithValue2("@IdProgetto", idProgetto);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new DescrizioneCupConcessioneContributiNoUnitaProduttive()
                                                          {
                                                              id_progetto = (int)reader["id_progetto"],
                                                              beneficiario = Convert.ToString(reader["beneficiario"]),
                                                              partita_iva = Convert.ToString(reader["partita_iva"]),
                                                              struttura = Convert.ToString(reader["struttura"]),
                                                              ind_area_rif = Convert.ToString(reader["ind_area_rif"]),
                                                              cap_area_rif = Convert.ToString(reader["cap_area_rif"]),
                                                              numero_area_rif = Convert.ToString(reader["numero_area_rif"]),
                                                              desc_intervento = Convert.ToString(reader["desc_intervento"]),
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
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                //System.Diagnostics.Trace.WriteLine(msg,"Error");
                throw new Exception(msg, ex);
            }

        }


        internal DescrizioneCupConcessioneIncentiviUnitaProduttive GetDescrizioneCUPConcessioneIncentiviUnitaProduttive(int idProgetto)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zCUPGetDescrizioneConcessioneIncentiviUnitaProduttive",
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.AddWithValue2("@IdProgetto", idProgetto);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new DescrizioneCupConcessioneIncentiviUnitaProduttive()
                                                          {
                                                              id_progetto = (int)reader["id_progetto"],
                                                              denominazione_impresa_stabilimento = Convert.ToString(reader["denominazione_impresa_stabilimento"]),
                                                              partita_iva = Convert.ToString(reader["partita_iva"]),
                                                              descrizione_intervento = Convert.ToString(reader["descrizione_intervento"]),
                                                              ind_area_rif = Convert.ToString(reader["ind_area_rif"]),
                                                              cap_area_rif = Convert.ToString(reader["cap_area_rif"]),
                                                              numero_area_rif = Convert.ToString(reader["numero_area_rif"]),
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
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                //System.Diagnostics.Trace.WriteLine(msg,"Error");
                throw new Exception(msg, ex);
            }

        }


        internal DescrizioneCupLavoriPubblici GetDescrizioneCUPLavoriPubblici(int idProgetto)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zCUPGetDescrizioneLavoriPubblici",
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.AddWithValue2("@IdProgetto", idProgetto);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new DescrizioneCupLavoriPubblici()
                                                          {
                                                              id_progetto = (int)reader["id_progetto"],
                                                              nome_stru_infrastr = Convert.ToString(reader["nome_stru_infrastr"]),
                                                              partita_iva = Convert.ToString(reader["partita_iva"]),
                                                              ind_area_rif = Convert.ToString(reader["ind_area_rif"]),
                                                              cap_area_rif = Convert.ToString(reader["cap_area_rif"]),
                                                              numero_area_rif = Convert.ToString(reader["numero_area_rif"]),
                                                              descrizione_intervento = Convert.ToString(reader["descrizione_intervento"]),
                                                              nr_imprese = Convert.ToInt32(reader["nr_imprese"]),
                                                              str_infrastr_unica = Convert.ToString(reader["str_infrastr_unica"]),
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
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                //System.Diagnostics.Trace.WriteLine(msg,"Error");
                throw new Exception(msg, ex);
            }

        }


        internal DescrizioneCupPartecipAzionarieConferimCapitale GetDescrizioneCUPPartecipAzionarieConferimCapitale(int idProgetto)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zCUPGetDescrizionePartecipAzionarieConferimCapitale",
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.AddWithValue2("@IdProgetto", idProgetto);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new DescrizioneCupPartecipAzionarieConferimCapitale()
                                                          {
                                                              id_progetto = (int)reader["id_progetto"],
                                                              ragione_sociale = Convert.ToString(reader["ragione_sociale"]),
                                                              partita_iva = Convert.ToString(reader["partita_iva"]),
                                                              finalita = Convert.ToString(reader["finalita"]),
                                                              ind_area_rif = Convert.ToString(reader["ind_area_rif"]),
                                                              cap_area_rif = Convert.ToString(reader["cap_area_rif"]),
                                                              numero_area_rif = Convert.ToString(reader["numero_area_rif"]),
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
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                //System.Diagnostics.Trace.WriteLine(msg,"Error");
                throw new Exception(msg, ex);
            }

        }


        internal DescrizioneCupRealizzAcquistoNoFormazioneRicerca GetDescrizioneCUPRealizzAcquistoNoFormazioneRicerca(int idProgetto)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zCUPGetDescrizioneRealizzAcquistoNoFormazioneRicerca",
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.AddWithValue2("@IdProgetto", idProgetto);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new DescrizioneCupRealizzAcquistoNoFormazioneRicerca()
                                                          {
                                                              id_progetto = (int)reader["id_progetto"],
                                                              nome_stru_infrastr = Convert.ToString(reader["nome_stru_infrastr"]),
                                                              partita_iva = Convert.ToString(reader["partita_iva"]),
                                                              servizio = Convert.ToString(reader["servizio"]),
                                                              ind_area_rif = Convert.ToString(reader["ind_area_rif"]),
                                                              cap_area_rif = Convert.ToString(reader["cap_area_rif"]),
                                                              numero_area_rif = Convert.ToString(reader["numero_area_rif"]),
                                                              //nr_imprese = Convert.ToInt32(reader["nr_imprese"]),
                                                              //str_infrastr_unica = Convert.ToString(reader["str_infrastr_unica"]),
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
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                //System.Diagnostics.Trace.WriteLine(msg,"Error");
                throw new Exception(msg, ex);
            }

        }


        internal DescrizioneCupRealizzAcquistoServiziRicerca GetDescrizioneCUPRealizzAcquistoServiziRicerca(int idProgetto)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zCUPGetDescrizioneRealizzAcquistoServiziRicerca",
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.AddWithValue2("@IdProgetto", idProgetto);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new DescrizioneCupRealizzAcquistoServiziRicerca()
                                                          {
                                                              id_progetto = (int)reader["id_progetto"],
                                                              denominazione_progetto = Convert.ToString(reader["denominazione_progetto"]),
                                                              ente = Convert.ToString(reader["ente"]),
                                                              partita_iva = Convert.ToString(reader["partita_iva"]),
                                                              descrizione_intervento = Convert.ToString(reader["descrizione_intervento"]),
                                                              ind_area_rif = Convert.ToString(reader["ind_area_rif"]),
                                                              cap_area_rif = Convert.ToString(reader["cap_area_rif"]),
                                                              numero_area_rif = Convert.ToString(reader["numero_area_rif"]),
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
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                //System.Diagnostics.Trace.WriteLine(msg,"Error");
                throw new Exception(msg, ex);
            }

        }


        //DA RIVEDERE IN BASE AI DATI RICHIESTI PER I CORSI DI FORMAZIONE
        internal DescrizioneCupRealizzAcquistoServiziFormazione GetDescrizioneCUPRealizzAcquistoServiziFormazione(int idProgetto)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zCUPGetDescrizioneRealizzAcquistoServiziFormazione",
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.AddWithValue2("@IdProgetto", idProgetto);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new DescrizioneCupRealizzAcquistoServiziFormazione()
                                                          {
                                                              id_progetto = (int)reader["id_progetto"],
                                                              denom_ente_corso = Convert.ToString(reader["denom_ente_corso"]),
                                                              obiett_corso = Convert.ToString(reader["obiett_corso"]),
                                                              denom_progetto = Convert.ToString(reader["denom_progetto"]),
                                                              partita_iva = Convert.ToString(reader["partita_iva"]),
                                                              mod_intervento_frequenza = Convert.ToString(reader["mod_intervento_frequenza"]),
                                                              ind_area_rif = Convert.ToString(reader["ind_area_rif"]),
                                                              cap_area_rif = Convert.ToString(reader["cap_area_rif"]),
                                                              numero_area_rif = Convert.ToString(reader["numero_area_rif"]),
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
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                //System.Diagnostics.Trace.WriteLine(msg,"Error");
                throw new Exception(msg, ex);
            }

        }

        internal string GetStrumentoProgrammazione(int idProgetto)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zCUPGetStrumentoProgrammazione",
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.AddWithValue2("@IdProgetto", idProgetto);
            try
            {
                var result = SqlHelper.ExecuteScalarCmd(connectionString, sqlCmd).ToString();

                return result;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
            
        }

        internal int InsertLogCupRichieste(CupRichieste cupRichieste)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zCUPInsertRichieste",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@IdRichiesta", cupRichieste.ID_RICHIESTA);
                sqlCmd.Parameters.AddWithValue2("@IdProgetto", cupRichieste.ID_PROGETTO);
                sqlCmd.Parameters.AddWithValue2("@CodiceCup", cupRichieste.CODICE_CUP);
                sqlCmd.Parameters.AddWithValue2("@DataRichiestaCup", cupRichieste.DATA_RICHIESTA_CUP);
                sqlCmd.Parameters.AddWithValue2("@IstanzaRichiesta", cupRichieste.ISTANZA_RICHIESTA);
                sqlCmd.Parameters.AddWithValue2("@IstanzaRisposta", cupRichieste.ISTANZA_RISPOSTA);
                sqlCmd.Parameters.AddWithValue2("@IdRichiestaAssegnataCup", cupRichieste.ID_RICHIESTA_ASSEGNATA_CUP);
                sqlCmd.Parameters.AddWithValue2("@EsitoElaborazioneCup", cupRichieste.ESITO_ELABORAZIONE_CUP);
                sqlCmd.Parameters.AddWithValue2("@DescrizioneEsitoElaborazioneCup", cupRichieste.DESCRIZIONE_ESITO_ELABORAZIONE_CUP);
                sqlCmd.Parameters.AddWithValue2("@TipoEsito", cupRichieste.TIPO_ESITO);
                sqlCmd.Parameters.AddWithValue2("@DataInserimento", DateTime.Now);
                sqlCmd.Parameters.AddWithValue2("@DataAggiornamento", DateTime.Now);

                var id = (int)SqlHelper.ExecuteScalarCmd(connectionString, sqlCmd);
                return id;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }


        internal List<ProgettiFinanziabili> GetProgettiFinanziabili()
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zCUPGetProgettiFinanziabili",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new ProgettiFinanziabili()
                                                          {
                                                              ID_PROGETTO = (int)reader["ID_PROGETTO"],
                                                              COD_STATO = Convert.ToString(reader["COD_STATO"]),
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
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                //System.Diagnostics.Trace.WriteLine(msg,"Error");
                throw new Exception(msg, ex);
            }

        }


        internal void UpdateProgetto(int id_progetto, string codice_cup)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zCUPUpdateProgetto",
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                sqlCmd.Parameters.AddWithValue2("@IdProgetto", id_progetto);
                sqlCmd.Parameters.AddWithValue2("@CodiceCup", codice_cup);

                SqlHelper.ExecuteNonQueryCmd(connectionString, sqlCmd);
                return;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                throw new Exception(msg, ex);
            }
        }


        internal ParametriRichiestaCupNoFesr GetParametriRichiestaCup(int idProgetto)
        {
            var sqlCmd = new SqlCommand
            {
                CommandText = "zCUPGetParametriRichiesta",
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.AddWithValue2("@IdProgetto", idProgetto);
            try
            {
                var list = SqlHelper.ExecuteReaderCmd(connectionString, sqlCmd,
                                                      reader =>
                                                      {
                                                          var o = new ParametriRichiestaCupNoFesr()
                                                          {
                                                              ID_PROGETTO = (int)reader["ID_PROGETTO"],
                                                              COD_STRUMENTO_PROGRAMMAZIONE = Convert.ToString(reader["COD_TIPO"]) == "STRUMPROGRAMCUP" ? Convert.ToString(reader["VALORE"]) : null,
                                                              FONTI_FINANZIAMENTO = Convert.ToString(reader["COD_TIPO"]) == "FONTIFINANZCUP" ? Convert.ToString(reader["VALORE"]).Split(';').ToList() : null,
                                                              DESC_STRUMENTO_PROGRAMMAZIONE = Convert.ToString(reader["COD_TIPO"]) == "DESCSTRUMPROGRAMCUP" ? Convert.ToString(reader["VALORE"]) : null,
                                                              TITOLO_PROGETTO = Convert.ToString(reader["COD_TIPO"]) == "TITOLOPROGETTOCUP" ? Convert.ToString(reader["VALORE"]) : null,
                                                          };
                                                          return o;
                                                      });

                if (list.Any())
                {
                    var tp = new ParametriRichiestaCupNoFesr()
                    {
                        ID_PROGETTO = list[0].ID_PROGETTO,
                        COD_STRUMENTO_PROGRAMMAZIONE = list.Find(x => x.COD_STRUMENTO_PROGRAMMAZIONE != null).COD_STRUMENTO_PROGRAMMAZIONE,
                        FONTI_FINANZIAMENTO = list.Find(x => x.FONTI_FINANZIAMENTO != null).FONTI_FINANZIAMENTO,
                        DESC_STRUMENTO_PROGRAMMAZIONE = list.FirstOrDefault().DESC_STRUMENTO_PROGRAMMAZIONE,
                        TITOLO_PROGETTO = list.FirstOrDefault().TITOLO_PROGETTO,
                    };

                    return tp;
                }

                return null;
            }
            catch (Exception ex)
            {
                var msg = string.Format("Si è verificato il seguente errore durante l'esecuzione del comando {0}: {1}", sqlCmd.CommandText, ex.Message);
                //System.Diagnostics.Trace.WriteLine(msg,"Error");
                throw new Exception(msg, ex);
            }
        }
    }
}

