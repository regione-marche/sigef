using System;
using System.Web.UI.WebControls;
using SiarLibrary;
using SiarBLL;

namespace web.Private.Psr.Programmazione
{
    public partial class IndicatoriRisultato : SiarLibrary.Web.PrivatePage
    {
        //TODO: Aggiungere una funzione di blocco per gli anni già "chiusi"
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "psr_mon_indic_risu";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnPreRender(EventArgs e)
        {
            cmbPsr.DataBind();

            if (!string.IsNullOrEmpty(cmbPsr.SelectedValue))
            {
                Alimenta_cmbAnno(cmbPsr.SelectedValue);
            }

            if (!string.IsNullOrEmpty(cmbAnno.SelectedValue) &&
               (!string.IsNullOrEmpty(cmbPsr.SelectedValue)))
            {
                Alimenta_dbDimensioni(cmbPsr.SelectedValue, int.Parse(cmbAnno.SelectedValue));
                btnSalva.Enabled = true;
            }
       
            base.OnPreRender(e);
        }


        #region ComboBox

        private void Alimenta_cmbAnno(string codicePsr)
        {
            ZpsrCollectionProvider psrPro = new ZpsrCollectionProvider();
            Zpsr psr = new Zpsr();

            psr = psrPro.GetById(cmbPsr.SelectedValue);
            cmbAnno.SortDirection = SiarLibrary.Web.SortDirection.Asc;
            cmbAnno.AnnoDa = psr.AnnoDa;
            cmbAnno.AnnoA = psr.AnnoA;
            cmbAnno.DataBind();
        }

        #endregion

        #region Griglia

        private void Alimenta_dbDimensioni(string codicePsr, int anno)
        {
            ZdimensioniEstrazioniIrCollection dims = LeggiIR(codicePsr, anno);           
            
            dgDimensioni.DataSource = dims;
            dgDimensioni.DataBind();
        }

        #endregion

        #region Bottoni

        protected void btnSalvaDimensione(object sender, EventArgs e)
        {
            SalvaIR();
        }

        #endregion

        #region Salvataggio

        private void SalvaIR()
        {
            decimal valoreRealizzato;
            string valoreForm;
            
            ZdimensioniEstrazioniIrCollectionProvider dimPro = new ZdimensioniEstrazioniIrCollectionProvider();
            ZdimensioniEstrazioniIrCollection dbData = LeggiIR(cmbPsr.SelectedValue, int.Parse(cmbAnno.SelectedValue));

            foreach (ZdimensioniEstrazioniIr dim in dbData)
            {
                valoreForm = "ValoreRealizzato" + dim.IdDimensione.ToString() + "_text";
                decimal.TryParse(Request.Form[valoreForm], out valoreRealizzato);
                dim.ValoreRealizzato = valoreRealizzato;
            }

            dimPro.SaveCollection(dbData);
        }

        #endregion

        #region Lettura

        private ZdimensioniEstrazioniIrCollection LeggiIR(string codicePsr, int anno)
        {
            ZdimensioniEstrazioniIrCollectionProvider dimPro = new ZdimensioniEstrazioniIrCollectionProvider();
            ZdimensioniEstrazioniIrCollection dims;

            dims = dimPro.Find(codicePsr, anno);

            if (dims == null || dims.Count == 0)
            {
                dims = dimPro.GetNew(codicePsr, anno);
            }

            return dims;
        }

        #endregion
    }
}
