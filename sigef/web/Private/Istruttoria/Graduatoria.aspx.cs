using System;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using SiarBLL;


namespace web.Private.Istruttoria
{
    public partial class Graduatoria : SiarLibrary.Web.IstruttoriaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "Graduatoria";
            base.OnPreInit(e);
        }

        SiarLibrary.GraduatoriaProgettiCollection graduatoria;
        SiarBLL.GraduatoriaProgettiCollectionProvider graduatoria_provider = new SiarBLL.GraduatoriaProgettiCollectionProvider();
        SiarBLL.GraduatoriaProgettiAttiCollectionProvider graduatoria_atti_provider = new SiarBLL.GraduatoriaProgettiAttiCollectionProvider();
        SiarLibrary.Atti decreto;
        SiarBLL.AttiCollectionProvider atti_provider = new SiarBLL.AttiCollectionProvider();
        SiarBLL.BandoComunicazioniCollectionProvider bcom_prov = new SiarBLL.BandoComunicazioniCollectionProvider();
        SiarLibrary.BandoComunicazioniCollection bcom_coll;
        SiarLibrary.BandoComunicazioni bcom = new SiarLibrary.BandoComunicazioni();
        SiarBLL.GraduatoriaProgettiAttiCollectionProvider atti_grad_prov = new SiarBLL.GraduatoriaProgettiAttiCollectionProvider();
        SiarBLL.GraduatoriaBandoScorrimentoCollectionProvider scorr_prov = new SiarBLL.GraduatoriaBandoScorrimentoCollectionProvider();
        bool responsabile;
        bool scorrimento;
        bool progettiRiportatiIndietro;
        Boolean Organismi_intermedi = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            // se il bando e' scaduto e graduatoria parziale attivata su bando config mostro l'elenco delle domande istruibili  
            SiarLibrary.BandoConfigCollection cc = new SiarBLL.BandoConfigCollectionProvider().Find(Bando.IdBando, "ATTGRADBLOCCHI", null, true, null);
            if (cc.Count > 0 && bool.Parse(cc[0].Valore)) Redirect("GraduatoriaIndividuale.aspx");
            else
            {
                ucFirmaDocumento.DocumentoFirmatoEvent = btnPostBack_Click;
                if (!string.IsNullOrEmpty(hdnDecretoJson.Value))
                {
                    decreto = new SiarLibrary.Atti();
                    decreto.FillByJsonObject(hdnDecretoJson.Value);
                }
                responsabile = new SiarBLL.BandoResponsabiliCollectionProvider().Find(Bando.IdBando, Operatore.Utente.IdUtente, null, true, true).Count > 0;

                SiarLibrary.GraduatoriaBandoScorrimentoCollection scorr_coll = scorr_prov.Find(Bando.IdBando, false);
                if (scorr_coll.Count > 0)
                    scorrimento = true;
                else
                    scorrimento = false;

                //verifico se progetti sono stati riportati indietro+
                progettiRiportatiIndietro = VerificaProgettiRiportatiIndietro();

                AbilitaModifica = (AbilitaModifica && Bando.OrdineStato < 5 && (Operatore.Utente.CodEnte == "%" || responsabile)) 
                    || scorrimento 
                    || (progettiRiportatiIndietro && (Operatore.Utente.CodEnte == "%" || responsabile));
                string Str_Organismi_intermedi = "";
                Str_Organismi_intermedi = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_OrganismiIntermedi(Bando.IdBando);
                if (Str_Organismi_intermedi == "True")
                    Organismi_intermedi = true;

                //Se la graduatoria è 
                // - almeno definitiva e non riaperta per scorrimento 
                // - se sono il rup o amministratore 
                //posso modificare la graduatoria con decreto 
                if (!(Bando.OrdineStato >= 5
                    && !scorrimento
                    && (Operatore.Utente.Profilo == "Amministratore"
                        || responsabile)))
                    dgProgetti.Columns[14].Visible = false;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            progettiRiportatiIndietro = VerificaProgettiRiportatiIndietro();

            AbilitaModifica = (AbilitaModifica && Bando.OrdineStato < 5 && (Operatore.Utente.CodEnte == "%" || responsabile))
                || scorrimento
                || (progettiRiportatiIndietro && (Operatore.Utente.CodEnte == "%" || responsabile));


            //TotaleBando.Value = Bando.Importo;  
            graduatoria = graduatoria_provider.GetListaProgettiInGraduatoria(Bando.IdBando);
            dgProgetti.DataSource = graduatoria;
            dgProgetti.ItemDataBound += new DataGridItemEventHandler(dgProgetti_ItemDataBound);
            dgProgetti.DataBind();

            Bando = BandoProvider.GetById(Bando.IdBando);

            //Controllo se la graduatoria è stata riaperta  
            SiarLibrary.GraduatoriaBandoScorrimentoCollection scorr_coll = scorr_prov.Find(Bando.IdBando, false);
            if (scorr_coll.Count > 0)
                scorrimento = true;
            else
                scorrimento = false;
            if (scorrimento)
            {
                btnInserisciSegnatura.Enabled = false;
                trRiapertura.Visible = true;
                btnRiapertura.Enabled = false;
                tbRiaperturaPulsanti.Visible = true;
                if (!responsabile)
                {
                    btnCalcolaScorr.Enabled = false;
                    btnGraduatoriaDefinitivaScorr.Enabled = false;

                    //Sezione ordinamento
                    trOrdinpar.Visible = false;
                    trOrdinSep.Visible = false;
                    trOrdinBtn.Visible = false;
                    btnSalvaOrdinamento.Enabled = false;
                }
                btnVisualizzaDecretoScorr.Enabled = false;
                if (Bando.Segnatura != null && Bando.IdAtto == null)
                {
                    if (responsabile)
                        btnVisualizzaDecretoScorr.Enabled = true;
                    btnCalcolaScorr.Enabled = false;
                    btnGraduatoriaDefinitivaScorr.Enabled = false;

                    //Sezione ordinamento
                    trOrdinpar.Visible = false;
                    trOrdinSep.Visible = false;
                    trOrdinBtn.Visible = false;
                    btnSalvaOrdinamento.Enabled = false;
                }

            }
            else
            {
                //Se la graduatoria è definitiva abilito la sezione per la riapertura  
                if (Bando.OrdineStato >= 5 && Bando.IdAtto != null)
                {
                    trRiapertura.Visible = true;
                    if (!responsabile)
                        btnRiapertura.Enabled = false;
                }
            }

            txtStatoGraduatoria.Text = "PROVVISORIA";
            if (Bando.CodStato == "G")
            {
                if (!scorrimento)
                {
                    txtStatoGraduatoria.Text = "DEFINITIVA";
                    txtSegnaturaGraduatoria.Text = Bando.Segnatura;
                    btnStampa.Disabled = false;
                    btnStampa.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + Bando.Segnatura + "');");
                }
                else
                {
                    txtStatoGraduatoria.Text = "RIAPERTA";
                    if(Bando.Segnatura!= null && Bando.Segnatura != "")
                    {
                        txtSegnaturaGraduatoria.Text = Bando.Segnatura;
                        btnStampa.Disabled = false;
                        btnStampa.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + Bando.Segnatura + "');");
                    }
                    else
                    {
                        txtSegnaturaGraduatoria.Text = "";
                        btnStampa.Disabled = true;
                    }

                }

                btnXLS.Disabled = false;
                btnXLS.Attributes.Add("onclick", "SNCVisualizzaReport('rptGraduatoriaxls',2,'IdBando=" + Bando.IdBando + "');");

                //elenco atti  
                trStoricoAtti.Visible = true;
                List<Int32> elenco_atti = new List<int>();
                SiarLibrary.AttiCollection atti_finanz = new SiarLibrary.AttiCollection();
                SiarLibrary.GraduatoriaProgettiAttiCollection atti_grad_col = atti_grad_prov.Find(Bando.IdBando, null, null, null);
                foreach (SiarLibrary.GraduatoriaProgettiAtti a in atti_grad_col)
                {
                    if (a.IdAtto != null && !elenco_atti.Contains(a.IdAtto))
                    {
                        elenco_atti.Add(a.IdAtto);
                        SiarLibrary.Atti atto = atti_provider.GetById(a.IdAtto);
                        atti_finanz.Add(atto);
                    }
                }
                if(!Organismi_intermedi)
                {
                    dgDocumenti.Titolo = "Elementi trovati: " + atti_finanz.Count;
                    dgDocumenti.DataSource = atti_finanz;
                    dgDocumenti.DataBind();
                }
                else
                {
                    TrDoc.Visible = false;
                    TrDoc_OrgInt.Visible = true;
                    dgDocumenti_OrgInt.Titolo = "Elementi trovati: " + atti_finanz.Count;
                    dgDocumenti_OrgInt.ItemDataBound += new DataGridItemEventHandler(dgDocumenti_OrgInt_itemDataBound);
                    dgDocumenti_OrgInt.DataSource = atti_finanz;
                    dgDocumenti_OrgInt.DataBind();
                }



                if (atti_finanz.Count > 0)
                {
                    btnGraduatoriaDefinitiva.Enabled = false;
                    btnCalcola.Enabled = false;
                    //btnSalvaOrdinamento.Enabled = false;
                    btnVisualizzaDecreto.Enabled = false;
                    btnCercaDecreto.Enabled = btnInserisciDecreto.Enabled = btnSalvaDescretoOrg.Enabled = responsabile;
                }
            }

            // dettaglio multiprogrammazione  
            if (Bando.Multimisura)
            {
                tbRiepilogoMisure.Visible = true;
                dgMisura.DataSource = graduatoria_provider.GetRiepilogoSpeseXMisura(Bando.IdBando);
                dgMisura.MostraTotale("DataField", 1, 2);
                dgMisura.DataBind();
            }

            // decreto di finanziabilità  
            lstComunicazione.Items.Clear();
            lstComunicazione.Items.Add(new ListItem("Finanziabilità", "CFI"));
            lstComunicazione.Items.Add(new ListItem("Non Finanziabilità", "CFN"));
            lstComunicazione.Items.Add(new ListItem("Provvedimento di non Ammissibilità", "NAD"));
            foreach (ListItem l in lstComunicazione.Items) l.Selected = l.Value == lstComunicazione.SelectedValue;
            lstComunicazione.Attributes.Add("onchange", "$('[id$=btnVisualizzaDecreto]').click();");



            //pregresso  
            bool Pregresso = false;
            string StPregresso = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_PregressoFinanziabilita(Bando.IdBando);
            if (StPregresso == "True")
                Pregresso = true;
            if (Pregresso)
            {
                btnInserisciSegnatura.Visible = true;
                btnGraduatoriaDefinitiva.Visible = false;
                ckAttivo.Attributes.Add("onchange", "DisabilitaLabel();");
            }
            else
            {
                btnInserisciSegnatura.Visible = false;
                btnGraduatoriaDefinitiva.Visible = true;
            }


            bcom_coll = new SiarBLL.BandoComunicazioniCollectionProvider().Find(lstComunicazione.SelectedValue, Bando.IdBando);
            if (bcom_coll.Count > 0) bcom = bcom_coll[0];
            
            lstDefAtto.DataBind();
            lstOrgIstituzionale.DataBind();
            lstTipoAtto.DataBind();
            lstRegistro.DataBind();
            trDecretoComunicazione.Visible = true;
            trDataComunicazione.Visible = false;
            if (bcom.IdAtto != null)
            {
                decreto = atti_provider.GetById(bcom.IdAtto);
                btnEliminaDecreto.Enabled = responsabile;
            }
            else btnCercaDecreto.Enabled = btnInserisciDecreto.Enabled = btnSalvaDescretoOrg.Enabled= responsabile;
            
            //bindDecreto(scorrimento);  

            //Se la graduatoria è stata firmata ma non c'è il decreto di finanziabilita e almeno un progetto è stato riportato indietro abilito i pulsanti "calcola" e "rendi definitiva"
            //controllo se operatore è rup innanzitutto
            if (responsabile && progettiRiportatiIndietro)
            {
                if (!scorrimento)
                {
                    btnCalcola.Enabled = true;
                    btnGraduatoriaDefinitiva.Enabled = true;
                    btnVisualizzaDecreto.Enabled = false;

                    //sezione Ordinamento
                    trOrdinpar.Visible = true;
                    trOrdinSep.Visible = true;
                    trOrdinBtn.Visible = true;
                    btnSalvaOrdinamento.Enabled = true;
                }
                else
                {
                    btnCalcolaScorr.Enabled = true;
                    btnGraduatoriaDefinitivaScorr.Enabled = true;
                    btnVisualizzaDecretoScorr.Enabled = false;

                    //sezione Ordinamento
                    trOrdinpar.Visible = true;
                    trOrdinSep.Visible = true;
                    trOrdinBtn.Visible = true;
                    btnSalvaOrdinamento.Enabled = true;
                }
            }
            base.OnPreRender(e);
        }

        void dgProgetti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataGridItem dgi = (DataGridItem)e.Item;
                SiarLibrary.GraduatoriaProgetti graduatoria_progetto = (SiarLibrary.GraduatoriaProgetti)dgi.DataItem;
                dgi.Cells[2].Style.Add("cursor", "pointer");
                dgi.Cells[2].CssClass = "clickable";
                dgi.Cells[2].Attributes.Add("onclick", "dettaglioDomanda(" + graduatoria_progetto.IdProgetto + ",this)");
                dgi.Cells[4].Text = "<a href=\"javascript:" + ucSiarNewZoomPunteggio.GetOpenZoomJsFunction(graduatoria_progetto.IdProgetto) + "\"><img src='../../images/domande.ico' alt='Visualizza dettaglio di priorita' /></a>";
                dgi.Cells[9].Text = "<a href='GraduatoriaDettaglio.aspx?iddom=" + graduatoria_progetto.IdProgetto
                    + "'><img src='../../images/euro.gif' alt='Visualizza dettaglio di finanziabilita' /></a>";
                switch (graduatoria_progetto.Finanziabilita)
                {
                    case "P":
                        dgi.BackColor = System.Drawing.Color.FromArgb(206, 179, 170);
                        break;
                    case "N":
                        dgi.BackColor = System.Drawing.Color.FromArgb(204, 204, 179);
                        break;
                    case "M":
                        dgi.Cells[6].Text = "<b>(**)</b>&nbsp;&nbsp;" + dgi.Cells[5].Text;
                        break;
                }

                string StringDecreto = "", stringImportoParz = "";
                SiarLibrary.GraduatoriaProgettiAttiCollection atti_grad_coll_1 = atti_grad_prov.Find(graduatoria_progetto.IdBando, graduatoria_progetto.IdProgetto, null, null);
                SiarLibrary.GraduatoriaProgettiAttiCollection atti_grad_coll_temp = new SiarLibrary.GraduatoriaProgettiAttiCollection();
                foreach (SiarLibrary.GraduatoriaProgettiAtti atti_grad in atti_grad_coll_1)
                {
                    if (atti_grad.IdAtto != null)
                        atti_grad_coll_temp.Add(atti_grad);
                }

                if (atti_grad_coll_temp.Count == 1)
                {
                    SiarLibrary.Atti att = atti_provider.GetById(atti_grad_coll_temp[0].IdAtto);
                    StringDecreto += att.Numero.ToString() + " | " + att.Data.ToString() + " | " + att.Registro;
                    //stringImportoParz += string.Format("{0:N}", atti_grad_coll_temp[0].Importo);  
                }
                else if (atti_grad_coll_temp.Count > 1)
                {
                    int i = 0;
                    foreach (SiarLibrary.GraduatoriaProgettiAtti atti_grad in atti_grad_coll_temp)
                    {
                        SiarLibrary.Atti att = atti_provider.GetById(atti_grad.IdAtto);
                        if (i > 0)
                        {
                            StringDecreto += "<br>";
                            stringImportoParz += "<br>";
                        }
                        StringDecreto += att.Numero.ToString() + " | " + att.Data.ToString() + " | " + att.Registro;
                        stringImportoParz += string.Format("{0:N}", atti_grad.Importo);
                        i++;
                    }
                }

                dgi.Cells[10].Text = StringDecreto;
                dgi.Cells[11].Text = stringImportoParz;

                SiarLibrary.Progetto prog = new SiarBLL.ProgettoCollectionProvider().GetById(graduatoria_progetto.IdProgetto);

                // Non visualizza il pulsante cambio stato se:   
                // - graduatoria è provvisoria per tutti i progetti 
                // - graduatoria firmata ma senza atto e  progetto non è finanziabili  o gia stato riportato indietro
                // - graduatoria firmata e atto inserito per tutti i progetti 
                // - graduatoria riaperta, non firmata e progetti finanziabili 
                if ((Bando.CodStato != "G")
                    || (Bando.Segnatura != null && Bando.Segnatura != "" && Bando.IdAtto == null && !scorrimento && (graduatoria_progetto.Finanziabilita == "N" || prog.OrdineFase < 4))
                    || (Bando.Segnatura != null && Bando.Segnatura != "" && Bando.IdAtto != null)
                    || (Bando.Segnatura != null && Bando.Segnatura != "" && Bando.IdAtto == null && scorrimento &&  (graduatoria_progetto.Finanziabilita == "N" || prog.OrdineFase < 4 || atti_grad_coll_temp.Count > 0) ))
                {
                    dgi.Cells[12].Text = "";
                }

                dgi.Cells[13].Text = dgi.Cells[13].Text.Replace("<input", "<input checked disabled "); ;
                
                //dgi.Cells[9].Text = graduatoria_progetto.AdditionalAttributes["SEGNATURA"];  
                //if(graduatoria_progetto.ContributoTotale != null && (graduatoria_progetto.Finanziabilita =="S" || graduatoria_progetto.Finanziabilita == "P"))  
                //    dgi.Cells[10].Text = dgi.Cells[10].Text.Replace("value=\"\"", "value=\"" + graduatoria_progetto.ContributoTotale.ToString() + "\"  sigefname=\"conta\" ");  
                //else  
                //    dgi.Cells[10].Text = dgi.Cells[10].Text.Replace("value=\"\"", "value=\"\"  sigefname=\"conta\" ");  
            }
        }

        void dgDecreti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.Atti a = (SiarLibrary.Atti)e.Item.DataItem;
                e.Item.Cells[4].Text = "<input type=button class=ButtonGrid style='width:100px' value='Seleziona' onclick=\"selezionaDecreto("
                    + a.ConvertToJSonObject() + ");\" />";
            }
        }

        void dgDocumenti_OrgInt_itemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;

            if (dgi.ItemType != ListItemType.Header && dgi.ItemType != ListItemType.Footer)
            {
                SiarLibrary.Atti atto = (SiarLibrary.Atti)dgi.DataItem;
                e.Item.Cells[4].Text = "<a href = '" + atto.LinkEsterno + "' target='_blank'><img title ='Atto esterno' src='" + Request.ApplicationPath + "/images/lente.png' /></a>";
            }
        }

        protected void btnCalcola_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                SiarLibrary.BandoConfigCollection cc = new SiarBLL.BandoConfigCollectionProvider().Find(Bando.IdBando, "ATTGRADPARZ", null, true, null);
                bool GraduatoriaParziale = false;
                if (cc.Count > 0 && bool.Parse(cc[0].Valore)) GraduatoriaParziale = true;
                graduatoria_provider.CalcolaGraduatoriaBando(Bando.IdBando, Operatore.Utente.CfUtente, GraduatoriaParziale);
                ShowMessage("Graduatoria calcolata correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnPostBack_Click(object sender, EventArgs e)
        {
            try
            {

                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (string.IsNullOrEmpty(ucFirmaDocumento.FileFirmato))
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk e segnalare il problema.");

                SiarLibrary.Protocollo documento_interno = new SiarLibrary.Protocollo(Bando.CodEnte);
                documento_interno.setDocumento("Graduatoria_definitiva_bando_" + Bando.IdBando + ".pdf", Convert.FromBase64String(ucFirmaDocumento.FileFirmato));

                string[] ss = new SiarBLL.BandoCollectionProvider().GetDatiXProtocollazione(Bando.IdBando, null);
                string oggetto = "Graduatoria definitiva per il bando: " + ss[0] + " del " + ss[1] + "\n" + ss[4];
                string identificativo_paleo = documento_interno.DocumentoInterno(oggetto, ss[4]);
                SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider(BandoProvider.DbProviderObj);
                SiarBLL.BandoStoricoCollectionProvider bstorico_provider = new SiarBLL.BandoStoricoCollectionProvider(BandoProvider.DbProviderObj);
                SiarBLL.GraduatoriaProgettiAttiCollectionProvider graduatoria_atti_provider = new SiarBLL.GraduatoriaProgettiAttiCollectionProvider(BandoProvider.DbProviderObj);
                BandoProvider.DbProviderObj.BeginTran();
                try
                {
                    graduatoria = graduatoria_provider.Find(Bando.IdBando, null, null);
                    SiarLibrary.ProgettoCollection progetti_correlati;
                    foreach (SiarLibrary.GraduatoriaProgetti g in graduatoria)
                    {
                        //string stato = (g.Finanziabilita == "S" ? "F" : "N");  
                        //string stato = (g.Finanziabilita == "N" ? "N" : "G"); //abilito la finanziabilita' parziale  
                        string stato = "G";
                        SiarLibrary.Progetto progetto_in_graduatoria = progetto_provider.GetById(g.IdProgetto);

                        if (g.ContributoTotale == null || g.CostoTotale == null || g.ContributoRimanente == null)
                            throw new Exception("Mancano dei dati necessari per rendere definitiva la graduatoria per il progetto " + g.IdProgetto
                                + ". Potrebbbe essere necessario calcolare la graduatoria.");

                        decimal CountcontributoAtti = g.ContributoTotale;
                        SiarLibrary.GraduatoriaProgettiAttiCollection atti_grad_col = graduatoria_atti_provider.Find(g.IdBando, g.IdProgetto, null, null);
                        foreach (SiarLibrary.GraduatoriaProgettiAtti att in atti_grad_col)
                        {
                            CountcontributoAtti = CountcontributoAtti - att.Importo;
                        }



                        //non modifico lo stato se sono state presentate domande di pagamento  o se gia era stata resa tutta finanziabile prima dello scorrimento 
                        if ((progetto_in_graduatoria.OrdineFase < 5 && !scorrimento) ||
                            (progetto_in_graduatoria.OrdineFase < 5 && scorrimento && progetto_in_graduatoria.CodStato != stato &&
                            (g.Finanziabilita == "N" || (g.Finanziabilita != "N" && ( atti_grad_col.Count == 0 || CountcontributoAtti != 0)))))
                        {
                            progetto_provider.CambioStatoProgetto(progetto_in_graduatoria, stato, identificativo_paleo, Operatore);
                            if (progetto_in_graduatoria.IdProgIntegrato != null)
                            {
                                progetti_correlati = progetto_provider.Find(null, null, g.IdProgetto, null, null, false, true);
                                foreach (SiarLibrary.Progetto p in progetti_correlati)
                                    if (p.IdProgetto != p.IdProgIntegrato) progetto_provider.CambioStatoProgetto(p, stato, Operatore);
                            }
                        }

                        if (!scorrimento)
                        {
                            //Creo le righe in tabella graduatoria_progetti_atti se il progetto è finanziabile o parzialmente  
                            if (g.Finanziabilita != "N")
                            {

                                SiarLibrary.GraduatoriaProgettiAtti gradAtto = new SiarLibrary.GraduatoriaProgettiAtti();
                                gradAtto.IdBando = g.IdBando;
                                gradAtto.IdProgetto = g.IdProgetto;
                                gradAtto.DataCreazione = DateTime.Now;
                                gradAtto.OperatoreCreazione = Operatore.Utente.IdUtente;
                                decimal contributotot = g.ContributoTotale;
                                gradAtto.Importo = contributotot;
                                if (g.Finanziabilita == "S")
                                    gradAtto.FinanziabilitaTotale = true;
                                else
                                    gradAtto.FinanziabilitaTotale = false;
                                graduatoria_atti_provider.Save(gradAtto);
                            }
                        }
                        else
                        {
                            //controllo  in tabella graduatoria_progetti_atti se non è gia stato finanziato tutto  
                            if (g.Finanziabilita != "N" && (atti_grad_col.Count == 0 || CountcontributoAtti != 0))
                            {
                                SiarLibrary.GraduatoriaProgettiAtti gradAtto = new SiarLibrary.GraduatoriaProgettiAtti();
                                gradAtto.IdBando = g.IdBando;
                                gradAtto.IdProgetto = g.IdProgetto;
                                gradAtto.DataCreazione = DateTime.Now;
                                gradAtto.OperatoreCreazione = Operatore.Utente.IdUtente;
                                gradAtto.Importo = CountcontributoAtti;
                                if (g.Finanziabilita == "S")
                                    gradAtto.FinanziabilitaTotale = true;
                                else
                                    gradAtto.FinanziabilitaTotale = false;
                                graduatoria_atti_provider.Save(gradAtto);
                            }
                            btnCalcolaScorr.Enabled = false;
                            btnGraduatoriaDefinitivaScorr.Enabled = false;
                            btnVisualizzaDecretoScorr.Enabled = true;
                        }
                    }
                    // storico  
                    SiarLibrary.BandoStorico s = new SiarLibrary.BandoStorico();
                    s.IdBando = Bando.IdBando;
                    s.CodStato = "G";
                    s.Segnatura = identificativo_paleo;
                    s.Data = DateTime.Now;
                    s.Operatore = Operatore.Utente.IdUtente;
                    bstorico_provider.Save(s);

                    Bando.IdStoricoUltimo = s.Id;
                    BandoProvider.Save(Bando);
                    BandoProvider.DbProviderObj.Commit();
                    Bando = BandoProvider.GetById(Bando.IdBando);
                    ShowMessage("Graduatoria firmata e protocollata correttamente.");
                    btnCalcola.Enabled = false;
                    btnGraduatoriaDefinitiva.Enabled = false;
                    
                    //sezione Ordinamento
                    trOrdinpar.Visible = false;
                    trOrdinSep.Visible = false;
                    trOrdinBtn.Visible = false;
                    btnSalvaOrdinamento.Enabled = false;
                    
                    btnXLS.Disabled = false;

                }
                catch (Exception exc)
                {
                    BandoProvider.DbProviderObj.Rollback();
                    string oggettoEmail = "Errore in graduatoria definitiva bando id: " + Bando.IdBando;
                    string testEmail = "id doc paleo: " + identificativo_paleo
                        + "\nDettaglio errore: \n" + exc.Message;
                    EmailUtility.SendEmailToTeamSigef(exc, oggettoEmail, testEmail);
                    throw;
                }
            }
            catch (Exception ex) { ShowError(ex); }
            finally { ucFirmaDocumento.FileFirmato = null; }
        }

        protected void btnGraduatoriaDefinitiva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!responsabile) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                //string rimanenza = RimanenzaGrad.Value;  
                //decimal rimanenzaDec = Convert.ToDecimal(rimanenza.Replace(".", ""));  
                //if(rimanenzaDec<0)  
                //    throw new Exception("La rimanenza del bando è negativa!.");  
                SiarBLL.ProgettoCollectionProvider progetto_prov = new SiarBLL.ProgettoCollectionProvider();
                SiarLibrary.GraduatoriaProgettiCollection grad = graduatoria_provider.Find(Bando.IdBando, null, null);
                foreach (SiarLibrary.GraduatoriaProgetti g in grad)
                {
                    SiarLibrary.Progetto prog = progetto_prov.GetById(g.IdProgetto);
                    //if ((prog.OrdineFase < 3 && !scorrimento) || (progettiRiportatiIndietro && prog.OrdineFase < 3) )
                    if (prog.OrdineFase < 3 )
                        throw new Exception("Attenzione! Non tutte le domande della graduatoria sono state rese ammissibili. Impossibile continuare!");
                }
                ucFirmaDocumento.loadDocumento(Operatore.Utente.CfUtente, Bando.IdBando);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnVisualizzaDecreto_Click(object sender, EventArgs e)
        {
            if (!Organismi_intermedi)
                RegisterClientScriptBlock("mostraPopupTemplate('divSchedaForm','divBKGMessaggio');");
            else
                RegisterClientScriptBlock("mostraPopupTemplate('divDecretoOrgInt','divBKGMessaggio');");
        }

        private void bindDecreto(Boolean scorrimento)
        {
            if (decreto != null && !scorrimento)
            {
                txtNumeroDecreto.Text = decreto.Numero;
                txtDataDecreto.Text = decreto.Data;
                txtNumeroBur.Text = decreto.NumeroBur;
                txtDataBur.Text = decreto.DataBur;
                txtRegistro.Text = decreto.Registro;
                lstDefAtto.SelectedValue = decreto.CodDefinizione;
                lstOrgIstituzionale.SelectedValue = decreto.CodOrganoIstituzionale;
                lstTipoAtto.SelectedValue = decreto.CodTipo;
                txtDescrizione.Text = decreto.Descrizione;
            }
            else
            {

                hdnDecretoJson.Value = null;
                txtNumeroDecreto.Text = null;
                txtDataDecreto.Text = null;
                txtNumeroBur.Text = null;
                txtDataBur.Text = null;
                txtRegistro.Text = null;
                lstDefAtto.ClearSelection();
                lstOrgIstituzionale.ClearSelection();
                lstTipoAtto.ClearSelection();
                txtDescrizione.Text = null;
                btnCercaDecreto.Enabled = btnInserisciDecreto.Enabled = true;
            }
        }

        protected void btnCercaDecreto_Click(object sender, EventArgs e)
        {
            try
            {
                if (!responsabile) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                RegisterClientScriptBlock("mostraPopupTemplate('divSchedaForm','divBKGMessaggio');");
                hdnDecretoJson.Value = null;
                decreto = null;
                int numero;
                int.TryParse(txtNumeroDecreto.Text, out numero);
                DateTime data;
                DateTime.TryParse(txtDataDecreto.Text, out data);
                SiarLibrary.AttiCollection atti_trovati = atti_provider.ImportaAtto(numero, data, "D", lstRegistro.SelectedValue);
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
                        lstTipoAtto.SelectedValue = decreto.CodTipo;
                        txtDescrizione.Text = decreto.Descrizione;
                    }
                }
                else ShowError("Il decreto cercato non è stato trovato.");
            }
            catch (Exception ex) { ShowError(ex); }
        }


        protected void btnInserisciDecreto_Click(object sender, EventArgs e)
        {
            try
            {
                if (!responsabile) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

                if (!Organismi_intermedi)
                {
                    RegisterClientScriptBlock("mostraPopupTemplate('divSchedaForm','divBKGMessaggio');");
                    if (string.IsNullOrEmpty(lstComunicazione.SelectedValue)) throw new Exception("Selezionare il tipo di comunicazione.");
                }
                bcom_coll = new SiarBLL.BandoComunicazioniCollectionProvider().Find( !Organismi_intermedi ? lstComunicazione.SelectedValue : "CFI", Bando.IdBando);
                if (bcom_coll.Count > 0) bcom = bcom_coll[0];


                //if (Bando.CodEnte.Value.Contains("GAL") || Bando.CodEnte.Value.Contains("PR"))
                //{
                //    if (string.IsNullOrEmpty(txtDataXComunicazione.Text)) throw new Exception("Inserire la data.");
                //    bcom.Data = txtDataXComunicazione.Text;
                //}
                //else
                //{
                if(!Organismi_intermedi)
                {
                    if (decreto == null) throw new Exception("Il decreto cercato non è stato trovato.");
                    if (lstTipoAtto.SelectedValue == null) throw new Exception("Selezionare il tipo di atto.");
                    if (decreto.IdAtto == null)
                    {
                        // se non e' ancora salvato sul db controllo che non sia duplicato  
                        SiarLibrary.AttiCollection atti_simili = atti_provider.Find(decreto.Numero, decreto.Data, "D", decreto.Registro);
                        if (atti_simili.Count > 0) decreto = atti_simili[0];
                    }
                    decreto.CodTipo = lstTipoAtto.SelectedValue;
                }
                else
                {
                    decreto = new SiarLibrary.Atti();
                    decreto.CodTipo = "A";
                    decreto.CodDefinizione = "D";
                    decreto.CodOrganoIstituzionale = "OI";
                    decreto.Numero = new SiarLibrary.NullTypes.IntNT(txtNumeroDecretoOrg.Text);
                    decreto.Data = txtDataDecretoOrg.Text;
                    decreto.Descrizione = txtDescrizioneDecretoOrg.Text;
                    decreto.LinkEsterno = txtLinkEst.Text;
                }

                atti_provider.Save(decreto);
                bcom.IdAtto = decreto.IdAtto;

                //Valorizzo id_atto sulla tabella Bando_Storico  
                SiarBLL.BandoStoricoCollectionProvider bstorico_provider = new SiarBLL.BandoStoricoCollectionProvider(BandoProvider.DbProviderObj);
                SiarLibrary.BandoStoricoCollection bsc = bstorico_provider.Find(Bando.IdBando, "G");
                SiarLibrary.BandoStorico bsg = bstorico_provider.GetById(Bando.IdStoricoUltimo);
                if (bsc.Count == 0 || (bsg.Segnatura != null && bsg.IdAtto != null && bsg.CodStato =='G'))
                    throw new Exception("La graduatoria non è stata ancora resa definitiva. Impossibile continuare..");

                //SiarLibrary.BandoStorico bs = null;
                //foreach (SiarLibrary.BandoStorico s in bsc)
                //    if (s.IdAtto == null)
                //        bs = s;
                //if (bs == null)
                //    throw new Exception("Errore nello stato del bando. Impossibile continuare..");
                    
                bsg.IdAtto = decreto.IdAtto;
                bstorico_provider.Save(bsg);

                //}
                bcom.IdBando = Bando.IdBando;
                bcom.CodTipo = lstComunicazione.SelectedValue;
                bcom_prov.Save(bcom);


                SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider();
                graduatoria = graduatoria_provider.Find(Bando.IdBando, null, null);
                SiarLibrary.ProgettoCollection progetti_correlati;
                foreach (SiarLibrary.GraduatoriaProgetti g in graduatoria)
                {
                    //string stato = (g.Finanziabilita == "S" ? "F" : "N");  
                    string stato = (g.Finanziabilita == "N" ? "N" : "F"); //abilito la finanziabilita' parziale  
                    SiarLibrary.Progetto progetto_in_graduatoria = progetto_provider.GetById(g.IdProgetto);

                    //non modifico lo stato se sono state presentate domande di pagamento  
                    if (progetto_in_graduatoria.CodStato =="G" && ((progetto_in_graduatoria.OrdineFase < 5 && !scorrimento) || (progetto_in_graduatoria.OrdineFase < 5 && scorrimento && progetto_in_graduatoria.CodStato != stato)))
                    {
                        progetto_provider.CambioStatoProgetto(progetto_in_graduatoria, stato, decreto.IdAtto, Operatore);
                        if (progetto_in_graduatoria.IdProgIntegrato != null)
                        {
                            progetti_correlati = progetto_provider.Find(null, null, g.IdProgetto, null, null, false, true);
                            foreach (SiarLibrary.Progetto p in progetti_correlati)
                                if (p.IdProgetto != p.IdProgIntegrato) progetto_provider.CambioStatoProgetto(p, stato, Operatore);
                        }
                    }
                }
                decreto = null;
                //Controllo se la graduatoria è stata riaperta  

                //Salvo l'id atto nella tabella Graduatoria_progetti_atti  
                SiarLibrary.GraduatoriaProgettiCollection grad = graduatoria_provider.Find(Bando.IdBando, null, null);
                foreach (SiarLibrary.GraduatoriaProgetti g in grad)
                {
                    if (g.Finanziabilita != "N")
                    {
                        SiarLibrary.GraduatoriaProgettiAttiCollection atti_coll = atti_grad_prov.Find(g.IdBando, g.IdProgetto, null, null);
                        foreach (SiarLibrary.GraduatoriaProgettiAtti a in atti_coll)
                        {
                            if (a.IdAtto == null)
                            {
                                a.IdAtto = bcom.IdAtto;
                                a.DataAggiornamento = DateTime.Now;
                                a.OperatoreAggiornamento = Operatore.Utente.IdUtente;
                                atti_grad_prov.Save(a);
                            }
                        }
                    }
                }

                //se scorrimento lo chiudo  
                SiarLibrary.GraduatoriaBandoScorrimentoCollection scorr_coll = scorr_prov.Find(Bando.IdBando, false);
                if (scorr_coll.Count > 0)
                {
                    SiarLibrary.GraduatoriaBandoScorrimento scorr = scorr_coll[0];
                    scorr.DataFine = DateTime.Now;
                    scorr.ScorrimentoCompletato = true;
                    scorr_prov.Save(scorr);
                }

                //bindDecreto(scorrimento);  

                btnSalvaOrdinamento.Enabled = false;

                if(scorrimento)
                    RegisterClientScriptBlock("chiudiPopupTemplate();");

                //Ricarico il bando
                Bando = BandoProvider.GetById(Bando.IdBando);

                ShowMessage("Dati salvati correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnEliminaDecreto_Click(object sender, EventArgs e)
        {
            try
            {
                if (!responsabile) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                RegisterClientScriptBlock("mostraPopupTemplate('divSchedaForm','divBKGMessaggio');");
                if (string.IsNullOrEmpty(lstComunicazione.SelectedValue)) throw new Exception("Selezionare il tipo di comunicazione.");
                bcom = new SiarBLL.BandoComunicazioniCollectionProvider().Find(lstComunicazione.SelectedValue, Bando.IdBando)[0];
                bcom.IdAtto = null;
                bcom.Data = null;
                bcom_prov.Save(bcom);
                decreto = null;
                bindDecreto(true);
                ShowMessage("Dati eliminati correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnPost_Click(object sender, EventArgs e) { }

        protected void btnInserisciSegnatura_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                RegisterClientScriptBlock("mostraPopupTemplate('divPregresso','divBKGMessaggio');");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalvaSegnatura_Click(object sender, EventArgs e)
        {
            try
            {
                if (((txtData.Text == "" || txtData.Text == null) && (txtSegnaturaIns.Text == null || txtSegnaturaIns.Text == "")) || ((txtData.Text == "" || txtData.Text == null) && !ckAttivo.Checked)) throw new Exception("Inserire la data e la segnatura se disponibile");
                if (!ckAttivo.Checked)
                {
                    if (!new SiarLibrary.Protocollo().ProtocolloEsistente(txtSegnaturaIns.Text))
                        throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.DocumentoNonValido);
                }
                SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider(BandoProvider.DbProviderObj);
                SiarBLL.BandoStoricoCollectionProvider bstorico_provider = new SiarBLL.BandoStoricoCollectionProvider(BandoProvider.DbProviderObj);
                SiarBLL.GraduatoriaProgettiAttiCollectionProvider graduatoria_atti_provider = new SiarBLL.GraduatoriaProgettiAttiCollectionProvider(BandoProvider.DbProviderObj);
                BandoProvider.DbProviderObj.BeginTran();
                graduatoria = graduatoria_provider.Find(Bando.IdBando, null, null);
                SiarLibrary.ProgettoCollection progetti_correlati;
                foreach (SiarLibrary.GraduatoriaProgetti g in graduatoria)
                {
                    //string stato = (g.Finanziabilita == "S" ? "F" : "N");  
                    //string stato = (g.Finanziabilita == "N" ? "N" : "G"); //abilito la finanziabilita' parziale  
                    string stato = "G"; //abilito la finanziabilita' parziale  

                    SiarLibrary.Progetto progetto_in_graduatoria = progetto_provider.GetById(g.IdProgetto);
                    if (progetto_in_graduatoria.OrdineFase < 5) //non modifico lo stato se sono state presentate domande di pagamento  
                    {
                        //progetto_provider.CambioStatoProgettoPregresso(progetto_in_graduatoria, "G", ckAttivo.Checked ? "ND" : txtSegnaturaIns.Text, Convert.ToDateTime(txtData.Text), Operatore, false, false, false);  
                        progetto_provider.CambioStatoProgettoPregresso(progetto_in_graduatoria, stato, ckAttivo.Checked ? "ND" : txtSegnaturaIns.Text, Convert.ToDateTime(txtData.Text), Operatore, false, false, false);
                        if (progetto_in_graduatoria.IdProgIntegrato != null)
                        {
                            progetti_correlati = progetto_provider.Find(null, null, g.IdProgetto, null, null, false, true);
                            foreach (SiarLibrary.Progetto p in progetti_correlati)
                                if (p.IdProgetto != p.IdProgIntegrato)
                                {
                                    //progetto_provider.CambioStatoProgettoPregresso(p, "G", null, Convert.ToDateTime(txtData.Text), Operatore, false, false, false);  
                                    progetto_provider.CambioStatoProgettoPregresso(p, stato, null, Convert.ToDateTime(txtData.Text), Operatore, false, false, false);
                                }
                        }
                    }

                    SiarLibrary.GraduatoriaProgettiAtti gradAtto = new SiarLibrary.GraduatoriaProgettiAtti();
                    gradAtto.IdBando = g.IdBando;
                    gradAtto.IdProgetto = g.IdProgetto;
                    gradAtto.DataCreazione = DateTime.Now;
                    gradAtto.OperatoreCreazione = Operatore.Utente.IdUtente;
                    decimal contributotot = g.ContributoTotale;
                    gradAtto.Importo = contributotot;
                    if (g.Finanziabilita == "S")
                        gradAtto.FinanziabilitaTotale = true;
                    else
                        gradAtto.FinanziabilitaTotale = false;
                    graduatoria_atti_provider.Save(gradAtto);

                }
                // storico  
                SiarLibrary.BandoStorico s = new SiarLibrary.BandoStorico();
                s.IdBando = Bando.IdBando;
                s.CodStato = "G";
                s.Segnatura = ckAttivo.Checked ? "ND" : txtSegnaturaIns.Text;
                s.Data = Convert.ToDateTime(txtData.Text);
                s.Operatore = Operatore.Utente.IdUtente;
                bstorico_provider.Save(s);

                Bando.IdStoricoUltimo = s.Id;
                BandoProvider.Save(Bando);
                BandoProvider.DbProviderObj.Commit();
                Bando = BandoProvider.GetById(Bando.IdBando);
                RegisterClientScriptBlock("chiudiPopupTemplate();");
                ShowMessage("La Data e la segnatura della graduatoria sono state salvate correttamente.");
                btnCalcola.Enabled = false;
                btnGraduatoriaDefinitiva.Enabled = false;
                btnInserisciSegnatura.Enabled = false;

                //sezione Ordinamento
                trOrdinpar.Visible = false;
                trOrdinSep.Visible = false;
                trOrdinBtn.Visible = false;
                btnSalvaOrdinamento.Enabled = false;

                btnXLS.Disabled = false;

            }
            catch (Exception ex)
            {
                btnInserisciSegnatura_Click(sender, e);
                ShowError("Attenzione! " + ex.Message);
            }
        }

        protected void btnRiapertura_Click(object sender, EventArgs e)
        {
            try
            {
                if (!responsabile) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

                int idbando = Bando.IdBando;

                //salvo l'istanza della graduatoria  
                SiarBLL.GRADUATORIA istanza = new SiarBLL.GRADUATORIA(idbando);
                SiarBLL.GraduatoriaProgettiStoricoCollectionProvider prov_storico_grad = new SiarBLL.GraduatoriaProgettiStoricoCollectionProvider();
                SiarLibrary.GraduatoriaProgettiStorico storico = new SiarLibrary.GraduatoriaProgettiStorico();
                storico.IdBando = idbando;
                storico.Operatore = Operatore.Utente.IdUtente;
                storico.DataAnnullamento = DateTime.Now;
                storico.IstanzaGraduatoria = istanza.Serialize();
                prov_storico_grad.Save(storico);

                //Verifica se qualche progetto è stato escluso ed elimino la riga su graduatoria progetti  
                SiarBLL.ProgettoCollectionProvider prog_prov = new SiarBLL.ProgettoCollectionProvider();
                SiarLibrary.GraduatoriaProgettiCollection grad = graduatoria_provider.Find(Bando.IdBando, null, null);
                foreach (SiarLibrary.GraduatoriaProgetti g in grad)
                {
                    SiarLibrary.Progetto ppp = prog_prov.GetById(g.IdProgetto);
                    if (ppp.CodStato == "R" || ppp.CodStato == "Y" || ppp.CodStato == "B" || ppp.CodStato == "E" || ppp.CodStato == "Q" || ppp.CodStato == "X")
                        graduatoria_provider.Delete(g);
                    else
                    {
                        g.Ordine = null;
                        g.CostoTotale = null;
                        g.ContributoTotale = null;
                        g.ContributoRimanente = null;
                        g.Finanziabilita = null;
                        graduatoria_provider.Save(g);

                    }
                }

                //Salvo in tabella Graduatoria_bando_scorrimento  
                SiarLibrary.GraduatoriaBandoScorrimento scorr = new SiarLibrary.GraduatoriaBandoScorrimento();
                scorr.IdBando = Bando.IdBando;
                scorr.DataInizio = DateTime.Now;
                scorr.ScorrimentoCompletato = false;
                scorr.Operatore = Operatore.Utente.IdUtente;
                scorr_prov.Save(scorr);

                //Ricalcola graduatoria  
                //if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);  
                SiarLibrary.BandoConfigCollection cc = new SiarBLL.BandoConfigCollectionProvider().Find(Bando.IdBando, "ATTGRADPARZ", null, true, null);
                bool GraduatoriaParziale = false;
                if (cc.Count > 0 && bool.Parse(cc[0].Valore)) GraduatoriaParziale = true;
                graduatoria_provider.CalcolaGraduatoriaBando(Bando.IdBando, Operatore.Utente.CfUtente, GraduatoriaParziale);
                btnSalvaOrdinamento.Enabled = true;
                //btnCalcola.Enabled = true;  
                //btnGraduatoriaDefinitiva.Enabled = true;  

                ShowMessage("La graduatoria è stata riaperta e ricalcolata correttamente.");

            }
            catch (Exception ex) { ShowError(ex); }
        }


        protected void btnSalvaDescretoOrg_Click(object sender, EventArgs e)
        {
            string messaggio = "";
            try
            {
                messaggio = "";

                SiarBLL.BandoStoricoCollectionProvider bstorico_provider = new SiarBLL.BandoStoricoCollectionProvider(BandoProvider.DbProviderObj);
                SiarLibrary.BandoStoricoCollection bsc = bstorico_provider.Find(Bando.IdBando, "G");
                if (bsc.Count == 0)
                    throw new Exception("La graduatoria non è stata ancora resa definitiva. Impossibile continuare..");
                if (txtDataDecretoOrg.Text == "" || txtDataDecretoOrg.Text == null
                        || txtNumeroDecretoOrg.Text == "" || txtNumeroDecretoOrg.Text == null
                        || txtDescrizioneDecretoOrg.Text == "" || txtDescrizioneDecretoOrg.Text == null
                        || txtLinkEst.Text == "" || txtLinkEst.Text == null)
                    throw new Exception("Informazioni mancanti. Inserire tutti i dati relativi al Decreto/Atto.");
                //try 
                //{ 
                //    if (txtDataDecreto.Text == "" || txtDataDecreto.Text == null 
                //        || txtNumeroDecreto.Text == "" || txtNumeroDecreto.Text == null 
                //        || txtDescrizioneDecreto.Text == "" || txtDescrizioneDecreto.Text == null 
                //        || txtLinkEst.Text == "" || txtLinkEst.Text == null) 
                //        throw new Exception("Informazioni mancanti. Inserire tutti i dati relativi al Decreto/Atto."); 
                btnInserisciDecreto_Click(sender, e);
            }
            catch (Exception ex)
            {
                RegisterClientScriptBlock("chiudiPopupTemplate();");
                messaggio = "Attenzione! " + ex.Message;
                RegisterClientScriptBlock("alert('" + messaggio + "');");
            }
        }

        
        protected void btnCambioStato_Click(object sender, EventArgs e)
        {
            try
            {
                if(!responsabile)
                    throw new Exception("Atenzione! Solo il responsabile del bando è abilitato ad utilizzare la funzione.");

                int idProgetto;
                if (int.TryParse(hdnIdProgettoCambiostato.Value, out idProgetto))
                {
                    SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider();
                    SiarLibrary.Progetto progettoC = progetto_provider.GetById(idProgetto);

                    //controllo se ci sono domande di pagamento 
                    SiarLibrary.DomandaDiPagamentoCollection dp_coll = new SiarBLL.DomandaDiPagamentoCollectionProvider().Find(null, null, idProgetto, null);
                    if (dp_coll.Count > 0)
                    {
                        foreach (SiarLibrary.DomandaDiPagamento dp in dp_coll)
                        {
                            if (dp.SegnaturaAnnullamento == null || dp.SegnaturaAnnullamento == "")
                                throw new Exception("Sono presenti domande di pagamento. Impossibile riportare la domanda allo stato Acquisito. Procedere con l'annullamento delle domande di pagamento e riprovare.");
                        }
                    }

                    //controllo se ha un decreto di finanziabilita gia collegato
                    SiarLibrary.GraduatoriaProgettiAttiCollection atti_coll = graduatoria_atti_provider.Find(Bando.IdBando, progettoC.IdProgetto, null, true);
                    if(atti_coll.Count >0 && atti_coll[0].IdAtto != null)
                        throw new Exception("Sono presenti decreti di finanziabilità collegati al progetto. Impossibile riportare la domanda allo stato Acquisito. ");

                    string stato = "I";
                    SiarLibrary.ProgettoCollection progetti_correlati;

                    progetto_provider.CambioStatoProgetto(progettoC, stato, Operatore);
                    if (progettoC.IdProgIntegrato != null)
                    {
                        progetti_correlati = progetto_provider.Find(null, null, idProgetto, null, null, false, true);
                        foreach (SiarLibrary.Progetto p in progetti_correlati)
                            if (p.IdProgetto != p.IdProgIntegrato) progetto_provider.CambioStatoProgetto(p, stato, Operatore);
                    }
                    //cancello le righe di graduatoria_progettia_atti
                    SiarLibrary.GraduatoriaProgettiAttiCollection atti_grad_col = atti_grad_prov.Find(Bando.IdBando, null, null, null);
                    foreach(SiarLibrary.GraduatoriaProgettiAtti a in atti_grad_col)
                    {
                        if (a.IdAtto == null)
                            atti_grad_prov.Delete(a);
                    }

                    ShowMessage("Il progetto è stato riportato allo stato Acquisito. Ora è possibile procedere con l'istruttoria di ammissibilità.");

                }
                else
                    throw new Exception("Errore nella selezione del progetto.");

                hdnIdProgettoCambiostato.Value = "";

            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnModificaProgetto_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(responsabile || Operatore.Utente.Profilo == "Amministratore"))
                    throw new Exception("Attenzione! Solo il responsabile del bando è abilitato ad utilizzare la funzione.");

                //Se la graduatoria è 
                // - almeno definitiva e non riaperta per scorrimento 
                // - se sono il rup o amministratore 
                //posso modificare la graduatoria con decreto 
                if (!(Bando.OrdineStato >= 5
                    && !scorrimento))
                    throw new Exception("Attenzione! La graduatoria deve essere almeno definitiva e non riaperta per scorrimento");

                int idProgetto;
                if (int.TryParse(hdnIdProgettoModifica.Value, out idProgetto))
                {
                    ProgettoCollectionProvider progetto_provider = new ProgettoCollectionProvider();
                    ProgettoModificaGraduatoria = progetto_provider.GetById(idProgetto);
                    GraduatoriaProgettoModifica = null;

                    Response.Redirect(PATH_ISTRUTTORIA + "ModificaGraduatoriaProgetto.aspx");
                }
                else
                    throw new Exception("Errore nella selezione del progetto.");

                hdnIdProgettoModifica.Value = "";
            }
            catch (Exception ex) 
            { 
                ShowError(ex); 
            }
        }

        protected void btnSalvaOrdinamento_Click(object sender, EventArgs e)
        {
            if (!responsabile) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

            SiarBLL.GraduatoriaProgettiCollectionProvider grad_prov = new SiarBLL.GraduatoriaProgettiCollectionProvider();

            //salvo l'istanza della graduatoria  
            SiarBLL.GRADUATORIA istanza = new SiarBLL.GRADUATORIA(Bando.IdBando);
            SiarBLL.GraduatoriaProgettiStoricoCollectionProvider prov_storico_grad = new SiarBLL.GraduatoriaProgettiStoricoCollectionProvider();
            SiarLibrary.GraduatoriaProgettiStorico storico = new SiarLibrary.GraduatoriaProgettiStorico();
            storico.IdBando = Bando.IdBando;
            storico.Operatore = Operatore.Utente.IdUtente;
            storico.DataAnnullamento = DateTime.Now;
            storico.IstanzaGraduatoria = istanza.Serialize();
            prov_storico_grad.Save(storico);
            
            decimal contributo_rimanente = Bando.Importo;

            SiarLibrary.BandoConfigCollection cc = new SiarBLL.BandoConfigCollectionProvider().Find(Bando.IdBando, "ATTGRADPARZ", null, true, null);
            bool GraduatoriaParziale = false;
            if (cc.Count > 0 && bool.Parse(cc[0].Valore)) GraduatoriaParziale = true;

            string[] voci = ((SiarLibrary.Web.CheckColumn)dgProgetti.Columns[13]).GetSelected();
            if (voci.Length > 0)
            {
                for (int i = 0; i < voci.Length; i++)
                {
                    var id_prog = int.Parse(voci[i]);

                    // se progetto ha ordine stato uguale a 2 lo elimino dalla graduatoria
                    SiarLibrary.Progetto prog = new SiarBLL.ProgettoCollectionProvider().GetById(id_prog);
                    if (prog.OrdineStato == 2 && prog.CodStato != "N")
                    {
                        SiarLibrary.GraduatoriaProgetti grad_prog_elim = grad_prov.Find(prog.IdBando, prog.IdProgetto, null)[0];
                        grad_prov.Delete(grad_prog_elim);
                    }
                    else
                    {
                        //aggiorno punteggio, importo e contributo per ogni progetto. 
                        //in caso in cui l'utente non abbia aggiornato la graduatoria col pulsante calcola graduatoria
                        SiarLibrary.GraduatoriaProgetti gp = grad_prov.GetRigaProgettoUpdateCostoContributo(id_prog);
                        if (contributo_rimanente >= gp.ContributoTotale)
                        {
                            contributo_rimanente = contributo_rimanente - gp.ContributoTotale;
                            gp.ContributoRimanente = contributo_rimanente;
                            gp.Finanziabilita = "F";
                        }
                        else
                        {
                            if ((GraduatoriaParziale == true) && (contributo_rimanente > 0))
                            {
                                gp.ContributoTotale = contributo_rimanente;
                                contributo_rimanente = 0;
                                gp.ContributoRimanente = 0;
                                gp.Finanziabilita = "P";
                            }
                            else
                            {
                                contributo_rimanente = 0;
                                gp.ContributoRimanente = 0;
                                gp.Finanziabilita = "N";
                            }
                        }

                        gp.Ordine = i + 1;
                        grad_prov.Save(gp);
                    }
                }
            }
        }

        public Boolean VerificaProgettiRiportatiIndietro()
        {
            bool return_valore = false; 
            if (Bando.CodStato == "G" && Bando.Segnatura != null && Bando.IdAtto == null)
            {
                //verifico se un progetto sia stato riportato indietro
                
                SiarLibrary.GraduatoriaProgettiCollection grad_coll = graduatoria_provider.Find(Bando.IdBando, null, null);
                foreach (SiarLibrary.GraduatoriaProgetti gp in grad_coll)
                {
                    SiarLibrary.Progetto p = new SiarBLL.ProgettoCollectionProvider().GetById(gp.IdProgetto);
                    // se progetto ha stato positivo e inferiore alla finanziabilita
                    if (p.OrdineStato == 1 && p.OrdineFase < 4)
                        return_valore = true;
                }
            }
            return return_valore;
        }

        
    }
}



