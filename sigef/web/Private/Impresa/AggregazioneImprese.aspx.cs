    using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.Impresa
{
    public partial class AggregazioneImprese : SiarLibrary.Web.ImpresaPage
    {
        SiarBLL.AggregazioneCollectionProvider AggregazioneCollectionProvider = new SiarBLL.AggregazioneCollectionProvider();
        SiarBLL.ImpresaAggregazioneCollectionProvider ImpresaAggregazioneCollectionProvider = new SiarBLL.ImpresaAggregazioneCollectionProvider();
        int id_aggregazione, id_impresa_aggregazione;

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "impresa_aggregazione";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lstTipoAggregazione.DataBind();

            //ComboAteco
            ComboAteco.Items.Clear();
            ComboAteco.Items.Add("");
            SiarBLL.TipoAteco2007CollectionProvider ateco_prov = new SiarBLL.TipoAteco2007CollectionProvider();
            SiarLibrary.TipoAteco2007Collection ateco = ateco_prov.Find(null);
            foreach (SiarLibrary.TipoAteco2007 a in ateco)
            {

                ComboAteco.Items.Add(new ListItem(a.Sottocategoria + " - " + a.Descrizione, a.CodTipoAteco2007));
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    if (!string.IsNullOrEmpty(hdnIdAggregazione.Value) && !int.TryParse(hdnIdAggregazione.Value, out id_aggregazione)) ShowError("L'aggregazione selezionata non è valida. Impossibile continuare.");
                    else
                    {
                        SiarLibrary.Aggregazione aggregazione = AggregazioneCollectionProvider.GetById(id_aggregazione);

                        bool isCapofila = true;
                        if (aggregazione != null)
                        {
                            SiarLibrary.ImpresaAggregazione impresaAggregazione = ImpresaAggregazioneCollectionProvider.Find(aggregazione.Id, null, Azienda.IdImpresa, null, null)[0];
                            if (impresaAggregazione != null)
                                isCapofila = impresaAggregazione.CodRuolo == "C";
                        }

                        btnEliminaAggregazione.Enabled = aggregazione != null && aggregazione.Attivo && isCapofila;
                        btnSalvaMembro.Enabled = aggregazione != null && aggregazione.Attivo && isCapofila;
                        btnEliminaSocio.Enabled = aggregazione != null && aggregazione.Attivo && isCapofila;
                        btnScaricaDatiImpresa.Enabled = aggregazione != null && aggregazione.Attivo && isCapofila;

                        if (aggregazione != null)
                            btnSalva.Enabled = aggregazione.Attivo && isCapofila;

                        tbNuovaAggregazione.Visible = true;
                        cmbSelTipoAggregazione.DataBind();
                        if (aggregazione != null)
                        {
                            tableImprese.Visible = true;
                            SiarLibrary.ImpresaAggregazioneCollection impresecoll = new SiarLibrary.ImpresaAggregazioneCollection();
                            if (aggregazione != null) impresecoll = ImpresaAggregazioneCollectionProvider.Find(aggregazione.Id, null, null, null, null);

                            dgImpreseAggregazione.DataSource = impresecoll;
                            dgImpreseAggregazione.ItemDataBound += new DataGridItemEventHandler(dgImpreseAggregazione_ItemDataBound);
                            dgImpreseAggregazione.DataBind();
                            cmbTipoImpresaAggregazione.DataBind();
                        }
                    }
                    break;
                default:
                    tbAggregazioni.Visible = true;
                    SiarLibrary.AggregazioneCollection aggColl = AggregazioneCollectionProvider.Find(lstTipoAggregazione.SelectedValue, null, Azienda.IdImpresa, true);
                    dg.DataSource = aggColl;
                    dg.DataBind();
                    dg.Titolo = "Elementi trovati: " + aggColl.Count;
                    break;
            }
            base.OnPreRender(e);
        }

        void dgImpreseAggregazione_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                SiarLibrary.ImpresaAggregazione impresa_aggregazione = (SiarLibrary.ImpresaAggregazione)dgi.DataItem;
                if (!impresa_aggregazione.Attivo)
                {
                    e.Item.Style.Add("background", "#CCC");
                    e.Item.Cells[7].Text = string.Format("Data eliminazione<br/>{0}", impresa_aggregazione.DataFine.ToFullYearString());
                }
                else
                    e.Item.Cells[7].Text = impresa_aggregazione.RuoloAggregazione;


            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            ucSiarNewTab.TabSelected = 2;
            if (!int.TryParse(hdnIdAggregazione.Value, out id_aggregazione)) ShowError("L'aggregazione selezionata non è valida. Impossibile continuare.");
            SiarLibrary.Aggregazione aggregazione = AggregazioneCollectionProvider.GetById(id_aggregazione);
            if (aggregazione != null)
            {
                cmbSelTipoAggregazione.SelectedValue = aggregazione.CodTipoAggregazione;
                txtDenominazione.Text = aggregazione.Denominazione;
                txtDataInizio.Text = aggregazione.DataInizio;
                txtDataFine.Text = aggregazione.DataFine;
            }
        }

        protected void btnPostAggregazione_Click(object sender, EventArgs e)
        {
            int id_aggregazione_impresa = 0;
            if (!int.TryParse(hdnIdImpresaAggregazione.Value, out id_aggregazione_impresa)) ShowError("L'impresa selezionata non è valida. Impossibile continuare.");
            SiarLibrary.ImpresaAggregazione impresaAggregazione = ImpresaAggregazioneCollectionProvider.GetById(id_aggregazione_impresa);
            if (impresaAggregazione != null)
            {
                hdnIdImpresa.Value = impresaAggregazione.IdImpresa;
                txtCFabilitato.Text = impresaAggregazione.Cuaa;
                txtRagSociale.Text = impresaAggregazione.RagioneSociale;
                txtDataInizioPartnership.Text = impresaAggregazione.DataInizio;
                txtDataFinePartnership.Text = impresaAggregazione.DataFine;
                cmbTipoImpresaAggregazione.SelectedValue = impresaAggregazione.CodRuolo;
                ComboAteco.SelectedValue = impresaAggregazione.CodAteco2007;

                if (impresaAggregazione.CodRuolo == "C")
                    btnEliminaSocio.Enabled = false;
                else
                    btnEliminaSocio.Enabled = true;
            }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                AggregazioneCollectionProvider.DbProviderObj.BeginTran();
                SiarLibrary.Aggregazione aggregazione = new SiarLibrary.Aggregazione();
                if (!string.IsNullOrEmpty(hdnIdAggregazione.Value))
                {
                    if (!int.TryParse(hdnIdAggregazione.Value, out id_aggregazione)) ShowError("L'aggregazione selezionata non è valida. Impossibile continuare.");
                    aggregazione = AggregazioneCollectionProvider.GetById(id_aggregazione);
                }

                aggregazione.Denominazione = txtDenominazione.Text;
                aggregazione.CodTipoAggregazione = cmbSelTipoAggregazione.SelectedValue;
                aggregazione.DataInizio = txtDataInizio.Text;
                aggregazione.OperatoreInizio = Operatore.Utente.IdUtente;
                if (!string.IsNullOrEmpty(txtDataFine.Text))
                {
                    if (DateTime.Parse(txtDataInizio.Text) >= DateTime.Parse(txtDataFine.Text)) throw new Exception("Date di inizio e fine non valide");
                    aggregazione.DataFine = txtDataFine.Text;
                }
                aggregazione.Attivo = true;

                AggregazioneCollectionProvider.Save(aggregazione);

                SiarLibrary.ImpresaAggregazione impresaAggregazione = new SiarLibrary.ImpresaAggregazione();
                ImpresaAggregazioneCollectionProvider = new SiarBLL.ImpresaAggregazioneCollectionProvider(AggregazioneCollectionProvider.DbProviderObj);
                SiarLibrary.ImpresaAggregazioneCollection impresa_aggregazione = ImpresaAggregazioneCollectionProvider.Find(aggregazione.Id, "C", Azienda.IdImpresa, true, null);
                if (impresa_aggregazione.Count == 0)
                {
                    impresaAggregazione.IdAggregazione = aggregazione.Id;
                    impresaAggregazione.Attivo = true;
                    impresaAggregazione.CodRuolo = "C";
                    impresaAggregazione.DataInizio = txtDataInizio.Text;
                    impresaAggregazione.OperatoreInizio = Operatore.Utente.IdUtente;
                    impresaAggregazione.OperatoreFine = Operatore.Utente.IdUtente;
                    if (!string.IsNullOrEmpty(txtDataFine.Text))
                        impresaAggregazione.DataFine = txtDataFine.Text;
                    impresaAggregazione.IdImpresa = Azienda.IdImpresa;
                    ImpresaAggregazioneCollectionProvider.Save(impresaAggregazione);
                }

                hdnIdAggregazione.Value = aggregazione.Id;
                AggregazioneCollectionProvider.DbProviderObj.Commit();
                ShowMessage("Aggregazione salvata correttamente.");

            }
            catch (Exception ex) { ShowError(ex); AggregazioneCollectionProvider.DbProviderObj.Rollback(); }
        }

        protected void btnEliminaAggregazione_Click(object sender, EventArgs e)
        {
            DeleteAggregazione(hdnIdAggregazione.Value);
        }

        protected void btnNewAggregazione_Click(object sender, EventArgs e)
        {
            NewAggregazione();
        }

        private void NewAggregazione()
        {
            cmbSelTipoAggregazione.SelectedIndex = -1;
            txtDenominazione.Text = string.Empty;
            hdnIdAggregazione.Value = string.Empty;
            txtDataInizio.Text = string.Empty;
            txtDataFine.Text = string.Empty;
            tableImprese.Visible = false;
            //btnEliminaAggregazione.Enabled = false;
            //btnSalva.Modifica = true;
        }

        private void DeleteAggregazione(SiarLibrary.NullTypes.IntNT idAggregazione)
        {
            try
            {
                // 1. Controllo se l'aggregazione è associata ad un progetto
                // dove va l'id dell'aggregazione in riferimento al progetto?

                AggregazioneCollectionProvider.DbProviderObj.BeginTran();
                ImpresaAggregazioneCollectionProvider = new SiarBLL.ImpresaAggregazioneCollectionProvider(AggregazioneCollectionProvider.DbProviderObj);
                SiarLibrary.Aggregazione agg = AggregazioneCollectionProvider.GetById(idAggregazione);
                //ImpresaAggregazioneCollectionProvider.DeleteCollection(ImpresaAggregazioneCollectionProvider.Find(agg.IdAggregazione, null, null, null, null));
                foreach (SiarLibrary.ImpresaAggregazione i in ImpresaAggregazioneCollectionProvider.Find(agg.Id, null, null, null, null))
                {
                    i.Attivo = false;
                    i.DataFine = DateTime.Now;
                    ImpresaAggregazioneCollectionProvider.Save(i);
                }
                agg.Attivo = false;
                agg.DataFine = DateTime.Now;
                //AggregazioneCollectionProvider.Delete(agg);
                AggregazioneCollectionProvider.Save(agg);
                AggregazioneCollectionProvider.DbProviderObj.Commit();
                ShowMessage("Aggregazione disabilitata correttamente.");
                NewAggregazione();
            }
            catch (Exception ex) { ShowError(ex); AggregazioneCollectionProvider.DbProviderObj.Rollback(); }
            finally { ucSiarNewTab.TabSelected = 1; }
        }

        protected void btnScaricaDatiImpresa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCFabilitato.Text) || txtCFabilitato.Text.Length > 16)
                    throw new Exception("La Partita iva/Codice fiscale digitata non è valida.");

                SiarLibrary.Impresa i = scaricaDatiAnagrafici(txtCFabilitato.Text);
                if (i == null) throw new Exception("L`impresa cercata non è stata trovata.");

                SiarLibrary.ImpresaAggregazioneCollection impresa_aggregazione = ImpresaAggregazioneCollectionProvider.Find(hdnIdAggregazione.Value, null, null, true, txtCFabilitato.Text);
                if (impresa_aggregazione.Count > 0) throw new Exception("Un'impresa attiva con questa partita iva/codice fiscale è già stata registrata nell'aggregazione.");

                hdnIdImpresa.Value = i.IdImpresa;
                txtRagSociale.Text = i.RagioneSociale;
                ComboAteco.SelectedValue = i.CodAteco2007;
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private SiarLibrary.Impresa scaricaDatiAnagrafici(string cuaa_impresa)
        {
            SiarLibrary.Impresa i = null;
            if (!string.IsNullOrEmpty(cuaa_impresa)) //rimosso controllo sulla lunghezza perchè in caso di p. iva estere non funzionerebbe
            {
                SiarBLL.ImpresaCollectionProvider impresa_provider = new SiarBLL.ImpresaCollectionProvider();
                i = impresa_provider.GetByCuaa(cuaa_impresa);
                //commentato per togliere la ricerca dall'anagrafe tributaria non più in uso
                //if (i == null)
                //{
                //    SianWebSrv.TraduzioneSianToSiar trad = new SianWebSrv.TraduzioneSianToSiar();
                //    trad.ScaricaDatiAzienda(cuaa_impresa.ToUpper(), null, Operatore.Utente.CfUtente);
                //    i = impresa_provider.GetByCuaa(cuaa_impresa);
                //}
                //if (i != null && (i.RagioneSociale == i.Cuaa || i.RagioneSociale == i.CodiceFiscale)) return null;
            }
            return i;
        }

        protected void btnSalvaMembro_Click(object sender, EventArgs e)
        {
            try
            {
                ImpresaAggregazioneCollectionProvider.DbProviderObj.BeginTran();
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

                int id_impresa;
                if (!int.TryParse(hdnIdImpresa.Value, out id_impresa)) throw new Exception("Impresa non trovata o partita iva/codice fiscale non valida.");

                //if (Azienda.IdImpresa == id_impresa)
                //    throw new Exception("Attenzione: non puoi inserire l'impresa principale come socio!");

                string piva = null;
                if (!string.IsNullOrEmpty(txtCFabilitato.Text))
                {
                    //Rimosso controllo sulla lunghezza perché non farebbe cercare la p. iva estera
                    //if (txtCFabilitato.Text.Length == 16) piva = txtCFabilitato.Text;
                    //else if (txtCFabilitato.Text.Length == 11) piva = txtCFabilitato.Text;
                    piva = txtCFabilitato.Text;
                }
                SiarLibrary.ImpresaAggregazione impresaAggregazione = new SiarLibrary.ImpresaAggregazione();
                SiarLibrary.ImpresaAggregazioneCollection impresa_aggregazione = ImpresaAggregazioneCollectionProvider.Find(hdnIdAggregazione.Value, null, null, true, piva);

                bool isEditCapofila = false;
                if (impresa_aggregazione.Count > 0)
                {
                    impresaAggregazione = impresa_aggregazione[0];
                    if (impresaAggregazione.CodRuolo == "C")
                        isEditCapofila = true;
                }

                impresaAggregazione.Attivo = true;

                if (!isEditCapofila)
                {
                    if (ImpresaAggregazioneCollectionProvider.Find(hdnIdAggregazione.Value, "C", null, true, null).Count > 0 && cmbTipoImpresaAggregazione.SelectedValue == "C")
                        throw new Exception("Esiste già un'impresa Capofila per questa aggregazione");

                }
                else if (cmbTipoImpresaAggregazione.SelectedValue != "C")
                    throw new Exception("Non è possibile cambiare ruolo all'impresa capofila");


                impresaAggregazione.CodRuolo = cmbTipoImpresaAggregazione.SelectedValue;
                impresaAggregazione.DataInizio = txtDataInizioPartnership.Text;

                if (DateTime.Parse(txtDataInizioPartnership.Text) < DateTime.Parse(txtDataInizio.Text)) throw new Exception("La data di inizio deve essere maggiore della data di inizio dell'aggregazione");

                if (!string.IsNullOrEmpty(txtDataFine.Text))
                {
                    if (DateTime.Parse(txtDataInizioPartnership.Text) > DateTime.Parse(txtDataFine.Text)) throw new Exception("La data di inizio deve essere minore della data di fine dell'aggregazione");
                }

                if (!string.IsNullOrEmpty(txtDataFinePartnership.Text))
                {
                    if (!string.IsNullOrEmpty(txtDataFine.Text))
                    {
                        if (DateTime.Parse(txtDataFinePartnership.Text) > DateTime.Parse(txtDataFine.Text)) throw new Exception("Data di inizio e fine devono rientrare all'interno del periodo definito per l'aggregazione");
                    }
                    if (DateTime.Parse(txtDataFinePartnership.Text) < DateTime.Parse(txtDataInizio.Text)) throw new Exception("Data di inizio e fine devono rientrare all'interno del periodo definito per l'aggregazione");
                    if (DateTime.Parse(txtDataInizioPartnership.Text) >= DateTime.Parse(txtDataFinePartnership.Text)) throw new Exception("Date di inizio e fine non valide");

                    impresaAggregazione.DataFine = txtDataFinePartnership.Text;
                }
                if(ComboAteco.SelectedValue == null || ComboAteco.SelectedValue =="")
                    throw new Exception("Inserire il codice Ateco dell'impresa dell'aggregazione");

                impresaAggregazione.IdImpresa = id_impresa;
                impresaAggregazione.IdAggregazione = hdnIdAggregazione.Value;
                impresaAggregazione.OperatoreInizio = Operatore.Utente.IdUtente;

                SiarLibrary.Impresa imp = new SiarBLL.ImpresaCollectionProvider().GetById(id_impresa);
                SiarBLL.ImpresaStoricoCollectionProvider storico_impresa_coll = new SiarBLL.ImpresaStoricoCollectionProvider();
                SiarLibrary.ImpresaStorico imp_sto = storico_impresa_coll.GetById(imp.IdStoricoUltimo);
                imp_sto.CodAteco2007 = ComboAteco.SelectedValue;
                storico_impresa_coll.Save(imp_sto);
                ImpresaAggregazioneCollectionProvider.Save(impresaAggregazione);

                ImpresaAggregazioneCollectionProvider.DbProviderObj.Commit();

                ShowMessage("Imprese aggiunta correttamente all'aggregazione.");

                clearFormMembro();

            }
            catch (Exception ex) { ShowError(ex); ImpresaAggregazioneCollectionProvider.DbProviderObj.Rollback(); }
        }

        public void clearFormMembro()
        {
            hdnIdImpresaAggregazione.Value = string.Empty;
            txtCFabilitato.Text = string.Empty;
            txtRagSociale.Text = string.Empty;
            txtDataInizioPartnership.Text = string.Empty;
            txtDataFinePartnership.Text = string.Empty;
            cmbTipoImpresaAggregazione.SelectedIndex = -1;
        }

        protected void btnEliminaSocio_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                //
                if (!int.TryParse(hdnIdImpresaAggregazione.Value, out id_impresa_aggregazione)) throw new Exception("Nessuna impresa selezionata. Impossibile Continuare.");
                SiarLibrary.ImpresaAggregazione impresa = ImpresaAggregazioneCollectionProvider.GetById(id_impresa_aggregazione);
                // 
                if (impresa.CodRuolo == "C") throw new Exception("Non è possibile disattivare l'impresa capofila");
                impresa.Attivo = false;
                impresa.OperatoreFine = Operatore.Utente.IdUtente;
                impresa.DataFine = DateTime.Now;
                ImpresaAggregazioneCollectionProvider.Save(impresa);

            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}
