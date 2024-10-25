using System;
using SiarLibrary.Extensions;

namespace web.CONTROLS
{
    public partial class InvestimentoBrevettoLicenza : System.Web.UI.UserControl
    {
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

        private SiarLibrary.PianoInvestimenti _investimento;
        public SiarLibrary.PianoInvestimenti Investimento
        {
            get { return _investimento; }
            set { _investimento = value; }
        }

        private string _fase;
        public string Fase { set { _fase = value; } }

        private bool _ricaricaInvestimento;
        public bool RicaricaInvestimento { set { _ricaricaInvestimento = value; } }

        public SiarLibrary.Operatore Operatore { get { return ((SiarLibrary.Web.MasterPage)Page.Master).Operatore; } }
        private void ShowMessage(string message) { ((SiarLibrary.Web.Page)Page).ShowMessage(message); }
        private void ShowError(string message) { ((SiarLibrary.Web.Page)Page).ShowError(message); }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (_investimento == null)
            {
                if (_fase.FindValueIn("IDOMANDA", "IVARIANTE")) throw new Exception("Non è possibile inserire un nuovo investimento in questa fase.");
                _investimento = new SiarLibrary.PianoInvestimenti();
            }
            if (_investimento.CodTipoInvestimento != null && _investimento.CodTipoInvestimento != 5) throw new Exception("Tipologia di investimento non valida.");
            if (_fase.FindValueIn("PVARIANTE", "IVARIANTE") && Variante == null) throw new Exception("Nessuna variante valida trovata per l'investimento.");
        }

        protected override void OnPreRender(EventArgs e)
        {
            lstUnitaDiMisura.DataBind();
            lstUnitaDiMisura.Items.FindByText("Numero").Selected = true;

            if (!IsPostBack || _ricaricaInvestimento)
            {
                txtDescTecnica.Text = _investimento.Descrizione;
                txtCostoInvestimento.Text = _investimento.CostoInvestimento;
                txtContributoRichiesto.Text = _investimento.ContributoRichiesto;
                txtQuotaContributo.Text = _investimento.QuotaContributoRichiesto;
                txtQuantita.Text = _investimento.Quantita;
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
                investimenti_provider.DbProviderObj.BeginTran();
                _investimento.IdProgetto = progetto_correlato.IdProgetto;
                _investimento.CodTipoInvestimento = 5;
                _investimento.Quantita = txtQuantita.Text;
                _investimento.IdUnitaMisura = lstUnitaDiMisura.SelectedValue;
                _investimento.Descrizione = txtDescTecnica.Text;
                // cerco id programmazione            
                SiarLibrary.BandoProgrammazioneCollection pbando = new SiarBLL.BandoProgrammazioneCollectionProvider().Find(progetto_correlato.IdBando, null, null, null);
                if (pbando.Count == 0) throw new Exception("Il bando non prevede investimenti di questo tipo. Impossibile continuare.");
                _investimento.IdProgrammazione = pbando[0].Id;
                _investimento.CostoInvestimento = txtCostoInvestimento.Text;
                _investimento.QuotaContributoRichiesto = 0;
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
                // salvo contributo e quota
                investimenti_provider.CalcoloContributoBrevettiLicenze(ref _investimento, _fase);
                investimenti_provider.Save(_investimento);
                // controllo i dati varianti dall'investimento originale
                if (_fase == "IDOMANDA")
                {
                    SiarLibrary.PianoInvestimenti investimento_originale = investimenti_provider.GetById(_investimento.IdInvestimentoOriginale);
                    if (investimento_originale.CostoInvestimento < _investimento.CostoInvestimento)
                        throw new Exception("Non è possibile aumentare il costo dell`investimento oltre l`ammontare richiesto dal beneficiario.");
                    if (salva && _investimento.ValutazioneInvestimento == null &&
                        (investimento_originale.Descrizione != _investimento.Descrizione
                            || investimento_originale.Quantita != _investimento.Quantita
                            || investimento_originale.CostoInvestimento != _investimento.CostoInvestimento
                            || investimento_originale.ContributoRichiesto != _investimento.ContributoRichiesto
                        /*|| investimento_originale.QuotaContributoRichiesto != _investimento.QuotaContributoRichiesto  <-- commentata perche' la quota di contributo e' variabile in base agli altri investimenti*/
                            ))
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
                                || investimento_originale.ContributoRichiesto != _investimento.ContributoRichiesto
                                || investimento_originale.QuotaContributoRichiesto != _investimento.QuotaContributoRichiesto) cod_variazione_investimento = "V";
                        _investimento.CodVariazione = cod_variazione_investimento;
                    }

                    investimenti_provider.Save(_investimento);
                    if (_fase == "PVARIANTE") new SiarBLL.VariantiCollectionProvider(investimenti_provider.DbProviderObj).AggiornaVariante(Variante, Operatore);
                    else new SiarBLL.VariantiCollectionProvider(investimenti_provider.DbProviderObj).AggiornaVarianteIstruttoria(Variante, Operatore);
                }
                if (salva) investimenti_provider.DbProviderObj.Commit();
                else investimenti_provider.DbProviderObj.Rollback();

                txtCostoInvestimento.Text = _investimento.CostoInvestimento;
                txtContributoRichiesto.Text = _investimento.ContributoRichiesto;
                txtQuotaContributo.Text = _investimento.QuotaContributoRichiesto;
                txtAmmontareDisponibile.Text = _investimento.AdditionalAttributes["AmmontareDisponibile"];

                SiarLibrary.NullTypes.StringNT codice_troncamento = new SiarLibrary.NullTypes.StringNT(_investimento.AdditionalAttributes["CodTroncamento"]);
                SiarLibrary.NullTypes.DecimalNT contributo_non_troncato = new SiarLibrary.NullTypes.DecimalNT(_investimento.AdditionalAttributes["ContributoNonTroncato"]),
                    costo_non_troncato = new SiarLibrary.NullTypes.DecimalNT(_investimento.AdditionalAttributes["CostoNonTroncato"]);
                if (codice_troncamento != null)
                {
                    string messaggio_troncamento = "<br />Attenzione!<br />";
                    switch (codice_troncamento.Value)
                    {
                        case "Q":
                            messaggio_troncamento += "Il costo inserito ammonta a € " + string.Format("{0:N}", costo_non_troncato.Value)
                                + " superando l'ammontare disponibile previsto dal bando<br />per questa tipologia di investimenti. E` stato troncato.";
                            break;
                        case "O":
                            messaggio_troncamento += "Il contributo calcolato ammonta a € " + string.Format("{0:N}", contributo_non_troncato.Value) +
                                " superando l'ammontare richiesto<br />per l'investimento. E` stato troncato.";
                            break;
                        case "M":
                            messaggio_troncamento += "Il contributo calcolato ammonta a € " + string.Format("{0:N}", contributo_non_troncato.Value) +
                                "superando il massimo ammissibile<br />a finanziamento. E' stato troncato.";
                            break;
                    }
                    rowContributoMessaggio.InnerHtml = messaggio_troncamento + "<br /><br />";
                }
            }
            catch (Exception ex) { investimenti_provider.DbProviderObj.Rollback(); throw ex; }
        }
    }
}