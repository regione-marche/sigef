using SiarLibrary.NullTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.admin
{
    public partial class RuoliPotereFirma : SiarLibrary.Web.PrivatePage
    {
        SiarBLL.PersoneXImpreseCollectionProvider personeProvider = new SiarBLL.PersoneXImpreseCollectionProvider();
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "gestione_altri_ruoli";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            StringNT cfUtenteFilter = null;
            if (!string.IsNullOrEmpty(txtCfFilter.Text))
                cfUtenteFilter = txtCfFilter.Text;
            IntNT idImpresaFilter = null;
            if (!string.IsNullOrEmpty(txtPivaFilter.Text))
            {
                SiarBLL.ImpresaCollectionProvider impresaProvider = new SiarBLL.ImpresaCollectionProvider();
                SiarLibrary.Impresa impresaFilter = impresaProvider.GetByCuaa(txtPivaFilter.Text);
                if (impresaFilter != null)
                    idImpresaFilter = impresaFilter.IdImpresa;
            }
            SiarLibrary.PersoneXImpreseCollection persone_x_imprese = personeProvider.Find(null, cfUtenteFilter, idImpresaFilter, null, null, null);
            dgPersoneXimprese.DataSource = persone_x_imprese;
            dgPersoneXimprese.ItemDataBound += new DataGridItemEventHandler(dgPersoneXimprese_ItemDataBound);
            dgPersoneXimprese.Titolo = "Elementi trovati: " + persone_x_imprese.Count;
            dgPersoneXimprese.DataBind();

            lstRuolo.DataBind();

            base.OnPreRender(e);
        }

        void dgPersoneXimprese_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            SiarLibrary.PersoneXImprese p = (SiarLibrary.PersoneXImprese)e.Item.DataItem;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.Impresa impresa = new SiarBLL.ImpresaCollectionProvider().GetById(p.IdImpresa);
                e.Item.Cells[5].Text = impresa.RagioneSociale + " - " + impresa.Cuaa;
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            caricaDati();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        public void clearForm() {
            hdnIdPpi.Value = string.Empty;
            txtCercaOperatore.Text = string.Empty;
            txtRagSociale.Text = string.Empty;
            txtCFabilitato.Text = string.Empty;
            txtNominativoOperatore.Text = string.Empty;
            txtDataInizio.Text = string.Empty;
            txtDataFV.Text = string.Empty;
            chkAttivo.Checked = false;
            lstRuolo.SelectedIndex = -1;
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {

        }

        private void caricaDati()
        {
            if (!string.IsNullOrEmpty(hdnIdPpi.Value))
            {
                try
                {
                    SiarLibrary.PersoneXImprese selected = personeProvider.GetById(hdnIdPpi.Value);
                    scaricaDatiUtente(selected.CodiceFiscale);
                    txtCercaOperatore.Text = selected.CodiceFiscale;
                    SiarLibrary.Impresa i = new SiarBLL.ImpresaCollectionProvider().GetById(selected.IdImpresa);
                    scaricaDatiImpresa(i.Cuaa);
                    txtCFabilitato.Text = i.Cuaa;
                    txtDataInizio.Text = selected.DataInizio;
                    txtDataFV.Text = selected.DataFine;
                    lstRuolo.SelectedValue = selected.CodRuolo;
                    chkAttivo.Checked = selected.Attivo;
                }
                catch (Exception ex) { ShowError(ex.Message); }
            }
        }

        public void btnScaricaAT_Click(object sender, EventArgs e)
        {
            try
            {
                scaricaDatiImpresa(txtCFabilitato.Text);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        public void scaricaDatiImpresa(string piva)
        {
            //SiarLibrary.DbStaticProvider.isCuaa(txtCFabilitato.Text);
            SiarBLL.ImpresaCollectionProvider impresaColl = new SiarBLL.ImpresaCollectionProvider();
            SiarLibrary.Impresa impresa = impresaColl.GetByCuaa(piva.ToUpper());
            if (impresa == null)
            {
                SianWebSrv.TraduzioneSianToSiar trad = new SianWebSrv.TraduzioneSianToSiar();
                //trad.ScaricaDatiAzienda(txtCFabilitato.Text.ToUpper(), null, utente_selezionato.CfUtente);
                //trad.ScaricaDatiAzienda(txtCFabilitato.Text.ToUpper(), null, ((SiarLibrary.Web.MasterPage)Page.Master).Operatore.Utente.CfUtente);
                if (System.Configuration.ConfigurationManager.AppSettings["ScaricaImpresa_CFOperatore"] != "")
                    trad.ScaricaDatiAzienda(piva.ToUpper(), null, System.Configuration.ConfigurationManager.AppSettings["ScaricaImpresa_CFOperatore"]);
                else
                    trad.ScaricaDatiAzienda(piva.ToUpper(), null, ((SiarLibrary.Web.MasterPage)Page.Master).Operatore.Utente.CfUtente);
            }
            impresa = impresaColl.GetByCuaa(piva.ToUpper());
            if (impresa == null) throw new Exception("L`impresa cercata non è stata trovata.");
            hdnIdImpresa.Value = impresa.IdImpresa;
            txtRagSociale.Text = impresa.RagioneSociale;
        }

        public void btCercaOperatore_Click(object sender, EventArgs e)
        {
            try
            {
                scaricaDatiUtente(txtCercaOperatore.Text);

            }
            catch (Exception ex) { ShowError(ex); }
        }

        public void scaricaDatiUtente(string cf)
        {
            SiarLibrary.UtentiCollection UtenteSel = new SiarBLL.UtentiCollectionProvider().Find(cf, null, null, null, null, null, true);
            if (UtenteSel.Count > 0)
            {
                txtNominativoOperatore.Text = UtenteSel[0].Nominativo;
                hdnIdUtente.Value = UtenteSel[0].IdPersonaFisica;
            }
            else
                throw new Exception("Utente non inserito in anagrafica.");
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstRuolo.SelectedValue != "R")
                {
                    personeProvider.DbProviderObj.BeginTran();
                    SiarLibrary.PersoneXImprese personaXimpresa = new SiarLibrary.PersoneXImprese();
                    if (!string.IsNullOrEmpty(hdnIdPpi.Value))
                        personaXimpresa = personeProvider.GetById(hdnIdPpi.Value);
                    personaXimpresa.IdImpresa = hdnIdImpresa.Value;
                    personaXimpresa.IdPersona = hdnIdUtente.Value;
                    personaXimpresa.CodRuolo = lstRuolo.SelectedValue;
                    personaXimpresa.Attivo = chkAttivo.Checked;
                    personaXimpresa.DataInizio = txtDataInizio.Text;
                    if (!chkAttivo.Checked && string.IsNullOrEmpty(txtDataFV.Text))
                        personaXimpresa.DataFine = DateTime.Now;
                    if (chkAttivo.Checked && !string.IsNullOrEmpty(txtDataFV.Text))
                        personaXimpresa.DataFine = DBNull.Value;
                    personaXimpresa.Ammesso = false;

                    if (string.IsNullOrEmpty(hdnIdPpi.Value))
                    {
                        if (checkExist())
                            throw new Exception("La persona selezionata ha già il ruolo scelto attivo, impossibile continuare.");
                    }

                    personeProvider.Save(personaXimpresa);

                    personeProvider.DbProviderObj.Commit();
                    ShowMessage("Ruolo salvato correttamente;");
                    clearForm();
                }
                else
                    throw new Exception("Non è possibile inserire o modificare un rappresentante legale.");
            }
            catch (Exception ex)
            {
                personeProvider.DbProviderObj.Rollback();
                ShowError(ex.Message);
            }
        }

        private bool checkExist()
        {
            bool exist = false;
            SiarLibrary.PersoneXImpreseCollection found = personeProvider.Find(hdnIdUtente.Value, null, hdnIdImpresa.Value, lstRuolo.SelectedValue, true, null);
            if (found.Count > 0)
            {
                foreach (SiarLibrary.PersoneXImprese p in found)
                {
                    if (p.Attivo)
                        exist = true;
                }
            }

            return exist;
        }
    }
}