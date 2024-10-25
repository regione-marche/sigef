using SiarLibrary.Web;
using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.Impresa
{
    public partial class ImpresaConsulente : SiarLibrary.Web.ImpresaPage
    {
        SiarBLL.RichiestaConsulenteCollectionProvider rich_prov = new SiarBLL.RichiestaConsulenteCollectionProvider();
        SiarLibrary.RichiestaConsulente richiesta_selezionata = null;
        SiarLibrary.RichiestaConsulenteProcuraXBando richiesta_selezionata_procura = null;
        SiarBLL.RichiestaConsulenteAllegatoCollectionProvider rich_all_prov = new SiarBLL.RichiestaConsulenteAllegatoCollectionProvider();
        SiarBLL.RichiestaConsulenteProcuraAllegatoCollectionProvider rich_all_proc_prov = new SiarBLL.RichiestaConsulenteProcuraAllegatoCollectionProvider();
        SiarLibrary.RichiestaConsulenteAllegato allegato_selezionato = null;
        SiarLibrary.RichiestaConsulenteProcuraAllegato allegato_selezionato_procura = null;
        SiarBLL.MandatiImpresaCollectionProvider mandati_provider = new SiarBLL.MandatiImpresaCollectionProvider();
        SiarBLL.RichiestaConsulenteProcuraXBandoCollectionProvider procure_provider = new SiarBLL.RichiestaConsulenteProcuraXBandoCollectionProvider();

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "impresa_consulente";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int idRichiesta;
            if (int.TryParse(hdnIdRichiestaConsulente.Value, out idRichiesta))
            {
                richiesta_selezionata = rich_prov.GetById(idRichiesta);
                int idAllegato;
                if (int.TryParse(hdnIdAllegato.Value, out idAllegato))
                    allegato_selezionato = rich_all_prov.GetById(idAllegato);
            }

            int idRichiestaProcura;
            if (int.TryParse(hdnIdRichiestaConsulenteProcura.Value, out idRichiestaProcura))
            {
                richiesta_selezionata_procura = procure_provider.GetById(idRichiestaProcura);
                int idAllegato;
                if (int.TryParse(hdnIdAllegatoProcura.Value, out idAllegato))
                    allegato_selezionato_procura = rich_all_proc_prov.GetById(idAllegato);
            }

            if (richiesta_selezionata != null)
                ucFirmaDocumento.DocumentoFirmatoEvent = ProtocollaDocFirmatoEvent;
            else if (richiesta_selezionata_procura != null)
                ucFirmaDocumento.DocumentoFirmatoEvent = ProtocollaDocFirmatoProcuraEvent;
        }

        protected override void OnPreRender(EventArgs e)
        {
            txtCodFiscale.AddJSAttribute("onblur", "ctrlCF(this,event);");

            switch (ucSiarNewTab.TabSelected)
            {
                case 3:
                    tbNuoveRichieste.Visible = false;
                    tbRichieste.Visible = false;

                    lstBandiProcuraTab3.IdImpresa = Azienda.IdImpresa;
                    lstBandiProcuraTab3.DataBind();

                    lstConsulentiAzienda.IdImpresa = Azienda.IdImpresa;
                    lstConsulentiAzienda.DataBind();

                    if (richiesta_selezionata_procura == null)
                    {
                        trAllegatiProcura.Visible = false;
                    }
                    else
                    {
                        trBtnAllegatiProcura.Visible = false;
                        lstBandiProcuraTab3.SelectedValue = richiesta_selezionata_procura.IdBando;
                        lstConsulentiAzienda.SelectedValue = richiesta_selezionata_procura.IdConsulente;

                        SiarLibrary.RichiestaConsulenteProcuraAllegatoCollection all_proc_coll = rich_all_proc_prov.Find(richiesta_selezionata_procura.Id, null);
                        dgAllegatiProcura.DataSource = all_proc_coll;
                        dgAllegatiProcura.SetTitoloNrElementi();
                        //dgAllegati.ItemDataBound += new DataGridItemEventHandler(dgAllegati_ItemDataBound);
                        dgAllegatiProcura.DataBind();

                        if (allegato_selezionato_procura != null)
                        {
                            ufcNAAllegatoProcura.IdFile = allegato_selezionato_procura.IdFile;
                            txtDescrizioneProcura.Text = allegato_selezionato_procura.Descrizione;
                        }
                        else
                        {
                            ufcNAAllegatoProcura.IdFile = "";
                            txtDescrizioneProcura.Text = "";
                        }
                    }

                    SiarLibrary.RichiestaConsulenteProcuraXBandoCollection rich_coll_proc_no_inv = procure_provider.Find(null, null, Azienda.IdImpresa, null, null, false, false, false, false);
                    dgRichiesteProcuraNonInviate.DataSource = rich_coll_proc_no_inv;
                    dgRichiesteProcuraNonInviate.ItemDataBound += new DataGridItemEventHandler(dgRichiesteNonInviateProcura_ItemDataBound);
                    dgRichiesteProcuraNonInviate.DataBind();

                    SiarLibrary.RichiestaConsulenteProcuraXBandoCollection rich_coll_proc_inv = procure_provider.Find(null, null, Azienda.IdImpresa, null, null, true, null, null, false);
                    dgRichiesteProcuraInviate.DataSource = rich_coll_proc_inv;
                    dgRichiesteProcuraInviate.ItemDataBound += new DataGridItemEventHandler(dgRichiesteInviateProcura_ItemDataBound);
                    dgRichiesteProcuraInviate.DataBind();

                    SiarLibrary.RichiestaConsulenteProcuraXBandoCollection mandati_utente_procura = new SiarBLL.RichiestaConsulenteProcuraXBandoCollectionProvider().Find(null, null, Azienda.IdImpresa, null, null, true, true, true, true);
                    dgMandatiProcura.DataSource = mandati_utente_procura;
                    dgMandatiProcura.ItemDataBound += new DataGridItemEventHandler(dgMandatiProcura_ItemDataBound);
                    dgMandatiProcura.DataBind();

                    break;
                case 2:
                    tbNuoveRichieste.Visible = false;
                    tbProcureSpeciali.Visible = false;

                    SiarLibrary.RichiestaConsulenteCollection rich_coll_inv = rich_prov.Find(null, Azienda.IdImpresa, null, true, null, null, null, false);
                    dgRichiesteInviate.DataSource = rich_coll_inv;
                    dgRichiesteInviate.ItemDataBound += new DataGridItemEventHandler(dgRichiesteInviate_ItemDataBound);
                    dgRichiesteInviate.DataBind();

                    SiarLibrary.MandatiImpresaCollection mandati_utente = new SiarBLL.MandatiImpresaCollectionProvider().Find(null, Azienda.Cuaa, Azienda.CodiceFiscale, null, null,
                    null, null, "PSR", null);
                    dgMandati.DataSource = mandati_utente;
                    dgMandati.ItemDataBound += new DataGridItemEventHandler(dgMandati_ItemDataBound);
                    dgMandati.DataBind();

                    break;
                default:
                    tbRichieste.Visible = false;
                    tbProcureSpeciali.Visible = false;

                    lstBandiProcura.IdImpresa = Azienda.IdImpresa;
                    lstBandiProcura.DataBind();

                    SiarLibrary.RichiestaConsulenteCollection rich_coll_non_inv = rich_prov.Find(null, Azienda.IdImpresa, null, false, null, null, null, null);
                    dgRichiesteNonInviate.DataSource = rich_coll_non_inv;
                    dgRichiesteNonInviate.DataBind();

                    if (richiesta_selezionata == null)
                    {
                        trAllegati.Visible = false;

                        if (hdnIdPersonaFisica.Value == null || hdnIdPersonaFisica.Value == "")
                        {
                            txtCFOperatore.Text = "";
                            txtNominativoOperatore.Text = "";
                        }
                        txtDataInizio.Text = "";
                        txtDataFine.Text = "31/12/2030";

                        if (Azienda.IdSedelegaleUltimo != null)
                        {
                            SiarLibrary.Indirizzario sede_legale = new SiarBLL.IndirizzarioCollectionProvider().GetById(Azienda.IdSedelegaleUltimo);
                            if (sede_legale.Telefono != null && sede_legale.Telefono != "")
                            {
                                txtSLTelefono.Text = sede_legale.Telefono;
                                txtSLTelefono.ReadOnly = true;
                            }
                            if (sede_legale.Email != null && sede_legale.Email != "")
                            {
                                txtSLEmail.Text = sede_legale.Email;
                                txtSLEmail.ReadOnly = true;
                            }
                            if (sede_legale.Pec != null && sede_legale.Pec != "")
                            {
                                txtSLPec.Text = sede_legale.Pec;
                                txtSLPec.ReadOnly = true;
                            }
                        }
                    }
                    else
                    {
                        trBtnAllegati.Visible = false;

                        hdnIdPersonaFisica.Value = richiesta_selezionata.IdConsulente.ToString();
                        txtCFOperatore.Text = richiesta_selezionata.CfUtenteConsulente;
                        txtNominativoOperatore.Text = richiesta_selezionata.NominativoConsulente;
                        txtDataInizio.Text = richiesta_selezionata.DataInizioAbilitazione;
                        txtDataFine.Text = richiesta_selezionata.DataFineAbilitazione;
                        txtSLTelefono.ReadOnly = true;
                        txtSLEmail.ReadOnly = true;
                        txtSLPec.ReadOnly = true;
                        chkProcuraSpeciale.Checked = richiesta_selezionata.ProcuraSpeciale;
                        if (richiesta_selezionata.ProcuraSpeciale)
                        {
                            SiarLibrary.RichiestaConsulenteProcuraXBandoCollection r = procure_provider.Find(null, richiesta_selezionata.IdRichiestaConsulente, Azienda.IdImpresa, richiesta_selezionata.IdConsulente, null, false, false, false, false);
                            if (r.Count > 0)
                            {
                                if (r[0].IdBando != null)
                                    lstBandiProcura.SelectedValue = r[0].IdBando;
                            }
                        }

                        SiarLibrary.RichiestaConsulenteAllegatoCollection all_coll = rich_all_prov.Find(null, richiesta_selezionata.IdRichiestaConsulente, null);
                        dgAllegati.DataSource = all_coll;
                        dgAllegati.SetTitoloNrElementi();
                        //dgAllegati.ItemDataBound += new DataGridItemEventHandler(dgAllegati_ItemDataBound);
                        dgAllegati.DataBind();

                        if (allegato_selezionato != null)
                        {
                            ufcNAAllegato.IdFile = allegato_selezionato.IdFile;
                            txtDescrizione.Text = allegato_selezionato.Descrizione;
                        }
                        else
                        {
                            ufcNAAllegato.IdFile = "";
                            txtDescrizione.Text = "";
                        }
                    }
                    //Popolo i recapiti se presenti in anagrafica

                    break;
            }

            base.OnPreRender(e);
        }

        void dgAllegati_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    SiarLibrary.DomandaPagamentoAllegati allegato = (SiarLibrary.DomandaPagamentoAllegati)e.Item.DataItem;

            //    if (allegato.Formato == "S")
            //        e.Item.Cells[3].Text = "<b>Nr.</b> " + allegato.Numero + " <b>del</b> " + allegato.Data + "<br /><b>Presso:</b> " + allegato.Ente
            //        + "<br /><b>Descrizione:</b> " + e.Item.Cells[3].Text;

            //    if (allegato.IdFile == null)
            //        e.Item.Cells[6].Text = "";
            //}
        }

        void dgRichiesteInviate_ItemDataBound(object sender, DataGridItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int col_Cons = 0,
                    col_Inizio = 1,
                    col_Fine = 2,
                    col_Doc = 3,
                    col_Stato = 4,
                    col_Rifiuto = 5,
                    col_DocIstr = 6;


                SiarLibrary.RichiestaConsulente r = (SiarLibrary.RichiestaConsulente)e.Item.DataItem;
                if (r.Segnatura != null)
                    e.Item.Cells[col_Doc].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='Domanda'  onclick=\"sncAjaxCallVisualizzaProtocollo('" + r.Segnatura + "');\" style='cursor: pointer;'>";
                if (!r.Istruita)
                    e.Item.Cells[col_Stato].Text = "DA EVADERE";
                else
                {
                    if (r.Approvata)
                    {
                        if (r.DataFineAbilitazione <= DateTime.Now)
                        {
                            e.Item.Cells[col_Stato].Text = "SCADUTA";
                        }
                        else
                            e.Item.Cells[col_Stato].Text = "APPROVATA";
                    }
                    else
                    {
                        if (r.Rifiutata)
                        {
                            e.Item.Cells[col_Stato].Text = "RIFIUTATA";
                            e.Item.Cells[col_Rifiuto].Text = r.MotivazioneRifiuto;
                        }
                    }
                    if (r.SegnaturaIstruttoria != null)
                        e.Item.Cells[col_DocIstr].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='Domanda'  onclick=\"sncAjaxCallVisualizzaProtocollo('" + r.SegnaturaIstruttoria + "');\" style='cursor: pointer;'>";
                }
            }
        }

        void dgRichiesteInviateProcura_ItemDataBound(object sender, DataGridItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int col_Cons = 0,
                    col_Bando = 1,
                    col_Inizio = 2,
                    col_Fine = 3,
                    col_Doc = 4,
                    col_Stato = 5,
                    col_Rifiuto = 6,
                    col_DocIstr = 7;


                SiarLibrary.RichiestaConsulenteProcuraXBando r = (SiarLibrary.RichiestaConsulenteProcuraXBando)e.Item.DataItem;
                ///e.Item.Cells[col_Cons].Text = new SiarBLL.UtentiCollectionProvider().Find(null, r.IdConsulente, null, null, null, null, 1)[0].Nominativo;
                if (new SiarBLL.UtentiCollectionProvider().Find(null, r.IdConsulente, null, null, null, null, 1).Count > 0)
                    e.Item.Cells[col_Cons].Text = new SiarBLL.UtentiCollectionProvider().Find(null, r.IdConsulente, null, null, null, null, 1)[0].Nominativo;
                else
                {
                    SiarLibrary.PersonaFisica pf = new SiarBLL.PersonaFisicaCollectionProvider().GetById(r.IdConsulente);
                    e.Item.Cells[col_Cons].Text = pf.Cognome + " " + pf.Nome;
                }

                e.Item.Cells[col_Bando].Text = new SiarBLL.BandoCollectionProvider().GetById(r.IdBando).Descrizione;
                if (r.Segnatura != null)
                    e.Item.Cells[col_Doc].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='Domanda'  onclick=\"sncAjaxCallVisualizzaProtocollo('" + r.Segnatura + "');\" style='cursor: pointer;'>";
                if (!r.Istruita)
                    e.Item.Cells[col_Stato].Text = "DA EVADERE";
                else
                {
                    if (r.Approvata)
                    {
                        if (r.DataFine <= DateTime.Now)
                        {
                            e.Item.Cells[col_Stato].Text = "SCADUTA";
                        }
                        else
                            e.Item.Cells[col_Stato].Text = "APPROVATA";
                    }
                    else
                    {
                        if (!r.Approvata && r.SegnaturaIstruttoria != null)
                        {
                            {
                                e.Item.Cells[col_Stato].Text = "RIFIUTATA";
                                e.Item.Cells[col_Rifiuto].Text = r.MotivazioneRifiuto;
                            }
                        }
                    }
                    if (r.SegnaturaIstruttoria != null)
                        e.Item.Cells[col_DocIstr].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='Domanda'  onclick=\"sncAjaxCallVisualizzaProtocollo('" + r.SegnaturaIstruttoria + "');\" style='cursor: pointer;'>";
                }
            }
        }

        void dgRichiesteNonInviateProcura_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int col_Cons = 0,
                    col_Bando = 1,
                    col_Inizio = 2,
                    col_Fine = 3,
                    col_Stato = 4;

                SiarLibrary.RichiestaConsulenteProcuraXBando r = (SiarLibrary.RichiestaConsulenteProcuraXBando)e.Item.DataItem;

                var utentiCollection = new SiarBLL.UtentiCollectionProvider().Find(null, r.IdConsulente, null, null, null, null, 1);
                if (utentiCollection.Count == 1)
                {
                    var consulente = utentiCollection[0];
                    e.Item.Cells[col_Cons].Text = consulente.Nominativo;
                }
                else
                    e.Item.Cells[col_Cons].Text = "Consulente con id " + r.IdConsulente + " non trovato come attivo, contattare l'helpdesk";

                var bando = new SiarBLL.BandoCollectionProvider().GetById(r.IdBando);
                if (bando != null)
                    e.Item.Cells[col_Bando].Text = bando.Descrizione;
                else
                    e.Item.Cells[col_Bando].Text = "Bando " + r.IdBando + " non trovato";

                e.Item.Cells[col_Stato].Text = "DA INVIARE";
            }
        }

        void dgMandati_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.MandatiImpresa m = (SiarLibrary.MandatiImpresa)e.Item.DataItem;
                SiarLibrary.Utenti u = new SiarBLL.UtentiCollectionProvider().GetById(m.IdUtenteAbilitato);
                e.Item.Cells[1].Text = u.CfUtente;
                e.Item.Cells[2].Text = u.Nominativo;
                if (m.Attivo) e.Item.Cells[4].Text = "<input type='Button' class='ButtonGrid' value='Revoca mandato' onclick='revocaMandato(" + m.Id + ");' />";
                else
                {
                    e.Item.Cells[4].Text = "SCADUTO/REVOCATO";
                    e.Item.BackColor = System.Drawing.Color.FromArgb(204, 204, 179);
                }
            }
        }

        void dgMandatiProcura_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.RichiestaConsulenteProcuraXBando m = (SiarLibrary.RichiestaConsulenteProcuraXBando)e.Item.DataItem;
                SiarLibrary.Utenti u = new SiarBLL.UtentiCollectionProvider().Find(null, m.IdConsulente, null, null, null, null, 1)[0];
                e.Item.Cells[1].Text = u.CfUtente;
                e.Item.Cells[2].Text = u.Nominativo;
                e.Item.Cells[3].Text = new SiarBLL.BandoCollectionProvider().GetById(m.IdBando).Descrizione;
                if (m.Attivo) e.Item.Cells[4].Text = "<input type='Button' class='ButtonGrid' value='Revoca mandato' onclick='revocaProcura(" + m.Id + ");' />";
                else
                {
                    e.Item.Cells[4].Text = "SCADUTO/REVOCATO";
                    e.Item.BackColor = System.Drawing.Color.FromArgb(204, 204, 179);
                }
                if (m.Segnatura != null)
                    e.Item.Cells[5].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='Domanda'  onclick=\"sncAjaxCallVisualizzaProtocollo('" + m.Segnatura + "');\" style='cursor: pointer;'>";
            }
        }

        protected void btnRevocaMandato_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.PersoneXImprese rlegale = new SiarBLL.PersoneXImpreseCollectionProvider().GetById(Azienda.IdRapprlegaleUltimo);
                if (rlegale.IdPersona != Operatore.Utente.IdPersonaFisica)
                    throw new Exception("Solo il rappresentante legale è abilitato ad effettuare la revoca.");
                int id_mandato;
                if (!int.TryParse(hdnIdMandato.Value, out id_mandato)) throw new Exception("Nessun mandato da revocare trovato. Impossibile Continuare.");
                SiarLibrary.MandatiImpresa mandato = mandati_provider.GetById(id_mandato);
                if (mandato == null) throw new Exception("Nessun mandato da revocare trovato. Impossibile Continuare.");
                if (procure_provider.Find(null, null, Azienda.IdImpresa, mandato.IdUtenteAbilitato, null, null, null, null, true).Count > 0)
                    throw new Exception("Questo consulente ha delle procure attive, prima di revocare il mandato occorre revocare le procure speciali!");
                mandato.Attivo = false;
                mandato.DataFineValidita = DateTime.Now;
                mandato.IdOperatoreFine = ((SiarLibrary.Web.MasterPage)Master).Operatore.Utente.IdUtente;
                mandati_provider.Save(mandato);
                ShowMessage("Mandato aziendale revocato correttamente.");

            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnRevocaProcura_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.PersoneXImprese rlegale = new SiarBLL.PersoneXImpreseCollectionProvider().GetById(Azienda.IdRapprlegaleUltimo);
                if (rlegale.IdPersona != Operatore.Utente.IdPersonaFisica)
                    throw new Exception("Solo il rappresentante legale è abilitato ad effettuare la revoca della procura.");
                int id_procura;
                if (!int.TryParse(hdnIdProcura.Value, out id_procura)) throw new Exception("Nessuna procura da revocare trovato. Impossibile Continuare.");
                SiarLibrary.RichiestaConsulenteProcuraXBando procura = procure_provider.GetById(id_procura);
                if (procura == null) throw new Exception("Nessuna procura da revocare trovata. Impossibile Continuare.");
                procura.Attivo = false;
                procura.OperatoreRevoca = ((SiarLibrary.Web.MasterPage)Master).Operatore.Utente.IdUtente;
                procura.DataFine = DateTime.Now;
                procure_provider.Save(procura);
                ShowMessage("Procura speciale revocata correttamente.");

            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnCercaOperatore_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodFiscale.Text) || txtCodFiscale.Text.Length != 16)
                    throw new Exception("Digitare un codice fiscale valido.");
                SiarLibrary.PersonaFisica pf;
                SiarLibrary.PersonaFisicaCollection persone_trovate = new SiarBLL.PersonaFisicaCollectionProvider().Find(txtCodFiscale.Text);
                if (persone_trovate.Count > 0 && persone_trovate[0].Nome != null) pf = persone_trovate[0];
                else
                {
                    SianWebSrv.TraduzioneSianToSiar trad = new SianWebSrv.TraduzioneSianToSiar();
                    pf = trad.ScaricaDatiPersonaFisica(txtCodFiscale.Text, ConfigurationManager.AppSettings["AutoInsertUser_CFOperatore"]);
                }
                if (pf == null) throw new Exception("Il codice fiscale non corrisponde a nessuna persona fisica conosciuta.");
                hdnIdPersonaFisica.Value = pf.IdPersona;
                txtNominativoOperatore.Text = pf.Cognome + " " + pf.Nome;
                txtCFOperatore.Text = pf.CodiceFiscale;
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.PersoneXImprese rlegale = new SiarBLL.PersoneXImpreseCollectionProvider().GetById(Azienda.IdRapprlegaleUltimo);
                if (rlegale.IdPersona != Operatore.Utente.IdPersonaFisica)
                    throw new Exception("Solo il rappresentante legale è abilitato ad effettuare le richieste.");
                richiesta_selezionata = new SiarLibrary.RichiestaConsulente();
                richiesta_selezionata.DataInizioAbilitazione = txtDataInizio.Text;
                richiesta_selezionata.DataFineAbilitazione = txtDataFine.Text;
                richiesta_selezionata.IdImpresa = Azienda.IdImpresa;
                richiesta_selezionata.IdUtente = Operatore.Utente.IdUtente;
                richiesta_selezionata.IdConsulente = Convert.ToInt32(hdnIdPersonaFisica.Value);
                richiesta_selezionata.Inviata = false;
                richiesta_selezionata.ProcuraSpeciale = chkProcuraSpeciale.Checked;

                rich_prov.Save(richiesta_selezionata);

                SiarBLL.IndirizzarioCollectionProvider indiririzzario_provider = new SiarBLL.IndirizzarioCollectionProvider();
                SiarLibrary.Indirizzario sede_legale = indiririzzario_provider.GetById(Azienda.IdSedelegaleUltimo);
                if (sede_legale.Email != txtSLEmail.Text || sede_legale.Telefono != txtSLTelefono.Text || sede_legale.Pec != txtSLPec.Text)
                {
                    sede_legale.Email = txtSLEmail.Text;
                    sede_legale.Telefono = txtSLTelefono.Text;
                    sede_legale.Pec = txtSLPec.Text;
                    indiririzzario_provider.Save(sede_legale);
                }

                hdnIdRichiestaConsulente.Value = richiesta_selezionata.IdRichiestaConsulente.ToString();

                if (chkProcuraSpeciale.Checked)
                {
                    richiesta_selezionata_procura = new SiarLibrary.RichiestaConsulenteProcuraXBando();
                    richiesta_selezionata_procura.DataInserimento = DateTime.Now;
                    richiesta_selezionata_procura.IdConsulente = Convert.ToInt32(hdnIdPersonaFisica.Value);
                    richiesta_selezionata_procura.IdBando = lstBandiProcura.SelectedValue;
                    richiesta_selezionata_procura.OperatoreInserimento = Operatore.Utente.IdUtente;
                    richiesta_selezionata_procura.IdImpresa = Azienda.IdImpresa;
                    richiesta_selezionata_procura.Attivo = false;
                    richiesta_selezionata_procura.Approvata = false;
                    richiesta_selezionata_procura.IdRichiestaConsulente = richiesta_selezionata.IdRichiestaConsulente;
                    richiesta_selezionata_procura.Inviata = false;
                    richiesta_selezionata_procura.Istruita = false;

                    procure_provider.Save(richiesta_selezionata_procura);
                }

            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalvaProcura_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.RichiestaConsulenteCollection rc = rich_prov.Find(null, Azienda.IdImpresa, lstConsulentiAzienda.SelectedValue, null, true, true, false, null);
                SiarLibrary.RichiestaConsulente r;
                if (rc.Count == 0)
                {
                    r = new SiarLibrary.RichiestaConsulente();
                    SiarLibrary.Utenti utente = new SiarBLL.UtentiCollectionProvider().Find(null, lstConsulentiAzienda.SelectedValue, null, null, null, null, true)[0];
                    SiarLibrary.MandatiImpresa m = mandati_provider.Find(Azienda.IdImpresa, null, null, null, utente.IdUtente, null, null, "PSR", 1)[0];

                    r.DataInizioAbilitazione = m.DataInizioValidita;
                    r.DataFineAbilitazione = m.DataFineValidita;
                    r.IdImpresa = Azienda.IdImpresa;
                    r.IdUtente = Operatore.Utente.IdUtente;
                    r.IdConsulente = lstConsulentiAzienda.SelectedValue;
                    r.Inviata = true;
                    r.ProcuraSpeciale = true;
                    r.Approvata = true;
                    r.Segnatura = "N.D.";
                    r.Data = DateTime.Now;
                    r.Istruita = true;
                    r.SegnaturaIstruttoria = "N.D.";

                    rich_prov.Save(r);
                }
                else
                    r = rc[0];


                SiarLibrary.PersoneXImprese rlegale = new SiarBLL.PersoneXImpreseCollectionProvider().GetById(Azienda.IdRapprlegaleUltimo);
                if (rlegale.IdPersona != Operatore.Utente.IdPersonaFisica)
                    throw new Exception("Solo il rappresentante legale è abilitato ad effettuare le richieste.");
                richiesta_selezionata_procura = new SiarLibrary.RichiestaConsulenteProcuraXBando();
                richiesta_selezionata_procura.DataInserimento = DateTime.Now;
                richiesta_selezionata_procura.IdConsulente = lstConsulentiAzienda.SelectedValue;
                richiesta_selezionata_procura.IdBando = lstBandiProcuraTab3.SelectedValue;
                richiesta_selezionata_procura.OperatoreInserimento = Operatore.Utente.IdUtente;
                richiesta_selezionata_procura.IdImpresa = Azienda.IdImpresa;
                richiesta_selezionata_procura.Attivo = false;
                richiesta_selezionata_procura.Approvata = false;
                richiesta_selezionata_procura.IdRichiestaConsulente = r.IdRichiestaConsulente;
                richiesta_selezionata_procura.Inviata = false;
                richiesta_selezionata_procura.Istruita = false;

                procure_provider.Save(richiesta_selezionata_procura);

                hdnIdRichiestaConsulenteProcura.Value = richiesta_selezionata_procura.Id.ToString();
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnNuovoAllegatoPost_Click(object sender, EventArgs e)
        {
            ufcNAAllegato.IdFile = null;
        }

        protected void btnNuovoAllegatoProcuraPost_Click(object sender, EventArgs e)
        {
            ufcNAAllegatoProcura.IdFile = null;
        }

        protected void btnSalvaAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (ufcNAAllegato.IdFile == null)
                    throw new Exception("Attenzione! Nessun file caricato, impossibile continuare");
                if (allegato_selezionato == null)
                    allegato_selezionato = new SiarLibrary.RichiestaConsulenteAllegato();
                allegato_selezionato.IdRichiestaConsulente = richiesta_selezionata.IdRichiestaConsulente;
                allegato_selezionato.IdFile = ufcNAAllegato.IdFile;
                allegato_selezionato.Descrizione = txtDescrizione.Text;
                rich_all_prov.Save(allegato_selezionato);
                ShowMessage("Allegato salvato correttamente");
                allegato_selezionato = null;
                hdnIdAllegato.Value = "";
                ufcNAAllegato.IdFile = null;

            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalvaAllProcura_Click(object sender, EventArgs e)
        {
            try
            {
                if (ufcNAAllegatoProcura.IdFile == null)
                    throw new Exception("Attenzione! Nessun file caricato, impossibile continuare");
                if (allegato_selezionato_procura == null)
                    allegato_selezionato_procura = new SiarLibrary.RichiestaConsulenteProcuraAllegato();
                allegato_selezionato_procura.IdRichiestaConsulenteProcuraXBando = richiesta_selezionata_procura.Id;
                allegato_selezionato_procura.IdFile = ufcNAAllegatoProcura.IdFile;
                allegato_selezionato_procura.Descrizione = txtDescrizioneProcura.Text;
                rich_all_proc_prov.Save(allegato_selezionato_procura);
                ShowMessage("Allegato salvato correttamente");
                allegato_selezionato_procura = null;
                hdnIdAllegatoProcura.Value = "";
                ufcNAAllegatoProcura.IdFile = null;

            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                rich_all_prov.Delete(allegato_selezionato);
                allegato_selezionato = null;
                hdnIdAllegato.Value = "";
                ShowMessage("Allegato eliminato correttamente");

            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnDelProcura_Click(object sender, EventArgs e)
        {
            try
            {
                rich_all_proc_prov.Delete(allegato_selezionato_procura);
                allegato_selezionato_procura = null;
                hdnIdAllegatoProcura.Value = "";
                ShowMessage("Allegato eliminato correttamente");

            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnDettaglioPost_click(object sender, EventArgs e)
        {
            try
            {
                ufcNAAllegato.IdFile = allegato_selezionato.IdFile;
                txtDescrizione.Text = allegato_selezionato.Descrizione;
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnDettaglioProcuraPost_click(object sender, EventArgs e)
        {
            try
            {
                ufcNAAllegatoProcura.IdFile = allegato_selezionato_procura.IdFile;
                txtDescrizioneProcura.Text = allegato_selezionato_procura.Descrizione;
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSelezionaRichiesta_click(object sender, EventArgs e)
        {
            try
            {
                if (hdnIdAllegato.Value != "")
                    hdnIdAllegato.Value = "";
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSelezionaRichiestaProcura_click(object sender, EventArgs e)
        {
            try
            {
                if (hdnIdAllegatoProcura.Value != "")
                    hdnIdAllegatoProcura.Value = "";
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnNuovaRichiesta_Click(object sender, EventArgs e)
        {
            try
            {
                richiesta_selezionata = null;
                hdnIdRichiestaConsulente.Value = "";
                hdnIdPersonaFisica.Value = "";
                hdnIdAllegato.Value = "";

            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnInvia_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.PersoneXImprese rlegale = new SiarBLL.PersoneXImpreseCollectionProvider().GetById(Azienda.IdRapprlegaleUltimo);
                if (rlegale.IdPersona != Operatore.Utente.IdPersonaFisica)
                    throw new Exception("Solo il rappresentante legale è abilitato ad effettuare le richieste.");
                SiarLibrary.RichiestaConsulenteAllegatoCollection all_coll = rich_all_prov.Find(null, richiesta_selezionata.IdRichiestaConsulente, null);
                if (all_coll.Count == 0)
                    throw new Exception("Non è stato inserito nessun documento alla domanda. Impossibile continuare!.");
                if (chkProcuraSpeciale.Checked && lstBandiProcura.SelectedValue == null)
                    throw new Exception("Se si intende conferire al consulente la procura speciale occorre specificare il bando per cui si da la procura!");
                ucFirmaDocumento.DocumentoFirmatoEvent = ProtocollaDocFirmatoEvent;
                ucFirmaDocumento.FirmaObbligatoria = false;
                ucFirmaDocumento.Titolo = "RICHIESTA ABILITAZIONE CONSULENTE PER IMPRESA";
                ucFirmaDocumento.TipoDocumento = "RICHIESTA_CONS";
                ucFirmaDocumento.loadDocumento(Operatore.Utente.CfUtente, richiesta_selezionata.IdRichiestaConsulente);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnEliminaRichiesta_Click(object sender, EventArgs e)
        {
            try
            {
                if (richiesta_selezionata == null)
                    throw new Exception("Prima occorre selezionare la richiesta di consulente che si desidera eliminare.");
                if (richiesta_selezionata.ProcuraSpeciale)
                {
                    throw new Exception("Impossibile cancellare la richiesta da questa sezione, cancellarla nella sezione 'Gestione Procure Speciali'.");
                }

                //prima cancello tutti gli allegati se ci sono, poi cancello la domanda
                SiarLibrary.RichiestaConsulenteAllegatoCollection all_coll = rich_all_prov.Find(null, richiesta_selezionata.IdRichiestaConsulente, null);
                if (all_coll.Count > 0)
                {
                    rich_all_prov.DeleteCollection(all_coll);
                }

                rich_prov.Delete(richiesta_selezionata);

                richiesta_selezionata = null;
                hdnIdRichiestaConsulente.Value = "";
                hdnIdPersonaFisica.Value = "";
                hdnIdAllegato.Value = "";
                ShowMessage("Richiesta eliminata correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnInviaProcura_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.PersoneXImprese rlegale = new SiarBLL.PersoneXImpreseCollectionProvider().GetById(Azienda.IdRapprlegaleUltimo);
                if (rlegale.IdPersona != Operatore.Utente.IdPersonaFisica)
                    throw new Exception("Solo il rappresentante legale è abilitato ad effettuare le richieste.");
                SiarLibrary.RichiestaConsulenteProcuraAllegatoCollection all_coll = rich_all_proc_prov.Find(richiesta_selezionata_procura.Id, null);
                if (all_coll.Count == 0)
                    throw new Exception("Non è stato inserito nessun documento alla domanda. Impossibile continuare!.");
                if (lstConsulentiAzienda.SelectedValue == null || lstBandiProcuraTab3.SelectedValue == null)
                    throw new Exception("Se si intende conferire al consulente la procura speciale occorre specificare il consulente e il bando per cui si da la procura!");
                if (procure_provider.Find(null, null, Azienda.IdImpresa, lstConsulentiAzienda.SelectedValue, lstBandiProcuraTab3.SelectedValue, true, false, false, false).Count > 0)
                    throw new Exception("Esiste già una richiesta di procura per il bando selezionato e il consulente selezionato non ancora istruita!");
                if (procure_provider.Find(null, null, Azienda.IdImpresa, lstConsulentiAzienda.SelectedValue, lstBandiProcuraTab3.SelectedValue, null, null, null, true).Count > 0)
                    throw new Exception("Esiste già una procura attiva per il bando selezionato e il consulente selezionato!");
                ucFirmaDocumento.DocumentoFirmatoEvent = ProtocollaDocFirmatoProcuraEvent;
                ucFirmaDocumento.FirmaObbligatoria = false;
                ucFirmaDocumento.Titolo = "RICHIESTA ABILITAZIONE PROCURA SPECIALE CONSULENTE PER IMPRESA";
                ucFirmaDocumento.TipoDocumento = "RICHIESTA_PROC";
                ucFirmaDocumento.loadDocumento(Operatore.Utente.CfUtente, richiesta_selezionata_procura.Id);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnEliminaProcura_Click(object sender, EventArgs e)
        {
            try
            {
                if (richiesta_selezionata_procura == null)
                {
                    throw new Exception("Prima occorre selezionare la richiesta di consulente che si desidera eliminare.");
                }

                //prima cancello tutti gli allegati se ci sono, poi cancello la domanda
                SiarLibrary.RichiestaConsulenteProcuraAllegatoCollection all_coll = rich_all_proc_prov.Find(richiesta_selezionata_procura.Id, null);                
                if (all_coll.Count > 0)
                {
                    rich_all_proc_prov.DeleteCollection(all_coll);
                }

                SiarLibrary.RichiestaConsulente r = rich_prov.GetById(richiesta_selezionata_procura.IdRichiestaConsulente);
                if (r.Approvata == null || !r.Approvata)
                    rich_prov.Delete(r);

                procure_provider.Delete(richiesta_selezionata_procura);

                richiesta_selezionata_procura = null;
                hdnIdRichiestaConsulenteProcura.Value = "";
                hdnIdAllegatoProcura.Value = "";
                ShowMessage("Richiesta di procura eliminata correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void ProtocollaDocFirmatoEvent(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.Bando bandoProcuraSpeciale = null;
                if (chkProcuraSpeciale.Checked)
                    bandoProcuraSpeciale = new SiarBLL.BandoCollectionProvider().GetById(lstBandiProcura.SelectedValue);

                if (string.IsNullOrEmpty(ucFirmaDocumento.FileFirmato))
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk e segnalare il problema.");

                SiarLibrary.Protocollo p = new SiarLibrary.Protocollo("RM_INF");

                if (chkProcuraSpeciale.Checked)
                    p = new SiarLibrary.Protocollo(bandoProcuraSpeciale.CodEnte);

                SiarLibrary.PersonaFisica pf = new SiarBLL.PersonaFisicaCollectionProvider().GetById(Operatore.Utente.IdPersonaFisica);
                p.setCorrispondente(pf.Cognome, pf.Nome, null, "mittente");
                p.setDocumento("SchedaAbilitazioneConsulente.pdf", Convert.FromBase64String(ucFirmaDocumento.FileFirmato));

                string oggetto = "Richiesta Abilitazione Consulente SIGEF: ID_RICHIESTA " + richiesta_selezionata.IdRichiestaConsulente.ToString();

#if (!DEBUG)
                //Token cohesion
                object sessione_cohesion = Session["COHESION_TOKEN"];
                if (sessione_cohesion == null || string.IsNullOrEmpty(sessione_cohesion.ToString()))
                    throw new Exception("Non è stata trovata nessuna informazione sull'operatore di rilascio, impossibile continuare.");
                p.addAllegato("Autenticazione_Operatore.xml", p.GetSHA256(System.Text.Encoding.Unicode.GetBytes(sessione_cohesion.ToString())));
#endif
                //TRasmissione utente se richieste consulente
                if (!chkProcuraSpeciale.Checked)
                {
                    p.setTrasmisisoneUtente("", "", "TDI", "RESPONSABILE_PO", "ASSEGNAZIONE");
                }

                //Aggiungo allegati
                SiarLibrary.RichiestaConsulenteAllegatoCollection all_coll = rich_all_prov.Find(null, richiesta_selezionata.IdRichiestaConsulente, null);
                if (all_coll.Count == 0)
                    throw new Exception("Attenzione nessun allegato selezionato. Impossibile continuare!");
                else
                {
                    foreach (SiarLibrary.RichiestaConsulenteAllegato a_r in all_coll)
                    {
                        SiarLibrary.ArchivioFile f = new SiarBLL.ArchivioFileCollectionProvider().GetById(a_r.IdFile);
                        if (f == null) throw new Exception("Almeno uno dei documenti allegati alla presente domanda non è valido.");
                        p.addAllegato(f.NomeFile, f.HashCode);
                    }
                }

                string segnatura;
                if (chkProcuraSpeciale.Checked)
                {
                    string[] ss = new SiarBLL.BandoCollectionProvider().GetFascicolo(Convert.ToInt32(lstBandiProcura.SelectedValue));
                    if (ss[1] != null && ss[1] != "")
                        segnatura = p.ProtocolloIngresso(oggetto, ss[1]);
                    else
                        throw new Exception("Il fascicolo non è stato associato al bando, contattare il RUP di riferimento.");
                }
                else
                {
                    segnatura = p.ProtocolloIngresso(oggetto, System.Configuration.ConfigurationManager.AppSettings["FascicoloRichiesteProfilazione"]);
                }


                //ALLEGATI
                System.Collections.ArrayList allegatiProtocollo = new System.Collections.ArrayList();

#if (!DEBUG)
                // carico il token di cohesion come allegato alla domanda
                object sessione_cohesion2 = Session["COHESION_TOKEN"];
                if (sessione_cohesion2 == null || string.IsNullOrEmpty(sessione_cohesion2.ToString()))
                    throw new Exception("Non è stata trovata nessuna informazione sull'operatore di rilascio, impossibile continuare.");
                else
                {
                    SiarBLL.paleoWebService.Allegato all = new SiarBLL.paleoWebService.Allegato();
                    all.Descrizione = "Autenticazione_Operatore.xml";
                    all.Documento = new SiarBLL.paleoWebService.File();
                    all.Documento.NomeFile = "Autenticazione_Operatore.xml";
                    all.Documento.Stream = System.Text.Encoding.Unicode.GetBytes(sessione_cohesion2.ToString());
                    System.Collections.Generic.Dictionary<string, object> allegatoProtocollo = new System.Collections.Generic.Dictionary<string, object>();
                    allegatoProtocollo.Add("allegato", all);
                    allegatoProtocollo.Add("id_file", -1);
                    allegatoProtocollo.Add("tipo_origine", "richiesta");
                    allegatoProtocollo.Add("id_origine", richiesta_selezionata.IdRichiestaConsulente);
                    allegatiProtocollo.Add(allegatoProtocollo);
                }
#endif

                //Carico Allegati
                if (all_coll.Count == 0)
                    throw new Exception("Attenzione nessun allegato selezionato. Impossibile continuare!");
                else
                {
                    foreach (SiarLibrary.RichiestaConsulenteAllegato a_r in all_coll)
                    {
                        SiarLibrary.ArchivioFile f = new SiarBLL.ArchivioFileCollectionProvider().GetById(a_r.IdFile);
                        if (f == null) throw new Exception("Almeno uno dei documenti allegati alla presente domanda non è valido.");
                        string estensione = null;
                        if (f.Tipo != null) estensione = f.Tipo.Value.Substring(f.Tipo.Value.LastIndexOf("/") + 1);
                        //p.addAllegato(f.NomeFile, f.Contenuto, estensione);
                        SiarBLL.paleoWebService.Allegato all = new SiarBLL.paleoWebService.Allegato();
                        all.Descrizione = f.NomeFile;
                        all.Documento = new SiarBLL.paleoWebService.File();
                        all.Documento.NomeFile = f.NomeFile;

                        System.Collections.Generic.Dictionary<string, object> allegatoProtocollo = new System.Collections.Generic.Dictionary<string, object>();
                        allegatoProtocollo.Add("allegato", all);
                        allegatoProtocollo.Add("id_file", f.Id);
                        allegatoProtocollo.Add("tipo_origine", "richiesta");
                        allegatoProtocollo.Add("id_origine", richiesta_selezionata.IdRichiestaConsulente);
                        allegatiProtocollo.Add(allegatoProtocollo);
                    }
                }

                SiarLibrary.Protocollo protocolloAll = new SiarLibrary.Protocollo("RM_INF");

                if (chkProcuraSpeciale.Checked)
                    protocolloAll = new SiarLibrary.Protocollo(bandoProcuraSpeciale.CodEnte);

                protocolloAll.addAllegatiProtocollo(allegatiProtocollo, segnatura);

                richiesta_selezionata.Data = DateTime.Now;
                richiesta_selezionata.ProcuraSpeciale = chkProcuraSpeciale.Checked;
                richiesta_selezionata.Segnatura = segnatura;
                richiesta_selezionata.Inviata = true;
                richiesta_selezionata.Istruita = false;
                rich_prov.Save(richiesta_selezionata);

                if (chkProcuraSpeciale.Checked)
                {
                    SiarBLL.RichiestaConsulenteProcuraXBandoCollectionProvider richXbandoProvider = new SiarBLL.RichiestaConsulenteProcuraXBandoCollectionProvider(rich_prov.DbProviderObj);

                    SiarLibrary.RichiestaConsulenteProcuraXBandoCollection procuraBandoCollection = richXbandoProvider.Find(null, richiesta_selezionata.IdRichiestaConsulente, Azienda.IdImpresa, richiesta_selezionata.IdConsulente, null, false, false, false, false);
                    SiarLibrary.RichiestaConsulenteProcuraXBando procuraBando;
                    if (procuraBandoCollection.Count > 0)
                        procuraBando = procuraBandoCollection[0];
                    else
                        procuraBando = new SiarLibrary.RichiestaConsulenteProcuraXBando();
                    procuraBando.IdBando = lstBandiProcura.SelectedValue;
                    procuraBando.IdRichiestaConsulente = richiesta_selezionata.IdRichiestaConsulente;
                    procuraBando.IdImpresa = richiesta_selezionata.IdImpresa;
                    procuraBando.IdConsulente = richiesta_selezionata.IdConsulente;
                    procuraBando.OperatoreInserimento = Operatore.Utente.IdUtente;
                    procuraBando.DataInserimento = DateTime.Now;
                    procuraBando.DataInizio = richiesta_selezionata.DataInizioAbilitazione;
                    procuraBando.DataFine = richiesta_selezionata.DataFineAbilitazione;
                    procuraBando.Segnatura = segnatura;
                    procuraBando.Attivo = false;
                    procuraBando.Inviata = true;
                    procuraBando.Approvata = false;
                    procuraBando.Istruita = false;

                    richXbandoProvider.Save(procuraBando);

                    SiarLibrary.Email em = new SiarLibrary.Email("Avviso di ricezione per una richiesta di abilitazione Consulente con procura speciale (ID_RICHIESTA :" + richiesta_selezionata.IdRichiestaConsulente + " )",
                                    "<html><body>Si comunica che con prot. " + richiesta_selezionata.Segnatura + "<br />è stata ricevuta la Richiesta di abilitazione consulente con procura speciale con ID_RICHIESTA  " + richiesta_selezionata.IdRichiestaConsulente
                                + " da " + Operatore.Utente.Nominativo + " per l'impresa/ente " + richiesta_selezionata.RagioneSociale
                                + "<br />Tale richiesta è consultabile all'indirizzo <a href='" + Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + "' target=_blank>Clicca qui</a> ricercando la richiesta nel cruscotto sotto la 'Sezione abilitazione Consulente con procura speciale'"
                                + "<br /><br />Questa è una notifica automatica del sistema " + System.Configuration.ConfigurationManager.AppSettings["APP:NomeCompleto"]
                                + "<br />Si prega di non rispondere a questa email.</body></html>");
                    em.SetHtmlBodyMessage(true);
                    string[] destinatari = new string[1];

                    SiarLibrary.BandoResponsabili rup = new SiarBLL.BandoResponsabiliCollectionProvider().Find(bandoProcuraSpeciale.IdBando, null, null, true, true)[0];
                    SiarLibrary.Utenti utenteRup = new SiarBLL.UtentiCollectionProvider().GetById(rup.IdUtente);

                    if (utenteRup.Email != null)
                        destinatari[0] = utenteRup.Email;
                    else
                        destinatari[0] = "helpdesk.sigef@regione.marche.it";
                    em.SendNotification(destinatari, new string[] { });
                }
                else
                {
                    SiarLibrary.Email em = new SiarLibrary.Email("Avviso di ricezione per una richiesta di abilitazione Consulente (ID_RICHIESTA :" + richiesta_selezionata.IdRichiestaConsulente + " )",
                                        "<html><body>Si comunica che con prot. " + richiesta_selezionata.Segnatura + "<br />è stata ricevuta la Richiesta di abilitazione consulente con ID_RICHIESTA  " + richiesta_selezionata.IdRichiestaConsulente
                                    + " da " + Operatore.Utente.Nominativo + " per l'impresa/ente " + richiesta_selezionata.RagioneSociale
                                    + "<br />Tale richiesta è consultabile all'indirizzo <a href='" + Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + "' target=_blank>Clicca qui</a> ricercando la richiesta nel cruscotto sotto la 'Sezione abilitazione Consulente'"
                                    + "<br /><br />Questa è una notifica automatica del sistema " + System.Configuration.ConfigurationManager.AppSettings["APP:NomeCompleto"]
                                    + "<br />Si prega di non rispondere a questa email.</body></html>");
                    em.SetHtmlBodyMessage(true);
                    string[] destinatari = new string[1];
                    destinatari[0] = "helpdesk.sigef@regione.marche.it";
                    em.SendNotification(destinatari, new string[] { });
                }

                richiesta_selezionata = null;
                hdnIdRichiestaConsulente.Value = "";
                hdnIdPersonaFisica.Value = "";
                hdnIdAllegato.Value = "";

                ShowMessage("La richiesta di abilitazione consulente è stata salvata ed inviata correttamente al protocollo.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void ProtocollaDocFirmatoProcuraEvent(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.Bando bandoProcuraSpeciale = new SiarBLL.BandoCollectionProvider().GetById(richiesta_selezionata_procura.IdBando);

                if (string.IsNullOrEmpty(ucFirmaDocumento.FileFirmato))
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk e segnalare il problema.");

                SiarLibrary.Protocollo p = new SiarLibrary.Protocollo(bandoProcuraSpeciale.CodEnte);

                SiarLibrary.PersonaFisica pf = new SiarBLL.PersonaFisicaCollectionProvider().GetById(Operatore.Utente.IdPersonaFisica);
                p.setCorrispondente(pf.Cognome, pf.Nome, null, "mittente");
                p.setDocumento("SchedaAbilitazioneConsulenteProcura.pdf", Convert.FromBase64String(ucFirmaDocumento.FileFirmato));

                string oggetto = "Richiesta Abilitazione Consulente alla Procura speciale SIGEF: ID_RICHIESTA " + richiesta_selezionata_procura.Id.ToString();

#if (!DEBUG)
                //Token cohesion
                object sessione_cohesion = Session["COHESION_TOKEN"];
                if (sessione_cohesion == null || string.IsNullOrEmpty(sessione_cohesion.ToString()))
                    throw new Exception("Non è stata trovata nessuna informazione sull'operatore di rilascio, impossibile continuare.");
                p.addAllegato("Autenticazione_Operatore.xml", p.GetSHA256(System.Text.Encoding.Unicode.GetBytes(sessione_cohesion.ToString())));
#endif

                //Aggiungo allegati
                SiarLibrary.RichiestaConsulenteProcuraAllegatoCollection all_coll = rich_all_proc_prov.Find(richiesta_selezionata_procura.Id, null);
                if (all_coll.Count == 0)
                    throw new Exception("Attenzione nessun allegato selezionato. Impossibile continuare!");
                else
                {
                    foreach (SiarLibrary.RichiestaConsulenteProcuraAllegato a_r in all_coll)
                    {
                        SiarLibrary.ArchivioFile f = new SiarBLL.ArchivioFileCollectionProvider().GetById(a_r.IdFile);
                        if (f == null) throw new Exception("Almeno uno dei documenti allegati alla presente domanda non è valido.");
                        p.addAllegato(f.NomeFile, f.HashCode);
                    }
                }

                string segnatura;
                string fascicolo = fascicolo = new SiarBLL.BandoCollectionProvider().GetFascicolo(richiesta_selezionata_procura.IdBando)[1];
                segnatura = p.ProtocolloIngresso(oggetto, fascicolo);

                //ALLEGATI
                System.Collections.ArrayList allegatiProtocollo = new System.Collections.ArrayList();

#if (!DEBUG)
                // carico il token di cohesion come allegato alla domanda
                object sessione_cohesion2 = Session["COHESION_TOKEN"];
                if (sessione_cohesion2 == null || string.IsNullOrEmpty(sessione_cohesion2.ToString()))
                    throw new Exception("Non è stata trovata nessuna informazione sull'operatore di rilascio, impossibile continuare.");
                else
                {
                    SiarBLL.paleoWebService.Allegato all = new SiarBLL.paleoWebService.Allegato();
                    all.Descrizione = "Autenticazione_Operatore.xml";
                    all.Documento = new SiarBLL.paleoWebService.File();
                    all.Documento.NomeFile = "Autenticazione_Operatore.xml";
                    all.Documento.Stream = System.Text.Encoding.Unicode.GetBytes(sessione_cohesion2.ToString());
                    System.Collections.Generic.Dictionary<string, object> allegatoProtocollo = new System.Collections.Generic.Dictionary<string, object>();
                    allegatoProtocollo.Add("allegato", all);
                    allegatoProtocollo.Add("id_file", -1);
                    allegatoProtocollo.Add("tipo_origine", "richiesta");
                    allegatoProtocollo.Add("id_origine", richiesta_selezionata_procura.Id);
                    allegatiProtocollo.Add(allegatoProtocollo);
                }
#endif

                //Carico Allegati
                if (all_coll.Count == 0)
                    throw new Exception("Attenzione nessun allegato selezionato. Impossibile continuare!");
                else
                {
                    foreach (SiarLibrary.RichiestaConsulenteProcuraAllegato a_r in all_coll)
                    {
                        SiarLibrary.ArchivioFile f = new SiarBLL.ArchivioFileCollectionProvider().GetById(a_r.IdFile);
                        if (f == null) throw new Exception("Almeno uno dei documenti allegati alla presente domanda non è valido.");
                        string estensione = null;
                        if (f.Tipo != null) estensione = f.Tipo.Value.Substring(f.Tipo.Value.LastIndexOf("/") + 1);
                        //p.addAllegato(f.NomeFile, f.Contenuto, estensione);
                        SiarBLL.paleoWebService.Allegato all = new SiarBLL.paleoWebService.Allegato();
                        all.Descrizione = f.NomeFile;
                        all.Documento = new SiarBLL.paleoWebService.File();
                        all.Documento.NomeFile = f.NomeFile;

                        System.Collections.Generic.Dictionary<string, object> allegatoProtocollo = new System.Collections.Generic.Dictionary<string, object>();
                        allegatoProtocollo.Add("allegato", all);
                        allegatoProtocollo.Add("id_file", f.Id);
                        allegatoProtocollo.Add("tipo_origine", "richiesta");
                        allegatoProtocollo.Add("id_origine", richiesta_selezionata_procura.Id);
                        allegatiProtocollo.Add(allegatoProtocollo);
                    }
                }

                SiarLibrary.Protocollo protocolloAll = new SiarLibrary.Protocollo(bandoProcuraSpeciale.CodEnte);

                protocolloAll.addAllegatiProtocollo(allegatiProtocollo, segnatura);

                SiarBLL.RichiestaConsulenteProcuraXBandoCollectionProvider richXbandoProvider = new SiarBLL.RichiestaConsulenteProcuraXBandoCollectionProvider();

                richiesta_selezionata_procura.IdBando = lstBandiProcuraTab3.SelectedValue;
                richiesta_selezionata_procura.IdRichiestaConsulente = richiesta_selezionata_procura.IdRichiestaConsulente;
                richiesta_selezionata_procura.IdImpresa = Azienda.IdImpresa;
                richiesta_selezionata_procura.IdConsulente = lstConsulentiAzienda.SelectedValue;
                richiesta_selezionata_procura.OperatoreInserimento = Operatore.Utente.IdUtente;
                richiesta_selezionata_procura.DataInserimento = DateTime.Now;
                richiesta_selezionata_procura.Segnatura = segnatura;
                richiesta_selezionata_procura.Attivo = false;
                richiesta_selezionata_procura.Inviata = true;
                richiesta_selezionata_procura.Istruita = false;
                richiesta_selezionata_procura.Approvata = false;

                richXbandoProvider.Save(richiesta_selezionata_procura);

                SiarLibrary.Email em = new SiarLibrary.Email("Avviso di ricezione per una richiesta di abilitazione di un Consulente alla procura speciale (ID_RICHIESTA :" + richiesta_selezionata_procura.Id + " )",
                                "<html><body>Si comunica che con prot. " + richiesta_selezionata_procura.Segnatura + "<br />è stata ricevuta la Richiesta di abilitazione consulente con procura speciale con ID_RICHIESTA  " + richiesta_selezionata_procura.Id
                            + " da " + Operatore.Utente.Nominativo + " per l'impresa/ente " + Azienda.RagioneSociale
                            + "<br />Tale richiesta è consultabile all'indirizzo <a href='" + Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + "' target=_blank>Clicca qui</a> ricercando la richiesta nel cruscotto sotto la 'Sezione abilitazione Consulente con procura speciale'"
                            + "<br /><br />Questa è una notifica automatica del sistema " + System.Configuration.ConfigurationManager.AppSettings["APP:NomeCompleto"]
                            + "<br />Si prega di non rispondere a questa email.</body></html>");
                em.SetHtmlBodyMessage(true);
                string[] destinatari = new string[1];

                SiarLibrary.BandoResponsabili rup = new SiarBLL.BandoResponsabiliCollectionProvider().Find(bandoProcuraSpeciale.IdBando, null, null, true, true)[0];
                SiarLibrary.Utenti utenteRup = new SiarBLL.UtentiCollectionProvider().GetById(rup.IdUtente);

                if (utenteRup.Email != null)
                    destinatari[0] = utenteRup.Email;
                else
                    destinatari[0] = "helpdesk.sigef@regione.marche.it";
                em.SendNotification(destinatari, new string[] { });

                richiesta_selezionata_procura = null;
                hdnIdRichiestaConsulenteProcura.Value = "";
                hdnIdAllegatoProcura.Value = "";

                ShowMessage("La richiesta di abilitazione del consulente alla procura speciale è stata salvata ed inviata correttamente al protocollo.");
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}