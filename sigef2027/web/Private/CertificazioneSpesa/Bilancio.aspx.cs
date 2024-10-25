using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.CertificazioneSpesa
{
    public partial class Bilancio : SiarLibrary.Web.CertificazioneSpesaPage
    {
        SiarBLL.DomandaDiPagamentoCollectionProvider domande_provider = new SiarBLL.DomandaDiPagamentoCollectionProvider();

        protected override void OnPreRender(EventArgs e)
        {
            dgImportiRegistrati.DataSource = domande_provider.GetRiepilogoSpeseXAsse("POR20142020", null, null, null, null);
            dgImportiRegistrati.Titolo = "Elementi trovati: " + ((SiarLibrary.CustomCollection)dgImportiRegistrati.DataSource).Count.ToString();
            dgImportiRegistrati.ItemDataBound += new DataGridItemEventHandler(dgImportiRegistrati_ItemDataBound);
            dgImportiRegistrati.DataBind();

            dgImportiRitirati.DataSource = domande_provider.GetRiepilogoSpeseXAsse("POR20142020", null, null, null, null);
            dgImportiRitirati.Titolo = "Elementi trovati: " + ((SiarLibrary.CustomCollection)dgImportiRitirati.DataSource).Count.ToString();
            dgImportiRitirati.ItemDataBound += new DataGridItemEventHandler(dgImportiRitirati_ItemDataBound);
            dgImportiRitirati.DataBind();

            dgImportiDaRecuperare.DataSource = domande_provider.GetRiepilogoSpeseXAsse("POR20142020", null, null, null, null);
            dgImportiDaRecuperare.Titolo = "Elementi trovati: " + ((SiarLibrary.CustomCollection)dgImportiDaRecuperare.DataSource).Count.ToString();
            dgImportiDaRecuperare.ItemDataBound += new DataGridItemEventHandler(dgImportiRegistrati_ItemDataBound);
            dgImportiDaRecuperare.DataBind();

            dgRecuperiEffettuati.DataSource = domande_provider.GetRiepilogoSpeseXAsse("POR20142020", null, null, null, null);
            dgRecuperiEffettuati.Titolo = "Elementi trovati: " + ((SiarLibrary.CustomCollection)dgRecuperiEffettuati.DataSource).Count.ToString();
            dgRecuperiEffettuati.ItemDataBound += new DataGridItemEventHandler(dgRecuperiEffettuati_ItemDataBound);
            dgRecuperiEffettuati.DataBind();

            dgImportiIrrecuperabili.DataSource = domande_provider.GetRiepilogoSpeseXAsse("POR20142020", null, null, null, null);
            dgImportiIrrecuperabili.Titolo = "Elementi trovati: " + ((SiarLibrary.CustomCollection)dgImportiIrrecuperabili.DataSource).Count.ToString();
            dgImportiIrrecuperabili.ItemDataBound += new DataGridItemEventHandler(dgImportiIrrecuperabili_ItemDataBound);
            dgImportiIrrecuperabili.DataBind();  
 
            dgStrumentiFinanziari.DataSource = domande_provider.GetRiepilogoSpeseXAsse("POR20142020", null, null, null, null);
            dgStrumentiFinanziari.Titolo = "Elementi trovati: " + ((SiarLibrary.CustomCollection)dgStrumentiFinanziari.DataSource).Count.ToString();
            dgStrumentiFinanziari.ItemDataBound += new DataGridItemEventHandler(dgStrumentiFinanziari_ItemDataBound);
            dgStrumentiFinanziari.DataBind();  

            dgAnticipiAiutiStato.DataSource = domande_provider.GetRiepilogoSpeseXAsse("POR20142020", null, null, null, null);
            dgAnticipiAiutiStato.Titolo = "Elementi trovati: " + ((SiarLibrary.CustomCollection)dgAnticipiAiutiStato.DataSource).Count.ToString();
            dgAnticipiAiutiStato.ItemDataBound += new DataGridItemEventHandler(dgImportiRegistrati_ItemDataBound);
            dgAnticipiAiutiStato.DataBind();  

            dgRiconciliazioneSpese.DataSource = domande_provider.GetRiepilogoSpeseXAsse("POR20142020", null, null, null, null);
            dgRiconciliazioneSpese.Titolo = "Elementi trovati: " + ((SiarLibrary.CustomCollection)dgRiconciliazioneSpese.DataSource).Count.ToString();
            dgRiconciliazioneSpese.ItemDataBound += new DataGridItemEventHandler(dgRiconciliazioneSpese_ItemDataBound);
            dgRiconciliazioneSpese.DataBind();  

            base.OnPreRender(e);
        }

        void dgImportiRegistrati_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
        }

        void dgImportiRitirati_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[0].ColumnSpan = 2;
                e.Item.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Item.Cells[0].Text = " </td><td colspan='2' align=center>RITIRI</td><td colspan='2' align=center>RECUPERI</td></tr><tr class='TESTA'><td>Nr.";
            }
        }

        void dgRecuperiEffettuati_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[0].ColumnSpan = 2;
                e.Item.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Item.Cells[0].Text = " </td><td colspan='2' align=center>RECUPERI</td></tr><tr class='TESTA'><td>Nr.";
            }
        }

        void dgImportiIrrecuperabili_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[0].ColumnSpan = 2;
                e.Item.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Item.Cells[0].Text = " </td><td colspan='3' align=center>IMPORTI IRRECUPERABILI</td></tr><tr class='TESTA'><td>Nr.";
            }
        }

        void dgStrumentiFinanziari_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[0].ColumnSpan = 2;
                e.Item.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Item.Cells[0].Text = " </td><td colspan='2' align=center>Importi dei contributi per programma erogati agli strumenti finanziari e inclusi nelle domande di pagamento</td><td colspan='2' align=center>Importi erogati a titolo di spesa ammissibile ai sensi dell'articolo 42, paragrafo 1, lettere a), b) e d), del regolamento (UE) n. 1303/2013</td></tr><tr class='TESTA'><td>Nr.";
            }
        }

        void dgRiconciliazioneSpese_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[0].ColumnSpan = 2;
                e.Item.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Item.Cells[0].Text = " </td><td colspan='2' align=center>Spesa totale ammissibile inclusa nelle domande di pagamento presentate alla Commissione</td><td colspan='2' align=center>Spesa dichiarata conformemente all'articolo 137, paragrafo 1, lettera a), del regolamento (UE) n. 1303/2013</td><td colspan='2' align=center>Differenza</td><td align=center>Osservazioni (obbligatorie in caso di differenza)</td></tr><tr class='TESTA'><td>Nr.";
            }
        }
    }
}
