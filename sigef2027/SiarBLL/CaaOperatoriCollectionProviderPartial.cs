using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class CaaOperatoriCollectionProvider : ICaaOperatoriProvider
    {
        public CaaOperatoriCollection GetStatisticheSportelloCaa(string codice_sportello, string sezione/* PSR, UMA, BIO */, bool statistica_regionale)
        {
            CaaOperatoriCollection operatori = new CaaOperatoriCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CODICE_SPORTELLO", codice_sportello.Trim()));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@STATISTICA_REGIONALE", statistica_regionale));
            switch (sezione)
            {
                case "PSR":
                    cmd.CommandText = "SpCaaSportelloStatistichePsr";
                    break;
                case "UMA":
                    cmd.CommandText = "SpCaaSportelloStatisticheUma";
                    break;
                case "BIO":
                    cmd.CommandText = "SpCaaSportelloStatisticheBio";
                    break;
            }

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                CaaOperatori o = new CaaOperatori();
                o.Id = new IntNT(DbProviderObj.DataReader["ID"]);
                o.Nominativo = new StringNT(DbProviderObj.DataReader["NOMINATIVO"]);
                o.CodStato = new StringNT(DbProviderObj.DataReader["COD_STATO"]);
                o.Responsabile = new BoolNT(DbProviderObj.DataReader["RESPONSABILE"]);
                o.AdditionalAttributes.Add("PROV1", new IntNT(DbProviderObj.DataReader["PROV1"]));
                o.AdditionalAttributes.Add("DEF1", new IntNT(DbProviderObj.DataReader["DEF1"]));
                o.AdditionalAttributes.Add("PROV2", new IntNT(DbProviderObj.DataReader["PROV2"]));
                o.AdditionalAttributes.Add("DEF2", new IntNT(DbProviderObj.DataReader["DEF2"]));
                o.AdditionalAttributes.Add("PROV3", new IntNT(DbProviderObj.DataReader["PROV3"]));
                o.AdditionalAttributes.Add("DEF3", new IntNT(DbProviderObj.DataReader["DEF3"]));
                operatori.Add(o);
            }
            DbProviderObj.Close();
            return operatori;
        }

        public CaaOperatoriCollection GetPraticheInCaricoSportelloCaa(string codice_sportello, string sezione /* PSR, UMA, BIO */,
            IntNT id_pratica, IntNT anno, StringNT cuaa, StringNT ragione_sociale, StringNT cod_stato, IntNT id_operatore, bool statistica_regionale)
        {
            CaaOperatoriCollection operatori = new CaaOperatoriCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            switch (sezione)
            {
                case "PSR":
                    cmd.CommandText = "SpCaaSportelloPraticheInCaricoPsr";
                    break;
                case "UMA":
                    cmd.CommandText = "SpCaaSportelloPraticheInCaricoUma";
                    break;
                case "BIO":
                    cmd.CommandText = "SpCaaSportelloPraticheInCaricoBio";
                    break;
            }
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CODICE_SPORTELLO", codice_sportello));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@STATISTICA_REGIONALE", statistica_regionale));
            if (id_pratica != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PRATICA", id_pratica.Value));
            if (anno != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ANNO", anno.Value));
            if (cuaa != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CUAA", cuaa.Value));
            if (ragione_sociale != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RAGIONE_SOCIALE", ragione_sociale.Value));
            if (cod_stato != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_STATO", cod_stato.Value));
            if (id_operatore != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_UTENTE", id_operatore.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                CaaOperatori o = new CaaOperatori();
                o.IdUtente = new IntNT(DbProviderObj.DataReader["ID_UTENTE"]);
                o.Nominativo = new StringNT(DbProviderObj.DataReader["NOMINATIVO"]);
                // CAMPI CUSTOM
                o.AdditionalAttributes.Add("ID_PRATICA", new IntNT(DbProviderObj.DataReader["ID_PRATICA"]));
                o.AdditionalAttributes.Add("ID_VISIBILE", new IntNT(DbProviderObj.DataReader["ID_VISIBILE"]));
                o.AdditionalAttributes.Add("DATA_ULTIMA_MODIFICA", new DatetimeNT(DbProviderObj.DataReader["DATA_ULTIMA_MODIFICA"]));
                o.AdditionalAttributes.Add("ANNO", new IntNT(DbProviderObj.DataReader["ANNO"]));
                o.AdditionalAttributes.Add("COD_TIPO_PRATICA", new StringNT(DbProviderObj.DataReader["COD_TIPO_PRATICA"]));
                o.AdditionalAttributes.Add("TIPO_PRATICA", new StringNT(DbProviderObj.DataReader["TIPO_PRATICA"]));
                o.AdditionalAttributes.Add("COD_STATO", new StringNT(DbProviderObj.DataReader["COD_STATO"]));
                o.AdditionalAttributes.Add("STATO", new StringNT(DbProviderObj.DataReader["STATO"]));
                o.AdditionalAttributes.Add("ID_IMPRESA", new IntNT(DbProviderObj.DataReader["ID_IMPRESA"]));
                o.AdditionalAttributes.Add("CUAA", new StringNT(DbProviderObj.DataReader["CUAA"]));
                o.AdditionalAttributes.Add("CODICE_FISCALE", new StringNT(DbProviderObj.DataReader["CODICE_FISCALE"]));
                o.AdditionalAttributes.Add("RAGIONE_SOCIALE", new StringNT(DbProviderObj.DataReader["RAGIONE_SOCIALE"]));
                operatori.Add(o);
            }
            DbProviderObj.Close();
            return operatori;
        }

        public CaaOperatoriCollection GetOperatoriAutorizzazione(int id_autorizzazione)
        {
            CaaOperatoriCollection operatori = new CaaOperatoriCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpCaaGetOperatoriAutorizzazione";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_AUTORIZZAZIONE", id_autorizzazione));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                CaaOperatori o = SiarDAL.CaaOperatoriDAL.GetFromDatareader(DbProviderObj);
                // campo custom: sovrascrivo il campo perche' non mi serve e per facilitare l'utilizzo sulla pagina
                o.IdStoricoUltimo = new IntNT(DbProviderObj.DataReader["ID_STORICO_TEMP"]);
                operatori.Add(o);
            }
            DbProviderObj.Close();
            return operatori;
        }
    }
}
