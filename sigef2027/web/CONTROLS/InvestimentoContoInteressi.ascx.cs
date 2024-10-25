using System;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;

namespace web.CONTROLS
{
    public partial class InvestimentoContoInteressi : System.Web.UI.UserControl
    {
        private SiarLibrary.PianoInvestimenti _investimento;
        public SiarLibrary.PianoInvestimenti Investimento
        {
            get { return _investimento; }
            set { _investimento = value; }
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
                if (_fase == "PVARIANTE") return ((SiarLibrary.Web.VariantePage)Page).Variante;
                if (_fase == "IVARIANTE") return ((SiarLibrary.Web.IstruttoriaVariantePage)Page).Variante;
                return null;
            }
        }

        private string _fase;
        public string Fase { set { _fase = value; } }

        private bool _ricaricaInvestimento;
        public bool RicaricaInvestimento { set { _ricaricaInvestimento = value; } }

        public SiarLibrary.Operatore Operatore { get { return ((SiarLibrary.Web.MasterPage)Page.Master).Operatore; } }
        private void ShowMessage(string message) { ((SiarLibrary.Web.Page)Page).ShowMessage(message); }
        private void ShowError(string message) { ((SiarLibrary.Web.Page)Page).ShowError(message); }

        decimal max_quota_contributo/*, max_importo_contributo*/;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (_investimento == null)
            {
                if (_fase.FindValueIn("IDOMANDA", "IVARIANTE")) throw new Exception("Non è possibile inserire un nuovo investimento in questa fase.");
                _investimento = new SiarLibrary.PianoInvestimenti();
            }
            if (_investimento.CodTipoInvestimento != null && _investimento.CodTipoInvestimento != 2) throw new Exception("Tipologia di investimento non valida.");
            if (_fase.FindValueIn("PVARIANTE", "IVARIANTE") && Variante == null) throw new Exception("Nessuna variante valida trovata per l'investimento.");
            SiarLibrary.BandoTipoInvestimentiCollection bt = new SiarBLL.BandoTipoInvestimentiCollectionProvider().Find(progetto_correlato.IdBando, 2, null);
            if (bt.Count == 0) throw new Exception("Massimali di aiuto per il conto interessi non trovati. Impossibile continuare.");
            max_quota_contributo = bt[0].QuotaMax;
            //max_importo_contributo = bt[0].ImportoMax ?? 0; non usato
        }

        protected override void OnPreRender(EventArgs e)
        {
            SiarLibrary.Bando disp_att = new SiarBLL.BandoCollectionProvider().GetById(progetto_correlato.IdBando);
            SiarLibrary.ZprogrammazioneCollection interventi = new SiarBLL.ZprogrammazioneCollectionProvider().GetProgrammazionePsr(null,
                disp_att.IdProgrammazione, null, null, null, true, null);
            lstTipoIntervento.Items.Clear();
            lstTipoIntervento.Items.Add("");
            foreach (SiarLibrary.Zprogrammazione i in interventi)
            {
                ListItem li = new ListItem();
                li.Value = i.Id;
                li.Text = i.Descrizione;
                li.Selected = ((!IsPostBack || _ricaricaInvestimento) && _investimento.IdInvestimento != null ?
                    li.Value == _investimento.IdProgrammazione : li.Value == lstTipoIntervento.SelectedValue);
                lstTipoIntervento.Items.Add(li);
            }

            lstFinalita.IdProgrammazione = disp_att.IdProgrammazione;
            lstFinalita.DataBind();
            if ((!IsPostBack || _ricaricaInvestimento) && _investimento.IdInvestimento != null)
                lstFinalita.SelectedValue = _investimento.IdObiettivoMisura;

            lstAnni.InitValue = 5;
            lstAnni.EndValue = 10;
            lstAnni.DataBind();
            txtRateAnnuali.Text = "2";
            lstCodificaInvestimenti.IdBando = progetto_correlato.IdBando;
            lstCodificaInvestimenti.DataBind();

            if (!IsPostBack || _ricaricaInvestimento)
            {
                if (_investimento.IdInvestimento == null)
                    txtDescrizioneTecnicaLunga.Text = "- Identificazione del bene: (Comune, foglio e particelle catastali, specie e razza, ecc)\n\n\n"
                        + "- Consistenza: (catastale n. vani, zootecnica numero, ecc)\n\n\n- Costo del bene:\n\n\n";
                else txtDescrizioneTecnicaLunga.Text = _investimento.Descrizione;
                txtAmmontare.Text = _investimento.CostoInvestimento;
                txtAmmontareInvestimenti.Text = _investimento.SpeseGenerali;
                txtAttualizzazione.Text = _investimento.QuotaContributoRichiesto;
                txtContributoAmmissibile.Text = _investimento.ContributoRichiesto;
                txtTasso.Text = (_investimento.TassoAbbuono != null ? _investimento.TassoAbbuono.ToString() : max_quota_contributo.ToString());
                lstAnni.SelectedValue = (_investimento.Quantita != null ? Convert.ToInt32(_investimento.Quantita.Value) : 0).ToString();
                lstCodificaInvestimenti.SelectedValue = _investimento.IdCodificaInvestimento;
                txtValutazioneIstruttore.Text = _investimento.ValutazioneInvestimento;
            }
            if (!(progetto_correlato.CodStato == "P" || (_fase == "PVARIANTE" && ((SiarLibrary.Web.PrivatePage)Page).TipoModifica == 2)))
            {
                string scpt_storico_investimento = "alert('Nessun precedente investimento trovato.');";
                if (_investimento.IdInvestimentoOriginale != null)
                    scpt_storico_investimento = "mostraStoricoInvestimento(" + _investimento.IdInvestimentoOriginale + ");";
                btnVisualizzaOriginale.Attributes.Add("onclick", scpt_storico_investimento);
                tableValutazione.Visible = true;
                txtValutazioneIstruttore.ReadOnly = false;
            }
            base.OnPreRender(e);
        }

        protected void btnCalcolaContributo_Click(object sender, EventArgs e)
        {
            try
            {
                CalcolaContributoInvestimento(false);
                ShowMessage("Contributo ricalcolato.");
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        public void CalcolaContributoInvestimento(bool salva)
        {
            SiarBLL.PianoInvestimentiCollectionProvider investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider();
            try
            {
                if (decimal.Parse(txtAmmontare.Text) > decimal.Parse(txtAmmontareInvestimenti.Text))
                    throw new Exception("Non è possibile richiedere un mutuo di importo superiore all`ammontare degli investimenti per cui lo si richiede.");
                if (decimal.Parse(txtAttualizzazione.Text) <= 0)
                    throw new Exception("Inserire un tasso di attualizzazione valido.");

                investimenti_provider.DbProviderObj.BeginTran();
                _investimento.IdProgetto = progetto_correlato.IdProgetto;
                _investimento.IdProgrammazione = lstTipoIntervento.SelectedValue;
                _investimento.Descrizione = txtDescrizioneTecnicaLunga.Text;
                _investimento.CodTipoInvestimento = 2;
                _investimento.IdObiettivoMisura = lstFinalita.SelectedValue;
                _investimento.IdCodificaInvestimento = lstCodificaInvestimenti.SelectedValue;
                _investimento.TassoAbbuono = txtTasso.Text;
                _investimento.CostoInvestimento = txtAmmontare.Text;
                _investimento.SpeseGenerali = txtAmmontareInvestimenti.Text;
                _investimento.QuotaContributoRichiesto = txtAttualizzazione.Text;
                _investimento.Quantita = lstAnni.SelectedValue;
                if (_fase.FindValueIn("IDOMANDA", "IVARIANTE"))
                {
                    _investimento.ValutazioneInvestimento = txtValutazioneIstruttore.Text;
                    _investimento.Ammesso = true;
                    _investimento.DataValutazione = DateTime.Now;
                    _investimento.Istruttore = Operatore.Utente.CfUtente;
                }
                else if (_fase == "PVARIANTE")
                {
                    if (_investimento.IdInvestimento == null) _investimento.CodVariazione = "N";
                    _investimento.IdVariante = Variante.IdVariante;
                    _investimento.DataVariazione = DateTime.Now;
                    _investimento.OperatoreVariazione = Operatore.Utente.CfUtente;
                }
                investimenti_provider.Save(_investimento);

                investimenti_provider.CalcoloContributoContoInteressi(ref _investimento, _fase);
                // salvo contributo e quota
                investimenti_provider.Save(_investimento);

                // controllo i dati varianti dall'investimento originale
                if (_fase == "IDOMANDA")
                {
                    SiarLibrary.PianoInvestimenti investimento_originale = investimenti_provider.GetById(_investimento.IdInvestimentoOriginale);
                    if (investimento_originale.CostoInvestimento < _investimento.CostoInvestimento)
                        throw new Exception("Non è possibile aumentare l`ammontare del mutuo oltre il richiesto dal beneficiario.");
                    if (investimento_originale.SpeseGenerali < _investimento.SpeseGenerali)
                        throw new Exception("Non è possibile aumentare l`ammontare dell`investimento per cui si richiede il mutuo oltre il richiesto dal beneficiario.");
                    if (salva && _investimento.ValutazioneInvestimento == null &&
                        (investimento_originale.IdProgrammazione != _investimento.IdProgrammazione
                            || investimento_originale.Descrizione != _investimento.Descrizione
                            || investimento_originale.Quantita != _investimento.Quantita
                            || investimento_originale.CostoInvestimento != _investimento.CostoInvestimento
                            || investimento_originale.SpeseGenerali != _investimento.SpeseGenerali
                            || investimento_originale.ContributoRichiesto != _investimento.ContributoRichiesto
                            || investimento_originale.QuotaContributoRichiesto != _investimento.QuotaContributoRichiesto
                            || investimento_originale.IdObiettivoMisura != _investimento.IdObiettivoMisura
                            || investimento_originale.IdCodificaInvestimento != _investimento.IdCodificaInvestimento))
                        throw new Exception("E` obbligatorio indicare nella valutazione dell`investimento qualsiasi modifica effettuata in corso di istruttoria.");
                }
                if (_fase.FindValueIn("PVARIANTE", "IVARIANTE"))
                {
                    if (_investimento.CodVariazione != "N" && _investimento.ContributoRichiesto <
                        investimenti_provider.GetContributoPagamentiRichiestiInvestimento(_investimento.IdInvestimento, Variante.Segnatura == null ? null : Variante.DataModifica))
                        throw new Exception("Impossibile diminuire il contributo richiesto sotto la soglia del`ammontare rendicontato nelle domande di pagamento precedenti la presente richiesta.");
                    // codice variazione (valori possibili: A,E,M,N,V)
                    string cod_variazione_investimento = null;
                    if (!_investimento.CodVariazione.FindValueIn("A", "N"))
                    {
                        SiarLibrary.PianoInvestimenti investimento_originale = investimenti_provider.GetById(_investimento.IdInvestimentoOriginale);
                        if (investimento_originale == null) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.GenericoConLink);
                        if (_investimento.CostoInvestimento > investimento_originale.CostoInvestimento) cod_variazione_investimento = "M";
                        else if (_investimento.CostoInvestimento < investimento_originale.CostoInvestimento) cod_variazione_investimento = "E";
                        else if (investimento_originale.IdProgrammazione != _investimento.IdProgrammazione
                                || investimento_originale.Descrizione != _investimento.Descrizione
                                || investimento_originale.Quantita != _investimento.Quantita
                                || investimento_originale.CostoInvestimento != _investimento.CostoInvestimento
                                || investimento_originale.SpeseGenerali != _investimento.SpeseGenerali
                                || investimento_originale.ContributoRichiesto != _investimento.ContributoRichiesto
                                || investimento_originale.QuotaContributoRichiesto != _investimento.QuotaContributoRichiesto
                                || investimento_originale.IdObiettivoMisura != _investimento.IdObiettivoMisura
                                || investimento_originale.IdCodificaInvestimento != _investimento.IdCodificaInvestimento) cod_variazione_investimento = "V";
                        _investimento.CodVariazione = cod_variazione_investimento;
                    }
                    investimenti_provider.Save(_investimento);
                    if (_fase == "PVARIANTE") new SiarBLL.VariantiCollectionProvider(investimenti_provider.DbProviderObj).AggiornaVariante(Variante, Operatore);
                    else new SiarBLL.VariantiCollectionProvider(investimenti_provider.DbProviderObj).AggiornaVarianteIstruttoria(Variante, Operatore);
                }
                if (salva) investimenti_provider.DbProviderObj.Commit();
                else investimenti_provider.DbProviderObj.Rollback();

                txtContributoAmmissibile.Text = _investimento.ContributoRichiesto;

                SiarLibrary.NullTypes.StringNT codice_troncamento = new SiarLibrary.NullTypes.StringNT(_investimento.AdditionalAttributes["CodTroncamento"]);
                SiarLibrary.NullTypes.DecimalNT contributo_non_troncato = new SiarLibrary.NullTypes.DecimalNT(_investimento.AdditionalAttributes["ContributoNonTroncato"]);
                if (codice_troncamento != null)
                {
                    string messaggio_troncamento = "<br />Attenzione!<br /><br />Il contributo calcolato per l'investimento ammonta a "
                                + string.Format("{0:c}", contributo_non_troncato.Value) + "<br />superando ";
                    switch (codice_troncamento.Value)
                    {
                        case "A": messaggio_troncamento += "il massimo ammissibile da bando. Verrà troncato sul totale."; break;
                        case "O": messaggio_troncamento += "l`ammontare richiesto dal beneficiario. E` stato troncato."; break;
                        case "M": messaggio_troncamento += "il massimo ammissibile a finanziamento. E' stato troncato."; break;
                    }
                    rowContributoMessaggio.InnerHtml = messaggio_troncamento + "<br /><br />";
                }
            }
            catch (Exception ex) { investimenti_provider.DbProviderObj.Rollback(); throw ex; }
        }
    }
}