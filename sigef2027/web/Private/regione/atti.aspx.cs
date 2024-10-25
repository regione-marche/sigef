using System;
using System.Web.UI.WebControls;

namespace web.Private.regione
{
    public partial class Atti : SiarLibrary.Web.PrivatePage
    {
        SiarBLL.AttiCollectionProvider atti_provider = new SiarBLL.AttiCollectionProvider();
        SiarLibrary.Atti atto_selezionato;
        bool cerca_su_attiweb = false;

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "Atti";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            int id_atto;
            if (int.TryParse(hdnIdAtto.Value, out id_atto)) atto_selezionato = atti_provider.GetById(id_atto);

        }
        protected override void OnPreRender(EventArgs e)
        {
            lstDefAtto.DataBind();
            lstOrgIstituzionale.DataBind();
            lstTipoAtto.DataBind();

            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    tbRicerca.Visible = false;
                    btnSalva.Enabled = AbilitaModifica && atto_selezionato != null;
                    if (atto_selezionato != null)
                    {
                        txtNumeroAtto.Text = atto_selezionato.Numero;
                        txtdataAtto.Text = atto_selezionato.Data;
                        lstTipoAtto.SelectedValue = atto_selezionato.CodTipo;
                        lstDefAtto.SelectedValue = atto_selezionato.CodDefinizione;
                        lstOrgIstituzionale.SelectedValue = atto_selezionato.CodOrganoIstituzionale;
                        txtDescrizione.Text = atto_selezionato.Descrizione;
                        txtRegistro.Text = atto_selezionato.Registro;
                        txtDataBur.Text = atto_selezionato.DataBur;
                        txtNumBoll.Text = atto_selezionato.NumeroBur;
                        btnVisualizzaDocumento.Disabled = false;
                        btnVisualizzaDocumento.Attributes.Add("onclick", SiarLibrary.DbStaticProvider.GetJsUrlDecreto(atto_selezionato));
                    }
                    break;
                default:
                    tbDettaglio.Visible = false;
                    lstRDefinizione.DataBind();
                    lstRRegistro.DataBind();
                    string cod_def_atto = lstRDefinizione.SelectedValue;
                    if (string.IsNullOrEmpty(cod_def_atto) || cod_def_atto.Length > 1) cod_def_atto = "D";
                    SiarLibrary.AttiCollection atti;
                    try
                    {
                        if (cerca_su_attiweb) atti = atti_provider.ImportaAtto(txtRNum.Text, txtRData.Text, cod_def_atto, lstRRegistro.SelectedValue);
                        else
                        {
                            string registro = null;
                            if (!string.IsNullOrEmpty(lstRRegistro.SelectedValue)) registro = lstRRegistro.SelectedValue.Split('|')[0];
                            atti = atti_provider.Find(txtRNum.Text, txtRData.Text, cod_def_atto, registro);
                        }
                    }
                    catch (Exception ex) { atti = new SiarLibrary.AttiCollection(); ShowError(ex); }
                    dg.DataSource = atti;
                    dg.ItemDataBound += new DataGridItemEventHandler(dg_ItemDataBound);
                    dg.Titolo = "Elementi trovati: " + ((SiarLibrary.CustomCollection)dg.DataSource).Count;
                    dg.DataBind();

                    break;
            }
            base.OnPreRender(e);
        }

        void dg_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.Atti a = (SiarLibrary.Atti)e.Item.DataItem;
                string fn_click;
                if (a.IdAtto != null) fn_click = "selezionaAtto(" + a.IdAtto + ");";
                else fn_click = "salvaAtto(" + a.ConvertToJSonObject() + ");";
                e.Item.Attributes.Add("onclick", fn_click);
                e.Item.Attributes.Add("onmouseover", "selectRow(this,'#fefeee');");
                e.Item.Attributes.Add("onmouseout", "unselectRow(this);");
            }
        }

        protected void btnSalva_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (atto_selezionato == null) throw new Exception("Non è stato selezionato nessun atto, impossibile continuare.");
                atto_selezionato.CodTipo = lstTipoAtto.SelectedValue;
                atti_provider.Save(atto_selezionato);
                ShowMessage("Modifiche salvate correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalvaAttoImportato_click(object sender, System.EventArgs e)
        {
            try
            {
                string atto_json = hdnIdAtto.Value;
                atto_selezionato = new SiarLibrary.Atti();
                try { atto_selezionato.FillByJsonObject(atto_json); }
                catch { throw new Exception("Non è stato selezionato nessun atto, impossibile continuare."); }
                SiarLibrary.AttiCollection atti_gia_presenti = atti_provider.Find(atto_selezionato.Numero, atto_selezionato.Data, atto_selezionato.CodDefinizione, atto_selezionato.Registro);
                if (atti_gia_presenti.Count == 0) atti_provider.Save(atto_selezionato);
                else if (atti_gia_presenti.Count == 1) atto_selezionato = atti_gia_presenti[0];
                else throw new Exception("L'atto selezionato è in conflitto con quelli già presenti su database locale, impossibile continuare.");
                hdnIdAtto.Value = atto_selezionato.IdAtto;
                ucSiarNewTab.TabSelected = 2;
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnCerca_Click(object sender, EventArgs e)
        {
            dg.SetPageIndex(0);
            cerca_su_attiweb = false;
        }

        protected void btnCercaAW_Click(object sender, EventArgs e)
        {
            dg.SetPageIndex(0);
            cerca_su_attiweb = true;
        }
    }
}
