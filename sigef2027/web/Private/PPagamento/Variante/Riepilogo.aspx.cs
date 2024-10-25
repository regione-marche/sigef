using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;
using web.CONTROLS;

namespace web.Private.PPagamento.Variante
{
    public partial class Riepilogo : SiarLibrary.Web.VariantePage
    {
        SiarBLL.ImpresaCollectionProvider impresa_provider = new SiarBLL.ImpresaCollectionProvider();

        protected void Page_Load(object sender, EventArgs e)
        {
            ((HtmlControl)txtCuaaEntrante.Controls[0]).Attributes.Add("onblur", "return ctrlCuaa(event);");

            ucProgettoInd.Progetto = Progetto;
            ucProgettoInd.Istruttoria = ProgettoIndicatori.eIstruttoria.No;
            ucProgettoInd.StatoProgetto = ProgettoIndicatori.eStato.Variante;
            ucProgettoInd.Operatore = Operatore.Utente.IdUtente;
            ucProgettoInd.IdVariante = Variante.IdVariante;
            ucProgettoInd.DataBind();
        }

        protected override void OnPreRender(EventArgs e)
        {
            btnScarica.Enabled = AbilitaModifica && Variante.CodTipo == "VA";
            btnCambiaBeneficiario.Enabled = AbilitaModifica && Variante.CodTipo == "VA" && !string.IsNullOrEmpty(hdnIdImpresaEntrante.Value);
            txtDescrizione.Text = Variante.Descrizione;
            if (Variante.CodTipo == "VI")
            {
                ListItem li = new ListItem("Variazione accertata in istruttoria", "VI");
                li.Selected = true;
                lstModalita.Items.Add(li);
            }
            else if (Variante.CodTipo == "AR")
            {
                ListItem li = new ListItem("Ridefinizione di esito istruttorio", "AR");
                li.Selected = true;
                lstModalita.Items.Add(li);
            }
            else lstModalita.DataBinding += new EventHandler(lstModalita_DataBinding);
            lstModalita.DataBind();
            if (Variante.CodTipo == "VA")
            {
                SiarLibrary.Impresa ie = null;
                if (!IsPostBack && Variante.CuaaEntrante != null)
                {
                    ie = impresa_provider.GetByCuaa(Variante.CuaaEntrante);
                    if (ie != null) hdnIdImpresaEntrante.Value = ie.IdImpresa;
                }
                int id_impresa_entrante;
                if (int.TryParse(hdnIdImpresaEntrante.Value, out id_impresa_entrante))
                    ie = new SiarBLL.ImpresaCollectionProvider().GetById(id_impresa_entrante);
                if (ie != null)
                {
                    txtCuaaEntrante.Text = ie.Cuaa;
                    txtPivaEntrante.Text = ie.CodiceFiscale;
                    txtRagSocEntrante.Text = ie.RagioneSociale;
                }
                txtCuaaUscente.Text = ucCardVarianti.Impresa.Cuaa;
                txtRagSocUscente.Text = ucCardVarianti.Impresa.RagioneSociale;
            }
            base.OnPreRender(e);
        }

        void lstModalita_DataBinding(object sender, EventArgs e)
        {
            lstModalita.Items.Clear();
            lstModalita.Items.Add(new ListItem("", ""));
            lstModalita.Items.Add(new ListItem("Variante", "VA"));
            lstModalita.Items.Add(new ListItem("Adeguamento tecnico", "AT"));
            foreach (ListItem li in lstModalita.Items) if (li.Value == Variante.CodTipo) { li.Selected = true; break; }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (Variante.CodTipo.FindValueIn("VI", "AR")) throw new Exception("Impossibile modificare una variazione di istruttoria.");
                if (Variante.CodTipo != lstModalita.SelectedValue)
                {
                    SiarLibrary.BandoTipoVarianti tipo_variante = new SiarBLL.BandoTipoVariantiCollectionProvider()
                        .GetById(Progetto.IdBando, lstModalita.SelectedValue);
                    if (tipo_variante == null) throw new Exception("Il bando non prevede la modifica degli investimenti della modalità selezionata.");
                    else
                    {
                        if (tipo_variante.NumeroMassimo > 0)
                        {
                            int varianti_inserite = VarianteProvider.Find(null, Progetto.IdProgetto, lstModalita.SelectedValue).Count;
                            if (tipo_variante.NumeroMassimo != null && varianti_inserite >= tipo_variante.NumeroMassimo)
                                throw new Exception("Sono già presenti " + varianti_inserite.ToString()
                                    + " modifiche al piano degli investimenti della modalità selezionata. Non è possibile richiederne altre.");
                        }
                    }
                }
                if (txtDescrizione.Text.Length > 1000) throw new Exception("Descrizione troppo lunga, impossibile salvare.");
                Variante.CodTipo = lstModalita.SelectedValue;
                Variante.Descrizione = txtDescrizione.Text;
                VarianteProvider.AggiornaVariante(Variante, Operatore);

                ucProgettoInd.Salva();

                ShowMessage("Modifiche salvate correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnAnnullamento_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (Variante.Segnatura != null) throw new Exception("Impossibile annullare la richiesta perchè e' stata resa definitiva.");
                if (Variante.CodTipo.FindValueIn("VI", "AR")) throw new Exception("Impossibile annullare una variazione di istruttoria.");
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
                allegati_provider.DeleteCollection(allegati_provider.Find(Variante.IdVariante, null, null));

                // eliminazione delle varianti per priorità
                SiarBLL.VariantiXPrioritaCollectionProvider varianti_priorita_provider = new SiarBLL.VariantiXPrioritaCollectionProvider(VarianteProvider.DbProviderObj);
                varianti_priorita_provider.DeleteCollection(varianti_priorita_provider.Find(Variante.IdVariante, null));

                //PROGETTO INDICATORI
                SiarBLL.ProgettoIndicatoriCollectionProvider indicatori_provider = new SiarBLL.ProgettoIndicatoriCollectionProvider(VarianteProvider.DbProviderObj);
                indicatori_provider.DeleteCollection(indicatori_provider.Find(null, null, Variante.IdVariante));

                VarianteProvider.Delete(Variante);
                VarianteProvider.DbProviderObj.Commit();
                Variante = null;
                Redirect("../GestioneLavori.aspx", "Richiesta di modifica al piano degli investimenti eliminata correttamente.", false);
            }
            catch (Exception ex)
            {
                VarianteProvider.DbProviderObj.Rollback();
                ShowError(ex);
            }
        }

        protected void btnScarica_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (Variante.CodTipo != "VA") throw new Exception("Il cambio di beneficiario può essere richiesto solamente con una variante.");
                SianWebSrv.TraduzioneSianToSiar traduzione = new SianWebSrv.TraduzioneSianToSiar();
                SiarLibrary.Impresa i = impresa_provider.GetByCuaa(txtCuaaEntrante.Text);
                if (i == null) traduzione.ScaricaDatiAzienda(txtCuaaEntrante.Text, null, Operatore.Utente.CfUtente);
                i = impresa_provider.GetByCuaa(txtCuaaEntrante.Text);
                if (i == null) throw new Exception("Nessuna impresa trovata.");
                if (i.Cuaa == ucCardVarianti.Impresa.Cuaa) throw new Exception("L`impresa entrante è già beneficiaria dell`attuale domanda di aiuto.");
                hdnIdImpresaEntrante.Value = i.IdImpresa;
                btnCambiaBeneficiario.Enabled = true;
                ShowMessage("Dati aziendali scaricati correttamente, è ora possibile effettuare il cambio di beneficiario.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnCambiaBeneficiario_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (Variante.CodTipo != "VA") throw new Exception("Il cambio di beneficiario può essere richiesto solamente con una variante.");

                int id_impresa_entrante;
                SiarLibrary.Impresa ie = null;
                if (int.TryParse(hdnIdImpresaEntrante.Value, out id_impresa_entrante))
                    ie = new SiarBLL.ImpresaCollectionProvider().GetById(id_impresa_entrante);
                if (ie == null) throw new Exception("L'azienda selezionata come beneficario entrante non è valida.");
                Variante.CuaaEntrante = ie.Cuaa;
                Variante.CuaaUscente = ucCardVarianti.Impresa.Cuaa;
                VarianteProvider.AggiornaVariante(Variante, Operatore);
                ShowMessage("Cambio di beneficiario impostato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}