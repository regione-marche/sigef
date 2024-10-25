using System;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using SiarBLL;
using SiarLibrary;
using SiarLibrary.Extensions;
using System.Linq;

namespace web.Private.Controlli
{
    public partial class PistaControllo : SiarLibrary.Web.PrivatePage
    {
        ProgettoCollection pp;
        VpistaControlloCollection vpc_coll;
        bool OrganismiIntermedi = false;

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "piste_controllo";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack && Request.Form["__EVENTTARGET"] != null)
            {
                if (Request.Form["__EVENTTARGET"] == "visualizza_pista" || SiarNewTab.TabSelected == "1")
                {
                    SiarNewTab.Select(1);
                    int idProgetto;
                    if (int.TryParse(hdnIdProgetto.Value, out idProgetto))
                        CaricaPistaDiControllo(idProgetto);
                    else
                    {
                        ShowMessage("Attenzione. Nessuna domanda di aiuto selezionata!");
                        SiarNewTab.Select(0);
                    }
                    //throw new Exception("Progetto non selezionato");
                }
            }
            string sdgas = SiarNewTab.TabSelected;


            lstIstruttoreAssegnato.CommandText = @"SELECT DISTINCT U.ID_UTENTE,NOMINATIVO FROM COLLABORATORI_X_BANDO C INNER JOIN BANDO B ON C.ID_BANDO=B.ID_BANDO
                        INNER JOIN vUTENTI U ON C.ID_UTENTE=U.ID_UTENTE ORDER BY U.NOMINATIVO";
            lstIstruttoreAssegnato.DataBind();

            lstRespProvinciale.CommandText = @"SELECT DISTINCT ID_UTENTE,NOMINATIVO FROM vBANDO_RESPONSABILI WHERE ATTIVO=1 AND PROVINCIA IS NOT NULL ORDER BY NOMINATIVO";
            lstRespProvinciale.DataBind();

            lstStatoProgetto.CommandText = @"SELECT S.COD_STATO,S.DESCRIZIONE FROM STATO_PROGETTO S LEFT JOIN FASI_PROCEDURALI F ON S.COD_FASE = F.COD_FASE WHERE COD_STATO != 'P' ORDER BY F.ORDINE";
            lstStatoProgetto.DataBind();

            lstProvince.DataBind();
            lstEntiBando.DataBind();
            lstProgrammazione.DataBind();
        }

        protected override void OnPreRender(EventArgs e)
        {
            pp = new ProgettoCollectionProvider().RicercaGeneraleProgettiNonProvvisori(txtIdProgetto.Text, lstStatoProgetto.SelectedValue, ucZoomBando.SelectedValue,
             txtCuaa.Text, txtRagioneSociale.Text, lstProvince.SelectedValue, lstProgrammazione.SelectedValue, lstEntiBando.SelectedValue,
             lstIstruttoreAssegnato.SelectedValue, lstRespProvinciale.SelectedValue, chkPagamenti.Checked, chkVarianti.Checked, chkAdeguamentiTecnici.Checked,
             chkIstruttoriaConclusa.Checked, chkIstruttoriaInCorso.Checked, chkAnnullati.Checked);
            
            dgDomande.DataSource = pp;
            dgDomande.ItemDataBound += new DataGridItemEventHandler(dgDomande_ItemDataBound);
            dgDomande.DataBind();
            
            lblNrElementi.Text = pp.Count.ToString();
            if (pp.Count == 0) 
                dgDomande.Titolo = "Nessun elemento trovato.";

            CaricaDatiMonitoraggio();

            base.OnPreRender(e);
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion

        void dgDomande_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.Progetto p = (SiarLibrary.Progetto)e.Item.DataItem;
                e.Item.Cells[4].Text = p.AdditionalAttributes["PROGRAMMAZIONE"];
                e.Item.Cells[5].Text = p.AdditionalAttributes["PIVA"] + " - " + p.AdditionalAttributes["RAGIONE_SOCIALE"];
            }
        }

        protected void rptAttoGraduatoria_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Reference the Repeater Item.
                RepeaterItem item = e.Item;
                SiarLibrary.Atti a = (SiarLibrary.Atti)item.DataItem;

                //Reference the Controls.
                //Button btnAttoGraduatoria = (item.FindControl("btnAttoGraduatoriaRpt") as Button);
                //Per il pulsante non funziona non so perché -> ho creato il metodo ProcessMyDataItem per gestirlo
                //if (btnAttoGraduatoria != null)
                //{
                //    if (!OrganismiIntermedi)
                //        btnAttoGraduatoria.Attributes.Add("onclick", "visualizzaAtto(" + a.Numero.ToString() + ");");
                //    else
                //    {
                //        if (a != null && a.LinkEsterno != null)
                //            btnAttoGraduatoria.Attributes.Add("onclick", "window.open('" + a.LinkEsterno + "');");
                //        else
                //            btnAttoGraduatoria.Attributes.Add("onclick", "alert('Link esterno per l'atto mancante';");
                //    }
                //}

                string testo = "Num. ";
                if (a.Numero != null)
                    testo += a.Numero.ToString();
                testo += " del ";
                if (a.Data != null)
                    testo += a.Data.ToString();
                testo += " Registro ";
                if (a.Registro != null)
                    testo += a.Registro.ToString() + " ";

                Label lbtAttoGraduatoria = (item.FindControl("lbAttoGraduatoriaRpt") as Label);
                if (lbtAttoGraduatoria != null)
                    lbtAttoGraduatoria.Text = testo;
            }
        }

        protected void rptDecretoLiq_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Reference the Repeater Item.
                RepeaterItem item = e.Item;
                SiarLibrary.DecretiXDomPagEsportazione d = (SiarLibrary.DecretiXDomPagEsportazione)item.DataItem;

                //Reference the Controls.
                //Button btnDecretoLiq = (item.FindControl("btnDecretoLiqRpt") as Button);

                string testo = "Num. ";
                if (d.Numero != null)
                    testo += d.Numero.ToString();
                testo += " del ";
                if (d.Data != null)
                    testo += d.Data.ToString();
                testo += " Registro ";
                if (d.Registro != null)
                    testo += d.Registro.ToString() + " ";

                Label lbDecretoLiq = (item.FindControl("lbDecretoLiqRpt") as Label);
                if (lbDecretoLiq != null)
                    lbDecretoLiq.Text = testo;
            }
        }

        protected string ProcessMyDataItem(object myValueLink, object myValueId)
        {
            //se ho il link esterno è da usare windows open per gli organismi intermedi, altrimenti visualizzo l'atto
            if (myValueLink != null)
                return "window.open('" + myValueLink + "');"; 
            else
                return "visualizzaAtto('" + myValueId + "');";
        }

        protected void btnCerca_Click(object sender, EventArgs e)
        {
            dgDomande.SetPageIndex(0);
        }

        public void CaricaPistaDiControllo(int IdProgetto)
        {
            try
            {
                vpc_coll = new VpistaControlloCollectionProvider().Find(IdProgetto);
                VpistaControllo vpc = new VpistaControllo();
                if (vpc_coll.Count > 0) vpc = vpc_coll[vpc_coll.Count - 1];
                bool TipoPista1 = true;
                string tipologia;
                if (vpc.CupNatura == "07")
                    tipologia = "AIUTI ";
                else
                    if (vpc.CupNatura == "08")
                        tipologia = "STRUMENTI FINANZIARI ";
                    else
                        tipologia = "OO PP ";
                if (vpc.Codicetitolaritaregia == "T")
                    tipologia += "A TITOLARITA'";
                else
                    tipologia += "A REGIA";
                lbTipologia.InnerText = tipologia;
                if (lbTipologia.InnerText == "OO PP A TITOLARITA'")
                    TipoPista1 = false;

                //controllo per organismi intermedi
                string Str_Organismi_intermedi = "";
                Str_Organismi_intermedi = new BandoConfigCollectionProvider().GetBandoConfig_OrganismiIntermedi(vpc.Idbando);
                if (Str_Organismi_intermedi == "True")
                    OrganismiIntermedi = true;

                //descrizione programmazione
                lblAsse.Text = "ASSE: " + vpc.Assecod + " - " + vpc.Assedescr;
                lblAzione.Text = "AZIONE: " + vpc.Azionecod + " - " + vpc.Azionedescr;
                lblIntervento.Text = "INTERVENTO: " + vpc.Interventocod + " - " + vpc.Interventodescr;
                lblBando.Text = "BANDO: " + vpc.Descrizionebando;
                lbAzienda.Text = "AZIENDA/ENTE: " + vpc.Ragionesociale;
                lbProgetto.Text = "PROGETTO NUM: " + vpc.Idprogetto.ToString();

                //modifiche per domande pregresse 20/11/2019
                BandoConfigCollectionProvider bcc = new BandoConfigCollectionProvider();

                // bandoPregresso è valorizzato se almeno una delle fasi pregresse è abilitata per il bando
                BandoConfigCollection bandoPregressoDOM = bcc.Find(vpc.Idbando, "PREGDOM", "PREGRESSO", true, null);
                BandoConfigCollection bandoPregressoAMM = bcc.Find(vpc.Idbando, "PREGAMM", "PREGRESSO", true, null);
                BandoConfigCollection bandoPregressoFIN = bcc.Find(vpc.Idbando, "PREGFIN", "PREGRESSO", true, null);
                //SiarLibrary.BandoConfigCollection bandoPregressoPDOM = bcc.Find(vpc.Idbando, "PREGPDOM", "PREGRESSO", true, null);
                //SiarLibrary.BandoConfigCollection bandoPregressoIDOM = bcc.Find(vpc.Idbando, "PREGIDOM", "PREGRESSO", true, null);
                //SiarLibrary.BandoConfigCollection bandoPregressoRIC = bcc.Find(vpc.Idbando, "PREGRIC", "PREGRESSO", true, null);

                string bandiPregressi = "";
                if (bandoPregressoDOM.Count > 0 || bandoPregressoAMM.Count > 0 || bandoPregressoFIN.Count > 0)
                {
                    bandiPregressi = " (P)";
                }

                //parere AdG
                if (vpc.Parereadg != null)
                {
                    btnParereAdg.Visible = true;
                    btnParereAdg.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + vpc.Parereadg + "');");
                    lbParereAdg.Text = vpc.Parereadg;
                    lbDataParereAdg.Text = vpc.Dataparereadg;
                }
                   

                if (TipoPista1)
                {
                    tdA1.Visible = false;
                    tdA2.Visible = false;
                    tdA3.Visible = false;
                    tdA4.Visible = false;
                    tdA5.Visible = false;
                    tbFideVar2.Visible = false;

                    //Atto pubblicazioneBando
                    lbAttoBandoPubblicazione.Text = "Num. " + vpc.Attopubblicazionebandonum.ToString() + " del " + vpc.Attopubblicazionebandodata.ToString() + " Registro " + vpc.Attopubblicazionebandoregistro + "  ";
                    btnVisualizzaAttoBandoPubblicazione.Visible = true;
                    // modifiche per organismi intermedi che non hanno AW_DOCNUMBER e AW_DOCNUMBER_NUOVO
                    if (!OrganismiIntermedi)
                        btnVisualizzaAttoBandoPubblicazione.Attributes.Add("onclick", "visualizzaAtto(" + vpc.Attopubblicazionebando.ToString() + ");");
                    else
                    {
                        var a = new AttiCollectionProvider().GetById(vpc.Attopubblicazionebando);
                        if (a != null && a.LinkEsterno != null)
                            btnVisualizzaAttoBandoPubblicazione.Attributes.Add("onclick", "window.open('" + a.LinkEsterno + "');");
                        else
                            btnVisualizzaAttoBandoPubblicazione.Attributes.Add("onclick", "alert('Link esterno per l'atto mancante';");
                    }
                    lbDataAttoBandoPubblicazione.Text = vpc.Attopubblicazionebandodata.ToString();

                    //Domanda di aiuto
                    lbDomandaAituo.Text = "Numero della Domanda SIGEF: " + vpc.Idprogetto.ToString();
                    lbDataDomandaAituo.Text = vpc.Domandadata.ToString("dd/MM/yyyy");
                    if (bandoPregressoDOM.Count > 0)
                        lbDataDomandaAituo.Text += bandiPregressi;

                    if (vpc.Segnaturadomanda != null && vpc.Segnaturadomanda !="")
                    { 
                        btnVisualizzaProgetto.Visible = true;
                        btnVisualizzaProgetto.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + vpc.Segnaturadomanda.ToString() + "');");
                    }
                    else
                    {
                        btnVisualizzaProgetto.Visible = false;
                    }

                    //Pubblicazione BUR
                    if (vpc.Attopubblicazionebandobur != null)
                        lbAttoBandoPubblicazioneBur.Text = "&nbsp;&nbsp;Numero " + vpc.Attopubblicazionebandobur.ToString();
                    if (vpc.Attopubblicazionebandoburdata != null)
                        lbDataAttoBandoPubblicazioneBur.Text = vpc.Attopubblicazionebandoburdata.ToString("dd/MM/yyyy");


                    //Verbale comitato di valutazione
                    if (vpc.Segnaturavalutazionevariantecomitato != null)
                    {
                        btnVisualizzaVerbale.Visible = true;
                        btnVisualizzaVerbale.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + vpc.Segnaturavalutazionevariantecomitato + "');");
                        lbVerbaleComitato.Text = vpc.Segnaturavalutazionevariantecomitato;
                        lbDataVerbaleComitato.Text = vpc.Datavalutazionevariantecomitato.ToString("dd/MM/yyyy");
                    }
                    else if (vpc.Segnaturavalutazionecomitato != null)
                    {
                        btnVisualizzaVerbale.Visible = true;
                        btnVisualizzaVerbale.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + vpc.Segnaturavalutazionecomitato + "');");
                        lbVerbaleComitato.Text = vpc.Segnaturavalutazionecomitato;
                        lbDataVerbaleComitato.Text = vpc.Datavalutazionecomitato.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        btnVisualizzaVerbale.Visible = false;
                        lbVerbaleComitato.Text = "";
                        lbDataVerbaleComitato.Text = "";
                    }

                    //Graduatoria
                    if (vpc.Segnaturagraduatoria != null)
                    {
                        btnVisualizzaGraduatoria.Visible = true;
                        btnVisualizzaGraduatoria.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + vpc.Segnaturagraduatoria + "');");
                        lbVisualizzaGraduatoria.Text = vpc.Segnaturagraduatoria;
                        lbDataGraduatoria.Text = vpc.Datagraduatoria.ToString("dd/MM/yyyy");
                        if (bandoPregressoFIN.Count > 0)
                            lbDataGraduatoria.Text += bandiPregressi;
                    }
                    else
                    {
                        btnVisualizzaGraduatoria.Visible = false;
                        lbVisualizzaGraduatoria.Text = "";
                        lbDataGraduatoria.Text = "";
                    }

                    //Atto Graduatoria
                    AttiCollection attiGradRPT = new AttiCollection();
                    if (vpc.Attodecretograduatoria != null || vpc.Attodecretograduatoriaindividuale != null)
                    {
                        GraduatoriaProgettiAttiCollection grad_prog_coll = new GraduatoriaProgettiAttiCollectionProvider().Find(vpc.Idbando, vpc.Idprogetto, null, null);
                        foreach(GraduatoriaProgettiAtti grad_p in grad_prog_coll)
                        {
                            Atti a = new AttiCollectionProvider().GetById(grad_p.IdAtto);
                            attiGradRPT.Add(a);
                        }

                    }

                    //Repeater rptDecretoGrad = (Repeater)e.Item.FindControl("rptAttoGraduatoria");
                    rptAttoGraduatoria.DataSource = attiGradRPT;
                    rptAttoGraduatoria.DataBind();

                    //Repeater rptDecretoGradData = (Repeater)e.Item.FindControl("rptAttoGraduatoriaData");
                    rptAttoGraduatoriaData.DataSource = attiGradRPT;
                    rptAttoGraduatoriaData.DataBind();

                    //if (vpc.Attodecretograduatoria != null)
                    //{
                    //    lbAttoGraduatoriaSchedaB.Text = "Num. " + vpc.Attodecretograduatorianum.ToString() + " del " + vpc.Attodecretograduatoriadata.ToString() + " Registro " + vpc.Attodecretograduatoriaregistro + "  ";
                    //    btnVisualizzaAttoGraduatoriaSchedaB.Visible = true;
                    //    btnVisualizzaAttoGraduatoriaSchedaB.Attributes.Add("onclick", "visualizzaAtto(" + vpc.Attodecretograduatoria.ToString() + ");");
                    //    lbDataAttoGraduatoriaSchedaB.Text = vpc.Attodecretograduatoriadata.ToString();
                    //}
                    //else if (vpc.Attodecretograduatoriaindividuale != null)
                    //{
                    //    btnVisualizzaAttoGraduatoriaSchedaB.Visible = true;
                    //    lbAttoGraduatoriaSchedaB.Text = "Num. " + vpc.Attodecretograduatoriaindividualenum.ToString() + " del " + vpc.Attodecretograduatoriaindividualedata.ToString() + " Registro " + vpc.Attodecretograduatoriaindividualeregistro + "  ";
                    //    btnVisualizzaAttoGraduatoriaSchedaB.Attributes.Add("onclick", "visualizzaAtto(" + vpc.Attodecretograduatoriaindividuale.ToString() + ");");
                    //    lbDataAttoGraduatoriaSchedaB.Text = vpc.Attodecretograduatoriaindividualedata.ToString();
                    //}
                    //else
                    //{
                    //    lbAttoGraduatoriaSchedaB.Text = "";
                    //    btnVisualizzaAttoGraduatoriaSchedaB.Visible = false;
                    //    lbDataAttoGraduatoriaSchedaB.Text = "";
                    //}

                    //Fidejussione
                    DomandaDiPagamentoCollection ddp_coll = new DomandaDiPagamentoCollectionProvider().Find(null, null, IdProgetto, null);
                    DomandaPagamentoFidejussioneImpresaCollection fidej_coll_rpt = new DomandaPagamentoFidejussioneImpresaCollection();
                    
                    if (ddp_coll.Count > 0)
                    {
                        foreach (DomandaDiPagamento v in ddp_coll)
                        {
                            if (v.IdFidejussione != null && v.SegnaturaApprovazione != null && v.Approvata == true && v.CodTipo=="ANT")
                            {
                                DomandaPagamentoFidejussione fidej_testa = new DomandaPagamentoFidejussioneCollectionProvider().GetById(v.IdFidejussione);
                                DomandaPagamentoFidejussioneImpresaCollection fidej_coll = new DomandaPagamentoFidejussioneImpresaCollectionProvider().Find(fidej_testa.IdDomandaPagamentoFidejussione, null, v.IdProgetto, null);
                                foreach (DomandaPagamentoFidejussioneImpresa fidej_imp in fidej_coll)
                                {
                                    if (fidej_imp.DataSottoscrizione != null  && fidej_imp.Numero != null && fidej_imp.LuogoSottoscrizione != null)
                                    {
                                        fidej_coll_rpt.Add(fidej_imp);
                                    }
                                }
                            }
                        }
                    }

                    rptFidej.DataSource = fidej_coll_rpt;
                    rptFidej.DataBind();
                    rptFidejData.DataSource = fidej_coll_rpt;
                    rptFidejData.DataBind();

                    //Varianti
                    VariantiCollection varianti_coll = new VariantiCollectionProvider().Find(null, IdProgetto, "VA");
                    VariantiCollection varianti_coll_rpt = new VariantiCollection();
                    int countVarianti = varianti_coll.Count;
                    for (int i = 0; i < countVarianti; i++)
                    {
                        if (varianti_coll[i].SegnaturaApprovazione != null)
                        {
                            varianti_coll_rpt.Add(varianti_coll[i]);
                        }
                    }

                    rptVarianti.DataSource = varianti_coll_rpt;
                    rptVarianti.DataBind();
                    rptVariantiData.DataSource = varianti_coll_rpt;
                    rptVariantiData.DataBind();

                }
                else
                {
                    tdB1.Visible = false;
                    tdB2.Visible = false;
                    tdB3.Visible = false;
                    tdB4.Visible = false;
                    tdB5.Visible = false;
                    tdB6.Visible = false;
                    tdB7.Visible = false;
                    tdB8.Visible = false;
                    tbFideVar.Visible = false;
                    tbFideVar2.Visible = true;
                    lbTipoProcedura.Text = (vpc.Tipoprocedura != null ? (string)vpc.Tipoprocedura : "");

                    //Atto Graduatoria
                    if (vpc.Attodecretograduatoria != null)
                    {
                        lbAttoGraduatoria.Text = "Num. " + vpc.Attodecretograduatorianum.ToString() + " del " + vpc.Attodecretograduatoriadata.ToString() + " Registro " + vpc.Attodecretograduatoriaregistro + "  ";
                        btnVisualizzaAttoGraduatoria.Visible = true;
                        // modifiche per organismi intermedi che non hanno AW_DOCNUMBER e AW_DOCNUMBER_NUOVO
                        if (!OrganismiIntermedi)
                            btnVisualizzaAttoGraduatoria.Attributes.Add("onclick", "visualizzaAtto(" + vpc.Attodecretograduatoria.ToString() + ");");
                        else
                        {
                            var a = new AttiCollectionProvider().GetById(vpc.Attodecretograduatoria);
                            if (a != null && a.LinkEsterno != null)
                                btnVisualizzaAttoGraduatoria.Attributes.Add("onclick", "window.open('" + a.LinkEsterno + "');");
                            else
                                btnVisualizzaAttoGraduatoria.Attributes.Add("onclick", "alert('Link esterno per l'atto mancante';");
                        }
                        lbDataAttoGraduatoria.Text = vpc.Attodecretograduatoriadata.ToString();
                    }
                    else if (vpc.Attodecretograduatoriaindividuale != null)
                    {
                        lbAttoGraduatoria.Text = "Num. " + vpc.Attodecretograduatoriaindividualenum.ToString() + " del " + vpc.Attodecretograduatoriaindividualedata.ToString() + " Registro " + vpc.Attodecretograduatoriaindividualeregistro + "  ";
                        btnVisualizzaAttoGraduatoria.Visible = true;

                        // modifiche per organismi intermedi che non hanno AW_DOCNUMBER e AW_DOCNUMBER_NUOVO
                        if (!OrganismiIntermedi)
                            btnVisualizzaAttoGraduatoria.Attributes.Add("onclick", "visualizzaAtto(" + vpc.Attodecretograduatoriaindividuale.ToString() + ");");
                        else
                        {
                            var a = new AttiCollectionProvider().GetById(vpc.Attodecretograduatoriaindividuale);
                            if (a != null && a.LinkEsterno != null)
                                btnVisualizzaAttoGraduatoria.Attributes.Add("onclick", "window.open('" + a.LinkEsterno + "');");
                            else
                                btnVisualizzaAttoGraduatoria.Attributes.Add("onclick", "alert('Link esterno per l'atto mancante';");
                        }

                        lbDataAttoGraduatoria.Text = vpc.Attodecretograduatoriaindividualedata.ToString();
                    }
                    else
                    {
                        lbAttoGraduatoria.Text = "";
                        lbDataAttoGraduatoria.Text = "";
                        btnVisualizzaAttoGraduatoria.Visible = false;
                    }

                    //Varianti
                    VariantiCollection varianti_coll = new VariantiCollectionProvider().Find(null, IdProgetto, "VA");
                    VariantiCollection varianti_coll_rpt = new VariantiCollection();
                    int countVarianti = varianti_coll.Count;
                    for (int i = 0; i < countVarianti; i++)
                    {
                        if (varianti_coll[i].SegnaturaApprovazione != null)
                        {
                            varianti_coll_rpt.Add(varianti_coll[i]);
                        }
                    }

                    rptVarianti2.DataSource = varianti_coll_rpt;
                    rptVarianti2.DataBind();
                    rptVarianti2Data.DataSource = varianti_coll_rpt;
                    rptVarianti2Data.DataBind();

                }

                DomandaDiPagamentoCollection ddp_coll_repeater = new DomandaDiPagamentoCollectionProvider().GetDomandePagamentoInviate(IdProgetto);
                rptDomandePagamento.DataSource = ddp_coll_repeater;
                rptDomandePagamento.DataBind();

                //Controlli in loco - verbale
                CntrlocoTestaCollection cntrlocoTesta_rpt = new CntrlocoTestaCollection();
                List<int> CntrLoco_IdLoco = new SiarBLL.CntrlocoDettaglioCollectionProvider().getArrayIdLoco_IdProgetto(IdProgetto);
                foreach (int IdLoco in CntrLoco_IdLoco)
                {
                    CntrlocoTesta testa = new CntrlocoTestaCollectionProvider().GetById(IdLoco);
                    if (testa.Segnatura != null)
                    {
                        cntrlocoTesta_rpt.Add(testa);
                    }
                }
                rptEstrazControllo.DataSource = cntrlocoTesta_rpt;
                rptEstrazControllo.DataBind();
                rptEstrazControlloData.DataSource = cntrlocoTesta_rpt;
                rptEstrazControlloData.DataBind();

                //Controlli in loco - checklist e file
                TestataControlliLocoCollection testataVerb_rpt = new TestataControlliLocoCollection();
                TestataControlliLocoCollection testataCk_rpt = new TestataControlliLocoCollection();
                TestataControlliLocoCollection testata_coll = new TestataControlliLocoCollectionProvider().Find(null, null, null, null, null, null, IdProgetto);
                if (testata_coll.Count > 0)
                {
                    foreach (TestataControlliLoco c in testata_coll)
                    {
                        if (c.IdFileVerbale != null || c.IdFileAttestazione != null)
                        {
                            testataVerb_rpt.Add(c);
                        }

                        if (c.SegnaturaTestata != null)
                        {
                            testataCk_rpt.Add(c);
                        }
                    }
                }
                rptVerbControllo.DataSource = testataVerb_rpt;
                rptVerbControllo.DataBind();
                rptVerbControlloData.DataSource = testataVerb_rpt;
                rptVerbControlloData.DataBind();
                rptCkControllo.DataSource = testataCk_rpt;
                rptCkControllo.DataBind();
                rptCkControlloData.DataSource = testataCk_rpt;
                rptCkControlloData.DataBind();

            }
            catch (Exception ex)
            { ShowError(ex.Message); }
        }

        protected void CaricaDatiMonitoraggio()
        {
            //MONITORIAGGIO
            int idProgetto;
            if (int.TryParse(hdnIdProgetto.Value, out idProgetto))
            {
                var pistaControlloProvider = new VpistaControlloCollectionProvider();
                vpc_coll = pistaControlloProvider.Find(idProgetto);
                VpistaControllo vpc = new VpistaControllo();
                if (vpc_coll.Count > 0) 
                    vpc = vpc_coll[vpc_coll.Count - 1];

                //Stato progetto
                string statoProgetto = pistaControlloProvider.GetStatoProgettoPistaDiControllo(idProgetto);
                lblStatoProgetto.Text = statoProgetto;

                //Data inizio
                var dateProgetto = pistaControlloProvider.GetDateProgettoPistaDiControllo(idProgetto);
                lblDataInizioProgetto.Text = dateProgetto.DataInizio;

                //Data fine prevista
                lblDataFinePrevistaProgetto.Text = dateProgetto.DataFinePrevista;

                //Data fine effettiva
                lblDataFineEffettivaProgetto.Text = dateProgetto.DataFineEffettiva; 

                //Indicatori
                var monitoraggio_selezionato = false;
                var bp_coll = new BusinessPlanCollectionProvider().GetBusinessPlanBando(vpc.Idbando);
                foreach (BusinessPlan bp in bp_coll)
                {
                    if (bp.IdBando == vpc.Idbando
                        && bp.Quadro.Contains("Dati di Monitoraggio"))
                        monitoraggio_selezionato = true;
                }

                if (monitoraggio_selezionato)
                {
                    ucProgettoInd.Progetto = new ProgettoCollectionProvider().GetById(vpc.Idprogetto);
                    ucProgettoInd.Istruttoria = CONTROLS.ProgettoIndicatori.eIstruttoria.No;
                    ucProgettoInd.StatoProgetto = CONTROLS.ProgettoIndicatori.eStato.Domanda;
                    ucProgettoInd.Operatore = Operatore.Utente.IdUtente;
                    ucProgettoInd.PistaDiControllo = true;
                    ucProgettoInd.DataBind();
                }
                else
                {
                    ucProgettoInd.Visible = false;
                }
            }
            else
            {
                ucProgettoInd.Visible = false;
            }
        }

        protected void rptDomandePagamento_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label TipoPag = (Label)e.Item.FindControl("lbTipoPagamento");
                string cod_tipo ="";
                switch (TipoPag.Text)
                {
                    case "ANT":
                        cod_tipo = "Anticipo";
                        break;
                    case "SAL":
                        cod_tipo = "SAL";
                        break;
                    case "SLD":
                        cod_tipo = "Saldo";
                        break;
                    case "RET":
                        cod_tipo = "Ulteriori contributi";
                        break;
                }
                TipoPag.Text = "Richiesta di pagamento " + cod_tipo;

                HiddenField iddomanda = e.Item.FindControl("hdnIdDomPag") as HiddenField;
                int idDomandaPag = Convert.ToInt32(iddomanda.Value);

                //modifiche per domande pregresse 20/11/2019
                BandoConfigCollectionProvider bcc = new BandoConfigCollectionProvider();
                
                Progetto prog = new ProgettoCollectionProvider().GetById(Convert.ToInt32(hdnIdProgetto.Value));
                
                // bandoPregresso è valorizzato se almeno una delle fasi pregresse è abilitata per il bando
                //SiarLibrary.BandoConfigCollection bandoPregressoDOM = bcc.Find(vpc.Idbando, "PREGDOM", "PREGRESSO", true, null);
                //SiarLibrary.BandoConfigCollection bandoPregressoAMM = bcc.Find(vpc.Idbando, "PREGAMM", "PREGRESSO", true, null);
                //SiarLibrary.BandoConfigCollection bandoPregressoFIN = bcc.Find(vpc.Idbando, "PREGFIN", "PREGRESSO", true, null);
                BandoConfigCollection bandoPregressoPDOM = bcc.Find(prog.IdBando, "PREGPDOM", "PREGRESSO", true, null);
                BandoConfigCollection bandoPregressoIDOM = bcc.Find(prog.IdBando, "PREGIDOM", "PREGRESSO", true, null);
                //SiarLibrary.BandoConfigCollection bandoPregressoRIC = bcc.Find(vpc.Idbando, "PREGRIC", "PREGRESSO", true, null);

                Label DataDomPag = (Label)e.Item.FindControl("lbDataDomandaPag");
                DateTime myDate = DateTime.ParseExact(DataDomPag.Text, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                DataDomPag.Text = myDate.ToString("dd/MM/yyyy");
                if (bandoPregressoPDOM.Count > 0)
                    DataDomPag.Text += " (P)";

                //DecretoLiquidazione
                Label lbDecreto = (Label)e.Item.FindControl("lbDecretoLiq");
                Label lbDataDecreto = (Label)e.Item.FindControl("lbDataDecretoLiq");
                DecretiXDomPagEsportazioneCollection decreti_coll = new DecretiXDomPagEsportazioneCollectionProvider().Find(idDomandaPag, null, null);
                DecretiXDomPagEsportazioneCollection decretoRPT = new DecretiXDomPagEsportazioneCollection();
                DomandaPagamentoLiquidazioneCollection liqMandatoRichiestoRPT = new DomandaPagamentoLiquidazioneCollection();
                DomandaPagamentoLiquidazioneCollection liqMandatoRPT = new DomandaPagamentoLiquidazioneCollection();
                for (int i = 0; i < decreti_coll.Count; i++)
                {
                    if (decreti_coll[i].IdDecreto != null)
                    {
                        decretoRPT.Add(decreti_coll[i]);

                        DomandaPagamentoLiquidazioneCollection Liq_coll = new DomandaPagamentoLiquidazioneCollectionProvider().FindByDecreto(idDomandaPag, null, null, null, decreti_coll[i].IdDecreto);
                        for (int j = 0; j < Liq_coll.Count; j++)
                        {
                            if (Liq_coll[j].RichiestaMandatoSegnatura != null)
                            {
                                liqMandatoRichiestoRPT.Add(Liq_coll[j]);
                            }
                            if (Liq_coll[j].MandatoIdFile != null)
                            {
                                liqMandatoRPT.Add(Liq_coll[j]);
                            }
                        }
                    }
                }

                Repeater rptDecreto = (Repeater)e.Item.FindControl("rptDecretoLiq");
                rptDecreto.DataSource = decretoRPT;
                rptDecreto.DataBind();
                Repeater rptDecretoData = (Repeater)e.Item.FindControl("rptDecretoLiqData");
                rptDecretoData.DataSource = decretoRPT;
                rptDecretoData.DataBind();
                //Repeater rptRichiestaMandatoData = (Repeater)e.Item.FindControl("rptRichiestaMandatoData");
                //rptRichiestaMandatoData.DataSource = liqMandatoRichiestoRPT;
                //rptRichiestaMandatoData.DataBind();
                //Repeater rptRichiestaMandato = (Repeater)e.Item.FindControl("rptRichiestaMandato");
                //rptRichiestaMandato.DataSource = liqMandatoRichiestoRPT;
                //rptRichiestaMandato.DataBind();
                Repeater rptMandatoData = (Repeater)e.Item.FindControl("rptMandatoData");
                rptMandatoData.DataSource = liqMandatoRPT;
                rptMandatoData.DataBind();
                Repeater rptMandato = (Repeater)e.Item.FindControl("rptMandato");
                rptMandato.DataSource = liqMandatoRPT;
                rptMandato.DataBind();

                //Checklist Validazione
                ImageButton imgval = e.Item.FindControl("ImgValidazione") as ImageButton;
                Label lbVal = e.Item.FindControl("lbValidazione") as Label;
                Label lbDataValidazione = e.Item.FindControl("lbDataValidazione") as Label;

                //SiarLibrary.RevisioneDomandaPagamentoCollection revDom_coll = new SiarBLL.RevisioneDomandaPagamentoCollectionProvider().Find(null, idDomandaPag, null, null, null, null);
                //if (revDom_coll.Count > 0)
                //{
                //    SiarLibrary.RevisioneDomandaPagamento revDom = revDom_coll[revDom_coll.Count - 1];
                //    if (revDom.SegnaturaRevisione != null)
                //    {
                //        lbVal.Text = revDom.SegnaturaRevisione;
                //        imgval.OnClientClick = " sncAjaxCallVisualizzaProtocollo('" + revDom.SegnaturaRevisione + "')";
                //        lbDataValidazione.Text = revDom.DataModifica.ToString("dd/MM/yyyy");
                //        if (bandoPregressoIDOM.Count > 0)
                //            lbDataValidazione.Text += " (P)";
                //    }
                //    else
                //    {
                //        imgval.Visible = false;
                //        lbVal.Visible = false;
                //    }
                //}
                //else
                //{
                //    imgval.Visible = false;
                //    lbVal.Visible = false;
                //}

                var revDom_coll = new TestataValidazioneCollectionProvider().GetUltimaRevisioneDomandaValida(idDomandaPag);
                if (revDom_coll.Count > 0)
                {
                    var revDom = revDom_coll[0];
                    if (revDom.SegnaturaRevisione != null)
                    {
                        lbVal.Text = revDom.SegnaturaRevisione;
                        imgval.OnClientClick = " sncAjaxCallVisualizzaProtocollo('" + revDom.SegnaturaRevisione + "')";
                        lbDataValidazione.Text = revDom.DataModifica.ToString("dd/MM/yyyy");
                        if (bandoPregressoIDOM.Count > 0)
                            lbDataValidazione.Text += " (P)";
                    }
                    else
                    {
                        imgval.Visible = false;
                        lbVal.Visible = false;
                    }
                }
                else
                {
                    imgval.Visible = false;
                    lbVal.Visible = false;
                }

                //Certificazione Spesa
                CertspTestaCollectionProvider cert_testa_prov = new CertspTestaCollectionProvider();
                var cert_dett_prov = new CertspDettaglioCollectionProvider();
                var dett_list = cert_dett_prov
                    .FindDefinitiviSelezionatiXProgetto(prog.IdProgetto)
                    .ToArrayList<CertspDettaglio>();
                var dett = dett_list
                    .Where(d => d.IdDomandaPagamento == idDomandaPag)
                    .OrderBy(d => d.IdcertspDettaglio)
                    .FirstOrDefault();

                Label lbDataCSAdg = e.Item.FindControl("lbDataCSAdg") as Label;
                Label lbCSAdg = e.Item.FindControl("lbCSAdg") as Label;
                ImageButton ImgCSAdga = e.Item.FindControl("ImgCSAdg") as ImageButton;

                Label lbCSVerbale = e.Item.FindControl("lbCSVerbale") as Label;
                ImageButton ImgCSVerbale = e.Item.FindControl("ImgCSVerbale") as ImageButton;

                Label lbDataCSContab = e.Item.FindControl("lbDataCSContab") as Label;
                Label lbCSContab = e.Item.FindControl("lbCSContab") as Label;

                if (dett != null && dett.Idcertsp != null)
                {
                    CertspTesta testa = cert_testa_prov.GetById(dett.Idcertsp);

                    if (testa.Datasegnatura != null && testa.Datasegnatura != "")
                        lbDataCSAdg.Text = testa.Datasegnatura.ToString("dd/MM/yyyy");
                    if (testa.Segnatura != null && testa.Segnatura != "")
                    {
                        lbCSAdg.Text = testa.Segnatura;
                        ImgCSAdga.OnClientClick = " sncAjaxCallVisualizzaProtocollo('" + testa.Segnatura + "')";
                    }
                    else
                        ImgCSAdga.Visible = false;

                    if (testa.IdFile != null && testa.IdFile != "")
                    {
                        lbCSVerbale.Text = "Verbale";
                        ImgCSVerbale.OnClientClick = " SNCUFVisualizzaFile('" + testa.IdFile + "')";
                    }
                    else
                        ImgCSVerbale.Visible = false;

                    DateTime fine = testa.Datainizio;
                    lbDataCSContab.Text = testa.Datafine.ToString("dd/MM/yyyy");
                    lbCSContab.Text = "  " + testa.Datainizio.ToString("dd/MM/yyyy") + " - " + fine.AddYears(1).AddDays(-1).ToString("dd/MM/yyyy");
                }
                else
                {
                    ImgCSAdga.Visible = false;
                    ImgCSVerbale.Visible = false;
                }
            }
        }

        protected void btnStampa_Click(object sender, EventArgs e)
        {
            try
            {
                int idProgetto;
                if (int.TryParse(hdnIdProgetto.Value, out idProgetto))
                    RegisterClientScriptBlock("SNCVisualizzaReport('rptPisteControllo', 1 ,'IdProgetto=" + idProgetto.ToString() + "');");
                else
                    throw new Exception("Progetto non selezionato");
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        protected void btnStampaFinanz_Click(object sender, EventArgs e)
        {
            try
            {
                int idProgetto;
                if (int.TryParse(hdnIdProgetto.Value, out idProgetto))
                    RegisterClientScriptBlock("SNCVisualizzaReport('rptPistaControlloFinanziario', 2 ,'IdProgetto=" + idProgetto.ToString() + "');");
                else
                    throw new Exception("Progetto non selezionato");

            }
            catch (Exception ex) { ShowError(ex.Message); }
        }
    }
}
