using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.CONTROLS
{
    public partial class WorkflowPagamento : System.Web.UI.UserControl
    {
        private SiarLibrary.VworkflowPagamentoCollection _workflow
        {
            get { return ((SiarLibrary.Web.DomandaPagamentoPage)Page).WorkFlow; }
            set { ((SiarLibrary.Web.DomandaPagamentoPage)Page).WorkFlow = value; }
        }

        private SiarLibrary.VworkflowPagamento _workflowCorrente;
        public SiarLibrary.VworkflowPagamento WorkflowCorrente
        {
            get
            {
                if (_workflowCorrente == null)
                {
                    string nome_pagina = Page.AppRelativeVirtualPath.Substring(Page.AppRelativeVirtualPath.LastIndexOf("/") + 1);
                    foreach (SiarLibrary.VworkflowPagamento p in _workflow)
                        if (p.Url == nome_pagina)
                            _workflowCorrente = p;
                }
                return _workflowCorrente;
            }
            set { _workflowCorrente = value; }
        }

        private bool _proseguiAbilitato = true;
        public bool ProseguiAbilitato
        {
            get { return _proseguiAbilitato; }
            set
            {
                if (_workflowCorrente.Obbligatorio)
                {
                    _proseguiAbilitato = value;
                    if (!value)
                        //btnGo.Attributes.Add("onclick", "alert('" + _proseguiMessaggio + "')");
                        btnSucc.Attributes.Add("onclick", "alert('" + _proseguiMessaggio + "')");
                }
            }
        }

        private SiarLibrary.NullTypes.StringNT _proseguiUrl;
        public string ProseguiUrl
        {
            get { return _proseguiUrl; }
            set { _proseguiUrl = value; }
        }

        private string _proseguiMessaggio = "Impossibile avanzare nella procedura.";
        public string ProseguiMessaggio
        {
            get { return _proseguiMessaggio; }
            set { _proseguiMessaggio = value; }
        }

        private bool _inIntegrazione = false;
        public bool InIntegrazione
        {
            get { return _inIntegrazione; }
            set { _inIntegrazione = value; }
        }

        public SiarLibrary.Progetto Progetto
        {
            get { return ((SiarLibrary.Web.DomandaPagamentoPage)Page).Progetto; }
        }

        private SiarLibrary.Impresa _impresa;
        public SiarLibrary.Impresa Impresa
        {
            get { return _impresa; }
            //set { _impresa = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page is SiarLibrary.Web.DomandaPagamentoPage && _workflow != null && WorkflowCorrente != null)
                loadData();
            else
                ((SiarLibrary.Web.PrivatePage)Page).Redirect("GestioneLavori.aspx", "Workflow procedurale di modifica domanda di pagamento non presente.", true);
        }

        protected override void OnPreRender(EventArgs e)
        {
            //rimosso vincolo per amministratori
            if (InIntegrazione
                && !(((SiarLibrary.Web.PrivatePage)Page).Operatore.Utente.Profilo == "Amministratore"))
            {
                tableNavigazione.Visible = false;
                divSteppersButtons.Visible = false;
            }
            else
            {
                tableNavigazione.Visible = true;
                divSteppersButtons.Visible = true;
            }
        }

        private SiarLibrary.DomandaDiPagamento DomandaPagamento
        {
            get { return ((SiarLibrary.Web.DomandaPagamentoPage)Page).DomandaPagamento; }
        }

        public int getItemsCount()
        {
            return _workflow.Count;
        }

        public void loadData()
        {
            rptSteppers.DataSource = _workflow;
            rptSteppers.DataBind();
            if (WorkflowCorrente.Ordine == 1)
            {
                //btnPrev.Style.Add("display", "none");
                btnPrec.Attributes.Add("disabled", "disabled");
            }
            else if (WorkflowCorrente.Ordine == _workflow.Count)
            {
                //btnGo.Style.Add("display", "none");
                btnSucc.Attributes.Add("disabled", "disabled");
            }

            //btnCurrent.Value = "(" + WorkflowCorrente.Ordine + "/" + _workflow.Count + ")";
            //btnPrev.Value = "<<< (" + (WorkflowCorrente.Ordine - 1) + "/" + _workflow.Count + ")";
            //btnGo.Value = "(" + (WorkflowCorrente.Ordine + 1) + "/" + _workflow.Count + ") >>>";

            foreach (SiarLibrary.VworkflowPagamento p in _workflow)
            {
                if (p.Ordine == WorkflowCorrente.Ordine - 1)
                {
                    //btnPrev.Attributes.Add("onclick", "location='" + p.Url + "'");
                    btnPrec.Attributes.Add("onclick", "location='" + p.Url + "'");
                }

                if (p.Ordine == WorkflowCorrente.Ordine + 1)
                {
                    //btnGo.Attributes.Add("onclick", "location='" + (_proseguiUrl != null ? _proseguiUrl : p.Url) + "'");
                    btnSucc.Attributes.Add("onclick", "location='" + (_proseguiUrl != null ? _proseguiUrl : p.Url) + "'");
                }
            }

            //lblStatoPagamento.Text = (DomandaPagamento.Annullata ? "ANNULLATA DAL RICHIEDENTE" : (DomandaPagamento.Segnatura == null ? "Provvisoria" : "Rilasciata"));
            //lblNumeroPagamento.Text = DomandaPagamento.IdDomandaPagamento;
            //lblOperatore.Text = DomandaPagamento.Operatore;
            //lblTipoPagamento.Text = _workflow[0].TipoPagamento;

            _impresa = new SiarBLL.ImpresaCollectionProvider().GetById(Progetto.IdImpresa);
            //if (_impresa != null)
            //{
            //    lblCodiceFiscale.Text = _impresa.CodiceFiscale;
            //    lblRagioneSociale.Text = _impresa.RagioneSociale;
            //}
            //lblNumero.Text = Progetto.IdProgetto;
            //lblStato.Text = Progetto.Stato;
            //SiarLibrary.ProgettoStoricoCollection ps = new SiarBLL.ProgettoStoricoCollectionProvider().Find(Progetto.IdProgetto, "L", null);
            //if (ps.Count > 0) ucVPProgetto.Segnatura = ps[0].Segnatura;
            //if (DomandaPagamento.Segnatura != null)
            //{
            //    ucVPPagamento.TipoVisualizzazione = web.CONTROLS.SNCOptions.ViewOption.Immagine;
            //    ucVPPagamento.Segnatura = DomandaPagamento.Segnatura;
            //    ucVRPagamento.ReportViewOptions = web.CONTROLS.SNCOptions.ViewOption.Immagine;
            //    ucVRPagamento.ReportParameters = "IdDomandaPagamento=" + DomandaPagamento.IdDomandaPagamento;
            //}
        }
    }
}