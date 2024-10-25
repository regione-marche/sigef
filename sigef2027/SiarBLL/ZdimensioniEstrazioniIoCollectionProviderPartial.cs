using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;
using System.Data;
using System.Data.SqlClient;

namespace SiarBLL
{
    public partial class ZdimensioniEstrazioniIoCollectionProvider : IZdimensioniEstrazioniIoProvider
    {
 
        public ZdimensioniEstrazioniIoCollection GetNewIndicatori(string id_prs, int i_anno)
        {

            DateTime dtInizio = new DateTime(i_anno, 01, 01, 0, 0, 0);
            DateTime dtFine = new DateTime(i_anno, 12, 31, 23, 59, 59);

            ZdimensioniEstrazioniIoCollectionProvider dimIOp = new ZdimensioniEstrazioniIoCollectionProvider();
            ZdimensioniEstrazioniIoCollection dimIO = new ZdimensioniEstrazioniIoCollection();

            IDbCommand cmd = DbProviderObj.GetCommand();
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CalcoloIndicatori";
                cmd.Parameters.Add(new SqlParameter("@IdPor", id_prs));
                cmd.Parameters.Add(new SqlParameter("@DataFin", dtFine));

                DbProviderObj.InitDatareader(cmd);
                while (DbProviderObj.DataReader.Read())
                {
                    dimIO.Add(SiarDAL.ZdimensioniEstrazioniIoDAL.GetFromDatareader(DbProviderObj));
                }
                DbProviderObj.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dimIO;

        }
        public ZdimensioniEstrazioniIoCollection GetIndicatoriVuoti(string id_prs, int i_anno)
        {

            DateTime dtInizio = new DateTime(i_anno, 01, 01, 0, 0, 0);
            DateTime dtFine = new DateTime(i_anno, 12, 31, 23, 59, 59);

            ZdimensioniEstrazioniIoCollectionProvider dimIOp = new ZdimensioniEstrazioniIoCollectionProvider();
            ZdimensioniEstrazioniIoCollection dimIO = new ZdimensioniEstrazioniIoCollection();

            IDbCommand cmd = DbProviderObj.GetCommand();
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CalcoloIndicatoriVuoti";
                cmd.Parameters.Add(new SqlParameter("@IdPor", id_prs));
                cmd.Parameters.Add(new SqlParameter("@DataFin", dtFine));

                DbProviderObj.InitDatareader(cmd);
                while (DbProviderObj.DataReader.Read())
                {
                    dimIO.Add(SiarDAL.ZdimensioniEstrazioniIoDAL.GetFromDatareader(DbProviderObj));
                }
                DbProviderObj.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dimIO;

        }             
 
    }
}
