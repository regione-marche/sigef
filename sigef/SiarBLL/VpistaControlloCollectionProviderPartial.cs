using SiarLibrary;
using SiarDAL;
using System.Data;
using SiarLibrary.NullTypes;
using System;
using System.Data.SqlClient;

namespace SiarBLL
{
    public partial class VpistaControlloCollectionProvider
    {
        public string GetStatoProgettoPistaDiControllo(int IdProgetto)
        {
            string stato = null;
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetStatoProgettoPistaDiControllo";
            cmd.Parameters.Add(new SqlParameter("IdProgetto", IdProgetto));
            stato = dbPro.ExecuteScalar(cmd).ToString();
            dbPro.Close();
            return stato;
        }

        public DateProgettoPistaDiControllo GetDateProgettoPistaDiControllo(int IdProgetto)
        {
            DateProgettoPistaDiControllo dateProgetto = new DateProgettoPistaDiControllo();
            dateProgetto.IdProgetto = IdProgetto;

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetDateProgettoPistaDiControllo";
            cmd.Parameters.Add(new SqlParameter("IdProgetto", IdProgetto));

            dbPro.InitDatareader(cmd);

            while (dbPro.DataReader.Read())
            {
                dateProgetto.DataInizio = new DatetimeNT(dbPro.DataReader["DataInizio"]);
                dateProgetto.DataFinePrevista = new DatetimeNT(dbPro.DataReader["DataFinePrevista"]);
                dateProgetto.DataFineEffettiva = new DatetimeNT(dbPro.DataReader["DataFineEffettiva"]);
            }
            
            dbPro.Close();

            return dateProgetto;
        }
    }

    public class DateProgettoPistaDiControllo
    {
        public int IdProgetto;
        public DatetimeNT DataInizio;
        public DatetimeNT DataFinePrevista;
        public DatetimeNT DataFineEffettiva;
    }
}
