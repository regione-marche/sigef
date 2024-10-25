using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace web.Public
{
    public partial class BandiAgid : SiarLibrary.Web.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "Bandi_pubblici_agid";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Form.DefaultButton = btnCerca.UniqueID;
            //if (!IsPostBack)
            //{
            //    if (Request.QueryString["action"] == "bando_non_selezionato")
            //        ShowError("Per inserire una domanda di aiuto è necessario selezionare un bando.");
            //}
        }

        protected override void OnPreRender(EventArgs e)
        {
            lstEntiBando.DataBind();
            lstZProgrammazione.AttivazioneBandi = true;
            lstZProgrammazione.DataBind();
            SiarLibrary.BandoCollection bandi = new SiarBLL.BandoCollectionProvider().RicercaBando(lstEntiBando.SelectedValue,
                lstZProgrammazione.SelectedValue, txtScadenza.Text, txtNumero.Text, txtDataAtto.Text, chkScaduti.Checked, true, orderBy.Value);
            rptBandi.DataSource = bandi;
            rptBandi.DataBind();
            base.OnPreRender(e);
        }

        void dgBandi_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.Bando b = (SiarLibrary.Bando)e.Item.DataItem;
                e.Item.Cells[0].CssClass = "testo_pagina";
                e.Item.Cells[0].Text = "Ente emettitore: <b>" + b.Ente + "<span style='width:30px'></span>Scadenza: <b>" + b.DataScadenza + "</b>"
                    + "<span style='width:30px'></span>Importo: <b>" + b.Importo + "</b><br /><br />" + b.Descrizione;
            }
        }

        protected void btnCerca_Click(object sender, EventArgs e) { }
    }
}