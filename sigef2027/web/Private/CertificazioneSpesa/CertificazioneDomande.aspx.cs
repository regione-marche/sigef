using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.CertificazioneSpesa
{
    public partial class CertificazioneDomande : SiarLibrary.Web.CertificazioneSpesaPage
    {
        SiarLibrary.CertspDomande domSel;
        SiarLibrary.CertspDomandeCollection domande = new SiarLibrary.CertspDomandeCollection();
        SiarBLL.CertspDomandeCollectionProvider domPro = new SiarBLL.CertspDomandeCollectionProvider();

        // Oggetti per ricerca atto
        SiarLibrary.Atti decreto_selezionato = null;
        SiarBLL.AttiCollectionProvider atti_provider = new SiarBLL.AttiCollectionProvider();
        bool show_div_decreto = false;

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "certificazioni_di_spesa";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HiddenFields_Valorizza();
        }

        protected override void OnPreRender(EventArgs e)
        {
            VisualizzaCorpo();
            VisualizzaDecreti();

            base.OnPreRender(e);
        }

        private void VisualizzaCorpo()
        {
            if (domSel == null)     // Nessun recupero selezionato, visualizzo l'elenco
            {
                divElenco.Visible = true;
                divDettaglio.Visible = false;

                dgDomande.DataSource = LeggiDomande();
                dgDomande.DataBind();

                PulisciDettaglio();
            }
            else                    // E' stato selezionto un recupero: visualizzo il dettaglio
            {
                divElenco.Visible = false;
                divDettaglio.Visible = true;
                ScriviTxtDettaglio();
            }
        }

        private void HiddenFields_Valorizza()
        {
            int idDomanda;
            int idAtto;

            if (int.TryParse(hdnIdDomanda.Value, out idDomanda))
            {
                domSel = domPro.GetById(idDomanda);
            }

            if (int.TryParse(hdnIdAttoNew.Value, out idAtto) && domSel == null)
            {
                domSel = new SiarLibrary.CertspDomande();
            }

        }

        #region Dettaglio

        private void ScriviTxtDettaglio()
        {
            SiarLibrary.Atti atto;
            int _idAtto;

            txtIdDomanda.Text = domSel.IdDomanda;
            //txtIdProgetto.Text = domSel.IdProgetto;
            if (string.IsNullOrEmpty(hdnIdAtto.Value))
            {
                hdnIdAtto.Value = domSel.IdAtto;
            }
            if (!string.IsNullOrEmpty(hdnIdAtto.Value))     // Se si tratta di un nuovo record è vuoto
            {
                int.TryParse(hdnIdAtto.Value, out _idAtto);
                atto = atti_provider.GetById(_idAtto);
                txtIdAttoNr.Text = atto.Numero.Value.ToString();
                txtIdAttoDt.Text = atto.Data.Value.ToShortDateString();
                txtIdAttoRe.Text = atto.Registro.ToString();
            }
            txtDataPres.Text = domSel.DataPres;
            txtSpeseAmm.Text = domSel.SpeseAmm;
            txtSpesaPubb.Text = domSel.SpesaPubb;
            txtSfTot.Text = domSel.SfTot;
            txtSfSpesaPubb.Text = domSel.SfSpesaPubb;
            txtSfSpeseAmm.Text = domSel.SfSpeseAmm;
            txtSfSpesaPubbAmm.Text = domSel.SfSpesaPubbAmm;
            txtAsTot.Text = domSel.AsTot;
            txtAsCoperto.Text = domSel.AsCoperto;
            txtAsNonCoperto.Text = domSel.AsNonCoperto;
        }

        private SiarLibrary.CertspDomande LeggiTxtDettaglio()
        {
            SiarLibrary.CertspDomande domanda;

            if (!string.IsNullOrEmpty(txtIdDomanda.Text))
            {
                domanda = domPro.GetById(txtIdDomanda.Text);
            }
            else
            {
                domanda = new SiarLibrary.CertspDomande();
            }
            //domanda.IdProgetto = txtIdProgetto.Text;
            //domanda.IdAtto = txtIdAtto.Text;
            domanda.IdAtto = hdnIdAtto.Value;
            domanda.DataPres = txtDataPres.Text;
            domanda.SpeseAmm = txtSpeseAmm.Text;
            domanda.SpesaPubb = txtSpesaPubb.Text;
            domanda.SfTot = txtSfTot.Text;
            domanda.SfSpesaPubb = txtSfSpesaPubb.Text;
            domanda.SfSpeseAmm = txtSfSpeseAmm.Text;
            domanda.SfSpesaPubbAmm = txtSfSpesaPubbAmm.Text;
            domanda.AsTot = txtAsTot.Text;
            domanda.AsCoperto = txtAsCoperto.Text;
            domanda.AsNonCoperto = txtAsNonCoperto.Text;

            return domanda;
        }

        private void PulisciDettaglio()
        {
            txtIdDomanda.Text = null;
            //txtIdProgetto.Text = null;
            //txtIdAtto.Text = null;
            hdnIdAtto.Value = null;
            txtDataPres.Text = null;
            txtSpeseAmm.Text = null;
            txtSpesaPubb.Text = null;
            txtSfTot.Text = null;
            txtSfSpesaPubb.Text = null;
            txtSfSpeseAmm.Text = null;
            txtSfSpesaPubbAmm.Text = null;
            txtAsTot.Text = null;
            txtAsCoperto.Text = null;
            txtAsNonCoperto.Text = null;
        }

        private bool ProgettoEsiste(int idProgetto)
        {
            bool PrgEss = false;
            SiarBLL.ProgettoCollectionProvider prgPrv = new SiarBLL.ProgettoCollectionProvider();
            SiarLibrary.Progetto prg = prgPrv.GetById(idProgetto);

            if (prg != null)
            {
                PrgEss = true;
            }

            return PrgEss;
        }

        #endregion

        #region Eventi

        protected void btnSelezionaDomanda_Click(object sender, EventArgs e)
        {
        }

        protected void btnRitorna_OnClick(object sender, EventArgs e)
        {
            hdnIdDomanda.Value = null;
            domSel = null;
        }

        protected void btnSalva_OnClick(object sender, EventArgs e)
        {
            SiarLibrary.CertspDomande domanda = LeggiTxtDettaglio();
            SalvaDomanda(domanda);
        }

        protected void btnCancella_OnClick(object sender, EventArgs e)
        {
            if (domSel != null)
            {
                CancellaRecupero(domSel);
            }
            NuovaDomanda();
        }

        protected void btnNuovo_OnClick(object sender, EventArgs e)
        {
            NuovaDomanda();
        }

        protected void btnCercaAtto_Click(object sender, EventArgs e)
        {
            show_div_decreto = true;
        }
        
        #endregion

        #region Lettura / Scrittura dati

        private SiarLibrary.CertspDomandeCollection LeggiDomande()
        {
            SiarLibrary.CertspDomandeCollection dom;

            dom = domPro.getAll();
            dom.Sort("DataPres");
            return dom;
        }

        private void SalvaDomanda(SiarLibrary.CertspDomande domanda)
        {
            int _res;
            bool _salvati = false;

            if (CampoObbligatoriCompilati(domanda))
            {
                _res = domPro.Save(domanda);
                if (_res > 0)
                {
                    _salvati = true;
                    domSel = domPro.GetById(domanda.IdDomanda);
                    ShowMessage("Dati Salvati correttamente");
                }
            }

            if (!_salvati)
            {
                domSel = domanda;
            }

        }

        private void NuovaDomanda()
        {
            PulisciDettaglio();
            domSel = new SiarLibrary.CertspDomande();
        }

        private void CancellaRecupero(SiarLibrary.CertspDomande domanda)
        {
            domPro.Delete(domanda);
        }

        private bool CampoObbligatoriCompilati(SiarLibrary.CertspDomande domanda)
        {
            bool compilati = true;
            //int _idProgetto;
            string msg = null;

            // Id Progetto
            //_idProgetto = int.Parse(domanda.IdProgetto);
            //if (!ProgettoEsiste(_idProgetto))
            //{
            //    compilati = false;
            //    msg = "Codice progetto errato.";
            //}

            // Data
            if (string.IsNullOrEmpty(domanda.DataPres.ToString()))
            {
                if (!compilati)
                {
                    msg += "<br />";
                }
                compilati = false;
                msg += "Data presentazione obbligatoria.";
            }

            if (!compilati)
            {
                msg += "<br /> Nessun dato salvato.";
                ShowError(msg);
            }

            return compilati;
        }

        #endregion

        #region Popup Ricerca Atto

        private void VisualizzaDecreti()
        {
            if (show_div_decreto)
            {
                lstAttoDefinizione.DataBind();
                lstAttoRegistro.DataBind();
                lstAttoOrgIstituzionale.DataBind();
                lstAttoTipo.DataBind();
                if (decreto_selezionato != null)
                {
                    hdnIdAttoNew.Value = decreto_selezionato.IdAtto;
                    txtAttoDescrizione.Text = decreto_selezionato.Descrizione;
                    lstAttoOrgIstituzionale.SelectedValue = decreto_selezionato.CodOrganoIstituzionale;
                    if (!string.IsNullOrEmpty(decreto_selezionato.CodTipo))
                    {
                        lstAttoTipo.SelectedValue = decreto_selezionato.CodTipo;
                        lstAttoTipo.Enabled = false;
                    }
                    txtAttoBurNumero.Text = decreto_selezionato.NumeroBur;
                    txtAttoBurData.Text = decreto_selezionato.DataBur;
                }
                else
                {
                    hdnIdAttoNew.Value = null;
                }

                RegisterClientScriptBlock("mostraPopupTemplate('divDecreto','divBKGMessaggio');");
            }
            else
            {
                PulisciCampiDecreto();
                //((SiarLibrary.Web.CheckColumn)dgProgetti.Columns[10]).ClearSelected();
            }
        }

        private void PulisciCampiDecreto()
        {
            txtAttoData.Text = "";
            txtAttoNumero.Text = "";
            txtAttoDescrizione.Text = "";
            txtAttoBurData.Text = "";
            txtAttoBurNumero.Text = "";
            txtAttoDataXComunicazione.Text = "";
            hdnIdAttoNew.Value = "";
            lstAttoRegistro.ClearSelection();
            lstAttoTipo.ClearSelection();
            lstAttoOrgIstituzionale.ClearSelection();
        }

        private void CercaDecreto()
        {
            int numero;
            DateTime data;
            string registro;
            SiarLibrary.AttiCollection atti_trovati;

            try
            {
                show_div_decreto = true;

                int.TryParse(txtAttoNumero.Text, out numero);
                DateTime.TryParse(txtAttoData.Text, out data);
                registro = lstAttoRegistro.SelectedValue;

                if (!string.IsNullOrEmpty(lstAttoRegistro.SelectedValue)
                    &&
                    lstAttoRegistro.SelectedValue.IndexOf("|") > 0)
                {
                    registro = lstAttoRegistro.SelectedValue.Substring(0, lstAttoRegistro.SelectedValue.IndexOf("|"));
                }

                // controllo che l'atto sia registrato su db, altrimenti lo importo
                atti_trovati = atti_provider.Find(numero, data, lstAttoDefinizione.SelectedValue, registro);
                if (atti_trovati.Count == 0)
                {
                    atti_trovati = atti_provider.ImportaAtto(numero, data, lstAttoDefinizione.SelectedValue, lstAttoRegistro.SelectedValue);
                    if (atti_trovati.Count > 0)
                    {
                        atti_provider.Save(atti_trovati[0]);
                    }
                }
                if (atti_trovati.Count > 0)
                {
                    decreto_selezionato = atti_trovati[0];
                }
                else
                {
                    ShowMessage("La ricerca non ha prodotto nessun risultato.");
                }
            }
            catch (Exception ex) 
            { 
                ShowError(ex); 
            }
        }

        protected void btnCercaDecreto_Click(object sender, EventArgs e)
        {
            CercaDecreto();
        }

        protected void btnAttoSeleziona_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hdnIdAttoNew.Value))
            {
                hdnIdAtto.Value = hdnIdAttoNew.Value;
            }
            RegisterClientScriptBlock("chiudiPopup();");
        }

        #endregion
    }
}
