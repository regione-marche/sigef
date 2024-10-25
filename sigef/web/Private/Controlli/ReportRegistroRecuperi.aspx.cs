using System;
using System.Web.UI.WebControls;
using SiarBLL;
using SiarLibrary;

namespace web.Private.Controlli
{
    public partial class ReportRegistroRecuperi : SiarLibrary.Web.ControlliIrregolaritaPage
    {
        CodificaGenericaCollectionProvider codifica_generica_provider;
        RegistroIrregolaritaCollectionProvider registro_irregolarita_provider;
        RegistroRecuperoCollectionProvider registro_recupero_provider;
        //VritiriRecuperiCollectionProvider vRitiriRecuperiCollectionProvider;
        VregistroRitiriRecuperiCollectionProvider Vregistro_Ritiri_Recuperi_Provider;

        Nullable<int> nullable_id_progetto;
        Nullable<DateTime> nullable_data_inizio_ricerca;
        Nullable<DateTime> nullable_data_fine_ricerca;

        const int tabRitiri = 1 , tabRecuperi = 2 , tabNonRecuperabili = 3;

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "registro_recuperi";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lstProgrammazioneNew.AttivazioneBandi = true;
            lstProgrammazioneNew.DataBind();

            lstPeriodoContabile.DataBind();
            lstSoggettoRilevatore.DataBind();
            lstTipoDetrazione.DataBind();
            lstTipoOrigine.DataBind();

        }

        protected override void OnPreRender(EventArgs e)
        {
            codifica_generica_provider = new CodificaGenericaCollectionProvider();
            registro_irregolarita_provider = new RegistroIrregolaritaCollectionProvider();
            registro_recupero_provider = new RegistroRecuperoCollectionProvider();
            //vRitiriRecuperiCollectionProvider = new VritiriRecuperiCollectionProvider();
            Vregistro_Ritiri_Recuperi_Provider = new VregistroRitiriRecuperiCollectionProvider();

            popolaVariabiliRicerca();

            int ricerca;
            if (int.TryParse(hdnRicercaBool.Value, out ricerca))
                ricerca = 1;
            else
                ricerca = 0;

            if (ricerca == 1)
            {
                //divElaborazione.Visible = true;
                divReport.Visible = true;

                switch (tabReport.TabSelected)
                {
                    case tabRitiri:
                        cercaRitiri();
                        break;
                    case tabRecuperi:
                        cercaRecuperi();
                        break;
                    case tabNonRecuperabili:
                        cercaNonRecuperabili();
                        break;
                }
            }

            base.OnPreRender(e);
        }

        protected void cercaRecuperi()
        {
            dgRegistroRecuperi.Visible = true;
            dgRegistroRitiri.Visible = false;
            divRegistroRitiri.Visible = false;
            dgRegistroNonRecuperabili.Visible = false;

            //var registro_recuperi_collection = registro_recupero_provider.GetCollectionReport(
            //        lstProgrammazioneNew.SelectedValue,
            //        nullable_id_progetto,
            //        nullable_data_inizio_ricerca,
            //        nullable_data_fine_ricerca,
            //        28000,
            //        true,
            //        null);

            //dgRegistroRecuperi.DataSource = registro_recuperi_collection;
            dgRegistroRecuperi.DataSource = new VritiriRecuperiCollection();
            dgRegistroRecuperi.SetTitoloNrElementi();
            dgRegistroRecuperi.ItemDataBound += new DataGridItemEventHandler(dgRegistroRecuperi_ItemDataBound);
            dgRegistroRecuperi.DataBind();
        }

        protected void salvaRecuperi()
        {
            try
            {
                popolaVariabiliRicerca();

                var registro_recuperi_collection = registro_recupero_provider.GetCollectionReport(
                    lstProgrammazioneNew.SelectedValue,
                    nullable_id_progetto,
                    nullable_data_inizio_ricerca,
                    nullable_data_fine_ricerca,
                    28000,
                    true,
                    null);

                int salvato = 0;
                foreach (RegistroRecupero recupero in registro_recuperi_collection)
                {
                    var dataCertificazione = Request.Form["DataCertificazioneRecupero" + recupero.IdRegistroRecupero + "_text"];
                    if (dataCertificazione != null && !dataCertificazione.Equals(""))
                    {
                        recupero.DataCertificazioneRecupero = dataCertificazione;
                        registro_recupero_provider.Save(recupero);
                        salvato = 1;
                    }
                }

                if (salvato == 1)
                    ShowMessage("Date di certificazione salvate correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void cercaRitiri()
        {
            dgRegistroRecuperi.Visible = false;
            dgRegistroRitiri.Visible = true;
            divRegistroRitiri.Visible = true;
            dgRegistroNonRecuperabili.Visible = false;

            //var registro_ritiri_collection = registro_recupero_provider.GetCollectionReport(
            //        lstProgrammazioneNew.SelectedValue,
            //        nullable_id_progetto,
            //        nullable_data_inizio_ricerca,
            //        nullable_data_fine_ricerca,
            //        28001,
            //        true,
            //        false);

            var ritiri_collection = Vregistro_Ritiri_Recuperi_Provider.Find(lstProgrammazioneNew.SelectedValue, nullable_id_progetto, "RITIRO" ,lstTipoOrigine.SelectedValue , lstSoggettoRilevatore.SelectedValue , lstTipoDetrazione.SelectedValue , lstPeriodoContabile.SelectedValue);

            dgRegistroRitiri.DataSource = ritiri_collection;
            dgRegistroRitiri.SetTitoloNrElementi();
            dgRegistroRitiri.ItemDataBound += new DataGridItemEventHandler(dgRegistroRitiri_ItemDataBound);
            dgRegistroRitiri.DataBind();
        }

        protected void salvaRitiri()
        {
            try
            {
                popolaVariabiliRicerca();

                var registro_ritiri_collection = registro_recupero_provider.GetCollectionReport(
                    lstProgrammazioneNew.SelectedValue,
                    nullable_id_progetto,
                    nullable_data_inizio_ricerca,
                    nullable_data_fine_ricerca,
                    28001,
                    true,
                    false);

                int salvato = 0;
                foreach (RegistroRecupero ritiro in registro_ritiri_collection)
                {
                    var dataCertificazione = Request.Form["DataCertificazioneRitiro" + ritiro.IdRegistroRecupero + "_text"];
                    if (dataCertificazione != null && !dataCertificazione.Equals(""))
                    {
                        ritiro.DataCertificazioneRitiro = dataCertificazione;
                        registro_recupero_provider.Save(ritiro);
                        salvato = 1;
                    }
                }

                if (salvato == 1)
                    ShowMessage("Date di certificazione salvate correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void cercaNonRecuperabili()
        {
            dgRegistroRecuperi.Visible = false;
            dgRegistroRitiri.Visible = false;
            divRegistroRitiri.Visible = false;
            dgRegistroNonRecuperabili.Visible = true;

            //var registro_non_recuperabili_collection = registro_recupero_provider.GetCollectionReport(
            //        lstProgrammazioneNew.SelectedValue,
            //        nullable_id_progetto,
            //        nullable_data_inizio_ricerca,
            //        nullable_data_fine_ricerca,
            //        null,
            //        false,
            //        false);

            //dgRegistroNonRecuperabili.DataSource = registro_non_recuperabili_collection;
            dgRegistroNonRecuperabili.DataSource = new VritiriRecuperiCollection();
            dgRegistroNonRecuperabili.SetTitoloNrElementi();
            dgRegistroNonRecuperabili.ItemDataBound += new DataGridItemEventHandler(dgRegistroNonRecuperabili_ItemDataBound);
            dgRegistroNonRecuperabili.DataBind();
        }

        protected void salvaNonRecuperabili()
        {
            try
            {
                popolaVariabiliRicerca();

                var registro_non_recuperabili_collection = registro_recupero_provider.GetCollectionReport(
                    lstProgrammazioneNew.SelectedValue,
                    nullable_id_progetto,
                    nullable_data_inizio_ricerca,
                    nullable_data_fine_ricerca,
                    null,
                    false,
                    false);

                int salvato = 0;
                foreach (RegistroRecupero non_recuperabile in registro_non_recuperabili_collection)
                {
                    var dataCertificazione = Request.Form["DataCertificazioneNonRecuperabilita" + non_recuperabile.IdRegistroRecupero + "_text"];
                    if (dataCertificazione != null && !dataCertificazione.Equals(""))
                    {
                        non_recuperabile.DataCertificazioneNonRecuperabilita = dataCertificazione;
                        registro_recupero_provider.Save(non_recuperabile);
                        salvato = 1;
                    }
                }

                if (salvato == 1)
                    ShowMessage("Date di certificazione salvate correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void popolaVariabiliRicerca()
        {
            registro_recupero_provider = new RegistroRecuperoCollectionProvider();

            int id_progetto;
            int.TryParse(hdnIdProgetto.Value, out id_progetto);
            if (id_progetto != 0)
                nullable_id_progetto = id_progetto;
            else
                nullable_id_progetto = null;

            lstTipoOrigine.SelectedValue = hdnTipoOrgine.Value;
            lstSoggettoRilevatore.SelectedValue = hdnSoggettoRilevatore.Value;
            lstTipoDetrazione.SelectedValue = hdnTipoDetrazione.Value;
            lstPeriodoContabile.SelectedValue = hdnPeriodoContabile.Value;


            //DateTime data_vuota = new DateTime(1, 1, 1);

            //DateTime data_inizio_ricerca = new DateTime(1753, 1, 1);
            //DateTime.TryParse(hdnDataInizioRicerca.Value, out data_inizio_ricerca);
            //if (!data_inizio_ricerca.Equals(data_vuota))
            //    nullable_data_inizio_ricerca = data_inizio_ricerca;
            //else
            //    nullable_data_inizio_ricerca = null;

            //DateTime data_fine_ricerca = new DateTime(9999, 12, 31);
            //DateTime.TryParse(hdnDataFineRicerca.Value, out data_fine_ricerca);
            //if (!data_fine_ricerca.Equals(data_vuota))
            //    nullable_data_fine_ricerca = data_fine_ricerca;
            //else
            //    nullable_data_fine_ricerca = null;
        }

        #region Button event

        protected void btnCerca_Click(object sender, EventArgs e)
        {
            try
            {
                hdnRicercaBool.Value = "1";
                hdnIdProgetto.Value = txtIdProgetto.Text;
                hdnTipoOrgine.Value = lstTipoOrigine.SelectedValue;
                hdnSoggettoRilevatore.Value = lstSoggettoRilevatore.SelectedValue;
                hdnTipoDetrazione.Value = lstTipoDetrazione.SelectedValue;
                hdnPeriodoContabile.Value = lstPeriodoContabile.SelectedValue;
                
                //hdnDataInizioRicerca.Value = txtDataInizioRicerca.Text;
                //hdnDataFineRicerca.Value = txtDataFineRicerca.Text;
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalvaRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                switch (tabReport.TabSelected)
                {
                    case tabRecuperi:
                        salvaRecuperi();
                        break;
                    case tabRitiri:
                        salvaRitiri();
                        break;
                    case tabNonRecuperabili:
                        salvaNonRecuperabili();
                        break;
                }
            }
            catch (Exception ex) { ShowError(ex); }
        }

        //protected void btnEsportaRegistro_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //    }
        //    catch (Exception ex) { ShowError(ex); }
        //}

        #endregion

        void dgRegistroRecuperi_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType == ListItemType.Header)
            {
                dgi.Cells[0].RowSpan = 2;
                dgi.Cells[1].ColumnSpan = 5;
                dgi.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                dgi.Cells[1].Text = "INTERVENTI</td><td colspan=3></td><td colspan=6 align=center>SPESA IRREGOLARE</td><td colspan=3></td><td colspan=7 align=center>SPESA RECUPERATA</td><td colspan=3></td></tr><tr class='TESTA'><td>";
            }
            else if (e.Item.ItemType != ListItemType.Footer)
            {
                RegistroRecupero rec = (RegistroRecupero)e.Item.DataItem;
                RegistroIrregolarita irr = null;
                if (rec.IdRegistroIrregolarita != null)
                    irr = new RegistroIrregolaritaCollectionProvider().GetById(rec.IdRegistroIrregolarita);

                if (rec.IdImpresa != null)
                {
                    var impresa = new ImpresaCollectionProvider().GetById(rec.IdImpresa);
                    if (impresa != null)
                        dgi.Cells[3].Text = impresa.RagioneSociale;
                }

                if (rec.IdAttoRecupero != null)
                {
                    var atto = new AttiCollectionProvider().GetById(rec.IdAttoRecupero);
                    var dec = atto.Numero.ToString() + '|' + atto.Data + '|' + atto.Registro;
                    e.Item.Cells[5].Text = "<a href=\"javascript:visualizzaAtto(" + atto.IdAtto + ");\">" + dec + "</a>";
                }

                if (irr != null)
                {
                    dgi.Cells[6].Text = e.Item.Cells[6].Text.Replace("<input", "<input checked");
                    if (irr.StabilitaOperazioni != null && irr.StabilitaOperazioni)
                        dgi.Cells[26].Text = e.Item.Cells[26].Text.Replace("<input", "<input checked");
                    else
                        dgi.Cells[26].Text = e.Item.Cells[26].Text.Replace("checked", "");
                }
                else
                {
                    dgi.Cells[6].Text = e.Item.Cells[6].Text.Replace("checked", "");
                    dgi.Cells[26].Text = e.Item.Cells[26].Text.Replace("checked", "");
                }

                if (rec.DataAvvio != null)
                {
                    DateTime dataAvvio = rec.DataAvvio;
                    DateTime dataInizioContabile = new DateTime(dataAvvio.Year, 7, 1);
                    DateTime dataFineContabile = new DateTime(dataAvvio.Year, 6, 30);
                    if (dataAvvio < dataInizioContabile)
                        dataInizioContabile = dataInizioContabile.AddYears(-1);
                    else
                        dataFineContabile = dataInizioContabile.AddYears(1);

                    dgi.Cells[7].Text = dataInizioContabile.ToString("dd/MM/yyyy") + " - " + dataFineContabile.ToString("dd/MM/yyyy");
                }
                else
                    dgi.Cells[7].Text = "";

                if (rec.DataCertificazioneRecupero != null && !rec.DataCertificazioneRecupero.Equals(""))
                {
                    string dataCert = "<input name=\"DataCertificazioneRecupero" + rec.IdRegistroRecupero + "_text\" id=\"DataCertificazioneRecupero" + rec.IdRegistroRecupero + "_text\" style=\"width: 80px; text-align: right;\" type=\"text\" value=\"" + rec.DataCertificazioneRecupero + "\">";
                    //dataCert += "<script> </script>";
                    dgi.Cells[8].Text = dataCert;
                }

                if (rec.ImportoDaRecuperareNazionale != null)
                {
                    var stato = rec.ImportoDaRecuperareNazionale * new Decimal(0.7);
                    var regione = rec.ImportoDaRecuperareNazionale * new Decimal(0.3);
                    dgi.Cells[10].Text = string.Format("{0:c}", stato);
                    dgi.Cells[11].Text = string.Format("{0:c}", regione);
                }
                else
                {
                    dgi.Cells[11].Text = "";
                    dgi.Cells[12].Text = "";
                }

                var sanzioni_collection = new SanzioniRecuperoCollectionProvider().GetByRegistroRecupero(rec.IdRegistroRecupero);
                if (sanzioni_collection.Count > 0)
                {
                    Decimal importo_sanzioni = new Decimal(0);
                    foreach (SanzioniRecupero sanz in sanzioni_collection)
                        if (sanz.ImportoSanzione != null && !sanz.ImportoSanzione.Equals(""))
                            importo_sanzioni += sanz.ImportoSanzione;
                    dgi.Cells[18].Text = string.Format("{0:c}", importo_sanzioni);
                }
                else
                    dgi.Cells[18].Text = "";

                if (rec.ImportoRecuperatoNazionale != null)
                {
                    var stato = rec.ImportoRecuperatoNazionale * new Decimal(0.7);
                    var regione = rec.ImportoRecuperatoNazionale * new Decimal(0.3);
                    dgi.Cells[20].Text = string.Format("{0:c}", stato);
                    dgi.Cells[21].Text = string.Format("{0:c}", regione);
                }
                else
                {
                    dgi.Cells[20].Text = "";
                    dgi.Cells[21].Text = "";
                }

                if (rec.Storico != null && rec.Storico && rec.ImportoDaRecuperareTotale != null && rec.ImportoRecuperatoTotale != null)
                    dgi.Cells[27].Text = string.Format("{0:c}", rec.ImportoDaRecuperareTotale - rec.ImportoRecuperatoTotale);
                else
                    dgi.Cells[27].Text = "";
            }
        }

        void dgRegistroRitiri_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType == ListItemType.Header)
            {
                dgi.Cells[0].ColumnSpan = 3;
                dgi.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                dgi.Cells[0].Text = "INTERVENTO</td><td colspan=9 align=center>RITIRO</td><td colspan=1 align=center>SPESA CORRISPONDENTE</td><td colspan=4 align=center>SPESA RECUPERATA</td><tr class='TESTA'><td>Asse";
            }
            else if (e.Item.ItemType != ListItemType.Footer)
            {
                VregistroRitiriRecuperi rec = (VregistroRitiriRecuperi)e.Item.DataItem;

                if(lstPeriodoContabile.SelectedValue == null)
                {
                    bool pari = new VregistroRitiriRecuperiCollectionProvider().getRigaPeriodoContabile(lstProgrammazioneNew.SelectedValue, nullable_id_progetto, "RITIRO", lstTipoOrigine.SelectedValue, lstSoggettoRilevatore.SelectedValue, lstTipoDetrazione.SelectedValue, rec.PeriodoContabile);
                    if(pari)
                        dgi.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
                    else
                        dgi.BackColor = System.Drawing.Color.FromArgb(208, 208, 208);
                }

            }
        }

        void dgRegistroNonRecuperabili_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType == ListItemType.Header)
            {
                dgi.Cells[0].RowSpan = 2;
                dgi.Cells[1].ColumnSpan = 5;
                dgi.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                dgi.Cells[1].Text = "INTERVENTI</td><td colspan=3></td><td colspan=11 align=center>NON RECUPERABILI</td></tr><tr class='TESTA'><td>";
            }
            else if (e.Item.ItemType != ListItemType.Footer)
            {
                RegistroRecupero rec = (RegistroRecupero)e.Item.DataItem;
                RegistroIrregolarita irr = null;
                if (rec.IdRegistroIrregolarita != null)
                    irr = new RegistroIrregolaritaCollectionProvider().GetById(rec.IdRegistroIrregolarita);

                if (rec.IdImpresa != null)
                {
                    var impresa = new ImpresaCollectionProvider().GetById(rec.IdImpresa);
                    if (impresa != null)
                        dgi.Cells[3].Text = impresa.RagioneSociale;
                }

                if (rec.IdAttoRecupero != null)
                {
                    var atto = new AttiCollectionProvider().GetById(rec.IdAttoRecupero);
                    var dec = atto.Numero.ToString() + '|' + atto.Data + '|' + atto.Registro;
                    e.Item.Cells[5].Text = "<a href=\"javascript:visualizzaAtto(" + atto.IdAtto + ");\">" + dec + "</a>";
                }

                if (irr != null)
                    dgi.Cells[6].Text = e.Item.Cells[6].Text.Replace("<input", "<input checked");
                else
                    dgi.Cells[6].Text = e.Item.Cells[6].Text.Replace("checked", "");

                if (rec.DataAvvio != null)
                {
                    DateTime dataAvvio = rec.DataAvvio;
                    DateTime dataInizioContabile = new DateTime(dataAvvio.Year, 7, 1);
                    DateTime dataFineContabile = new DateTime(dataAvvio.Year, 6, 30);
                    if (dataAvvio < dataInizioContabile)
                        dataInizioContabile = dataInizioContabile.AddYears(-1);
                    else
                        dataFineContabile = dataInizioContabile.AddYears(1);

                    dgi.Cells[7].Text = dataInizioContabile.ToString("dd/MM/yyyy") + " - " + dataFineContabile.ToString("dd/MM/yyyy");
                }
                else
                    dgi.Cells[7].Text = "";

                if (rec.DataCertificazioneNonRecuperabilita != null && !rec.DataCertificazioneNonRecuperabilita.Equals(""))
                {
                    string dataCert = "<input name=\"DataCertificazioneNonRecuperabilita" + rec.IdRegistroRecupero + "_text\" id=\"DataCertificazioneNonRecuperabilita" + rec.IdRegistroRecupero + "_text\" style=\"width: 80px; text-align: right;\" type=\"text\" value=\"" + rec.DataCertificazioneNonRecuperabilita + "\">";
                    //dataCert += "<script> </script>";
                    dgi.Cells[8].Text = dataCert;
                }

                if (rec.ImportoDaRecuperareNazionale != null)
                {
                    var stato = rec.ImportoDaRecuperareNazionale * new Decimal(0.7);
                    var regione = rec.ImportoDaRecuperareNazionale * new Decimal(0.3);
                    dgi.Cells[10].Text = string.Format("{0:c}", stato);
                    dgi.Cells[11].Text = string.Format("{0:c}", regione);
                }
                else
                {
                    dgi.Cells[11].Text = "";
                    dgi.Cells[12].Text = "";
                }

                if (rec.IdAttoNonRecuperabilita != null)
                {
                    var atto = new AttiCollectionProvider().GetById(rec.IdAttoNonRecuperabilita);
                    var dec = atto.Numero.ToString() + '|' + atto.Data + '|' + atto.Registro;
                    e.Item.Cells[18].Text = "<a href=\"javascript:visualizzaAtto(" + atto.IdAtto + ");\">" + dec + "</a>";
                }
                else
                    e.Item.Cells[18].Text = "";
            }
        }
    }
}