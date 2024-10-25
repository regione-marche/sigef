using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SiarBLL;
using SiarLibrary;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using SiarLibrary.Extensions;

namespace web.Private.Controlli
{
    public partial class RegistroRecuperi : SiarLibrary.Web.ControlliIrregolaritaPage
    {
        SiarLibrary.CodificaGenericaCollectionProvider codifica_generica_provider;
        SiarBLL.RegistroIrregolaritaCollectionProvider registro_irregolarita_provider;
        SiarBLL.RegistroRecuperoCollectionProvider registro_recupero_provider;
        SiarBLL.SanzioniRecuperoCollectionProvider sanzioni_provider;
        SiarBLL.RataCollectionProvider rata_provider;
        SiarBLL.AttiCollectionProvider atti_provider;
        SiarLibrary.RegistroIrregolarita registro_irregolarita_selezionato;
        SiarLibrary.RegistroRecupero registro_recupero_selezionato;
        SiarLibrary.Rata rata_selezionata;
        SiarLibrary.Atti decreto_selezionato;
        SiarLibrary.SanzioniRecupero sanzione_selezionata;

        const int tabInfoGenerali = 1, tabImpattoFinanziario = 2, tabAtti = 3, tabSanzioni = 4, tabStorico = 5;

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "recuperi";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            codifica_generica_provider = new CodificaGenericaCollectionProvider();
            registro_irregolarita_provider = new RegistroIrregolaritaCollectionProvider();
            registro_recupero_provider = new RegistroRecuperoCollectionProvider();

            if (Irregolarita != null)
            {
                //Se arrivo dalla ricerca selezionando un irregolarità 
                registro_irregolarita_selezionato = Irregolarita;
                hdnIdIrregolarita.Value = Irregolarita.IdIrregolarita;
            }

            if (Progetto != null)
            {
                //Se arrivo dalla ricerca volendo inserire un irregolarità 
                registro_irregolarita_selezionato = new RegistroIrregolarita();
                registro_irregolarita_selezionato.IdProgetto = Progetto.IdProgetto;

                ucZoomLoaderIrregolaritaProgetto.KeySearch += "|IdProgetto:" + Progetto.IdProgetto + ":h";
            }
            else
            {
                //Se non ho nulla rimando alla ricerca del progetto a cui associare l'irregolarità
                ShowMessage("E' necessario selezionare prima il progetto a cui associare il registro di recupero/ritiro");
                Response.Redirect("../Controlli/RicercaRecuperi.aspx");
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (IsPostBack)
            {
                string onload = "$('[id$=lstOrigineRecupero]').change(checkOrigine); $('[id$=lstOrigineRecupero]').change();  ";
                onload += "$('[id$=lstCategoriaSanzione]').change(checkCategoriaSanzione); $('[id$=lstCategoriaSanzione]').change();  ";
                onload += "$('[id$=lstTipoRecupero]').change(checkTipoRecupero); $('[id$=lstTipoRecupero]').change();  ";
                onload += "$('[id$=lstAbilitaGestioneRate]').change(checkAbilitaGestioneRate); $('[id$=lstAbilitaGestioneRate]').change();  ";
                onload += "$('[id$=lstRataPagata]').change(checkRataPagata); $('[id$=lstRataPagata]').change();  ";

                //Tabella importi
                onload += "$('[id$=txtImportoDaRecuperareQuotaUe]').change(aggiornaTotali); ";
                onload += "$('[id$=txtImportoDaRecuperareQuotaNazionale]').change(aggiornaTotali); ";
                onload += "$('[id$=txtImportoDaRecuperareContributoPrivato]').change(aggiornaTotali); ";
                onload += "$('[id$=txtImportoDetrattoQuotaUe]').change(aggiornaTotali); ";
                onload += "$('[id$=txtImportoDetrattoQuotaNazionale]').change(aggiornaTotali); ";
                onload += "$('[id$=txtImportoDetrattoContributoPrivato]').change(aggiornaTotali); ";
                onload += "$('[id$=txtImportoRecuperatoQuotaUe]').change(aggiornaTotali); ";
                onload += "$('[id$=txtImportoRecuperatoQuotaNazionale]').change(aggiornaTotali); ";
                onload += "$('[id$=txtImportoRecuperatoContributoPrivato]').change(aggiornaTotali); ";
                onload += "$('[id$=txtSaldoDaRecuperareQuotaUe]').change(aggiornaTotali); ";
                onload += "$('[id$=txtSaldoDaRecuperareQuotaNazionale]').change(aggiornaTotali); ";
                onload += "$('[id$=txtSaldoDaRecuperareContributoPrivato]').change(aggiornaTotali); ";
                onload += "$('[id$=txtImportoDaRecuperareQuotaUe]').change(); ";

                ScriptManager.RegisterStartupScript(Page, this.GetType(), "onload", onload, true);
            }

            //codifica_generica_provider = new CodificaGenericaCollectionProvider();
            //registro_irregolarita_provider = new RegistroIrregolaritaCollectionProvider();
            //registro_recupero_provider = new RegistroRecuperoCollectionProvider();
            //SiarLibrary.RegistroIrregolaritaCollection irregolarita_collection = null;

            #region Sezione domanda

            if (Progetto != null)
            {
                SiarLibrary.Bando b = new SiarBLL.BandoCollectionProvider().GetById(Progetto.IdBando);
                //irregolarita_collection = registro_irregolarita_provider.Find(null, Progetto.IdProgetto);

                Control c = LoadControl("../../CONTROLS/DatiDomanda.ascx");
                System.Type t = c.GetType();
                t.GetProperty("Progetto").SetValue(c, Progetto, null);
                t.GetProperty("Bando").SetValue(c, b, null);
                tdDomanda.Controls.Add(c);
                Session["_progetto"] = Progetto;
                Session["_bando"] = b;
            }

            #endregion



            if (Recupero != null)
            {
                hdnIdRecupero.Value = Recupero.IdRegistroRecupero;
                Recupero = null;
            }

            popolaCampiNascosti();

            //int id_recupero;
            //if (int.TryParse(hdnIdRecupero.Value, out id_recupero))
            //    registro_recupero_selezionato = registro_recupero_provider.GetById(id_recupero);

            if (registro_recupero_selezionato != null)
            {
                riempiFormRegistroRecupero();

                //var atti_collection = new SiarLibrary.AttiCollection();
                //var atti_provider = new SiarBLL.AttiCollectionProvider();
                //if(registro_recupero_selezionato.IdAttoRecupero != null)
                //    atti_collection.Add(atti_provider.GetById(registro_recupero_selezionato.IdAttoRecupero));
                //if (registro_recupero_selezionato.IdAttoRitiro != null)
                //    atti_collection.Add(atti_provider.GetById(registro_recupero_selezionato.IdAttoRitiro));
                //if (registro_recupero_selezionato.IdAttoNonRecuperabilita != null)
                //    atti_collection.Add(atti_provider.GetById(registro_recupero_selezionato.IdAttoNonRecuperabilita));
                //dgAtti.DataSource = atti_collection;
                //dgAtti.SetTitoloNrElementi();
                //dgAtti.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgAtti_ItemDataBound);
                //dgAtti.DataBind();

                //int id_irregolarita;
                //if (int.TryParse(hdnIdIrregolarita.Value, out id_irregolarita))
                //    registro_irregolarita_selezionato = registro_irregolarita_provider.GetById(id_irregolarita);

                //if (registro_irregolarita_selezionato != null)
                //{
                //    irregolarita_collection = registro_recupero_selezionato.IdRegistroIrregolarita != null
                //        ? registro_irregolarita_provider.Find(registro_recupero_selezionato.IdRegistroIrregolarita, registro_recupero_selezionato.IdProgetto)
                //        : new SiarLibrary.RegistroIrregolaritaCollection();
                //    dgIrregolarita.DataSource = irregolarita_collection;
                //    dgIrregolarita.SetTitoloNrElementi();
                //    dgIrregolarita.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgIrregolarita_ItemDataBound);
                //    dgIrregolarita.DataBind();
                //}

                //int id_rata;
                //if (int.TryParse(hdnIdRata.Value, out id_rata))
                //    divDettaglioRata.Visible = true;
                //else
                //    divDettaglioRata.Visible = false;

                //var sanzioni_provider = new SiarBLL.SanzioniRecuperoCollectionProvider();
                //var sanzioni_collection = registro_recupero_selezionato.IdRegistroRecupero != null
                //    ? sanzioni_provider.GetByRegistroRecupero(registro_recupero_selezionato.IdRegistroRecupero)
                //    : new SiarLibrary.SanzioniRecuperoCollection();
                //dgSanzioniRecuperi.DataSource = sanzioni_collection;
                //dgSanzioniRecuperi.SetTitoloNrElementi();
                //dgSanzioniRecuperi.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgSanzioniRecuperi_ItemDataBound);
                //dgSanzioniRecuperi.DataBind();

                //int id_sanzione;
                //if (int.TryParse(hdnIdSanzione.Value, out id_sanzione))
                //{
                //    sanzione_selezionata = sanzioni_provider.GetById(id_sanzione);
                //    riempiFormSanzioni();
                //    btnAggiornaSanzione.Visible = true;
                //}
            }
            else
                registro_recupero_selezionato = new RegistroRecupero();

            var recuperi_collection = registro_recupero_provider.GetByIdProgetto(Progetto.IdProgetto, false);
            dgRegistroRecuperi.DataSource = recuperi_collection;
            dgRegistroRecuperi.SetTitoloNrElementi();
            dgRegistroRecuperi.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgRegistroRecuperi_ItemDataBound);
            dgRegistroRecuperi.DataBind();

            //lnkAssociaIrregolarita.HRef = "javascript:" + ucZoomLoaderIrregolaritaProgetto.SearchFunction;

            #region Associazione combobox

            lstProcedureAvviate.DataBinding += new EventHandler(lstProcedureAvviate_DataBinding);
            lstProcedureAvviate.DataBind();
            lstTipoProcedureAvviate.DataBinding += new EventHandler(lstTipoProcedureAvviate_DataBinding);
            lstTipoProcedureAvviate.DataBind();
            lstStatoProcedure.DataBinding += new EventHandler(lstStatoProcedure_DataBinding);
            lstStatoProcedure.DataBind();
            lstCategoriaSanzione.DataBinding += new EventHandler(lstCategoriaSanzione_DataBinding);
            lstCategoriaSanzione.DataBind();
            lstTipoSanzione.DataBinding += new EventHandler(lstTipoSanzione_DataBinding);
            lstTipoSanzione.DataBind();
            lstTipoRecupero.DataBinding += new EventHandler(lstTipoRecupero_DataBinding);
            lstTipoRecupero.DataBind();
            lstOrigineRecupero.DataBinding += new EventHandler(lstOrigineRecupero_DataBinding);
            lstOrigineRecupero.DataBind();
            lstAbilitaGestioneRate.DataBinding += new EventHandler(lstBoolGenerico_DataBinding);
            lstAbilitaGestioneRate.DataBind();
            lstRataPagata.DataBinding += new EventHandler(lstBoolGenerico_DataBinding);
            lstRataPagata.DataBind();
            lstAttoDefinizione.DataBind();
            lstAttoRegistro.DataBind();

            #endregion

            switch (tabRitiriRecuperi.TabSelected)
            {
                case tabInfoGenerali:
                    divInformazioniGenerali.Visible = true;
                    riempiFormInformazioniGenerali();
                    break;
                case tabImpattoFinanziario:
                    divImpattoFinanziario.Visible = true;
                    riempiFormImpattoFinanziario();
                    break;
                case tabAtti:
                    divAttiAssociati.Visible = true;
                    riempiFormAttiAssociati();
                    break;
                case tabSanzioni:
                    divSanzioni.Visible = true;
                    riempiFormSanzioni();
                    break;
                case tabStorico:
                    divStorico.Visible = true;
                    riempiFormStorico();
                    break;
            }

            if (registro_recupero_selezionato != null && registro_recupero_selezionato.Storico != null && registro_recupero_selezionato.Storico)
                enableGestioneStorico(false);

            base.OnPreRender(e);
        }

        #region DataBinding ComboBox con codifica unica

        void lstProcedureAvviate_DataBinding(object sender, EventArgs e)
        {
            lstProcedureAvviate.Items.Clear();
            lstProcedureAvviate.Items.Add(new ListItem("", ""));
            var codifica_collection = codifica_generica_provider.FTipo(22);

            if (codifica_collection.Count > 0)
                foreach (SiarLibrary.CodificaGenerica cod in codifica_collection)
                    lstProcedureAvviate.Items.Add(new ListItem(cod.Descrizione, cod.Id));
        }

        void lstTipoProcedureAvviate_DataBinding(object sender, EventArgs e)
        {
            lstTipoProcedureAvviate.Items.Clear();
            lstTipoProcedureAvviate.Items.Add(new ListItem("", ""));
            var codifica_collection = codifica_generica_provider.FTipo(23);

            if (codifica_collection.Count > 0)
                foreach (SiarLibrary.CodificaGenerica cod in codifica_collection)
                    lstTipoProcedureAvviate.Items.Add(new ListItem(cod.Descrizione, cod.Id));
        }

        void lstStatoProcedure_DataBinding(object sender, EventArgs e)
        {
            lstStatoProcedure.Items.Clear();
            lstStatoProcedure.Items.Add(new ListItem("", ""));
            var codifica_collection = codifica_generica_provider.FTipo(24);

            if (codifica_collection.Count > 0)
                foreach (SiarLibrary.CodificaGenerica cod in codifica_collection)
                    lstStatoProcedure.Items.Add(new ListItem(cod.Descrizione, cod.Id));
        }

        void lstCategoriaSanzione_DataBinding(object sender, EventArgs e)
        {
            lstCategoriaSanzione.Items.Clear();
            lstCategoriaSanzione.Items.Add(new ListItem("", ""));
            var codifica_collection = codifica_generica_provider.FTipo(25);

            if (codifica_collection.Count > 0)
                foreach (SiarLibrary.CodificaGenerica cod in codifica_collection)
                    lstCategoriaSanzione.Items.Add(new ListItem(cod.Descrizione, cod.Id));
        }

        void lstTipoSanzione_DataBinding(object sender, EventArgs e)
        {
            var codifica_collection = codifica_generica_provider.FTipo(26);

            string json = "var jsonTipiSanzioni=" + codifica_collection.ConvertToJSonObject() + ";";
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "jsjsonTipiSanzioni", json, true);
        }

        void lstTipoRecupero_DataBinding(object sender, EventArgs e)
        {
            lstTipoRecupero.Items.Clear();
            lstTipoRecupero.Items.Add(new ListItem("", ""));
            var codifica_collection = codifica_generica_provider.FTipo(28);

            if (codifica_collection.Count > 0)
                foreach (SiarLibrary.CodificaGenerica cod in codifica_collection)
                    lstTipoRecupero.Items.Add(new ListItem(cod.Descrizione, cod.Id));
        }

        void lstOrigineRecupero_DataBinding(object sender, EventArgs e)
        {
            lstOrigineRecupero.Items.Clear();
            lstOrigineRecupero.Items.Add(new ListItem("", ""));
            var codifica_collection = codifica_generica_provider.FTipo(27);

            if (codifica_collection.Count > 0)
                foreach (SiarLibrary.CodificaGenerica cod in codifica_collection)
                    lstOrigineRecupero.Items.Add(new ListItem(cod.Descrizione, cod.Id));
        }

        void lstBoolGenerico_DataBinding(object sender, EventArgs e)
        {
            lstAbilitaGestioneRate.Items.Clear();
            lstRataPagata.Items.Clear();
            var codifica_collection = codifica_generica_provider.FTipo(11);

            if (codifica_collection.Count > 0)
                foreach (SiarLibrary.CodificaGenerica cod in codifica_collection)
                {
                    lstAbilitaGestioneRate.Items.Add(new ListItem(cod.Descrizione, cod.Flag));
                    lstRataPagata.Items.Add(new ListItem(cod.Descrizione, cod.Flag));
                }
        }

        #endregion

        #region Button event

        protected void btnSalvaRegistroRecuperi_Click(object sender, EventArgs e)
        {
            try
            {
                getHdnIdRegistroRecuperoOCrea();

                string errore = riempiCampiRegistroRecupero();
                if (errore == null || errore.Equals(""))
                {
                    new SiarBLL.RegistroRecuperoCollectionProvider().Save(registro_recupero_selezionato);
                    hdnIdRecupero.Value = registro_recupero_selezionato.IdRegistroRecupero;
                    ShowMessage("Dati salvati correttamente.");
                }
                else
                    ShowError(errore);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnEliminaRegistroRecuperi_Click(object sender, EventArgs e)
        {
            try
            {
                registro_recupero_provider = new RegistroRecuperoCollectionProvider();
                int id_recupero;
                if (int.TryParse(hdnIdRecupero.Value, out id_recupero))
                    registro_recupero_selezionato = registro_recupero_provider.GetById(id_recupero);

                if (registro_recupero_selezionato == null)
                    throw new Exception("Nessun recupero/ritiro selezionato.");

                var rate_collection_provider = new SiarBLL.RataCollectionProvider();
                var rate_collection = rate_collection_provider.GetRateByIdRegistroRecupero(registro_recupero_selezionato.IdRegistroRecupero, null);
                if (rate_collection.Count > 0)
                    rate_collection_provider.DeleteCollection(rate_collection);

                var sanzioni_collection_provider = new SiarBLL.SanzioniRecuperoCollectionProvider();
                var sanzioni_collection = sanzioni_collection_provider.GetByRegistroRecupero(registro_recupero_selezionato.IdRegistroRecupero);
                if (sanzioni_collection.Count > 0)
                    sanzioni_collection_provider.DeleteCollection(sanzioni_collection);

                registro_recupero_provider.Delete(registro_recupero_selezionato);
                hdnIdRecupero.Value = null;
                Recupero = null;
                hdnIdSanzione = null;
                ShowMessage("Recupero/ritiro eliminato");
                Response.Redirect("../Controlli/RicercaRecuperi.aspx");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnNuovoRegistroRecuperi_Click(object sender, EventArgs e)
        {
            svuotaTuttiCampi();
        }

        protected void btnSalvaInformazioniGenerali_Click(object sender, EventArgs e)
        {
            try
            {
                getHdnIdRegistroRecuperoOCrea();

                string errore = riempiCampiInformazioniGenerali();
                if (errore == null || errore.Equals(""))
                {
                    new SiarBLL.RegistroRecuperoCollectionProvider().Save(registro_recupero_selezionato);
                    hdnIdRecupero.Value = registro_recupero_selezionato.IdRegistroRecupero;
                    ShowMessage("Dati salvati correttamente.");
                }
                else
                    ShowError(errore);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnInserisciSegnatura_Click(object sender, EventArgs e)
        {
            try
            {
                getHdnIdRegistroRecuperoOCrea();

                if (registro_recupero_selezionato != null)
                {
                    if (registro_recupero_selezionato.IdRegistroRecupero == null)
                        registro_recupero_provider.Save(registro_recupero_selezionato);

                    if (registro_recupero_selezionato.DataSegnatura == null)
                        txtData.Text = "";
                    else
                        txtData.Text = registro_recupero_selezionato.DataSegnatura;
                    if (registro_recupero_selezionato.Segnatura == null)
                        txtSegnatura.Text = "";
                    else
                    {
                        txtSegnatura.Text = registro_recupero_selezionato.Segnatura;
                        imgSegnatura.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + txtSegnatura.Text + "');");
                        imgSegnatura.Style.Add("cursor", "pointer");

                    }
                    RegisterClientScriptBlock("mostraPopupTemplate('divSegnatura','divBKGMessaggio');");
                }
                else
                    ShowError("Nessun recupero/ritiro selezionato.");

            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalvaSegnatura_Click(object sender, EventArgs e)
        {
            try
            {
                getHdnIdRegistroRecuperoOCrea();

                if (registro_recupero_selezionato != null)
                {
                    if (registro_recupero_selezionato.IdRegistroRecupero == null)
                        registro_recupero_provider.Save(registro_recupero_selezionato);

                    if ((txtData.Text == "" || txtData.Text == null) && (txtSegnatura.Text == null || txtSegnatura.Text == ""))
                        throw new Exception("Inserire la data e la segnatura");

                    if (!new SiarLibrary.Protocollo().ProtocolloEsistente(txtSegnatura.Text))
                        throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.DocumentoNonValido);

                    registro_recupero_selezionato.DataSegnatura = txtData.Text;
                    registro_recupero_selezionato.Segnatura = txtSegnatura.Text;
                    registro_recupero_provider.Save(registro_recupero_selezionato);
                    RegisterClientScriptBlock("chiudiPopupTemplate();");
                    ShowMessage("La data e la segnatura sono state salvate correttamente.");
                }
                else
                    ShowError("Nessun recupero/ritiro selezionato.");
            }
            catch (Exception ex)
            {
                string messaggio = "Attenzione! " + ex.Message;
                btnInserisciSegnatura_Click(sender, e);
                RegisterClientScriptBlock("alert('" + messaggio + "');");
            }
        }

        protected void btnSalvaImpattoFinanziario_Click(object sender, EventArgs e)
        {
            try
            {
                getHdnIdRegistroRecuperoOCrea();

                string errore = riempiCampiImpattoFinanziario();
                if (errore == null || errore.Equals(""))
                {
                    new SiarBLL.RegistroRecuperoCollectionProvider().Save(registro_recupero_selezionato);
                    hdnIdRecupero.Value = registro_recupero_selezionato.IdRegistroRecupero;
                    ShowMessage("Dati salvati correttamente.");
                }
                else
                    ShowError(errore);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnInserisciSanzione_Click(object sender, EventArgs e)
        {
            try
            {
                sanzione_selezionata = new SiarLibrary.SanzioniRecupero();
                getHdnIdRegistroRecuperoOCrea();
                if (registro_recupero_selezionato.IdRegistroRecupero == null)
                {
                    riempiCampiRegistroRecupero();
                    new SiarBLL.RegistroRecuperoCollectionProvider().Save(registro_recupero_selezionato);
                }
                sanzione_selezionata.IdRegistroRecupero = registro_recupero_selezionato.IdRegistroRecupero;
                sanzione_selezionata.CfInserimento = Operatore.Utente.CfUtente;
                sanzione_selezionata.CfModifica = Operatore.Utente.CfUtente;

                string errore = riempiCampiSanzioni();
                if (errore == null || errore.Equals(""))
                {
                    new SiarBLL.SanzioniRecuperoCollectionProvider().Save(sanzione_selezionata);
                    hdnIdSanzione.Value = sanzione_selezionata.IdSanzioneRecupero;
                    ShowMessage("Sanzione salvata correttamente.");
                }
                else
                    ShowError(errore);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnAggiornaSanzione_Click(object sender, EventArgs e)
        {
            try
            {
                getHdnIdSanzioneOCrea();

                string errore = riempiCampiSanzioni();
                if (errore == null || errore.Equals(""))
                {
                    new SiarBLL.SanzioniRecuperoCollectionProvider().Save(sanzione_selezionata);
                    hdnIdSanzione.Value = sanzione_selezionata.IdSanzioneRecupero;
                    ShowMessage("Sanzione salvata correttamente.");
                }
                else
                    ShowError(errore);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnEliminaSanzione_Click(object sender, EventArgs e)
        {
            try
            {
                var sanzioni_provider = new SiarBLL.SanzioniRecuperoCollectionProvider();
                int id_sanzione;
                if (int.TryParse(hdnIdSanzione.Value, out id_sanzione))
                    sanzione_selezionata = sanzioni_provider.GetById(id_sanzione);

                if (sanzione_selezionata == null)
                    throw new Exception("Nessuna sanzione selezionata");

                sanzioni_provider.Delete(sanzione_selezionata);
                sanzione_selezionata = null;
                hdnIdSanzione.Value = null;
                ShowMessage("Sanzione eliminata correttamente");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalvaProcedureSanzioni_Click(object sender, EventArgs e)
        {
            try
            {
                getHdnIdRegistroRecuperoOCrea();

                string errore = riempiCampiSanzioni();
                if (errore == null || errore.Equals(""))
                {
                    new SiarBLL.RegistroRecuperoCollectionProvider().Save(registro_recupero_selezionato);
                    hdnIdRecupero.Value = registro_recupero_selezionato.IdRegistroRecupero;
                    ShowMessage("Dati salvati correttamente.");
                }
                else
                    ShowError(errore);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            try
            {
                int id_recupero;
                if (int.TryParse(hdnIdRecupero.Value, out id_recupero))
                {
                    registro_recupero_selezionato = new SiarBLL.RegistroRecuperoCollectionProvider().GetById(id_recupero);
                    hdnIdIrregolarita.Value = null;
                    hdnIdAtto.Value = null;
                    hdnIdRata.Value = null;
                    hdnIdSanzione.Value = null;
                    //riempiFormRegistroRecupero();
                    tabRitiriRecuperi.TabSelected = 0;
                }
                else
                    ShowError("Nessun registro recupero/ritiro selezionato");
            }
            catch (Exception ex) { ShowError(ex.ToString()); }
        }

        protected void btnCaricaSanzione_Click(object sender, EventArgs e)
        {
            try
            {
                popolaCampiNascosti();
                riempiFormSanzioni();
            }
            catch (Exception ex) { ShowError(ex.ToString()); }
        }

        protected void btnCaricaRata_Click(object sender, EventArgs e)
        {
            try
            {
                popolaCampiNascosti();
                riempiFormRata();
            }
            catch (Exception ex) { ShowError(ex.ToString()); }
        }

        protected void btnCaricaAtto_Click(object sender, EventArgs e)
        {
            try
            {
                //int id_decreto;
                //if (int.TryParse(hdnIdAtto.Value, out id_decreto))
                //    decreto_selezionato = new SiarBLL.AttiCollectionProvider().GetById(id_decreto);

                //if (decreto_selezionato == null) throw new Exception("Per proseguire è necessario specificare l'atto di riferimento.");
                popolaCampiNascosti();
                riempiFormAttiAssociati();
            }
            catch (Exception ex) { ShowError(ex.ToString()); }
        }

        protected void btnCaricaIrregolarita_Click(object sender, EventArgs e)
        {
            try
            {
                int id_irregolarita;
                if (int.TryParse(ucZoomLoaderIrregolaritaProgetto.SelectedValue, out id_irregolarita))
                {

                    int id_recupero;
                    if (int.TryParse(hdnIdRecupero.Value, out id_recupero))
                    {
                        var irregolarita = new SiarBLL.RegistroIrregolaritaCollectionProvider().GetById(id_irregolarita);
                        var recupero_provider = new SiarBLL.RegistroRecuperoCollectionProvider();
                        SiarLibrary.RegistroRecupero recupero = recupero_provider.GetById(id_recupero);
                        recupero.IdRegistroIrregolarita = irregolarita.IdIrregolarita;
                        recupero_provider.Save(recupero);
                        hdnIdIrregolarita.Value = irregolarita.IdIrregolarita;
                        ucZoomLoaderIrregolaritaProgetto.UnselectItem();
                        ShowMessage("Registro irregolarità associato correttamente.");
                    }
                    else
                        ShowError("Registro recupero/ritiro non selezionato: provare a salvarlo e riprovare.");
                }
                else
                    ShowError("Registro irregolarita non selezionata.");
            }
            catch (Exception ex) { ShowError(ex.ToString()); }
        }

        protected void btnEscludiIrregolarita_Click(object sender, EventArgs e)
        {
            var reg_rec_provedir = new SiarBLL.RegistroRecuperoCollectionProvider();
            int id_recupero;
            if (int.TryParse(hdnIdRecupero.Value, out id_recupero))
            {
                var recupero = reg_rec_provedir.GetById(id_recupero);
                if (recupero != null && recupero.Storico == false)
                {
                    int id_irregolarita;
                    if (int.TryParse(hdnIdIrregolarita.Value, out id_irregolarita))
                    {
                        recupero.IdRegistroIrregolarita = null;
                        hdnIdIrregolarita.Value = null;
                        Irregolarita = null;
                        registro_irregolarita_selezionato = null;
                        reg_rec_provedir.Save(recupero);
                        ShowMessage("Registro irregolarità escluso correttamente.");
                    }
                    else
                        ShowError("Nessun registro irregolarità associato.");
                }
                else
                    ShowError("Nessun è possibile modificare uno storico di registro.");
            }
            else
                ShowError("Nessun registro recupero selezionato.");
        }

        protected void btnGeneraGestioneRate_Click(object sender, EventArgs e)
        {
            try
            {
                string errore = "";
                if (txtNumeroRate.Text == null || txtNumeroRate.Text.Equals(""))
                    errore += "Numero di rate richieste non inserito.<br />";
                if (txtDataInizioRate.Text == null || txtDataInizioRate.Text.Equals(""))
                    errore += "Data inizio rate richieste non inserita.<br />";
                if (txtImportoRataRichiesta.Text == null || txtImportoRataRichiesta.Text.Equals(""))
                    errore += "Importo rata richiesta non inserita.<br />";
                if (txtIntervalloRate.Text == null || txtIntervalloRate.Text.Equals(""))
                    errore += "Intervallo di mesi non inserito";

                if (!errore.Equals(""))
                    ShowError(errore);
                else
                {
                    try
                    {
                        var rate_collection_provider = new SiarBLL.RataCollectionProvider();
                        getHdnIdRegistroRecuperoOCrea();
                        if (registro_recupero_selezionato.IdRegistroRecupero == null)
                        {
                            riempiCampiRegistroRecupero();
                            new SiarBLL.RegistroRecuperoCollectionProvider().Save(registro_recupero_selezionato);
                            Recupero = registro_recupero_selezionato;
                            hdnIdRecupero.Value = registro_recupero_selezionato.IdRegistroRecupero;
                        }

                        var rate_vecchie_collection = rate_collection_provider.GetRateByIdRegistroRecupero(registro_recupero_selezionato.IdRegistroRecupero, null);
                        if (rate_vecchie_collection.Count > 0)
                            rate_collection_provider.DeleteCollection(rate_vecchie_collection);

                        int intervalloRate = Convert.ToInt16(txtIntervalloRate.Text);
                        DateTime dataInizioRate = Convert.ToDateTime(txtDataInizioRate.Text);
                        decimal importoRate = Convert.ToDecimal(txtImportoRataRichiesta.Text);
                        int numeroRate = Convert.ToInt16(txtNumeroRate.Text);

                        for (int i = 0; i < numeroRate; i++)
                        {
                            var rata_nuova = new SiarLibrary.Rata();
                            rata_nuova.CfInserimento = Operatore.Utente.CfUtente;
                            rata_nuova.IdRegistroRecupero = registro_recupero_selezionato.IdRegistroRecupero;
                            rata_nuova.IdTipoRata = 1; //Tipo recupero
                            rata_nuova.ImportoRata = importoRate;
                            rata_nuova.Pagata = false;
                            rata_nuova.DataRata = dataInizioRate.AddMonths(intervalloRate * i);
                            rate_collection_provider.Save(rata_nuova);
                        }

                        registro_recupero_selezionato.GestioneRate = true;
                        registro_recupero_selezionato.IntervalloRateMesi = intervalloRate;
                        registro_recupero_selezionato.DataInizioRate = dataInizioRate;
                        registro_recupero_selezionato.ImportoRata = importoRate;
                        registro_recupero_selezionato.NumeroRate = numeroRate;
                        new SiarBLL.RegistroRecuperoCollectionProvider().Save(registro_recupero_selezionato);

                        ShowMessage("Piano rate creato correttamente.");
                    }
                    catch (Exception ex) { ShowError(ex.ToString()); }
                }
            }
            catch (Exception ex) { ShowError(ex.ToString()); }
        }

        protected void btnSalvaRata_Click(object sender, EventArgs e)
        {
            try
            {
                int id_rata;
                if (int.TryParse(hdnIdRata.Value, out id_rata))
                {
                    var rata_collection_provider = new SiarBLL.RataCollectionProvider();
                    var rata_selezionata = rata_collection_provider.GetById(id_rata);
                    rata_selezionata.CfModifica = Operatore.Utente.CfUtente;
                    rata_selezionata.DataRata = txtDataRata.Text;
                    rata_selezionata.DataScadenza = txtDataScadenzaRata.Text;
                    rata_selezionata.ImportoRata = txtImportoRata.Text;
                    if (lstRataPagata.SelectedValue.Equals("1"))
                    {
                        rata_selezionata.Pagata = true;
                        rata_selezionata.DataPagamento = txtDataPagamentoRata.Text;
                    }
                    else
                    {
                        rata_selezionata.Pagata = false;
                        rata_selezionata.DataPagamento = null;
                    }

                    rata_collection_provider.Save(rata_selezionata);
                }
                else
                    ShowError("Nessuna rata selezionata.");
            }
            catch (Exception ex) { ShowError(ex.ToString()); }
        }

        protected void btnCercaDecreto_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

                int numero;
                int.TryParse(txtAttoNumero.Text, out numero);
                DateTime data;
                DateTime.TryParse(txtAttoData.Text, out data);
                string registro = lstAttoRegistro.SelectedValue;

                if (!string.IsNullOrEmpty(lstAttoRegistro.SelectedValue) && lstAttoRegistro.SelectedValue.IndexOf("|") > 0)
                    registro = lstAttoRegistro.SelectedValue.Substring(0, lstAttoRegistro.SelectedValue.IndexOf("|"));

                // controllo che l'atto sia registrato su db, altrimenti lo importo
                var atti_provider = new SiarBLL.AttiCollectionProvider();
                SiarLibrary.AttiCollection atti_trovati = atti_provider.Find(numero, data, lstAttoDefinizione.SelectedValue, registro);

                if (atti_trovati.Count == 0)
                {
                    atti_trovati = atti_provider.ImportaAtto(numero, data, lstAttoDefinizione.SelectedValue, lstAttoRegistro.SelectedValue);
                    if (atti_trovati.Count > 0)
                        atti_provider.Save(atti_trovati[0]);
                }

                if (atti_trovati.Count > 0)
                    hdnIdAtto.Value = atti_trovati[0].IdAtto;
                else ShowError("La ricerca non ha prodotto nessun risultato.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnAssociaDecretoRecupero_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

                int id_decreto = getHdnIdAtto();
                getHdnIdRegistroRecuperoOCrea();

                string messaggio;
                if (registro_recupero_selezionato.IdAttoRecupero != null)
                    messaggio = "Decreto aggiornato correttamente";
                else
                    messaggio = "Decreto associato correttamente";

                registro_recupero_selezionato.IdAttoRecupero = id_decreto;
                new SiarBLL.RegistroRecuperoCollectionProvider().Save(registro_recupero_selezionato);
                ShowMessage(messaggio);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnAssociaDecretoRitiro_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

                int id_decreto = getHdnIdAtto();
                getHdnIdRegistroRecuperoOCrea();

                string messaggio;
                if (registro_recupero_selezionato.IdAttoRitiro != null)
                    messaggio = "Decreto aggiornato correttamente";
                else
                    messaggio = "Decreto associato correttamente";

                registro_recupero_selezionato.IdAttoRitiro = id_decreto;
                new SiarBLL.RegistroRecuperoCollectionProvider().Save(registro_recupero_selezionato);
                ShowMessage(messaggio);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnAssociaDecretoNonRecuperabilita_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

                int id_decreto = getHdnIdAtto();
                getHdnIdRegistroRecuperoOCrea();

                string messaggio;
                if (registro_recupero_selezionato.IdAttoNonRecuperabilita != null)
                    messaggio = "Decreto aggiornato correttamente";
                else
                    messaggio = "Decreto associato correttamente";

                registro_recupero_selezionato.IdAttoNonRecuperabilita = id_decreto;
                new SiarBLL.RegistroRecuperoCollectionProvider().Save(registro_recupero_selezionato);
                ShowMessage(messaggio);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        #endregion

        protected void popolaCampiNascosti()
        {
            try
            {
                codifica_generica_provider = new CodificaGenericaCollectionProvider();
                registro_recupero_provider = new RegistroRecuperoCollectionProvider();
                registro_irregolarita_provider = new RegistroIrregolaritaCollectionProvider();
                sanzioni_provider = new SanzioniRecuperoCollectionProvider();
                rata_provider = new RataCollectionProvider();
                atti_provider = new AttiCollectionProvider();

                int id_recupero;
                if (int.TryParse(hdnIdRecupero.Value, out id_recupero))
                    registro_recupero_selezionato = registro_recupero_provider.GetById(id_recupero);

                int id_irregolarita;
                if (int.TryParse(hdnIdIrregolarita.Value, out id_irregolarita))
                    registro_irregolarita_selezionato = registro_irregolarita_provider.GetById(id_irregolarita);

                int id_rata;
                if (int.TryParse(hdnIdRata.Value, out id_rata))
                    rata_selezionata = rata_provider.GetById(id_rata);

                int id_sanzione;
                if (int.TryParse(hdnIdSanzione.Value, out id_sanzione))
                    sanzione_selezionata = sanzioni_provider.GetById(id_sanzione);

                // evento ricerca
                int id_decreto;
                if (decreto_selezionato == null && int.TryParse(hdnIdAtto.Value, out id_decreto))
                    decreto_selezionato = atti_provider.GetById(id_decreto);
            }
            catch (Exception ex) { ShowError(ex.ToString()); }
        }

        protected string salvaTipoPrecedente()
        {
            string errore = "";

            try
            {
                var registro_recupero_provider = new SiarBLL.RegistroRecuperoCollectionProvider();
                var registro_recupero_copia = registro_recupero_provider.DeepCopy(registro_recupero_selezionato);
                registro_recupero_copia.Storico = true;
                registro_recupero_provider.Save(registro_recupero_copia);
                registro_recupero_selezionato.IdStoricoRecuperoPrecedente = registro_recupero_copia.IdRegistroRecupero;
                registro_recupero_selezionato.Storico = 0;
            }
            catch (Exception ex) { errore = ex.ToString(); }

            return errore;
        }

        protected string riempiCampiRegistroRecupero()
        {
            string errore = "";
            errore += riempiCampiInformazioniGenerali();
            errore += riempiCampiSanzioni();
            return errore;
        }

        protected void riempiFormRegistroRecupero()
        {
            riempiFormInformazioniGenerali();
            riempiFormSanzioni();
        }

        private void svuotaTuttiCampi()
        {
            Recupero = null;
            Irregolarita = null;
            hdnIdIrregolarita.Value = null;
            hdnIdRecupero.Value = null;
            hdnIdOrigine.Value = null;

            registro_irregolarita_selezionato = new SiarLibrary.RegistroIrregolarita();
            registro_recupero_selezionato = new SiarLibrary.RegistroRecupero();
            riempiFormRegistroRecupero();
        }

        protected string riempiCampiInformazioniGenerali()
        {
            string errore = "";

            if ((registro_recupero_selezionato.IdTipoRecupero == null ||
                (registro_recupero_selezionato.IdTipoRecupero != null && !registro_recupero_selezionato.IdTipoRecupero.Equals("28001")))
                && lstTipoRecupero.SelectedValue != null && lstTipoRecupero.SelectedValue.Equals("28001"))
            {
                errore += salvaTipoPrecedente();
                if (errore != null && !errore.Equals(""))
                    throw new Exception("Errore nel salvataggio durante il cambio di stato: " + errore + ".");
            }

            registro_recupero_selezionato.IdTipoRecupero = lstTipoRecupero.SelectedValue;
            registro_recupero_selezionato.DataAvvio = txtDataAvvio.Text;
            registro_recupero_selezionato.SoggettoRevocaFinanziamento = txtSoggettoRevocaFinanziamento.Text;
            registro_recupero_selezionato.DataRegistrazioneRitiro = txtDataRegistrazioneRitiro.Text;
            registro_recupero_selezionato.DataCertificazioneRecupero = txtDataCertificazioneRecupero.Text;
            registro_recupero_selezionato.DataCertificazioneRitiro = txtDataCertificazioneRitiro.Text;
            registro_recupero_selezionato.DataCertificazioneNonRecuperabilita = txtDataCertificazioneNonRecuperabilita.Text;
            registro_recupero_selezionato.Recuperabile = chkRecuperabile.Checked;
            registro_recupero_selezionato.IdOrigineRecupero = lstOrigineRecupero.SelectedValue;
            //if (lstOrigineRecupero.SelectedValue != null && lstOrigineRecupero.SelectedValue.Equals(27000) && Irregolarita != null)
            //    registro_recupero_selezionato.IdRegistroIrregolarita = Irregolarita.IdIrregolarita;
            //else
            //    registro_recupero_selezionato.IdRegistroIrregolarita = null;
            registro_recupero_selezionato.DataProbabileConclusione = txtDataProbabileConclusione.Text;
            registro_recupero_selezionato.DataConclusione = txtDataConclusione.Text;

            return errore;
        }

        protected void riempiFormInformazioniGenerali()
        {
            txtDataAvvio.Text = registro_recupero_selezionato.DataAvvio;
            lstTipoRecupero.SelectedValue = registro_recupero_selezionato.IdTipoRecupero;
            txtSoggettoRevocaFinanziamento.Text = registro_recupero_selezionato.SoggettoRevocaFinanziamento;
            txtDataRegistrazioneRitiro.Text = registro_recupero_selezionato.DataRegistrazioneRitiro;
            txtDataCertificazioneRecupero.Text = registro_recupero_selezionato.DataCertificazioneRecupero;
            txtDataCertificazioneRitiro.Text = registro_recupero_selezionato.DataCertificazioneRitiro;
            txtDataCertificazioneNonRecuperabilita.Text = registro_recupero_selezionato.DataCertificazioneNonRecuperabilita;
            chkRecuperabile.Checked = checkBoolValue(registro_recupero_selezionato.Recuperabile, true);

            lstOrigineRecupero.SelectedValue = registro_recupero_selezionato.IdOrigineRecupero;
            if (registro_recupero_selezionato.IdRegistroIrregolarita != null
                && registro_recupero_selezionato.IdOrigineRecupero != null
                && registro_recupero_selezionato.IdOrigineRecupero.Equals(27000))
            {
                if (registro_irregolarita_selezionato == null && registro_recupero_selezionato.IdRegistroIrregolarita != null)
                    registro_irregolarita_selezionato = registro_irregolarita_provider.GetById(registro_recupero_selezionato.IdRegistroIrregolarita);

                if (registro_irregolarita_selezionato != null)
                {
                    var irregolarita_collection = registro_recupero_selezionato.IdRegistroIrregolarita != null
                        ? registro_irregolarita_provider.Find(registro_recupero_selezionato.IdRegistroIrregolarita, registro_recupero_selezionato.IdProgetto, null)
                        : new SiarLibrary.RegistroIrregolaritaCollection();
                    dgIrregolarita.DataSource = irregolarita_collection;
                    dgIrregolarita.SetTitoloNrElementi();
                    dgIrregolarita.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgIrregolarita_ItemDataBound);
                    dgIrregolarita.DataBind();
                }
            }

            txtDataProbabileConclusione.Text = registro_recupero_selezionato.DataProbabileConclusione;
            txtDataConclusione.Text = registro_recupero_selezionato.DataConclusione;

            lnkAssociaIrregolarita.HRef = "javascript:" + ucZoomLoaderIrregolaritaProgetto.SearchFunction;

            if (registro_recupero_selezionato != null && registro_recupero_selezionato.Segnatura != null)
            {
                txtSegnaturaVerbale.Text = registro_recupero_selezionato.Segnatura;
                imgSegnaturaVerbale.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + registro_recupero_selezionato.Segnatura + "');");
            }
            else
                txtSegnaturaVerbale.Text = null;
        }

        protected string riempiCampiImpattoFinanziario()
        {
            string errore = "";

            if ((txtImportoDaRecuperareQuotaUe.Text != null && !txtImportoDaRecuperareQuotaUe.Text.Equals(""))
                || (txtImportoDaRecuperareQuotaNazionale.Text != null && !txtImportoDaRecuperareQuotaNazionale.Text.Equals(""))
                || (txtImportoDaRecuperareContributoPubblico.Text != null && !txtImportoDaRecuperareContributoPubblico.Text.Equals(""))
                || (txtImportoDaRecuperareContributoPrivato.Text != null && !txtImportoDaRecuperareContributoPrivato.Text.Equals(""))
                || (txtImportoDaRecuperareTotale.Text != null && !txtImportoDaRecuperareTotale.Text.Equals("")))
            {
                if (((Convert.ToDouble(txtImportoDaRecuperareQuotaUe.Text) + Convert.ToDouble(txtImportoDaRecuperareQuotaNazionale.Text))
                    != (Convert.ToDouble(txtImportoDaRecuperareContributoPubblico.Text)))
                    || ((Convert.ToDouble(txtImportoDaRecuperareContributoPubblico.Text) + Convert.ToDouble(txtImportoDaRecuperareContributoPrivato.Text))
                        != Convert.ToDouble(txtImportoDaRecuperareTotale.Text)))
                    errore += "Somma importo da recuperare sbagliata.<br />";
                else
                {
                    registro_recupero_selezionato.ImportoDaRecuperareUe = txtImportoDaRecuperareQuotaUe.Text;
                    registro_recupero_selezionato.ImportoDaRecuperareNazionale = txtImportoDaRecuperareQuotaNazionale.Text;
                    registro_recupero_selezionato.ImportoDaRecuperarePubblico = txtImportoDaRecuperareContributoPubblico.Text;
                    registro_recupero_selezionato.ImportoDaRecuperarePrivato = txtImportoDaRecuperareContributoPrivato.Text;
                    registro_recupero_selezionato.ImportoDaRecuperareTotale = txtImportoDaRecuperareTotale.Text;
                }
            }

            if ((txtImportoDetrattoQuotaUe.Text != null && !txtImportoDetrattoQuotaUe.Text.Equals(""))
                || (txtImportoDetrattoQuotaNazionale.Text != null && !txtImportoDetrattoQuotaNazionale.Text.Equals(""))
                || (txtImportoDetrattoContributoPubblico.Text != null && !txtImportoDetrattoContributoPubblico.Text.Equals(""))
                || (txtImportoDetrattoContributoPrivato.Text != null && !txtImportoDetrattoContributoPrivato.Text.Equals(""))
                || (txtImportoDetrattoTotale.Text != null && !txtImportoDetrattoTotale.Text.Equals("")))
            {
                if (((Convert.ToDouble(txtImportoDetrattoQuotaUe.Text) + Convert.ToDouble(txtImportoDetrattoQuotaNazionale.Text))
                    != (Convert.ToDouble(txtImportoDetrattoContributoPubblico.Text)))
                    || ((Convert.ToDouble(txtImportoDetrattoContributoPubblico.Text) + Convert.ToDouble(txtImportoDetrattoContributoPrivato.Text))
                        != Convert.ToDouble(txtImportoDetrattoTotale.Text)))
                    errore += "Somma importo detratto sbagliata.<br />";
                else
                {
                    registro_recupero_selezionato.ImportoDetrattoUe = txtImportoDetrattoQuotaUe.Text;
                    registro_recupero_selezionato.ImportoDetrattoNazionale = txtImportoDetrattoQuotaNazionale.Text;
                    registro_recupero_selezionato.ImportoDetrattoPubblico = txtImportoDetrattoContributoPubblico.Text;
                    registro_recupero_selezionato.ImportoDetrattoPrivato = txtImportoDetrattoContributoPrivato.Text;
                    registro_recupero_selezionato.ImportoDetrattoTotale = txtImportoDetrattoTotale.Text;
                }
            }

            if ((txtImportoRecuperatoQuotaUe.Text != null && !txtImportoRecuperatoQuotaUe.Text.Equals(""))
                || (txtImportoRecuperatoQuotaNazionale.Text != null && !txtImportoRecuperatoQuotaNazionale.Text.Equals(""))
                || (txtImportoRecuperatoContributoPubblico.Text != null && !txtImportoRecuperatoContributoPubblico.Text.Equals(""))
                || (txtImportoRecuperatoContributoPrivato.Text != null && !txtImportoRecuperatoContributoPrivato.Text.Equals(""))
                || (txtImportoRecuperatoTotale.Text != null && !txtImportoRecuperatoTotale.Text.Equals("")))
            {
                if (((Convert.ToDouble(txtImportoRecuperatoQuotaUe.Text) + Convert.ToDouble(txtImportoRecuperatoQuotaNazionale.Text))
                    != (Convert.ToDouble(txtImportoRecuperatoContributoPubblico.Text)))
                    || ((Convert.ToDouble(txtImportoRecuperatoContributoPubblico.Text) + Convert.ToDouble(txtImportoRecuperatoContributoPrivato.Text))
                        != Convert.ToDouble(txtImportoRecuperatoTotale.Text)))
                    errore += "Somma importo recuperato sbagliata.<br />";
                else
                {
                    registro_recupero_selezionato.ImportoRecuperatoUe = txtImportoRecuperatoQuotaUe.Text;
                    registro_recupero_selezionato.ImportoRecuperatoNazionale = txtImportoRecuperatoQuotaNazionale.Text;
                    registro_recupero_selezionato.ImportoRecuperatoPubblico = txtImportoRecuperatoContributoPubblico.Text;
                    registro_recupero_selezionato.ImportoRecuperatoPrivato = txtImportoRecuperatoContributoPrivato.Text;
                    registro_recupero_selezionato.ImportoRecuperatoTotale = txtImportoRecuperatoTotale.Text;
                }
            }

            if ((txtSaldoDaRecuperareQuotaUe.Text != null && !txtSaldoDaRecuperareQuotaUe.Text.Equals(""))
                || (txtSaldoDaRecuperareQuotaNazionale.Text != null && !txtSaldoDaRecuperareQuotaNazionale.Text.Equals(""))
                || (txtSaldoDaRecuperareContributoPubblico.Text != null && !txtSaldoDaRecuperareContributoPubblico.Text.Equals(""))
                || (txtSaldoDaRecuperareContributoPrivato.Text != null && !txtSaldoDaRecuperareContributoPrivato.Text.Equals(""))
                || (txtSaldoDaRecuperareTotale.Text != null && !txtSaldoDaRecuperareTotale.Text.Equals("")))
            {
                if (((Convert.ToDouble(txtSaldoDaRecuperareQuotaUe.Text) + Convert.ToDouble(txtSaldoDaRecuperareQuotaNazionale.Text))
                    != (Convert.ToDouble(txtSaldoDaRecuperareContributoPubblico.Text)))
                    || ((Convert.ToDouble(txtSaldoDaRecuperareContributoPubblico.Text) + Convert.ToDouble(txtSaldoDaRecuperareContributoPrivato.Text))
                        != Convert.ToDouble(txtSaldoDaRecuperareTotale.Text)))
                    errore += "Somma saldo da recuperare sbagliata.<br />";
                else
                {
                    registro_recupero_selezionato.SaldoDaRecuperareUe = txtSaldoDaRecuperareQuotaUe.Text;
                    registro_recupero_selezionato.SaldoDaRecuperareNazionale = txtSaldoDaRecuperareQuotaNazionale.Text;
                    registro_recupero_selezionato.SaldoDaRecuperarePubblico = txtSaldoDaRecuperareContributoPubblico.Text;
                    registro_recupero_selezionato.SaldoDaRecuperarePrivato = txtSaldoDaRecuperareContributoPrivato.Text;
                    registro_recupero_selezionato.SaldoDaRecuperareTotale = txtSaldoDaRecuperareTotale.Text;
                }
            }

            registro_recupero_selezionato.ImportoVersatoUe = txtImportoVersatoQuotaUe.Text;
            registro_recupero_selezionato.ImportoRitenutoStato = txtImportoRitenutoStato.Text;
            registro_recupero_selezionato.ImportoInteressiLegali = txtImportoInteressiLegali.Text;
            registro_recupero_selezionato.ImportoInteressiMora = txtImportoInteressiMora.Text;
            registro_recupero_selezionato.ImportoGestionePratica = txtImportoGestionePratica.Text;

            registro_recupero_selezionato.GestioneRate = lstAbilitaGestioneRate.SelectedValue;
            if (lstAbilitaGestioneRate.SelectedValue != null && lstAbilitaGestioneRate.SelectedValue.Equals("1"))
            {
                registro_recupero_selezionato.NumeroRate = txtNumeroRate.Text;
                registro_recupero_selezionato.DataInizioRate = txtDataInizioRate.Text;
                registro_recupero_selezionato.ImportoRata = txtImportoRataRichiesta.Text;
                registro_recupero_selezionato.IntervalloRateMesi = txtIntervalloRate.Text;
                //DEVO SALVARE LE RATE GENERATE?
            }
            else
            {
                registro_recupero_selezionato.NumeroRate = null;
                registro_recupero_selezionato.DataInizioRate = null;
                registro_recupero_selezionato.ImportoRata = null;
                registro_recupero_selezionato.IntervalloRateMesi = null;
                //DEVO ELIMINARE LE RATE GENERATE?
            }

            return errore;
        }

        protected void riempiFormImpattoFinanziario()
        {
            txtImportoDaRecuperareQuotaUe.Text = registro_recupero_selezionato.ImportoDaRecuperareUe;
            txtImportoDaRecuperareQuotaNazionale.Text = registro_recupero_selezionato.ImportoDaRecuperareNazionale;
            txtImportoDaRecuperareContributoPubblico.Text = registro_recupero_selezionato.ImportoDaRecuperarePubblico;
            txtImportoDaRecuperareContributoPrivato.Text = registro_recupero_selezionato.ImportoDaRecuperarePrivato;
            txtImportoDaRecuperareTotale.Text = registro_recupero_selezionato.ImportoDaRecuperareTotale;

            txtImportoDetrattoQuotaUe.Text = registro_recupero_selezionato.ImportoDetrattoUe;
            txtImportoDetrattoQuotaNazionale.Text = registro_recupero_selezionato.ImportoDetrattoNazionale;
            txtImportoDetrattoContributoPubblico.Text = registro_recupero_selezionato.ImportoDetrattoPubblico;
            txtImportoDetrattoContributoPrivato.Text = registro_recupero_selezionato.ImportoDetrattoPrivato;
            txtImportoDetrattoTotale.Text = registro_recupero_selezionato.ImportoDetrattoTotale;

            txtImportoRecuperatoQuotaUe.Text = registro_recupero_selezionato.ImportoRecuperatoUe;
            txtImportoRecuperatoQuotaNazionale.Text = registro_recupero_selezionato.ImportoRecuperatoNazionale;
            txtImportoRecuperatoContributoPubblico.Text = registro_recupero_selezionato.ImportoRecuperatoPubblico;
            txtImportoRecuperatoContributoPrivato.Text = registro_recupero_selezionato.ImportoRecuperatoPrivato;
            txtImportoRecuperatoTotale.Text = registro_recupero_selezionato.ImportoRecuperatoTotale;

            txtSaldoDaRecuperareQuotaUe.Text = registro_recupero_selezionato.SaldoDaRecuperareUe;
            txtSaldoDaRecuperareQuotaNazionale.Text = registro_recupero_selezionato.SaldoDaRecuperareNazionale;
            txtSaldoDaRecuperareContributoPubblico.Text = registro_recupero_selezionato.SaldoDaRecuperarePubblico;
            txtSaldoDaRecuperareContributoPrivato.Text = registro_recupero_selezionato.SaldoDaRecuperarePrivato;
            txtSaldoDaRecuperareTotale.Text = registro_recupero_selezionato.SaldoDaRecuperareTotale;

            txtImportoVersatoQuotaUe.Text = registro_recupero_selezionato.ImportoVersatoUe;
            txtImportoRitenutoStato.Text = registro_recupero_selezionato.ImportoRitenutoStato;
            txtImportoInteressiLegali.Text = registro_recupero_selezionato.ImportoInteressiLegali;
            txtImportoInteressiMora.Text = registro_recupero_selezionato.ImportoInteressiMora;
            txtImportoGestionePratica.Text = registro_recupero_selezionato.ImportoGestionePratica;

            lstAbilitaGestioneRate.SelectedValue = checkBoolLst(registro_recupero_selezionato.GestioneRate);
            txtNumeroRate.Text = registro_recupero_selezionato.NumeroRate;
            txtDataInizioRate.Text = registro_recupero_selezionato.DataInizioRate;
            txtImportoRataRichiesta.Text = registro_recupero_selezionato.ImportoRata;
            txtIntervalloRate.Text = registro_recupero_selezionato.IntervalloRateMesi;

            var rate_collection = new SiarBLL.RataCollectionProvider().GetRateByIdRegistroRecupero(registro_recupero_selezionato.IdRegistroRecupero, null);
            dgRateRecupero.DataSource = rate_collection;
            dgRateRecupero.SetTitoloNrElementi();
            dgRateRecupero.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgRateRecupero_ItemDataBound);
            dgRateRecupero.DataBind();

            if (rata_selezionata != null)
            {
                divDettaglioRata.Visible = true;
                riempiFormRata();
            }
            else
            {
                divDettaglioRata.Visible = false;
                lstRataPagata.SelectedValue = "0";
            }
            //int id_rata;
            //if (int.TryParse(hdnIdRata.Value, out id_rata))
            //    riempiFormRata();
            //else
            //    lstRataPagata.SelectedValue = "0";
        }

        protected void riempiFormAttiAssociati()
        {
            var atti_collection = new SiarLibrary.AttiCollection();
            var atti_provider = new SiarBLL.AttiCollectionProvider();

            if (registro_recupero_selezionato.IdAttoRecupero != null)
                atti_collection.Add(atti_provider.GetById(registro_recupero_selezionato.IdAttoRecupero));
            if (registro_recupero_selezionato.IdAttoRitiro != null)
                atti_collection.Add(atti_provider.GetById(registro_recupero_selezionato.IdAttoRitiro));
            if (registro_recupero_selezionato.IdAttoNonRecuperabilita != null)
                atti_collection.Add(atti_provider.GetById(registro_recupero_selezionato.IdAttoNonRecuperabilita));

            dgAtti.DataSource = atti_collection;
            dgAtti.SetTitoloNrElementi();
            dgAtti.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgAtti_ItemDataBound);
            dgAtti.DataBind();

            if (decreto_selezionato != null)
                compilaCampiDecreto();
            else
                pulisciCampiDecreto();
        }

        protected string riempiCampiSanzioni()
        {
            string errore = "";

            registro_recupero_selezionato.IdProcedureAvviate = lstProcedureAvviate.SelectedValue;
            registro_recupero_selezionato.IdTipoProcedureAvviate = lstTipoProcedureAvviate.SelectedValue;

            if (sanzione_selezionata == null)
                sanzione_selezionata = new SiarLibrary.SanzioniRecupero();
            sanzione_selezionata.IdCategoriaSanzione = lstCategoriaSanzione.SelectedValue;
            sanzione_selezionata.IdTipoSanzione = lstTipoSanzione.SelectedValue;
            sanzione_selezionata.IdStatoSanzione = lstStatoProcedure.SelectedValue;
            sanzione_selezionata.ImportoSanzione = txtImportoSanzione.Text;
            sanzione_selezionata.DataConclusione = txtDataConclusioneSanzione.Text;

            return errore;
        }

        protected void riempiFormSanzioni()
        {
            lstProcedureAvviate.SelectedValue = registro_recupero_selezionato.IdProcedureAvviate;
            lstTipoProcedureAvviate.SelectedValue = registro_recupero_selezionato.IdTipoProcedureAvviate;

            var sanzioni_provider = new SiarBLL.SanzioniRecuperoCollectionProvider();
            var sanzioni_collection = registro_recupero_selezionato.IdRegistroRecupero != null
                ? sanzioni_provider.GetByRegistroRecupero(registro_recupero_selezionato.IdRegistroRecupero)
                : new SiarLibrary.SanzioniRecuperoCollection();
            dgSanzioniRecuperi.DataSource = sanzioni_collection;
            dgSanzioniRecuperi.SetTitoloNrElementi();
            dgSanzioniRecuperi.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgSanzioniRecuperi_ItemDataBound);
            dgSanzioniRecuperi.DataBind();

            //int id_recupero;
            //if (int.TryParse(hdnIdRecupero.Value, out id_recupero))
            //    registro_recupero_selezionato = new SiarBLL.RegistroRecuperoCollectionProvider().GetById(id_recupero);

            //int id_sanzione;
            //if (int.TryParse(hdnIdSanzione.Value, out id_sanzione))
            //    sanzione_selezionata = new SiarBLL.SanzioniRecuperoCollectionProvider().GetById(id_sanzione);

            if (sanzione_selezionata != null)
            {
                lstCategoriaSanzione.SelectedValue = sanzione_selezionata.IdCategoriaSanzione;
                lstTipoSanzione.SelectedValue = sanzione_selezionata.IdTipoSanzione;
                lstStatoProcedure.SelectedValue = sanzione_selezionata.IdStatoSanzione;
                txtImportoSanzione.Text = sanzione_selezionata.ImportoSanzione;
                txtDataConclusioneSanzione.Text = sanzione_selezionata.DataConclusione;

                btnAggiornaSanzione.Visible = true;
            }
        }

        protected void riempiFormRata()
        {
            int id_rata;
            if (int.TryParse(hdnIdRata.Value, out id_rata))
            {
                var rata_collection_provider = new SiarBLL.RataCollectionProvider();
                var rata_selezionata = rata_collection_provider.GetById(id_rata);

                txtDataRata.Text = rata_selezionata.DataRata;
                txtDataScadenzaRata.Text = rata_selezionata.DataScadenza;
                txtImportoRata.Text = rata_selezionata.ImportoRata;

                if (rata_selezionata.Pagata != null && rata_selezionata.Pagata)
                {
                    lstRataPagata.SelectedValue = "1";
                    txtDataPagamentoRata.Text = rata_selezionata.DataPagamento;
                    //divDataPagamentoRata.Visible = true;
                }
                else
                {
                    lstRataPagata.SelectedValue = "0";
                    txtDataPagamentoRata.Text = null;
                    //divDataPagamentoRata.Visible = false;
                }
            }
            else
                ShowError("Nessuna rata selezionata.");
        }

        protected void compilaCampiDecreto()
        {
            hdnIdAtto.Value = decreto_selezionato.IdAtto;
            txtAttoData.Text = decreto_selezionato.Data;
            txtAttoNumero.Text = decreto_selezionato.Numero;
            txtAttoDescrizione.Text = decreto_selezionato.Descrizione;
            foreach (ListItem l in lstAttoRegistro.Items)
                if (l.Value.StartsWith(decreto_selezionato.Registro))
                {
                    l.Selected = true;
                    break;
                }

            btnVidualizzaDecreto.Disabled = false;
            btnVidualizzaDecreto.Attributes.Add("onclick", "visualizzaAtto(" + decreto_selezionato.IdAtto + ");");
            btnAssociaDecretoRecupero.Enabled = true;
            btnAssociaDecretoRitiro.Enabled = true;
            btnAssociaDecretoNonRecuperabilita.Enabled = true;
        }

        protected void pulisciCampiDecreto()
        {
            txtAttoData.Text = "";
            txtAttoNumero.Text = "";
            lstAttoRegistro.ClearSelection();
            txtAttoDescrizione.Text = "";
            hdnIdAtto.Value = "";
        }

        protected void riempiFormStorico()
        {
            if (registro_recupero_selezionato != null && registro_recupero_selezionato.IdStoricoRecuperoPrecedente != null)
            {
                var recuperi_collection_storico = new SiarLibrary.RegistroRecuperoCollection();
                recuperi_collection_storico.Add(new SiarBLL.RegistroRecuperoCollectionProvider().GetById(registro_recupero_selezionato.IdStoricoRecuperoPrecedente));
                dgRegistroRecuperiStorico.DataSource = recuperi_collection_storico;
                dgRegistroRecuperiStorico.SetTitoloNrElementi();
                dgRegistroRecuperiStorico.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgRegistroRecuperi_ItemDataBound);
                dgRegistroRecuperiStorico.DataBind();
            }
        }

        protected void getHdnIdRegistroRecuperoOCrea()
        {
            int id_recupero;
            if (int.TryParse(hdnIdRecupero.Value, out id_recupero))
            {
                registro_recupero_selezionato = registro_recupero_provider.GetById(id_recupero);
                registro_recupero_selezionato.CfModifica = Operatore.Utente.CfUtente;
            }

            if (registro_recupero_selezionato == null || registro_recupero_selezionato.IdRegistroRecupero == null)
            {
                registro_recupero_selezionato = new SiarLibrary.RegistroRecupero();
                registro_recupero_selezionato.Storico = 0;
                registro_recupero_selezionato.DataInserimento = DateTime.Now;
                registro_recupero_selezionato.IdProgetto = Progetto.IdProgetto;
                registro_recupero_selezionato.CfInserimento = Operatore.Utente.CfUtente;
                registro_recupero_selezionato.CfModifica = Operatore.Utente.CfUtente;
            }
        }

        protected void getHdnIdSanzioneOCrea()
        {
            int id_sanzione;
            if (int.TryParse(hdnIdSanzione.Value, out id_sanzione))
            {
                sanzione_selezionata = new SiarBLL.SanzioniRecuperoCollectionProvider().GetById(id_sanzione);
                sanzione_selezionata.CfModifica = Operatore.Utente.CfUtente;
            }

            if (sanzione_selezionata == null || sanzione_selezionata.IdSanzioneRecupero == null)
            {
                sanzione_selezionata = new SiarLibrary.SanzioniRecupero();
                getHdnIdRegistroRecuperoOCrea();
                sanzione_selezionata.IdRegistroRecupero = registro_recupero_selezionato.IdRegistroRecupero;
                sanzione_selezionata.CfInserimento = Operatore.Utente.CfUtente;
                sanzione_selezionata.CfModifica = Operatore.Utente.CfUtente;
            }
        }

        protected int getHdnIdAtto()
        {
            int id_decreto;
            SiarLibrary.Atti decreto_recupero = null;

            if (int.TryParse(hdnIdAtto.Value, out id_decreto))
                decreto_recupero = new SiarBLL.AttiCollectionProvider().GetById(id_decreto);

            if (decreto_recupero == null) throw new Exception("Per proseguire è necessario specificare l'atto di riferimento.");

            return id_decreto;
        }

        protected void enableGestioneStorico(bool enable)
        {
            btnSalvaRegistroRecuperi.Enabled = false;
            btnEliminaRegistroRecuperi.Enabled = false;
            btnSalvaInformazioniGenerali.Enabled = false;
            btnSalvaProcedureSanzioni.Enabled = false;
            btnInserisciSanzione.Enabled = false;
            btnEliminaSanzione.Enabled = false;
            lnkAssociaIrregolarita.Visible = false;
        }

        private string checkBoolLst(String value)
        {
            if (value == null)
                return "0";

            switch (value)
            {
                case "True": return "1";
                case "true": return "1";
                default: return "0";
            }
        }

        private bool checkBoolValue(SiarLibrary.NullTypes.BoolNT value, bool defaultValue)
        {
            if (value != null)
                return value;
            else
                return defaultValue;
        }

        #region ItemDataBound

        void dgIrregolarita_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.RegistroIrregolarita reg = (SiarLibrary.RegistroIrregolarita)e.Item.DataItem;
                SiarLibrary.CodificaGenericaCollectionProvider codifica_provider = new SiarLibrary.CodificaGenericaCollectionProvider();

                if (reg.IdImpresaCommessaDa == null || reg.IdImpresaCommessaDa == 0)
                    e.Item.Cells[2].Text = reg.NoteCommessaDa;
                else
                {
                    var impresa = new SiarBLL.ImpresaCollectionProvider().GetById(reg.IdImpresaCommessaDa);
                    e.Item.Cells[2].Text = impresa.RagioneSociale;
                }

                if (reg.IdCategoriaIrregolarita != null)
                {
                    var codifica = codifica_provider.GetById(reg.IdCategoriaIrregolarita);

                    if (codifica != null)
                        e.Item.Cells[4].Text = codifica.Descrizione;
                }

                if (reg.IdTipoIrregolarita != null)
                {
                    var codifica = codifica_provider.GetById(reg.IdTipoIrregolarita);

                    if (codifica != null)
                        e.Item.Cells[5].Text = codifica.Descrizione;
                }

                if (reg.IdClassificazioneIrregolarita != null)
                {
                    var codifica = codifica_provider.GetById(reg.IdClassificazioneIrregolarita);

                    if (codifica != null)
                        e.Item.Cells[6].Text = codifica.Descrizione;
                }

                if (reg.SegnalazioneOlaf != null && reg.SegnalazioneOlaf)
                    e.Item.Cells[7].Text = e.Item.Cells[7].Text.Replace("<input", "<input checked");
                else
                    e.Item.Cells[7].Text = e.Item.Cells[7].Text.Replace("<input checked", "<input");
            }
        }

        decimal importo_sanzioni_totale = 0;

        void dgSanzioniRecuperi_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.SanzioniRecupero san = (SiarLibrary.SanzioniRecupero)e.Item.DataItem;
                SiarLibrary.CodificaGenericaCollectionProvider codifica_provider = new SiarLibrary.CodificaGenericaCollectionProvider();

                if (san.IdCategoriaSanzione != null)
                {
                    var codifica = codifica_provider.GetById(san.IdCategoriaSanzione);

                    if (codifica != null)
                        e.Item.Cells[1].Text = codifica.Descrizione;
                }

                if (san.IdTipoSanzione != null)
                {
                    var codifica = codifica_provider.GetById(san.IdTipoSanzione);

                    if (codifica != null)
                        e.Item.Cells[2].Text = codifica.Descrizione;
                }

                if (san.IdStatoSanzione != null)
                {
                    var codifica = codifica_provider.GetById(san.IdStatoSanzione);

                    if (codifica != null)
                        e.Item.Cells[4].Text = codifica.Descrizione;
                }

                if (san.ImportoSanzione != null)
                {
                    e.Item.Cells[3].Text = string.Format("{0:c}", san.ImportoSanzione);
                    importo_sanzioni_totale += san.ImportoSanzione;
                }
            }
            else if (e.Item.ItemType == ListItemType.Footer)
                e.Item.Cells[3].Text = string.Format("{0:c}", importo_sanzioni_totale);
        }

        void dgRegistroRecuperi_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.RegistroRecupero rec = (SiarLibrary.RegistroRecupero)e.Item.DataItem;
                SiarLibrary.CodificaGenericaCollectionProvider codifica_provider = new SiarLibrary.CodificaGenericaCollectionProvider();

                if (rec.IdTipoRecupero != null)
                {
                    var codifica = codifica_provider.GetById(rec.IdTipoRecupero);
                    if (codifica != null)
                        e.Item.Cells[1].Text = codifica.Descrizione;
                }

                if (rec.IdProcedureAvviate != null)
                {
                    var codifica = codifica_provider.GetById(rec.IdProcedureAvviate);
                    if (codifica != null)
                        e.Item.Cells[4].Text = codifica.Descrizione;
                }

                if (rec.IdTipoProcedureAvviate != null)
                {
                    var codifica = codifica_provider.GetById(rec.IdTipoProcedureAvviate);
                    if (codifica != null)
                        e.Item.Cells[5].Text = codifica.Descrizione;
                }

                if (rec.Recuperabile != null && rec.Recuperabile)
                    e.Item.Cells[6].Text = e.Item.Cells[6].Text.Replace("<input", "<input checked");
                else
                    e.Item.Cells[6].Text = e.Item.Cells[6].Text.Replace("<input checked", "<input");
            }
        }

        decimal importo_rate_totale = 0;

        void dgRateRecupero_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.Rata rata = (SiarLibrary.Rata)e.Item.DataItem;
                SiarLibrary.CodificaGenericaCollectionProvider codifica_provider = new SiarLibrary.CodificaGenericaCollectionProvider();

                if (rata.ImportoRata != null)
                    importo_rate_totale += rata.ImportoRata;

                if (rata.Pagata != null && rata.Pagata)
                    e.Item.Cells[3].Text = e.Item.Cells[3].Text.Replace("<input", "<input checked");
                else
                    e.Item.Cells[3].Text = e.Item.Cells[3].Text.Replace("checked", "");
            }
            else if (e.Item.ItemType == ListItemType.Footer)
                e.Item.Cells[1].Text = string.Format("{0:c}", importo_rate_totale);
        }

        void dgAtti_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.Atti atto = (SiarLibrary.Atti)e.Item.DataItem;

                string motivazione = "";
                if (registro_recupero_selezionato != null)
                {
                    if (atto.IdAtto == registro_recupero_selezionato.IdAttoRecupero)
                        motivazione = "Recupero";
                    else if (atto.IdAtto == registro_recupero_selezionato.IdAttoRitiro)
                        motivazione = "Ritiro";
                    else if (atto.IdAtto == registro_recupero_selezionato.IdAttoNonRecuperabilita)
                        motivazione = "Non recuperabilità";
                    else
                        motivazione = "Sconosciuto";
                }
                e.Item.Cells[0].Text = motivazione;

                var dec = atto.Numero.ToString() + '|' + atto.Data + '|' + atto.Registro;
                e.Item.Cells[1].Text = "<a href=\"javascript:visualizzaAtto(" + atto.IdAtto + ");\">" + dec + "</a>";
            }
        }

        #endregion
    }
}