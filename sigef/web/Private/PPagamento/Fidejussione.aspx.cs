using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;




namespace web.Private.PPagamento
{
    public partial class Fidejussione : SiarLibrary.Web.DomandaPagamentoPage
    {
        SiarBLL.FidejussioniCollectionProvider fidejussioni_provider;
        SiarLibrary.Fidejussioni fidejussione;
        
        SiarBLL.AggregazioneCollectionProvider aggregazione_prov = new SiarBLL.AggregazioneCollectionProvider();
        string codTipoFidejussioneBando = null;
        decimal ammontare_richiesto, ammontare_garantito;
        bool boolAggregazione = false;
        SiarBLL.DomandaPagamentoFidejussioneCollectionProvider dompag_fidej_prov = new SiarBLL.DomandaPagamentoFidejussioneCollectionProvider();
        SiarBLL.DomandaPagamentoFidejussioneImpresaCollectionProvider dompag_fidej_imp_prov = new SiarBLL.DomandaPagamentoFidejussioneImpresaCollectionProvider();
        SiarLibrary.DomandaPagamentoFidejussione testa_fidej = null;
        SiarLibrary.DomandaPagamentoFidejussioneImpresa impresa_fidej = null;
        SiarBLL.ImpresaCollectionProvider impresa_prov = new SiarBLL.ImpresaCollectionProvider();
        SiarLibrary.Impresa impresa_selezionata = null;
        SiarBLL.PianoInvestimentiCollectionProvider  investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider();
        string QuotaFidej, MesiFidej;

        protected void Page_Load(object sender, EventArgs e)
        {
            fidejussioni_provider = new SiarBLL.FidejussioniCollectionProvider(PagamentoProvider.DbProviderObj);
            SiarLibrary.BandoTipoPagamento btpc = new SiarBLL.BandoTipoPagamentoCollectionProvider().GetById(Progetto.IdBando, DomandaPagamento.CodTipo);
            if (btpc != null) codTipoFidejussioneBando = btpc.CodTipoPolizza;

            //Valorizzo variabili mesi e quota fidejussione presi da bandoConfig, se non presenti le imposto di default
            QuotaFidej = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_QuotaFidej(Progetto.IdBando);
            if (QuotaFidej == null || QuotaFidej == "")
                QuotaFidej = "100";
            hdnQuotaFidej.Value = QuotaFidej;
            MesiFidej = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_MesiDurataFidej(Progetto.IdBando);
            if (MesiFidej == null || MesiFidej == "")
                MesiFidej = "6";
            hdnMesiFidej.Value = MesiFidej;

            if (DomandaPagamento.IdFidejussione != null)
            {
                hdnIdFidejussione.Value = DomandaPagamento.IdFidejussione.ToString();
                testa_fidej = dompag_fidej_prov.GetById(DomandaPagamento.IdFidejussione);
            }
            
            //SiarLibrary.DomandaPagamentoFidejussioneCollection fidej_coll = dompag_fidej_prov.Find(DomandaPagamento.IdDomandaPagamento, DomandaPagamento.IdProgetto);
            //if (fidej_coll.Count > 0)
            //{
            //    testa_fidej = fidej_coll[0];
            //    hdnIdFidejussione
            //}

            int id_impresa;

            SiarLibrary.Bando bando = null;
            SiarBLL.BandoCollectionProvider bando_prov = new SiarBLL.BandoCollectionProvider();
            bando = bando_prov.GetById(Progetto.IdBando);
            if(bando.Aggregazione)
            {
                SiarBLL.ProgettoNaturaSoggettoCollectionProvider natura_sogg_prov = new SiarBLL.ProgettoNaturaSoggettoCollectionProvider();
                SiarLibrary.ProgettoNaturaSoggettoCollection natura_coll = natura_sogg_prov.Find(Progetto.IdProgetto, null, null);
                if (natura_coll[0].TipoNaturaSoggetto == "Aggregata")
                    boolAggregazione = true;
                else
                    boolAggregazione = false;
            }
            else
                boolAggregazione = aggregazione_prov.VerificaAggregazione(Progetto.IdProgetto);
            if (boolAggregazione)
            {
                

                if (int.TryParse(hdnIdImpresa.Value, out id_impresa))
                {
                    impresa_selezionata = impresa_prov.GetById(id_impresa);
                    if (testa_fidej != null)
                    {
                        SiarLibrary.DomandaPagamentoFidejussioneImpresaCollection imp_fid_coll = dompag_fidej_imp_prov.Find(testa_fidej.IdDomandaPagamentoFidejussione, DomandaPagamento.IdDomandaPagamento, DomandaPagamento.IdProgetto, id_impresa);
                        if (imp_fid_coll.Count > 0)
                        {
                            impresa_fidej = imp_fid_coll[0];
                        }
                    }
                }
            }
            else
            {
                hdnIdImpresa.Value = Progetto.IdImpresa.ToString();
                impresa_selezionata = impresa_prov.GetById(Progetto.IdImpresa);
                if (testa_fidej != null)
                {
                    SiarLibrary.DomandaPagamentoFidejussioneImpresaCollection imp_fid_coll = dompag_fidej_imp_prov.Find(testa_fidej.IdDomandaPagamentoFidejussione, DomandaPagamento.IdDomandaPagamento, DomandaPagamento.IdProgetto, Progetto.IdImpresa);
                    if (imp_fid_coll.Count > 0)
                    {
                        impresa_fidej = imp_fid_coll[0];
                    }
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            try
            {
                //txtDataFineLavori.AddJSAttribute("oninput", "CalcolaScadenza();");
                //txtAmmontareRichiesto.AddJSAttribute("onchange", "CalcolaImporto();");
                
                SiarLibrary.DbStaticProvider.CalcolaImportoGarantitoFidejussione(DomandaPagamento.IdDomandaPagamento, out ammontare_garantito, out ammontare_richiesto,
                    PagamentoProvider.DbProviderObj);
                if (boolAggregazione)
                {
                    SiarLibrary.ImpresaCollection imp_coll = aggregazione_prov.GetElencoImpreseAggregazione(Progetto.IdProgetto);
                    dgImprese.DataSource = imp_coll;
                    dgImprese.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgImprese_ItemDataBound);
                    dgImprese.DataBind();


                    txtImportoTotaleGarantito.Text = string.Format("{0:N}", Math.Round(ammontare_richiesto, 2, MidpointRounding.AwayFromZero));
                    txtImportoTotale.Text = string.Format("{0:N}", Math.Round(ammontare_garantito, 2, MidpointRounding.AwayFromZero));
                    if (impresa_selezionata != null)
                    {
                        tbFidejussione.Visible = true;
                        tbEsenzione.Visible = true;
                        tbNoAnticipo.Visible = true;
                        tbCkEsenzione.Visible = true;
                        tbNoAnticipo.Visible = true;
                        tbImprea.Visible = true;
                        txtImpresaSelezionata.Text = impresa_selezionata.RagioneSociale;
                        txtPartitaIvaImpresaSelezionata.Text = impresa_selezionata.Cuaa;
                    }
                    else
                    {
                        tbFidejussione.Visible = false;
                        tbEsenzione.Visible = false;
                        checkEsente.Visible = false;
                        tbCkEsenzione.Visible = false;
                        tbNoAnticipo.Visible = false;
                        checkNoAnticipo.Visible = false;
                        tbCkNoAnticipo.Visible = false;
                    }

                }
                else
                {
                    tbEsenzione.Visible = true;
                    tbCkEsenzione.Visible = true;
                    tbNoAnticipo.Visible = true;
                    tbCkNoAnticipo.Visible = true;
                    tbElencoImprese.Visible = false;
                    tbImprea.Visible = false;
                    txtImporto.ReadOnly = true;
                    txtAmmontareRichiesto.ReadOnly = true;
                }
                    



                if (string.IsNullOrEmpty(codTipoFidejussioneBando))
                    throw new Exception("Nessuna tipologia di polizza fidejussoria è stata specificata dal bando, per proseguire rivolgersi al responsabile di misura del bando.");
                else
                {
                    bool ente_pubblico = ucWorkflowPagamento.Impresa.CodFormaGiuridica.Value.Substring(0, 1) == "2";
                    if (codTipoFidejussioneBando == "F4M") codTipoFidejussioneBando = (ente_pubblico ? "F3G" : "F1F");

                    if (codTipoFidejussioneBando == "F3G") // garanzia ente pubblico
                    {
                        if (!ente_pubblico) throw new Exception("L`impresa non soddisfa i requisiti giuridici per la definizione della polizza richiesta dal bando.");
                        lblNumero.Text = "Numero Delibera:";
                        lblData.Text = "Data Delibera:";
                        lblLuogo.Visible = false;
                        txtLuogo.Visible = false;
                        anagHeader.Visible = false;
                        anagDati.Visible = false;
                    }
                    else // polizza privati
                    {
                        if (ente_pubblico) throw new Exception("L`impresa non soddisfa i requisiti giuridici per la definizione della polizza richiesta dal bando.");
                        lblNumero.Text = "Numero:";
                        lblData.Text = "Data sottoscrizione:";
                        lblLuogo.Visible = true;
                        txtLuogo.Visible = true;
                        anagHeader.Visible = true;
                        anagDati.Visible = true;
                        txtCF.AddJSAttribute("onblur", "return ctrlCF(this,ctrlCodiceFiscale,event);");
                        txtPiva.AddJSAttribute("onblur", "return ctrlCF(this,ctrlPIVA,event);");
                    }


                    BindControlli();
                }
            }
            catch (Exception ex) { ShowError(ex); btnStampa.Enabled = btnSalva.Enabled = false; }
            finally
            {


                if (boolAggregazione)
                {
                    int count_imprese = 0;
                    SiarLibrary.ImpresaCollection imp_coll = aggregazione_prov.GetElencoImpreseAggregazione(Progetto.IdProgetto);
                    count_imprese = imp_coll.Count;
                    int count2_imp = 0;
                    bool esente = false;
                    bool noAnticipo = false;
                    //Se aggragazione controllo che il totale delle fidejussioni sia uguale al totale richiesto della domanda
                    decimal importi_inseriti = 0;
                    SiarLibrary.DomandaPagamentoFidejussioneImpresaCollection col_imp_ = dompag_fidej_imp_prov.Find(null, DomandaPagamento.IdDomandaPagamento, Progetto.IdProgetto, null);
                    foreach (SiarLibrary.DomandaPagamentoFidejussioneImpresa i in col_imp_)
                    {
                        if (i.Esente)
                        {
                            esente = true;
                            count2_imp++;
                        }
                        else if (i.NoAnticipo)
                        {
                            noAnticipo = true;
                            count2_imp++;
                        }
                        else
                        {
                            if (i.Numero != null && i.Numero != "")
                                count2_imp++;
                        }
                            
                        if (i.Numero != null)
                            importi_inseriti += i.AmmontareRichiesto;
                    }
                    if (importi_inseriti < ammontare_richiesto &&  !esente   )
                    {
                        ucWorkflowPagamento.ProseguiMessaggio = "Il totale delle fidejussioni inserite compilate in tutte le loro parti per le imprese non raggiunge il totale della domanda di anticipo.Impossibile continuare.";
                        ucWorkflowPagamento.ProseguiAbilitato = false;
                    }
                    else if(count_imprese> count2_imp)
                    {
                        ucWorkflowPagamento.ProseguiMessaggio = "Non sono stati compilate le fidejussioni e/o l esenzione di tutte le imprese.Impossibile continuare.";
                        ucWorkflowPagamento.ProseguiAbilitato = false;
                    }

                }
                else
                {
                    if ((ammontare_garantito > 0 || (impresa_fidej != null && impresa_fidej.Importo > 0)) && (impresa_fidej == null || impresa_fidej.Numero == null) )
                    {

                        int i;
                        if (impresa_fidej != null && impresa_fidej.Esente)
                           i = 0;
                        else if (impresa_fidej != null && impresa_fidej.NoAnticipo)
                        {
                            ucWorkflowPagamento.ProseguiMessaggio = "Impossibile selezionare il flag per il beneficiario non richiedente anticipo.";
                            ucWorkflowPagamento.ProseguiAbilitato = false;
                        }
                        else
                        {
                            ucWorkflowPagamento.ProseguiMessaggio = "E` obbligatorio immettere i dati della fidejussione per proseguire.";
                            ucWorkflowPagamento.ProseguiAbilitato = false;
                        }


                    }
                }
            }
            base.OnPreRender(e);
        }

        decimal importo_anticipo_tot = 0;
        void dgImprese_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.Impresa impresa = (SiarLibrary.Impresa)e.Item.DataItem;
                SiarLibrary.DomandaPagamentoFidejussioneCollection fidej_coll = dompag_fidej_prov.Find(DomandaPagamento.IdDomandaPagamento, DomandaPagamento.IdProgetto);
                if (fidej_coll.Count > 0)
                {
                    SiarLibrary.DomandaPagamentoFidejussioneImpresaCollection imp_fid_coll = dompag_fidej_imp_prov.Find(fidej_coll[0].IdDomandaPagamentoFidejussione, DomandaPagamento.IdDomandaPagamento, DomandaPagamento.IdProgetto, impresa.IdImpresa);
                    if (imp_fid_coll.Count > 0)
                    {
                        importo_anticipo_tot += imp_fid_coll[0].AmmontareRichiesto;
                        if(imp_fid_coll[0].Esente)
                            e.Item.Cells[3].Text = "ESENTE";
                        else if (imp_fid_coll[0].NoAnticipo)
                            e.Item.Cells[3].Text = "NON RICHIEDENTE ANTICIPO";
                        else
                            e.Item.Cells[3].Text = string.Format("{0:c}", imp_fid_coll[0].AmmontareRichiesto);
                    }
                    else
                        e.Item.Cells[3].Text = "";
                }
                else
                    e.Item.Cells[3].Text = string.Format("{0:c}", 0);



                //SiarLibrary.ContrattiFemCollection contratti_fem = new SiarBLL.ContrattiFemCollectionProvider().Find(p.IdBando, p.IdProgetto);
                //if (contratti_fem.Count > 0)
                //{
                //    if (contratti_fem[0].Segnatura != null)
                //        e.Item.Cells[3].Text = contratti_fem[0].Segnatura;
                //}
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[3].Text = string.Format("{0:c}", importo_anticipo_tot);
            }
        }

        protected void btnSelezionaImpresa_Click(object sender, EventArgs e)
        { }

        private void BindControlli()
        {
            if (!boolAggregazione)
                checkNoAnticipo.Enabled = false;

            if(impresa_fidej == null)
            {
                checkEsente.Checked = false;
                checkNoAnticipo.Checked = false;
                if(boolAggregazione)
                {
                    txtAmmontareRichiesto.Text = "";
                    txtImporto.Text = "";
                }
                else
                {
                    txtAmmontareRichiesto.Text = string.Format("{0:N}", Math.Round(ammontare_garantito, 2, MidpointRounding.AwayFromZero));
                    txtImporto.Text = string.Format("{0:N}", Math.Round(ammontare_richiesto, 2, MidpointRounding.AwayFromZero));
                }

                btnSalva.Enabled = false;
                btnStampa.Enabled = false;
                txtDataScadenza.Text = "";
                txtDataFineLavori.Text = "";
                txtNumero.Text = "";
                txtDataSottoscrizione.Text = "";
                txtLuogo.Text = "";
                txtPiva.Text = "";
                txtDenominazione.Text = "";
                txtNumeroRegistro.Text = "";
                txtLocalita.Text = "";
                txtNome.Text = "";
                txtCognome.Text = "";
                txtDataNascita.Text = "";
                txtCF.Text = "";
            }
            else
            {
                if(impresa_fidej.Esente)
                {
                    checkEsente.Checked = true;
                    checkNoAnticipo.Checked = false;
                    if (boolAggregazione)
                    {
                        txtAmmontareRichiesto.Text = "";
                        txtImporto.Text = "";
                    }
                    else
                    {
                        txtAmmontareRichiesto.Text = string.Format("{0:N}", Math.Round(ammontare_garantito, 2, MidpointRounding.AwayFromZero));
                        txtImporto.Text = string.Format("{0:N}", Math.Round(ammontare_richiesto, 2, MidpointRounding.AwayFromZero));
                    }
                    btnSalva1.Enabled = true;
                    btnSalva.Enabled = false;
                    btnStampa.Enabled = true;
                    txtDataScadenza.Text = "";
                    txtDataFineLavori.Text = "";
                    txtNumero.Text = "";
                    txtDataSottoscrizione.Text = "";
                    txtLuogo.Text = "";
                    txtPiva.Text = "";
                    txtDenominazione.Text = "";
                    txtNumeroRegistro.Text = "";
                    txtLocalita.Text = "";
                    txtNome.Text = "";
                    txtCognome.Text = "";
                    txtDataNascita.Text = "";
                    txtCF.Text = "";
                }
                else if (impresa_fidej.NoAnticipo)
                {
                    checkEsente.Checked = false;
                    checkNoAnticipo.Checked = true;
                    if (boolAggregazione)
                    {
                        txtAmmontareRichiesto.Text = "";
                        txtImporto.Text = "";
                    }
                    else
                    {
                        txtAmmontareRichiesto.Text = string.Format("{0:N}", Math.Round(ammontare_garantito, 2, MidpointRounding.AwayFromZero));
                        txtImporto.Text = string.Format("{0:N}", Math.Round(ammontare_richiesto, 2, MidpointRounding.AwayFromZero));
                    }
                    btnSalva1.Enabled = true;
                    btnSalva.Enabled = false;
                    btnStampa.Enabled = true;
                    txtDataScadenza.Text = "";
                    txtDataFineLavori.Text = "";
                    txtNumero.Text = "";
                    txtDataSottoscrizione.Text = "";
                    txtLuogo.Text = "";
                    txtPiva.Text = "";
                    txtDenominazione.Text = "";
                    txtNumeroRegistro.Text = "";
                    txtLocalita.Text = "";
                    txtNome.Text = "";
                    txtCognome.Text = "";
                    txtDataNascita.Text = "";
                    txtCF.Text = "";
                }
                else
                {
                    checkEsente.Checked = false;
                    checkNoAnticipo.Checked = false;
                    txtAmmontareRichiesto.Text = impresa_fidej.AmmontareRichiesto;
                    txtImporto.Text = impresa_fidej.Importo;
                    txtDataScadenza.Text = impresa_fidej.DataScadenza;
                    txtDataFineLavori.Text = impresa_fidej.DataFineLavori;
                    if (impresa_fidej.Stampato)
                    {
                        txtAmmontareRichiesto.ReadOnly = true;
                        txtDataFineLavori.ReadOnly = true;
                        btnSalva1.Enabled = false;
                        btnStampa.Enabled = true;
                    }
                    else
                    {
                        btnSalva1.Enabled = true;
                        btnSalva.Enabled = false;
                        btnStampa.Enabled = true;
                    }
                    txtNumero.Text = impresa_fidej.Numero;
                    txtDataSottoscrizione.Text = impresa_fidej.DataSottoscrizione;
                    txtLuogo.Text = impresa_fidej.LuogoSottoscrizione;
                    txtPiva.Text = impresa_fidej.PivaGarante;
                    txtDenominazione.Text = impresa_fidej.RagioneSocialeGarante;
                    txtNumeroRegistro.Text = impresa_fidej.NumeroRegistroImprese;
                    txtLocalita.Text = impresa_fidej.LocalitaGarante;
                    txtNome.Text = impresa_fidej.NomeRapplegale;
                    txtCognome.Text = impresa_fidej.CognomeRapplegale;
                    txtDataNascita.Text = impresa_fidej.DataNascitaRapplegale;
                    txtCF.Text = impresa_fidej.CfRapplegale;
                }
                if (DomandaPagamento.Segnatura != null && DomandaPagamento.Segnatura != "")
                {
                    checkEsente.Enabled = false;
                    checkNoAnticipo.Enabled = false;
                }
                    
            }

            //if (fidejussione == null)
            //{
            //    SiarLibrary.DbStaticProvider.CalcolaImportoGarantitoFidejussione(DomandaPagamento.IdDomandaPagamento, out ammontare_garantito, out ammontare_richiesto,
            //    PagamentoProvider.DbProviderObj);
            //    txtAmmontareRichiesto.Text = string.Format("{0:N}", Math.Round(ammontare_richiesto, 2, MidpointRounding.AwayFromZero));
            //    txtImporto.Text = string.Format("{0:N}", Math.Round(ammontare_garantito, 2, MidpointRounding.AwayFromZero));
            //    btnSalva.Enabled = false;
            //    btnStampa.Enabled = (ammontare_garantito > 0);
            //}
            //else
            //{
            //    txtImporto.Text = fidejussione.Importo;
            //    txtAmmontareRichiesto.Text = fidejussione.AmmontareRichiesto;
            //    txtDataFineLavori.ReadOnly = true;
            //    chkProroga.Enabled = false;
            //    btnStampa.OnClientClick = null;
            //    txtNumero.Text = fidejussione.Numero;
            //    //txtCodiceBarre.Text = fidejussione.Barcode;
            //    txtDataFineLavori.Text = fidejussione.DataFineLavori;
            //    txtDataScadenza.Text = fidejussione.DataScadenza;
            //    chkProroga.Checked = fidejussione.ProrogaScadenza;
            //    txtDataSottoscrizione.Text = fidejussione.DataSottoscrizione;

            //    if (codTipoFidejussioneBando != "F3G")
            //    {
            //        txtLuogo.Text = fidejussione.LuogoSottoscrizione;
            //        txtDenominazione.Text = fidejussione.RagioneSocialeGarante;
            //        txtPiva.Text = fidejussione.PivaGarante;
            //        txtLocalita.Text = fidejussione.LocalitaGarante;
            //        txtNumeroRegistro.Text = fidejussione.NumeroRegistroImprese;
            //        txtCognome.Text = fidejussione.CognomeRapplegale;
            //        txtNome.Text = fidejussione.NomeRapplegale;
            //        txtDataNascita.Text = fidejussione.DataNascitaRapplegale;
            //        txtCF.Text = fidejussione.CfRapplegale;
            //    }
            //}
        }

        protected void btnSalva1_Click(object sender, EventArgs e)
        {
            try
            {
                PagamentoProvider.DbProviderObj.BeginTran();

                if (boolAggregazione)
                {
                    //se aggregazione controllo che l'ammontare richiesto sia compreso nel range profilato nella domanda di pagamento
                    decimal importorAmmontareRichiesto = Convert.ToDecimal(txtAmmontareRichiesto.Text);
                    SiarLibrary.BandoTipoPagamento btpc = new SiarBLL.BandoTipoPagamentoCollectionProvider().GetById(Progetto.IdBando, DomandaPagamento.CodTipo);
                    decimal min = 0, max, contributoAzienda = 0;
                    if (btpc.QuotaMax == null)
                        max = 100;
                    else
                        max = btpc.QuotaMax;
                    if (btpc.QuotaMin != null)
                        min = btpc.QuotaMin;

                    //Calcolo l'ammontare totale del contributo richiesto dall'azienda
                    SiarLibrary.PianoInvestimentiCollection investimenti = investimenti_provider.GetPianoInvestimentiDomandaPagamento(Progetto.IdProgetto, DomandaPagamento.IdDomandaPagamento);
                    // pagamenti richiesti nella presente domanda di pagamento (non compresi nella query del piano investimento)
                    SiarLibrary.PianoInvestimentiCollection inv_supp = null;
                    //investimenti ordinari
                    inv_supp = investimenti.FiltroTipoInvestimento(1);
                    foreach (SiarLibrary.PianoInvestimenti pi in inv_supp)
                    {
                        string[] Aggregazione = new string[2];
                        Aggregazione = investimenti_provider.GetImpresaAggregazioneInvestimento(pi.IdInvestimento);
                        if (Aggregazione[0] != null && Aggregazione[1] != null && Aggregazione[0] != "" && Aggregazione[1] != "")
                        {
                            SiarLibrary.Impresa impresa = new SiarBLL.ImpresaCollectionProvider().GetByCuaa(Aggregazione[0]);
                            if (impresa_selezionata.IdImpresa == impresa.IdImpresa)
                                contributoAzienda += pi.ContributoRichiesto;
                        }
                    }
                    if (importorAmmontareRichiesto < (Math.Round(contributoAzienda * min / 100, 2, MidpointRounding.AwayFromZero)) || importorAmmontareRichiesto > (Math.Round(contributoAzienda * max / 100, 2, MidpointRounding.AwayFromZero)))
                        throw new Exception("Contributo richiesto per l'impresa selezionata non è racchiuso nel range dell'anticipo del bando. Impossibile continuare.");

                    //Controllo che la somma delle fidejuzzioni non sia maggiore del totale
                    decimal importi_inseriti=0,importo_totale;
                    importo_totale = Convert.ToDecimal( txtImportoTotaleGarantito.Text);
                    SiarLibrary.DomandaPagamentoFidejussioneImpresaCollection col_imp_ = dompag_fidej_imp_prov.Find(null, DomandaPagamento.IdDomandaPagamento, Progetto.IdProgetto, null);
                    foreach (SiarLibrary.DomandaPagamentoFidejussioneImpresa i in col_imp_)
                    {
                        if(i.IdImpresa != impresa_selezionata.IdImpresa)
                            importi_inseriti += i.AmmontareRichiesto;
                    }
                    if( (importi_inseriti + importorAmmontareRichiesto)> importo_totale )
                        throw new Exception("L'importo totale delle fidejussioni inserite supera l'ammontare richiesto della domanda di anticipo. Impossibile continuare.");
                }

                if(impresa_fidej == null)
                {
                    if(testa_fidej == null)
                    {
                        testa_fidej = new SiarLibrary.DomandaPagamentoFidejussione();
                        testa_fidej.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                        testa_fidej.IdProgetto = Progetto.IdProgetto;
                        testa_fidej.DataCreazione = DateTime.Today;
                        testa_fidej.OperatoreCreazione = Operatore.Utente.IdUtente;
                    }
                    testa_fidej.DataModifica = DateTime.Today;
                    dompag_fidej_prov.Save(testa_fidej);

                    if(DomandaPagamento.IdFidejussione == null)
                    {
                        DomandaPagamento.IdFidejussione = testa_fidej.IdDomandaPagamentoFidejussione;
                        SiarBLL.DomandaDiPagamentoCollectionProvider dom_prov = new SiarBLL.DomandaDiPagamentoCollectionProvider();
                        dom_prov.Save(DomandaPagamento);
                    }

                    impresa_fidej = new SiarLibrary.DomandaPagamentoFidejussioneImpresa();
                    impresa_fidej.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                    impresa_fidej.IdDomandaPagamentoFidejussione = testa_fidej.IdDomandaPagamentoFidejussione;
                    impresa_fidej.IdProgetto = Progetto.IdProgetto;
                    impresa_fidej.IdImpresa = impresa_selezionata.IdImpresa;
                }
                impresa_fidej.AmmontareRichiesto = txtAmmontareRichiesto.Text;
                impresa_fidej.Importo = Convert.ToDecimal(txtAmmontareRichiesto.Text) * Convert.ToDecimal(hdnQuotaFidej.Value)/100 ;
                impresa_fidej.DataFineLavori = txtDataFineLavori.Text;
                impresa_fidej.DataScadenza = Convert.ToDateTime(txtDataFineLavori.Text).AddMonths(Convert.ToInt32(hdnMesiFidej.Value));
                impresa_fidej.Esente = false;
                impresa_fidej.NoAnticipo = false;
                dompag_fidej_imp_prov.Save(impresa_fidej);


                PagamentoProvider.AggiornaDomandaDiPagamento(DomandaPagamento, Operatore);
                PagamentoProvider.DbProviderObj.Commit();
                ShowMessage("Polizza fidejussoria per l'impresa registrata correttamente.Procedere con la stampa del documento.");
            }
            catch (Exception ex) { PagamentoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnStampa_Click(object sender, EventArgs e)
        {
            try
            {
                //Rifaccio i controlli
                if (boolAggregazione)
                {
                    //se aggregazione controllo che l'ammontare richiesto sia compreso nel range profilato nella domanda di pagamento
                    decimal importorAmmontareRichiesto = Convert.ToDecimal(txtAmmontareRichiesto.Text);
                    SiarLibrary.BandoTipoPagamento btpc = new SiarBLL.BandoTipoPagamentoCollectionProvider().GetById(Progetto.IdBando, DomandaPagamento.CodTipo);
                    decimal min = 0, max, contributoAzienda = 0;
                    if (btpc.QuotaMax == null)
                        max = 100;
                    else
                        max = btpc.QuotaMax;
                    if (btpc.QuotaMin != null)
                        min = btpc.QuotaMin;

                    //Calcolo l'ammontare totale del contributo richiesto dall'azienda
                    SiarLibrary.PianoInvestimentiCollection investimenti = investimenti_provider.GetPianoInvestimentiDomandaPagamento(Progetto.IdProgetto, DomandaPagamento.IdDomandaPagamento);
                    // pagamenti richiesti nella presente domanda di pagamento (non compresi nella query del piano investimento)
                    SiarLibrary.PianoInvestimentiCollection inv_supp = null;
                    //investimenti ordinari
                    inv_supp = investimenti.FiltroTipoInvestimento(1);
                    foreach (SiarLibrary.PianoInvestimenti pi in inv_supp)
                    {
                        string[] Aggregazione = new string[2];
                        Aggregazione = investimenti_provider.GetImpresaAggregazioneInvestimento(pi.IdInvestimento);
                        if (Aggregazione[0] != null && Aggregazione[1] != null && Aggregazione[0] != "" && Aggregazione[1] != "")
                        {
                            SiarLibrary.Impresa impresa = new SiarBLL.ImpresaCollectionProvider().GetByCuaa(Aggregazione[0]);
                            if (impresa_selezionata.IdImpresa == impresa.IdImpresa)
                                contributoAzienda += pi.ContributoRichiesto;
                        }
                    }
                    if (importorAmmontareRichiesto < (Math.Round(contributoAzienda * min / 100, 2, MidpointRounding.AwayFromZero)) || importorAmmontareRichiesto > (Math.Round(contributoAzienda * max / 100, 2, MidpointRounding.AwayFromZero)))
                        throw new Exception("Contributo richiesto per l'impresa selezionata non è racchiuso nel range dell'anticipo del bando. Impossibile continuare.");

                    //Controllo che la somma delle fidejuzzioni non sia maggiore del totale
                    decimal importi_inseriti = 0, importo_totale;
                    importo_totale = Convert.ToDecimal(txtImportoTotaleGarantito.Text);
                    SiarLibrary.DomandaPagamentoFidejussioneImpresaCollection col_imp_ = dompag_fidej_imp_prov.Find(null, DomandaPagamento.IdDomandaPagamento, Progetto.IdProgetto, null);
                    foreach (SiarLibrary.DomandaPagamentoFidejussioneImpresa i in col_imp_)
                    {
                        if (i.IdImpresa != impresa_selezionata.IdImpresa)
                            importi_inseriti += i.AmmontareRichiesto;
                    }
                    if ((importi_inseriti + importorAmmontareRichiesto) > importo_totale)
                        throw new Exception("L'importo totale delle fidejussioni inserite supera l'ammontare richiesto della domanda di anticipo. Impossibile continuare.");
                }



                PagamentoProvider.DbProviderObj.BeginTran();
                impresa_fidej.AmmontareRichiesto = txtAmmontareRichiesto.Text;
                impresa_fidej.Importo = Convert.ToDecimal(txtAmmontareRichiesto.Text) * Convert.ToDecimal(hdnQuotaFidej.Value) / 100;
                impresa_fidej.DataFineLavori = txtDataFineLavori.Text;
                impresa_fidej.DataScadenza = Convert.ToDateTime(txtDataFineLavori.Text).AddMonths(Convert.ToInt32(hdnMesiFidej.Value));
                impresa_fidej.Stampato = true;
                impresa_fidej.Esente = false;
                impresa_fidej.NoAnticipo = false;
                dompag_fidej_imp_prov.Save(impresa_fidej);

                PagamentoProvider.AggiornaDomandaDiPagamento(DomandaPagamento, Operatore);
                PagamentoProvider.DbProviderObj.Commit();
                
                RegisterClientScriptBlock("SNCVisualizzaReport('rptPolizzaImpresa',1,'IdDomandaPagamento=" + DomandaPagamento.IdDomandaPagamento + "|Stato=" + DomandaPagamento.CodTipo + "|IdImpresa=" + impresa_fidej.IdImpresa + "');");
            }
            catch (Exception ex) { PagamentoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                PagamentoProvider.DbProviderObj.BeginTran();
                
                if (impresa_fidej == null) throw new Exception("Fidejussone selezionata non valida. Impossibile continuare.");

                impresa_fidej.Numero = txtNumero.Text;
                impresa_fidej.DataSottoscrizione = txtDataSottoscrizione.Text;
                impresa_fidej.LuogoSottoscrizione = txtLuogo.Text;
                impresa_fidej.PivaGarante = txtPiva.Text;
                impresa_fidej.RagioneSocialeGarante = txtDenominazione.Text;
                impresa_fidej.LocalitaGarante = txtLocalita.Text;
                impresa_fidej.NumeroRegistroImprese = txtNumeroRegistro.Text;
                impresa_fidej.CognomeRapplegale = txtCognome.Text;
                impresa_fidej.NomeRapplegale = txtNome.Text;
                impresa_fidej.DataNascitaRapplegale = txtDataNascita.Text;
                impresa_fidej.CfRapplegale = txtCF.Text;
                impresa_fidej.Esente = false;
                impresa_fidej.NoAnticipo = false;
                dompag_fidej_imp_prov.Save(impresa_fidej);

                PagamentoProvider.AggiornaDomandaDiPagamento(DomandaPagamento, Operatore);
                PagamentoProvider.DbProviderObj.Commit();
                ShowMessage("Polizza fidejussoria registrata correttamente.");
            }
            catch (Exception ex) { PagamentoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        
        protected void btnSalvaEsenzione_Click(object sender, EventArgs e)
        {
            try
            {
                PagamentoProvider.DbProviderObj.BeginTran();

                if (impresa_fidej == null)
                {
                    if (testa_fidej == null)
                    {
                        testa_fidej = new SiarLibrary.DomandaPagamentoFidejussione();
                        testa_fidej.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                        testa_fidej.IdProgetto = Progetto.IdProgetto;
                        testa_fidej.DataCreazione = DateTime.Today;
                        testa_fidej.OperatoreCreazione = Operatore.Utente.IdUtente;
                    }
                    testa_fidej.DataModifica = DateTime.Today;
                    dompag_fidej_prov.Save(testa_fidej);

                    if (DomandaPagamento.IdFidejussione == null)
                    {
                        DomandaPagamento.IdFidejussione = testa_fidej.IdDomandaPagamentoFidejussione;
                        SiarBLL.DomandaDiPagamentoCollectionProvider dom_prov = new SiarBLL.DomandaDiPagamentoCollectionProvider();
                        dom_prov.Save(DomandaPagamento);
                    }

                    impresa_fidej = new SiarLibrary.DomandaPagamentoFidejussioneImpresa();
                    impresa_fidej.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                    impresa_fidej.IdDomandaPagamentoFidejussione = testa_fidej.IdDomandaPagamentoFidejussione;
                    impresa_fidej.IdProgetto = Progetto.IdProgetto;
                    impresa_fidej.IdImpresa = impresa_selezionata.IdImpresa;
                }

                impresa_fidej.Esente = true;
                impresa_fidej.NoAnticipo = false;

                impresa_fidej.AmmontareRichiesto = 0;
                impresa_fidej.Importo = 0;
                impresa_fidej.DataFineLavori = null;
                impresa_fidej.DataScadenza = null;
                impresa_fidej.Numero = null;
                impresa_fidej.DataSottoscrizione = null;
                impresa_fidej.LuogoSottoscrizione = null;
                impresa_fidej.PivaGarante = null;
                impresa_fidej.RagioneSocialeGarante = null;
                impresa_fidej.LocalitaGarante = null;
                impresa_fidej.NumeroRegistroImprese = null;
                impresa_fidej.CognomeRapplegale = null;
                impresa_fidej.NomeRapplegale = null;
                impresa_fidej.DataNascitaRapplegale = null;
                impresa_fidej.CfRapplegale = null;
                dompag_fidej_imp_prov.Save(impresa_fidej);

                PagamentoProvider.AggiornaDomandaDiPagamento(DomandaPagamento, Operatore);
                PagamentoProvider.DbProviderObj.Commit();
                ShowMessage("Esenzione Polizza fidejussoria registrata correttamente.");
            }
            catch (Exception ex) { PagamentoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnSalvaNoAnticipo_Click(object sender, EventArgs e)
        {
            try
            {
                PagamentoProvider.DbProviderObj.BeginTran();

                if (impresa_fidej == null)
                {
                    if (testa_fidej == null)
                    {
                        testa_fidej = new SiarLibrary.DomandaPagamentoFidejussione();
                        testa_fidej.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                        testa_fidej.IdProgetto = Progetto.IdProgetto;
                        testa_fidej.DataCreazione = DateTime.Today;
                        testa_fidej.OperatoreCreazione = Operatore.Utente.IdUtente;
                    }
                    testa_fidej.DataModifica = DateTime.Today;
                    dompag_fidej_prov.Save(testa_fidej);

                    if (DomandaPagamento.IdFidejussione == null)
                    {
                        DomandaPagamento.IdFidejussione = testa_fidej.IdDomandaPagamentoFidejussione;
                        SiarBLL.DomandaDiPagamentoCollectionProvider dom_prov = new SiarBLL.DomandaDiPagamentoCollectionProvider();
                        dom_prov.Save(DomandaPagamento);
                    }

                    impresa_fidej = new SiarLibrary.DomandaPagamentoFidejussioneImpresa();
                    impresa_fidej.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                    impresa_fidej.IdDomandaPagamentoFidejussione = testa_fidej.IdDomandaPagamentoFidejussione;
                    impresa_fidej.IdProgetto = Progetto.IdProgetto;
                    impresa_fidej.IdImpresa = impresa_selezionata.IdImpresa;
                }

                impresa_fidej.Esente = false;
                impresa_fidej.NoAnticipo = true;

                impresa_fidej.AmmontareRichiesto = 0;
                impresa_fidej.Importo = 0;
                impresa_fidej.DataFineLavori = null;
                impresa_fidej.DataScadenza = null;
                impresa_fidej.Numero = null;
                impresa_fidej.DataSottoscrizione = null;
                impresa_fidej.LuogoSottoscrizione = null;
                impresa_fidej.PivaGarante = null;
                impresa_fidej.RagioneSocialeGarante = null;
                impresa_fidej.LocalitaGarante = null;
                impresa_fidej.NumeroRegistroImprese = null;
                impresa_fidej.CognomeRapplegale = null;
                impresa_fidej.NomeRapplegale = null;
                impresa_fidej.DataNascitaRapplegale = null;
                impresa_fidej.CfRapplegale = null;
                dompag_fidej_imp_prov.Save(impresa_fidej);

                PagamentoProvider.AggiornaDomandaDiPagamento(DomandaPagamento, Operatore);
                PagamentoProvider.DbProviderObj.Commit();
                ShowMessage("Beneficiario non richiedente anticipo registrato correttamente.");
            }
            catch (Exception ex) { PagamentoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }
    }
}