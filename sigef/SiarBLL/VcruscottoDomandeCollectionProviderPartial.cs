using SiarLibrary;
using SiarLibrary.NullTypes;
using System;

namespace SiarBLL
{
    public partial class VcruscottoDomandeCollectionProvider
    {
        public VcruscottoDomandeCollection FindDomandeIstruttore(int id_utente, string cod_stato_progetto, int? IdDomandaPagamento, int? idProgetto)
        {
            VcruscottoDomandeCollection cruscotto_domande = new VcruscottoDomandeCollection();

            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpCruscottoGetDomandeFirma";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("IdUtente", id_utente));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("CodStatoProgetto", cod_stato_progetto));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("CodIdDomandaPagamento", IdDomandaPagamento));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("CodIdProgetto", idProgetto));

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                VcruscottoDomande f = SiarDAL.VcruscottoDomandeDAL.GetFromDatareader(DbProviderObj);
                cruscotto_domande.Add(f);
            }

            DbProviderObj.Close();
            return cruscotto_domande;
        }
    }
}
