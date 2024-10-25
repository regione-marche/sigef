using SiarLibrary;
using SiarDAL;
using SiarLibrary.NullTypes;

namespace SiarBLL
{
    public partial class ScaricamentoFirmaEsternaCollectionProvider : IScaricamentoFirmaEsternaProvider
    {
        public ScaricamentoFirmaEsterna GetUltimoScaricamentoFile(IntNT idProgetto, IntNT idDomandaPagamento, IntNT idVariante)
        {
            ScaricamentoFirmaEsterna scaricamento = null;
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetUltimoScaricamentoFile";
            if (idProgetto != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", idProgetto.Value));
            if (idDomandaPagamento != null) 
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_DOMANDA_PAGAMENTO", idDomandaPagamento.Value));
            if (idVariante != null) 
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_VARIANTE", idVariante.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                scaricamento = ScaricamentoFirmaEsternaDAL.GetFromDatareader(DbProviderObj);
            }
            DbProviderObj.Close();
            return scaricamento;
        }
    }
}
