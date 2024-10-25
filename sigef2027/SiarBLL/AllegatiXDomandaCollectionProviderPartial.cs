using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;
using System.Data;
using System.Data.SqlClient;

namespace SiarBLL
{
    public partial class AllegatiXDomandaCollectionProvider : IAllegatiXDomandaProvider
    {
        public AllegatiXDomandaCollection GetAllegatiModelloDomanda(int id_modello_domanda, string misura)
        {
            AllegatiXDomandaCollection dd = new AllegatiXDomandaCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetAllegatiModelloDomanda";
            cmd.Parameters.Add(new SqlParameter("@ID_MODELLO_DOMANDA", id_modello_domanda));
            if (misura != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MISURA", misura));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) dd.Add(SiarDAL.AllegatiXDomandaDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return dd;
        }
    }
}
