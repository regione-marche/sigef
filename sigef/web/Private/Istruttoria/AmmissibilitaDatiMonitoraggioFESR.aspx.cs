using System;
using System.Web.UI.WebControls;
using web.CONTROLS;

namespace web.Private.Istruttoria
{
    public partial class AmmissibilitaDatiMonitoraggioFESR : SiarLibrary.Web.IstruttoriaPage
    {
        SiarLibrary.Progetto p;
        SiarLibrary.DatiMonitoraggioFESR m_MonFESRclss = null;

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "ammissibilita_domande";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int idProgetto;

            if (!int.TryParse(Request.QueryString["iddom"], out idProgetto)) Redirect("Ammissibilita.aspx");
            else
            {
                p = new SiarBLL.ProgettoCollectionProvider().GetById(idProgetto);
                
                ucInfoDomanda.Progetto = p;

                ucCUPCategoria.Progetto = p;
                ucCUPCategoriaSoggetto.Progetto = p;

                selAteco2007.Progetto = p;

                cmbTemaPrior.DataBind();
                cmbAttivitaEcon.DataBind();
                cmbCPTSettore.DataBind();
                cmbCUPDimensioneTerr.DataBind();
                ucCmbTipoOper.DataBind();

                ucProgettoInd.Progetto = p;
                ucProgettoInd.Istruttoria = ProgettoIndicatori.eIstruttoria.Si;
                ucProgettoInd.StatoProgetto = ProgettoIndicatori.eStato.Domanda;
                ucProgettoInd.Operatore = Operatore.Utente.IdUtente;
                ucProgettoInd.DataBind();

                SiarLibrary.DatiMonitoraggioFESRCollection monitColl = new SiarBLL.DatiMonitoraggioFESRCollectionProvider().Select(null, p.IdProgetto);
                if (monitColl.Count > 0)
                    m_MonFESRclss = monitColl[0];

                //-----------

                SiarLibrary.CUPCategoria CUPCategClss = null;
                SiarLibrary.CUPCategoriaSoggetto CUPCategSoggClss = null;
                SiarLibrary.Ateco2007 AtecoClss = null;

                if (m_MonFESRclss != null)
                {
                    if (m_MonFESRclss.IdCUPCategoria != null && m_MonFESRclss.IdCUPCategoria != "")
                    {
                        CUPCategClss = new SiarBLL.CUPCategoriaCollectionProvider().GetById(m_MonFESRclss.IdCUPCategoria);
                        if (CUPCategClss != null)
                            ucCUPCategoria.CUPCategoriaCurrent = CUPCategClss;
                    }

                    if (m_MonFESRclss.IdCUPCategoriaSoggetto != null && m_MonFESRclss.IdCUPCategoriaSoggetto != "")
                    {
                        CUPCategSoggClss = new SiarBLL.CUPCategoriaSoggettoCollectionProvider().GetById(m_MonFESRclss.IdCUPCategoriaSoggetto);
                        if (CUPCategSoggClss != null)
                            ucCUPCategoriaSoggetto.CUPCategoriaCurrent = CUPCategSoggClss;
                    }
                    if (m_MonFESRclss.IdAteco2007 != null && m_MonFESRclss.IdAteco2007 != "")
                    {
                        AtecoClss = new SiarBLL.Ateco2007CollectionProvider().GetById(m_MonFESRclss.IdAteco2007);
                        if (AtecoClss != null)
                            selAteco2007.AtecoCurrent = AtecoClss;
                    }

                    if (!IsPostBack)
                    {
                        if (m_MonFESRclss.IdTemaPrioritario != null && m_MonFESRclss.IdTemaPrioritario != "")
                            cmbTemaPrior.SelectedValue = m_MonFESRclss.IdTemaPrioritario;
                        if (m_MonFESRclss.IdAttivitaEcon != null && m_MonFESRclss.IdAttivitaEcon != "")
                            cmbAttivitaEcon.SelectedValue = m_MonFESRclss.IdAttivitaEcon;
                        if (m_MonFESRclss.IdCPTSettore != null && m_MonFESRclss.IdCPTSettore != "")
                            cmbCPTSettore.SelectedValue = m_MonFESRclss.IdCPTSettore;
                        if (m_MonFESRclss.IdDimensioneTerr != null && m_MonFESRclss.IdDimensioneTerr != "")
                            cmbCUPDimensioneTerr.SelectedValue = m_MonFESRclss.IdDimensioneTerr;
                        if (m_MonFESRclss.IdCUPCategoriaTipoOperazione != null && m_MonFESRclss.IdCUPCategoriaTipoOperazione != "")
                            ucCmbTipoOper.SelectedValue = m_MonFESRclss.IdCUPCategoriaTipoOperazione;
                    }

                }
            }
            controlloOperatoreStatoProgetto();
        }

        protected override void OnPreRender(EventArgs e)
        {
            btnAmmissibilita.Attributes.Add("onclick", "location='checklistammissibilita.aspx?iddom="
                + p.IdProgetto + "'");

            base.OnPreRender(e);
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_MonFESRclss == null)
                {
                    m_MonFESRclss = new SiarLibrary.DatiMonitoraggioFESR();
                    m_MonFESRclss.IdProgetto = p.IdProgetto;
                }
                m_MonFESRclss.IdCUPCategoria = ucCUPCategoria.IdCategoriaSelezionato;
                m_MonFESRclss.IdCUPCategoriaSoggetto = ucCUPCategoriaSoggetto.IdCategoriaSelezionato;
                if (!String.IsNullOrEmpty(selAteco2007.IdAteco2007Selezionato))
                    m_MonFESRclss.IdAteco2007 = selAteco2007.IdAteco2007Selezionato;
                else
                    throw new Exception("Inserire un Codice Ateco valido.");
                m_MonFESRclss.IdTemaPrioritario = cmbTemaPrior.SelectedValue;
                m_MonFESRclss.IdAttivitaEcon = cmbAttivitaEcon.SelectedValue;
                m_MonFESRclss.IdCPTSettore = cmbCPTSettore.SelectedValue;
                m_MonFESRclss.IdDimensioneTerr = cmbCUPDimensioneTerr.SelectedValue;
                //m_MonFESRclss = cmbCUPNatura.SelectedValue;
                if (string.IsNullOrEmpty(ucCmbTipoOper.SelectedValue)) m_MonFESRclss.IdCUPNatura = "";
                else m_MonFESRclss.IdCUPNatura = ucCmbTipoOper.SelectedValue.Substring(0, 2);
                m_MonFESRclss.IdCUPCategoriaTipoOperazione = ucCmbTipoOper.SelectedValue;
                new SiarBLL.DatiMonitoraggioFESRCollectionProvider().Save(m_MonFESRclss);

                ucProgettoInd.Salva();

                ShowMessage("Dati di Monitoraggio salvati correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void controlloOperatoreStatoProgetto()
        {
            if (AbilitaModifica)
            {
                if (ucInfoDomanda.Progetto.CodStato != "I" && !ucInfoDomanda.DomandaInRiesame && !ucInfoDomanda.DomandaInRevisione
                    && !ucInfoDomanda.DomandaInRicorso) AbilitaModifica = false;
                else if (new SiarBLL.CollaboratoriXBandoCollectionProvider().Find(Bando.IdBando, ucInfoDomanda.Progetto.IdProgetto,
                        Operatore.Utente.IdUtente, null, true).Count == 0) AbilitaModifica = false;
            }
        }
    }
}
