using SiarBLL;
using System;
using System.Collections;
using System.Web.UI.WebControls;

namespace web.Private.Istruttoria
{
    public partial class RapportoIstruttorio : SiarLibrary.Web.IstruttoriaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "ammissibilita_domande";
            base.OnPreInit(e);
        }

        SiarBLL.GraduatoriaProgettiCollectionProvider punteggio_provider = new SiarBLL.GraduatoriaProgettiCollectionProvider();
        ArrayList province_abilitate = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            ucFirmaRapportoIstruttorio.DocumentoFirmatoEvent = btnPostBack_Click;
        }

        protected override void OnPreRender(EventArgs e)
        {
            SiarLibrary.BandoResponsabiliCollection responsabili = new SiarBLL.BandoResponsabiliCollectionProvider().Find( Bando.IdBando,
               Operatore.Utente.IdUtente, null, false, true);
            //SiarLibrary.ResponsabiliXBandoCollection responsabili = new SiarBLL.ResponsabiliXBandoCollectionProvider().Find(null, Bando.IdBando,
            //    ((SiarLibrary.Web.MasterPage)Master).Operatore.Utente.CfUtente, null, null).FiltroProvincia(null, false);
            foreach (SiarLibrary.BandoResponsabili r in responsabili) province_abilitate.Add(r.Provincia);

            SiarBLL.VistruttoriaDomandeCollectionProvider istruttoria_provider = new SiarBLL.VistruttoriaDomandeCollectionProvider();
            SiarLibrary.VistruttoriaDomandeCollection progetti_istruiti = istruttoria_provider.Find(Bando.IdBando, null, null, lstProvincia.SelectedValue,
                null, null, null, "A", null);
            progetti_istruiti.AddCollection(istruttoria_provider.Find(Bando.IdBando, null, null, lstProvincia.SelectedValue, null, null, null, "B", null));
            dg.DataSource = progetti_istruiti;
            dg.ItemDataBound += new DataGridItemEventHandler(dg_ItemDataBound);
            dg.DataBind();
            int istruttorie_competenza = 0, istruttorie_totali = 0;
            foreach (SiarLibrary.VistruttoriaDomande v in progetti_istruiti)
                if (v.SegnaturaRi == null)
                {
                    istruttorie_totali++;
                    if (AbilitaModifica && province_abilitate.Contains(v.ProvinciaAssegnazione)) istruttorie_competenza++;
                }
            lblTotali.Text = istruttorie_totali.ToString();
            lblCompetenza.Text = istruttorie_competenza.ToString();
            lstProvincia.DataBind();
            base.OnPreRender(e);
        }

        void dg_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.VistruttoriaDomande progetto = (SiarLibrary.VistruttoriaDomande)e.Item.DataItem;
                e.Item.Cells[1].Text = "NUMERO: <b>" + progetto.IdProgetto + "</b>&nbsp;&nbsp;-&nbsp;&nbsp; Partita iva/Codice fiscale: <b>" + progetto.Cuaa
                    + "<br />Rag.soc:</b> " + progetto.RagioneSociale + "<br /><b>Sede:</b> " + progetto.Comune + " ("
                    + progetto.Sigla + ") - " + progetto.Cap;
                if (progetto.SegnaturaRi != null)
                    e.Item.Cells[4].Text = "<input type='text' disabled=disabled value='" + progetto.SegnaturaRi
                        + "' style='width:220px' /><input type='button' class='ButtonGrid' value='Apri' onclick=\"sncAjaxCallVisualizzaProtocollo('"
                        + progetto.SegnaturaRi + "');\" style='width:45px' />";
                else if (AbilitaModifica && province_abilitate.Contains(progetto.ProvinciaAssegnazione))
                    e.Item.Cells[4].Text = "<input type='button' class='ButtonGrid' value='Firma e protocolla' onclick=\"firmaDocumento("
                        + progetto.IdProgetto + ");\" />";
            }
        }

        protected void btnFirmaRapporto_Click(object sender, EventArgs e)
        {
            try
            {
                int id_progetto;
                if (!int.TryParse(hdnIdProgetto.Value, out id_progetto))
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk per segnalare il problema.");
                SiarLibrary.Progetto p = new SiarBLL.ProgettoCollectionProvider().GetById(id_progetto);
                if (p == null) throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk per segnalare il problema.");
                SiarLibrary.GraduatoriaProgetti punteggio = punteggio_provider.GetById(Bando.IdBando, id_progetto);
                if (punteggio == null && p.CodStato == "A") throw new Exception("Il punteggio della domanda non è ancora stato calcolato. Impossibile continuare.");
                ucFirmaRapportoIstruttorio.loadDocumento(((SiarLibrary.Web.MasterPage)Master).Operatore.Utente.CfUtente, id_progetto.ToString());
            }
            catch (Exception ex) { ShowError(ex); }

        }

        protected void btnPostBack_Click(object sender, EventArgs e)
        {
            try
            {
                int id_progetto;
                if (string.IsNullOrEmpty(ucFirmaRapportoIstruttorio.FileFirmato))
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk per segnalare il problema.");
                if (int.TryParse(hdnIdProgetto.Value, out id_progetto))
                {
                    SiarLibrary.Progetto progetto = new SiarBLL.ProgettoCollectionProvider().GetById(id_progetto);
                    if (progetto != null)
                    {
                        SiarBLL.ProgettoStoricoCollectionProvider storico_provider = new SiarBLL.ProgettoStoricoCollectionProvider();
                        SiarLibrary.ProgettoStorico stato;
                        if (progetto.CodStato == "A" || progetto.CodStato == "B") stato = storico_provider.GetById(progetto.IdStoricoUltimo);
                        else //La domanda selezionata non si trova nello stato necessario alla firma del rapporto istruttorio.
                        {
                            SiarLibrary.ProgettoStoricoCollection stati = storico_provider.Find(progetto.IdProgetto, null, "A");
                            if (stati.Count > 0) stato = stati[0];
                            else throw new Exception("La domanda selezionata non si trova nello stato necessario alla firma del rapporto istruttorio.");
                        }
                        if (stato.SegnaturaRi == null)
                        {
                            SiarLibrary.Protocollo rapporto = new SiarLibrary.Protocollo(Bando.CodEnte);
                            rapporto.setDocumento("rapporto_istruttorio_domanda_nr_" + progetto.IdProgetto + ".pdf", Convert.FromBase64String(ucFirmaRapportoIstruttorio.FileFirmato));

                            string[] ss = new SiarBLL.BandoCollectionProvider().GetDatiXProtocollazione(Bando.IdBando, progetto.ProvinciaDiPresentazione);
                            var impresa = new SiarBLL.ImpresaCollectionProvider().GetById(progetto.IdImpresa);
                            string oggetto = "Rapporto istruttorio domanda di aiuto nr. " + progetto.IdProgetto
                               + " in risposta al bando: " + ss[0] + " del " + ss[1] + " con scadenza: "
                               + Bando.DataScadenza + "\n " + ss[3] 
                               + "\n Partita iva/Codice fiscale: " + impresa.Cuaa
                               + "\n Ragione sociale: " + impresa.RagioneSociale;

                            string identificativo_paleo = rapporto.DocumentoInterno(oggetto, ss[4]);
                            try
                            {
                                stato.OperatoreRi = Operatore.Utente.IdUtente;
                                stato.DataRi = DateTime.Now;
                                stato.SegnaturaRi = identificativo_paleo;
                                storico_provider.Save(stato);
                                ShowMessage("Rapporto istruttorio firmato e protocollato correttamente.");
                            }
                            catch (Exception ex)
                            {
                                string oggettoEmail = "Errore durante la firma del rapporto istruttorio";
                                string testEmail = "Domanda: " + progetto.IdProgetto + "\nSegnatura: " + identificativo_paleo + "\n\n" + ex.Message;
                                EmailUtility.SendEmailToTeamSigef(ex, oggettoEmail, testEmail);
                                ShowError(ex);
                            }
                        }
                        else ShowError("Esiste gia' un rapporto istruttorio firmato per la domanda nr. " + progetto.IdProgetto + ".");
                    }
                    else ShowError("Si è verificato un errore sul server. Si prega di contattare l`helpdesk per e segnalare il problema urgentemente.");
                }
                else ShowError("Si è verificato un errore sul server. Si prega di contattare l`helpdesk per e segnalare il problema urgentemente.");
            }
            catch (Exception ex) { ShowError(ex); }
            finally { ucFirmaRapportoIstruttorio.FileFirmato = null; }
        }
    }
}