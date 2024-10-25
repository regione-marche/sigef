using System;
using System.Web.UI.WebControls;

namespace web.Private.Psr.Programmazione
{
    public partial class Dimensioni : SiarLibrary.Web.PrivatePage
    {
        // zDimensioni
        SiarBLL.ZdimensioniCollectionProvider zdim_provider = new SiarBLL.ZdimensioniCollectionProvider();
        SiarLibrary.Zdimensioni zdim_selezionata = null;

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "psr_mon_dimensioni";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HiddenFields_Valorizza();
        }

        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 1:
                    visualizzaElenco();
                    break;
                case 2:
                    visualizzaDettagio();
                    break;
            }
       
            base.OnPreRender(e);
        }

        private void visualizzaElenco()
        {
            SiarLibrary.ZdimensioniCollection zdims;

            tbDettaglio.Visible = false;
            pulisciDettaglio();

            cmbTipo.DataBind();

            dgDimensioni.Titolo = "Selezionare la Dimensione da modificare o cancellare";
            if (!string.IsNullOrEmpty(cmbTipo.SelectedValue))
            {
                // Filtro sul tipo dimensione selezionato
                zdims = zdim_provider.GetByCodDim(cmbTipo.SelectedValue);
            }
            else
            {
                // Visualizzazione di tutte le dimensioni
                zdims = zdim_provider.GetAll();
            }
            
            if (zdims.Count == 0)
            {
                dgDimensioni.Titolo = "Il Tipo Dimensione selezionata non ha nessuna Dimensione";
            }

            dgDimensioni.DataSource = zdims;
            dgDimensioni.DataBind();
        }

        private void visualizzaDettagio()
        {
            tbElenco.Visible = false;
            cmbTipoDettaglio.DataBind();

            if (zdim_selezionata != null)
            {
                valorizzaCampiDettaglio();
            }
            
        }

        private void HiddenFields_Valorizza()
        {
            int idDimensione;

            if (int.TryParse(hdnIdDimensione.Value, out idDimensione))
            {
                zdim_selezionata = zdim_provider.GetById(idDimensione);
            }
            
        }

        #region Campi Dettaglio

        private void valorizzaCampiDettaglio()
        {
            if (zdim_selezionata.CodDim != null)
            {
                cmbTipoDettaglio.SelectedValue = zdim_selezionata.CodDim;
            }
            if (zdim_selezionata.Codice != null)
            {
                txtCodice.Text = zdim_selezionata.Codice.ToString();
            }
            if (zdim_selezionata.Valore != null)
            {
                txtValore.Text = zdim_selezionata.Valore.ToString();
            }
            if (zdim_selezionata.ValoreBase != null)
            {
                txtValoreBase.Text = zdim_selezionata.ValoreBase.ToString();
            }
            if (zdim_selezionata.Richiedibile != null)
            {
                txtRichiedibile.Text = zdim_selezionata.Richiedibile.ToString();
            }
            if (zdim_selezionata.Um != null)
            {
                txtUM.Text = zdim_selezionata.Um.ToString();
            }
            if (zdim_selezionata.Descrizione != null)
            {
                txtDescrizione.Text = zdim_selezionata.Descrizione.ToString();
            }
            if (zdim_selezionata.Metodo != null)
            {
                txtMetodo.Text = zdim_selezionata.Metodo.ToString();
            }
            if (zdim_selezionata.Ordine != null)
            {
                txtOrdine.Text = zdim_selezionata.Ordine.ToString();
            }
            if (zdim_selezionata.ProceduraCalcolo != null)
            {
                txtProCalcolo.Text = zdim_selezionata.ProceduraCalcolo.ToString();
            }
        }

        private void pulisciDettaglio()
        {
            cmbTipoDettaglio.SelectedIndex = -1;
            txtCodice.Text = null;
            txtValore.Text = null;
            txtValoreBase.Text = null;
            txtRichiedibile.Text = null;
            txtUM.Text = null;
            txtDescrizione.Text = null;
            txtMetodo.Text = null;
            txtOrdine.Text = null;
            txtProCalcolo.Text = null;

            hdnIdDimensione.Value = null;
            zdim_selezionata = null;
        }

        #endregion

        #region Eventi Bottoni

        protected void btnProgrammazionePost_Click(object sender, EventArgs e)
        {

        }

        protected void btnSelezionaDimensione_Click(object sender, EventArgs e)
        {
            int idDimensione;

            if (int.TryParse(hdnIdDimensione.Value, out idDimensione))
            {
                zdim_selezionata = zdim_provider.GetById(idDimensione);
            }
            if (zdim_selezionata == null)
            {
                ShowError("Dimensione selezionata non valida.");
            }
            ucSiarNewTab.TabSelected = 2;
        }

        protected void btnSalvaDimensione(object sender, EventArgs e)
        {
            SalvaDimensione();
        }

        protected void btnCancellaDimensione(object sender, EventArgs e)
        {
            CancellaDimensione();
            btnProgrammazionePost_Click(this, null);
        }

        protected void btnNuovaDimensione(object sender, EventArgs e)
        {
            nuovaDimensione();
        }

        #endregion

        #region Nuovo / Salva / Cancella

        private void SalvaDimensione()
        {
            SiarLibrary.Zdimensioni dim;

            if (string.IsNullOrEmpty(cmbTipoDettaglio.SelectedValue))
            {
                ShowError("Selezionare un Tipo Dimensione.");
            }
            else
            {
                if (zdim_selezionata != null)
                {
                    dim = zdim_selezionata;
                }
                else
                {
                    dim = new SiarLibrary.Zdimensioni();
                    dim.MarkAsNew();
                    dim.Id = null;
                }
                dim.CodDim = cmbTipoDettaglio.SelectedValue;
                dim.Codice = txtCodice.Text;
                dim.Descrizione = txtDescrizione.Text;
                dim.Metodo = txtMetodo.Text;
                dim.Richiedibile = txtRichiedibile.Text;
                dim.Um = txtUM.Text;
                dim.Valore = txtValore.Text;
                dim.ValoreBase = txtValoreBase.Text;
                dim.Ordine = txtOrdine.Text;
                dim.ProceduraCalcolo = txtProCalcolo.Text;

                zdim_provider.DbProviderObj.BeginTran();
                try
                {
                    zdim_provider.Save(dim);
                    zdim_provider.DbProviderObj.Commit();
                    hdnIdDimensione.Value = dim.Id;
                    ShowMessage("Dati salvati correttamente.");
                }
                catch
                {
                    zdim_provider.DbProviderObj.Rollback();
                    ShowError("Errore nel salvataggio: i dati sono stati ripristinati alla situazione precedente.");
                }
            }
        }

        protected void CancellaDimensione()
        {
            SiarLibrary.Zdimensioni dimDel = null;
            SiarBLL.ZdimensioniXProgrammazioneCollectionProvider dxpPro = new SiarBLL.ZdimensioniXProgrammazioneCollectionProvider();
            SiarLibrary.ZdimensioniXProgrammazioneCollection dxp = null;
            int idDim = 0;

            if (hdnIdDimensione.Value != null && int.TryParse(hdnIdDimensione.Value, out idDim))
            {
                dimDel = zdim_provider.GetById(idDim);
            }

            if (dimDel != null)
            {
                dxp = dxpPro.GetBy_IdDimensione(dimDel.Id);
                if (dxp.Count > 0)
                {
                    ShowError("Non è possibile cancellare questa dimensione in quanto è usata nelle Dimensioni per Programmazione");
                    dimDel = null;
                }
            }

            if (dimDel != null)
            {
                zdim_provider.DbProviderObj.BeginTran();
                try
                {
                    zdim_provider.Delete(dimDel);
                    zdim_provider.DbProviderObj.Commit();
                    ShowMessage("Dati cancellati correttamente.");
                }
                catch
                {
                    zdim_provider.DbProviderObj.Rollback();
                    ShowError("Errore nel salvataggio: i dati sono stati ripristinati alla situazione precedente.");
                }
            }
            zdim_selezionata = null;
            pulisciDettaglio();
        }

        private void nuovaDimensione()
        {
            zdim_selezionata = null;
            pulisciDettaglio();
        }

        #endregion
    }
}
