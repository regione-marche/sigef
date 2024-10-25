using SiarDAL;
using SiarLibrary;
using SiarLibrary.NullTypes;
using System.Data;

namespace SiarBLL
{
    public partial class ErroreCollectionProvider : IErroreProvider
    {
        public ErroreCollection GetErroriDaRecuperarePerProgetto(IntNT idProgetto)
        {
            var errCollection = new ErroreCollection();

            DbProvider db = DbProviderObj;
            IDbCommand cmd = db.GetCommand();
            Errore err;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetErroriDaRecuperarePerProgetto";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("IdProgetto", idProgetto.Value));

            db.InitDatareader(cmd);
            while (db.DataReader.Read())
            {
                err = ErroreDAL.GetFromDatareader(db);
                errCollection.Add(err);
            }
            db.Close();

            return errCollection;
        }
    }
}
