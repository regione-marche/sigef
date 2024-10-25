using System;
using System.Web.UI.WebControls;

namespace web.Private.admin
{
    /// <summary>
    /// Summary description for Funzionalita.
    /// </summary>
    public partial class Funzionalita : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "Funzionalità";
            base.OnPreInit(e);
        }

        SiarBLL.FunzionalitaCollectionProvider funzionalita_provider = new SiarBLL.FunzionalitaCollectionProvider();

        protected void Page_Load(object sender, System.EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    tbElenco.Visible = false;
                    lstFPadre.DataBind();
                    int cod_funzione;
                    SiarLibrary.Funzionalita funzionalita_selezionata = null;
                    if (int.TryParse(hdnIdFunzionalita.Value, out cod_funzione))
                        funzionalita_selezionata = funzionalita_provider.GetById(cod_funzione);
                    if (funzionalita_selezionata != null)
                    {
                        txtDescrizione.Text = funzionalita_selezionata.Descrizione;
                        txtDescMenu.Text = funzionalita_selezionata.DescMenu;
                        lstFPadre.SelectedValue = funzionalita_selezionata.Padre;
                        txtLink.Text = funzionalita_selezionata.Link;
                        txtOrdine.Text = funzionalita_selezionata.Ordine;
                        txtLivello.Text = funzionalita_selezionata.Livello;
                        chkMenu.Checked = funzionalita_selezionata.FlagMenu;

                        SiarLibrary.ProfiloXFunzioniCollection profili_funzionalita = new SiarBLL.ProfiloXFunzioniCollectionProvider().Find(null,
                                funzionalita_selezionata.CodFunzione, null, null, null, null, null, null);
                        System.Collections.ArrayList pf_selez = new System.Collections.ArrayList(), pf_modif = new System.Collections.ArrayList();
                        foreach (SiarLibrary.ProfiloXFunzioni pf in profili_funzionalita)
                        {
                            pf_selez.Add(pf.IdProfilo);
                            if (pf.Modifica) pf_modif.Add(pf.IdProfilo);
                        }
                        SiarLibrary.ProfiliCollection profili = new SiarBLL.ProfiliCollectionProvider().Find(null, null, null, null, null);
                        dgProfili.DataSource = profili;
                        dgProfili.ItemDataBound += new DataGridItemEventHandler(dgProfili_ItemDataBound);
                        ((SiarLibrary.Web.CheckColumn)dgProfili.Columns[3]).SetSelected(pf_modif);
                        ((SiarLibrary.Web.CheckColumn)dgProfili.Columns[4]).SetSelected(pf_selez);
                        dgProfili.DataBind();
                    }
                    else
                    {
                        tbProfili.Visible = false;
                        txtDescrizione.Text = "";
                        txtDescMenu.Text = "";
                        lstFPadre.SelectedValue = "";
                        txtLink.Text = "";
                        txtOrdine.Text = "";
                        txtLivello.Text = "";
                        chkMenu.Checked = false;
                    }
                    break;
                default:
                    tbDettaglio.Visible = false;
                    hdnIdFunzionalita.Value = null;
                    SiarLibrary.FunzionalitaCollection funzionalita_raw = funzionalita_provider.Find(null, null, null, null, null, null),
                        funzionalita_sorted = new SiarLibrary.FunzionalitaCollection();
                    funzionalita_raw.Sort("Ordine,Padre,Livello");
                    foreach (SiarLibrary.Funzionalita f in funzionalita_raw.SubSelect(null, null, null, null, 0, null, null, null))
                    {
                        funzionalita_sorted.Add(f);
                        ordinaFunzionalita(ref funzionalita_sorted, ref funzionalita_raw, f.CodFunzione);
                    }
                    dg.DataSource = funzionalita_sorted;
                    dg.ItemDataBound += new DataGridItemEventHandler(dg_ItemDataBound);
                    dg.DataBind();
                    break;
            }
            base.OnPreRender(e);
        }

        void dgProfili_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[3].Text="<input type='checkbox' onclick=\"selezionaCheckBoxes('chkModificaPXF',this);\" />sel.tutti";
                e.Item.Cells[4].Text="<input type='checkbox' onclick=\"selezionaCheckBoxes('chkSelezionaPXF',this);\" />sel.tutti";
            }
        }

        void dg_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                SiarLibrary.Funzionalita func = (SiarLibrary.Funzionalita)e.Item.DataItem;
                switch (func.Livello.Value)
                {
                    case 0:
                        e.Item.Cells[1].Text = e.Item.Cells[1].Text.ToUpper();
                        break;
                    case 1:
                        e.Item.Cells[1].Style.Add("padding-left", "15px");
                        e.Item.Cells[1].Text = func.Ordine.ToString() + ". " + e.Item.Cells[1].Text.ToUpper();
                        break;
                    case 2:
                        e.Item.Cells[1].Style.Add("padding-left", "30px");
                        e.Item.Cells[1].Text = func.Ordine.ToString() + ". " + e.Item.Cells[1].Text;
                        break;
                    case 3:
                        e.Item.Cells[1].Style.Add("padding-left", "45px");
                        //e.Item.BackColor = System.Drawing.Color.FromArgb(255, 240, 210);
                        e.Item.Cells[1].Text = func.Ordine.ToString() + ". " + e.Item.Cells[1].Text;
                        break;
                }
                e.Item.Cells[4].Text = "<input type=button class=ButtonGrid value='Seleziona' onclick=\"selezionaFunzionalita('" + func.CodFunzione + "');\" />";
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
                int cod_funzione;
                SiarLibrary.Funzionalita funzionalita_selezionata = null;
                if (int.TryParse(hdnIdFunzionalita.Value, out cod_funzione))
                    funzionalita_selezionata = funzionalita_provider.GetById(cod_funzione);
                if (funzionalita_selezionata == null) funzionalita_selezionata = new SiarLibrary.Funzionalita();

                funzionalita_selezionata.Padre = string.IsNullOrEmpty(lstFPadre.SelectedValue) ? "-1" : lstFPadre.SelectedValue;
                funzionalita_selezionata.DescMenu = txtDescMenu.Text;
                funzionalita_selezionata.Descrizione = txtDescrizione.Text;
                funzionalita_selezionata.Ordine = txtOrdine.Text;
                funzionalita_selezionata.Livello = txtLivello.Text;
                funzionalita_selezionata.Link = txtLink.Text + " ";
                funzionalita_selezionata.FlagMenu = chkMenu.Checked;
                funzionalita_provider.Save(funzionalita_selezionata);
                hdnIdFunzionalita.Value = funzionalita_selezionata.CodFunzione;
                ShowMessage("Salvataggio completato");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            ucSiarNewTab.TabSelected = 2;
        }

        protected void btnSalvaProfili_Click(object sender, EventArgs e)
        {
            try
            {
                int cod_funzione;
                SiarLibrary.Funzionalita funzionalita_selezionata = null;
                if (int.TryParse(hdnIdFunzionalita.Value, out cod_funzione))
                    funzionalita_selezionata = funzionalita_provider.GetById(cod_funzione);
                if (funzionalita_selezionata == null) throw new Exception("Per proseguire è necessario selezionare la funzionalità desiderata.");
                SiarBLL.ProfiloXFunzioniCollectionProvider pxf_provider = new SiarBLL.ProfiloXFunzioniCollectionProvider();
                pxf_provider.DeleteCollection(pxf_provider.Find(null, funzionalita_selezionata.CodFunzione, null, null, null, null, null, null));

                foreach (string s in ((SiarLibrary.Web.CheckColumn)dgProfili.Columns[4]).GetSelected())
                {
                    SiarLibrary.ProfiloXFunzioni pf = new SiarLibrary.ProfiloXFunzioni();
                    pf.CodFunzione = funzionalita_selezionata.CodFunzione;
                    pf.IdProfilo = s;
                    bool modifica = false;
                    foreach (string m in ((SiarLibrary.Web.CheckColumn)dgProfili.Columns[3]).GetSelected())
                        if (m == s)
                        {
                            modifica = true;
                            break;
                        }
                    pf.Modifica = modifica;
                    pxf_provider.Save(pf);
                }
                ShowMessage("Salvataggio completato");
            }
            catch (Exception ex) { ShowError(ex); }

        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                int cod_funzione;
                SiarLibrary.Funzionalita funzionalita_selezionata = null;
                if (int.TryParse(hdnIdFunzionalita.Value, out cod_funzione))
                    funzionalita_selezionata = funzionalita_provider.GetById(cod_funzione);
                if (funzionalita_selezionata == null) throw new Exception("Per proseguire è necessario selezionare la funzionalità desiderata.");

                funzionalita_provider.DbProviderObj.BeginTran();
                SiarBLL.ProfiloXFunzioniCollectionProvider pxf_provider = new SiarBLL.ProfiloXFunzioniCollectionProvider(funzionalita_provider.DbProviderObj);
                pxf_provider.DeleteCollection(pxf_provider.Find(null, funzionalita_selezionata.CodFunzione, null, null, null, null, null, null));
                funzionalita_provider.Delete(funzionalita_selezionata);
                funzionalita_provider.DbProviderObj.Commit();
                ShowMessage("Funzionalità eliminata correttamente.");
            }
            catch (Exception ex) { funzionalita_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }
    }
}
