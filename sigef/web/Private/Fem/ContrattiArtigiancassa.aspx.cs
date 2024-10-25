using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using SiarBLL;
using SiarLibrary;

namespace web.Private.Fem
{
    public partial class ContrattiArtigiancassa : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "contratti_artigiancassa";
            base.OnPreInit(e);
        }

        Bando bando_selezionato = null;
        BandoCollectionProvider bando_prov = new BandoCollectionProvider();
        Progetto progetto_selezionato = null;
        Progetto progettoArtigiancassa_selezionato = null;
        ProgettoCollectionProvider prog_prov = new ProgettoCollectionProvider();
        ContrattiFem contratto_selezionato = null;
        ContrattiFem giustificativo_selezionato = null;
        ContrattiFemPagamenti pagamento_selezionato = null;
        ContrattiFemCollectionProvider contratto_prov = new ContrattiFemCollectionProvider();
        ContrattiFemPagamentiCollectionProvider contratto_pagamento_prov = new ContrattiFemPagamentiCollectionProvider();
        ProgettoSoggettoGestoreCollectionProvider prog_sog_gest_prov = new ProgettoSoggettoGestoreCollectionProvider();

        protected void Page_Load(object sender, EventArgs e)
        {
            ProgettoSoggettoGestoreCollection prog_sogg = prog_sog_gest_prov.FindProgettiSoggettoGestore((int)SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Artigiancassa, null, null, null, null, null, null);
            if (prog_sogg.Count == 0)
                throw new Exception("Progetto Artigiancassa non trovato.");
            int id_prog_arting = prog_sogg[0].IdProgettoRiferimento;
            progettoArtigiancassa_selezionato = prog_prov.GetById(id_prog_arting);
            if (progettoArtigiancassa_selezionato == null)
                throw new Exception("Progetto Artiogiancassa non trovato");
            int id_contratto_giust;
            if (int.TryParse(hdnIdContrattoFemGiustificativo.Value, out id_contratto_giust))
            {
                giustificativo_selezionato = contratto_prov.GetById(id_contratto_giust);
            }
            else
                giustificativo_selezionato = null;

            int id_bando;
            if (int.TryParse(hdnIdBando.Value, out id_bando))
            {
                bando_selezionato = bando_prov.GetById(id_bando);
                int id_progetto;
                if (int.TryParse(hdnIdProgetto.Value, out id_progetto))
                {
                    progetto_selezionato = prog_prov.GetById(id_progetto);
                    tbContratto.Visible = true;
                    int id_contratto;
                    if (int.TryParse(hdnIdContrattoFem.Value, out id_contratto))
                    {
                        contratto_selezionato = contratto_prov.GetById(id_contratto);

                        int id_pagamento;
                        if (int.TryParse(hdnIdPagamentoFem.Value, out id_pagamento))
                        {
                            pagamento_selezionato = contratto_pagamento_prov.GetById(id_pagamento);
                        }
                        else
                            pagamento_selezionato = null;
                    }
                    else
                        contratto_selezionato = null;
                }
                else
                    tbContratto.Visible = false;

            }

            if (AbilitaModifica)
            {
                if (Operatore.Utente.Profilo != "Amministratore") // ora anche gli amministratori hanno libero accesso e modifica ai dati per pass Funzionalita' #211268
                {
                    var esito = StrumentiFinanziariUtility.VerificaPermessiUtente(Operatore, SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Artigiancassa);
                    if (esito == StrumentiFinanziariUtility.PermessiFem.Lettura)
                        AbilitaModifica = false;
                    else if (esito == StrumentiFinanziariUtility.PermessiFem.Nessuno)
                        Redirect(PATH_PDOMANDA + "Cruscotto.aspx", "Non si hanno i pemessi per accedere alla pagina", true);
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            imgContratti.Attributes.Add("src", PATH_IMAGES + "ArrowUpSolid.png");
            imgGiustificativi.Attributes.Add("src", PATH_IMAGES + "ArrowUpSolid.png");

            btnStampa.Attributes.Add("onclick", "SNCVisualizzaReport('rptEstrazioneContrattiFemArtigiancassaXls',2,'');");

            SiarLibrary.BandoCollection bando_coll = new SiarLibrary.BandoCollection();

            //Gestione Giustificativi
            SiarLibrary.ContrattiFemCollection contratti_femGiust = new SiarLibrary.ContrattiFemCollection();
            //decimal importoFemCalcolato = new SiarBLL.ProgettoCollectionProvider().CalcolaTotaleContributoAltreFonti(progetto_selezionato.IdProgetto);
            if (giustificativo_selezionato != null)
            {
                contratti_femGiust.Add(contratto_prov.GetById(giustificativo_selezionato.IdContrattoFem));
                tbGiustificativiFemPagamento.Visible = true;
                SiarLibrary.ContrattiFemPagamentiCollection pagamenti_coll = contratto_pagamento_prov.Find(null, giustificativo_selezionato.IdContrattoFem, giustificativo_selezionato.IdProgetto, null, null);
                decimal ImportoFemPagamentoInserito = 0;
                foreach (SiarLibrary.ContrattiFemPagamenti fem_pag in pagamenti_coll)
                {
                    ImportoFemPagamentoInserito += fem_pag.Importo;
                }
                if (ImportoFemPagamentoInserito != 0 && giustificativo_selezionato.Importo == ImportoFemPagamentoInserito)
                {
                    btnAggiungiPagamentoGiustificativo.Enabled = false;
                    btnAggiungiPagamentoGiustificativo.ToolTip = "Importo raggiunto!";
                }
                else
                {

                    //int id_bando = Convert.ToInt32(hdnIdBando.Value);
                    //SiarLibrary.BandoResponsabiliCollection resp_coll = new SiarBLL.BandoResponsabiliCollectionProvider().Find(progetto_selezionato.IdBando, Operatore.Utente.IdUtente, null, true, true);
                    //if (resp_coll.Count > 0)
                    if (Operatore.Utente.Profilo == "Operatore FEM")
                        btnAggiungiPagamentoGiustificativo.Enabled = true;
                    else
                    {
                        btnAggiungiPagamentoGiustificativo.Enabled = false;
                        btnAggiungiPagamentoGiustificativo.ToolTip = "Operatore non abilitato all'inserimento";
                    }
                }
                dgGiustificativoFemPagamenti.DataSource = pagamenti_coll;
                dgGiustificativoFemPagamenti.SetTitoloNrElementi();
                dgGiustificativoFemPagamenti.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgContrattiFemPagamenti_ItemDataBound);
                dgGiustificativoFemPagamenti.DataBind();


            }
            else
            {
                SiarLibrary.ContrattiFemCollection contratti_femGiust2 = new SiarBLL.ContrattiFemCollectionProvider().Find(progettoArtigiancassa_selezionato.IdBando, progettoArtigiancassa_selezionato.IdProgetto, null, null, false, (int)SiarBLL.SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Artigiancassa, null);
                foreach (SiarLibrary.ContrattiFem cf in contratti_femGiust2)
                {
                    if (cf.IdGiustificativo != null)
                        contratti_femGiust.Add(cf);
                }
            }
                

            dgContrattiFemGiustificativi.DataSource = contratti_femGiust;
            dgContrattiFemGiustificativi.SetTitoloNrElementi();
            dgContrattiFemGiustificativi.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgContrattiFemGiustificativi_ItemDataBound);
            dgContrattiFemGiustificativi.DataBind();

            //Gestione Contratti
            if (bando_selezionato == null)
            {
                //SiarLibrary.BandoCollection bando_coll_find = bando_prov.Find(null, null, null, null, null, null, null, null, null);
                ////SiarLibrary.BandoResponsabiliCollection resp_coll = new SiarBLL.BandoResponsabiliCollectionProvider().Find(null, Operatore.Utente.IdUtente, null, true, true);
                //foreach (SiarLibrary.Bando r in bando_coll_find)
                //{
                //    string UtStrumFin = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_UtStrumFin(r.IdBando);
                //    if (UtStrumFin == "True")
                //    {
                //        bando_coll.Add(bando_prov.GetById(r.IdBando));
                //    }

                //}
                bando_coll = bando_prov.GetBandiUtilizzanoContrattiArtigiancassa();
                tbProgetti.Visible = false;
            }
            else
            {
                SiarLibrary.ProgettoCollection prog_coll = new SiarLibrary.ProgettoCollection();
                bando_coll.Add(bando_selezionato);
                tbProgetti.Visible = true;


                if (txtProgettoFiltra.Text != "" && txtProgettoFiltra.Text != null)
                {
                    SiarLibrary.Progetto progg = prog_prov.GetById(Convert.ToInt32(txtProgettoFiltra.Text));
                    if (progg != null)
                        if (progg.OrdineFase > 3 && progg.IdBando == bando_selezionato.IdBando)
                            prog_coll.Add(progg);
                }
                else
                {
                    SiarLibrary.ProgettoCollection prog_coll_2 = prog_prov.Find(bando_selezionato.IdBando, null, null, null, null, null, null);
                    foreach (SiarLibrary.Progetto pp in prog_coll_2)
                    {
                        if (pp.OrdineFase != null && pp.OrdineFase > 3 && pp.OrdineStato == 1)
                        {
                            prog_coll.Add(pp);
                        }
                    }

                }

                dgProgetti.DataSource = prog_coll;
                dgProgetti.SetTitoloNrElementi();
                dgProgetti.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgProgetti_ItemDataBound);
                dgProgetti.DataBind();

                if(progetto_selezionato != null)
                {
                    ContrattiFemCollection contratti_fem = new ContrattiFemCollection();
                    decimal importoFemCalcolato = CalcolaContributoFem(progetto_selezionato.IdProgetto);
                    if (contratto_selezionato != null)
                    {
                        contratti_fem.Add(contratto_prov.GetById(contratto_selezionato.IdContrattoFem));
                        tbContrattiFemPagamento.Visible = true;

                        txtNumeroContrattoModifica.Text = contratto_selezionato.Numero;
                        txtDataContrattoModifica.Text = contratto_selezionato.DataStipulaContratto;
                        txtNewImportoModifica.Text = contratto_selezionato.Importo;
                        ufContrattoModifica.IdFile = contratto_selezionato.IdFile;

                        ContrattiFemPagamentiCollection pagamenti_coll = new ContrattiFemPagamentiCollection();
                        ContrattiFemPagamentiCollection pagamenti_totali_coll = contratto_pagamento_prov.Find(null, contratto_selezionato.IdContrattoFem, contratto_selezionato.IdProgetto, null, null);
                        if (pagamento_selezionato != null)
                        {
                            pagamenti_coll.Add(pagamento_selezionato);
                            tbModificaPagamento.Visible = true;
                            lstPagamentoModifica.DataBind();

                            lstPagamentoModifica.SelectedValue = pagamento_selezionato.CodTipo;
                            txtDataPagamentoModifica.Text = pagamento_selezionato.Data;
                            txtImportoLordoPagamentoModifica.Text = pagamento_selezionato.Importo;
                            txtEstremiModifica.Text = pagamento_selezionato.Estremi;
                            ufPagamentoModifica.IdFile = pagamento_selezionato.IdFile;
                        }
                        else
                            pagamenti_coll = pagamenti_totali_coll;

                        decimal ImportoFemPagamentoInserito = 0;
                        foreach (ContrattiFemPagamenti fem_pag in pagamenti_totali_coll)
                        {
                            ImportoFemPagamentoInserito += fem_pag.Importo;
                        }

                        if (ImportoFemPagamentoInserito != 0 && contratto_selezionato.Importo == ImportoFemPagamentoInserito)
                        {
                            btnAggiungiPagamento.Enabled = false;
                            btnAggiungiPagamento.ToolTip = "Importo raggiunto!";
                        }
                        else
                        {
                            if (Operatore.Utente.Profilo == "Operatore FEM")
                                btnAggiungiPagamento.Enabled = true;
                            else
                            {
                                btnAggiungiPagamento.Enabled = false;
                                btnAggiungiPagamento.ToolTip = "Operatore non abilitato all'inserimento";
                            }
                        }

                        dgContrattiFemPagamenti.DataSource = pagamenti_coll;
                        dgContrattiFemPagamenti.SetTitoloNrElementi();
                        dgContrattiFemPagamenti.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgContrattiFemPagamenti_ItemDataBound);
                        dgContrattiFemPagamenti.DataBind();
                    }
                    else
                        contratti_fem = new ContrattiFemCollectionProvider().Find(progetto_selezionato.IdBando, progetto_selezionato.IdProgetto, null, null, false, (int)SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Artigiancassa, null);
                    
                    decimal ImportoFemInserito = 0;
                    ContrattiFemCollection contratti_fem_totali = new ContrattiFemCollectionProvider().Find(progetto_selezionato.IdBando, progetto_selezionato.IdProgetto, null, null, null, (int)SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Artigiancassa, null);
                    foreach (ContrattiFem fem in contratti_fem_totali)
                    {
                        ImportoFemInserito += fem.Importo ?? fem.ImponibileGiustificativo;
                    }
                    if (ImportoFemInserito != 0 && importoFemCalcolato == ImportoFemInserito)
                    {
                        btnAggiungi.Enabled = false;
                        btnAggiungi.ToolTip = "Importo raggiunto!";
                    }
                    else
                    {
                        //int id_bando = Convert.ToInt32(hdnIdBando.Value);
                        //SiarLibrary.BandoResponsabiliCollection resp_coll = new SiarBLL.BandoResponsabiliCollectionProvider().Find(progetto_selezionato.IdBando, Operatore.Utente.IdUtente, null, true, true);
                        //if (resp_coll.Count > 0)
                        if (Operatore.Utente.Profilo == "Operatore FEM")
                            btnAggiungi.Enabled = true;
                        else
                        {
                            btnAggiungi.Enabled = false;
                            btnAggiungi.ToolTip = "Operatore non abilitato all'inserimento";
                        }
                    }
                    
                    dgContrattiFem.DataSource = contratti_fem;
                    dgContrattiFem.SetTitoloNrElementi();
                    dgContrattiFem.ItemDataBound += new DataGridItemEventHandler(dgContrattiFem_ItemDataBound);
                    dgContrattiFem.DataBind();
                }
            }

            dgBando.DataSource = bando_coll;
            dgBando.SetTitoloNrElementi();
            dgBando.ItemDataBound += new DataGridItemEventHandler(dgBando_ItemDataBound);
            dgBando.DataBind();

            base.OnPreRender(e);
        }

        void dgBando_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int col_prog = 2,
                    //col_contr = 3,
                    col_imp_fem = 3,
                    col_imp_contr = 4,
                    col_imp_pag = 5,
                    col_chek = 6;
                SiarLibrary.Bando b = (SiarLibrary.Bando)e.Item.DataItem;
                int count_prog = 0, count_contr = 0;
                decimal importo_fem = 0, importo_contr = 0, importo_pag = 0;
                SiarLibrary.ProgettoCollection prog_coll = prog_prov.Find(b.IdBando, null, null, null, null, null, null);
                foreach (SiarLibrary.Progetto p in prog_coll)
                {
                    if (p.OrdineFase != null && p.OrdineFase > 3 && p.OrdineStato == 1)
                    {
                        

                        decimal totImportoFem = 0;
                        totImportoFem += CalcolaContributoFem(p.IdProgetto);

                        SiarLibrary.ContrattiFemCollection contratti_coll = contratto_prov.Find(p.IdBando, p.IdProgetto, null, null, null, (int)SiarBLL.SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Artigiancassa, null);
                        decimal totContratti = 0;

                        if(contratti_coll.Count>0)
                            count_prog++;

                        foreach (SiarLibrary.ContrattiFem c in contratti_coll)
                            totContratti += c.Importo ?? c.ImponibileGiustificativo;

                        decimal totPagamenti = 0;
                        SiarLibrary.ContrattiFemPagamentiCollection pagamenti_coll = contratto_pagamento_prov.Find(null, null, p.IdProgetto, null, null);
                        foreach (SiarLibrary.ContrattiFemPagamenti cp in pagamenti_coll)
                            totPagamenti += cp.Importo;

                        //if (totImportoFem > 0 && totContratti > 0 && totPagamenti > 0 && totImportoFem == totContratti && totContratti == totPagamenti)
                        //    count_contr++;

                        importo_fem += totImportoFem;
                        importo_contr += totContratti;
                        importo_pag += totPagamenti;
                    }
                }
                e.Item.Cells[col_prog].Text = count_prog.ToString();
                //e.Item.Cells[col_contr].Text = count_contr.ToString();
                e.Item.Cells[col_imp_fem].Text = string.Format("{0:c}", importo_fem);
                e.Item.Cells[col_imp_contr].Text = string.Format("{0:c}", importo_contr);
                e.Item.Cells[col_imp_pag].Text = string.Format("{0:c}", importo_pag);
                e.Item.Cells[col_chek].Text = e.Item.Cells[col_chek].Text.Replace("<input", "<input onclick=\"selezionaBando(" + b.IdBando + ",this);\"");
            }
        }

        void dgProgetti_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.Progetto p = (SiarLibrary.Progetto)e.Item.DataItem;
                SiarLibrary.Impresa imp = new SiarBLL.ImpresaCollectionProvider().GetById(p.IdImpresa);
                e.Item.Cells[2].Text = imp.RagioneSociale;
                e.Item.Cells[3].Text = string.Format("{0:c}", CalcolaContributoFem(p.IdProgetto));

                //Calcolo il totale dei contratti inseriti
                decimal totContratti = 0;
                SiarLibrary.ContrattiFemCollection contratti_coll = contratto_prov.Find(p.IdBando, p.IdProgetto, null, null, null, (int)SiarBLL.SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Artigiancassa, null);
                foreach (SiarLibrary.ContrattiFem c in contratti_coll)
                    totContratti += c.Importo ?? c.ImponibileGiustificativo;
                e.Item.Cells[4].Text = string.Format("{0:c}", totContratti);

                //calcolo il totale dei pagamenti inseriti
                decimal totPagamenti = 0;
                SiarLibrary.ContrattiFemPagamentiCollection pagamenti_coll = contratto_pagamento_prov.Find(null, null, p.IdProgetto, null, null);
                foreach (SiarLibrary.ContrattiFemPagamenti cp in pagamenti_coll)
                    totPagamenti += cp.Importo;
                e.Item.Cells[5].Text = string.Format("{0:c}", totPagamenti);
            }
        }

        decimal totaleImportiContrattiFemGiustificativi = 0, totaleImportiContrattiFemGiustificativiPagamento_ = 0, totaleImportiContrattiFemPagamentoGiustificativi = 0;
        void dgContrattiFemGiustificativi_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            int col_Id = 0,

                col_Numero = 1,

                col_Data = 2,

                col_File = 3,

                col_Importo = 4,

                col_ImportoPag = 5,

                col_Check = 6;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.ContrattiFem fem = (SiarLibrary.ContrattiFem)e.Item.DataItem;

                //if (fem.IdGiustificativo == null)
                //{
                //e.Item.Cells[col_Importo].Text = string.Format("{0:c}", fem.Importo);
                //totaleImportiContrattiFemGiustificativi += fem.Importo;

                //if (fem.IdFile != null)
                //    e.Item.Cells[col_File].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='File'  onclick=\"SNCUFVisualizzaFile(" + fem.IdFile + ");\" style='cursor: pointer;'>";
                //}
                //else
                //{
                e.Item.Cells[col_Numero].Text = fem.NumeroGiustificativo;
                e.Item.Cells[col_Data].Text = fem.DataGiustificativo;
                e.Item.Cells[col_Importo].Text = string.Format("{0:c}", fem.ImponibileGiustificativo);

                totaleImportiContrattiFemGiustificativi += fem.ImponibileGiustificativo;

                if (fem.IdFileGiustificativo != null)
                    e.Item.Cells[col_File].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='File'  onclick=\"SNCUFVisualizzaFile(" + fem.IdFileGiustificativo + ");\" style='cursor: pointer;'>";
                //}

                e.Item.Cells[col_Check].Text = e.Item.Cells[col_Check].Text.Replace("<input", "<input checked onclick=\"selezionaContrattoGiustificativo(" + fem.IdContrattoFem + ",this);\"");
                if (hdnIdContrattoFemGiustificativo.Value == null || hdnIdContrattoFemGiustificativo.Value == "")
                    e.Item.Cells[col_Check].Text = e.Item.Cells[col_Check].Text.Replace("checked", "");

                //calcolo il totale dei pagamenti inseriti
                decimal totPagamenti = 0;
                SiarLibrary.ContrattiFemPagamentiCollection pagamenti_coll = contratto_pagamento_prov.Find(null, fem.IdContrattoFem, fem.IdProgetto, null, null);
                foreach (SiarLibrary.ContrattiFemPagamenti cp in pagamenti_coll)
                    totPagamenti += cp.Importo;
                e.Item.Cells[col_ImportoPag].Text = string.Format("{0:c}", totPagamenti);
                totaleImportiContrattiFemGiustificativiPagamento_ += totPagamenti;
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[col_Importo].Text = string.Format("{0:c}", totaleImportiContrattiFemGiustificativi);
                e.Item.Cells[col_ImportoPag].Text = string.Format("{0:c}", totaleImportiContrattiFemGiustificativiPagamento_);
            }
        }

        decimal totaleImportiContrattiFem = 0, totaleImportiContrattiFemPagamento_ = 0, totaleImportiContrattiFemPagamento = 0;
        void dgContrattiFem_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            int col_Id = 0,

                col_Numero = 1,

                col_Data =2,

                col_File = 3,

                col_Importo = 4,

                col_ImportoPag = 5,

                col_Check = 6;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.ContrattiFem fem = (SiarLibrary.ContrattiFem)e.Item.DataItem;
                
                //if (fem.IdGiustificativo == null)
                //{
                e.Item.Cells[col_Importo].Text = string.Format("{0:c}", fem.Importo);
                totaleImportiContrattiFem += fem.Importo;

                if (fem.IdFile != null)
                    e.Item.Cells[col_File].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='File'  onclick=\"SNCUFVisualizzaFile(" + fem.IdFile + ");\" style='cursor: pointer;'>";
                else if(fem.Segnatura != null)
                    e.Item.Cells[col_File].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='File'  onclick=\"sncAjaxCallVisualizzaProtocollo('" + fem.Segnatura + "');\" style='cursor: pointer;'>";
                //}
                //else
                //{
                //    e.Item.Cells[col_Numero].Text = fem.NumeroGiustificativo;
                //    e.Item.Cells[col_Data].Text = fem.DataGiustificativo;
                //    e.Item.Cells[col_Importo].Text = string.Format("{0:c}", fem.ImponibileGiustificativo);
                //    totaleImportiContrattiFem += fem.ImponibileGiustificativo;

                //    if (fem.IdFileGiustificativo != null)
                //        e.Item.Cells[col_File].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='File'  onclick=\"SNCUFVisualizzaFile(" + fem.IdFileGiustificativo + ");\" style='cursor: pointer;'>";
                //}

                e.Item.Cells[col_Check].Text = e.Item.Cells[col_Check].Text.Replace("<input", "<input checked onclick=\"selezionaContratto(" + fem.IdContrattoFem + ",this);\"");
                if (hdnIdContrattoFem.Value == null || hdnIdContrattoFem.Value == "")
                    e.Item.Cells[col_Check].Text = e.Item.Cells[col_Check].Text.Replace("checked", "");

                //calcolo il totale dei pagamenti inseriti
                decimal totPagamenti = 0;
                SiarLibrary.ContrattiFemPagamentiCollection pagamenti_coll = contratto_pagamento_prov.Find(null, fem.IdContrattoFem, fem.IdProgetto, null, null);
                foreach (SiarLibrary.ContrattiFemPagamenti cp in pagamenti_coll)
                    totPagamenti += cp.Importo;
                e.Item.Cells[col_ImportoPag].Text = string.Format("{0:c}", totPagamenti);
                totaleImportiContrattiFemPagamento_ += totPagamenti;
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[col_Importo].Text = string.Format("{0:c}", totaleImportiContrattiFem);
                e.Item.Cells[col_ImportoPag].Text = string.Format("{0:c}", totaleImportiContrattiFemPagamento_);
            }
        }

        void dgContrattiFemPagamenti_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.ContrattiFemPagamenti fem_pag = (SiarLibrary.ContrattiFemPagamenti)e.Item.DataItem;

                if (fem_pag.IdFile != null)
                    e.Item.Cells[4].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='File'  onclick=\"SNCUFVisualizzaFile(" + fem_pag.IdFile + ");\" style='cursor: pointer;'>";
                e.Item.Cells[5].Text = string.Format("{0:c}", fem_pag.Importo);
                totaleImportiContrattiFemPagamento += fem_pag.Importo;

                e.Item.Cells[6].Text = e.Item.Cells[6].Text.Replace("<input", "<input checked onclick=\"selezionaPagamento(" + fem_pag.IdContrattoFemPagamenti + ",this);\"");
                if (hdnIdPagamentoFem.Value == null || hdnIdPagamentoFem.Value == "")
                    e.Item.Cells[6].Text = e.Item.Cells[6].Text.Replace("checked", "");
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[5].Text = string.Format("{0:c}", totaleImportiContrattiFemPagamento);
            }
        }
        

        protected void btnPost_Click(object sender, EventArgs e)
        {
            dgBando.SetPageIndex(0);
        }

        protected void btnPost2_Click(object sender, EventArgs e)
        {
            dgContrattiFem.SetPageIndex(0);
            if (hdnIdContrattoFem.Value != null && hdnIdContrattoFem.Value != "")
                hdnTotaleContratto.Value = contratto_prov.GetById(Convert.ToInt32(hdnIdContrattoFem.Value)).Importo;
        }

        protected void btnPostGiust2_Click(object sender, EventArgs e)
        {
            dgContrattiFemGiustificativi.SetPageIndex(0);
            if (hdnIdContrattoFemGiustificativo.Value != null && hdnIdContrattoFemGiustificativo.Value != "")
                hdnTotaleGiustificativo.Value = contratto_prov.GetById(Convert.ToInt32(hdnIdContrattoFemGiustificativo.Value)).ImponibileGiustificativo;

        }

        protected void btnSelezionaProgetto_Click(object sender, EventArgs e)
        {
            tbContratto.Visible = true;
            txtIdProgetto.Text = progetto_selezionato.IdProgetto;
            SiarLibrary.Impresa imp = new SiarBLL.ImpresaCollectionProvider().GetById(progetto_selezionato.IdImpresa);
            if (imp != null)
                txtRagioneSociale.Text = imp.RagioneSociale;
            txtImporto.Text = CalcolaContributoFem(progetto_selezionato.IdProgetto).ToString();
        }

        //spostato su ProgettoCollectionProviderPartial.cs
        //private decimal CalcolaTotaleContributoAltreFonti(int IdProgetto)
        //{
        //    decimal totaleImportoFem = 0;
        //    SiarLibrary.PianoInvestimentiCollection pianoInv_col = new SiarBLL.PianoInvestimentiCollectionProvider().GetPianoInvestimentiIstruttoria(IdProgetto);
        //    foreach (SiarLibrary.PianoInvestimenti p in pianoInv_col)
        //    {
        //        if (p.ContributoAltreFonti != null)
        //            totaleImportoFem += p.ContributoAltreFonti;
        //    }
        //    return totaleImportoFem;
        //}

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

                //Commento perchè controlli fatti in javascript

                ////verifico che l'importo inserito piu quelli gia esistenti non siano superiori all'importo totale calcolato dal sigef
                //if (txtNewImporto.Text == null || txtNewImporto.Text == "")
                //    throw new Exception("Inserire l'importo del contratto.");
                //decimal totCalcolato = CalcolaTotaleContributoAltreFonti(progetto_selezionato.IdProgetto);
                //decimal totInserito = 0;
                //SiarLibrary.ContrattiFemCollection contratti_fem = new SiarBLL.ContrattiFemCollectionProvider().Find(progetto_selezionato.IdBando, progetto_selezionato.IdProgetto);
                //foreach (SiarLibrary.ContrattiFem fem in contratti_fem)
                //    totInserito += fem.Importo;
                //if((totInserito + Convert.ToDecimal( txtNewImporto.Text))> totCalcolato )
                //    throw new Exception("L'importo inserito o la somma degli importi inseriti sono maggiori dell'importo FEM calcolato dal sistema");
                //if (txtDataSegnatura.Text == null || txtDataSegnatura.Text == "")
                //    throw new Exception("Inserire la data della segnatura.");
                //if (txtDataContratto.Text == null || txtDataContratto.Text == "")
                //    throw new Exception("Inserire la data di stipula del contratto.");
                if (ufContratto.IdFile == null || ufContratto.IdFile == "")
                    throw new Exception("Inserire il documento relativo al pagamento.");


                SiarLibrary.ContrattiFem contratto = new SiarLibrary.ContrattiFem();
                contratto.IdProgetto = progetto_selezionato.IdProgetto;
                contratto.IdBando = progetto_selezionato.IdBando;
                contratto.DataCreazione = DateTime.Now;
                contratto.DataAggiornamento = DateTime.Now;
                contratto.DataStipulaContratto = txtDataContratto.Text;
                contratto.Importo = txtNewImporto.Text;
                contratto.IdFile = ufContratto.IdFile;
                contratto.Numero = txtNumeroContratto.Text;
                contratto.OperatoreCreazione = Operatore.Utente.IdUtente;
                contratto.OperatoreAggiornamento = Operatore.Utente.IdUtente;
                contratto.IdSoggettoGestore = (int)SiarBLL.SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Artigiancassa;
                contratto.IdProgettoSoggettoGestore = prog_sog_gest_prov.FindProgettiSoggettoGestore((int)SiarBLL.SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Artigiancassa, null, null, null, null, progettoArtigiancassa_selezionato.IdBando, progettoArtigiancassa_selezionato.IdProgetto)[0].IdProgettoSoggettoGestore;
                contratto_prov.Save(contratto);
                divNuovoContratto.Visible = false;
                //hdnIdProgetto.Value = "";
                hdnIdContrattoFem.Value = "";
                ShowMessage("Dati del contratto inseriti correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalvaModificaContratto_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica && Operatore.Utente.Profilo != "Amministratore") 
                    throw new SiarException(TextErrorCodes.ModificaDisabilitata);

                int id_contratto;
                if (int.TryParse(hdnIdContrattoFem.Value, out id_contratto))
                {
                    contratto_selezionato = contratto_prov.GetById(id_contratto);
                }
                else
                    throw new Exception("Non ho trovato il contratto selezionato");

                if (ufContrattoModifica.IdFile == null || ufContrattoModifica.IdFile == "")
                    throw new Exception("Inserire il documento relativo al pagamento.");

                contratto_selezionato.OperatoreAggiornamento = Operatore.Utente.IdUtente;
                contratto_selezionato.DataAggiornamento = DateTime.Now;
                contratto_selezionato.Numero = txtNumeroContrattoModifica.Text;
                contratto_selezionato.DataStipulaContratto = txtDataContrattoModifica.Text;
                contratto_selezionato.Importo = txtNewImportoModifica.Text;
                contratto_selezionato.IdFile = ufContrattoModifica.IdFile;

                contratto_prov.Save(contratto_selezionato);
                hdnIdContrattoFem.Value = "";
                ShowMessage("Dati del contratto aggiornati correttamente.");
            }
            catch (Exception ex) 
            { 
                ShowError(ex); 
            }
        }

        protected void btnFiltra_Click(object sender, EventArgs e)
        {
            dgProgetti.SetPageIndex(0);
            tbContratto.Visible = false;

            hdnIdProgetto.Value = "";
            hdnIdContrattoFem.Value = "";
        }

        protected void btnAggiungi_Click(object sender, EventArgs e)
        {

            divNuovoContratto.Visible = true;
            tbContrattiFemPagamento.Visible = false;
            hdnIdContrattoFem.Value = "";
            hdnTotaleFem.Value = txtImporto.Text;
            ufContratto.AbilitaModifica = true;
            ufGiustificativo.AbilitaModifica = true;
            //lstTipoGiustificativo.DataBind();

            decimal totInserito = 0;
            SiarLibrary.ContrattiFemCollection contratti_fem = new SiarBLL.ContrattiFemCollectionProvider().Find(progetto_selezionato.IdBando, progetto_selezionato.IdProgetto, null, null, null, (int)SiarBLL.SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Artigiancassa, null);
            foreach (SiarLibrary.ContrattiFem fem in contratti_fem)
                totInserito += fem.Importo ?? fem.ImponibileGiustificativo;
            hdnTotaleContrattiInseriti.Value = totInserito.ToString();
        }

        protected void btnAggiungiGiustificativo_Click(object sender, EventArgs e)
        {

            divNuovoGiustificativo.Visible = true;
            tbGiustificativiFemPagamento.Visible = false;
            hdnIdContrattoFemGiustificativo.Value = "";
            //hdnTotaleFem.Value = txtImporto.Text;
            ufGiustificativo.AbilitaModifica = true;
            lstTipoGiustificativo.DataBind();

            decimal totInserito = 0;
            SiarLibrary.ContrattiFemCollection contratti_fem = new SiarBLL.ContrattiFemCollectionProvider().Find(progettoArtigiancassa_selezionato.IdBando, progettoArtigiancassa_selezionato.IdProgetto, null, null, null, (int)SiarBLL.SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Artigiancassa, null);
            foreach (SiarLibrary.ContrattiFem fem in contratti_fem)
                totInserito += fem.Importo ?? fem.ImponibileGiustificativo;
            hdnTotaleGiustificativiInseriti.Value = totInserito.ToString();
        }

        protected void btnAggiungiPagamento_Click(object sender, EventArgs e)
        {
            tbNuovoPagamento.Visible = true;
            lstPagamento.DataBind();
            ufPagamento.AbilitaModifica = true;

            decimal totInserito = 0;
            SiarLibrary.ContrattiFemPagamentiCollection coll_pag = contratto_pagamento_prov.Find(null, contratto_selezionato.IdContrattoFem, contratto_selezionato.IdProgetto, null, null);
            foreach (SiarLibrary.ContrattiFemPagamenti p in coll_pag)
                totInserito += p.Importo;
            hdnTotalePagamentiInseriti.Value = totInserito.ToString();
        }

        protected void btnAggiungiPagamentoGiustificativo_Click(object sender, EventArgs e)
        {
            tbNuovoPagamentoGiustificativo.Visible = true;
            lstPagamentoGiust.DataBind();
            ufPagamentoGiust.AbilitaModifica = true;

            decimal totInserito = 0;
            SiarLibrary.ContrattiFemPagamentiCollection coll_pag = contratto_pagamento_prov.Find(null, giustificativo_selezionato.IdContrattoFem, giustificativo_selezionato.IdProgetto, null, null);
            foreach (SiarLibrary.ContrattiFemPagamenti p in coll_pag)
                totInserito += p.Importo;
            hdnTotalePagamentiGiustificativiInseriti.Value = totInserito.ToString();
        }


        protected void btnSalvaPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

                //Commento perchè controlli fatti in javascript

                ////Calcolo l'importo gia inserito
                //decimal totInserito = 0;
                //SiarLibrary.ContrattiFemPagamentiCollection coll_pag = contratto_pagamento_prov.Find(null, contratto_selezionato.IdContrattoFem, contratto_selezionato.IdProgetto);
                //foreach (SiarLibrary.ContrattiFemPagamenti p in coll_pag)
                //    totInserito += p.Importo;
                //if(totInserito + Convert.ToDecimal(txtImportoLordoPagamento.Text) > contratto_selezionato.Importo)
                //    throw new Exception("L'importo inserito o la somma degli importi inseriti sono maggiori dell'importo del contratto");

                //if (txtDataPagamento.Text == null || txtDataPagamento.Text == "")
                //    throw new Exception("Inserire la data di stipula del contratto.");
                //if (txtEstremi.Text == null || txtEstremi.Text == "")
                //    throw new Exception("Inserire la data di stipula del contratto.");
                //if (txtImportoLordoPagamento.Text == null || txtImportoLordoPagamento.Text == "")
                //    throw new Exception("Inserire la data di stipula del contratto.");
                //if (lstPagamento.SelectedValue == null || lstPagamento.SelectedValue == "")
                //    throw new Exception("Inserire la data di stipula del contratto.");

                if (ufPagamento.IdFile == null || ufPagamento.IdFile == "")
                    throw new Exception("Inserire il documento relativo al pagamento.");

                SiarLibrary.ContrattiFemPagamenti spesa = new SiarLibrary.ContrattiFemPagamenti();
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
                contratto_pagamento_prov.Save(spesa); 
                ShowMessage("Dati del pagamento inseriti correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalvaPagamentoModifica_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica && Operatore.Utente.Profilo != "Amministratore") 
                    throw new SiarException(TextErrorCodes.ModificaDisabilitata);

                int id_pagamento;
                if (int.TryParse(hdnIdPagamentoFem.Value, out id_pagamento))
                {
                    pagamento_selezionato = contratto_pagamento_prov.GetById(id_pagamento);
                }
                else
                    throw new Exception("Non ho trovato il pagamento selezionato");

                if (ufPagamentoModifica.IdFile == null || ufPagamentoModifica.IdFile == "")
                    throw new Exception("Inserire il documento relativo al pagamento.");

                pagamento_selezionato.Estremi = txtEstremiModifica.Text;
                pagamento_selezionato.Data = txtDataPagamentoModifica.Text;
                pagamento_selezionato.CodTipo = lstPagamentoModifica.Text;
                pagamento_selezionato.Importo = txtImportoLordoPagamentoModifica.Text;
                pagamento_selezionato.ImportoAmmesso = txtImportoLordoPagamentoModifica.Text;
                pagamento_selezionato.IdFile = ufPagamentoModifica.IdFile;
                pagamento_selezionato.OperatoreAggiornamento = Operatore.Utente.IdUtente;
                pagamento_selezionato.DataAggiornamento = DateTime.Now;
                contratto_pagamento_prov.Save(pagamento_selezionato);
                ShowMessage("Dati del pagamento modificati correttamente.");
            }
            catch (Exception ex) 
            { 
                ShowError(ex); 
            }
        }

        protected void btnSalvaPagamentoGiustificativo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

                //Commento perchè controlli fatti in javascript

                ////Calcolo l'importo gia inserito
                //decimal totInserito = 0;
                //SiarLibrary.ContrattiFemPagamentiCollection coll_pag = contratto_pagamento_prov.Find(null, contratto_selezionato.IdContrattoFem, contratto_selezionato.IdProgetto);
                //foreach (SiarLibrary.ContrattiFemPagamenti p in coll_pag)
                //    totInserito += p.Importo;
                //if(totInserito + Convert.ToDecimal(txtImportoLordoPagamento.Text) > contratto_selezionato.Importo)
                //    throw new Exception("L'importo inserito o la somma degli importi inseriti sono maggiori dell'importo del contratto");

                //if (txtDataPagamento.Text == null || txtDataPagamento.Text == "")
                //    throw new Exception("Inserire la data di stipula del contratto.");
                //if (txtEstremi.Text == null || txtEstremi.Text == "")
                //    throw new Exception("Inserire la data di stipula del contratto.");
                //if (txtImportoLordoPagamento.Text == null || txtImportoLordoPagamento.Text == "")
                //    throw new Exception("Inserire la data di stipula del contratto.");
                //if (lstPagamento.SelectedValue == null || lstPagamento.SelectedValue == "")
                //    throw new Exception("Inserire la data di stipula del contratto.");

                if (ufPagamentoGiust.IdFile == null || ufPagamentoGiust.IdFile == "")
                    throw new Exception("Inserire il documento relativo al pagamento.");

                SiarLibrary.ContrattiFemPagamenti spesa = new SiarLibrary.ContrattiFemPagamenti();
                spesa.IdProgetto = giustificativo_selezionato.IdProgetto;
                spesa.IdContrattoFem = giustificativo_selezionato.IdContrattoFem;
                spesa.Estremi = txtEstremiGiust.Text;
                spesa.Data = txtDataPagamentoGiust.Text;
                spesa.CodTipo = lstPagamentoGiust.Text;
                spesa.Importo = txtImportoLordoPagamentoGiust.Text;
                spesa.ImportoAmmesso = txtImportoLordoPagamentoGiust.Text;
                spesa.IdFile = ufPagamentoGiust.IdFile;
                spesa.DataCreazione = DateTime.Now;
                spesa.OperatoreCreazione = Operatore.Utente.IdUtente;
                spesa.OperatoreAggiornamento = Operatore.Utente.IdUtente;
                spesa.DataAggiornamento = DateTime.Now;
                contratto_pagamento_prov.Save(spesa);
                ShowMessage("Dati del pagamento inseriti correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }
        

        protected void btnSalvaGiustificativo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica)
                    throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (ufGiustificativo.IdFile == null || ufGiustificativo.IdFile == "")
                    throw new Exception("Inserire il documento relativo al pagamento.");

                SiarLibrary.Giustificativi giustificativo = new SiarLibrary.Giustificativi();
                giustificativo.IdProgetto = progettoArtigiancassa_selezionato.IdProgetto;
                giustificativo.CodTipo = lstTipoGiustificativo.Text;
                giustificativo.Data = txtDataGiustificativo.Text;
                giustificativo.Numero = txtNumGiustificativo.Text;
                //giustificativo.NumeroDoctrasporto = txtNumDocTrasporto.Text;
                //giustificativo.DataDoctrasporto = txtDataDocTrasporto.Text;
                giustificativo.Imponibile = txtImportoGiustificativo.Text;
                giustificativo.Iva = txtIva.Text;
                giustificativo.Descrizione = CleanInput(txtDescGiustificativo.Text);
                giustificativo.CfFornitore = txtPivaFornitore.Text.ToUpper();
                if (txtRSFornitore.Text == null || txtRSFornitore.Text.Equals(""))
                {
                    SiarBLL.ImpresaCollectionProvider impresa_provider = new SiarBLL.ImpresaCollectionProvider();
                    SiarLibrary.Impresa i = impresa_provider.GetByCuaa(txtPivaFornitore.Text);
                    if (i != null)
                        txtRSFornitore.Text = i.RagioneSociale;
                }
                giustificativo.DescrizioneFornitore = txtRSFornitore.Text;
                giustificativo.IvaNonRecuperabile = chkNonRecuperabile.Checked;
                giustificativo.IdFile = ufGiustificativo.IdFile;
                new SiarBLL.GiustificativiCollectionProvider().Save(giustificativo);

                SiarLibrary.ContrattiFem contratto = new SiarLibrary.ContrattiFem();
                contratto.IdProgetto = progettoArtigiancassa_selezionato.IdProgetto;
                contratto.IdBando = progettoArtigiancassa_selezionato.IdBando;
                contratto.DataCreazione = DateTime.Now;
                contratto.DataAggiornamento = DateTime.Now;
                contratto.OperatoreCreazione = Operatore.Utente.IdUtente;
                contratto.OperatoreAggiornamento = Operatore.Utente.IdUtente;
                contratto.IdGiustificativo = giustificativo.IdGiustificativo;
                contratto.IdSoggettoGestore = (int)SiarBLL.SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Artigiancassa;
                contratto.IdProgettoSoggettoGestore = prog_sog_gest_prov.FindProgettiSoggettoGestore((int)SiarBLL.SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Artigiancassa, null, null, null, null, progettoArtigiancassa_selezionato.IdBando, progettoArtigiancassa_selezionato.IdProgetto)[0].IdProgettoSoggettoGestore;
                contratto_prov.Save(contratto);

                divNuovoContratto.Visible = false;
                //hdnIdProgetto.Value = "";
                hdnIdContrattoFem.Value = "";
                ShowMessage("Dati del contratto inseriti correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
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

        public decimal CalcolaContributoFem(int IdProgetto)
        {
            decimal contributoFem = 0;
            int idVariante = 0;
            SiarLibrary.VariantiCollection var_coll = new SiarBLL.VariantiCollectionProvider().Find(null, IdProgetto, null);
            foreach (SiarLibrary.Varianti v in var_coll)
            {
                if (v.SegnaturaApprovazione != null && v.SegnaturaApprovazione != "" && v.Approvata == true)
                    idVariante = v.IdVariante;
            }

            
            SiarLibrary.PianoInvestimentiCollection pianoInv_col;
            if (idVariante == 0)
                pianoInv_col = new SiarBLL.PianoInvestimentiCollectionProvider().GetSituazionePianoInvestimenti(IdProgetto);
            else
                pianoInv_col = new SiarBLL.PianoInvestimentiCollectionProvider().GetPianoInvestimentiVariante(IdProgetto,idVariante);

            foreach (SiarLibrary.PianoInvestimenti p in pianoInv_col)
            {
                if (p.ContributoAltreFonti != null && p.CodVariazione != "A")
                    contributoFem += p.ContributoAltreFonti;
            }


            return contributoFem;
        }

    }
}