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
    public partial class ucContrattiFemEPagamenti : SigefUserControl
    {
        private Utenti _utente;
        public Utenti Utente
        {
            get { return _utente; }
            set { _utente = value; }
        }

        private DomandaDiPagamento _domanda;
        public DomandaDiPagamento Domanda
        {
            get { return _domanda; }
            set { _domanda = value; }
        }

        private CollaboratoriXBando _istruttore;

        #region Collection Provider
        BandoConfigCollectionProvider bando_provider;
        ProgettoCollectionProvider progetto_provider;
        ContrattiFemCollectionProvider contratti_provider;
        ContrattiFemPagamentiCollectionProvider pagamenti_provider;
        #endregion

        private ContrattiFem _contratto_selezionato;
        private ContrattiFem _contratto_selezionato_mostra;
        private ContrattiFemPagamenti _pagamento_selezionato;
        private ContrattiFemCollection contratti_coll;
        private ContrattiFemPagamentiCollection pagamenti_coll;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (_domanda != null)
            {
                if (!_domanda.TpAppaltoStrumentiFinanziari)
                    ((PrivatePage)Page).Redirect("GestioneLavori.aspx", "Il bando non prevede l'uso degli strumenti finanziari.", true);
            }
            else
                ((PrivatePage)Page).Redirect("GestioneLavori.aspx", "Domanda non selezionata.", true);
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (_domanda != null)
            {
                InizializzaProvider();
                CaricaHidden();

                CaricaRiepilogo();
                CaricaContrattiFem();
                CaricaPagamenti();

                ControlloUtente();
                popolaHidden();
            }
            base.OnPreRender(e);
        }

        private void InizializzaProvider()
        {
            bando_provider = new BandoConfigCollectionProvider();
            progetto_provider = new ProgettoCollectionProvider();
            contratti_provider = new ContrattiFemCollectionProvider();
            pagamenti_provider = new ContrattiFemPagamentiCollectionProvider();
        }

        private void popolaHidden()
        {

        }

        private void svuotaHidden()
        {
            hdnIdContrattoFem.Value = null;
            hdnIdContrattoFemMostra.Value = null;
            hdnIdContrattoFemPagamenti.Value = null;
        }

        private void CaricaHidden()
        {
            int id_contratto;
            if (int.TryParse(hdnIdContrattoFem.Value, out id_contratto))
                _contratto_selezionato = contratti_provider.GetById(id_contratto);

            int id_contratto_mostra;
            if (int.TryParse(hdnIdContrattoFemMostra.Value, out id_contratto_mostra))
                _contratto_selezionato_mostra = contratti_provider.GetById(id_contratto_mostra);

            int id_pagamento;
            if (int.TryParse(hdnIdContrattoFemPagamenti.Value, out id_pagamento))
                _pagamento_selezionato = pagamenti_provider.GetById(id_pagamento);
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
                    btnInserisciContratto.Enabled = false;
                    btnInserisciPagamento.Enabled = false;

                    hdnInserimentoPagamentoAbilitato.Value = "false";
                }
                else
                    hdnInserimentoPagamentoAbilitato.Value = "true";
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
                btnInserisciContratto.Enabled = false;
                btnInserisciPagamento.Enabled = false;

                hdnInserimentoPagamentoAbilitato.Value = "false";
            }
        }

        protected void CaricaRiepilogo()
        {
            try
            {
                //Totale domanda
                var importoContributo = new ProgettoCollectionProvider().CalcolaTotaleContributo(Domanda.IdProgetto);
                txtImportoDomanda.Text = importoContributo.ToString();

                //Totale contratti domanda
                contratti_coll = contratti_provider.Find(null, _domanda.IdProgetto, null, _domanda.IdDomandaPagamento, null, null, null);
                var contratti_list = contratti_coll.ToArrayList<ContrattiFem>();
                var totaleContratti = (from c in contratti_list
                                       select c)
                                       .Sum(c => c.Importo);
                txtImportoTotaleContratti.Text = totaleContratti.ToString();

                //Controllo se è possibile inserire nuovi contratti
                if (totaleContratti >= importoContributo)
                {
                    btnInserisciContratto.Enabled = false;
                    btnInserisciContratto.ToolTip = "Non è possibile inserire ulteriori contratti perché si è già raggiunto l'importo della domanda.";
                }

                //Totale pagamenti domanda
                pagamenti_coll = pagamenti_provider.Find(null, null, _domanda.IdProgetto, null, _domanda.IdDomandaPagamento);
                var pagamenti_list = pagamenti_coll.ToArrayList<ContrattiFemPagamenti>();
                var totalePagamenti = (from p in pagamenti_list
                                       select p)
                                       .Sum(p => p.Importo);
                txtImportoTotalePagamenti.Text = totalePagamenti.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CaricaContrattiFem()
        {
            try
            {
                var contratti_coll = contratti_provider.Find(null, _domanda.IdProgetto, null, _domanda.IdDomandaPagamento, null, null, null);
                if (contratti_coll.Count > 0)
                {
                    lblContrattiFem.Text = string.Format("Selezionare un contratto per vederne i pagamenti");

                    dgContrattiFem.DataSource = contratti_coll;
                    dgContrattiFem.ItemDataBound += new DataGridItemEventHandler(dgContratti_ItemDataBound);
                    dgContrattiFem.MostraTotale("DataField", 3, 4);
                    dgContrattiFem.DataBind();
                }
                else
                {
                    lblContrattiFem.Text = "Nessun contratto trovato.";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void CaricaPagamenti()
        {
            try
            {
                var pagamenti_coll = pagamenti_provider.Find(null, null, _domanda.IdProgetto, null, _domanda.IdDomandaPagamento);
                if (pagamenti_coll.Count > 0)
                {
                    lblPagamenti.Text = string.Format("Visualizzate {0} righe", pagamenti_coll.Count.ToString());

                    dgPagamenti.DataSource = pagamenti_coll;
                    dgPagamenti.ItemDataBound += new DataGridItemEventHandler(dgPagamenti_ItemDataBound);
                    dgPagamenti.MostraTotale("DataField", 4);
                    dgPagamenti.DataBind();
                }
                else
                {
                    lblPagamenti.Text = "Nessun pagamento trovato.";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CaricaDatiContratti(bool daPulsanteDataGrid)
        {
            InizializzaProvider();
            CaricaHidden();

            var importoTotaleContratti = contratti_provider.GetTotaleContrattiDomandaPagamento(Domanda.IdProgetto, Domanda.IdDomandaPagamento, null);
            decimal importoProgetto = decimal.Parse(txtImportoDomanda.Text);
            if (importoTotaleContratti > importoProgetto)
                throw new Exception("Non è possibile inserire ulteriori contratti perché si è già raggiunto l'importo del progetto.");

            modaleContratto.Utente = _utente;
            modaleContratto.Progetto = new ProgettoCollectionProvider().GetById(_domanda.IdProgetto);
            modaleContratto.Domanda = _domanda;

            if (daPulsanteDataGrid)
            {
                if (_contratto_selezionato_mostra != null)
                    modaleContratto.Contratto = _contratto_selezionato_mostra;
                else
                    throw new Exception("Contratto non selezionato.");
            }

            svuotaHidden();
            ((PrivatePage)Page).RegisterClientScriptBlock(modaleContratto.Mostra);
        }

        protected void CaricaDatiPagamento(bool daPulsanteDataGrid)
        {
            InizializzaProvider();
            CaricaHidden();

            modalePagamento.Utente = _utente;
            //modalePagamento.Progetto = new ProgettoCollectionProvider().GetById(_domanda.IdProgetto);
            modalePagamento.Domanda = _domanda;
            modalePagamento.Contratto = _contratto_selezionato;

            if (daPulsanteDataGrid)
            {
                if (_pagamento_selezionato != null)
                    modalePagamento.Pagamento = _pagamento_selezionato;
                else
                    throw new Exception("Pagamento non selezionato.");
            }

            svuotaHidden();
            ((PrivatePage)Page).RegisterClientScriptBlock(modalePagamento.Mostra);
        }

        #region Button_Click

        protected void btnInserisciContratto_Click(object sender, EventArgs e)
        {
            try
            {
                CaricaDatiContratti(false);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void btnInserisciPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                CaricaDatiPagamento(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnPostContratto_Click(object sender, EventArgs e)
        {
            try
            {
                CaricaDatiContratti(true);
            }
            catch (Exception ex)
            {
                ((PrivatePage)Page).ShowError(ex.Message);
                ((PrivatePage)Page).RegisterClientScriptBlock("chiudiPopup();");
            }
        }

        protected void btnPostPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                CaricaDatiPagamento(true);
            }
            catch (Exception ex)
            {
                ((PrivatePage)Page).ShowError(ex.Message);
                ((PrivatePage)Page).RegisterClientScriptBlock("chiudiPopup();");
            }
        }

        protected void btnImportaContratti_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region ItemDataBound

        void dgContratti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            //Se si modificano le colonne, modificare anche i controlli js per il button di inserimento pagamenti e il MostraTotale dei footer
            int col_IdContratto = 0,
                col_Riferimenti = 1,
                col_Segnatura = 2,
                col_ImportoContratto = 3,
                col_ImportoPagamenti = 4,
                col_Button = 5;

            DataGridItem dgi = (DataGridItem)e.Item;
            ContrattiFem contratto = (ContrattiFem)dgi.DataItem;

            if (dgi.ItemType == ListItemType.Header)
            {
                //dgi.CssClass = "TESTA1";
                //dgi.Cells[0].ColumnSpan = 4;
                //dgi.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                //dgi.Cells[0].Text = "Bando di gara</td><td colspan=4 align=center>Domanda di aiuto</td><td colspan=6 align=center>Domanda di pagamento</td><td align=center>Azione</td></tr><tr class='TESTA'><td>Id";
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string riferimenti = "Data stipula: <b>" + contratto.DataStipulaContratto + "</b>";
                if(contratto.Numero != null)
                    riferimenti += "<br/>Numero: <b>" + contratto.Numero + "</b>";
                if (contratto.Impresa != null)
                    riferimenti += "<br/>Impresa: <b>" + contratto.Impresa + "</b>";
                if (contratto.DataSegnatura != null)
                    riferimenti += "<br/>Data segnatura: <b>" + contratto.DataSegnatura + "</b>";
                if (contratto.Segnatura == null)
                    e.Item.Cells[col_Segnatura].Text = "";
                if (contratto.Descrizione != null)
                    riferimenti += "<br/>Descrizione: <b>" + contratto.Descrizione + "</b>";

                e.Item.Cells[col_Riferimenti].Text = riferimenti;

                var tot_importo_pagamenti = pagamenti_provider.GetTotalePagamentiContratto(contratto.IdDomandaPagamento, contratto.IdContrattoFem, null);
                e.Item.Cells[col_ImportoPagamenti].Text = string.Format("{0:c}", tot_importo_pagamenti);
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                var pagamenti_list = pagamenti_provider.Find(null, null, _domanda.IdProgetto, null, _domanda.IdDomandaPagamento)
                    .ToArrayList<ContrattiFemPagamenti>();
                var tot_pagamenti = (from p in pagamenti_list
                                     select p)
                                     .Sum(p => p.Importo);

                e.Item.Cells[col_ImportoPagamenti].Text = string.Format("{0:c}", tot_pagamenti); //tot_pagamenti + " €";
            }
        }

        void dgPagamenti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;

            if (dgi.ItemType == ListItemType.Header)
            {
                //dgi.CssClass = "TESTA1";
                //dgi.Cells[0].ColumnSpan = 4;
                //dgi.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                //dgi.Cells[0].Text = "Bando di gara</td><td colspan=4 align=center>Domanda di aiuto</td><td colspan=6 align=center>Domanda di pagamento</td><td align=center>Azione</td></tr><tr class='TESTA'><td>Id";
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ContrattiFemPagamenti pagamento = (ContrattiFemPagamenti)dgi.DataItem;

                int col_IdPagamento = 0,
                    col_Impresa = 1,
                    col_TipoPagamento = 2,
                    col_Data = 3,
                    col_Importo = 4,
                    col_IdContrattoFem = 5;
                    
            }
        }

        #endregion
    }
}