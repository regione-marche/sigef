using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;
using System.Data;
using System.Data.SqlClient;

namespace SiarBLL
{
    public partial class DichiarazioniXDomandaCollectionProvider : IDichiarazioniXDomandaProvider
    {
        public DichiarazioniXDomandaCollection GetDichiarazioniModelloDomanda(int id_modello_domanda, string misura, string descrizione)
        {
            DichiarazioniXDomandaCollection dd = new DichiarazioniXDomandaCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetDichiarazioniModelloDomanda";
            cmd.Parameters.Add(new SqlParameter("@ID_MODELLO_DOMANDA", id_modello_domanda));
            if (!string.IsNullOrEmpty(misura)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MISURA", misura));
            if (!string.IsNullOrEmpty(descrizione)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DESCRIZIONE", descrizione));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) dd.Add(SiarDAL.DichiarazioniXDomandaDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return dd;
        }
    }
}
