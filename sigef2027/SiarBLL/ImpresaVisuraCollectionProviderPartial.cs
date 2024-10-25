using SiarLibrary;
using SiarLibrary.NullTypes;
using System;

namespace SiarBLL
{
    public partial class ImpresaVisuraCollectionProvider : IImpresaVisuraProvider
    {
        public ImpresaVisura GetUltimaVisuraImpresa(IntNT IdimpresaEqualThis)
        {
            ImpresaVisura iv = new ImpresaVisura();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetUltimaVisuraImpresa";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IdImpresa", IdimpresaEqualThis.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
                iv = SiarDAL.ImpresaVisuraDAL.GetFromDatareader(DbProviderObj);
            DbProviderObj.Close();

            return iv;
        }
    }
}
