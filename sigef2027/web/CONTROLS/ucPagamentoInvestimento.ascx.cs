﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarLibrary;
using SiarBLL;

namespace web.CONTROLS
{
    public partial class ucPagamentoInvestimento : System.Web.UI.UserControl
    {
        private Utenti _utente;
        public Utenti Utente
        {
            get { return _utente; }
            set { _utente = value; }
        }

        private Giustificativi _giustificativo;
        public Giustificativi Giustificativo
        {
            get { return _giustificativo; }
            set { _giustificativo = value; }
        }

        private DomandaDiPagamento _domanda;
        public DomandaDiPagamento Domanda
        {
            get { return _domanda; }
            set { _domanda = value; }
        }

        private PagamentiBeneficiario _pag_ben;
        public PagamentiBeneficiario PagamentoBeneficiario
        {
            get { return _pag_ben; }
            set { _pag_ben = value; }
        }

        private SiarLibrary.PianoInvestimenti _investimento;
        public SiarLibrary.PianoInvestimenti PianoInvestimento
        {
            get { return _investimento; }
            set { _investimento = value; }
        }

        private string _mostra;
        public string Mostra
        {
            get { return _mostra; }
            //set { _mostra = value; }
        }

        public string PercentualeContributo
        {
            get { return hdnPercContributo.Value; }
            set { hdnPercContributo.Value = value; }
        }

        private SpeseSostenute _spesa_selezionata;
        private PagamentiRichiesti _pag_richiesto;
        CollaboratoriXBando _istruttore;
        CollaboratoriIstruttoriaBando _collaboratoreIstruttoria;

        #region Collection Provider
        private SpeseSostenuteCollectionProvider spese_provider;
        private PagamentiBeneficiarioCollectionProvider pag_ben_provider;
        private PagamentiRichiestiCollectionProvider pag_ric_provider;
        private DomandaDiPagamentoCollectionProvider domande_provider;
        private GiustificativiCollectionProvider giustificativi_provider;
        private UtentiCollectionProvider utenti_provider;
        private PianoInvestimentiCollectionProvider investimenti_provider;
        private NoteCollectionProvider note_provider;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            _mostra = "mostraPopupTemplate('" + divPagInv.UniqueID.Replace('$', '_') + "','divBKGMessaggio'); $('[id$=txtPBContributoRichiestoQuota]').attr('title', $('[id$=hdnPercContributo]').val());";
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (_domanda != null && _giustificativo != null)
            {
                InizializzaProvider();
                lstMotivoRiduzione.DataBinding += new EventHandler(lstMotivoRiduzione_DataBinding);
                lstMotivoRiduzione.DataBind();

                ControlloUtente();
                CaricaDatiGiustificativo();
                CaricaDatiPagamentoBeneficiario();
                CaricaSpeseGiustificativo();
                CaricaPagamentoAmmesso();
                popolaHidden();
            }
            base.OnPreRender(e);
        }

        private void InizializzaProvider()
        {
            spese_provider = new SpeseSostenuteCollectionProvider();
            pag_ben_provider = new PagamentiBeneficiarioCollectionProvider();
            pag_ric_provider = new PagamentiRichiestiCollectionProvider();
            domande_provider = new DomandaDiPagamentoCollectionProvider();
            giustificativi_provider = new GiustificativiCollectionProvider();
            utenti_provider = new UtentiCollectionProvider();
            investimenti_provider = new PianoInvestimentiCollectionProvider();
            note_provider = new NoteCollectionProvider();
        }

        private void popolaHidden()
        {
            hdnIdDomanda.Value = _domanda.IdDomandaPagamento;
            hdnIdGiustificativo.Value = _giustificativo.IdGiustificativo;
            hdnIdInvestimento.Value = _investimento.IdInvestimento;
            hdnIdOperatore.Value = _utente.IdUtente;
            hdnIdPagamentoBeneficiario.Value = _pag_ben.IdPagamentoBeneficiario;
            hdnIvaGiustificativo.Value = _giustificativo.Iva;
            hdnPercContributo.Value = _investimento.QuotaContributoRichiesto;
            txtPBContributoRichiestoQuota.ToolTip = _investimento.QuotaContributoRichiesto;
            txtPBContributoAmmessoQuota.ToolTip = _pag_ben.QuotaContributoAmmesso;

            txtPBImportoRichiesto.AddJSAttribute("onblur", "calcolaContributoRichiesto();");
            txtLordoSpesa.AddJSAttribute("onblur", "validaImportiSpesa(true);");
        }

        private void svuotaHidden()
        {
            hdnIdDomanda.Value = null;
            hdnIdGiustificativo.Value = null;
            hdnIdInvestimento.Value = null;
            hdnIdOperatore.Value = null;
            hdnIdPagamentoBeneficiario.Value = null;
            hdnIvaGiustificativo.Value = null;
            hdnPercContributo.Value = null;
            txtPBContributoRichiestoQuota.ToolTip = null;
            txtPBContributoAmmessoQuota.ToolTip = null;
        }

        private void CaricaHidden()
        {
            InizializzaProvider();
            _domanda = domande_provider.GetById(hdnIdDomanda.Value);
            _giustificativo = giustificativi_provider.GetById(hdnIdGiustificativo.Value);
            _utente = utenti_provider.GetById(hdnIdOperatore.Value);
            _pag_ben = pag_ben_provider.GetById(hdnIdPagamentoBeneficiario.Value);
            _pag_richiesto = pag_ric_provider.GetById(_pag_ben.IdPagamentoRichiesto);
            _investimento = investimenti_provider.GetById(hdnIdInvestimento.Value);
            int id_spesa;
            if (int.TryParse(hdnIdSpesa.Value, out id_spesa))
                _spesa_selezionata = spese_provider.GetById(id_spesa);
        }

        void lstMotivoRiduzione_DataBinding(object sender, EventArgs e)
        {
            lstMotivoRiduzione.Items.Clear();
            lstMotivoRiduzione.Items.Add(new ListItem("", ""));
            Dictionary<string, string> tipi_riduzione = DbStaticProvider.GetTipiRiduzionePagamento(true, _pag_ben.CodTipo == "LEC");

            foreach (KeyValuePair<string, string> rid in tipi_riduzione)
                lstMotivoRiduzione.Items.Add(new ListItem(rid.Key, rid.Value));
        }

        private void CaricaDatiGiustificativo()
        {
            txtGSNumero.Text = _giustificativo.Numero;
            txtGSData.Text = _giustificativo.Data;
            txtGSOggetto.Text = _giustificativo.Descrizione;
            txtGSImponibile.Text = _giustificativo.Imponibile;
            txtGSIva.Text = _giustificativo.Iva;
            chkGSIvaNonRecuperabile.Checked = _giustificativo.IvaNonRecuperabile;
            //var totale_spese = DbStaticProvider.GetAmmontarePagamentiGiustificativo(_giustificativo.IdGiustificativo, null);
            var domande_list = domande_provider.Find(null, null, _domanda.IdProgetto, null)
                    .ToArrayList<DomandaDiPagamento>();
            var spese_list = spese_provider.Find(null, _giustificativo.IdGiustificativo, null)
                .ToArrayList<SpeseSostenute>();
            var totale_spese = (from s in spese_list
                                join d in domande_list on s.IdDomandaPagamento equals d.IdDomandaPagamento
                                where d.Annullata == false
                                select s)
                .Sum(s => s.Netto);
            txtTotaleSpese.Text = totale_spese.ToString();

            var totale_spese_precedenti = Math.Round(
                (from s in spese_list
                 join d in domande_list on s.IdDomandaPagamento equals d.IdDomandaPagamento
                 where s.IdDomandaPagamento < _domanda.IdDomandaPagamento
                 && (d.Annullata == null || d.Annullata == false)
                 select s).Sum(s => s.Netto)
                , 2, MidpointRounding.AwayFromZero);
            txtTotaleSpesePrecedenti.Text = totale_spese_precedenti.ToString();

            txtTotaleSpeseDomanda.Text = Math.Round(totale_spese - totale_spese_precedenti, 2, MidpointRounding.AwayFromZero).ToString();

            var pag_ben_list = pag_ben_provider.Find(null, null, _domanda.IdProgetto, _giustificativo.IdGiustificativo, null, null)
                .ToArrayList<PagamentiBeneficiario>();
            var pag_ric_list = pag_ric_provider.Find(null, null, _domanda.IdProgetto, null)
                .ToArrayList<PagamentiRichiesti>();

            txtTotaleAmmesso.Text = Math.Round(
                (from ben in pag_ben_list
                 join ric in pag_ric_list on ben.IdPagamentoRichiesto equals ric.IdPagamentoRichiesto
                 join d in domande_list on ric.IdDomandaPagamento equals d.IdDomandaPagamento
                 where ben.IdGiustificativo == _giustificativo.IdGiustificativo
                 && (d.Annullata == null || d.Annullata == false)
                 select ben).Sum(b => b.ImportoAmmesso != null ? b.ImportoAmmesso : 0.00)
                        , 2, MidpointRounding.AwayFromZero).ToString();

            txtTotaleAmmessoSpesePrecedenti.Text = Math.Round(
                (from ben in pag_ben_list
                 join ric in pag_ric_list on ben.IdPagamentoRichiesto equals ric.IdPagamentoRichiesto
                 join d in domande_list on ric.IdDomandaPagamento equals d.IdDomandaPagamento
                 where ben.IdGiustificativo == _giustificativo.IdGiustificativo
                 && (d.Annullata == null || d.Annullata == false)
                 && d.IdDomandaPagamento < _domanda.IdDomandaPagamento
                 select ben).Sum(b => b.ImportoAmmesso != null ? b.ImportoAmmesso : 0.00)
                        , 2, MidpointRounding.AwayFromZero).ToString();
        }

        private void CaricaDatiPagamentoBeneficiario()
        {
            decimal importoRichiesto = 0;
            if (_pag_ben.ImportoRichiesto != null)
            {
                importoRichiesto = _pag_ben.ImportoRichiesto;
            }
            else
            {
                // il massimo richiedibile è l'importo del giustificativo con o senza iva in base a se l'iva è recuperabile o meno
                importoRichiesto = _giustificativo.Imponibile;
                if (_giustificativo.IvaNonRecuperabile)
                    importoRichiesto = Math.Round(importoRichiesto * (_giustificativo.Iva + 100) / 100, 2, MidpointRounding.AwayFromZero);
                _pag_ben.ImportoRichiesto = importoRichiesto;
            }
            txtPBImportoRichiesto.Text = importoRichiesto.ToString();

            var contributoRichiesto = Math.Round(importoRichiesto * _investimento.QuotaContributoRichiesto.Value / 100, 2, MidpointRounding.AwayFromZero);
            txtPBContributoRichiesto.Text = contributoRichiesto.ToString();
            txtPBContributoRichiestoQuota.Text = string.Format("{0:N12}", Math.Round(_investimento.QuotaContributoRichiesto.Value, 12, MidpointRounding.AwayFromZero));
        }

        private void CaricaSpeseGiustificativo()
        {
            var spese_giustificativo_coll = spese_provider.Find(_domanda.IdDomandaPagamento, _giustificativo.IdGiustificativo, null);

            dgSpeseGiustificativo.DataSource = spese_giustificativo_coll;
            dgSpeseGiustificativo.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgSpeseGiustificativo_ItemDataBound);
            dgSpeseGiustificativo.MostraTotale("DataField", 2, 3);
            dgSpeseGiustificativo.DataBind();
        }

        private void CaricaPagamentoAmmesso()
        {
            if (_pag_ben.ImportoAmmesso != null) // se ho l'importo ammesso, ho tutti gli importi già salvati
            {
                txtPBImportoAmmesso.Text = _pag_ben.ImportoAmmesso;
                txtPBContributoAmmesso.Text = _pag_ben.ContributoAmmesso;

                if (_pag_ben.QuotaContributoAmmesso != null)
                    txtPBContributoAmmessoQuota.Text = string.Format("{0:N12}", Math.Round(_pag_ben.QuotaContributoAmmesso.Value, 12, MidpointRounding.AwayFromZero));
                else
                    txtPBContributoAmmessoQuota.Text = string.Format("{0:N12}", Math.Round(_investimento.QuotaContributoRichiesto.Value, 12, MidpointRounding.AwayFromZero));

                txtPBImportoNonAmmesso.Text = string.Format("{0:N}", _pag_ben.ImportoRichiesto.Value - _pag_ben.ImportoAmmesso.Value);
                decimal contributo_richiesto = Math.Round(_pag_ben.ImportoRichiesto.Value * _investimento.QuotaContributoRichiesto / 100, 2, MidpointRounding.AwayFromZero);
                decimal contributo_ammesso = 0;
                if (_pag_ben.ContributoAmmesso != null)
                    contributo_ammesso = _pag_ben.ContributoAmmesso;
                else
                    contributo_ammesso = Math.Round(_pag_ben.ImportoAmmesso.Value * _investimento.QuotaContributoRichiesto / 100, 2, MidpointRounding.AwayFromZero);
                txtPBContributoNonAmmesso.Text = string.Format("{0:N}", contributo_richiesto - contributo_ammesso);

                if (_pag_ben.CodRiduzione != null)
                {
                    lstMotivoRiduzione.SelectedValue = _pag_ben.CodRiduzione;
                    SiarLibrary.Note motivazioni = null;
                    if (_pag_ben.MotivazioneRiduzione != null)
                        motivazioni = new SiarBLL.NoteCollectionProvider().GetById(_pag_ben.MotivazioneRiduzione);
                    txtPBNoteAggiuntive.Text = motivazioni != null ? motivazioni.Testo : null;
                }
                else
                    txtPBNoteAggiuntive.Text = null;
            }
            else // altrimenti scrivo i minimi necessari per calcolare
            {
                txtPBImportoAmmesso.Text = _pag_ben.ImportoRichiesto;
                txtPBContributoAmmessoQuota.Text = string.Format("{0:N12}", Math.Round(_investimento.QuotaContributoRichiesto.Value, 12, MidpointRounding.AwayFromZero));
            }
        }

        private bool ControlloCollaboratoreIstruttoria()
        {
            bool collaboratore = false;
            SiarLibrary.Progetto p = new SiarBLL.ProgettoCollectionProvider().GetById(_domanda.IdProgetto);

            SiarLibrary.CollaboratoriIstruttoriaBandoCollection collaboratoriIstruttoria = new SiarBLL.CollaboratoriIstruttoriaBandoCollectionProvider().Find(p.IdBando, _utente.IdUtente, true);

            if (collaboratoriIstruttoria.Count > 0)
            {
                collaboratore = true;
                _collaboratoreIstruttoria = collaboratoriIstruttoria[0];
            }

            return collaboratore;
        }

        private void ControlloUtente()
        {
            SiarLibrary.CollaboratoriXBandoCollection istruttori = new SiarBLL.CollaboratoriXBandoCollectionProvider()
                .Find(null, _domanda.IdProgetto, _utente.IdUtente, null, true);
            if (istruttori.Count > 0)
                _istruttore = istruttori[0];

            if (_utente.Profilo.Equals("Utente singolo")
                || _utente.Profilo.Equals("Consulente"))
            {
                if (_domanda.SegnaturaApprovazione == null)
                {
                    divPagamentoAmmesso.Visible = false;
                    txtPBImportoAmmesso.ReadOnly = true;
                    txtPBContributoAmmessoQuota.ReadOnly = true;
                    btnCalcolaContributoAmmesso.Disabled = true;
                    lstMotivoRiduzione.Enabled = false;
                    txtPBNoteAggiuntive.ReadOnly = true;
                }

                if (_domanda.Segnatura != null)
                {
                    btnEliminaPag.Enabled = false;

                    if (_giustificativo.InIntegrazione == null || _giustificativo.InIntegrazione == false)
                    {
                        txtPBImportoRichiesto.ReadOnly = true;
                        btnSalvaPag.Enabled = false;
                    }

                    if (_spesa_selezionata == null
                        || _spesa_selezionata.InIntegrazione == null || _spesa_selezionata.InIntegrazione == false)
                    {
                        txtLordoSpesa.ReadOnly = true;
                        btnSalvaImportiSpesa.Enabled = false;
                    }
                }
            }
            else if ((istruttori.Count > 0
                && _istruttore != null && _istruttore.Nominativo.Equals(Utente.Nominativo)) || ControlloCollaboratoreIstruttoria())
            {
                txtPBImportoRichiesto.ReadOnly = true;
                btnEliminaPag.Visible = false;

                if (_domanda.Segnatura == null
                    || _domanda.SegnaturaApprovazione != null)
                {
                    txtPBImportoAmmesso.ReadOnly = true;
                    txtPBContributoAmmessoQuota.ReadOnly = true;
                    btnCalcolaContributoAmmesso.Disabled = true;
                    lstMotivoRiduzione.Enabled = false;
                    txtPBNoteAggiuntive.ReadOnly = true;
                    btnSalvaPag.Enabled = false;
                    txtLordoSpesa.ReadOnly = true;
                    btnSalvaImportiSpesa.Enabled = false;
                }
            }
            else
            {
                txtPBImportoRichiesto.ReadOnly = true;
                txtPBImportoAmmesso.ReadOnly = true;
                txtPBContributoAmmessoQuota.ReadOnly = true;
                btnCalcolaContributoAmmesso.Disabled = true;
                lstMotivoRiduzione.Enabled = false;
                txtPBNoteAggiuntive.ReadOnly = true;
                btnSalvaPag.Enabled = false;
                btnEliminaPag.Enabled = false;
                txtLordoSpesa.ReadOnly = true;
                btnSalvaImportiSpesa.Enabled = false;
            }
        }

        private string VerificaSalvataggioBeneficiario()
        {
            //Verifico il superamento dell'imponibile del giustificativo
            decimal new_importo;
            decimal.TryParse(txtPBImportoRichiesto.Text, out new_importo);
            var max_importo_giustificativo = _giustificativo.IvaNonRecuperabile ? Math.Round(_giustificativo.Imponibile.Value * (_giustificativo.Iva + 100) / 100, 2, MidpointRounding.AwayFromZero) : _giustificativo.Imponibile.Value;

            if (new_importo > max_importo_giustificativo)
                throw new Exception("Importo richiesto non valido perchè maggiore dell`imponibile del giustificativo.");

            //Verifico il superamento dell'imponibile delle spese
            decimal spese_domanda;
            decimal.TryParse(txtTotaleSpeseDomanda.Text, out spese_domanda);
            var max_importo_spese = _giustificativo.IvaNonRecuperabile ? Math.Round(spese_domanda * (_giustificativo.Iva + 100) / 100, 2, MidpointRounding.AwayFromZero) : spese_domanda;

            if (new_importo > max_importo_spese)
                throw new Exception("Importo richiesto non valido perchè maggiore delle spese sostenute per il giustificativo.");

            //Non può essere negativo, ma può essere 0 per recuperare nelle domande successive
            if (new_importo < 0)
                throw new Exception("Importo richiesto non valido.");

            return "";
        }

        private string VerificaSalvataggioIstruttore()
        {
            decimal old_importo = (_pag_ben.ImportoAmmesso != null ? _pag_ben.ImportoAmmesso.Value : 0);
            decimal importo_giustificativo = _pag_ben.Imponibile + ((_pag_ben.IvaNonRecuperabile ? _pag_ben.Imponibile.Value * _pag_ben.Iva / 100 : 0));
            importo_giustificativo = Math.Round(importo_giustificativo, 2, MidpointRounding.AwayFromZero);
            decimal new_importo = 0; // importo_nonresp = 0;
            decimal.TryParse(txtPBImportoAmmesso.Text, out new_importo);
            //decimal.TryParse(txtPBImportoNonresp.Text, out importo_nonresp);

            if (new_importo > importo_giustificativo)
                return "Importo ammesso non valido perchè maggiore dell`imponibile del giustificativo.";
            if (new_importo > _pag_ben.ImportoRichiesto)
                return "Importo ammesso non valido perchè maggiore di quello richiesto.";
            //if (importo_nonresp > _pag_ben.ImportoRichiesto - new_importo) 
            //    return "Importo non ammesso a non responsabilita' non valido perchè maggiore dello scostamento.";


            //decimal importo_disponibile_giustificativo = SiarLibrary.DbStaticProvider.GetAmmontareDisponibileGiustificativo(
            //    pagben.IdGiustificativo, importo_giustificativo + old_importo, true, PagamentoProvider.DbProviderObj);
            //if (new_importo > importo_disponibile_giustificativo)
            //{
            //    new_importo = importo_disponibile_giustificativo;
            //    messaggio = "L`importo inserito supera l`ammontare disponibile per il giustificativo selezionato, è stato troncato.";
            //}
            if (new_importo < 0)
                return "Nessuno degli importi imputabili può essere negativo.";

            decimal quotaImporto = Convert.ToDecimal(txtPBContributoAmmessoQuota.Text);
            if (quotaImporto < 0 || quotaImporto > 100)
                return "Quota del contributo ammesso non valida.";
            decimal Contributo = Math.Round(Convert.ToDecimal(txtPBContributoAmmesso.Text), 2, MidpointRounding.AwayFromZero);
            decimal ContributoCalcolato = Math.Round(new_importo * quotaImporto / 100, 2, MidpointRounding.AwayFromZero);
            decimal ContributoRichiesto = Math.Round(_pag_ben.ImportoRichiesto.Value * _investimento.QuotaContributoRichiesto / 100, 2, MidpointRounding.AwayFromZero);

            //calcolo i valori per le textbox nel caso in cui non si premesse prima calcola 
            txtPBContributoAmmesso.Text = string.Format("{0:N}", ContributoCalcolato);
            txtPBImportoNonAmmesso.Text = string.Format("{0:N}", _pag_ben.ImportoRichiesto - new_importo);
            txtPBContributoNonAmmesso.Text = string.Format("{0:N}", Convert.ToDecimal(txtPBContributoRichiesto.Text) - ContributoCalcolato);

            if ((new_importo < _pag_ben.ImportoRichiesto || ContributoCalcolato < ContributoRichiesto)
                && string.IsNullOrEmpty(lstMotivoRiduzione.SelectedValue))
                return "Si richiede di specificare le motivazioni della riduzione per gli importi non ammessi.";
            if ((new_importo < _pag_ben.ImportoRichiesto || ContributoCalcolato < ContributoRichiesto)
                && lstMotivoRiduzione.SelectedValue == "ALT"
                && (txtPBNoteAggiuntive.Text == null || txtPBNoteAggiuntive.Text == ""))
                return "Si richiede di specificare nelle note la motivazioni della riduzione per gli importi.";
            if (new_importo == _pag_ben.ImportoRichiesto
                && ContributoCalcolato == ContributoRichiesto
                && !string.IsNullOrEmpty(lstMotivoRiduzione.SelectedValue))
                return "Le motivazioni della riduzione di spese sono valide solo per gli importi non ammessi.";

            return "";
        }

        private void SalvaPagamentoRichiesto()
        {
            decimal importo_investimento = 0, importo_spese_tecniche = 0, impcomputometrico = 1000000000, importo_lavori_in_economia = 0;
            //if (_investimento.Mobile != null && !_investimento.Mobile)
            //{
            //    decimal.TryParse(txtImportoComputoMetrico.Text, out impcomputometrico);
            //    prichiesto.ImportoComputoMetrico = impcomputometrico;
            //}
            if (_pag_richiesto != null && _pag_richiesto.IdPagamentoRichiesto != null)
            {
                var pbeneficiario_attuali = pag_ben_provider.Find(_pag_richiesto.IdPagamentoRichiesto, null, null, null, null, null);
                foreach (PagamentiBeneficiario pb in pbeneficiario_attuali)
                {
                    if (pb.SpesaTecnicaRichiesta)
                        importo_spese_tecniche += pb.ImportoRichiesto;
                    else if (pb.IdPagamentoBeneficiario == _pag_ben.IdPagamentoBeneficiario)
                        importo_investimento += Decimal.Parse(txtPBImportoRichiesto.Text);
                    else
                        importo_investimento += pb.ImportoRichiesto;
                    if (pb.CodTipo == "LEC")
                        importo_lavori_in_economia += pb.ImportoRichiesto;
                }
            }
            // controllo su computo metrico
            //if (importo_investimento > impcomputometrico) importo_investimento = impcomputometrico;
            // memorizzo il richiesto non troncato
            _pag_richiesto.ImportoRichiesto = importo_investimento + importo_spese_tecniche;

            #region calcolo il contributo
            //suddivido il contributo tra costo investimento e spese tecniche (mutuo 112 niente spese tecniche)
            decimal contributo_spese_tecniche_richiesto = 0;
            if (_investimento.SpeseGenerali != null && importo_spese_tecniche > _investimento.SpeseGenerali) importo_spese_tecniche = _investimento.SpeseGenerali;
            if (_investimento.CodTipoInvestimento != 2 && _investimento.QuotaSpeseGenerali != null && _investimento.QuotaSpeseGenerali > 0)
            {
                decimal max_spese_tecniche_investimento = (_investimento.CostoInvestimento * _investimento.QuotaSpeseGenerali / 100);
                if (importo_spese_tecniche > max_spese_tecniche_investimento) importo_spese_tecniche = max_spese_tecniche_investimento;
                contributo_spese_tecniche_richiesto = Math.Round(importo_spese_tecniche * _investimento.QuotaContributoRichiesto / 100, 2, MidpointRounding.AwayFromZero);
            }
            // tronco l'importo su cui calcolare il contributo per evitare che prenda anche la capienza delle spese tecniche
            if (importo_investimento > _investimento.CostoInvestimento) importo_investimento = _investimento.CostoInvestimento;
            decimal contributo_costo_investimento_calcolato = Math.Round(importo_investimento * _investimento.QuotaContributoRichiesto / 100, 2, MidpointRounding.AwayFromZero);
            decimal contributo_calcolato = contributo_costo_investimento_calcolato + contributo_spese_tecniche_richiesto;

            // controllo il disponibile per l'investimento
            decimal contributo_disponibile = _investimento.ContributoRichiesto.Value - DbStaticProvider.GetAmmontareErogatoInvestimento(
                _investimento.IdInvestimento, _domanda.IdDomandaPagamento, domande_provider.DbProviderObj);
            if (contributo_disponibile < 0) contributo_disponibile = 0;
            if (contributo_calcolato > contributo_disponibile) contributo_calcolato = contributo_disponibile;


            //if (contributo_calcolato > 0)
            //{
            //    //controllo disponibile di progetto correlato 
            //    decimal contributo_disponibile_domanda = domande_provider.CalcoloContributoRichiestoDisponibilePagamento(_investimento.IdProgetto,
            //        _domanda.IdDomandaPagamento, _investimento.CodTipoInvestimento, (_pag_richiesto != null ? _pag_richiesto.IdPagamentoRichiesto : null));
            //    if (contributo_calcolato > contributo_disponibile_domanda) contributo_calcolato = contributo_disponibile_domanda;
            //}





            // controllo quota dei lavori in economia (contributo richiesto<=importo_computo_metrico-importo lav in economia)
            //if (importo_lavori_in_economia > 0)
            //{
            //    if (string.IsNullOrEmpty(txtImportoComputoMetrico.Text) || impcomputometrico == 0)
            //        throw new Exception("Per richiedere il pagamento dei lavori in economia è necessario specificare l`importo da computo metrico.");
            //    //L`ammontare dei lavori in economia è maggiore della differenza tra importo da computo metrico e contributo. Impossibile continuare.
            //    decimal importo_fatturato_effettivo = Math.Min(impcomputometrico, importo_investimento) + importo_spese_tecniche - importo_lavori_in_economia;
            //    if (contributo_calcolato > importo_fatturato_effettivo) contributo_calcolato = importo_fatturato_effettivo;
            //    if (contributo_calcolato < 0) contributo_calcolato = 0;
            //}

            #endregion

            //Contributo Altre Fonti
            if (_domanda != null && _domanda.UtilizzaStrumentiFinanziari)
                _pag_richiesto.ContributoRichiestoAltreFonti = Math.Round(_pag_richiesto.ImportoRichiesto * (_investimento.QuotaContributoAltreFonti != null ? _investimento.QuotaContributoAltreFonti / 100 : 0), 2, MidpointRounding.AwayFromZero);
            else
                _pag_richiesto.ContributoRichiestoAltreFonti = null;

            _pag_richiesto.ContributoRichiesto = contributo_calcolato;
            _pag_richiesto.DataRichiestaPagamento = DateTime.Now;

            //Controllo su importo richiesto max in base a quanto richiesto in altre voci del piano in tutte le domande non annullate
            var pag_ben_giustificativo_list = pag_ben_provider.Find(null, null, null, Giustificativo.IdGiustificativo, null, null)
                .ToArrayList<PagamentiBeneficiario>();
            var pag_ric_list = pag_ric_provider.Find(null, null, Domanda.IdProgetto, null)
                .ToArrayList<PagamentiRichiesti>();
            var domande_progetto_list = domande_provider.Find(null, null, Domanda.IdProgetto, null)
                .ToArrayList<DomandaDiPagamento>();

            var importi_richiesti_precedenti = (from p in pag_ben_giustificativo_list
                                                join ric in pag_ric_list on p.IdPagamentoRichiesto equals ric.IdPagamentoRichiesto
                                                join dom in domande_progetto_list on ric.IdDomandaPagamento equals dom.IdDomandaPagamento
                                                where p.IdPagamentoBeneficiario != _pag_ben.IdPagamentoBeneficiario
                                                    && (dom.Annullata == null || dom.Annullata == false)
                                                select p
                                                )
                                                .Where(p => p.IdPagamentoBeneficiario != _pag_ben.IdPagamentoBeneficiario)
                                                .Distinct()
                                                .Sum(p => p.ImportoRichiesto);

            var max_imponibile = Giustificativo.Imponibile;
            if (Giustificativo.IvaNonRecuperabile != null && Giustificativo.IvaNonRecuperabile)
                max_imponibile = Giustificativo.Imponibile * (100 + Giustificativo.Iva) / 100;

            if ((importi_richiesti_precedenti + _pag_ben.ImportoRichiesto) > Math.Round(max_imponibile.Value, 2, MidpointRounding.AwayFromZero))
                throw new Exception("Non è possibile richiedere un importo maggiore dell'imponibile disponibile del giustificativo");

            pag_ric_provider.Save(_pag_richiesto);
        }

        private decimal getTotaleImportoAmmessoInvestimentoAltreDomande()
        {
            PagamentiRichiestiCollection pagamentiRichiestiAmmessi = pag_ric_provider.Find(null, _investimento.IdInvestimento, _domanda.IdProgetto, null);

            decimal importoAmmesso = 0;
            foreach (PagamentiRichiesti p in pagamentiRichiestiAmmessi)
            {
                if (p.IdDomandaPagamento != _domanda.IdDomandaPagamento)
                {
                    DomandaDiPagamento d = domande_provider.GetById(p.IdDomandaPagamento);
                    if (d.Approvata != null && d.Approvata && d.SegnaturaApprovazione != null)
                        importoAmmesso += p.ImportoAmmesso;
                }
            }

            return importoAmmesso;
        }

        public decimal getTotalePagamentiRiassegnatiDomanda(decimal? cifraCorrenteDaEscludere, int idDomanda)
        {
            decimal totale_contributi_riassegnati_investimento = 0;
            PagamentiRichiestiCollection pagamenti_richiesti_totali_investimento = pag_ric_provider.Find(null, null, _domanda.IdProgetto, idDomanda);
            foreach (PagamentiRichiesti p in pagamenti_richiesti_totali_investimento)
            {
                if (p.ContributoDisavanzoCostiAmmessi != null)
                    totale_contributi_riassegnati_investimento += p.ContributoDisavanzoCostiAmmessi;
            }
            decimal corrente = 0;
            if (cifraCorrenteDaEscludere != null)
                corrente = cifraCorrenteDaEscludere.Value;
            return totale_contributi_riassegnati_investimento - corrente;
        }

        public decimal getTotalePagamentiRiassegnatiInvestimento(decimal? cifraCorrenteDaEscludere, int idInvestimento)
        {
            decimal totale_contributi_riassegnati_investimento = 0;
            PagamentiRichiestiCollection pagamenti_richiesti_totali_investimento = pag_ric_provider.Find(null, idInvestimento, _domanda.IdProgetto, null);
            foreach (PagamentiRichiesti p in pagamenti_richiesti_totali_investimento)
            {
                var dom = new SiarBLL.DomandaDiPagamentoCollectionProvider().GetById(p.IdDomandaPagamento);

                if (!dom.Annullata && p.IdDomandaPagamento != _domanda.IdDomandaPagamento && p.ContributoDisavanzoCostiAmmessi != null)
                    totale_contributi_riassegnati_investimento += p.ContributoDisavanzoCostiAmmessi;
            }
            decimal corrente = 0;
            if (cifraCorrenteDaEscludere != null)
                corrente = cifraCorrenteDaEscludere.Value;
            return totale_contributi_riassegnati_investimento - corrente;
        }

        private bool checkAltreDomandeProgetto(SiarLibrary.NullTypes.IntNT intNT)
        {
            // se ci sono altre domande di pagamento controllo che siano tutte firmate altrimenti non posso spalmare nessuna cifra.
            DomandaDiPagamentoCollection domande = domande_provider.Find(null, null, _domanda.IdProgetto, null);
            bool ok = true;
            if (domande.Count > 1)
            {
                foreach (SiarLibrary.DomandaDiPagamento d in domande)
                {
                    if (d.IdDomandaPagamento != _domanda.IdDomandaPagamento)
                    {
                        if (d.SegnaturaApprovazione == null)
                            ok = false;
                    }
                }
            }
            return ok;
        }

        private void SalvaPagamentoAmmesso()
        {
            decimal importo_investimento = 0, contributo_investimento = 0, importo_spese_tecniche = 0, impcomputometrico = 1000000000, importo_lavori_in_economia = 0;
            if (_pag_richiesto != null && _pag_richiesto.IdPagamentoRichiesto != null)
            {
                var pbeneficiario_attuali = pag_ben_provider.Find(_pag_richiesto.IdPagamentoRichiesto, null, null, null, null, null);
                foreach (PagamentiBeneficiario pb in pbeneficiario_attuali)
                {
                    if (pb.ImportoAmmesso != null)
                    {
                        if (pb.SpesaTecnicaAmmessa)
                            importo_spese_tecniche += pb.ImportoAmmesso;
                        else if (pb.IdPagamentoBeneficiario == _pag_ben.IdPagamentoBeneficiario)
                            importo_investimento += Decimal.Parse(txtPBImportoAmmesso.Text);
                        else
                            importo_investimento += pb.ImportoAmmesso;
                        if (pb.CodTipo == "LEC")
                            importo_lavori_in_economia += pb.ImportoAmmesso;
                    }
                    else
                    {
                        if (pb.IdPagamentoBeneficiario == _pag_ben.IdPagamentoBeneficiario)
                            importo_investimento += Decimal.Parse(txtPBImportoAmmesso.Text);
                    }
                    if (pb.ContributoAmmesso != null)
                    {
                        if (pb.IdPagamentoBeneficiario == _pag_ben.IdPagamentoBeneficiario)
                            contributo_investimento += Decimal.Parse(txtPBContributoAmmesso.Text);
                        else
                            contributo_investimento += pb.ContributoAmmesso;
                    }
                    else
                    {
                        if (pb.IdPagamentoBeneficiario == _pag_ben.IdPagamentoBeneficiario)
                            contributo_investimento += Decimal.Parse(txtPBContributoAmmesso.Text);
                    }
                }
            }
            // memorizzo il richiesto non troncato
            _pag_richiesto.ImportoAmmesso = importo_investimento + importo_spese_tecniche;

            #region calcolo il contributo
            //suddivido il contributo tra costo investimento e spese tecniche (mutuo 112 niente spese tecniche)           
            decimal contributo_spese_tecniche_richiesto = 0;
            if (_investimento.SpeseGenerali != null && importo_spese_tecniche > _investimento.SpeseGenerali)
                importo_spese_tecniche = _investimento.SpeseGenerali;
            if (_investimento.CodTipoInvestimento != 2 && _investimento.QuotaSpeseGenerali != null && _investimento.QuotaSpeseGenerali > 0)
            {
                decimal max_spese_tecniche_investimento = (_investimento.CostoInvestimento * _investimento.QuotaSpeseGenerali / 100);
                if (importo_spese_tecniche > max_spese_tecniche_investimento)
                    importo_spese_tecniche = max_spese_tecniche_investimento;
                contributo_spese_tecniche_richiesto = Math.Round(importo_spese_tecniche * _investimento.QuotaContributoRichiesto / 100, 2, MidpointRounding.AwayFromZero);
            }
            // tronco l'importo su cui calcolare il contributo per evitare che prenda anche la capienza delle spese tecniche
            if (importo_investimento > _investimento.CostoInvestimento)
                importo_investimento = _investimento.CostoInvestimento;
            //decimal contributo_costo_investimento_calcolato = Math.Round(importo_investimento * _investimento.QuotaContributoRichiesto / 100, 2, MidpointRounding.AwayFromZero);
            decimal contributo_costo_investimento_calcolato = contributo_investimento;
            decimal contributo_calcolato = contributo_costo_investimento_calcolato + contributo_spese_tecniche_richiesto;

            // controllo il disponibile per l'investimento
            decimal contributo_disponibile = _investimento.ContributoRichiesto.Value - DbStaticProvider.GetAmmontareErogatoInvestimento(
                _investimento.IdInvestimento, _domanda.IdDomandaPagamento, domande_provider.DbProviderObj);
            if (contributo_disponibile < 0)
                contributo_disponibile = 0;
            if (contributo_calcolato > contributo_disponibile)
                contributo_calcolato = contributo_disponibile;
            if (contributo_calcolato > 0)
            {
                ////controllo disponibile di progetto correlato 
                //decimal contributo_disponibile_domanda = domande_provider.CalcoloContributoAmmessoDisponibilePagamento(_investimento.IdProgetto,
                //    _domanda.IdDomandaPagamento, _investimento.CodTipoInvestimento, _pag_richiesto.IdPagamentoRichiesto);
                //if (contributo_calcolato > contributo_disponibile_domanda)
                //    contributo_calcolato = contributo_disponibile_domanda;
                // controllo sul richiesto
                if (contributo_calcolato > _pag_richiesto.ContributoRichiesto)
                    contributo_calcolato = _pag_richiesto.ContributoRichiesto;
            }

            #endregion

            #region getDisavanzo()
            //totali richiesti fino ad ora
            decimal storico_contributo_richiesto = DbStaticProvider.GetStoricoContributoRichiestoInvestimento(_investimento.IdInvestimento,
                _domanda.IdDomandaPagamento, domande_provider.DbProviderObj);
            decimal storico_importo_richiesto = DbStaticProvider.GetStoricoImportoRichiestoInvestimento(_investimento.IdInvestimento,
                _domanda.IdDomandaPagamento, domande_provider.DbProviderObj);

            // mi serve l'investimento attuale
            // non vanno bene le spese richieste, devo sempre verificare quelle ammesse
            decimal storico_spese_richieste = 0;
            storico_spese_richieste = storico_importo_richiesto; // decimal.TryParse(txtStoricoImportoRichiesto.Text, out storico_spese_richieste);

            var pagamenti_benef_inv = pag_ben_provider.Find(_pag_richiesto.IdPagamentoRichiesto, null, null, null, null, null)
                .ToArrayList<PagamentiBeneficiario>();
            var importo_investimento_richiesto = (from pb in pagamenti_benef_inv
                                                  where pb.SpesaTecnicaRichiesta == null || pb.SpesaTecnicaRichiesta == false
                                                  select pb)
                .Sum(p => p.ImportoRichiesto);
            decimal importo_investimento_attuale_richiesto = 0;
            importo_investimento_attuale_richiesto = importo_investimento_richiesto; //decimal.TryParse(txtImportoInvestimento.Text, out importo_investimento_attuale_richiesto);

            /*
            decimal importo_investimento_ammesso = 0;
            importo_investimento_ammesso = (from pb in pagamenti_benef_inv
                                            where pb.SpesaTecnicaAmmessa == null || pb.SpesaTecnicaAmmessa == false
                                            select pb)
                .Sum(p => p.ImportoAmmesso); //decimal.TryParse(txtImportoInvestimentoAmmesso.Text, out importo_investimento_ammesso);
            */

            decimal totale_ammesso = 0;
            totale_ammesso = _pag_richiesto.ImportoAmmesso; //decimal.TryParse(txtImportoTotaleAmmesso.Text, out totale_ammesso);

            // un metodo che mi calcola questo ed eventualmente mi dice quanto ho riassegnato. Lo vedo da pagamenti richiesti
            decimal totale_ammesso_investimento_altre_domdande = getTotaleImportoAmmessoInvestimentoAltreDomande();

            decimal disavanzo = 0;
            // se prendo solo il costo investimento della domanda attuale mi perdo i vecchi e quindi mi perdo il disavanzo
            if (totale_ammesso + totale_ammesso_investimento_altre_domdande > _investimento.CostoInvestimento)
            {
                disavanzo = totale_ammesso + totale_ammesso_investimento_altre_domdande - _investimento.CostoInvestimento;
                if (disavanzo > _investimento.CostoInvestimento * 10 / 100)
                    disavanzo = _investimento.CostoInvestimento * 10 / 100;
                //txtDisavanzoInvestimento.Text = string.Format("{0:N}", Math.Round(disavanzo, 2, MidpointRounding.AwayFromZero));
                //txtDisavanzoInvestimentoContributo.Text = string.Format("{0:N}", Math.Round(disavanzo * _investimento.QuotaContributoRichiesto / 100, 2, MidpointRounding.AwayFromZero));
            }
            //else
            //{
            //    txtDisavanzoInvestimento.Text = string.Format("{0:N}", "0,00");
            //    txtDisavanzoInvestimentoContributo.Text = string.Format("{0:N}", "0,00");
            //}

            decimal totale_importi_economia = 0;
            decimal totale_contributi_economia = 0;
            decimal pag_inv_importo_ammesso = 0;
            decimal pag_inv_contributo_ammesso = 0;
            // decimal pag_inv_importo_richiesto = 0;
            decimal pag_inv_contributo_richiesto = 0;
            PianoInvestimentiCollection investimenti = investimenti_provider.GetPianoInvestimentiDomandaPagamento(_domanda.IdProgetto, _domanda.IdDomandaPagamento);
            PagamentiRichiestiCollection pagamenti_richiesti = pag_ric_provider.Find(null, null, _domanda.IdProgetto, _domanda.IdDomandaPagamento);
            foreach (SiarLibrary.PianoInvestimenti f in investimenti.FiltroTipoInvestimento(1))
            {
                decimal importo_pagamento_ammesso = 0;
                PagamentiRichiestiCollection pagamenti = pagamenti_richiesti.FiltroInvestimento(f.IdInvestimento);
                if (pagamenti.Count > 0)
                {
                    if (pagamenti[0].ImportoAmmesso != null)
                    {
                        pag_inv_importo_ammesso += pagamenti[0].ImportoAmmesso;
                        importo_pagamento_ammesso = pagamenti[0].ImportoAmmesso;
                    }
                    if (pagamenti[0].ContributoAmmesso != null)
                        pag_inv_contributo_ammesso += pagamenti[0].ContributoAmmesso;
                    pag_inv_contributo_richiesto += pagamenti[0].ContributoRichiesto;
                }

                decimal importo_pagamento_richiesti = 0;
                decimal.TryParse(f.AdditionalAttributes["ImportoPagamentoRichiesto"], out importo_pagamento_richiesti);
                if (f.CostoInvestimento > importo_pagamento_ammesso + importo_pagamento_richiesti)
                {
                    decimal economia_spesa = f.CostoInvestimento - importo_pagamento_richiesti - importo_pagamento_ammesso;
                    if (economia_spesa > f.CostoInvestimento * 10 / 100)
                        economia_spesa = f.CostoInvestimento * 10 / 100;
                    totale_importi_economia += economia_spesa;
                    decimal economia_contributo = economia_spesa * f.QuotaContributoRichiesto / 100;
                    if (economia_contributo > f.ContributoRichiesto * 10 / 100)
                        economia_contributo = f.ContributoRichiesto * 10 / 100;
                    // if (pagamenti.Count > 0)
                    totale_contributi_economia += economia_contributo;
                }
            }

            decimal totale_contributi_riassegnati_domanda = getTotalePagamentiRiassegnatiDomanda(null, _domanda.IdDomandaPagamento);
            decimal totale_contributi_riassegnati_investimento = getTotalePagamentiRiassegnatiInvestimento(null, _investimento.IdInvestimento);

            //txtEconomieDaCoprire.Text = string.Format("{0:N}", Math.Round(totale_contributi_economia, 2, MidpointRounding.AwayFromZero));
            //txtEconomieScoperte.Text = string.Format("{0:N}", Math.Round(totale_contributi_economia = totale_contributi_economia - totale_contributi_riassegnati_domanda, 2, MidpointRounding.AwayFromZero));
            //txtImportoRiassegnatoInvestimento.Text = string.Format("{0:N}", Math.Round(totale_contributi_riassegnati_investimento, 2, MidpointRounding.AwayFromZero));
            #endregion

            decimal costoDaAssegnare = 0;
            costoDaAssegnare = _pag_richiesto.ImportoDisavanzoCostiAmmessi != null ? _pag_richiesto.ImportoDisavanzoCostiAmmessi : 0.00; //decimal.TryParse(txtCostoDaAssegnare.Text, out costoDaAssegnare);

            decimal economieDaCoprire = 0;
            economieDaCoprire = totale_contributi_economia; // decimal.TryParse(txtEconomieDaCoprire.Text, out economieDaCoprire);

            decimal contributoDisavanzoVecchio = 0;
            if (_pag_richiesto.ContributoDisavanzoCostiAmmessi != null)
                contributoDisavanzoVecchio = _pag_richiesto.ContributoDisavanzoCostiAmmessi;
            decimal contributoDisavanzoAttuale = costoDaAssegnare * _investimento.QuotaContributoRichiesto / 100;

            decimal economieScoperte = economieDaCoprire - (getTotalePagamentiRiassegnatiDomanda(contributoDisavanzoVecchio, _domanda.IdDomandaPagamento) + contributoDisavanzoAttuale);

            decimal disavanzoInvestimento = 0;
            disavanzoInvestimento = disavanzo; //decimal.TryParse(txtDisavanzoInvestimento.Text, out disavanzoInvestimento);

            decimal contributiRiassegnatiInvestimento = 0;
            contributiRiassegnatiInvestimento = totale_contributi_riassegnati_investimento; //decimal.TryParse(txtImportoRiassegnatoInvestimento.Text, out contributiRiassegnatiInvestimento);

            bool altreDomandeOk = checkAltreDomandeProgetto(_domanda.IdProgetto);


            // contributo dispoibile - contributo riassegnato - contributo da assegnare deve essere >= 0
            decimal contributoDisponibile = disavanzoInvestimento * _investimento.QuotaContributoRichiesto / 100;
            decimal contributoDaAssegnare = costoDaAssegnare * _investimento.QuotaContributoRichiesto / 100;

            if (costoDaAssegnare > disavanzoInvestimento)
                throw new Exception("Non si possono assegnare più fondi di quelli a disposizione.");
            if (costoDaAssegnare * _investimento.QuotaContributoRichiesto / 100 > economieDaCoprire
                || economieScoperte < 0)
                throw new Exception("Il contributo non può superare il massimo assegnabile.");
            if (contributoDisponibile - contributiRiassegnatiInvestimento - contributoDaAssegnare < 0)
                throw new Exception("I contributi in disavanzo totali disponibili per l'investimento sono stati esauriti tra tutte le domande di pagamento presentate. Modificare l'importo.");
            if (costoDaAssegnare > 0 && !altreDomandeOk)
                throw new Exception("Non si possono assegnare fondi se ci sono altre domande di pagamento per il progetto che non sono ancora state istruite.");

            _pag_richiesto.ImportoDisavanzoCostiAmmessi = costoDaAssegnare;
            _pag_richiesto.ContributoDisavanzoCostiAmmessi = costoDaAssegnare * _investimento.QuotaContributoRichiesto / 100;

            _pag_richiesto.ContributoAmmesso = contributo_calcolato;

            //Contributo Altre Fonti
            if (_domanda != null && _domanda.UtilizzaStrumentiFinanziari)
                _pag_richiesto.ContributoAmmessoAltreFonti = Math.Round((_pag_richiesto.ImportoAmmesso + costoDaAssegnare) * _investimento.QuotaContributoAltreFonti / 100, 2, MidpointRounding.AwayFromZero);
            else
                _pag_richiesto.ContributoAmmessoAltreFonti = null;

            _pag_richiesto.Ammesso = true;
            _pag_richiesto.DataValutazione = DateTime.Now;
            _pag_richiesto.Istruttore = _utente.CfUtente;
            //_pag_richiesto.NoteIstruttore = txtValutazioneLunga.Text;
            pag_ric_provider.Save(_pag_richiesto);
        }

        void dgSpeseGiustificativo_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;

            if (dgi.ItemType == ListItemType.Header)
            {
                //dgi.CssClass = "TESTA1";
                //dgi.Cells[0].ColumnSpan = 5;
                //dgi.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                //dgi.Cells[0].Text = "Dati spesa</td><td colspan=2 align=center>Beneficiario</td><td colspan=3 align=center>Istruttore</td><tr class='TESTA1'><td>Tipo pagamento</td>";
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SpeseSostenute spesa = (SpeseSostenute)dgi.DataItem;

                dgi.Cells[0].Text = "<b>Tipo:</b> " + spesa.TipoPagamento
                    + "<br><b>Estremi:</b> " + spesa.Estremi;

                if (_utente.Profilo.Equals("Utente singolo")
                    || _utente.Profilo.Equals("Consulente"))
                {
                    if (_domanda.Segnatura != null)
                    {
                        if (spesa.InIntegrazione == null
                            || spesa.InIntegrazione == false)
                            dgi.Cells[5].Text = "false";
                        else
                            dgi.Cells[5].Text = "true";
                    }
                    else
                        dgi.Cells[5].Text = "true";
                }
                else if (_istruttore != null
                    && _istruttore.Nominativo.Equals(Utente.Nominativo))
                {
                    if (_domanda.Segnatura == null
                        || _domanda.SegnaturaApprovazione != null)
                        dgi.Cells[5].Text = "false";
                    else
                        dgi.Cells[5].Text = "true";
                }
                else
                {
                    dgi.Cells[5].Text = "false";
                }
            }
        }

        #region Button_Click

        protected void btnSalvaPag_Click(object sender, EventArgs e)
        {
            try
            {
                CaricaHidden();

                SiarLibrary.CollaboratoriXBandoCollection istruttori = new SiarBLL.CollaboratoriXBandoCollectionProvider()
                    .Find(null, _domanda.IdProgetto, _utente.IdUtente, null, true);

                if (_utente.Profilo.Equals("Utente singolo")
                    || _utente.Profilo.Equals("Consulente"))
                {
                    string errore = VerificaSalvataggioBeneficiario();
                    if (errore == null || errore.Equals(""))
                    {
                        _pag_ben.ImportoRichiesto = txtPBImportoRichiesto.Text;
                        if (_pag_ben.ImportoAmmesso != null
                                && _pag_ben.ImportoAmmesso > _pag_ben.ImportoRichiesto)
                            throw new Exception("Non è possibile richiedere un importo minore di quanto già ammesso dall'istruttore.");
                        SalvaPagamentoRichiesto();
                        pag_ben_provider.Save(_pag_ben);
                    }
                    else
                        throw new Exception(errore);
                }
                else if ((istruttori.Count > 0
                    && istruttori[0].Nominativo.Equals(Utente.Nominativo)) || ControlloCollaboratoreIstruttoria())
                {
                    string errore = VerificaSalvataggioIstruttore();
                    if (errore == null || errore.Equals(""))
                    {
                        _pag_ben.ImportoAmmesso = txtPBImportoAmmesso.Text;
                        _pag_ben.QuotaContributoAmmesso = txtPBContributoAmmessoQuota.Text;
                        _pag_ben.ContributoAmmesso = Math.Round(_pag_ben.ImportoAmmesso * _pag_ben.QuotaContributoAmmesso / 100, 2, MidpointRounding.AwayFromZero);
                        _pag_ben.CodRiduzione = lstMotivoRiduzione.SelectedValue;

                        SiarLibrary.Note motivazioni = new SiarLibrary.Note();
                        if (_pag_ben.MotivazioneRiduzione != null) motivazioni = note_provider.GetById(_pag_ben.MotivazioneRiduzione);
                        if (!string.IsNullOrEmpty(txtPBNoteAggiuntive.Text))
                        {
                            motivazioni.Testo = txtPBNoteAggiuntive.Text;
                            note_provider.Save(motivazioni);
                            _pag_ben.MotivazioneRiduzione = motivazioni.Id;
                        }
                        else if (motivazioni.Id != null)
                        {
                            note_provider.Delete(motivazioni);
                            _pag_ben.MotivazioneRiduzione = null;
                        }

                        SalvaPagamentoAmmesso();
                        pag_ben_provider.Save(_pag_ben);
                        domande_provider.AggiornaDomandaDiPagamentoIstruttore(_domanda, _utente);
                        domande_provider.DbProviderObj.Commit();
                    }
                    else
                        throw new Exception(errore);
                }
                else
                {
                    throw new Exception("Non si hanno i permessi.");
                }

                ((SiarLibrary.Web.PrivatePage)Page).ShowMessage("Dati salvati correttamente.");
            }
            catch (Exception ex) { ((SiarLibrary.Web.PrivatePage)Page).ShowError(ex.Message); }
            finally
            {
                hdnSpese.Value = "false";
                hdnIdSpesa.Value = null;
                ((SiarLibrary.Web.PrivatePage)Page).RegisterClientScriptBlock(Mostra);
            }
        }

        protected void btnSalvaImportiSpesa_Click(object sender, EventArgs e)
        {
            try
            {
                CaricaHidden();

                var importo_nuovo = decimal.Parse(txtNettoSpesa.Text);
                var domande_list = domande_provider.Find(null, null, _domanda.IdProgetto, null)
                    .ToArrayList<DomandaDiPagamento>();
                var spese_list = spese_provider.Find(null, _giustificativo.IdGiustificativo, null)
                    .ToArrayList<SpeseSostenute>();
                var totale_spese = (from s in spese_list
                                    join d in domande_list on s.IdDomandaPagamento equals d.IdDomandaPagamento
                                    where d.Annullata == false
                                    select s)
                    .Sum(s => s.Importo);

                var max_imponibile = _giustificativo.Imponibile;
                if (_giustificativo.IvaNonRecuperabile != null && _giustificativo.IvaNonRecuperabile)
                    max_imponibile = Math.Round(max_imponibile * (_giustificativo.Iva + 100) / 100, 2, MidpointRounding.AwayFromZero);
                //17-02-2023 Commentato controllo campi giustificativi per PASS#187931
                //if (totale_spese + importo_nuovo - _spesa_selezionata.Importo > max_imponibile)
                //    throw new Exception("L`importo netto dei pagamenti riferiti al giustificativo selezionato supera l'ammontare del giustificativo. Impossibile continuare.");

                if (_spesa_selezionata.Importo > importo_nuovo)
                {
                    var totale_spese_domanda = (from s in spese_list
                                                join d in domande_list on s.IdDomandaPagamento equals d.IdDomandaPagamento
                                                where d.IdDomandaPagamento == _domanda.IdDomandaPagamento
                                                select s)
                        .Sum(s => s.Importo);

                    if (_pag_ben.ImportoAmmesso != null
                        && (_pag_ben.ImportoAmmesso > totale_spese_domanda + importo_nuovo - _spesa_selezionata.Importo))
                        throw new Exception("Non è possibile modificare l'importo della spesa perché l'importo ammesso supererebbe il totale delle spese asssociate al giustificativo. Se necessario, modificare prima l'importo ammesso.");
                }

                _spesa_selezionata.Importo = txtLordoSpesa.Text;
                _spesa_selezionata.Netto = txtNettoSpesa.Text;
                spese_provider.Save(_spesa_selezionata);

                ((SiarLibrary.Web.PrivatePage)Page).ShowMessage("Importi spesa salvati correttamente.");
            }
            catch (Exception ex) { ((SiarLibrary.Web.PrivatePage)Page).ShowError(ex.Message); }
            finally
            {
                hdnSpese.Value = "false";
                hdnIdSpesa.Value = null;
                ((SiarLibrary.Web.PrivatePage)Page).RegisterClientScriptBlock(Mostra);
            }
        }

        protected void btnEliminaPag_Click(object sender, EventArgs e)
        {
            try
            {
                CaricaHidden();

                if (_pag_ben == null || _pag_ben.IdPagamentoBeneficiario == null)
                    throw new Exception("Si è verificato un errore nella procedura.");

                var prichiesto = pag_ric_provider.GetById(_pag_ben.IdPagamentoRichiesto);
                if (prichiesto == null)
                    throw new Exception("Si è verificato un errore nella procedura.");

                domande_provider.DbProviderObj.BeginTran();
                pag_ben_provider.Delete(_pag_ben);
                if (pag_ben_provider.Find(prichiesto.IdPagamentoRichiesto, null, null, null, null, null).Count == 0)
                {
                    pag_ric_provider.Delete(prichiesto);
                    prichiesto = null;
                }
                else
                    SalvaPagamentoRichiesto();
                domande_provider.AggiornaDomandaDiPagamento(_domanda, _utente);
                domande_provider.DbProviderObj.Commit();
                ((SiarLibrary.Web.PrivatePage)Page).RegisterClientScriptBlock("chiudiPopup();");
                ((SiarLibrary.Web.PrivatePage)Page).ShowMessage("La spesa selezionata è stata rimossa correttamente.");
                svuotaHidden();
            }
            catch (Exception ex)
            {
                domande_provider.DbProviderObj.Rollback();
                ((SiarLibrary.Web.PrivatePage)Page).RegisterClientScriptBlock("chiudiPopup();");
                ((SiarLibrary.Web.PrivatePage)Page).ShowError(ex);
            }
        }

        #endregion
    }
}