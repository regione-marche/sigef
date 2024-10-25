using System;
using System.Web.UI.WebControls;

namespace web.Private.PPagamento
{
    public partial class BusinessPlan : SiarLibrary.Web.DomandaPagamentoPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SiarLibrary.BusinessPlanCollection sezioni = new SiarLibrary.BusinessPlanCollection();

            // sezioni
            //SiarLibrary.BusinessPlan b1 = new SiarLibrary.BusinessPlan();
            //b1.Quadro = "Produzione lorda vendibile e unità lavorative aziendali per l'anno corrente";
            //b1.Url = "PlvAnnoCorrente.aspx";
            //sezioni.Add(b1);

            SiarLibrary.BusinessPlan b2 = new SiarLibrary.BusinessPlan();
            b2.Quadro = "Bilancio aziendale";
            b2.Url = "BilancioAziendale.aspx";
            sezioni.Add(b2);

            SiarLibrary.BusinessPlan b3 = new SiarLibrary.BusinessPlan();
            b3.Quadro = "Fatturato";
            b3.Url = "Fatturato.aspx";
            sezioni.Add(b3);

            SiarLibrary.BusinessPlan b4 = new SiarLibrary.BusinessPlan();
            b4.Quadro = "Valutazione economico-finanziaria del piano di sviluppo";
            b4.Url = "PianoSviluppo.aspx";
            sezioni.Add(b4);

            dg.DataSource = sezioni;
            dg.Titolo = "NR. 3 SEZIONI ELENCATE";
            dg.ItemDataBound += new DataGridItemEventHandler(dg_ItemDataBound);            
            dg.DataBind();
        }

        void dg_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                SiarLibrary.BusinessPlan s = (SiarLibrary.BusinessPlan)e.Item.DataItem;
                e.Item.Cells[0].Attributes.Add("onmouseover", "selectRow(this,'#fefeee');");
                e.Item.Cells[0].Attributes.Add("onmouseout", "unselectRow(this);");
                e.Item.Cells[0].Attributes.Add("onclick", "location='" + s.Url + "'");
            }
        }
    }
}
