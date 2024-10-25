using System;
using System.Web.UI.WebControls;

namespace web.Private.IPagamento
{
    public partial class SelezioneDomande : SiarLibrary.Web.IstruttoriaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "selezione_domande_rendicontazione";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnPreRender(EventArgs e)
        {
            lstOperatore.IdBando = Bando.IdBando;
            lstOperatore.DataBind();
            lstStato.DataBinding += new EventHandler(lstStato_DataBinding);
            lstStato.DataBind();
            lstProvince.CodRegione = "11";
            lstProvince.DataBind();

            if (!IsPostBack) getParametriRicerca();

            SiarLibrary.VistruttoriaDomandeCollection domande = new SiarBLL.VistruttoriaDomandeCollectionProvider().FindIPagamenti(Bando.IdBando,
                lstOperatore.SelectedValue, txtNumero.Text, lstStato.SelectedValue, lstProvince.SelectedValue, txtCuaa.Text, txtRagioneSociale.Text,
                chkPagamenti.Checked, chkVarianti.Checked, chkAdeguamentiTecnici.Checked, chkIstruttoriaConclusa.Checked, chkIstruttoriaInCorso.Checked,
                chkAnnullati.Checked);
            dg.DataSource = domande;
            dg.Titolo = "Elementi trovati: " + domande.Count.ToString();
            dg.ItemDataBound += new DataGridItemEventHandler(dg_ItemDataBound);
            dg.DataBind();
            base.OnPreRender(e);
        }

        void dg_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataGridItem dgi = (DataGridItem)e.Item;
                SiarLibrary.VistruttoriaDomande progetto = (SiarLibrary.VistruttoriaDomande)dgi.DataItem;
                /*dgi.Cells[1].Text = "NUMERO: <b>" + progetto.IdProgetto + "</b>&nbsp;&nbsp;-&nbsp;&nbsp; CUAA: <b>" + progetto.Cuaa
                    + "<br />Rag.soc:</b> " + progetto.RagioneSociale + "<br /><b>Sede:</b> " + progetto.Comune + " ("
                    + progetto.Sigla + ") - " + progetto.Cap;*/

                dgi.Cells[1].Style.Add("cursor", "pointer");
                dgi.Cells[1].CssClass = "clickable";
                dgi.Cells[1].Attributes.Add("onclick", "dettaglioDomanda(" + progetto.IdProgetto + ",this)");
                dgi.Cells[1].Text = "NUMERO: <b>" + progetto.IdProgetto + "</b>&nbsp;-&nbsp;Partita iva/Codice fiscale: <b>" + progetto.Cuaa;
                dgi.Cells[5].Text = "<a href='../PPAgamento/GestioneLavori.aspx?iddom=" + progetto.IdProgetto
                    + "'><img src='../../images/config.ico' alt='Vai alla gestione dei lavori della domanda' /></a>";
                dgi.Cells[6].Text = "<a href='../Istruttoria/MonitoraggioStatoProgetto.aspx?iddom=" + progetto.IdProgetto + "'>Visualizza</a>";
            }
        }

        void lstStato_DataBinding(object sender, EventArgs e)
        {
            lstStato.Items.Clear();
            lstStato.Items.Add(new ListItem("Finanziabile", "F"));
            lstStato.Items.Add(new ListItem("Avviato", "V"));
            lstStato.Items.Add(new ListItem("SAL", "S"));
            lstStato.Items.Add(new ListItem("Secondo SAL", "O"));
            lstStato.Items.Add(new ListItem("Rendicontato", "T"));
            lstStato.Items.Add(new ListItem("Escluso", "E"));
            lstStato.Items.Add(new ListItem("Rinuncia", "R"));
            foreach (ListItem li in lstStato.Items)
                if (li.Value == lstStato.SelectedValue) li.Selected = true;
        }

        protected void btnCerca_Click(object sender, EventArgs e) { setParametriRicerca(); }

        private object ParametriRicerca
        {
            get { return Session["_paramRicercaIPagamenti"]; }
            set { Session["_paramRicercaIPagamenti"] = value; }
        }

        protected void setParametriRicerca()
        {
            string stringa_parametri =
                "operatore:" + lstOperatore.SelectedValue
                + "|idp:" + txtNumero.Text
                + "|stato:" + lstStato.SelectedValue
                + "|provincia:" + lstProvince.SelectedValue
                + "|cuaa:" + txtCuaa.Text
                + "|ragsoc:" + txtRagioneSociale.Text
                + "|chkPag:" + chkPagamenti.Checked.ToString()
                + "|chkVar:" + chkVarianti.Checked.ToString()
                + "|chkAt:" + chkAdeguamentiTecnici.Checked.ToString()
                + "|chkIstConclusa:" + chkIstruttoriaConclusa.Checked.ToString()
                + "|chkIstinCorso:" + chkIstruttoriaInCorso.Checked.ToString()
                + "|chkAnn:" + chkAnnullati.Checked.ToString();
            ParametriRicerca = stringa_parametri;
        }

        protected void getParametriRicerca()
        {
            if (ParametriRicerca != null)
            {
                string[] parametri = ParametriRicerca.ToString().Split('|');
                lstOperatore.SelectedValue = parametri[0].Split(':')[1];
                txtNumero.Text = parametri[1].Split(':')[1];
                lstStato.SelectedValue = parametri[2].Split(':')[1];
                lstProvince.SelectedValue = parametri[3].Split(':')[1];
                txtCuaa.Text = parametri[4].Split(':')[1];
                txtRagioneSociale.Text = parametri[5].Split(':')[1];
                chkPagamenti.Checked = bool.Parse(parametri[6].Split(':')[1]);
                chkVarianti.Checked = bool.Parse(parametri[7].Split(':')[1]);
                chkAdeguamentiTecnici.Checked = bool.Parse(parametri[8].Split(':')[1]);
                chkIstruttoriaConclusa.Checked = bool.Parse(parametri[9].Split(':')[1]);
                chkIstruttoriaInCorso.Checked = bool.Parse(parametri[10].Split(':')[1]);
                chkAnnullati.Checked = bool.Parse(parametri[11].Split(':')[1]);
            }
        }

        protected void btnResetForm_Click(object sender, EventArgs e)
        {
            ParametriRicerca = null;
        }
    }
}