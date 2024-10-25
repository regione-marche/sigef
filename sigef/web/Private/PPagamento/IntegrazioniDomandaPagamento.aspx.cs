using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using SiarLibrary;
using SiarBLL;
using SiarLibrary.NullTypes;
using System.Collections;
using System.Text;

namespace web.Private.PPagamento
{
    public partial class IntegrazioniDomandaPagamento : SiarLibrary.Web.DomandaPagamentoPage
    {
        IntegrazioniPerDomandaDiPagamentoCollectionProvider integrazione_provider;
        IntegrazioniPerDomandaDiPagamento integrazione_selezionata = null;
        IntegrazioneSingolaDiDomandaCollectionProvider integrazione_singola_provider;
        IntegrazioneSingolaDiDomanda integrazione_singola_selezionata = null;
        int id_integrazione_di_domanda_selezionata, id_integrazione_di_domanda_singola;

        DomandaDiPagamentoCollectionProvider pagamento_provider;
        DomandaDiPagamento domanda_selezionata = null;
        int id_domanda_selezionata;

        #region Indici colonne DataGrid

        //Indici per integrazioni per domanda
        int col_InTDom_Id = 0,
            col_InTDom_DataRichiesta = 1,
            col_InTDom_Note = 2,
            col_InTDom_SegnaturaIstruttore = 3,
            col_InTDom_SegnaturaBeneficiario = 4,
            col_InTDom_DataConclusione = 5,
            col_InTDom_IntegrazioneCompleta = 6,
            col_InTDom_Visualizza = 7;

        //Indici per integrazioni singole
        int col_IntSing_Id = 0,
            col_IntSing_DataRichiesta = 1,
            col_IntSing_TipoIntegrazione = 2,
            col_IntSing_CompletataIntegrazione = 3,
            col_IntSing_DataRilascioBeneficiario = 4,
            col_IntSing_CompletataBeneficiario = 5,
            col_IntSing_DatiGiustificativo = 6,
            col_IntSing_DatiPagamento = 7,
            col_IntSing_Apri = 8;

        #endregion Indici colonne DataGrid

        protected override void OnInit(EventArgs e)
        {
            var memoriaInUso = GC.GetTotalMemory(false);

            if (memoriaInUso > 100000000)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                var memoriaInUsoDopo = GC.GetTotalMemory(false);
            } 

            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ucFirmaComunicazione.DocumentoFirmatoEvent = btnPostBack_Click;

            ucInfoDomanda.Progetto = new ProgettoCollectionProvider().GetById(DomandaPagamento.IdProgetto);

            integrazione_singola_provider = new IntegrazioneSingolaDiDomandaCollectionProvider();
            integrazione_provider = new IntegrazioniPerDomandaDiPagamentoCollectionProvider();
            pagamento_provider = new DomandaDiPagamentoCollectionProvider();

            id_domanda_selezionata = DomandaPagamento.IdProgetto;

            domanda_selezionata = pagamento_provider.GetById(id_domanda_selezionata);

            if (int.TryParse(hdnIdIntegrazioneDomandaDiPagamentoSelezionato.Value, out id_integrazione_di_domanda_selezionata))
            {
                integrazione_selezionata = integrazione_provider.GetById(id_integrazione_di_domanda_selezionata);

                if (int.TryParse(hdnIdIntegrazioneSingolaSelezionata.Value, out id_integrazione_di_domanda_singola))
                {
                    integrazione_singola_selezionata = integrazione_singola_provider.GetById(id_integrazione_di_domanda_singola);

                    UcVisualizzaIntegrazioneSingola.IntegrazioneSingola = integrazione_singola_selezionata;
                    UcVisualizzaIntegrazioneSingola.PerBeneficiario = true;
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            var integrazioni_collection = new IntegrazioniPerDomandaDiPagamentoCollection();
            if (integrazione_selezionata != null)
                integrazioni_collection.Add(integrazione_provider.GetById(id_integrazione_di_domanda_selezionata));
            else 
                integrazioni_collection = integrazione_provider.Find(null, DomandaPagamento.IdDomandaPagamento, null, null);

            dgIntegrazioniDomanda.DataSource = integrazioni_collection;
            dgIntegrazioniDomanda.SetTitoloNrElementi();
            dgIntegrazioniDomanda.ItemDataBound += new DataGridItemEventHandler(dgIntegrazioniDomanda_ItemDataBound);
            dgIntegrazioniDomanda.DataBind();

            if (integrazione_selezionata != null)
            {
                trElencoIntegrazioniIncluse.Visible = true;
                riempiCampiInteraIntegrazione();

                BoolNT soloNonCompletatiIstruttore = null;
                if (checkNonCompletateIstruttore.Checked)
                    soloNonCompletatiIstruttore = false; //per la find per filtrare non completati

                BoolNT soloNonCompletatiBenefeciari = null;
                if (checkNonCompletateBeneficiario.Checked)
                    soloNonCompletatiBenefeciari = false; //per la find per filtrare non completati

                var integrazioni_singole_collection = new IntegrazioneSingolaDiDomandaCollection();
                if (integrazione_singola_selezionata != null)
                    integrazioni_singole_collection.Add(integrazione_singola_provider.GetById(id_integrazione_di_domanda_singola));
                else 
                    integrazioni_singole_collection = integrazione_singola_provider.Find(
                        null, 
                        integrazione_selezionata.IdIntegrazioneDomandaDiPagamento, 
                        null,
                        soloNonCompletatiIstruttore,
                        soloNonCompletatiBenefeciari, 
                        null);
                var integrazioni_singole_list = integrazioni_singole_collection.ToArrayList<IntegrazioneSingolaDiDomanda>();

                if (integrazioni_singole_list
                        .Where(i => i.CodTipoIntegrazione == "ALL")
                        .Count() < 1)
                    btnAllegati.Visible = false;
                if (integrazioni_singole_list
                    .Where(i => i.CodTipoIntegrazione == "GIU")
                    .Count() < 1
                    && integrazioni_singole_list
                        .Where(i => i.CodTipoIntegrazione == "PAG")
                        .Count() < 1)
                    btnSpese.Visible = false;
                if (integrazioni_singole_list
                        .Where(i => i.CodTipoIntegrazione == "INV")
                        .Count() < 1)
                    btnInvestimenti.Visible = false;

                dgIntegrazioni.DataSource = integrazioni_singole_collection;
                dgIntegrazioni.SetTitoloNrElementi();
                dgIntegrazioni.ItemDataBound += new DataGridItemEventHandler(dgIntegrazioni_ItemDataBound);
                dgIntegrazioni.DataBind();

                integrazioni_singole_list.Clear();

                if (integrazione_selezionata.Segnatura != null)
                {
                    //AllegatiProtocollatiCollection apc = new AllegatiProtocollatiCollectionProvider().Find(null, null, null, integrazione_selezionata.IdIntegrazioneDomandaDiPagamento, null, null, null, null);
                    //int numeroAllegati = apc.Count;

                    //bool allegatiProtocollatiOk = checkAllegatiProtocollati(numeroAllegati, integrazione_selezionata.SegnaturaBeneficiario);
                    bool allegatiProtocollatiOk = new AllegatiProtocollatiCollectionProvider().CheckAllegatiProtocollati(AllegatiProtocollatiCollectionProvider.TipoCheck.IntegrazioneDiDomandaPagamento, integrazione_selezionata.IdIntegrazioneDomandaDiPagamento, integrazione_selezionata.SegnaturaBeneficiario);

                    if (!allegatiProtocollatiOk)
                    {
                        rowProtocolliAllegati.Visible = true;
                        btnProtocollaAllegati.Enabled = true;
                    }
                    else
                    {
                        rowProtocolliAllegati.Visible = false;
                        btnProtocollaAllegati.Enabled = false;
                    }
                }
            }

            base.OnPreRender(e);
        }

        void dgIntegrazioniDomanda_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            var dgi = e.Item;
            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var d = (IntegrazioniPerDomandaDiPagamento)dgi.DataItem;

                if (d.SegnaturaIstruttore != null && !d.SegnaturaIstruttore.Equals(""))
                {
                    var segnaturaIstruttore = d.SegnaturaIstruttore.ToString().Replace("R_MARCHE|", "R_MARCHE|\n");
                    //dgi.Cells[col_SegnaturaIstruttore].Text = "<a href=\"javascript:sncAjaxCallVisualizzaProtocollo('" + d.SegnaturaIstruttore + "');\">" + segnaturaIstruttore + "</a>";
                    dgi.Cells[col_InTDom_SegnaturaIstruttore].Text = "<a href=\"javascript:MostraProtocolloNew('" + d.SegnaturaIstruttore + "');\">" + segnaturaIstruttore + "</a>";
                }

                if (d.SegnaturaBeneficiario != null && !d.SegnaturaBeneficiario.Equals(""))
                {
                    var segnaturaBeneficiario = d.SegnaturaBeneficiario.ToString().Replace("R_MARCHE|", "R_MARCHE|\n");
                    //dgi.Cells[col_SegnaturaBeneficiario].Text = "<a href=\"javascript:sncAjaxCallVisualizzaProtocollo('" + d.SegnaturaBeneficiario + "');\">" + segnaturaBeneficiario + "</a>";
                    dgi.Cells[col_InTDom_SegnaturaBeneficiario].Text = "<a href=\"javascript:MostraProtocolloNew('" + d.SegnaturaBeneficiario + "');\">" + segnaturaBeneficiario + "</a>";
                }

                if (d.IntegrazioneCompleta != null && d.IntegrazioneCompleta == true)
                    dgi.Cells[col_InTDom_IntegrazioneCompleta].Text = "<div class=\"positivo\">SI</div>";
                else
                    dgi.Cells[col_InTDom_IntegrazioneCompleta].Text = "<div class=\"negativo\">NO</div>";

                if (integrazione_selezionata != null && d.IdIntegrazioneDomandaDiPagamento == integrazione_selezionata.IdIntegrazioneDomandaDiPagamento)
                    dgi.Cells[col_InTDom_Visualizza].Text = dgi.Cells[col_InTDom_Visualizza].Text.Replace("Visualizza", "Torna elenco");
            }
        }

        void dgIntegrazioni_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            var dgi = e.Item;
            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var d = (IntegrazioneSingolaDiDomanda)dgi.DataItem;

                if (d.SingolaIntegrazioneCompletataIstruttore != null && d.SingolaIntegrazioneCompletataIstruttore == true)
                    dgi.Cells[col_IntSing_CompletataIntegrazione].Text = "<div class=\"positivo\">SI</div>";
                else
                    dgi.Cells[col_IntSing_CompletataIntegrazione].Text = "<div class=\"negativo\">NO</div>";

                if (d.SingolaIntegrazioneCompletataBeneficiario != null && d.SingolaIntegrazioneCompletataBeneficiario == true)
                    dgi.Cells[col_IntSing_CompletataBeneficiario].Text = "<div class=\"positivo\">SI</div>";
                else
                    dgi.Cells[col_IntSing_CompletataBeneficiario].Text = "<div class=\"negativo\">NO</div>";

                if ((d.DescrizioneTipoIntegrazione != null)
                    && (d.DescrizioneTipoIntegrazione.Equals("Spese sostenute giustificativo") || d.DescrizioneTipoIntegrazione.Equals("Spese sostenute pagamento")))
                {
                    if (d.DescrizioneTipoIntegrazione.Equals("Spese sostenute giustificativo"))
                    {
                        var giustificativo = new GiustificativiCollectionProvider().GetById(d.IdGiustificativo);
                        dgi.Cells[col_IntSing_DatiGiustificativo].Text = "<b>Numero:</b> " + giustificativo.Numero + "<br /><b>Data:</b> " + giustificativo.Data + "<br /><b>Ragione sociale:</b> " + giustificativo.DescrizioneFornitore + "<br /><b>Oggetto:</b> " + giustificativo.Descrizione;
                        dgi.Cells[col_IntSing_DatiPagamento].Text = "";
                    }
                    else
                    {
                        var spesa = new SpeseSostenuteCollectionProvider().GetById(d.IdSpesa);
                        dgi.Cells[col_IntSing_DatiGiustificativo].Text = "<b>Numero:</b> " + spesa.Numero + "<br /><b>Data:</b> " + spesa.Data + "<br /><b>Ragione sociale:</b> " + spesa.DescrizioneFornitore + "<br /><b>Oggetto:</b> " + spesa.Descrizione;
                        dgi.Cells[col_IntSing_DatiPagamento].Text = "<b>Tipo:</b> " + spesa.TipoPagamento + "<br /><b>Estremi:</b> " + spesa.Estremi;
                    }
                }
                else
                {
                    dgi.Cells[col_IntSing_DatiGiustificativo].Text = "";
                    dgi.Cells[col_IntSing_DatiPagamento].Text = "";
                }

                if (integrazione_singola_selezionata != null && d.IdSingolaIntegrazione == integrazione_singola_selezionata.IdSingolaIntegrazione)
                    dgi.Cells[col_IntSing_Apri].Text = dgi.Cells[col_IntSing_Apri].Text.Replace("Apri", "Torna elenco");
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            dgIntegrazioni.SetPageIndex(0);
            dgIntegrazioniDomanda.SetPageIndex(0);
        }

        protected void riempiCampiInteraIntegrazione()
        {
            txtNoteIntegrazioneDomandaDiPagamento.Text = integrazione_selezionata.NoteIntegrazioneDomanda;
            if ((integrazione_selezionata != null
                && integrazione_singola_provider.Find(null, integrazione_selezionata.IdIntegrazioneDomandaDiPagamento, null, null, false, null).Count > 0)
                || (integrazione_selezionata != null && integrazione_selezionata.SegnaturaBeneficiario != null))
            {
                btnInviaIntegrazione.Enabled = false;
                btnInviaIntegrazione.ToolTip = "Non è possibile inviare la risposta perché già inviata o perché non sono state completate tutte le singole integrazioni";
            }
        }

        protected void btnRisolviIntegrazione_Click(object sender, EventArgs e)
        {
            try
            {
                string pagina_risoluzione = PATH_PPAGAMENTO;
                string link_spese_sostenute = "SpeseSostenute.aspx?idpag=" + integrazione_selezionata.IdDomandaPagamento;
                string link_piano_investimenti = "PianoInvestimenti.aspx?idpag=" + integrazione_selezionata.IdDomandaPagamento;
                string link_allegati = "FirmaRichiesta.aspx?idpag=" + integrazione_selezionata.IdDomandaPagamento;
                //StringBuilder sbRisoluzione = new StringBuilder(PATH_PPAGAMENTO);
                //StringBuilder sbSpeseSostenute = new StringBuilder("SpeseSostenute.aspx?idpag=").Append(integrazione_selezionata.IdDomandaPagamento.ToString());
                //StringBuilder sbPianoInvestimenti = new StringBuilder("PianoInvestimenti.aspx?idpag=").Append(integrazione_selezionata.IdDomandaPagamento.ToString());
                //StringBuilder sbAllegati = new StringBuilder("FirmaRichiesta.aspx?idpag=").Append(integrazione_selezionata.IdDomandaPagamento.ToString());

                switch (integrazione_singola_selezionata.DescrizioneTipoIntegrazione)
                {
                    case "Spese sostenute pagamento":
                        //pagina_risoluzione += link_spese_sostenute;
                        //sbRisoluzione.Append(sbSpeseSostenute);
                        Session["id_spesa_integrazione"] = integrazione_singola_selezionata.IdSpesa;
                        break;
                    case "Spese sostenute giustificativo":
                        pagina_risoluzione += link_spese_sostenute;
                        //sbRisoluzione.Append(sbSpeseSostenute.ToString());
                        Session["id_giustificativo_integrazione"] = integrazione_singola_selezionata.IdGiustificativo;
                        break;
                    case "Piano investimenti":
                        pagina_risoluzione += link_piano_investimenti;
                        //sbRisoluzione.Append(sbPianoInvestimenti.ToString());
                        break;
                    case "Allegati":
                        pagina_risoluzione += link_allegati;
                        //sbRisoluzione.Append(sbAllegati.ToString());
                        break;
                    default: throw new Exception("Errore di tipologia");
                }

                Session["id_integrazione_domanda"] = integrazione_singola_selezionata.IdIntegrazioneDomanda;
                Response.Redirect(pagina_risoluzione);
                //Response.Redirect(sbRisoluzione.ToString());
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnInviaIntegrazione_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(DomandaPagamento.IdProgetto))
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk per segnalare il problema.");

                ucFirmaComunicazione.FirmaObbligatoria = new BandoCollectionProvider().GetById(Progetto.IdBando).FirmaRichiesta;
                ArrayList parametri = new ArrayList();
                parametri.Add(DomandaPagamento.IdProgetto.ToString());
                parametri.Add(integrazione_selezionata.IdIntegrazioneDomandaDiPagamento.ToString());
                ucFirmaComunicazione.loadDocumento(((SiarLibrary.Web.MasterPage)Master).Operatore.Utente.CfUtente, (string[])parametri.ToArray(typeof(string)));
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnPostBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ucFirmaComunicazione.FileFirmato))
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk e segnalare il problema.");

                Progetto progetto = new ProgettoCollectionProvider().GetById(DomandaPagamento.IdProgetto);
                SiarLibrary.Impresa impresa = new ImpresaCollectionProvider().GetById(progetto.IdImpresa);
                Bando bando = new BandoCollectionProvider().GetById(progetto.IdBando);
                PersoneXImprese rlegale = new PersoneXImpreseCollectionProvider().GetById(impresa.IdRapprlegaleUltimo);
                if (rlegale == null) 
                    throw new Exception("I dati anagrafici dell`azienda non sono validi. Si prega di contattare l`helpdesk.");

                ArchivioFileCollectionProvider archivioProvider = new ArchivioFileCollectionProvider();
                AllegatiProtocollatiCollectionProvider allegatiProtocollatiProvider = new AllegatiProtocollatiCollectionProvider();
                SpeseSostenuteFileCollectionProvider speseSostenuteFileCollectionProvider = new SpeseSostenuteFileCollectionProvider();
                var segnatureMultipleCollectionProvider = new SegnatureMultipleCollectionProvider();
                integrazione_provider = new IntegrazioniPerDomandaDiPagamentoCollectionProvider();

                ArchivioFileCollection fileDaProtocollareCollection = new ArchivioFileCollection();
                //List<ArrayList> allegatiProtocolloList = new List<ArrayList>();
                ArrayList allegatiProtocollo = new ArrayList();
                string segnaturaPrincipale = null;
                List<Protocollo> protocolli = new List<Protocollo>();
                List<string> segnature = new List<string>();

                Protocollo protocollo = new Protocollo(bando.CodEnte);
                protocollo.setCorrispondente(rlegale.Cognome, rlegale.Nome, null, "mittente");
                var filePrincipale = Convert.FromBase64String(ucFirmaComunicazione.FileFirmato);
                var nomeFilePrincipale = "comunicazione_richiesta_integrazioni_domanda_nr_" + Progetto.IdProgetto + ".pdf";
                protocollo.setDocumento(nomeFilePrincipale, filePrincipale);
                protocolli.Add(protocollo);

                string[] ss = new BandoCollectionProvider().GetDatiXProtocollazione(Progetto.IdBando, Progetto.ProvinciaDiPresentazione);
                string oggetto = "Soluzione integrazioni domanda di pagamento (" + DomandaPagamento.Descrizione + ") per la domanda di aiuto nr. " + Progetto.IdProgetto
                    + " in risposta al bando: " + ss[0] + " del " + ss[1] + " con scadenza: " + ss[2] + "\n" + ss[3] + "\n P.Iva: " + impresa.CodiceFiscale
                     + "\n Ragione sociale: " + impresa.RagioneSociale;

                //se il bando non prevede la firma aggiungo anche l'allegato con il token Cohesion
                byte[] fileTokenCohesion = null;
                if (!bando.FirmaRichiesta)
                {
                    object sessione_cohesion = Session["COHESION_TOKEN"];
                    if (sessione_cohesion == null || string.IsNullOrEmpty(sessione_cohesion.ToString()))
                        throw new Exception("Non è stata trovata nessuna informazione sull'operatore di rilascio, impossibile continuare.");

                    fileTokenCohesion = System.Text.Encoding.Unicode.GetBytes(sessione_cohesion.ToString());
                    var af = new ArchivioFile();
                    af.Id = -1;
                    af.Tipo = "application/xml";
                    af.NomeCompleto = af.NomeFile = "Autenticazione_Operatore.xml";
                    af.Contenuto = fileTokenCohesion;
                    af.Dimensione = fileTokenCohesion.Length;
                    af.HashCode = protocollo.GetSHA256(fileTokenCohesion);

                    fileDaProtocollareCollection.Add(af); // lo inserisco all'inizio così da andare nella segnatura principale
                }

                //prendo l'elenco dei file che dovrò caricare su Paleo
                fileDaProtocollareCollection = PagamentoProvider.GetFileXProtocollazioneIntegrazioneDomandaPagamentoNoStream(integrazione_selezionata.IdIntegrazioneDomandaDiPagamento);

                //Dichiarazione nome e hash degli allegati per l'impronta
                for (int i = 0; i < fileDaProtocollareCollection.Count; i++)
                {
                    if (i != 0 && i % (Protocollo.LimiteAllegatiPaleo + 1) == 0) //se supero il limite massimo degli allegati creo un nuovo protocollo
                    {
                        protocollo = new Protocollo(bando.CodEnte);
                        protocollo.setDocumento(nomeFilePrincipale, filePrincipale);
                        protocolli.Add(protocollo);
                    }

                    ArchivioFile f = fileDaProtocollareCollection[i];

                    try
                    {
                        if (f == null)
                            throw new Exception("Almeno uno dei documenti allegati alla presente domanda non è valido.");

                        protocollo.addAllegato(f.NomeFile, f.HashCode);
                    }
                    catch (Exception ex) { throw new Exception(ex.Message); }
                }

                //prendo la segnatura per ogni protocollo e gestisco il salvataggio delle segnature multiple
                try
                {
                    for (int i = 0; i < protocolli.Count; i++)
                    {
                        var p = protocolli[i];

                        string segnatura = "";
                        string nuovo_oggetto = oggetto + "\nProtocollo " + (i + 1) + " di " + (protocolli.Count);
                        p.setCorrispondente(rlegale.Cognome, rlegale.Nome, null, "mittente");
                        segnatura = p.ProtocolloIngresso(nuovo_oggetto, ss[4]);

                        segnature.Add(segnatura);

                        if (i == 0)
                        {
                            segnaturaPrincipale = segnatura;

                            integrazione_selezionata.CfBenficiario = Operatore.Utente.CfUtente;
                            integrazione_selezionata.SegnaturaBeneficiario = segnatura;
                            integrazione_provider.Save(integrazione_selezionata);
                        }
                        else
                        {
                            var segnaturaMultipla = new SegnatureMultiple();
                            segnaturaMultipla.SegnaturaPrincipale = segnaturaPrincipale;
                            segnaturaMultipla.SegnaturaSecondaria = segnatura;
                            segnaturaMultipla.Ordine = i;
                            segnaturaMultipla.Tipo = "IntegrazioneDomandaDiPagamento";
                            segnaturaMultipla.IdRiferimento = integrazione_selezionata.IdIntegrazioneDomandaDiPagamento;
                            segnaturaMultipla.DataInserimento = segnaturaMultipla.DataModifica = DateTime.Now;
                            segnaturaMultipla.OperatoreInserimento = segnaturaMultipla.OperatoreModifica = Operatore.Utente.CfUtente;
                            segnatureMultipleCollectionProvider.Save(segnaturaMultipla);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                // carico gli allegati su paleo 
                bool allegatiProtocollatiOk = true;
                for (int i = 0; i < fileDaProtocollareCollection.Count; i++)
                {
                    ArchivioFile f = fileDaProtocollareCollection[i];

                    if (i != 0 && i % (Protocollo.LimiteAllegatiPaleo + 1) == 0) //se supero il limite massimo degli allegati creo un nuovo allegati protocollo
                    {
                        allegatiProtocollo = new ArrayList();
                        //allegatiProtocolloList.Add(allegatiProtocollo);
                    }

                    try
                    {
                        SiarBLL.paleoWebService.Allegato all = new SiarBLL.paleoWebService.Allegato();
                        all.Descrizione = f.NomeCompleto;
                        all.Documento = new SiarBLL.paleoWebService.File();
                        all.Documento.NomeFile = f.NomeFile;
                        all.Documento.Stream = f.Contenuto;
                        if (f.Id == null || f.Id == -1)
                            all.Documento.Impronta = new Protocollo().GetSHA256(f.Contenuto);
                        else
                            all.Documento.Impronta = f.HashCode;

                        Dictionary<string, object> allegatoProtocollo = new Dictionary<string, object>();
                        allegatoProtocollo.Add("allegato", all);
                        allegatoProtocollo.Add("id_file", f.Id != null ? f.Id.Value : -1); //aggiunto controllo per file token cohesion che non ha id
                        allegatoProtocollo.Add("tipo_origine", "integrazione");
                        allegatoProtocollo.Add("id_origine", integrazione_selezionata.IdIntegrazioneDomandaDiPagamento);
                        allegatiProtocollo.Add(allegatoProtocollo);

                        AllegatiProtocollatiCollection exist = allegatiProtocollatiProvider.Find(null, null, null, integrazione_selezionata.IdIntegrazioneDomandaDiPagamento, null, f.Id, null, null);
                        if (exist.Count == 0)
                        {
                            AllegatiProtocollati ap = new AllegatiProtocollati();
                            ap.IdVariante = DBNull.Value;
                            ap.IdProgetto = DBNull.Value;
                            ap.IdDomandaPagamento = DBNull.Value;
                            ap.IdIntegrazione = integrazione_selezionata.IdIntegrazioneDomandaDiPagamento;
                            ap.IdFile = f.Id != null ? f.Id.Value : -1; //aggiunto controllo per file token cohesion che non ha id
                            ap.Protocollato = false;
                            allegatiProtocollatiProvider.Save(ap);
                        }
                    }
                    catch (Exception ex) { }

                    //se raggiungo il limite o sono all'ultimo allegato allego il blocco degli allegati alla segnatura
                    if (i != 0 && i % Protocollo.LimiteAllegatiPaleo == 0)
                    {
                        Protocollo protocolloAll = new Protocollo(bando.CodEnte);

                        var segnatura = segnature[(int)Math.Truncate((decimal)(i / Protocollo.LimiteAllegatiPaleo)) - 1]; //trovo il protocollo in base al numero dell'allegato in cui sto ciclando

                        protocolloAll.addAllegatiProtocollo(allegatiProtocollo, segnatura);

                        var esito = allegatiProtocollatiProvider.CheckAllegatiProtocollati(AllegatiProtocollatiCollectionProvider.TipoCheck.IntegrazioneDiDomandaPagamento, integrazione_selezionata.IdIntegrazioneDomandaDiPagamento, segnatura);
                        if (!esito)
                            allegatiProtocollatiOk = false;
                    }

                    //se sono all'ultimo allegato allego il blocco degli allegati all'ultima segnatura
                    if (i == (fileDaProtocollareCollection.Count - 1))
                    {
                        Protocollo protocolloAll = new Protocollo(bando.CodEnte);

                        var segnatura = segnature.Last();

                        protocolloAll.addAllegatiProtocollo(allegatiProtocollo, segnatura);

                        var esito = allegatiProtocollatiProvider.CheckAllegatiProtocollati(AllegatiProtocollatiCollectionProvider.TipoCheck.IntegrazioneDiDomandaPagamento, integrazione_selezionata.IdIntegrazioneDomandaDiPagamento, segnatura);
                        if (!esito)
                            allegatiProtocollatiOk = false;
                    }
                }

                try
                {
                    /*
                     *  ### NON INSERISCO PROGETTOSEGNATURE PERCHE' POTREI DOVERNE FARE PIU' DI UNA ###
                    ProgettoSegnatureCollectionProvider segnature_provider = new ProgettoSegnatureCollectionProvider();
                    ProgettoSegnature segnatura_comunicazione = new ProgettoSegnature();
                    segnatura_comunicazione.Segnatura = segnatura;
                    segnatura_comunicazione.IdProgetto = Progetto.IdProgetto;
                    segnatura_comunicazione.Data = DateTime.Now;
                    segnatura_comunicazione.CodTipo = "IDP";
                    segnatura_comunicazione.Operatore = Operatore.Utente.CfUtente;
                    segnature_provider.Save(segnatura_comunicazione);
                    ShowMessage("Comunicazione di soluzione integrazioni firmata e protocollata correttamente.");
                    */
                   
                    if (allegatiProtocollatiOk) 
                        ShowMessage("Comunicazione di soluzione integrazione firmata e protocollata correttamente.");
                    else 
                        ShowError("Comunicazione di soluzione integrazione firmata e protocollata correttamente. Attenzione: non tutti gli allegati sono stati inviati al protocollo, riprovare ad inviare tramite l'apposito pulsante.");
                   
                    try
                    {
                        // invio la notifica del rilascio al responsabile del bando e a quello provinciale                
                        UtentiCollectionProvider utenti_provider = new UtentiCollectionProvider();
                        ArrayList destinatari = new ArrayList();
                        foreach (BandoResponsabili r in new BandoResponsabiliCollectionProvider().Find(Progetto.IdBando, null, null, null, true))
                        {
                            Utenti u = utenti_provider.GetById(r.IdUtente);
                            if (u != null && u.Email != null)
                                destinatari.Add(u.Email.Value);
                        }

                        if (destinatari.Count > 0)
                        {
                            Email em = new Email("Avviso di ricezione Soluzione integrazioni di " + DomandaPagamento.Descrizione + " (Progetto: " + Progetto.IdProgetto + ")",
                                "<html><body>Si comunica che con prot. " + segnaturaPrincipale + "<br />è stata presentata la Soluzione integrazioni di " + DomandaPagamento.Descrizione
                            + " per il Progetto ID: " + Progetto.IdProgetto + "."
                            + "<br /><ul><li style='width:650px'>Bando: " + bando.Descrizione + "</li><li>Scadenza: " + bando.DataScadenza + "</li><br />"
                            + "<li>CF/P.Iva: " + impresa.CodiceFiscale + "</li><li style='width:650px'>Ragione sociale: "
                            + impresa.RagioneSociale + "</li><br />" + "<li>Stato progetto: " + Progetto.Stato + "</li></ul>"
                            + "<br />Tale integrazione è consultabile all'indirizzo: <a href='" + Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath
                            + "/private/IPagamento/IstruttoriaIntegrazioniDomandaPagamento.aspx?iddom=" + Progetto.IdProgetto + "' target=_blank>Clicca qui</a>"
                            + "<br /><br />Questa è una notifica automatica del sistema " + System.Configuration.ConfigurationManager.AppSettings["APP:NomeCompleto"]
                            + "<br />Si prega di non rispondere a questa email.</body></html>");
                            em.SetHtmlBodyMessage(true);
                            em.SendNotification((string[])destinatari.ToArray(typeof(string)), new string[] { });
                        }
                    }
                    catch (Exception exy) { ShowError(exy.ToString()); }
                }
                catch (Exception exz) { ShowError(exz.ToString()); }
            }
            catch (Exception ex) { ShowError(ex.ToString()); }
        }

        protected void btnProtocollaAllegati_Click(object sender, EventArgs e)
        {
            object tokenCohesion = null;
            var bando = new BandoCollectionProvider().GetById(Progetto.IdBando);
            if (!bando.FirmaRichiesta)
            {
                tokenCohesion = Session["COHESION_TOKEN"];
                if (tokenCohesion == null || string.IsNullOrEmpty(tokenCohesion.ToString()))
                    throw new Exception("Non è stata trovata nessuna informazione sull'operatore di rilascio, impossibile continuare.");
            }

            bool allegatiProtocollatiOk = new AllegatiProtocollatiCollectionProvider()
                .ProtocollaAllegatiSegnatura(AllegatiProtocollatiCollectionProvider.TipoCheck.IntegrazioneDiDomandaPagamento, 
                    integrazione_selezionata.IdIntegrazioneDomandaDiPagamento, 
                    integrazione_selezionata.SegnaturaBeneficiario,
                    tokenCohesion);

            if (allegatiProtocollatiOk) 
                ShowMessage("Comunicazione di soluzione integrazione firmata e protocollata correttamente.");
            else 
                ShowError("Comunicazione di soluzione integrazione firmata e protocollata correttamente. Attenzione: non tutti gli allegati sono stati inviati al protocollo, riprovare ad inviare tramite l'apposito pulsante.");
        }

        protected void btnAllegati_Click(object sender, EventArgs e)
        {
            if (int.TryParse(hdnIdIntegrazioneDomandaDiPagamentoSelezionato.Value, out id_integrazione_di_domanda_selezionata))
            {
                Session["id_integrazione_domanda"] = id_integrazione_di_domanda_selezionata;
                Redirect(PATH_PPAGAMENTO + "FirmaRichiesta.aspx");
            }
        }

        protected void btnSpese_Click(object sender, EventArgs e)
        {
            if (int.TryParse(hdnIdIntegrazioneDomandaDiPagamentoSelezionato.Value, out id_integrazione_di_domanda_selezionata))
            {
                Session["id_integrazione_domanda"] = id_integrazione_di_domanda_selezionata;
                Redirect(PATH_PPAGAMENTO + "SpeseSostenute.aspx");
            }
        }

        protected void btnInvestimenti_Click(object sender, EventArgs e)
        {
            if (int.TryParse(hdnIdIntegrazioneDomandaDiPagamentoSelezionato.Value, out id_integrazione_di_domanda_selezionata))
            {
                Session["id_integrazione_domanda"] = id_integrazione_di_domanda_selezionata;
                Redirect(PATH_PPAGAMENTO + "PianoInvestimenti.aspx");
            }
        }

        protected void checkNonCompletateBeneficiario_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void checkNonCompletateIstruttore_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnMostraProtocollo_Click(object sender, EventArgs e)
        {
            try
            {
                string segnatura = hdnSegnatura.Value;
                if (string.IsNullOrEmpty(segnatura) || segnatura == "undefined")
                    throw new Exception("Segnatura vuota");

                modaleMostraProtocollo.Segnatura = segnatura;
                RegisterClientScriptBlock(modaleMostraProtocollo.Mostra);
            }
            catch (Exception ex)
            {
                RegisterClientScriptBlock("chiudiPopupTemplate();");
                ShowError(ex.Message);
            }
        }
    }
}
