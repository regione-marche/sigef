using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
	public partial class TipoPistaControlloCollectionProvider : ITipoPistaControlloProvider
	{
		public TipoPistaControlloCollection GetTipoPistaControlloPadre(IntNT IdProgetto)
		{
			SiarLibrary.TipoPistaControlloCollection coll = new TipoPistaControlloCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetTipoPistaControlloPadre";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", IdProgetto.Value));            
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                TipoPistaControllo t = TipoPistaControlloDAL.GetFromDatareader(DbProviderObj);
                coll.Add(t);
            }
            DbProviderObj.Close();
            return coll;
		}

        public TipoPistaControlloCollection GetTipoPistaControlloFiglio(IntNT IdProgetto, IntNT IdPadre)
        {
            SiarLibrary.TipoPistaControlloCollection coll = new TipoPistaControlloCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetTipoPistaControlloFiglio";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", IdProgetto.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PADRE", IdPadre.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                TipoPistaControllo t = TipoPistaControlloDAL.GetFromDatareader(DbProviderObj);
                coll.Add(t);
            }
            DbProviderObj.Close();
            return coll;
        }

    }
}