using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.Istruttoria
{
    public partial class AmmissibilitaCofirmatario : SiarLibrary.Web.IstruttoriaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "ammissibilita_domande";
            base.OnPreInit(e);
        }
        SiarLibrary.Progetto p;
        SiarBLL.PersoneXImpreseCollectionProvider pxp_provider;
        SiarLibrary.PersoneXImprese amministratore, rlegale;
        SiarLibrary.PersoneXImpreseCollection amm_coll;

        protected void Page_Load(object sender, EventArgs e)
        {
            int idProgetto;

            if (!int.TryParse(Request.QueryString["iddom"], out idProgetto)) Redirect("Ammissibilita.aspx");
            else
            {
                p = new SiarBLL.ProgettoCollectionProvider().GetById(idProgetto);
                ucInfoDomanda.Progetto = p;
                controlloOperatoreStatoProgetto();
                btnBack.Attributes.Add("onclick", "location='ChecklistAmmissibilita.aspx?iddom=" + ucInfoDomanda.Progetto.IdProgetto + "'");
            }

            pxp_provider = new SiarBLL.PersoneXImpreseCollectionProvider();
            amministratore = new SiarLibrary.PersoneXImprese();
            SiarLibrary.Impresa impresa = new SiarBLL.ImpresaCollectionProvider().GetById(p.IdImpresa);
            //Rappresentante Legale
            rlegale = pxp_provider.GetById(impresa.IdRapprlegaleUltimo);
            txtRLCodiceFiscale.Text = rlegale.CodiceFiscale;
            txtRLNominativo.Text = rlegale.Cognome + " " + rlegale.Nome;

        }
        protected override void OnPreRender(EventArgs e)
        {
            txtRicercaCodFiscale.AddJSAttribute("onblur", "ctrlCF(this,event);");
            SiarLibrary.PersoneXImpreseCollection cofirmatari = new SiarBLL.PersoneXImpreseCollectionProvider().Find(null, null, p.IdImpresa,
                      "C", true, true);
            if (!IsPostBack && cofirmatari.Count > 0) VisualizzaCofirmatario(cofirmatari[0]);
            if (cofirmatari.Count > 0 && cofirmatari[0].Ammesso) tdAmmesso.InnerHtml = tdAmmesso.InnerHtml + "  <img src='" + Request.ApplicationPath + "/images/visto.gif' alt='Ammessa' />";

            base.OnPreRender(e);
        }

        void dgPersonale_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                amministratore = (SiarLibrary.PersoneXImprese)dgi.DataItem;
                e.Item.Cells[6].Text = "<input type='button' style='width:70px' class='ButtonGrid' value='Dettaglio' onclick='dettaglioAmministratore("
                   + amministratore.IdPersoneXImprese + ")' />";
            }
        }

        protected void btnScarica_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtRicercaCodFiscale.Text) || txtRicercaCodFiscale.Text.Length != 16)
                    throw new Exception("Digitare un codice fiscale valido.");
                if (txtRicercaCodFiscale.Text == rlegale.CodiceFiscale)
                    throw new Exception("Il codice fiscale indicato corrisponde al Rappresentate Legale dell'impresa. Impossibile continuare.");

                SiarLibrary.PersonaFisica pf;
                SiarLibrary.PersonaFisicaCollection persone_trovate = new SiarBLL.PersonaFisicaCollectionProvider().Find(txtRicercaCodFiscale.Text);
                if (persone_trovate.Count > 0 && persone_trovate[0].Nome != null) pf = persone_trovate[0];
                else
                {
                    SianWebSrv.TraduzioneSianToSiar trad = new SianWebSrv.TraduzioneSianToSiar();
                    pf = trad.ScaricaDatiPersonaFisica(txtRicercaCodFiscale.Text, Operatore.Utente.CfUtente);
                }
                if (pf == null) throw new Exception("Il codice fiscale non corrisponde a nessuna persona fisica conosciuta.");

                hdnIdPersonaFisica.Value = pf.IdPersona;
                txtNominativo.Text = pf.Cognome + " " + pf.Nome;
                txtRicercaCodFiscale.Text = pf.CodiceFiscale;
                txtDataNascita.Text = pf.DataNascita;
                txtComuneNascita.Text = pf.Comune + " (" + pf.Provincia + ") ";
                txtDataInsediamento.Text = string.Empty;
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            int id_persona;
            DateTime data_insediamento;
            amm_coll = new SiarLibrary.PersoneXImpreseCollection();
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (!int.TryParse(hdnIdPersonaFisica.Value, out id_persona)) throw new Exception("Persona non corretta");
                if (!DateTime.TryParse(txtDataInsediamento.Text, out data_insediamento)) throw new Exception("Data insediamento del Cofirmatario non valida. Impossibile continuare.");
                if (rlegale.IdPersona == id_persona) throw new Exception("La persona indicata è il Rappresentante Legale dell'impresa. Impossibile continuare.");

                // se ne esiste un altro? LO STORICIZZO
                amm_coll = pxp_provider.Find(null, null, p.IdImpresa, "C", true, true);
                if (amm_coll.Count == 0)
                {
                    amministratore = new SiarLibrary.PersoneXImprese();
                    amministratore.CodRuolo = "C";
                    amministratore.IdPersona = id_persona;
                    amministratore.IdImpresa = p.IdImpresa;
                    amministratore.DataInizio = data_insediamento;
                    amministratore.Attivo = true;
                    amministratore.Ammesso = true;
                    pxp_provider.Save(amministratore);
                }
                else
                {
                    amministratore = amm_coll[0];
                    if (amministratore.IdPersona != id_persona || !amministratore.Attivo)
                    {
                        //storicizzo il vecchio 
                        amministratore.DataFine = DateTime.Now;
                        amministratore.Ammesso = false;
                        amministratore.Attivo = false;
                        pxp_provider.Save(amministratore);
                        // e ne creo uno nuovo 
                        amministratore.MarkAsNew();
                        amministratore.IdPersona = id_persona;
                        amministratore.CodRuolo = "C";
                    }
                    amministratore.DataInizio = data_insediamento;
                    amministratore.DataFine = null;
                    amministratore.Ammesso = true;
                    pxp_provider.Save(amministratore);
                }
                ShowMessage("Salvatagio completato");
                amministratore = pxp_provider.GetById(amministratore.IdPersoneXImprese);
                VisualizzaCofirmatario(amministratore);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            int id_persona;
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (!int.TryParse(hdnIdPersonaFisica.Value, out id_persona)) throw new Exception("Amministratore non valido.");
                amm_coll = pxp_provider.Find(id_persona, null, p.IdImpresa, "C", true, true);
                if (amm_coll.Count == 0) throw new Exception("Amministratore non valido. Impossibile continuare");
                amministratore = amm_coll[0];
                if (amministratore.CodRuolo != "C") throw new Exception("Attenzione! E' possibile eliminare solo il Cofirmatario. ");
                amministratore.DataFine = DateTime.Now;
                amministratore.Ammesso = false;
                amministratore.Attivo = false;
                pxp_provider.Save(amministratore);
                ShowMessage("Il cofirmatario è stato eliminato.");
                VisualizzaCofirmatario(null);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void VisualizzaCofirmatario(SiarLibrary.PersoneXImprese p)
        {
            if (p == null)
            {
                btnElimina.Enabled = false;
                txtRicercaCodFiscale.Text = string.Empty;
                txtNominativo.Text = string.Empty;
                txtDataInsediamento.Text = string.Empty;
                txtDataNascita.Text = string.Empty;
                txtComuneNascita.Text = string.Empty;
                hdnIdPersonaFisica.Value = string.Empty;
            }
            else
            {
                txtRicercaCodFiscale.Text = p.CodiceFiscale;
                txtNominativo.Text = p.Cognome + " " + p.Nome;
                txtDataInsediamento.Text = p.DataInizio;
                txtDataNascita.Text = p.DataNascita;
                txtComuneNascita.Text = p.Comune + " (" + p.Sigla + ")";
                hdnIdPersonaFisica.Value = p.IdPersona;
            }

        }
        private void controlloOperatoreStatoProgetto()
        {
            if (AbilitaModifica)
            {
                if (ucInfoDomanda.Progetto.CodStato != "I" && !ucInfoDomanda.DomandaInRiesame && !ucInfoDomanda.DomandaInRevisione
                    && !ucInfoDomanda.DomandaInRicorso && !ucInfoDomanda.DomandaInIstruttoriaProvinciale) AbilitaModifica = false;
                else if (new SiarBLL.CollaboratoriXBandoCollectionProvider().Find(Bando.IdBando, ucInfoDomanda.Progetto.IdProgetto,
                        Operatore.Utente.IdUtente, null, true).Count == 0) AbilitaModifica = false;
            }
        }
    }
}
