using SiarBLL;
using SiarLibrary;
using SiarLibrary.NullTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.Controlli
{
    public partial class ControlliStabilita : SiarLibrary.Web.PrivatePage
    {
        ControlliStabilitaEstrazioneCollectionProvider estrazioneProvider = new ControlliStabilitaEstrazioneCollectionProvider();        

        string profilo_utente;

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "controlli_stabilita";
            base.OnPreInit(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    tbNuovaEstrazione.Visible = true;
                    profilo_utente = ((SiarLibrary.Web.PrivatePage)Page).Operatore.Utente.Profilo;
                    if (profilo_utente.Contains("Responsabile di misura") || profilo_utente.Contains("Funzionario istruttore") || profilo_utente.Contains("Amministratore"))
                    {
                        AbilitaModifica = true;

                        int id_estrazione;
                        btnSave.Enabled = false;                        
                        if (!string.IsNullOrEmpty(hdnIdEstrazione.Value))
                        {
                            int.TryParse(hdnIdEstrazione.Value, out id_estrazione);

                            SiarLibrary.ControlliStabilitaEstrazione estrazione = estrazioneProvider.GetById(id_estrazione);
                            if (estrazione != null)
                            {
                                hdnProgettiEstrazione.Value = estrazione.Progetti;
                                txtDataEstrazione.Text = estrazione.DataApertura;
                                txtSegnatura.Text = estrazione.Segnatura;
                                if (estrazione.Segnatura != null)
                                {
                                    AbilitaModifica = false;
                                    btnElimina.Enabled = AbilitaModifica;
                                    btnSave.Enabled = AbilitaModifica;
                                }
                                else
                                {
                                    btnElimina.Enabled = AbilitaModifica;
                                    btnSave.Enabled = AbilitaModifica;
                                }

                            }
                            else
                            {
                                btnElimina.Enabled = AbilitaModifica;
                                btnSave.Enabled = AbilitaModifica;
                            }
                        }
                        else
                        {
                            btnElimina.Enabled = AbilitaModifica;
                            btnSave.Enabled = AbilitaModifica;
                        }
                        popolaDataGridBandiRup();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:FiltraRichieste();", true);
                    }
                    else
                    {
                        AbilitaModifica = false;
                        btnElimina.Enabled = AbilitaModifica;
                        btnSave.Enabled = AbilitaModifica;
                    }
                    break;
                default:
                    hdnIdEstrazione.Value = "";
                    tbEstrazioni.Visible = true;
                    SiarLibrary.ControlliStabilitaEstrazioneCollection estrazioni = new ControlliStabilitaEstrazioneCollectionProvider().Find(null);
                    dgEstrazioni.DataSource = estrazioni;
                    dgEstrazioni.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgEstrazioni_ItemDataBound);
                    if (estrazioni.Count == 0) dgEstrazioni.Titolo = "&nbsp;&nbsp;&nbsp;<em><b>Nessuna estrazione effettuata.</b></em>";
                    dgEstrazioni.DataBind();
                    break;
            }
            base.OnPreRender(e);
        }

        void dgEstrazioni_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.ControlliStabilitaEstrazione c = (SiarLibrary.ControlliStabilitaEstrazione)e.Item.DataItem;
                e.Item.Cells[2].Text = new SiarBLL.UtentiCollectionProvider().GetById(c.Operatore).Nominativo;

                e.Item.Cells[3].Text = "<input type=button class=ButtonGrid value='" + c.Segnatura + "' style='width:370px' onclick=\"sncAjaxCallVisualizzaProtocollo('" + c.Segnatura + "')\" />";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNuovoPost_Click(object sender, EventArgs e)
        {
            pulisciCampi();
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (hdnIdEstrazione.Value == null || hdnIdEstrazione.Value == string.Empty) throw new Exception("La comunicazione selezionata non è valida.");
                //SiarLibrary.ComunicazioniMassive c = comunicazioni_massive_provider.GetById(hdnIdEstrazione.Value);
                SiarLibrary.ControlliStabilitaEstrazione c = estrazioneProvider.GetById(hdnIdEstrazione.Value);
                if (c.Segnatura != null) throw new Exception("La comunicazione selezionata è stata protocollata e non può essere eliminata.");
                //comunicazioni_massive_provider.Delete(c);
                pulisciCampi();
                RegisterClientScriptBlock("pulisciCampi();");
                ShowMessage("Comunicazione eliminata correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void pulisciCampi()
        {
            hdnIdEstrazione.Value = null;
            hdnProgettiEstrazione.Value = null;
            txtDataEstrazione.Text = string.Empty;
            txtSegnatura.Text = string.Empty;
            btnElimina.Enabled = AbilitaModifica;
            btnSave.Enabled = AbilitaModifica;
        }

        protected void popolaDataGridBandiRup()
        {
            VcontrolliStabilitaCollection controlli_stabilita_collection = new VcontrolliStabilitaCollectionProvider().Find(null, null, null, null, null, null);

            if (controlli_stabilita_collection.Count > 0)
            {
                lblNrRecordProgetti.Text = string.Format("Visualizzate {0} righe", controlli_stabilita_collection.Count.ToString());

                dgDomande.DataSource = controlli_stabilita_collection;
                dgDomande.DataBind();
            }
            else
            {
                lblNrRecordProgetti.Text = "Nessun progetto trovato.";
            }
        }

        protected void btnSalvaEstrazione_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                estrazioneProvider.DbProviderObj.BeginTran();
                verificaSegnatura();
                SiarLibrary.ControlliStabilitaEstrazione estrazione = new ControlliStabilitaEstrazione();

                if (!string.IsNullOrEmpty(hdnIdEstrazione.Value))
                    estrazione = estrazioneProvider.GetById(hdnIdEstrazione.Value);

                if (string.IsNullOrEmpty(hdnProgettiEstrazione.Value)) throw new SiarLibrary.SiarException("Selezionare almeno un progetto per l'estrazione");

                estrazione.Progetti = hdnProgettiEstrazione.Value;
                estrazione.DataApertura = txtDataEstrazione.Text;
                estrazione.Segnatura = txtSegnatura.Text;
                estrazione.Operatore = Operatore.Utente.IdUtente;

                estrazioneProvider.Save(estrazione);
                estrazioneProvider.DbProviderObj.Commit();
                hdnIdEstrazione.Value = estrazione.Id;
                hdnProgettiEstrazione.Value = estrazione.Progetti;
                txtSegnatura.Text = estrazione.Segnatura;
                txtDataEstrazione.Text = estrazione.DataApertura;
                ShowMessage("Estrazione salvata correttamente.");
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
                byte[] doc = richiesta.RicercaProtocollo(txtSegnatura.Text, true);
                ShowMessage("La segnatura risulta corretta.");
            }
            catch (Exception ex) { throw ex; }
        }
    }
}