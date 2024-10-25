using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;
using System.Data;

namespace SiarBLL
{
    public partial class LogAccessiCollectionProvider : ILogAccessiProvider
    {
        public int GetUtentiConnessi(string istanza)
        {
            int utenti = 0;

            DbProvider db = DbProviderObj;
            IDbCommand cmd = db.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetUtentiConnessi";

            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Istanza", istanza));

            object result = db.ExecuteScalar(cmd);
            db.Close();

            if (result == null || !int.TryParse(result.ToString(), out utenti)) 
                utenti = -1; //errore generico

            return utenti;
        }

        public LogAccessiCollection GetLoginAppesiUtente(string istanza, IntNT id_utente)
        {
            LogAccessiCollection accessiCollection = new LogAccessiCollection();
            LogAccessi accesso;

            DbProvider db = DbProviderObj;
            IDbCommand cmd = db.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetLoginAppesiUtente";

            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Istanza", istanza));
            if (id_utente != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IdUtente", id_utente.Value));

            db.InitDatareader(cmd);
            while (db.DataReader.Read())
            {
                accesso = LogAccessiDAL.GetFromDatareader(db);
                accessiCollection.Add(accesso);
            }

            db.Close();

            return accessiCollection;
        }

        public int RiempiDataLogout(string istanza, IntNT id_utente)
        {
            int modifiche = 0;

            DbProvider db = DbProviderObj;
            IDbCommand cmd = db.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpRiempiDataLogout";

            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Istanza", istanza));
            if (id_utente != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IdUtente", id_utente.Value));

            object result = db.ExecuteScalar(cmd);
            db.Close();
            
            if (result == null || !int.TryParse(result.ToString(), out modifiche))
                modifiche = -1; //errore generico

            return modifiche;
        }
    }
}
