using System;
using System.Collections;
using System.Web.UI.WebControls;
using SiarLibrary;
using SiarLibrary.Extensions;

namespace web.Private.IPagamento
{
    public partial class IstruttoriaSpeseSostenute : SiarLibrary.Web.IstruttoriaPagamentoPage
    {
        SiarBLL.SpeseSostenuteCollectionProvider spese_provider;
        SiarBLL.GiustificativiCollectionProvider giustificativi_provider;
        Hashtable ammontare_x_giustificativo = new Hashtable();
        SiarBLL.IntegrazioniPerDomandaDiPagamentoCollectionProvider integrazione_provider;
        SiarBLL.IntegrazioneSingolaDiDomandaCollectionProvider integrazione_singola_provider;

        SiarBLL.PianoInvestimentiCollectionProvider investimenti_provider;

        protected void Page_Load(object sender, EventArgs e)
        {
            spese_provider = new SiarBLL.SpeseSostenuteCollectionProvider(PagamentoProvider.DbProviderObj);
            giustificativi_provider = new SiarBLL.GiustificativiCollectionProvider(PagamentoProvider.DbProviderObj);
            investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider(PagamentoProvider.DbProviderObj);
            integrazione_provider = new SiarBLL.IntegrazioniPerDomandaDiPagamentoCollectionProvider();
            integrazione_singola_provider = new SiarBLL.IntegrazioneSingolaDiDomandaCollectionProvider();

            txtDataRichiestaGiustificativo.Text = new SiarLibrary.NullTypes.DatetimeNT(DateTime.Now);
            txtDataRichiestaSpesa.Text = new SiarLibrary.NullTypes.DatetimeNT(DateTime.Now);

            if (Session["id_spesa_integrazione"] != null || Session["id_giustificativo_integrazione"] != null)
                ucSiarNewTab.TabSelected = 2;
        }

        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    tabElenco.Visible = false;
                    lstPagamento.DataBind();
                    lstTipoGiustificativo.DataBind();
                    txtImportoLordoPagamento.AddJSAttribute("onblur", "validaImporti(true);");
                    txtPivaFornitore.AddJSAttribute("onblur", "ctrlCF();");
                    CaricaSpesa();
                    if (AbilitaModifica)
                    {
                        trIntegrazioneGiustificativo.Visible = true;
                        trIntegrazioneSpesa.Visible = true;
                    }
                    break;
                default:
                    tabDettaglio.Visible = false;
                    //ucSiarNewTab.Width = tabElenco.Width;
                    if (Request.QueryString["redir"] == "revisione")
                    {
                        btnBack.Attributes["onclick"] = "location='Revisionedomande.aspx?&idpag="
                              + DomandaPagamento.IdDomandaPagamento + "'";
                        btnBackDown.Attributes["onclick"] = "location='Revisionedomande.aspx?&idpag="
                              + DomandaPagamento.IdDomandaPagamento + "'";
                    }
                    btnStampa.Attributes.Add("onclick", "SNCVisualizzaReport('rptIstruttoriaSpeseSostenute',2,'IdDomandaPagamento="
                        + DomandaPagamento.IdDomandaPagamento + "');");
                    ammontare_x_giustificativo = giustificativi_provider.CalcoloAmmontareRichiestoXGiustificativo(DomandaPagamento.IdDomandaPagamento);
                    SiarLibrary.SpeseSostenuteCollection spese = spese_provider.Find(DomandaPagamento.IdDomandaPagamento, null, null);
                    // filtro
                    bool? ckIntegraz = null;
                    if (ckInintegrazione.Checked)
                        ckIntegraz = true;
                    lstFiltroTipoGiustificativo.DataBind();
                    spese = spese.FiltraPerDatiGiustificativoIstruttoriaSpeseSostenute(txtFiltroNumero.Text, txtFiltroData.Text, lstFiltroTipoGiustificativo.SelectedValue,
                        txtFiltroOggetto.Text, ckIntegraz);
                    dgSpese.DataSource = spese;
                    lblNrRecord.Text = spese.Count.ToString();
                    dgSpese.ItemDataBound += new DataGridItemEventHandler(dgSpese_ItemDataBound);
                    //dgSpese.Titolo = "&nbsp;&nbsp;<b><em>Elementi trovati: " + spese.Count.ToString() + "</em></b>";
                    dgSpese.DataBind();
                    if (DomandaPagamento.InIntegrazione == null || DomandaPagamento.InIntegrazione == false)
                        dgSpese.Columns[11].Visible = false;
                    break;
            }
            base.OnPreRender(e);
        }

        protected void controlloCampiGiustificativo(ref SiarLibrary.Giustificativi giustificativo, int idSpesa)
        {
            //Controllo copiato da /PPagamento/SpeseSostenute.aspx.cs
            SpeseSostenuteCollection spese = spese_provider.Find(null, giustificativo.IdGiustificativo, null);
            decimal totaleSpeseNette = 0;
            foreach (SiarLibrary.SpeseSostenute s in spese)
            {
                if (!s.DomandaPagamentoAnnullata && s.IdSpesa != idSpesa) totaleSpeseNette += s.Netto.Value;

            }

            if (totaleSpeseNette > giustificativo.Imponibile)
                throw new Exception("L`importo netto dei pagamenti riferiti al giustificativo selezionato supera l'ammontare del giustificativo. Impossibile continuare.");
        }

        private void CaricaSpesa()
        {
            SiarLibrary.SpeseSostenute spesa = null;

            int idspesa;
            if (int.TryParse(hdnIdSpesaSostenuta.Value, out idspesa))
            {
                spesa = spese_provider.GetById(idspesa);
            }

            if (spesa == null && Session["id_spesa_integrazione"] != null)
            {
                spesa = spese_provider.GetById(int.Parse(Session["id_spesa_integrazione"].ToString()));
                Session["id_spesa_integrazione"] = null;
                hdnIdSpesaSostenuta.Value = spesa.IdSpesa;
            }

            if (spesa == null && Session["id_giustificativo_integrazione"] != null)
            {
                var spese_collection = spese_provider.GetSpeseModificateIntegrazione(DomandaPagamento.IdDomandaPagamento, int.Parse(Session["id_giustificativo_integrazione"].ToString()), DomandaPagamento.IdProgetto, null, null);
                if (spese_collection.Count > 0)
                {
                    spesa = spese_collection[0];
                    hdnIdSpesaSostenuta.Value = spesa.IdSpesa;
                }
                Session["id_giustificativo_integrazione"] = null;
            }

            if (spesa == null)
            {
                btnSalva.Enabled = false;
                ShowError("Nessuna spesa selezionata.");
            }
            else
            {
                txtDataDocTrasporto.Text = spesa.DataDoctrasporto;
                txtDataGiustificativo.Text = spesa.DataGiustificativo;
                txtDataPagamento.Text = spesa.Data;
                txtDescGiustificativo.Text = spesa.Descrizione;
                txtEstremi.Text = spesa.Estremi;
                txtImportoGiustificativo.Text = spesa.Imponibile;
                txtImportoLordoPagamento.Text = spesa.Importo;
                txtImportoNettoPagamento.Text = spesa.Netto;
                txtIva.Text = spesa.Iva;
                txtNumDocTrasporto.Text = spesa.NumeroDoctrasporto;
                txtNumGiustificativo.Text = spesa.Numero;
                txtPivaFornitore.Text = spesa.CfFornitore;
                txtRSFornitore.Text = spesa.DescrizioneFornitore;
                lstTipoGiustificativo.SelectedValue = spesa.CodTipoGiustificativo;
                lstPagamento.SelectedValue = spesa.CodTipo;
                chkNonRecuperabile.Checked = spesa.IvaNonRecuperabile;
                ufGiustificativo.IdFile = spesa.IdFileGiustificativo;
                ufPagamento.IdFile = spesa.IdFile;
                ufGiustificativo.AbilitaModifica = ufPagamento.AbilitaModifica = AbilitaModifica;

                if (spesa.InIntegrazione != null && spesa.InIntegrazione)
                {
                    tdRichiestaIntegrazionePagamento.Visible = true;
                    txtDataRichiestaSpesa.Enabled = false;
                    txtNoteIntegrazioneSpesa.Enabled = false;
                    btnRichiediIntegrazioneSpesa.Enabled = false;

                    var integrazioni_spesa = new SiarBLL.IntegrazioneSingolaDiDomandaCollectionProvider()
                        .Select(null, null, "PAG", null, null, null, null, null, null, false, null, null, null, null, null, spesa.IdSpesa, null, null);

                    if (integrazioni_spesa.Count > 0)
                    {
                        var integrazione = integrazioni_spesa[0];

                        txtDataRichiestaSpesa.Text = integrazione.DataRichiestaIntegrazioneIstruttore;
                        txtNoteIntegrazioneSpesa.Text = integrazione.NoteIntegrazioneIstruttore;
                    }
                }

                SiarBLL.SpeseSostenuteFileCollectionProvider file_spese_provider = new SiarBLL.SpeseSostenuteFileCollectionProvider();
                var file_spese_collection = file_spese_provider.GetByIdSpesa(spesa.IdSpesa, null);
                if (file_spese_collection.Count > 0)
                {
                    trFileSpesaSostenuta.Visible = true;
                    dgFileSpeseSostenute.DataSource = file_spese_collection;
                    dgFileSpeseSostenute.SetTitoloNrElementi();
                    dgFileSpeseSostenute.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgFileSpeseSostenute_ItemDataBound);
                    dgFileSpeseSostenute.DataBind();
                }

                var giustificativo_selezionato = new SiarBLL.GiustificativiCollectionProvider().GetById(spesa.IdGiustificativo);
                if (giustificativo_selezionato.InIntegrazione != null && giustificativo_selezionato.InIntegrazione)
                {
                    tdRichiestaIntegrazioneGiustificativo.Visible = true;
                    txtDataRichiestaGiustificativo.Enabled = false;
                    txtNoteIntegrazioneGiustificativo.Enabled = false;
                    btnRichiediIntegrazioneGiustificativo.Enabled = false;

                    var integrazioni_giustificativo = new SiarBLL.IntegrazioneSingolaDiDomandaCollectionProvider()
                        .Select(null, null, "GIU", null, null, null, null, null, null, false, null, null, null, null, null, null, giustificativo_selezionato.IdGiustificativo, null);

                    if (integrazioni_giustificativo.Count > 0)
                    {
                        var integrazione = integrazioni_giustificativo[0];

                        txtDataRichiestaGiustificativo.Text = integrazione.DataRichiestaIntegrazioneIstruttore;
                        txtNoteIntegrazioneGiustificativo.Text = integrazione.NoteIntegrazioneIstruttore;
                    }
                }
                //Carico datagrid piano investimenti
                SiarLibrary.PianoInvestimentiCollection investimenti = investimenti_provider.GetPianoInvestimentiGiustificativo(DomandaPagamento.IdDomandaPagamento, spesa.IdGiustificativo);
                if (investimenti.Count > 0)
                {
                    divElencoPianoInv.Visible = true;
                    dgInvestimenti.DataSource = investimenti;
                    dgInvestimenti.ItemDataBound += new DataGridItemEventHandler(dgInvestimenti_ItemDataBound);
                    dgInvestimenti.DataBind();
                }
            }
        }

        #region ItemDataBound

        void dgSpese_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            int col_Numero = 0,
                col_RiepilogoGius = 1,
                col_OggettoGiust = 2,
                col_FileGius = 3,
                col_LordoGius = 4,
                col_NettoGius = 5,
                col_Richiesto = 6,
                col_Ammesso = 7,
                col_RiepilogoSp = 8,
                col_FileSp = 9,
                col_LordoSp = 10,
                col_Integrazione = 11;

            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType == ListItemType.Header)
            {
                dgi.Cells[col_Numero].RowSpan = 2;
                dgi.Cells[col_RiepilogoGius].ColumnSpan = 7;
                dgi.Cells[col_RiepilogoGius].HorizontalAlign = HorizontalAlign.Center;
                dgi.Cells[col_RiepilogoGius].Text = "Dati giustificativo</th><th colspan=3 align=center>Dati pagamento</th><th></th></tr><tr class='TESTA'><td>Riepilogo";
            }
            else if (e.Item.ItemType != ListItemType.Footer)
            {
                SiarLibrary.SpeseSostenute spesa = (SiarLibrary.SpeseSostenute)dgi.DataItem;
                if (spesa.Ammesso) dgi.Cells[0].Text = dgi.Cells[col_Numero].Text + "  <svg alt='Ammessa' class='icon icon-breadcrumb icon-secondary me-1' aria-hidden='true'><use href='/web/bootstrap-italia/svg/sprites.svg#it-check'></use></svg>";
                object valore = ammontare_x_giustificativo[spesa.IdGiustificativo.Value.ToString()];
                string[] valori;
                if (valore != null) valori = valore.ToString().Split('|');
                else
                {
                    valori = new string[2];
                    valori[col_Numero] = "0";
                    valori[col_RiepilogoGius] = "0";
                }
                dgi.Cells[col_Richiesto].Text = string.Format("{0:c}", decimal.Parse(valori[0]));
                dgi.Cells[col_Ammesso].Text = string.Format("{0:c}", decimal.Parse(valori[1]));
                dgi.Cells[col_RiepilogoSp].Text = "<b>Tipo:</b> " + spesa.TipoPagamento + "<br /><b>Estremi:</b> " + spesa.Estremi;
                dgi.Cells[col_RiepilogoGius].Text = "Numero: <b>" + spesa.Numero
                   + "</b><br />Data: <b>" + spesa.DataGiustificativo + "</b><br />Tipo: <b>" + spesa.TipoGiustificativo + "</b>";
                decimal importo_lordo_giustificativo = spesa.Imponibile + (spesa.Imponibile * spesa.Iva / 100);
                dgi.Cells[col_LordoGius].Text = string.Format("{0:c}", importo_lordo_giustificativo);

                SiarBLL.GiustificativiCollectionProvider giustificativi_provider = new SiarBLL.GiustificativiCollectionProvider();
                SiarLibrary.Giustificativi giustificativo = giustificativi_provider.GetById(spesa.IdGiustificativo);
                dgi.Cells[col_FileGius].Text = dgi.Cells[col_FileGius].Text.Replace("SNCUFVisualizzaFile(" + spesa.IdFile + ",this);", "SNCUFVisualizzaFile(" + giustificativo.IdFile + ",this);");
                if ((spesa.InIntegrazione == null || spesa.InIntegrazione == false)
                    && (giustificativo.InIntegrazione == null || giustificativo.InIntegrazione == false))
                    dgi.Cells[col_Integrazione].Text = "";
            }
        }

        void dgFileSpeseSostenute_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var d = (SiarLibrary.SpeseSostenuteFile)e.Item.DataItem;

                if (d.Descrizione.Value.Length > 50)
                {
                    dgi.Cells[1].Text = d.Descrizione.Value.Substring(0, 50);
                    dgi.Cells[1].ToolTip = d.Descrizione;
                }

                if (d.NomeFile.Value.Length > 50)
                {
                    dgi.Cells[2].Text = d.NomeFile.Value.Substring(0, 50);
                    dgi.Cells[2].ToolTip = d.NomeFile;
                }
            }
        }

        void dgInvestimenti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType == ListItemType.Header)
            {
                dgi.Cells[0].ColumnSpan = 3;
                dgi.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                dgi.Cells[0].Text = "Piano Investimenti</th><th colspan=4 align=center>Dati Giustificativo</th></tr><tr class='TESTA'><th>Descrizione";
            }
            else if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.PianoInvestimenti f = (SiarLibrary.PianoInvestimenti)dgi.DataItem;
                dgi.Cells[0].Text = "<b>Codifica:</b> " + f.CodificaInvestimento + "<br /><b>Dettaglio:</b> " + f.DettaglioInvestimenti
                                    + "<br /><b>Descrizione:</b> " + f.Descrizione;
                //Aggregazione  
                string[] Aggregazione = new string[2];
                Aggregazione = investimenti_provider.GetImpresaAggregazioneInvestimento(f.IdInvestimento);
                if (Aggregazione[0] != null && Aggregazione[1] != null && Aggregazione[0] != "" && Aggregazione[1] != "")
                {
                    dgi.Cells[0].Text += "<br /><b>Impresa: </b>" + Aggregazione[0] + " - " + Aggregazione[1];
                    SiarLibrary.Impresa impresa = new SiarBLL.ImpresaCollectionProvider().GetByCuaa(Aggregazione[0]);
                    if (impresa.CodAteco2007 != null && impresa.CodAteco2007 != "")
                        dgi.Cells[0].Text += " - Ateco: " + impresa.CodAteco2007;
                }

                //Personalizzazione bando 6.2  
                if (Progetto.IdBando == 39)
                {
                    string linea_intervento = "";
                    linea_intervento = investimenti_provider.GetLineaInterventoInvestimento(f.IdInvestimento);
                    if (linea_intervento != null && linea_intervento != "")
                        dgi.Cells[0].Text += "<br /><b>" + linea_intervento + "</b>";
                }

                decimal importo_giu_richiesti, contributo_giu_richiesto, importo_giu_ammesso, contributo_giu_ammesso;

                decimal.TryParse(f.AdditionalAttributes["ImportoGiustificativoRichiesto"], out importo_giu_richiesti);
                decimal.TryParse(f.AdditionalAttributes["ContributoGiustificativoRichiesto"], out contributo_giu_richiesto);
                dgi.Cells[3].Text = string.Format("{0:c}", importo_giu_richiesti);
                dgi.Cells[4].Text = string.Format("{0:c}", contributo_giu_richiesto);

                if (decimal.TryParse(f.AdditionalAttributes["ImportoGiustificativoAmmesso"], out importo_giu_ammesso))
                    dgi.Cells[5].Text = string.Format("{0:c}", importo_giu_ammesso);
                if (decimal.TryParse(f.AdditionalAttributes["ContributoGiustificativoAmmesso"], out contributo_giu_ammesso))
                    dgi.Cells[6].Text = string.Format("{0:c}", contributo_giu_ammesso);
            }
        }

        #endregion

        #region Button_Click

        protected void btnCerca_Click(object sender, EventArgs e)
        {
            dgSpese.SetPageIndex(0);
        }

        protected void btnRichiediIntegrazioneGiustificativo_Click(object sender, EventArgs e)
        {
            int idspesa;
            if (int.TryParse(hdnIdSpesaSostenuta.Value, out idspesa))
            {
                spese_provider = new SiarBLL.SpeseSostenuteCollectionProvider();
                SiarLibrary.SpeseSostenute spesa = spese_provider.GetById(idspesa);
                if (spesa == null) ShowError("Nessuna spesa selezionata.");
                else
                {
                    giustificativi_provider = new SiarBLL.GiustificativiCollectionProvider();
                    SiarLibrary.Giustificativi giustificativo = giustificativi_provider.GetById(spesa.IdGiustificativo);
                    string error = SiarBLL.IntegrazioniDomandaPagamentoUtility.creaNuovaIntegrazione(DomandaPagamento, giustificativo, Operatore.Utente,
                        txtNoteIntegrazioneGiustificativo.Text, txtDataRichiestaGiustificativo.Text, spesa.IdGiustificativo);

                    if (error != null && error.Equals(""))
                        ShowMessage("Richiesta di integrazione giustificativo inserita.");
                    else
                        ShowError(error);
                }
            }
        }

        protected void btnRichiediIntegrazioneSpesa_Click(object sender, EventArgs e)
        {
            int idspesa;
            if (int.TryParse(hdnIdSpesaSostenuta.Value, out idspesa))
            {
                spese_provider = new SiarBLL.SpeseSostenuteCollectionProvider();
                SiarLibrary.SpeseSostenute spesa = spese_provider.GetById(idspesa);
                if (spesa == null) ShowError("Nessuna spesa selezionata.");
                else
                {
                    string error = SiarBLL.IntegrazioniDomandaPagamentoUtility.creaNuovaIntegrazione(DomandaPagamento, spesa, Operatore.Utente,
                        txtNoteIntegrazioneSpesa.Text, txtDataRichiestaSpesa.Text, spesa.IdSpesa);

                    if (error != null && error.Equals(""))
                        ShowMessage("Richiesta di integrazione pagamento inserita.");
                    else
                        ShowError(error);
                }
            }
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            ucSiarNewTab.TabSelected = 2;
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                int idSpesaSostenuta;
                if (int.TryParse(hdnIdSpesaSostenuta.Value, out idSpesaSostenuta))
                {
                    PagamentoProvider.DbProviderObj.BeginTran();
                    SiarLibrary.SpeseSostenute spesa = spese_provider.GetById(idSpesaSostenuta);
                    SiarLibrary.Giustificativi giustificativo = giustificativi_provider.GetById(spesa.IdGiustificativo);
                    if (spesa == null || giustificativo == null) throw new Exception("La voce di spesa selezionata non è valida. Impossibile continuare.");
                    giustificativo.IdProgetto = Progetto.IdProgetto;
                    giustificativo.CodTipo = lstTipoGiustificativo.Text;
                    giustificativo.Data = txtDataGiustificativo.Text;
                    giustificativo.Numero = txtNumGiustificativo.Text;
                    giustificativo.NumeroDoctrasporto = txtNumDocTrasporto.Text;
                    giustificativo.DataDoctrasporto = txtDataDocTrasporto.Text;
                    giustificativo.Imponibile = txtImportoGiustificativo.Text;
                    giustificativo.Iva = txtIva.Text;
                    giustificativo.Descrizione = txtDescGiustificativo.Text;
                    giustificativo.CfFornitore = txtPivaFornitore.Text.ToUpper();
                    giustificativo.DescrizioneFornitore = txtRSFornitore.Text;
                    giustificativo.IvaNonRecuperabile = chkNonRecuperabile.Checked;
                    giustificativo.IdFile = ufGiustificativo.IdFile;

                    spesa.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                    spesa.Estremi = txtEstremi.Text;
                    spesa.Data = txtDataPagamento.Text;
                    spesa.CodTipo = lstPagamento.Text;
                    spesa.Importo = txtImportoLordoPagamento.Text;
                    spesa.Netto = txtImportoNettoPagamento.Text;
                    spesa.IdFile = ufPagamento.IdFile;
                    spesa.Ammesso = true;
                    spesa.DataApprovazione = DateTime.Now;
                    spesa.OperatoreApprovazione = Operatore.Utente.IdUtente;

                    controlloCampiGiustificativo(ref giustificativo, idSpesaSostenuta);
                    giustificativi_provider.Save(giustificativo);
                    spese_provider.Save(spesa);
                    PagamentoProvider.AggiornaDomandaDiPagamentoIstruttore(DomandaPagamento, Operatore);
                    PagamentoProvider.DbProviderObj.Commit();
                    ShowMessage("Modifiche salvate correttamente.");
                }
                else ShowError("Impossibile inserire una nuova spesa in fase istruttoria.");
            }
            catch (Exception ex) { PagamentoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnPost_Click(object sender, EventArgs e) { }

        protected void btnIndietro_Click(object sender, EventArgs e)
        {
            ucSiarNewTab.TabSelected = 1;
        }

        #endregion
    }
}