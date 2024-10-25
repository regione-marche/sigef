using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.Istruttoria
{
    public partial class DecretiDecadenza : SiarLibrary.Web.IstruttoriaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "collaboratori_istruttoria";
            base.OnPreInit(e);
        }

        SiarBLL.AttiCollectionProvider atti_provider = new SiarBLL.AttiCollectionProvider();
        SiarLibrary.Atti decreto_selezionato = null;
        SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider();

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_progetto, id_atto;
            if (int.TryParse(hdnIdProgetto.Value, out id_progetto)) ucInfoDomanda.Progetto = progetto_provider.GetById(id_progetto);
            if (int.TryParse(hdnIdAtto.Value, out id_atto)) decreto_selezionato = atti_provider.GetById(id_atto);
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (ucInfoDomanda.Progetto != null)
            {
                ucInfoDomanda.Visible = true;
                ucInfoDomanda.loadData();
                if (ucInfoDomanda.Progetto.CodStato == "E")
                    if (ucInfoDomanda.Progetto.IdAtto != null)
                    {
                        decreto_selezionato = atti_provider.GetById(ucInfoDomanda.Progetto.IdAtto);
                        if (decreto_selezionato != null)
                        {
                            btnCercaDecreto.Enabled = btnRegistraDecadenza.Enabled = false;
                            txtAttoNumero.Text = decreto_selezionato.Numero;
                            txtAttoData.Text = decreto_selezionato.Data;
                            lstAttoRegistro.SelectedValue = decreto_selezionato.Registro;
                            lstAttoDefinizione.SelectedValue = decreto_selezionato.CodDefinizione;
                        }
                    }
            }

            lstAttoDefinizione.DataBind();
            lstAttoRegistro.DataBind();
            lstAttoOrgIstituzionale.DataBind();
            lstAttoTipo.DataBind();
            if (decreto_selezionato != null)
            {
                hdnIdAtto.Value = decreto_selezionato.IdAtto;
                txtAttoDescrizione.Text = decreto_selezionato.Descrizione;
                lstAttoOrgIstituzionale.SelectedValue = decreto_selezionato.CodOrganoIstituzionale;
                if (!string.IsNullOrEmpty(decreto_selezionato.CodTipo))
                {
                    lstAttoTipo.SelectedValue = decreto_selezionato.CodTipo;
                    lstAttoTipo.Enabled = false;
                }
                txtAttoBurNumero.Text = decreto_selezionato.NumeroBur;
                txtAttoBurData.Text = decreto_selezionato.DataBur;
                btnVidualizzaDecreto.Disabled = false;
                btnVidualizzaDecreto.Attributes.Add("onclick", "visualizzaAtto(" + decreto_selezionato.IdAtto + ");");
            }
            else pulisciCampiDecreto();
            base.OnPreRender(e);
        }

        private void pulisciCampiDecreto()
        {
            txtAttoData.Text = "";
            txtAttoNumero.Text = "";
            lstAttoRegistro.ClearSelection();
            lstAttoTipo.ClearSelection();
            lstAttoOrgIstituzionale.ClearSelection();
            txtAttoDescrizione.Text = "";
            txtAttoBurData.Text = "";
            txtAttoBurNumero.Text = "";
            hdnIdAtto.Value = "";
        }

        protected void btnRegistraDecadenza_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucInfoDomanda.Progetto == null) throw new Exception("Nessuna domanda di aiuto selezionata.");
                if (decreto_selezionato == null) throw new Exception("Il decreto cercato non è stato trovato.");

                SiarBLL.ProgettoStoricoCollectionProvider pstorico_provider = new SiarBLL.ProgettoStoricoCollectionProvider(progetto_provider.DbProviderObj);
                progetto_provider.DbProviderObj.BeginTran();
                SiarLibrary.DbStaticProvider.ControlloStatoProgettoXDecadenza(ucInfoDomanda.Progetto.IdProgetto, progetto_provider.DbProviderObj);
                if (decreto_selezionato.IdAtto == null)
                {
                    // se non e' ancora salvato sul db controllo che non sia duplicato
                    SiarLibrary.AttiCollection atti_simili = atti_provider.Find(decreto_selezionato.Numero, decreto_selezionato.Data, "D", decreto_selezionato.Registro);
                    if (atti_simili.Count > 0) decreto_selezionato = atti_simili[0];
                }
                // se non è ancora definita la tipologia dell'atto, la salvo
                if (decreto_selezionato.CodTipo == null) decreto_selezionato.CodTipo = lstAttoTipo.SelectedValue;
                atti_provider.Save(decreto_selezionato);

                // controllo che ci sia un unico stato escluso
                SiarLibrary.ProgettoStoricoCollection pstorico_cc = pstorico_provider.Find(ucInfoDomanda.Progetto.IdProgetto, "E", null);
                if (pstorico_cc.Count == 0) // se non c'e' uno stato escluso, cambio lo stato del progetto (in caso di rinuncia o altro)
                {
                    progetto_provider.CambioStatoProgetto(ucInfoDomanda.Progetto, "E", decreto_selezionato.IdAtto, Operatore);
                    if (ucInfoDomanda.Progetto.IdProgIntegrato != null)
                    {
                        SiarLibrary.ProgettoCollection progetti_correlati = progetto_provider.Find(null, null, ucInfoDomanda.Progetto.IdProgIntegrato, null, null, false, true);
                        foreach (SiarLibrary.Progetto p in progetti_correlati)
                            if (p.IdProgetto != p.IdProgIntegrato) progetto_provider.CambioStatoProgetto(p, "E", Operatore);
                    }
                }
                else // se c'e' gia' lo stato escluso, ovvero in caso di bocciatura del saldo aggiorno i dati dello storico con la data dell'atto
                {
                    pstorico_cc[0].Data = decreto_selezionato.Data;
                    pstorico_cc[0].Operatore = Operatore.Utente.IdUtente;
                    pstorico_cc[0].IdAtto = decreto_selezionato.IdAtto;
                    pstorico_provider.Save(pstorico_cc[0]);
                }
                progetto_provider.DbProviderObj.Commit();
                ShowMessage("Decreto registrato correttamente.");
                ucInfoDomanda.Progetto = progetto_provider.GetById(ucInfoDomanda.Progetto.IdProgetto);
            }
            catch (Exception ex) { progetto_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnCercaProgetto_Click(object sender, EventArgs e)
        {
            try
            {
                int id_progetto;
                if (!int.TryParse(txtIdProgetto.Text, out id_progetto)) throw new Exception("Digitare un numero domanda valido.");
                SiarLibrary.Progetto p = progetto_provider.GetById(id_progetto);
                if (p == null) throw new Exception("Nessuna domanda di aiuto trovata.");
                ucInfoDomanda.Progetto = p;
                hdnIdProgetto.Value = ucInfoDomanda.Progetto.IdProgetto;
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnCercaDecreto_Click(object sender, EventArgs e)
        {
            try
            {
                int numero;
                int.TryParse(txtAttoNumero.Text, out numero);
                DateTime data;
                DateTime.TryParse(txtAttoData.Text, out data);
                string registro = lstAttoRegistro.SelectedValue;
                if (!string.IsNullOrEmpty(lstAttoRegistro.SelectedValue) && lstAttoRegistro.SelectedValue.IndexOf("|") > 0)
                    registro = lstAttoRegistro.SelectedValue.Substring(0, lstAttoRegistro.SelectedValue.IndexOf("|"));
                // controllo che l'atto sia registrato su db, altrimenti lo importo
                SiarLibrary.AttiCollection atti_trovati = atti_provider.Find(numero, data, lstAttoDefinizione.SelectedValue, registro);
                if (atti_trovati.Count == 0)
                {
                    atti_trovati = atti_provider.ImportaAtto(numero, data, lstAttoDefinizione.SelectedValue, lstAttoRegistro.SelectedValue);
                    if (atti_trovati.Count > 0) atti_provider.Save(atti_trovati[0]);
                }
                if (atti_trovati.Count > 0) decreto_selezionato = atti_trovati[0];
                else ShowError("La ricerca non ha prodotto nessun risultato.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnNuovaDecadenza_Click(object sender, EventArgs e)
        {
            ucInfoDomanda.Progetto = null;
            hdnIdProgetto.Value = "";
            decreto_selezionato = null;
        }
    }
}
