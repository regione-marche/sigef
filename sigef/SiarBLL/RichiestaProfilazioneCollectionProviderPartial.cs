using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;


namespace SiarBLL
{

	public partial class RichiestaProfilazioneCollectionProvider : IRichiestaProfilazioneProvider
	{
        public RichiestaProfilazioneCollection FindDomandeDaApprovare(int? idOperatore)
        {
            SiarLibrary.RichiestaProfilazione dom = null;
            SiarLibrary.RichiestaProfilazioneCollection doms = new RichiestaProfilazioneCollection();

            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            string str = @"SELECT  * FROM RICHIESTA_PROFILAZIONE WHERE DEFINITIVA = 1 AND APPROVATA IS NULL";
            if(idOperatore != null)
                str += " AND OPERATORE = "+idOperatore.ToString();
            str += " ORDER BY ID_RICHIESTA DESC";
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = str;
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                dom = (SiarDAL.RichiestaProfilazioneDAL.GetFromDatareader(dbPro));
                doms.Add(dom);
            }
            dbPro.Close();

            return doms;
        }

        public RichiestaProfilazioneCollection FindDomandeApprovateEInviate(int? idOperatore)
        {
            SiarLibrary.RichiestaProfilazione dom = null;
            SiarLibrary.RichiestaProfilazioneCollection doms = new RichiestaProfilazioneCollection();

            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            string str = @"SELECT  * FROM RICHIESTA_PROFILAZIONE WHERE DEFINITIVA = 1 AND APPROVATA = 1 AND SEGNATURA IS NOT NULL";
            if (idOperatore != null)
                str += " AND OPERATORE = " + idOperatore.ToString();
            str += " ORDER BY ID_RICHIESTA DESC";
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = str;
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                dom = (SiarDAL.RichiestaProfilazioneDAL.GetFromDatareader(dbPro));
                doms.Add(dom);
            }
            dbPro.Close();

            return doms;
        }

        public RichiestaProfilazioneCollection FindDomandeApprovateDaInviare(int? idOperatore)
        {
            SiarLibrary.RichiestaProfilazione dom = null;
            SiarLibrary.RichiestaProfilazioneCollection doms = new RichiestaProfilazioneCollection();

            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            string str = @"SELECT  * FROM RICHIESTA_PROFILAZIONE WHERE DEFINITIVA = 1 AND APPROVATA = 1 AND SEGNATURA IS NULL";
            if (idOperatore != null)
                str += " AND OPERATORE = " + idOperatore.ToString();
            str += " ORDER BY ID_RICHIESTA DESC";
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = str;
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                dom = (SiarDAL.RichiestaProfilazioneDAL.GetFromDatareader(dbPro));
                doms.Add(dom);
            }
            dbPro.Close();

            return doms;
        }

        public RichiestaProfilazioneCollection FindDomandeAdg(int? idOperatore)
        {
            SiarLibrary.RichiestaProfilazione dom = null;
            SiarLibrary.RichiestaProfilazioneCollection doms = new RichiestaProfilazioneCollection();

            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            string str = @"SELECT  * FROM RICHIESTA_PROFILAZIONE WHERE DEFINITIVA = 1 AND APPROVATA IS NOT NULL";
            if (idOperatore != null)
                str += " AND OPERATORE_APPROVAZIONE = " + idOperatore.ToString();
            str += " ORDER BY ID_RICHIESTA DESC";
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = str;
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                dom = (SiarDAL.RichiestaProfilazioneDAL.GetFromDatareader(dbPro));
                doms.Add(dom);
            }
            dbPro.Close();

            return doms;
        }
    }
}	