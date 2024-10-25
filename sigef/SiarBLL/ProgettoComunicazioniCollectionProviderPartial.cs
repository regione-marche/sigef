using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class ProgettoComunicazioniCollectionProvider : IProgettoComunicazioniProvider
    {
        public string[] GetPecSuap(int id_comune)
        {
            string[] result = new string[2];
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetPecSuap";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_COMUNE", id_comune));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                result[0] = new StringNT(DbProviderObj.DataReader["SPORTELLO"]);
                result[1] = new StringNT(DbProviderObj.DataReader["PEC"]);
            }
            DbProviderObj.Close();
            return result;
        }

        public ProgettoSegnatureCollection GetComunicazioniNonAmmissibilita(int id_bando, string provincia, IntNT id_progetto)
        {
            ProgettoSegnatureCollection cc = new ProgettoSegnatureCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetComunicazioniNonAmmissibilitaBando";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", id_bando));
            if (!string.IsNullOrEmpty(provincia)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PROVINCIA", provincia));
            if (id_progetto != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", id_progetto.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                ProgettoSegnature c = new ProgettoSegnature();
                c.IdProgetto = new IntNT(DbProviderObj.DataReader["ID_PROGETTO"]);
                c.AdditionalAttributes.Add("STATO", new StringNT(DbProviderObj.DataReader["STATO"]));
                c.AdditionalAttributes.Add("PIVA", new StringNT(DbProviderObj.DataReader["PIVA"]));
                c.AdditionalAttributes.Add("RAGIONE_SOCIALE", new StringNT(DbProviderObj.DataReader["RAGIONE_SOCIALE"]));
                c.AdditionalAttributes.Add("SEDE", new StringNT(DbProviderObj.DataReader["SEDE"]));
                c.AdditionalAttributes.Add("ISTRUTTORE", new StringNT(DbProviderObj.DataReader["ISTRUTTORE"]));
                c.AdditionalAttributes.Add("PROVINCIA", new StringNT(DbProviderObj.DataReader["PROVINCIA"]));
                c.AdditionalAttributes.Add("NAP_SEGNATURA", new StringNT(DbProviderObj.DataReader["NAP_SEGNATURA"]));
                c.AdditionalAttributes.Add("NAD_SEGNATURA", new StringNT(DbProviderObj.DataReader["NAD_SEGNATURA"]));
                c.AdditionalAttributes.Add("ID_ATTO", new StringNT(DbProviderObj.DataReader["ID_ATTO"]));
                c.AdditionalAttributes.Add("ATTO", new StringNT(DbProviderObj.DataReader["ATTO"]));
                cc.Add(c);
            }
            DbProviderObj.Close();
            return cc;
        }
    }
}
