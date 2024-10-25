using System;

namespace web.CONTROLS
{
    public partial class WorkFlowVarianti : System.Web.UI.UserControl
    {
        private SiarLibrary.VworkflowVarianteCollection _workflow
        {
            get { return ((SiarLibrary.Web.VariantePage)Page).WorkFlow; }
            set { ((SiarLibrary.Web.VariantePage)Page).WorkFlow = value; }
        }

        private SiarLibrary.VworkflowVariante _workflowCorrente;
        public SiarLibrary.VworkflowVariante WorkflowCorrente
        {
            get
            {
                if (_workflowCorrente == null)
                {
                    string nome_pagina = Page.AppRelativeVirtualPath.Substring(Page.AppRelativeVirtualPath.LastIndexOf("/") + 1);
                    foreach (SiarLibrary.VworkflowVariante p in _workflow)
                        if (p.Url == nome_pagina)
                            _workflowCorrente = p;
                }
                return _workflowCorrente;
            }
            set { _workflowCorrente = value; }
        }

        private SiarLibrary.Progetto Progetto
        {
            get { return ((SiarLibrary.Web.VariantePage)Page).Progetto; }
        }

        private SiarLibrary.Impresa _impresa;
        public SiarLibrary.Impresa Impresa
        {
            get { return _impresa; }
        }

        private SiarLibrary.Varianti Variante
        {
            get { return ((SiarLibrary.Web.VariantePage)Page).Variante; }
        }

        protected void Page_Load(object sender, EventArgs e)
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

            foreach (SiarLibrary.VworkflowVariante p in _workflow)
            {
                if (p.Ordine == WorkflowCorrente.Ordine - 1)
                {
                    //btnPrev.Attributes.Add("onclick", "location='" + p.Url + "'");
                    btnPrec.Attributes.Add("onclick", "location='" + p.Url + "'");
                }

                if (p.Ordine == WorkflowCorrente.Ordine + 1)
                {
                    //btnGo.Attributes.Add("onclick", "location='" + (_proseguiUrl != null ? _proseguiUrl : p.Url) + "'");
                    btnSucc.Attributes.Add("onclick", "location='" + p.Url + "'");
                }
            }
        }
    }
}