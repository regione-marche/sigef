using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarLibrary;
using SiarLibrary.Web;
using SiarBLL;
using SiarLibrary.NullTypes;

namespace web.Private.Controlli
{
    public partial class RicercaRinunce : RinuncePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            CaricaRinunce();
            base.OnPreRender(e);
        }

        protected void btnVisualizzaRinuncia_Click(object sender, EventArgs e)
        {
            try
            {
                RinunciaCollectionProvider rinunciaCollectionProvider = new RinunciaCollectionProvider();

                int idRinuncia;
                if (int.TryParse(hdnIdRinuncia.Value, out idRinuncia))
                {
                    var rinuncia = rinunciaCollectionProvider.GetById(idRinuncia);
                    if (rinuncia != null && rinuncia.IdProgetto != null)
                    {
                        var progetto = new ProgettoCollectionProvider().GetById(rinuncia.IdProgetto);
                        Rinuncia = rinuncia;
                        Progetto = progetto;
                        Redirect(PATH_CONTROLLI + "Rinunce.aspx");
                    }
                    else
                    {
                        throw new Exception("Progetto non caricato correttamente. Contattare l'helpdesk");
                    }
                }
                else
                    throw new Exception("Nessuna revoca selezionata.");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void CaricaRinunce()
        {
            RinunciaCollectionProvider rinunciaCollectionProvider = new RinunciaCollectionProvider();
            RinunciaCollection rinunciaCollection = new RinunciaCollection();
            rinunciaCollection = rinunciaCollectionProvider.Select(null, null, null, null, null, null, null);
            dgRinunce.DataSource = rinunciaCollection;
            dgRinunce.DataBind();
            if (rinunciaCollection.Count == 0)
                lblNumRinunce.Text = "Non ci sono rinunce da visualizzare";
            else
                lblNumRinunce.Text = "Rinunce visualizzate: " + rinunciaCollection.Count.ToString();
        }
    }
}