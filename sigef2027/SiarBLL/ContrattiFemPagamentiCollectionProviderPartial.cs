using System.Linq;
using SiarLibrary;
using SiarLibrary.NullTypes;
using System;
using System.Data;
using System.Data.SqlClient;


namespace SiarBLL
{
    public partial class ContrattiFemPagamentiCollectionProvider : IContrattiFemPagamentiProvider
    {
        public decimal GetTotalePagamentiContratto(int? id_domanda, int id_contratto, int? id_pagamento)
        {
            decimal totale = 0;

            var pagamenti_list = this.Find(null, id_contratto, null, null, id_domanda)
                .ToArrayList<ContrattiFemPagamenti>();

            if(id_pagamento != null)
                totale = (from pag in pagamenti_list
                          where pag.IdContrattoFemPagamenti != id_pagamento
                          select pag).Sum(p => p.Importo);
            else
                totale = (from pag in pagamenti_list
                          select pag).Sum(p => p.Importo);

            return totale;
        }

        public  ContrattiFemPagamentiCollection GetPagamentiPerErogazione(bool confidi,int? IdErogazioneFem, int? IdProgetto)
        {
            ContrattiFemPagamentiCollection dd = new ContrattiFemPagamentiCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetContrattiFemPagamentiDaIstruire";
            cmd.Parameters.Add(new SqlParameter("@CONFIDI", confidi));
            cmd.Parameters.Add(new SqlParameter("@ID_EROGAZIONE_FEM", IdErogazioneFem));
            cmd.Parameters.Add(new SqlParameter("@ID_PROGETTO", IdProgetto));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) dd.Add(SiarDAL.ContrattiFemPagamentiDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return dd;
        }

        public ContrattiFemPagamentiCollection GetPagamentiPerErogazioneSoggettoGestore(int idSoggettoGestore, int idProgettoSoggettoGestore,  int? IdErogazioneFem)
        {
            ContrattiFemPagamentiCollection dd = new ContrattiFemPagamentiCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetContrattiFemPagamentiDaIstruireSoggettoGestore";
            cmd.Parameters.Add(new SqlParameter("@ID_SOGGETTO_GESTORE", idSoggettoGestore));
            cmd.Parameters.Add(new SqlParameter("@ID_PROGETTO_SOGGETTO_GESTORE", idProgettoSoggettoGestore));
            cmd.Parameters.Add(new SqlParameter("@ID_EROGAZIONE_FEM", IdErogazioneFem));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) dd.Add(SiarDAL.ContrattiFemPagamentiDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return dd;
        }
    }
}
