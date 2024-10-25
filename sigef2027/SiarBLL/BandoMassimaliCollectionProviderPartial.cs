using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class BandoMassimaliCollectionProvider : IBandoMassimaliProvider
    {
        public BandoMassimaliCollection GetMassimaliBando(int id_bando)
        {
            BandoMassimaliCollection cc = new BandoMassimaliCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetMassimaliBando";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", id_bando));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) cc.Add(SiarDAL.BandoMassimaliDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return cc;
        }

        public BandoMassimaliCollection GetMassimaliBandoInterventi(int id_bando)
        {
            BandoMassimaliCollection cc = new BandoMassimaliCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetMassimaliBandoInterventi";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", id_bando));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) cc.Add(SiarDAL.BandoMassimaliDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return cc;
        }
    }
}
