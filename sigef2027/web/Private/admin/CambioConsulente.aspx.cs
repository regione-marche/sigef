using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.admin
{
    public partial class CambioConsulente : SiarLibrary.Web.PrivatePage
    {

        private int _idProfiloConsulete = int.Parse(System.Configuration.ConfigurationManager.AppSettings["Profilo_Consulente"]);


        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "cambio_consulente";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdProgetto.Text) && string.IsNullOrEmpty(txtIdDomanda.Text) && string.IsNullOrEmpty(txtIdVariante.Text))
            {
                int idProgetto = 0;
                int.TryParse(txtIdProgetto.Text, out idProgetto);
                cercaConsulente(idProgetto, "progetto");
            }
            else if (string.IsNullOrEmpty(txtIdProgetto.Text) && !string.IsNullOrEmpty(txtIdDomanda.Text) && string.IsNullOrEmpty(txtIdVariante.Text))
            {
                int idDomanda = 0;
                int.TryParse(txtIdDomanda.Text, out idDomanda);
                cercaConsulente(idDomanda, "domanda_pagamento");
            }
            else if (string.IsNullOrEmpty(txtIdProgetto.Text) && string.IsNullOrEmpty(txtIdDomanda.Text) && !string.IsNullOrEmpty(txtIdVariante.Text))
            {
                int idVariante = 0;
                int.TryParse(txtIdVariante.Text, out idVariante);
                cercaConsulente(idVariante, "variante");
            }
            else
            {
                ShowError("Cercare solo un unico id pratica");
            }
        }

        public void cercaConsulente(int idPratica, string tipoPratica)
        {
            try
            {
                SiarBLL.ProgettoCollectionProvider pProvider = new SiarBLL.ProgettoCollectionProvider();
                SiarBLL.DomandaDiPagamentoCollectionProvider dProvider = new SiarBLL.DomandaDiPagamentoCollectionProvider();
                SiarBLL.VariantiCollectionProvider vProvider = new SiarBLL.VariantiCollectionProvider();
                SiarBLL.UtentiCollectionProvider uProvider = new SiarBLL.UtentiCollectionProvider();

                SiarLibrary.Utenti u = new SiarLibrary.Utenti();
                SiarLibrary.Progetto p = new SiarLibrary.Progetto();

                switch (tipoPratica)
                {
                    case "progetto":
                        p = pProvider.GetById(idPratica);
                        if (p == null) throw new Exception("Digitare un id valido.");
                        u = uProvider.GetById(p.OperatoreCreazione);
                        txtNominativoOperatore.Text = u.Nominativo;
                        txtCFOperatore.Text = u.CfUtente;
                        cercaImpresa(p.IdImpresa);
                        break;
                    case "domanda_pagamento":
                        SiarLibrary.DomandaDiPagamento d = dProvider.GetById(idPratica);
                        if (d == null) throw new Exception("Digitare un id valido.");
                        u = uProvider.Find(d.CfOperatore, null, null, null, null, null, true)[0];
                        txtNominativoOperatore.Text = u.Nominativo;
                        txtCFOperatore.Text = u.CfUtente;
                        p = pProvider.GetById(d.IdProgetto);
                        cercaImpresa(p.IdImpresa);
                        break;
                    case "variante":
                        SiarLibrary.Varianti v = vProvider.GetById(idPratica);
                        if (v == null) throw new Exception("Digitare un id valido.");
                        u = uProvider.Find(v.Operatore, null, null, null, null, null, true)[0];
                        txtNominativoOperatore.Text = u.Nominativo;
                        txtCFOperatore.Text = u.CfUtente;
                        p = pProvider.GetById(v.IdProgetto);
                        cercaImpresa(p.IdImpresa);
                        break;
                }

                hdnIdOperatore.Value = u.IdUtente;
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        public void cercaImpresa(int idImpresa)
        {
            SiarBLL.ImpresaCollectionProvider iProvider = new SiarBLL.ImpresaCollectionProvider();
            SiarLibrary.Impresa i = iProvider.GetById(idImpresa);
            txtRagioneSociale.Text = i.RagioneSociale;
            txtPivaImpresa.Text = i.CodiceFiscale;
            hdnIdImpresa.Value = i.IdImpresa;
        }

        protected void btCercaOperatore_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.UtentiCollection UtenteSel = new SiarBLL.UtentiCollectionProvider().Find(txtCercaOperatore.Text, null, null, null, null, null, true);
                if (UtenteSel.Count > 0)
                {
                    SiarLibrary.UtentiStoricoCollection usrConsulente = new SiarBLL.UtentiStoricoCollectionProvider().Find(UtenteSel[0].IdUtente, null, _idProfiloConsulete, true);

                    //Verifico se l'utente selezionato é un rappresentante legale
                    bool israppr = new SiarBLL.ImpresaCollectionProvider().IsRapprLegale(Int32.Parse(hdnIdImpresa.Value), UtenteSel[0].CfUtente);
                    if (israppr)
                    {
                        lblAvviso.Text = "Stai per effettuare la modifica per rappresentante legale (NON consulente)";
                        usrConsulente = new SiarBLL.UtentiStoricoCollectionProvider().Find(UtenteSel[0].IdUtente, null, null, true);
                    }
                    if (usrConsulente.Count > 0)
                    {
                        SiarLibrary.Utenti nuovoConsulente = UtenteSel[0];

                        SiarBLL.MandatiImpresaCollectionProvider mIProvider = new SiarBLL.MandatiImpresaCollectionProvider();
                        SiarLibrary.MandatiImpresaCollection mandati = mIProvider.Find(hdnIdImpresa.Value, null, null, null, nuovoConsulente.IdUtente, null, null, null, true);

                        if (mandati.Count > 0 || israppr)
                        {
                            txtNominativoNuovoConsulente.Text = nuovoConsulente.Nominativo;
                            txtCfNuovoConsulente.Text = nuovoConsulente.CfUtente;
                            hdnIdNuovoConsulente.Value = nuovoConsulente.IdUtente;
                        }
                        else
                            throw new Exception("L'utente selezionato non ha un mandato impresa attivo per l'impresa selezionata.");
                    }
                    else
                        throw new Exception("L'utente selezionato non ha il ruolo Consulente abilitato.");
                }
                else
                    throw new Exception("Utente non inserito in anagrafica.");

            }
            catch (Exception ex) { 
                ShowError(ex);
                txtCfNuovoConsulente.Text = null;
                txtNominativoNuovoConsulente.Text = null;
                hdnIdNuovoConsulente.Value = null;
            }
        }

        protected void btnCambiaConsulente_Click(object sender, EventArgs e)
        {
            SiarBLL.ProgettoCollectionProvider pProvider = new SiarBLL.ProgettoCollectionProvider();
            SiarBLL.ProgettoStoricoCollectionProvider pStoricoProvider = new SiarBLL.ProgettoStoricoCollectionProvider(pProvider.DbProviderObj);
            SiarBLL.DomandaDiPagamentoCollectionProvider dProvider = new SiarBLL.DomandaDiPagamentoCollectionProvider();
            SiarBLL.VariantiCollectionProvider vProvider = new SiarBLL.VariantiCollectionProvider();
            SiarBLL.UtentiCollectionProvider uProvider = new SiarBLL.UtentiCollectionProvider();
            SiarBLL.UtentiStoricoCollectionProvider uSProvider = new SiarBLL.UtentiStoricoCollectionProvider(pProvider.DbProviderObj);
            SiarBLL.BackupCambioConsulenteCollectionProvider backupProvider = new SiarBLL.BackupCambioConsulenteCollectionProvider(pProvider.DbProviderObj);

            try
            {
                pProvider.DbProviderObj.BeginTran();

                if (string.IsNullOrEmpty(hdnIdOperatore.Value)) throw new Exception("Selezionare una pratica valida.");
                if (string.IsNullOrEmpty(hdnIdNuovoConsulente.Value)) throw new Exception("Selezionare un nuovo consulente valido.");

                if (!string.IsNullOrEmpty(txtIdProgetto.Text) && string.IsNullOrEmpty(txtIdDomanda.Text) && string.IsNullOrEmpty(txtIdVariante.Text))
                {
                    int idProgetto = 0;
                    int.TryParse(txtIdProgetto.Text, out idProgetto);

                    SiarLibrary.Progetto p = pProvider.GetById(idProgetto);

                    int operatoreCreazione = p.OperatoreCreazione;

                    p.OperatoreCreazione = hdnIdNuovoConsulente.Value;
                    // cambio l'operatore del progetto
                    pProvider.Save(p);

                    SiarLibrary.ProgettoStoricoCollection pStoricoCollection = pStoricoProvider.Find(idProgetto, null, null);

                    foreach (SiarLibrary.ProgettoStorico pStorico in pStoricoCollection)
                    {
                        if (pStorico.Operatore == operatoreCreazione)
                        {
                            pStorico.Operatore = hdnIdNuovoConsulente.Value;
                            pStoricoProvider.Save(pStorico);
                        }
                    }


                    SiarLibrary.UtentiStoricoCollection utenteStoricoCollection = uSProvider.Find(hdnIdOperatore.Value, null, null, true);

                    Boolean trovato = false;

                    DateTime dataOriginale = new DateTime();

                    foreach (SiarLibrary.UtentiStorico s in utenteStoricoCollection)
                    {
                        if (s.Data < p.DataCreazione && !trovato)
                        {
                            // DI TUTTE LE DATE CHE SONO NELLO STORICO DELL'ORIGINALE PRENDO LA PRIMA CHE è < DELLA DATA DI CREAZIONE DEL PROGETTO
                            SiarLibrary.UtentiStorico nuovoOperatoreStorico = uSProvider.Find(hdnIdNuovoConsulente.Value, null, null, true)[0];
                            dataOriginale = nuovoOperatoreStorico.Data;
                            nuovoOperatoreStorico.Data = s.Data;
                            uSProvider.Save(nuovoOperatoreStorico);
                            trovato = true;
                        }
                    }

                    SiarLibrary.BackupCambioConsulente backup = new SiarLibrary.BackupCambioConsulente();

                    backup.CfUtenteOriginale = txtCFOperatore.Text;
                    backup.CfNuovoUtente = txtCfNuovoConsulente.Text;
                    backup.DataCambioOperatore = DateTime.Now;
                    backup.DataUtenteStoricoOriginaleNuovoUtente = dataOriginale;
                    backup.IdProgetto = idProgetto;

                    backupProvider.Save(backup);

                    pProvider.DbProviderObj.Commit();

                }
                else if (string.IsNullOrEmpty(txtIdProgetto.Text) && !string.IsNullOrEmpty(txtIdDomanda.Text) && string.IsNullOrEmpty(txtIdVariante.Text))
                {
                    int idDomanda = 0;
                    int.TryParse(txtIdDomanda.Text, out idDomanda);

                    SiarLibrary.DomandaDiPagamento d = dProvider.GetById(idDomanda);

                    string operatoreCreazione = d.CfOperatore;

                    d.CfOperatore = txtCfNuovoConsulente.Text;
                    // cambio l'operatore del progetto
                    dProvider.Save(d);

                    SiarLibrary.BackupCambioConsulente backup = new SiarLibrary.BackupCambioConsulente();

                    backup.CfUtenteOriginale = txtCFOperatore.Text;
                    backup.CfNuovoUtente = txtCfNuovoConsulente.Text;
                    backup.DataCambioOperatore = DateTime.Now;
                    // SOLO PER  I PROGETTI OCCORRE FARSI UN BACKUP DELLE DATE, DOMANDE DI PAGAMENTO E VARIANTI NON NESSU CONTROLLO SULLE DATE
                    backup.DataUtenteStoricoOriginaleNuovoUtente = DateTime.Now;
                    backup.IdDomandaPagamento = idDomanda;

                    backupProvider.Save(backup);

                    pProvider.DbProviderObj.Commit();

                }
                else if (string.IsNullOrEmpty(txtIdProgetto.Text) && string.IsNullOrEmpty(txtIdDomanda.Text) && !string.IsNullOrEmpty(txtIdVariante.Text))
                {
                    int idVariante = 0;
                    int.TryParse(txtIdVariante.Text, out idVariante);

                    SiarLibrary.Varianti v = vProvider.GetById(idVariante);

                    string operatoreCreazione = v.Operatore;

                    v.Operatore = txtCfNuovoConsulente.Text;
                    // cambio l'operatore del progetto
                    vProvider.Save(v);

                    SiarLibrary.BackupCambioConsulente backup = new SiarLibrary.BackupCambioConsulente();

                    backup.CfUtenteOriginale = txtCFOperatore.Text;
                    backup.CfNuovoUtente = txtCfNuovoConsulente.Text;
                    backup.DataCambioOperatore = DateTime.Now;
                    // SOLO PER  I PROGETTI OCCORRE FARSI UN BACKUP DELLE DATE, DOMANDE DI PAGAMENTO E VARIANTI NON NESSU CONTROLLO SULLE DATE
                    backup.DataUtenteStoricoOriginaleNuovoUtente = DateTime.Now;
                    backup.IdVariante = idVariante;

                    backupProvider.Save(backup);

                    pProvider.DbProviderObj.Commit();
                    
                }
                ShowMessage("Consulente cambiato correttamente.");
                clearForm();
            }
            catch (Exception ex) { ShowError(ex); pProvider.DbProviderObj.Rollback(); }
        }

        private void clearForm()
        {
            txtNominativoOperatore.Text = string.Empty;
            txtCFOperatore.Text = string.Empty;
            hdnIdOperatore.Value = string.Empty;
            hdnIdImpresa.Value = string.Empty;
            txtPivaImpresa.Text = string.Empty;
            txtCercaOperatore.Text = string.Empty;
            hdnIdNuovoConsulente.Value = string.Empty;
            txtCfNuovoConsulente.Text = string.Empty;
            txtRagioneSociale.Text = string.Empty;
            txtNominativoNuovoConsulente.Text = string.Empty;
        }
    }
}