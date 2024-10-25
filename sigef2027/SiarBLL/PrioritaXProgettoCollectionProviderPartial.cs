using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class PrioritaXProgettoCollectionProvider : IPrioritaXProgettoProvider
    {
        public PrioritaXProgettoCollection GetPrioritaDisposizioniAttuative(IntNT id_disposizione_attuativa, StringNT cod_livello, IntNT id_progetto)
        {
            PrioritaXProgettoCollection priorita = new PrioritaXProgettoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetPrioritaDisposizioniAttuative";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", id_disposizione_attuativa.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LIVELLO", cod_livello.Value));
            if (id_progetto != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", id_progetto.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) priorita.Add(SiarDAL.PrioritaXProgettoDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return priorita;
        }

        // : metodo aggiunto
        public PrioritaXProgettoCollection GetPrioritaConAiutoAddizionale(IntNT id_progetto)
        {
            PrioritaXProgettoCollection priorita = new PrioritaXProgettoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetPrioritaConAiutoAddizionale";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", id_progetto.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) priorita.Add(SiarDAL.PrioritaXProgettoDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return priorita;
        }
    }
}
