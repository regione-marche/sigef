using System;
using System.Web;
using System.Web.UI.WebControls;
using SiarLibrary;
using SiarBLL;

namespace web.Private.ModificaDati
{
    public partial class Ricerca : SiarLibrary.Web.ModificaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnPreRender(EventArgs e)
        {
            popolaImmagini();
            popolaCombo();

            var ricerca_provider = new VricercaProgModificabiliCollectionProvider();
            var cod_ente_operatore = lstEntiBando.SelectedValue != "" ? lstEntiBando.SelectedValue : null;
            VricercaProgModificabiliCollection domande_coll;
            
            var idBando = txtIdBando.Text != "" ? txtIdBando.Text : null;
            var idProgetto = txtIdProgetto.Text != "" ? txtIdProgetto.Text : null;

            if (Operatore.Utente.Profilo.ToString().ToUpper() != "AMMINISTRATORE"
                && !(Operatore.Utente.CodEnte == "AdC"))
            {
                btnCercaDomande.Visible = false;

                domande_coll = ricerca_provider.FindGrande(idBando, cod_ente_operatore, null, null, null, null, idProgetto, null, null, null, null, null, null);

                if (domande_coll.Count > 0)
                {
                    lblDomande.Text = string.Format("Visualizzate {0} righe", domande_coll.Count.ToString());

                    dgDomande.DataSource = domande_coll;
                    dgDomande.ItemDataBound += new DataGridItemEventHandler(dgDomande_ItemDataBound);
                    dgDomande.DataBind();
                }
                else
                {
                    dgDomande.Visible = false;
                    lblDomande.Text = "Nessuna domanda trovata.";
                }
            }
            else
            {
                divEnte.Visible = false;
                divStatoBando.Visible = false;
                divStatoProgetto.Visible = false;
                divImpresa.Visible = false;
                divIstruttore.Visible = false;
                btnFiltraDomande.Visible = false;

                if (IsPostBack) // se ho premuto il pulsante di ricerca
                {
                    domande_coll = ricerca_provider.FindGrande(idBando, cod_ente_operatore, null, null, null, null, idProgetto, null, null, null, null, null, null);

                    if (domande_coll.Count > 0)
                    {
                        lblDomande.Text = string.Format("Visualizzate {0} righe", domande_coll.Count.ToString());

                        dgDomande.DataSource = domande_coll;
                        dgDomande.ItemDataBound += new DataGridItemEventHandler(dgDomande_ItemDataBound);
                        dgDomande.DataBind();
                    }
                    else
                    {
                        dgDomande.Visible = false;
                        lblDomande.Text = "Nessuna domanda trovata.";
                    }
                }
            }

            base.OnPreRender(e);
        }

        private void popolaImmagini()
        {
            imgSearchFilterDomande.Attributes.Add("src", PATH_IMAGES + "lente24.png");
        }

        private void popolaCombo()
        {
            string cod_ente_operatore = Operatore.Utente.CodEnte;
            if (cod_ente_operatore != "%" 
                && cod_ente_operatore != "RM" //Regione Marche
                && cod_ente_operatore != "AdC") //Autorità di Controllo
            {
                if (cod_ente_operatore == "RM_DEC") 
                    cod_ente_operatore = "RM";
                lstEntiBando.SelectedValue = cod_ente_operatore;
                lstEntiBando.Enabled = false;
            }

            lstEntiBando.DataBind();

            var empty_item = new ListItem("", "");
            lstStatoBando.Items.Add(empty_item);
            lstStatoProgetto.Items.Add(empty_item);
            lstImpresa.Items.Add(empty_item);
            lstIstruttore.Items.Add(empty_item);
        }

        #region Button event

        protected void btnPost_Click(object sender, EventArgs e)
        {
            try
            {
                int id_progetto;
                if (int.TryParse(hdnIdProgetto.Value, out id_progetto))
                {
                    Progetto = new ProgettoCollectionProvider().GetById(id_progetto);

                    Redirect(PATH_MODIFICA + "ModificaProgetto.aspx");
                }
                else
                    throw new Exception("Nessun progetto selezionato.");
            }
            catch(Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnCercaDomande_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region ItemDataBound

        void dgDomande_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;

            if (dgi.ItemType == ListItemType.Header)
            {
                dgi.CssClass = "TESTA1";
                dgi.Cells[0].ColumnSpan = 6;
                dgi.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                dgi.Cells[0].Text = "Bando di gara</td><td align=center colspan=4>Domanda di aiuto</td><td align=center>Dettaglio</td></tr><tr class='TESTA'><td>";
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var domanda = (VricercaProgModificabili)dgi.DataItem;

                int col_Info = 0,
                    col_IdBando = 1,
                    col_Entebando = 2,
                    col_DescrizioneBando = 3,
                    col_StatoBando = 4,
                    col_DataScadenzaBando = 5,
                    col_IdProgetto = 6,
                    col_StatoProgetto = 7,
                    col_Impresa = 8,
                    col_IstruttoreProgetto = 9,
                    col_SelezionaProgetto = 10;

                dgi.Cells[col_Info].Text =
                   " <a id='linkBando" + domanda.IdBando + "' href='javascript:mostraPopupDocumentiBando(" + domanda.IdBando + ");'> <img title='Info sul bando' src='" + PATH_IMAGES + "info.ico' /> </a> ";

                var stato_bando_item = new ListItem(domanda.StatoBando, domanda.CodStatoBando);
                if (!lstStatoBando.Items.Contains(stato_bando_item))
                    lstStatoBando.Items.Add(stato_bando_item);

                var stato_progetto_item = new ListItem(domanda.StatoProgetto, domanda.CodStatoProgetto);
                if (!lstStatoProgetto.Items.Contains(stato_progetto_item))
                    lstStatoProgetto.Items.Add(stato_progetto_item);

                var impresa_item = new ListItem(domanda.Impresa, domanda.IdImpresa);
                if (!lstImpresa.Items.Contains(impresa_item))
                    lstImpresa.Items.Add(impresa_item);

                var istruttore_item = new ListItem(domanda.IstruttoreProgetto, domanda.IdIstruttoreProgetto);
                if (!lstIstruttore.Items.Contains(istruttore_item))
                    lstIstruttore.Items.Add(istruttore_item);
            }
        }

        #endregion
    }
}