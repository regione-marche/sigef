using System;
using System.Web.UI.WebControls;

namespace web.Private.Psr.Finanziario
{
    /// <summary>
    /// Summary description for FontiFinanziarie.
    /// </summary>
    public partial class FontiFinanziarie : SiarLibrary.Web.PrivatePage
    {

        private SiarBLL.FontiFinanziarieCollectionProvider ff_provider = new SiarBLL.FontiFinanziarieCollectionProvider();
        private SiarLibrary.FontiFinanziarie ff_selezionata = null;

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "psr_fin_fonti_finanziarie";
            base.OnPreInit(e);
        }
        protected void Page_Load(object sender, System.EventArgs e)
        {
            int id_fonte;
            if (int.TryParse(hdnIdFonte.Value, out id_fonte)) ff_selezionata = ff_provider.GetById(id_fonte);
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (ff_selezionata != null)
            {
                txtPercentuale.Text = ff_selezionata.Percentuale;
                txtDescrizione.Text = ff_selezionata.Descrizione;
                btnElimina.Enabled = AbilitaModifica;
            }
            SiarLibrary.FontiFinanziarieCollection cc = ff_provider.Find(null);
            dg.DataSource = cc;
            dg.Titolo = "Elementi trovati: " + cc.Count;
            dg.DataBind();
            base.OnPreRender(e);
        }

        protected void btnSalva_Click(object sender, System.EventArgs e)
        {
            try
            {
                // Controllo che sia abilitata la modifica del record
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

                if (ff_selezionata == null) ff_selezionata = new SiarLibrary.FontiFinanziarie();

                ff_selezionata.Percentuale = txtPercentuale.Text;
                ff_selezionata.Descrizione = txtDescrizione.Text;
                ff_provider.Save(ff_selezionata);
                ShowMessage("Fonte finanziaria salvata correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnFFPost_Click(object sender, EventArgs e)
        {

        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (ff_selezionata == null) throw new Exception("Per proseguire è necessario selezionare l'elemento da eliminare.");

                // TODO: controllare se la FONTE è utilizzata in chiave in altre tabelle

                ff_provider.Delete(ff_selezionata);
                ShowMessage("Fonte Finanziaria eliminata correttamente.");
                ff_selezionata = null;
                RegisterClientScriptBlock("nuovaFF();");
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}
