using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;
using CupManager;
using System.Linq;
using System.Collections.Generic;

namespace SiarBLL
{
    public partial class ProgettoCollectionProvider : IProgettoProvider
    {
        public void AggiornaProgetto(Progetto progetto, int id_operatore)
        {
            ProgettoStoricoCollectionProvider storico_provider = new ProgettoStoricoCollectionProvider(DbProviderObj);
            ProgettoStorico s = storico_provider.GetById(progetto.IdStoricoUltimo);
            s.Operatore = id_operatore;
            s.Data = DateTime.Now;
            storico_provider.Save(s);
            progetto = GetById(progetto.IdProgetto);
        }

        public void CambioStatoProgetto(Progetto progetto, string nuovo_stato, string segnatura, IntNT id_atto, SiarLibrary.Operatore operatore, bool riesame,
            bool revisione, bool ricorso)
        {
            ProgettoStorico s = new ProgettoStorico();
            s.IdProgetto = progetto.IdProgetto;
            s.CodStato = nuovo_stato;
            s.Segnatura = segnatura;
            s.IdAtto = id_atto;
            s.Data = DateTime.Now;
            s.Operatore = operatore.Utente.IdUtente;
            s.Ricorso = ricorso;
            s.Riesame = riesame;
            s.Revisione = revisione;
            new ProgettoStoricoCollectionProvider(DbProviderObj).Save(s);
            progetto.IdStoricoUltimo = s.Id;
            Save(progetto);
            progetto = GetById(progetto.IdProgetto);
        }
        public void CambioStatoProgettoRiaperturaProvinciale(Progetto progetto, string nuovo_stato, string segnatura, SiarLibrary.Operatore operatore)
        {
            ProgettoStorico s = new ProgettoStoricoCollectionProvider(DbProviderObj).GetById(progetto.IdStoricoUltimo);
            s.IdProgetto = progetto.IdProgetto;
            s.CodStato = nuovo_stato;
            s.Segnatura = segnatura;
            s.Data = DateTime.Now;
            s.Operatore = operatore.Utente.IdUtente;
            s.Ricorso = false;
            s.Riesame = false;
            s.Revisione = false;
            s.RiaperturaProvinciale = true;
            new ProgettoStoricoCollectionProvider(DbProviderObj).Save(s);
            progetto = GetById(progetto.IdProgetto);
        }

        public void CambioStatoProgetto(Progetto progetto, string newStato, SiarLibrary.Operatore operatore, bool riesame, bool revisione, bool ricorso)
        {
            CambioStatoProgetto(progetto, newStato, null, null, operatore, riesame, revisione, ricorso);
        }

        public void CambioStatoProgetto(Progetto progetto, string newStato, string segnaturaStato, SiarLibrary.Operatore operatore)
        {
            CambioStatoProgetto(progetto, newStato, segnaturaStato, null, operatore, false, false, false);
        }

        public void CambioStatoProgetto(Progetto progetto, string newStato, IntNT id_atto, SiarLibrary.Operatore operatore)
        {
            CambioStatoProgetto(progetto, newStato, null, id_atto, operatore, false, false, false);
        }

        public void CambioStatoProgetto(Progetto progetto, string newStato, SiarLibrary.Operatore operatore)
        {
            CambioStatoProgetto(progetto, newStato, null, null, operatore, false, false, false);
        }

        public void CambioStatoProgettoPregresso(Progetto progetto, string nuovo_stato, string segnatura, DateTime Data, SiarLibrary.Operatore operatore, bool riesame,
            bool revisione, bool ricorso)
        {
            ProgettoStorico s = new ProgettoStorico();
            s.IdProgetto = progetto.IdProgetto;
            s.CodStato = nuovo_stato;
            s.Segnatura = segnatura;
            s.Data = Data;
            s.Operatore = operatore.Utente.IdUtente;
            s.Ricorso = ricorso;
            s.Riesame = riesame;
            s.Revisione = revisione;
            new ProgettoStoricoCollectionProvider(DbProviderObj).Save(s);
            progetto.IdStoricoUltimo = s.Id;
            Save(progetto);
            progetto = GetById(progetto.IdProgetto);
        }


        public void AnnullaUltimoCambioStatoProgetto(Progetto progetto, bool controllo_segnatura)
        {
            if (progetto.CodStato == "P") throw new SiarException(TextErrorCodes.GenericoConLink);
            if (controllo_segnatura && progetto.Segnatura != null) throw new Exception("Non si puo' eliminare uno stato protocollato.");

            ProgettoStoricoCollectionProvider storico_provider = new ProgettoStoricoCollectionProvider(DbProviderObj);
            ProgettoStoricoCollection storico_progetto = storico_provider.Find(progetto.IdProgetto, null, null);
            if (storico_progetto.Count < 2) throw new SiarException(TextErrorCodes.GenericoConLink);
            ProgettoStorico stato_attuale = storico_progetto.CollectionGetById(progetto.IdStoricoUltimo);
            storico_progetto.Remove(stato_attuale);
            storico_provider.Delete(stato_attuale);
            progetto.IdStoricoUltimo = storico_progetto[0].Id;
            Save(progetto);
            progetto = GetById(progetto.IdProgetto);
        }

        public void AnnullaUltimoCambioStatoProgetto(Progetto progetto, bool controllo_segnatura, DbProvider dbProvider)
        {
            if (progetto.CodStato == "P") throw new SiarException(TextErrorCodes.GenericoConLink);
            if (controllo_segnatura && progetto.Segnatura != null) throw new Exception("Non si puo' eliminare uno stato protocollato.");

            ProgettoStoricoCollectionProvider storico_provider = new ProgettoStoricoCollectionProvider(dbProvider);
            ProgettoStoricoCollection storico_progetto = storico_provider.Find(progetto.IdProgetto, null, null);
            if (storico_progetto.Count < 2) throw new SiarException(TextErrorCodes.GenericoConLink);
            ProgettoStorico stato_attuale = storico_progetto.CollectionGetById(progetto.IdStoricoUltimo);
            storico_progetto.Remove(stato_attuale);
            storico_provider.Delete(stato_attuale);
            progetto.IdStoricoUltimo = storico_progetto[0].Id;
            Save(progetto);
            progetto = GetById(progetto.IdProgetto);
        }

        /// <summary>
        /// usata per l'assegnazione dei progetti i funzionari istruttori
        /// FASE ISTRUTTORIA
        /// </summary>
        /// <returns></returns>
        public ProgettoCollection FindProgettiNonAssegnati(int idBando, IntNT idComune, StringNT provincia)
        {
            ProgettoCollection progetti = new ProgettoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetAssegnazioneDomande";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_BANDO", idBando));
            if (provincia != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("PROVINCIA", provincia.Value));
            if (idComune != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_COMUNE", idComune.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                Progetto p = ProgettoDAL.GetFromDatareader(DbProviderObj);
                p.AdditionalAttributes.Add("DATA_PRESENTAZIONE", new DatetimeNT(DbProviderObj.DataReader["DATA_PRESENTAZIONE"]));
                p.AdditionalAttributes.Add("CUAA", new StringNT(DbProviderObj.DataReader["CUAA"].ToString()));
                p.AdditionalAttributes.Add("PIVA", new StringNT(DbProviderObj.DataReader["CODICE_FISCALE"].ToString()));
                p.AdditionalAttributes.Add("RagioneSociale", new StringNT(DbProviderObj.DataReader["RAGIONE_SOCIALE"].ToString()));
                p.AdditionalAttributes.Add("SedeLegale", new StringNT(DbProviderObj.DataReader["COMUNE"].ToString()) + "("
                    + new StringNT(DbProviderObj.DataReader["SIGLA"].ToString()) + ") - " + new StringNT(DbProviderObj.DataReader["CAP"].ToString()));
                progetti.Add(p);
            }
            DbProviderObj.Close();
            return progetti;
        }

        public void ControlloAziendaAbilitataXPresentazioneDomanda(IntNT IdBando, IntNT IdImpresa, IntNT IdUtente)
        {
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrControlloAziendaAbilitataXPresentazioneDomanda";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_BANDO", IdBando.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_IMPRESA", IdImpresa.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_UTENTE", IdUtente.Value));
            DbProviderObj.InitDatareader(cmd);
            IntNT cod_risultato = null;
            StringNT messaggio = null;
            if (DbProviderObj.DataReader.Read())
            {
                cod_risultato = new IntNT(DbProviderObj.DataReader["COD_RISULTATO"]);
                messaggio = new StringNT(DbProviderObj.DataReader["MESSAGGIO"]);
            }
            DbProviderObj.Close();
            if (cod_risultato != 0) throw new Exception(messaggio);
        }

        public string VerificaCondizioniGeneraliPresentazioneDomandaAiuto(IntNT IdProgetto)
        {
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpVerificaCondizioniGeneraliPresentazioneDomandaAiuto";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", IdProgetto.Value));
            DbProviderObj.InitDatareader(cmd);
            int cod_risultato = 0;
            string messaggio = null;
            if (DbProviderObj.DataReader.Read())
            {
                cod_risultato = new IntNT(DbProviderObj.DataReader["RETVAL"]);
                messaggio = new StringNT(DbProviderObj.DataReader["ERRORE"]);
            }
            DbProviderObj.Close();
            if (cod_risultato == 2) throw new Exception(messaggio);
            return messaggio;
        }

        public string VerificaCondizioniGeneraliPresentazioneDomandaCovid(IntNT IdProgetto)
        {
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpVerificaCondizioniGeneraliPresentazioneDomandaAiutoCovid";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", IdProgetto.Value));
            DbProviderObj.InitDatareader(cmd);
            int cod_risultato = 0;
            string messaggio = null;
            if (DbProviderObj.DataReader.Read())
            {
                cod_risultato = new IntNT(DbProviderObj.DataReader["RETVAL"]);
                messaggio = new StringNT(DbProviderObj.DataReader["ERRORE"]);
            }
            DbProviderObj.Close();
            if (cod_risultato == 1)
            {
                throw new Exception(messaggio);
            }
            else if (cod_risultato == 2)
            {
                // tolgo l'ultima virgola
                messaggio = messaggio.Substring(0, messaggio.Length - 1);
                string[] ids = messaggio.Split(';');
                string return_message = "Sono stati trovati errori nelle seguenti informazioni: <br />";
                SiarBLL.StepCollectionProvider stepProvider = new StepCollectionProvider();
                foreach (string id in ids)
                {
                    SiarLibrary.Step step = stepProvider.GetById(int.Parse(id));
                    return_message += step.Descrizione + "; <br />";
                }
                throw new Exception(return_message);
            }
            return messaggio;
        }

        public void CalcoloPunteggioDomandaDiAiuto(IntNT IdProgetto, IntNT IdVariante, StringNT punteggi_manuali, BoolNT istruttoria, StringNT operatore)
        {
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpCalcoloPunteggioDomandaDiAiuto";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", IdProgetto.Value));
            if (IdVariante != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_VARIANTE", IdVariante.Value));
            if (punteggi_manuali != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PUNTEGGI_MANUALI", punteggi_manuali.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ISTRUTTORIA", istruttoria.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OPERATORE", operatore.Value));
            DbProviderObj.Execute(cmd);
            DbProviderObj.Close();
        }

        public void CalcoloPunteggiAutomaticiDomandaDiAiuto(IntNT IdProgetto, IntNT IdVariante, BoolNT istruttoria, StringNT operatore)
        {
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpCalcoloPunteggiAutomaticiDomandaDiAiuto";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", IdProgetto.Value));
            if (IdVariante != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_VARIANTE", IdVariante.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ISTRUTTORIA", istruttoria.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OPERATORE", operatore.Value));
            DbProviderObj.Execute(cmd);
            DbProviderObj.Close();
        }

        public ProgettoCollection RicercaGeneraleProgetti(IntNT IdProgetto, string cod_stato, IntNT IdBando, string cuaa, string ragione_sociale,
            string provincia, IntNT IdProgrammazione, string cod_ente_bando, IntNT IdIstruttore, IntNT IdRespProvinciale,
            bool pagamenti, bool varianti, bool ad_tecnici, bool ist_conclusa, bool ist_incorso, bool annullati, string tipo_Dom_pag)
        {
            ProgettoCollection pp = new ProgettoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrRicercaGeneraleDomandaDiAiuto";
            if (IdProgetto != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", IdProgetto.Value));
            if (!string.IsNullOrEmpty(cod_stato)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_STATO", cod_stato));
            if (IdBando != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", IdBando.Value));
            if (!string.IsNullOrEmpty(cuaa)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CUAA", cuaa));
            if (!string.IsNullOrEmpty(ragione_sociale)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RAGIONE_SOCIALE", ragione_sociale));
            if (!string.IsNullOrEmpty(provincia)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PROVINCIA", provincia));
            if (IdProgrammazione != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGRAMMAZIONE", IdProgrammazione.Value));
            if (!string.IsNullOrEmpty(cod_ente_bando)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_ENTE_BANDO", cod_ente_bando));
            if (IdIstruttore != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_ISTRUTTORE", IdIstruttore.Value));
            if (IdRespProvinciale != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_RESP_PROVINCIALE", IdRespProvinciale.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DPAGAMENTO", pagamenti));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VARIANTI", varianti));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AT", ad_tecnici));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IST_CONCLUSA", ist_conclusa));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IST_INCORSO", ist_incorso));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ANNULLATI", annullati));
            if (tipo_Dom_pag != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_TIPO_DP", tipo_Dom_pag));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                Progetto p = new Progetto();
                p.IdProgetto = new IntNT(DbProviderObj.DataReader["ID_PROGETTO"]);
                p.IdBando = new IntNT(DbProviderObj.DataReader["ID_BANDO"]);
                p.CodStato = new StringNT(DbProviderObj.DataReader["COD_STATO"]);
                p.CodFase = new StringNT(DbProviderObj.DataReader["COD_FASE"]);
                p.OrdineFase = new SiarLibrary.NullTypes.IntNT(DbProviderObj.DataReader["ORDINE_FASE"]);
                p.Stato = new StringNT(DbProviderObj.DataReader["STATO"]);
                p.IdImpresa = new IntNT(DbProviderObj.DataReader["ID_IMPRESA"]);
                // CAMPI CUSTOM
                p.Data = new DatetimeNT(DbProviderObj.DataReader["DATA_PRESENTAZIONE"]);
                p.Provincia = new StringNT(DbProviderObj.DataReader["PROVINCIA_SEDELEGALE"]); // sede legale impresa
                p.AdditionalAttributes.Add("PIVA", new StringNT(DbProviderObj.DataReader["PIVA"]));
                p.AdditionalAttributes.Add("RAGIONE_SOCIALE", new StringNT(DbProviderObj.DataReader["RAGIONE_SOCIALE"]));
                p.AdditionalAttributes.Add("PROGRAMMAZIONE", new StringNT(DbProviderObj.DataReader["PROGRAMMAZIONE"]));
                p.AdditionalAttributes.Add("COSTO_PROGETTO", new DecimalNT(DbProviderObj.DataReader["COSTO_PROGETTO"]));
                p.AdditionalAttributes.Add("CONTRIBUTO_PROGETTO", new DecimalNT(DbProviderObj.DataReader["CONTRIBUTO_PROGETTO"]));
                pp.Add(p);
            }
            DbProviderObj.Close();
            return pp;
        }

        public ProgettoCollection RicercaGeneraleProgettiOperePubbliche(IntNT IdProgetto, string cod_stato, IntNT IdBando, string cuaa, string ragione_sociale,
            string provincia, IntNT IdProgrammazione, string cod_ente_bando, IntNT IdIstruttore, IntNT IdRespProvinciale,
            bool pagamenti, bool varianti, bool ad_tecnici, bool ist_conclusa, bool ist_incorso, bool annullati, string tipo_Dom_pag)
        {
            ProgettoCollection pp = new ProgettoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrRicercaGeneraleDomandaDiAiutoOperePubbliche";
            if (IdProgetto != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", IdProgetto.Value));
            if (!string.IsNullOrEmpty(cod_stato)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_STATO", cod_stato));
            if (IdBando != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", IdBando.Value));
            if (!string.IsNullOrEmpty(cuaa)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CUAA", cuaa));
            if (!string.IsNullOrEmpty(ragione_sociale)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RAGIONE_SOCIALE", ragione_sociale));
            if (!string.IsNullOrEmpty(provincia)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PROVINCIA", provincia));
            if (IdProgrammazione != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGRAMMAZIONE", IdProgrammazione.Value));
            if (!string.IsNullOrEmpty(cod_ente_bando)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_ENTE_BANDO", cod_ente_bando));
            if (IdIstruttore != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_ISTRUTTORE", IdIstruttore.Value));
            if (IdRespProvinciale != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_RESP_PROVINCIALE", IdRespProvinciale.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DPAGAMENTO", pagamenti));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VARIANTI", varianti));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AT", ad_tecnici));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IST_CONCLUSA", ist_conclusa));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IST_INCORSO", ist_incorso));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ANNULLATI", annullati));
            if (tipo_Dom_pag != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_TIPO_DP", tipo_Dom_pag));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                Progetto p = new Progetto();
                p.IdProgetto = new IntNT(DbProviderObj.DataReader["ID_PROGETTO"]);
                p.IdBando = new IntNT(DbProviderObj.DataReader["ID_BANDO"]);
                p.CodStato = new StringNT(DbProviderObj.DataReader["COD_STATO"]);
                p.CodFase = new StringNT(DbProviderObj.DataReader["COD_FASE"]);
                p.OrdineFase = new SiarLibrary.NullTypes.IntNT(DbProviderObj.DataReader["ORDINE_FASE"]);
                p.Stato = new StringNT(DbProviderObj.DataReader["STATO"]);
                p.IdImpresa = new IntNT(DbProviderObj.DataReader["ID_IMPRESA"]);
                // CAMPI CUSTOM
                p.Data = new DatetimeNT(DbProviderObj.DataReader["DATA_PRESENTAZIONE"]);
                p.Provincia = new StringNT(DbProviderObj.DataReader["PROVINCIA_SEDELEGALE"]); // sede legale impresa
                p.AdditionalAttributes.Add("PIVA", new StringNT(DbProviderObj.DataReader["PIVA"]));
                p.AdditionalAttributes.Add("RAGIONE_SOCIALE", new StringNT(DbProviderObj.DataReader["RAGIONE_SOCIALE"]));
                p.AdditionalAttributes.Add("PROGRAMMAZIONE", new StringNT(DbProviderObj.DataReader["PROGRAMMAZIONE"]));
                p.AdditionalAttributes.Add("COSTO_PROGETTO", new DecimalNT(DbProviderObj.DataReader["COSTO_PROGETTO"]));
                p.AdditionalAttributes.Add("CONTRIBUTO_PROGETTO", new DecimalNT(DbProviderObj.DataReader["CONTRIBUTO_PROGETTO"]));
                pp.Add(p);
            }
            DbProviderObj.Close();
            return pp;
        }

        public bool AbilitaDoppiaFirmaDomandaAiuto(int idProgetto, bool istruttoria)
        {
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT DBO.fnGetNrFirmatariProgetto(@ID_PROGETTO,@ISTRUTTORIA )";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", idProgetto));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ISTRUTTORIA", istruttoria));
            object result = db.ExecuteScalar(cmd);
            db.Close();
            return (int)result > 1;
        }


        public void AggiornaCupProgetto(Progetto progetto, int id_operatore)
        {
            try
            {
                CupRichiesta cup = new CupRichiesta();
                var result = cup.RequestCodiceCUP(progetto.IdProgetto);
                if (result.Esito == "OK")
                {
                    progetto.CodAgea = result.CodiceCUP;
                    progetto.Save();
                    this.AggiornaProgetto(progetto, id_operatore);
                    progetto = GetById(progetto.IdProgetto);
                }
                else
                {
                    throw new Exception("Si è verificato un errore durante la richiesta CUP: " + result.Messaggio);
                }
            }
            catch (Exception ex)
            {               
                throw ex;
            }
            
        }

        public ProgettoCollection RicercaGeneraleProgettiNonProvvisori(IntNT IdProgetto, string cod_stato, IntNT IdBando, string cuaa, string ragione_sociale,
            string provincia, IntNT IdProgrammazione, string cod_ente_bando, IntNT IdIstruttore, IntNT IdRespProvinciale,
            bool pagamenti, bool varianti, bool ad_tecnici, bool ist_conclusa, bool ist_incorso, bool annullati)
        {
            ProgettoCollection pp = new ProgettoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrRicercaGeneraleDomandaDiAiutoNonProvvisorie";
            if (IdProgetto != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", IdProgetto.Value));
            if (!string.IsNullOrEmpty(cod_stato)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_STATO", cod_stato));
            if (IdBando != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", IdBando.Value));
            if (!string.IsNullOrEmpty(cuaa)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CUAA", cuaa));
            if (!string.IsNullOrEmpty(ragione_sociale)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RAGIONE_SOCIALE", ragione_sociale));
            if (!string.IsNullOrEmpty(provincia)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PROVINCIA", provincia));
            if (IdProgrammazione != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGRAMMAZIONE", IdProgrammazione.Value));
            if (!string.IsNullOrEmpty(cod_ente_bando)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_ENTE_BANDO", cod_ente_bando));
            if (IdIstruttore != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_ISTRUTTORE", IdIstruttore.Value));
            if (IdRespProvinciale != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_RESP_PROVINCIALE", IdRespProvinciale.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DPAGAMENTO", pagamenti));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VARIANTI", varianti));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AT", ad_tecnici));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IST_CONCLUSA", ist_conclusa));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IST_INCORSO", ist_incorso));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ANNULLATI", annullati));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                Progetto p = new Progetto();
                p.IdProgetto = new IntNT(DbProviderObj.DataReader["ID_PROGETTO"]);
                p.IdBando = new IntNT(DbProviderObj.DataReader["ID_BANDO"]);
                p.CodStato = new StringNT(DbProviderObj.DataReader["COD_STATO"]);
                p.CodFase = new StringNT(DbProviderObj.DataReader["COD_FASE"]);
                p.OrdineFase = new SiarLibrary.NullTypes.IntNT(DbProviderObj.DataReader["ORDINE_FASE"]);
                p.Stato = new StringNT(DbProviderObj.DataReader["STATO"]);
                p.IdImpresa = new IntNT(DbProviderObj.DataReader["ID_IMPRESA"]);
                // CAMPI CUSTOM
                p.Data = new DatetimeNT(DbProviderObj.DataReader["DATA_PRESENTAZIONE"]);
                p.Provincia = new StringNT(DbProviderObj.DataReader["PROVINCIA_SEDELEGALE"]); // sede legale impresa
                p.AdditionalAttributes.Add("PIVA", new StringNT(DbProviderObj.DataReader["PIVA"]));
                p.AdditionalAttributes.Add("RAGIONE_SOCIALE", new StringNT(DbProviderObj.DataReader["RAGIONE_SOCIALE"]));
                p.AdditionalAttributes.Add("PROGRAMMAZIONE", new StringNT(DbProviderObj.DataReader["PROGRAMMAZIONE"]));
                p.AdditionalAttributes.Add("COSTO_PROGETTO", new DecimalNT(DbProviderObj.DataReader["COSTO_PROGETTO"]));
                p.AdditionalAttributes.Add("CONTRIBUTO_PROGETTO", new DecimalNT(DbProviderObj.DataReader["CONTRIBUTO_PROGETTO"]));
                pp.Add(p);
            }
            DbProviderObj.Close();
            return pp;
        }


        public decimal CalcolaTotaleContributoAltreFonti(int IdProgetto)
        {
            decimal totaleImportoFem = 0;
            PianoInvestimentiCollection pianoInv_col = new PianoInvestimentiCollectionProvider().GetSituazionePianoInvestimenti(IdProgetto);

            foreach (PianoInvestimenti p in pianoInv_col)
            {
                if (p.ContributoAltreFonti != null)
                    totaleImportoFem += p.ContributoAltreFonti;
            }

            return totaleImportoFem;
        }

        public decimal CalcolaTotaleContributo(int IdProgetto)
        {
            decimal totaleImporto = 0;
            var pianoInv_list = new PianoInvestimentiCollectionProvider().GetSituazionePianoInvestimenti(IdProgetto)
                .ToArrayList<PianoInvestimenti>();

            totaleImporto = (from p in pianoInv_list
                             select p).Sum(p => p.ContributoRichiesto);

            return totaleImporto;
        }

        public int VerificaProgettiEsistenti(string progetti)
        {
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = @"SELECT COUNT(*)
                                FROM PROGETTO P
                                WHERE 1 = 1
                                    AND (@IdProgetti IS NULL 
                                        OR P.ID_PROGETTO IN (SELECT Item 
                                                               FROM dbo.SplitString(@IdProgetti, ',')))";

            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("IdProgetti", string.IsNullOrEmpty(progetti) ? null : progetti));

            int result = (int)db.ExecuteScalar(cmd);
            db.Close();
            return result;
        }

        public void DeleteProgetto(Progetto prog, DbProvider dbProvider )
        {
            if (dbProvider != null)
                this.DbProviderObj = dbProvider;

            // allegati
            ProgettoAllegatiCollectionProvider allegati_provider = new ProgettoAllegatiCollectionProvider(this.DbProviderObj);
            allegati_provider.DeleteCollection(allegati_provider.Find(prog.IdProgetto, null));

            // Dichiarazioni
            DichiarazioniXProgettoCollectionProvider dichiarazioniprovider = new DichiarazioniXProgettoCollectionProvider(this.DbProviderObj);
            dichiarazioniprovider.DeleteCollection(dichiarazioniprovider.Find(null, prog.IdProgetto));

            // Requisiti Soggettivi (PrioritaXprogetto)
            PrioritaXProgettoCollectionProvider prioXproProvider = new PrioritaXProgettoCollectionProvider(this.DbProviderObj);
            prioXproProvider.DeleteCollection(prioXproProvider.Find(prog.IdProgetto, null, null));

            // Dati monitoraggio
            DatiMonitoraggioFESRCollectionProvider dtMonProv = new DatiMonitoraggioFESRCollectionProvider(this.DbProviderObj);
            dtMonProv.DeleteCollection(dtMonProv.Find(null, prog.IdProgetto));

            // Localizzazione progetto
            LocalizzazioneProgettoCollectionProvider dtLocProv = new LocalizzazioneProgettoCollectionProvider(this.DbProviderObj);
            dtLocProv.DeleteCollection(dtLocProv.Find(null, prog.IdProgetto, null, null));

            // CollaboratoriXprogetto
            // commentata perche' dati non ancora presenti in questa fase
            //CollaboratoriXBandoCollectionProvider collaboratoriprovider = new CollaboratoriXBandoCollectionProvider(this.DbProviderObj);
            //collaboratoriprovider.DeleteCollection(collaboratoriprovider.Find(null, null, null, prog.IdProgetto));

            // Piano investimenti
            PianoInvestimentiCollectionProvider pianoinvestimentiprovider = new PianoInvestimentiCollectionProvider(this.DbProviderObj);
            PianoInvestimentiCollection pianocoll = pianoinvestimentiprovider.Find(null, prog.IdProgetto, null, null, null, null, null);

            // priorita x investimenti
            PrioritaXInvestimentiCollectionProvider prioXinvestimentiProvider = new PrioritaXInvestimentiCollectionProvider(this.DbProviderObj);
            foreach (PianoInvestimenti piano in pianocoll)
            {
                // Localizzazione Investimento
                //localprovider.DeleteCollection(localprovider.Find(null, piano.IdInvestimento, null, null));
                // Priorita per investimento
                prioXinvestimentiProvider.DeleteCollection(prioXinvestimentiProvider.Find(null, piano.IdInvestimento, null, null));
            }
            pianoinvestimentiprovider.DeleteCollection(pianocoll);

            //Natura soggetto Aggregazione
            ProgettoNaturaSoggettoCollectionProvider progettonaturasoggettoprovider = new ProgettoNaturaSoggettoCollectionProvider(this.DbProviderObj);
            progettonaturasoggettoprovider.DeleteCollection(progettonaturasoggettoprovider.Find(prog.IdProgetto, null, null));

            //priorita x imprese
            PrioritaXImpresaCollectionProvider prioritaximpreseprovider = new PrioritaXImpresaCollectionProvider(this.DbProviderObj);
            prioritaximpreseprovider.DeleteCollection(prioritaximpreseprovider.Find(null, null, prog.IdProgetto, null, null));

            // Piano Di sviluppo
            PianoDiSviluppoCollectionProvider pianodisviluppoprovider = new PianoDiSviluppoCollectionProvider(this.DbProviderObj);
            pianodisviluppoprovider.DeleteCollection(pianodisviluppoprovider.Find(null, null, prog.IdProgetto, null));

            // Bilanci
            BilancioAgricoloCollectionProvider bilagriprov = new BilancioAgricoloCollectionProvider(this.DbProviderObj);
            bilagriprov.DeleteCollection(bilagriprov.Find(null, null, prog.IdProgetto, null, null, null));
            BilancioIndustrialeCollectionProvider bilindprov = new BilancioIndustrialeCollectionProvider(this.DbProviderObj);
            bilindprov.DeleteCollection(bilindprov.Find(null, null, prog.IdProgetto, null, null, null));

            // RelazioneTecnica
            ProgettoRelazioneTecnicaCollectionProvider relazionetecnicaprovider = new ProgettoRelazioneTecnicaCollectionProvider(this.DbProviderObj);
            relazionetecnicaprovider.DeleteCollection(relazionetecnicaprovider.Find(prog.IdProgetto, null));

            // graduatoria Progetto
            // commentata perche' dati non ancora presenti in questa fase
            //SiarBLL.GraduatoriaProgettiCollectionProvider graduatoriaprogetto = new SiarBLL.GraduatoriaProgettiCollectionProvider(this.DbProviderObj);
            //graduatoriaprogetto.DeleteCollection(graduatoriaprogetto.Find(null, prog.IdProgetto));

            // progetto segnature
            //non implementata perche' non sono ancora presenti in questa fase                    

            // Progetti filiera
            //SiarBLL.PartecipantiXFilieraCollectionProvider partecipantiprovider = new SiarBLL.PartecipantiXFilieraCollectionProvider(this.DbProviderObj);
            //partecipantiprovider.DeleteCollection(partecipantiprovider.Find(null, null, null, Progetto.IdProgetto));

            // Indicatori
            ProgettoIndicatoriCollectionProvider indicatoriprovider = new ProgettoIndicatoriCollectionProvider(this.DbProviderObj);
            indicatoriprovider.DeleteCollection(indicatoriprovider.Find(prog.IdProgetto, null, null));

            // Iter StatoProgetto
            IterProgettoCollectionProvider iterprogettoprovider = new IterProgettoCollectionProvider(this.DbProviderObj);
            iterprogettoprovider.DeleteCollection(iterprogettoprovider.Find(prog.IdProgetto, null, null, null, null, null, null));

            // storico progetto
            ProgettoStoricoCollectionProvider storico_provider = new ProgettoStoricoCollectionProvider(this.DbProviderObj);
            storico_provider.DeleteCollection(storico_provider.Find(prog.IdProgetto, null, null));

            // Graduatoria progetto
            GraduatoriaProgettiCollectionProvider graduatoria_provider = new GraduatoriaProgettiCollectionProvider(this.DbProviderObj);
            graduatoria_provider.DeleteCollection(graduatoria_provider.Find(null, prog.IdProgetto, null));

            // Progetto comunicazione
            ProgettoComunicazioneCollectionProvider comunicazione_provider = new ProgettoComunicazioneCollectionProvider(this.DbProviderObj);
            comunicazione_provider.DeleteCollection(comunicazione_provider.Find(prog.IdProgetto, null, null, null, null, null));

            // Iter progetto
            IterProgettoCollectionProvider iter_provider = new IterProgettoCollectionProvider(this.DbProviderObj);
            iter_provider.DeleteCollection(iter_provider.Find(prog.IdProgetto, null, null, null, null, null, null));

            // elimino il progetto alla fine
            this.Delete(prog);
        }


        public List<int> GetProgettiCupDoppi(int? IdProgetto, string CodiceCUP)
        {
            List<int> result = new List<int>();
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = @"SELECT 
                                p.ID_PROGETTO--,
                                --cnt_cup.COD_AGEA
                                FROM 
                                PROGETTO p
                                JOIN 
                                (
	                                SELECT 
	                                COUNT(p.ID_PROGETTO) cnt,
	                                p.COD_AGEA
	                                FROM PROGETTO p
	                                WHERE 
	                                p.COD_AGEA IS NOT NULL
	                                GROUP BY 
	                                p.COD_AGEA
	                                HAVING COUNT(p.ID_PROGETTO) > 1
                                ) cnt_cup ON 
                                p.COD_AGEA = cnt_cup.COD_AGEA
                                WHERE 
                                ((@id_progetto IS NULL) OR (p.ID_PROGETTO <> @id_progetto))
                                AND 
                                cnt_cup.COD_AGEA = @cod_agea
                                ORDER BY 
                                p.COD_AGEA";

            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("id_progetto", IdProgetto));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("cod_agea", CodiceCUP));
            try
            {
                if (string.IsNullOrEmpty(CodiceCUP))
                {
                    return result;
                }
                DbProviderObj.InitDatareader(cmd);
                while (DbProviderObj.DataReader.Read())
                {
                    result.Add((int)DbProviderObj.DataReader["ID_PROGETTO"]);
                }
                DbProviderObj.Close();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
