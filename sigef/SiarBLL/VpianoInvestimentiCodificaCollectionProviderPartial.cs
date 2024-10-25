using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class VpianoInvestimentiCodificaCollectionProvider 
    {
        public VpianoInvestimentiCodificaCollection GetPianoInvestimentiCodifica(int id_progetto,string cod_fase)
        {
            string cod_query = "";
            if (cod_fase == "PDOMANDA")
                cod_query = "PIANO_INVESTIMENTI";
            else if(cod_fase =="IDOMANDA")
                cod_query = "PIANO_INVESTIMENTI_ISTRUTTORIA";
            VpianoInvestimentiCodificaCollection investimenti = new VpianoInvestimentiCodificaCollection();
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPianoInvestimentiCodifica";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_QUERY", cod_query));
            db.InitDatareader(cmd);
            while (db.DataReader.Read()) investimenti.Add(SiarDAL.VpianoInvestimentiCodificaDAL.GetFromDatareader(db));
            db.Close();
            return investimenti;
        }

        public VpianoInvestimentiCodificaCollection GetPianoInvestimentiCodificaIntervento(int id_progetto, string cod_fase, int id_intervento)
        {
            string cod_query = "";
            if (cod_fase == "PDOMANDA")
                cod_query = "PIANO_INVESTIMENTI";
            else if (cod_fase == "IDOMANDA")
                cod_query = "PIANO_INVESTIMENTI_ISTRUTTORIA";
            VpianoInvestimentiCodificaCollection investimenti = new VpianoInvestimentiCodificaCollection();
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPianoInvestimentiCodifica2";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_QUERY", cod_query));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_INTERVENTO", id_intervento));
            db.InitDatareader(cmd);
            while (db.DataReader.Read()) investimenti.Add(SiarDAL.VpianoInvestimentiCodificaDAL.GetFromDatareader(db));
            db.Close();
            return investimenti;
        }
        

        public VpianoInvestimentiCodificaCollection GetPianoInvestimentiCodificaVariante(int id_progetto, string cod_fase, int id_variante)
        {
            string cod_query = "VARIANTE";
            VpianoInvestimentiCodificaCollection investimenti = new VpianoInvestimentiCodificaCollection();
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPianoInvestimentiCodifica";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_QUERY", cod_query));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_VARIANTE_ATTUALE", id_variante));
            db.InitDatareader(cmd);
            while (db.DataReader.Read()) investimenti.Add(SiarDAL.VpianoInvestimentiCodificaDAL.GetFromDatareader(db));
            db.Close();
            return investimenti;
        }

        public VpianoInvestimentiCodificaCollection GetPianoInvestimentiCodificaVarianteIntervento(int id_progetto, string cod_fase, int id_variante, int id_intervento)
        {
            string cod_query = "VARIANTE";
            VpianoInvestimentiCodificaCollection investimenti = new VpianoInvestimentiCodificaCollection();
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPianoInvestimentiCodifica2";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_QUERY", cod_query));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_INTERVENTO", id_intervento));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_VARIANTE_ATTUALE", id_variante));
            db.InitDatareader(cmd);
            while (db.DataReader.Read()) investimenti.Add(SiarDAL.VpianoInvestimentiCodificaDAL.GetFromDatareader(db));
            db.Close();
            return investimenti;
        }

        public VpianoInvestimentiCodificaCollection GetPianoInvestimentiCodificaDomanda(int id_progetto, int id_domanda_pagamento)
        {
            string cod_query = "INVESTIMENTI_DOMANDA_PAGAMENTO";
            VpianoInvestimentiCodificaCollection investimenti = new VpianoInvestimentiCodificaCollection();
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPianoInvestimentiCodifica";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_QUERY", cod_query));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", id_domanda_pagamento));
            db.InitDatareader(cmd);
            while (db.DataReader.Read()) investimenti.Add(SiarDAL.VpianoInvestimentiCodificaDAL.GetFromDatareader(db));
            db.Close();
            return investimenti;
        }
    }
}