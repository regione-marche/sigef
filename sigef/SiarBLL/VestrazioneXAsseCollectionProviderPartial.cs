using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class VestrazioneXAsseCollectionProvider
    {
        public VestrazioneXAsseCollection GetEstrazioneXasse(int id_Asse, string ente)
        {
            VestrazioneXAsseCollection estrazione = new VestrazioneXAsseCollection();
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetEstrazioneXasse";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_ASSE", id_Asse));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ENTE", ente));
            db.InitDatareader(cmd);
            while (db.DataReader.Read()) estrazione.Add(SiarDAL.VestrazioneXAsseDAL.GetFromDatareader(db));
            db.Close();
            return estrazione;
        }
    }
}
