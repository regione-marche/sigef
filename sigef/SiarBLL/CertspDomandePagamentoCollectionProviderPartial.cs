using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class CertspDomandePagamentoCollectionProvider : ICertspDomandePagamentoProvider
    {
        public CertspDomandePagamentoCollection CreaElencoDomandeXControlliLoco(IntNT idLotto)
        {
            CertspDomandePagamentoCollection domande_selezionate = new CertspDomandePagamentoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpCertspCreaElencoDomandeXControlliLoco";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_LOTTO", idLotto.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
                domande_selezionate.Add(SiarDAL.CertspDomandePagamentoDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return domande_selezionate;
        }

        public int EstraiCampioneDomandeXControlliLoco(IntNT idLotto, IntNT id_operatore, bool estrazione_aggiuntiva)
        {
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpCertspEstraiCampioneDomandeXControlliLoco";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_LOTTO", idLotto.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("OPERATORE", id_operatore));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("CAMPIONE_AGGIUNTIVO", estrazione_aggiuntiva));
            //cmd..Add(new System.Data.SqlClient.SqlParameter("CAMPIONE_AGGIUNTIVO", estrazione_aggiuntiva));
            System.Data.SqlClient.SqlParameter param_out = new System.Data.SqlClient.SqlParameter("RETURN_VALUE", System.Data.SqlDbType.Int);
            param_out.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(param_out);
            DbProviderObj.ExecuteScalar(cmd);
            DbProviderObj.Close();
            if (param_out.Value == null) return -1;
            return (int)param_out.Value;
        }
    }
}
