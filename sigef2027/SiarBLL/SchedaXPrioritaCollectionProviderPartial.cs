using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class SchedaXPrioritaCollectionProvider : ISchedaXPrioritaProvider
    {
        public SchedaXPrioritaCollection GetPrioritaBySchedaValutazione(IntNT Idschedavalutazione, string misura , string descrizione)
        {
            SchedaXPrioritaCollection retval = new SchedaXPrioritaCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetPrioritaBySchedaValutazione";
            if (Idschedavalutazione != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_SCHEDA_VALUTAZIONE", Idschedavalutazione.Value));
            if (!string.IsNullOrEmpty(misura)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("MISURA", misura));
            if (!string.IsNullOrEmpty(descrizione)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("DESCRIZIONE", descrizione));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                SchedaXPriorita p = SchedaXPrioritaDAL.GetFromDatareader(DbProviderObj);
                p.AdditionalAttributes.Add("ID_PRIORITA_SPECIALE", new IntNT(DbProviderObj.DataReader["ID_PRIORITA_SPECIALE"]));
                p.AdditionalAttributes.Add("IS_MAX_SPECIALE", new BoolNT(DbProviderObj.DataReader["IS_MAX_SPECIALE"]));
                retval.Add(p);
            }
            DbProviderObj.Close();
            return retval;
        }

        public SchedaXPrioritaCollection GetPrioritaXInvestimento(int id_scheda_valutazione, IntNT IdInvestimento)
        {
            SchedaXPrioritaCollection cc = new SchedaXPrioritaCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetPrioritaXInvestimento";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_SCHEDA_VALUTAZIONE", id_scheda_valutazione));
            if (IdInvestimento != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_INVESTIMENTO", IdInvestimento.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                SchedaXPriorita p = SchedaXPrioritaDAL.GetFromDatareader(DbProviderObj);
                p.AdditionalAttributes.Add("IdInvestimento", new IntNT(DbProviderObj.DataReader["ID_INVESTIMENTO"]));
                p.AdditionalAttributes.Add("IdValore", new IntNT(DbProviderObj.DataReader["ID_VALORE"]));
                p.AdditionalAttributes.Add("Scelto", new BoolNT(DbProviderObj.DataReader["SCELTO"]));
                p.AdditionalAttributes.Add("Valore", new DecimalNT(DbProviderObj.DataReader["VALORE"]));
                p.AdditionalAttributes.Add("ValData", new DatetimeNT(DbProviderObj.DataReader["VAL_DATA"]));
                p.AdditionalAttributes.Add("ValTesto", new StringNT(DbProviderObj.DataReader["VAL_TESTO"]));
                p.AdditionalAttributes.Add("PlurivaloreDescrizione", new StringNT(DbProviderObj.DataReader["PLURIVALORE_DESCRIZIONE"]));
                p.AdditionalAttributes.Add("PlurivalorePunteggio", new DecimalNT(DbProviderObj.DataReader["PLURIVALORE_PUNTEGGIO"]));
                cc.Add(p);
            }
            DbProviderObj.Close();
            return cc;
        }
        public SchedaXPrioritaCollection GetPrioritaXImpresa(int id_scheda_valutazione, IntNT IdImpresa, IntNT IdProgetto)
        {
            SchedaXPrioritaCollection cc = new SchedaXPrioritaCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetPrioritaXImpresa";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_SCHEDA_VALUTAZIONE", id_scheda_valutazione));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_IMPRESA", IdImpresa.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", IdProgetto.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                SchedaXPriorita p = SchedaXPrioritaDAL.GetFromDatareader(DbProviderObj);
                p.AdditionalAttributes.Add("IdImpresa", new IntNT(DbProviderObj.DataReader["ID_IMPRESA"]));
                p.AdditionalAttributes.Add("IdProgetto", new IntNT(DbProviderObj.DataReader["ID_PROGETTO"]));
                p.AdditionalAttributes.Add("IdValore", new IntNT(DbProviderObj.DataReader["ID_VALORE"]));
                p.AdditionalAttributes.Add("Scelto", new BoolNT(DbProviderObj.DataReader["SCELTO"]));
                p.AdditionalAttributes.Add("Valore", new DecimalNT(DbProviderObj.DataReader["VALORE"]));
                p.AdditionalAttributes.Add("ValData", new DatetimeNT(DbProviderObj.DataReader["VAL_DATA"]));
                p.AdditionalAttributes.Add("ValTesto", new StringNT(DbProviderObj.DataReader["VAL_TESTO"]));
                p.AdditionalAttributes.Add("PlurivaloreDescrizione", new StringNT(DbProviderObj.DataReader["PLURIVALORE_DESCRIZIONE"]));
                p.AdditionalAttributes.Add("PlurivalorePunteggio", new DecimalNT(DbProviderObj.DataReader["PLURIVALORE_PUNTEGGIO"]));
                cc.Add(p);
            }
            DbProviderObj.Close();
            return cc;
        }
    }
}
