using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;
using System.Data;
using System.Data.SqlClient;

namespace SiarBLL
{
    public partial class ZprogrammazioneFontiCollectionProvider : IZprogrammazioneFontiProvider
    {
        public ZprogrammazioneFontiCollection GetProgrammazioneFonti(int id_programmazione)
        {
            ZprogrammazioneFontiCollection pf = new ZprogrammazioneFontiCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetProgrammazioneFonti";
            cmd.Parameters.Add(new SqlParameter("@ID_PROG", id_programmazione));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                pf.Add(SiarDAL.ZprogrammazioneFontiDAL.GetFromDatareader(DbProviderObj));
            }
            DbProviderObj.Close();
            return pf;
        }


    }
}
