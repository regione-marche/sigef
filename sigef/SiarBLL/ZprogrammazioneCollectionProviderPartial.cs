using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class ZprogrammazioneCollectionProvider : IZprogrammazioneProvider
    {
        public ZprogrammazioneCollection GetProgrammazionePsr(string cod_psr, IntNT id_padre, BoolNT attivazione_bandi,
            BoolNT attivazione_fa, BoolNT attivazione_ob_misura, BoolNT attivazione_investimenti, BoolNT attivazione_ff)
        {
            ZprogrammazioneCollection programmazione = new ZprogrammazioneCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetProgrammazione";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_PSR", cod_psr));
            if (id_padre != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PADRE", id_padre.Value));
            if (attivazione_bandi != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ATTIVAZIONE_BANDI", attivazione_bandi.Value));
            if (attivazione_fa != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ATTIVAZIONE_FA", attivazione_fa.Value));
            if (attivazione_ob_misura != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ATTIVAZIONE_OB_MISURA", attivazione_ob_misura.Value));
            if (attivazione_investimenti != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ATTIVAZIONE_INVESTIMENTI", attivazione_investimenti.Value));
            if (attivazione_ff != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ATTIVAZIONE_FF", attivazione_ff.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                SiarLibrary.Zprogrammazione pr = SiarDAL.ZprogrammazioneDAL.GetFromDatareader(DbProviderObj);
                pr.AdditionalAttributes.Add("PathLabel", new StringNT(DbProviderObj.DataReader["PathLabel"]));
                programmazione.Add(pr);
            }
            DbProviderObj.Close();
            return programmazione;
        }

        public int GetCountProgrammazioneBando(int id_programmazione)
        {
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select count(*) as num_bando from zPROGRAMMAZIONE inner join BANDO_PROGRAMMAZIONE ON zPROGRAMMAZIONE.ID = BANDO_PROGRAMMAZIONE.ID_PROGRAMMAZIONE"
                            + " WHERE BANDO_PROGRAMMAZIONE.ID_PROGRAMMAZIONE = " + id_programmazione;

            DbProviderObj.InitDatareader(cmd);
            DbProviderObj.DataReader.Read();
            int count = Convert.ToInt16(DbProviderObj.DataReader["num_bando"]);
            DbProviderObj.Close();
            return count;
        }

        public Boolean isPorFesr(int id_programmazione)
        {
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select count(*) as num_prog from zPROGRAMMAZIONE"
                            + " WHERE zPROGRAMMAZIONE.COD_TIPO like '%POR20142020%' AND zPROGRAMMAZIONE.ID = " + id_programmazione;

            DbProviderObj.InitDatareader(cmd);
            DbProviderObj.DataReader.Read();
            int count = Convert.ToInt16(DbProviderObj.DataReader["num_prog"]);
            DbProviderObj.Close();
            if (count > 0)
                return true;
            else
                return false;
        }
    }
}
