using SiarBLL;
using SiarLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace web.Private.Fem
{
    public partial class ContrattiConfidi : SiarLibrary.Web.PrivatePage
    {
        ContrattiFemCollectionProvider contratto_provider = new ContrattiFemCollectionProvider();
        ContrattiFemPagamentiCollectionProvider contratto_pagamento_provider = new ContrattiFemPagamentiCollectionProvider();

        ContrattiFem contratto_selezionato;
        ProgettoSoggettoGestoreCollection progetti_coll;

        #region Indici colonne Datagrid

        //dgContratti
        private int col_con_numero = 0,
            col_con_file = 1,
            col_con_impresa = 2,
            col_con_pivaimpresa = 3,
            col_con_tipologia_credito = 4,
            col_con_finalita_operazione = 5,
            col_con_imp_finanziamento = 6,
            col_con_data_erogazione = 7,
            col_con_imp_garanzia_confidi = 8,
            col_con_imp_garanzia_fondo = 9,
            col_con_regime = 10,
            col_con_perdita_fondo = 11,
            col_con_imp_contratto = 12,
            col_con_imp_pagamenti = 13,
            col_con_check = 14;

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
            FunzioneMenu = "contratti_confidi";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (AbilitaModifica)
            {
                var esito = StrumentiFinanziariUtility.VerificaPermessiUtente(Operatore, SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Confidi_Unico);
                if (esito == StrumentiFinanziariUtility.PermessiFem.Lettura)
                    AbilitaModifica = false;
                else if (esito == StrumentiFinanziariUtility.PermessiFem.Nessuno)
                    Redirect(PATH_PDOMANDA + "Cruscotto.aspx", "Non si hanno i pemessi per accedere alla pagina", true);

                //progetti_coll = new ProgettoSoggettoGestoreCollectionProvider().FindProgettiSoggettoGestore(
                //    (int)SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Confidi,
                //    null,
                //    null,
                //    null,
                //    null,
                //    null,
                //    null);

                if (Operatore.Utente.Profilo == "Operatore FEM")
                    progetti_coll = new ProgettoSoggettoGestoreCollectionProvider()
                        .FindOperatoreCreazioneSoggettoGestore(Operatore.Utente.IdUtente,false);
                else
                {
                    progetti_coll = new ProgettoSoggettoGestoreCollectionProvider()
                        .FindOperatoreCreazioneSoggettoGestore(null, false);
                }

                if (progetti_coll.Count > 0)
                {
                    foreach (ProgettoSoggettoGestore p in progetti_coll)
                    {
                        ListItem itemProgetto = new ListItem(p.IdProgettoRiferimento, p.IdProgettoRiferimento);
                        itemProgetto.Attributes.Add("IdSoggettoGestore", p.IdSoggettoGestore);
                        if (!rblProgettiSoggetto.Items.Contains(itemProgetto))
                            rblProgettiSoggetto.Items.Add(itemProgetto);

                        ListItem itemProgettoInserimento = new ListItem(p.IdProgettoRiferimento, p.IdProgettoRiferimento);
                        if (!rblProgettiInserimento.Items.Contains(itemProgettoInserimento))
                            rblProgettiInserimento.Items.Add(itemProgettoInserimento);
                    }
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            lstTipoGiustificativo.DataBind();
            lstPagamento.DataBind();

            string id_progetto = hdnIdProgetto.Value;
            string id_progetto_inserimento = hdnIdProgettoInserimento.Value;
            rblProgettiSoggetto.SelectedValue = id_progetto;
            rblProgettiInserimento.SelectedValue = id_progetto_inserimento;

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
                //contratti_coll = contratto_provider.FindConfidi(null, true, (int)SiarBLL.SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Confidi, null);
                contratti_coll = contratto_provider.GetContrattiConfidiVela(
                    id_progetto == "Y" ? null : id_progetto);

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

                if (fem.IdGiustificativo == null)
                {
                    e.Item.Cells[col_con_imp_finanziamento].Text = string.Format("{0:c}", fem.ImportoFinanziamento);
                    e.Item.Cells[col_con_imp_garanzia_confidi].Text = string.Format("{0:c}", fem.ImportoGaranziaConfidi);
                    e.Item.Cells[col_con_imp_garanzia_fondo].Text = string.Format("{0:c}", fem.ImportoGaranziaFondo);
                    e.Item.Cells[col_con_perdita_fondo].Text = string.Format("{0:c}", fem.PerditaFondoEscussioneConfidi);
                    e.Item.Cells[col_con_imp_contratto].Text = string.Format("{0:c}", fem.Importo);

                    if (fem.IdFile != null)
                        e.Item.Cells[col_con_file].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='File'  onclick=\"SNCUFVisualizzaFile(" + fem.IdFile + ");\" style='cursor: pointer;'>";
                }
                else
                {
                    e.Item.Cells[col_con_numero].Text = fem.NumeroGiustificativo;
                    e.Item.Cells[col_con_data_erogazione].Text = fem.DataGiustificativo;
                    e.Item.Cells[col_con_imp_contratto].Text = string.Format("{0:c}", fem.ImponibileGiustificativo);

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

                    var errore = StrumentiFinanziariUtility.ImportaContrattiConfidi(null, file.Id, file.Contenuto, Operatore.Utente.IdUtente, out contratti_nuovi, out contratti_aggiornati);
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

                //var id_prog_asse = rblProgetti.SelectedValue;
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
                contratto.IdSoggettoGestore = (int)SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Confidi_Unico;
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
            string id_progetto = hdnIdProgetto.Value;
            if (id_progetto == "Y")
                RegisterClientScriptBlock("SNCVisualizzaReport('rptEstrazioneContrattiFemFondoConfidiXls', 2 ,'');");
            else
                RegisterClientScriptBlock("SNCVisualizzaReport('rptEstrazioneContrattiFemFondoConfidiXls', 2 ,'IdProgetto=" + id_progetto + "');");
        }

        
        

        #endregion
    }
}