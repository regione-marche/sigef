using System;
using System.Web.UI.WebControls;

namespace web.Private.PPagamento
{
    public partial class RendicontazioneVeloce : SiarLibrary.Web.DomandaPagamentoPage
    {
        SiarLibrary.SpeseSostenute spesa_selezionata;
        SiarBLL.PianoInvestimentiCollectionProvider investimenti_provider;
        SiarLibrary.PianoInvestimentiCollection investimenti;

        protected void Page_Load(object sender, EventArgs e)
        {
            ucWorkflowPagamento.WorkflowCorrente = new SiarBLL.VworkflowPagamentoCollectionProvider().Find(null, "SPBEN", null, null)[0];
            investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider(PagamentoProvider.DbProviderObj);
            if (!IsPostBack)
            {
                object o = Session["siar_rendicontazione_veloce_spesa_selezionata"];
                Session.Remove("siar_rendicontazione_veloce_spesa_selezionata");
                if (o == null) Redirect("SpeseSostenute.aspx?action=spesa_non_selezionata");
                else
                {
                    spesa_selezionata = (SiarLibrary.SpeseSostenute)o;
                    hdnIdSpesaSostenuta.Value = spesa_selezionata.IdSpesa;
                }
            }
            else
            {
                int id_spesa_sostenuta;
                if (!int.TryParse(hdnIdSpesaSostenuta.Value, out id_spesa_sostenuta)) Redirect("SpeseSostenute.aspx?action=spesa_non_selezionata");
                else
                {
                    spesa_selezionata = new SiarBLL.SpeseSostenuteCollectionProvider().GetById(id_spesa_sostenuta);
                    if (spesa_selezionata == null) Redirect("SpeseSostenute.aspx?action=spesa_non_selezionata");
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            investimenti = investimenti_provider.GetPianoInvestimentiDomandaPagamento(Progetto.IdProgetto, DomandaPagamento.IdDomandaPagamento);
            dgInvestimenti.ItemDataBound += new DataGridItemEventHandler(dgInvestimenti_ItemDataBound);
            dgInvestimenti.DataSource = investimenti;
            dgInvestimenti.DataBind();

            SiarLibrary.SpeseSostenuteCollection giustificativi = new SiarLibrary.SpeseSostenuteCollection();
            giustificativi.Add(spesa_selezionata);
            dgGiustificativo.ItemDataBound += new DataGridItemEventHandler(dgGiustificativo_ItemDataBound);
            dgGiustificativo.DataSource = giustificativi;
            dgGiustificativo.DataBind();
            base.OnPreRender(e);
        }

        void dgInvestimenti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            e.Item.Cells[6].Style.Add("border-left", "solid 1px black");
            e.Item.Cells[6].Style.Add("padding-left", "5px");
            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[0].ColumnSpan = 6;
                e.Item.Cells[0].HorizontalAlign=HorizontalAlign.Center;
                e.Item.Cells[0].Text = "DATI INVESTIMENTO</td><td colspan=4 align=center>DATI PAGAMENTO</td></tr><tr class=TESTA><td>Nr.";
            }
            else if (e.Item.ItemType != ListItemType.Footer)
            {
                SiarLibrary.PianoInvestimenti investimento = (SiarLibrary.PianoInvestimenti)e.Item.DataItem;
                if (investimento.CodTipoInvestimento != 2)
                    e.Item.Cells[3].Text = string.Format("{0:c}", investimento.CostoInvestimento.Value + investimento.SpeseGenerali);
                else 
                {
                    e.Item.Cells[3].Text = string.Format("{0:c}", investimento.CostoInvestimento.Value) + "<br />(Ammontare del mutuo)";
                    e.Item.Cells[5].Text = string.Format("{0:N}", investimento.TassoAbbuono.Value) + "<br />(Tasso di abbuono)";
                }
                /*e.Item.Cells[8].Text = "<input type=text id=txtImportoPagamentoRichiesto" + investimento.IdInvestimento + " style='width:110px;text-align:right'"
                    +" />";
                e.Item.Cells[9].Text = "<input type=text id=txtContributoPagamentoRichiesto" + investimento.IdInvestimento + " style='width:90px;text-align:right'"
                    + " />";*/
            }
        }

        void dgGiustificativo_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Footer && e.Item.ItemType != ListItemType.Header)
            {
                decimal importo_lordo_giustificativo = spesa_selezionata.Imponibile + (spesa_selezionata.Imponibile * spesa_selezionata.Iva / 100);
                e.Item.Cells[4].Text = string.Format("{0:c}", importo_lordo_giustificativo);

                decimal importo_richiesto = 0, importo_ammesso = 0;
                SiarLibrary.PagamentiBeneficiarioCollection richiesti = new SiarBLL.PagamentiBeneficiarioCollectionProvider().
                    Find(null, null, null, spesa_selezionata.IdGiustificativo, null, null);
                //sommo tutti indistintamente, sia gli importi in domande di pagamento annullate o non approvate, sia in domande successive a questa
                foreach (SiarLibrary.PagamentiBeneficiario p in richiesti)
                {
                    if (p.ImportoRichiesto != null) importo_richiesto += p.ImportoRichiesto;
                    if (p.ImportoAmmesso != null) importo_ammesso += p.ImportoAmmesso;
                }
                e.Item.Cells[6].Text = string.Format("{0:c}", importo_richiesto);
                e.Item.Cells[7].Text = string.Format("{0:c}", importo_ammesso);
            }
        }

        protected void btnSalvaRendicontazione_Click(object sender, EventArgs e)
        {

        }
    }
}
