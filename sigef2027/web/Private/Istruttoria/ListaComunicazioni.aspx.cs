using System;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;

namespace web.Private.Istruttoria
{
    public partial class ListaComunicazioni : SiarLibrary.Web.IstruttoriaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "collaboratori_istruttoria";
            base.OnPreInit(e);
        }

        SiarBLL.ProgettoComunicazioniCollectionProvider com_provider = new SiarBLL.ProgettoComunicazioniCollectionProvider();
        SiarBLL.ProgettoComunicazioniAllegatiCollectionProvider progComAll_provider = new SiarBLL.ProgettoComunicazioniAllegatiCollectionProvider();
        SiarLibrary.ProgettoComunicazioniCollection comunicazioni = new SiarLibrary.ProgettoComunicazioniCollection();
        protected void Page_Load(object sender, EventArgs e) { }

        protected override void OnPreRender(EventArgs e)
        {
            SiarLibrary.NullTypes.IntNT id_progetto = null;
            lstTipoDocumento.DataBind();
            if (!String.IsNullOrEmpty(txtNumeroDomandaFiltro.Text)) id_progetto = int.Parse(txtNumeroDomandaFiltro.Text);
            comunicazioni = com_provider.Find(Bando.IdBando, id_progetto, null, null, lstTipoDocumento.SelectedValue, null).FiltroComunicazioniDomandaAiuto(true, true);
            dgComunicazioni.DataSource = comunicazioni;
            dgComunicazioni.ItemDataBound += new DataGridItemEventHandler(dgComunicazioni_ItemDataBound);
            dgComunicazioni.SetTitoloNrElementi();
            dgComunicazioni.DataBind();

            base.OnPreRender(e);
        }

        protected void btnCerca_Click(object sender, EventArgs e) { }

        void dgComunicazioni_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Footer && e.Item.ItemType != ListItemType.Header)
            {
                DataGridItem dgi = (DataGridItem)e.Item;
                SiarLibrary.ProgettoComunicazioni c = (SiarLibrary.ProgettoComunicazioni)dgi.DataItem;
                e.Item.Cells[2].Text = "<b>Partita iva/Codice fiscale:</b> " + c.Cuaa + "<br/><b>P.Iva:</b> " + c.CodiceFiscale
                     + "<br/><b>Rag.Sociale:</b> " + c.RagioneSociale;
                string url = "";
                if (c.CodTipo == "RCC" || c.CodTipo == "PCC") url = "RichiestaCertificazione";
                if (c.CodTipo == "DNT" || c.CodTipo == "DPT") url = "RichiestaDocumentiIntegrativi";
                if (c.Direzione == "P") // in partenza
                {
                    SiarLibrary.ProgettoComunicazioniAllegatiCollection paColl = progComAll_provider.Find(c.Id, null, null);
                    if (paColl.Count > 0)
                        e.Item.Cells[4].Text = paColl[0].Ente;
                    if (string.IsNullOrEmpty(c.Segnatura))
                        if (c.PredispostaAllaFirma)
                            e.Item.Cells[7].Text = "Predisposta alla firma";
                        else e.Item.Cells[7].Text = "In lavorazione";
                    else e.Item.Cells[7].Text = "Richiesta Inviata";
                    e.Item.Cells[8].Text = "<input type='button' class='ButtonGrid' style='width:70px' " +
                        "onclick=\"location='" + url + ".aspx?idcom=" + c.Id + "'\" value='Dettaglio' />";
                }
                else // in arrivo
                {
                    SiarLibrary.ProgettoComunicazioniAllegatiCollection paColl = progComAll_provider.Find(c.IdComunicazioneRiferimento, null, null);
                    if (paColl.Count > 0)
                        e.Item.Cells[4].Text = paColl[0].Ente;
                    e.Item.Cells[7].Text = "Documento Acquisito";
                    e.Item.Cells[8].Text = "<input type='button' class='ButtonGrid' style='width:70px' " +
                        "onclick=\"location='" + url + ".aspx?idcom=" + c.IdComunicazioneRiferimento + "'\" value='Dettaglio' />";
                }
            }
        }
    }
}
