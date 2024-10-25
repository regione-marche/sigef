using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarLibrary;
using SiarLibrary.Web;
using SiarBLL;

namespace web.CONTROLS
{
    public partial class ucContrattoFem : System.Web.UI.UserControl
    {
        private Utenti _utente;
        public Utenti Utente
        {
            get { return _utente; }
            set { _utente = value; }
        }

        private ContrattiFem _contratto;
        public ContrattiFem Contratto
        {
            get { return _contratto; }
            set { _contratto = value; }
        }

        private Progetto _progetto;
        public Progetto Progetto
        {
            get { return _progetto; }
            set { _progetto = value; }
        }

        private DomandaDiPagamento _domanda;
        public DomandaDiPagamento Domanda
        {
            get { return _domanda; }
            set { _domanda = value; }
        }

        private string _mostra;
        public string Mostra
        {
            get { return _mostra; }
            //set { _mostra = value; }
        }

        CollaboratoriXBando _istruttore;

        #region Collection Provider
        private ContrattiFemCollectionProvider contratti_provider;
        private ProgettoCollectionProvider progetto_provider;
        private DomandaDiPagamentoCollectionProvider domanda_provider;
        private UtentiCollectionProvider utenti_provider;
        private ImpresaCollectionProvider impresa_provider;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            _mostra = "mostraPopupTemplate('" + divPagInv.UniqueID.Replace('$', '_') + "','divBKGMessaggio');";
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (_progetto != null)
            {
                InizializzaProvider();
                txtImpresaContratto.AddJSAttribute("onkeydown", "SNCVolatileZoom(this,event,'SNCVZCercaImpresa');");

                ControlloUtente();
                CaricaDatiContrattoFem();

                popolaHidden();
            }
            base.OnPreRender(e);
        }

        private void InizializzaProvider()
        {
            contratti_provider = new ContrattiFemCollectionProvider();
            progetto_provider = new ProgettoCollectionProvider();
            domanda_provider = new DomandaDiPagamentoCollectionProvider();
            utenti_provider = new UtentiCollectionProvider();
            impresa_provider = new ImpresaCollectionProvider();
        }

        private void popolaHidden()
        {
            if (_contratto != null && _contratto.IdContrattoFem != null)
                hdnModaleContrattoIdContrattoFem.Value = _contratto.IdContrattoFem;

            if (_progetto != null && _progetto.IdProgetto != null)
                hdnModaleContrattoIdProgetto.Value = _progetto.IdProgetto;

            if (_domanda != null && _domanda.IdDomandaPagamento != null)
                hdnModaleContrattoIdDomanda.Value = _domanda.IdDomandaPagamento;

            if (_utente != null && _utente.IdUtente != null)
                hdnModaleContrattoIdUtente.Value = _utente.IdUtente;
        }

        private void svuotaHidden()
        {
            hdnModaleContrattoIdContrattoFem.Value = null;
            hdnModaleContrattoIdProgetto.Value = null;
            hdnModaleContrattoIdDomanda.Value = null;
            hdnModaleContrattoIdUtente.Value = null;
        }

        private void CaricaHidden()
        {
            InizializzaProvider();

            int id_contratto;
            if (int.TryParse(hdnModaleContrattoIdContrattoFem.Value, out id_contratto))
                _contratto = contratti_provider.GetById(id_contratto);

            int id_progetto;
            if (int.TryParse(hdnModaleContrattoIdProgetto.Value, out id_progetto))
                _progetto = progetto_provider.GetById(id_progetto);

            int id_domanda;
            if (int.TryParse(hdnModaleContrattoIdDomanda.Value, out id_domanda))
                _domanda = domanda_provider.GetById(id_domanda);

            int id_utente;
            if (int.TryParse(hdnModaleContrattoIdUtente.Value, out id_utente))
                _utente = utenti_provider.GetById(id_utente);
        }

        private void CaricaDatiContrattoFem()
        {
            if(_contratto != null)
            {
                txtNumeroContratto.Text = _contratto.Numero;
                txtProgettoRiferimento.Text = _contratto.IdProgettoRif;
                txtDataStipula.Text = _contratto.DataStipulaContratto;
                txtImporto.Text = _contratto.Importo;
                txtDataSegnatura.Text = _contratto.DataSegnatura;
                txtSegnatura.Text = _contratto.Segnatura;
                txtDescrizioneContratto.Text = _contratto.Descrizione;
                ufContratto.IdFile = _contratto.IdFile;
                if (_contratto.IdImpresa != null)
                {
                    var imp = impresa_provider.GetById(_contratto.IdImpresa);
                    txtImpresaContratto.Text = imp.RagioneSociale;
                    txtImpresaContratto.ToolTip = imp.RagioneSociale;
                    hdnModaleContrattoIdImpresa.Value = _contratto.IdImpresa;
                }
                else
                {
                    txtImpresaContratto.Text = null;
                    txtImpresaContratto.ToolTip = null;
                    hdnModaleContrattoIdImpresa.Value = null;
                }
            }
            else
            {
                txtNumeroContratto = null;
                txtProgettoRiferimento.Text = null;
                txtDataStipula.Text = null;
                txtImporto.Text = null;
                txtDataSegnatura.Text = null;
                txtSegnatura.Text = null;
                txtDescrizioneContratto.Text = null;
                ufContratto.IdFile = null;
                txtImpresaContratto.Text = null;
                txtImpresaContratto.ToolTip = null;
                hdnModaleContrattoIdImpresa.Value = null;
            }

            txtCuaaModaleContratto.Text = null;
            txtPivaModaleContratto.Text = null;
            txtRagioneSocialeModaleContratto.Text = null;
        }

        private void popolaContrattoFem(DbProvider dbProvider)
        {
            if (txtImporto.Text == null)
                throw new Exception("Campo importo non valorizzato");
            //else if (txtSegnatura.Text == null)
            //    throw new Exception("Campo segnatura non valorizzato");
            //else if (txtDataSegnatura.Text == null)
            //    throw new Exception("Campo data segnatura non valorizzato");
            else if (txtDataStipula.Text == null)
                throw new Exception("Campo data stipula non valorizzato");
            else if (txtProgettoRiferimento.Text != null)
            {
                var testo = txtProgettoRiferimento.Text.Trim();

                int id_progetto;
                if (int.TryParse(testo, out id_progetto))
                {
                    var prog = progetto_provider.GetById(id_progetto);

                    if (prog != null)
                    {
                        _contratto.IdProgettoRif = id_progetto;
                    }
                    else
                        throw new Exception("Progetto di riferimento non trovato: verificare e riprovare");
                }
                else
                    throw new Exception("Progetto di riferimento mal compilato: inserire solo numeri e riprovare. ");
            }

            _contratto.Numero = txtNumeroContratto.Text;
            _contratto.DataStipulaContratto = txtDataStipula.Text;
            _contratto.Importo = txtImporto.Text;
            _contratto.DataSegnatura = txtDataSegnatura.Text;
            _contratto.Segnatura = txtSegnatura.Text;
            _contratto.Descrizione = txtDescrizioneContratto.Text;
            _contratto.IdFile = ufContratto.IdFile;

            popolaImpresa(dbProvider);

            _contratto.OperatoreAggiornamento = _utente.IdUtente;
            _contratto.DataAggiornamento = DateTime.Now;
        }

        private void popolaImpresa(DbProvider dbProvider)
        {
            //Se hanno compilato il modulo, prendo le informazioni da li. Altrimenti uso quelle del campo impresa
            if(txtCuaaModaleContratto.Text != null || txtPivaModaleContratto.Text != null || txtRagioneSocialeModaleContratto.Text != null)
            {
                //Verifico che tutti i campi siano compilati da javascript

                //Verifico se l'impresa esiste già
                var impresa_provider = new ImpresaCollectionProvider(dbProvider);

                var imp_cuaa = impresa_provider.Find(txtPivaModaleContratto.Text, null, null);
                if (imp_cuaa.Count > 0)
                    throw new Exception("Esiste già un impresa con la partita iva inserita. Riprovare inserendo " + imp_cuaa[0].RagioneSociale + " nell'apposito campo.");

                var imp_piva = impresa_provider.Find(null, txtCuaaModaleContratto.Text, null);
                if (imp_piva.Count > 0)
                    throw new Exception("Esiste già un impresa con il codice fiscale inserita. Riprovare inserendo " + imp_piva[0].RagioneSociale + " nell'apposito campo.");

                var imp_rag = impresa_provider.Find(null, null, txtRagioneSocialeModaleContratto.Text);
                if (imp_rag.Count > 0)
                    throw new Exception("Esiste già un impresa con la ragione sociale inserita. Riprovare inserendo " + imp_rag[0].RagioneSociale + " nell'apposito campo.");

                var impresa = new Impresa();
                impresa.Cuaa = txtPivaModaleContratto.Text;
                impresa.CodiceFiscale = txtPivaModaleContratto.Text;
                impresa_provider.Save(impresa);

                var impresa_storico_provider = new ImpresaStoricoCollectionProvider(dbProvider);
                var impresa_storico = new ImpresaStorico();
                impresa_storico.IdImpresa = impresa.IdImpresa;
                impresa_storico.RagioneSociale = txtRagioneSocialeModaleContratto.Text;
                impresa_storico.DataInizioValidita = DateTime.Now;
                impresa_storico_provider.Save(impresa_storico);

                impresa.IdStoricoUltimo = impresa_storico.IdStoricoImpresa;
                impresa_provider.Save(impresa);

                _contratto.IdImpresa = impresa.IdImpresa;
            }
            else if (hdnModaleContrattoIdImpresa.Value != null)
                _contratto.IdImpresa = hdnModaleContrattoIdImpresa.Value;
            else
                _contratto.IdImpresa = null;
        }


        private void ControlloUtente()
        {
            //CollaboratoriXBandoCollection istruttori = new CollaboratoriXBandoCollectionProvider()
            //    .Find(null, _domanda.IdProgetto, _utente.IdUtente, null, true);
            //if (istruttori.Count > 0)
            //    _istruttore = istruttori[0];

            if (_utente.Profilo.Equals("Utente singolo")
                || _utente.Profilo.Equals("Consulente")) //SE E' IL BENEFICIARIO
            {
                if (_domanda.Segnatura != null || _domanda.Annullata == true)
                {
                    btnSalvaContratto.Enabled = false;
                    btnEliminaContratto.Enabled = false;
                    btnMostraNascondiImpresaModaleContratto.Visible = false;

                    txtNumeroContratto.ReadOnly = true;
                    txtDataStipula.ReadOnly = true;
                    txtSegnatura.ReadOnly = true;
                    txtDataSegnatura.ReadOnly = true;
                    txtDescrizioneContratto.ReadOnly = true;
                    ufContratto.AbilitaModifica = false;
                    txtImporto.ReadOnly = true;
                    txtImpresaContratto.ReadOnly = true;
                    labelModuloImpresaContratto.Visible = true;
                }
                else
                {
                    ufContratto.AbilitaModifica = true;
                }
            }
            //else if (istruttori.Count > 0
            //    && _istruttore != null && _istruttore.Nominativo.Equals(Utente.Nominativo)) //SE E' L'ISTRUTTORE
            //{
            //    if (_domanda.Segnatura == null 
            //        || _domanda.SegnaturaApprovazione != null)
            //    {

            //    }
            //}
            else //SE DIVERSO DA BENEFICIARIO // E ISTRUTTORE
            {
                btnSalvaContratto.Enabled = false;
                btnEliminaContratto.Enabled = false;
                btnMostraNascondiImpresaModaleContratto.Visible = false;

                txtNumeroContratto.ReadOnly = true;
                txtDataStipula.ReadOnly = true;
                txtSegnatura.ReadOnly = true;
                txtDataSegnatura.ReadOnly = true;
                txtDescrizioneContratto.ReadOnly = true;
                ufContratto.AbilitaModifica = false;
                txtImporto.ReadOnly = true;
                txtImpresaContratto.ReadOnly = true;
                labelModuloImpresaContratto.Visible = true;
            }
        }

        #region Button_Click

        protected void btnSalvaContratto_Click(object sender, EventArgs e)
        {
            try
            {
                CaricaHidden();
                contratti_provider.DbProviderObj.BeginTran();

                if(_contratto == null)
                {
                    _contratto = new ContrattiFem();
                    _contratto.OperatoreCreazione = _utente.IdUtente;
                    _contratto.DataCreazione = DateTime.Now;
                    _contratto.IdProgetto = _progetto.IdProgetto;
                    _contratto.IdBando = _progetto.IdBando;
                    _contratto.IdDomandaPagamento = _domanda.IdDomandaPagamento;
                }

                popolaContrattoFem(contratti_provider.DbProviderObj);

                var totaleContrattiDomandaPagamento = contratti_provider.GetTotaleContrattiDomandaPagamento(_contratto.IdProgetto, _contratto.IdDomandaPagamento, _contratto.IdContrattoFem);
                decimal importoFemCalcolato = new ProgettoCollectionProvider().CalcolaTotaleContributo(_contratto.IdProgetto);
                if (totaleContrattiDomandaPagamento + _contratto.Importo > importoFemCalcolato)
                    throw new Exception("L'importo inserito o la somma dei contratti inseriti sono maggiori dell'importo totale del progetto");

                string messaggio = "Contratto aggiornato correttamente";
                if (_contratto.IdContrattoFem == null)
                    messaggio = "Contratto inserito correttamente";

                contratti_provider.Save(_contratto);
                contratti_provider.DbProviderObj.Commit();
                ((PrivatePage)Page).ShowMessage(messaggio);
            }
            catch (Exception ex)
            {
                contratti_provider.DbProviderObj.Rollback();
                ((PrivatePage)Page).ShowError(ex.Message);
            }
            finally
            {
                ((PrivatePage)Page).RegisterClientScriptBlock(Mostra);
            }
        }

        protected void btnEliminaContratto_Click(object sender, EventArgs e)
        {
            try
            {
                CaricaHidden();

                if (_contratto != null)
                {
                    var pagamenti_coll = new ContrattiFemPagamentiCollectionProvider().Find(null, _contratto.IdContrattoFem, null, null, null);

                    if (pagamenti_coll.Count > 0)
                        throw new Exception("Non è possibile eliminare il contratto perchè associato a dei pagamenti");

                    contratti_provider.Delete(_contratto);
                    ((PrivatePage)Page).RegisterClientScriptBlock("chiudiPopup();");
                    ((PrivatePage)Page).ShowMessage("Il contratto selezionato è stato rimosso correttamente");
                    svuotaHidden();
                    _contratto = null;
                }
            }
            catch (Exception ex)
            {
                ((PrivatePage)Page).RegisterClientScriptBlock("chiudiPopup();");
                ((PrivatePage)Page).ShowError(ex.Message);
            }
        }

        #endregion
    }
}