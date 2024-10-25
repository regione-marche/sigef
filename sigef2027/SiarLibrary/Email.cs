using System;
using System.Net.Mail;
using System.Collections.Generic;

namespace SiarLibrary
{
    public class Email : IDisposable
    {
        MailMessage messaggio;
        SmtpClient smtp;
        public Email(string oggetto, string testo)
        {
            smtp = new SmtpClient();
            smtp.Host = "webmail.regione.marche.it";
            messaggio = new MailMessage();
            messaggio.Subject = oggetto;
            messaggio.Body = testo;
        }

        public void SetHtmlBodyMessage(bool set_html) { messaggio.IsBodyHtml = set_html; }

        public void Send(string from, string[] to, string[] cc)
        {
            try
            {
                messaggio.From = new MailAddress(from);
                foreach (string s in to) messaggio.To.Add(s);
                foreach (string s in cc) messaggio.CC.Add(s);
                if (System.Configuration.ConfigurationManager.AppSettings["APP:TipoInstallazione"] == "Produzione")
                    smtp.Send(messaggio); // al momento dello sviluppo tira fuori errore di mancato invio e per il server di test è inutile
                Dispose();
            }
            catch { throw new SiarException(TextErrorCodes.EmailNonInviata); }
        }

        public void Send(string from, string to, string[] cc) { Send(from, new string[] { to }, cc); }

        public void Send(string from, string to, string cc) { Send(from, new string[] { to }, new string[] { cc }); }

        public void Send(string from, string to) { Send(from, to, new string[] { }); }

        public void Send(string from, List<string> to)
        {
            Send(from, to.ToArray(), new string[] { });
        }

        public void SendAlert() { Send("info-noreply.sigef@regione.marche.it", "sigefweb_error_administrator@regione.marche.it"); }

        public void SendAlertToTeamSigef(Exception e, List<string> to, string istanzaSigef)
        {
            logMessageDataTeamSigef(e, istanzaSigef);
            Send("info-noreply.sigef@regione.marche.it", to);
        }

        public void SendAlert(Exception e) { logMessageData(e); SendAlert(); }

        public void SendNotification(string to) { SendNotification(to, new string[] { }); }

        public void SendNotification(string to, string cc) { SendNotification(new string[] { to }, new string[] { cc }); }

        public void SendNotification(string to, string[] cc) { SendNotification(new string[] { to }, cc); }

        public void SendNotification(string[] to, string[] cc) { Send("info-noreply.sigef@regione.marche.it", to, cc); }

        public void SendCertified(string from, string to)
        {
            throw new System.NotImplementedException();
            //smtp.UseDefaultCredentials = false;
            //smtp.Credentials = new System.Net.NetworkCredential("regione.marche.agricoltura@emarche.it", "...");
            //smtp.Host = "smtps.emarche.it";
            //smtp.Port = 465;
            //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtp.EnableSsl = true;
            //Send(from, to);
        }

        private void logMessageData(Exception e)
        {
            if (e != null)
            {
                messaggio.Body += "\n\nMessaggio errore:" + e.Message
                    + (e is SiarException ? "\nSiar exception: [Codice: " + ((SiarException)e).Codice + " ] [Gravità: " + ((SiarException)e).Gravita + " ]" : "")
                    + "\nSource: " + (e.Source != null ? e.Source : "")
                    + "\nTarget site: " + (e.TargetSite != null ? e.TargetSite.ToString() : "")
                    + "\nStack trace: " + (e.StackTrace != null ? e.StackTrace : "");
                logMessageData(e.InnerException);
            }
        }

        private void logMessageDataTeamSigef(Exception e, string istanzaSigef)
        {
            if (e != null)
            {
                messaggio.Body += "\nIstanza Sigef: " + istanzaSigef
                    + "\n\nMessaggio errore:" + e.Message
                    + (e is SiarException ? "\nSiar exception: [Codice: " + ((SiarException)e).Codice + " ] [Gravità: " + ((SiarException)e).Gravita + " ]" : "")
                    + "\nSource: " + (e.Source != null ? e.Source : "")
                    + "\nTarget site: " + (e.TargetSite != null ? e.TargetSite.ToString() : "")
                    + "\nStack trace: " + (e.StackTrace != null ? e.StackTrace : "");
                logMessageData(e.InnerException);
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (smtp != null) smtp = null;
            if (messaggio != null) messaggio = null;
        }

        #endregion
    }
}
