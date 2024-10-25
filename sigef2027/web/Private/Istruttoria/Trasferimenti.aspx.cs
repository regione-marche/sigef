using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.Istruttoria
{
    public partial class Trasferimenti : SiarLibrary.Web.PrivatePage
    {
        SiarBLL.ImpresaCollectionProvider impresa_provider = new SiarBLL.ImpresaCollectionProvider();
        SiarLibrary.Impresa impresa_selezionata = null;
        SiarBLL.TrasferimentiCollectionProvider trasf_prov = new SiarBLL.TrasferimentiCollectionProvider();
        SiarLibrary.Trasferimenti trasferimento_selezionato = null;
        SiarBLL.TrasferimentiDettaglioCollectionProvider trasf_dett_prov = new SiarBLL.TrasferimentiDettaglioCollectionProvider();
        SiarBLL.AttiCollectionProvider atti_provider = new SiarBLL.AttiCollectionProvider();
        SiarLibrary.Atti decreto_selezionato = null;
        SiarBLL.TrasferimentiMandatoCollectionProvider trasf_mandato_prov = new SiarBLL.TrasferimentiMandatoCollectionProvider();
        SiarLibrary.TrasferimentiMandato trasf_mandato_selezionato = null;

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "trasferimenti";
            base.OnPreInit(e);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            Form.DefaultButton = btnCercaDB.UniqueID;
            txtCuaaRicerca.AddJSAttribute("onblur", "ctrlCuaaDitta();");
            int id_impresa;
            if (int.TryParse(hdnIdImpresa.Value, out id_impresa))
            {
                tbImpresa.Visible = true;
                impresa_selezionata = impresa_provider.GetById(id_impresa);
                int id_trasferimento;
                if (int.TryParse(hdnIdTrasferimento.Value, out id_trasferimento))
                {
                    trasferimento_selezionato = trasf_prov.GetById(id_trasferimento);
                    divTrasf_new.Visible = true;
                    divProgetti.Visible = true;
                    divBandi.Visible = true;

                    int id_trasf_mand;
                    if (int.TryParse(hdnIdTrasferimentoMandato.Value, out id_trasf_mand))
                    {
                        trasf_mandato_selezionato = trasf_mandato_prov.GetById(id_trasf_mand);
                    }
                }
                else
                {
                    if (decreto_selezionato != null) tbTrasf_new.Visible = true;
                    divProgetti.Visible = false;
                    divBandi.Visible = false;
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            //imgTrasf_new.Attributes.Add("src", PATH_IMAGES + "ArrowUpSolid.png");
            //imgdivBandi.Attributes.Add("src", PATH_IMAGES + "ArrowUpSolid.png");
            //imgProgetti.Attributes.Add("src", PATH_IMAGES + "ArrowUpSolid.png");

            if (impresa_selezionata != null)
            {
                tbImpresa.Visible = true;
                txtCuaa.Text = impresa_selezionata.Cuaa;
                txtPiva.Text = impresa_selezionata.CodiceFiscale;
                txtRagioneSociale.Text = impresa_selezionata.RagioneSociale;

                SiarLibrary.TrasferimentiCollection trasf_coll = trasf_prov.Find(impresa_selezionata.IdImpresa, null);
                if (trasferimento_selezionato != null)
                    trasf_coll = trasf_coll.SubSelect(trasferimento_selezionato.IdTrasferimento, null, null, null, null, null, null);
                dgTrasferimenti.DataSource = trasf_coll;
                if (trasf_coll.Count == 0) dgTrasferimenti.Titolo = "Nessun trasferimento inserito.";
                else dgTrasferimenti.SetTitoloNrElementi();
                dgTrasferimenti.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgTrasferimenti_ItemDataBound);
                dgTrasferimenti.DataBind();

                lstAttoDefinizione.DataBind();
                lstAttoRegistro.DataBind();
                lstAttoOrgIstituzionale.DataBind();
                lstAttoTipo.DataBind();

                lstBandi.DataBind();


                if (trasferimento_selezionato != null)
                {
                    txtAttoImporto.Text = trasferimento_selezionato.Importo;
                    ddlCausale.SelectedValue = trasferimento_selezionato.CausaleTrasferimento;
                    decreto_selezionato = atti_provider.GetById(trasferimento_selezionato.IdAtto);
                    btnAssociaDecreto.Enabled = false;
                    btnCercaDecreto.Enabled = false;

                    SiarLibrary.TrasferimentiDettaglioCollection trasfDett_coll = trasf_dett_prov.Find(trasferimento_selezionato.IdTrasferimento, null, null, null);
                    //Trasferimento Dettaglio Progetto
                    SiarLibrary.TrasferimentiDettaglioCollection trasf_prog_coll = new SiarLibrary.TrasferimentiDettaglioCollection();
                    foreach (SiarLibrary.TrasferimentiDettaglio td in trasfDett_coll)
                    {
                        if (td.IdProgetto != null && td.IdProgetto != "")
                            trasf_prog_coll.Add(td);
                    }
                    dgTrasfDettaglioProgetti.DataSource = trasf_prog_coll;
                    if (trasf_prog_coll == null || trasf_prog_coll.Count == 0) dgTrasfDettaglioProgetti.Titolo = "Nessun progetto collegato.";
                    else dgTrasfDettaglioProgetti.SetTitoloNrElementi();
                    dgTrasfDettaglioProgetti.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgTrasfDettaglioProgetti_ItemDataBound);
                    dgTrasfDettaglioProgetti.DataBind();


                    //trasferimento dettaglio bando
                    SiarLibrary.TrasferimentiDettaglioCollection trasf_bando_coll = new SiarLibrary.TrasferimentiDettaglioCollection();
                    foreach (SiarLibrary.TrasferimentiDettaglio td in trasfDett_coll)
                    {
                        if (td.IdBando != null && td.IdBando != "")
                            trasf_bando_coll.Add(td);
                    }
                    dgTrasfDettaglioBando.DataSource = trasf_bando_coll;
                    if (trasf_bando_coll == null || trasf_bando_coll.Count == 0) dgTrasfDettaglioBando.Titolo = "Nessuna Procedura di Attivazione collegata.";
                    else dgTrasfDettaglioBando.SetTitoloNrElementi();
                    dgTrasfDettaglioBando.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgTrasfDettaglioBando_ItemDataBound);
                    dgTrasfDettaglioBando.DataBind();


                }


                if (decreto_selezionato != null)
                {
                    tbTrasf_new.Visible = true;
                    hdnIdAtto.Value = decreto_selezionato.IdAtto;
                    txtAttoData.Text = decreto_selezionato.Data;
                    txtAttoNumero.Text = decreto_selezionato.Numero;
                    txtAttoDescrizione.Text = decreto_selezionato.Descrizione;
                    lstAttoOrgIstituzionale.SelectedValue = decreto_selezionato.CodOrganoIstituzionale;

                    foreach (ListItem l in lstAttoRegistro.Items) if (l.Value.StartsWith(decreto_selezionato.Registro)) { l.Selected = true; break; }

                    if (!string.IsNullOrEmpty(decreto_selezionato.CodTipo))
                    {
                        lstAttoTipo.SelectedValue = decreto_selezionato.CodTipo;
                        lstAttoTipo.Enabled = false;
                    }
                    txtAttoBurNumero.Text = decreto_selezionato.NumeroBur;
                    txtAttoBurData.Text = decreto_selezionato.DataBur;
                    btnVidualizzaDecreto.Disabled = false;
                    btnVidualizzaDecreto.Attributes.Add("onclick", "visualizzaAtto(" + decreto_selezionato.IdAtto + ");");

                    //Mandati
                    
                    if (trasferimento_selezionato != null)
                    {
                        divMostraMandati.Visible = true;
                        SiarLibrary.TrasferimentiMandatoCollection mandato_coll = trasf_mandato_prov.Find(null, trasferimento_selezionato.IdTrasferimento);
                        dgTrasferimentoMandato.DataSource = mandato_coll;
                        dgTrasferimentoMandato.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgTrasferimentoMandato_ItemDataBound);
                        dgTrasferimentoMandato.DataBind();

                        if (trasf_mandato_selezionato != null)
                        {
                            divMandato.Visible = true;
                            ufMandato.IdFile = trasf_mandato_selezionato.MandatoIdFile;
                            txtMandatoNumero.Text = trasf_mandato_selezionato.MandatoNumero;
                            txtMandatoData.Text = trasf_mandato_selezionato.MandatoData;
                            txtMandatoImporto.Text = trasf_mandato_selezionato.MandatoImporto;

                            if (trasf_mandato_selezionato.QuietanzaData != null)
                                txtQuietanzaData.Text = trasf_mandato_selezionato.QuietanzaData;
                            else
                                txtQuietanzaData.Text = "";
                            if (trasf_mandato_selezionato.QuietanzaImporto != null)
                                txtQuietanzaImporto.Text = trasf_mandato_selezionato.QuietanzaImporto;
                            else
                                txtQuietanzaImporto.Text = "";
                        }
                    }
                    
                }
                else
                {
                    pulisciCampiDecreto();
                }

            }

            base.OnPreRender(e);
        }

        protected void btnCercaDB_Click(object sender, EventArgs e)
        {
            try
            {
                hdnIdTrasferimento.Value = "";
                hdnIdImpresa.Value = "";
                hdnIdTrasferimentoMandato.Value = "";
                decreto_selezionato = null;
                trasferimento_selezionato = null;
                trasf_mandato_selezionato = null;
                if (string.IsNullOrEmpty(txtCuaaRicerca.Text)) throw new Exception("Inserire una Partita iva/Codice fiscale valida per la ricerca.");
                else
                {
                    string cuaa_selezionato = txtCuaaRicerca.Text;
                    impresa_selezionata = impresa_provider.GetByCuaa(cuaa_selezionato);
                    if (impresa_selezionata != null)
                    {
                        hdnIdImpresa.Value = impresa_selezionata.IdImpresa.ToString();
                    }
                    else
                        throw new Exception("Beneficiario non trovato in anagrafica locale. Contattare l'helpdesk per l'inserimento");
                }
            }
            catch (Exception ex) { ShowError(ex); }
        }

        void dgTrasferimenti_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.Trasferimenti te = (SiarLibrary.Trasferimenti)e.Item.DataItem;
                e.Item.Cells[4].Text = string.Format("{0:c}", te.Importo);
                string causale = "";
                switch (te.CausaleTrasferimento)
                {
                    case "1":
                        causale = "Trasferimento a titolo di anticipazione";
                        break;
                    case "2":
                        causale = "Trasferimento intermedio";
                        break;
                    case "3":
                        causale = "Trasferimento a saldo";
                        break;

                }
                e.Item.Cells[5].Text = causale;

                decimal mandati = 0, quietanza = 0;
                SiarLibrary.TrasferimentiMandatoCollection trasf_mand_coll = new SiarBLL.TrasferimentiMandatoCollectionProvider().Find(null, te.IdTrasferimento);
                foreach(SiarLibrary.TrasferimentiMandato tm in trasf_mand_coll)
                {
                    if (tm.MandatoImporto != null)
                        mandati += tm.MandatoImporto;
                    if (tm.QuietanzaImporto != null)
                        quietanza += tm.QuietanzaImporto;
                }
                e.Item.Cells[7].Text = string.Format("{0:c}", mandati);
                e.Item.Cells[8].Text = string.Format("{0:c}", quietanza);

                if (trasferimento_selezionato != null && te.IdTrasferimento == trasferimento_selezionato.IdTrasferimento)
                    e.Item.Cells[9].Text = e.Item.Cells[9].Text.Replace("Seleziona", "Torna elenco");

            }
        }
        
        void dgTrasfDettaglioProgetti_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.TrasferimentiDettaglio td = (SiarLibrary.TrasferimentiDettaglio)e.Item.DataItem;
                SiarLibrary.Progetto prog = new SiarBLL.ProgettoCollectionProvider().GetById(td.IdProgetto);
                SiarLibrary.Bando b = new SiarBLL.BandoCollectionProvider().GetById(prog.IdBando);
                e.Item.Cells[1].Text = b.Descrizione;
                e.Item.Cells[2].Text = prog.Stato;
                SiarLibrary.Utenti u = new SiarBLL.UtentiCollectionProvider().GetById(td.Operatore);
                e.Item.Cells[3].Text = u.Nominativo;
            }
        }

        void dgTrasfDettaglioBando_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.TrasferimentiDettaglio td = (SiarLibrary.TrasferimentiDettaglio)e.Item.DataItem;
                SiarLibrary.Bando b = new SiarBLL.BandoCollectionProvider().GetById(td.IdBando);
                e.Item.Cells[1].Text = b.Descrizione;
                e.Item.Cells[2].Text = b.Stato;
                SiarLibrary.Utenti u = new SiarBLL.UtentiCollectionProvider().GetById(td.Operatore);
                e.Item.Cells[3].Text = u.Nominativo;
            }
        }

        decimal tot_mandatoImporto = 0, tot_quietanzaImporto = 0;
        void dgTrasferimentoMandato_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            int col_Id = 0,
                col_MandatoNumero = 1,
                col_MandatoData = 2,
                col_MandatoImporto = 3,
                col_MandatoFile = 4,
                col_QuietanzaData = 5,
                col_QuietanzaImporto = 6;

            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.CssClass = "TESTA1";
                e.Item.Cells[0].ColumnSpan = 5;
                e.Item.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Item.Cells[0].Text = "Mandati</td><td colspan=2 align=center>Quietanza</td></tr><tr class='TESTA'><td>Id";
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.TrasferimentiMandato td = (SiarLibrary.TrasferimentiMandato)e.Item.DataItem;

                //Mandato
                e.Item.Cells[col_MandatoImporto].Text = string.Format("{0:c}", td.MandatoImporto);
                tot_mandatoImporto += td.MandatoImporto;
                if (td.MandatoIdFile != null)
                    e.Item.Cells[col_MandatoFile].Text = "<img src='" + Page.ResolveUrl("~/images/print_ico.gif") + "' alt='File'  onclick=\"SNCUFVisualizzaFile(" + td.MandatoIdFile + ");\" style='cursor: pointer;'>";

                //Quietanza
                if (td.QuietanzaImporto != null)
                {
                    e.Item.Cells[col_QuietanzaImporto].Text = string.Format("{0:c}", td.QuietanzaImporto);
                    tot_quietanzaImporto += td.QuietanzaImporto;
                }

            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[col_MandatoImporto].Text = string.Format("{0:c}", tot_mandatoImporto);
                e.Item.Cells[col_QuietanzaImporto].Text = string.Format("{0:c}", tot_quietanzaImporto);
            }
        }

        protected void btnInserisciNew_Click(object sender, EventArgs e)
        {
            pulisciCampiDecreto();
            divTrasf_new.Visible = true;
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
                if (atti_trovati.Count > 0)
                {
                    decreto_selezionato = atti_trovati[0];
                    hdnIdAtto.Value = "";
                    txtAttoImporto.Text = null;
                    tbTrasf_new.Visible = true;
                }
                else ShowError("La ricerca non ha prodotto nessun risultato.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnAssociaDecreto_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

                int id_decreto;
                if (int.TryParse(hdnIdAtto.Value, out id_decreto))
                    decreto_selezionato = atti_provider.GetById(id_decreto);
                if (decreto_selezionato == null) throw new Exception("Per proseguire è necessario specificare l'atto di riferimento.");

                if (string.IsNullOrEmpty(lstAttoTipo.SelectedValue)) throw new Exception("Per proseguire è necessario specificare la tipologia dell'atto.");
                // se non è ancora definita la tipologia dell'atto, la salvo
                if (decreto_selezionato.CodTipo == null)
                {
                    decreto_selezionato.CodTipo = lstAttoTipo.SelectedValue;
                    atti_provider.Save(decreto_selezionato);
                }

                //SiarLibrary.ErogazioneAnticipoEnte trasfer = new SiarLibrary.ErogazioneAnticipoEnte();
                if (trasferimento_selezionato == null)
                {
                    trasferimento_selezionato = new SiarLibrary.Trasferimenti();
                    trasferimento_selezionato.IdImpresa = impresa_selezionata.IdImpresa;
                }
                trasferimento_selezionato.CausaleTrasferimento = ddlCausale.SelectedValue;
                trasferimento_selezionato.IdAtto = decreto_selezionato.IdAtto;
                trasferimento_selezionato.Importo = txtAttoImporto.Text;
                trasferimento_selezionato.Operatore = Operatore.Utente.IdUtente;
                trasferimento_selezionato.DataCreazione = DateTime.Today;
                trasf_prov.Save(trasferimento_selezionato);
                hdnIdTrasferimento.Value = trasferimento_selezionato.IdTrasferimento.ToString();
                divProgetti.Visible = true;
                divBandi.Visible = true;
                //btnNuovoMandato.Visible = true;
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void pulisciCampiDecreto()
        {
            decreto_selezionato = null;
            hdnIdTrasferimento.Value = "";
            trasferimento_selezionato = null;
            tbTrasf_new.Visible = true;
            decreto_selezionato = null;
            hdnIdAtto.Value = "";
            txtAttoData.Text = "";
            txtAttoNumero.Text = "";
            lstAttoRegistro.ClearSelection();
            lstAttoTipo.ClearSelection();
            lstAttoOrgIstituzionale.ClearSelection();
            txtAttoDescrizione.Text = "";
            txtAttoBurData.Text = "";
            txtAttoBurNumero.Text = "";
            txtAttoImporto.Text = "";
            divProgetti.Visible = false;
            divBandi.Visible = false;
        }

        protected void btnSelezionaTrasf_Click(object sender, EventArgs e)
        {
        }

        protected void btnAggiungiProgetto_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txtIdProgetto.Text)) throw new Exception("Inserire il numero del Progetto.");
                SiarLibrary.Progetto prog = new SiarBLL.ProgettoCollectionProvider().GetById(txtIdProgetto.Text);
                if (prog == null) throw new Exception("Numero del Progetto inesistente.");

                string TrasfBool = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_TrasferimentoEnte(prog.IdBando);
                if (TrasfBool != "True") throw new Exception("La procedura di attivazione non prevede l'aggancio dei propri progetti ai trasferimenti.");

                bool capofila = true;
                //controllo se il benficiario è quello che ha presentato domanda
                if (prog.IdImpresa != impresa_selezionata.IdImpresa)
                    capofila = false;

                bool aggregazione = false;
                SiarLibrary.ProgettoNaturaSoggettoCollection nat_sogg_coll = new SiarBLL.ProgettoNaturaSoggettoCollectionProvider().Find(prog.IdProgetto, "Aggregata", null);
                if (nat_sogg_coll.Count > 0)
                {
                    int id_aggr = nat_sogg_coll[0].IdAggregazione;
                    SiarLibrary.ImpresaAggregazioneCollection imp_aggr_coll = new SiarBLL.ImpresaAggregazioneCollectionProvider().Find(id_aggr, null, null, true, null);
                    foreach (SiarLibrary.ImpresaAggregazione aggr in imp_aggr_coll)
                    {
                        if (aggr.IdImpresa == impresa_selezionata.IdImpresa)
                            aggregazione = true;
                    }

                }

                if (!capofila && !aggregazione)
                    throw new Exception("Il beneficiario selezionato non coincide con quello del progetto che si sta cercando di inserire.");


                SiarLibrary.TrasferimentiDettaglio td = new SiarLibrary.TrasferimentiDettaglio();
                td.IdTrasferimento = trasferimento_selezionato.IdTrasferimento;
                td.IdProgetto = prog.IdProgetto;
                td.Operatore = Operatore.Utente.IdUtente;
                td.DataCreazione = DateTime.Today;
                trasf_dett_prov.Save(td);
                txtIdProgetto.Text = "";


                ShowMessage("Progetto associato corretamente al trasferimento");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnAggiungiBando_Click(object sender, EventArgs e)
        {
            try
            {

                //if (txtBando.Text == "") throw new Exception("Inserire il numero del Progetto.");
                //SiarLibrary.Bando b = new SiarBLL.BandoCollectionProvider().GetById(txtBando.Text);
                //if (b == null) throw new Exception("Numero del bando inesistente.");

                //string TrasfBool = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_TrasferimentoEnte(prog.IdBando);
                //if (TrasfBool != "True") throw new Exception("La procedura di attivazione non prevede l'aggancio dei propri progetti ai trasferimenti.");

                //if (prog.IdImpresa != impresa_selezionata.IdImpresa) throw new Exception("Il beneficiario selezionato non coincide con quello del progetto che si sta cercando di inserire.");
                if (lstBandi.SelectedValue == null || lstBandi.SelectedValue == "") throw new Exception("Selezionare la Procedura di Attivazione.");

                SiarLibrary.TrasferimentiDettaglio td = new SiarLibrary.TrasferimentiDettaglio();
                td.IdTrasferimento = trasferimento_selezionato.IdTrasferimento;
                td.IdBando = lstBandi.SelectedValue;
                td.Operatore = Operatore.Utente.IdUtente;
                td.DataCreazione = DateTime.Today;
                trasf_dett_prov.Save(td);

                ShowMessage("Procedura di attivazione associata corretamente al trasferimento");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            dgTrasfDettaglioBando.SetPageIndex(0);
            dgTrasfDettaglioProgetti.SetPageIndex(0);
        }

        protected void btnNuovoMandato_Click(object sender, EventArgs e)
        {
            try
            {
                divMandato.Visible = true;
                trasf_mandato_selezionato = null;
                hdnIdTrasferimentoMandato.Value = null;
                ufMandato.IdFile = null;
                txtMandatoNumero.Text = "";
                txtMandatoData.Text = "";
                txtMandatoImporto.Text = "";

                txtQuietanzaData.Text = "";
                txtQuietanzaImporto.Text = "";
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalvaMandato_Click(object sender, EventArgs e)
        {
            try
            {
                if (trasf_mandato_selezionato == null)
                {
                    trasf_mandato_selezionato = new SiarLibrary.TrasferimentiMandato();
                    trasf_mandato_selezionato.OperatoreCreazione = Operatore.Utente.IdUtente;
                    trasf_mandato_selezionato.DataCreazione = DateTime.Today;
                    trasf_mandato_selezionato.IdTrasferimento = trasferimento_selezionato.IdTrasferimento;
                }
                else
                {
                    trasf_mandato_selezionato.OperatoreModifica = Operatore.Utente.IdUtente;
                    trasf_mandato_selezionato.DataModifica = DateTime.Today;
                }

                trasf_mandato_selezionato.MandatoData = txtMandatoData.Text;
                trasf_mandato_selezionato.MandatoImporto = txtMandatoImporto.Text;
                trasf_mandato_selezionato.MandatoNumero = txtMandatoNumero.Text;
                trasf_mandato_selezionato.MandatoIdFile = ufMandato.IdFile;

                if (txtQuietanzaData.Text != "" && txtQuietanzaData.Text != null)
                    trasf_mandato_selezionato.QuietanzaData = txtQuietanzaData.Text;
                if (txtQuietanzaImporto.Text != "" && txtQuietanzaImporto.Text != null)
                    trasf_mandato_selezionato.QuietanzaImporto = txtQuietanzaImporto.Text;

                trasf_mandato_prov.Save(trasf_mandato_selezionato);
                hdnIdTrasferimentoMandato.Value = trasf_mandato_selezionato.IdTrasferimentoMandato.ToString();
                ShowMessage("Dati del mandato di pagamento registrati correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnEliminaMandato_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnIdTrasferimentoMandato.Value == "" || hdnIdTrasferimentoMandato.Value == null)
                    throw new Exception("Nessun mandato selezionato!");

                trasf_mandato_prov.Delete(trasf_mandato_selezionato);
                hdnIdTrasferimentoMandato.Value = null;
                trasf_mandato_selezionato = null;

                divMandato.Visible = false;
                ufMandato.IdFile = null;
                txtMandatoNumero.Text = "";
                txtMandatoData.Text = "";
                txtMandatoImporto.Text = "";

                txtQuietanzaData.Text = "";
                txtQuietanzaImporto.Text = "";


                ShowMessage("Mandato eliminato correttamente!");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnPostNull_Click(object sender, EventArgs e)
        {
        }
     
    }
}