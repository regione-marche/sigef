using System;
using System.Web.UI.WebControls;
using SiarLibrary.NullTypes;

namespace web.Private.Impresa
{
    public partial class ImpresaDomande : SiarLibrary.Web.ImpresaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "impresa_domande";
            base.OnPreInit(e);
        }

        SiarBLL.BandoCollectionProvider bando_provider = new SiarBLL.BandoCollectionProvider();
        SiarBLL.ProgettoCollectionProvider progprovider = new SiarBLL.ProgettoCollectionProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnPreRender(EventArgs e)
        {
            lstEntiBando.DataBind();
            lstZProgrammazione.AttivazioneBandi = true;
            lstZProgrammazione.DataBind();
            SiarLibrary.BandoCollection bandi = bando_provider.RicercaBandiImpresa(Azienda.IdImpresa, lstEntiBando.SelectedValue, lstZProgrammazione.SelectedValue,
                txtScadenza.Text, chkAdesioni.Checked);
            dgBandi.DataSource = bandi;
            dgBandi.ItemDataBound += new DataGridItemEventHandler(dgBandi_ItemDataBound);
            dgBandi.DataBind();
            lblRisultato.Text = bandi.Count.ToString();
            base.OnPreRender(e);
        }

        void dgBandi_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            dgi.Cells[0].Enabled = false;
            if (dgi.ItemType == ListItemType.Header)
            {
                e.Item.Cells[0].RowSpan = 2;
                e.Item.Cells[1].RowSpan = 2;
                e.Item.Cells[2].RowSpan = 2;
                e.Item.Cells[3].RowSpan = 2;
                e.Item.Cells[4].RowSpan = 2;
                e.Item.Cells[5].ColumnSpan = 4;
                e.Item.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                dgi.Cells[5].Text = "Domande di aiuto</td></tr><tr class='TESTA'><td>Numero";
            }
            else if (dgi.ItemType != ListItemType.Footer)
            {
                SiarLibrary.Bando b = (SiarLibrary.Bando)dgi.DataItem;
                int nr_progetti, id_progetto, ordine_fase, ordine_stato;
                bool flag_preadesione;
                int.TryParse(b.AdditionalAttributes["NR_PROGETTI"], out nr_progetti);
                int.TryParse(b.AdditionalAttributes["ID_PROGETTO"], out id_progetto);
                int.TryParse(b.AdditionalAttributes["ORDINE_FASE_PROGETTO"], out ordine_fase);
                int.TryParse(b.AdditionalAttributes["ORDINE_STATO_PROGETTO"], out ordine_stato);
                bool.TryParse(b.AdditionalAttributes["FLAG_PREADESIONE"], out flag_preadesione);
                string cod_stato = b.AdditionalAttributes["COD_STATO_PROGETTO"], stato = b.AdditionalAttributes["STATO_PROGETTO"];

                if (nr_progetti == 1)
                {
                    string messaggio_pulsante = "Domanda di aiuto";
                    string url = "location='../PDomanda/DatiGenerali.aspx?iddom=" + id_progetto + "'";
                    if (b.InteresseFiliera)
                    {
                        messaggio_pulsante = "Manifestazione";
                        url = "location='../ManifInteresse/DatiGenerali.aspx?idman=" + id_progetto + "'";
                    }
                    if (flag_preadesione) url = "SNCVisualizzaReport('rpt_StampaPreDomanda',1,'Id_Progetto=" + id_progetto + "');";
                    //else if (b.Multiprogetto)
                    //{
                    //    messaggio_pulsante = "Elenco domande";
                    //    url = "location='selezionedomande.aspx?idb=" + b.IdBando + "'";
                    //}
                    else
                    {
                        dgi.Cells[5].Text = id_progetto.ToString();
                        dgi.Cells[6].Text = stato;
                        //Se la domanda è non ricevibile o non ammissibile e non ha presentato altre domande aggiungo il pulsante pèer presentarne una nuova
                        if ((b.Multiprogetto || cod_stato == "B" || cod_stato == "Q") && b.DataScadenza > DateTime.Now)
                        {
                            dgi.Cells[4].Text = "<input type=button class='btn btn-primary py-1' value='Ripresenta domanda' onclick=\"location='nuovadomanda.aspx?idb=" + b.IdBando + "&idimp=" + Azienda.IdImpresa + "'\" />";
                        }
                        if (ordine_stato == 1 && ordine_fase > 3)
                            dgi.Cells[8].Text = "<input type=button class='btn btn-primary py-1' value='prosegui >>' onclick=\"location='../PPagamento/GestioneLavori.aspx?iddom=" + id_progetto + "';\" />";
                    }
                    dgi.Cells[7].Text = "<input type=button class='btn btn-primary py-1' value='" + messaggio_pulsante
                        + "' onclick=\"" + url + "\" />";
                    dgi.Cells[0].Text = dgi.Cells[0].Text.Replace("<input", "<input checked");
                }
                else if (nr_progetti > 1)
                {
                    Boolean pulsante_ripresenta = true;
                    dgi.Cells[5].Text = "";
                    dgi.Cells[6].Text = "";
                    dgi.Cells[8].Text = "";
                    SiarLibrary.ProgettoCollection coll_prog = progprovider.Find(b.IdBando, Azienda.IdImpresa, null, null, null, false, null);
                    foreach (SiarLibrary.Progetto pp in coll_prog)
                    {
                        dgi.Cells[5].Text += "<div style=' height: 30px;padding-top:5px'><Label>" + pp.IdProgetto.ToString() + "</Label></div>";
                        dgi.Cells[6].Text += "<div style=' height: 30px;padding-top:5px'><Label>" + pp.Stato + "</Label></div>";
                        dgi.Cells[7].Text += "<div style=' height: 30px;padding-top:5px'><input style='width:150px' type=button class=ButtonGrid value='Domanda di aiuto' onclick=location='../PDomanda/DatiGenerali.aspx?iddom=" + pp.IdProgetto.ToString() + "' /></div>";
                        if (pp.CodStato != "B" && pp.CodStato != "Q")
                            pulsante_ripresenta = false;
                        if (pp.OrdineFase != null && pp.OrdineFase > 3 && pp.OrdineStato == 1)
                            dgi.Cells[8].Text += "<div style=' height: 30px;padding-top:5px'><input type=button class='btn btn-primary py-1' value='prosegui >>' onclick=\"location='../PPagamento/GestioneLavori.aspx?iddom=" + pp.IdProgetto.ToString() + "';\" /></div>";
                        else
                            dgi.Cells[8].Text += "<div style=' height: 30px;padding-top:5px'></div>";

                    }
                    if (b.DataScadenza > DateTime.Now && (pulsante_ripresenta || b.Multiprogetto))
                        dgi.Cells[4].Text = "<input type=button class='btn btn-primary py-1' value='Ripresenta domanda' onclick=\"location='nuovadomanda.aspx?idb=" + b.IdBando + "&idimp=" + Azienda.IdImpresa + "'\" />";
                }
                else
                {
                    string messaggio_pulsante = "Presenta domanda";
                    string url = "nuovadomanda.aspx?idb=" + b.IdBando + "&idimp=" + Azienda.IdImpresa;
                    if (b.InteresseFiliera)
                    {
                        messaggio_pulsante = "Presenta manifestazione";
                        url = "../ManifInteresse/Inserimento.aspx?idb=" + b.IdBando + "&idimp=" + Azienda.IdImpresa;
                    }
                    dgi.Cells[4].Text = "<input type=button class='btn btn-primary py-1' value='" + messaggio_pulsante + "' onclick=\"location='"
                        + url + "'\" />";
                }
                if (b.DataScadenza < DateTime.Now)
                {
                    dgi.Cells[3].Text = "Scaduto";
                    dgi.Cells[4].Text = " ";
                }
                if (!Azienda.Attiva) dgi.Cells[4].Text = " ";
            }
        }

        protected void btnCerca_Click(object sender, System.EventArgs e)
        {
            dgBandi.SetPageIndex(0);
        }

        protected void btnNoFilter_Click(object sender, System.EventArgs e)
        {
            lstZProgrammazione.ClearSelection();
            txtScadenza.Text = "";
            chkAdesioni.Checked = false;
        }
    }
}