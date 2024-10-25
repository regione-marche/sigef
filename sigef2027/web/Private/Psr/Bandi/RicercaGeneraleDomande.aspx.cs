using System;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;

namespace web.Private.Psr.Bandi
{
    public partial class RicercaGeneraleDomande : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "bando_ricerca_progetti";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnPreRender(EventArgs e)
        {
            string cod_ente_operatore = Operatore.Utente.CodEnte;
            if (cod_ente_operatore != "%" && cod_ente_operatore != "RM")
            {
                if (cod_ente_operatore == "RM_DEC") cod_ente_operatore = "RM";
                lstEntiBando.SelectedValue = cod_ente_operatore;
                lstEntiBando.Enabled = false;
            }

            lstIstruttoreAssegnato.CommandText = @"SELECT DISTINCT U.ID_UTENTE,NOMINATIVO FROM COLLABORATORI_X_BANDO C INNER JOIN BANDO B ON C.ID_BANDO=B.ID_BANDO
                INNER JOIN vUTENTI U ON C.ID_UTENTE=U.ID_UTENTE" + (cod_ente_operatore == "%" ? "" : " WHERE B.COD_ENTE='" + cod_ente_operatore + "'") + " ORDER BY U.NOMINATIVO";
            lstIstruttoreAssegnato.DataBind();

            lstRespProvinciale.CommandText = @"SELECT DISTINCT ID_UTENTE,NOMINATIVO FROM vBANDO_RESPONSABILI WHERE ATTIVO=1 AND PROVINCIA IS NOT NULL"
                + (cod_ente_operatore != "%" ? " AND COD_ENTE LIKE '" + cod_ente_operatore + "%'" : "") + " ORDER BY NOMINATIVO";
            lstRespProvinciale.DataBind();
            lstStatoProgetto.DataBind();
            lstProvince.DataBind();
            lstEntiBando.DataBind();
            lstProgrammazione.DataBind();
            lstTipoPag.DataBind();
            if (IsPostBack)
            {
                SiarLibrary.ProgettoCollection pp = new SiarBLL.ProgettoCollectionProvider().RicercaGeneraleProgetti(txtIdProgetto.Text, lstStatoProgetto.SelectedValue, ucZoomBando.SelectedValue,
                     txtCuaa.Text, txtRagioneSociale.Text, lstProvince.SelectedValue, lstProgrammazione.SelectedValue, lstEntiBando.SelectedValue,
                     lstIstruttoreAssegnato.SelectedValue, lstRespProvinciale.SelectedValue, chkPagamenti.Checked, chkVarianti.Checked, chkAdeguamentiTecnici.Checked,
                     chkIstruttoriaConclusa.Checked, chkIstruttoriaInCorso.Checked, chkAnnullati.Checked, lstTipoPag.SelectedValue);
                dgDomande.DataSource = pp;
                dgDomande.ItemDataBound += new DataGridItemEventHandler(dgDomande_ItemDataBound);
                dgDomande.DataBind();
                lblNrElementi.Text = pp.Count.ToString();
                if (pp.Count == 0) dgDomande.Titolo = "Nessun elemento trovato.";
            }
            base.OnPreRender(e);
        }

        void dgDomande_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.Progetto p = (SiarLibrary.Progetto)e.Item.DataItem;
                e.Item.Cells[4].Text = p.AdditionalAttributes["PROGRAMMAZIONE"];
                e.Item.Cells[5].Text = p.AdditionalAttributes["PIVA"] + " - " + p.AdditionalAttributes["RAGIONE_SOCIALE"];

                //SiarLibrary.AllegatiProtocollatiCollection allegati = new SiarBLL.AllegatiProtocollatiCollectionProvider().Find(p.IdProgetto, null, null, null, null, null, null, null);
                //int numeroAllegati = allegati.Count;
                //bool allegatiProtocollatiOk = checkAllegatiProtocollati(p, numeroAllegati);
                bool allegatiProtocollatiOk = new SiarBLL.AllegatiProtocollatiCollectionProvider().CheckAllegatiProtocollati(SiarBLL.AllegatiProtocollatiCollectionProvider.TipoCheck.Progetto, p.IdProgetto, p.Segnatura);

                if (p.CodStato == "P") e.Item.Cells[7].Text = "<input type=button class='btn btn-secondary py-1' value='Sezione domanda' onclick=\"location='../../pdomanda/datigenerali.aspx?iddom="
                    + p.IdProgetto + "'\" />";
                else if (!allegatiProtocollatiOk) e.Item.Cells[7].Text = "<input type=button class=ButtonGrid value='Protocolla allegati' onclick=\"location='../../pdomanda/RiepilogoDomanda.aspx?iddom="
                    + p.IdProgetto + "'\" />";
                else e.Item.Cells[7].Text = "<input type=button class='btn btn-secondary py-1' value='Istruttoria domanda' onclick=\"location='../../istruttoria/checklistammissibilita.aspx?iddom="
                    + p.IdProgetto + "&idb=" + p.IdBando + "'\" />";
                if (p.OrdineFase.Between(4, 9))
                    e.Item.Cells[8].Text = "<input type=button class='btn btn-secondary py-1' value='Gestione lavori'  onclick=\"location='../../ppagamento/gestionelavori.aspx?iddom="
                        + p.IdProgetto + "'\" />";
                //e.Item.Cells[6].Text = "€ " + string.Format("{0:N}", new SiarLibrary.NullTypes.DecimalNT(p.AdditionalAttributes["COSTO_PROGETTO"]));
                //e.Item.Cells[7].Text = "€ " + string.Format("{0:N}", new SiarLibrary.NullTypes.DecimalNT(p.AdditionalAttributes["CONTRIBUTO_PROGETTO"]));
            }
        }

        protected void btnCerca_Click(object sender, EventArgs e)
        {
            dgDomande.SetPageIndex(0);
        }
    }
}
