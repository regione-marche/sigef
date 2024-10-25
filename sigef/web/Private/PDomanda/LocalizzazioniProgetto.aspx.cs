using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/* STORIA
 * Data: 2016-05-24; Stato: Creazione; Autore: 
*/

namespace web.Private.PDomanda
{
    public partial class LocalizzazioniProgetto : SiarLibrary.Web.ProgettoPage
    {        
        SiarLibrary.LocalizzazioneProgetto localizzazione_selezionata;        

        SiarBLL.LocalizzazioneProgettoCollectionProvider localizzazioneProvider = new SiarBLL.LocalizzazioneProgettoCollectionProvider();

        public bool isUpdating = false;

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (Progetto == null) Redirect("RicercaDomanda.aspx");
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
            SiarLibrary.LocalizzazioneProgettoCollection localizzazioni = localizzazioneProvider.Find( null, Progetto.IdProgetto, null, null);
            dgLocalizzazioni.ItemDataBound += new DataGridItemEventHandler(dgLocalizzazioni_ItemDataBound);
            dgLocalizzazioni.DataSource = localizzazioni;
            dgLocalizzazioni.Titolo = "<br /><br /><em>Elementi trovati: " + localizzazioni.Count.ToString() + "</em>";
            dgLocalizzazioni.DataBind();

            if (localizzazione_selezionata != null && isUpdating)
            {
                ucIndirizzo.Progetto = Progetto;

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

            }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

                if (localizzazione_selezionata == null)
                {
                    localizzazione_selezionata = new SiarLibrary.LocalizzazioneProgetto();
                    localizzazione_selezionata.IdProgetto = Progetto.IdProgetto;                    
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
                SiarBLL.LocalizzazioneProgettoCollectionProvider dbProvider = new SiarBLL.LocalizzazioneProgettoCollectionProvider();
                dbProvider.Save(localizzazione_selezionata);
                ShowMessage("Localizzazione salvata correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
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
    }
}