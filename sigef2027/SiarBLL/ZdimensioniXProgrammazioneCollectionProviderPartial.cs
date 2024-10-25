using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;
using System.Data;
using System.Data.SqlClient;

namespace SiarBLL
{
    public partial class ZdimensioniXProgrammazioneCollectionProvider : IZdimensioniXProgrammazioneProvider
    {
        public ZdimensioniXProgrammazioneCollection GetIndicatoriIntervento(int id_intervento)
        {
            ZdimensioniXProgrammazioneCollection dp = new ZdimensioniXProgrammazioneCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetIndicatoriIntervento";
            cmd.Parameters.Add(new SqlParameter("@ID_PROG", id_intervento));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                dp.Add(SiarDAL.ZdimensioniXProgrammazioneDAL.GetFromDatareader(DbProviderObj));
            }
            DbProviderObj.Close();
            return dp;
        }

        //public ZdimensioniXProgrammazioneCollection GetValoriIndicatore(int id_intervento, int id_dim, out decimal val_prog, out decimal val_pf)
        //{
        //    SqlParameter output1 = new SqlParameter("@VAL_PROG", SqlDbType.Float);
        //    output1.Direction = ParameterDirection.Output;
        //    SqlParameter output2 = new SqlParameter("@VAL_PF", SqlDbType.Float);
        //    output2.Direction = ParameterDirection.Output;
        //    val_prog = 0;
        //    val_pf = 0;
        //    ZdimensioniXProgrammazioneCollection dp = new ZdimensioniXProgrammazioneCollection();
        //    IDbCommand cmd = DbProviderObj.GetCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "SpPsrGetValoriIndicatore";
        //    cmd.Parameters.Add(new SqlParameter("@ID_PROG", id_intervento));
        //    cmd.Parameters.Add(new SqlParameter("@ID_DIM", id_dim));
        //    cmd.Parameters.Add(output1);
        //    cmd.Parameters.Add(output2);
        //    DbProviderObj.Execute(cmd);

        //    Decimal.TryParse(output1.Value.ToString(), out val_prog);
        //    Decimal.TryParse(output2.Value.ToString(), out val_pf);

        //    DbProviderObj.Close();
        //    return dp;
        //}



        public ZdimensioniXProgrammazioneCollection GetByCodPsr(string codPsr, int id_dimensione)
        {
            ZdimensioniXProgrammazioneCollection dims = new ZdimensioniXProgrammazioneCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetDimProgrammazione_ByCodPsr";
            cmd.Parameters.Add(new SqlParameter("@Psr", codPsr));
            cmd.Parameters.Add(new SqlParameter("@Dim", id_dimensione));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                dims.Add(SiarDAL.ZdimensioniXProgrammazioneDAL.GetFromDatareader(DbProviderObj));
            }
            DbProviderObj.Close();

            return dims;
        }

        public void DeleteByCodPsr(string codPsr, int id_dimensione)
        {
            ZdimensioniXProgrammazioneCollection dims = new ZdimensioniXProgrammazioneCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrDeleteDimProgrammazione_ByCodPsr";
            cmd.Parameters.Add(new SqlParameter("@Psr", codPsr));
            cmd.Parameters.Add(new SqlParameter("@Dim", id_dimensione));
            DbProviderObj.Execute(cmd);
        }

        public ZdimensioniXProgrammazioneCollection GetBy_IdDimensione(int idDimensione)
        {
            ZdimensioniXProgrammazioneCollection dxps = new ZdimensioniXProgrammazioneCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetDimProgrammazione_ByIdDimensione";
            cmd.Parameters.Add(new SqlParameter("@Dim", idDimensione));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                dxps.Add(SiarDAL.ZdimensioniXProgrammazioneDAL.GetFromDatareader(DbProviderObj));
            }
            DbProviderObj.Close();            

            return dxps;
        }
    }
}
