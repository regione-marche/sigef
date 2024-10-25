using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class RevisioneDpagamentoEsitoCollectionProvider : IRevisioneDpagamentoEsitoProvider
    {
        private string sqlSelect()
        {
            string sSql;

            sSql = @"SELECT rdp.ID,
                            rdp.ID_LOTTO,
                            rdp.ID_DOMANDA_PAGAMENTO,
                            rdp.ID_VLD_STEP,
                            rdp.COD_ESITO,
                            rdp.DATA,
                            rdp.OPERATORE,
                            rdp.NOTE,
                            rdp.ESCLUDI_DA_COMUNICAZIONE,
                            s.DESCRIZIONE,
                            s.AUTOMATICO,
                            e.ESITO_POSITIVO,
                            cls.Ordine ";
            return sSql;
        }

        private string sqlFrom()
        {
            string sSql;

            sSql = @" FROM Revisione_DPagamento_Esito rdp
                          INNER JOIN
                          Vld_Step s ON rdp.Id_Vld_Step = s.Id
                          LEFT JOIN
                          Esiti_Step e ON rdp.Cod_Esito = e.Cod_Esito
                          LEFT JOIN
                          Vld_Check_List_Step cls ON rdp.Id_Vld_Step = cls.Id_Vld_Step
                            INNER JOIN
                            Vld_Check_List cl ON cls.Id_Vld_Check_list = cl.Id ";
            return sSql;
        }

        public RevisioneDpagamentoEsitoCollection getAll()
        {
            SiarLibrary.RevisioneDpagamentoEsito rec = null;
            SiarLibrary.RevisioneDpagamentoEsitoCollection recs = new RevisioneDpagamentoEsitoCollection();

            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlSelect() + sqlFrom();
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                rec = (SiarDAL.RevisioneDpagamentoEsitoDAL.GetFromDatareader(dbPro));
                recs.Add(rec);
            }
            dbPro.Close();

            return recs;
        }

        public RevisioneDpagamentoEsitoCollection getBy_Id_LottoDomanda(int id_Lotto, int id_Domanda_Pagamento, string codTipo, string tpAppalto)
        {
            string sqlWhere;
            string sqlOrder;
            SiarLibrary.RevisioneDpagamentoEsito rec = null;
            SiarLibrary.RevisioneDpagamentoEsitoCollection recs = new RevisioneDpagamentoEsitoCollection();

            sqlWhere = @" WHERE rdp.ID_LOTTO = @id_Lotto 
                            AND rdp.ID_DOMANDA_PAGAMENTO = @id_Domanda_Pagamento
                            AND cl.Cod_Tipo_DPagamento = @codTipo
                            AND cl.TpAppalto = @tpAppalto";
            sqlOrder = @" ORDER BY cls.Ordine ";

            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlSelect() + sqlFrom() + sqlWhere + sqlOrder;
            cmd.Parameters.Add(new SqlParameter("@id_Lotto", id_Lotto));
            cmd.Parameters.Add(new SqlParameter("@id_Domanda_Pagamento", id_Domanda_Pagamento));
            cmd.Parameters.Add(new SqlParameter("@codTipo", codTipo));
            cmd.Parameters.Add(new SqlParameter("@tpAppalto", tpAppalto));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                rec = (SiarDAL.RevisioneDpagamentoEsitoDAL.GetFromDatareader(dbPro));
                recs.Add(rec);
            }
            dbPro.Close();

            return recs;
        }
    }
}
