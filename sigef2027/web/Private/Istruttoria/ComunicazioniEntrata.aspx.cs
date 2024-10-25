using System;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;

namespace web.Private.Istruttoria
{
    public partial class ComunicazioniEntrata : SiarLibrary.Web.IstruttoriaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "collaboratori_istruttoria";
            base.OnPreInit(e);
        }

        SiarLibrary.BandoResponsabiliCollection responsabili;
        SiarBLL.CollaboratoriXBandoCollectionProvider coll_provider = new SiarBLL.CollaboratoriXBandoCollectionProvider();
        SiarBLL.ProgettoSegnatureCollectionProvider segnature_provider = new SiarBLL.ProgettoSegnatureCollectionProvider();
        SiarBLL.ProgettoStoricoCollectionProvider storico_provider = new SiarBLL.ProgettoStoricoCollectionProvider();

        protected void Page_Load(object sender, EventArgs e)
        {
            responsabili = new SiarBLL.BandoResponsabiliCollectionProvider().Find(Bando.IdBando, Operatore.Utente.IdUtente,
                null, false, true);
            //AbilitaModifica = (AbilitaModifica && !Bando.GraduatoriaDefinitiva && responsabili.Count > 0);
        }

        protected override void OnPreRender(EventArgs e)
        {
            lstTipoDoc.DataBinding += new EventHandler(lstTipoDocumento_DataBinding);
            lstTipoDoc.DataBind();

            SiarLibrary.ProgettoSegnatureCollection comunicazioni = segnature_provider.GetComunicazioniEntrataBando(Bando.IdBando,
                ucFiltroRicercaComunicazioni.IdProgetto, ucFiltroRicercaComunicazioni.TipoDocumento);
            dg.DataSource = comunicazioni;
            dg.ItemDataBound += new DataGridItemEventHandler(dg_ItemDataBound);
            dg.SetTitoloNrElementi();
            dg.DataBind();

            RegisterClientScriptBlock("selezionaPulsanti('" + lstTipoDoc.SelectedValue + "');$('[id$=lstTipoDoc]').change(function(){selezionaPulsanti(this.value);});");
            base.OnPreRender(e);
        }

        void lstTipoDocumento_DataBinding(object sender, EventArgs e)
        {
            lstTipoDoc.Items.Clear();
            lstTipoDoc.Items.Add(new ListItem("", ""));
            lstTipoDoc.Items.Add(new ListItem("Documenti di integrazione", "DNT"));
            lstTipoDoc.Items.Add(new ListItem("Richiesta di riesame", "RID"));
            lstTipoDoc.Items.Add(new ListItem("Comunicazione di rinuncia", "RIN"));
            lstTipoDoc.Items.Add(new ListItem("Esito del ricorso", "RIC"));
            foreach (ListItem li in lstTipoDoc.Items)
                if (li.Value == lstTipoDoc.SelectedValue) li.Selected = true;
        }

        void dg_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[0].RowSpan = 2;
                e.Item.Cells[1].RowSpan = 2;
                e.Item.Cells[2].HorizontalAlign = HorizontalAlign.Center;
                e.Item.Cells[2].ColumnSpan = 3;
                e.Item.Cells[2].Text = "Documento registrato</td><td>Motivazione</td><td align=center colspan=2>Procedura di riesame</td></tr><tr class='TESTA'><td>Data";
            }
            else if (e.Item.ItemType != ListItemType.Footer)
            {
                DataGridItem dgi = (DataGridItem)e.Item;
                SiarLibrary.ProgettoSegnature s = (SiarLibrary.ProgettoSegnature)dgi.DataItem;
                dgi.Cells[1].Style.Add("cursor", "pointer");
                dgi.Cells[1].CssClass = "clickable";
                dgi.Cells[1].Attributes.Add("onclick", "dettaglioDomanda(" + s.IdProgetto + ",this)");
                dgi.Cells[2].Text = "<b>Data:</b>  " + s.Data + "<br /><b>Operatore:</b>  " + s.Nominativo + "<br />";


                dgi.Cells[6].Text = "-";
                dgi.Cells[7].Text = "-";
                if (s.CodTipo == "RID")
                {
                    if (s.RiapriDomanda)
                    {
                        dgi.Cells[6].Text = "SI";
                        dgi.Cells[7].Text = "in corso";
                        SiarLibrary.ProgettoStoricoCollection stati = storico_provider.Find(s.IdProgetto, null, "A");
                        foreach (SiarLibrary.ProgettoStorico p in stati)
                            if (p.Riesame)
                            {
                                dgi.Cells[7].Text = p.Stato;
                                break;
                            }
                    }
                    else dgi.Cells[6].Text = "NO";
                    dgi.Cells[5].Text += "<div style='width:100%' id='divMotivazione" + s.IdProgetto + "'>" + s.Motivazione
                        + "</div><div id='divLinkMotivazione" + s.IdProgetto
                        + "' style='width:100%;text-align:right'><a href=\"javascript:" + (
                        Bando.OrdineStato > 4 ? "alert('Modifica non abilitata in quanto la graduatoria è stata resa definitiva.'"
                        : "modificaMotivazione(" + s.IdProgetto) + ");\">[modifica la motivazione]</a></div>";
                }
            }
        }

        protected void btnAvvio_Click(object sender, EventArgs e)
        {
            avvioRiesame(true);
        }

        protected void btnRifiuta_Click(object sender, EventArgs e)
        {
            avvioRiesame(false);
        }

        private void avvioRiesame(bool riapri_domanda)
        {
            try
            {
                controlloSegnatura();
                int id_progetto;
                if (!int.TryParse(txtNumero.Text, out id_progetto)) throw new Exception("Numero di domanda non valido.");
                SiarLibrary.CollaboratoriXBandoCollection cc = coll_provider.GetCollabBandoDatiProgettoImpresa(Bando.IdBando, id_progetto, null, null, null);
                if (cc.Count == 0) throw new Exception("Numero di domanda non valido.");

                if (cc[0].AdditionalAttributes["COD_STATO"] != "B" && cc[0].AdditionalAttributes["COD_STATO"] != "A")
                    throw new Exception("La domanda deve essere stata istruita in ammissibilità per effettuare il riesame.");

                SiarLibrary.ProgettoSegnature revisione = segnature_provider.GetById(id_progetto, "REV");
                if (revisione != null && revisione.RiapriDomanda && !bool.Parse(cc[0].AdditionalAttributes["REVISIONE"]))
                    throw new Exception("La domanda è già in istruttoria per la revisione. Operazione annullata.");
                if (segnature_provider.GetById(id_progetto, "RID") != null)
                    throw new Exception("E` già stata registrata una richiesta di riesame per la domanda. Impossibile continuare.");

                bool is_responsabile = false;
                foreach (SiarLibrary.BandoResponsabili resp in responsabili)
                    if (resp.Provincia == cc[0].Provincia) { is_responsabile = true; break; }
                if (!is_responsabile) throw new Exception("L'operatore non è il responsabile provinciale della domanda cercata. Impossibile continuare.");

                SiarLibrary.ProgettoSegnature doc = new SiarLibrary.ProgettoSegnature();
                doc.IdProgetto = id_progetto;
                doc.Segnatura = txtSegnatura.Text;
                doc.CodTipo = "RID";
                doc.RiapriDomanda = riapri_domanda;
                doc.Motivazione = txtMotivazioneLunga.Text;
                doc.Data = DateTime.Now;
                doc.Operatore = Operatore.Utente.CfUtente;
                segnature_provider.Save(doc);
                if (riapri_domanda) ShowMessage("Avvio procedura completato. Ora la domanda è pronta per essere riesaminata.");
                else ShowMessage("Richiesta di riesame registrata correttamente. Riesame rifiutato.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void controlloSegnatura()
        {
            SiarLibrary.Protocollo protocollo = new SiarLibrary.Protocollo();
            byte[] stream = protocollo.RicercaProtocollo(txtSegnatura.Text, true);
        }

        protected void btnIntegrazione_Click(object sender, EventArgs e)
        {
            try
            {
                controlloSegnatura();
                int id_progetto;
                if (!int.TryParse(txtNumero.Text, out id_progetto)) throw new Exception("Numero di domanda non valido.");
                SiarLibrary.CollaboratoriXBandoCollection cc = coll_provider.Find(Bando.IdBando, id_progetto, null, null, true);
                if (cc.Count == 0) throw new Exception("Numero di domanda non valido.");

                if (segnature_provider.GetById(id_progetto, "DNT") != null)
                    throw new Exception("E` già stato registrato un documento di integrazione per la domanda. Impossibile continuare.");

                //if (progetto.CodStato != "B" && progetto.CodStato != "A")
                //    throw new Exception("La domanda deve essere stata istruita in ammissibilità per effettuare il riesame.");
                //else if (segnature_provider.Find(progetto.IdProgetto, null, null, "REV").Count > 0 && !progetto.Revisione)
                //    throw new Exception("La domanda è già in istruttoria per la revisione. Operazione annullata.");
                bool is_responsabile = false;
                foreach (SiarLibrary.BandoResponsabili resp in responsabili)
                    if (resp.Provincia == cc[0].Provincia) { is_responsabile = true; break; }
                if (!is_responsabile) throw new Exception("L'operatore non è il responsabile provinciale della domanda cercata. Impossibile continuare.");


                SiarLibrary.ProgettoSegnature doc = new SiarLibrary.ProgettoSegnature();
                doc.IdProgetto = id_progetto;
                doc.Segnatura = txtSegnatura.Text;
                doc.CodTipo = "DNT";
                doc.RiapriDomanda = false;
                doc.Motivazione = txtMotivazioneLunga.Text;
                doc.Data = DateTime.Now;
                doc.Operatore = Operatore.Utente.CfUtente;
                segnature_provider.Save(doc);
                ShowMessage("Documento di integrazione registrato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnRinuncia_Click(object sender, EventArgs e)
        {
            try
            {
                controlloSegnatura();
                int id_progetto;
                if (!int.TryParse(txtNumero.Text, out id_progetto)) throw new Exception("Numero di domanda non valido.");
                SiarLibrary.CollaboratoriXBandoCollection cc = coll_provider.GetCollabBandoDatiProgettoImpresa(Bando.IdBando, id_progetto, null, null, null);
                if (cc.Count == 0) throw new Exception("Numero di domanda non valido.");

                string cod_stato = cc[0].AdditionalAttributes["COD_STATO"];
                if (cod_stato == "R") throw new Exception("Documento di rinuncia già registrato.");
                else if (cod_stato.FindValueIn("B", "Q", "N", "Y", "E"))
                    throw new Exception("Non è possibile registrare la rinuncia per le domanda di aiuto che si trovano già in uno stato negativo.");

                #region controllo operatore
                bool is_responsabile = false;
                foreach (SiarLibrary.BandoResponsabili resp in responsabili)
                    if (resp.Provincia == cc[0].Provincia) { is_responsabile = true; break; }
                if (!is_responsabile)
                    throw new Exception("L'operatore non è in responsabile provinciale della domanda cercata. Impossibile continuare.");
                #endregion

                SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider();
                segnature_provider = new SiarBLL.ProgettoSegnatureCollectionProvider(progetto_provider.DbProviderObj);
                try
                {
                    progetto_provider.DbProviderObj.BeginTran();
                    progetto_provider.CambioStatoProgetto(progetto_provider.GetById(id_progetto), "R", txtSegnatura.Text, Operatore);
                    if (cc[0].AdditionalAttributes["ID_PROG_INTEGRATO"] != null)
                    {
                        SiarLibrary.ProgettoCollection progetti = progetto_provider.Find(null, null, id_progetto, null, null, false, true);
                        foreach (SiarLibrary.Progetto p in progetti)
                            if (p.IdProgetto != cc[0].IdProgetto) progetto_provider.CambioStatoProgetto(p, "R", Operatore);
                    }

                    SiarLibrary.ProgettoSegnature doc = new SiarLibrary.ProgettoSegnature();
                    doc.IdProgetto = id_progetto;
                    doc.Segnatura = txtSegnatura.Text;
                    doc.CodTipo = "RIN";
                    doc.RiapriDomanda = false;
                    doc.Motivazione = txtMotivazioneLunga.Text;
                    doc.Data = DateTime.Now;
                    doc.Operatore = Operatore.Utente.CfUtente;
                    try { segnature_provider.Save(doc); }
                    catch { throw new Exception("E` già stata registrata una richiesta di rinuncia per la domanda. Impossibile continuare."); }

                    progetto_provider.DbProviderObj.Commit();
                    ShowMessage("Richiesta di rinuncia registrata correttamente e stato della domanda cambiato.");
                }
                catch { progetto_provider.DbProviderObj.Rollback(); throw; }
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalvaMotivazione_Click(object sender, EventArgs e)
        {
            string idprogetto = null, motivazione = null;
            foreach (string s in Request.Form.AllKeys)
            {
                if (s.EndsWith("hdnIdProgetto")) idprogetto = Request.Form[s];
                if (s.EndsWith("hdnMotivazione")) motivazione = Request.Form[s];
            }
            try
            {
                if (string.IsNullOrEmpty(idprogetto) || string.IsNullOrEmpty(idprogetto))
                    throw new Exception("Si è verificato un errore nella procedura. Impossibile continuare.");

                #region controllo operatore
                SiarLibrary.CollaboratoriXBandoCollection progetti = coll_provider.Find(Bando.IdBando, idprogetto, null, null, true);
                if (progetti.Count == 0) throw new Exception("Numero di domanda non valido.");
                bool is_responsabile = false;
                foreach (SiarLibrary.BandoResponsabili resp in responsabili)
                    if (resp.Provincia == progetti[0].Provincia) { is_responsabile = true; break; }
                if (!is_responsabile)
                    throw new Exception("L'operatore non è il responsabile provinciale della domanda cercata. Impossibile continuare.");
                #endregion

                SiarLibrary.ProgettoSegnature riesame = segnature_provider.GetById(idprogetto, "RID");
                if (riesame == null) throw new Exception("Richiesta di riesame per la domanda nr." + idprogetto + " non trovata.");
                riesame.Motivazione = motivazione;
                riesame.Data = DateTime.Now;
                riesame.Operatore = Operatore.Utente.CfUtente;
                segnature_provider.Save(riesame);
                ShowMessage("Modifica delle motivazioni del riesame registrata correttamente.");
                hdnIdProgetto.Value = "";
                hdnMotivazione.Value = "";
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnRicorso_Click(object sender, EventArgs e)
        {
            try
            {
                controlloSegnatura();
                int id_progetto;
                if (!int.TryParse(txtNumero.Text, out id_progetto)) throw new Exception("Numero di domanda non valido.");
                SiarLibrary.CollaboratoriXBandoCollection cc = coll_provider.GetCollabBandoDatiProgettoImpresa(Bando.IdBando, id_progetto, null, null, null);
                if (cc.Count == 0) throw new Exception("Numero di domanda non valido.");

                if (cc[0].AdditionalAttributes["COD_STATO"] != "B") throw new Exception("Il ricorso è valido solo se la domanda si trova nello stato NON AMMISSIBILE.");
                bool is_responsabile = false;
                foreach (SiarLibrary.BandoResponsabili resp in responsabili)
                    if (resp.Provincia == cc[0].Provincia) { is_responsabile = true; break; }
                if (!is_responsabile) throw new Exception("L'operatore non è in responsabile provinciale della domanda cercata. Impossibile continuare.");

                SiarLibrary.ProgettoSegnature doc = new SiarLibrary.ProgettoSegnature();
                doc.IdProgetto = txtNumero.Text;
                doc.Segnatura = txtSegnatura.Text;
                doc.CodTipo = "RIC";
                doc.RiapriDomanda = true;
                doc.Motivazione = txtMotivazioneLunga.Text;
                doc.Data = DateTime.Now;
                doc.Operatore = Operatore.Utente.CfUtente;
                try
                {
                    segnature_provider.Save(doc);
                    ShowMessage("Esito del ricorso salvato correttamente. Ora la domanda è pronta per essere reistruita in ammissibilità.");
                }
                catch { ShowError("E` già stata registrata un esito del ricorso per la domanda. Impossibile continuare."); }
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}
