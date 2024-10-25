using System;
using System.Web.UI.WebControls;

namespace web.Private.Psr.Bandi
{
    public partial class BandoSettoriProduttiviPriorita : SiarLibrary.Web.BandoPage
    {

        SiarBLL.BandoXSettoreProduttivoCollectionProvider bando_settori_provider;
        SiarBLL.SettoriProduttiviCollectionProvider settori_provider;
        SiarLibrary.BandoXSettoreProduttivoCollection settori_bando;
        SiarBLL.BandoAteco2007CollectionProvider ateco_provider;
        SiarBLL.BandoComuniLocalizzazioniCollectionProvider comuni_provider;

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "riepilogo_bando";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            settori_provider = new SiarBLL.SettoriProduttiviCollectionProvider(BandoProvider.DbProviderObj);
            bando_settori_provider = new SiarBLL.BandoXSettoreProduttivoCollectionProvider(BandoProvider.DbProviderObj);
            ateco_provider = new SiarBLL.BandoAteco2007CollectionProvider(BandoProvider.DbProviderObj);
            comuni_provider = new SiarBLL.BandoComuniLocalizzazioniCollectionProvider(BandoProvider.DbProviderObj);
            AbilitaModifica = AbilitaModifica && TipoModifica == 2;
        }

        protected override void OnPreRender(EventArgs e)
        {
            SiarLibrary.BandoXSettoreProduttivoCollection prioritaBando = new SiarLibrary.BandoXSettoreProduttivoCollection();
            string Sezione = null, Ateco = null, Prov = null, Denominazione = null;
            // carico tutto
            settori_bando = bando_settori_provider.Find(Bando.IdBando, null, null);
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    tbSettoriProduttivi.Visible = false;
                    tbCodiciAteco.Visible = false;
                    tbComuniLocaliz.Visible = false;
                    lstSettoreProduttivo.IdBando = Bando.IdBando;
                    lstSettoreProduttivo.DataBind();

                    SiarLibrary.BandoXSettoreProduttivoCollection bpriorita = new SiarLibrary.BandoXSettoreProduttivoCollection();
                    foreach (SiarLibrary.BandoXSettoreProduttivo bs in settori_bando)
                        if (bs.IdPrioritaSettoriale != null) bpriorita.Add(bs);

                    dgPrioritaSettoriali.Titolo = "Elementi trovati: " + bpriorita.Count;
                    dgPrioritaSettoriali.DataSource = bpriorita;
                    ((SiarLibrary.Web.JsButtonColumn)dgPrioritaSettoriali.Columns[3]).AbilitaModifica = AbilitaModifica;
                    dgPrioritaSettoriali.DataBind();

                    break;
                case 3:
                    tbSettoriProduttivi.Visible = false;
                    tbPrioritaSettoriali.Visible = false;
                    tbComuniLocaliz.Visible = false;
                    Sezione = txtSezione.Text;
                    Ateco = txtAteco.Text;
                    SiarLibrary.BandoAteco2007Collection ateco_coll = ateco_provider.GetBandoAteco(Bando.IdBando, Sezione, chkGruppo.Checked, chkClasse.Checked, chkCategoria.Checked, chkSottocategoria.Checked, Ateco);
                    dgBandoAteco.DataSource = ateco_coll;
                    SiarLibrary.BandoAteco2007Collection bando_ateco_coll = ateco_provider.Find(Bando.IdBando, null);
                    if (bando_ateco_coll.Count == 0)
                        dgBandoAteco.Titolo = "Nessun codice Ateco selezionato";
                    else
                        dgBandoAteco.Titolo = "Codici Ateco selezionati: " + bando_ateco_coll.Count.ToString();
                    dgBandoAteco.ItemDataBound += new DataGridItemEventHandler(dgBandoAteco_ItemDataBound);
                    dgBandoAteco.DataBind();
                    break;
                case 4:
                    tbSettoriProduttivi.Visible = false;
                    tbPrioritaSettoriali.Visible = false;
                    tbCodiciAteco.Visible = false;
                    lstProvincia.DataBind();
                    Prov = lstProvincia.SelectedValue;
                    Denominazione = txtDenominazione.Text;
                    SiarLibrary.BandoComuniLocalizzazioniCollection comuni_coll = comuni_provider.GetBandoComuniLocalizzazione(Bando.IdBando, chkCratere.Checked, Prov, Denominazione);
                    dgComuniLocaliz.DataSource = comuni_coll;
                    SiarLibrary.BandoComuniLocalizzazioniCollection bando_comuni_coll = comuni_provider.Find(Bando.IdBando, null);
                    if (bando_comuni_coll.Count == 0)
                        dgComuniLocaliz.Titolo = "Nessun comune selezionato";
                    else
                        dgComuniLocaliz.Titolo = "Comuni selezionati: " + bando_comuni_coll.Count.ToString();
                    dgComuniLocaliz.ItemDataBound += new DataGridItemEventHandler(dgComuniLocaliz_ItemDataBound);
                    dgComuniLocaliz.DataBind();
                    break;
                default:
                    tbPrioritaSettoriali.Visible = false;
                    tbCodiciAteco.Visible = false;
                    tbComuniLocaliz.Visible = false;
                    txtDescrizioneSettore.AddJSAttribute("onkeydown", "SNCVolatileZoom(this,event,'SNCVZCercaSettoriProduttivi');");
                    SiarLibrary.BandoXSettoreProduttivoCollection bsettori = new SiarLibrary.BandoXSettoreProduttivoCollection();
                    foreach (SiarLibrary.BandoXSettoreProduttivo bs in settori_bando)
                        if (bs.IdPrioritaSettoriale == null) bsettori.Add(bs);

                    dgSettoriProduttivi.Titolo = "Elementi trovati: " + bsettori.Count;
                    dgSettoriProduttivi.DataSource = bsettori;
                    ((SiarLibrary.Web.JsButtonColumn)dgSettoriProduttivi.Columns[2]).AbilitaModifica = AbilitaModifica;
                    dgSettoriProduttivi.DataBind();
                    break;
            }
            base.OnPreRender(e);
        }

        void dgBandoAteco_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataGridItem dgi = (DataGridItem)e.Item;
                SiarLibrary.BandoAteco2007 bando_ateco = (SiarLibrary.BandoAteco2007)dgi.DataItem;
                if (bando_ateco.IdBando!= null)
                {
                    dgi.Cells[9].Text = dgi.Cells[9].Text.Replace("<input", "<input checked");
                }
                else
                    dgi.Cells[9].Text = dgi.Cells[9].Text.Replace("checked", "");
            }
        }

        void dgComuniLocaliz_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataGridItem dgi = (DataGridItem)e.Item;
                SiarLibrary.BandoComuniLocalizzazioni bando_comune = (SiarLibrary.BandoComuniLocalizzazioni)dgi.DataItem;
                if (bando_comune.IdBando != null)
                {
                    dgi.Cells[5].Text = dgi.Cells[5].Text.Replace("<input", "<input checked");
                }
                else
                    dgi.Cells[5].Text = dgi.Cells[5].Text.Replace("checked", "");
            }
        }

        protected void btnFiltra_Click(object sender, EventArgs e)
        {
            try
            {
                dgBandoAteco.CurrentPageIndex = 0;
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnFiltraComuni_Click(object sender, EventArgs e)
        {
            try
            {
                dgComuniLocaliz.CurrentPageIndex = 0;
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        public void btnSalvaAteco_Click(object sender, EventArgs e)
        {
            if(Bando.IdBando == null)
                throw new Exception("Errore nella selezione del bando. Impossibile continuare");
            string[] selezionate = ((SiarLibrary.Web.CheckColumn)dgBandoAteco.Columns[9]).GetSelected();
            SiarBLL.BandoAteco2007CollectionProvider ateco_del_provider = new SiarBLL.BandoAteco2007CollectionProvider();
            ateco_del_provider.DbProviderObj.BeginTran();
            try
            {
                ateco_del_provider.DeleteCollection(ateco_del_provider.Find(Bando.IdBando, null));
                foreach (string s in selezionate)
                {
                    SiarLibrary.BandoAteco2007 ba = new SiarLibrary.BandoAteco2007();
                    ba.IdBando = Bando.IdBando;
                    ba.IdAteco2007 = s;
                    ateco_del_provider.Save(ba);
                }
                ateco_del_provider.DbProviderObj.Commit();
                ShowMessage("Codici ateco salvati correttamente.");
                //txtSezione.Text = null; txtAteco.Text = null;
                dgBandoAteco.CurrentPageIndex = 0;
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }
        public void btnSalvaComuni_Click(object sender, EventArgs e)
        {
            if (Bando.IdBando == null)
                throw new Exception("Errore nella selezione del bando. Impossibile continuare");
            string[] selezionate = ((SiarLibrary.Web.CheckColumn)dgComuniLocaliz.Columns[5]).GetSelected();
            SiarBLL.BandoComuniLocalizzazioniCollectionProvider comuni_del_provider = new SiarBLL.BandoComuniLocalizzazioniCollectionProvider();
            comuni_del_provider.DbProviderObj.BeginTran();
            try
            {
                comuni_del_provider.DeleteCollection(comuni_del_provider.Find(Bando.IdBando, null));
                foreach (string s in selezionate)
                {
                    SiarLibrary.BandoComuniLocalizzazioni ba = new SiarLibrary.BandoComuniLocalizzazioni();
                    ba.IdBando = Bando.IdBando;
                    ba.IdComune = s;
                    ba.EffettoSuContributo = 0;
                    ba.IsAttivo = true;
                    comuni_del_provider.Save(ba);
                }
                comuni_del_provider.DbProviderObj.Commit();
                ShowMessage("Comuni salvati correttamente.");
                //txtSezione.Text = null; txtAteco.Text = null;
                dgComuniLocaliz.CurrentPageIndex = 0;
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnSalvaSettori_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (string.IsNullOrEmpty(txtDescrizioneSettore.Text))
                    throw new Exception("Per proseguire è necessario specificare il settore produttivo desiderato.");
                SiarLibrary.SettoriProduttivi settore_selezionato = null;
                int id_settore_produttivo;
                if (int.TryParse(hdnIdSettoreProduttivo.Text, out id_settore_produttivo))
                    settore_selezionato = settori_provider.GetById(id_settore_produttivo);
                if (settore_selezionato == null)
                {
                    SiarLibrary.SettoriProduttiviCollection settori_esistenti = settori_provider.Find(null, txtDescrizioneSettore.Text);
                    //se gia' esistente lo recupero
                    if (settori_esistenti.Count > 0) settore_selezionato = settori_esistenti[0];
                    else
                    {
                        //altrimenti nuovo
                        settore_selezionato = new SiarLibrary.SettoriProduttivi();
                        settore_selezionato.Descrizione = txtDescrizioneSettore.Text;
                        settori_provider.Save(settore_selezionato);
                    }
                }
                if (settore_selezionato == null) throw new Exception("Per proseguire è necessario specificare il settore produttivo desiderato.");
                if (bando_settori_provider.Find(Bando.IdBando, settore_selezionato.IdSettoreProduttivo, null).Count > 0)
                    throw new Exception("Il settore produttivo selezionato è già stato associato al bando.");

                BandoProvider.DbProviderObj.BeginTran();

                SiarLibrary.BandoXSettoreProduttivo bxs = new SiarLibrary.BandoXSettoreProduttivo();
                bxs.IdSettoreProduttivo = settore_selezionato.IdSettoreProduttivo;
                bxs.IdBando = Bando.IdBando;
                bando_settori_provider.Save(bxs);
                AggiornaLogModifica(null);
                BandoProvider.DbProviderObj.Commit();
                ShowMessage("Settore produttivo salvato correttamente.");
                txtDescrizioneSettore.Text = "";
                hdnIdSettoreProduttivo.Text = "";
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnEliminaSettoreProduttivo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                int id_settore_produttivo;
                if (!int.TryParse(hdnIdSettoreProduttivo.Text, out id_settore_produttivo))
                    throw new Exception("Il settore produttivo selezionato non è valido.");

                BandoProvider.DbProviderObj.BeginTran();
                SiarLibrary.BandoXSettoreProduttivoCollection bsettori = bando_settori_provider.Find(Bando.IdBando, id_settore_produttivo, null);
                if (bsettori.Count == 0) throw new Exception("Il settore produttivo selezionato non è valido.");
                bando_settori_provider.DeleteCollection(bsettori);
                AggiornaLogModifica(null);
                BandoProvider.DbProviderObj.Commit();
                ShowMessage("Settore produttivo eliminato correttamente.");
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnSalvaPriorita_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (string.IsNullOrEmpty(txtDescrizionePriorita.Text)) throw new Exception("Specificare la descrizione della priorità.");
                int id_settore_produttivo;
                if (int.TryParse(lstSettoreProduttivo.SelectedValue, out id_settore_produttivo))
                {
                    if (bando_settori_provider.Find(Bando.IdBando, id_settore_produttivo, null).Count == 0)
                        throw new Exception("Il settore produttivo selezionato non è valido.");
                }
                //controllo che la descrizione della priorita non sia gia' presente
                SiarBLL.PrioritaSettorialiCollectionProvider priorita_provider = new SiarBLL.PrioritaSettorialiCollectionProvider(BandoProvider.DbProviderObj);
                SiarLibrary.PrioritaSettorialiCollection ps_cc = priorita_provider.Find(null, "%" + txtDescrizionePriorita.Text + "%");

                BandoProvider.DbProviderObj.BeginTran();
                int id_priorita;
                SiarLibrary.PrioritaSettorialiCollection priorita_presenti = priorita_provider.Find(null, txtDescrizionePriorita.Text + "%");
                if (priorita_presenti.Count > 0)
                {
                    id_priorita = priorita_presenti[0].IdPrioritaSettoriale;
                    if (bando_settori_provider.Find(Bando.IdBando, null, id_priorita).Count > 0)
                        throw new Exception("La priorità specificata è gia' stata associata al presente bando.");
                }
                else
                {
                    SiarLibrary.PrioritaSettoriali p = new SiarLibrary.PrioritaSettoriali();
                    p.Descrizione = txtDescrizionePriorita.Text;
                    priorita_provider.Save(p);
                    id_priorita = p.IdPrioritaSettoriale;
                }

                SiarLibrary.BandoXSettoreProduttivo bxs = new SiarLibrary.BandoXSettoreProduttivo();
                if (id_settore_produttivo > 0) bxs.IdSettoreProduttivo = id_settore_produttivo;
                bxs.IdBando = Bando.IdBando;
                bxs.IdPrioritaSettoriale = id_priorita;
                bando_settori_provider.Save(bxs);
                AggiornaLogModifica(null);
                BandoProvider.DbProviderObj.Commit();
                ShowMessage("Priorita settoriale salvata correttamente.");
                txtDescrizionePriorita.Text = "";
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnEliminaPrioritaSettoriale_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                SiarLibrary.BandoXSettoreProduttivo priorita_selezionata = null;
                int id_bxs;
                if (int.TryParse(hdnIdBandoSettoreProduttivo.Text, out id_bxs))
                    priorita_selezionata = bando_settori_provider.GetById(id_bxs);
                if (priorita_selezionata == null) throw new Exception("La priorità selezionata non è valida.");

                BandoProvider.DbProviderObj.BeginTran();
                bando_settori_provider.Delete(priorita_selezionata);
                AggiornaLogModifica(null);
                BandoProvider.DbProviderObj.Commit();
                ShowMessage("Priorità settoriale eliminata correttamente.");
                hdnIdBandoSettoreProduttivo.Text = null;
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }
    }
}