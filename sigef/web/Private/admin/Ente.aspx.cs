using System;
using System.Web.UI.WebControls;

namespace web.Private.admin
{
    public partial class Ente : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "Enti";
            base.OnPreInit(e);
        }
        SiarBLL.EnteCollectionProvider enteprov = new SiarBLL.EnteCollectionProvider();
        SiarBLL.ProfiloXFunzioniCollectionProvider pxfprov = new SiarBLL.ProfiloXFunzioniCollectionProvider();
        SiarLibrary.Ente ente;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 1:
                    tabNuovo.Visible = false;
                    ucSiarNewTab.Width = tabLista.Width;
                    lstTipoEnteRicerca.DataBind();
                    dg.DataSource = enteprov.Find(null, lstTipoEnteRicerca.SelectedValue, null);
                    dg.ItemDataBound += new DataGridItemEventHandler(dg_ItemDataBound);
                    dg.DataBind();
                    break;
                case 2:
                    lstTipoEnte.DataBind();
                    ucSiarNewTab.Width = tabNuovo.Width;
                    popolaEnte();
                    popolaProfili();
                    tabLista.Visible = false;
                    break;
            }
            base.OnPreRender(e);
        }

        private void popolaEnte()
        {
            if (!string.IsNullOrEmpty(hdnCodEnte.Value))
            {
                ente = enteprov.GetById(hdnCodEnte.Value);
                if (ente == null) hdnCodEnte.Value = null;
                else
                {
                    txtCodice.Text = ente.CodEnte;
                    txtCodice.ReadOnly = true;
                    txtDescrizione.Text = ente.Descrizione;
                    txtDescrizione.ReadOnly = !ente.Attivo;
                    lstTipoEnte.SelectedValue = ente.CodTipoEnte;
                    lstTipoEnte.Enabled = ente.Attivo;
                    btnSalva.Enabled = AbilitaModifica && ente.Attivo;
                }
            }
            btnDisabilita.Enabled = AbilitaModifica && ente != null && ente.Attivo;
        }

        void dg_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                if (!((SiarLibrary.Ente)e.Item.DataItem).Attivo) e.Item.BackColor = System.Drawing.Color.FromArgb(204, 204, 185);
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (!string.IsNullOrEmpty(hdnCodEnte.Value)) ente = enteprov.GetById(hdnCodEnte.Value);
                else
                {
                    ente = new SiarLibrary.Ente();
                    ente.CodEnte = txtCodice.Text;
                }
                ente.CodTipoEnte = lstTipoEnte.SelectedValue;
                ente.Descrizione = txtDescrizione.Text;
                enteprov.Save(ente);
                hdnCodEnte.Value = ente.CodEnte;
                ShowMessage("Ente salvato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void popolaProfili()
        {
            if (!string.IsNullOrEmpty(lstTipoEnte.SelectedValue))
            {
                SiarLibrary.ProfiliCollection profcoll = new SiarBLL.ProfiliCollectionProvider().Find(null, null, lstTipoEnte.SelectedValue, null, null);
                dgProfili.DataSource = profcoll;
                SiarLibrary.Web.CheckColumn chk = ((SiarLibrary.Web.CheckColumn)dgProfili.Columns[0]);
                chk.SelectAll();
                chk.SetDisabled(chk.GetSelected());
                dgProfili.DataBind();
            }
        }

        protected void btnFiltroEnte_Click(object sender, EventArgs e)
        {
            dg.SetPageIndex(0);
        }

        protected void btnDisabilita_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (string.IsNullOrEmpty(hdnCodEnte.Value)) throw new Exception("L'ente selezionato non è valido.");
                ente = enteprov.GetById(hdnCodEnte.Value);
                if (ente == null || !ente.Attivo) throw new Exception("L'ente selezionato non è valido.");
                if (new SiarBLL.UtentiCollectionProvider().Find(null, null, null, ente.CodEnte, null, null, true).Count > 0)
                    throw new Exception("Esistono degli utenti attivi appartenenti all'ente selezionato.");
                ente.Attivo = false;
                enteprov.Save(ente);
                ShowMessage("Ente disattivato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}