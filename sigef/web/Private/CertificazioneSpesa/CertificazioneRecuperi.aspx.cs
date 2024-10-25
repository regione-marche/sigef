using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.CertificazioneSpesa
{
    public partial class CertificazioneRecuperi : SiarLibrary.Web.CertificazioneSpesaPage
    {
        SiarLibrary.CertspRecuperi recSel;
        SiarLibrary.CertspRecuperiCollection recuperi = new SiarLibrary.CertspRecuperiCollection();
        SiarBLL.CertspRecuperiCollectionProvider recPro = new SiarBLL.CertspRecuperiCollectionProvider();

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

        private void HiddenFields_Valorizza()
        {
            int idRecupero;
            int idAtto;

            if (int.TryParse(hdnIdRecupero.Value, out idRecupero))
            {
                recSel = recPro.GetById(idRecupero);
            }

            if (int.TryParse(hdnIdAttoNew.Value, out idAtto) && recSel == null)
            {
                recSel = new SiarLibrary.CertspRecuperi();
            }

        }

        private void VisualizzaCorpo()
        {
            if (recSel == null)     // Nessun recupero selezionato, visualizzo l'elenco
            {
                divElenco.Visible = true;
                divDettaglio.Visible = false;

                dgRecuperi.DataSource = LeggiRecuperi();
                dgRecuperi.DataBind();

                PulisciDettaglio();
            }
            else                    // E' stato selezionto un recupero: visualizzo il dettaglio
            {
                divElenco.Visible = false;
                divDettaglio.Visible = true;
                ScriviTxtDettaglio();
            }
        }

        #region Dettaglio

        private void ScriviTxtDettaglio()
        {
            SiarLibrary.Atti atto;
            int _idAtto;

            txtIdRecupero.Text = recSel.IdRecupero;
            txtIdProgetto.Text = recSel.IdProgetto;

            if (string.IsNullOrEmpty(hdnIdAtto.Value))
            {
                hdnIdAtto.Value = recSel.IdAtto;
            }
            if (!string.IsNullOrEmpty(hdnIdAtto.Value))     // Se si tratta di un nuovo record è vuoto
            {
                int.TryParse(hdnIdAtto.Value, out _idAtto);
                atto = atti_provider.GetById(_idAtto);
                txtIdAttoNr.Text = atto.Numero.Value.ToString();
                txtIdAttoDt.Text = atto.Data.Value.ToShortDateString();
                txtIdAttoRe.Text = atto.Registro.ToString();
            }

            txtSostegno.Text = recSel.Sostegno;
            txtSpeseAmm.Text = recSel.SpeseAmm;
            txtDataRicevRimb.Text = recSel.DataRicevRimb;
            txtRimbSostegno.Text = recSel.RimbSostegno;
            txtRimbSpeseAmm.Text = recSel.RimbSpeseAmm;
            txtNonRSostegno.Text = recSel.NonrSostegno;
            txtNonRSpeseAmm.Text = recSel.NonrSpeseAmm;
        }

        private SiarLibrary.CertspRecuperi LeggiTxtDettaglio()
        {
            SiarLibrary.CertspRecuperi recupero;

            if (!string.IsNullOrEmpty(txtIdRecupero.Text))
            {
                recupero = recPro.GetById(txtIdRecupero.Text);
            }
            else
            {
                recupero = new SiarLibrary.CertspRecuperi();
            }
            recupero.IdProgetto = txtIdProgetto.Text;
            //recupero.IdAtto = txtIdAtto.Text;
            recupero.IdAtto = hdnIdAtto.Value;
            recupero.Sostegno = txtSostegno.Text;
            recupero.SpeseAmm = txtSpeseAmm.Text;
            recupero.DataRicevRimb = txtDataRicevRimb.Text;
            recupero.RimbSostegno = txtRimbSostegno.Text;
            recupero.RimbSpeseAmm = txtRimbSpeseAmm.Text;
            recupero.NonrSostegno = txtNonRSostegno.Text;
            recupero.NonrSpeseAmm = txtNonRSpeseAmm.Text;

            return recupero;
        }

        private void PulisciDettaglio()
        {
            txtIdRecupero.Text = null;
            txtIdProgetto.Text = null;
            //txtIdAtto.Text = null;
            hdnIdAtto.Value = null;
            txtSostegno.Text = null;
            txtSpeseAmm.Text = null;
            txtDataRicevRimb.Text = null;
            txtRimbSostegno.Text = null;
            txtRimbSpeseAmm.Text = null;
            txtNonRSostegno.Text = null;
            txtNonRSpeseAmm.Text = null;
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

        protected void btnSelezionaRecupero_Click(object sender, EventArgs e)
        {
        }

        protected void btnRitorna_OnClick(object sender, EventArgs e)
        {
            hdnIdRecupero.Value = null;
            recSel = null;
        }

        protected void btnSalva_OnClick(object sender, EventArgs e)
        {
            SiarLibrary.CertspRecuperi recupero = LeggiTxtDettaglio();
            SalvaRecuperi(recupero);
        }

        protected void btnCancella_OnClick(object sender, EventArgs e)
        {
            if (recSel != null)
            {
                CancellaRecupero(recSel);
            }
            NuovoRecupero();
        }

        protected void btnNuovo_OnClick(object sender, EventArgs e)
        {
            NuovoRecupero();
        }

        protected void btnCercaAtto_Click(object sender, EventArgs e)
        {
            show_div_decreto = true;
        }
        
        #endregion

        #region Lettura / Scrittura dati

        private SiarLibrary.CertspRecuperiCollection LeggiRecuperi()
        {
            SiarLibrary.CertspRecuperiCollection rec;

            rec = recPro.getAll();
            rec.Sort("IdProgetto, DataRicevRimb");
            return rec;
        }

        private void SalvaRecuperi(SiarLibrary.CertspRecuperi recupero)
        {
            int _res;
            bool _salvati = false;

            if (CampoObbligatoriCompilati(recupero))
            {
                _res = recPro.Save(recupero);
                if (_res > 0)
                {
                    _salvati = true;
                    recSel = recPro.GetById(recupero.IdRecupero);
                    ShowMessage("Dati Salvati correttamente");
                }
            }
            if (!_salvati)
            {
                recSel = recupero;
            }
        }

        private void NuovoRecupero()
        {
            PulisciDettaglio();
            recSel = new SiarLibrary.CertspRecuperi();
        }

        private void CancellaRecupero(SiarLibrary.CertspRecuperi recupero)
        {
            recPro.Delete(recupero);
        }

        private bool CampoObbligatoriCompilati(SiarLibrary.CertspRecuperi recupero)
        {
            bool compilati = true;
            int _idProgetto;
            string msg = null;

            // Id Progetto
            int.TryParse(recupero.IdProgetto.ToString(), out _idProgetto);
            if (!ProgettoEsiste(_idProgetto))
            {
                compilati = false;
                msg = "Codice progetto errato.";
            }
            if (string.IsNullOrEmpty(recupero.IdProgetto.ToString()))
            {
                if (!compilati)
                {
                    msg += "<br />";
                }
                compilati = false;
                msg += "Codice progetto Obbligatorio.";
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
