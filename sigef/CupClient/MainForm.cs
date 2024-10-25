using System;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using CupManager;
using System.Net.Mail;


namespace CupClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        static string path = Path.GetDirectoryName(Application.ExecutablePath);
        static string logpath = path + "\\Log\\";
        string[] args = Environment.GetCommandLineArgs();


        private void Main_Load(object sender, EventArgs e)
        {
            if ((args != null) && (args.Length > 1))
            {
                if (args[1].Equals("s"))
                {
                    if (lstMsg.Items.Count > 0)
                    {
                        LogMessage("");
                    }
                    LogMessage("Richiesta CUP in corso (" + DateTime.Now.ToString("dd/MM/yyyy") + ") ...");
                    backgroundWorker1.RunWorkerAsync();
                }
                if (args[1].Equals("n"))
                {
                    LogMessage("Test automazione");
                    Application.Exit();
                }
            }
            else
            {
                LogMessage("Avvio manuale interfaccia");
            }
        }

        string stringa_rapporto_email = "<br />";
        private void LogMessage(string msg)
        {
            string hmsg = DateTime.Now.ToString("HH:mm:ss") + " " + msg;
            stringa_rapporto_email += hmsg + "<br />";
            if (string.IsNullOrEmpty(msg))
                lstMsg.Items.Add(msg);
            else
                lstMsg.Items.Add(hmsg);
            lstMsg.SelectedIndex = lstMsg.Items.Count - 1;
            lstMsg.SelectedIndex = -1;
            if (bool.Parse(ConfigurationManager.AppSettings["enable_log"]))
            {
                CreateDirectory(logpath);
                string log = logpath + "Log.txt";
                using (StreamWriter sw = File.AppendText(log))
                {
                    if (string.IsNullOrEmpty(msg))
                        sw.WriteLine(msg);
                    else
                        sw.WriteLine(hmsg);
                }
            }
        }


        private void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            btnRequest.Enabled = false;
            int last_prog = 0;
            try
            {
                var cup = new CupRichiesta();

                var lprog = cup.GetProgettiFinanziabili();
                if ((lprog != null) && (lprog.Count > 0))
                {
                    LogMessage("Sono stati trovati " + lprog.Count.ToString() + " progetti finanziabili");

                    foreach (ProgettiFinanziabili p in lprog)
                    {
                        try
                        {
                            last_prog = p.ID_PROGETTO;
                            var res = cup.RequestCodiceCUP(p.ID_PROGETTO);

                            if (res.Esito.Equals("OK"))
                            {
                                var msg = "Esito: " + res.Esito;
                                msg += "; Id Progetto: " + res.IdProgetto.ToString();
                                msg += "; Codice CUP: " + res.CodiceCUP;
                                LogMessage(msg);
                                cup.UpdateProgetto(p.ID_PROGETTO, res.CodiceCUP);
                                LogMessage("Progetto " + p.ID_PROGETTO.ToString() + " aggiornato in banca dati");
                            }
                            else
                            {
                                var msg = "Esito: " + res.Esito;
                                msg += "; Id Progetto: " + res.IdProgetto.ToString();
                                msg += "; Messaggio: " + res.Messaggio;
                                LogMessage(msg);
                            }
                        }
                        catch (Exception ex)
                        {
                            LogMessage("ERR: progetto processato: " + last_prog.ToString() + ": " + ex.Message);
                        }

                        //#if DEBUG
                        //                        return;
                        //#endif

                    }
                }
                else
                {
                    LogMessage("Nessun progetto presente per cui richiedere il CUP");
                }
            }
            catch (Exception ex)
            {
                LogMessage("ERR: ultimo progetto processato: " + last_prog.ToString() + ": " + ex.Message);
            }
            finally
            {
                btnRequest.Enabled = true;
            }

        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstMsg.Items.Count > 0)
                {
                    LogMessage("");
                }
                LogMessage("Richiesta CUP in corso (" + DateTime.Now.ToString("dd/MM/yyyy") + ") ...");
                Button.CheckForIllegalCrossThreadCalls = false;
                ListBox.CheckForIllegalCrossThreadCalls = false;
                backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                LogMessage("ERR: " + ex.Message);
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                LogMessage("ERR: " + e.Error.Message);
            }

            LogMessage("Procedura di richiesta CUP completata");
            LogMessage("");
            btnRequest.Enabled = true;
            SendNotification(stringa_rapporto_email);
            if ((args != null) && (args.Length > 1))
            {
                if (args[1].Equals("s"))
                {
                    Application.Exit();
                }
            }
        }

        private void SendNotification(string stringa_rapporto_email)
        {
            try
            {
                if (bool.Parse(ConfigurationManager.AppSettings["enable_email_notification"]))
                {
                    MailMessage messaggio;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "webmail.regione.marche.it";
                    messaggio = new MailMessage();
                    messaggio.Subject = "Rapporto esecuzione notturna richiesta CUP";
                    messaggio.Body = "<html><body>" + stringa_rapporto_email + "</body></html>";
                    messaggio.IsBodyHtml = true;
                    messaggio.From = new MailAddress(ConfigurationManager.AppSettings["email_notification_from"]);
                    messaggio.To.Add(new MailAddress(ConfigurationManager.AppSettings["email_notification_to"]));
                    smtp.Send(messaggio);
                    smtp = null;
                    messaggio.Dispose();
                    messaggio = null;
                }
            }
            catch (Exception ex) { LogMessage("ERR: " + ex.Message); }
        }
    }
}
