using SiarDAL;
using SiarLibrary;
using SiarLibrary.NullTypes;
using System;
using System.Data;

namespace SiarBLL
{
    public partial class RevocaCollectionProvider : IRevocaProvider
    {
        public RevocaCollection GetRevocheDaRecuperarePerProgetto(IntNT idProgetto)
        {
            var revCollection = new RevocaCollection();

            DbProvider db = DbProviderObj;
            IDbCommand cmd = db.GetCommand();
            Revoca rev;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetRevocheDaRecuperarePerProgetto";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("IdProgetto", idProgetto.Value));

            db.InitDatareader(cmd);
            while (db.DataReader.Read())
            {
                rev = RevocaDAL.GetFromDatareader(db);
                revCollection.Add(rev);
            }
            db.Close();

            return revCollection;
        }
    }
}
