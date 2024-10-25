using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.COVID
{
    public partial class BandiCovid : SiarLibrary.Web.PrivatePage
    {

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "bandi_covid";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            SiarLibrary.BandoCollection bandi = new SiarBLL.BandoCollectionProvider().RicercaBandoCovid(null,
                null, null, null, null, true, true);
            dgBandi.DataSource = bandi;
            //dgBandi.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgBandi_ItemDataBound);
            dgBandi.DataBind();
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

        protected void btnSelectIdBandoCovid_Click(object sender, EventArgs e)
        {
            Session.Add("id_bando_covid", hdnIdBando.Value);
            Redirect("SelezionaAutocertificazione.aspx");
        }

    }
}