using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

    public partial class ValoriPrioritaCollectionProvider : IValoriPrioritaProvider
    {
        public ValoriPrioritaCollection GetValoriPrioritaSql(int IdProgetto, bool FaseIstruttoria, int IdRequisito, StringNT Codice)
        {
            ValoriPrioritaCollection vpc = new ValoriPrioritaCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpZoomPrioritaPlurivaloreSql";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", IdProgetto));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FASE_ISTRUTTORIA", FaseIstruttoria));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_REQUISITO", IdRequisito));
            if (Codice != null)cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CODICE", Codice.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                ValoriPriorita vp = new ValoriPriorita();             
                vp.Codice = new StringNT(DbProviderObj.DataReader["Codice"]);
                vp.Descrizione = new StringNT(DbProviderObj.DataReader["Descrizione"]);
                vp.IdPriorita = IdRequisito ;
                vpc.Add(vp);
            }
            DbProviderObj.Close();
            return vpc;
        }
    }
}