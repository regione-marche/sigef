using System;
using System.Web.UI.WebControls;

namespace web.Private.Psr.Bandi
{
    public partial class Ricerca : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "bando_ricerca";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        { }

        protected override void OnPreRender(EventArgs e)
        {
            lstEntiBando.DataBind();
            lstProgrammazione.AttivazioneBandi = true;
            lstProgrammazione.DataBind();
            lstStatoBando.DataBind();
            lstPsr.DataBind();
            if (!IsPostBack) dgBandi.Titolo = "Specificare i parametri di ricerca.";
            else
            {
                SiarLibrary.NullTypes.DatetimeNT data_scadenza = new SiarLibrary.NullTypes.DatetimeNT(txtScadenza.Text);
                SiarLibrary.NullTypes.IntNT id_bando = new SiarLibrary.NullTypes.IntNT(txtIdBando.Text);
                if (data_scadenza != null) data_scadenza.AddHour(24, 0, 0);
                string parole_chiave = null;
                if (!string.IsNullOrEmpty(txtParoleChiave.Text)) parole_chiave = "%" + txtParoleChiave.Text + "%";
                SiarLibrary.BandoCollection bandi = new SiarBLL.BandoCollectionProvider().BandoRicercaGenerale(lstEntiBando.SelectedValue, lstStatoBando.SelectedValue, null,
                    data_scadenza, lstProgrammazione.SelectedValue, chkMultiprogetto.Checked ? new SiarLibrary.NullTypes.BoolNT(true) : new SiarLibrary.NullTypes.BoolNT(),
                    chkMultimisura.Checked ? new SiarLibrary.NullTypes.BoolNT(true) : new SiarLibrary.NullTypes.BoolNT(), chkDisposizioni.Checked, parole_chiave, id_bando,
                    lstPsr.SelectedValue);
                dgBandi.Titolo = "Elementi trovati: " + bandi.Count;
                dgBandi.DataSource = bandi;
            }
            dgBandi.DataBind();
            base.OnPreRender(e);
        }

        protected void btnCerca_Click(object sender, EventArgs e)
        {
            hdnRicerca.Value = "true";
            dgBandi.SetPageIndex(0);
        }
    }
}
