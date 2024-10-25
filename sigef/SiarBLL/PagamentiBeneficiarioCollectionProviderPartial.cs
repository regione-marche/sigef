using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class PagamentiBeneficiarioCollectionProvider : IPagamentiBeneficiarioProvider
    {
        

        public PagamentiBeneficiarioCollection GetPagamentiDomandeDiPagamento(int idInvestimento, string numeroGiu)
        {
            PagamentiBeneficiarioCollection pagamenti = new PagamentiBeneficiarioCollection();
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetPagamentiBenificiarioDomandePagamento";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_INVESTIMENTO", idInvestimento));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("NUMERO", numeroGiu));
            db.InitDatareader(cmd);
            while (db.DataReader.Read())
            {
                SiarLibrary.PagamentiBeneficiario i = SiarDAL.PagamentiBeneficiarioDAL.GetFromDatareader(db);
                i.AdditionalAttributes.Add("IdDomandaPagamento", db.DataReader["ID_DOMANDA_PAGAMENTO"].ToString());
                i.AdditionalAttributes.Add("CodTipo", db.DataReader["COD_TIPO"].ToString());
                pagamenti.Add(i);
            }
            db.Close();
            return pagamenti;
        }

    }
}
