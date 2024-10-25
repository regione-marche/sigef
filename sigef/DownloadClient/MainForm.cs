using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.IO;
using System.Configuration;
using System.Windows.Forms;
using DownloadManager;
using SiarLibrary;

namespace DownloadClient
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


        private void MainForm_Load(object sender, EventArgs e)
        {
            if ((args != null) && (args.Length > 1))
            {
                if (args[1].Equals("s"))
                {
                    if (lstMsg.Items.Count > 0)
                    {
                        LogMessage("");
                    }
                    LogMessage("Avvio procedura di download massivo (" + DateTime.Now.ToString("dd/MM/yyyy") + ") ...");
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


        private void LogMessage(string msg)
        {
            string hmsg = DateTime.Now.ToString("HH:mm:ss") + " " + msg;
            //stringa_rapporto_email += hmsg + "<br />";
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

        private void btnRequest_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstMsg.Items.Count > 0)
                {
                    LogMessage("");
                }
                LogMessage("Avvio procedura di download (" + DateTime.Now.ToString("dd/MM/yyyy") + ") ...");
                Button.CheckForIllegalCrossThreadCalls = false;
                TextBox.CheckForIllegalCrossThreadCalls = false;
                ComboBox.CheckForIllegalCrossThreadCalls = false;
                backgroundWorker1.RunWorkerAsync(txtIdTicket.Text);
            }
            catch (Exception ex)
            {
                LogMessage("ERR: " + ex.Message);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            btnRequest.Enabled = false;
            List<DownloadRequest> lTickets = new List<DownloadRequest>();
            DownloadOperazioni dlOps = new DownloadOperazioni();
            var currentTicket = new DownloadRequest();
            DateTime? dataInizioEstrazione;

            try
            {
                if (!string.IsNullOrEmpty(txtIdTicket.Text))
                {
                    lTickets.Add(dlOps.GetDownloadByTicket(int.Parse(txtIdTicket.Text)));
                }
                else
                {
                    var r = dlOps.GetOpenDownloadRequests();
                    if(r != null)
                    {
                        lTickets.AddRange(dlOps.GetOpenDownloadRequests());
                    }                    
                }

                if ((lTickets != null) && (lTickets.Count > 0))
                {
                    foreach (DownloadRequest request in lTickets)
                    {
                        try
                        {
                            currentTicket = request;
                            dataInizioEstrazione = DateTime.Now;
                            var docs = new ArchivioFileCollection();
                            var res = dlOps.GetUnitaDocumentale(request, out docs);
                            LogMessage("");
                            LogMessage("Esito: " + res.Esito + "; " + res.DescrizioneEsito);

                            foreach (ArchivioFile doc in docs)
                            {
                                string docname = doc.NomeCompleto;
                                docname = ReplaceInvalidChars(doc.NomeFile);
                                LogMessage("Download in corso per il file " + docname + "...");
                                try
                                {

                                    doc.NomeCompleto = docname;
                                    var r = dlOps.WriteFileToDirectory(doc, request.IdTicket, request.Segnatura);
                                    LogMessage(r.Esito + ": " + r.DescrizioneEsito);
                                }
                                catch (Exception ex)
                                {

                                    LogMessage("ERR: documento processato: " + docname + ": " + ex.Message);
                                }
                            }
                            LogMessage("Documenti scaricati per il ticket " + request.IdTicket.ToString());
                            LogMessage("Creazione archivio ZIP in corso...");
                            decimal size = dlOps.CreateZipFile(request.IdTicket, true);
                            LogMessage("Archivio ZIP creato con successo");
                            size /= 1048576;
                            dlOps.UpdateTicketStatus(request.IdTicket, dataInizioEstrazione, size);
                        }
                        catch (Exception ex)
                        {

                            LogMessage("ERR: ticket processato: " + currentTicket.IdTicket.ToString() + ": " + ex.Message);
                        }

                    }
                }
                else
                {
                    LogMessage("Nessun ticket da processare");
                }
                if (string.IsNullOrEmpty(txtIdTicket.Text)) 
                {
                    LogMessage("Cancellazione vecchi archivi in corso...");
                    var d = dlOps.DeleteOldArchives();
                    string msg = "Cancellazione effettuata ";
                    if ((d != null) && (d.Count > 0))
                    {
                        msg += "per i ticket: " + String.Join(", ", d.ToArray());
                    }
                    LogMessage(msg);
                }
                
            }
            catch (Exception ex)
            {

                LogMessage("ERR: ultimo ticket processato: " + currentTicket.IdTicket.ToString() + ": " + ex.Message);
            }
            finally
            {
                btnRequest.Enabled = true;
                e.Result = lTickets;
            }

            

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<DownloadRequest> tickets = (List<DownloadRequest>)e.Result;
            if (e.Error != null)
            {
                LogMessage("ERR: " + e.Error.Message);
            }

            string msg = "Procedura di download completata ";

            if ((tickets != null) && (tickets.Count > 0))
            {
                msg += "per i ticket: " + string.Join(", ", tickets.Select(x => x.IdTicket).ToArray());
            }

            LogMessage(msg);

            btnRequest.Enabled = true;
            if ((args != null) && (args.Length > 1))
            {
                if (args[1].Equals("s"))
                {
                    Application.Exit();
                }
            }
        }

        private string ReplaceInvalidChars(string filename)
        {
            return string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));
        }
    }
}
