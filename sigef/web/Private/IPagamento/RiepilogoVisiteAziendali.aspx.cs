using System;
using System.Web.UI.WebControls;

namespace web.Private.IPagamento
{
    public partial class RiepilogoVisiteAziendali : SiarLibrary.Web.IstruttoriaPagamentoPage
    {
        SiarBLL.UtentiCollectionProvider utenti_provider = new SiarBLL.UtentiCollectionProvider();
        SiarBLL.VisiteAziendaliCollectionProvider visite_provider = new SiarBLL.VisiteAziendaliCollectionProvider();
        SiarLibrary.VisiteAziendaliCollection visite_aziendali;

        protected void Page_Load(object sender, EventArgs e) { }

        protected override void OnPreRender(EventArgs e)
        {
            visite_aziendali = visite_provider.Find(null, null, ucIDomandaPagamento.Impresa.IdImpresa, null, null, null);
            lblNumVisite.Text = visite_aziendali.Count.ToString();
            dgVisite.DataSource = visite_aziendali;
            //dgVisite.ItemDataBound += new DataGridItemEventHandler(dgVisite_ItemDataBound);
            dgVisite.DataBind();

            // visita in situ
            SiarLibrary.VisiteAziendaliCollection visite_in_situ = visite_aziendali.FiltroTipo("VIS", DomandaPagamento.IdDomandaPagamento);
            bool visita_in_situ_presente = visite_in_situ.Count > 0;
            btnAvviaVIS.Enabled = AbilitaModifica && !visita_in_situ_presente;
            if (visita_in_situ_presente && !visite_in_situ[0].ControlloConcluso)
            {
                btnStampaVerbaleVIS.Disabled = false;
                btnStampaVerbaleVIS.Attributes.Add("onclick", "SNCVisualizzaReport('rptVerbaleVIS',1,'IdVisita=" + visite_in_situ[0].IdVisita + "');");
            }
            btnChiudiVIS.Enabled = AbilitaModifica && visita_in_situ_presente && !visite_in_situ[0].ControlloConcluso;
            if (visita_in_situ_presente)
            {
                SiarLibrary.UtentiCollection operatori = utenti_provider.Find(visite_in_situ[0].OperatoreApertura, null, null, null, null, null, null);
                if (operatori.Count > 0) txtVISOperatore.Text = operatori[0].Nominativo;
                txtVISStato.Text = visite_in_situ[0].ControlloConcluso ? "Conclusa" : "In corso";
                if (!IsPostBack) txtVISSegnatura.Text = visite_in_situ[0].SegnaturaVerbale;
            }
            else txtVISStato.Text = "Non effettuata";

            //Controllo in loco
            SiarLibrary.VisiteAziendaliCollection cil = visite_aziendali.FiltroTipo("CIL", DomandaPagamento.IdDomandaPagamento);
            bool cil_presente = cil.Count > 0;
            if (cil_presente)
            {
                txtCILStato.Text = "In corso";
                if (cil[0].ControlloConcluso) txtCILStato.Text = "Conclusa";
                txtCILSegnatura.Text = cil[0].SegnaturaVerbale;
            }
            else txtCILStato.Text = "Non effettuata";
            SiarLibrary.ControlliDomandePagamentoCollection controlli = new SiarBLL.ControlliDomandePagamentoCollectionProvider()
                .Find(null, DomandaPagamento.IdDomandaPagamento, null);
            if (controlli.Count > 0 && controlli[0].OperatoreAssegnato != null)
            {
                SiarLibrary.UtentiCollection controllori = new SiarBLL.UtentiCollectionProvider().Find(controlli[0].OperatoreAssegnato, null, null, null, null, null, null);
                if (controllori.Count > 0) txtCILOperatore.Text = controllori[0].Nominativo;
            }
            base.OnPreRender(e);
        }

        void dgVisite_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                SiarLibrary.VisiteAziendali v = (SiarLibrary.VisiteAziendali)e.Item.DataItem;
                if (v.ControlloConcluso)
                    e.Item.Cells[7].Text = "<img src='../../images/lente.png' style='width:24px;height:24px;cursor:pointer' alt='Visualizza il verbale' onclick=\"sncAjaxCallVisualizzaProtocollo('" + v.SegnaturaVerbale + "');\" />";
            }
        }

        protected void btnAvviaVIS_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.VisiteAziendali vis = new SiarLibrary.VisiteAziendali();
                vis.CodTipo = "VIS";
                vis.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                vis.IdImpresa = ucIDomandaPagamento.Impresa.IdImpresa;
                vis.DataApertura = DateTime.Now;
                vis.OperatoreApertura = Operatore.Utente.CfUtente;
                visite_provider.Save(vis);
                ShowMessage("Visita in situ avviata. Ora è possibile stampare il verbale di controllo.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnChiudiVIS_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.VisiteAziendaliCollection visite_in_situ = visite_provider.Find(null, DomandaPagamento.IdDomandaPagamento,
                    ucIDomandaPagamento.Impresa.IdImpresa, "VIS", Progetto.IdProgetto, null);
                if (visite_in_situ.Count == 0) throw new Exception("Nessuna visita in situ trovata. Impossibile continuare.");
                if (visite_in_situ[0].ControlloConcluso) throw new Exception("La visita in situ selezionata è già stata chiusa.");
                if (string.IsNullOrEmpty(txtVISSegnatura.Text)) throw new Exception("La segnatura del verbale è obbligatoria.");
                //controllo che il documento sia stato acquisito
                if (!new SiarLibrary.Protocollo().ProtocolloEsistente(txtVISSegnatura.Text))
                    throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.DocumentoNonValido);
                visite_in_situ[0].SegnaturaVerbale = txtVISSegnatura.Text;
                visite_in_situ[0].ControlloConcluso = true;
                visite_in_situ[0].DataChiusura = DateTime.Now;
                visite_in_situ[0].OperatoreChiusura = Operatore.Utente.CfUtente;
                visite_provider.Save(visite_in_situ[0]);
                ShowMessage("Visita in situ chiusa correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}