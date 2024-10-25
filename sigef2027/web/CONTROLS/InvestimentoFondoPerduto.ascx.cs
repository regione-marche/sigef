using System;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;
using SiarLibrary.Web;


namespace web.CONTROLS
{
    public partial class InvestimentoFondoPerduto : System.Web.UI.UserControl
    {

        private SiarLibrary.PianoInvestimenti _investimento;
        public SiarLibrary.PianoInvestimenti Investimento
        {
            get { return _investimento; }
            set { _investimento = value; }
        }

        private bool _fase_istruttoria = false;
        public bool fase_istruttoria
        {
            set { _fase_istruttoria = value; }
        }

        /// <summary>
        /// elementi contenuti:
        /// priorita checkate: singola stringa con id priorita
        /// priorita con zoom: stringa con id|valore
        /// priorita numerica: stringa con id|valore
        /// priorita data : stringa con id|valore
        /// priorita testo: stringa con id|valore
        /// </summary>
        public System.Collections.ArrayList PrioritaInvestimento
        {
            get
            {
                System.Collections.ArrayList priorita_buffer = new System.Collections.ArrayList();
                foreach (string s in ((SiarLibrary.Web.CheckColumn)dgPriorita.Columns[2]).GetSelected())
                {
                    priorita_buffer.Add("c|" + s);
                }

                foreach (string s in Request.Form.AllKeys)
                {
                    // priorita x investimento con combo a piu' valori
                    if (s.StartsWith("hdnValoriPriorita") && !s.Contains("Sql"))
                    {
                        if (!string.IsNullOrEmpty(Request.Form[s].Trim()) && int.Parse(Request.Form[s]) > 0)
                        {
                            string hdn = s.Replace("hdnValoriPriorita", "hdnPriorita");
                            int idpriorita;
                            if (int.TryParse(Request.Form[hdn], out idpriorita))
                            {
                                priorita_buffer.Add("z|" + idpriorita.ToString() + "|" + Request.Form[s]);
                            }
                        }
                    }
                    // priorita x investimento con combo a piu' valori dinamica con query sql
                    if (s.StartsWith("hdnValoriPrioritaSql"))
                    {
                        if (!string.IsNullOrEmpty(Request.Form[s].Trim()))
                        {
                            string hdn = s.Replace("hdnValoriPrioritaSql", "hdnPrioritaSql");
                            int idpriorita;
                            if (int.TryParse(Request.Form[hdn], out idpriorita))
                            {
                                priorita_buffer.Add("q|" + idpriorita.ToString() + "|" + Request.Form[s]);
                            }
                        }
                    }
                    //  priorita ad input numerico
                    if (s.StartsWith("txtPrioritaNumerica") && s.EndsWith("_text"))
                    {
                        if (!string.IsNullOrEmpty(Request.Form[s].Trim()))
                        {
                            int idpriorita;
                            if (int.TryParse(s.Replace("txtPrioritaNumerica", "").Replace("_text", ""), out idpriorita))
                            {
                                priorita_buffer.Add("n|" + idpriorita.ToString() + "|" + Request.Form[s].Replace(".", ""));
                            }
                        }
                    }
                    // priorita data
                    if (s.StartsWith("txtPrioritaDatetime") && s.EndsWith("_text"))
                    {
                        if (!string.IsNullOrEmpty(Request.Form[s].Trim()))
                        {
                            int idpriorita;
                            if (int.TryParse(s.Replace("txtPrioritaDatetime", "").Replace("_text", ""), out idpriorita))
                            {
                                priorita_buffer.Add("d|" + idpriorita.ToString() + "|" + Request.Form[s]);
                            }
                        }
                    }
                    // priorita testo
                    if (s.StartsWith("txtPrioritaTestoSemplice") && s.EndsWith("_text"))
                    {
                        if (!string.IsNullOrEmpty(Request.Form[s].Trim()))
                        {
                            int idpriorita;
                            if (int.TryParse(s.Replace("txtPrioritaTestoSemplice", "").Replace("_text", ""), out idpriorita))
                            {
                                priorita_buffer.Add("t|" + idpriorita.ToString() + "|" + Request.Form[s].Replace("|", " "));
                            }
                        }
                    }
                    // priorita text area
                    if (s.StartsWith("txtPrioritaTestoArea") && s.EndsWith("_text"))
                    {
                        if (!string.IsNullOrEmpty(Request.Form[s].Trim()))
                        {
                            int idpriorita;
                            if (int.TryParse(s.Replace("txtPrioritaTestoArea", "").Replace("_text", ""), out idpriorita))
                            {
                                priorita_buffer.Add("a|" + idpriorita.ToString() + "|" + Request.Form[s].Replace(".", "").Replace("|", ""));
                            }
                        }
                    }
                }
                return priorita_buffer;
            }
        }

        private SiarLibrary.Progetto progetto_correlato;
        public SiarLibrary.Progetto ProgettoCorrelato
        {
            get { return progetto_correlato; }
            set { progetto_correlato = value; }
        }

        public SiarLibrary.Varianti Variante
        {
            get
            {
                if (_fase == "PVARIANTE")
                {
                    return ((SiarLibrary.Web.VariantePage)Page).Variante;
                }
                if (_fase == "IVARIANTE")
                {
                    return ((SiarLibrary.Web.IstruttoriaVariantePage)Page).Variante;
                }
                return null;
            }
        }

        private SiarLibrary.NullTypes.IntNT _idFascicolo;
        public int IdFascicolo
        {
            get { return _idFascicolo.Value; }
            set { _idFascicolo = value; }
        }

        private string _fase;
        public string Fase
        {
            set { _fase = value; }
        }

        private bool _ricaricaInvestimento;
        public bool RicaricaInvestimento
        {
            set { _ricaricaInvestimento = value; }
        }

        private bool _AltreFonti;
        public bool AltreFonti
        {
            set { _AltreFonti = value; }
        }

        public SiarLibrary.Operatore Operatore
        {
            get { return ((SiarLibrary.Web.MasterPage)Page.Master).Operatore; }
        }

        private void ShowMessage(string message)
        {
            ((SiarLibrary.Web.Page)Page).ShowMessage(message);
        }

        private void ShowError(string message)
        {
            ((SiarLibrary.Web.Page)Page).ShowError(message);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (_investimento == null)
            {
                if (_fase.FindValueIn("IDOMANDA", "IVARIANTE"))
                {
                    throw new Exception("Non è possibile inserire un nuovo investimento in questa fase.");
                }
                if (Session["IdInvestimento"] != null)
                {
                    SiarBLL.PianoInvestimentiCollectionProvider investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider();
                    int IdInvestimento = (int)Session["IdInvestimento"];
                    _investimento = investimenti_provider.GetById(IdInvestimento);
                }
                //if (hdnIdInvestimentoAttuale.Value != null && hdnIdInvestimentoAttuale.Value !="")
                //{
                //    SiarBLL.PianoInvestimentiCollectionProvider investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider();
                //    _investimento = investimenti_provider.GetById(Convert.ToInt32(hdnIdInvestimentoAttuale.Value));
                //}
                else
                {
                    _investimento = new SiarLibrary.PianoInvestimenti();
                    //inizializzo sempre quantita a 1 per nuovo investimenti! 
                    _investimento.Quantita = 1;
                }
            }
            if (_investimento.CodTipoInvestimento != null && _investimento.CodTipoInvestimento != 1)
            {
                throw new Exception("Tipologia di investimento non valida.");
            }
            if (_fase.FindValueIn("PVARIANTE", "IVARIANTE") && Variante == null)
            {
                throw new Exception("Nessuna variante valida trovata per l'investimento.");
            }
            if (_investimento != null && _investimento.IdProgetto != null)
            {
                //Rilassamento controlli in ammessibilità
                var progetto = new SiarBLL.ProgettoCollectionProvider().GetById(_investimento.IdProgetto);
                if (progetto != null && (progetto.Stato.Value.Equals("Ricevibile") || progetto.Stato.Value.Equals("Acquisito")))
                {
                    txtQuotaContributo.ReadOnly = false;
                    chckAbilitaModificaPercentualeAiuto.Enabled = true;
                }
                else
                    divAbilitaModificaPercentualeAiuto.Visible = false;
            }
            else
                divAbilitaModificaPercentualeAiuto.Visible = false;
        }

        protected override void OnPreRender(EventArgs e)
        {

            SiarLibrary.Bando disp_att = new SiarBLL.BandoCollectionProvider().GetById(progetto_correlato.IdBando);

            //se sono abilitate le aggregazioni verifico che siano state selezionate altrimenti 
            if (disp_att.Aggregazione)
            {
                
                SiarBLL.ProgettoNaturaSoggettoCollectionProvider natura_sogg_prov = new SiarBLL.ProgettoNaturaSoggettoCollectionProvider();
                SiarLibrary.ProgettoNaturaSoggettoCollection natura_coll = natura_sogg_prov.Find(progetto_correlato.IdProgetto, null, null);
                if (_fase == "PDOMANDA" && (natura_coll.Count == 0 || natura_coll[0].TipoNaturaSoggetto == null || natura_coll[0].TipoNaturaSoggetto == ""))
                {
                    ((SiarLibrary.Web.PrivatePage)Page).Redirect("PianoInvestimenti.aspx", "Non è stato selezionato nei requisiti impresa se il progetto è presentato in forma singola o aggregata. Impossibile continuare!", false);
                }
                else
                {
                    if (natura_coll[0].TipoNaturaSoggetto == "Aggregata")
                    {
                        if(natura_coll[0].IdAggregazione == null)
                            ((SiarLibrary.Web.PrivatePage)Page).Redirect("PianoInvestimenti.aspx", "Non è stata selezionata l'aggregazione nei requisiti impresa. Impossibile continuare!", false);
                        else
                        {
                            tbImpresaAggregazione.Visible = true;
                            ddlImpresaAggregazione.IdAggregazione = natura_coll[0].IdAggregazione;
                            ddlImpresaAggregazione.DataBind();
                            if (_investimento.IdImpresaAggregazione != null)
                                ddlImpresaAggregazione.SelectedValue = _investimento.IdImpresaAggregazione;
                        }
                    }

                }
            }


            SiarLibrary.BandoProgrammazioneCollection interventi = new SiarBLL.BandoProgrammazioneCollectionProvider().Find(progetto_correlato.IdBando, null, null, null);
            lstTipoIntervento.Items.Clear();
            lstTipoIntervento.Items.Add("");
            foreach (SiarLibrary.BandoProgrammazione bp in interventi)
            {
                ListItem li = new ListItem();
                li.Value = bp.IdProgrammazione;
                li.Text =bp.Codice+" "+ bp.Descrizione;
                li.Selected = ((!IsPostBack || _ricaricaInvestimento) && _investimento.IdInvestimento != null ?
                                li.Value == _investimento.IdProgrammazione :
                                li.Value == lstTipoIntervento.SelectedValue
                              );
                lstTipoIntervento.Items.Add(li);
            }

            
            // codici stp collegati all'operazione o azione (stesso livello del bando)
            //lstSTP.idProgrammazione = disp_att.IdProgrammazione;
            bool naturaCupNull = true;
            SiarBLL.BandoCollectionProvider gbBndPro = new SiarBLL.BandoCollectionProvider();
            lstSTP.DataValueField = "Voce_Spesa";
            lstSTP.DataTextField = "Descrizione_Voce_Spesa";
            lstSTP.NoBlankItem = true;
            if (!gbBndPro.IsFesr(ProgettoCorrelato.IdBando))
            {
                lstSTP.CommandText = string.Format(@"SELECT '00'                        AS Voce_Spesa,
                                                            'Nessun elemento trovato'   AS Descrizione_Voce_Spesa");
                lstSTP.DataBind();
            }
            else
            {
                lstSTP.CommandText = string.Format(@"SELECT v.Voce_Spesa,
                                                          v.Descrizione_Voce_Spesa
                                                   FROM dbo.vIgrue_Voci_Spesa v
                                                        INNER JOIN
                                                        dbo.Dati_Monitoraggio_Fesr d ON v.Codice_Natura_Cup = d.Cup_Natura
                                                        WHERE d.Id_Progetto = {0}", ProgettoCorrelato.IdProgetto);
                SiarBLL.DatiMonitoraggioFESRCollectionProvider dtmFesrPro = new SiarBLL.DatiMonitoraggioFESRCollectionProvider();
                SiarLibrary.DatiMonitoraggioFESRCollection dtmFesrColl = dtmFesrPro.Select(null, ProgettoCorrelato.IdProgetto.Value);
                foreach (SiarLibrary.DatiMonitoraggioFESR dtmFesr in dtmFesrColl)
                {
                    if (!string.IsNullOrEmpty(dtmFesr.IdCUPNatura.Value.ToString()))
                    {
                        naturaCupNull = false;
                    }
                }

                if (naturaCupNull)
                {
                    lblSTP.Visible = true;
                }

                if (ProgettoCorrelato.IdProgetto != null)
                {
                    lstSTP.DataBind();
                }
            }

            if ((!IsPostBack || _ricaricaInvestimento) && _investimento.CodStp != null)
            {
                lstSTP.SelectedValue = _investimento.CodStp;
            }

            // descrizione investimento
            bool richiedi_particella = false;
            if (!string.IsNullOrEmpty(lstTipoIntervento.SelectedValue))
            {
                SiarBLL.ZprogrammazioneCollectionProvider programmazione_provider = new SiarBLL.ZprogrammazioneCollectionProvider();
                SiarLibrary.Zprogrammazione operazione = programmazione_provider.GetById(lstTipoIntervento.SelectedValue);
                SiarLibrary.Zprogrammazione Azione = programmazione_provider.GetById(operazione.IdPadre);
                //Azione
                lstTipoAzione.Items.Clear();
                ListItem liAz = new ListItem();
                liAz.Value = Azione.Id;
                liAz.Text = Azione.Codice + " " + Azione.Descrizione;

                lstTipoAzione.Items.Add(liAz);

                //Obbiettivo di misura
                //while (operazione != null && !operazione.AttivazioneObMisura)
                //{
                //    operazione = programmazione_provider.GetById(operazione.IdPadre);
                //}
                //if (operazione != null)
                //{
                //    lstFinalita.IdProgrammazione = operazione.Id;
                //    lstFinalita.DataBind();
                //    if ((!IsPostBack || _ricaricaInvestimento) && _investimento.IdInvestimento != null)
                //    {
                //        lstFinalita.SelectedValue = _investimento.IdObiettivoMisura;
                //    }
                //}
                while (operazione != null && !operazione.AttivazioneObMisura)
                {
                    operazione = programmazione_provider.GetById(operazione.IdPadre);
                }
                if (operazione != null)
                {
                    lstFinalita.Items.Clear();
                    SiarLibrary.ZobMisuraCollection zob_coll = new SiarBLL.ZobMisuraCollectionProvider().Find(operazione.Id,null);
                    foreach(SiarLibrary.ZobMisura zob in zob_coll)
                    {
                        ListItem liZob = new ListItem();
                        liZob.Value = zob.Id;
                        liZob.Text = zob.Codice + " " + zob.Descrizione;
                        lstFinalita.Items.Add(liZob);
                        if ((!IsPostBack || _ricaricaInvestimento) && _investimento.IdInvestimento != null)
                        {
                            lstFinalita.SelectedValue = _investimento.IdObiettivoMisura;
                        }
                    }
                }


                lstCodificaInvestimenti.IdBando = progetto_correlato.IdBando;
                lstCodificaInvestimenti.IdIntervento = lstTipoIntervento.SelectedValue;
                lstCodificaInvestimenti.DataBind();
                if ((!IsPostBack || _ricaricaInvestimento) && _investimento.IdInvestimento != null)
                {
                    lstCodificaInvestimenti.SelectedValue = _investimento.IdCodificaInvestimento;
                }
                if (!string.IsNullOrEmpty(lstCodificaInvestimenti.SelectedValue))
                {
                    lstDettInvest.IdCodifica = lstCodificaInvestimenti.SelectedValue;
                    lstDettInvest.DataBind();
                    if ((!IsPostBack || _ricaricaInvestimento) && _investimento.IdInvestimento != null)
                    {
                        lstDettInvest.SelectedValue = _investimento.IdDettaglioInvestimento;
                    }
                    if (!string.IsNullOrEmpty(lstDettInvest.SelectedValue))
                    {
                        lstUnitaDiMisura.DataBind();
                        int id_dettaglio_investimenti;
                        int.TryParse(lstDettInvest.SelectedValue, out id_dettaglio_investimenti);
                        SiarLibrary.DettaglioInvestimenti d = new SiarBLL.DettaglioInvestimentiCollectionProvider().GetById(id_dettaglio_investimenti);
                        if (d != null && d.IdUdm != null)
                        {
                            lstUnitaDiMisura.SelectedValue = d.IdUdm; lstUnitaDiMisura.Enabled = false;
                        }
                        lstSpecInvest.IdDettaglio = lstDettInvest.SelectedValue;
                        lstSpecInvest.DataBind();
                        if ((!IsPostBack || _ricaricaInvestimento) && _investimento.IdInvestimento != null)
                        {
                            lstSpecInvest.SelectedValue = _investimento.IdSpecificaInvestimento;
                        }
                        richiedi_particella = lstDettInvest.SelectedItem != null && lstDettInvest.SelectedItem.Text.EndsWith(" (R)");
                    }
                }
                else
                    lstDettInvest.Items.Clear();

            }

            // settore produttivo e priorita            
            lstSettoreProduttivo.IdBando = progetto_correlato.IdBando;
            lstSettoreProduttivo.DataBind();
            lstPrioritaSettoriali.IdBando = progetto_correlato.IdBando;
            if ((!IsPostBack || _ricaricaInvestimento) && _investimento.IdInvestimento != null)
            {
                lstSettoreProduttivo.SelectedValue = _investimento.IdSettoreProduttivo;
                lstPrioritaSettoriali.SelectedValue = _investimento.IdPrioritaSettoriale;
                lstPrioritaSettoriali.IdSettoreProduttivo = _investimento.IdSettoreProduttivo ?? 0;
            }
            int id_settore_produttivo;
            int.TryParse(lstSettoreProduttivo.SelectedValue, out id_settore_produttivo);
            lstPrioritaSettoriali.IdSettoreProduttivo = id_settore_produttivo;
            lstPrioritaSettoriali.DataBind();

            // priorita x investimento            
            if (_ricaricaInvestimento)
            {
                ((SiarLibrary.Web.CheckColumn)dgPriorita.Columns[2]).ClearSelected();
            }
            SiarLibrary.SchedaXPrioritaCollection priorita_investimento = new SiarBLL.SchedaXPrioritaCollectionProvider().
            GetPrioritaXInvestimento(disp_att.IdSchedaValutazione, (_ricaricaInvestimento ? _investimento.IdInvestimentoOriginale : _investimento.IdInvestimento));
            dgPriorita.DataSource = priorita_investimento;
            if (priorita_investimento.Count == 0)
            {
                dgPriorita.Titolo = "Nessun elemento trovato.";
            }
            else
            {
                dgPriorita.ItemDataBound += new DataGridItemEventHandler(dgPriorita_ItemDataBound);
            }
            dgPriorita.DataBind();

            if (!IsPostBack || _ricaricaInvestimento)
            {
                txtDescIntervento.Text = _investimento.Descrizione;
                txtQuantita.Text = _investimento.Quantita;
                txtCostoInvestimento.Text = _investimento.CostoInvestimento;
                txtSpeseTecniche.Text = _investimento.SpeseGenerali;
                lstUnitaDiMisura.SelectedValue = _investimento.IdUnitaMisura;
                if (_investimento.IdInvestimento != null)
                {
                    chkNoConfinanziamento.Checked = _investimento.NonCofinanziato;
                    txtCostoTotale.Text = (_investimento.CostoInvestimento.Value + _investimento.SpeseGenerali).ToString();
                }
                txtQuotaContributo.Text = _investimento.QuotaContributoRichiesto;
                txtContributoTotale.Text = _investimento.ContributoRichiesto;

                if (_investimento.QuotaContributoRichiesto == -1.00)
                    trErroreSQL.Visible = true;
                else
                    trErroreSQL.Visible = false;

                txtContributoInvestimento.Text = _investimento.AdditionalAttributes["ContributoInvestimento"];
                txtContributoSpese.Text = _investimento.AdditionalAttributes["ContributoSpeseTecniche"];
                txtMaxSpese.Text = _investimento.AdditionalAttributes["MaxSpeseTecniche"];
                txtValutazioneIstruttore.Text = _investimento.ValutazioneInvestimento;
                txtContributoAltreFonti.Text = _investimento.ContributoAltreFonti;
                txtQuotaContributoAltreFonti.Text = _investimento.QuotaContributoAltreFonti;
            }
            else
                txtSpeseTecniche.Text = "0";
            if (!(progetto_correlato.CodStato == "P" || (_fase == "PVARIANTE" && ((SiarLibrary.Web.PrivatePage)Page).TipoModifica == 2)))
            {
                string scpt_storico_investimento = "alert('Nessun precedente investimento trovato.');";
                if (_investimento.IdInvestimentoOriginale != null)
                {
                    scpt_storico_investimento = "mostraStoricoInvestimento(" + _investimento.IdInvestimentoOriginale + ");";
                }
                btnVisualizzaOriginale.Attributes.Add("onclick", scpt_storico_investimento);
                tableValutazione.Visible = true;
                txtValutazioneIstruttore.ReadOnly = !((SiarLibrary.Web.PrivatePage)Page).AbilitaModifica;
            }

            //strumenti finanziari
            string UtStrumFin = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_UtStrumFin(progetto_correlato.IdBando);
            if (UtStrumFin == "True")
            {
                AltreFonti = true;
                trAltreFonti.Visible = true;
            }
            else
            {
                AltreFonti = false;
                trAltreFonti.Visible = false;
            }
            //Per SISMA art 20BIS modifica LABEL
            //pregresso
            bool LabelSisma = false;
            string StrLabelSisma = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_SismaLAbel(progetto_correlato.IdBando);
            if (StrLabelSisma == "True")
                LabelSisma = true;
            if (LabelSisma)
                lbCostoInvestimento.Text = "Riduzione fatturato:";
            else
                lbCostoInvestimento.Visible = false;






            base.OnPreRender(e);
        }

        void dgPriorita_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (dgi.ItemType != ListItemType.Header && dgi.ItemType != ListItemType.Footer)
            {
                SiarLibrary.SchedaXPriorita sxp = (SiarLibrary.SchedaXPriorita)dgi.DataItem;
                if (sxp.PluriValore)
                {
                    string hdn = "hdnPriorita" + sxp.IdPriorita;
                    string hdnval = "hdnValoriPriorita" + sxp.IdPriorita;
                    string lbl = "labelValoriPriorita" + sxp.IdPriorita;

                    SiarLibrary.NullTypes.IntNT ValorePriorita = new SiarLibrary.NullTypes.IntNT(Request.Form[hdnval]);
                    SiarLibrary.NullTypes.StringNT TestoPriorita = new SiarLibrary.NullTypes.StringNT(Request.Form[lbl]);
                    if (!IsPostBack || _ricaricaInvestimento)
                    {
                        int id_valore;
                        if (int.TryParse(sxp.AdditionalAttributes["IdValore"], out id_valore))
                        {
                            ValorePriorita = id_valore;
                            TestoPriorita = sxp.AdditionalAttributes["PlurivaloreDescrizione"];
                        }
                    }
                    e.Item.Cells[2].Text = "<span><svg class='icon m-1' style='cursor: pointer;' onclick=\"SNCZoomPlurivalore(" + sxp.IdPriorita + ",'getPlurivaloriRequisitiDomanda',selezionaPlurivalore,0);\" alt='Apri il popup di selezione del valore'><use href='/web/bootstrap-italia/svg/sprites.svg#it-list'></use></svg>" +
                        "<svg class='icon m-1' style='cursor: pointer;' onclick='deselezionaPlurivalore("
                        + sxp.IdPriorita + ");' alt='Deseleziona'><use href='/web/bootstrap-italia/svg/sprites.svg#it-close-big'></use></svg></span>";
                    e.Item.Cells[3].Text = "<input type='hidden' id='" + hdn + "' name='" + hdn + "' value='" + sxp.IdPriorita + "' />" +
                        "<input type='hidden' id='" + hdnval + "' name='" + hdnval + "' value='" + ValorePriorita + " ' />" +
                        "<input type='hidden' id='" + lbl + "' name='" + lbl + "' value=\"" + TestoPriorita + "\">" +
                        "<span id='" + lbl + "_text' name='" + lbl + "_text' style='font-weight:bold'>" + TestoPriorita + "</span>";
                }
                else if (sxp.PluriValoreSql)
                {
                    string hdn = "hdnPrioritaSql" + sxp.IdPriorita;
                    string hdnval = "hdnValoriPrioritaSql" + sxp.IdPriorita;
                    string lbl = "labelValoriPrioritaSql" + sxp.IdPriorita;

                    SiarLibrary.NullTypes.StringNT ValorePriorita = new SiarLibrary.NullTypes.StringNT(Request.Form[hdnval]);
                    SiarLibrary.NullTypes.StringNT TestoPriorita = new SiarLibrary.NullTypes.StringNT(Request.Form[lbl]);
                    //bool deleted = false;
                    if (!IsPostBack || _ricaricaInvestimento)
                    {
                        if (!string.IsNullOrEmpty(sxp.AdditionalAttributes["ValTesto"]))
                        {
                            ValorePriorita = sxp.AdditionalAttributes["ValTesto"];
                            SiarLibrary.ValoriPrioritaCollection cc = new SiarBLL.ValoriPrioritaCollectionProvider().GetValoriPrioritaSql(progetto_correlato.IdProgIntegrato
                                ?? progetto_correlato.IdProgetto, _fase_istruttoria, sxp.IdPriorita, ValorePriorita);
                            if (cc.Count > 0) TestoPriorita = cc[0].Descrizione;  // ------> testo da valorizzare se il requisito e' gia' stato salvato
                            else
                            {
                                ValorePriorita = null;
                                TestoPriorita = null;
                            }
                        }
                    }

                    //id_progetto, fase_istruttoria, id_requisito,search_method,select_js_method,page_index
                    e.Item.Cells[2].Text = "<span><svg class='icon m-1' style='cursor: pointer;' onclick=\"SNCZoomPlurivaloreSql(" + (progetto_correlato.IdProgIntegrato ?? progetto_correlato.IdProgetto)
                        + ", " + _fase_istruttoria.ToString().ToLower() + " ," + sxp.IdPriorita
                        + ",'getPlurivaloriSql',selezionaPlurivaloreSql,0);\" alt='Apri il popup di selezione del valore'><use href='/web/bootstrap-italia/svg/sprites.svg#it-list'></use></svg>" +
                        "<svg class='icon m-1' style='cursor: pointer;' onclick='deselezionaPlurivaloreSql("
                          + sxp.IdPriorita + ");' alt='Deseleziona'><use href='/web/bootstrap-italia/svg/sprites.svg#it-close-big'></use></svg></span>";
                    e.Item.Cells[3].Text = "<input type='hidden' id='" + hdn + "' name='" + hdn + "' value='" + sxp.IdPriorita + "' />" +
                        "<input type='hidden' id='" + hdnval + "' name='" + hdnval + "' value='" + ValorePriorita + "' />" +
                        "<input type='hidden' id='" + lbl + "' name='" + lbl + "' value=\"" + TestoPriorita + "\">" +
                        "<span id='" + lbl + "_text' name='" + lbl + "_text' style='font-weight:bold'>" + TestoPriorita + "</span>";
                }
                else if (sxp.InputNumerico)
                {
                    string nome_casella = "txtPrioritaNumerica" + sxp.IdPriorita;
                    string valore = Request.Form[nome_casella + "_text"];
                    if (!IsPostBack || _ricaricaInvestimento) valore = sxp.AdditionalAttributes["Valore"];
                    e.Item.Cells[2].Text = "";
                    e.Item.Cells[3].Text = "<span id=\"" + nome_casella + "\" class=\"CurrencyBox\" >"
                        + "<input name=\"" + nome_casella + "_text\" type=\"text\" id=\"" + nome_casella
                        + "_text\" value='" + valore + "'/></span>";
                }
                else if (sxp.Datetime)
                {
                    string nome_casella = "txtPrioritaDatetime" + sxp.IdPriorita;
                    string valore = Request.Form[nome_casella + "_text"];
                    if (!IsPostBack || _ricaricaInvestimento) valore = sxp.AdditionalAttributes["ValData"];
                    e.Item.Cells[2].Text = "";
                    e.Item.Cells[3].Text = "<span id=\"" + nome_casella + "\" class=\"DataBox\" >"
                        + "<input name=\"" + nome_casella + "_text\" type=\"text\" id=\"" + nome_casella
                        + "_text\" value='" + valore + "'/></span>";
                }
                else if (sxp.TestoSemplice)
                {
                    string nome_casella = "txtPrioritaTestoSemplice" + sxp.IdPriorita;
                    string valore = Request.Form[nome_casella + "_text"];
                    if (!IsPostBack || _ricaricaInvestimento) valore = sxp.AdditionalAttributes["ValTesto"];
                    e.Item.Cells[2].Text = "";
                    e.Item.Cells[3].Text = "<span id=\"" + nome_casella + "\" class=\"TextBox\" >"
                        + "<input name=\"" + nome_casella + "_text\" type=\"text\" id=\"" + nome_casella
                        + "_text\" value='" + valore + "'/></span>";
                }
                else if (sxp.TestoArea)
                {
                    string nome_casella = "txtPrioritaTestoArea" + sxp.IdPriorita;
                    string valore = Request.Form[nome_casella + "_text"];
                    if (!IsPostBack || _ricaricaInvestimento) valore = sxp.AdditionalAttributes["ValTesto"];
                    e.Item.Cells[2].Text = "";
                    e.Item.Cells[3].Text = "<span id='" + nome_casella + "' class='TextArea'><textarea id='" + nome_casella + "_text' name='"
                        + nome_casella + "_text' cols='20' rows='3'>" + valore + "</textarea></span>";
                }
                else
                {
                    int id_investimento;
                    if ((!IsPostBack || _ricaricaInvestimento) && int.TryParse(sxp.AdditionalAttributes["IdInvestimento"], out id_investimento))
                        e.Item.Cells[2].Text = e.Item.Cells[2].Text.Replace("<input type='checkbox'", "<input type='checkbox' checked");
                }
            }
        }

        protected void btnCalcolaContributo_Click(object sender, EventArgs e)
        {
            try
            {
                CalcolaContributoInvestimento(false);

                //hdnIdInvestimentoAttuale.Value = _investimento.IdInvestimento.ToString();

                if (Request.QueryString["idinv"] == null)
                {
                    int id = _investimento.IdInvestimento;
                    Session.Add("IdInvestimento", id);
                }

                ShowMessage("Contributo calcolato ed investimento salvato correttamente.");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        public void CalcolaContributoInvestimento(bool salva)
        {
            if(lstFinalita.SelectedValue == null || lstTipoIntervento.SelectedValue == null || lstSTP.SelectedValue == null)
                throw new Exception("Attenzione, compilare i campi relativi al tipo di intervento.");
            if(lstCodificaInvestimenti.SelectedValue == null || lstDettInvest.SelectedValue == null || txtDescIntervento.Text == null || txtDescIntervento.Text == "")
                throw new Exception("Attenzione, compilare i campi relativi alla descrizione dell'intervento.");
            if (txtCostoInvestimento.Text == "" || txtCostoInvestimento.Text == null)
                throw new Exception("Inserire il costo dell'investimento.");
            if (txtQuantita.Text == "" || txtQuantita.Text == null)
                throw new Exception("Inserire la quantità.");
            if(lstUnitaDiMisura.SelectedValue == null)
                throw new Exception("Inserire l'unità di misura.");

            SiarLibrary.Bando bando = new SiarBLL.BandoCollectionProvider().GetById(progetto_correlato.IdBando);

            int? id_impresa_aggregazione = null;
            if(bando.Aggregazione)
            {
                SiarLibrary.ProgettoNaturaSoggettoCollection natura_coll = new SiarBLL.ProgettoNaturaSoggettoCollectionProvider().Find(progetto_correlato.IdProgetto, null, null);
                if(natura_coll[0].TipoNaturaSoggetto == "Aggregata")
                {
                    if (ddlImpresaAggregazione.SelectedValue == "" || ddlImpresaAggregazione.SelectedValue == null)
                        throw new Exception("Attenzione, selezionare l'impresa dell'aggregazione che ha in carico l'investimento.");
                    else
                        id_impresa_aggregazione = Convert.ToInt32( ddlImpresaAggregazione.SelectedValue);
                }
                    
            }

            SiarBLL.PianoInvestimentiCollectionProvider investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider();
            //SiarBLL.LocalizzazioneInvestimentoCollectionProvider localizzazione_provider = new SiarBLL.LocalizzazioneInvestimentoCollectionProvider(investimenti_provider.DbProviderObj);
            SiarBLL.PrioritaXInvestimentiCollectionProvider priorita_provider = new SiarBLL.PrioritaXInvestimentiCollectionProvider(investimenti_provider.DbProviderObj);
            var modifica_perc_abilitata = false; //serve per verificare se in istruttoria ammissibilità è stata autorizzata la modifica della percentuale aiuto

            try
            {
                if (_fase != "PDOMANDA" && _fase != "PVARIANTE")
                    investimenti_provider.DbProviderObj.BeginTran();

                if (_investimento != null && _investimento.IdProgetto != null)
                {
                    //Rilassamento controlli in ammessibilità
                    var progetto = new SiarBLL.ProgettoCollectionProvider().GetById(_investimento.IdProgetto);
                    if (progetto != null && (progetto.Stato.Value.Equals("Ricevibile") || progetto.Stato.Value.Equals("Acquisito")) && chckAbilitaModificaPercentualeAiuto.Checked == true)
                    {
                        var aut_modifica = new SiarLibrary.AutModificaPercAiuto();
                        aut_modifica.IdInvestimento = _investimento.IdInvestimento;
                        aut_modifica.CfInserimento = Operatore.Utente.CfUtente;
                        aut_modifica.DataInserimento = DateTime.Now;
                        aut_modifica.CfModifica = Operatore.Utente.CfUtente;
                        aut_modifica.DataModifica = DateTime.Now;
                        aut_modifica.CostoInvestimentoPrecedente = _investimento.CostoInvestimento;
                        aut_modifica.CostoInvestimentoAutorizzato = txtCostoInvestimento.Text;
                        aut_modifica.QuantitaPrecedente = _investimento.Quantita;
                        aut_modifica.QuantitaAutorizzata = txtQuantita.Text;
                        aut_modifica.PercPrecedente = _investimento.QuotaContributoRichiesto;
                        aut_modifica.PercAutorizzata = txtQuotaContributo.Text;
                        new SiarBLL.AutModificaPercAiutoCollectionProvider().Save(aut_modifica);

                        modifica_perc_abilitata = true;
                    }
                }

                _investimento.IdProgetto = progetto_correlato.IdProgetto;
                _investimento.IdProgrammazione = lstTipoIntervento.SelectedValue;
                _investimento.Descrizione = txtDescIntervento.Text;
                _investimento.CodStp = lstSTP.SelectedValue;
                _investimento.CodTipoInvestimento = 1;
                _investimento.IdUnitaMisura = lstUnitaDiMisura.SelectedValue;
                _investimento.Quantita = txtQuantita.Text;
                _investimento.IdObiettivoMisura = lstFinalita.SelectedValue;
                _investimento.IdCodificaInvestimento = lstCodificaInvestimenti.SelectedValue;
                _investimento.IdDettaglioInvestimento = lstDettInvest.SelectedValue;
                _investimento.IdSpecificaInvestimento = lstSpecInvest.SelectedValue;
                _investimento.IdSettoreProduttivo = lstSettoreProduttivo.SelectedValue;
                _investimento.IdPrioritaSettoriale = lstPrioritaSettoriali.SelectedValue;
                _investimento.IdImpresaAggregazione = id_impresa_aggregazione;
                
                _investimento.CostoInvestimento = txtCostoInvestimento.Text;

                _investimento.SpeseGenerali = txtSpeseTecniche.Text;
                _investimento.NonCofinanziato = chkNoConfinanziamento.Checked;

                if (_investimento.QuotaContributoRichiesto == null)
                {
                    // impongo cosi' perche' non nulla sul db, poi tanto la ricalcolo
                    _investimento.QuotaContributoRichiesto = 0;
                }
                if (_fase.FindValueIn("IDOMANDA", "IVARIANTE"))
                {
                    _investimento.ValutazioneInvestimento = txtValutazioneIstruttore.Text;
                    _investimento.Ammesso = true;
                    _investimento.DataValutazione = DateTime.Now;
                    _investimento.Istruttore = Operatore.Utente.CfUtente;
                }
                else if (_fase == "PVARIANTE")
                {
                    if (_investimento.IdInvestimento == null)
                    {
                        _investimento.CodVariazione = "N";
                    }
                    _investimento.IdVariante = Variante.IdVariante;
                    _investimento.DataVariazione = DateTime.Now;
                    _investimento.OperatoreVariazione = Operatore.Utente.CfUtente;
                }
                investimenti_provider.Save(_investimento);
                
                bool AltreFonti = false;
                string UtStrumFin = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_UtStrumFin(progetto_correlato.IdBando);
                if (UtStrumFin == "True")
                    AltreFonti = true;

                // priorita x investimento
                priorita_provider.DeleteCollection(priorita_provider.Find(null, _investimento.IdInvestimento, null, null));
                foreach (string s in PrioritaInvestimento)
                {
                    string[] valori_priorita = s.Split('|');
                    SiarLibrary.PrioritaXInvestimenti pxi = new SiarLibrary.PrioritaXInvestimenti();
                    pxi.IdInvestimento = _investimento.IdInvestimento;
                    pxi.IdPriorita = valori_priorita[1];
                    if (valori_priorita[0] == "z") pxi.IdValore = valori_priorita[2];
                    else if (valori_priorita[0] == "q") pxi.ValTesto = valori_priorita[2];
                    else if (valori_priorita[0] == "n") pxi.Valore = valori_priorita[2];
                    else if (valori_priorita[0] == "d") pxi.ValData = valori_priorita[2];
                    else if (valori_priorita[0] == "t") pxi.ValTesto = valori_priorita[2];
                    else if (valori_priorita[0] == "a") pxi.ValTesto = valori_priorita[2];
                    else pxi.Scelto = true;
                    priorita_provider.Save(pxi);
                }


                if (_investimento.NonCofinanziato)
                {
                    _investimento.QuotaContributoRichiesto = 0;
                    _investimento.ContributoRichiesto = 0;

                    if (AltreFonti)
                    {
                        _investimento.ContributoAltreFonti = 0;
                        _investimento.QuotaContributoAltreFonti = 0;
                    }
                    
                }
                else
                {
                    // salvo contributo e quota
                    decimal? QuotaContributo = null ;
                    if (txtQuotaContributo.Text != null && txtQuotaContributo.Text != "" && modifica_perc_abilitata)
                        QuotaContributo = Convert.ToDecimal(txtQuotaContributo.Text);

                    investimenti_provider.CalcoloContributoInvestimento(ref _investimento, _fase, QuotaContributo );
                    if (!AltreFonti)
                    {
                        _investimento.ContributoAltreFonti = null;
                        _investimento.QuotaContributoAltreFonti = null;
                    }
                }
                investimenti_provider.Save(_investimento);
                // popolo i campi
                txtQuotaContributo.Text = _investimento.QuotaContributoRichiesto;
                txtContributoTotale.Text = _investimento.ContributoRichiesto;
                txtContributoInvestimento.Text = _investimento.AdditionalAttributes["ContributoInvestimento"];
                txtContributoSpese.Text = _investimento.AdditionalAttributes["ContributoSpeseTecniche"];
                txtMaxSpese.Text = _investimento.AdditionalAttributes["MaxSpeseTecniche"];
                txtCostoTotale.Text = (_investimento.CostoInvestimento.Value + _investimento.SpeseGenerali).ToString();
                
                if (_investimento.QuotaContributoRichiesto == -1.00)
                    trErroreSQL.Visible = true;
                else
                    trErroreSQL.Visible = false;

                txtContributoAltreFonti.Text = _investimento.ContributoAltreFonti;
                txtQuotaContributoAltreFonti.Text = _investimento.QuotaContributoAltreFonti;


                // controllo i dati varianti dall'investimento originale
                if (_fase == "IDOMANDA")
                {
                    SiarLibrary.PianoInvestimenti investimento_originale = investimenti_provider.GetById(_investimento.IdInvestimentoOriginale);
                    if (investimento_originale == null)
                    {
                        throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.GenericoConLink);
                    }
                    //Rilassamento controlli in ammessibilità
                    var progetto = new SiarBLL.ProgettoCollectionProvider().GetById(_investimento.IdProgetto);
                    if (investimento_originale.CostoInvestimento < _investimento.CostoInvestimento 
                        && (!progetto.Stato.Value.Equals("Ricevibile") && !progetto.Stato.Value.Equals("Acquisito")))
                    {
                        throw new Exception("Non è possibile aumentare il costo dell`investimento oltre l`ammontare richiesto dal beneficiario.");
                    }
                    if (investimento_originale.SpeseGenerali < _investimento.SpeseGenerali)
                    {
                        throw new Exception("Non è possibile aumentare le spese tecniche dell`investimento oltre l`ammontare richiesto dal beneficiario.");
                    }
                    if ( _investimento.ValutazioneInvestimento == null &&
                        (investimento_originale.IdProgrammazione != _investimento.IdProgrammazione
                            || investimento_originale.Descrizione != _investimento.Descrizione
                            || investimento_originale.CodStp != _investimento.CodStp
                            || investimento_originale.IdUnitaMisura != _investimento.IdUnitaMisura
                            || investimento_originale.Quantita != _investimento.Quantita
                            || investimento_originale.CostoInvestimento != _investimento.CostoInvestimento
                            || investimento_originale.SpeseGenerali != _investimento.SpeseGenerali
                            || investimento_originale.ContributoRichiesto != _investimento.ContributoRichiesto
                            || investimento_originale.QuotaContributoRichiesto != _investimento.QuotaContributoRichiesto
                            || investimento_originale.IdSettoreProduttivo != _investimento.IdSettoreProduttivo
                            || investimento_originale.IdObiettivoMisura != _investimento.IdObiettivoMisura
                            || investimento_originale.IdCodificaInvestimento != _investimento.IdCodificaInvestimento
                            || investimento_originale.IdDettaglioInvestimento != _investimento.IdDettaglioInvestimento
                            || investimento_originale.IdSpecificaInvestimento != _investimento.IdSpecificaInvestimento
                            || investimento_originale.IdPrioritaSettoriale != _investimento.IdPrioritaSettoriale))
                    {
                        throw new Exception("E` obbligatorio indicare nella valutazione dell`investimento qualsiasi modifica effettuata in corso di istruttoria.");
                    }
                    // per ora tralascio il controllo sulla localizzazione e le priorita variate
                }
                if (_fase.FindValueIn("PVARIANTE", "IVARIANTE"))
                {
                    if (_investimento.CodVariazione != "N")
                    {
                        decimal pagamenti_investimento = investimenti_provider.GetContributoPagamentiRichiestiInvestimento(_investimento.IdInvestimento,
                                                                                                                            Variante.Segnatura == null ?
                                                                                                                            null :
                                                                                                                            Variante.DataModifica);
                        if (_investimento.CodVariazione == "D")
                        {
                            // calcolo il contributo dell'altro investimento duplicato
                            SiarLibrary.PianoInvestimentiCollection investimenti_fratelli = investimenti_provider.Find(null,
                                                                                                                       _investimento.IdProgetto,
                                                                                                                       null,
                                                                                                                       null,
                                                                                                                       null,
                                                                                                                       null,
                                                                                                                       _investimento.IdInvestimentoOriginale
                                                                                                                       ).FiltroVariante(Variante.IdVariante);
                            foreach (SiarLibrary.PianoInvestimenti i in investimenti_fratelli)
                            {
                                if (i.IdInvestimento != _investimento.IdInvestimento)
                                {
                                    pagamenti_investimento -= i.ContributoRichiesto;
                                }
                            }
                        }
                        if (_investimento.ContributoRichiesto < pagamenti_investimento)
                        {
                            throw new Exception("Impossibile diminuire il contributo richiesto sotto la soglia del`ammontare rendicontato nelle domande di pagamento precedenti la presente richiesta.");
                        }
                    }

                    // codice variazione (valori possibili: A,E,M,N,V)
                    string cod_variazione_investimento = null;
                    if (!_investimento.CodVariazione.FindValueIn("A", "N", "D", "R"))
                    {
                        SiarLibrary.PianoInvestimenti investimento_originale = investimenti_provider.GetById(_investimento.IdInvestimentoOriginale);
                        if (investimento_originale == null)
                        {
                            throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.GenericoConLink);
                        }
                        decimal totale_originale = investimento_originale.CostoInvestimento + investimento_originale.SpeseGenerali.Value;
                        decimal totale_attuale = _investimento.CostoInvestimento + _investimento.SpeseGenerali.Value;

                        if (totale_attuale > totale_originale)
                        {
                            cod_variazione_investimento = "M";
                        }
                        else if (totale_attuale < totale_originale)
                        {
                            cod_variazione_investimento = "E";
                        }
                        else if (investimento_originale.IdProgrammazione != _investimento.IdProgrammazione
                                || investimento_originale.Descrizione != _investimento.Descrizione
                                || investimento_originale.CodStp != _investimento.CodStp
                                || investimento_originale.IdUnitaMisura != _investimento.IdUnitaMisura
                                || investimento_originale.Quantita != _investimento.Quantita
                                || investimento_originale.CostoInvestimento != _investimento.CostoInvestimento
                                || investimento_originale.SpeseGenerali != _investimento.SpeseGenerali
                                || investimento_originale.ContributoRichiesto != _investimento.ContributoRichiesto
                                || investimento_originale.QuotaContributoRichiesto != _investimento.QuotaContributoRichiesto
                                || investimento_originale.IdSettoreProduttivo != _investimento.IdSettoreProduttivo
                                || investimento_originale.IdObiettivoMisura != _investimento.IdObiettivoMisura
                                || investimento_originale.IdCodificaInvestimento != _investimento.IdCodificaInvestimento
                                || investimento_originale.IdDettaglioInvestimento != _investimento.IdDettaglioInvestimento
                                || investimento_originale.IdSpecificaInvestimento != _investimento.IdSpecificaInvestimento
                                || investimento_originale.IdPrioritaSettoriale != _investimento.IdPrioritaSettoriale)
                        {
                            cod_variazione_investimento = "V";
                        }
                        // commentato: il controllo sulle variazioni piu' complesse lo faccio in seguito
                        //if (string.IsNullOrEmpty(cod_variazione_investimento) && (priorita_variate || particelle_variate)) cod_variazione_investimento = "V";
                        _investimento.CodVariazione = cod_variazione_investimento;
                    }
                    investimenti_provider.Save(_investimento);
                    if (_fase == "PVARIANTE")
                    {
                        new SiarBLL.VariantiCollectionProvider(investimenti_provider.DbProviderObj).AggiornaVariante(Variante, Operatore);
                    }
                    else
                    {
                        new SiarBLL.VariantiCollectionProvider(investimenti_provider.DbProviderObj).AggiornaVarianteIstruttoria(Variante, Operatore);
                    }
                }
                //if (salva)
                //{
                //    investimenti_provider.DbProviderObj.Commit();
                //}
                //else
                //{
                //    investimenti_provider.DbProviderObj.Rollback();
                //}

                if (_fase != "PDOMANDA" && _fase != "PVARIANTE")
                    investimenti_provider.DbProviderObj.Commit();

                SiarLibrary.NullTypes.StringNT codice_troncamento = new SiarLibrary.NullTypes.StringNT(_investimento.AdditionalAttributes["CodTroncamento"]);
                SiarLibrary.NullTypes.DecimalNT contributo_non_troncato = new SiarLibrary.NullTypes.DecimalNT(_investimento.AdditionalAttributes["ContributoNonTroncato"]);
                if (codice_troncamento != null)
                {
                    string messaggio_troncamento = "<br />Attenzione!<br /><br />Il contributo calcolato per l'investimento ammonta a "
                                + string.Format("{0:c}", contributo_non_troncato.Value) + "<br />superando ";
                    switch (codice_troncamento.Value)
                    {
                        case "I":
                            messaggio_troncamento += "il totale ammissibile per l'intervento. Verrà troncato sul totale.";
                            break;
                        case "D":
                            messaggio_troncamento += "il massimo ammissibile per DOMANDA. Verrà troncato sul totale.";
                            break;
                        case "O":
                            messaggio_troncamento += "il contributo richiesto per l'investimento. E` stato troncato.";
                            break;
                        case "M":
                            messaggio_troncamento += "il massimo ammissibile a finanziamento. E' stato troncato.";
                            break;
                        case "P":
                            messaggio_troncamento += "il contributo ammesso in precedenza per l'investimento. E` stato troncato.";
                            break;
                    }
                    rowContributoMessaggio.InnerHtml = messaggio_troncamento + "<br /><br />";
                }
            }
            catch (Exception ex)
            {
                investimenti_provider.DbProviderObj.Rollback();
                throw ex;
            }
        }
    }
}