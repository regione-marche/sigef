using System;
using System.Web.UI.WebControls;

namespace web.Private.admin
{
    public partial class Profilo : SiarLibrary.Web.PrivatePage
    {
        SiarBLL.ProfiliCollectionProvider profili_provider = new SiarBLL.ProfiliCollectionProvider();
        SiarBLL.ProfiloXFunzioniCollectionProvider pxfprovider;
        SiarLibrary.Profili profilo_selezionato, profilo_da_caricare;

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "Profili";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            pxfprovider = new SiarBLL.ProfiloXFunzioniCollectionProvider(profili_provider.DbProviderObj);
        }

        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 1:
                    tbDettaglio.Visible = false;
                    ucSiarNewTab.Width = tbProfili.Width;
                    dgProfili.DataSource = profili_provider.Find(null, null, null, null, null);
                    dgProfili.DataBind();
                    break;
                case 2:
                    tbProfili.Visible = false;
                    ucSiarNewTab.Width = tbDettaglio.Width;
                    lstProfili.DataBind();
                    lstTipoEnte.DataBind();

                    int id_profilo;
                    if (profilo_selezionato == null && int.TryParse(hdnIdProfilo.Value, out id_profilo))
                        profilo_selezionato = profili_provider.GetById(id_profilo);
                    if (profilo_selezionato != null) //pulisciDettaglio();
                    {
                        lstTipoEnte.SelectedValue = profilo_selezionato.CodTipoEnte;
                        txtDescrizione.Text = profilo_selezionato.Descrizione;
                        txtOrdine.Text = profilo_selezionato.Ordine;
                    }

                    int id_profilo_da_caricare = (profilo_da_caricare != null ? profilo_da_caricare.IdProfilo.Value : (profilo_selezionato != null ?
                        profilo_selezionato.IdProfilo.Value : 0));
                    if (id_profilo_da_caricare > 0)
                    {
                        SiarLibrary.ProfiloXFunzioniCollection pxfcollection = pxfprovider.Find(id_profilo_da_caricare, null, null, null, null, null, null, null);
                        string[] selezionati = new string[pxfcollection.Count];
                        string[] permodifica = new string[pxfcollection.Count];
                        for (int i = 0; i < pxfcollection.Count; i++)
                        {
                            selezionati[i] = pxfcollection[i].CodFunzione;
                            if (pxfcollection[i].Modifica) permodifica[i] = pxfcollection[i].CodFunzione;
                        }
                        ((SiarLibrary.Web.CheckColumn)dgFunzionalita.Columns[4]).SetSelected(selezionati);
                        ((SiarLibrary.Web.CheckColumn)dgFunzionalita.Columns[3]).SetSelected(permodifica);
                    }
                    SiarLibrary.FunzionalitaCollection funzionalita_raw = new SiarBLL.FunzionalitaCollectionProvider().Find(null, null, null, null, null, null),
                            funzionalita_sorted = new SiarLibrary.FunzionalitaCollection();
                    funzionalita_raw.Sort("Ordine,Livello");
                    foreach (SiarLibrary.Funzionalita f in funzionalita_raw.SubSelect(null, null, null, null, 0, null, null, null))
                    {
                        funzionalita_sorted.Add(f);
                        ordinaFunzionalita(ref funzionalita_sorted, ref funzionalita_raw, f.CodFunzione);
                    }
                    dgFunzionalita.DataSource = funzionalita_sorted;
                    dgFunzionalita.ItemDataBound += new DataGridItemEventHandler(dgFunzionalita_ItemDataBound);
                    dgFunzionalita.DataBind();
                    break;
            }
            base.OnPreRender(e);
        }

        private void pulisciDettaglio()
        {
            profilo_selezionato = null;
            hdnIdProfilo.Value = null;
            lstTipoEnte.ClearSelection();
            txtDescrizione.Text = null;
            txtOrdine.Text = null;
            ((SiarLibrary.Web.CheckColumn)dgFunzionalita.Columns[4]).ClearSelected();
            ((SiarLibrary.Web.CheckColumn)dgFunzionalita.Columns[3]).ClearSelected();
        }

        void dgFunzionalita_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                SiarLibrary.Funzionalita func = (SiarLibrary.Funzionalita)e.Item.DataItem;
                //e.Item.BackColor = System.Drawing.ColorTranslator.FromHtml("#ede2c3");
                string testo_cella = e.Item.Cells[1].Text;
                switch (func.Livello.Value)
                {
                    case 0:
                        testo_cella = testo_cella.ToUpper();
                        break;
                    case 1:
                        e.Item.Cells[1].Style.Add("padding-left", "15px");
                        testo_cella = func.Ordine + ". " + testo_cella.ToUpper();
                        break;
                    case 2:
                        e.Item.Cells[1].Style.Add("padding-left", "30px");
                        testo_cella = func.Ordine + ". " + testo_cella;
                        break;
                    case 3:
                        e.Item.Cells[1].Style.Add("padding-left", "45px");
                        //e.Item.BackColor = System.Drawing.ColorTranslator.FromHtml("#fff0d2");
                        testo_cella = func.Ordine + ". " + testo_cella;
                        break;
                }
                e.Item.Cells[1].Text = testo_cella;
            }
        }

        private void ordinaFunzionalita(ref SiarLibrary.FunzionalitaCollection f_sorted, ref SiarLibrary.FunzionalitaCollection f_raw,
            SiarLibrary.NullTypes.IntNT padre)
        {
            foreach (SiarLibrary.Funzionalita f in f_raw.SubSelect(null, null, null, null, null, padre, null, null))
            {
                f_sorted.Add(f);
                ordinaFunzionalita(ref f_sorted, ref f_raw, f.CodFunzione);
            }
        }

        protected void btnSalva_Click(object sender, System.EventArgs e)
        {
            try
            {
                int id_profilo;
                if (int.TryParse(hdnIdProfilo.Value, out id_profilo)) profilo_selezionato = profili_provider.GetById(id_profilo);

                profili_provider.DbProviderObj.BeginTran();

                if (profilo_selezionato == null) profilo_selezionato = new SiarLibrary.Profili();
                profilo_selezionato.Descrizione = txtDescrizione.Text;
                profilo_selezionato.Ordine = txtOrdine.Text;
                profilo_selezionato.CodTipoEnte = lstTipoEnte.SelectedValue;
                profili_provider.Save(profilo_selezionato);

                //profiloxfunzioni
                pxfprovider.DeleteCollection(pxfprovider.Find(profilo_selezionato.IdProfilo, null, null, null, null, null, null, null));

                string[] selezionati = ((SiarLibrary.Web.CheckColumn)dgFunzionalita.Columns[4]).GetSelected();
                string[] inmodifica = ((SiarLibrary.Web.CheckColumn)dgFunzionalita.Columns[3]).GetSelected();
                foreach (string s in selezionati)
                {
                    SiarLibrary.ProfiloXFunzioni pxf = new SiarLibrary.ProfiloXFunzioni();
                    pxf.IdProfilo = profilo_selezionato.IdProfilo;
                    pxf.CodFunzione = s;
                    pxf.Modifica = false;
                    foreach (string mod in inmodifica)
                    {
                        if (s == mod)
                        {
                            pxf.Modifica = true;
                            break;
                        }
                    }
                    pxfprovider.Save(pxf);
                }
                profili_provider.DbProviderObj.Commit();
                hdnIdProfilo.Value = profilo_selezionato.IdProfilo;
                lstProfili.ClearSelection();
                ShowMessage("Profilo salvato correttamente.");
            }
            catch (Exception ex) { profili_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnSelezionaProfilo_Click(object sender, EventArgs e)
        {
            try
            {
                int id_profilo;
                if (int.TryParse(hdnIdProfilo.Value, out id_profilo)) profilo_selezionato = profili_provider.GetById(id_profilo);
                if (profilo_selezionato == null) throw new Exception("Il profilo selezionato non è valido.");
                ucSiarNewTab.TabSelected = 2;
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnCaricaProfilo_Click(object sender, EventArgs e)
        {
            try
            {
                int id_profilo;
                if (int.TryParse(lstProfili.SelectedValue, out id_profilo)) profilo_da_caricare = profili_provider.GetById(id_profilo);
                if (profilo_da_caricare == null) throw new Exception("Il profilo selezionato non è valido.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                int id_profilo;
                if (int.TryParse(hdnIdProfilo.Value, out id_profilo)) profilo_selezionato = profili_provider.GetById(id_profilo);
                if (profilo_selezionato == null) throw new Exception("Il profilo selezionato non è valido.");
                if (new SiarBLL.UtentiCollectionProvider().Find(null, null, null, null, profilo_selezionato.IdProfilo, null, null).Count > 0)
                    throw new Exception("Esistono utenti registrati con il profilo selezionato. impossibile continuare.");
                profili_provider.DbProviderObj.BeginTran();
                pxfprovider.DeleteCollection(pxfprovider.Find(profilo_selezionato.IdProfilo, null, null, null, null, null, null, null));
                profili_provider.Delete(profilo_selezionato);
                profili_provider.DbProviderObj.Commit();
                ShowMessage("Profilo eliminato correttamente.");
                pulisciDettaglio();
            }
            catch (Exception ex) { profili_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }
    }
}
