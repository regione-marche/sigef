using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class SanzioniCollectionProvider : ISanzioniProvider
    {
        public SanzioniCollection RilevaSanzioniXDomandaPagamento(int id_domanda_pagamento)
        {
            SanzioniCollection sanzioni = new SanzioniCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrRilevaSanzioniXDomandaPagamento";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_DOMANDA_PAGAMENTO", id_domanda_pagamento));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                Sanzioni s = new Sanzioni();
                s.CodTipo = new StringNT(DbProviderObj.DataReader["COD_TIPO"]);
                s.Titolo = new StringNT(DbProviderObj.DataReader["TITOLO"]);
                s.Ammontare = new DecimalNT(DbProviderObj.DataReader["AMMONTARE"]);
                s.IdInvestimento = new IntNT(DbProviderObj.DataReader["NUM_INVESTIMENTI"]);
                s.Livello = new StringNT(DbProviderObj.DataReader["LIVELLO"]);
                s.Automatico = new BoolNT(DbProviderObj.DataReader["AUTOMATICO"]);
                sanzioni.Add(s);
            }
            DbProviderObj.Close();
            return sanzioni;
        }

        /// <summary>
        /// funzione che esegue la query di calcolo della sanzione e ritorna la classe aggiornata
        /// viene utilizzata sia per livello investimenmto che livello domanda
        /// nota: imporre che le query salvino i dati sulla tabella
        /// </summary>
        /// <param name="sanzione"></param>
        /// <returns></returns>
        public Sanzioni CalcoloSanzionePagamento(Sanzioni sanzione)
        {
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = sanzione.QuerySql;
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_SANZIONE", sanzione.IdSanzione.Value));

            System.Data.SqlClient.SqlParameter durata_param = new System.Data.SqlClient.SqlParameter();
            durata_param.ParameterName = "@DURATA";
            if (sanzione.DurataSelezionato)
                if (sanzione.DurataNumerico)
                {
                    if (sanzione.ValoreDurata != null) durata_param.Value = sanzione.ValoreDurata.Value;
                }
                else if (sanzione.Durata != null) durata_param.Value = sanzione.Durata.Value;
            cmd.Parameters.Add(durata_param);

            System.Data.SqlClient.SqlParameter gravita_param = new System.Data.SqlClient.SqlParameter();
            gravita_param.ParameterName = "@GRAVITA";
            if (sanzione.GravitaSelezionato)
                if (sanzione.GravitaNumerico)
                {
                    if (sanzione.ValoreGravita != null) gravita_param.Value = sanzione.ValoreGravita.Value;
                }
                else if (sanzione.Gravita != null) gravita_param.Value = sanzione.Gravita.Value;
            cmd.Parameters.Add(gravita_param);

            System.Data.SqlClient.SqlParameter entita_param = new System.Data.SqlClient.SqlParameter();
            entita_param.ParameterName = "@ENTITA";
            if (sanzione.EntitaSelezionato)
                if (sanzione.EntitaNumerico)
                {
                    if (sanzione.ValoreEntita != null) entita_param.Value = sanzione.ValoreEntita.Value;
                }
                else if (sanzione.Entita != null) entita_param.Value = sanzione.Entita.Value;
            cmd.Parameters.Add(entita_param);

            if (sanzione.Motivazione != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("MOTIVAZIONE", sanzione.Motivazione.Value));

            DbProviderObj.InitDatareader(cmd);
            if (DbProviderObj.DataReader.Read()) sanzione = SiarDAL.SanzioniDAL.GetFromDatareader(DbProviderObj);
            DbProviderObj.Close();
            return sanzione;
        }

        public int AssegnaSanzioneDomandaPagamento(IntNT idDomandaPagamento, string codTipo, SiarLibrary.Operatore op)
        {
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpAssegnaSanzioneDomandaPagamento";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", idDomandaPagamento.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_TIPO_SANZIONE", codTipo));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("OPERATORE", op.Utente.CfUtente.Value));
            object result = DbProviderObj.ExecuteScalar(cmd);
            DbProviderObj.Close();
            int retval;
            if (result == null || !int.TryParse(result.ToString(), out retval)) retval = -1; //errore generico
            return retval;
        }

        public SanzioniCollection GetProgrammazioneSanzioni(int id_programmazione, string livello)
        {
            SanzioniCollection sanzioni = new SanzioniCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetProgrammazioneSanzioni";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGRAMMAZIONE", id_programmazione));
            if (!string.IsNullOrEmpty(livello)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LIVELLO", livello));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                Sanzioni s = new Sanzioni();
                s.CodTipo = new StringNT(DbProviderObj.DataReader["COD_TIPO"]);
                s.Titolo = new StringNT(DbProviderObj.DataReader["TITOLO"]);
                s.Livello = new StringNT(DbProviderObj.DataReader["LIVELLO"]);
                sanzioni.Add(s);
            }
            DbProviderObj.Close();
            return sanzioni;
        }
    }
}
