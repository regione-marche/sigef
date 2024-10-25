using SiarBLL;
using SiarLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace web.Private.Fem
{
    public partial class ContrattiAltriSoggettiGestoriPoc : SiarLibrary.Web.PrivatePage
    {
        ContrattiFemCollectionProvider contratto_provider = new ContrattiFemCollectionProvider();
        ContrattiFemPagamentiCollectionProvider contratto_pagamento_provider = new ContrattiFemPagamentiCollectionProvider();
        SoggettoGestoreCollectionProvider soggetto_provider = new SoggettoGestoreCollectionProvider();

        ContrattiFem contratto_selezionato;
        List<ProgettoSoggettoGestore> progetti_list;

        #region Indici colonne Datagrid

        //dgContratti
        private int
            col_con_soggetto = 0,
            col_con_numero = 1,
            col_con_id_progetto = 2,
            col_con_gestore = 3,
            col_con_file = 4,
            col_con_linea_intervento = 5,
            col_con_codice_pratica = 6,
            col_con_data_erogazione = 7,
            col_con_impresa = 8,
            col_con_pivaimpresa = 9,
            col_con_tipologia_credito = 10,
            col_con_finalita_operazione = 11,
            col_con_durata_finanziamento = 12,
            col_con_imp_finanziamento = 13,
            col_con_imp_garanzia_gestore = 14,
            col_con_imp_agevolazione_erogata = 15,
            col_con_regime = 16,
            col_con_perdita_fondo = 17,
            col_con_imp_pagamenti = 18,
            col_con_check = 19;

        //dgContrattiPagamenti
        private int col_pag_id = 0,
            col_pag_tipo = 1,
            col_pag_data = 2,
            col_pag_estremi = 3,
            col_pag_file = 4,
            col_pag_importo = 5;

        #endregion

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "contratti_altri_soggetti_gestori_poc";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (AbilitaModifica)
            {
                progetti_list = StrumentiFinanziariUtility.GetProgettiUtenteFondoPoc(Operatore);

                if (progetti_list.Count > 0)
                {
                    foreach (ProgettoSoggettoGestore p in progetti_list)
                    {
                        ListItem itemSoggetto = new ListItem(p.DenominazioneSoggettoGestore, p.IdSoggettoGestore);
                        if (!rblSoggettiGestori.Items.Contains(itemSoggetto))
                            rblSoggettiGestori.Items.Add(itemSoggetto);
                        //if (!rblSoggettiGestoriInserimento.Items.Contains(itemSoggetto))
                        //    rblSoggettiGestoriInserimento.Items.Add(itemSoggetto);

                        ListItem itemProgetto = new ListItem(p.IdProgettoRiferimento, p.IdProgettoRiferimento);
                        itemProgetto.Attributes.Add("IdSoggettoGestore", p.IdSoggettoGestore);
                        if (!rblProgettiSoggetto.Items.Contains(itemProgetto))
                            rblProgettiSoggetto.Items.Add(itemProgetto);

                        ListItem itemProgettoInserimento = new ListItem(p.IdProgettoRiferimento, p.IdProgettoRiferimento);
                        if (!rblProgettiSoggettoInserimento.Items.Contains(itemProgettoInserimento))
                            rblProgettiSoggettoInserimento.Items.Add(itemProgettoInserimento);
                    }

                    if (Operatore.Utente.Profilo != "Operatore FEM")
                    {
                        dgContratti.Columns[col_con_soggetto].HeaderStyle.CssClass = "";
                        dgContratti.Columns[col_con_soggetto].ItemStyle.CssClass = "";
                        dgContratti.Columns[col_con_soggetto].FooterStyle.CssClass = "";

                        lblTitolo.InnerText = "Fondo Covid l.r. 13/2020 POC";

                        if (Operatore.Utente.Profilo != "Amministratore")
                        {
                            AbilitaModifica = false;
                            divInserimento.Visible = false;
                        }
                    }
                    else
                    {
                        var prog_sog_gest = progetti_list[0];

                        if (prog_sog_gest.DenominazioneSoggettoGestore == "Artigiancassa")
                            Redirect(PATH_FEM + "ContrattiArtigiancassa.aspx",
                                "La gestione dei contratti di Artigiancassa si effettua dall'apposita funzione 'Fondo Energia'",
                                false);

                        //if (prog_sog_gest.DenominazioneSoggettoGestore == "Confidi UNI.CO. (ex SRGM)")
                        //    Redirect(PATH_FEM + "ContrattiConfidi.aspx",
                        //        "La gestione dei contratti di Confidi UNI.CO. si effettua dall'apposita funzione 'Fondo Confidi UNI.CO.'",
                        //        false);

                        //lblTitolo.InnerText = prog_sog_gest.DenominazioneSoggettoGestore;

                        rblSoggettiGestori.SelectedValue = prog_sog_gest.IdSoggettoGestore;
                        hdnIdSoggettoGestore.Value = prog_sog_gest.IdSoggettoGestore;
                        divSoggettiGestori.Visible = false;
                        //rblSoggettiGestoriInserimento.SelectedValue = prog_sog_gest.IdSoggettoGestore;
                        //divSoggettiGestoriInserimento.Visible = false;
                    }
                }
                else
                    Redirect(PATH_PDOMANDA + "Cruscotto.aspx", "Non si hanno i pemessi per accedere alla pagina", true);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            lstTipoGiustificativo.DataBind();
            lstPagamento.DataBind();

            string id_soggetto = hdnIdSoggettoGestore.Value;
            string id_progetto = hdnIdProgetto.Value;
            rblSoggettiGestori.SelectedValue = id_soggetto;
            rblProgettiSoggetto.SelectedValue = id_progetto;

            ContrattiFemCollection contratti_coll = new ContrattiFemCollection();
            int id_contratto;
            if (int.TryParse(hdnIdContratto.Value, out id_contratto))
            {
                contratto_selezionato = contratto_provider.GetById(id_contratto);
                contratti_coll.Add(contratto_selezionato);

                divContrattoPagamento.Visible = true;

                var pagamenti_coll = contratto_pagamento_provider.Find(null, contratto_selezionato.IdContrattoFem, null, null, null);
                var pagamenti_list = pagamenti_coll.ToArrayList<ContrattiFemPagamenti>();
                dgContrattiPagamenti.DataSource = pagamenti_coll;
                dgContrattiPagamenti.SetTitoloNrElementi();
                dgContrattiPagamenti.ItemDataBound += new DataGridItemEventHandler(dgContrattiPagamenti_ItemDataBound);
                dgContrattiPagamenti.DataBind();

                decimal importo_pagamenti = pagamenti_list.Sum(p => p.Importo ?? 0.00);
                if ((contratto_selezionato.Importo ?? contratto_selezionato.ImponibileGiustificativo) > importo_pagamenti)
                    divAggiungiPagamento.Visible = true;
                else
                    divAggiungiPagamento.Visible = false;
            }
            else
            {
                if (Operatore.Utente.Profilo != "Operatore FEM")
                {
                    contratti_coll = contratto_provider.GetContrattiAltriSoggettiFondoLeggeCovidPoc(
                        id_soggetto == "X" ? null : id_soggetto,
                        id_progetto == "Y" ? null : id_progetto);
                }
                else
                {
                    var prog_sog_gest = progetti_list[0];

                    contratti_coll = contratto_provider.GetContrattiAltriSoggettiFondoLeggeCovidPoc(
                        prog_sog_gest.IdSoggettoGestore,
                        id_progetto == "Y" ? null : id_progetto);
                }

                divContrattoPagamento.Visible = false;
            }

            dgContratti.DataSource = contratti_coll;
            dgContratti.SetTitoloNrElementi();
            dgContratti.ItemDataBound += new DataGridItemEventHandler(dgContratti_ItemDataBound);
            dgContratti.DataBind();

            base.OnPreRender(e);
        }

        private string CleanInput(string strIn)
        {
            StringBuilder sb = new StringBuilder(strIn.Length);
            foreach (char c in strIn)
            {
                var num_c = (int)c;

                if (num_c >= 131 && num_c <= 146)
                    continue;
                if (num_c >= 149 && num_c <= 162)
                    continue;
                if (num_c >= 164 && num_c <= 223)
                    continue;

                sb.Append(c);
            }
            return sb.ToString();
        }

        private void CleanCampiGiustificativo()
        {
            lstTipoGiustificativo.Text = null;
            txtDataGiustificativo.Text = null;
            txtNumGiustificativo.Text = null;
            txtImportoGiustificativo.Text = null;
            txtIva.Text = null;
            txtDescGiustificativo.Text = null;
            txtPivaFornitore.Text = null;
            txtRSFornitore.Text = null;
            ufGiustificativo.IdFile = null;
            chkNonRecuperabile.Checked = false;
        }

        private void CleanCampiPagamento()
        {
            txtEstremi.Text = null;
            txtDataPagamento.Text = null;
            lstPagamento.Text = null;
            txtImportoLordoPagamento.Text = null;
            ufPagamento.IdFile = null;
        }

        #region ItemDataBound

        void dgContratti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var fem = (ContrattiFem)e.Item.DataItem;

                var sog = soggetto_provider.GetById(fem.IdSoggettoGestore);
                e.Item.Cells[col_con_soggetto].Text = sog.DenominazioneSoggettoGestore;

                if (fem.IdGiustificativo == null)
                {
                    e.Item.Cells[col_con_imp_finanziamento].Text = string.Format("{0:c}", fem.ImportoFinanziamento);
                    e.Item.Cells[col_con_imp_garanzia_gestore].Text = string.Format("{0:c}", fem.ImportoGaranziaConfidi);
                    e.Item.Cells[col_con_perdita_fondo].Text = string.Format("{0:c}", fem.PerditaFondoEscussioneConfidi);
                    e.Item.Cells[col_con_imp_agevolazione_erogata].Text = string.Format("{0:c}", fem.Importo);

                    if (fem.IdFile != null)
                        e.Item.Cells[col_con_file].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='File'  onclick=\"SNCUFVisualizzaFile(" + fem.IdFile + ");\" style='cursor: pointer;'>";
                }
                else
                {
                    e.Item.Cells[col_con_numero].Text = fem.NumeroGiustificativo;
                    e.Item.Cells[col_con_data_erogazione].Text = fem.DataGiustificativo;
                    e.Item.Cells[col_con_imp_agevolazione_erogata].Text = string.Format("{0:c}", fem.ImponibileGiustificativo);

                    if (fem.IdFileGiustificativo != null)
                        e.Item.Cells[col_con_file].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='File'  onclick=\"SNCUFVisualizzaFile(" + fem.IdFileGiustificativo + ");\" style='cursor: pointer;'>";
                }

                //calcolo il totale dei pagamenti inseriti
                decimal totPagamenti = 0;
                var pagamenti_list = contratto_pagamento_provider
                    .Find(null, fem.IdContrattoFem, null, null, null)
                    .ToArrayList<ContrattiFemPagamenti>();

                totPagamenti = pagamenti_list.Sum(p => p.Importo);
                e.Item.Cells[col_con_imp_pagamenti].Text = string.Format("{0:c}", totPagamenti);

                e.Item.Cells[col_con_check].Text = e.Item.Cells[col_con_check].Text.Replace("<input", "<input checked onclick=\"selezionaContratto(" + fem.IdContrattoFem + ",this);\"");
                if (contratto_selezionato == null)
                    e.Item.Cells[col_con_check].Text = e.Item.Cells[col_con_check].Text.Replace("checked", "");
            }
        }

        decimal totaleImportiContrattiFemPagamento = 0;
        void dgContrattiPagamenti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var fem_pag = (ContrattiFemPagamenti)e.Item.DataItem;

                if (fem_pag.IdFile != null)
                    e.Item.Cells[col_pag_file].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='File'  onclick=\"SNCUFVisualizzaFile(" + fem_pag.IdFile + ");\" style='cursor: pointer;'>";

                e.Item.Cells[col_pag_importo].Text = string.Format("{0:c}", fem_pag.Importo);
                totaleImportiContrattiFemPagamento += fem_pag.Importo;

            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[col_pag_importo].Text = string.Format("{0:c}", totaleImportiContrattiFemPagamento);
            }
        }

        #endregion

        #region Button Click

        protected void btnPost_Click(object sender, EventArgs e) { }

        protected void btnImportaContratti_Click(object sender, EventArgs e)
        {
            try
            {
                if (ufContratti.IdFile != null)
                {
                    int contratti_nuovi = 0, contratti_aggiornati = 0, contratti_totale = 0;
                    var file = new ArchivioFileCollectionProvider().GetById(ufContratti.IdFile);

                    if (file == null)
                        throw new Exception("File non selezionato");

                    if (!file.NomeCompleto.ToString().EndsWith(".txt"))
                        throw new Exception("Formato file non accettato");

                    var errore = StrumentiFinanziariUtility.ImportaContrattiAltriSoggetti(null, file.Id, file.Contenuto, Operatore.Utente.IdUtente, out contratti_nuovi, out contratti_aggiornati);
                    contratti_totale = contratti_nuovi + contratti_aggiornati;

                    if (errore == null || errore != "")
                        throw new Exception(errore);

                    ShowMessage("Importazione avvenuta con successo. <br/><br/>Su un totale di " + contratti_totale + " contratti:<br/> - sono stati inseriti " + contratti_nuovi + " nuovi contratti<br/> - sono stati aggiornati " + contratti_aggiornati + " contratti");
                }
                else
                    throw new Exception("File non selezionato");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnSalvaGiustificativo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica)
                    throw new SiarException(TextErrorCodes.ModificaDisabilitata);

                int id_prog_asse;
                if (!int.TryParse(hdnIdProgettoInserimento.Value, out id_prog_asse))
                    throw new Exception("E' necessario specificare il progetto di riferimento per il giustificativo");

                var prog_sog_gest_coll = new ProgettoSoggettoGestoreCollectionProvider().FindProgettiSoggettoGestore(
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        id_prog_asse);
                if (prog_sog_gest_coll.Count != 1)
                    throw new Exception("Progetto non trovato");
                var prog_sog_gest = prog_sog_gest_coll[0];

                var giustificativo = new Giustificativi();
                giustificativo.IdProgetto = id_prog_asse;
                giustificativo.CodTipo = lstTipoGiustificativo.Text;
                giustificativo.Data = txtDataGiustificativo.Text;
                giustificativo.Numero = txtNumGiustificativo.Text;
                giustificativo.NumeroDoctrasporto = null;
                giustificativo.DataDoctrasporto = null;
                giustificativo.Imponibile = txtImportoGiustificativo.Text;
                giustificativo.Iva = txtIva.Text;
                giustificativo.Descrizione = CleanInput(txtDescGiustificativo.Text);
                giustificativo.CfFornitore = txtPivaFornitore.Text.ToUpper();

                if (txtRSFornitore.Text == null || txtRSFornitore.Text.Equals(""))
                {
                    var impresa_provider = new ImpresaCollectionProvider();
                    SiarLibrary.Impresa i = impresa_provider.GetByCuaa(txtPivaFornitore.Text);
                    if (i != null)
                        txtRSFornitore.Text = i.RagioneSociale;
                }

                giustificativo.DescrizioneFornitore = txtRSFornitore.Text;
                giustificativo.IvaNonRecuperabile = chkNonRecuperabile.Checked;
                giustificativo.IdFile = ufGiustificativo.IdFile;
                new GiustificativiCollectionProvider().Save(giustificativo);

                var contratto = new ContrattiFem();
                contratto.IdProgetto = id_prog_asse;
                contratto.IdBando = prog_sog_gest.IdBando;
                contratto.DataCreazione = DateTime.Now;
                contratto.DataAggiornamento = DateTime.Now;
                contratto.OperatoreCreazione = Operatore.Utente.IdUtente;
                contratto.OperatoreAggiornamento = Operatore.Utente.IdUtente;
                contratto.IdGiustificativo = giustificativo.IdGiustificativo;
                contratto.Confidi = true;
                contratto.IdSoggettoGestore = prog_sog_gest.IdSoggettoGestore;
                contratto.IdProgettoSoggettoGestore = prog_sog_gest.IdProgettoSoggettoGestore;
                contratto_provider.Save(contratto);

                hdnIdContratto.Value = "";
                ShowMessage("Dati del contratto inseriti correttamente.");

                CleanCampiGiustificativo();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnAggiungiPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica)
                    throw new SiarException(TextErrorCodes.ModificaDisabilitata);

                int id_contratto;
                if (int.TryParse(hdnIdContratto.Value, out id_contratto))
                    contratto_selezionato = contratto_provider.GetById(id_contratto);
                else
                    throw new Exception("Contratto non selezionato");

                var spesa = new ContrattiFemPagamenti();
                spesa.IdProgetto = contratto_selezionato.IdProgetto;
                spesa.IdContrattoFem = contratto_selezionato.IdContrattoFem;
                spesa.Estremi = txtEstremi.Text;
                spesa.Data = txtDataPagamento.Text;
                spesa.CodTipo = lstPagamento.Text;
                spesa.Importo = txtImportoLordoPagamento.Text;
                spesa.ImportoAmmesso = txtImportoLordoPagamento.Text;
                spesa.IdFile = ufPagamento.IdFile;
                spesa.DataCreazione = DateTime.Now;
                spesa.OperatoreCreazione = Operatore.Utente.IdUtente;
                spesa.OperatoreAggiornamento = Operatore.Utente.IdUtente;
                spesa.DataAggiornamento = DateTime.Now;
                contratto_pagamento_provider.Save(spesa);

                ShowMessage("Dati del pagamento inseriti correttamente.");

                CleanCampiPagamento();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnMostraContratti_Click(object sender, EventArgs e)
        {
            hdnIdContratto.Value = null;
            //hdnIdSoggettoGestore.Value = rblSoggettiGestori.SelectedValue;
            //hdnIdProgetto.Value = rblProgettiSoggetto.SelectedValue;
        }

        protected void btnEstraiContratti_Click(object sender, EventArgs e)
        {
            string id_soggetto = hdnIdSoggettoGestore.Value;
            string id_progetto = hdnIdProgetto.Value;
            if (id_soggetto == "X")
            {
                RegisterClientScriptBlock("SNCVisualizzaReport('rptEstrazioneContrattiFemFondoCovidPocXls', 2 ,'');");
            }
            else
            {
                if (id_progetto == "Y")
                    RegisterClientScriptBlock("SNCVisualizzaReport('rptEstrazioneContrattiFemFondoCovidPocXls', 2 ,'IdSoggettoGestore=" + id_soggetto + "');");
                else
                    RegisterClientScriptBlock("SNCVisualizzaReport('rptEstrazioneContrattiFemFondoCovidPocXls', 2 ,'IdProgetto=" + id_progetto + "|IdSoggettoGestore=" + id_soggetto + "');");
            }


        }


        #endregion
    }
}