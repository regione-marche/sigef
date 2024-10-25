using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using System.Windows.Forms;
using ProtocolloBatchManager;

namespace ProtocolloBatchClient
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
        List<int> lCounter = new List<int>
        {
            0,0,0,0
        };
        static string separatore = "/";

        private void Main_Load(object sender, EventArgs e)
        {
            BindComboBandi();
            lblCounter.Text = "--/--";

            if ((args != null) && (args.Length > 1))
            {
                if (args[1].Equals("s"))
                {
                    if (lstMsg.Items.Count > 0)
                    {
                        LogMessage("");
                    }
                    LogMessage("Richiesta Protocollo in corso (" + DateTime.Now.ToString("dd/MM/yyyy") + ") ...");
                    backgroundWorker1.RunWorkerAsync(lCounter);
                }
                if (args[1].Equals("n"))
                {
                    LogMessage("Test automazione");
                    Application.Exit();
                }
            }
            else
            {
                LogMessage(DateTime.Now.ToString("dd/MM/yyyy") + " - Avvio manuale interfaccia");
            }
           
        }

        private void BindComboBandi()
        {
            var protocollo = new ProtocolloOperazioni();
            var bandi = protocollo.GetBandi();
            bandi.Insert(0, new Bando { IdBando = -1, Descrizione = "" });
            cbBandi.DataSource = bandi;
            cbBandi.DisplayMember = "Descrizione";
            cbBandi.ValueMember = "IdBando";

        }

        private void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
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

        private void UpdateCounter(int total, int count)
        {
            lblCounter.Text = total.ToString() + "/" + count.ToString();
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstMsg.Items.Count > 0)
                {
                    LogMessage("");
                }
                LogMessage("Richiesta Protocollo in corso (" + DateTime.Now.ToString("dd/MM/yyyy") + ") ...");
                Button.CheckForIllegalCrossThreadCalls = false;
                ListBox.CheckForIllegalCrossThreadCalls = false;
                ComboBox.CheckForIllegalCrossThreadCalls = false;
                backgroundWorker1.RunWorkerAsync(lCounter);
            }
            catch (Exception ex)
            {
                LogMessage("ERR: " + ex.Message);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            List<int> counter = (List<int>)e.Argument;
            btnRequest.Enabled = false;
            int last_prog = 0;

            int idBando = (int)cbBandi.SelectedValue;
            string descBando = cbBandi.GetItemText(cbBandi.SelectedItem);
            if(idBando == -1)
            {
                LogMessage("Nessun bando selezionato!");
                return;
            }
            counter[3] = idBando;

            try
            {

                var protocollo = new ProtocolloOperazioni();
                var listProgetti = protocollo.GetProgettiProtocollabili(idBando);
                DateTime? dataRichiesta = null, dataRisposta = null;
                string esito = "KO";
                


                if ((listProgetti != null) && (listProgetti.Count > 0))
                {
                    LogMessage("Sono stati trovati " + listProgetti.Count.ToString() + " progetti protocollabili per il bando " + idBando.ToString() + " - " + descBando);
                    counter[0] = listProgetti.Count;
                    counter[1] = 0;
                    counter[2] = 0;
                    int done = 0;
                    UpdateCounter(counter[0], done); 

                    foreach (ProgettoProtocollabile progettoProtocollabile in listProgetti)
                    {
                        try
                        {
                            last_prog = progettoProtocollabile.IdProgetto;

                            if (string.IsNullOrEmpty(progettoProtocollabile.Segnatura))
                            {

                                var progetto = protocollo.GetIstanzaById(last_prog);
                                dataRichiesta = DateTime.Now;
                                var result = protocollo.ProtocollaDocumento(progetto);
                                esito = result.Esito;

                                var msg = "Esito: " + result.Esito;
                                msg += "; Id Progetto: " + result.IdProgetto.ToString();
                                msg += "; Id Istanza: " + result.IdIstanza.ToString();
                                msg += "; Segnatura: " + result.Segnatura;
                                msg += "; Msg: " + result.DescrizioneEsito;
                                LogMessage(msg);

                                if (result.Esito == "OK")
                                {
                                    protocollo.AggiornaSegnaturaProgetto(result.IdProgetto, result.Segnatura);
                                    LogMessage("Progetto " + result.IdProgetto.ToString() + " aggiornato con segnatura " + result.Segnatura);
                                    counter[1]++;

                                }
                                if (result.Esito == "KO")
                                {
                                    counter[2]++;
                                }

                                    protocollo.InsertLog(new ProtocolloLog
                                {
                                    IdProgetto = result.IdProgetto,
                                    Segnatura = result.Segnatura,
                                    DataRichiesta = dataRichiesta,
                                    DataRisposta = result.DataRisposta,
                                    Esito = result.Esito,
                                    DescrizioneEsito = result.DescrizioneEsito
                                });
                            }
                            else
                            {
                                LogMessage("il progetto " + last_prog.ToString() + " ha già la segnatura " + progettoProtocollabile.Segnatura);
                            }
                        }
                        catch (Exception ex)
                        {

                            LogMessage("ERR: progetto processato: " + last_prog.ToString() + ": " + ex.Message);
                            counter[2]++;
                            protocollo.InsertLog(new ProtocolloLog
                            {
                                IdProgetto = progettoProtocollabile.IdProgetto,
                                Segnatura = null,
                                DataRichiesta = dataRichiesta,
                                DataRisposta = dataRisposta,
                                Esito = "KO",
                                DescrizioneEsito = ex.Message
                            });
                        }
                        finally
                        {
                            done++;
                            UpdateCounter(counter[0], done);
                        }
                    }
                }
                else
                {
                    LogMessage("Nessun progetto da protocollare per il bando " + idBando.ToString() + " - " + descBando);
                    counter[0] = 0;
                    counter[1] = 0;
                    counter[2] = 0;
                }

            }
            catch (Exception ex)
            {

                LogMessage("ERR: ultimo progetto processato: " + last_prog.ToString() + ": " + ex.Message);
            }
            finally
            {
                btnRequest.Enabled = true;
                e.Result = counter;
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<int> counter = (List<int>)e.Result;
            if (e.Error != null)
            {
                LogMessage("ERR: " + e.Error.Message);
            }

            string msg = string.Format("Procedura di richiesta protocollo completata per il bando {0}: tot: {1}; OK: {2}; KO: {3}", counter[3].ToString(), counter[0].ToString(), counter[1].ToString(), counter[2].ToString());
            LogMessage(msg);
            LogMessage("");
            btnRequest.Enabled = true;
            if ((args != null) && (args.Length > 1))
            {
                if (args[1].Equals("s"))
                {
                    Application.Exit();
                }
            }
        }
    }
}
