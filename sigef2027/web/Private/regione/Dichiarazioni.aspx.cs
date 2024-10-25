using System;
using System.Web.UI.WebControls;
using SiarLibrary.NullTypes;

namespace web.Private.regione
{
    public partial class Dichiarazioni : SiarLibrary.Web.PrivatePage
    {
        StringNT misura = null;
        StringNT descrizione = null;
        SiarBLL.CatalogoDichiarazioniCollectionProvider dicprov = new SiarBLL.CatalogoDichiarazioniCollectionProvider();

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "Dichiarazioni";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack && Request.Form["__EVENTTARGET"] != null && Request.Form["__EVENTTARGET"].StartsWith("ctl00$cphContenuto$dg$ctl"))
            {
                try
                {
                    dicprov.Delete(dicprov.GetById(int.Parse(Request.Form["__EVENTARGUMENT"])));
                    ShowMessage("Dichiarazione eliminata.");
                }
                catch
                {
                    this.ShowError("Attenzione", "Impossibile eliminare la dichiarazione perche' utilizzata nei modelli di domanda.");
                }
            }
        }
        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab1.TabSelected)
            {
                case 2:
                    tblElenco.Visible = false;
                    //ucSiarNewTab1.Width = tblNuovo.Width;
                    int idEdit;
                    if (int.TryParse(hdnEdit.Value, out idEdit))
                    {
                        SiarLibrary.CatalogoDichiarazioni d = new SiarLibrary.CatalogoDichiarazioni();
                        d = dicprov.GetById(idEdit);
                        txtDescrizioneLunga.Text = d.Descrizione;
                        txtMisura.Text = d.Misura;
                    }
                    break;
                default:
                    tblNuovo.Visible = false;
                    //ucSiarNewTab1.Width = tblElenco.Width;
                    hdnEdit.Value = string.Empty;
                    if (!String.IsNullOrEmpty(txtMisuraFind.Text)) misura = txtMisuraFind.Text + "%";
                    if (!String.IsNullOrEmpty(txtDescrizioneFind.Text)) descrizione = "%" + txtDescrizioneFind.Text + "%";

                    SiarLibrary.CatalogoDichiarazioniCollection diccoll;
                    diccoll = dicprov.Find(null, misura, descrizione);

                    dg.DataSource = diccoll;
                    dg.Titolo = "Elementi trovati: " + diccoll.Count;
                    dg.DataBind();
                    break;
            }
            base.OnPreRender(e);
        }


        protected string getElimina(object container /*ds della riga*/)
        {
            DataGridItem dgi = (DataGridItem)container;
            SiarLibrary.CatalogoDichiarazioni f = (SiarLibrary.CatalogoDichiarazioni)dgi.DataItem;
            if (!AbilitaModifica) return "";

            return "javascript:if(confirm('Eliminare la dichiarazione?')){" + ClientScript.GetPostBackEventReference(dgi, f.IdDichiarazione) + ";}";
        }
        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.CatalogoDichiarazioni f = new SiarLibrary.CatalogoDichiarazioni();
                string modifica = hdnEdit.Value;
                if (modifica != null && modifica != "")
                {
                    f = dicprov.GetById(modifica);
                }
                f.Descrizione = txtDescrizioneLunga.Text;
                f.Misura = txtMisura.Text;
                dicprov.Save(f);
                ShowMessage("Salvataggio completato");
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            ucSiarNewTab1.TabSelected = 2;
        }

        protected void btnCerca_Click(object sender, EventArgs e) { }

        protected void btnNoFilter_Click(object sender, EventArgs e)
        {
            misura = null;
            descrizione = null;
            txtMisuraFind.Text = "";
            txtDescrizioneFind.Text = "";
        }

    }
}