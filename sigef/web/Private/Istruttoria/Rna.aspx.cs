using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RnaManager;
using System.Web.UI.HtmlControls;
using SiarBLL;
using SiarLibrary;
using System.Xml.Linq;
using System.IO;

namespace web.Private.Psr.Bandi
{
    public partial class Rna : SiarLibrary.Web.PrivatePage
    {
        enum tipoVisura
        {
            deggendorf,
            deminimis,
            aiuti
        }
        enum statoVisura
        {
            darichiedere,
            daVerificare,
            daScaricare,
            errore
        }

        enum StatoConcessione
        {
            daInviare,
            daVerificareEsito,
            daConfermareCOR,
            completata,
            erroreRichiesta
        }

        bool attoConcessionePresente = false;
        bool produzione = false;
        string PATH_IMAGES = VirtualPathUtility.ToAbsolute("~/Images/");
        VrnaEsitoConcessioneCollection vRnaEsitoConcessioneCollection = new VrnaEsitoConcessioneCollection();
        VrnaEsitoVisureCollection vRnaEsitoVisure = new VrnaEsitoVisureCollection();
        RnaEntiCollectionProvider RnaEntiCollectionProvider = new RnaEntiCollectionProvider();
        SiarBLL.RnaBandoConfigCollectionProvider rnaBandoConfigCollectionProvider = new SiarBLL.RnaBandoConfigCollectionProvider();
        int nProgetti;
        int countRichiesteMassive;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.btnScaricaVisura);
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "myJsFn", "hideModaleCaricamento();", true);
            gestisciRichiesta();
        }

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "Rna";
            base.OnPreInit(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            nProgetti = 0;
            caricaComboEnti();
            caricaBandi();
            lblNrProgetti.Text = string.Format("Progetti visualizzati: {0}", nProgetti);
            base.OnPreRender(e);
        }

        private void caricaBandi()
        {
            var rnaEnti = new RnaEnti();
            if (lstEntiRna.Items.Count == 0)//UTENTE MAI REGISTRATO
            {
                divBandi.Visible = false;
                lblSottotitolo.Text = "Per usufruire del servizio occorre richiedere le credenziali per il Web Service di " +
                                      "collaudo all'RNA e comunicarle all'help desk per essere abilitati all'invio di prova.";
            }
            else
            {
                rnaEnti = RnaEntiCollectionProvider.Select(lstEntiRna.SelectedValue, null, null, null, null, null, null, null, null)[0];
                if (!rnaEnti.Abilitato)//UTENTE NON ABILITATO 
                {
                    lblTitolo.Text = "Cruscotto RNA Collaudo";
                    produzione = false;
                }
                else//UTENTE ABILITATO 
                {
                    if (!rnaEnti.CredenzialiProduzione)
                    {
                        divBandi.Visible = false;
                        lblSottotitolo.Text = "E' stato completato un iter in ambiente di collaudo, ora si è abilitati all'utilizzio in produzione.<br>" +
                            "Occorre contattare l'assistenza dell'RNA per avere le nuove credenziali e comunicarle all'help desk del SIGEF per aggiornare la propria utenza.";
                    }
                    else
                    {
                        produzione = true;
                        //imposta endpoint produzione 
                    }
                }
            }

            if (Operatore.Utente.Ente != "Amministrazione")
                divLstEntiBando.Visible = false;
            else
                lstEntiBando.DataBind();
            lstProgrammazione.AttivazioneBandi = true;
            lstProgrammazione.DataBind();
            lstStatoBando.DataBind();
            string idBando = txtIdBando.Text;
            string ente;
            string programmazione;
            SiarLibrary.NullTypes.DatetimeNT dataScadenza;
            string statoProcedurale;
            IEnumerable<Bando> listBandoCollection = null;
            SiarLibrary.BandoCollection bandoCollection = new SiarLibrary.BandoCollection();
            SiarBLL.BandoCollectionProvider bandoCollectionProvider = new SiarBLL.BandoCollectionProvider();
            divProgetti.Style.Add("display", "none");
            divDatiConcessione.Style.Add("display", "none");
            if (!string.IsNullOrEmpty(hdnBandoSelezionato.Value))
            {
                RnaBandoConfigCollectionProvider rnaBandoConfigCollectionProvider = new RnaBandoConfigCollectionProvider();
                RnaBandoConfigCollection rnaBandoConfigCollection = rnaBandoConfigCollectionProvider.Select(null, int.Parse(hdnBandoSelezionato.Value), null, null, null, null, null);

                string errore_bando = null;
                if (rnaBandoConfigCollection.Count == 0)
                    errore_bando = string.Format("Il Bando {0} non è stato ancora configurato per l'invio all'RNA", hdnBandoSelezionato.Value);
                else
                if (rnaEnti.Abilitato && rnaBandoConfigCollection[0].CodBandoRna == null)
                    errore_bando = string.Format("La configurazione del bando {0} non è completa per l'invio all'RNA", hdnBandoSelezionato.Value);
                else
                if (!rnaEnti.Abilitato && rnaBandoConfigCollection[0].CodBandoRnaCollaudo == null)
                    errore_bando = string.Format("La configurazione del bando {0} non è completa per l'invio all'RNA in ambiende di Collaudo", hdnBandoSelezionato.Value);

                if (errore_bando != null)
                {
                    ShowError(errore_bando);
                    hdnBandoSelezionato.Value = "";
                    ente = lstEntiBando.SelectedValue;
                    programmazione = lstProgrammazione.SelectedValue;
                    dataScadenza = new SiarLibrary.NullTypes.DatetimeNT(txtScadenza.Text);
                    if (dataScadenza != null) dataScadenza.AddHour(24, 0, 0);
                    statoProcedurale = lstStatoBando.SelectedValue;
                    ente = lstEntiBando.SelectedValue;
                    programmazione = lstProgrammazione.SelectedValue;
                    dataScadenza = new SiarLibrary.NullTypes.DatetimeNT(txtScadenza.Text);
                    if (dataScadenza != null) dataScadenza.AddHour(24, 0, 0);
                    statoProcedurale = lstStatoBando.SelectedValue;

                    if (Operatore.Utente.Ente == "Amministrazione")
                        bandoCollection = bandoCollectionProvider.Find(ente, statoProcedurale, null, dataScadenza, programmazione, null, null, null, null);
                    else
                        bandoCollection = bandoCollectionProvider.Find(Operatore.Utente.CodEnte, statoProcedurale, null, dataScadenza, programmazione, null, null, null, null);

                    if (!string.IsNullOrEmpty(idBando))
                        listBandoCollection = bandoCollection.ToArrayList<SiarLibrary.Bando>().Where(o => o.CodStato != "P" && o.IdBando == int.Parse(idBando));
                    else
                        listBandoCollection = bandoCollection.ToArrayList<SiarLibrary.Bando>().Where(o => o.CodStato != "P");

                    rnaBandoConfigCollection = new RnaBandoConfigCollectionProvider().Select(null, null, null, null, null, null, null);
                    BandoCollection bandiDaVisualizzare = new BandoCollection();

                    foreach (Bando b in listBandoCollection)
                    {
                        foreach (RnaBandoConfig rnaB in rnaBandoConfigCollection)
                        {
                            if (b.IdBando == rnaB.IdBando)
                                bandiDaVisualizzare.Add(b);
                        }
                    }

                    dgBandi.DataSource = bandiDaVisualizzare;
                    dgBandi.DataBind();
                }
                else
                {

                    Bando bando = bandoCollectionProvider.GetById(hdnBandoSelezionato.Value);
                    Zprogrammazione zprogrammazione = new ZprogrammazioneCollectionProvider().GetById(bando.IdProgrammazione);
                    if (zprogrammazione.Descrizione != "COVID")
                    {
                        bandoCollection.Add(bandoCollectionProvider.GetById(int.Parse(hdnBandoSelezionato.Value)));
                        txtIdBando.Text = "";
                        txtScadenza.Text = "";
                        lstEntiBando.SelectedIndex = -1;
                        lstProgrammazione.SelectedIndex = -1;
                        lstStatoBando.SelectedIndex = -1;
                        txtDataConcessione.Text = "";
                        divFiltraBandi.Style.Add("display", "none");
                        GraduatoriaProgettiAttiCollectionProvider graduatoriaProgettiAttiCollectionProvider = new SiarBLL.GraduatoriaProgettiAttiCollectionProvider();
                        GraduatoriaProgettiAttiCollection graduatoriaProgettiAttiCollection = graduatoriaProgettiAttiCollectionProvider.Find(hdnBandoSelezionato.Value, null, null, null);
                        if (graduatoriaProgettiAttiCollection.Count != 0)
                            if (graduatoriaProgettiAttiCollection[graduatoriaProgettiAttiCollection.Count-1].IdAtto != null)
                                attoConcessionePresente = true;
                        caricaProgetti();

                        RnaBandoConfig rnaBandoConfig = rnaBandoConfigCollection[0];
                        if (rnaBandoConfig.DataPrevistaConcessione != null)
                        {
                            divDatiBandoGenerali.Style.Remove("display");
                            lblDataConcessione.Text = rnaBandoConfig.DataPrevistaConcessione.ToString();
                            salvaDataConcessione.Text = "Modifica";
                            if (attoConcessionePresente)
                            {
                                Atti atto = new AttiCollectionProvider().GetById(graduatoriaProgettiAttiCollection[graduatoriaProgettiAttiCollection.Count - 1].IdAtto);
                                lblNumeroAtto.Text = atto.Numero;
                                lblRegistroAtto.Text = atto.Registro;
                                lblDataAtto.Text = atto.Data;
                            }
                        }
                        divProgetti.Visible = true;
                        divProgettiContatoriCovid.Visible = false;
                    }
                    else//è un bando covid
                    {
                        divProgetti.Visible = false;
                        divProgettiContatoriCovid.Visible = true;
                        btnExcelCovid.OnClientClick = string.Format("EstraiXLS({0}); return false;", hdnBandoSelezionato.Value);
                        btnExcelCovid.CausesValidation = false;
                        caricaProgettiCovid();
                    }
                    bandoCollection.Clear();
                    bandoCollection.Add(bandoCollectionProvider.GetById(int.Parse(hdnBandoSelezionato.Value)));
                    dgBandi.DataSource = bandoCollection;
                    dgBandi.DataBind();
                }
            }
            else
            {
                //Applico i filtri
                ente = lstEntiBando.SelectedValue;
                programmazione = lstProgrammazione.SelectedValue;
                dataScadenza = new SiarLibrary.NullTypes.DatetimeNT(txtScadenza.Text);
                if (dataScadenza != null) dataScadenza.AddHour(24, 0, 0);
                statoProcedurale = lstStatoBando.SelectedValue;

                BandoCollection bandiDaVisualizzare = new BandoCollection();
                if (rnaEnti != null)
                {
                    RnaBandoConfigCollection rnaBandoConfigCollection;

                    if (Operatore.Utente.Ente == "Amministrazione")
                    {
                        bandoCollection = bandoCollectionProvider.Find(ente, statoProcedurale, null, dataScadenza, programmazione, null, null, null, null);
                        rnaBandoConfigCollection = new RnaBandoConfigCollectionProvider().Select(null, null, null, null, null, null, null);
                    }
                    else
                    {
                        bandoCollection = bandoCollectionProvider.Find(Operatore.Utente.CodEnte, statoProcedurale, null, dataScadenza, programmazione, null, null, null, null);
                        rnaBandoConfigCollection = new RnaBandoConfigCollectionProvider().Select(null, null, null, null, null, null, rnaEnti.IdRnaEnte);
                    }

                if (!string.IsNullOrEmpty(idBando))
                        listBandoCollection = bandoCollection.ToArrayList<SiarLibrary.Bando>().Where(o => o.CodStato != "P" && o.IdBando == int.Parse(idBando));
                    else
                        listBandoCollection = bandoCollection.ToArrayList<SiarLibrary.Bando>().Where(o => o.CodStato != "P");

                    foreach (Bando b in listBandoCollection)
                    {
                        foreach (RnaBandoConfig rnaB in rnaBandoConfigCollection)
                        {
                            if (b.IdBando == rnaB.IdBando)
                                bandiDaVisualizzare.Add(b);
                        }
                    }
                }
                dgBandi.DataSource = bandiDaVisualizzare;
                dgBandi.DataBind();
            }
        }

        private void caricaProgettiCovid() 
        {
            int nRichiedere = 0;
            int nVerivicare = 0;
            int nConfermare = 0;
            int nCompletate = 0;
            int nErrore = 0;

            if(produzione)
            {
                VrnaCovidEsitoConcessioneCollection esitoConcessione = new VrnaCovidEsitoConcessioneCollectionProvider().Select(int.Parse(hdnBandoSelezionato.Value), null, null, null, null, null, null, null, null, null, null, null, null, null, null);
                foreach (VrnaCovidEsitoConcessione esito in esitoConcessione)
                {
                    switch (esito.StatoConcessione)
                    {
                        case ("daInviare"):
                            nRichiedere++;
                            break;
                        case ("daVerificareEsito"):
                            nVerivicare++;
                            break;
                        case ("daConfermareCOR"):
                            nConfermare++;
                            break;
                        case ("daConfermareCORNoAtto"):
                            nConfermare++;
                            break;
                        case ("completata"):
                            nCompletate++;
                            break;
                        case ("erroreRichiesta"):
                            nErrore++;
                            break;
                    }

                }
            }
            else
            {
                VrnaCovidEsitoConcessioneCollaudoCollection esitoConcessione = new VrnaCovidEsitoConcessioneCollaudoCollectionProvider().Select(int.Parse(hdnBandoSelezionato.Value), null, null, null, null, null, null, null, null, null, null, null, null, null, null);
                foreach (VrnaCovidEsitoConcessioneCollaudo esito in esitoConcessione)
                {
                    switch (esito.StatoConcessione)
                    {
                        case ("daInviare"):
                            nRichiedere++;
                            break;
                        case ("daVerificareEsito"):
                            nVerivicare++;
                            break;
                        case ("daConfermareCOR"):
                            nConfermare++;
                            break;
                        case ("daConfermareCORNoAtto"):
                            nConfermare++;
                            break;
                        case ("completata"):
                            nCompletate++;
                            break;
                        case ("erroreRichiesta"):
                            nErrore++;
                            break;
                    }

                }
            }
            lblNRichiedere.Text = nRichiedere.ToString();
            lblNVerificare.Text = nVerivicare.ToString();
            lblNConfermare.Text = nConfermare.ToString();
            lblNCompletate.Text = nCompletate.ToString();
            lblNErrori.Text = nErrore.ToString();
        }

        protected void caricaProgetti()
        {
            divProgetti.Style.Remove("display");
            divDatiConcessione.Style.Remove("display");
            VrnaEsitoConcessioneCollectionProvider vRnaEsitoConcessioneCollectionProvider = new VrnaEsitoConcessioneCollectionProvider();
            //vRnaEsitoConcessioneCollection = new VrnaEsitoConcessioneCollectionProvider().Find(int.Parse(hdnBandoSelezionato.Value), null, null, null); 
            vRnaEsitoConcessioneCollection = new VrnaEsitoConcessioneCollectionProvider().Find(int.Parse(hdnBandoSelezionato.Value), null, null, null);
            List<VrnaEsitoConcessione> vSoloProgetti = (from x in vRnaEsitoConcessioneCollection.ToArrayList<VrnaEsitoConcessione>()
                                                            //where x.IdProgetto == 16788//TODO 
                                                        group x by x.IdProgetto into g
                                                        select g.First()).ToList<VrnaEsitoConcessione>();
            vSoloProgetti = vSoloProgetti.OrderBy(x => x.Ordine).ToList();
            vRnaEsitoVisure = new VrnaEsitoVisureCollectionProvider().Find(int.Parse(hdnBandoSelezionato.Value), null, null, null, null);
            dgProgetti.DataSource = vSoloProgetti;
            dgProgetti.ItemDataBound += new DataGridItemEventHandler(dgProgetto_ItemDataBound);
            dgProgetti.DataBind();

            Dictionary<string, string> campiAzioniMassive = new Dictionary<string, string>();
            campiAzioniMassive.Add("", "");
            campiAzioniMassive.Add("Invia Richieste COR", "richiediAiuti");
            campiAzioniMassive.Add("Verifica Esiti", "verificaEsiti");
            campiAzioniMassive.Add("Conferma COR", "confermaCor");
            campiAzioniMassive.Add("Annulla Richieste", "annullaRichieste");
            cmbAzioneMassiva.DataSource = campiAzioniMassive;
            cmbAzioneMassiva.DataTextField = "key";
            cmbAzioneMassiva.DataValueField = "value";
            cmbAzioneMassiva.DataBind();

            Dictionary<string, string> campiFiltraStati = new Dictionary<string, string>();
            campiFiltraStati.Add("", "");
            campiFiltraStati.Add("Da Inviare", StatoConcessione.daInviare.ToString());
            campiFiltraStati.Add("Esito da verificare", StatoConcessione.daVerificareEsito.ToString());
            campiFiltraStati.Add("COR da confermare", StatoConcessione.daConfermareCOR.ToString());
            campiFiltraStati.Add("Completata", StatoConcessione.completata.ToString());
            campiFiltraStati.Add("Richiesta fallita", StatoConcessione.erroreRichiesta.ToString());
            cmbStatoRichiestaRNA.DataSource = campiFiltraStati;
            cmbStatoRichiestaRNA.DataTextField = "key";
            cmbStatoRichiestaRNA.DataValueField = "value";
            cmbStatoRichiestaRNA.DataBind();
            cmbStatoRichiestaRNA.SelectedValue = hdnFiltroStatoProgetto.Value;
        }

        private void dgProgetto_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            int idProgetto = 0;
            try
            {
                int nColonneProgetti = 6;
                var progettiAperti = hdnProgettiAperti.Value.Split('|');
                DataGridItem dgi = (DataGridItem)e.Item;
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    idProgetto = int.Parse(dgi.Cells[2].Text);

                    //caricaDgVisure(idProgetto);

                    string tabellaImpresa;
                    var esitoProgetto = vRnaEsitoConcessioneCollection.ToArrayList<VrnaEsitoConcessione>().FirstOrDefault(x => x.IdProgetto == idProgetto);

                    dgi.Cells[3].Text = getStatoProgetto(esitoProgetto);
                    dgi.Cells[4].Text = string.Format("<select id = 'cmbAzioneProgetto_{0}' onclick='selezionaProgetto({0})'><option value = \"richiediVisure\"> Richiedi Visure </option><option value = \"richiediAiuti\"> Invia Richieste COR </option>"
                        + "<option value = \"verificaEsiti\"> Verifica Esiti </option><option value = \"confermaCor\"> Conferma COR </option><option value = \"annullaRichieste\"> Annulla Richieste </option></ select>", idProgetto);

                    #region celle tabella 
                    if (progettiAperti.Contains(idProgetto.ToString()))
                    {
                        tabellaImpresa = string.Format("</td> </tr><tr><td colspan ='{0}'><table id='tabella{1}' style=' width:100%; '>", nColonneProgetti, idProgetto);
                        dgi.Cells[0].Text = "<img src='" + PATH_IMAGES + "ArrowUpSolid.png' id='img" + idProgetto + "' style=\" width: 23px; height: 23px;\"/>";
                    }
                    else
                    {
                        tabellaImpresa = string.Format("</td> </tr><tr><td colspan ='{0}'><table id='tabella{1}' style=' width:100%; display:none; '>", nColonneProgetti, idProgetto);
                        dgi.Cells[0].Text = "<img src='" + PATH_IMAGES + "ArrowUpSolid.png' id='img" + idProgetto + "' style=\" width: 23px; height: 23px; transform: rotate(180deg);\"/>";
                    }

                    string headTabella1 = "<tr class='TESTA1'> <td colspan='2'>Dati Impresa</td><td colspan='5'>Gestione Visure</td><td colspan='6'>Invio richiesta COR</td></tr>";
                    string headTabella = "<tr class='TESTA'><td>Id Fiscale Impresa</td><td>Ragione Sociale</td>" +
                        "<td colspan='2'>Richiedi Visura</td><td>Aiuti</td><td>De Minimis</td><td>Deggendorf</td>" +
                        "<td>Stato Richiesta</td><td>Id Richiesta RNA</td><td>COR</td><td>Data COR</td><td>Richiesta COR</td><td>Annulla Richiesta COR</td></tr>";

                    string righeTabella = "";
                    string riga = "";
                    string clIdImpresa = "<td></td>";
                    string clRagSociale = "<td></td>";
                    string clStato = "<td>Da Inviare</td>";
                    string clIdRichiesta = "<td></td>";
                    string clCOR = "<td></td>";
                    string clDataCOR = "<td></td>";
                    string clVAiuti = "<td></td>";
                    string clVMinimis = "<td></td>";
                    string clVDeggendorf = "<td></td>";
                    string clInviaRic = "<td><input type='button' class='ButtonGrid' id=\"btnInviaRichiesta\" runat=\"server\" value=\"Richiedi COR\" onclick=\"__doPostBack('btnInviaRichiesta', 'InviaRichiesta')\"></td>";
                    string fineTabellaImpresa = "<tr class='TESTA' style=\"height: 3px;\"><td style=\"height: 3px;\" colspan='13'></td></tr></table></td></tr>";
                    string clRichiediVisura;
                    string clComboVisure = "<td></td> ";
                    string clAnnulla = "<td></td>;";
                    #endregion

                    dgi.Cells[1].Text = "Id progetto: " + dgi.Cells[1].Text;
                    var esitoImpresePerProgetto = vRnaEsitoConcessioneCollection.ToArrayList<VrnaEsitoConcessione>().Where(x => x.IdProgetto == idProgetto);

                    int countNumImprese = 0;
                    foreach (VrnaEsitoConcessione esitoImpresa in esitoImpresePerProgetto)
                    {
                        //bool inviabile = ((esitoProgetto.CodStato != "G" && esitoProgetto.CodStato != "F") || esitoImpresa.Finanziabilita == "N") ? false : true;
                        
                        bool inviabile = getStatoProgetto(esitoProgetto)== "Richiedibile" ? true : false;

                        StatoConcessione statoConcessione = getStatoConcessione(esitoImpresa);
                        if (!inviabile)
                            dgi.Cells[4].Text = string.Format("<select id = 'cmbAzioneProgetto_{0}' onclick='selezionaProgetto({0})'><option value = \"richiediVisure\"> Richiedi Visure </option>></ select>", idProgetto);

                        if (filtraImpresa(esitoImpresa))
                        {
                            countNumImprese++;
                            VrnaEsitoVisureCollection vRnaEsitoVisureCollection;// = new VrnaEsitoVisureCollectionProvider().Find(null, idProgetto, esitoImpresa.IdImpresa, null, null);
                            VrnaEsitoVisure vRnaEsitoVisura;
                            RnaLogVisureCollection rnaLogVisureCollection = new RnaLogVisureCollection();
                            RnaLogVisureCollectionProvider rnaLogVisureCollectionProvider = new RnaLogVisureCollectionProvider();
                            riga = "<tr class=\"DataGridRow\">";
                            clIdImpresa = string.Format("<td>{0}</td>", esitoImpresa.CodiceFiscale);
                            clRagSociale = string.Format("<td>{0}</td>", esitoImpresa.RagioneSociale);

                            //Visure Aiuti 
                            statoVisura statoV = getStatoVisura(idProgetto, esitoImpresa.IdImpresa, tipoVisura.aiuti.ToString());
                            if (statoV == statoVisura.daVerificare)
                                clVAiuti = string.Format("<td><a href=\"javascript:scaricaVisura({0}, {1}, '{2}')\">Verifica Visura</a></td>", idProgetto, esitoImpresa.IdImpresa, tipoVisura.aiuti);
                            else
                                if (statoV == statoVisura.daScaricare)
                            {
                                vRnaEsitoVisureCollection = new VrnaEsitoVisureCollectionProvider().Find(null, idProgetto, esitoImpresa.IdImpresa, null, tipoVisura.aiuti.ToString());
                                var listVisure = vRnaEsitoVisureCollection.ToArrayList<SiarLibrary.VrnaEsitoVisure>();
                                vRnaEsitoVisura = listVisure.FirstOrDefault(x => x.IdRichiesta == listVisure.Max(w => int.Parse(w.IdRichiesta)).ToString());
                                rnaLogVisureCollection = rnaLogVisureCollectionProvider.Find(null, null, null, vRnaEsitoVisura.IdRichiesta, null, null, null, null, null);
                                clVAiuti = string.Format("<td><a href=\"javascript:fnRNAScaricaVisura({0})\">Scarica Visura</a></td>", rnaLogVisureCollection[0].IdArchivioFile);
                            }
                            else
                                clVAiuti = "<td></td>";

                            //Visura De Minimis 
                            statoV = getStatoVisura(idProgetto, esitoImpresa.IdImpresa, tipoVisura.deminimis.ToString());
                            if (statoV == statoVisura.daVerificare)
                                clVMinimis = string.Format("<td><a href=\"javascript:scaricaVisura({0}, {1}, '{2}')\">Verifica Visura</a></td>", idProgetto, esitoImpresa.IdImpresa, tipoVisura.deminimis);
                            else
                                if (statoV == statoVisura.daScaricare)
                            {
                                vRnaEsitoVisureCollection = new VrnaEsitoVisureCollectionProvider().Find(null, idProgetto, esitoImpresa.IdImpresa, null, tipoVisura.deminimis.ToString());
                                var listVisure = vRnaEsitoVisureCollection.ToArrayList<SiarLibrary.VrnaEsitoVisure>();
                                vRnaEsitoVisura = listVisure.FirstOrDefault(x => x.IdRichiesta == listVisure.Max(w => int.Parse(w.IdRichiesta)).ToString());
                                rnaLogVisureCollection = rnaLogVisureCollectionProvider.Find(null, null, null, vRnaEsitoVisura.IdRichiesta, null, null, null, null, null);
                                clVMinimis = string.Format("<td><a href=\"javascript:fnRNAScaricaVisura({0})\">Scarica Visura</a></td>", rnaLogVisureCollection[0].IdArchivioFile);
                            }
                            else
                                clVMinimis = "<td></td>";

                            //Visura Deggendorf 
                            statoV = getStatoVisura(idProgetto, esitoImpresa.IdImpresa, tipoVisura.deggendorf.ToString());
                            if (statoV == statoVisura.daVerificare)
                                clVDeggendorf = string.Format("<td><a href=\"javascript:scaricaVisura({0}, {1}, '{2}')\">Verifica Visura</a></td>", idProgetto, esitoImpresa.IdImpresa, tipoVisura.deggendorf);
                            else
                                if (statoV == statoVisura.daScaricare)
                            {
                                vRnaEsitoVisureCollection = new VrnaEsitoVisureCollectionProvider().Find(null, idProgetto, esitoImpresa.IdImpresa, null, tipoVisura.deggendorf.ToString());
                                var listVisure = vRnaEsitoVisureCollection.ToArrayList<SiarLibrary.VrnaEsitoVisure>();
                                vRnaEsitoVisura = listVisure.FirstOrDefault(x => x.IdRichiesta == listVisure.Max(w => int.Parse(w.IdRichiesta)).ToString());
                                rnaLogVisureCollection = rnaLogVisureCollectionProvider.Find(null, null, null, vRnaEsitoVisura.IdRichiesta, null, null, null, null, null);
                                clVDeggendorf = string.Format("<td><a href=\"javascript:fnRNAScaricaVisura({0})\">Scarica Visura</a></td>", rnaLogVisureCollection[0].IdArchivioFile);
                            }
                            else
                                clVDeggendorf = "<td></td>";

                            clDataCOR = "<td></td>";
                            clAnnulla = "<td></td>";
                            clRichiediVisura = string.Format("<td><input type='button' class='ButtonGrid' id=\"btnRichiediVisure\" runat=\"server\" value=\"Richiedi\" onclick=\"richiediVisura({0}, {1}, this)\"></td>", idProgetto, esitoImpresa.IdImpresa);
                            clComboVisure = string.Format("<td><select id='cmbTipoVisura_{0}_{1}'><option value = \"aiuti\"> Aiuti </option><option value = \"deminimis\"> De Minimis </option><option value = \"deggendorf\"> Deggendorf </option></ select></td>", idProgetto, esitoImpresa.IdImpresa);

                            switch (statoConcessione)
                            {
                                case (StatoConcessione.daVerificareEsito):
                                    clInviaRic = string.Format("<td><input type='button' class='ButtonGrid' id='btnInviaRichiesta' runat='server' value='Verifica Esito' onclick=\"inviaRichiestaAiuto({0}, {1})\"></td>", idProgetto, esitoImpresa.IdImpresa);
                                    clStato = "<td>Esito da verificare</td>";
                                    clIdRichiesta = string.Format("<td>{0}</td>", esitoImpresa.IdRichiesta);
                                    clCOR = "<td></td>";
                                    break;
                                case StatoConcessione.daConfermareCOR:
                                    if (attoConcessionePresente || !produzione)
                                        clInviaRic = string.Format("<td><input type='button' class='ButtonGrid' id='btnInviaRichiesta' runat='server' value='Conferma COR' onclick=\"inviaRichiestaAiuto({0}, {1})\"></td>", idProgetto, esitoImpresa.IdImpresa);
                                    else
                                        clInviaRic = string.Format("<td><input type='button' class='ButtonGrid' id='btnInviaRichiesta' runat='server' value='Conferma COR' disabled='disabled' onclick=\"inviaRichiestaAiuto({0}, {1})\"></td>", idProgetto, esitoImpresa.IdImpresa);

                                    clIdRichiesta = string.Format("<td>{0}</td>", esitoImpresa.IdRichiesta);
                                    clStato = "<td>COR da confermare</td>";
                                    clCOR = string.Format("<td>{0}</td>", esitoImpresa.Cor);
                                    clAnnulla = string.Format("<td><input type='button' class='ButtonGrid' id=\"btnAnnullaAiuto\" runat=\"server\" value=\"Annulla Richiesta\" onclick=\"annullaRichiesta({0})\"></td>", esitoImpresa.IdRichiesta);
                                    clDataCOR = string.Format("<td>{0}</td>", esitoImpresa.DataAssegnazioneCor);
                                    break;
                                case StatoConcessione.completata:
                                    clInviaRic = string.Format("<td></td>");
                                    clIdRichiesta = string.Format("<td>{0}</td>", esitoImpresa.IdRichiesta);
                                    clStato = "<td>Completata</td>";
                                    clCOR = string.Format("<td>{0}</td>", esitoImpresa.Cor);
                                    clAnnulla = "<td></td>";
                                    clDataCOR = string.Format("<td>{0}</td>", esitoImpresa.DataAssegnazioneCor);
                                    break;
                                case StatoConcessione.erroreRichiesta:
                                    clInviaRic = string.Format("<td><input type='button' class='ButtonGrid' id='btnInviaRichiesta' runat='server' value='Richiedi nuovamente' onclick=\"inviaRichiestaAiuto({0}, {1})\"></td>", idProgetto, esitoImpresa.IdImpresa);
                                    clIdRichiesta = string.Format("<td>{0}</td>", esitoImpresa.IdRichiesta);
                                    clStato = "<td>Richiesta fallita</td>";
                                    clCOR = "<td></td>";
                                    break;
                                default:
                                    clInviaRic = string.Format("<td><input type='button' class='ButtonGrid' id='btnInviaRichiesta' runat='server' value='Richiedi COR' onclick=\"inviaRichiestaAiuto({0}, {1})\"></td>", idProgetto, esitoImpresa.IdImpresa);
                                    clIdRichiesta = "<td></td>";
                                    clStato = "<td>Da Inviare</td>";
                                    clCOR = "<td></td>";
                                    break;
                            }
                            if (!inviabile)
                                clInviaRic = clInviaRic.Replace("<input type='button'", "<input type='button' disabled='disabled'");
                            riga += clIdImpresa + clRagSociale + clComboVisure + clRichiediVisura + clVAiuti + clVMinimis + clVDeggendorf + clStato + clIdRichiesta + clCOR + clDataCOR + clInviaRic + clAnnulla + "</tr>";
                            righeTabella += riga;
                        }
                    }
                    if (countNumImprese == 0)
                        dgi.Style.Add("display", "none");
                    else
                    {
                        tabellaImpresa += headTabella1 + headTabella + righeTabella + fineTabellaImpresa;
                        dgi.Cells[nColonneProgetti - 1].Text += tabellaImpresa;
                        nProgetti++;
                    }
                    countNumImprese = 0;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + idProgetto.ToString());
            }
        }

        private void gestisciRichiesta()
        {
            string parameter = Request["__EVENTARGUMENT"];
            produzione = getProduzione();
            RnaBandoConfig rnaBando = new RnaBandoConfig();
            if (!string.IsNullOrEmpty(hdnBandoSelezionato.Value))
            {
                vRnaEsitoVisure = new VrnaEsitoVisureCollectionProvider().Find(int.Parse(hdnBandoSelezionato.Value), null, null, null, null);
                vRnaEsitoConcessioneCollection = new VrnaEsitoConcessioneCollectionProvider().Find(int.Parse(hdnBandoSelezionato.Value), null, null, null);
                rnaBando = new RnaBandoConfigCollectionProvider().Select(null, int.Parse(hdnBandoSelezionato.Value), null, null, null, null, null)[0];
            }
            switch (parameter)
            {
                case "btnInviaRichiesta":
                    {
                        int idProgetto = int.Parse(hdnProgettoVisura.Value);
                        int idImpresa = int.Parse(hdnImpresaVisura.Value);
                        int idBandoRna = getIdBandoRna(int.Parse(hdnBandoSelezionato.Value),produzione);
                        VrnaEsitoConcessione impresa = vRnaEsitoConcessioneCollection.ToArrayList<VrnaEsitoConcessione>().FirstOrDefault(x => (x.IdImpresa == idImpresa) && (x.IdProgetto == idProgetto));
                        RnaOperazioni rnaOp = new RnaOperazioni(rnaBando.IdRnaEnte);
                        ProjectInfo projectInfo = new ProjectInfo()
                        {
                            IdProgetto = idProgetto,
                            IdImpresa = idImpresa,
                            IdFiscaleImpresa = impresa.CodiceFiscale,
                            CodiceBandoRna = idBandoRna.ToString(),
                            IdOperatore = Operatore.Utente.IdUtente
                        };
                        StatoConcessione statoC = getStatoConcessione(impresa);
                        if (statoC == StatoConcessione.daInviare)
                        {
                            rnaOp.RegistraAiutoSingolaImpresa(projectInfo,produzione);
                            System.Threading.Thread.Sleep(int.Parse(hdnTempoSleep.Value));
                            ShowMessage("Richiesta effettuata con successo");
                        }

                        if (statoC == StatoConcessione.erroreRichiesta)
                        {
                            rnaOp.RegistraAiutoSingolaImpresa(projectInfo,produzione);
                            System.Threading.Thread.Sleep(int.Parse(hdnTempoSleep.Value));
                            ShowMessage("Richiesta inviata nuovamente. Se l'errore si ripresenta, contattare l'help desk");
                        }
                        if (statoC == StatoConcessione.daVerificareEsito)
                        {
                            rnaOp.AggiornaStatoConcessione(impresa.IdRichiesta, produzione);
                            ShowMessage("Esito verificato");
                        }
                        if (statoC.Equals(StatoConcessione.daConfermareCOR))
                        {
                            SiarBLL.GraduatoriaProgettiAttiCollectionProvider graduatoriaProgettiAttiCollectionProvider = new SiarBLL.GraduatoriaProgettiAttiCollectionProvider();
                            SiarLibrary.GraduatoriaProgettiAttiCollection graduatoriaProgettiAttiCollection = graduatoriaProgettiAttiCollectionProvider.Find(null, idProgetto, null, null);
                            if (graduatoriaProgettiAttiCollection.Count != 0)
                                if (graduatoriaProgettiAttiCollection[graduatoriaProgettiAttiCollection.Count - 1].IdAtto != null)
                                    attoConcessionePresente = true;
                            if (produzione)
                            {
                                if (attoConcessionePresente)
                                {
                                    SiarLibrary.Atti atti = new SiarBLL.AttiCollectionProvider().GetById(graduatoriaProgettiAttiCollection[0].IdAtto);
                                    var ris = rnaOp.ConfermaConcessione(impresa.Cor, Operatore.Utente.IdUtente, atti.Numero.ToString(), atti.Data);
                                }
                                else
                                {
                                    ShowError("Atto di concessione non trovato");
                                }
                                
                            }
                            else
                            {
                                var ris = rnaOp.ConfermaConcessione(impresa.Cor, Operatore.Utente.IdUtente, "100", DateTime.Now);
                            }
                        }
                    }
                    break;

                case "btnScaricaVisura":
                    {
                        int idProgetto = int.Parse(hdnProgettoVisura.Value);
                        int idImpresa = int.Parse(hdnImpresaVisura.Value);
                        SiarLibrary.Impresa impresa = new SiarBLL.ImpresaCollectionProvider().GetById(idImpresa);
                        RnaOperazioni rnaOp = new RnaOperazioni(rnaBando.IdRnaEnte);
                        ProjectInfo projectInfo = new ProjectInfo()
                        {
                            IdProgetto = idProgetto,
                            IdImpresa = idImpresa,
                            IdFiscaleImpresa = impresa.Cuaa,
                            IdOperatore = Operatore.Utente.IdUtente
                        };
                        string tipoV = hdnTipoRichiestaV.Value;
                        scaricaVisura(projectInfo, tipoV);
                    }
                    break;
                case "btnRichiediVisureProgetto":
                    {
                        int idProgetto = int.Parse(hdnIdProgettoRichiesta.Value);
                        richiediVisureProgetto(idProgetto);
                        ShowMessage("Visure richieste con successo");
                    }
                    break;
                case "btnInviaRichiesteProgetto":
                    {
                        int idProgetto = int.Parse(hdnIdProgettoRichiesta.Value);
                        inviaRichiesteProgetto(idProgetto);
                        ShowMessage("Richieste inviate con successo");
                    }
                    break;
                case "btnAnnullaRichiesta":
                    int idRichiesta = int.Parse(hdnIdRichiestaAnnulla.Value);
                    annullaRichiesta(idRichiesta);
                    ShowMessage("Richiesta annullata con successo");
                    break;
                case "btnAzioneProgetto":
                    {
                        int idProgetto = int.Parse(hdnIdProgAzioneProgetto.Value);
                        switch (hdnAzioneProgetto.Value)
                        {
                            case "richiediVisure":
                                richiediVisureProgetto(idProgetto);
                                ShowMessage("Richieste effettuate con successo");
                                break;
                            case "richiediAiuti":

                                inviaRichiesteProgetto(idProgetto);
                                ShowMessage("Richieste effettuate con successo");
                                break;
                            case "verificaEsiti":

                                verificaEsitiProgetto(idProgetto);
                                ShowMessage("Esiti verificati con successo");
                                break;
                            case "confermaCor":

                                confermaCorProgetto(idProgetto);
                                ShowMessage("Cor confermati con successo");
                                break;
                            case "annullaRichieste":

                                annullaRichiesteProgetto(idProgetto);
                                ShowMessage("Cor annullati con successo");
                                break;
                        }
                    }
                    break;
            }
        }

        private statoVisura getStatoVisura(int idProgetto, int idImpresa, string tipoV)
        {
            statoVisura result;
            VrnaEsitoVisureCollection vRnaEsitoVisureCollection = new VrnaEsitoVisureCollectionProvider().Find(null, idProgetto, idImpresa, null, tipoV);
            var listVisure = vRnaEsitoVisureCollection.ToArrayList<SiarLibrary.VrnaEsitoVisure>();
            VrnaEsitoVisure vRnaEsitoVisura = listVisure.FirstOrDefault(x => x.IdRichiesta == listVisure.Max(w => int.Parse(w.IdRichiesta)).ToString());
             //vrnaEsitoVisura = vRnaEsitoVisure.ToArrayList<VrnaEsitoVisure>().FirstOrDefault(x => x.IdProgetto == idProgetto && x.IdImpresa == idImpresa && x.TipoVisura == tipoV);
            if (vRnaEsitoVisura == null)
                result = statoVisura.darichiedere;
            else
                if (vRnaEsitoVisura.DescrizioneStatoRichiesta == "Completata")
                result = statoVisura.daScaricare;
            else
                result = statoVisura.daVerificare;
            return result;
        }

        private void scaricaVisura(ProjectInfo projectInfo, string tipoV)
        {
            try
            {
                var rnaBando = new RnaBandoConfigCollectionProvider().Select(null, int.Parse(hdnBandoSelezionato.Value), null, null, null, null, null)[0];
                RnaOperazioni rnaOp = new RnaOperazioni(rnaBando.IdRnaEnte);
                RnaLogVisureCollectionProvider rnaLogVisureCollectionProvider = new RnaLogVisureCollectionProvider();
                RnaLogVisureCollection rnaLogVisureCollection = new RnaLogVisureCollection();
                rnaLogVisureCollection = rnaLogVisureCollectionProvider.Find(null, projectInfo.IdProgetto, projectInfo.IdImpresa, null, tipoV, null, null, null, null);
                //inserisci file in archivio file e poi redirect 
                if (rnaLogVisureCollection.Count == 1)
                {
                    ResultInfoVisura risVisura = rnaOp.GetVisura(rnaLogVisureCollection[0].IdRichiesta);
                    if (risVisura.DescrizioneEsito == "Richiesta elaborata correttamente")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "myJsFn", "btnSNCUFVisualizzaFile(2);", true);
                    }
                    else
                        ShowError("Visura non ancora elaborata");
                }
            }
            catch (Exception e)
            { throw new Exception(e.Message); }
        }




        private int getIdBandoRna(int idBando,bool produzione)
        {
            if (produzione)
            {
                int result = -1;
                string strSql = String.Format(@"SELECT COD_BANDO_RNA FROM RNA_BANDO_CONFIG
                                                WHERE ID_BANDO = @IdBando");

                SiarLibrary.DbProvider dbPro = new SiarLibrary.DbProvider();
                IDbCommand cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IdBando", idBando));
                dbPro.InitDatareader(cmd);
                while (dbPro.DataReader.Read())
                {
                    result = dbPro.DataReader.GetInt32(0);
                }
                dbPro.Close();
                return result;
            }
            else
            {
                int result = -1;
                string strSql = String.Format(@"SELECT COD_BANDO_RNA_COLLAUDO FROM RNA_BANDO_CONFIG
                                                WHERE ID_BANDO = @IdBando");

                SiarLibrary.DbProvider dbPro = new SiarLibrary.DbProvider();
                IDbCommand cmd = dbPro.GetCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IdBando", idBando));
                dbPro.InitDatareader(cmd);
                while (dbPro.DataReader.Read())
                {
                    result = dbPro.DataReader.GetInt32(0);
                }
                dbPro.Close();
                return result;
            }
        }
        
        protected void btnFiltra_Click(object sender, EventArgs e)
        {

        }

        protected void btnRichiediVisura_Click(object sender, EventArgs e)
        {
            int idProgetto = int.Parse(hdnProgettoVisura.Value);
            int idImpresa = int.Parse(hdnImpresaVisura.Value);
            SiarLibrary.Impresa impresa = new ImpresaCollectionProvider().GetById(idImpresa);
            var rnaBando = new RnaBandoConfigCollectionProvider().Select(null, int.Parse(hdnBandoSelezionato.Value), null, null, null, null, null)[0];
            RnaOperazioni rnaOp = new RnaOperazioni(rnaBando.IdRnaEnte);
            ProjectInfo projectInfo = new ProjectInfo()
            {
                IdProgetto = idProgetto,
                IdImpresa = idImpresa,
                IdFiscaleImpresa = impresa.Cuaa,
                IdOperatore = Operatore.Utente.IdUtente
            };
            string tipoV = hdnTipoRichiestaV.Value;

            ResultInfoVisura ris = new ResultInfoVisura();

            if (tipoV == tipoVisura.deggendorf.ToString())
            {
                ris = rnaOp.RequestVisuraDeggendorf(projectInfo);
            }
            else if (tipoV == tipoVisura.deminimis.ToString())
            {
                ris = rnaOp.RequestVisuraDeminimis(projectInfo, new DateTime(DateTime.Now.Year, 12, 31), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
            }
            else if (tipoV == tipoVisura.aiuti.ToString())
            {
                ris = rnaOp.RequestVisuraAiuti(projectInfo, new DateTime(DateTime.Now.Year - 10, DateTime.Now.Month, DateTime.Now.Day));
            }
            if (ris.DescrizioneEsito == "Richiesta elaborata correttamente")
                ShowMessage("Visura richiesta con successo");
            else
                ShowError(ris.DescrizioneEsito);
        }

        protected void btnScaricaVisura_Click(object sender, EventArgs e)
        {
            int idProgetto = int.Parse(hdnProgettoVisura.Value);
            int idImpresa = int.Parse(hdnImpresaVisura.Value);
            string tipoV = hdnTipoRichiestaV.Value;
            SiarLibrary.Impresa impresa = new ImpresaCollectionProvider().GetById(idImpresa);
            var rnaBando = new RnaBandoConfigCollectionProvider().Select(null, int.Parse(hdnBandoSelezionato.Value), null, null, null, null, null)[0];
            RnaOperazioni rnaOp = new RnaOperazioni(rnaBando.IdRnaEnte);

            ResultInfoVisura risVisura;
            RnaLogVisureCollectionProvider rnaLogVisureCollectionProvider = new RnaLogVisureCollectionProvider();
            RnaLogVisureCollection rnaLogVisureCollection;
            ArchivioFileCollectionProvider archivioFileCollectionProvider = new ArchivioFileCollectionProvider();
            SiarLibrary.Impresa imp = new SiarBLL.ImpresaCollectionProvider().GetById(idImpresa);

            rnaLogVisureCollection = rnaLogVisureCollectionProvider.Find(null, idProgetto, idImpresa, null, tipoV, null, null, null, null);
            RnaLogVisure visura = rnaLogVisureCollection.ToArrayList<RnaLogVisure>().FirstOrDefault(x => x.DataInserimento == rnaLogVisureCollection.ToArrayList<RnaLogVisure>().Max(w => w.DataInserimento));

            if (visura != null)
            {
                risVisura = rnaOp.GetVisura(visura.IdRichiesta);
                if (risVisura.DescrizioneEsito == "Autenticazione non valida")
                { ShowError("Credenziali RNA Errate, il suo ente deve prima essere abilitato per l'invio al servizio RNA. "); }
                else
                {
                    if (risVisura.DescrizioneEsito == "Richiesta elaborata correttamente")
                    {
                        string nome = tipoV.ToUpper() + "_" + idProgetto.ToString() + "_" + visura.IdFiscaleImpresa;
                        ArchivioFile archivioFile = new ArchivioFile()
                        {
                            Tipo = "application/pdf",
                            Dimensione = 1,
                            NomeFile = nome,
                            NomeCompleto = visura.IdRichiesta,
                            Contenuto = risVisura.PayloadEsito
                        };
                        archivioFileCollectionProvider.Save(archivioFile);
                        ArchivioFileCollection archivioFileCollection = archivioFileCollectionProvider.Find(null, nome, null);
                        rnaLogVisureCollection = rnaLogVisureCollectionProvider.Find(null, idProgetto, idImpresa, null, tipoV, null, null, null, null);
                        visura = rnaLogVisureCollection.ToArrayList<RnaLogVisure>().FirstOrDefault(x => x.DataInserimento == rnaLogVisureCollection.ToArrayList<RnaLogVisure>().Max(w => w.DataInserimento));
                        archivioFile = archivioFileCollection.ToArrayList<ArchivioFile>().FirstOrDefault(x => x.NomeCompleto == visura.IdRichiesta);
                        visura.IdArchivioFile = archivioFile.Id;
                        rnaLogVisureCollectionProvider.Save(visura);
                        ShowMessage("La visura è pronta per il download");
                    }
                    else
                        ShowError(risVisura.DescrizioneEsito);
                }
            }
        }

        private StatoConcessione getStatoConcessione(VrnaEsitoConcessione vrnaEsitoConcessione)
        {
            return (StatoConcessione)Enum.Parse(typeof(StatoConcessione), vrnaEsitoConcessione.StatoConcessione);
        }

        protected void btnFiltraProgetti_Click(object sender, EventArgs e)
        {

        }


        private bool filtraImpresa(VrnaEsitoConcessione vRnaEsitoConcessione)
        {
            bool result = true;
            if (!string.IsNullOrEmpty(txtIdProgettoRNA.Text))
            {
                if (!(txtIdProgettoRNA.Text.Replace(" ", "") == vRnaEsitoConcessione.IdProgetto))
                    result = false;
            }
            if (!string.IsNullOrEmpty(txtIdRichiestaRNA.Text))
            {
                if (!(txtIdRichiestaRNA.Text.Replace(" ", "") == vRnaEsitoConcessione.IdRichiesta))
                    result = false;
            }
            if (!string.IsNullOrEmpty(hdnFiltroStatoProgetto.Value))
            {
                if (getStatoProgetto(vRnaEsitoConcessione) != "Richiedibile")
                    return false;
                if (!(vRnaEsitoConcessione.StatoConcessione == hdnFiltroStatoProgetto.Value))
                    result = false;
            }
            if (!string.IsNullOrEmpty(dataCorDa.Text))
            {
                SiarLibrary.NullTypes.DatetimeNT dataDa = new SiarLibrary.NullTypes.DatetimeNT(dataCorDa.Text);
                if (vRnaEsitoConcessione.DataAssegnazioneCor < dataDa)
                    result = false;
            }
            if (!string.IsNullOrEmpty(dataCorA.Text))
            {
                SiarLibrary.NullTypes.DatetimeNT dataA = new SiarLibrary.NullTypes.DatetimeNT(dataCorA.Text);
                if (vRnaEsitoConcessione.DataAssegnazioneCor > dataA)
                    result = false;
            }
            return result;
        }

        private void richiediVisureProgetto(int idProgetto)
        {
            var rnaBando = new RnaBandoConfigCollectionProvider().Select(null, int.Parse(hdnBandoSelezionato.Value), null, null, null, null, null)[0];
            vRnaEsitoConcessioneCollection = new VrnaEsitoConcessioneCollectionProvider().Find(int.Parse(hdnBandoSelezionato.Value), null, null, null);
            RnaOperazioni rnaOp = new RnaOperazioni(rnaBando.IdRnaEnte);
            var esitoImprese = vRnaEsitoConcessioneCollection.ToArrayList<VrnaEsitoConcessione>().Where(x => x.IdProgetto == idProgetto);
            foreach (VrnaEsitoConcessione esitoImpresa in esitoImprese)
            {
                try
                {
                    int idImpresa = esitoImpresa.IdImpresa;
                    ProjectInfo projectInfo = new ProjectInfo()
                    {
                        IdProgetto = idProgetto,
                        IdImpresa = idImpresa,
                        IdFiscaleImpresa = esitoImpresa.CodiceFiscale,
                        IdOperatore = Operatore.Utente.IdUtente
                    };

                        rnaOp.RequestVisuraAiuti(projectInfo, new DateTime(DateTime.Now.Year - 10, DateTime.Now.Month, DateTime.Now.Day));

                        rnaOp.RequestVisuraDeggendorf(projectInfo);

                        rnaOp.RequestVisuraDeminimis(projectInfo, new DateTime(DateTime.Now.Year, 12, 31), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));

                    ShowMessage("Visure richieste con successo");
                }
                catch (Exception e)
                { throw new Exception(e.Message); }
            }
        }

        private void inviaRichiesteProgetto(int idProgetto)
        {
            
            int idBandoRna = getIdBandoRna(int.Parse(hdnBandoSelezionato.Value),produzione);
            var impresePerProgetto = vRnaEsitoConcessioneCollection.ToArrayList<VrnaEsitoConcessione>().Where(x => x.IdProgetto == idProgetto);
            var rnaBando = new RnaBandoConfigCollectionProvider().Select(null, int.Parse(hdnBandoSelezionato.Value), null, null, null, null, null)[0];
            foreach (VrnaEsitoConcessione impresa in impresePerProgetto)
            {
                if (countRichiesteMassive >= int.Parse(hdnMassimoMassivo.Value))
                    break;
                if (getStatoProgetto(impresa)== "Richiedibile")
                {
                    try
                    {
                        RnaOperazioni rnaOp = new RnaOperazioni(rnaBando.IdRnaEnte);
                        ProjectInfo projectInfo = new ProjectInfo()
                        {
                            IdProgetto = idProgetto,
                            IdImpresa = impresa.IdImpresa,
                            IdFiscaleImpresa = impresa.CodiceFiscale,
                            CodiceBandoRna = idBandoRna.ToString(),
                            IdOperatore = Operatore.Utente.IdUtente
                        };
                        StatoConcessione statoC = getStatoConcessione(impresa);
                        if (statoC == StatoConcessione.daInviare || statoC == StatoConcessione.erroreRichiesta)
                        {
                            rnaOp.RegistraAiutoSingolaImpresa(projectInfo,produzione);
                            countRichiesteMassive++;
                            System.Threading.Thread.Sleep(int.Parse(hdnTempoSleep.Value));
                        }
                    }
                    catch (Exception e)
                    { throw new Exception(e.Message); }
                }
            }
        }

        private void verificaEsitiProgetto(int idProgetto)
        {
            produzione = getProduzione();
            int idBandoRna = getIdBandoRna(int.Parse(hdnBandoSelezionato.Value),produzione);
            var esitoImpresePerProgetto = vRnaEsitoConcessioneCollection.ToArrayList<VrnaEsitoConcessione>().Where(x => x.IdProgetto == idProgetto);
            var rnaBando = new RnaBandoConfigCollectionProvider().Select(null,int.Parse(hdnBandoSelezionato.Value), idBandoRna, null, null, null, null)[0];
            foreach (VrnaEsitoConcessione esitoImpresa in esitoImpresePerProgetto)
            {
                try
                {
                    RnaOperazioni rnaOp = new RnaOperazioni(rnaBando.IdRnaEnte);
                    ProjectInfo projectInfo = new ProjectInfo()
                    {
                        IdProgetto = idProgetto,
                        IdImpresa = esitoImpresa.IdImpresa,
                        IdFiscaleImpresa = esitoImpresa.CodiceFiscale,
                        CodiceBandoRna = idBandoRna.ToString(),
                        IdOperatore = Operatore.Utente.IdUtente
                    };
                    StatoConcessione statoC = getStatoConcessione(esitoImpresa);
                    if (statoC == StatoConcessione.daVerificareEsito)
                        rnaOp.AggiornaStatoConcessione(esitoImpresa.IdRichiesta, produzione);
                }
                catch (Exception e)
                { throw new Exception(e.Message); }
            }
        }

        private void annullaRichiesteProgetto(int idProgetto)
        {
            int idBandoRna = getIdBandoRna(int.Parse(hdnBandoSelezionato.Value),produzione);
            var esitoImpresePerProgetto = vRnaEsitoConcessioneCollection.ToArrayList<VrnaEsitoConcessione>().Where(x => x.IdProgetto == idProgetto);
            var rnaBando = new RnaBandoConfigCollectionProvider().Select(null, int.Parse(hdnBandoSelezionato.Value), idBandoRna, null, null, null, null)[0];
            foreach (VrnaEsitoConcessione esitoImpresa in esitoImpresePerProgetto)
            {
                try
                {
                    RnaOperazioni rnaOp = new RnaOperazioni(rnaBando.IdRnaEnte);
                    ProjectInfo projectInfo = new ProjectInfo()
                    {
                        IdProgetto = idProgetto,
                        IdImpresa = esitoImpresa.IdImpresa,
                        IdFiscaleImpresa = esitoImpresa.CodiceFiscale,
                        CodiceBandoRna = idBandoRna.ToString(),
                        IdOperatore = Operatore.Utente.IdUtente
                    };
                    StatoConcessione statoC = getStatoConcessione(esitoImpresa);
                    if (statoC == StatoConcessione.daConfermareCOR)
                        rnaOp.AnnullaConcessione(esitoImpresa.Cor, Operatore.Utente.IdUtente);
                }
                catch (Exception e)
                { throw new Exception(e.Message); }
            }
        }


        private void confermaCorProgetto(int idProgetto)
        {
            int idBandoRna = getIdBandoRna(int.Parse(hdnBandoSelezionato.Value),produzione);
            var esitoImpresePerProgetto = vRnaEsitoConcessioneCollection.ToArrayList<VrnaEsitoConcessione>().Where(x => x.IdProgetto == idProgetto);
            var rnaBando = new RnaBandoConfigCollectionProvider().Select(null, int.Parse(hdnBandoSelezionato.Value), idBandoRna, null, null, null, null)[0];
            GraduatoriaProgettiAttiCollectionProvider graduatoriaProgettiAttiCollectionProvider = new GraduatoriaProgettiAttiCollectionProvider();
            GraduatoriaProgettiAttiCollection graduatoriaProgettiAttiCollection = graduatoriaProgettiAttiCollectionProvider.Find(null, idProgetto, null, null);
            if (graduatoriaProgettiAttiCollection.Count != 0)
                if (graduatoriaProgettiAttiCollection[graduatoriaProgettiAttiCollection.Count - 1].IdAtto != null)
                    attoConcessionePresente = true;

            Atti atti = new AttiCollectionProvider().GetById(graduatoriaProgettiAttiCollection[0].IdAtto);
            foreach (VrnaEsitoConcessione esitoImpresa in esitoImpresePerProgetto)
            {
                try
                {
                    RnaOperazioni rnaOp = new RnaOperazioni(rnaBando.IdRnaEnte);
                    ProjectInfo projectInfo = new ProjectInfo()
                    {
                        IdProgetto = idProgetto,
                        IdImpresa = esitoImpresa.IdImpresa,
                        IdFiscaleImpresa = esitoImpresa.CodiceFiscale,
                        CodiceBandoRna = idBandoRna.ToString(),
                        IdOperatore = Operatore.Utente.IdUtente
                    };
                    StatoConcessione statoC = getStatoConcessione(esitoImpresa);
                    if (statoC == StatoConcessione.daConfermareCOR)
                    {
                        if (produzione)
                        {
                            if (attoConcessionePresente)
                            {
                                var ris = rnaOp.ConfermaConcessione(esitoImpresa.Cor, Operatore.Utente.IdUtente, atti.Numero.ToString(), atti.Data);
                                //var dataAtto = DateTime.Parse(atti.Data);
                                
                                //var ris = rnaOp.ConfermaConcessione(esitoImpresa.Cor, Operatore.Utente.IdUtente, atti.Numero.ToString(), new DateTime(dataAtto.Year, dataAtto.Month, dataAtto.Day));
                            }                               
                        }
                        else
                        {
                            var ris = rnaOp.ConfermaConcessione(esitoImpresa.Cor, Operatore.Utente.IdUtente, "100", DateTime.Now);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        protected void btnSalvaDataConcessione_Click(object sender, EventArgs e)
        {
            try
            {
                SiarBLL.RnaBandoConfigCollectionProvider rnaBandoConfigCollectionProvider = new SiarBLL.RnaBandoConfigCollectionProvider();
                SiarLibrary.RnaBandoConfig rnaBandoConfig = rnaBandoConfigCollectionProvider.Select(null, int.Parse(hdnBandoSelezionato.Value), null, null, null, null, null)[0];
                rnaBandoConfig.DataPrevistaConcessione = new SiarLibrary.NullTypes.DatetimeNT(txtDataConcessione.Text);
                rnaBandoConfigCollectionProvider.Save(rnaBandoConfig);
                ShowMessage("Dati salvati con successo");
            }
            catch (Exception ex)
            { throw new Exception(ex.Message); }
        }


        protected void btnInvioMassivo_Click(object sender, EventArgs e)
        {
            vRnaEsitoVisure = new VrnaEsitoVisureCollectionProvider().Find(int.Parse(hdnBandoSelezionato.Value), null, null, null, null);
            vRnaEsitoConcessioneCollection = new VrnaEsitoConcessioneCollectionProvider().Find(int.Parse(hdnBandoSelezionato.Value), null, null, null);
            List<VrnaEsitoConcessione> vSoloProgetti = (from x in vRnaEsitoConcessioneCollection.ToArrayList<VrnaEsitoConcessione>()
                                                        group x by x.IdProgetto into g
                                                        select g.First()).ToList<VrnaEsitoConcessione>();
            vSoloProgetti = vSoloProgetti.OrderBy(x => x.Ordine).ToList();

            switch (hdnAzioneMassiva.Value)
            {
                //case "richiediVisure":
                //    foreach (VrnaEsitoConcessione progetto in vSoloProgetti)
                //    {
                //        richiediVisureProgetto(progetto.IdProgetto);
                //    }
                //    ShowMessage("Richiesta effettuata con successo");
                //    break;
                case "richiediAiuti":
                    countRichiesteMassive = 0;
                    foreach (VrnaEsitoConcessione progetto in vSoloProgetti)
                    {
                        inviaRichiesteProgetto(progetto.IdProgetto);
                    }
                    ShowMessage("Richiesta effettuata con successo");
                    break;
                case "verificaEsiti":
                    foreach (VrnaEsitoConcessione progetto in vSoloProgetti)
                    {
                        verificaEsitiProgetto(progetto.IdProgetto);
                    }
                    ShowMessage("Esiti verificati con successo");
                    break;
                case "confermaCor":
                    foreach (VrnaEsitoConcessione progetto in vSoloProgetti)
                    {
                        confermaCorProgetto(progetto.IdProgetto);
                    }
                    ShowMessage("Cor confermati con successo");
                    break;
                case "annullaRichieste":
                    foreach (VrnaEsitoConcessione progetto in vSoloProgetti)
                    {
                        annullaRichiesteProgetto(progetto.IdProgetto);
                    }
                    ShowMessage("Richieste Cor annullate");
                    break;
            }
            vRnaEsitoVisure.Clear();
            vRnaEsitoConcessioneCollection.Clear();
        }

        private void annullaRichiesta(int idRichiesta)
        {
            var rnaBando = new RnaBandoConfigCollectionProvider().Select(null, int.Parse(hdnBandoSelezionato.Value), null, null, null, null, null)[0];
            RnaOperazioni rnaOp = new RnaOperazioni(rnaBando.IdRnaEnte);
            SiarLibrary.RnaLogConcessioniCollection rnaLogConcessioniCollection = new SiarBLL.RnaLogConcessioniCollectionProvider().Find(null, null, null, null, idRichiesta.ToString());
            if (rnaLogConcessioniCollection.Count != 0)
                rnaOp.AnnullaConcessione(rnaLogConcessioniCollection[0].Cor, Operatore.Utente.IdUtente);
        }

        private string getStatoProgetto(VrnaEsitoConcessione esitoProgetto)
        {
            BandoConfigCollectionProvider bandoConfigCollectionProvider = new BandoConfigCollectionProvider();
            BandoConfigCollection bandoConfigCollection = bandoConfigCollectionProvider.Select(null, hdnBandoSelezionato.Value, "ATTGRADBLOCCHI", "True", true, null, null, null, null);
            if (bandoConfigCollection.Count != 0)
            {
                Progetto p = new ProgettoCollectionProvider().GetById(esitoProgetto.IdProgetto);
                if(p.OrdineFase>=3 && p.OrdineStato==1)
                    return "Richiedibile";
                else
                    return "Escluso";
            }
            else
            {
                if (esitoProgetto.CodStato != "G" && esitoProgetto.CodStato != "F")
                    return "Escluso";
                else if (esitoProgetto.Finanziabilita == "N")
                    return "Non Finanziabile";
                else
                    return "Richiedibile";
            }
        }


        #region COVID
        protected void btnRichiediCovid_Click(object sender, EventArgs e)
        {
            produzione = getProduzione();
            try
            {
                if (produzione)
                {
                    int countRichieste = 0;
                    int nMaxMassivo = int.Parse(hdnMassimoMassivo.Value);
                    VrnaCovidEsitoConcessioneCollection concessioniDaRichiedere = new VrnaCovidEsitoConcessioneCollection();
                    VrnaCovidEsitoConcessioneCollection esitoConcessione = new VrnaCovidEsitoConcessioneCollectionProvider().Select(int.Parse(hdnBandoSelezionato.Value), null, null, null, null, null, null, null, null, null, null, null, null, 1, null);
                    foreach (VrnaCovidEsitoConcessione esito in esitoConcessione)
                    {
                        if (esito.Produzione == null || esito.Produzione == produzione)
                            if (esito.StatoConcessione == "daInviare")
                            {
                                concessioniDaRichiedere.Add(esito);
                                countRichieste++;
                            }
                        if (countRichieste == nMaxMassivo)
                            break;
                    }
                    if (countRichieste != nMaxMassivo)
                    {
                        foreach (VrnaCovidEsitoConcessione esito in esitoConcessione)
                        {
                            if (esito.Produzione == null || esito.Produzione == produzione)
                                if (esito.StatoConcessione == "erroreRichiesta")
                                {
                                    concessioniDaRichiedere.Add(esito);
                                    countRichieste++;
                                }
                            if (countRichieste == nMaxMassivo)
                                break;
                        }
                    }
                    foreach (VrnaCovidEsitoConcessione concessione in concessioniDaRichiedere)
                    {
                        inviaRichiesteProgettoCovid(concessione);
                    }
                }
                else
                {
                    int countRichieste = 0;
                    int nMaxMassivo = int.Parse(hdnMassimoMassivo.Value);
                    VrnaCovidEsitoConcessioneCollaudoCollection concessioniDaRichiedere = new VrnaCovidEsitoConcessioneCollaudoCollection();
                    VrnaCovidEsitoConcessioneCollaudoCollection esitoConcessione = new VrnaCovidEsitoConcessioneCollaudoCollectionProvider().Select(int.Parse(hdnBandoSelezionato.Value), null, null, null, null, null, null, null, null, null, null, null, null, 1, null);
                    foreach (VrnaCovidEsitoConcessioneCollaudo esito in esitoConcessione)
                    {
                        if (esito.Produzione == null || esito.Produzione == produzione)
                            if (esito.StatoConcessione == "daInviare")
                            {
                                concessioniDaRichiedere.Add(esito);
                                countRichieste++;
                            }
                        if (countRichieste == nMaxMassivo)
                            break;
                    }
                    if (countRichieste != nMaxMassivo)
                    {
                        foreach (VrnaCovidEsitoConcessioneCollaudo esito in esitoConcessione)
                        {
                            if (esito.Produzione == null || esito.Produzione == produzione)
                                if (esito.StatoConcessione == "erroreRichiesta")
                                {
                                    concessioniDaRichiedere.Add(esito);
                                    countRichieste++;
                                }
                            if (countRichieste == nMaxMassivo)
                                break;
                        }
                    }
                    foreach (VrnaCovidEsitoConcessioneCollaudo concessione in concessioniDaRichiedere)
                    {
                        inviaRichiesteProgettoCovidCollaudo(concessione);
                    }
                }
                ShowMessage("Procedura completata con successo");
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        protected void btnVerificaCovid_Click(object sender, EventArgs e)
        {
            try
            {
                produzione = getProduzione();
                if (produzione)
                {
                    VrnaCovidEsitoConcessioneCollection esitoConcessione = new VrnaCovidEsitoConcessioneCollectionProvider().Select(int.Parse(hdnBandoSelezionato.Value), null, null, null, null, null, null, null, null, null, null, null, null, 1, null);
                    foreach (VrnaCovidEsitoConcessione esito in esitoConcessione)
                    {
                        if (esito.Produzione == null || esito.Produzione == produzione)
                            if (esito.StatoConcessione == "daVerificareEsito")
                                verificaEsitiProgettoCovid(esito);
                    }
                }
                else
                {
                    VrnaCovidEsitoConcessioneCollaudoCollection esitoConcessione = new VrnaCovidEsitoConcessioneCollaudoCollectionProvider().Select(int.Parse(hdnBandoSelezionato.Value), null, null, null, null, null, null, null, null, null, null, null, null, 1, null);
                    foreach (VrnaCovidEsitoConcessioneCollaudo esito in esitoConcessione)
                    {
                        if (esito.Produzione == null || esito.Produzione == produzione)
                            if (esito.StatoConcessione == "daVerificareEsito")
                                verificaEsitiProgettoCovidCollaudo(esito);
                    }
                }
                ShowMessage("Procedura completata con successo");
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        protected void btnConfermaCovid_Click(object sender, EventArgs e)
        {
            try
            {
                produzione = getProduzione();
                if (produzione)
                {
                    VrnaCovidEsitoConcessioneCollection esitoConcessione = new VrnaCovidEsitoConcessioneCollectionProvider().Select(int.Parse(hdnBandoSelezionato.Value), null, null, null, null, null, null, null, null, null, null, null, null, 1, null);
                    foreach (VrnaCovidEsitoConcessione esito in esitoConcessione)
                    {
                        if (esito.Produzione == null || esito.Produzione == produzione)
                            if (esito.StatoConcessione == "daConfermareCOR")
                                confermaCorProgettoCovid(esito);
                    }
                }
                else
                {
                    VrnaCovidEsitoConcessioneCollaudoCollection esitoConcessione = new VrnaCovidEsitoConcessioneCollaudoCollectionProvider().Select(int.Parse(hdnBandoSelezionato.Value), null, null, null, null, null, null, null, null, null, null, null, null, 1, null);
                    foreach (VrnaCovidEsitoConcessioneCollaudo esito in esitoConcessione)
                    {
                        if (esito.Produzione == null || esito.Produzione == produzione)
                            if (esito.StatoConcessione == "daConfermareCOR")
                                confermaCorProgettoCovidCollaudo(esito);
                    }
                }
                ShowMessage("Procedura completata con successo");
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        private void inviaRichiesteProgettoCovid(VrnaCovidEsitoConcessione concessione)
        {
            int idBandoRna = getIdBandoRna(int.Parse(hdnBandoSelezionato.Value),produzione);
            var rnaBando = new RnaBandoConfigCollectionProvider().Select(null, int.Parse(hdnBandoSelezionato.Value), idBandoRna, null, null, null, null)[0];
            try
            {
                RnaOperazioni rnaOp = new RnaOperazioni(rnaBando.IdRnaEnte);
                ProjectInfo projectInfo = new ProjectInfo()
                {
                    IdProgetto = concessione.IdProgetto,
                    IdImpresa = concessione.IdImpresa,
                    IdFiscaleImpresa = concessione.CodiceFiscale,
                    CodiceBandoRna = idBandoRna.ToString(),
                    IdOperatore = Operatore.Utente.IdUtente
                };
                rnaOp.RegistraAiutoSingolaImpresaCovid(projectInfo, produzione);
                System.Threading.Thread.Sleep(int.Parse(hdnTempoSleep.Value));
            }
            catch (Exception e)
            { throw new Exception(e.Message); }
        }

        private void inviaRichiesteProgettoCovidCollaudo(VrnaCovidEsitoConcessioneCollaudo concessione)
        {
            int idBandoRna = getIdBandoRna(int.Parse(hdnBandoSelezionato.Value),produzione);
            var rnaBando = new RnaBandoConfigCollectionProvider().Select(null, int.Parse(hdnBandoSelezionato.Value), idBandoRna, null, null, null, null)[0];
            try
            {
                RnaOperazioni rnaOp = new RnaOperazioni(rnaBando.IdRnaEnte);
                ProjectInfo projectInfo = new ProjectInfo()
                {
                    IdProgetto = concessione.IdProgetto,
                    IdImpresa = concessione.IdImpresa,
                    IdFiscaleImpresa = concessione.CodiceFiscale,
                    CodiceBandoRna = idBandoRna.ToString(),
                    IdOperatore = Operatore.Utente.IdUtente
                };
                rnaOp.RegistraAiutoSingolaImpresaCovid(projectInfo, produzione);
                System.Threading.Thread.Sleep(int.Parse(hdnTempoSleep.Value));
            }
            catch (Exception e)
            { throw new Exception(e.Message); }
        }

        private void verificaEsitiProgettoCovid(VrnaCovidEsitoConcessione esito)
        {
            try
            {
                
                int idBandoRna = getIdBandoRna(int.Parse(hdnBandoSelezionato.Value),produzione);
                var rnaBando = new RnaBandoConfigCollectionProvider().Select(null, int.Parse(hdnBandoSelezionato.Value), idBandoRna, null, null, null, null)[0];
                RnaOperazioni rnaOp = new RnaOperazioni(rnaBando.IdRnaEnte);
                ProjectInfo projectInfo = new ProjectInfo()
                {
                    IdProgetto = esito.IdProgetto,
                    IdImpresa = esito.IdImpresa,
                    IdFiscaleImpresa = esito.CodiceFiscale,
                    CodiceBandoRna = idBandoRna.ToString(),
                    IdOperatore = Operatore.Utente.IdUtente
                };
                rnaOp.AggiornaStatoConcessione(esito.IdRichiesta, produzione);
            }
            catch (Exception e)
            { throw new Exception(e.Message); }

        }

        private void verificaEsitiProgettoCovidCollaudo(VrnaCovidEsitoConcessioneCollaudo esito)
        {
            try
            {
                int idBandoRna = getIdBandoRna(int.Parse(hdnBandoSelezionato.Value),produzione);
                var rnaBando = new RnaBandoConfigCollectionProvider().Select(null, int.Parse(hdnBandoSelezionato.Value), idBandoRna, null, null, null, null)[0];
                RnaOperazioni rnaOp = new RnaOperazioni(rnaBando.IdRnaEnte);
                ProjectInfo projectInfo = new ProjectInfo()
                {
                    IdProgetto = esito.IdProgetto,
                    IdImpresa = esito.IdImpresa,
                    IdFiscaleImpresa = esito.CodiceFiscale,
                    CodiceBandoRna = idBandoRna.ToString(),
                    IdOperatore = Operatore.Utente.IdUtente
                };
                rnaOp.AggiornaStatoConcessione(esito.IdRichiesta, produzione);
            }
            catch (Exception e)
            { throw new Exception(e.Message); }

        }

        private void confermaCorProgettoCovid(VrnaCovidEsitoConcessione esito)
        {
            try
            {
                GraduatoriaProgettiAttiCollectionProvider graduatoriaProgettiAttiCollectionProvider = new GraduatoriaProgettiAttiCollectionProvider();
                GraduatoriaProgettiAttiCollection graduatoriaProgettiAttiCollection = graduatoriaProgettiAttiCollectionProvider.Find(hdnBandoSelezionato.Value, esito.IdProgetto, null, null);
                Atti atti = new AttiCollectionProvider().GetById(graduatoriaProgettiAttiCollection[0].IdAtto);
                int idBandoRna = getIdBandoRna(int.Parse(hdnBandoSelezionato.Value), produzione);
                var rnaBando = new RnaBandoConfigCollectionProvider().Select(null, int.Parse(hdnBandoSelezionato.Value), idBandoRna, null, null, null, null)[0];
                RnaOperazioni rnaOp = new RnaOperazioni(rnaBando.IdRnaEnte);
                produzione = getProduzione();

                ProjectInfo projectInfo = new ProjectInfo()
                {
                    IdProgetto = esito.IdProgetto,
                    IdImpresa = esito.IdImpresa,
                    IdFiscaleImpresa = esito.CodiceFiscale,
                    CodiceBandoRna = idBandoRna.ToString(),
                    IdOperatore = Operatore.Utente.IdUtente
                };
                var ris = rnaOp.ConfermaConcessione(esito.Cor, Operatore.Utente.IdUtente, atti.Numero.ToString(), atti.Data);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        private void confermaCorProgettoCovidCollaudo(VrnaCovidEsitoConcessioneCollaudo esito)
        {
            try
            {
                int idBandoRna = getIdBandoRna(int.Parse(hdnBandoSelezionato.Value), produzione);
                var rnaBando = new RnaBandoConfigCollectionProvider().Select(null, int.Parse(hdnBandoSelezionato.Value), idBandoRna, null, null, null, null)[0];
                RnaOperazioni rnaOp = new RnaOperazioni(rnaBando.IdRnaEnte);
                produzione = getProduzione();

                ProjectInfo projectInfo = new ProjectInfo()
                {
                    IdProgetto = esito.IdProgetto,
                    IdImpresa = esito.IdImpresa,
                    IdFiscaleImpresa = esito.CodiceFiscale,
                    CodiceBandoRna = idBandoRna.ToString(),
                    IdOperatore = Operatore.Utente.IdUtente
                };
                var ris = rnaOp.ConfermaConcessione(esito.Cor, Operatore.Utente.IdUtente, "0001", new DateTime(2020, 06, 24));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private bool getProduzione()
        {
            RnaEntiCollection rnaEntiCollection = new RnaEntiCollection();
            RnaEnti rnaEnti = new RnaEnti();
            rnaEntiCollection = RnaEntiCollectionProvider.FindCodEnte(Operatore.Utente.CodEnte);

            if (rnaEntiCollection.Count == 0)//UTENTE MAI REGISTRATO 
                return false;
            else
            {
                rnaEnti = rnaEntiCollection[0];
                if (!rnaEnti.Abilitato)//UTENTE NON ABILITATO 
                    return false;

                else
                    if (!rnaEnti.CredenzialiProduzione)
                    return false;
                else
                    return true;
            }
        }
        #endregion

        private void caricaComboEnti()
        {
            RnaEntiCollectionProvider rnaEntiCollectionProvider = new RnaEntiCollectionProvider();
            var account_disponibili = rnaEntiCollectionProvider.Select(null, Operatore.Utente.CodEnte, null, null, null, null, null, null, null);
            foreach(RnaEnti account in account_disponibili)
            {
                lstEntiRna.Items.Add(new ListItem(account.DescrizioneAccount, account.IdRnaEnte));
                lstEntiRna.SelectedValue = lstEntiRna.Items[lstEntiRna.Items.Count - 1].Value;
            }
            if (IsPostBack)
                lstEntiRna.SelectedValue = Request.Form[lstEntiRna.UniqueID];

            var enteSelezionato = new RnaEntiCollectionProvider().GetById(lstEntiRna.SelectedValue);
            lblUsernameWS.Text = "Username WS: " + enteSelezionato.Username;
        }
        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            hdnBandoSelezionato.Value = "";
            hdnProgettoSelezionato.Value = "";
        }

        protected void btnSalvaPsw_Click(object sender, EventArgs e)
        {
            RnaEntiCollectionProvider rnaEntiCollectionProvider = new RnaEntiCollectionProvider();
            RnaEntiCollection rnaEntiCollection = new RnaEntiCollection();
            RnaCryptography rnaCryptography = new RnaCryptography();
            var rnaEnte = RnaEntiCollectionProvider.Select(lstEntiRna.SelectedValue, null, null, null, null, null, null, null, null)[0];
            
            if (txtVecchiaPsw.Text != rnaCryptography.Decrypt(rnaEnte.PasswordCrypted))//verifico la vecchia password decriptata con quella vecchia inserita
                ShowError("Vecchia password non corretta");
            
            else if(txtNuovaPsw.Text!=txtConfermaPsw.Text)//guardo che le due nuove corrispondano 
                ShowError("La nuova password e la conferma non corrispondono, verificare di averle inserite correttamente");
            else//salvo
            {
                rnaEnte.DataPassword = DateTime.Now;
                rnaEnte.PasswordCrypted = rnaCryptography.Encrypt(txtNuovaPsw.Text);
                rnaEntiCollectionProvider.Save(rnaEnte);
                ShowMessage("Password aggiornata con successo");
            }
            RegisterClientScriptBlock("chiudiPopupTemplate();");
        }
    }
}