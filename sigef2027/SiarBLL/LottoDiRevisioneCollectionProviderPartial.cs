using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;
using System.Data;
using System.Data.SqlClient;

namespace SiarBLL
{
    public partial class LottoDiRevisioneCollectionProvider : ILottoDiRevisioneProvider
    {
        public int FiltroLottiRevisionePagamento(int idBando, int idProgetto, string codTipoPagamento)
        {
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpFiltroLottiRevisionePagamento";
            cmd.Parameters.Add(new SqlParameter("ID_BANDO", idBando));
            cmd.Parameters.Add(new SqlParameter("ID_PROGETTO", idProgetto));
            cmd.Parameters.Add(new SqlParameter("COD_TIPO_PAGAMENTO", codTipoPagamento));
            object result = DbProviderObj.ExecuteScalar(cmd);
            DbProviderObj.Close();
            if (result == null) return 0;
            int retval;
            int.TryParse(result.ToString(), out retval);
            return retval;
        }

        public int VerificaCompletamentoRevisione(int id_lotto)
        {
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT DBO.calcoloPercentualeCompletamentoRevisionePagamenti(@ID_LOTTO)";
            cmd.Parameters.Add(new SqlParameter("@ID_LOTTO", id_lotto));
            object result = DbProviderObj.ExecuteScalar(cmd);
            DbProviderObj.Close();
            int retval = 0;
            int.TryParse(result.ToString(), out retval);
            return retval;
        }

        public int EstraiCampioneDomandeXRevisionePagamenti(int id_lotto, string cf_utente)
        {
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpEstraiCampioneDomandeXRevisionePagamenti";
            cmd.Parameters.Add(new SqlParameter("@ID_LOTTO", id_lotto));
            cmd.Parameters.Add(new SqlParameter("@REVISORE", cf_utente));
            object result = DbProviderObj.ExecuteScalar(cmd);
            DbProviderObj.Close();
            int retval = 0;
            int.TryParse(result.ToString(), out retval);
            return retval;
        }

        public int SelezioneDomandeXLottoRevisione(int id_lotto, string cf_utente)
        {
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrRevisioneSelezioneDomandeXLotto";
            cmd.Parameters.Add(new SqlParameter("@ID_LOTTO", id_lotto));
            cmd.Parameters.Add(new SqlParameter("@REVISORE", cf_utente));
            object result = DbProviderObj.ExecuteScalar(cmd);
            DbProviderObj.Close();
            int retval = 0;
            int.TryParse(result.ToString(), out retval);
            return retval;
        }



        public void GetRevisioneRiepilogo(int id_bando, ref IntNT nr_pag_pervenute, ref IntNT nr_pag_istruite, ref IntNT nr_pag_validate, 
            ref IntNT nr_lotti, ref IntNT nr_lotti_campionati, ref IntNT nr_lotti_conclusi)
        {
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrRevisioneRiepilogo";
            cmd.Parameters.Add(new SqlParameter("@ID_BANDO", id_bando));
            DbProviderObj.InitDatareader(cmd);
            if (DbProviderObj.DataReader.Read())
            {
                nr_pag_pervenute = new IntNT(DbProviderObj.DataReader["NR_PAG_PERVENUTE"]);
                nr_pag_istruite = new IntNT(DbProviderObj.DataReader["NR_PAG_ISTRUITE"]);
                nr_pag_validate = new IntNT(DbProviderObj.DataReader["NR_PAG_VALIDATE"]);
                nr_lotti = new IntNT(DbProviderObj.DataReader["NR_LOTTI"]);
                nr_lotti_campionati = new IntNT(DbProviderObj.DataReader["NR_LOTTI_CAMPIONATI"]);
                nr_lotti_conclusi = new IntNT(DbProviderObj.DataReader["NR_LOTTI_CONCLUSI"]);
            }
            DbProviderObj.Close();
        }

        public void GetRevisioneRiepilogoRup(int id_utente_rup, IntNT id_bando, ref IntNT nr_pag_pervenute, ref IntNT nr_pag_istruite, ref IntNT nr_pag_validate,
            ref IntNT nr_lotti, ref IntNT nr_lotti_campionati, ref IntNT nr_lotti_conclusi)
        {
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrRevisioneRiepilogoRup";
            cmd.Parameters.Add(new SqlParameter("ID_UTENTE", id_utente_rup));
            cmd.Parameters.Add(new SqlParameter("ID_BANDO", id_bando));
            DbProviderObj.InitDatareader(cmd);
            if (DbProviderObj.DataReader.Read())
            {
                nr_pag_pervenute = new IntNT(DbProviderObj.DataReader["NR_PAG_PERVENUTE"]);
                nr_pag_istruite = new IntNT(DbProviderObj.DataReader["NR_PAG_ISTRUITE"]);
                nr_pag_validate = new IntNT(DbProviderObj.DataReader["NR_PAG_VALIDATE"]);
                nr_lotti = new IntNT(DbProviderObj.DataReader["NR_LOTTI"]);
                nr_lotti_campionati = new IntNT(DbProviderObj.DataReader["NR_LOTTI_CAMPIONATI"]);
                nr_lotti_conclusi = new IntNT(DbProviderObj.DataReader["NR_LOTTI_CONCLUSI"]);
            }
            DbProviderObj.Close();
        }
    }
}
