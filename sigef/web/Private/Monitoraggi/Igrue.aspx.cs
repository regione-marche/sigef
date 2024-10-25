using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarBLL;
using SiarLibrary;
using PucManager;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace web.Private.Monitoraggi 
{
    public partial class Igrue : SiarLibrary.Web.PrivatePage
    {
        IgrueInvioCollectionProvider igrue_invio_provider;
        IgrueInvio invio_selezionato;
        IgrueLogErroriCollectionProvider igruee_log_provider;
        IgrueLogErrori log_selezionato;
        PucOperazioni puc_operazioni;

        const int tabFesr = 1, tabLeggeStabilità = 2, tabPsc = 3, tabPoc = 4, tabGestioneAvanzata = 5;
        const int eliminazioneFile = 0, eliminazioneIdProgetti = 1, eliminazioneSQL = 2;

        const string codiceFondoFesr2020 = "FESR20142020",
                     codiceFondoITI = "ITIAILS20142020",
                     codiceFondoPsc = "PSCMARCHE",
                     codiceFondoPoc ="POCMARCHE"; 

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "igrue";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.btnDownloadFileInvioFesr);
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (Operatore.Utente.Profilo != "Amministratore") //Solo noi amministratori possiamo vedere l'eliminazione
                divEliminazioneSingoli.Visible = false;

            switch (ucSiarNewTab.TabSelected)
            {
                case tabGestioneAvanzata:
                    divFesr.Visible = false;
                    divLeggeStabilita.Visible = false;
                    divPsc.Visible = false;
                    divPoc.Visible = false;

                    svuotaCampiNascostiFesr();
                    svuotaCampiNascostiLeggeStabilita();
                    svuotaCampiNascostiPsc();
                    svuotaCampiNascostiPoc();
                    break;

                case tabLeggeStabilità:
                    divFesr.Visible = false;
                    divPsc.Visible = false;
                    divGestioneAvanzate.Visible = false;
                    divPoc.Visible = false;

                    popolaCampiNascostiLeggeStabilita();
                    popolaDgIgrueeInviiLeggeStabilita();
                    popolaDgDettaglioInvioLeggeStabilita();
                    popolaDgDettaglioErroriLeggeStabilita();

                    svuotaCampiNascostiFesr();
                    svuotaCampiNascostiPsc();
                    svuotaCampiNascostiPoc();
                    break;

                case tabPsc:
                    divFesr.Visible = false;
                    divLeggeStabilita.Visible = false;
                    divGestioneAvanzate.Visible = false;
                    divPoc.Visible = false;

                    popolaCampiNascostiPsc();
                    popolaDgIgrueeInviiPsc();
                    popolaDgDettaglioInvioPsc();
                    popolaDgDettaglioErroriPsc();

                    svuotaCampiNascostiFesr();
                    svuotaCampiNascostiLeggeStabilita();
                    svuotaCampiNascostiPoc();
                    break;
                case tabPoc:
                    divFesr.Visible = false;
                    divLeggeStabilita.Visible = false;
                    divGestioneAvanzate.Visible = false;
                    divPsc.Visible = false;

                    popolaCampiNascostiPoc();
                    popolaDgIgrueeInviiPoc();
                    popolaDgDettaglioInvioPoc();
                    popolaDgDettaglioErroriPoc();

                    svuotaCampiNascostiFesr();
                    svuotaCampiNascostiLeggeStabilita();
                    svuotaCampiNascostiPsc();
                    break;

                default:
                    divLeggeStabilita.Visible = false;
                    divPsc.Visible = false;
                    divGestioneAvanzate.Visible = false;
                    divPoc.Visible = false;

                    popolaCampiNascostiFesr();
                    popolaDgIgrueeInviiFesr();
                    popolaDgDettaglioInvioFesr();
                    popolaDgDettaglioErroriFesr();

                    svuotaCampiNascostiLeggeStabilita();
                    svuotaCampiNascostiPsc();
                    svuotaCampiNascostiPoc();
                    break;
            }   

            base.OnPreRender(e);
        }

        #region Metodi Fesr 

        protected void popolaCampiNascostiFesr()
        {
            igrue_invio_provider = new IgrueInvioCollectionProvider();
            igruee_log_provider = new IgrueLogErroriCollectionProvider();
            puc_operazioni = new PucOperazioni();

            int id_invio;
            if (int.TryParse(hdnIdInvioFesr.Value, out id_invio))
                invio_selezionato = igrue_invio_provider.GetByIdInvio(id_invio)[0];

            int id_log_errori;
            if (int.TryParse(hdnIdLogErroriFesr.Value, out id_log_errori))
                log_selezionato = igruee_log_provider.GetById(id_log_errori);
        }

        protected void svuotaCampiNascostiFesr()
        {
            hdnIdInvioFesr.Value = null;
            hdnIdLogErroriFesr.Value = null;
        }

        protected void popolaDgIgrueeInviiFesr()
        {
            IgrueInvioCollection igruee_invii_collection;
            if (invio_selezionato != null)
            {
                igruee_invii_collection = new IgrueInvioCollection
                {
                    invio_selezionato
                };
                dgIgrueInviiFesr.Titolo = "Selezionare per ritornare all'elenco degli invii ad Igrue.";
            }
            else
            {
                igruee_invii_collection = igrue_invio_provider.GetDataInvioDaASenzaFile(null, null, codiceFondoFesr2020);
                
                if (igruee_invii_collection.Count == 0)
                    dgIgrueInviiFesr.Titolo = "Nessun invio di monitoraggio Igrue presente.";
                else
                    dgIgrueInviiFesr.Titolo = "Selezionare l'invio per visualizzare il dettaglio";
            }

            dgIgrueInviiFesr.DataSource = igruee_invii_collection;
            //dgIgrueInviiFesr.SetTitoloNrElementi();
            dgIgrueInviiFesr.ItemDataBound += new DataGridItemEventHandler(dgIgrueInvii_ItemDataBound);
            dgIgrueInviiFesr.DataBind();
        }

        protected void popolaDgDettaglioInvioFesr()
        {   
            if (invio_selezionato != null)
            {
                divDettaglioFesr.Visible = true;

                var igruee_log_collection = igruee_log_provider.GetByIdInvioSenzaFile(invio_selezionato.IdInvio, codiceFondoFesr2020);

                if (igruee_log_collection.Count == 0)
                {
                    dgInvioLogFesr.Titolo = "Nessun esito presente.";
                }
                else
                {
                    dgInvioLogFesr.Titolo = "Selezionare l'esito per visualizzare il dettaglio";

                    if (igruee_log_collection[0].IstanzaErrori != null)
                        btnRichiediValidazioneFesr.Enabled = false;
                }

                dgInvioLogFesr.DataSource = igruee_log_collection;
                //dgInvioLogFesr.SetTitoloNrElementi();
                dgInvioLogFesr.ItemDataBound += new DataGridItemEventHandler(dgInvioLog_ItemDataBound);
                dgInvioLogFesr.DataBind();
            }
        }

        protected void popolaDgDettaglioErroriFesr()
        {
            if (log_selezionato != null && log_selezionato.IstanzaErrori != null)
            {
                divDettaglioErroriFesr.Visible = true;

                int id_log = log_selezionato.IdIgrueLogErrori;
                var xml_log_errori = puc_operazioni.GetXmlLogErrori(id_log);
                
                try
                {
                    SiarBLL.LogRoot entity = FromXml<SiarBLL.LogRoot>(xml_log_errori);
                    txtIdInvioErroreFesr.Text = entity.IdInvio;
                    txtIdTicketErroreFesr.Text = entity.IdTicket;

                    var elenco_errori_collection = entity.LogEntry;
                    dgLogErroriFesr.DataSource = elenco_errori_collection;
                    dgLogErroriFesr.ItemDataBound += new DataGridItemEventHandler(dgLogErrori_ItemDataBound);
                    dgLogErroriFesr.DataBind();
                }
                catch (Exception ex) { ShowError(ex.ToString()); }
            }
        }

        #endregion Metodi Fesr

        #region Metodi ITI

        protected void popolaCampiNascostiLeggeStabilita()
        {
            igrue_invio_provider = new IgrueInvioCollectionProvider();
            igruee_log_provider = new IgrueLogErroriCollectionProvider();
            puc_operazioni = new PucOperazioni();

            int id_invio;
            if (int.TryParse(hdnIdInvioLeggeStabilita.Value, out id_invio))
                invio_selezionato = igrue_invio_provider.GetByIdInvio(id_invio)[0];

            int id_log_errori;
            if (int.TryParse(hdnIdLogErroriLeggeStabilita.Value, out id_log_errori))
                log_selezionato = igruee_log_provider.GetById(id_log_errori);
        }

        protected void svuotaCampiNascostiLeggeStabilita()
        {
            hdnIdInvioLeggeStabilita.Value = null;
            hdnIdLogErroriLeggeStabilita.Value = null;
        }

        protected void popolaDgIgrueeInviiLeggeStabilita()
        {
            IgrueInvioCollection igruee_invii_collection;
            if (invio_selezionato != null)
            {
                igruee_invii_collection = new IgrueInvioCollection
                {
                    invio_selezionato
                };
                dgIgrueInviiLeggeStabilita.Titolo = "Selezionare per ritornare all'elenco degli invii ad Igrue.";
            }
            else
            {
                igruee_invii_collection = igrue_invio_provider.GetDataInvioDaASenzaFile(null, null, codiceFondoITI);
                
                if (igruee_invii_collection.Count == 0)
                    dgIgrueInviiLeggeStabilita.Titolo = "Nessun invio di monitoraggio Igrue presente.";
                else
                    dgIgrueInviiLeggeStabilita.Titolo = "Selezionare l'invio per visualizzare il dettaglio";
            }

            dgIgrueInviiLeggeStabilita.DataSource = igruee_invii_collection;
            //dgIgrueInviiLeggeStabilita.SetTitoloNrElementi();
            dgIgrueInviiLeggeStabilita.ItemDataBound += new DataGridItemEventHandler(dgIgrueInvii_ItemDataBound);
            dgIgrueInviiLeggeStabilita.DataBind();
        }

        protected void popolaDgDettaglioInvioLeggeStabilita()
        {
            if (invio_selezionato != null)
            {
                divDettaglioLeggeStabilita.Visible = true;

                var igruee_log_collection = igruee_log_provider.GetByIdInvioSenzaFile(invio_selezionato.IdInvio, codiceFondoITI);

                if (igruee_log_collection.Count == 0)
                {
                    dgInvioLogLeggeStabilita.Titolo = "Nessun esito presente.";
                }
                else
                {
                    dgInvioLogLeggeStabilita.Titolo = "Selezionare l'esito per visualizzare il dettaglio";

                    if (igruee_log_collection[0].IstanzaErrori != null)
                        btnRichiediValidazioneLeggeStabilita.Enabled = false;
                }

                dgInvioLogLeggeStabilita.DataSource = igruee_log_collection;
                //dgInvioLogLeggeStabilita.SetTitoloNrElementi();
                dgInvioLogLeggeStabilita.ItemDataBound += new DataGridItemEventHandler(dgInvioLog_ItemDataBound);
                dgInvioLogLeggeStabilita.DataBind();
            }
        }

        protected void popolaDgDettaglioErroriLeggeStabilita()
        {
            if (log_selezionato != null && log_selezionato.IstanzaErrori != null)
            {
                divDettaglioErroriLeggeStabilita.Visible = true;

                int id_log = log_selezionato.IdIgrueLogErrori;
                var xml_log_errori = puc_operazioni.GetXmlLogErrori(id_log);

                try
                {
                    SiarBLL.LogRoot entity = FromXml<SiarBLL.LogRoot>(xml_log_errori);
                    txtIdInvioErroreLeggeStabilita.Text = entity.IdInvio;
                    txtIdTicketErroreLeggeStabilita.Text = entity.IdTicket;

                    var elenco_errori_collection = entity.LogEntry;
                    dgLogErroriLeggeStabilita.DataSource = elenco_errori_collection;
                    dgLogErroriLeggeStabilita.ItemDataBound += new DataGridItemEventHandler(dgLogErrori_ItemDataBound);
                    dgLogErroriLeggeStabilita.DataBind();
                }
                catch (Exception ex) { ShowError(ex.ToString()); }
            }
        }

        #endregion Metodi ITI

        #region Metodi Psc 

        protected void popolaCampiNascostiPsc()
        {
            igrue_invio_provider = new IgrueInvioCollectionProvider();
            igruee_log_provider = new IgrueLogErroriCollectionProvider();
            puc_operazioni = new PucOperazioni();

            int id_invio;
            if (int.TryParse(hdnIdInvioPsc.Value, out id_invio))
                invio_selezionato = igrue_invio_provider.GetByIdInvio(id_invio)[0];

            int id_log_errori;
            if (int.TryParse(hdnIdLogErroriPsc.Value, out id_log_errori))
                log_selezionato = igruee_log_provider.GetById(id_log_errori);
        }

        protected void svuotaCampiNascostiPsc()
        {
            hdnIdInvioPsc.Value = null;
            hdnIdLogErroriPsc.Value = null;
        }

        protected void popolaDgIgrueeInviiPsc()
        {
            IgrueInvioCollection igruee_invii_collection;
            if (invio_selezionato != null)
            {
                igruee_invii_collection = new IgrueInvioCollection
                {
                    invio_selezionato
                };
                dgIgrueInviiPsc.Titolo = "Selezionare per ritornare all'elenco degli invii ad Igrue.";
            }
            else
            {
                igruee_invii_collection = igrue_invio_provider.GetDataInvioDaASenzaFile(null, null, codiceFondoPsc); 

                if (igruee_invii_collection.Count == 0)
                    dgIgrueInviiPsc.Titolo = "Nessun invio di monitoraggio Igrue presente.";
                else
                    dgIgrueInviiPsc.Titolo = "Selezionare l'invio per visualizzare il dettaglio";
            }

            dgIgrueInviiPsc.DataSource = igruee_invii_collection;
            //dgIgrueInviiPsc.SetTitoloNrElementi();
            dgIgrueInviiPsc.ItemDataBound += new DataGridItemEventHandler(dgIgrueInvii_ItemDataBound);
            dgIgrueInviiPsc.DataBind();
        }

        protected void popolaDgDettaglioInvioPsc()
        {
            if (invio_selezionato != null)
            {
                divDettaglioPsc.Visible = true;

                var igruee_log_collection = igruee_log_provider.GetByIdInvioSenzaFile(invio_selezionato.IdInvio, codiceFondoPsc); 

                if (igruee_log_collection.Count == 0)
                {
                    dgInvioLogPsc.Titolo = "Nessun esito presente.";
                }
                else
                {
                    dgInvioLogPsc.Titolo = "Selezionare l'esito per visualizzare il dettaglio";

                    if (igruee_log_collection[0].IstanzaErrori != null)
                        btnRichiediValidazionePsc.Enabled = false;
                }

                dgInvioLogPsc.DataSource = igruee_log_collection;
                //dgInvioLogPsc.SetTitoloNrElementi();
                dgInvioLogPsc.ItemDataBound += new DataGridItemEventHandler(dgInvioLog_ItemDataBound);
                dgInvioLogPsc.DataBind();
            }
        }

        protected void popolaDgDettaglioErroriPsc()
        {
            if (log_selezionato != null && log_selezionato.IstanzaErrori != null)
            {
                divDettaglioErroriPsc.Visible = true;

                int id_log = log_selezionato.IdIgrueLogErrori;
                var xml_log_errori = puc_operazioni.GetXmlLogErrori(id_log);

                try
                {
                    SiarBLL.LogRoot entity = FromXml<SiarBLL.LogRoot>(xml_log_errori);
                    txtIdInvioErrorePsc.Text = entity.IdInvio;
                    txtIdTicketErrorePsc.Text = entity.IdTicket;

                    var elenco_errori_collection = entity.LogEntry;
                    dgLogErroriPsc.DataSource = elenco_errori_collection;
                    dgLogErroriPsc.ItemDataBound += new DataGridItemEventHandler(dgLogErrori_ItemDataBound);
                    dgLogErroriPsc.DataBind();
                }
                catch (Exception ex) { ShowError(ex.ToString()); }
            }
        }

        #endregion Metodi Psc 

        #region Metodi Poc

        protected void popolaCampiNascostiPoc()
        {
            igrue_invio_provider = new IgrueInvioCollectionProvider();
            igruee_log_provider = new IgrueLogErroriCollectionProvider();
            puc_operazioni = new PucOperazioni();

            int id_invio;
            if (int.TryParse(hdnIdInvioPoc.Value, out id_invio))
                invio_selezionato = igrue_invio_provider.GetByIdInvio(id_invio)[0];

            int id_log_errori;
            if (int.TryParse(hdnIdLogErroriPoc.Value, out id_log_errori))
                log_selezionato = igruee_log_provider.GetById(id_log_errori);
        }

        protected void svuotaCampiNascostiPoc()
        {
            hdnIdInvioPoc.Value = null;
            hdnIdLogErroriPoc.Value = null;
        }

        protected void popolaDgIgrueeInviiPoc()
        {
            IgrueInvioCollection igruee_invii_collection;
            if (invio_selezionato != null)
            {
                igruee_invii_collection = new IgrueInvioCollection
                {
                    invio_selezionato
                };
                dgIgrueInviiPoc.Titolo = "Selezionare per ritornare all'elenco degli invii ad Igrue.";
            }
            else
            {
                igruee_invii_collection = igrue_invio_provider.GetDataInvioDaASenzaFile(null, null, codiceFondoPoc);

                if (igruee_invii_collection.Count == 0)
                    dgIgrueInviiPoc.Titolo = "Nessun invio di monitoraggio Igrue presente.";
                else
                    dgIgrueInviiPoc.Titolo = "Selezionare l'invio per visualizzare il dettaglio";
            }

            dgIgrueInviiPoc.DataSource = igruee_invii_collection;
            //dgIgrueInviiPsc.SetTitoloNrElementi();
            dgIgrueInviiPoc.ItemDataBound += new DataGridItemEventHandler(dgIgrueInvii_ItemDataBound);
            dgIgrueInviiPoc.DataBind();
        }

        protected void popolaDgDettaglioInvioPoc()
        {
            if (invio_selezionato != null)
            {
                divDettaglioPoc.Visible = true;

                var igruee_log_collection = igruee_log_provider.GetByIdInvioSenzaFile(invio_selezionato.IdInvio, codiceFondoPoc);

                if (igruee_log_collection.Count == 0)
                {
                    dgInvioLogPoc.Titolo = "Nessun esito presente.";
                }
                else
                {
                    dgInvioLogPoc.Titolo = "Selezionare l'esito per visualizzare il dettaglio";

                    if (igruee_log_collection[0].IstanzaErrori != null)
                        btnRichiediValidazionePoc.Enabled = false;
                }

                dgInvioLogPoc.DataSource = igruee_log_collection;
                //dgInvioLogPsc.SetTitoloNrElementi();
                dgInvioLogPoc.ItemDataBound += new DataGridItemEventHandler(dgInvioLog_ItemDataBound);
                dgInvioLogPoc.DataBind();
            }
        }

        protected void popolaDgDettaglioErroriPoc()
        {
            if (log_selezionato != null && log_selezionato.IstanzaErrori != null)
            {
                divDettaglioErroriPoc.Visible = true;

                int id_log = log_selezionato.IdIgrueLogErrori;
                var xml_log_errori = puc_operazioni.GetXmlLogErrori(id_log);

                try
                {
                    SiarBLL.LogRoot entity = FromXml<SiarBLL.LogRoot>(xml_log_errori);
                    txtIdInvioErrorePoc.Text = entity.IdInvio;
                    txtIdTicketErrorePoc.Text = entity.IdTicket;

                    var elenco_errori_collection = entity.LogEntry;
                    dgLogErroriPoc.DataSource = elenco_errori_collection;
                    dgLogErroriPoc.ItemDataBound += new DataGridItemEventHandler(dgLogErrori_ItemDataBound);
                    dgLogErroriPoc.DataBind();
                }
                catch (Exception ex) { ShowError(ex.ToString()); }
            }
        }

        #endregion

        protected T FromXml<T>(String xml)
        {
            T returnedXmlClass = default(T);

            try
            {
                using (TextReader reader = new StringReader(xml))
                {
                    try
                    {
                        returnedXmlClass = (T)new XmlSerializer(typeof(T)).Deserialize(reader);
                    }
                    catch (InvalidOperationException ioe)
                    {
                        // String passed is not XML, simply return defaultXmlClass
                        ShowError(ioe.ToString());
                    }
                }
            }
            catch (Exception ex) { ShowError(ex.ToString()); }

            return returnedXmlClass;
        }

        protected string GetTracciatiSelezionati(string CodiceFondo)
        {
            string tracciati = "";

            if (rblTipiTracciati.SelectedValue == "1")
            {
                List<string> selectedValues = cblTracciatiInvio.Items.Cast<ListItem>()
                   .Where(li => li.Selected)
                   .Select(li => li.Value)
                   .ToList();

                tracciati = string.Join(",", selectedValues.ToArray());

                if (tracciati.EndsWith(","))
                    tracciati = tracciati.TrimEnd(','); 
            }
            else
            {
                switch (CodiceFondo)
                {
                    case codiceFondoITI: //Fondo ITI
                        tracciati = txtFiles.Value;
                        break;
                    case codiceFondoFesr2020: //Fondo FESR
                        tracciati = txtFilesLeggeStabilita.Value;
                        break;
                    case codiceFondoPsc: // Fondo PSC 
                        tracciati = txtFilesPsc.Value;
                        break;
                    case codiceFondoPoc: // Fondo POC 
                        tracciati = txtFilesPoc.Value;
                        break;
                }
            }

            return tracciati;
        }

        protected string GetTracciatiSelezionatiEliminazione(string CodiceFondo)
        {
            string tracciati = "";

            if (rblTipiTracciatiEliminazione.SelectedValue == "1")
            {
                List<string> selectedValues = cblTracciatiEliminazione.Items.Cast<ListItem>()
                   .Where(li => li.Selected)
                   .Select(li => li.Value)
                   .ToList();

                tracciati = string.Join(",", selectedValues.ToArray());

                if (tracciati.EndsWith(","))
                    tracciati = tracciati.TrimEnd(',');
            }
            else
            {
                switch (CodiceFondo)
                {
                    case codiceFondoITI: //Fondo ITI
                        tracciati = txtFiles.Value;
                        break;
                    case codiceFondoFesr2020: //Fondo FESR
                        tracciati = txtFilesLeggeStabilita.Value;
                        break;
                    case codiceFondoPsc: // Fondo PSC 
                        tracciati = txtFilesPsc.Value;
                        break;
                    case codiceFondoPoc: // Fondo PSC 
                        tracciati = txtFilesPoc.Value;
                        break;
                }
            }

            return tracciati;
        }

        #region Button event

        protected void btnPost_Click(object sender, EventArgs e) { }

        protected void btnInviaDatiSingoli_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.Configuration.ConfigurationManager.AppSettings["APP:TipoInstallazione"] != "Produzione")
                    throw new Exception("E' possibile inviare i dati di monitoraggio solamente in produzione.");

                var puc = new PucOperazioni();

                var codiceFondo = rblProgrammazione.SelectedValue;

                var IdProgetti = txtIdProgetti.Text;
                if (IdProgetti == null || IdProgetti == "")
                    throw new Exception("Id domande di aiuto non inseriti");
                var progetti = IdProgetti.Split(',');
                var progetti_esistenti = new ProgettoCollectionProvider().VerificaProgettiEsistenti(IdProgetti);
                if (progetti_esistenti < progetti.Length)
                    throw new Exception("Non tutte le domande di aiuto risultano esistenti: correggere e riprovare");

                string tracciati = GetTracciatiSelezionati(codiceFondo);
                if (tracciati == null || tracciati == "")
                    throw new Exception("Selezionare almeno un tracciato");

                var result = puc.InviaMonitoraggio(null, null, tracciati.Split(','), IdProgetti, codiceFondo);
                if (result.CodiceEsito == 0)
                    ShowMessage(result.DescrizioneEsito + ": " + result.DettaglioEsito);

                //ShowMessage("Progetti trovati: " + progetti_esistenti + "<br/><br/>Tracciati selezionati: " + tracciati);

                ucSiarNewTab.TabSelected = 1;
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        protected void btnInviaFileCancellazione_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.Configuration.ConfigurationManager.AppSettings["APP:TipoInstallazione"] != "Produzione")
                    throw new Exception("E' possibile inviare i file di eliminazione solamente in produzione.");

                var puc = new PucOperazioni();

                var codiceFondo = rblProgrammazioneEliminazione.SelectedValue;

                if (txtIdInvioEliminazione.Text == null || txtIdInvioEliminazione.Text == "")
                    throw new Exception("Inserire l'id dell'invio");
                var id_invio_eliminazione = int.Parse(txtIdInvioEliminazione.Text);

                string tracciati = GetTracciatiSelezionatiEliminazione(codiceFondo);
                if (tracciati == null || tracciati == "")
                    throw new Exception("Selezionare almeno un tracciato");

                ResultInfo result = null;

                var tipo_eliminazione = int.Parse(rblTipoEliminazione.SelectedValue);
                switch (tipo_eliminazione)
                {
                    case eliminazioneFile:
                        result = puc.SendProgettiDelete(tracciati.Split(','), id_invio_eliminazione, rblProgrammazioneEliminazione.SelectedValue);
                        break;
                    case eliminazioneIdProgetti:
                        char[] charSeparators = new char[] { ',' };
                        if (string.IsNullOrEmpty(txtIdProgettiEliminazione.Text) && string.IsNullOrEmpty(txtNumRigheEliminazione.Text))
                            throw new Exception("Gli Id delle domande di aiuto e i numeri di riga da eliminare non possono essere entrambi vuoti");

                        var IdProgetti = txtIdProgettiEliminazione.Text == null ? string.Empty : txtIdProgettiEliminazione.Text;
                        var progetti = IdProgetti.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

                        var righe_inserite = txtNumRigheEliminazione.Text == null ? string.Empty : txtNumRigheEliminazione.Text;
                        var righe = righe_inserite.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

                        result = puc.SendProgettiDelete(tracciati, id_invio_eliminazione, progetti, righe, rblProgrammazioneEliminazione.SelectedValue);
                        break;
                    case eliminazioneSQL:
                        result = puc.SendProgettiDelete(tracciati, id_invio_eliminazione, txtFiltroSQLEliminazione.Text, rblProgrammazioneEliminazione.SelectedValue);
                        break;
                    default:
                        throw new Exception("Che modalità hai scelto?");
                }

                if (result.CodiceEsito == 0)
                    ShowMessage(result.DescrizioneEsito + ": " + result.DettaglioEsito);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        #region click Fesr

        protected void btnInviaDatiMonitoraggioFesr_Click(object sender, EventArgs e) 
        {
            try
            {
                if (System.Configuration.ConfigurationManager.AppSettings["APP:TipoInstallazione"] != "Produzione")
                    throw new Exception("E' possibile inviare i dati di monitoraggio solamente in produzione.");

                var puc = new PucOperazioni();

                List<BandoInfo> bandi = new List<BandoInfo>();
                bandi = puc.CheckBandiAttivazione(codiceFondoFesr2020);
                if (bandi != null)
                {
                    string msg = "<span>I seguenti bandi non hanno codice di attivazione: </span><br/>";
                    foreach (BandoInfo item in bandi)
                    {
                        msg += "<span>id bando: " + item.ID_BANDO.ToString() + " : " + item.DESCRIZIONE + "</span><br/>";
                    }
                    lblErroriInvioFesr.Text = msg;
                    return;
                }

                var result = puc.InviaMonitoraggio(null, null, txtFiles.Value.Split(','), codiceFondoFesr2020);
                if (result.CodiceEsito == 0)
                    ShowMessage(result.DescrizioneEsito + ": " + result.DettaglioEsito);
            }
            catch (Exception ex) { ShowError(ex.ToString()); }
        }

        protected void btnRichiediValidazioneFesr_Click(object sender, EventArgs e) 
        {
            try
            {
                popolaCampiNascostiFesr();

                if (invio_selezionato != null)
                {
                    if (puc_operazioni.GetLogErrori(invio_selezionato.IdTicket, codiceFondoFesr2020).DettaglioEsito == "UNKNOWN")
                        ShowMessage("Log errori ricevuto.");
                    else
                        ShowError("Nessun log errori ricevuto.");
                }
                else
                    ShowError("Nessun invio selezionato.");
            }
            catch (Exception ex) { ShowError(ex.ToString()); }
        }

        protected void btnDownloadFileInvioFesr_Click(object sender, EventArgs e) 
        {
            popolaCampiNascostiFesr();

            if (invio_selezionato != null) 
            {
                int id_invio = invio_selezionato.IdInvio;
                var file = puc_operazioni.GetFileInvio(id_invio);

                if (file != null)
                {
                    Session["evita_controllo_date_sessione"] = "true";
                    string filename = "invio_" + id_invio.ToString() + ".zip";

                    ArchivioFileCollection docs = new ArchivioFileCollection();
                    ArchivioFile a = new ArchivioFile();
                    a.Contenuto = file;
                    a.Dimensione = file.Length;
                    a.NomeFile = filename;
                    a.NomeCompleto = filename;

                    docs.Add(a);
                    Session["siar_view_file"] = docs;
                    string url_location = "getBaseUrl()+'VisualizzaDocumento.aspx'";
                    RegisterClientScriptBlock("window.open(" + url_location + ");");
                }
                else
                    ShowError("File mancante!");
                
            }
            else
                ShowError("Nessun invio selezionato.");
        }

        #endregion click Fesr

        #region click ITI

        protected void btnInviaDatiMonitoraggioLeggeStabilita_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.Configuration.ConfigurationManager.AppSettings["APP:TipoInstallazione"] != "Produzione")
                    throw new Exception("E' possibile inviare i dati di monitoraggio solamente in produzione.");

                var puc = new PucOperazioni();

                List<BandoInfo> bandi = new List<BandoInfo>();
                bandi = puc.CheckBandiAttivazione(codiceFondoITI);
                if (bandi != null)
                {
                    string msg = "<span>I seguenti bandi non hanno codice di attivazione: </span><br/>";
                    foreach (BandoInfo item in bandi)
                    {
                        msg += "<span>id bando: " + item.ID_BANDO.ToString() + " : " + item.DESCRIZIONE + "</span><br/>";
                    }
                    lblErroriInvioLeggeStabilita.Text = msg;
                    return;
                }

                var result = puc.InviaMonitoraggio(null, null, txtFilesLeggeStabilita.Value.Split(','), codiceFondoITI);
                if (result.CodiceEsito == 0)
                    ShowMessage(result.DescrizioneEsito + ": " + result.DettaglioEsito);
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        protected void btnRichiediValidazioneLeggeStabilita_Click(object sender, EventArgs e)
        {
            try
            {
                popolaCampiNascostiLeggeStabilita();

                if (invio_selezionato != null)
                {
                    if (puc_operazioni.GetLogErrori(invio_selezionato.IdTicket, codiceFondoITI).DettaglioEsito == "UNKNOWN")
                        ShowMessage("Log errori ricevuto.");
                    else
                        ShowError("Nessun log errori ricevuto.");
                }
                else
                    ShowError("Nessun invio selezionato.");
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        protected void btnDownloadFileInvioLeggeStabilita_Click(object sender, EventArgs e)
        {
            popolaCampiNascostiLeggeStabilita();

            if (invio_selezionato != null)
            {
                int id_invio = invio_selezionato.IdInvio;
                var file = puc_operazioni.GetFileInvio(id_invio);

                if (file != null)
                {
                    Session["evita_controllo_date_sessione"] = "true";
                    string filename = "invio_" + id_invio.ToString() + ".zip";

                    ArchivioFileCollection docs = new ArchivioFileCollection();
                    ArchivioFile a = new ArchivioFile();
                    a.Contenuto = file;
                    a.Dimensione = file.Length;
                    a.NomeFile = filename;
                    a.NomeCompleto = filename;

                    docs.Add(a);
                    Session["siar_view_file"] = docs;
                    string url_location = "getBaseUrl()+'VisualizzaDocumento.aspx'";
                    RegisterClientScriptBlock("window.open(" + url_location + ");");
                }
                else
                    ShowError("File mancante!");

            }
            else
                ShowError("Nessun invio selezionato.");
        }

        #endregion click ITI

        #region click Psc 

        protected void btnInviaDatiMonitoraggioPsc_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.Configuration.ConfigurationManager.AppSettings["APP:TipoInstallazione"] != "Produzione")
                    throw new Exception("E' possibile inviare i dati di monitoraggio solamente in produzione.");

                var puc = new PucOperazioni();

                List<BandoInfo> bandi = new List<BandoInfo>();
                bandi = puc.CheckBandiAttivazione(codiceFondoPsc);  
                if (bandi != null)
                {
                    string msg = "<span>I seguenti bandi non hanno codice di attivazione: </span><br/>";
                    foreach (BandoInfo item in bandi)
                    {
                        msg += "<span>id bando: " + item.ID_BANDO.ToString() + " : " + item.DESCRIZIONE + "</span><br/>";
                    }
                    lblErroriInvioPsc.Text = msg;
                    return;
                }

                var result = puc.InviaMonitoraggio(null, null, txtFilesPsc.Value.Split(','), codiceFondoPsc); 
                if (result.CodiceEsito == 0)
                    ShowMessage(result.DescrizioneEsito + ": " + result.DettaglioEsito);
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        protected void btnRichiediValidazionePsc_Click(object sender, EventArgs e)
        {
            try
            {
                popolaCampiNascostiPsc();

                if (invio_selezionato != null)
                {
                    if (puc_operazioni.GetLogErrori(invio_selezionato.IdTicket, codiceFondoPsc).DettaglioEsito == "UNKNOWN") 
                        ShowMessage("Log errori ricevuto.");
                    else
                        ShowError("Nessun log errori ricevuto.");
                }
                else
                    ShowError("Nessun invio selezionato.");
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        protected void btnDownloadFileInvioPsc_Click(object sender, EventArgs e)
        {
            popolaCampiNascostiPsc();

            if (invio_selezionato != null)
            {
                int id_invio = invio_selezionato.IdInvio;
                var file = puc_operazioni.GetFileInvio(id_invio);

                if (file != null)
                {
                    Session["evita_controllo_date_sessione"] = "true";
                    string filename = "invio_" + id_invio.ToString() + ".zip";

                    ArchivioFileCollection docs = new ArchivioFileCollection();
                    ArchivioFile a = new ArchivioFile();
                    a.Contenuto = file;
                    a.Dimensione = file.Length;
                    a.NomeFile = filename;
                    a.NomeCompleto = filename;

                    docs.Add(a);
                    Session["siar_view_file"] = docs;
                    string url_location = "getBaseUrl()+'VisualizzaDocumento.aspx'";
                    RegisterClientScriptBlock("window.open(" + url_location + ");");
                }
                else
                    ShowError("File mancante!");

            }
            else
                ShowError("Nessun invio selezionato.");
        }

        #endregion click Psc 

        #region click Poc

        protected void btnInviaDatiMonitoraggioPoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.Configuration.ConfigurationManager.AppSettings["APP:TipoInstallazione"] != "Produzione")
                    throw new Exception("E' possibile inviare i dati di monitoraggio solamente in produzione.");

                var puc = new PucOperazioni();

                List<BandoInfo> bandi = new List<BandoInfo>();
                bandi = puc.CheckBandiAttivazione(codiceFondoPoc);
                if (bandi != null)
                {
                    string msg = "<span>I seguenti bandi non hanno codice di attivazione: </span><br/>";
                    foreach (BandoInfo item in bandi)
                    {
                        msg += "<span>id bando: " + item.ID_BANDO.ToString() + " : " + item.DESCRIZIONE + "</span><br/>";
                    }
                    lblErroriInvioPsc.Text = msg;
                    return;
                }

                var result = puc.InviaMonitoraggio(null, null, txtFilesPsc.Value.Split(','), codiceFondoPoc);
                if (result.CodiceEsito == 0)
                    ShowMessage(result.DescrizioneEsito + ": " + result.DettaglioEsito);
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        protected void btnRichiediValidazionePoc_Click(object sender, EventArgs e)
        {
            try
            {
                popolaCampiNascostiPoc();

                if (invio_selezionato != null)
                {
                    if (puc_operazioni.GetLogErrori(invio_selezionato.IdTicket, codiceFondoPoc).DettaglioEsito == "UNKNOWN")
                        ShowMessage("Log errori ricevuto.");
                    else
                        ShowError("Nessun log errori ricevuto.");
                }
                else
                    ShowError("Nessun invio selezionato.");
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        protected void btnDownloadFileInvioPoc_Click(object sender, EventArgs e)
        {
            popolaCampiNascostiPoc();

            if (invio_selezionato != null)
            {
                int id_invio = invio_selezionato.IdInvio;
                var file = puc_operazioni.GetFileInvio(id_invio);

                if (file != null)
                {
                    Session["evita_controllo_date_sessione"] = "true";
                    string filename = "invio_" + id_invio.ToString() + ".zip";

                    ArchivioFileCollection docs = new ArchivioFileCollection();
                    ArchivioFile a = new ArchivioFile();
                    a.Contenuto = file;
                    a.Dimensione = file.Length;
                    a.NomeFile = filename;
                    a.NomeCompleto = filename;

                    docs.Add(a);
                    Session["siar_view_file"] = docs;
                    string url_location = "getBaseUrl()+'VisualizzaDocumento.aspx'";
                    RegisterClientScriptBlock("window.open(" + url_location + ");");
                }
                else
                    ShowError("File mancante!");

            }
            else
                ShowError("Nessun invio selezionato.");
        }

        #endregion

        #endregion Button event

        #region ItemDataBound

        void dgIgrueInvii_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType == ListItemType.Header)
            {
                //dgi.Cells[0].RowSpan = 2;
                //dgi.Cells[1].ColumnSpan = 5;
                //dgi.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                //dgi.Cells[1].Text = "INTERVENTI</td><td colspan=3></td><td colspan=6 align=center>SPESA IRREGOLARE</td><td colspan=3></td><td colspan=7 align=center>SPESA RECUPERATA</td><td colspan=3></td></tr><tr class='TESTA'><td>";
            }
            else if (e.Item.ItemType != ListItemType.Footer) 
            {
                IgrueInvio invio = (IgrueInvio)e.Item.DataItem;

                if (invio.DataInvio != null)
                    e.Item.Cells[2].Text = invio.DataInvio.ToString("dd/MM/yyyy HH:mm:ss");

                if (invio.TimestampEsito != null)
                    e.Item.Cells[3].Text = invio.TimestampEsito.ToString("dd/MM/yyyy HH:mm:ss");

                if (invio.DataRichiesta != null)
                    e.Item.Cells[4].Text = invio.DataRichiesta.ToString("dd/MM/yyyy HH:mm:ss");

                if (invio.TimestampEsitoLog != null)
                    e.Item.Cells[5].Text = invio.TimestampEsitoLog.ToString("dd/MM/yyyy HH:mm:ss");

                if (invio.IstanzaErrori != null)
                    dgi.Cells[6].Text = e.Item.Cells[6].Text.Replace("<input", "<input checked"); //e.Item.Cells[6].Text = "Visualizza errori";
                else
                    dgi.Cells[6].Text = e.Item.Cells[6].Text.Replace("checked", "");
            }
        }

        void dgInvioLog_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType == ListItemType.Header)
            {
            }
            else if (e.Item.ItemType != ListItemType.Footer)
            {
                IgrueLogErrori riga_log = (IgrueLogErrori)e.Item.DataItem;

                if (riga_log.DataRichiesta != null)
                    e.Item.Cells[1].Text = riga_log.DataRichiesta.ToString("dd/MM/yyyy HH:mm:ss");

                if (riga_log.TimestampEsito != null)
                    e.Item.Cells[4].Text = riga_log.TimestampEsito.ToString("dd/MM/yyyy HH:mm:ss");

                if (riga_log.IstanzaErrori != null)
                    e.Item.Cells[5].Text = "Visualizza errori";
            }
        }

        void dgLogErrori_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType == ListItemType.Header)
            {
            }
            else if (e.Item.ItemType != ListItemType.Footer)
            {
                LogRecord riga_errore = (LogRecord)e.Item.DataItem;

            }
        }

        #endregion
    }
}