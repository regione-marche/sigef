using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class BusinessPlanCollectionProvider : IBusinessPlanProvider
    {
        public BusinessPlanCollection GetBusinessPlanBando(int id_bando)
        {
            BusinessPlanCollection cc = new BusinessPlanCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetBusinessPlanBando";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", id_bando));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) cc.Add(SiarDAL.BusinessPlanDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return cc;
        }
    }
}
