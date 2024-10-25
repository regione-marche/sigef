using System.Linq;
using SiarLibrary;
using SiarLibrary.NullTypes;

namespace SiarBLL
{
    public partial class ContrattiFemCollectionProvider : IContrattiFemProvider
    {
        public decimal GetTotaleContrattiProgetto(int id_progetto, int? id_contratto)
        {
            decimal totale = 0;

            var contratti_list = this.Find(null, id_progetto, null, null, null, null, null)
                .ToArrayList<ContrattiFem>();

            if (id_contratto != null)
                totale = (from con in contratti_list
                          where con.IdContrattoFem != id_contratto
                          select con).Sum(c => c.Importo);
            else
                totale = (from con in contratti_list
                          select con).Sum(c => c.Importo);

            return totale;
        }

        public decimal GetTotaleContrattiDomandaPagamento(int id_progetto, int id_domanda, int? id_contratto)
        {
            decimal totale = 0;

            var contratti_list = this.Find(null, id_progetto, null, id_domanda, null, null, null)
                .ToArrayList<ContrattiFem>();

            if (id_contratto != null)
                totale = (from con in contratti_list
                          where con.IdContrattoFem != id_contratto
                          select con).Sum(c => c.Importo);
            else
                totale = (from con in contratti_list
                          select con).Sum(c => c.Importo);

            return totale;
        }

        public ContrattiFemCollection GetContrattiDomandaPagamento(IntNT id_domanda, StringNT segnatura, DatetimeNT data_stipula)
        {
            ContrattiFemCollection contratti = new ContrattiFemCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetContrattiDomandaPagamento"; 

            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_DOMANDA_PAGAMENTO", id_domanda.Value));
            if (segnatura != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SEGNATURA", segnatura.Value));
            if (data_stipula != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DATA_STIPULA", data_stipula.Value));

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
                contratti.Add(SiarDAL.ContrattiFemDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();

            return contratti;
        }

        public ContrattiFemCollection GetContrattiConfidiVela(IntNT id_progetto)
        {
            ContrattiFemCollection contratti = new ContrattiFemCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetContrattiConfidiVela";

            if (id_progetto != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", id_progetto.Value));

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
                contratti.Add(SiarDAL.ContrattiFemDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();

            return contratti;
        }

        //Con questo metodo è possibile estrarre i contratti di tutti i soggetti gestori tranne di Artigiancassa e Confidi
        public ContrattiFemCollection GetContrattiAltriSoggetti(IntNT id_soggetto, IntNT id_progetto)
        {
            ContrattiFemCollection contratti = new ContrattiFemCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetContrattiAltriSoggetti";

            if (id_soggetto != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_SOGGETTO_GESTORE", id_soggetto.Value));
            if (id_progetto != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", id_progetto.Value));

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
                contratti.Add(SiarDAL.ContrattiFemDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();

            return contratti;
        }

        //Con questo metodo è possibile estrarre i contratti di tutti i soggetti gestori tranne di Artigiancassa
        //e dei progetti di Confidi in base al parametro
        //@BANDI_VELA = NULL -> TUTTI I RECORD
        //@BANDI_VELA = 0 -> NON ESTRAE CONTRATTI DEI PROGETTI BANDI VELA
        //@BANDI_VELA = 1 -> ESTRAE CONTRATTI DEI PROGETTI BANDI VELA
        public ContrattiFemCollection GetContrattiAltriSoggettiFondoLeggeCovid(IntNT id_soggetto, IntNT id_progetto, bool? bandi_Vela)
        {
            ContrattiFemCollection contratti = new ContrattiFemCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetContrattiAltriSoggettiFondoLeggeCovid";

            if (id_soggetto != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_SOGGETTO_GESTORE", id_soggetto.Value));
            if (id_progetto != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", id_progetto.Value));
            if (bandi_Vela != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BANDI_VELA", bandi_Vela.Value));

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
                contratti.Add(SiarDAL.ContrattiFemDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();

            return contratti;
        }
    }
}
