using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.admin
{
    public partial class EnteRNA : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "EntiRNA";
            base.OnPreInit(e);
        }
        SiarBLL.EnteCollectionProvider enteprov = new SiarBLL.EnteCollectionProvider();
        SiarBLL.VrnaEntiCollectionProvider VrnaEntiCollectionProvider = new SiarBLL.VrnaEntiCollectionProvider();
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
                    //ucSiarNewTab.Width = tabLista.Width;
                    lstTipoEnteRicerca.DataBind();
                    dg_enti.DataSource = VrnaEntiCollectionProvider.Select(null, lstTipoEnteRicerca.SelectedValue, null, null, null, null, null, null);
                    dg_enti.ItemDataBound += new DataGridItemEventHandler(dg_ItemDataBound);
                    dg_enti.DataBind();
                    hdnCodEnte.Value = "";
                    break;
                case 2:
                    if (!string.IsNullOrEmpty(hdnCodEnte.Value))
                    {
                        //ucSiarNewTab.Width = tabNuovo.Width;
                        popolaEnte();
                        tabLista.Visible = false;
                    }
                    else
                    {
                        ucSiarNewTab.TabSelected = 1;
                        tabNuovo.Visible = false;
                        //ucSiarNewTab.Width = tabLista.Width;
                        lstTipoEnteRicerca.DataBind();
                        dg_enti.DataSource = VrnaEntiCollectionProvider.Select(null, lstTipoEnteRicerca.SelectedValue, null, null, null, null, null, null);
                        dg_enti.ItemDataBound += new DataGridItemEventHandler(dg_ItemDataBound);
                        dg_enti.DataBind();
                        hdnCodEnte.Value = "";
                        ShowError("Selezionare un ente per andare in dettaglio");
                    }
                    break;
            }
            base.OnPreRender(e);
        }

        private void popolaEnte()
        {
            SiarBLL.RnaEntiCollectionProvider rnaEntiCollectionProvider = new SiarBLL.RnaEntiCollectionProvider();
            SiarLibrary.RnaEntiCollection rnaEntiCollection = new SiarLibrary.RnaEntiCollection();
            RnaManager.RnaCryptography rnaCryptography = new RnaManager.RnaCryptography();
            btnElimina.Enabled = false;
            if (!string.IsNullOrEmpty(hdnCodEnte.Value))
            {
                rnaEntiCollection = rnaEntiCollectionProvider.FindCodEnte(hdnCodEnte.Value);
                ente = enteprov.GetById(hdnCodEnte.Value);
                if (ente == null) hdnCodEnte.Value = null;
                else
                {
                    txtCodice.Text = ente.CodEnte;
                    txtCodice.ReadOnly = true;
                    txtDescrizione.Text = ente.Descrizione;
                    txtDescrizione.ReadOnly = true;
                    if(rnaEntiCollection.Count!=0)
                    {
                        txtUsername.Text = rnaEntiCollection[0].Username;
                        if(!string.IsNullOrEmpty(rnaEntiCollection[0].PasswordCrypted))
                            txtPassword.Text = rnaCryptography.Decrypt(rnaEntiCollection[0].PasswordCrypted);
                        btnElimina.Enabled = true;
                    }
                }
            }
            
        }

        void dg_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.VrnaEnti vEnte = (SiarLibrary.VrnaEnti)e.Item.DataItem;
                if (vEnte.IdRnaEnte == null)
                {
                    e.Item.BackColor = System.Drawing.Color.FromArgb(204, 204, 185);
                    e.Item.Cells[5].Text = "NO";
                }
                else
                {
                    e.Item.Cells[5].Text = "SI";
                }
            }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (!string.IsNullOrEmpty(hdnCodEnte.Value))
                {
                    if (!(string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text)))
                    {
                        ente = enteprov.GetById(hdnCodEnte.Value);
                        RnaManager.RnaCryptography rnaCryptography = new RnaManager.RnaCryptography();
                        SiarBLL.RnaEntiCollectionProvider rnaEntiCollectionProvider = new SiarBLL.RnaEntiCollectionProvider();
                        SiarLibrary.RnaEntiCollection rnaEntiCollection = new SiarLibrary.RnaEntiCollection();
                        rnaEntiCollection = rnaEntiCollectionProvider.FindCodEnte(hdnCodEnte.Value);
                        if (rnaEntiCollection.Count == 0)
                        {
                            SiarLibrary.RnaEnti rnaEnte = new SiarLibrary.RnaEnti()
                            {
                                Abilitato = false,
                                CodEnte = ente.CodEnte,
                                Username = txtUsername.Text,
                                PasswordCrypted = rnaCryptography.Encrypt(txtPassword.Text),
                                CredenzialiProduzione = false
                            };
                            rnaEntiCollectionProvider.Save(rnaEnte);
                        }
                        else
                        {
                            rnaEntiCollection[0].Username = txtUsername.Text;
                            rnaEntiCollection[0].PasswordCrypted = rnaCryptography.Encrypt(txtPassword.Text);
                            rnaEntiCollection[0].CredenzialiProduzione = rnaEntiCollection[0].Abilitato ? 1 : 0;

                            rnaEntiCollectionProvider.Save(rnaEntiCollection[0]);
                        }
                        ShowMessage("Credenziali salvate correttamente.");
                    }
                    else
                        ShowError("Inserire username e password da salvare");
                }
                else
                    ShowError("Selezionare prima un ente");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnFiltroEnte_Click(object sender, EventArgs e)
        {
            dg_enti.SetPageIndex(0);
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (string.IsNullOrEmpty(hdnCodEnte.Value)) throw new Exception("L'ente selezionato non è valido.");
                SiarBLL.RnaEntiCollectionProvider rnaEntiCollectionProvider = new SiarBLL.RnaEntiCollectionProvider();
                SiarLibrary.RnaEntiCollection rnaEntiCollection = new SiarLibrary.RnaEntiCollection();
                rnaEntiCollection = rnaEntiCollectionProvider.FindCodEnte(hdnCodEnte.Value);
                if (rnaEntiCollection.Count == 0)
                    ShowError("Credenzali non presenti nel sistema.");
                else
                {
                    if (!rnaEntiCollection[0].Abilitato)
                    {
                        rnaEntiCollectionProvider.Delete(rnaEntiCollection[0]);
                        ucSiarNewTab.TabSelected = 1;
                        ShowMessage("Credenziali eliminate correttamente.");
                    }
                    else
                        ShowError("Impossibile eliminare un ente già abilitato, contattare l'help desk.");
                }
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}