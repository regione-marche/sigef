using SiarBLL;
using SiarLibrary;
using SiarLibrary.NullTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.Controlli
{
    public partial class MessaggiBroadcast : SiarLibrary.Web.PrivatePage
    {
        VprogettoComunicazioniMassiveCollectionProvider progetto_comunicazioni_massive_provider = new VprogettoComunicazioniMassiveCollectionProvider();
        BandoConfigCollectionProvider bando_config_provider = new BandoConfigCollectionProvider();
        ComunicazioniMassiveCollectionProvider comunicazioni_massive_provider = new ComunicazioniMassiveCollectionProvider();
        PagamentiRichiestiFemCollectionProvider pag_rich_fem_provider = new PagamentiRichiestiFemCollectionProvider();
        ProgettoComunicazioneCollectionProvider ComunicazioneCollectionProvider = new ProgettoComunicazioneCollectionProvider();
        NoteCollectionProvider note_provider = new NoteCollectionProvider();

        string profilo_utente;

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "messaggi_broadcast";
            base.OnPreInit(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    tbNuovaComunicazione.Visible = true;
                    lstBandiRup.IdRup = Operatore.Utente.IdUtente;
                    lstBandiRup.DataBind();
                    profilo_utente = ((SiarLibrary.Web.PrivatePage)Page).Operatore.Utente.Profilo;
                    if (profilo_utente.Contains("Responsabile di misura") || profilo_utente.Contains("Funzionario istruttore") || profilo_utente.Contains("Amministratore"))
                    {
                        AbilitaModifica = true;
                        lstStatoProgetto.DataBind();
                        cmbSelTipoComunicazione.inUscita = true;
                        cmbSelTipoComunicazione.DataBind();

                        int id_comunicazione;
                        btnInvia.Enabled = false;
                        if (!string.IsNullOrEmpty(hdnIdComunicazione.Value))
                        {
                            int.TryParse(hdnIdComunicazione.Value, out id_comunicazione);

                            SiarLibrary.ComunicazioniMassive comunicazione = comunicazioni_massive_provider.GetById(id_comunicazione);
                            if (comunicazione != null)
                            {
                                cmbSelTipoComunicazione.SelectedValue = comunicazione.CodTipo;
                                lstBandiRup.SelectedValue = comunicazione.IdBando;
                                txtTesto.Text = comunicazione.Testo;
                                txtOggetto.Text = comunicazione.Oggetto;
                                hdnProgettiComunicazione.Value = comunicazione.Progetti;
                                if (comunicazione.IdNote != null)
                                {
                                    SiarLibrary.Note n = note_provider.GetById(comunicazione.IdNote);
                                    txtNote.Text = n.Testo;
                                }
                                ufcNAAllegato.IdFile = comunicazione.IdFile;
                                txtNADescrizioneBreve.Text = comunicazione.DescrizioneAllegato;
                                if (comunicazione.Segnatura != null)
                                {
                                    AbilitaModifica = false;
                                    btnInvia.Enabled = AbilitaModifica;
                                    btnElimina.Enabled = AbilitaModifica;
                                    btnSave.Enabled = AbilitaModifica;
                                }
                                else
                                {
                                    btnInvia.Enabled = AbilitaModifica;
                                    btnElimina.Enabled = AbilitaModifica;
                                    btnSave.Enabled = AbilitaModifica;
                                }

                            }
                            else
                            {
                                btnInvia.Enabled = AbilitaModifica;
                                btnElimina.Enabled = AbilitaModifica;
                                btnSave.Enabled = AbilitaModifica;
                            }
                        }
                        else
                        {
                            btnElimina.Enabled = AbilitaModifica;
                            btnSave.Enabled = AbilitaModifica;
                        }
                        popolaDataGridBandiRup();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:FiltraRichieste();", true);
                    }
                    else
                    {
                        AbilitaModifica = false;
                        btnInvia.Enabled = AbilitaModifica;
                        btnElimina.Enabled = AbilitaModifica;
                        btnSave.Enabled = AbilitaModifica;
                    }
                    break;
                default:
                    hdnIdComunicazione.Value = "";
                    tbComunicazioni.Visible = true;
                    SiarLibrary.ComunicazioniMassiveCollection comunicazioni = new ComunicazioniMassiveCollectionProvider().Find(null, Operatore.Utente.IdUtente);
                    dgComunicazioni.DataSource = comunicazioni;
                    dgComunicazioni.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgComunicazioni_ItemDataBound);
                    if (comunicazioni.Count == 0) dgComunicazioni.Titolo = "&nbsp;&nbsp;&nbsp;<em><b>Nessuna comunicazione effettuata.</b></em>";
                    dgComunicazioni.DataBind();
                    break;
            }
            base.OnPreRender(e);
        }

        void dgComunicazioni_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.ComunicazioniMassive c = (SiarLibrary.ComunicazioniMassive)e.Item.DataItem;
                SiarLibrary.Bando b = new SiarBLL.BandoCollectionProvider().GetById(c.IdBando);
                e.Item.Cells[1].Text = b.Descrizione;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ucFirmaDocumento.DocumentoFirmatoEvent = btnInviaComunicazione_Click;
        }

        protected void btnNuovoPost_Click(object sender, EventArgs e)
        {
            pulisciCampi();
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (hdnIdComunicazione.Value == null || hdnIdComunicazione.Value == string.Empty) throw new Exception("La comunicazione selezionata non è valida.");
                SiarLibrary.ComunicazioniMassive c = comunicazioni_massive_provider.GetById(hdnIdComunicazione.Value);
                if (c.Segnatura != null) throw new Exception("La comunicazione selezionata è stata protocollata e non può essere eliminata.");
                comunicazioni_massive_provider.Delete(c);
                pulisciCampi();
                RegisterClientScriptBlock("pulisciCampi();");
                ShowMessage("Comunicazione eliminata correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void pulisciCampi()
        {
            hdnIdComunicazione.Value = null;
            hdnProgettiComunicazione.Value = null;
            cmbSelTipoComunicazione.SelectedIndex = -1;
            ufcNAAllegato.IdFile = null;
            lstBandiRup.SelectedIndex = -1;
            txtNote.Text = string.Empty;
            txtOggetto.Text = string.Empty;
            txtTesto.Text = string.Empty;
            btnInvia.Enabled = false;
            btnElimina.Enabled = AbilitaModifica;
            btnSave.Enabled = AbilitaModifica;
        }

        protected void popolaDataGridBandiRup()
        {
            VprogettoComunicazioniMassiveCollection cruscotto_bandi_rup_collection = new VprogettoComunicazioniMassiveCollection();
            if (profilo_utente.Contains("Responsabile di misura"))
                cruscotto_bandi_rup_collection = progetto_comunicazioni_massive_provider.Find(null, Operatore.Utente.IdUtente, null);
            else if (profilo_utente.Contains("Funzionario istruttore"))
                cruscotto_bandi_rup_collection = progetto_comunicazioni_massive_provider.Find(null, null, Operatore.Utente.IdUtente);
            else if (profilo_utente.Contains("Amministratore"))
                cruscotto_bandi_rup_collection = progetto_comunicazioni_massive_provider.Find(null, null, null);

            if (cruscotto_bandi_rup_collection.Count > 0)
            {
                lblNrRecordBandiRup.Text = string.Format("Visualizzate {0} righe", cruscotto_bandi_rup_collection.Count.ToString());

                dgDomande.DataSource = cruscotto_bandi_rup_collection;
                dgDomande.DataBind();
            }
            else
            {
                lblNrRecordBandiRup.Text = "Nessun bando trovato.";
            }
        }

        protected void btnFirma_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnProgettiComunicazione.Value == string.Empty)
                    throw new Exception("Selezionare almeno un progetto a cui inviare la comunicazione.");

                string[] progetti = hdnProgettiComunicazione.Value.Split(';');

                if (progetti.Count() > 25)
                    throw new Exception("Selezionare un massimo di 25 progetti a cui inviare la comunicazione.");
                Session["evita_controllo_date_sessione"] = "true";
                SiarLibrary.ModelloDomandaCollection cc = new SiarBLL.ModelloDomandaCollectionProvider().Find(null, lstBandiRup.SelectedValue, null);

                ucFirmaDocumento.TipoDocumento = "COMUNICAZIONE_MASSIVA_GENERICA";

                ucFirmaDocumento.loadDocumento(Operatore.Utente.CfUtente, hdnIdComunicazione.Value, lstBandiRup.SelectedValue);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnInviaComunicazione_Click(object sender, EventArgs e)
        {
            inviaComunicazione();
        }

        public void inviaComunicazione()
        {
            try
            {
                // bisogna caricare il report della comunicazione massiva e protocollarlo con tutti gli allegati.
                // per ogni azienda creare una nuova comunicazione e settarla ad inviata con il protocollo.
                // mandare la pec a tutti quanti assegnando i destinatari multipli



                if (string.IsNullOrEmpty(hdnIdComunicazione.Value)) throw new Exception("Comunicazione non valida, impossibile continuare.");
                if (string.IsNullOrEmpty(hdnProgettiComunicazione.Value)) throw new Exception("Non sono stati selezionati progetti per la comunicazione, impossibile continuare.");

                SiarLibrary.ComunicazioniMassive comunicazione = new ComunicazioniMassiveCollectionProvider().GetById(hdnIdComunicazione.Value);

                string identificativo_paleo = "";

                SiarLibrary.Bando bando = new BandoCollectionProvider().GetById(lstBandiRup.SelectedValue);

                SiarLibrary.Protocollo protocollo = new SiarLibrary.Protocollo(bando.CodEnte);

                //aggiungo nome e hash del file per impronta

                string[] progetti = hdnProgettiComunicazione.Value.Split(';');

                List<SiarLibrary.Impresa> imprese = new List<SiarLibrary.Impresa>();

                List<SiarLibrary.Progetto> listaProgetti = new List<SiarLibrary.Progetto>();

                foreach (string s in progetti)
                {
                    SiarLibrary.Progetto p = new ProgettoCollectionProvider().GetById(s);
                    listaProgetti.Add(p);
                    SiarLibrary.Impresa i = new ImpresaCollectionProvider().GetById(p.IdImpresa);
                    imprese.Add(i);
                }

                // fa il set dei destinatari della comunicazione massiva
                protocollo.setCorrispondenti(listaProgetti);

                protocollo.setDocumento("comunicazione_massiva_bando_" + bando.IdBando + "-" + hdnIdComunicazione.Value + ".pdf", Convert.FromBase64String(ucFirmaDocumento.FileFirmato));

                string[] ss = new SiarBLL.BandoCollectionProvider().GetDatiXProtocollazione(bando.IdBando, "");
                string oggetto = "COMUNICAZIONI per il bando: " + ss[0] + " del " + ss[1] + "\n" + ss[3] + "\nAnno: " + DateTime.Now.Year;

                // carico gli allegati su paleo
                System.Collections.ArrayList allegatiProtocollo = new System.Collections.ArrayList();
                if (ufcNAAllegato.IdFile != null)
                {
                    SiarLibrary.ArchivioFile f = new ArchivioFileCollectionProvider().GetById(ufcNAAllegato.IdFile);

                    try
                    {
                        protocollo.addAllegato(f.NomeFile, f.HashCode);
                    }
                    catch (Exception ex) { }

                    SiarBLL.paleoWebService.Allegato all = new SiarBLL.paleoWebService.Allegato();
                    all.Descrizione = f.NomeCompleto;
                    all.Documento = new SiarBLL.paleoWebService.File();
                    all.Documento.NomeFile = f.NomeFile;

                    System.Collections.Generic.Dictionary<string, object> allegatoProtocollo = new System.Collections.Generic.Dictionary<string, object>();
                    allegatoProtocollo.Add("allegato", all);
                    allegatoProtocollo.Add("id_file", f.Id);
                    allegatoProtocollo.Add("tipo_origine", "comunicazione_massiva");
                    allegatoProtocollo.Add("id_origine", comunicazione.Id);
                    allegatiProtocollo.Add(allegatoProtocollo);
                }

                identificativo_paleo = protocollo.ProtocolloUscita(oggetto, ss[4], true);

                comunicazioni_massive_provider.DbProviderObj.BeginTran();

                SiarBLL.ProgettoComunicazioneCollectionProvider comunicazioneProvider = new ProgettoComunicazioneCollectionProvider(comunicazioni_massive_provider.DbProviderObj);
                SiarBLL.ProgettoComunicazioneAllegatoCollectionProvider comunicazioneAllegatiProvider = new ProgettoComunicazioneAllegatoCollectionProvider(comunicazioni_massive_provider.DbProviderObj);
                foreach (SiarLibrary.Progetto p in listaProgetti)
                {
                    SiarLibrary.ProgettoComunicazione c = new ProgettoComunicazione();

                    c.IdComunicazioneRef = DBNull.Value;
                    c.IdProgetto = p.IdProgetto;
                    c.InEntrata = false;
                    c.CodTipo = comunicazione.CodTipo;
                    c.Operatore = Operatore.Utente.IdUtente;
                    c.Segnatura = identificativo_paleo;
                    c.SegnaturaEsterna = false;

                    c.Oggetto = comunicazione.Oggetto;
                    c.Testo = comunicazione.Testo;

                    if (string.IsNullOrEmpty(txtNote.Text)) c.IdNote = DBNull.Value;
                    else
                        c.IdNote = comunicazione.IdNote;
                    comunicazioneProvider.Save(c);

                    if (comunicazione.IdFile != null)
                    {
                        SiarLibrary.ProgettoComunicazioneAllegato a = new ProgettoComunicazioneAllegato();
                        a.IdComunicazione = c.IdComunicazione;
                        a.IdFile = comunicazione.IdFile;
                        a.IdProgetto = p.IdProgetto;
                        a.Descrizione = comunicazione.DescrizioneAllegato;

                        comunicazioneAllegatiProvider.Save(a);
                    }

                }
                comunicazione.Segnatura = identificativo_paleo;
                comunicazioni_massive_provider.Save(comunicazione);
                comunicazioni_massive_provider.DbProviderObj.Commit();
                if (ufcNAAllegato.IdFile != null)
                    protocollo.addAllegatiProtocollo(allegatiProtocollo, identificativo_paleo);
                ShowMessage("Comunicazione inviata correttamente.");
            }
            catch (Exception ex)
            {
                ShowError("Si è verificato un errore durante l'invio della comunicazione, riprovare più tardi.");
                ComunicazioneCollectionProvider.DbProviderObj.Rollback();
            }
        }

        protected void btnSalvaComunicazione_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                comunicazioni_massive_provider.DbProviderObj.BeginTran();
                SiarLibrary.ComunicazioniMassive comunicazione = new SiarLibrary.ComunicazioniMassive();

                if (!string.IsNullOrEmpty(hdnIdComunicazione.Value))
                    comunicazione = comunicazioni_massive_provider.GetById(hdnIdComunicazione.Value);

                comunicazione.CodTipo = cmbSelTipoComunicazione.SelectedValue;
                comunicazione.IdBando = lstBandiRup.SelectedValue;
                comunicazione.Operatore = Operatore.Utente.IdUtente;
                comunicazione.Testo = txtTesto.Text;
                comunicazione.Oggetto = txtOggetto.Text;

                if (string.IsNullOrEmpty(txtNote.Text)) comunicazione.IdNote = DBNull.Value;
                else
                {
                    SiarLibrary.Note n = new SiarLibrary.Note();
                    n.Testo = txtNote.Text;
                    note_provider.Save(n);
                    comunicazione.IdNote = n.Id;
                }

                comunicazione.IdFile = ufcNAAllegato.IdFile;
                comunicazione.DescrizioneAllegato = txtNADescrizioneBreve.Text;

                comunicazione.Progetti = hdnProgettiComunicazione.Value;

                comunicazioni_massive_provider.Save(comunicazione);
                comunicazioni_massive_provider.DbProviderObj.Commit();
                hdnIdComunicazione.Value = comunicazione.Id;
                hdnProgettiComunicazione.Value = comunicazione.Progetti;
                ShowMessage("Comunicazione salvata correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}