using SiarLibrary.NullTypes;
using System;
using System.Web.UI.WebControls;

namespace web.Private.regione
{
    public partial class BandiQuotaFissa : SiarLibrary.Web.PrivatePage
    {
        SiarBLL.BandoImpreseQuotaFissaCollectionProvider bando_impresa_quota_provider = new SiarBLL.BandoImpreseQuotaFissaCollectionProvider();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "bandi_quota_fissa";
            base.OnPreInit(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            cmbSelBando.DataBind();
            cmbFilter.DataBind();
            SiarLibrary.BandoImpreseQuotaFissaCollection bandoImpreseQuotaFissa = new SiarLibrary.BandoImpreseQuotaFissaCollection();

            int idBando = 0;
            int.TryParse(cmbFilter.SelectedValue, out idBando);

            IntNT idB = null;
            if (idBando != 0)
                idB = idBando;

            bandoImpreseQuotaFissa = bando_impresa_quota_provider.Find(idB, null, null, true);

            dgBandoImpresaQuotaFissa.DataSource = bandoImpreseQuotaFissa;
            dgBandoImpresaQuotaFissa.ItemDataBound += new DataGridItemEventHandler(dgBandoImpresaQuotaFissa_ItemDataBound);
            dgBandoImpresaQuotaFissa.Titolo = "Elementi trovati: " + bandoImpreseQuotaFissa.Count;
            dgBandoImpresaQuotaFissa.DataBind();
            base.OnPreRender(e);
        }


        void dgBandoImpresaQuotaFissa_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {

            }
        }

        protected void btnPostImpresa_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (!int.TryParse(hdnIdImpreseQuotaFissa.Value, out id)) ShowError("L'impresa selezionata non è valida. Impossibile continuare.");
            else
            {
                SiarLibrary.BandoImpreseQuotaFissa bandoImpreseQuotaFissa = bando_impresa_quota_provider.GetById(id);
                SiarLibrary.Impresa i = new SiarBLL.ImpresaCollectionProvider().GetById(bandoImpreseQuotaFissa.IdImpresa);
                hdnIdImpreseQuotaFissa.Value = bandoImpreseQuotaFissa.Id;
                hdnIdImpresa.Value = bandoImpreseQuotaFissa.IdImpresa;
                txtCFabilitato.Text = i.Cuaa;
                txtRagSociale.Text = i.RagioneSociale;
                txtQuota.Text = bandoImpreseQuotaFissa.Quota;
                cmbSelBando.SelectedValue = bandoImpreseQuotaFissa.IdBando;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                bando_impresa_quota_provider.DbProviderObj.BeginTran();
                int id = 0;
                if (!int.TryParse(hdnIdImpreseQuotaFissa.Value, out id)) ShowError("Selezionare un'impresa valida per poterla eliminare.");
                else
                {
                    SiarLibrary.BandoImpreseQuotaFissa bandoImpreseQuotaFissa = bando_impresa_quota_provider.GetById(id);
                    bandoImpreseQuotaFissa.Attivo = false;
                    bando_impresa_quota_provider.Save(bandoImpreseQuotaFissa);
                    bando_impresa_quota_provider.DbProviderObj.Commit();
                    ShowMessage("Quota eliminata correttamente.");
                    clearForm();
                }
            }
            catch (Exception ex) { ShowError(ex); bando_impresa_quota_provider.DbProviderObj.Rollback(); }
        }

        protected void btnScaricaDatiImpresa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCFabilitato.Text) || txtCFabilitato.Text.Length > 16)
                    throw new Exception("La Partita iva/Codice fiscale digitata non è valida.");

                SiarLibrary.Impresa i = scaricaDatiAnagrafici(txtCFabilitato.Text);
                if (i == null) throw new Exception("L`impresa cercata non è stata trovata.");

                hdnIdImpresa.Value = i.IdImpresa;
                txtRagSociale.Text = i.RagioneSociale;
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {

        }

        private SiarLibrary.Impresa scaricaDatiAnagrafici(string cuaa_impresa)
        {
            SiarLibrary.Impresa i = null;
            if (!string.IsNullOrEmpty(cuaa_impresa) && (cuaa_impresa.Length == 11 || cuaa_impresa.Length == 16))
            {
                SiarBLL.ImpresaCollectionProvider impresa_provider = new SiarBLL.ImpresaCollectionProvider();
                i = impresa_provider.GetByCuaa(cuaa_impresa);
                if (i == null)
                {
                    SianWebSrv.TraduzioneSianToSiar trad = new SianWebSrv.TraduzioneSianToSiar();
                    trad.ScaricaDatiAzienda(cuaa_impresa.ToUpper(), null, Operatore.Utente.CfUtente);
                    i = impresa_provider.GetByCuaa(cuaa_impresa);
                }
                if (i != null && (i.RagioneSociale == i.Cuaa || i.RagioneSociale == i.CodiceFiscale)) return null;
            }
            return i;
        }

        private void clearForm()
        {
            cmbSelBando.SelectedIndex = -1;
            hdnIdImpresa.Value = string.Empty;
            hdnIdImpreseQuotaFissa.Value = string.Empty;
            txtRagSociale.Text = string.Empty;
            txtCFabilitato.Text = string.Empty;
            txtQuota.Text = string.Empty;
        }

        protected void btnSalvaQuotaImpresa_Click(object sender, EventArgs e)
        {
            try
            {
                bando_impresa_quota_provider.DbProviderObj.BeginTran();
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                SiarLibrary.Bando b = new SiarBLL.BandoCollectionProvider().GetById(cmbSelBando.SelectedValue);
                if (b.Stato == "G") throw new SiarLibrary.SiarException("Non è possibile aggiungere imprese a quota fissa in quanto il bando ha una graduatoria chiusa.");
                string piva = null;
                if (!string.IsNullOrEmpty(txtCFabilitato.Text))
                {
                    if (txtCFabilitato.Text.Length == 16) piva = txtCFabilitato.Text;
                    else if (txtCFabilitato.Text.Length == 11) piva = txtCFabilitato.Text;
                }
                SiarLibrary.BandoImpreseQuotaFissa quotaFissa;
                if (hdnIdImpreseQuotaFissa.Value == string.Empty)
                    quotaFissa = new SiarLibrary.BandoImpreseQuotaFissa();
                else
                    quotaFissa = bando_impresa_quota_provider.GetById(hdnIdImpreseQuotaFissa.Value);

                quotaFissa.IdBando = cmbSelBando.SelectedValue;
                quotaFissa.IdImpresa = hdnIdImpresa.Value;
                quotaFissa.Attivo = true;
                quotaFissa.Quota = txtQuota.Text;
                quotaFissa.Operatore = Operatore.Utente.IdUtente;
                quotaFissa.DataModifica = DateTime.Now;
                if (hdnIdImpreseQuotaFissa.Value == string.Empty)
                    quotaFissa.DataInserimento = DateTime.Now;

                bando_impresa_quota_provider.Save(quotaFissa);

                bando_impresa_quota_provider.DbProviderObj.Commit();

                ShowMessage("Quota aggiunta correttamente.");

                clearForm();

            }
            catch (Exception ex) { ShowError(ex); bando_impresa_quota_provider.DbProviderObj.Rollback(); }
        }
    }
}