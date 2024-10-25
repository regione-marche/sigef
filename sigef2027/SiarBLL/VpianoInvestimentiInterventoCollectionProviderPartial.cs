using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class VpianoInvestimentiInterventoCollectionProvider
    {
        public VpianoInvestimentiInterventoCollection GetPianoInvestimentiIntervento(int id_progetto,string cod_fase, int id_intervento)
        {
            string cod_query = "";
            if (cod_fase == "PDOMANDA")
                cod_query = "PIANO_INVESTIMENTI";
            else if(cod_fase =="IDOMANDA")
                cod_query = "PIANO_INVESTIMENTI_ISTRUTTORIA";
            VpianoInvestimentiInterventoCollection investimenti = new VpianoInvestimentiInterventoCollection();
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPianoInvestimentiIntervento";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_QUERY", cod_query));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_INTERVENTO", id_intervento));
            db.InitDatareader(cmd);
            while (db.DataReader.Read()) investimenti.Add(SiarDAL.VpianoInvestimentiInterventoDAL.GetFromDatareader(db));
            db.Close();
            return investimenti;
        }

        public VpianoInvestimentiInterventoCollection GetPianoInvestimentiInterventoVariante(int id_progetto, string cod_fase, int id_variante, int id_intervento)
        {
            string cod_query = "VARIANTE";
            VpianoInvestimentiInterventoCollection investimenti = new VpianoInvestimentiInterventoCollection();
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPianoInvestimentiIntervento";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_QUERY", cod_query));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_VARIANTE_ATTUALE", id_variante));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_INTERVENTO", id_intervento));
            db.InitDatareader(cmd);
            while (db.DataReader.Read()) investimenti.Add(SiarDAL.VpianoInvestimentiInterventoDAL.GetFromDatareader(db));
            db.Close();
            return investimenti;
        }

        public VpianoInvestimentiInterventoCollection GetPianoInvestimentiInterventoDomanda(int id_progetto, int id_domanda_pagamento)
        {
            string cod_query = "INVESTIMENTI_DOMANDA_PAGAMENTO";
            VpianoInvestimentiInterventoCollection investimenti = new VpianoInvestimentiInterventoCollection();
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPianoInvestimentiIntervento";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_QUERY", cod_query));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", id_domanda_pagamento));
            db.InitDatareader(cmd);
            while (db.DataReader.Read()) investimenti.Add(SiarDAL.VpianoInvestimentiInterventoDAL.GetFromDatareader(db));
            db.Close();
            return investimenti;
        }

        




    }
}