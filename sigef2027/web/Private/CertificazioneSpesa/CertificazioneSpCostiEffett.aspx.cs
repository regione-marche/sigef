using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarLibrary.Web;
using SiarLibrary;


namespace web.Private.CertificazioneSpesa
{
    public partial class CertificazioneSpCostiEffett : SiarLibrary.Web.CertificazioneSpesaPage
    {
        private const int cAzione       = 1;
        private const int cIdProgeto    = 2;
        private const int cTipoDomPag   = 3;
        private const int cContrAmmTot  = 4;
        private const int cContrPagTot  = 5;
        private const int cTipoApp      = 6;
        private const int cImpoApp      = 7;
        private const int cContrAmmApp  = 8;
        private const int cTipoProcApp  = 9;
        private const int cImprApp      = 10;

        private const int cfTotale      = 0;
        private const int cfContAmm     = 4;
        private const int cfContPag     = 5;
        private const int cfImpApp      = 7;
        private const int cfAmmApp      = 8;

        private decimal tot_contributo_ammesso  = 0;
        private decimal tot_contributo_pagato   = 0;
        private decimal tot_importo_appalto     = 0;
        private decimal tot_ammissib_appalto    = 0;

        SiarBLL.DomandaDiPagamentoCollectionProvider domc_provider = new SiarBLL.DomandaDiPagamentoCollectionProvider();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtDataInizio_Valorizza();
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            lstPsr.DataBind();

            if (!string.IsNullOrEmpty(lstPsr.SelectedValue))
            {
                dgCostiEff_Visualizza();
            }

            base.OnPreRender(e);
        }

        protected void btnCerca_Click(object sender, EventArgs e)
        {
            dgCostiEff.SetPageIndex(0);
        }

        protected void btnEstrai_Click(object sender, EventArgs e) { }

        #region Visualizza

        private void txtDataInizio_Valorizza()
        {
            DateTime d = new DateTime(DateTime.Now.Year - 1, 6, 1);
            if (DateTime.Now.Month > 6)
            {
                d.AddYears(1);
            }
            txtDataInizio.Text = d.Date.ToString("dd/MM/yyyy");
        }

        private void dgCostiEff_Visualizza()
        {
            SiarLibrary.NullTypes.DatetimeNT dtInizio = null;
            SiarLibrary.NullTypes.DatetimeNT dtFine   = null;

            if (!string.IsNullOrEmpty(txtDataInizio.Text))
            {   
                dtInizio = new SiarLibrary.NullTypes.DatetimeNT(txtDataInizio.Text); 
            }
            if (!string.IsNullOrEmpty(txtDataFine.Text))
            {   
                dtFine = new SiarLibrary.NullTypes.DatetimeNT(txtDataFine.Text); 
            }

            //btnEstraiSpese.Attributes.Add("onclick", "SNCVisualizzaReport('SpCertspGetRiepilogoSpeseXAsse',2,'CodPsr=" + lstPsr.SelectedValue + "')");

            dgCostiEff.DataSource       =  domc_provider.GetSpeseCostiEffett(lstPsr.SelectedValue, dtInizio, dtFine);
            dgCostiEff.Titolo           =  "Elementi trovati: " + ((SiarLibrary.CustomCollection)dgCostiEff.DataSource).Count.ToString();
            dgCostiEff.ItemDataBound    += new DataGridItemEventHandler(dgCostiEff_ItemDataBound);
            dgCostiEff.DataBind();
        }

        protected void dgCostiEff_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            decimal vContrAmmTot = 0;
            decimal vContrPagTot = 0;
            decimal vImpoApp = 0;
            decimal vContrAmmApp = 0;

            if (e.Item.ItemType != ListItemType.Footer && e.Item.ItemType != ListItemType.Header)
            {
                SiarLibrary.Zprogrammazione d = (SiarLibrary.Zprogrammazione)e.Item.DataItem;

                //vContrAmmTot = decimal.Parse(d.AdditionalAttributes["CONTRIBUTO_AMMISSIBILE_TOTALE"]);
                vContrAmmTot = decimal.Parse(d.AdditionalAttributes["Importo_Ammesso_Totale"]);

                if (d.AdditionalAttributes["Forma"] == "2")
                {   // Ente pubblico
                    vContrPagTot = decimal.Parse(d.AdditionalAttributes["CONTRIBUTO_AMMISSIBILE_TOTALE"]);
                }
                else 
                {   // Attività privata
                    vContrPagTot = decimal.Parse(d.AdditionalAttributes["CONTRIBUTO_PAGATO_TOTALE"]);
                }
                vImpoApp = decimal.Parse(d.AdditionalAttributes["IMPORTO_APPALTO"]);
                //vContrAmmApp = decimal.Parse(d.AdditionalAttributes["CONTRIBUTO_AMMISSIBILE_APPALTO"]);
                if (!string.IsNullOrEmpty(d.AdditionalAttributes["Tipo_Appalto"]))
                {
                    vContrAmmApp = decimal.Parse(d.AdditionalAttributes["Importo_Ammesso_Totale"]);
                }

                e.Item.Cells[cAzione].Text      = d.AdditionalAttributes["AZIONE"];
                e.Item.Cells[cIdProgeto].Text   = d.AdditionalAttributes["ID_PROGETTO"];
                e.Item.Cells[cTipoDomPag].Text  = d.AdditionalAttributes["TIPO_DOMPAG"];
                e.Item.Cells[cContrAmmTot].Text = string.Format("{0:c}", vContrAmmTot);
                e.Item.Cells[cContrPagTot].Text = string.Format("{0:c}", vContrPagTot);
                e.Item.Cells[cTipoApp].Text     = d.AdditionalAttributes["TIPO_APPALTO"];
                e.Item.Cells[cImpoApp].Text     = string.Format("{0:c}", vImpoApp);
                e.Item.Cells[cContrAmmApp].Text = string.Format("{0:c}", vContrAmmApp);
                e.Item.Cells[cTipoProcApp].Text = d.AdditionalAttributes["TIPO_PROCAGG_APPALTO"];
                e.Item.Cells[cImprApp].Text     = d.AdditionalAttributes["IMPRESA_APPALTO"];

                /*
                tot_contributo_ammesso  += decimal.Parse(d.AdditionalAttributes["CONTRIBUTO_AMMISSIBILE_TOTALE"]);
                tot_contributo_pagato   += decimal.Parse(d.AdditionalAttributes["CONTRIBUTO_PAGATO_TOTALE"]);
                tot_importo_appalto     += decimal.Parse(d.AdditionalAttributes["IMPORTO_APPALTO"]);
                tot_ammissib_appalto    += decimal.Parse(d.AdditionalAttributes["CONTRIBUTO_AMMISSIBILE_APPALTO"]);
                */

                tot_contributo_ammesso += vContrAmmTot;
                tot_contributo_pagato  += vContrPagTot;
                tot_importo_appalto    += vImpoApp;
                tot_ammissib_appalto   += vContrAmmApp;
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[cfTotale].Text     = "Totale";
                e.Item.Cells[cfContAmm].Text    = string.Format("{0:c}", tot_contributo_ammesso);
                e.Item.Cells[cfContPag].Text    = string.Format("{0:c}", tot_contributo_pagato);
                e.Item.Cells[cfImpApp].Text     = string.Format("{0:c}", tot_importo_appalto);
                e.Item.Cells[cfAmmApp].Text     = string.Format("{0:c}", tot_ammissib_appalto);
            }
        }

        #endregion
    }
}
