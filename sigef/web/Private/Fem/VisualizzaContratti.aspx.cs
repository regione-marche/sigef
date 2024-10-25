using SiarBLL;
using SiarLibrary;
using System;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.Fem
{
    public partial class VisualizzaContratti : SiarLibrary.Web.PrivatePage
    {
        BandoCollectionProvider bando_provider = new BandoCollectionProvider();
        ProgettoCollectionProvider progetto_provider = new ProgettoCollectionProvider();
        ContrattiFemCollectionProvider contratti_provider = new ContrattiFemCollectionProvider();
        ContrattiFemPagamentiCollectionProvider pagamenti_provider = new ContrattiFemPagamentiCollectionProvider();
        ErogazioneFemCollectionProvider erogazione_provider = new ErogazioneFemCollectionProvider();

        #region Indici colonne Datagrid

        //dgBandi
        private int col_bandi_Id = 0,
                col_bandi_Descr = 1,
                col_bandi_Importo = 2,
                col_bandi_Rup = 3,
                col_bandi_Check = 4;

        //dgContrattiPagamenti
        private int col_idContr = 0,
            col_tipo = 1,
            col_numeroContr = 2,
            col_dataContr = 3,
            col_importoContr = 4,
            col_fileContr = 5,
            col_idPag = 6,
            col_tipoPag = 7,
            col_dataPag = 8,
            col_estremiPag = 9,
            col_filePag = 10,
            col_importoPag = 11,
            col_importoPagAmm = 12,
            col_erogazione = 13;

        #endregion

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "visualizza_contratti";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected override void OnPreRender(EventArgs e)
        {
            //int id_prog_artig = int.Parse(ConfigurationManager.AppSettings["IdProgettoArtigiancassa"]);
            //int id_prog_conf3 = int.Parse(ConfigurationManager.AppSettings["IdProgettoConfidiAsse3"]);
            //int id_prog_conf8 = int.Parse(ConfigurationManager.AppSettings["IdProgettoConfidiAsse8"]);

            //var prog_artig = progetto_provider.GetById(id_prog_artig);
            //var prog_conf3 = progetto_provider.GetById(id_prog_conf3);
            //var prog_conf8 = progetto_provider.GetById(id_prog_conf8);

            // SVILUPPO
            #region Sviluppo
            var prog_sog_artigiancassa = new ProgettoSoggettoGestoreCollectionProvider().FindProgettiSoggettoGestore(
                (int)SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Artigiancassa,
                null,
                null,
                null,
                null,
                null,
                null);
            if (prog_sog_artigiancassa.Count != 1)
                throw new Exception("Progetto Artigiancassa non trovato");
            var prog_artig = new ProgettoCollectionProvider().GetById(prog_sog_artigiancassa[0].IdProgettoRiferimento);

            var prog_sog_asse3 = new ProgettoSoggettoGestoreCollectionProvider().FindProgettiSoggettoGestore(
                (int)SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Confidi_Unico,
                null,
                null,
                null,
                null,
                null,
                20);
            if (prog_sog_asse3.Count != 1)
                throw new Exception("Progetto Confidi in asse 3 non trovato");
            var prog_conf3 = new ProgettoCollectionProvider().GetById(prog_sog_asse3[0].IdProgettoRiferimento);

            var prog_sog_asse8 = new ProgettoSoggettoGestoreCollectionProvider().FindProgettiSoggettoGestore(
                (int)SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Confidi_Unico,
                null,
                null,
                null,
                null,
                null,
                54);
            if (prog_sog_asse8.Count != 1)
                throw new Exception("Progetto Confidi in asse 8 non trovato");
            var prog_conf8 = new ProgettoCollectionProvider().GetById(prog_sog_asse8[0].IdProgettoRiferimento);
            #endregion

            // PRODUZIONE
            #region Produzione
            //var prog_sog_artigiancassa = new ProgettoSoggettoGestoreCollectionProvider().FindProgettiSoggettoGestore(
            //    (int)SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Artigiancassa,
            //    null,
            //    null,
            //    null,
            //    null,
            //    null,
            //    null);
            //if (prog_sog_artigiancassa.Count != 1)
            //    throw new Exception("Progetto Artigiancassa non trovato");
            //var prog_artig = new ProgettoCollectionProvider().GetById(prog_sog_artigiancassa[0].IdProgettoRiferimento);

            //var prog_sog_asse3 = new ProgettoSoggettoGestoreCollectionProvider().FindProgettiSoggettoGestore(
            //    (int)SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Confidi,
            //    null,
            //    null,
            //    null,
            //    "3",
            //    null,
            //    null);
            //if (prog_sog_asse3.Count != 1)
            //    throw new Exception("Progetto Confidi in asse 3 non trovato");
            //var prog_conf3 = new ProgettoCollectionProvider().GetById(prog_sog_asse3[0].IdProgettoRiferimento);

            //var prog_sog_asse8 = new ProgettoSoggettoGestoreCollectionProvider().FindProgettiSoggettoGestore(
            //    (int)SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Confidi,
            //    null,
            //    null,
            //    null,
            //    "8",
            //    null,
            //    null);
            //if (prog_sog_asse8.Count != 1)
            //    throw new Exception("Progetto Confidi in asse 8 non trovato");
            //var prog_conf8 = new ProgettoCollectionProvider().GetById(prog_sog_asse8[0].IdProgettoRiferimento);
            #endregion

            var bando_artig = bando_provider.GetById(prog_artig.IdBando);
            var bando_conf3 = bando_provider.GetById(prog_conf3.IdBando);
            var bando_conf8 = bando_provider.GetById(prog_conf8.IdBando);

            string parametri = "";
            var bandi_coll = new BandoCollection();

            int id_Bando;
            if (int.TryParse(hdnIdBando.Value, out id_Bando))
            {
                var pagamenti_coll = new ContrattiFemPagamentiCollection();

                if (id_Bando == bando_artig.IdBando)
                {
                    bandi_coll.Add(bando_artig);

                    var contratti_coll = contratti_provider.FindConfidi(null, false, (int)SiarBLL.SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Artigiancassa, null);
                    foreach (ContrattiFem contratto in contratti_coll)
                        pagamenti_coll.AddCollection(pagamenti_provider.Find(null, contratto.IdContrattoFem, null, null, null));

                    parametri += "IdProgetto=" + prog_artig + "|Confidi=false";
                }
                else if (id_Bando == bando_conf3.IdBando)
                {
                    bandi_coll.Add(bando_conf3);

                    var contratti_coll = contratti_provider.Find(null, prog_conf3.IdProgetto, null, null, true, (int)SiarBLL.SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Confidi_Unico, null);
                    foreach (ContrattiFem contratto in contratti_coll)
                        pagamenti_coll.AddCollection(pagamenti_provider.Find(null, contratto.IdContrattoFem, null, null, null));

                    parametri += "IdProgetto=" + prog_conf3.IdProgetto + "|Confidi=true";
                }
                else if (id_Bando == bando_conf8.IdBando)
                {
                    bandi_coll.Add(bando_conf8);

                    var contratti_coll = contratti_provider.Find(null, prog_conf8.IdProgetto, null, null, true, (int)SiarBLL.SoggettoGestoreCollectionProvider.EnumSoggettiGestore.Confidi_Unico, null);
                    foreach (ContrattiFem contratto in contratti_coll)
                        pagamenti_coll.AddCollection(pagamenti_provider.Find(null, contratto.IdContrattoFem, null, null, null));

                    parametri += "IdProgetto=" + prog_conf8 + "|Confidi=true";
                }
                else
                    throw new Exception("Il bando selezionato non usa strumenti finanziari");

                dgContrattiPagamenti.DataSource = pagamenti_coll;
                dgContrattiPagamenti.ItemDataBound += new DataGridItemEventHandler(dgContrattiPagamenti_ItemDataBound);
                dgContrattiPagamenti.SetTitoloNrElementi();
                dgContrattiPagamenti.DataBind();

                btnEstraiContratti.Attributes.Add("onclick", "SNCVisualizzaReport('rptContrattiFem', 2, '" + parametri + "');");
            }
            else
            {
                divElencoContratti.Visible = false;
                
                bandi_coll.Add(bando_artig);
                bandi_coll.Add(bando_conf3);
                bandi_coll.Add(bando_conf8);
            }

            dgBandi.DataSource = bandi_coll;
            dgBandi.SetTitoloNrElementi();
            dgBandi.ItemDataBound += new DataGridItemEventHandler(dgBandi_ItemDataBound);
            dgBandi.DataBind();

            base.OnPreRender(e);
        }

        #region Button Click

        protected void btnPost_Click(object sender, EventArgs e) { }

        protected void btnEstraiContratti_Click(object sender, EventArgs e)
        {
            try
            {
                int id_prog_artig = int.Parse(ConfigurationManager.AppSettings["IdProgettoArtigiancassa"]);
                int id_prog_conf3 = int.Parse(ConfigurationManager.AppSettings["IdProgettoConfidiAsse3"]);
                int id_prog_conf8 = int.Parse(ConfigurationManager.AppSettings["IdProgettoConfidiAsse8"]);

                var prog_artig = progetto_provider.GetById(id_prog_artig);
                var prog_conf3 = progetto_provider.GetById(id_prog_conf3);
                var prog_conf8 = progetto_provider.GetById(id_prog_conf8);

                var bando_artig = bando_provider.GetById(prog_artig.IdBando);
                var bando_conf3 = bando_provider.GetById(prog_conf3.IdBando);
                var bando_conf8 = bando_provider.GetById(prog_conf8.IdBando);

                string parametri = "";

                int id_Bando;
                if (int.TryParse(hdnIdBando.Value, out id_Bando))
                {
                    if (id_Bando == bando_artig.IdBando)
                        parametri += "IdProgetto=" + id_prog_artig + "|Confidi='false'";
                    else if (id_Bando == bando_conf3.IdBando)
                        parametri += "IdProgetto=" + id_prog_conf3 + "|Confidi='true'";
                    else if (id_Bando == bando_conf8.IdBando)
                        parametri += "IdProgetto=" + id_prog_conf8 + "|Confidi='true'";
                    else
                        throw new Exception("Il bando selezionato non usa strumenti finanziari");
                }
                else
                    throw new Exception("Bando non selezionato");

                string jsFunction = "SNCVisualizzaReport('rptContrattiFem', 2, '" + parametri + "');";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "myJsFn", jsFunction, true);
            }
            catch (Exception ex) { ((SiarLibrary.Web.PrivatePage)Page).ShowError(ex); }
        }

        #endregion

        #region ItemDataBound datagrid

        void dgBandi_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            var dgi = e.Item;

            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var bando = (Bando)dgi.DataItem;

                dgi.Cells[col_bandi_Importo].Text = string.Format("{0:c}", bando.Importo);

                SiarLibrary.BandoResponsabiliCollection resp_coll = new SiarBLL.BandoResponsabiliCollectionProvider().Find(bando.IdBando, null, null, null, true);
                foreach (SiarLibrary.BandoResponsabili resp in resp_coll)
                {
                    if (resp.Provincia == null)
                    {
                        dgi.Cells[col_bandi_Rup].Text = resp.Nominativo;
                    }
                }

                dgi.Cells[col_bandi_Check].Text = dgi.Cells[col_bandi_Check].Text.Replace("<input", "<input checked onclick=\"selezionaBando(" + bando.IdBando + ",this);\"");
                if (hdnIdBando.Value == null || hdnIdBando.Value == "")
                {
                    dgi.Cells[col_bandi_Check].Text = dgi.Cells[col_bandi_Check].Text.Replace("checked", "");
                }
            }
        }

        void dgContrattiPagamenti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            var dgi = e.Item;

            if (dgi.ItemType == ListItemType.Header)
            {
                dgi.CssClass = "TESTA1";
                dgi.Cells[col_idContr].ColumnSpan = 6;
                dgi.Cells[col_idContr].HorizontalAlign = HorizontalAlign.Center;
                dgi.Cells[col_idContr].Text = "CONTRATTO/GIUSTIFICATIVO</td><td align=center colspan=7>PAGAMENTO</td><td align=center>EROGAZIONE</td></tr><tr class='TESTA'><td>ID";
            }
            else if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var cfp = (ContrattiFemPagamenti)dgi.DataItem;
                var cf = contratti_provider.GetById(cfp.IdContrattoFem);

                if (cf.IdGiustificativo == null)
                {
                    dgi.Cells[col_tipo].Text = "Contratto";
                    dgi.Cells[col_numeroContr].Text = cf.Numero;
                    dgi.Cells[col_dataContr].Text = cf.DataStipulaContratto;
                    dgi.Cells[col_importoContr].Text = string.Format("{0:c}", cf.Importo);
                    if (cf.IdFile != null)
                        dgi.Cells[col_fileContr].Text = "<img src='" + Page.ResolveUrl(PATH_IMAGES + "print_ico.gif") + "' alt='File'  onclick=\"SNCUFVisualizzaFile(" + cf.IdFile + ");\" style='cursor: pointer;'>";
                    else if (cf.Segnatura != null )
                        dgi.Cells[col_fileContr].Text = "<img src='" + Page.ResolveUrl(PATH_IMAGES + "print_ico.gif") + "' alt='File'  onclick=\"sncAjaxCallVisualizzaProtocollo('" + cf.Segnatura + "');\" style='cursor: pointer;'>";
                    else
                        dgi.Cells[col_fileContr].Text = "";
                }
                else
                {
                    dgi.Cells[col_tipo].Text = "Giustificativo";
                    dgi.Cells[col_numeroContr].Text = cf.NumeroGiustificativo;
                    dgi.Cells[col_dataContr].Text = cf.DataGiustificativo;
                    dgi.Cells[col_importoContr].Text = string.Format("{0:c}", cf.ImponibileGiustificativo);
                    if (cf.IdFileGiustificativo != null)
                        dgi.Cells[col_fileContr].Text = "<img src='" + Page.ResolveUrl(PATH_IMAGES + "print_ico.gif") + "' alt='File'  onclick=\"SNCUFVisualizzaFile(" + cf.IdFileGiustificativo + ");\" style='cursor: pointer;'>";
                    else
                        dgi.Cells[col_fileContr].Text = "";
                }

                dgi.Cells[col_importoPag].Text = string.Format("{0:c}", cfp.Importo);
                dgi.Cells[col_importoPagAmm].Text = string.Format("{0:c}", cfp.ImportoAmmesso);

                if (cfp.IdFile != null)
                    dgi.Cells[col_filePag].Text = "<img src='" + Page.ResolveUrl(PATH_IMAGES + "print_ico.gif") + "' alt='File'  onclick=\"SNCUFVisualizzaFile(" + cfp.IdFile + ");\" style='cursor: pointer;'>";
                else
                    dgi.Cells[col_filePag].Text = "";

                if (cfp.IdErogazioneFem != null)
                {
                    var erogazione = erogazione_provider.GetById(cfp.IdErogazioneFem);

                    dgi.Cells[col_erogazione].Text = @"<b>Id: </b>" + erogazione.IdErogazione + "<br/>"
                        + "<b>Numero: </b>" + erogazione.Numero + "<br/>"
                        + "<b>Definitiva: </b>" + (erogazione.Definitivo ? "Si" : "No") + "<br/>";
                }
                else
                    dgi.Cells[col_erogazione].Text = "";
            }
        }

        #endregion
    }
}