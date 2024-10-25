using SiarBLL;
using SiarLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.Controlli
{
    public partial class ControlliSecondoLivello : SiarLibrary.Web.PrivatePage
    {
        ControlliSecondoLivelloCollectionProvider controlliProvider = new ControlliSecondoLivelloCollectionProvider();

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "controlli_secondo_livello";
            base.OnPreInit(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    tbNuovoControllo.Visible = true;
                    txtControllore.AddJSAttribute("onkeydown", "SNCVolatileZoom(this,event,'SNCVZCercaUtenti');");

                    int id_controllo;
                    btnSave.Enabled = false;
                    if (!string.IsNullOrEmpty(hdnIdControllo.Value))
                    {
                        int.TryParse(hdnIdControllo.Value, out id_controllo);

                        SiarLibrary.ControlliSecondoLivello controllo = controlliProvider.GetById(id_controllo);
                        if (controllo != null)
                        {
                            loadControllo(controllo);
                            if (controllo.SegnaturaVerbale != null)
                            {
                                btnElimina.Enabled = true;
                                btnSave.Enabled = false;
                            }
                            else
                            {
                                btnElimina.Enabled = false;
                                btnSave.Enabled = AbilitaModifica;
                            }

                        }
                        else
                        {
                            btnElimina.Enabled = false;
                            btnSave.Enabled = AbilitaModifica;
                        }
                    }
                    else
                    {
                        btnElimina.Enabled = false;
                        btnSave.Enabled = AbilitaModifica;
                    }

                    int idProgetto = 0;
                    if (!string.IsNullOrEmpty(txtProgetto.Text))
                    {
                        int.TryParse(txtProgetto.Text, out idProgetto);

                        lstLottiCert.IdProgetto = idProgetto;
                        lstLottiCert.DataBind();
                    }
                    break;
                default:
                    hdnIdControllo.Value = "";
                    tbControlli.Visible = true;
                    SiarLibrary.ControlliSecondoLivelloCollection controlli = new SiarBLL.ControlliSecondoLivelloCollectionProvider().Find(null, null, null, null, null, null);
                    dgControlli.DataSource = controlli;
                    dgControlli.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgControlli_ItemDataBound);
                    if (controlli.Count == 0) dgControlli.Titolo = "&nbsp;&nbsp;&nbsp;<em><b>Nessun controllo effettuato.</b></em>";
                    dgControlli.DataBind();
                    break;
            }
            base.OnPreRender(e);
        }

        void loadControllo(SiarLibrary.ControlliSecondoLivello controllo)
        {
            txtProgetto.Text = controllo.IdProgetto;
            lstLottiCert.IdProgetto = controllo.IdProgetto;
            lstLottiCert.DataBind();
            lstLottiCert.SelectedValue = controllo.IdLotto;

            CertspDettaglioCollection domande = new CertspDettaglioCollectionProvider().getBy_IdCertSp(controllo.IdLotto);

            decimal spesaAmmessa = 0;
            decimal contributoRendicontato = 0;

            foreach (CertspDettaglio c in domande)
            {
                if (c.Selezionata && c.IdProgetto == controllo.IdProgetto)
                {
                    ListItem a = new ListItem();
                    a.Text = c.IdDomandaPagamento;
                    lstDomandePagamento.Items.Add(a);

                    if (c.Spesaammessa != null)
                        spesaAmmessa += c.Spesaammessa;
                    if (c.ImportocontributopubblicoIncrementale != null)
                        contributoRendicontato += c.ImportocontributopubblicoIncrementale;
                }
            }

            txtSpesaAmmessa.Text = spesaAmmessa.ToString();
            txtContributoRendicontato.Text = contributoRendicontato.ToString();

            lstDomandePagamento.DataBind();
            txtSpesaIrregolare.Text = controllo.SpesaAmmessaIrregolare;
            txtContributoIrregolare.Text = controllo.ContributoAmmessoIrregolare;
            hdnIdControllore.Value = controllo.Controllore;
            txtControllore.Text = controllo.Nominativo;
            txtDataControllo.Text = controllo.DataControllo;
            ddlEsito.SelectedValue = controllo.Esito;
            txtSegnatura.Text = controllo.SegnaturaVerbale;


        }

        void dgControlli_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.ControlliSecondoLivello c = (SiarLibrary.ControlliSecondoLivello)e.Item.DataItem;

                if (c.Esito == 1)
                    e.Item.Cells[10].Text = "Positivo";
                else if (c.Esito == 2)
                    e.Item.Cells[10].Text = "Parzialmente positivo";
                else if (c.Esito == 3)
                    e.Item.Cells[10].Text = "Negativo";
                else if (c.Esito == 4)
                    e.Item.Cells[10].Text = "Parzialmente negativo";

                e.Item.Cells[12].Text = "<input type=button class=ButtonGrid value='Segnatura' style='width:100px' onclick=\"sncAjaxCallVisualizzaProtocollo('" + c.SegnaturaVerbale + "')\" />";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNuovoPost_Click(object sender, EventArgs e)
        {
            pulisciCampi();
        }

        protected void btnCercaProgetto_Click(object sender, EventArgs e)
        {

        }

        protected void btnCercaDomande_Click(object sender, EventArgs e)
        {
            try
            {
                int idCert = 0;
                if (!string.IsNullOrEmpty(lstLottiCert.SelectedValue))
                {
                    int.TryParse(lstLottiCert.SelectedValue, out idCert);
                    CertspDettaglioCollection domande = new CertspDettaglioCollectionProvider().getBy_IdCertSp(idCert);

                    decimal spesaAmmessa = 0;
                    decimal contributoRendicontato = 0;

                    int idProgetto = 0;
                    int.TryParse(txtProgetto.Text, out idProgetto);

                    foreach (CertspDettaglio c in domande)
                    {
                        if (c.Selezionata && c.IdProgetto == idProgetto)
                        {
                            ListItem a = new ListItem();
                            a.Text = c.IdDomandaPagamento;
                            lstDomandePagamento.Items.Add(a);

                            if (c.Spesaammessa != null)
                                spesaAmmessa += c.Spesaammessa;
                            if (c.ImportocontributopubblicoIncrementale != null)
                                contributoRendicontato += c.ImportocontributopubblicoIncrementale;
                        }
                    }

                    txtSpesaAmmessa.Text = spesaAmmessa.ToString();
                    txtContributoRendicontato.Text = contributoRendicontato.ToString();

                    lstDomandePagamento.DataBind();
                }
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (hdnIdControllo.Value == null || hdnIdControllo.Value == string.Empty) throw new Exception("Il controllo selezionato non è valido.");
                //SiarLibrary.ComunicazioniMassive c = comunicazioni_massive_provider.GetById(hdnIdEstrazione.Value);
                SiarLibrary.ControlliSecondoLivello c = controlliProvider.GetById(hdnIdControllo.Value);
                controlliProvider.Delete(c);
                pulisciCampi();
                ShowMessage("Controllo di secondo livello eliminato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnNuovo_Click(object sender, EventArgs e)
        {
            pulisciCampi();
        }

        private void pulisciCampi()
        {
            hdnIdControllo.Value = null;
            txtProgetto.Text = string.Empty;
            txtSegnatura.Text = string.Empty;
            btnElimina.Enabled = AbilitaModifica;
            btnSave.Enabled = AbilitaModifica;
            txtSpesaAmmessa.Text = string.Empty;
            txtContributoRendicontato.Text = string.Empty;
            txtSpesaIrregolare.Text = string.Empty;
            txtContributoIrregolare.Text = string.Empty;
            txtControllore.Text = string.Empty;
            hdnIdControllore.Value = string.Empty;
            txtDataControllo.Text = string.Empty;
            ddlEsito.SelectedValue = "-1";
            txtSegnatura.Text = string.Empty;
        }

        protected void btnSalvaControllo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                controlliProvider.DbProviderObj.BeginTran();
                verificaSegnatura();
                SiarLibrary.ControlliSecondoLivello controllo = new SiarLibrary.ControlliSecondoLivello();

                if (!string.IsNullOrEmpty(hdnIdControllo.Value))
                    controllo = controlliProvider.GetById(hdnIdControllo.Value);

                if (string.IsNullOrEmpty(txtProgetto.Text)) throw new SiarLibrary.SiarException("Selezionare un progetto e un lotto per il controllo.");
                if (string.IsNullOrEmpty(lstLottiCert.SelectedValue)) throw new SiarLibrary.SiarException("Selezionare un progetto e un lotto per il controllo.");
                if (ddlEsito.SelectedValue == "-1") throw new SiarLibrary.SiarException("Selezionare un esito tra quelli in lista.");

                controllo.IdProgetto = txtProgetto.Text;
                controllo.IdLotto = lstLottiCert.SelectedValue;
                controllo.TotaleSpesaAmmessa = txtSpesaAmmessa.Text;
                controllo.TotaleContributiRendicontati = txtContributoRendicontato.Text;
                controllo.SpesaAmmessaIrregolare = txtSpesaIrregolare.Text;
                controllo.ContributoAmmessoIrregolare = txtContributoIrregolare.Text;
                controllo.Controllore = hdnIdControllore.Value;
                controllo.DataControllo = txtDataControllo.Text;
                controllo.Esito = ddlEsito.SelectedValue;
                if (string.IsNullOrEmpty(hdnIdControllo.Value))
                    controllo.DataInserimento = DateTime.Now;
                controllo.DataAggiornamento = DateTime.Now;
                controllo.SegnaturaVerbale = txtSegnatura.Text;

                controlliProvider.Save(controllo);
                controlliProvider.DbProviderObj.Commit();

                ShowMessage("Controllo di secondo livello salvato correttamente.");

                pulisciCampi();
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnVerifica_Click(object sender, EventArgs e)
        {
            try
            {
                verificaSegnatura();
            }
            catch (Exception ex) { ShowError(ex); }
        }

        public void verificaSegnatura()
        {
            try
            {
                //if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (string.IsNullOrEmpty(txtSegnatura.Text)) throw new Exception("Non è stata inserita alcuna Segnatura. Impossibile continuare.");
                SiarLibrary.Protocollo richiesta = new SiarLibrary.Protocollo();

                bool protocolloOk = richiesta.ProtocolloEsistente(txtSegnatura.Text);

                if (!protocolloOk)
                    throw new Exception("Il protocollo è inesistente o non corretto.");

                ShowMessage("La segnatura risulta corretta.");
            }
            catch (Exception ex) { throw ex; }
        }
    }
}