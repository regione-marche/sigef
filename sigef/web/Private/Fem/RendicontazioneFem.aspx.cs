using System;
using System.Configuration;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using SiarLibrary;
using SiarBLL;
using System.Linq;

namespace web.Private.Fem
{
    public partial class RendicontazioneFem : SiarLibrary.Web.PrivatePage
    {

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "rendicontazione_fem";
            base.OnPreInit(e);
        }

        Progetto progetto_selezionato = null;
        ProgettoSoggettoGestore progetto_gestore_selezionato = null;
        Bando bando_selezionato = null;
        BandoCollectionProvider bando_prov = new BandoCollectionProvider();
        ProgettoCollectionProvider prog_prov = new ProgettoCollectionProvider();
        ErogazioneFemCollectionProvider erog_prov = new ErogazioneFemCollectionProvider();
        ErogazioneFem erogazione_selezionata = null;
        ContrattiFemPagamentiCollectionProvider contr_pag_prov = new ContrattiFemPagamentiCollectionProvider();
        ContrattiFemCollectionProvider contr_prov = new ContrattiFemCollectionProvider();
        ErogazioneFemXDecretiCollectionProvider erog_decreti_prov = new ErogazioneFemXDecretiCollectionProvider();
        ErogazioneFemXDecreti erogazioni_decreto_selezionato = null;
        ErogazioneLiquidazioniCollectionProvider erog_liqu_prov = new ErogazioneLiquidazioniCollectionProvider();
        ErogazioneLiquidazioni erogazioni_liquid_selezionato = null;
        Atti decreto;
        AttiCollectionProvider atti_provider = new AttiCollectionProvider();
        ProgettoSoggettoGestoreCollectionProvider prog_sog_gest_prov = new ProgettoSoggettoGestoreCollectionProvider();
        SoggettoGestoreCollectionProvider sog_gest_prov = new SoggettoGestoreCollectionProvider();
        CertspDettaglioCollectionProvider certspDettaglioCollectionProvider = new CertspDettaglioCollectionProvider();
        CertspTestaCollectionProvider certspTestaCollectionProvider = new CertspTestaCollectionProvider();
        bool responsabile;


        protected void Page_Load(object sender, EventArgs e)
        {
            int id_Bando;
            if (int.TryParse(hdnIdBando.Value, out id_Bando))
            {
                bando_selezionato = bando_prov.GetById(id_Bando);
                responsabile = new BandoResponsabiliCollectionProvider().Find(bando_selezionato.IdBando, Operatore.Utente.IdUtente, null, true, true).Count > 0;
                ucFirmaDocumento.DocumentoFirmatoEvent = ProtocollaDocFirmatoEvent;

                int id_progetto;
                if (int.TryParse(hdnIdProgetto.Value, out id_progetto))
                {
                    progetto_selezionato = prog_prov.GetById(id_progetto);
                    
                    ProgettoSoggettoGestoreCollection prog_sog_coll = prog_sog_gest_prov.FindProgettiSoggettoGestore(null, progetto_selezionato.IdImpresa, null, null, null, progetto_selezionato.IdBando, progetto_selezionato.IdProgetto);
                    if (prog_sog_coll.Count == 0)
                        throw new Exception("Progetto non selezionato. Contattare l'helpdesk per risolvere il problema.");
                    progetto_gestore_selezionato = prog_sog_coll[0];

                    int erogazione;
                    if (int.TryParse(hdnIdErogazione.Value, out erogazione))
                    {
                        erogazione_selezionata = erog_prov.GetById(erogazione);

                        if (!string.IsNullOrEmpty(hdnDecretoJson.Value))
                        {
                            decreto = new SiarLibrary.Atti();
                            decreto.FillByJsonObject(hdnDecretoJson.Value);
                        }

                        int erogazioneXDecreto;
                        if (int.TryParse(hdnIdErogazioneXDecreti.Value, out erogazioneXDecreto))
                        {
                            erogazioni_decreto_selezionato = erog_decreti_prov.GetById(erogazioneXDecreto);

                            int IdLiquidazione;
                            if (int.TryParse(hdnIdLiquidazione.Value, out IdLiquidazione))
                            {
                                erogazioni_liquid_selezionato = erog_liqu_prov.GetById(IdLiquidazione);
                            }
                        }
                    }
                }   
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            imgRendicontazione.Attributes.Add("src", PATH_IMAGES + "ArrowUpSolid.png");
            BandoCollection bandi_coll = new BandoCollection();
            //ProgettoCollection prog_coll = new SiarLibrary.ProgettoCollection();

            if (bando_selezionato == null)
            {
                List<int> list_bando = new List<int>();
                ProgettoSoggettoGestoreCollection prog_gest_coll = prog_sog_gest_prov.FindProgettiSoggettoGestore(null, null, null, null, null, null, null);
                foreach (ProgettoSoggettoGestore pg in prog_gest_coll)
                {
                    if (!list_bando.Contains(pg.IdBando))
                        list_bando.Add(pg.IdBando);
                }

                foreach (int i in list_bando)
                    bandi_coll.Add(bando_prov.GetById(i));

                ucSiarNewTab.Visible = false;
            }
            else
            {
                bandi_coll.Add(bando_selezionato);

                tbProgetti.Visible = true;
                ProgettoCollection prog_coll = new ProgettoCollection();

                if (progetto_selezionato == null)
                {
                    List<int> list_prog = new List<int>();
                    ProgettoSoggettoGestoreCollection prog_gest_coll = prog_sog_gest_prov.FindProgettiSoggettoGestore(null, null, null, null, null, bando_selezionato.IdBando, null);
                    foreach (ProgettoSoggettoGestore pg in prog_gest_coll)
                    {
                        //aggiunto controllo per evitare di mettere due volte Artigiancassa dopo le modifiche del 11/06/2024
                        bool presente = false;
                        foreach (Progetto p in prog_coll)
                        {
                            if (p.IdProgetto == pg.IdProgettoRiferimento)
                                presente = true;
                        }

                        if (!presente)
                            prog_coll.Add(prog_prov.GetById(pg.IdProgettoRiferimento));
                    }
                }
                else
                {
                    prog_coll.Add(progetto_selezionato);

                    //Disabilito pulsanti se non è rup
                    if (!responsabile)
                    {
                        btnAssociaDecreto.Enabled = false;
                        btnAssociaDecreto1.Enabled = false;
                        btnConcludi.Enabled = false;
                        btnCreaErogazione.Enabled = false;
                        btnEliminaMandato.Enabled = false;
                        btnInserisciDecreto.Enabled = false;
                        btnSalvaMandato.Enabled = false;
                        btnSalvaPagAmmessi.Enabled = false;
                        btnSalvaQuietanza.Enabled = false;

                    }

                    if (progetto_selezionato != null)
                        btnStampa.Attributes.Add("onclick", "SNCVisualizzaReport('rptEstrazioneErogazioneContrattiFemXls',2,'IdProgetto=" + progetto_selezionato.IdProgetto.ToString() + "');");

                    // ricarico variabile di sessione
                    if (erogazione_selezionata != null)
                    {
                        int idEroga = erogazione_selezionata.IdErogazione;
                        erogazione_selezionata = erog_prov.GetById(idEroga);
                    }


                    tbErogazioni.Visible = true;
                    ErogazioneFemCollection erog_coll = erog_prov.FindErogazioni(null, progetto_selezionato.IdProgetto, null, null, null, null);
                    var erog_list = erog_coll.ToArrayList<ErogazioneFem>();
                    dgErogazioni.DataSource = erog_coll;
                    dgErogazioni.SetTitoloNrElementi();
                    dgErogazioni.ItemDataBound += new DataGridItemEventHandler(dgErogazioni_ItemDataBound);
                    dgErogazioni.DataBind();

                    int erog_count = erog_coll.Count;
                    if (erog_count == 0 || (erog_count > 0 && erog_coll[erog_count - 1].Definitivo == true))
                    {
                        trNuovaErogazione.Visible = true;
                    }
                    else
                    {
                        if (erogazione_selezionata == null && erog_count > 0 && erog_coll[erog_count - 1].Definitivo == false)
                        {
                            erogazione_selezionata = erog_coll[erog_count - 1];
                            hdnIdErogazione.Value = erog_coll[erog_count - 1].IdErogazione.ToString();
                        }
                    }

                    decimal totPagamentiAmmessiPrecedenti = 0;
                    if (erogazione_selezionata != null)
                    {
                        //ricarico variabile di sessione
                        int idEroga = erogazione_selezionata.IdErogazione;
                        erogazione_selezionata = erog_prov.GetById(idEroga);

                        trErogazioneSelezionata.Visible = true;
                        txtNumeroErogazione.Text = erogazione_selezionata.Numero;
                        txtSogliaContributiErog.Text = erogazione_selezionata.SogliaContributi;
                        txtSommaContrattiErog.Text = erogazione_selezionata.SommaContratti;
                        txtSommaPagamentiErog.Text = erogazione_selezionata.SommaPagamenti;
                        txtSommaPagamentiAmmessiErog.Text = erogazione_selezionata.SommaPagamentiAmmessi;
                        txtSommaDecretiErog.Text = erogazione_selezionata.SommaDecreti;
                        txtSommaDecretiAmmErog.Text = erogazione_selezionata.SommaDecretiAmmessi;
                        txtSommaMandati.Text = erogazione_selezionata.SommaMandati;
                        txtSommaQuietanza.Text = erogazione_selezionata.SommaQuietanza;

                        //bool confidi = true;
                        //if (progetto_selezionato.IdProgetto == int.Parse(ConfigurationManager.AppSettings["IdProgettoArtigiancassa"]))
                        //{
                        //    confidi = false;
                        //}

                        ErogazioneFemXDecretiCollection decreti_coll = erog_decreti_prov.FindDecretiErogazione(null, erogazione_selezionata.IdErogazione, null, progetto_selezionato.IdProgetto, null);
                        if (decreti_coll.Count == 0)
                        {
                            switch (ucSiarNewTab.TabSelected)
                            {
                                case 2:
                                    ShowError("Nessun decreto ancora collegato");
                                    ucSiarNewTab.TabSelected = 0;

                                    break;
                            }

                            trPagamentiDaIstruire.Visible = true;
                            tbDecreti.Visible = false;
                            //ContrattiFemPagamentiCollection pag_coll = contr_pag_prov.GetPagamentiPerErogazione(confidi, null, progetto_selezionato.IdProgetto);
                            ContrattiFemPagamentiCollection pag_coll = contr_pag_prov.GetPagamentiPerErogazioneSoggettoGestore(progetto_gestore_selezionato.IdSoggettoGestore,progetto_gestore_selezionato.IdProgettoSoggettoGestore, null);
                            dgPagamentiDaIstruire.DataSource = pag_coll;
                            dgPagamentiDaIstruire.ItemDataBound += new DataGridItemEventHandler(dgPagamentiDaIstruire_ItemDataBound);
                            dgPagamentiDaIstruire.SetTitoloNrElementi();
                            dgPagamentiDaIstruire.DataBind();
                            decimal TotImportoAmmessiPrecedenti_ = 0, TotImportoAmmessiPrecedentiSelezionati_ = 0;

                            ErogazioneFem erog_max = new ErogazioneFem();
                            //totPagamentiAmmessiPrecedenti = erog_list.Where(er => er.Definitivo).Sum(er => er.SommaPagamentiAmmessi ?? 0.00);
                            erog_max = erog_list.Where(er => er.Definitivo && er.IdErogazione < erogazione_selezionata.IdErogazione).OrderByDescending(er => er.IdErogazione).FirstOrDefault();
                            if (erog_max != null)
                                TotImportoAmmessiPrecedenti_ = (erog_max.SommaPagamentiAmmessi ?? 0.00);

                            TotImportoAmmessiPrecedenti.Text = TotImportoAmmessiPrecedenti_.ToString();

                            string[] selezionati = ((SiarLibrary.Web.CheckColumn)dgPagamentiDaIstruire.Columns[13]).GetSelected();
                            foreach (string s in selezionati)
                            {
                                ContrattiFemPagamenti cfp = contr_pag_prov.GetById(Convert.ToInt32(s));
                                TotImportoAmmessiPrecedentiSelezionati_ += cfp.ImportoAmmesso;
                            }
                            TotImportoAmmesso.Text = TotImportoAmmessiPrecedentiSelezionati_.ToString();
                            TotPagamentiAmmessi.Text = (TotImportoAmmessiPrecedentiSelezionati_ + TotImportoAmmessiPrecedenti_).ToString();
                        }
                        else
                        {
                            switch (ucSiarNewTab.TabSelected)
                            {
                                case 2:
                                    tbpagamenti.Visible = false;
                                    trDecreti.Visible = true;
                                    ErogazioneFemXDecretiCollection erog_dec_coll = new ErogazioneFemXDecretiCollection();
                                    if (erogazioni_decreto_selezionato == null)
                                    {
                                        trMandato.Visible = false;
                                        erogazioni_liquid_selezionato = null;
                                        hdnIdLiquidazione.Value = null;
                                        ufMandato.IdFile = null;
                                        txtMandatoNumero.Text = "";
                                        txtMandatoData.Text = "";
                                        txtMandatoImporto.Text = "";
                                        txtQuietanzaData.Text = "";
                                        txtQuietanzaImporto.Text = "";
                                        erog_dec_coll = erog_decreti_prov.FindDecretiErogazione(null, erogazione_selezionata.IdErogazione, null, progetto_selezionato.IdProgetto, null);
                                    }
                                    else
                                    {
                                        erog_dec_coll.Add(erogazioni_decreto_selezionato);
                                    }
                                    dgDecretiPag.DataSource = erog_dec_coll;
                                    dgDecretiPag.ItemDataBound += new DataGridItemEventHandler(dgDecretiPag_ItemDataBound);
                                    dgDecretiPag.SetTitoloNrElementi();
                                    dgDecretiPag.DataBind();

                                    if (erogazioni_decreto_selezionato != null)
                                    {
                                        tbDettaglioMandato.Visible = true;
                                        ErogazioneLiquidazioniCollection erog_liqu_coll = erog_liqu_prov.FindLiquidazione(null, erogazioni_decreto_selezionato.IdErogazioneXDecreti, null, null, null, erogazioni_decreto_selezionato.IdDecreto);
                                        dgDomandeLiquidazioni.DataSource = erog_liqu_coll;
                                        dgDomandeLiquidazioni.ItemDataBound += new DataGridItemEventHandler(dgDomandeLiquidazioni_ItemDataBound);
                                        dgDomandeLiquidazioni.SetTitoloNrElementi();
                                        dgDomandeLiquidazioni.DataBind();

                                        if (erogazioni_liquid_selezionato != null)
                                        {
                                            trMandato.Visible = true;
                                            ufMandato.IdFile = erogazioni_liquid_selezionato.MandatoIdFile;
                                            txtMandatoNumero.Text = erogazioni_liquid_selezionato.MandatoNumero;
                                            txtMandatoData.Text = erogazioni_liquid_selezionato.MandatoData;
                                            txtMandatoImporto.Text = erogazioni_liquid_selezionato.MandatoImporto;

                                            if (erogazioni_liquid_selezionato.QuietanzaData != null)
                                                txtQuietanzaData.Text = erogazioni_liquid_selezionato.QuietanzaData;
                                            if (erogazioni_liquid_selezionato.QuietanzaImporto != null)
                                                txtQuietanzaImporto.Text = erogazioni_liquid_selezionato.QuietanzaImporto;
                                        }
                                    }

                                    break;
                                default:

                                    tbDecreti.Visible = false;
                                    trPagamentiIstruitiPrec.Visible = true;
                                    trPagamentiIstruiti.Visible = true;
                                    //ContrattiFemPagamentiCollection pag_coll = contr_pag_prov.GetPagamentiPerErogazione(confidi, erogazione_selezionata.IdErogazione, null);
                                    ContrattiFemPagamentiCollection pag_coll = contr_pag_prov.GetPagamentiPerErogazioneSoggettoGestore(progetto_gestore_selezionato.IdSoggettoGestore, progetto_gestore_selezionato.IdProgettoSoggettoGestore,  erogazione_selezionata.IdErogazione);
                                    
                                    dgPagamentiErogazione.DataSource = pag_coll;
                                    dgPagamentiErogazione.ItemDataBound += new DataGridItemEventHandler(dgPagamentiErogazione_ItemDataBound);
                                    dgPagamentiErogazione.SetTitoloNrElementi();
                                    dgPagamentiErogazione.DataBind();

                                    //erogazioni precedenti
                                    ErogazioneFemCollection erog_col_per_prec = erog_prov.FindErogazioni(null, erogazione_selezionata.IdProgetto, null, null, null, true);
                                    ContrattiFemPagamentiCollection pag_coll_prec = new SiarLibrary.ContrattiFemPagamentiCollection();
                                    foreach (ErogazioneFem ef in erog_col_per_prec)
                                    {
                                        if (ef.IdErogazione < erogazione_selezionata.IdErogazione)
                                        {
                                            //ContrattiFemPagamentiCollection pag_coll_prec_appoggio = contr_pag_prov.GetPagamentiPerErogazione(confidi, ef.IdErogazione, null);
                                            ContrattiFemPagamentiCollection pag_coll_prec_appoggio = contr_pag_prov.GetPagamentiPerErogazioneSoggettoGestore(progetto_gestore_selezionato.IdSoggettoGestore, progetto_gestore_selezionato.IdProgettoSoggettoGestore, ef.IdErogazione);
                                            if (pag_coll_prec_appoggio.Count > 0)
                                                pag_coll_prec.AddCollection(pag_coll_prec_appoggio);
                                        }
                                    }
                                    dgPagamentiErogazionePrec.DataSource = pag_coll_prec;
                                    dgPagamentiErogazionePrec.ItemDataBound += new DataGridItemEventHandler(dgPagamentiErogazionePrec_ItemDataBound);
                                    dgPagamentiErogazionePrec.SetTitoloNrElementi();
                                    dgPagamentiErogazionePrec.DataBind();

                                    break;
                            }
                            //se definitiva disabilito i pulsanti
                            if (erogazione_selezionata.Definitivo == true)
                            {
                                trButtonConcludi.Visible = false;
                                btnAssociaDecreto.Enabled = false;
                                btnAssociaDecreto1.Enabled = false;
                                btnConcludi.Enabled = false;
                                //btnCreaErogazione.Enabled = true;
                                btnEliminaMandato.Enabled = false;
                                btnInserisciDecreto.Enabled = false;
                                btnSalvaMandato.Enabled = false;
                                btnSalvaPagAmmessi.Enabled = false;
                                btnSalvaQuietanza.Enabled = false;
                            }
                        }

                        lstDefAtto.DataBind();
                        lstOrgIstituzionale.DataBind();
                        lstRegistro.DataBind();
                    }
                    else
                    {
                        ucSiarNewTab.Visible = false;
                    }
                }

                dgProgetti.DataSource = prog_coll;
                dgProgetti.SetTitoloNrElementi();
                dgProgetti.ItemDataBound += new DataGridItemEventHandler(dgProgetti_ItemDataBound);
                dgProgetti.DataBind();
            }
            dgBandi.DataSource = bandi_coll;
            dgBandi.SetTitoloNrElementi();
            dgBandi.ItemDataBound += new DataGridItemEventHandler(dgBandi_ItemDataBound);
            dgBandi.DataBind();
            base.OnPreRender(e);
        }

        #region ItemDataBound

        void dgBandi_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            int col_Id = 0,
                col_Descr = 1,
                col_Importo = 2,
                col_Rup = 3,
                col_Check = 4;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Bando bando = (Bando)e.Item.DataItem;

                BandoResponsabiliCollection resp_coll = new BandoResponsabiliCollectionProvider().Find(bando.IdBando, null, null, null, true);
                foreach(BandoResponsabili resp in resp_coll)
                {
                    if(resp.Provincia == null)
                    {
                        e.Item.Cells[col_Rup].Text = resp.Nominativo;
                    }
                }
                //responsabile = new SiarBLL.BandoResponsabiliCollectionProvider().Find(Bando.IdBando, Operatore.Utente.IdUtente, null, true, true).Count > 0;
                e.Item.Cells[col_Importo].Text = string.Format("{0:c}", bando.Importo);



                e.Item.Cells[col_Check].Text = e.Item.Cells[col_Check].Text.Replace("<input", "<input checked onclick=\"selezionaBando(" + bando.IdBando + ",this);\"");
                if (hdnIdBando.Value == null || hdnIdBando.Value == "")
                {
                    e.Item.Cells[col_Check].Text = e.Item.Cells[col_Check].Text.Replace("checked", "");
                }
            }
            //else if (e.Item.ItemType == ListItemType.Footer)
            //{

            //}
        }

        void dgProgetti_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            int col_p_Id = 0,
                col_p_ragSoc = 1,
                col_p_Importo = 2,
                col_p_Check = 3;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Progetto progetto = (Progetto)e.Item.DataItem;
                SiarLibrary.Impresa imp = new ImpresaCollectionProvider().GetById(progetto.IdImpresa);

                e.Item.Cells[col_p_ragSoc].Text = imp.RagioneSociale;


                //Calcolo contributo Progetto
                decimal contributo = 0;
                int idVariante = 0;
                VariantiCollection var_coll = new VariantiCollectionProvider().Find(null, progetto.IdProgetto, null);
                foreach (Varianti v in var_coll)
                {
                    if (v.SegnaturaApprovazione != null && v.SegnaturaApprovazione != "" && v.Approvata == true)
                        idVariante = v.IdVariante;
                }

                PianoInvestimentiCollection pianoInv_col;
                if (idVariante == 0)
                    pianoInv_col = new PianoInvestimentiCollectionProvider().GetSituazionePianoInvestimenti(progetto.IdProgetto);
                else
                    pianoInv_col = new PianoInvestimentiCollectionProvider().GetPianoInvestimentiVariante(progetto.IdProgetto, idVariante);

                foreach (PianoInvestimenti p in pianoInv_col)
                {
                    if ( p.CodVariazione != "A")
                        contributo += p.ContributoRichiesto;
                }
                e.Item.Cells[col_p_Importo].Text = string.Format("{0:c}", contributo);



                e.Item.Cells[col_p_Check].Text = e.Item.Cells[col_p_Check].Text.Replace("<input", "<input checked onclick=\"selezionaProgetto(" + progetto.IdProgetto + ",this);\"");
                if (hdnIdProgetto.Value == null || hdnIdProgetto.Value == "")
                {
                    e.Item.Cells[col_p_Check].Text = e.Item.Cells[col_p_Check].Text.Replace("checked", "");
                }
            }
        }

        decimal totImportoPagamenti = 0, totImportoPagamentiAmmessi = 0;
        void dgPagamentiDaIstruire_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            int col_idContr = 0,
                col_tipo = 1,
                col_numeroContr = 2,
                col_dataContr = 3,
                col_importoContr = 4,
                col_fileContr = 5,
                col_idPag = 6,
                col_tipoPag = 7,
                col_dataPag = 8,
                col_estremiPag = 9,
                col_filePag = 10,
                col_importoPag = 11,
                col_importoPagAmm = 12,
                col_check = 13;


            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.CssClass = "TESTA1";
                e.Item.Cells[0].ColumnSpan = 6;
                e.Item.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Item.Cells[0].Text = "CONTRATTO/GIUSTIFICATIVO</td><td align=center colspan=8>PAGAMENTO</td></tr><tr class='TESTA'><td>";
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ContrattiFemPagamenti cfp = (ContrattiFemPagamenti)e.Item.DataItem;
                ContrattiFem cf = contr_prov.GetById(cfp.IdContrattoFem);
                if (cf.IdGiustificativo == null)
                {
                    e.Item.Cells[col_tipo].Text = "Contratto";
                    e.Item.Cells[col_numeroContr].Text = cf.Numero;
                    e.Item.Cells[col_dataContr].Text = cf.DataStipulaContratto;
                    e.Item.Cells[col_importoContr].Text = string.Format("{0:c}", cf.Importo);
                    if (cf.IdFile != null)
                        e.Item.Cells[col_fileContr].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='File'  onclick=\"SNCUFVisualizzaFile(" + cf.IdFile + ");\" style='cursor: pointer;'>";
                    else if (cf.Segnatura != null)
                        e.Item.Cells[col_fileContr].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='File'  onclick=\"sncAjaxCallVisualizzaProtocollo('" + cf.IdFile + "');\" style='cursor: pointer;'>";
                    else
                        e.Item.Cells[col_fileContr].Text = "";

                }
                else
                {
                    e.Item.Cells[col_tipo].Text = "Giustificativo";
                    e.Item.Cells[col_numeroContr].Text = cf.NumeroGiustificativo;
                    e.Item.Cells[col_dataContr].Text = cf.DataGiustificativo;
                    e.Item.Cells[col_importoContr].Text = string.Format("{0:c}", cf.ImponibileGiustificativo);
                    e.Item.Cells[col_fileContr].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='File'  onclick=\"SNCUFVisualizzaFile(" + cf.IdFileGiustificativo + ");\" style='cursor: pointer;'>";
                }

                e.Item.Cells[col_importoPag].Text = string.Format("{0:c}", cfp.Importo);

                totImportoPagamenti += cfp.Importo;
                totImportoPagamentiAmmessi += cfp.ImportoAmmesso ?? 0.00;

                e.Item.Cells[col_filePag].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='File'  onclick=\"SNCUFVisualizzaFile(" + cfp.IdFile + ");\" style='cursor: pointer;'>";

                if (cfp.ImportoAmmesso != null)
                {
                    e.Item.Cells[col_importoPagAmm].Text = e.Item.Cells[col_importoPagAmm].Text.Replace("value=\"\"", "value=\"" + cfp.ImportoAmmesso.ToString() + "\"  sigefname=\"conta\" onblur='sommaPagamentiSelezionati();' ");
                }
                else
                {
                    e.Item.Cells[col_importoPagAmm].Text = e.Item.Cells[col_importoPagAmm].Text.Replace("value=\"\"", "value=\"\"  sigefname=\"conta\" onblur='sommaPagamentiSelezionati();' ");
                }

                e.Item.Cells[col_check].Text = e.Item.Cells[col_check].Text.Replace("name='chkQuadro'", "name='chkQuadro' onclick='sommaPagamentiSelezionati();'");
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[col_importoPag].Text = string.Format("{0:c}", totImportoPagamenti);
                //e.Item.Cells[col_importoPagAmm].Text = string.Format("{0:c}", totImportoPagamentiAmmessi);
            }
        }

        decimal totPagamenti_istruiti = 0, totPagamentiAmmessi_istruiti = 0;
        void dgPagamentiErogazione_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            int col_idContr = 0,
                col_tipo = 1,
                col_numeroContr = 2,
                col_dataContr = 3,
                col_importoContr = 4,
                col_fileContr = 5,
                col_idPag = 6,
                col_tipoPag = 7,
                col_dataPag = 8,
                col_estremiPag = 9,
                col_filePag = 10,
                col_importoPag = 11,
                col_importoPagAmm = 12;


            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.CssClass = "TESTA1";
                e.Item.Cells[0].ColumnSpan = 6;
                e.Item.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Item.Cells[0].Text = "CONTRATTO/GIUSTIFICATIVO</td><td align=center colspan=7>PAGAMENTO</td></tr><tr class='TESTA'><td>";
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ContrattiFemPagamenti cfp = (ContrattiFemPagamenti)e.Item.DataItem;
                ContrattiFem cf = contr_prov.GetById(cfp.IdContrattoFem);
                if (cf.IdGiustificativo == null)
                {
                    e.Item.Cells[col_tipo].Text = "Contratto";
                    e.Item.Cells[col_numeroContr].Text = cf.Numero;
                    e.Item.Cells[col_dataContr].Text = cf.DataStipulaContratto;
                    e.Item.Cells[col_importoContr].Text = string.Format("{0:c}", cf.Importo);
                    if (cf.IdFile != null)
                        e.Item.Cells[col_fileContr].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='File'  onclick=\"SNCUFVisualizzaFile(" + cf.IdFile + ");\" style='cursor: pointer;'>";
                    else if (cf.Segnatura != null)
                        e.Item.Cells[col_fileContr].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='File'  onclick=\"sncAjaxCallVisualizzaProtocollo('" + cf.Segnatura + "');\" style='cursor: pointer;'>";
                    else
                        e.Item.Cells[col_fileContr].Text = "";
                }
                else
                {
                    e.Item.Cells[col_tipo].Text = "Giustificativo";
                    e.Item.Cells[col_numeroContr].Text = cf.NumeroGiustificativo;
                    e.Item.Cells[col_dataContr].Text = cf.DataGiustificativo;
                    e.Item.Cells[col_importoContr].Text = string.Format("{0:c}", cf.ImponibileGiustificativo);
                    e.Item.Cells[col_fileContr].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='File'  onclick=\"SNCUFVisualizzaFile(" + cf.IdFileGiustificativo + ");\" style='cursor: pointer;'>";
                }

                totPagamenti_istruiti += cfp.Importo;
                e.Item.Cells[col_importoPag].Text = string.Format("{0:c}", cfp.Importo);
                totPagamentiAmmessi_istruiti += cfp.ImportoAmmesso;
                e.Item.Cells[col_importoPagAmm].Text = string.Format("{0:c}", cfp.ImportoAmmesso);

                //totImportoPagamenti += cfp.Importo;
                //totImportoPagamentiAmmessi += cfp.ImportoAmmesso ?? 0.00;

                e.Item.Cells[col_filePag].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='File'  onclick=\"SNCUFVisualizzaFile(" + cfp.IdFile + ");\" style='cursor: pointer;'>";

            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[col_importoPag].Text = string.Format("{0:c}", totPagamenti_istruiti);
                e.Item.Cells[col_importoPagAmm].Text = string.Format("{0:c}", totPagamentiAmmessi_istruiti);
            }
        }

        decimal totPagamentiPrec_istruiti = 0, totPagamentiAmmessiPrec_istruiti = 0;
        void dgPagamentiErogazionePrec_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            int col_idContr = 0,
                col_tipo = 1,
                col_numeroContr = 2,
                col_dataContr = 3,
                col_importoContr = 4,
                col_fileContr = 5,
                col_idPag = 6,
                col_tipoPag = 7,
                col_dataPag = 8,
                col_estremiPag = 9,
                col_filePag = 10,
                col_importoPag = 11,
                col_importoPagAmm = 12;


            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.CssClass = "TESTA1";
                e.Item.Cells[0].ColumnSpan = 6;
                e.Item.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Item.Cells[0].Text = "CONTRATTO/GIUSTIFICATIVO</td><td align=center colspan=7>PAGAMENTO</td></tr><tr class='TESTA'><td>";
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ContrattiFemPagamenti cfp = (SiarLibrary.ContrattiFemPagamenti)e.Item.DataItem;
                ContrattiFem cf = contr_prov.GetById(cfp.IdContrattoFem);
                if (cf.IdGiustificativo == null)
                {
                    e.Item.Cells[col_tipo].Text = "Contratto";
                    e.Item.Cells[col_numeroContr].Text = cf.Numero;
                    e.Item.Cells[col_dataContr].Text = cf.DataStipulaContratto;
                    e.Item.Cells[col_importoContr].Text = string.Format("{0:c}", cf.Importo);
                    if (cf.IdFile != null)
                        e.Item.Cells[col_fileContr].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='File'  onclick=\"SNCUFVisualizzaFile(" + cf.IdFile + ");\" style='cursor: pointer;'>";
                    else if (cf.Segnatura != null)
                        e.Item.Cells[col_fileContr].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='File'  onclick=\"sncAjaxCallVisualizzaProtocollo('" + cf.Segnatura + "');\" style='cursor: pointer;'>";
                    else
                        e.Item.Cells[col_fileContr].Text = "";
                }
                else
                {
                    e.Item.Cells[col_tipo].Text = "Giustificativo";
                    e.Item.Cells[col_numeroContr].Text = cf.NumeroGiustificativo;
                    e.Item.Cells[col_dataContr].Text = cf.DataGiustificativo;
                    e.Item.Cells[col_importoContr].Text = string.Format("{0:c}", cf.ImponibileGiustificativo);
                    e.Item.Cells[col_fileContr].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='File'  onclick=\"SNCUFVisualizzaFile(" + cf.IdFileGiustificativo + ");\" style='cursor: pointer;'>";
                }

                totPagamentiPrec_istruiti += cfp.Importo;
                e.Item.Cells[col_importoPag].Text = string.Format("{0:c}", cfp.Importo);
                totPagamentiAmmessiPrec_istruiti += cfp.ImportoAmmesso;
                e.Item.Cells[col_importoPagAmm].Text = string.Format("{0:c}", cfp.ImportoAmmesso);

                //totImportoPagamenti += cfp.Importo;
                //totImportoPagamentiAmmessi += cfp.ImportoAmmesso ?? 0.00;

                e.Item.Cells[col_filePag].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='File'  onclick=\"SNCUFVisualizzaFile(" + cfp.IdFile + ");\" style='cursor: pointer;'>";

            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[col_importoPag].Text = string.Format("{0:c}", totPagamentiPrec_istruiti);
                e.Item.Cells[col_importoPagAmm].Text = string.Format("{0:c}", totPagamentiAmmessiPrec_istruiti);
            }
        }

        decimal importo_decreti_totale = 0, importo_decreti_totale_ammesso=0;

        void dgDecretiPag_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            int col_numero = 0,
            col_Descrizione = 1,
            col_tipo = 2,
            col_definizione = 3,
            col_organo = 4,
            col_importo = 5,
            col_importoAmm = 6,
            col_check = 7;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var d = (SiarLibrary.ErogazioneFemXDecreti)e.Item.DataItem;

                if (d.Importo != null)
                    importo_decreti_totale += d.Importo;
                if (d.ImportoAmmesso != null)
                    importo_decreti_totale_ammesso += d.ImportoAmmesso;

                Atti atto = atti_provider.GetById(d.IdDecreto);

                var dec = atto.Numero.ToString() + '|' + atto.Data + '|' + atto.Registro;
                e.Item.Cells[col_numero].Text = "<a href=\"javascript:visualizzaAtto(" + atto.IdAtto + ");\">" + dec + "</a>";

                e.Item.Cells[col_Descrizione].Text = atto.Descrizione;
            
                if(atto.TipoAtto != null)
                    e.Item.Cells[col_tipo].Text = atto.TipoAtto;
                else
                    e.Item.Cells[col_tipo].Text = "";

                if (atto.DefinizioneAtto != null)
                    e.Item.Cells[col_definizione].Text = atto.DefinizioneAtto;
                else
                    e.Item.Cells[col_definizione].Text = "";
                e.Item.Cells[col_organo].Text = atto.Servizio ;


                e.Item.Cells[col_importo].Text = string.Format("{0:c}", d.Importo);
                e.Item.Cells[col_importoAmm].Text = string.Format("{0:c}", d.ImportoAmmesso);

                if (erogazioni_decreto_selezionato != null)
                    e.Item.Cells[col_check].Text = e.Item.Cells[col_check].Text.Replace("<input", "<input checked");
                else
                    e.Item.Cells[col_check].Text = e.Item.Cells[col_check].Text.Replace("checked", "");

                e.Item.Cells[col_check].Text = e.Item.Cells[col_check].Text.Replace("<input", "<input onclick=\"selezionaDecretoPag(" + d.IdErogazioneXDecreti + ",this);\"");
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[col_importo].Text = string.Format("{0:c}", importo_decreti_totale);
                e.Item.Cells[col_importoAmm].Text = string.Format("{0:c}", importo_decreti_totale_ammesso);
            }

        }


        decimal totContratti = 0, totPagamenti = 0, totPagamentiAmm = 0, totDecreti = 0,
            totDecretiAmm = 0, totMandati = 0, totQuietanza = 0;

        void dgErogazioni_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            int col_Id = 0,
                col_Numero = 1,
                col_SogliaContributi = 2,
                col_Contratti = 3,
                col_Pagamenti = 4,
                col_PagamentiAmmessi = 5,
                col_Decreti = 6,
                col_DecretiAmmessi = 7,
                col_Mandati = 8,
                col_Quietanza = 9,
                col_definitiva = 10,
                col_segnatura = 11,
                col_IdDomandaPagamento = 12,
                col_DataCertificazione = 13;


            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ErogazioneFem erog = (ErogazioneFem)e.Item.DataItem;

                e.Item.Cells[col_SogliaContributi].Text = string.Format("{0:c}", erog.SogliaContributi);

                e.Item.Cells[col_Contratti].Text = string.Format("{0:c}", erog.SommaContratti);
                if (erog.SommaContratti != null)
                {
                    totContratti += erog.SommaContratti;
                }

                e.Item.Cells[col_Pagamenti].Text = string.Format("{0:c}", erog.SommaPagamenti);
                if (erog.SommaPagamenti != null)
                {
                    totPagamenti += erog.SommaPagamenti;
                }

                e.Item.Cells[col_PagamentiAmmessi].Text = string.Format("{0:c}", erog.SommaPagamentiAmmessi);
                if (erog.SommaPagamentiAmmessi != null)
                {
                    totPagamentiAmm += erog.SommaPagamentiAmmessi;
                }

                e.Item.Cells[col_Decreti].Text = string.Format("{0:c}", erog.SommaDecreti);
                if (erog.SommaDecreti != null)
                {
                    totDecreti += erog.SommaDecreti;
                }

                e.Item.Cells[col_DecretiAmmessi].Text = string.Format("{0:c}", erog.SommaDecretiAmmessi);
                if (erog.SommaDecretiAmmessi != null)
                {
                    totDecretiAmm += erog.SommaDecretiAmmessi;
                }

                e.Item.Cells[col_Mandati].Text = string.Format("{0:c}", erog.SommaMandati);
                if (erog.SommaMandati != null)
                {
                    totMandati += erog.SommaMandati;
                }

                e.Item.Cells[col_Quietanza].Text = string.Format("{0:c}", erog.SommaQuietanza);
                if (erog.SommaQuietanza != null)
                {
                    totQuietanza += erog.SommaQuietanza;
                }

                if (erog.Definitivo)
                {
                    e.Item.Cells[col_definitiva].Text = "SI";
                    if(erog.Segnatura !=null )
                        e.Item.Cells[col_segnatura].Text= "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='File'  onclick=\"sncAjaxCallVisualizzaProtocollo('" + erog.Segnatura + "');\" style='cursor: pointer;'>";

                    
                }
                else
                    e.Item.Cells[col_definitiva].Text = "NO";

                switch (erog.IdErogazione.Value)
                {
                    case 3:
                        e.Item.Cells[col_DataCertificazione].Text = "01/07/2017 - 10/05/2018";
                        break;
                    case 4:
                        e.Item.Cells[col_DataCertificazione].Text = "01/07/2017 - 04/09/2018";
                        break;
                    case 5:
                        e.Item.Cells[col_DataCertificazione].Text = "01/07/2017 - 12/11/2018";
                        break;
                    case 12:
                        e.Item.Cells[col_DataCertificazione].Text = "01/07/2017 - 19/12/2018";
                        break;
                    default:
                        var certDettaglioCollection = certspDettaglioCollectionProvider.FindDefinitiviSelezionatiXProgetto(erog.IdProgetto);
                        if (certDettaglioCollection.Count > 0)
                        {
                            var certDettaglioList = certDettaglioCollection.ToArrayList<CertspDettaglio>();
                            var certspDettaglio = certDettaglioList.Where(c => c.IdDomandaPagamento == erog.IdDomandaPagamento).FirstOrDefault();
                            if (certspDettaglio != null && certspDettaglio.Idcertsp != null)
                            {
                                var certspTesta = certspTestaCollectionProvider.GetById(certspDettaglio.Idcertsp);
                                e.Item.Cells[col_DataCertificazione].Text = certspTesta.Datainizio + " - " + certspTesta.Datafine;
                            }
                            else
                                e.Item.Cells[col_DataCertificazione].Text = "";
                        }
                        else
                            e.Item.Cells[col_DataCertificazione].Text = "";
                        break;
                }
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                //e.Item.Cells[col_Contratti].Text = string.Format("{0:c}", totContratti);
                //e.Item.Cells[col_Pagamenti].Text = string.Format("{0:c}", totPagamenti);
                //e.Item.Cells[col_PagamentiAmmessi].Text = string.Format("{0:c}", totPagamentiAmm);
                e.Item.Cells[col_Decreti].Text = string.Format("{0:c}", totDecreti);
                e.Item.Cells[col_DecretiAmmessi].Text = string.Format("{0:c}", totDecretiAmm);
                e.Item.Cells[col_Mandati].Text = string.Format("{0:c}", totMandati);
                e.Item.Cells[col_Quietanza].Text = string.Format("{0:c}", totQuietanza);
            }
        }

        decimal importo_mandato = 0, importo_quietanza = 0;
        void dgDomandeLiquidazioni_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            int col_id = 0,
                col_mandaoNum = 1,
                col_mandatoData = 2,
                col_mandatoImp = 3,
                col_impresa = 4,
                col_quietData = 5,
                col_quietImp = 6;

            DataGridItem dgi = (DataGridItem)e.Item;
            if (dgi.ItemType == ListItemType.Header)
            {
                e.Item.CssClass = "TESTA1";
                e.Item.Cells[0].ColumnSpan = 5;
                e.Item.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Item.Cells[0].Text = "MANDATO DI PAGAMENTO</td><td colspan=2 align=center>QUIETANZA</td></tr><tr class='TESTA'><td>";
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                //e.Item.Cells[2].Text = string.Format("{0:c}", importo_mandato_richiesto);
                e.Item.Cells[col_mandatoImp].Text = string.Format("{0:c}", importo_mandato);
                e.Item.Cells[col_quietImp].Text = string.Format("{0:c}", importo_quietanza);
            }
            else
            {
                ErogazioneLiquidazioni dpl = (ErogazioneLiquidazioni)e.Item.DataItem;
                //SiarLibrary.NullTypes.DecimalNT imr = new SiarLibrary.NullTypes.DecimalNT(dpl.RichiestaMandatoImporto);
                //if (imr != null) importo_mandato_richiesto += imr;
                //e.Item.Cells[2].Text = string.Format("{0:c}", imr);
                SiarLibrary.NullTypes.DecimalNT im = new SiarLibrary.NullTypes.DecimalNT(dpl.MandatoImporto);
                if (im != null) importo_mandato += im;
                e.Item.Cells[col_mandatoImp].Text = string.Format("{0:c}", im);
                var impresaMandato = new SiarBLL.ImpresaCollectionProvider().GetById(dpl.IdImpresaBeneficiaria);
                e.Item.Cells[col_impresa].Text = impresaMandato.RagioneSociale;
                SiarLibrary.NullTypes.DecimalNT iq = new SiarLibrary.NullTypes.DecimalNT(dpl.QuietanzaImporto);
                if (iq != null) importo_quietanza += iq;
                e.Item.Cells[col_quietImp].Text = string.Format("{0:c}", iq);
            }
        }


        #endregion

        #region Button

        
        protected void btnPost_Click(object sender, EventArgs e)
        {
            dgBandi.SetPageIndex(0);
        }

        protected void btnCreaErogazione_Click(object sender, EventArgs e)
        {
            try
            {

                //svuoto tutte le variabili
                hdnIdErogazione.Value = null;
                erogazione_selezionata = null;
                hdnIdErogazioneXDecreti.Value = null;
                erogazioni_decreto_selezionato = null;
                hdnIdLiquidazione.Value = null;
                erogazioni_liquid_selezionato = null;
                hdnDecretoJson.Value = null;
                decreto = null;

                ErogazioneFem erog = new ErogazioneFem();
                erog.OperatoreCreazione = Operatore.Utente.IdUtente;
                erog.DataCreazione = DateTime.Today;
                erog.IdProgetto = progetto_selezionato.IdProgetto;
                erog.SogliaContributi = txtSogliaContributi.Text;
                erog.Definitivo = false;

                ErogazioneFemCollection erog_coll = erog_prov.FindErogazioni(null, progetto_selezionato.IdProgetto, null, null, null, null);
                if (erog_coll.Count == 0)
                {
                    erog.Anticipo = true;
                }
                else
                {
                    erog.Anticipo = false;
                }

                erog.Numero = erog_coll.Count + 1;

                erog_prov.Save(erog);

                hdnIdErogazione.Value = erog.IdErogazione;
                erogazione_selezionata = erog_prov.GetById(Convert.ToInt32( hdnIdErogazione.Value));


            }
            catch (Exception ex) { ShowError(ex); }
        }
        protected void btnSalvaPagAmmessi_Click(object sender, EventArgs e)
        {
            try
            {
                //bool confidi = true;
                //if (progetto_selezionato.IdProgetto == int.Parse(ConfigurationManager.AppSettings["IdProgettoArtigiancassa"]))
                //{
                //    confidi = false;
                //}

                //SiarLibrary.ContrattiFemPagamentiCollection pag_coll = contr_pag_prov.GetPagamentiPerErogazione(confidi, null,progetto_selezionato.IdProgetto);
                ContrattiFemPagamentiCollection pag_coll = contr_pag_prov.GetPagamentiPerErogazioneSoggettoGestore(progetto_gestore_selezionato.IdSoggettoGestore, progetto_gestore_selezionato.IdProgettoSoggettoGestore,  null);
                foreach (ContrattiFemPagamenti cfp in pag_coll)
                {
                    decimal importoAmm;
                    string str_importoAmm = Request.Form["txtImportoAmmesso" + cfp.IdContrattoFemPagamenti + "_text"];


                    if (str_importoAmm != "" && str_importoAmm != null)
                    {
                        str_importoAmm.Replace(".", "");
                        importoAmm = Convert.ToDecimal(str_importoAmm);
                        ContrattiFemPagamenti cfp_n = contr_pag_prov.GetById(cfp.IdContrattoFemPagamenti);
                        cfp_n.ImportoAmmesso = importoAmm;
                        contr_pag_prov.Save(cfp_n);
                    }
                }
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnAssociaDecreto_Click(object sender, EventArgs e)
        {
            try
            {
                string[] selezionate = ((SiarLibrary.Web.CheckColumn)dgPagamentiDaIstruire.Columns[13]).GetSelected();
                //if (selezionate.Length == 0 && !erogazione_selezionata.Anticipo) { ShowError("Occorre selezionare almeno un pagamento."); return; }

                hdnIdErogazioneXDecreti.Value = "";
                erogazioni_decreto_selezionato = null;
                //svuoto campi popup
                hdnDecretoJson.Value = null;
                txtNumeroDecreto.Text = null;
                txtDataDecreto.Text = null;
                txtNumeroBur.Text = null;
                txtDataBur.Text = null;
                txtRegistro.Text = null;
                lstDefAtto.ClearSelection();
                lstOrgIstituzionale.ClearSelection();
                txtDescrizione.Text = null;

                RegisterClientScriptBlock("mostraPopupTemplate('divSchedaForm','divBKGMessaggio');");
            }
            catch (Exception ex) { ShowError(ex); }


        }

        protected void btnAssociaDecreto1_Click(object sender, EventArgs e)
        {
            try
            {
                //string[] selezionate = ((SiarLibrary.Web.CheckColumn)dgPagamentiDaIstruire.Columns[13]).GetSelected();
                //if (selezionate.Length == 0 && !erogazione_selezionata.Anticipo) { ShowError("Occorre selezionare almeno un pagamento."); return; }

                hdnIdErogazioneXDecreti.Value = "";
                erogazioni_decreto_selezionato = null;
                //svuoto campi popup
                hdnDecretoJson.Value = null;
                txtNumeroDecreto.Text = null;
                txtDataDecreto.Text = null;
                txtNumeroBur.Text = null;
                txtDataBur.Text = null;
                txtRegistro.Text = null;
                lstDefAtto.ClearSelection();
                lstOrgIstituzionale.ClearSelection();
                txtDescrizione.Text = null;

                RegisterClientScriptBlock("mostraPopupTemplate('divSchedaForm','divBKGMessaggio');");
            }
            catch (Exception ex) { ShowError(ex); }


        }

        protected void btnInserisciDecreto_Click(object sender, EventArgs e)
        {
            try
            {
                if (decreto == null) throw new Exception("Il decreto cercato non è stato trovato.");
                if (decreto.IdAtto == null)
                {
                    // se non e' ancora salvato sul db controllo che non sia duplicato 
                    AttiCollection atti_simili = atti_provider.Find(decreto.Numero, decreto.Data, "D", decreto.Registro);
                    if (atti_simili.Count > 0) decreto = atti_simili[0];
                }
                atti_provider.Save(decreto);

                ErogazioneFemXDecreti efxd = new ErogazioneFemXDecreti();
                efxd.OperatoreCreazione = Operatore.Utente.IdUtente;
                efxd.DataCreazione = DateTime.Today;
                efxd.IdErogazione = erogazione_selezionata.IdErogazione;
                efxd.IdDecreto = decreto.IdAtto;
                efxd.Importo = txtImportoDecreto.Text;
                efxd.ImportoAmmesso = txtImportoDecretoAmmesso.Text;
                erog_decreti_prov.Save(efxd);


                if (!erogazione_selezionata.Anticipo)
                {
                    string[] selezionati = ((SiarLibrary.Web.CheckColumn)dgPagamentiDaIstruire.Columns[13]).GetSelected();

                    foreach (string s in selezionati)
                    {
                        SiarLibrary.ContrattiFemPagamenti cfp = contr_pag_prov.GetById(Convert.ToInt32(s));
                        cfp.IdErogazioneFem = erogazione_selezionata.IdErogazione;
                        contr_pag_prov.Save(cfp);
                    }

                }
                decreto = null;

                RegisterClientScriptBlock("chiudiPopupTemplate();");
                ShowMessage("Decreto associato correttamente!");

                
                
            }
            catch (Exception ex) { RegisterClientScriptBlock("chiudiPopupTemplate();"); ShowError(ex); }
        }

        protected void btnCercaDecreto_Click(object sender, EventArgs e)
        {
            try
            {
                //if (!responsabile) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                RegisterClientScriptBlock("mostraPopupTemplate('divSchedaForm','divBKGMessaggio');");
                hdnDecretoJson.Value = null;
                decreto = null;
                int numero;
                int.TryParse(txtNumeroDecreto.Text, out numero);
                DateTime data;
                DateTime.TryParse(txtDataDecreto.Text, out data);
                AttiCollection atti_trovati = atti_provider.ImportaAtto(numero, data, "D", lstRegistro.SelectedValue);
                if (atti_trovati.Count > 0)
                {
                    if (atti_trovati.Count > 1)
                    {
                        dgDecreti.DataSource = atti_trovati;
                        dgDecreti.Titolo = "Elementi trovati: " + atti_trovati.Count.ToString();
                        dgDecreti.ItemDataBound += new DataGridItemEventHandler(dgDecreti_ItemDataBound);
                        dgDecreti.DataBind();
                        trElencoDecreti.Visible = true;
                    }
                    else
                    {
                        decreto = atti_trovati[0];
                        hdnDecretoJson.Value = decreto.ConvertToJSonObject();
                        trDettaglioDecreto.Visible = true;

                        txtNumeroDecreto.Text = decreto.Numero;
                        txtDataDecreto.Text = decreto.Data;
                        txtNumeroBur.Text = decreto.NumeroBur;
                        txtDataBur.Text = decreto.DataBur;
                        txtRegistro.Text = decreto.Registro;
                        lstDefAtto.SelectedValue = decreto.CodDefinizione;
                        lstOrgIstituzionale.SelectedValue = decreto.CodOrganoIstituzionale;
                        txtDescrizione.Text = decreto.Descrizione;
                    }
                }
                else
                {
                    ShowError("Il decreto cercato non è stato trovato.");
                }
            }
            catch (Exception ex) { ShowError(ex); }
        }

        void dgDecreti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Atti a = (Atti)e.Item.DataItem;
                e.Item.Cells[4].Text = "<input type=button class=ButtonGrid style='width:100px' value='Seleziona' onclick=\"selezionaDecreto("
                    + a.ConvertToJSonObject() + ");\" />";
            }
        }

        protected void btnNuovoMandato_Click(object sender, EventArgs e)
        {
            try
            {
                trMandato.Visible = true;
                erogazioni_liquid_selezionato = null;
                hdnIdLiquidazione.Value = null;
                ufMandato.IdFile = null;
                txtMandatoNumero.Text = "";
                txtMandatoData.Text = "";
                txtMandatoImporto.Text = "";

                txtQuietanzaData.Text = "";
                txtQuietanzaImporto.Text = "";


            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalvaMandato_Click(object sender, EventArgs e)
        {
            try
            {

                if (erogazioni_liquid_selezionato == null)
                {
                    erogazioni_liquid_selezionato = new SiarLibrary.ErogazioneLiquidazioni();
                    erogazioni_liquid_selezionato.OperatoreCreazione = Operatore.Utente.IdUtente;
                    erogazioni_liquid_selezionato.DataCreazione = DateTime.Today;
                    erogazioni_liquid_selezionato.IdErogazioneXDecreti = erogazioni_decreto_selezionato.IdErogazioneXDecreti;
                    erogazioni_liquid_selezionato.IdImpresaBeneficiaria = progetto_selezionato.IdImpresa;
                }
                else
                {
                    erogazioni_liquid_selezionato.OperatoreModifica = Operatore.Utente.IdUtente;
                    erogazioni_liquid_selezionato.DataModifica = DateTime.Today;
                }

                erogazioni_liquid_selezionato.MandatoData = txtMandatoData.Text;
                erogazioni_liquid_selezionato.MandatoImporto = txtMandatoImporto.Text;
                erogazioni_liquid_selezionato.MandatoNumero = txtMandatoNumero.Text;
                erogazioni_liquid_selezionato.MandatoIdFile = ufMandato.IdFile;

                erog_liqu_prov.Save(erogazioni_liquid_selezionato);
                hdnIdLiquidazione.Value = erogazioni_liquid_selezionato.IdLiquidazione.ToString();
                ShowMessage("Dati del mandato di pagamento registrati correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalvaQuietanza_Click(object sender, EventArgs e)
        {
            try
            {
                if (erogazioni_liquid_selezionato == null)
                {
                    erogazioni_liquid_selezionato = new SiarLibrary.ErogazioneLiquidazioni();
                    erogazioni_liquid_selezionato.OperatoreCreazione = Operatore.Utente.IdUtente;
                    erogazioni_liquid_selezionato.DataCreazione = DateTime.Today;
                    erogazioni_liquid_selezionato.IdErogazioneXDecreti = erogazioni_decreto_selezionato.IdErogazioneXDecreti;
                    erogazioni_liquid_selezionato.IdImpresaBeneficiaria = progetto_selezionato.IdImpresa;
                }
                else
                {
                    erogazioni_liquid_selezionato.OperatoreModifica = Operatore.Utente.IdUtente;
                    erogazioni_liquid_selezionato.DataModifica = DateTime.Today;
                }

                erogazioni_liquid_selezionato.MandatoData = txtMandatoData.Text;
                erogazioni_liquid_selezionato.MandatoImporto = txtMandatoImporto.Text;
                erogazioni_liquid_selezionato.MandatoNumero = txtMandatoNumero.Text;
                erogazioni_liquid_selezionato.MandatoIdFile = ufMandato.IdFile;
                erogazioni_liquid_selezionato.QuietanzaData = txtQuietanzaData.Text;
                erogazioni_liquid_selezionato.QuietanzaImporto = txtQuietanzaImporto.Text;


                erog_liqu_prov.Save(erogazioni_liquid_selezionato);
                hdnIdLiquidazione.Value = erogazioni_liquid_selezionato.IdLiquidazione.ToString();

                erogazioni_liquid_selezionato = null;
                hdnIdLiquidazione.Value = "";

                ShowMessage("Dati del mandato e della quietanza di pagamento registrati correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }


        protected void btnEliminaMandato_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnIdLiquidazione.Value == "" || hdnIdLiquidazione.Value == null)
                    throw new Exception("Nessun mandato selezionato!");

                erog_liqu_prov.Delete(erogazioni_liquid_selezionato);
                hdnIdLiquidazione.Value = null;
                erogazioni_liquid_selezionato = null;

                trMandato.Visible = true;
                ufMandato.IdFile = null;
                txtMandatoNumero.Text = "";
                txtMandatoData.Text = "";
                txtMandatoImporto.Text = "";

                txtQuietanzaData.Text = "";
                txtQuietanzaImporto.Text = "";


                ShowMessage("Mandato eliminato correttamente!");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }

        }

        protected void btnConcludi_Click(object sender, EventArgs e)
        {
            try
            {
                //controlo se è stato inserito almeno un decreto e un mandato
                ErogazioneFemXDecretiCollection dec_coll = erog_decreti_prov.FindDecretiErogazione(null, erogazione_selezionata.IdErogazione, null, progetto_selezionato.IdProgetto, null);
                if (dec_coll.Count == 0)
                    throw new Exception("Impossibile concludere l'erogazione in quanto non è stato collegato nessun decreto.");
                //else
                //{
                //    foreach(SiarLibrary.ErogazioneFemXDecreti d in dec_coll)
                //    {
                //        SiarLibrary.ErogazioneLiquidazioniCollection liqu_col = erog_liqu_prov.FindLiquidazione(null, d.IdErogazioneXDecreti, progetto_selezionato.IdProgetto, null, erogazione_selezionata.IdErogazione, d.IdDecreto);
                //        if (liqu_col.Count == 0)
                //            throw new Exception("Impossibile concludere l'erogazione in quanto non è stato collegato nessun mandato.");
                //    }
                //}

                ucFirmaDocumento.FirmaObbligatoria = true;
                ucFirmaDocumento.loadDocumento(Operatore.Utente.CfUtente,erogazione_selezionata.IdErogazione );
                
            }
            catch (Exception ex)
            {
                
                ShowError(ex.Message);
            }

        }

        protected void ProtocollaDocFirmatoEvent(object sender, EventArgs e)
        {
            try
            {
                Protocollo documento_interno = new Protocollo(bando_selezionato.CodEnte);
                documento_interno.setDocumento("erogazione_nr_"+erogazione_selezionata.Numero.ToString()+"_strumenti_finanziari_" + progetto_selezionato.IdProgetto + ".pdf",
                    Convert.FromBase64String(ucFirmaDocumento.FileFirmato));

                string[] ss = new BandoCollectionProvider().GetDatiXProtocollazione(bando_selezionato.IdBando, progetto_selezionato.ProvinciaDiPresentazione);
                var impresa = new ImpresaCollectionProvider().GetById(progetto_selezionato.IdImpresa);
                string oggetto = "Erogazione Strumenti Finanziari nr " + erogazione_selezionata.Numero.ToString()+". " 
                    + "\n Partita iva/Codice fiscale: " + impresa.Cuaa
                    + "\n Ragione sociale: " + impresa.RagioneSociale
                    + "\n N° Domanda: " + erogazione_selezionata.IdProgetto;

                string identificativo_paleo = documento_interno.DocumentoInterno(oggetto, ss[4]);

                erog_prov.DbProviderObj.BeginTran();

                erogazione_selezionata.DataModifica = DateTime.Today;
                erogazione_selezionata.OperatoreModifica = Operatore.Utente.IdUtente;
                erogazione_selezionata.Definitivo = true;
                erogazione_selezionata.Segnatura = identificativo_paleo;
                erog_prov.Save(erogazione_selezionata);

                DomandaDiPagamento dp = new DomandaDiPagamentoCollectionProvider().GeneraDomandaPagamentoFem(erog_prov.DbProviderObj, Operatore.Utente, erogazione_selezionata);
                if (dp == null)
                    throw new Exception("Errore nella generazione della domanda di pagamento fittizia collegata all'erogazione");
                erogazione_selezionata.IdDomandaPagamento = dp.IdDomandaPagamento;
                erog_prov.Save(erogazione_selezionata);

                erog_prov.DbProviderObj.Commit();

                //svuoto tutte le variabili
                hdnIdErogazione.Value = null;
                erogazione_selezionata = null;
                hdnIdErogazioneXDecreti.Value = null;
                erogazioni_decreto_selezionato = null;
                hdnIdLiquidazione.Value = null;
                erogazioni_liquid_selezionato = null;
                hdnDecretoJson.Value = null;
                decreto = null;


                ShowMessage("Erogazione firmata, protocollata e conclusa con successo.");

            }
            catch (Exception ex) {
                erog_prov.DbProviderObj.Rollback();
                ShowError(ex); 
            }
        }

        protected void btnPostNull_click(object sender, EventArgs e)
        {
        }

        #endregion

    }
}