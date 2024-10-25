using System;
using System.Linq;
using System.Web.UI.WebControls;
using web.CONTROLS;

/* STORIA
 * Data: 2016-05-24; Stato: Creazione; Autore: 
*/

namespace web.Private.PDomanda
{
    public partial class DatiMonitoraggioFESR : SiarLibrary.Web.ProgettoPage
    {
        SiarLibrary.DatiMonitoraggioFESR m_MonFESRclss = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            string idbando = Progetto.IdBando;
            ucCUPCategoria.Progetto = Progetto;
            ucCUPCategoriaSoggetto.Progetto = Progetto;
            cmbTemaPrior.DataBind();
            cmbAttivitaEcon.DataBind();
            cmbCPTSettore.DataBind();
            cmbCUPDimensioneTerr.DataBind();
            //cmbCUPNatura.DataBind();
            ucCmbTipoOper.DataBind();
            FiltraNaturaCupBando();

            ucProgettoInd.Progetto = Progetto;
            ucProgettoInd.Istruttoria = ProgettoIndicatori.eIstruttoria.No;
            ucProgettoInd.StatoProgetto = ProgettoIndicatori.eStato.Domanda;
            ucProgettoInd.Operatore = Operatore.Utente.IdUtente;
            ucProgettoInd.DataBind();

            SiarLibrary.DatiMonitoraggioFESRCollection monitColl = new SiarBLL.DatiMonitoraggioFESRCollectionProvider().Select(null, Progetto.IdProgetto);
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
                else
                {
                    //cerco codice ateco su anagrafica impresa
                    SiarLibrary.Impresa impresa = new SiarBLL.ImpresaCollectionProvider().GetById(Progetto.IdImpresa);
                    if (impresa.CodAteco2007 != null)
                    {
                        SiarLibrary.BandoAteco2007Collection bando_ateco_coll = new SiarBLL.BandoAteco2007CollectionProvider().Find(Progetto.IdBando, null);
                        if (bando_ateco_coll.Count == 0)
                        {
                            selAteco2007.AtecoCurrent = new SiarBLL.Ateco2007CollectionProvider().GetById(impresa.CodAteco2007);
                        }
                        else
                        {
                            SiarLibrary.BandoAteco2007Collection bando_ateco_coll_2 = new SiarBLL.BandoAteco2007CollectionProvider().Find(Progetto.IdBando, impresa.CodAteco2007);
                            if (bando_ateco_coll_2.Count > 0)
                            {
                                selAteco2007.AtecoCurrent = new SiarBLL.Ateco2007CollectionProvider().GetById(impresa.CodAteco2007);
                            }
                        }
                    }
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
                    //if (m_MonFESRclss.IdCUPNatura != null && m_MonFESRclss.IdCUPNatura != "")
                    //    cmbCUPNatura.SelectedValue = m_MonFESRclss.IdCUPNatura;
                    if (m_MonFESRclss.IdCUPCategoriaTipoOperazione != null && m_MonFESRclss.IdCUPCategoriaTipoOperazione != "")
                        ucCmbTipoOper.SelectedValue = m_MonFESRclss.IdCUPCategoriaTipoOperazione;
                }
            }
            else
            {
                //cerco codice ateco su anagrafica impresa
                SiarLibrary.Impresa impresa = new SiarBLL.ImpresaCollectionProvider().GetById(Progetto.IdImpresa);
                if (impresa.CodAteco2007 != null)
                {
                    SiarLibrary.BandoAteco2007Collection bando_ateco_coll = new SiarBLL.BandoAteco2007CollectionProvider().Find(Progetto.IdBando, null);
                    if (bando_ateco_coll.Count == 0)
                    {
                        selAteco2007.AtecoCurrent = new SiarBLL.Ateco2007CollectionProvider().GetById(impresa.CodAteco2007);
                    }
                    else
                    {
                        SiarLibrary.BandoAteco2007Collection bando_ateco_coll_2 = new SiarBLL.BandoAteco2007CollectionProvider().Find(Progetto.IdBando, impresa.CodAteco2007);
                        if (bando_ateco_coll_2.Count > 0)
                        {
                            selAteco2007.AtecoCurrent = new SiarBLL.Ateco2007CollectionProvider().GetById(impresa.CodAteco2007);
                        }
                    }
                }
                    
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_MonFESRclss == null)
                {
                    m_MonFESRclss = new SiarLibrary.DatiMonitoraggioFESR();
                    m_MonFESRclss.IdProgetto = Progetto.IdProgetto;
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
                if (string.IsNullOrEmpty(ucCmbTipoOper.SelectedValue))
                {
                    m_MonFESRclss.IdCUPNatura = "";
                }
                else
                {
                    var idCupNatura = ucCmbTipoOper.SelectedValue.Substring(0, 2);
                    // verifico prima la natura cup se permessa dal bando 
                    CheckParametroNaturaCupBando(idCupNatura);
                    m_MonFESRclss.IdCUPNatura = idCupNatura;
                }
                m_MonFESRclss.IdCUPCategoriaTipoOperazione = ucCmbTipoOper.SelectedValue;
                new SiarBLL.DatiMonitoraggioFESRCollectionProvider().Save(m_MonFESRclss);

                ucProgettoInd.Salva();
                
                ShowMessage("Dati di Monitoraggio salvati correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void CheckParametroNaturaCupBando(string naturaCup)
        {
            var bando_config_provider = new SiarBLL.BandoConfigCollectionProvider();
            var codNaturaCupBandoList = bando_config_provider.GetBandoConfig_NaturaCupList(Bando.IdBando);

            // se il parametro avanzato è valorizzato e il tipo operazione non è valido, mostro un errore con la lista dei concessi
            if (codNaturaCupBandoList != null && codNaturaCupBandoList.Count > 0 
                && !codNaturaCupBandoList.Contains(naturaCup))
            {
                string errore = "E' stata selezionato un Tipo Operazione non valido.<br/><br/>" +
                    "E' necessario selezionarlo tra una di queste categorie: ";

                for (int i = 0; i < codNaturaCupBandoList.Count; i++) 
                {
                    string natura = codNaturaCupBandoList[i];
                    errore += "<br/>- " + natura + ";";
                }

                throw new Exception(errore);
            } 
        }

        protected void FiltraNaturaCupBando()
        {
            var bando_config_provider = new SiarBLL.BandoConfigCollectionProvider();
            var natureCupList = bando_config_provider.GetBandoConfig_NaturaCupList(Bando.IdBando);

            // se il parametro avanzato è valorizzato, mi creo una lista dei tipi operazioni con i soli elementi 
            // aventi la natura cup permessa
            if(natureCupList != null && natureCupList.Count > 0)
            {
                var items = new ListItemCollection();

                //se c'è un elemento selezionato lo aggiungo comunque, semmai non sarà valido al salvataggio
                var itemSelected = ucCmbTipoOper.SelectedItem;
                if(itemSelected != null && itemSelected.Value.Length > 0)
                    items.Add(itemSelected);

                foreach (ListItem tipoOperazione in ucCmbTipoOper.Items)
                {
                    if (tipoOperazione.Value.Length > 0)
                    {
                        var naturaTipoOperazione = tipoOperazione.Value.Substring(0, 2);

                        if (natureCupList.Contains(naturaTipoOperazione))
                            items.Add(tipoOperazione);
                    };
                }

                ucCmbTipoOper.Items.Clear();
                ucCmbTipoOper.Items.AddRange(items.OfType<ListItem>().ToArray());
            }
        }
    }
}