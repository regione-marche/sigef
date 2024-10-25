using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarBLL;
using SiarLibrary;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Collections.Generic;

namespace web.Private.CertificazioneSpesa
{
    public partial class CertificazioneRendicontazione : SiarLibrary.Web.PrivatePage
    {
        VcertrendicontazioneCollection detSel1 = new VcertrendicontazioneCollection();
        VcertrendicontazioneCollectionProviderPartial tstProv = new VcertrendicontazioneCollectionProviderPartial();
        VcertrendicontazioneCollectionProvider tst = new VcertrendicontazioneCollectionProvider();
        public enum TipoDomande
        {
            Tutte, SelezionateSi, SelezionateNo, ChecklistSi, ChecklistNo,
            Asse1, Asse2, Asse3, Asse4, Asse5, Asse6, Asse7
        }

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "certificazione_di_rendicontazione";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        { }

        protected override void OnPreRender(EventArgs e)
        {
            lstPsr.DataBind();
            //visualizzaTesta();
            visualizzaDettaglio();

            base.OnPreRender(e);
        }

        private void visualizzaDettaglio()
        {
            const int cElenco = 1,
                      cDati = 2;

            //lstPsr.DataBind();
            if (!IsPostBack) dgDettaglio.Titolo = "Specificare i parametri di ricerca.";
            else
            {
             divDettaglio.Visible = true;
                //ufTstChecklist.IdFile = tstSel.IdFile;
                //AbilitaOggettiDettaglio();

                switch (tabDettaglio.TabSelected)
                {
                    case cElenco:
                        visualizzaDettaglioElenco( lstPsr.SelectedValue);
                        break;
                    case cDati:
                        //detSel = null;
                        visualizzaDettaglioDati(lstPsr.SelectedValue);
                        break;
                }
            }
        }

        private void visualizzaDettaglioElenco( string SelectedValue)
        {
            detSel1 = tst.Find(lstPsr.SelectedValue);
            lblNrRecord.Text= string.Format("Visualizzate {0} righe", detSel1.Count.ToString());
            //dgDettaglio.Titolo = string.Format("Visualizzate {0} righe", detSel1.Count.ToString());
            //visualizzaDettaglio(dataInizio, dataFine, lstPsr.SelectedValue);
            dgDettaglio.DataSource = detSel1;
            //dgBandi.DataBind();
            dgDettaglio.DataBind();
            divDettaglioElenco.Visible = true;
        }
        private void visualizzaDettaglioDati( string SelectedValue)
        {
            sommaDettagli(lstPsr.SelectedValue);
            //StrumentiFinanziari();
            //AnticipiVersati();

            divDettaglioElenco.Visible = false;
            divDettaglioDati.Visible = true;
        }
       
        private void sommaDettagli( string SelectedValue)
        {
            const string strForma = "{0:c}",
                             SpesaInc = "ImportoConcesso",
                             ContrInc = "ImportoContributoPubblico";

            VcertrendicontazioneCollectionProviderPartial tstProv = new VcertrendicontazioneCollectionProviderPartial();

            DatiRiassuntiviRendicontazioneCollection detSell = new DatiRiassuntiviRendicontazioneCollection();




            detSell = tstProv.SommaImporti(SelectedValue, null, null, null);
            string strTb = "";
            string strRiga = "";
            if (detSell == null)
            {
                //setVisible();
                //carmine detElenco.no_dettaglio.Visible = true;
                //detElenco.si_dettaglio.Visible = false;
            }
            else
            {
            //detElenco.DataGrid1.DataSource = detSell;
            //detElenco.DataGrid1.DataBind();
            if (detSell.Count > 0)
            {
             strTb = "<div class=\"dContenuto\">" +
                        " <label class=\"active fw-semibold fst-italic pt-5\" for=\"tblDettaglioDati\">Spesa suddivisa per priorità e per categoria di regioni, come contabilizzata dall'autorità di certificazione</label>" +
                "<table id=\"tblDettaglioDati\" width=\"100% \" runat=\"server\"  class=\"table table-striped\"  clientidmode=\"Static\"><tr class=\"TESTA1\" >" +
                "<th>" +
                "</th>" +
                "<th>" +
                "Asse" +
                "</th>" +
                "<th>" +
                "Importo ammesso rendicontato (di cui all'istruttoria della domanda di pagamento)" +
                "</th>" +
                "<th>" +
                "Contributo concesso rendicontato UE" +
                "</th>" +
                "<th>" +
                "Contributo concesso rendicontato dello Stato" +
                "</th>" +
                "<th>" +
                "Contributo concesso rendicontato della Regione" +
                "</th>" +
                "<th>" +
                "Importo Privato" +
                "</th></tr>";
                    int i = 1;


                    foreach (SiarLibrary.DatiRiassuntiviRendicontazione r in detSell)
                    {

                        string sImpAmmesso = string.Format(strForma, r.ImportoAmmesso);
                        string sContrUE = string.Format(strForma, r.ContributoUE);
                        string sContrStato = string.Format(strForma, r.ContributoStato);
                        string sContrReg = string.Format(strForma, r.ContributoRegione);
                        string sImpPrivato = string.Format(strForma, r.ImportoPrivato);
                        string vDettaglio = r.Dettaglio;
                        string sEspandibile = "details-control";
                        if (string.IsNullOrEmpty(vDettaglio))
                        {
                            sEspandibile = "stop-details-control";
                        }
    
                        strRiga +=
                            " <tr class=\"DataGridRowAlt\"  style=\"text-align: center; font-size: small;\">" +
                             "<td id = '"+i+"' onclick=\"selezionaRaggruppamento(0, "+ i + ", null, null, null, this); \" class=\""+ sEspandibile+"\" style=\" text-align: center; min-width: 50px;\">" +
                            " </td>" +
                            "<td class=\"asse fw-semibold\" style=\" text-align: center; font-size: small; min-width: 50px;\">" +
                            "Asse "+i+"" +
                            " </td>" +
                            "<td class=\"fw-semibold\" style=\"padding: 5px;text-align: center; font-size: small;\">" +
                               sImpAmmesso +
                            "</td>" +
                            "<td class=\"fw-semibold\" style=\"padding: 5px; text-align: center; font-size: small;  \">" +
                                sContrUE +
                            "</td>" +
                            "<td class=\"fw-semibold\" style=\"padding: 5px; text-align: center;font-size: small; \">" +
                                 sContrStato +
                            "</td>" +
                            "<td class=\"fw-semibold\" style=\"padding: 5px; text-align: center;font-size: small;\">" +
                                 sContrReg +
                            "</td>" +
                            "<td class=\"fw-semibold\" style=\"padding: 5px; text-align: center; font-size: small; \">" +
                                 sImpPrivato +
                            "</td>" +
                            "</tr>";
                        i++;


                    }
                }

            }

            string strTable= strTb + strRiga + "<tr></tr></table></div>";
            //aggiungo una riga  vuota come ultima riga perhè altrimenti non funziona l'inserimento di del dettaglio cliccando su rig asse 7 o ultimo asse.
            divDettaglioDati.InnerHtml = strTable;           
            divDettaglioDati.Visible = true;
        }


        [System.Web.Services.WebMethod]
        public static string SommaperTipoRagggruppamento( string selectedValue, string asse, string azione, string intervento)
        {
            VcertrendicontazioneCollectionProviderPartial tstProv = new VcertrendicontazioneCollectionProviderPartial();
            DatiRiassuntiviRendicontazione spAmm1 = new DatiRiassuntiviRendicontazione();
            DatiRiassuntiviRendicontazioneCollection detSell = new DatiRiassuntiviRendicontazioneCollection();
            CertificazioneRendicontazione detElenco = new CertificazioneRendicontazione();

            string json= "";
            if (azione == "null")
                azione = null;
            if (intervento == "null")
                intervento = null;
            detSell = tstProv.SommaImporti(selectedValue, asse,azione, intervento);
            if (detSell == null)
            {
                //setVisible();
                //carmine detElenco.no_dettaglio.Visible = true;
                //detElenco.si_dettaglio.Visible = false;
            }
            else
            {
                //detElenco.DataGrid1.DataSource = detSell;
                //detElenco.DataGrid1.DataBind();
                if (detSell.Count > 0)
                {
                    json = "'" + detSell.ConvertToJSonObject() + "';";
                    //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "jsonTipoIrregolarita", json, true);
                }
            }
            return json;
        }

        
        public static void setVisible()
        {
            CertificazioneRendicontazione form = new CertificazioneRendicontazione();
        }



        

    }
}
