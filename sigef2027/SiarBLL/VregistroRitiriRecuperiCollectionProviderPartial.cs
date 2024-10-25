using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;
using System.Data;
using System.Data.SqlClient;

namespace SiarBLL
{
    public partial class VregistroRitiriRecuperiCollectionProvider
    {
        public bool getRigaPeriodoContabile( string ID_AZIONE, int? ID_PROGETTO, string TIPO, string TIPO_ORIGINE ,string SOGGETTO_RILEVATORE ,string TIPO_DETRAZIONE , string PERIODO_CONTABILE_RIGA)
        {
            bool pari = false;

            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetRigaPeriodoContabile";
            if (!string.IsNullOrEmpty(ID_AZIONE)) 
                cmd.Parameters.Add(new SqlParameter("@ID_AZIONE", Convert.ToInt32(ID_AZIONE)));
            if (ID_PROGETTO != null) 
                cmd.Parameters.Add(new SqlParameter("@ID_PROGETTO", ID_PROGETTO));
            cmd.Parameters.Add(new SqlParameter("@TIPO", TIPO));
            if (!string.IsNullOrEmpty(TIPO_ORIGINE)) 
                cmd.Parameters.Add(new SqlParameter("@TIPO_ORIGINE", TIPO_ORIGINE));
            if (!string.IsNullOrEmpty(SOGGETTO_RILEVATORE)) 
                cmd.Parameters.Add(new SqlParameter("@SOGGETTO_RILEVATORE", SOGGETTO_RILEVATORE));
            if (!string.IsNullOrEmpty(TIPO_DETRAZIONE)) 
                cmd.Parameters.Add(new SqlParameter("@TIPO_DETRAZIONE", TIPO_DETRAZIONE));
            if (!string.IsNullOrEmpty(PERIODO_CONTABILE_RIGA)) 
                cmd.Parameters.Add(new SqlParameter("@PERIODO_CONTABILE_RIGA", PERIODO_CONTABILE_RIGA));

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                int riga = new IntNT(DbProviderObj.DataReader["NUMERO_RIGA"]);
                if (riga % 2 == 0)
                {
                    pari = true;
                }

            }
            DbProviderObj.Close();
            return pari;
        }
    }
}
