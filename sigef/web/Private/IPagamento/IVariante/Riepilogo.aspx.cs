using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.IPagamento.IVariante
{
    public partial class Riepilogo : SiarLibrary.Web.IstruttoriaVariantePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnPreRender(EventArgs e)
        {
            try
            {
                if (Variante.CuaaEntrante != null)
                {
                    txtCuaaEntrante.Text = Variante.CuaaEntrante;
                    txtCuaaUscente.Text = Variante.CuaaUscente;
                    txtRagSocUscente.Text = Variante.RagsocUscente;
                    SiarBLL.ImpresaCollectionProvider impresa_provider = new SiarBLL.ImpresaCollectionProvider();
                    SiarLibrary.Impresa entrante = impresa_provider.GetByCuaa(Variante.CuaaEntrante);
                    if (entrante == null) throw new Exception("Il beneficiario subentrante definito dalla presente richiesta non è valido.");
                    txtPivaEntrante.Text = entrante.CodiceFiscale;
                    txtRagSocEntrante.Text = entrante.RagioneSociale;
                }
                txtDescrizione.Text = Variante.Descrizione;
                lstModalita.DataBinding += new EventHandler(lstModalita_DataBinding);
                lstModalita.DataBind();
                if (Variante.CodTipo == "AR") txtDescrizione.Enabled = btnSalvaMotivazioni.Visible = btnEliminaVariazione.Visible = true;
            }
            catch (Exception ex) { Redirect("../../ppagamento/gestionelavori.aspx", ex.Message, true); }
            base.OnPreRender(e);
        }

        void lstModalita_DataBinding(object sender, EventArgs e)
        {
            lstModalita.Items.Clear();
            lstModalita.Items.Add(new ListItem("", ""));
            lstModalita.Items.Add(new ListItem("Variante/Variazione Finanziaria", "VA"));
            lstModalita.Items.Add(new ListItem("Adeguamento tecnico", "AT"));
            lstModalita.Items.Add(new ListItem("Variazione accertata in istruttoria", "VI"));
            lstModalita.Items.Add(new ListItem("Rifinizione di esito istruttorio", "AR"));
            foreach (ListItem li in lstModalita.Items) if (li.Value == Variante.CodTipo) { li.Selected = true; break; }
        }

        protected void btnEliminaVariazione_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (Variante.Segnatura != null) throw new Exception("Impossibile eliminare la variazione perchè è stata resa definitiva.");
                if (Variante.CodTipo != "AR") throw new Exception("Impossibile eliminare una variante/A.T. richiesta dal beneficiario.");
                VarianteProvider.DbProviderObj.BeginTran();
                // esiti step
                SiarBLL.VariantiEsitiRequisitiCollectionProvider esiti_provider = new SiarBLL.VariantiEsitiRequisitiCollectionProvider(VarianteProvider.DbProviderObj);
                esiti_provider.DeleteCollection(esiti_provider.Find(Variante.IdVariante, null));
                //investimenti
                SiarBLL.PianoInvestimentiCollectionProvider investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider(VarianteProvider.DbProviderObj);
                SiarLibrary.PianoInvestimentiCollection investimenti_variante = investimenti_provider.Find(null, null, null, null, null, null, null)
                    .FiltroVariante(Variante.IdVariante);
                //SiarBLL.LocalizzazioneInvestimentoCollectionProvider localizzazione_provider = new SiarBLL.LocalizzazioneInvestimentoCollectionProvider(VarianteProvider.DbProviderObj);
                SiarBLL.PrioritaXInvestimentiCollectionProvider priorita_provider = new SiarBLL.PrioritaXInvestimentiCollectionProvider(VarianteProvider.DbProviderObj);
                foreach (SiarLibrary.PianoInvestimenti i in investimenti_variante)
                {
                    //localizzazione_provider.DeleteCollection(localizzazione_provider.Find(null, i.IdInvestimento, null, null));
                    priorita_provider.DeleteCollection(priorita_provider.Find(null, i.IdInvestimento, null, null));
                }
                investimenti_provider.DeleteCollection(investimenti_variante);
                //allegati
                SiarBLL.VariantiAllegatiCollectionProvider allegati_provider = new SiarBLL.VariantiAllegatiCollectionProvider(VarianteProvider.DbProviderObj);
                allegati_provider.DeleteCollection(allegati_provider.Find(Variante.IdVariante,null,null));
                VarianteProvider.Delete(Variante);
                VarianteProvider.DbProviderObj.Commit();
                Variante = null;
                Redirect("../../ppagamento/GestioneLavori.aspx", "Variazione di istruttoria eliminata correttamente.", false);
            }
            catch (Exception ex) { VarianteProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnSalvaMotivazioni_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (Variante.CodTipo != "AR") throw new Exception("Impossibile modificare una variante/A.T. richiesta dal beneficiario.");
                Variante.Descrizione = txtDescrizione.Text;
                VarianteProvider.AggiornaVarianteIstruttoria(Variante, Operatore);
                ShowMessage("Modifiche salvate correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}