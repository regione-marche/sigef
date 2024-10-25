using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class FunzionalitaCollectionProvider : IFunzionalitaProvider
    {
        public FunzionalitaCollection GetMenuOperatore(int id_profilo)
        {
            FunzionalitaCollection ff = new FunzionalitaCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetMenuOperatore";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROFILO", id_profilo));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                Funzionalita f = SiarDAL.FunzionalitaDAL.GetFromDatareader(DbProviderObj);
                f.AdditionalAttributes.Add("Aperto", new BoolNT(DbProviderObj.DataReader["APERTO"]));
                ff.Add(f);
            }
            DbProviderObj.Close();
            return ff;
        }
    }
}
