using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FirmaRemotaManager;
using SiarBLL;
using SiarLibrary;

namespace web.Private.Istruttoria
{
    public partial class CorrezioneFirmaMassivaValutazione : SiarLibrary.Web.PrivatePage
    {
        protected string dataToSign { get; set; }

        private VistruttoriaDomandeCollectionProvider istruttoria_provider;
        private BandoCollectionProvider bando_provider;
        private ProgettoCollectionProvider progetto_provider;
        private ProgettoValutazioneCollectionProvider valutazione_provider;
        private IterProgettoCollectionProvider iter_provider;
        private ImpresaCollectionProvider impresa_provider;
        private ProgettoSegnatureCollectionProvider progetto_segnature_provider;
        private ProgettoStoricoCollectionProvider progetto_storico_provider;

        private BandoValutatoriCollectionProvider valutatori_bando_provider;
        private ProgettoValutatoriCollectionProvider valutatori_progetto_provider;
        private ProgettiErroreFirmaMassivaOperatoriFirmaCollectionProvider progetti_errore_provider;

        string nome_documento = "VERBALE_VALUTAZIONE_DOMANDA-";

        #region Indici colonne Datagrid

        private int col_Nr = 0,
            col_IdBando = 1,
            col_DescrizioneBando = 2,
            col_IdDomanda = 3,
            col_Piva = 4,
            col_RagioneSociale = 5,
            //col_Sede = 6,
            col_VaiChecklist = 6,
            col_Check = 7;

        #endregion

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "correzione_firma_massiva_valutazione";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            InizializzaProvider();
            var id_utente = Operatore.Utente.IdUtente;

            var progetti_istruttore_correzione_list = progetti_errore_provider
                .FindProgettiUtente(id_utente, 0, null)
                .ToArrayList<ProgettiErroreFirmaMassivaOperatoriFirma>();

            dgFirmeValutazione.Titolo = "Elenco delle domande in valutazione da correggere di competenza dell'operatore: " + progetti_istruttore_correzione_list.Count.ToString();
            dgFirmeValutazione.DataSource = progetti_istruttore_correzione_list;
            dgFirmeValutazione.DataBind();

            base.OnPreRender(e);
        }

        private void InizializzaProvider()
        {
            istruttoria_provider = new VistruttoriaDomandeCollectionProvider();
            bando_provider = new BandoCollectionProvider();
            progetto_provider = new ProgettoCollectionProvider();
            valutazione_provider = new ProgettoValutazioneCollectionProvider();
            iter_provider = new IterProgettoCollectionProvider();
            impresa_provider = new ImpresaCollectionProvider();
            progetto_segnature_provider = new ProgettoSegnatureCollectionProvider();
            progetto_storico_provider = new ProgettoStoricoCollectionProvider();

            valutatori_bando_provider = new BandoValutatoriCollectionProvider();
            valutatori_progetto_provider = new ProgettoValutatoriCollectionProvider();
            progetti_errore_provider = new ProgettiErroreFirmaMassivaOperatoriFirmaCollectionProvider();
        }

        private void SvuotaCampiHidden()
        {
            hdnJsonDatiFirma.Value = null;
            hdnDataToSign.Value = null;
            hdnSignedData.Value = null;
            hdnIdProgettiFirma.Value = null;
        }

        private string VerificaChecklist(Progetto _progetto)
        {
            try
            {
                var esito = iter_provider.VerificaCheckListDomandaDiAiuto(_progetto.IdProgetto, null, "A", Operatore.Utente.CfUtente);

                return esito;
            }
            catch (Exception ex) { return ex.Message; }
        }

        private string VerificaChecklistSelezionati(List<int> id_progetti_list)
        {
            int esiti_positivi = 0;
            int esiti_negativi = 0;
            int senza_checklist = 0;

            //Dei progetti assegnati all'istruttore prendo solo quelli selezionati
            //Se li ho selezionati fanno già parte di quelli che non sono in un comitato di valutazione
            var progetti_istruttore_list = istruttoria_provider
                .Find(null, null, Operatore.Utente.IdUtente, null, null, null, null, "I", null)
                .ToArrayList<VistruttoriaDomande>();

            var progetti_verifica_list = progetti_istruttore_list
                .Where(p => id_progetti_list.Any(id => id == p.IdProgetto));

            foreach (VistruttoriaDomande istruttoria in progetti_verifica_list)
            {
                var prog = progetto_provider.GetById(istruttoria.IdProgetto);
                string sing_esito = VerificaChecklist(prog);

                switch (sing_esito)
                {
                    case "SI":
                        esiti_positivi++;
                        break;
                    case "NO":
                        esiti_negativi++;
                        break;
                    default:
                        senza_checklist++;
                        break;
                }
            }

            string esito = @"Riepilogo della verifica delle domande selezionate: <br/>" +
                "- " + esiti_positivi + " domande hanno avuto esito positivo; <br/>" +
                "- " + esiti_negativi + " domande hanno avuto esito negativo; <br/>" +
                "- " + senza_checklist + " domande non hanno una checklist associata. <br/>";

            return esito;
        }

        protected byte[] GetDocumentoSingoloFromServer(int idProgetto)
        {
            byte[] report;

            //Cerco la valutazione del progetto: 
            //se c'è già un file presente recupero quello che è già firmato dai valutatori precedenti
            //altrimenti do errore perché in teoria il file della valutazione c'è essendo già firmata
            var valutazioni = valutazione_provider
                .Find(idProgetto, null, true, null, false)
                .ToArrayList<ProgettoValutazione>();

            if (valutazioni.Count() == 1)
            {
                var valutazione_progetto = valutazioni.ElementAt(0);

                if (valutazione_progetto.IdFile != null)
                {
                    var file_provider = new ArchivioFileCollectionProvider();
                    var af = file_provider.GetById(valutazione_progetto.IdFile);

                    report = af.Contenuto;
                }
                else
                    throw new Exception("- La domanda <b>" + idProgetto + "</b> è stata elaborata <b>non correttamente</b> perchè manca il documento della valutazione </br>");
            }
            else
                throw new Exception("- La domanda <b>" + idProgetto + "</b> è stata elaborata <b>non correttamente</b> perchè manca la valutazione </br>");

            return report;
        }

        protected string ProtocollaSingoloDocumento(byte[] file_firmato, int id_progetto)
        {
            try
            {
                valutazione_provider.DbProviderObj.BeginTran();
                progetti_errore_provider = new ProgettiErroreFirmaMassivaOperatoriFirmaCollectionProvider(valutazione_provider.DbProviderObj);
                bando_provider = new BandoCollectionProvider(valutazione_provider.DbProviderObj);
                var file_provider = new ArchivioFileCollectionProvider(valutazione_provider.DbProviderObj);

                var progetto = progetto_provider.GetById(id_progetto);
                var bando = bando_provider.GetById(progetto.IdBando);

                var cerca_correzione = progetti_errore_provider
                    .FindProgettiUtente(Operatore.Utente.IdUtente, 0, id_progetto)
                    .ToArrayList<ProgettiErroreFirmaMassivaOperatoriFirma>();
                
                //Cerco la correzione e la valutazione
                if (cerca_correzione.Count() != 1)
                    throw new Exception("- La domanda <b>" + id_progetto + "</b> è stata elaborata <b>NON CORRETTAMENTE</b> perchè manca la valutazione </br>");

                var correzione = cerca_correzione.ElementAt(0);
                var valutazione = valutazione_provider.GetById(correzione.IdProgettoValutazione);
                
                //Aggiorno il file della valutazione con il nuovo firmato
                ArchivioFile af = null;

                if (valutazione.IdFile != null)
                    af = file_provider.GetById(valutazione.IdFile);
                else
                {
                    af = new ArchivioFile();
                    af.Tipo = "application/pdf";
                    af.NomeFile = "valutazione_" + valutazione.IdProgetto + ".pdf";
                    af.NomeCompleto = "valutazione progetto " + valutazione.IdProgetto + ".pdf";
                }

                af.Contenuto = file_firmato;
                af.Dimensione = file_firmato.Length;

                file_provider.Save(af);
                valutazione.IdFile = af.Id;

                //Segno la correzione come firmata
                correzione.FirmaUtentePresente = 1;
                progetti_errore_provider.Save(correzione);

                //Verifico se hanno firmato tutti, se si aggiorno il documento nel protocollo
                var correzione_list = progetti_errore_provider
                    .FindFirmeValutazione(valutazione.Id)
                    .ToArrayList<ProgettiErroreFirmaMassivaOperatoriFirma>();

                var firme_presenti = correzione_list.Sum(c => c.FirmaUtentePresente);
                var firme_presenti_bool = false;
                string documento_aggiornato = null;

                if (correzione_list.Count() == firme_presenti)
                {
                    firme_presenti_bool = true;

                    Protocollo proto = new Protocollo(bando.CodEnte);
                    proto.setDocumento("valutazione_domanda_" + progetto.IdProgetto + ".pdf", file_firmato);
                    try
                    {
                        documento_aggiornato = proto.AddVersioneDocumento(valutazione.Segnatura, "Aggiunta versione del file correttamente firmato da tutti i valutatori");
                    }
                    catch(Exception ex)
                    {
                        throw new Exception("- La domanda <b>" + id_progetto + "</b> è stata elaborata <b>NON CORRETTAMENTE</b>, errore: " + ex.Message + " </br>");
                    }
                }

                if (test_locale.Value != "true") 
                {
                    valutazione_provider.Save(valutazione);
                    valutazione_provider.DbProviderObj.Commit();
                }

                string successo = "- La domanda <b>" + id_progetto + "</b> è stata elaborata <b>correttamente</b>";
                if (firme_presenti_bool)
                    successo += " e sono presenti tutte le firme, " + documento_aggiornato + " <br/>";
                else
                    successo += " <br/>";

                return successo;
            }
            catch (Exception ex)
            {
                valutazione_provider.DbProviderObj.Rollback();
                return (ex.Message);
            }
        }

        private void LogSign(LogInfo logInfo)
        {
            try
            {
                var logger = new Logger();
                logger.SaveLogFirma(logInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void dgFirmeValutazione_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;

            if (dgi.ItemType == ListItemType.Header)
            {
                dgi.CssClass = "TESTA1";
                dgi.Cells[col_Nr].ColumnSpan = 1;
                dgi.Cells[col_Nr].HorizontalAlign = HorizontalAlign.Center;
                dgi.Cells[col_Nr].Text = "</td><td colspan=2 align=center>BANDO</td><td colspan=3 align=center>DOMANDA DI AIUTO</td><td></td><td></td></tr><tr class='TESTA'><td>Nr.";
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var istruttoria = (ProgettiErroreFirmaMassivaOperatoriFirma)dgi.DataItem;
                var bando = bando_provider.GetById(istruttoria.IdBando);
                var progetto = progetto_provider.GetById(istruttoria.IdProgetto);
                var impresa = impresa_provider.GetById(progetto.IdImpresa);

                dgi.Cells[col_DescrizioneBando].Text = bando.Descrizione;
                dgi.Cells[col_Piva].Text = impresa.Cuaa;
                dgi.Cells[col_RagioneSociale].Text = impresa.RagioneSociale;
                //dgi.Cells[col_Sede].Text = istruttoria.Comune + " (" + istruttoria.Sigla + ") - " + istruttoria.Cap;
            }
        }

        #region Button Click

        protected void btnVerificaRequisiti_Click(object sender, EventArgs e)
        {
            InizializzaProvider();
            string[] selezionati = ((SiarLibrary.Web.CheckColumn)dgFirmeValutazione.Columns[col_Check]).GetSelected();

            if (selezionati.Length > 0)
            {
                List<int> id_progetti_list = selezionati.Select(int.Parse).ToList();

                string esito = VerificaChecklistSelezionati(id_progetti_list);

                ShowMessage(esito);
            }
            else
                ShowError("Nessuna domanda selezionata.");
        }

        protected void btnFirmaMassivaValutazione_Click(object sender, EventArgs e)
        {
            try
            {
                InizializzaProvider();
                string[] selezionati = ((SiarLibrary.Web.CheckColumn)dgFirmeValutazione.Columns[col_Check]).GetSelected();

                if (selezionati.Length > 0)
                {
                    int maxDocumentiFirma = 0;
                    int.TryParse(hdnMaxDocumentiFirma.Value, out maxDocumentiFirma);

                    if (selezionati.Length > maxDocumentiFirma)
                        throw new Exception("E' possibile firmare massivamente al massimo " + maxDocumentiFirma + " istruttorie di valutazione alla volta.");

                    List<int> id_progetti_list = selezionati.Select(int.Parse).ToList();
                    var progetti_firma_list = new List<Progetto>();

                    //Prendo l'elenco dei progetti
                    foreach (int id_progetto in id_progetti_list)
                    {
                        var prog = progetto_provider.GetById(id_progetto);
                        progetti_firma_list.Add(prog);
                    }

                    if (progetti_firma_list.Count > 0)
                    {
                        var reportCompilati = new List<byte[]>();
                        var identificativi_file = new List<string>();
                        string esito = "";

                        foreach (Progetto prog in progetti_firma_list)
                        {
                            var report = GetDocumentoSingoloFromServer(prog.IdProgetto); 
                            if (report == null || report.Length == 0)
                            {
                                esito += "Non è stato possibile generare il documento richiesto per il progetto " + prog.IdProgetto + "<br/>";
                                continue;
                            }

                            reportCompilati.Add(report);
                            identificativi_file.Add(nome_documento + prog.IdProgetto);
                        }

                        if (esito != "")
                            throw new Exception(esito);

                        if (reportCompilati.Count == 0)
                            throw new Exception("Nessun report compilato correttamente");

                        hdnIdProgettiFirma.Value = string.Join("|", identificativi_file.ToArray());

                        var dataToSign = CalamaioUtility.GetDataToSign(reportCompilati, Operatore.Utente.CfUtente, identificativi_file);
                        byte[] byt = System.Text.Encoding.UTF8.GetBytes(dataToSign);
                        hdnDataToSign.Value = Convert.ToBase64String(byt);

                        //ShowMessage("Posso firmare " + progetti_firma_list.Count + " domande");
                        RegisterClientScriptBlock("btnFirmaClick(); return false;"); 
                    }
                    else
                        ShowError("Non ho trovato nessuna domanda da firmare.");
                }
                else
                    ShowError("Nessuna domanda selezionata.");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnFirmaMassivaRemotaValutazione_Click(object sender, EventArgs e)
        {
            var logInfo = new LogInfo();
            string username_firma = txtUsernameRS.Value;
            string pin_firma = txtPasswordRS.Value;
            string otp_firma = txtOtpRS.Value;
            string dominio_firma = txtDominioRS.Value;
            if (!string.IsNullOrEmpty(dominio_firma) || !string.IsNullOrWhiteSpace(dominio_firma))
                logInfo.DominioFirma = dominio_firma;
            else
                logInfo.DominioFirma = "frRegioneMarche";
            logInfo.Operatore = username_firma;
            logInfo.TipoFirma = "remota";
            logInfo.TipoDocumento = "CorrezioneFirmaMassivaValutazione";

            string esito_firma = "OK";
            string dettaglioEsito = "firma effettuata con successo";

            try
            {
                InizializzaProvider();
                string[] selezionati = ((SiarLibrary.Web.CheckColumn)dgFirmeValutazione.Columns[col_Check]).GetSelected();

                if (selezionati.Length > 0)
                {
                    int maxDocumentiFirma = 0;
                    int.TryParse(hdnMaxDocumentiFirma.Value, out maxDocumentiFirma);

                    if (selezionati.Length > maxDocumentiFirma)
                        throw new Exception("E' possibile firmare massivamente al massimo " + maxDocumentiFirma + " istruttorie di valutazione alla volta.");

                    List<int> id_progetti_list = selezionati.Select(int.Parse).ToList();
                    var progetti_firma_list = new List<Progetto>();
                    string esito = "";

                    //Prendo l'elenco dei progetti
                    foreach (int id_progetto in id_progetti_list)
                    {
                        var prog = progetto_provider.GetById(id_progetto);
                        progetti_firma_list.Add(prog);
                    }

                    if (progetti_firma_list.Count > 0)
                    {
                        var reportCompilati = new List<byte[]>();
                        var identificativi_file = new List<string>();
                        
                        var rsclient = new FirmaRemotaOperazioni();
                        var request_list = new List<FirmaRemotaRequest>();

                        foreach (Progetto prog in progetti_firma_list)
                        {
                            var report = GetDocumentoSingoloFromServer(prog.IdProgetto);
                            if (report == null || report.Length == 0)
                            {
                                esito += "Non è stato possibile generare il documento richiesto per il progetto " + prog.IdProgetto + "<br/>";
                                continue;
                            }

                            reportCompilati.Add(report);
                            identificativi_file.Add(nome_documento + prog.IdProgetto);

                            var request = new FirmaRemotaRequest();
                            request.CfFirmatario = username_firma;
                            request.Pin = pin_firma;
                            request.Otp = otp_firma;
                            if (!string.IsNullOrEmpty(dominio_firma) || !string.IsNullOrWhiteSpace(dominio_firma))
                                request.Domain = dominio_firma;

                            request.IdFile = prog.IdProgetto;
                            request.NomeFile = nome_documento + prog.IdProgetto;
                            request.File = report;
                            request_list.Add(request);
                        }

                        //dati log
                        string parametriDocumento = string.Join("|", identificativi_file.ToArray());
                        logInfo.ParametriDocumento = parametriDocumento;

                        if (esito != "")
                            throw new Exception(esito);

                        if (reportCompilati.Count == 0)
                            throw new Exception("Nessun report compilato correttamente");

                        var response_list = rsclient.ArubaMultiRemoteSignWs(request_list);
                        foreach (FirmaRemotaResponse response in response_list)
                        {
                            int id_progetto = response.IdSignedFile ?? default(int);

                            if (string.IsNullOrEmpty(response.ErrorCode))
                            {
                                if (test_locale.Value != "true")
                                {
                                    esito += ProtocollaSingoloDocumento(response.SignedFile, id_progetto);
                                }
                                else
                                {
                                    File.WriteAllBytes(@"C:\test\" + response.NomeFile + "_firmato.pdf", response.SignedFile);
                                    esito += "- Domanda " + id_progetto + " elaborata_correttamente <br/>";
                                }
                            }
                            else
                            {
                                esito += "- Errore domanda " + id_progetto + " con codice: " + response.ErrorCode + ": " + response.ErrorDescription + "<br/>";
                                dettaglioEsito = "Errore domanda " + id_progetto + " con codice: " + response.ErrorCode + ": " + response.ErrorDescription + "|";
                            }
                        }

                        ShowMessage("Esito della protocollazione di " + response_list.Count + " valutazione ammissibilità:<br/><br/>" + esito);
                    }
                    else
                    {
                        esito_firma = "KO";
                        dettaglioEsito = "Nessuna domanda ha superato la checklist: impossibile continuare.";
                        ShowError("Nessuna domanda ha superato la checklist: impossibile continuare.");
                    }
                }
                else
                {
                    esito_firma = "KO";
                    dettaglioEsito = "Nessuna domanda selezionata.";
                    ShowError("Nessuna domanda selezionata.");
                }
            }
            catch (Exception ex)
            {
                esito_firma = "KO";
                dettaglioEsito = ex.Message;
                ShowError(ex.Message);
            }
            finally
            {
                logInfo.Esito = esito_firma;
                logInfo.DataFirma = DateTime.Now;
                logInfo.DettaglioEsito = dettaglioEsito;
                LogSign(logInfo);
            }
        }

        protected void btnProtocolla_Click(object sender, EventArgs e)
        {
            try
            {
                string xmlstring = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(hdnSignedData.Value));
                var signedFile = CalamaioUtility.ExtractSignedDataCalamaio1(xmlstring);
                string esito = "";

                foreach (SignInfo data in signedFile)
                {
                    InizializzaProvider();

                    var singolo_documento = Convert.FromBase64String(data.SignedData);
                    int id_progetto = int.Parse(data.DocumentIdentifier.Substring(nome_documento.Length));

                    if (test_locale.Value != "true")
                    {
                        esito += ProtocollaSingoloDocumento(singolo_documento, id_progetto);
                    }
                    else
                    {
                        File.WriteAllBytes(@"C:\test\" + data.DocumentIdentifier + "_firmato.pdf", singolo_documento);
                        esito += "- Domanda " + id_progetto + " elaborata_correttamente <br/>";
                    }
                }

                ShowMessage("Esito della firma di " + signedFile.Count + " valutazione ammissibilità:<br/><br/>" + esito);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            finally
            {
                SvuotaCampiHidden();
            }
        }

        protected void btnVaiAChecklist_Click(object sender, EventArgs e)
        {
            InizializzaProvider();

            int id_progetto;
            if (int.TryParse(hdnIdProgetto.Value, out id_progetto))
            {
                var progetto = progetto_provider.GetById(id_progetto);

                if (progetto != null)
                {
                    var bando = bando_provider.GetById(progetto.IdBando);

                    if (bando != null)
                    {
                        //Session["_bando"] = bando;
                        Redirect(PATH_ISTRUTTORIA + "Valutazione.aspx?iddom=" + id_progetto + "&idb=" + bando.IdBando);
                    }
                    else
                        ShowError("Bando non trovato");
                }
                else
                    ShowError("Progetto non trovato");

            }
            else
                ShowError("Nessuna domanda selezionata");
        }

        #endregion
    }
}