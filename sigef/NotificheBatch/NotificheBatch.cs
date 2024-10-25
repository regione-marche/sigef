using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Data;

namespace NotificheBatch
{
    class Program
    {
        static string m_LogSuFile = ConfigurationManager.AppSettings["LogSuFile"];
        static string m_periodoEsecuzione = ConfigurationManager.AppSettings["periodoEsecuzione"];

        public static void writeLog(string messaggio, bool isErrorr)
        {
            try
            {
                if (m_LogSuFile != "")
                {
                    messaggio = "[" + string.Format("{0:yyyyMMdd_HH.mm.ss.fff}", DateTime.Now) + "] " + (isErrorr ? "ERR " : "    ") + messaggio + "\r\n"; ;
                    System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                    byte[] _ByteArray = encoding.GetBytes(messaggio);
                    System.IO.FileStream _FileStream = new System.IO.FileStream(m_LogSuFile, System.IO.FileMode.Append, System.IO.FileAccess.Write);
                    _FileStream.Write(_ByteArray, 0, _ByteArray.Length);
                    _FileStream.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        static void Main(string[] args)
        {
            if (m_LogSuFile != "") m_LogSuFile = m_LogSuFile.Replace("[DATETIME]", string.Format("{0:yyyyMMddHHmmss}", DateTime.Now));
            SiarLibrary.DbProvider _db = new SiarLibrary.DbProvider();
            IDataReader dr = null;
            List<string> notificatori = new List<string>();

            // legge tabela di notifivhr da fare in questo minuto ()
            DateTime adesso = DateTime.Now;
            string m = adesso.Minute.ToString();
            string h = adesso.Hour.ToString();
            string dom = adesso.Day.ToString();        // gg del mese
            string mon = adesso.Month.ToString();      // mese
            string dow = ((int)adesso.DayOfWeek).ToString();  // gg della settimana, da 0..6 (0 = domenica)
            string sql = @"
                select * from NOTIFICHE where ATTIVO = 1 and CLASSE_NOTIFICHE is not null and
                (h='*' or h=" + h + " or h like '" + h + ",%' or h like '%," + h + ",%' or h like '%," + h + @"') and 
                (dom='*' or dom='" + dom + "' or dom like '" + dom + ",%' or dom like '%," + dom + ",%' or dom like '%," + dom + @"') and
                (mon='*' or mon='" + mon + "' or mon like '" + mon + ",%' or mon like '%," + mon + ",%' or mon like '%," + mon + @"') and
                (dow='*' or dow='" + dow + "' or dow like '" + dow + ",%' or dow like '%," + dow + ",%' or dow like '%," + dow + @"')";
            if (m_periodoEsecuzione.ToLower() == "m") sql = sql + "and (m='*' or m='" + m + "' or m like '" + m + ",%' or m like '%," + m + ",%' or m like '%," + m + "')";

            try
            {
                IDbCommand cmd;
                cmd = _db.GetCommand();
                cmd.CommandText = sql;
                _db.InitDatareader(cmd);
                dr = _db.DataReader;
                while (dr.Read())
                    notificatori.Add(dr["CLASSE_NOTIFICHE"].ToString());
            }
            catch (Exception ex)
            {
                writeLog(ex.Message, true);
            }
            finally {
                if (dr != null && !dr.IsClosed) dr.Close();
            }

            int okNotifica = 0;
            for (int i = 0; i < notificatori.Count; i++) {
                NotificatoreBase notificatore = (NotificatoreBase)Activator.CreateInstance(Type.GetType(notificatori[i]));
                okNotifica = notificatore.Invia(_db);
                if (okNotifica != 0) writeLog(notificatore.ERRORE, true);
            }

            _db.Close();


        }
    }
}
