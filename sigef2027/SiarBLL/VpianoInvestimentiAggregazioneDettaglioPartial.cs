using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class VpianoInvestimentiAggregazioneDettaglioCollectionProvider 
    {
        public VpianoInvestimentiAggregazioneDettaglioCollection GetPianoInvestimentiAggregazione(int id_progetto,string cod_fase)
        {
            string cod_query = "";
            if (cod_fase == "PDOMANDA")
                cod_query = "PIANO_INVESTIMENTI";
            else if(cod_fase =="IDOMANDA")
                cod_query = "PIANO_INVESTIMENTI_ISTRUTTORIA";
            VpianoInvestimentiAggregazioneDettaglioCollection investimenti = new VpianoInvestimentiAggregazioneDettaglioCollection();
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPianoInvestimentiAggregazioneImpresa";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_QUERY", cod_query));
            db.InitDatareader(cmd);
            while (db.DataReader.Read()) investimenti.Add(SiarDAL.VpianoInvestimentiAggregazioneDettaglioDAL.GetFromDatareader(db));
            db.Close();
            return investimenti;
        }

        public VpianoInvestimentiAggregazioneDettaglioCollection GetPianoInvestimentiAggregazioneVariante(int id_progetto, string cod_fase, int id_variante)
        {
            string cod_query = "VARIANTE";
            VpianoInvestimentiAggregazioneDettaglioCollection investimenti = new VpianoInvestimentiAggregazioneDettaglioCollection();
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPianoInvestimentiAggregazioneImpresa";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_QUERY", cod_query));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_VARIANTE_ATTUALE", id_variante));
            db.InitDatareader(cmd);
            while (db.DataReader.Read()) investimenti.Add(SiarDAL.VpianoInvestimentiAggregazioneDettaglioDAL.GetFromDatareader(db));
            db.Close();
            return investimenti;
        }

        public VpianoInvestimentiAggregazioneDettaglioCollection GetPianoInvestimentiAggregazioneIntervento(int id_progetto, string cod_fase, int id_intervento)
        {
            string cod_query = "";
            if (cod_fase == "PDOMANDA")
                cod_query = "PIANO_INVESTIMENTI";
            else if (cod_fase == "IDOMANDA")
                cod_query = "PIANO_INVESTIMENTI_ISTRUTTORIA";
            VpianoInvestimentiAggregazioneDettaglioCollection investimenti = new VpianoInvestimentiAggregazioneDettaglioCollection();
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPianoInvestimentiAggregazioneImpresa2";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_QUERY", cod_query));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_INTERVENTO", id_intervento));
            db.InitDatareader(cmd);
            while (db.DataReader.Read()) investimenti.Add(SiarDAL.VpianoInvestimentiAggregazioneDettaglioDAL.GetFromDatareader(db));
            db.Close();
            return investimenti;
        }

        public VpianoInvestimentiAggregazioneDettaglioCollection GetPianoInvestimentiAggregazioneVarianteIntervento(int id_progetto, string cod_fase, int id_variante, int id_intervento)
        {
            string cod_query = "VARIANTE";
            VpianoInvestimentiAggregazioneDettaglioCollection investimenti = new VpianoInvestimentiAggregazioneDettaglioCollection();
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPianoInvestimentiAggregazioneImpresa2";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_QUERY", cod_query));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_VARIANTE_ATTUALE", id_variante));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_INTERVENTO", id_intervento));
            db.InitDatareader(cmd);
            while (db.DataReader.Read()) investimenti.Add(SiarDAL.VpianoInvestimentiAggregazioneDettaglioDAL.GetFromDatareader(db));
            db.Close();
            return investimenti;
        }

        public VpianoInvestimentiAggregazioneDettaglioCollection GetPianoInvestimentiAggregazioneDomanda(int id_progetto, int id_domanda_pagamento)
        {
            string cod_query = "INVESTIMENTI_DOMANDA_PAGAMENTO";
            VpianoInvestimentiAggregazioneDettaglioCollection investimenti = new VpianoInvestimentiAggregazioneDettaglioCollection();
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPianoInvestimentiAggregazioneImpresa";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", id_progetto));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_QUERY", cod_query));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", id_domanda_pagamento));
            db.InitDatareader(cmd);
            while (db.DataReader.Read()) investimenti.Add(SiarDAL.VpianoInvestimentiAggregazioneDettaglioDAL.GetFromDatareader(db));
            db.Close();
            return investimenti;
        }

        




    }
}