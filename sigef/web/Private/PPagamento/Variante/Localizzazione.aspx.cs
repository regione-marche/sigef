using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.PPagamento.Variante
{
    public partial class Localizzazione : SiarLibrary.Web.VariantePage
    {
        SiarLibrary.LocalizzazioneProgetto localizzazione_selezionata;

        SiarBLL.LocalizzazioneProgettoCollectionProvider localizzazioneProvider = new SiarBLL.LocalizzazioneProgettoCollectionProvider();

        public bool isUpdating = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            string idbando = Progetto.IdBando;

            int id_localizzazione;
            if (int.TryParse(hdnIdLocalizzazioneSelezionata.Value, out id_localizzazione))
            {
                isUpdating = true;
                localizzazione_selezionata = localizzazioneProvider.GetById(id_localizzazione);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            SiarLibrary.LocalizzazioneProgettoCollection localizzazioni = localizzazioneProvider.Find(null, Progetto.IdProgetto, null, null);
            dgLocalizzazioni.ItemDataBound += new DataGridItemEventHandler(dgLocalizzazioni_ItemDataBound);
            dgLocalizzazioni.DataSource = localizzazioni;
            dgLocalizzazioni.Titolo = "<br /><br /><em>Elementi trovati: " + localizzazioni.Count.ToString() + "</em>";
            dgLocalizzazioni.DataBind();

            ucIndirizzo.Progetto = Progetto;

            if (localizzazione_selezionata != null && isUpdating)
            {
                SiarLibrary.Comuni currComune = null;

                if (localizzazione_selezionata.IdComune != null && localizzazione_selezionata.IdComune > 0)
                {
                    currComune = new SiarBLL.ComuniCollectionProvider().GetById(localizzazione_selezionata.IdComune);
                }

                ucIndirizzo.loadLocalizzazione(localizzazione_selezionata, currComune);

                RicercaImpresa.IdImpresa = localizzazione_selezionata.IdImpresa;
            }

            base.OnPreRender(e);
        }

        void dgLocalizzazioni_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.LocalizzazioneProgetto lp = (SiarLibrary.LocalizzazioneProgetto)e.Item.DataItem;
                SiarBLL.ImpresaCollectionProvider impresaProvider = new SiarBLL.ImpresaCollectionProvider();
                e.Item.Cells[1].Text = impresaProvider.GetById(lp.IdImpresa).RagioneSociale;

                SiarBLL.ComuniCollectionProvider comuniProvider = new SiarBLL.ComuniCollectionProvider();
                e.Item.Cells[2].Text = comuniProvider.GetById(lp.IdComune).Denominazione;

                e.Item.Cells[4].Text = lp.DugDescrizione + " " + lp.Via + " " + lp.Num;

                SiarBLL.LocalizzazioneProgettoStoricoCollectionProvider local_stor_prov = new SiarBLL.LocalizzazioneProgettoStoricoCollectionProvider();
                SiarLibrary.LocalizzazioneProgettoStoricoCollection coll_storico = local_stor_prov.Find(lp.IdLocalizzazione, null, null, null);
                if(coll_storico.Count>0)
                    e.Item.Cells[5].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='Storico'  onclick=\"VisualizzaStorico(" + lp.IdLocalizzazione + ");\" style='cursor: pointer;'>";
            }
        }

        void dgLocalizzazioniStorico_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.LocalizzazioneProgettoStorico lp = (SiarLibrary.LocalizzazioneProgettoStorico)e.Item.DataItem;
                SiarBLL.ImpresaCollectionProvider impresaProvider = new SiarBLL.ImpresaCollectionProvider();
                e.Item.Cells[1].Text = impresaProvider.GetById(lp.IdImpresa).RagioneSociale;

                SiarBLL.ComuniCollectionProvider comuniProvider = new SiarBLL.ComuniCollectionProvider();
                e.Item.Cells[2].Text = comuniProvider.GetById(lp.IdComune).Denominazione;

                e.Item.Cells[3].Text = lp.DugDescrizione + " " + lp.Via + " " + lp.Num;

                SiarBLL.UtentiCollectionProvider utentiProvider = new SiarBLL.UtentiCollectionProvider();
                e.Item.Cells[4].Text = utentiProvider.GetById(lp.OperatoreModifica).Nominativo;
            }
        }


        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

                localizzazioneProvider.DbProviderObj.BeginTran();

                if (localizzazione_selezionata == null)
                {
                    localizzazione_selezionata = new SiarLibrary.LocalizzazioneProgetto();
                    localizzazione_selezionata.IdProgetto = Progetto.IdProgetto;
                }
                else
                {
                    SiarBLL.LocalizzazioneProgettoStoricoCollectionProvider local_stor_prov = new SiarBLL.LocalizzazioneProgettoStoricoCollectionProvider(localizzazioneProvider.DbProviderObj);
                    SiarLibrary.LocalizzazioneProgettoStorico storico = new SiarLibrary.LocalizzazioneProgettoStorico();
                    storico.IdLocalizzazione = localizzazione_selezionata.IdLocalizzazione;
                    storico.IdProgetto = localizzazione_selezionata.IdProgetto;
                    storico.IdImpresa = localizzazione_selezionata.IdImpresa;
                    storico.IdComune = localizzazione_selezionata.IdComune;
                    storico.Cap = localizzazione_selezionata.Cap;
                    storico.Dug = localizzazione_selezionata.Dug;
                    storico.Via = localizzazione_selezionata.Via;
                    storico.Num  = localizzazione_selezionata.Num;
                    storico.DataModifica = DateTime.Now;
                    storico.OperatoreModifica = Operatore.Utente.IdUtente;
                    storico.IdVariante = Variante.IdVariante;
                    local_stor_prov.Save(storico);

                }

                if (string.IsNullOrEmpty(ucIndirizzo.inputComuneId) || string.IsNullOrEmpty(ucIndirizzo.inputCAP) || ucIndirizzo.inputDUG == 0 || string.IsNullOrEmpty(ucIndirizzo.inputVia) || string.IsNullOrEmpty(ucIndirizzo.inputNum))
                    throw new Exception("Inserire tutti i valori della localizzazione.");

                if (RicercaImpresa.IdImpresa != null)
                    localizzazione_selezionata.IdImpresa = RicercaImpresa.IdImpresa;
                else
                    localizzazione_selezionata.IdImpresa = Progetto.IdImpresa;
                localizzazione_selezionata.IdComune = ucIndirizzo.inputComuneId;
                localizzazione_selezionata.Cap = ucIndirizzo.inputCAP;
                if (ucIndirizzo.inputDUG > 0) localizzazione_selezionata.Dug = ucIndirizzo.inputDUG.ToString();
                else localizzazione_selezionata.Dug = null;
                localizzazione_selezionata.Via = ucIndirizzo.inputVia;
                localizzazione_selezionata.Num = ucIndirizzo.inputNum;

                localizzazioneProvider.Save(localizzazione_selezionata);
                localizzazioneProvider.DbProviderObj.Commit();
                ShowMessage("Localizzazione salvata correttamente.");
            }
            catch (Exception ex) {
                localizzazioneProvider.DbProviderObj.Rollback();
                ShowError(ex); 

            }
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (localizzazione_selezionata == null || localizzazione_selezionata.IdProgetto != Progetto.IdProgetto) throw new Exception("Nessuna localizzazione selezionata, impossibile eliminare.");
                localizzazioneProvider.Delete(localizzazione_selezionata);
                ShowMessage("Localizzazione eliminata correttamente.");
                RegisterClientScriptBlock("pulisciCampi();");
                PulisciCampi();
            }
            catch (Exception ex) { ShowError(ex); }
        }
        protected void btnNuovo_Click(object sender, EventArgs e)
        {
            PulisciCampi();
        }

        public void btnSelezionaLocalizzazione_Click(object sender, EventArgs e)
        {

        }

        private void PulisciCampi()
        {
            RicercaImpresa.IdImpresa = null;
            ucIndirizzo.clearForm();
            hdnIdLocalizzazioneSelezionata.Value = string.Empty;
        }

        protected void btnApriPopup_Click(object sender, EventArgs e)
        {
            int IdLocal;
            if(int.TryParse(hdnIdLocalizzazioneSelezionataPopup.Value, out IdLocal))
            {
                SiarBLL.LocalizzazioneProgettoStoricoCollectionProvider local_stor_prov = new SiarBLL.LocalizzazioneProgettoStoricoCollectionProvider();
                SiarLibrary.LocalizzazioneProgettoStoricoCollection coll_storico = local_stor_prov.Find(IdLocal, null, null, null);
                dgLocalizzazioniStorico.ItemDataBound += new DataGridItemEventHandler(dgLocalizzazioniStorico_ItemDataBound);
                dgLocalizzazioniStorico.DataSource = coll_storico;
                dgLocalizzazioniStorico.DataBind();
                RegisterClientScriptBlock("mostraPopupTemplate('divLocalizzazioneStorico','divBKGMessaggio');");
            }
        }
        

    }
}