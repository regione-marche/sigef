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
    public partial class ucPagamentoFem : System.Web.UI.UserControl
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

        private ContrattiFemPagamenti _pagamento;
        public ContrattiFemPagamenti Pagamento
        {
            get { return _pagamento; }
            set { _pagamento = value; }
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
        private ContrattiFemPagamentiCollectionProvider pagamenti_provider;
        private DomandaDiPagamentoCollectionProvider domande_provider;
        private UtentiCollectionProvider utenti_provider;
        private ImpresaCollectionProvider impresa_provider;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            _mostra = "mostraPopupTemplate('" + divPagInv.UniqueID.Replace('$', '_') + "','divBKGMessaggio');";
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (_domanda != null)
            {
                InizializzaProvider();
                lstPagamento.DataBind();
                txtImpresaPagamento.AddJSAttribute("onkeydown", "SNCVolatileZoom(this,event,'SNCVZCercaImpresa');");

                ControlloUtente();
                CaricaDatiPagamentoFem();

                popolaHidden();
            }
            base.OnPreRender(e);
        }

        private void InizializzaProvider()
        {
            contratti_provider = new ContrattiFemCollectionProvider();
            pagamenti_provider = new ContrattiFemPagamentiCollectionProvider();
            domande_provider = new DomandaDiPagamentoCollectionProvider();
            utenti_provider = new UtentiCollectionProvider();
            impresa_provider = new ImpresaCollectionProvider();
        }

        private void popolaHidden()
        {
            if (_contratto != null && _contratto.IdContrattoFem != null)
                hdnModalePagamentoIdContrattoFem.Value = _contratto.IdContrattoFem;

            if (_pagamento != null && _pagamento.IdContrattoFemPagamenti != null)
                hdnModalePagamentoIdPagamentoFem.Value = _pagamento.IdContrattoFemPagamenti;

            if (_domanda != null && _domanda.IdDomandaPagamento != null)
                hdnModalePagamentoIdDomanda.Value = _domanda.IdDomandaPagamento;

            if (_utente != null && _utente.IdUtente != null)
                hdnModalePagamentoIdUtente.Value = _utente.IdUtente;
        }

        private void svuotaHidden()
        {
            hdnModalePagamentoIdContrattoFem.Value = null;
            hdnModalePagamentoIdPagamentoFem.Value = null;
            hdnModalePagamentoIdDomanda.Value = null;
            hdnModalePagamentoIdUtente.Value = null;
        }

        private void CaricaHidden()
        {
            InizializzaProvider();

            int id_contratto;
            if (int.TryParse(hdnModalePagamentoIdContrattoFem.Value, out id_contratto))
                _contratto = contratti_provider.GetById(id_contratto);

            int id_pagamento;
            if (int.TryParse(hdnModalePagamentoIdPagamentoFem.Value, out id_pagamento))
                _pagamento = pagamenti_provider.GetById(id_pagamento);

            int id_domanda;
            if (int.TryParse(hdnModalePagamentoIdDomanda.Value, out id_domanda))
                _domanda = domande_provider.GetById(id_domanda);

            int id_utente;
            if (int.TryParse(hdnModalePagamentoIdUtente.Value, out id_utente))
                _utente = utenti_provider.GetById(id_utente);
        }

        private void CaricaDatiPagamentoFem()
        {
            if(_pagamento != null)
            {
                txtIdContratto.Text = _pagamento.IdContrattoFem;
                lstPagamento.SelectedValue = _pagamento.CodTipo;
                txtData.Text = _pagamento.Data;
                txtImportoPagamento.Text = _pagamento.Importo;
                txtEstremi.Text = _pagamento.Estremi;
                ufPagamento.IdFile = _pagamento.IdFile;
                if (_pagamento.IdImpresa != null)
                {
                    var imp = impresa_provider.GetById(_pagamento.IdImpresa);
                    txtImpresaPagamento.Text = imp.RagioneSociale;
                    txtImpresaPagamento.ToolTip = imp.RagioneSociale;
                    hdnModalePagamentoIdImpresa.Value = _pagamento.IdImpresa;
                }
                else
                {
                    txtImpresaPagamento.Text = null;
                    txtImpresaPagamento.ToolTip = null;
                    hdnModalePagamentoIdImpresa.Value = null;
                }
            }
            else
            {
                txtIdContratto.Text = (_contratto != null && _contratto.IdContrattoFem != null) ? _contratto.IdContrattoFem : null;
                lstPagamento.SelectedValue = null;
                txtData.Text = null;
                txtImportoPagamento.Text = null;
                txtEstremi.Text = null;
                ufPagamento.IdFile = null;
                txtImpresaPagamento.Text = null;
                txtImpresaPagamento.ToolTip = null;
                hdnModalePagamentoIdImpresa.Value = null;
            }
        }

        private void popolaPagamentoFem(DbProvider dbProvider)
        {
            if (_pagamento.IdContrattoFem == null)
                throw new Exception("Campo id contratto non valorizzato");
            else if (lstPagamento.SelectedValue == null)
                throw new Exception("Campo tipo pagamento non valorizzato");
            else if (txtData.Text == null)
                throw new Exception("Campo data non valorizzato");
            else if (txtImportoPagamento.Text == null)
                throw new Exception("Campo importo non valorizzato");
            else if (txtEstremi.Text == null)
                throw new Exception("Campo estremi non valorizzato");
            else if (ufPagamento.IdFile == null)
                throw new Exception("File non valorizzato");

            _pagamento.CodTipo = lstPagamento.SelectedValue;
            _pagamento.Data = txtData.Text;
            _pagamento.Importo = txtImportoPagamento.Text;
            _pagamento.Estremi = txtEstremi.Text;
            _pagamento.IdFile = ufPagamento.IdFile;
            _pagamento.IdImpresa = hdnModalePagamentoIdImpresa.Value;

            popolaImpresa(dbProvider);

            _pagamento.OperatoreAggiornamento = _utente.IdUtente;
            _pagamento.DataAggiornamento = DateTime.Now;
        }

        private void popolaImpresa(DbProvider dbProvider)
        {
            //Se hanno compilato il modulo, prendo le informazioni da li. Altrimenti uso quelle del campo impresa
            if (txtCuaaModalePagamento.Text != null || txtPivaModalePagamento.Text != null || txtRagioneSocialeModalePagamento.Text != null)
            {
                //Verifico che tutti i campi siano compilati da javascript

                //Verifico se l'impresa esiste già
                var impresa_provider = new ImpresaCollectionProvider(dbProvider);

                var imp_cuaa = impresa_provider.Find(txtPivaModalePagamento.Text, null, null);
                if (imp_cuaa.Count > 0)
                    throw new Exception("Esiste già un impresa con la partita iva inserita. Riprovare inserendo " + imp_cuaa[0].RagioneSociale + " nell'apposito campo.");

                var imp_piva = impresa_provider.Find(null, txtCuaaModalePagamento.Text, null);
                if (imp_piva.Count > 0)
                    throw new Exception("Esiste già un impresa con il codice fiscale inserita. Riprovare inserendo " + imp_piva[0].RagioneSociale + " nell'apposito campo.");

                var imp_rag = impresa_provider.Find(null, null, txtRagioneSocialeModalePagamento.Text);
                if (imp_rag.Count > 0)
                    throw new Exception("Esiste già un impresa con la ragione sociale inserita. Riprovare inserendo " + imp_rag[0].RagioneSociale + " nell'apposito campo.");

                var impresa = new Impresa();
                impresa.Cuaa = txtPivaModalePagamento.Text;
                impresa.CodiceFiscale = txtPivaModalePagamento.Text;
                impresa_provider.Save(impresa);

                var impresa_storico_provider = new ImpresaStoricoCollectionProvider(dbProvider);
                var impresa_storico = new ImpresaStorico();
                impresa_storico.IdImpresa = impresa.IdImpresa;
                impresa_storico.RagioneSociale = txtRagioneSocialeModalePagamento.Text;
                impresa_storico.DataInizioValidita = DateTime.Now;
                impresa_storico_provider.Save(impresa_storico);

                impresa.IdStoricoUltimo = impresa_storico.IdStoricoImpresa;
                impresa_provider.Save(impresa);

                _pagamento.IdImpresa = impresa.IdImpresa;
            }
            else if (hdnModalePagamentoIdImpresa.Value != null)
                _pagamento.IdImpresa = hdnModalePagamentoIdImpresa.Value;
            else
                _pagamento.IdImpresa = null;
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
                    btnSalvaPagamento.Enabled = false;
                    btnEliminaPagamento.Enabled = false;
                    btnMostraNascondiImpresaModalePagamento.Visible = false;

                    txtIdContratto.ReadOnly = true;
                    lstPagamento.Enabled = false;
                    txtData.ReadOnly = true;
                    txtImportoPagamento.ReadOnly = true;
                    txtEstremi.ReadOnly = true;
                    ufPagamento.AbilitaModifica = false;
                    txtImpresaPagamento.ReadOnly = true;
                    labelModuloImpresaPagamento.Visible = false;
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
                btnSalvaPagamento.Enabled = false;
                btnEliminaPagamento.Enabled = false;
                btnMostraNascondiImpresaModalePagamento.Visible = false;

                txtIdContratto.ReadOnly = true;
                lstPagamento.Enabled = false;
                txtData.ReadOnly = true;
                txtImportoPagamento.ReadOnly = true;
                txtEstremi.ReadOnly = true;
                ufPagamento.AbilitaModifica = false;
                txtImpresaPagamento.ReadOnly = true;
                labelModuloImpresaPagamento.Visible = false;
            }
        }

        #region Button_Click

        protected void btnSalvaPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                CaricaHidden();
                pagamenti_provider.DbProviderObj.BeginTran();

                if (_pagamento == null)
                {
                    _pagamento = new ContrattiFemPagamenti();
                    _pagamento.OperatoreCreazione = _utente.IdUtente;
                    _pagamento.DataCreazione = DateTime.Now;
                    _pagamento.IdProgetto = _domanda.IdProgetto;
                    _pagamento.IdDomandaPagamento = _domanda.IdDomandaPagamento;
                    _pagamento.IdBando = new ProgettoCollectionProvider().GetById(_domanda.IdProgetto).IdBando;
                    _pagamento.IdContrattoFem = _contratto.IdContrattoFem;
                    _pagamento.ImportoContratto = _contratto.Importo;
                }

                popolaPagamentoFem(pagamenti_provider.DbProviderObj);

                var totalePagamentiContratto = pagamenti_provider.GetTotalePagamentiContratto(null, _pagamento.IdContrattoFem, _pagamento.IdContrattoFemPagamenti);
                if (totalePagamentiContratto + _pagamento.Importo > _pagamento.ImportoContratto)
                    throw new Exception("L'importo inserito o la somma dei pagamenti inseriti sono maggiori dell'importo totale del contratto");

                string messaggio = "Pagamento aggiornato correttamente";
                if (_pagamento.IdContrattoFemPagamenti == null)
                    messaggio = "Pagamento inserito correttamente";

                pagamenti_provider.Save(_pagamento);
                pagamenti_provider.DbProviderObj.Commit();
                ((PrivatePage)Page).ShowMessage(messaggio);
            }
            catch (Exception ex)
            {
                pagamenti_provider.DbProviderObj.Rollback();
                ((PrivatePage)Page).ShowError(ex.Message);
            }
            finally
            {
                ((PrivatePage)Page).RegisterClientScriptBlock(Mostra);
            }
        }

        protected void btnEliminaPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                CaricaHidden();

                if (_pagamento != null)
                {
                    pagamenti_provider.Delete(_pagamento);
                    ((PrivatePage)Page).RegisterClientScriptBlock("chiudiPopup();");
                    ((PrivatePage)Page).ShowMessage("Il pagamento selezionato è stato rimosso correttamente");
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