using System;
using System.Web.UI.WebControls;

namespace web.Private.IPagamento
{

    public partial class CertificazioneAntimafia : SiarLibrary.Web.IstruttoriaPagamentoPage
    {
        SiarBLL.ImpresaCertificazioneAntimafiaCollectionProvider icaProv = new SiarBLL.ImpresaCertificazioneAntimafiaCollectionProvider();
        DateTime dataApprovazione = DateTime.Now;

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected override void OnPreRender(EventArgs e)
        {
            bindCombo();
            bindComboCamerale();
            bindComboEsenzione();
            cmbEsenzionePagamento.SelectedValue = cmbEsenzionePagamento.SelectedValue;
            if (Request.QueryString["redir"] == "revisione") btnBack.Attributes["onclick"] = "location='Revisionedomande.aspx?&idpag="
                    + DomandaPagamento.IdDomandaPagamento + "'";
            if (DomandaPagamento.DataApprovazione != null) dataApprovazione = DomandaPagamento.DataApprovazione;
            if (!IsPostBack)
            {
                SiarLibrary.ImpresaCertificazioneAntimafia ica = icaProv.GetCertificazioneAntimafiaXImpresa(Progetto.IdImpresa, dataApprovazione); 
                if (ica != null)
                {
                    txtProtRichiesta.Text = ica.NumeroProtocolloRichiesta;
                    txtDataRichiesta.Text = ica.DataProtocolloRichiesta;
                    txtNumeroPrefettizio.Text = ica.NumeroProtocolloPrefettizio;
                    txtDataPrefettizio.Text = ica.DataCertificatoPrefettizio;
                    txtDataInizioValidita.Text = ica.DataInizioValidita;
                    txtDataFineValidita.Text = ica.DataFineValidita;
                    txtNumCamerale.Text = ica.NumeroProtocolloCamerale;
                    txtDataCamerale.Text = ica.DataCertificatoCamerale;
                    if (ica.EsitoCertificatoPrefettizio == null) cmbEsitoPrefettizio.SelectedValue = "";
                    else cmbEsitoPrefettizio.SelectedValue = (ica.EsitoCertificatoPrefettizio ? "1" : "0");
                    if (ica.EsitoCertificatoCamerale == null) cmbEsenzionePagamento.SelectedValue = "";
                    else cmbEsitoCamerale.SelectedValue = (ica.EsitoCertificatoCamerale ? "1" : "0");
                    if (ica.EsenzioneCertificazione == null) cmbEsenzionePagamento.SelectedValue = ""; 
                    else cmbEsenzionePagamento.SelectedValue = (ica.EsenzioneCertificazione ? "1" : "0");
                    txtDataRaccomandata.Text = ica.DataProtocolloComunicazione;
                    txtNumRaccomandata.Text = ica.NumeroProtocolloComunicazione;
                    txtDataAcquisizione.Text = ica.DataAcquisizioneAntimafia;
                    txtProtAcquisizione.Text = ica.NumeroProtocolloAcquisizioneAntimafia;
                    hdnIdAntimafia.Value = ica.Id;
                }
            }
            if (cmbEsenzionePagamento.SelectedValue == "0") tbSenzaEsenzione.Visible = true;
            eseguiControllo();

            base.OnPreRender(e);
        }
        #region carica combo
        private void bindCombo()
        {
            cmbEsitoPrefettizio.Items.Clear();
            cmbEsitoPrefettizio.Items.Add(new ListItem("", ""));
            cmbEsitoPrefettizio.Items.Add(new ListItem("IDONEO", "1"));
            cmbEsitoPrefettizio.Items.Add(new ListItem("NON IDONEO", "0"));
            foreach (ListItem li in cmbEsitoPrefettizio.Items)
                if (li.Value == cmbEsitoPrefettizio.SelectedValue) li.Selected = true;
        }
        private void bindComboCamerale()
        {
            cmbEsitoCamerale.Items.Clear();
            cmbEsitoCamerale.Items.Add(new ListItem("", ""));
            cmbEsitoCamerale.Items.Add(new ListItem("IDONEO", "1"));
            cmbEsitoCamerale.Items.Add(new ListItem("NON IDONEO", "0"));
            foreach (ListItem li in cmbEsitoCamerale.Items)
                if (li.Value == cmbEsitoCamerale.SelectedValue) li.Selected = true;
        }
        private void bindComboEsenzione()
        {
            cmbEsenzionePagamento.Items.Clear();
            cmbEsenzionePagamento.Items.Add(new ListItem("", ""));
            cmbEsenzionePagamento.Items.Add(new ListItem("NO", "0"));
            cmbEsenzionePagamento.Items.Add(new ListItem("SI", "1"));
            foreach (ListItem li in cmbEsenzionePagamento.Items)
                if (li.Value == cmbEsenzionePagamento.SelectedValue) li.Selected = true;
        }
        #endregion

        protected void eseguiControllo()
        {
            try
            {
                lblEsitoControllo.Text = SiarLibrary.DbStaticProvider.EsitoControlloAntimafia(Progetto.IdImpresa, dataApprovazione,
                    icaProv.DbProviderObj) == 1 ? "POSITIVO" : "NEGATIVO";
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                PagamentoProvider.DbProviderObj.BeginTran();
                if (!string.IsNullOrEmpty(hdnIdAntimafia.Value))
                {
                    SiarLibrary.ImpresaCertificazioneAntimafia ica = icaProv.GetById(hdnIdAntimafia.Value);
                    if (string.IsNullOrEmpty(ica.DataFineValidita) || (ica.DataFineValidita >= DateTime.Now))
                    {
                        ica.NumeroProtocolloRichiesta = txtProtRichiesta.Text;
                        ica.DataProtocolloRichiesta = txtDataRichiesta.Text;
                        ica.NumeroProtocolloPrefettizio = txtNumeroPrefettizio.Text;
                        ica.DataCertificatoPrefettizio = txtDataPrefettizio.Text;
                        ica.EsenzioneCertificazione = (cmbEsenzionePagamento.SelectedValue == "1" ? true : false);
                        ica.NumeroProtocolloCamerale = txtNumCamerale.Text;
                        ica.DataCertificatoCamerale = txtDataCamerale.Text;
                        ica.NumeroProtocolloComunicazione = txtNumRaccomandata.Text;
                        ica.DataProtocolloComunicazione = txtDataRaccomandata.Text;
                        if (cmbEsitoCamerale.SelectedValue == null) ica.EsitoCertificatoCamerale = null;
                        else ica.EsitoCertificatoCamerale = (cmbEsitoCamerale.SelectedValue == "1" ? true : false);
                        if (cmbEsitoPrefettizio.SelectedValue == null) ica.EsitoCertificatoPrefettizio = null;
                        else ica.EsitoCertificatoPrefettizio = (cmbEsitoPrefettizio.SelectedValue == "1" ? true : false);
                        ica.DataAcquisizioneAntimafia = txtDataAcquisizione.Text;
                        ica.NumeroProtocolloAcquisizioneAntimafia = txtProtAcquisizione.Text;
                        ica.DataInizioValidita = txtDataInizioValidita.Text;
                        ica.DataFineValidita = txtDataFineValidita.Text;
                        icaProv.Save(ica);
                    }
                    else nuovo();
                }
                else nuovo();
                PagamentoProvider.AggiornaDomandaDiPagamentoIstruttore(DomandaPagamento, ((SiarLibrary.Web.MasterPage)Master).Operatore);
                PagamentoProvider.DbProviderObj.Commit();
                ShowMessage("Salvataggio completato.");
            }
            catch (Exception ex) { PagamentoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void nuovo()
        {
            SiarLibrary.ImpresaCertificazioneAntimafia icaNew = new SiarLibrary.ImpresaCertificazioneAntimafia();
            icaNew.IdImpresa = Progetto.IdImpresa;
            icaNew.NumeroProtocolloRichiesta = txtProtRichiesta.Text;
            icaNew.DataProtocolloRichiesta = txtDataRichiesta.Text;
            icaNew.NumeroProtocolloPrefettizio = txtNumeroPrefettizio.Text;
            icaNew.DataCertificatoPrefettizio = txtDataPrefettizio.Text;
            icaNew.EsenzioneCertificazione = (cmbEsenzionePagamento.SelectedValue == "1" ? true : false);
            icaNew.NumeroProtocolloCamerale = txtNumCamerale.Text;
            icaNew.DataCertificatoCamerale = txtDataCamerale.Text;
            icaNew.NumeroProtocolloComunicazione = txtNumRaccomandata.Text;
            icaNew.DataProtocolloComunicazione = txtDataRaccomandata.Text;
            if (cmbEsitoCamerale.SelectedValue == null) icaNew.EsitoCertificatoCamerale = null;
            else icaNew.EsitoCertificatoCamerale = (cmbEsitoCamerale.SelectedValue == "1" ? true : false);
            if (cmbEsitoPrefettizio.SelectedValue == null) icaNew.EsitoCertificatoPrefettizio = null;
            else icaNew.EsitoCertificatoPrefettizio = (cmbEsitoPrefettizio.SelectedValue == "1" ? true : false);
            icaNew.DataAcquisizioneAntimafia = txtDataAcquisizione.Text;
            icaNew.NumeroProtocolloAcquisizioneAntimafia = txtProtAcquisizione.Text;
            icaNew.DataInizioValidita = txtDataInizioValidita.Text;
            icaNew.DataFineValidita = txtDataFineValidita.Text;
            icaNew.DataInizioValidita = txtDataInizioValidita.Text;
            icaNew.DataFineValidita = txtDataFineValidita.Text;
            icaProv.Save(icaNew);
        }
    }
}
