using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class PianoInvestimentiCollectionProvider : IPianoInvestimentiProvider
    {
        public PianoInvestimentiCollection GetSituazionePianoInvestimenti(int id_progetto)
        {
            PianoInvestimentiCollection investimenti = new PianoInvestimentiCollection();
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPianoInvestimenti";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_QUERY", "PIANO_INVESTIMENTI"));
            db.InitDatareader(cmd);
            while (db.DataReader.Read()) investimenti.Add(SiarDAL.PianoInvestimentiDAL.GetFromDatareader(db));
            db.Close();
            return investimenti;
        }

        //public PianoInvestimentiCollection GetSituazioneInvestimentiProgettoCorrelato(Progetto progetto, IntNT idVariante)
        //{
        //    PianoInvestimentiCollection investimenti = new PianoInvestimentiCollection();
        //    DbProvider db = DbProviderObj;
        //    System.Data.IDbCommand cmd = db.GetCommand();
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.CommandText = "SpPianoInvestimenti";
        //    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", progetto.IdProgetto.Value));
        //    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_QUERY", "INVESTIMENTI_PROG_CORRELATO"));
        //    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_VARIANTE_ATTUALE", idVariante.Value));
        //    db.InitDatareader(cmd);
        //    while (db.DataReader.Read())
        //        investimenti.Add(SiarDAL.PianoInvestimentiDAL.GetFromDatareader(db));
        //    db.Close();
        //    return investimenti;
        //}

        //public PianoInvestimentiCollection GetSituazioneSpeseGenerali(Progetto progetto)
        //{
        //    PianoInvestimentiCollection spese = new PianoInvestimentiCollection();
        //    //brevetti e fidejussioni
        //    DbProvider db = DbProviderObj;
        //    System.Data.IDbCommand cmd = db.GetCommand();
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.CommandText = "SpPianoInvestimenti";
        //    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", progetto.IdProgetto.Value));
        //    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_QUERY", "SPESE_GENERALI"));
        //    db.InitDatareader(cmd);
        //    while (db.DataReader.Read())
        //    {
        //        PianoInvestimenti PianoInvestimentiObj = new PianoInvestimenti();
        //        PianoInvestimentiObj.IdInvestimento = new IntNT(db.DataReader["ID_INVESTIMENTO"]);
        //        PianoInvestimentiObj.IdProgetto = new IntNT(db.DataReader["ID_PROGETTO"]);
        //        PianoInvestimentiObj.IdProgrammazione = new IntNT(db.DataReader["ID_PROGRAMMAZIONE"]);
        //        PianoInvestimentiObj.Descrizione = new StringNT(db.DataReader["DESCRIZIONE"]);
        //        PianoInvestimentiObj.CostoInvestimento = new DecimalNT(db.DataReader["COSTO_INVESTIMENTO"]);
        //        PianoInvestimentiObj.SpeseGenerali = new DecimalNT(db.DataReader["SPESE_GENERALI"]);
        //        PianoInvestimentiObj.ContributoRichiesto = new DecimalNT(db.DataReader["CONTRIBUTO_RICHIESTO"]);
        //        PianoInvestimentiObj.QuotaContributoRichiesto = new DecimalNT(db.DataReader["QUOTA_CONTRIBUTO_RICHIESTO"]);
        //        PianoInvestimentiObj.CodTipoInvestimento = new IntNT(db.DataReader["COD_TIPO_INVESTIMENTO"]);
        //        //PianoInvestimentiObj.CodiceMisura = new StringNT(db.DataReader["CODICE_MISURA"]);
        //        PianoInvestimentiObj.CodVariazione = new StringNT(db.DataReader["COD_VARIAZIONE"]);
        //        //PianoInvestimentiObj.TipoVariazione = new StringNT(db.DataReader["TIPO_VARIAZIONE"]);
        //        spese.Add(PianoInvestimentiObj);
        //    }
        //    db.Close();
        //    return spese;
        //}

        public PianoInvestimentiCollection GetPianoInvestimentiVariante(int id_progetto, int id_variante)
        {
            PianoInvestimentiCollection investimenti = new PianoInvestimentiCollection();
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPianoInvestimenti";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_QUERY", "VARIANTE_ATTUALE"));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_VARIANTE_ATTUALE", id_variante));
            db.InitDatareader(cmd);
            while (db.DataReader.Read())
                investimenti.Add(SiarDAL.PianoInvestimentiDAL.GetFromDatareader(db));
            db.Close();
            return investimenti;
        }

        //public PianoInvestimentiCollection GetPianoInvestimentiVariantePrecedente(IntNT idProgetto, IntNT idVariante)
        //{
        //    PianoInvestimentiCollection investimenti = new PianoInvestimentiCollection();
        //    DbProvider db = DbProviderObj;
        //    System.Data.IDbCommand cmd = db.GetCommand();
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.CommandText = "SpPianoInvestimenti";
        //    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", idProgetto.Value));
        //    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_QUERY", "VARIANTE_PRECEDENTE"));
        //    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_VARIANTE_ATTUALE", idVariante.Value));
        //    db.InitDatareader(cmd);
        //    while (db.DataReader.Read())
        //        investimenti.Add(SiarDAL.PianoInvestimentiDAL.GetFromDatareader(db));
        //    db.Close();
        //    return investimenti;
        //}

        public PianoInvestimentiCollection GetPianoInvestimentiIstruttoria(int id_progetto)
        {
            PianoInvestimentiCollection investimenti = new PianoInvestimentiCollection();
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPianoInvestimenti";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_QUERY", "PIANO_INVESTIMENTI_ISTRUTTORIA"));
            db.InitDatareader(cmd);
            while (db.DataReader.Read())
                investimenti.Add(SiarDAL.PianoInvestimentiDAL.GetFromDatareader(db));
            db.Close();
            return investimenti;
        }

        public PianoInvestimentiCollection GetPianoInvestimentiDomandaPagamento(int idProgetto, int idDomandaPagamento)
        {
            PianoInvestimentiCollection investimenti = new PianoInvestimentiCollection();
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPianoInvestimenti";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", idProgetto));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_QUERY", "INVESTIMENTI_DOMANDA_PAGAMENTO"));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", idDomandaPagamento));
            db.InitDatareader(cmd);
            while (db.DataReader.Read())
            {
                SiarLibrary.PianoInvestimenti i = SiarDAL.PianoInvestimentiDAL.GetFromDatareader(db);
                i.AdditionalAttributes.Add("ImportoPagamentoRichiesto", db.DataReader["IMPORTO_PAGAMENTO_RICHIESTO"].ToString());
                investimenti.Add(i);
            }
            db.Close();
            return investimenti;
        }

        //public PianoInvestimentiCollection GetSpeseGeneraliDomandaPagamento(int idProgetto, int idDomandaPagamento)
        //{
        //    PianoInvestimentiCollection spese = new PianoInvestimentiCollection();
        //    //brevetti e fidejussioni
        //    DbProvider db = DbProviderObj;
        //    System.Data.IDbCommand cmd = db.GetCommand();
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.CommandText = "SpPianoInvestimenti";
        //    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", idProgetto));
        //    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_QUERY", "SPESE_DOMANDA_PAGAMENTO"));
        //    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", idDomandaPagamento));
        //    db.InitDatareader(cmd);
        //    while (db.DataReader.Read())
        //    {
        //        PianoInvestimenti PianoInvestimentiObj = new PianoInvestimenti();
        //        PianoInvestimentiObj.IdInvestimento = new IntNT(db.DataReader["ID_INVESTIMENTO"]);
        //        PianoInvestimentiObj.IdProgetto = new IntNT(db.DataReader["ID_PROGETTO"]);
        //        PianoInvestimentiObj.IdProgrammazione = new IntNT(db.DataReader["ID_PROGRAMMAZIONE"]);
        //        PianoInvestimentiObj.Descrizione = new StringNT(db.DataReader["DESCRIZIONE"]);
        //        PianoInvestimentiObj.CostoInvestimento = new DecimalNT(db.DataReader["COSTO_INVESTIMENTO"]);
        //        PianoInvestimentiObj.SpeseGenerali = new DecimalNT(db.DataReader["SPESE_GENERALI"]);
        //        PianoInvestimentiObj.ContributoRichiesto = new DecimalNT(db.DataReader["CONTRIBUTO_RICHIESTO"]);
        //        PianoInvestimentiObj.QuotaContributoRichiesto = new DecimalNT(db.DataReader["QUOTA_CONTRIBUTO_RICHIESTO"]);
        //        PianoInvestimentiObj.CodTipoInvestimento = new IntNT(db.DataReader["COD_TIPO_INVESTIMENTO"]);
        //        PianoInvestimentiObj.CodVariazione = new StringNT(db.DataReader["COD_VARIAZIONE"]);
        //        //PianoInvestimentiObj.TipoVariazione = new StringNT(db.DataReader["TIPO_VARIAZIONE"]);
        //        spese.Add(PianoInvestimentiObj);
        //    }
        //    db.Close();
        //    return spese;
        //}

        public DecimalNT GetContributoRimanenteMisura(IntNT idProgetto, IntNT idVariante, IntNT idInvestimento)
        {
            decimal contributo_rimanente = 0;
            try
            {
                DbProvider db = DbProviderObj;
                System.Data.IDbCommand cmd = db.GetCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT DBO.calcoloContributoRimanenteFinanziabileProgetto(" + idProgetto + "," + idVariante + ","
                    + (idInvestimento != null ? idInvestimento.ToString() : "DEFAULT") + ")";
                object result = db.ExecuteScalar(cmd);
                decimal.TryParse(result.ToString(), out contributo_rimanente);
                db.Close();
            }
            catch { }
            return contributo_rimanente;
        }

        public PianoInvestimenti CalcoloPremio(int idProgetto, bool fase_istruttoria, IntNT idVariante)
        {
            try
            {
                PianoInvestimenti premio = null;
                DbProvider db = DbProviderObj;
                System.Data.IDbCommand cmd = db.GetCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT DBO.calcoloPremioContoCapitale(@ID_PROGETTO,@FASE_ISTRUTTORIA,@ID_VARIANTE)";
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", idProgetto));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("FASE_ISTRUTTORIA", fase_istruttoria));
                if (idVariante != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_VARIANTE", idVariante.Value));
                else cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_VARIANTE", System.DBNull.Value));
                object result = db.ExecuteScalar(cmd);
                db.Close();
                if (result != null)
                {
                    decimal ammontare_premio;
                    if (decimal.TryParse(result.ToString(), out ammontare_premio))
                    {
                        premio = new PianoInvestimenti();
                        premio.CostoInvestimento = ammontare_premio;
                    }
                }
                return premio;
            }
            catch { return null; }
        }

        public PianoInvestimenti CalcoloPremioSaldo(IntNT id_domanda_pagamento, IntNT fase_istruttoria)
        {
            try
            {
                PianoInvestimenti premio = null;
                DbProvider db = DbProviderObj;
                System.Data.IDbCommand cmd = db.GetCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT DBO.calcoloPremioContoCapitaleSaldo(" + id_domanda_pagamento + "," + fase_istruttoria + ")";
                object result = db.ExecuteScalar(cmd);
                db.Close();
                if (result != null)
                {
                    decimal ammontare_premio;
                    if (decimal.TryParse(result.ToString(), out ammontare_premio))
                    {
                        premio = new PianoInvestimenti();
                        premio.CostoInvestimento = ammontare_premio;
                    }
                }
                return premio;
            }
            catch { return null; }
        }

        public PianoInvestimentiCollection GetStoricoInvestimento(IntNT idInvestimentoOriginale)
        {
            PianoInvestimentiCollection retCollection = new PianoInvestimentiCollection();
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_INVESTIMENTO_ORIGINALE", idInvestimentoOriginale.Value));
            cmd.CommandText = "SpGetStoricoInvestimento";
            db.InitDatareader(cmd);
            while (db.DataReader.Read())
            {
                PianoInvestimenti PianoInvestimentiObj = new PianoInvestimenti();
                PianoInvestimentiObj.IdInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INVESTIMENTO"]);
                PianoInvestimentiObj.DataVariazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_VARIAZIONE"]);
                PianoInvestimentiObj.OperatoreVariazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE_VARIAZIONE"]);
                PianoInvestimentiObj.IdPrioritaSettoriale = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PRIORITA_SETTORIALE"]);
                PianoInvestimentiObj.Ammesso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AMMESSO"]);
                PianoInvestimentiObj.IdInvestimentoOriginale = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INVESTIMENTO_ORIGINALE"]);
                PianoInvestimentiObj.DataValutazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_VALUTAZIONE"]);
                PianoInvestimentiObj.ValutazioneInvestimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["VALUTAZIONE_INVESTIMENTO"]);
                PianoInvestimentiObj.IdVariante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VARIANTE"]);
                PianoInvestimentiObj.CodVariazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_VARIAZIONE"]);
                retCollection.Add(PianoInvestimentiObj);
            }
            db.Close();
            return retCollection;
        }

        public string CalcoloImportiFidejussione(ref PianoInvestimenti polizza, bool fase_istruttoria)
        {
            try
            {
                string messaggio_troncamento = "", codice_troncamento = null;
                System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SpCalcoloImportiFidejussione";
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", polizza.IdProgetto.Value));
                if (fase_istruttoria)
                {
                    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FASE_ISTRUTTORIA", 1));
                    if (polizza.IdVariante != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_VARIANTE", polizza.IdVariante.Value));
                }
                if (polizza.CostoInvestimento != null)
                    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IMPORTO_POLIZZA_INSERITO", polizza.CostoInvestimento.Value));
                DbProviderObj.InitDatareader(cmd);
                if (DbProviderObj.DataReader.Read())
                {
                    polizza.CostoInvestimento = new DecimalNT(DbProviderObj.DataReader["AMMONTARE_POLIZZA"]);
                    polizza.ContributoRichiesto = new DecimalNT(DbProviderObj.DataReader["CONTRIBUTO_POLIZZA"]);
                    polizza.QuotaContributoRichiesto = new DecimalNT(DbProviderObj.DataReader["QUOTA_CONTRIBUTO_POLIZZA"]);
                    if (polizza.IdInvestimento == null)
                        polizza.IdInvestimento = new IntNT(DbProviderObj.DataReader["ID_INVESTIMENTO"]);
                    codice_troncamento = new StringNT(DbProviderObj.DataReader["COD_TRONCAMENTO"]);
                }
                DbProviderObj.Close();
                switch (codice_troncamento)
                {
                    case "DI":
                        messaggio_troncamento = "<br />N.B: L`importo inserito supera l`ammontare disponibile per le spese generali, è stato troncato.";
                        break;
                    case "IO":
                        messaggio_troncamento = "<br />N.B: L`importo inserito supera l`ammontare richiesto dal beneficiario, è stato troncato.";
                        break;
                    case "CO":
                        messaggio_troncamento = "<br />N.B: Il contributo calcolato supera l`ammontare richiesto dal beneficiario, è stato troncato.";
                        break;
                    case "FI":
                        messaggio_troncamento = "<br />N.B: Il contributo calcolato supera l`ammontare finanziabile disponibile per la misura, è stato troncato.";
                        break;
                }
                return messaggio_troncamento;
            }
            catch { throw; }
        }

        public string[] VerificaRendicontazionePagamentoSaldo(IntNT IdDomandaPagamento)
        {
            string[] result = new string[2];
            try
            {
                System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SpVerificaRendicontazionePagamentoSaldo";
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_DOMANDA_PAGAMENTO", IdDomandaPagamento.Value));
                DbProviderObj.InitDatareader(cmd);
                if (DbProviderObj.DataReader.Read())
                {
                    result[0] = new StringNT(DbProviderObj.DataReader["TIPO_RISULTATO"]);
                    result[1] = new StringNT(DbProviderObj.DataReader["MESSAGGIO_RISULTATO"]);
                }
                DbProviderObj.Close();
            }
            catch { throw; }
            return result;
        }

        public SiarLibrary.NullTypes.DecimalNT ControlloContributoInvestimentoRichiestoVariante(int id_investimento)
        {
            try
            {
                DbProvider db = DbProviderObj;
                System.Data.IDbCommand cmd = db.GetCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT dbo.controlloContributoInvestimentoRichiestoVariante(" + id_investimento.ToString() + ")";
                object result = db.ExecuteScalar(cmd);
                db.Close();
                return new SiarLibrary.NullTypes.DecimalNT(result);
            }
            catch { throw; }
        }

        public decimal GetContributoPagamentiRichiestiInvestimento(IntNT idInvestimento, DatetimeNT data_interrogazione)
        {
            if (data_interrogazione == null) data_interrogazione = DateTime.Now;
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandText = "SELECT DBO.calcoloContributoPagamentiRichiestiInvestimento(@ID_INVESTIMENTO,@DATA)";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_INVESTIMENTO", idInvestimento.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DATA", data_interrogazione.Value));
            object result = DbProviderObj.ExecuteScalar(cmd);
            DbProviderObj.Close();
            decimal retval = 0;
            decimal.TryParse(result.ToString(), out retval);
            return retval;
        }

        /// <summary>
        /// calcola il contributo dell'investimento e riempie i campi della classe con i valori aggiornati
        /// </summary>
        /// <param name="i"></param>
        public void CalcoloContributoInvestimento(ref PianoInvestimenti i, string fase, Nullable<Decimal> quota)
        {
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrCalcoloContributoInvestimento";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_INVESTIMENTO", i.IdInvestimento.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FASE", fase));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@QUOTA_PARAMETRO", quota));
            DbProviderObj.InitDatareader(cmd);
            if (DbProviderObj.DataReader.Read())
            {
                i.ContributoRichiesto = new DecimalNT(DbProviderObj.DataReader["CONTRIBUTO_TRONCATO"]);
                i.QuotaContributoRichiesto = new DecimalNT(DbProviderObj.DataReader["QUOTA_CONTRIBUTO"]);
                i.ContributoAltreFonti = new SiarLibrary.NullTypes.DecimalNT(DbProviderObj.DataReader["CONTRIBUTO_INVESTIMENTO_ALTRE_FONTI"]);
                i.QuotaContributoAltreFonti = new SiarLibrary.NullTypes.DecimalNT(DbProviderObj.DataReader["QUOTA_CONTRIBUTO_ALTRE_FONTI"]);
                i.AdditionalAttributes.Add("MaxSpeseTecniche", new DecimalNT(DbProviderObj.DataReader["MAX_SPESE_TECNICHE"]));
                i.AdditionalAttributes.Add("ContributoSpeseTecniche", new DecimalNT(DbProviderObj.DataReader["CONTRIBUTO_SPESE_TECNICHE"]));
                i.AdditionalAttributes.Add("ContributoInvestimento", new DecimalNT(DbProviderObj.DataReader["CONTRIBUTO_INVESTIMENTO"]));
                i.AdditionalAttributes.Add("ContributoNonTroncato", new DecimalNT(DbProviderObj.DataReader["CONTRIBUTO_TOTALE"]));
                i.AdditionalAttributes.Add("CodTroncamento", new StringNT(DbProviderObj.DataReader["COD_TRONCAMENTO"]));

            }
            DbProviderObj.Close();
        }

        public void CalcoloContributoBrevettiLicenze(ref PianoInvestimenti i, string fase)
        {
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrCalcoloContributoBrevettiLicenze";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_INVESTIMENTO", i.IdInvestimento.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FASE", fase));
            DbProviderObj.InitDatareader(cmd);
            if (DbProviderObj.DataReader.Read())
            {
                i.CostoInvestimento = new DecimalNT(DbProviderObj.DataReader["COSTO_BREVETTO"]);
                i.ContributoRichiesto = new DecimalNT(DbProviderObj.DataReader["CONTRIBUTO_BREVETTO"]);
                i.QuotaContributoRichiesto = new DecimalNT(DbProviderObj.DataReader["QUOTA_CONTRIBUTO"]);
                i.AdditionalAttributes.Add("AmmontareDisponibile", new DecimalNT(DbProviderObj.DataReader["AMMONTARE_DISPONIBILE"]));
                i.AdditionalAttributes.Add("CostoNonTroncato", new DecimalNT(DbProviderObj.DataReader["COSTO_NON_TRONCATO"]));
                i.AdditionalAttributes.Add("ContributoNonTroncato", new DecimalNT(DbProviderObj.DataReader["CONTRIBUTO_NON_TRONCATO"]));
                i.AdditionalAttributes.Add("CodTroncamento", new StringNT(DbProviderObj.DataReader["COD_TRONCAMENTO"]));
            }
            DbProviderObj.Close();
        }

        public void CalcoloContributoContoInteressi(ref PianoInvestimenti i, string fase)
        {
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrCalcoloContributoContoInteressi";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_INVESTIMENTO", i.IdInvestimento.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FASE", fase));
            DbProviderObj.InitDatareader(cmd);
            if (DbProviderObj.DataReader.Read())
            {
                i.ContributoRichiesto = new DecimalNT(DbProviderObj.DataReader["CONTRIBUTO"]);
                i.AdditionalAttributes.Add("ContributoNonTroncato", new DecimalNT(DbProviderObj.DataReader["CONTRIBUTO_NON_TRONCATO"]));
                i.AdditionalAttributes.Add("CodTroncamento", new StringNT(DbProviderObj.DataReader["COD_TRONCAMENTO"]));
            }
            DbProviderObj.Close();
        }

        public DecimalNT CalcoloContributoInvestimentiProgetto(int idProgetto, bool fase_istruttoria, IntNT idVariante)
        {
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT dbo.calcoloContributoInvestimentiProgetto(@ID_PROGETTO,@FASE_ISTRUTTORIA,@ID_VARIANTE)";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", idProgetto));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FASE_ISTRUTTORIA", fase_istruttoria));
            if (idVariante != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_VARIANTE", idVariante.Value));
            else cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_VARIANTE", System.DBNull.Value));
            object o = DbProviderObj.ExecuteScalar(cmd);
            DbProviderObj.Close();
            return new DecimalNT(o);
        }

        public string[] GetImpresaAggregazioneInvestimento(IntNT IdInvestimento)
        {
            string[] result = new string[2];
            try
            {
                System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SpGetImpresaAggregazioneInvestimento";
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_INVESTIMENTO", IdInvestimento.Value));
                DbProviderObj.InitDatareader(cmd);
                if (DbProviderObj.DataReader.Read())
                {
                    result[0] = new StringNT(DbProviderObj.DataReader["CODICE_FISCALE"]);
                    result[1] = new StringNT(DbProviderObj.DataReader["DENOMINAZIONE"]);
                }
                DbProviderObj.Close();
            }
            catch { throw; }
            return result;
        }

        public string GetLineaInterventoInvestimento(IntNT IdInvestimento)
        {
            string result="";
            try
            {
                System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SpGetLineaDiInverventoInvestimento";
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_INVESTIMENTO", IdInvestimento.Value));
                DbProviderObj.InitDatareader(cmd);
                if (DbProviderObj.DataReader.Read())
                {
                    result = new StringNT(DbProviderObj.DataReader["LINEA_INTERVENTO"]);
                }
                DbProviderObj.Close();
            }
            catch { throw; }
            return result;
        }

        public PianoInvestimentiCollection GetPianoInvestimentiGiustificativo(int idDomandaPagamento, int idGiustificativo)
        {
            PianoInvestimentiCollection investimenti = new PianoInvestimentiCollection();
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetPianoInvestimentiGiustificativo";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", idDomandaPagamento));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_GIUSTIFICATIVO", idGiustificativo));
            db.InitDatareader(cmd);
            while (db.DataReader.Read())
            {
                SiarLibrary.PianoInvestimenti i = SiarDAL.PianoInvestimentiDAL.GetFromDatareader(db);
                i.AdditionalAttributes.Add("ImportoGiustificativoRichiesto", db.DataReader["IMPORTO_GIUSTIFICATIVO_RICHIESTO"].ToString());
                i.AdditionalAttributes.Add("ContributoGiustificativoRichiesto", db.DataReader["CONTRIBUTO_GIUSTIFICATIVO_RICHIESTO"].ToString());
                i.AdditionalAttributes.Add("ImportoGiustificativoAmmesso", db.DataReader["IMPORTO_GIUSTIFICATIVO_AMMESSO"].ToString());
                i.AdditionalAttributes.Add("ContributoGiustificativoAmmesso", db.DataReader["CONTRIBUTO_GIUSTIFICATIVO_AMMESSO"].ToString());
                investimenti.Add(i);
            }
            db.Close();
            return investimenti;
        }


    }
}
