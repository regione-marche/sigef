using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class BandoProgrammazioneCollectionProvider : IBandoProgrammazioneProvider
    {
        public BandoProgrammazioneCollection GetProgrammazioneBando(int id_bando, bool disp_attuative)
        {
            BandoProgrammazioneCollection cc = new BandoProgrammazioneCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetProgrammazioneBando";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", id_bando));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DISP_ATTUATIVE", disp_attuative));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                BandoProgrammazione bp = SiarDAL.BandoProgrammazioneDAL.GetFromDatareader(DbProviderObj);
                bp.AdditionalAttributes.Add("PADRE", new StringNT(DbProviderObj.DataReader["PADRE"]));
                cc.Add(bp);
            }
            DbProviderObj.Close();
            return cc;
        }

        /// <summary>
        /// usata per recuperare le disposizioni attuative del bando per i requisiti di misura nel progetto
        /// </summary>
        /// <param name="id_bando"></param>
        /// <returns></returns>
        public BandoProgrammazioneCollection GetDispAttuativeBando(int id_bando, IntNT id_progetto)
        {
            BandoProgrammazioneCollection cc = new BandoProgrammazioneCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetDispAttuativeBando";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", id_bando));
            if (id_progetto != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", id_progetto.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                BandoProgrammazione bp = new BandoProgrammazione();
                bp.Codice = new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["CODICE"]);
                bp.Descrizione = new SiarLibrary.NullTypes.StringNT(DbProviderObj.DataReader["DESCRIZIONE"]);
                bp.MisuraPrevalente = new SiarLibrary.NullTypes.BoolNT(DbProviderObj.DataReader["MISURA_PREVALENTE"]);
                bp.IdDisposizioniAttuative = new SiarLibrary.NullTypes.IntNT(DbProviderObj.DataReader["ID_DISPOSIZIONI_ATTUATIVE"]);
                bp.AdditionalAttributes.Add("IdProgetto", new SiarLibrary.NullTypes.IntNT(DbProviderObj.DataReader["ID_PROGETTO"]));
                cc.Add(bp);
            }
            DbProviderObj.Close();
            return cc;
        }

        public BandoProgrammazioneCollection GetProgrammazioneBandoInvestimentiProgetto(int id_progetto, int id_bando)
        {
            BandoProgrammazioneCollection cc = new BandoProgrammazioneCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetProgrammazioneBandoInvestimentiProgetto";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", id_progetto));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", id_bando));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                BandoProgrammazione bp = SiarDAL.BandoProgrammazioneDAL.GetFromDatareader(DbProviderObj);
                cc.Add(bp);
            }
            DbProviderObj.Close();
            return cc;
        }
    }
}
