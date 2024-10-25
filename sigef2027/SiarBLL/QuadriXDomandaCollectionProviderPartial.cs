using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;
using System.Data;
using System.Data.SqlClient;

namespace SiarBLL
{
    public partial class QuadriXDomandaCollectionProvider : IQuadriXDomandaProvider
    {
        public QuadriXDomandaCollection GetQuadriModelloDomanda(int id_modello_domanda)
        {
            QuadriXDomandaCollection qq = new QuadriXDomandaCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetQuadriModelloDomanda";
            cmd.Parameters.Add(new SqlParameter("@ID_MODELLO_DOMANDA", id_modello_domanda));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) qq.Add(SiarDAL.QuadriXDomandaDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return qq;
        }
    }
}
