using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.CertificazioneSpesa
{
    public partial class CertificazioneSpesa : SiarLibrary.Web.CertificazioneSpesaPage
    {
        SiarBLL.DomandaDiPagamentoCollectionProvider domande_provider = new SiarBLL.DomandaDiPagamentoCollectionProvider();

        decimal tot_contributo_richiesto     = 0, 
                tot_contributo_ammesso       = 0, 
                tot_contributo_pagato        = 0,
                tot_contributo_richiesto_str = 0, 
                tot_contributo_ammesso_str   = 0, 
                tot_contributo_pagato_str    = 0,
                tot_contributo_richiesto_ant = 0, 
                tot_contributo_ammesso_ant   = 0, 
                tot_contributo_pagato_ant    = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DateTime d = new DateTime(DateTime.Now.Year - 1, 6, 1);
                if (DateTime.Now.Month > 6)
                {
                    d.AddYears(1);
                }
                txtDataInizio.Text = d.Date.ToString("dd/MM/yyyy");
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            lstPsr.DataBind();
            
            SiarLibrary.NullTypes.DatetimeNT data_inizio = null;
            SiarLibrary.NullTypes.DatetimeNT data_fine   = null;

            if (!string.IsNullOrEmpty(txtDataInizio.Text))
            {
              data_inizio = new SiarLibrary.NullTypes.DatetimeNT(txtDataInizio.Text);
            }

            if (!string.IsNullOrEmpty(txtDataFine.Text))
            {
              data_fine = new SiarLibrary.NullTypes.DatetimeNT(txtDataFine.Text);
            }

            if (!string.IsNullOrEmpty(lstPsr.SelectedValue))
            {
                //btnEstraiSpese.Attributes.Add("onclick", "SNCVisualizzaReport('SpCertspGetRiepilogoSpeseXAsse',2,'CodPsr=" + lstPsr.SelectedValue + "')");

                dgSpese.DataSource = domande_provider.GetSpesePubblichePrivate(lstPsr.SelectedValue, null, data_inizio, data_fine);
                dgSpese.Titolo = "Elementi trovati: " + ((SiarLibrary.CustomCollection)dgSpese.DataSource).Count.ToString();
                dgSpese.ItemDataBound += new DataGridItemEventHandler(dgSpese_ItemDataBound);
                dgSpese.DataBind();

                //dgSpeseStrumentiFinanziari.DataSource = domande_provider.GetRiepilogoSpeseXAsse(lstPsr.SelectedValue, null, null, data_inizio, data_fine);
                dgSpeseStrumentiFinanziari.DataSource = domande_provider.GetStrumentiFinanziari(lstPsr.SelectedValue, null, null, data_inizio, data_fine);
                dgSpeseStrumentiFinanziari.Titolo = "Elementi trovati: " + ((SiarLibrary.CustomCollection)dgSpese.DataSource).Count.ToString();
                dgSpeseStrumentiFinanziari.ItemDataBound += new DataGridItemEventHandler(dgSpeseStrumentiFinanziari_ItemDataBound);
                dgSpeseStrumentiFinanziari.DataBind();

                dgSpeseAnticipi.DataSource = domande_provider.GetAnticipiAiutiDiStato(lstPsr.SelectedValue, null);
                dgSpeseAnticipi.Titolo = "Elementi trovati: " + ((SiarLibrary.CustomCollection)dgSpese.DataSource).Count.ToString();
                dgSpeseAnticipi.ItemDataBound += new DataGridItemEventHandler(dgSpeseAnticipi_ItemDataBound);
                dgSpeseAnticipi.DataBind();
            }
            base.OnPreRender(e);
        }

        void dgSpese_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            const int cNume = 0,
                      cAsse = 1,
                      cBase = 2,
                      cAmmi = 3,
                      cPubb = 4;

            if (e.Item.ItemType != ListItemType.Footer && e.Item.ItemType != ListItemType.Header)
            {
                SiarLibrary.Zprogrammazione d = (SiarLibrary.Zprogrammazione)e.Item.DataItem;

                tot_contributo_ammesso += decimal.Parse(d.AdditionalAttributes["CONTRIBUTO_AMMISSIBILE_TOTALE"]);
                tot_contributo_pagato += decimal.Parse(d.AdditionalAttributes["CONTRIBUTO_PAGATO_TOTALE"]);

                e.Item.Cells[cAsse].Text = d.AdditionalAttributes["ASSE"];
                e.Item.Cells[cBase].Text = "PUBBLICO";
                e.Item.Cells[cAmmi].Text = string.Format("{0:c}", decimal.Parse(d.AdditionalAttributes["CONTRIBUTO_AMMISSIBILE_TOTALE"]));
                e.Item.Cells[cPubb].Text = string.Format("{0:c}", decimal.Parse(d.AdditionalAttributes["CONTRIBUTO_PAGATO_TOTALE"]));
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[cNume].Text = "Totale";
                e.Item.Cells[cBase].Text = string.Format("{0:c}", tot_contributo_richiesto);
                e.Item.Cells[cAmmi].Text = string.Format("{0:c}", tot_contributo_ammesso);
                e.Item.Cells[cPubb].Text = string.Format("{0:c}", tot_contributo_pagato);
            }
        }

        void dgSpeseStrumentiFinanziari_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            const int cNume = 0,
                      cAsse = 1,
                      cStrf = 2,
                      cSfpb = 3,
                      cComp = 4;

            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[cNume].ColumnSpan = 2;
                e.Item.Cells[cNume].HorizontalAlign = HorizontalAlign.Center;
                e.Item.Cells[cNume].Text = " </td><td colspan='2' align=center>Importi dei contributi per programma erogati agli strumenti finanziari e inclusi nelle domande di pagamento</td><td colspan='2' align=center>Importi erogati a titolo di spesa ammissibile ai sensi dell'articolo 42, paragrafo 1, lettere a), b) e d), del regolamento (UE) n. 1303/2013</td></tr><tr class='TESTA'><td>Nr.";
            } 
            else if (e.Item.ItemType != ListItemType.Footer && e.Item.ItemType != ListItemType.Header)
            {
                SiarLibrary.Zprogrammazione d = (SiarLibrary.Zprogrammazione)e.Item.DataItem;

                tot_contributo_richiesto_str += decimal.Parse(d.AdditionalAttributes["CONTRIBUTO_RICHIESTO_TOTALE"]);
                tot_contributo_ammesso_str += decimal.Parse(d.AdditionalAttributes["CONTRIBUTO_AMMESSO_TOTALE"]);
                tot_contributo_pagato_str += decimal.Parse(d.AdditionalAttributes["CONTRIBUTO_PAGATO_TOTALE"]);

                e.Item.Cells[cAsse].Text = d.AdditionalAttributes["ASSE"];
                e.Item.Cells[cStrf].Text = string.Format("{0:c}", decimal.Parse(d.AdditionalAttributes["CONTRIBUTO_RICHIESTO_TOTALE"]));
                e.Item.Cells[cSfpb].Text = string.Format("{0:c}", decimal.Parse(d.AdditionalAttributes["CONTRIBUTO_AMMESSO_TOTALE"]));
                e.Item.Cells[cComp].Text = string.Format("{0:c}", decimal.Parse(d.AdditionalAttributes["CONTRIBUTO_PAGATO_TOTALE"]));
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[cNume].Text = "Totale";
                e.Item.Cells[cStrf].Text = string.Format("{0:c}", tot_contributo_richiesto_str);
                e.Item.Cells[cSfpb].Text = string.Format("{0:c}", tot_contributo_ammesso_str);
                e.Item.Cells[cComp].Text = string.Format("{0:c}", tot_contributo_pagato_str);
            }
        }

        void dgSpeseAnticipi_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            const int cNume = 0,
                      cAsse = 1,
                      cAnti = 2,
                      cCope = 3,
                      cScop = 4;

            if (e.Item.ItemType != ListItemType.Footer && e.Item.ItemType != ListItemType.Header)
            {
                SiarLibrary.Zprogrammazione d = (SiarLibrary.Zprogrammazione)e.Item.DataItem;

                tot_contributo_richiesto_ant += decimal.Parse(d.AdditionalAttributes["ANTICIPI"]);
                tot_contributo_ammesso_ant += decimal.Parse(d.AdditionalAttributes["IMPORTO_COPERTO_ANTICIPI"]);
                tot_contributo_pagato_ant += decimal.Parse(d.AdditionalAttributes["DISAVANZO"]);

                e.Item.Cells[cAsse].Text = d.AdditionalAttributes["ASSE"];
                e.Item.Cells[cAnti].Text = string.Format("{0:c}", decimal.Parse(d.AdditionalAttributes["ANTICIPI"]));
                e.Item.Cells[cCope].Text = string.Format("{0:c}", decimal.Parse(d.AdditionalAttributes["IMPORTO_COPERTO_ANTICIPI"]));
                e.Item.Cells[cScop].Text = string.Format("{0:c}", decimal.Parse(d.AdditionalAttributes["DISAVANZO"]));
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[cNume].Text = "Totale";
                e.Item.Cells[cAnti].Text = string.Format("{0:c}", tot_contributo_richiesto_ant);
                e.Item.Cells[cCope].Text = string.Format("{0:c}", tot_contributo_ammesso_ant);
                e.Item.Cells[cScop].Text = string.Format("{0:c}", tot_contributo_pagato_ant);
            }
        }

        protected void btnCerca_Click(object sender, EventArgs e)
        {
            dgSpese.SetPageIndex(0);
        }
    }
}
