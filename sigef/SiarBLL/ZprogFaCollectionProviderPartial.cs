using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class ZprogFaCollectionProvider : IZprogFaProvider
    {
        public ZprogFaCollection GetDotazioneFinanziariaFA(string cod_fa)
        {
            ZprogFaCollection cc = new ZprogFaCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetDotazioneFinanziariaFA";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_FA", cod_fa));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())            
                cc.Add(SiarDAL.ZprogFaDAL.GetFromDatareader(DbProviderObj));            
            DbProviderObj.Close();
            return cc;
        }
    }
}
