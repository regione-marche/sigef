using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class AggregazioneCollectionProvider : IAggregazioneProvider
    {
        public bool VerificaAggregazione(IntNT id_progetto)
        {
            bool result = false;
            try
            {
                System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SpVerificaFidejussioneAggregazione";
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IdProgetto", id_progetto.Value));
                DbProviderObj.InitDatareader(cmd);
                if (DbProviderObj.DataReader.Read())
                {
                    result = new BoolNT(DbProviderObj.DataReader["RESULT"]);
                }
                DbProviderObj.Close();
            }
            catch { throw; }
            return result;
        }

        public SiarLibrary.ImpresaCollection GetElencoImpreseAggregazione(IntNT id_progetto)
        {
            SiarLibrary.ImpresaCollection impresa_coll = new SiarLibrary.ImpresaCollection();

            try
            {
                System.Data.IDbCommand cmd = DbProviderObj.GetCommand();

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SpGetImpresaAggregazione";
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IdProgetto", id_progetto.Value));
                DbProviderObj.InitDatareader(cmd);
                while (DbProviderObj.DataReader.Read())
                {
                    SiarLibrary.Impresa i = SiarDAL.ImpresaDAL.GetFromDatareader(DbProviderObj);
                    //i.AdditionalAttributes.Add("NOMINATIVO", new StringNT(DbProviderObj.DataReader["NOMINATIVO"]));
                    impresa_coll.Add(i);
                }
                DbProviderObj.Close();
            }
            catch { throw; }
            return impresa_coll;
        }
    }
}
