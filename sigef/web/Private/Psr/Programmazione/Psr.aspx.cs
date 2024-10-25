using System;
using System.Web.UI.WebControls;

namespace web.Private.regione
{
    public partial class zProgrammazione : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "psr_programmazione";
            base.OnPreInit(e);
        }

        SiarBLL.ZpsrCollectionProvider psr_provider = new SiarBLL.ZpsrCollectionProvider();
        SiarBLL.ZprogrammazioneCollectionProvider programmazione_provider;
        SiarBLL.ZpsrAlberoCollectionProvider albero_provider;
        SiarLibrary.Zpsr psr_selezionato;
        SiarLibrary.ZpsrAlbero albero_selezionato;
        SiarLibrary.Zprogrammazione programmazione_selezionata;

        protected void Page_Load(object sender, EventArgs e)
        {
            programmazione_provider = new SiarBLL.ZprogrammazioneCollectionProvider(psr_provider.DbProviderObj);
            albero_provider = new SiarBLL.ZpsrAlberoCollectionProvider(psr_provider.DbProviderObj);

            if (!string.IsNullOrEmpty(hdnCodicePsr.Value))
            {
                psr_selezionato = psr_provider.GetById(hdnCodicePsr.Value);
            }
            if (psr_selezionato == null)
            {
                hdnCodicePsr.Value = null;
            }
            else
            {
                if (!string.IsNullOrEmpty(hdnCodicePsrAlbero.Value))
                {
                    albero_selezionato = albero_provider.GetById(hdnCodicePsrAlbero.Value);
                }
                int id_programmazione;
                if (int.TryParse(hdnIdProgrammazione.Value, out id_programmazione) && id_programmazione > 0)
                {
                    programmazione_selezionata = programmazione_provider.GetById(id_programmazione);
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    tableElenco.Visible = false;
                    if (psr_selezionato != null)
                    {
                        txtPsrCodice.ReadOnly = true;
                        txtPsrCodice.Text = psr_selezionato.Codice;
                        txtPsrDescrizione.Text = psr_selezionato.Descrizione;
                        txtPsrAnnoDa.Text = psr_selezionato.AnnoDa;
                        txtPsrAnnoA.Text = psr_selezionato.AnnoA;
                        txtPsrCci.Text = psr_selezionato.Cci;

                        SiarLibrary.ZpsrAlberoCollection livelli = albero_provider.Find(psr_selezionato.Codice, null, null, null, null,
                            null, null, null);
                        dgPsrAlbero.DataSource = livelli;
                        dgPsrAlbero.Titolo = "Elementi trovati: " + livelli.Count.ToString();
                        dgPsrAlbero.DataBind();
                        if (albero_selezionato == null)
                        {
                            // inizializzo codice e livello per un eventuale nuovo elemento
                            int nuovo_livello = 1;
                            if (livelli.Count > 0) nuovo_livello = livelli[livelli.Count - 1].Livello + 1;
                            txtPrgCodice.Text = psr_selezionato.Codice + "L" + nuovo_livello.ToString();
                            txtPrgLivello.Text = nuovo_livello.ToString();
                        }
                    }
                    else
                    {
                        trPsrAlbero.Visible = false;
                        btnPsrElimina.Enabled = false;
                        txtPsrCodice.ReadOnly = false;
                        txtPsrCodice.Text = "";
                        txtPsrDescrizione.Text = "";
                        txtPsrAnnoDa.Text = "";
                        txtPsrAnnoA.Text = "";
                        txtPsrCci.Text = "";
                    }

                    if (albero_selezionato != null)
                    {
                        txtPrgCodice.Text = albero_selezionato.Codice;
                        txtPrgDescrizione.Text = albero_selezionato.Descrizione;
                        txtPrgLivello.Text = albero_selezionato.Livello;
                        chkPrgAttivazioneBandi.Checked = albero_selezionato.AttivazioneBandi;
                        chkPrgAttivazioneFA.Checked = albero_selezionato.AttivazioneFa;
                        chkPrgAttivazioneOBMisura.Checked = albero_selezionato.AttivazioneObMisura;
                        chkPrgAttivazioneInvestimenti.Checked = albero_selezionato.AttivazioneInvestimenti;
                        chkPrgAttivazioneFF.Checked = albero_selezionato.AttivazioneFf;
                    }
                    else
                    {
                        btnPrgElimina.Enabled = false;
                        txtPrgDescrizione.Text = "";
                        chkPrgAttivazioneBandi.Checked = chkPrgAttivazioneFA.Checked = chkPrgAttivazioneOBMisura.Checked = false;
                    }
                    break;
                default:
                    tableModifica.Visible = false;
                    SiarLibrary.ZpsrCollection psrs = psr_provider.Find(null, null, null);
                    dgPsr.DataSource = psrs;
                    dgPsr.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgPsr_ItemDataBound);
                    dgPsr.DataBind();

                    if (psr_selezionato != null)
                    {
                        SiarLibrary.ZprogrammazioneCollection programmazione = programmazione_provider.GetProgrammazionePsr(psr_selezionato.Codice, null, null, null, null, null, null);
                        dgProgrammazione.DataSource = programmazione;
                        dgProgrammazione.Titolo = "Elementi trovati: " + programmazione.Count.ToString();
                        dgProgrammazione.ItemDataBound += new DataGridItemEventHandler(dgProgrammazione_ItemDataBound);
                        dgProgrammazione.DataBind();
                        mostraDettaglioProgrammazione();
                    }
                    else trProgrammazione.Visible = false;
                    RegisterClientScriptBlock("espandiProgrammazionePost();");
                    break;
            }
            base.OnPreRender(e);
        }

        void dgPsr_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.Zpsr psr = (SiarLibrary.Zpsr)e.Item.DataItem;
                if (psr_selezionato != null && psr.Codice == psr_selezionato.Codice)
                    e.Item.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32("FEFEEE", 16));
            }
        }

        void dgProgrammazione_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.Zprogrammazione pr = (SiarLibrary.Zprogrammazione)e.Item.DataItem;
                e.Item.Attributes.Add("id", "dgTrProgr" + pr.Id);
                e.Item.Attributes.Add("PathLabel", pr.AdditionalAttributes["PathLabel"]);
                e.Item.Attributes.Add("ElemEspanso", "false");
                if (pr.Livello > 1) e.Item.Style["display"] = "none";
                string testo_cella = "<table style='width100%;padding-left:10px' cellpadding=0 cellspacing=0><tr>";
                int counter = 1;
                while (counter++ < pr.Livello) testo_cella += "<td style='width:20px;border:0'></td>";
                testo_cella += "<td style='width:50px;border:0;padding-right:8px'><span style='font-weight:bold;text-decoration:underline;cursor:pointer;' onclick=\"espandiProgrammazione('"
                    + pr.AdditionalAttributes["PathLabel"] + "');\">" + pr.Codice + "</span></td><td style='border:0'>" + pr.Descrizione + "</td></tr></table>";
                e.Item.Cells[0].Text = testo_cella;
            }
        }

        private void mostraDettaglioProgrammazione()
        {
            try
            {
                int id_programmazione; // se nuovo elemento di primo livello id_programmazione=0
                int count_bandi;
                if (int.TryParse(hdnIdProgrammazione.Value, out id_programmazione))
                {
                    if (programmazione_selezionata == null)
                    {
                        SiarLibrary.ZpsrAlberoCollection primo_livello = albero_provider.Find(psr_selezionato.Codice, null, 1, null, null, null, null, null);
                        if (primo_livello.Count == 0) throw new Exception("Per proseguire è necessario completare la definizione del Programma selezionato.");
                        txtDPTipo.Text = primo_livello[0].Descrizione;
                        txtDPCodice.Text = null;
                        txtDPDescrizione.Text = null;
                        btnDPSESalva.Enabled = false;
                        trDPSottoelemento1.Visible = false;
                        trDPSottoelemento2.Visible = false;
                    }
                    else
                    {
                        lstDPLivello.CommandText = "SELECT CODICE,CAST(LIVELLO AS VARCHAR(5))+' - '+DESCRIZIONE AS DESCRIZIONE FROM zPSR_ALBERO WHERE COD_PSR='"
                            + psr_selezionato.Codice + "' AND LIVELLO>" + programmazione_selezionata.Livello + " ORDER BY LIVELLO";
                        //lstDPLivello.Enabled = false;
                        //lstDPLivello.SelectedValue = programmazione_selezionata.CodTipo;
                        lstDPLivello.DataBind();
                        txtDPCodice.Text = programmazione_selezionata.Codice;
                        txtDPDescrizione.Text = programmazione_selezionata.Descrizione;
                        txtDPTipo.Text = programmazione_selezionata.Tipo;
                        if (programmazione_selezionata.Livello > 1)
                        {
                            btnDPSelezionaPadre.Disabled = false;
                            btnDPSelezionaPadre.Attributes.Add("onclick", "mostraDettaglioProgrammazione(" + programmazione_selezionata.IdPadre + ");");
                            //txtDotazione.CommandText = "select count(*) from zPROGRAMMAZIONE inner join BANDO_PROGRAMMAZIONE ON zPROGRAMMAZIONE.ID = BANDO_PROGRAMMAZIONE.ID_PROGRAMMAZIONE" 
                            //+ " WHERE BANDO_PROGRAMMAZIONE.ID_PROGRAMMAZIONE = " + programmazione_selezionata.Id;
                            //txtDotazione.DataBind();
                            
                            //tdTxtDotazione.Visible = programmazione_selezionata.Livello == 3 ? true : false;

                            tdTxtDPImporto.Visible = true;

                            if (programmazione_selezionata.Livello == 3)
                            {
                                tdTxtDotazione.Visible = true;
                                txtDotazione.Text = programmazione_selezionata.ImportoDotazione!= null?programmazione_selezionata.ImportoDotazione:0;
                                count_bandi = new SiarBLL.ZprogrammazioneCollectionProvider().GetCountProgrammazioneBando(programmazione_selezionata.Id);
                                if (count_bandi > 0) 
                                {
                                    txtDPCodice.ReadOnly = true;
                                    txtDPDescrizione.ReadOnly = true;
                                    btnDPElimina.Enabled = false;
                                }
                            }
                        }

                        SiarLibrary.ZprogrammazioneCollection figli = programmazione_provider.Find(null, null, psr_selezionato.Codice, null, null, programmazione_selezionata.Id);
                        dgDPProgrammazione.DataSource = figli;
                        dgDPProgrammazione.Titolo = "Sottoelementi trovati: " + figli.Count.ToString();
                        dgDPProgrammazione.DataBind();
                    }
                    RegisterClientScriptBlock("mostraPopupTemplate('divDettaglioProgrammazione','divBKGMessaggio');");
                }
            }
            catch (Exception ex) { RegisterClientScriptBlock("chiudiDettaglioProgrammazione();"); ShowError(ex); }
        }

        protected void btnPsrSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica)
                {
                    throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                }

                // Controllo campi obbligatori
                if (string.IsNullOrEmpty(txtPsrCodice.Text) ||
                    string.IsNullOrEmpty(txtPsrDescrizione.Text) ||
                    string.IsNullOrEmpty(txtPsrAnnoDa.Text) ||
                    string.IsNullOrEmpty(txtPsrAnnoA.Text))
                {
                    throw new Exception("E` obbligatorio compilare tutti i campi richiesti dalla form di inserimento.");
                }

                // Valorizzazione campo oggetto
                if (psr_selezionato == null)
                {
                    if (psr_provider.GetById(txtPsrCodice.Text) != null)
                    {
                        throw new Exception("Il codice specificato è già utilizzato da un precedente programma.");
                    }
                    psr_selezionato = new SiarLibrary.Zpsr();
                    psr_selezionato.Codice = txtPsrCodice.Text;
                    psr_selezionato.ProfonditaAlbero = 0;
                }
                psr_selezionato.Descrizione = txtPsrDescrizione.Text;
                psr_selezionato.AnnoDa = txtPsrAnnoDa.Text.Replace(".", "");
                psr_selezionato.AnnoA = txtPsrAnnoA.Text;
                psr_selezionato.Cci = txtPsrCci.Text;

                // Salvataggio
                psr_provider.Save(psr_selezionato);
                hdnCodicePsr.Value = psr_selezionato.Codice;

                ShowMessage("Psr salvato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnPsrElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (psr_selezionato == null) throw new Exception("Il psr selezionato non è valido.");
                if (programmazione_provider.Find(null, null, psr_selezionato.Codice, null, null, null).Count > 0)
                    throw new Exception("Non è possibile eliminare il psr selezionato a causa della presenza di suttolivelli della struttura.");
                psr_provider.DbProviderObj.BeginTran();
                // elimino la struttura
                albero_provider.DeleteCollection(albero_provider.Find(psr_selezionato.Codice, null, null, null, null, null, null, null));
                // elimino il psr
                psr_provider.Delete(psr_selezionato);
                psr_provider.DbProviderObj.Commit();
                ShowMessage("Il psr selezionato è stato eliminato correttamente.");
                btnPsrNuovo_Click(sender, e);
            }
            catch (Exception ex) { psr_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnPsrNuovo_Click(object sender, EventArgs e)
        {
            hdnCodicePsr.Value = "";
            hdnCodicePsrAlbero.Value = "";
            psr_selezionato = null;
            albero_selezionato = null;
        }

        protected void btnPrgSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (psr_selezionato == null) throw new Exception("Il psr selezionato non è valido.");
                if (albero_selezionato == null)
                {
                    albero_selezionato = new SiarLibrary.ZpsrAlbero();
                    albero_selezionato.Codice = txtPrgCodice.Text;
                    albero_selezionato.CodPsr = psr_selezionato.Codice;
                    albero_selezionato.Livello = txtPrgLivello.Text;
                }
                albero_selezionato.Descrizione = txtPrgDescrizione.Text;
                albero_selezionato.AttivazioneBandi = chkPrgAttivazioneBandi.Checked;
                albero_selezionato.AttivazioneFa = chkPrgAttivazioneFA.Checked;
                albero_selezionato.AttivazioneInvestimenti = chkPrgAttivazioneInvestimenti.Checked;
                albero_selezionato.AttivazioneFf = chkPrgAttivazioneFF.Checked;
                albero_selezionato.AttivazioneObMisura = chkPrgAttivazioneOBMisura.Checked;
                albero_provider.Save(albero_selezionato);
                hdnCodicePsrAlbero.Value = albero_selezionato.Codice;
                ShowMessage("Elemento salvato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnPrgElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (albero_selezionato == null) throw new Exception("Il livello selezionato non è valido.");
                if (programmazione_provider.Find(null, albero_selezionato.Codice, psr_selezionato.Codice, null, null, null).Count > 0)
                    throw new Exception("Non è possibile eliminare il livello selezionato a causa della presenza di elementi di programmazione che lo utilizzano.");
                albero_provider.Delete(albero_selezionato);
                hdnCodicePsrAlbero.Value = "";
                albero_selezionato = null;
                ShowMessage("Livello di programmazione eliminato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnPrgNuovo_Click(object sender, EventArgs e)
        {
            hdnCodicePsrAlbero.Value = "";
            albero_selezionato = null;
        }

        protected void btnDPSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (psr_selezionato == null) throw new Exception("Il psr selezionato non è valido.");
                if (programmazione_selezionata == null)
                {
                    programmazione_selezionata = new SiarLibrary.Zprogrammazione();
                    programmazione_selezionata.IdPadre = 0;
                    SiarLibrary.ZpsrAlberoCollection primo_livello = albero_provider.Find(psr_selezionato.Codice, null, 1, null, null, null, null, null);
                    if (primo_livello.Count == 0) throw new Exception("Per proseguire è necessario completare la definizione del Programma selezionato.");
                    programmazione_selezionata.CodTipo = primo_livello[0].Codice;
                }
                programmazione_selezionata.Codice = txtDPCodice.Text;
                programmazione_selezionata.Descrizione = txtDPDescrizione.Text;
                programmazione_selezionata.ImportoDotazione = txtDotazione.Text;
                programmazione_provider.Save(programmazione_selezionata);
                programmazione_selezionata = programmazione_provider.GetById(programmazione_selezionata.Id);
                hdnIdProgrammazione.Value = programmazione_selezionata.Id;
                RegisterClientScriptBlock("alert('Elemento di programmazione salvato correttamente.');");
            }
            catch (Exception ex) { RegisterClientScriptBlock("alert('Attenzione! " + ex.Message + "');"); }
        }

        protected void btnDPElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (programmazione_selezionata == null) throw new Exception("L`elemento selezionato non è valido.");
                if (programmazione_provider.Find(null, null, psr_selezionato.Codice, null, null, programmazione_selezionata.Id)
                    .Count > 0) throw new Exception("Non è possibile eliminare l`elemento selezionato a causa della presenza di sottoelementi di programmazione.");
                // aggiungere controllo sui bandi che attivano questo livello
                programmazione_provider.Delete(programmazione_selezionata);
                hdnIdProgrammazione.Value = "";
                programmazione_selezionata = null;
                RegisterClientScriptBlock("chiudiDettaglioProgrammazione();");
                ShowMessage("Elemento di programmazione eliminato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnDPSESalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (psr_selezionato == null) throw new Exception("Il psr selezionato non è valido.");
                if (programmazione_selezionata == null) throw new Exception("L`elemento selezionato non è valido.");
                if (string.IsNullOrEmpty(lstDPLivello.SelectedValue) || string.IsNullOrEmpty(txtDPSECodice.Text) || string.IsNullOrEmpty(txtDPSEDescrizione.Text))
                    throw new Exception("Specificare codice, descrizione e livello dell`elemento da aggiungere.");
                SiarLibrary.Zprogrammazione np = new SiarLibrary.Zprogrammazione();
                np.CodTipo = lstDPLivello.SelectedValue;
                np.IdPadre = programmazione_selezionata.Id;
                np.Codice = txtDPSECodice.Text;
                np.Descrizione = txtDPSEDescrizione.Text;
                np.ImportoDotazione = txtDPImporto.Text;
                programmazione_provider.Save(np);
                txtDPSECodice.Text = "";
                txtDPSEDescrizione.Text = "";
                RegisterClientScriptBlock("alert('Elemento salvato correttamente.');");
            }
            catch (Exception ex) { RegisterClientScriptBlock("alert('Attenzione! " + ex.Message + "');"); }
        }
    }
}
