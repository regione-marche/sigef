using System;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;

namespace web.Private.Istruttoria
{
    public partial class MonitoraggioStatoProgetto : SiarLibrary.Web.IstruttoriaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "Istruttoria";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_domanda;
            if (int.TryParse(Request.QueryString["iddom"], out id_domanda))
                ucInfoDomanda.Progetto = new SiarBLL.ProgettoCollectionProvider().GetById(id_domanda);
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (ucInfoDomanda.Progetto != null)
            {
                dg.DataSource = new SiarBLL.ProgettoStoricoCollectionProvider().Find(ucInfoDomanda.Progetto.IdProgetto, null, null);
                dg.ItemDataBound += new DataGridItemEventHandler(dg_ItemDataBound);
                dg.DataBind();

                SiarBLL.ProgettoSegnatureCollectionProvider psegnature_provider = new SiarBLL.ProgettoSegnatureCollectionProvider();
                SiarLibrary.ProgettoSegnatureCollection segnature = psegnature_provider.Find(ucInfoDomanda.Progetto.IdProgetto, null, null, null);
                dgSegnature.DataSource = segnature;
                dgSegnature.ItemDataBound += new DataGridItemEventHandler(dgSegnature_ItemDataBound);
                if (segnature.Count == 0) dgSegnature.Titolo = "Nessun elemento trovato.";
                dgSegnature.DataBind();

                SiarLibrary.ProgettoSegnatureCollection segnature_pagamento = psegnature_provider.FindSegnatureDomandePagamento(ucInfoDomanda.Progetto.IdProgetto);
                dgDomandePagamento.DataSource = segnature_pagamento;
                dgDomandePagamento.ItemDataBound += new DataGridItemEventHandler(dgSegnature_ItemDataBound);
                if (segnature_pagamento.Count == 0) dgDomandePagamento.Titolo = "Nessun elemento trovato.";
                dgDomandePagamento.DataBind();

                SiarLibrary.ProgettoSegnatureCollection segnature_varianti = psegnature_provider.FindSegnatureVarianti(ucInfoDomanda.Progetto.IdProgetto);
                dgVarianti.DataSource = segnature_varianti;
                dgVarianti.ItemDataBound += new DataGridItemEventHandler(dgSegnature_ItemDataBound);
                if (segnature_varianti.Count == 0) dgVarianti.Titolo = "Nessun elemento trovato.";
                dgVarianti.DataBind();
            }
            base.OnPreRender(e);
        }

        void dgSegnature_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.ProgettoSegnature s = (SiarLibrary.ProgettoSegnature)e.Item.DataItem;
                if (s.Segnatura == null) e.Item.Cells[5].Text = "";
                if (s.CodTipo.FindValueIn("RID", "RIP", "RIV"))
                {
                    string url = "dettaglioRiesame('" + (s.RiapriDomanda ? "SI" : "NO") + "','" + s.Motivazione.ToCleanJsString() + "');";
                    e.Item.Cells[2].Text = "<input type=button class='btn btn-secondary py-1' value='Vedi esito' onclick=\""
                        + url + "\" />";
                }
            }
        }

        void dg_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.ProgettoStorico s = (SiarLibrary.ProgettoStorico)e.Item.DataItem;
                e.Item.Cells[2].Text = (s.Riesame ? "Riesame" : (s.Revisione ? "Revisione" : (s.Ricorso ? "Ricorso" : "")));
                if (s.Segnatura == null) e.Item.Cells[5].Text = "";
                else if (s.CodStato == "E")
                {
                    SiarLibrary.Atti decreto = null;
                    int id_decreto;
                    if (int.TryParse(s.Segnatura, out id_decreto)) decreto = new SiarBLL.AttiCollectionProvider().GetById(id_decreto);
                    if (decreto != null) e.Item.Cells[5].Text = "<input type=button class='btn btn-secondary py-1' value='Visualizza decreto' onclick=\""
                        + SiarLibrary.DbStaticProvider.GetJsUrlDecreto(decreto) + "\" />";
                }
            }
        }
    }
}
