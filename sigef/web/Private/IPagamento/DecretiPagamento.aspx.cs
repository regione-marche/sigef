using System;
using System.Web.UI.WebControls;

namespace web.Private.IPagamento
{
    public partial class DecretiPagamento : SiarLibrary.Web.IstruttoriaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "selezione_domande_rendicontazione";
            base.OnPreInit(e);
        }
        SiarBLL.AttiCollectionProvider atti_provider = new SiarBLL.AttiCollectionProvider();
        SiarLibrary.Atti decreto_selezionato = null;
        SiarBLL.DomandaDiPagamentoCollectionProvider pagamento_provider = new SiarBLL.DomandaDiPagamentoCollectionProvider();
        SiarLibrary.DomandaDiPagamento domanda_selezionata = null;
        //SiarLibrary.DecretiXDomPagEsportazione decreto_selezionato = null;
        SiarBLL.DomandaPagamentoLiquidazioneCollectionProvider liquidazione_provider = new SiarBLL.DomandaPagamentoLiquidazioneCollectionProvider();
        SiarLibrary.DomandaPagamentoLiquidazione liquidazione_domanda = null;
        SiarLibrary.DomandaPagamentoLiquidazioneCollection Elenco_liquidazione_domanda = null;
        Boolean Organismi_intermedi = false;

        decimal importo_mandato_richiesto = 0, importo_mandato = 0, importo_quietanza = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnIdBando.Value = Bando.IdBando;
            AbilitaModifica = AbilitaModifica && 
                (new SiarBLL.BandoResponsabiliCollectionProvider().Find(Bando.IdBando, Operatore.Utente.IdUtente, null, true, true).Count > 0
                || Operatore.Utente.Profilo =="Consulente RUP"   );
            int id_domanda_pagamento;
            if (int.TryParse(hdnIDomandaPagamento.Value, out id_domanda_pagamento))
            {
                SiarLibrary.DomandaDiPagamentoCollection dd = pagamento_provider.GetDomandePagamentoPerDecreti(Bando.IdBando,null, id_domanda_pagamento,
                    chkNascondiDecreti.Checked, chkNascondiLiquidati.Checked,false, false);
                if (dd.Count > 0)
                {
                    domanda_selezionata = dd[0];
                    //Elenco_liquidazione_domanda = liquidazione_provider.Find(domanda_selezionata.IdDomandaPagamento,
                    //    domanda_selezionata.IdProgetto, null, null);
                    //if (ll.Count > 0)
                    //{
                    //    liquidazione_domanda = ll[0];
                    //    if (liquidazione_domanda.Liquidato) AbilitaModifica = false;
                    //}
                }
            }
            string Str_Organismi_intermedi = "";
            Str_Organismi_intermedi = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_OrganismiIntermedi(Bando.IdBando);
            if (Str_Organismi_intermedi == "True")
                Organismi_intermedi = true;

            if (!AbilitaModifica)
                chkCompensazione.Enabled = false;
        }

        protected override void OnPreRender(EventArgs e)
        {
            SiarLibrary.DomandaDiPagamentoCollection dd = new SiarLibrary.DomandaDiPagamentoCollection();
            if (domanda_selezionata == null)
            {
                int? id_progetto_ins = null;
                if (txtIdProgettoF.Text != "" && txtIdProgettoF.Text != null)
                    id_progetto_ins = Convert.ToInt32(txtIdProgettoF.Text);
                dd = pagamento_provider.GetDomandePagamentoPerDecreti(Bando.IdBando, id_progetto_ins, null, chkNascondiDecreti.Checked, chkNascondiLiquidati.Checked,false,false);
                pulisciCampiDecreto();
            }
            else
            {
                dd.Add(domanda_selezionata);

                var decCollProv = new SiarBLL.DecretiXDomPagEsportazioneCollectionProvider();
                SiarLibrary.NullTypes.DecimalNT cm = new SiarLibrary.NullTypes.DecimalNT(domanda_selezionata.AdditionalAttributes["CONTRIBUTO_AMMESSO"]);
                var decxdomcheck = decCollProv.Find(domanda_selezionata.IdDomandaPagamento, domanda_selezionata.IdProgetto, null);
                decimal totaleImportiDecretiDomanda = calcolaTotaleImportiDecretiDomanda(decxdomcheck);
                if (cm <= totaleImportiDecretiDomanda)
                {
                    if(!Organismi_intermedi)
                    {
                        btnAssociaDecreto.ToolTip = "Non è possibile associare un nuovo decreto in quanto è stato raggiunto il contributo ammesso della domanda.";
                        btnAssociaDecreto.Enabled = false;
                    }
                    else
                    {
                        btnAssociaDecretoOrg.ToolTip = "Non è possibile associare un nuovo decreto in quanto è stato raggiunto il contributo ammesso della domanda.";
                        btnAssociaDecretoOrg.Enabled = false;
                    }

                }

                trDettaglioDomanda.Visible = true;
                dgMisura.DataSource = new SiarBLL.DomandaDiPagamentoCollectionProvider().GetRiepilogoSpesaXMisura(domanda_selezionata.IdDomandaPagamento);
                dgMisura.DataBind();

                if(!Organismi_intermedi)
                {
                    trDecreti.Visible = true;
                    trDecretiRicerca.Visible = true;
                    trDecretiOrg.Visible = false;
                    lstAttoDefinizione.DataBind();
                    lstAttoRegistro.DataBind();
                    lstAttoOrgIstituzionale.DataBind();
                    lstAttoTipo.DataBind();
                }
                else
                {
                    trDecreti.Visible = false;
                    trDecretiRicerca.Visible = false;
                    trDecretiOrg.Visible = true;
                }

                

                //Decreti
                var decxdom = new SiarBLL.DecretiXDomPagEsportazioneCollectionProvider().Find(domanda_selezionata.IdDomandaPagamento, domanda_selezionata.IdProgetto, null);
                int id_decreto_sel;
                // atto gia' associato
                SiarLibrary.DecretiXDomPagEsportazione dxdpe = null;
                if (int.TryParse(hdnIdDecretiXDomPagEsportazione.Value, out id_decreto_sel))
                {
                    dxdpe = decxdom.CollectionGetById(id_decreto_sel);
                    decreto_selezionato = atti_provider.GetById(dxdpe.IdAtto);
                    decxdom = decxdom.SubSelect(id_decreto_sel, null, null, null, null, null, null, null);
                }
                dgDecreti.DataSource = decxdom;
                dgDecreti.SetTitoloNrElementi();
                dgDecreti.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgDecreti_ItemDataBound);
                dgDecreti.DataBind();

                bool decreto_associato = decxdom.Count > 0;//false;
                int id_decreto, id_mandato;
                //// atto gia' associato
                //if (decreto_selezionato == null && int.TryParse(domanda_selezionata.AdditionalAttributes["ID_ATTO_PAGAMENTO"], out id_decreto))
                //{
                //    decreto_selezionato = atti_provider.GetById(id_decreto);
                //    if (decreto_selezionato != null) decreto_associato = true;
                //}
                // evento ricerca
                if (decreto_selezionato == null && int.TryParse(hdnIdAtto.Value, out id_decreto))
                    decreto_selezionato = atti_provider.GetById(id_decreto);
                // bind dei campi
                if (decreto_selezionato != null)
                {
                    hdnIdAtto.Value = decreto_selezionato.IdAtto;

                    if(!Organismi_intermedi)
                    {
                        txtAttoData.Text = decreto_selezionato.Data;
                        txtAttoNumero.Text = decreto_selezionato.Numero;
                        txtAttoDescrizione.Text = decreto_selezionato.Descrizione;
                        lstAttoOrgIstituzionale.SelectedValue = decreto_selezionato.CodOrganoIstituzionale;

                        if (dxdpe != null && dxdpe.RecuperoCompensazione != null && dxdpe.RecuperoCompensazione)
                        {
                            txtAttoImporto.Text = null;
                            txtAttoImporto.Enabled = false;
                            chkCompensazione.Checked = true;
                        }
                        else
                        {
                            if (dxdpe != null)
                                txtAttoImporto.Text = dxdpe.Importo;
                            txtAttoImporto.Enabled = true;
                            chkCompensazione.Checked = false;
                        }
                            

                        foreach (ListItem l in lstAttoRegistro.Items) if (l.Value.StartsWith(decreto_selezionato.Registro)) { l.Selected = true; break; }

                        if (!string.IsNullOrEmpty(decreto_selezionato.CodTipo))
                        {
                            lstAttoTipo.SelectedValue = decreto_selezionato.CodTipo;
                            lstAttoTipo.Enabled = false;
                        }
                        txtAttoBurNumero.Text = decreto_selezionato.NumeroBur;
                        txtAttoBurData.Text = decreto_selezionato.DataBur;
                        btnVidualizzaDecreto.Disabled = false;
                        btnVidualizzaDecreto.Attributes.Add("onclick", "visualizzaAtto(" + decreto_selezionato.IdAtto + ");");
                    }
                    else
                    {
                        txtNumeroDecretoOrg.Text = decreto_selezionato.Numero;
                        txtDataDecretoOrg.Text = decreto_selezionato.Data;
                        txtDescrizioneDecretoOrg.Text = decreto_selezionato.Descrizione;
                        txtLinkEst.Text = decreto_selezionato.LinkEsterno;
                        if (dxdpe != null) txtAttoImportoOrg.Text = dxdpe.Importo;
                        txtAttoImportoOrg.ReadOnly = true;
                        txtNumeroDecretoOrg.ReadOnly = true;
                        txtDataDecretoOrg.ReadOnly = true;
                        txtDescrizioneDecretoOrg.ReadOnly = true;
                        txtLinkEst.ReadOnly = true;
                        //btnVidualizzaDecretoOrg.Disabled = false;
                        //btnVidualizzaDecretoOrg.Attributes.Add("href", decreto_selezionato.LinkEsterno );
                        //btnVidualizzaDecretoOrg.Attributes.Add("target", "_blank");
                        btnAssociaDecretoOrg.Enabled = false;
                    }
                }
                else pulisciCampiDecreto();

                if (decreto_selezionato != null) //(decreto_associato)
                {
                    // btnAssociaDecreto.Enabled = btnCercaDecreto.Enabled = false;

                    id_decreto = decreto_selezionato.IdAtto; // Convert.ToInt32(hdnIdAtto.Value);
                    Elenco_liquidazione_domanda = liquidazione_provider.FindByDecreto(domanda_selezionata.IdDomandaPagamento,
                        domanda_selezionata.IdProgetto, null, null, id_decreto);
                    if (Elenco_liquidazione_domanda.Count == 0 && AbilitaModifica)
                    {
                        btnEliminaDecreto.Enabled = true;
                        btnEliminaDecretoOrg.Enabled = true;
                    }
                    else
                    {
                        btnEliminaDecreto.ToolTip = "Impossibile eliminare il decreto perchè ha mandati collegati ad esso";
                        btnEliminaDecretoOrg.ToolTip = "Impossibile eliminare il decreto perchè ha mandati collegati ad esso";
                    }
                        

                    foreach(SiarLibrary.DomandaPagamentoLiquidazione l in Elenco_liquidazione_domanda)
                    {
                        if (l.MandatoImporto != null)
                            importo_mandato += l.MandatoImporto;
                        if (l.QuietanzaImporto != null)
                            importo_quietanza += l.QuietanzaImporto;

                    }
                    dgDomandeLiquidazioni.DataSource = Elenco_liquidazione_domanda;
                    dgDomandeLiquidazioni.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgDomandeLiquidazioni_ItemDataBound);
                    dgDomandeLiquidazioni.DataBind();

                    lstBeneficiarioMandato.DataBinding += new EventHandler(lstBeneficiarioMandato_DataBinding);
                    lstBeneficiarioMandato.DataBind();

                    btnNuovoMandato.Visible = true;
                    if (dxdpe != null && dxdpe.Importo != null && dxdpe.Importo <= importo_mandato)
                    {
                        btnNuovoMandato.ToolTip = "Non è possibile aggiungere un nuovo mandato in quanto è stato raggiunto il l'importo del decreto.";
                        btnNuovoMandato.Enabled = false;
                    }

                    if (dxdpe != null && dxdpe.RecuperoCompensazione != null && dxdpe.RecuperoCompensazione)
                    {
                        btnNuovoMandato.ToolTip = "Non è possibile associare un mandato in quanto il decreto è a compensazione.";
                        btnNuovoMandato.Enabled = false;
                    }

                    if (int.TryParse(hdnIdMandato.Value, out id_mandato))
                    {
                        liquidazione_domanda = liquidazione_provider.GetById(id_mandato);
                        trMandato.Visible = true;
                        txtRichiestaData.Text = liquidazione_domanda.RichiestaMandatoData;
                        txtRichiestaImporto.Text = liquidazione_domanda.RichiestaMandatoImporto;
                        txtRichiestaSegnatura.Text = liquidazione_domanda.RichiestaMandatoSegnatura;
                        imgRichiestaSegnatura.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + liquidazione_domanda.RichiestaMandatoSegnatura + "');");
                        imgRichiestaSegnatura.Style.Add("cursor", "pointer");

                        ufMandato.IdFile = liquidazione_domanda.MandatoIdFile;
                        txtMandatoNumero.Text = liquidazione_domanda.MandatoNumero;
                        txtMandatoData.Text = liquidazione_domanda.MandatoData;
                        txtMandatoImporto.Text = liquidazione_domanda.MandatoImporto;

                        txtQuietanzaData.Text = liquidazione_domanda.QuietanzaData;
                        txtQuietanzaImporto.Text = liquidazione_domanda.QuietanzaImporto;

                        if (liquidazione_domanda.MandatoIdFile == null && liquidazione_domanda.MandatoNumero == null && liquidazione_domanda.MandatoData == null && liquidazione_domanda.MandatoImporto == null)
                        {
                            ufMandato.AbilitaModifica = true;
                            btnSalvaMandato.Enabled = true;
                        }
                        if (liquidazione_domanda.QuietanzaData == null && liquidazione_domanda.QuietanzaImporto == null)
                        {
                            btnSalvaQuietanza.Enabled = true;
                        }

                        if (!VerificaValidazione(liquidazione_domanda.IdDomandaPagamento) && AbilitaModifica)
                            btnEliminaMandato.Enabled = true;
                        else
                        {
                            if (VerificaValidazione(liquidazione_domanda.IdDomandaPagamento))
                                btnEliminaMandato.ToolTip = "Impossibile eliminare il mandato in quanto la checklist di validazione è stata chiusa";
                        }
                    }
                }
            }
            dgDomande.DataSource = dd;
            dgDomande.SetTitoloNrElementi();
            dgDomande.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgDomande_ItemDataBound);
            dgDomande.DataBind();

            base.OnPreRender(e);
        }

        void lstBeneficiarioMandato_DataBinding(object sender, EventArgs e)
        {
            lstBeneficiarioMandato.Items.Clear();

            var priorita_aggregazione_collection = new SiarBLL.PrioritaCollectionProvider().Find(null, null, null, null, null, null, null, "Per domande presentate in forma aggregata selezionare l`aggregazione di impresa.", null);
            if (priorita_aggregazione_collection.Count > 0)
            {
                var priorita_aggregazione = priorita_aggregazione_collection[0];
                var prior_x_prog_collection = new SiarBLL.PrioritaXProgettoCollectionProvider().Find(domanda_selezionata.IdProgetto, priorita_aggregazione.IdPriorita, null);
                if (prior_x_prog_collection.Count > 0) // se è un aggregazione, prendo l'id e le relative imprese
                {
                    int id_aggregazione = Convert.ToInt16(prior_x_prog_collection[0].ValTesto);
                    var impresa_aggregazione_collection = new SiarBLL.ImpresaAggregazioneCollectionProvider().Find(id_aggregazione, null, null, null, null); //GetById(id_aggregazione);
                    foreach (SiarLibrary.ImpresaAggregazione impresa_aggregazione in impresa_aggregazione_collection)
                        lstBeneficiarioMandato.Items.Add(new ListItem(impresa_aggregazione.RagioneSociale, impresa_aggregazione.IdImpresa));
                }
                else // prendo solamente l'impresa collegata al progetto
                {
                    var prog = new SiarBLL.ProgettoCollectionProvider().GetById(domanda_selezionata.IdProgetto);
                    var impresa = new SiarBLL.ImpresaCollectionProvider().GetById(prog.IdImpresa);
                    lstBeneficiarioMandato.Items.Add(new ListItem(impresa.RagioneSociale, impresa.IdImpresa));
                }
            }
        }

        decimal contributo_ammesso_totale = 0;
        decimal importo_decreti_domande_totale = 0;
        decimal importo_richieste_liquidazione_totale = 0;
        decimal importo_liquidato_totale = 0;
        decimal importo_quietanza_totale = 0;

        void dgDomande_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.DomandaDiPagamento d = (SiarLibrary.DomandaDiPagamento)e.Item.DataItem;

                SiarLibrary.NullTypes.DecimalNT cm = new SiarLibrary.NullTypes.DecimalNT(d.AdditionalAttributes["CONTRIBUTO_AMMESSO"]);
                if (cm != null) contributo_ammesso_totale += cm;
                e.Item.Cells[3].Text = string.Format("{0:c}", cm);

                SiarLibrary.NullTypes.DecimalNT imp_dec = new SiarLibrary.NullTypes.DecimalNT(d.AdditionalAttributes["IMPORTO_DECRETI"]);
                if (imp_dec != null) importo_decreti_domande_totale += imp_dec;
                e.Item.Cells[4].Text = string.Format("{0:c}", imp_dec);

                SiarLibrary.NullTypes.DecimalNT imp_liq = new SiarLibrary.NullTypes.DecimalNT(d.AdditionalAttributes["IMPORTO_LIQUIDATO"]);
                if (imp_liq != null) importo_liquidato_totale += imp_liq;
                e.Item.Cells[5].Text = string.Format("{0:c}", imp_liq);

                SiarLibrary.NullTypes.DecimalNT imp_quiet = new SiarLibrary.NullTypes.DecimalNT(d.AdditionalAttributes["IMPORTO_QUIETANZA"]);
                if (imp_quiet != null) importo_quietanza_totale += imp_quiet;
                e.Item.Cells[6].Text = string.Format("{0:c}", imp_quiet);


                e.Item.Cells[7].Text = d.AdditionalAttributes["STATO_LIQUIDAZIONE"];
                if (domanda_selezionata != null && d.IdDomandaPagamento == domanda_selezionata.IdDomandaPagamento)
                    e.Item.Cells[8].Text = e.Item.Cells[8].Text.Replace("<input", "<input checked");
                e.Item.Cells[8].Text = e.Item.Cells[8].Text.Replace("<input", "<input onclick=\"selezionaDomanda(" + d.IdDomandaPagamento + ",this);\"");

                //aggiunto campo se la domanda è stata validata
                string validazione = "NO";
                var rev = new SiarBLL.TestataValidazioneCollectionProvider().FindRevisione(null, d.IdDomandaPagamento, true, true, Bando.IdBando, "AN", null, false);
                if(rev.Count>0)
                {
                    if (rev[0].Approvata && rev[0].SegnaturaRevisione != null && rev[0].SegnaturaRevisione != "")
                        validazione = "SI";
                }
                e.Item.Cells[9].Text = validazione;
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[3].Text = string.Format("{0:c}", contributo_ammesso_totale);
                e.Item.Cells[4].Text = string.Format("{0:c}", importo_decreti_domande_totale);
                e.Item.Cells[5].Text = string.Format("{0:c}", importo_liquidato_totale);
                e.Item.Cells[6].Text = string.Format("{0:c}", importo_quietanza_totale);
            }
        }

        decimal importo_decreti_totale = 0;

        void dgDecreti_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var d = (SiarLibrary.DecretiXDomPagEsportazione)e.Item.DataItem;
                SiarLibrary.NullTypes.DecimalNT cm = new SiarLibrary.NullTypes.DecimalNT(d.AdditionalAttributes["CONTRIBUTO_AMMESSO"]);

                if (d.Importo != null)
                    importo_decreti_totale += d.Importo;
                if(!Organismi_intermedi)
                {
                    var dec = d.Numero.ToString() + '|' + d.Data + '|' + d.Registro;
                    e.Item.Cells[0].Text = "<a href=\"javascript:visualizzaAtto(" + d.IdAtto + ");\">" + dec + "</a>";
                }
                else
                {
                    SiarLibrary.Atti a = atti_provider.GetById(d.IdAtto);
                    var dec = d.Numero.ToString() + '|' + d.Data ;
                    e.Item.Cells[0].Text = "<a target=\"_blank\" href=\"" + a.LinkEsterno + "\">" + dec + "</a>";
                }
                
                e.Item.Cells[5].Text = string.Format("{0:c}", d.Importo);

                if (d.RecuperoCompensazione != null && d.RecuperoCompensazione)
                    e.Item.Cells[6].Text = "Sì";
                else
                    e.Item.Cells[6].Text = "No";

                if (decreto_selezionato != null && d.IdAtto == decreto_selezionato.IdAtto)
                    e.Item.Cells[7].Text = e.Item.Cells[7].Text.Replace("<input", "<input checked");
                else
                    e.Item.Cells[7].Text = e.Item.Cells[7].Text.Replace("checked", "");

                e.Item.Cells[7].Text = e.Item.Cells[7].Text.Replace("<input", "<input onclick=\"selezionaDecreto(" + d.IdDecretiXDomPagEsportazione + ",this);\"");
            }
            else if (e.Item.ItemType == ListItemType.Footer) 
                e.Item.Cells[5].Text = string.Format("{0:c}", importo_decreti_totale);

        }

        void dgDomandeLiquidazioni_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (dgi.ItemType == ListItemType.Header)
            {
                dgi.CssClass = "TESTA1";
                dgi.Cells[0].ColumnSpan = 5;
                dgi.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                dgi.Cells[0].Text = "MANDATO DI PAGAMENTO</td><td colspan=2 align=center>QUIETANZA</td></tr><tr class='TESTA'><td>";
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                //e.Item.Cells[2].Text = string.Format("{0:c}", importo_mandato_richiesto);
                e.Item.Cells[3].Text = string.Format("{0:c}", importo_mandato);
                e.Item.Cells[6].Text = string.Format("{0:c}", importo_quietanza);
            }
            else
            {
                SiarLibrary.DomandaPagamentoLiquidazione dpl = (SiarLibrary.DomandaPagamentoLiquidazione)e.Item.DataItem;
                //SiarLibrary.NullTypes.DecimalNT imr = new SiarLibrary.NullTypes.DecimalNT(dpl.RichiestaMandatoImporto);
                //if (imr != null) importo_mandato_richiesto += imr;
                //e.Item.Cells[2].Text = string.Format("{0:c}", imr);
                SiarLibrary.NullTypes.DecimalNT im = new SiarLibrary.NullTypes.DecimalNT(dpl.MandatoImporto);
                //if (im != null) importo_mandato += im;
                e.Item.Cells[3].Text = string.Format("{0:c}", im);
                var impresaMandato = new SiarBLL.ImpresaCollectionProvider().GetById(dpl.IdImpresaBeneficiaria);
                e.Item.Cells[4].Text = impresaMandato.RagioneSociale;
                SiarLibrary.NullTypes.DecimalNT iq = new SiarLibrary.NullTypes.DecimalNT(dpl.QuietanzaImporto);
                //if (iq != null) importo_quietanza += iq;
                e.Item.Cells[6].Text = string.Format("{0:c}", iq);
            }

        }

        private void pulisciCampiDecreto()
        {
            txtAttoData.Text = "";
            txtAttoNumero.Text = "";
            lstAttoRegistro.ClearSelection();
            lstAttoTipo.ClearSelection();
            lstAttoOrgIstituzionale.ClearSelection();
            txtAttoDescrizione.Text = "";
            txtAttoBurData.Text = "";
            txtAttoBurNumero.Text = "";
            txtAttoImporto.Text = "";
            hdnIdAtto.Value = "";
            hdnIdDecretiXDomPagEsportazione.Value = "";
            hdnIdMandato.Value = "";

            txtDataDecretoOrg.Text = "";
            txtNumeroDecretoOrg.Text = "";
            txtDescrizioneDecretoOrg.Text = "";
            txtLinkEst.Text = "";
            txtAttoImportoOrg.Text = "";
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            dgDomande.SetPageIndex(0);
            dgDecreti.SetPageIndex(0);
        }

        protected void btnFiltra_Click(object sender, EventArgs e) { dgDomande.SetPageIndex(0); }

        protected void btnCercaDecreto_Click(object sender, EventArgs e)
        {
            try
            {
                int numero;
                int.TryParse(txtAttoNumero.Text, out numero);
                DateTime data;
                DateTime.TryParse(txtAttoData.Text, out data);
                string registro = lstAttoRegistro.SelectedValue;
                if (!string.IsNullOrEmpty(lstAttoRegistro.SelectedValue) && lstAttoRegistro.SelectedValue.IndexOf("|") > 0)
                    registro = lstAttoRegistro.SelectedValue.Substring(0, lstAttoRegistro.SelectedValue.IndexOf("|"));
                // controllo che l'atto sia registrato su db, altrimenti lo importo
                SiarLibrary.AttiCollection atti_trovati = atti_provider.Find(numero, data, lstAttoDefinizione.SelectedValue, registro);
                if (atti_trovati.Count == 0)
                {
                    atti_trovati = atti_provider.ImportaAtto(numero, data, lstAttoDefinizione.SelectedValue, lstAttoRegistro.SelectedValue);
                    if (atti_trovati.Count > 0) atti_provider.Save(atti_trovati[0]);
                }
                if (atti_trovati.Count > 0)
                {
                    decreto_selezionato = atti_trovati[0];
                    hdnIdDecretiXDomPagEsportazione.Value = "";
                    hdnIdAtto.Value = "";
                    txtAttoImporto.Text = null;
                }
                else ShowError("La ricerca non ha prodotto nessun risultato.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnAssociaDecreto_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if(!Organismi_intermedi)
                {
                    int id_decreto;
                    if (int.TryParse(hdnIdAtto.Value, out id_decreto))
                        decreto_selezionato = atti_provider.GetById(id_decreto);
                    if (decreto_selezionato == null) throw new Exception("Per proseguire è necessario specificare l'atto di riferimento.");
                    // se non è ancora definita la tipologia dell'atto, la salvo
                    if (decreto_selezionato.CodTipo == null)
                    {
                        decreto_selezionato.CodTipo = lstAttoTipo.SelectedValue;
                        atti_provider.Save(decreto_selezionato);
                    }
                }
                else
                {
                    if(txtDataDecretoOrg.Text == "" || txtNumeroDecretoOrg.Text == "" || txtDescrizioneDecretoOrg.Text == "" || txtLinkEst.Text == "" || txtAttoImportoOrg.Text == "" )
                        throw new Exception("Per proseguire è necessario specificare la data, il numero, la descrizione, il link esterno e l'importo.");
                    decreto_selezionato = new SiarLibrary.Atti();
                    decreto_selezionato.CodTipo = "L";
                    decreto_selezionato.CodDefinizione = "D";
                    decreto_selezionato.CodOrganoIstituzionale = "OI";
                    decreto_selezionato.Numero = new SiarLibrary.NullTypes.IntNT(txtNumeroDecretoOrg.Text);
                    decreto_selezionato.Data = txtDataDecretoOrg.Text;
                    decreto_selezionato.Descrizione = txtDescrizioneDecretoOrg.Text;
                    decreto_selezionato.LinkEsterno = txtLinkEst.Text;
                    atti_provider.Save(decreto_selezionato);
                }
                

                

                // salvo il decreto in domanda_pagamento_esportazione, per ora lascio null i campi importo_liquidato e flag_liquidato
                var decCollProv = new SiarBLL.DecretiXDomPagEsportazioneCollectionProvider();
                SiarLibrary.NullTypes.DecimalNT cm = new SiarLibrary.NullTypes.DecimalNT(domanda_selezionata.AdditionalAttributes["CONTRIBUTO_AMMESSO"]);
                var decxdomcheck = decCollProv.Find(domanda_selezionata.IdDomandaPagamento, domanda_selezionata.IdProgetto, null);
                decimal totaleImportiDecretiDomanda = calcolaTotaleImportiDecretiDomanda(decxdomcheck);
                decimal importoNuovo = 0;
                if(!Organismi_intermedi)
                    decimal.TryParse(txtAttoImporto.Text, out importoNuovo);
                else
                    decimal.TryParse(txtAttoImportoOrg.Text, out importoNuovo);
                var decxdom = decCollProv.Find(domanda_selezionata.IdDomandaPagamento, domanda_selezionata.IdProgetto, decreto_selezionato.IdAtto);
                
                if (decxdom.Count == 0)
                {
                    if (cm < totaleImportiDecretiDomanda + importoNuovo)
                    {
                        ShowError("Impossibile associare", "Il decreto ha un importo superiore al contributo ammesso della domanda.");
                    }
                    else
                    {
                        var dec = new SiarLibrary.DecretiXDomPagEsportazione();
                        dec.IdDomandaPagamento = domanda_selezionata.IdDomandaPagamento;
                        dec.IdProgetto = domanda_selezionata.IdProgetto;
                        dec.IdDecreto = decreto_selezionato.IdAtto;
                        
                        if (chkCompensazione.Checked)
                        {
                            dec.RecuperoCompensazione = true;
                            dec.Importo = null;
                        }
                        else
                        {
                            dec.RecuperoCompensazione = false;
                            dec.Importo = importoNuovo;
                        }
                        
                        decCollProv.Save(dec);
                        ShowMessage("Decreto di pagamento registrato correttamente.");
                    }
                }
                else
                {
                    var dec = decxdom[0];
                    if (importoNuovo == dec.Importo)
                    {
                        ShowError("Impossibile associare", "Il decreto era già associato alla domanda.");
                    }
                    else
                    {
                        decimal decretoImporto = dec.Importo ?? 0;

                        if (importoNuovo > decretoImporto && cm < totaleImportiDecretiDomanda + importoNuovo - decretoImporto)
                        {
                            ShowError("Impossibile aggiornare", "Non posso aggiornare l'importo del decreto in quanto il totale degli importi dei decreti associati alla domanda supererebbe il contributo ammesso.");
                        }
                        else
                        {
                            if (chkCompensazione.Checked)
                            {
                                dec.RecuperoCompensazione = true;
                                dec.Importo = null;
                            }
                            else
                            {
                                dec.RecuperoCompensazione = false;
                                dec.Importo = importoNuovo;
                            }
                            decCollProv.Save(dec);
                            ShowMessage("Il decreto era già associato alla domanda ma ho aggiornato l'importo.");
                        }
                    }
                }

                if (!chkCompensazione.Checked)
                    btnNuovoMandato.Visible = true;
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected decimal calcolaTotaleImportiDecretiDomanda(SiarLibrary.DecretiXDomPagEsportazioneCollection coll)
        {
            decimal total = 0;

            foreach (SiarLibrary.DecretiXDomPagEsportazione decreto in coll)
                total += decreto.Importo ?? 0;

            return total;
        }

        protected void btnSalvaRichiesta_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                // impostazione: per ora salvo tutti gli importi delle misure correlate in quella principale, 
                // quindi una liquidazione per domanda di pagamento, poi vedremo
                if (liquidazione_domanda == null)
                {
                    liquidazione_domanda = new SiarLibrary.DomandaPagamentoLiquidazione();
                    liquidazione_domanda.IdDomandaPagamento = domanda_selezionata.IdDomandaPagamento;
                    liquidazione_domanda.IdProgetto = domanda_selezionata.IdProgetto;
                    SiarLibrary.Progetto p = new SiarBLL.ProgettoCollectionProvider().GetById(domanda_selezionata.IdProgetto);
                    liquidazione_domanda.IdImpresaBeneficiaria = p.IdImpresa;
                }

                SiarLibrary.NullTypes.DatetimeNT data_richiesta_mandato = new SiarLibrary.NullTypes.DatetimeNT(txtRichiestaData.Text);
                if (data_richiesta_mandato > DateTime.Today)
                    throw new Exception("La data non può essere nel futuro.");
                liquidazione_domanda.RichiestaMandatoData = txtRichiestaData.Text;
                liquidazione_domanda.RichiestaMandatoImporto = txtRichiestaImporto.Text;
                if (!new SiarLibrary.Protocollo().ProtocolloEsistente(txtRichiestaSegnatura.Text))
                    throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.DocumentoNonValido);
                liquidazione_domanda.RichiestaMandatoSegnatura = txtRichiestaSegnatura.Text;
                liquidazione_domanda.IdDecreto = Convert.ToInt32(hdnIdAtto.Value);
                liquidazione_provider.Save(liquidazione_domanda);
                hdnIdMandato.Value = liquidazione_domanda.Id.ToString();
                ShowMessage("Dati della richiesta di mandato registrati correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalvaMandato_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

                if (liquidazione_domanda == null)
                {
                    liquidazione_domanda = new SiarLibrary.DomandaPagamentoLiquidazione();
                    liquidazione_domanda.IdDomandaPagamento = domanda_selezionata.IdDomandaPagamento;
                    liquidazione_domanda.IdProgetto = domanda_selezionata.IdProgetto;
                    SiarLibrary.Progetto p = new SiarBLL.ProgettoCollectionProvider().GetById(domanda_selezionata.IdProgetto);
                    //liquidazione_domanda.IdImpresaBeneficiaria = p.IdImpresa;
                    liquidazione_domanda.IdImpresaBeneficiaria = lstBeneficiarioMandato.SelectedValue;
                }

                liquidazione_domanda.IdDecreto = Convert.ToInt32(hdnIdAtto.Value);
                
                SiarLibrary.NullTypes.DecimalNT importo_mandato = new SiarLibrary.NullTypes.DecimalNT(txtMandatoImporto.Text);
                //if (liquidazione_domanda.RichiestaMandatoImporto == null || liquidazione_domanda.RichiestaMandatoImporto < importo_mandato) 
                //    throw new Exception("L'importo del mandato di pagamento non può essere superiore all'importo della richiesta.");
                SiarLibrary.NullTypes.DatetimeNT data_mandato = new SiarLibrary.NullTypes.DatetimeNT(txtMandatoData.Text);
                //if (liquidazione_domanda.RichiestaMandatoData == null || liquidazione_domanda.RichiestaMandatoData > data_mandato)
                //    throw new Exception("La data non può essere inferiore a quella della richiesta di mandato di pagamento.");
                if(data_mandato > DateTime.Today)
                    throw new Exception("La data non può essere nel futuro.");
                if (txtAttoImporto.Text != null && txtAttoImporto.Text != "" && importo_mandato > Convert.ToDecimal(txtAttoImporto.Text))
                    throw new Exception("L'importo del mandato non può essere superiore all'importo del decreto.");
                liquidazione_domanda.MandatoNumero = txtMandatoNumero.Text;
                liquidazione_domanda.MandatoData = txtMandatoData.Text;
                liquidazione_domanda.MandatoImporto = txtMandatoImporto.Text;
                liquidazione_domanda.MandatoIdFile = ufMandato.IdFile;
                liquidazione_provider.Save(liquidazione_domanda);
                hdnIdMandato.Value = liquidazione_domanda.Id.ToString();
                btnSalvaQuietanza.Enabled = true;
                ShowMessage("Dati del mandato di pagamento registrati correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalvaQuietanza_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

                int id_mandato;
                if (int.TryParse(hdnIdMandato.Value, out id_mandato))
                    liquidazione_domanda = liquidazione_provider.GetById(id_mandato);

                if (liquidazione_domanda == null) 
                    throw new Exception("La domanda selezionata non è valida.");
                SiarLibrary.NullTypes.DecimalNT importo_quietanza = new SiarLibrary.NullTypes.DecimalNT(txtQuietanzaImporto.Text);
                if (liquidazione_domanda.MandatoImporto == null || liquidazione_domanda.MandatoImporto < importo_quietanza)
                    throw new Exception("L'importo della quietanza non può essere superiore all'importo del mandato di pagamento.");
                SiarLibrary.NullTypes.DatetimeNT data_quietanza = new SiarLibrary.NullTypes.DatetimeNT(txtQuietanzaData.Text);
                if (liquidazione_domanda.MandatoData == null || liquidazione_domanda.MandatoData > data_quietanza)
                    throw new Exception("La data non può essere inferiore a quella del mandato di pagamento.");
                if (data_quietanza > DateTime.Today)
                    throw new Exception("La data non può essere nel futuro.");

                liquidazione_domanda.QuietanzaData = txtQuietanzaData.Text;
                liquidazione_domanda.QuietanzaImporto = txtQuietanzaImporto.Text;
                liquidazione_domanda.Liquidato = true;
                liquidazione_provider.Save(liquidazione_domanda);
                AbilitaModifica = false;
                ShowMessage("Dati della quietanza di pagamento registrati correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSelezionaMandato_Click(object sender, EventArgs e)
        {
        }
        
        protected void btnElimnaDecreto_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnIdDecretiXDomPagEsportazione.Value == "" || hdnIdDecretiXDomPagEsportazione.Value == null)
                    throw new Exception("Nessun decreto selezionato!");
                SiarLibrary.DomandaPagamentoLiquidazioneCollection dpl = new SiarBLL.DomandaPagamentoLiquidazioneCollectionProvider().FindByDecreto(domanda_selezionata.IdDomandaPagamento,
                    domanda_selezionata.IdProgetto, null, null, Convert.ToInt32(hdnIdAtto.Value));
                if(dpl.Count>0)
                    throw new Exception("Impossibile eliminare il decreto in quanto ci sono mandati collegati!");
                SiarBLL.DecretiXDomPagEsportazioneCollectionProvider dpe_prov = new SiarBLL.DecretiXDomPagEsportazioneCollectionProvider();
                SiarLibrary.DecretiXDomPagEsportazione dpe = dpe_prov.GetById(Convert.ToInt32(hdnIdDecretiXDomPagEsportazione.Value));
                dpe_prov.Delete(dpe);
                hdnIdDecretiXDomPagEsportazione.Value = null;
                pulisciCampiDecreto();
                ShowMessage("Decreto eliminato correttamente!");
            }
            catch(Exception ex)
            {
                ShowMessage(ex.Message);
            }
            
        }

        protected void btnEliminaMandato_Click(object sender, EventArgs e)
        {
            try
            {
                //verifica se la domanda è gia validata
                if (VerificaValidazione(domanda_selezionata.IdDomandaPagamento))
                    throw new Exception("La domanda è già stata validata, impossibile eliminare il mandato!");
                SiarBLL.DomandaPagamentoLiquidazioneCollectionProvider dpl_prov = new SiarBLL.DomandaPagamentoLiquidazioneCollectionProvider();
                if (hdnIdMandato.Value == null || hdnIdMandato.Value =="")
                    throw new Exception("Errore nella selezione del mandato");
                SiarLibrary.DomandaPagamentoLiquidazione dpl = dpl_prov.GetById(Convert.ToInt32(hdnIdMandato.Value));
                dpl_prov.Delete(dpl);
                liquidazione_domanda = null;
                hdnIdMandato.Value = "";
                ShowMessage("Mandato eliminate correttamente");


            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
            

        }

        protected void btnNuovoMandato_Click(object sender, EventArgs e)
        {
            liquidazione_domanda = null;
            hdnIdMandato.Value = null;
            trMandato.Visible = true;
            txtRichiestaData.Text = "";
            txtRichiestaImporto.Text = "";
            txtRichiestaSegnatura.Text = "";
            btnSalvaRichiesta.Enabled = true;

            ufMandato.IdFile = null;
            txtMandatoNumero.Text = "";
            txtMandatoData.Text = "";
            txtMandatoImporto.Text = "";
            ufMandato.AbilitaModifica = true;
            btnSalvaMandato.Enabled = true;

            txtQuietanzaData.Text = "";
            txtQuietanzaImporto.Text = "";
            btnSalvaQuietanza.Enabled = false;
        }

        private bool VerificaValidazione(int IdDomandaPagamento)
        {
            bool validata = false;

            var rdp = new SiarBLL.TestataValidazioneCollectionProvider().FindRevisione(null, IdDomandaPagamento, null, true, null, null, null, false);
            if (rdp.Count > 0)
                validata = true;

            return validata;

        }
    }
}
