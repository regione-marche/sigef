using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.COVID
{
    public partial class ProgettoCovid : SiarLibrary.Web.PrivatePage
    {

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "autocertificazione_covid";
            base.OnPreInit(e);
        }

        SiarLibrary.Bando bando;
        SiarLibrary.Progetto progetto;
        SiarLibrary.Impresa impresa;
        SiarBLL.ProgettoCollectionProvider ProgettoProvider = new SiarBLL.ProgettoCollectionProvider();
        SiarBLL.CovidAutodichiarazioneCollectionProvider covid_provider = new SiarBLL.CovidAutodichiarazioneCollectionProvider();
        SiarLibrary.CovidAutodichiarazione autodic_selezionata = null;
        //SiarLibrary.DichiarazioniXDomandaCollection diccoll;
        //SiarLibrary.DichiarazioniXProgettoCollection dicXprogettoColl;


        protected void Page_Load(object sender, EventArgs e)
        {
            //int id_bando,id_progetto;
            //if (int.TryParse(Request.QueryString["idb"], out id_bando)) bando = new SiarBLL.BandoCollectionProvider().GetById(id_bando);
            //if (int.TryParse(Request.QueryString["iddom"], out id_progetto)) progetto = new SiarBLL.ProgettoCollectionProvider().GetById(id_progetto);
            if (Session["id_bando_covid"] != null) bando = new SiarBLL.BandoCollectionProvider().GetById(Session["id_bando_covid"].ToString());
            if (Session["id_progetto_covid"] != null) progetto = new SiarBLL.ProgettoCollectionProvider().GetById(Session["id_progetto_covid"].ToString());

            if (bando == null || progetto == null) Redirect("SelezionaAutocertificazione.aspx", "Per proseguire è necessario selezionare il bando desiderato.", true);
            //if (bando.IdModelloDomanda != null)
            //{
            //    diccoll = new SiarBLL.DichiarazioniXDomandaCollectionProvider().Find(null, bando.IdModelloDomanda);
            //    diccoll.Sort("Ordine, Misura, Descrizione");
            //}

            impresa = new SiarBLL.ImpresaCollectionProvider().GetById(progetto.IdImpresa);
            SiarLibrary.CovidAutodichiarazioneCollection auto_coll = covid_provider.Find(Operatore.Utente.IdUtente,
                    progetto.IdProgetto, progetto.IdBando, progetto.IdImpresa, null, null, null);
            autodic_selezionata = auto_coll[0];
            //ucFirmaDocumento.DocumentoFirmatoEvent = ProtocollaDocFirmatoEvent;

        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            SiarLibrary.CovidAutodichiarazione autodichiarazione_selezionata = new SiarBLL.CovidAutodichiarazioneCollectionProvider().Find(null, progetto.IdProgetto, progetto.IdBando, null, null, null, null)[0];

            try
            {
                covid_provider.DbProviderObj.BeginTran();

                if (autodichiarazione_selezionata == null)
                    throw new Exception("Impossibile trovare l'autodichiarazione selezionata");
                if (autodichiarazione_selezionata != null && autodichiarazione_selezionata.Definitiva)
                    throw new Exception("L'autodichiarazione è già stata resa definitiva, impossibile continuare");

                // devo eliminare il progetto, i requisiti dell'autocertificazione, il piano investimenti  e l'autocertificazione
                SiarBLL.ProgettoCollectionProvider progprovider = new SiarBLL.ProgettoCollectionProvider(covid_provider.DbProviderObj);
                SiarLibrary.Progetto p = progprovider.GetById(autodichiarazione_selezionata.IdProgetto);

                progprovider.DeleteProgetto(p, covid_provider.DbProviderObj);

                covid_provider.Delete(autodichiarazione_selezionata);
                covid_provider.DbProviderObj.Commit();

                Redirect("RichiestePredomanda.aspx", "Domanda eliminata correttamente.", false);
            }
            catch (Exception ex)
            {
                covid_provider.DbProviderObj.Rollback();
                Redirect("RichiestePredomanda.aspx", ex.Message, true);
            }
            finally
            {
                Session["id_bando_covid"] = null;
                Session["id_progetto_covid"] = null;
            }
        }


        protected override void OnPreRender(EventArgs e)
        {
            if (!autodic_selezionata.Definitiva)
            {
                btnPresenta.Enabled = true;
                btnElimina.Enabled = true;
            }
            else
            {
                btnPresenta.Enabled = false;
                btnElimina.Enabled = false;
            }

            if (Operatore.Utente.CodEnte == "%")
            {
                btnPresenta.Enabled = false;
                btnElimina.Enabled = false;
            }


            base.OnPreRender(e);
        }

        protected void btnPresenta_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (autodic_selezionata.Definitiva)
                    throw new Exception("La Pre Domanda è già stata resa definitiva!");

                autodic_selezionata.DataDefinitiva = DateTime.Now;
                autodic_selezionata.Definitiva = true;
                covid_provider.Save(autodic_selezionata);
                //ShowMessage("La Pre Domanda è stata resa definitiva!");
                Redirect("RichiestePredomanda.aspx", "La Pre Domanda è stata resa definitiva!",false);

            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}