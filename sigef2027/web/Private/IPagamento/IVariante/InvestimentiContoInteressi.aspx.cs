using System;
using System.Data;
using SiarLibrary.Extensions;

namespace web.Private.IPagamento.IVariante
{
    public partial class InvestimentiContoInteressi : SiarLibrary.Web.IstruttoriaVariantePage
    {
        SiarBLL.PianoInvestimentiCollectionProvider investimenti_provider;
        SiarLibrary.Progetto progetto_corrente;
        SiarLibrary.PianoInvestimenti investimento;
        CONTROLS.InvestimentoContoInteressi ComponenteInvestimento;

        protected void Page_Load(object sender, EventArgs e)
        {
            investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider(VarianteProvider.DbProviderObj);
            try
            {
                SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider();
                int id_progetto_corrente;
                if (int.TryParse(Request.QueryString["idpcurrent"], out id_progetto_corrente))
                {
                    // se e' integrato tiro su il progetto relativo alla misura selezionata
                    if (id_progetto_corrente == Progetto.IdProgetto) progetto_corrente = Progetto;
                    else progetto_corrente = progetto_provider.GetById(id_progetto_corrente);
                }
                if (progetto_corrente == null) throw new Exception("L`investimento selezionato non è valido.");

                // permetto l'inserimento di un solo mutuo
                SiarLibrary.PianoInvestimentiCollection mutuocoll = investimenti_provider.Find(null, progetto_corrente.IdProgetto, null, null, null, null,
                    null).FiltroTipoInvestimento(2).FiltroInvestimentoOriginale(false).FiltroVariante(Variante.IdVariante);
                if (mutuocoll.Count > 0) investimento = mutuocoll[0];

                ComponenteInvestimento = (CONTROLS.InvestimentoContoInteressi)LoadControl(Request.ApplicationPath + "/controls/InvestimentoContoInteressi.ascx");
                ComponenteInvestimento.Investimento = investimento;
                ComponenteInvestimento.ProgettoCorrelato = progetto_corrente;
                ComponenteInvestimento.Fase = "IVARIANTE";
                tdInvestimentoComponent.Controls.Add(ComponenteInvestimento);
                ucSiarNewToolTip.Codice = "idomanda_invcinteressi_idb" + progetto_corrente.IdBando;
            }
            catch (Exception ex) { Redirect("PianoInvestimenti.aspx", ex.Message, true); }
        }

        protected override void OnPreRender(EventArgs e)
        {
            btnSalvaInvestimento.Enabled = AbilitaModifica && investimento.CodVariazione != "A";
            base.OnPreRender(e);
        }

        protected void btnSalvaInvestimento_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (investimento.CodVariazione == "A") throw new Exception("Non è possibile modificare un investimento annullato.");
                ComponenteInvestimento.CalcolaContributoInvestimento(true);
                investimento = ComponenteInvestimento.Investimento;
                ShowMessage("Dati del mutuo salvati correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}