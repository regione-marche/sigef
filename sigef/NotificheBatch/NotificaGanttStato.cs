using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace NotificheBatch
{
    class NotificaGanttStato: NotificatoreBase
    {
        public override int Invia(SiarLibrary.DbProvider db)
        {
            //
            //return base.Invia(db);
            int retI = 0;
            int idGPrev = -1;
            IDataReader dr = null;
            List<string[]> elencoGanttMailNotifica = new List<string[]>();
            SiarLibrary.Email mailToSend = null;
            List<string> destinatari = null;
            string testoMail = "";

            try
            {
                IDbCommand cmd;
                cmd = db.GetCommand();
                cmd.CommandText = "SELECT EMAIL, ID_GANTT, OGGETTO FROM vNOTIFICHE_GANTT group by EMAIL, ID_GANTT, OGGETTO order by ID_GANTT, EMAIL";
                db.InitDatareader(cmd);
                dr = db.DataReader;
                while (dr.Read()) {
                    elencoGanttMailNotifica.Add(new string[] { dr["ID_GANTT"].ToString(), dr["EMAIL"].ToString(), dr["OGGETTO"].ToString() });
                }
            }
            catch (Exception ex)
            {
                ERRORE = "NotificaGanttStato - " + ex.Message;
                retI = -1;
            }
            finally
            {
                if (dr != null && !dr.IsClosed) dr.Close();
            }

            foreach (string[] ganttMail in elencoGanttMailNotifica)
            {
                if (idGPrev != Convert.ToInt32(ganttMail[0]))
                {
                    // invia la mail preparata (è finita); al primo ciclo ho mail = null --> non fa nulla
                    if (mailToSend != null && destinatari != null) mailToSend.Send("info-noreply.sigef@regione.marche.it", destinatari.ToArray(), new string[] { });
                    idGPrev = Convert.ToInt32(ganttMail[0]);
                    // prepara la nuova mail
                    destinatari = new List<string>();
                    testoMail = getTestoNotifica(Convert.ToInt32(ganttMail[0]), ganttMail[2]);
                    mailToSend = new SiarLibrary.Email("Stato pianificazione performace SIGEF", testoMail);
                    mailToSend.SetHtmlBodyMessage(true);
                }
                // aggiunge indirizzo dr["EMAIL"] alla mail da inviare
                if (destinatari != null) destinatari.Add(ganttMail[1]);

            }
            // invia la mail preparata (se esiste)
            if (mailToSend != null && destinatari != null) mailToSend.Send("info-noreply.sigef@regione.marche.it", destinatari.ToArray(), new string[] { }); 


            return retI;
        }

        private string getTestoNotifica(int idUOGantt, string oggettoBandoGantt) {
            return "La procedura <i>" + oggettoBandoGantt + "</i> ha uno o più passi in ritardo rispetto alla pianificazione.";
        }

    }
}
