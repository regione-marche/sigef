using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

/* STORIA
 * Data: 2016-05-24; Statoo: Creazione; Autore: 
*/

namespace web.CONTROLS
{
    public partial class Indirizzo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cmbDUG.DataBind();

            if (Page is SiarLibrary.Web.ProgettoPage) _progetto = ((SiarLibrary.Web.ProgettoPage)Page).Progetto;
            if (Page is SiarLibrary.Web.IstruttoriaVariantePage) _progetto = ((SiarLibrary.Web.IstruttoriaVariantePage)Page).Progetto;
            if (Page is SiarLibrary.Web.PrivatePage) _progetto = (SiarLibrary.Progetto)(Session["_progetto"]);
            
            ((SiarLibrary.Web.PrivatePage)Page).RegisterClientScriptBlock(@"
                $('" + cmbComune.ClientID + @"').impostaAutoComplete('getComuniBandoLocalizzazioneProgetti', " + idBando + @", 3, 30, [['" + IdComuneHide.ClientID + @"', 'codice'], ['" + txtProv.ClientID + @"', 'prov'], ['" + txtCAP.ClientID + @"', 'cap']], 'Comuni');
            ");            
        }

        private SiarLibrary.Progetto _progetto;
        public SiarLibrary.Progetto Progetto
        {
            get { return _progetto; }
            set { _progetto = value; }
        }

        public int idBando
        {
            get
            {
                if (_progetto != null) return _progetto.IdBando;
                else return 0;
            }
        }

        // Comune impostato per il loda del controllo
        private SiarLibrary.Comuni _CurrentComune;
        public SiarLibrary.Comuni CurrentComune
        {
            get { return _CurrentComune; }
            set { _CurrentComune = value; }
        }

        string _CurrentVia = "";
        public string CurrentVia
        {
            get { return _CurrentVia; }
            set { _CurrentVia = value; }
        }


        string _CurrentNum = "";
        public string CurrentNum
        {
            get { return _CurrentNum; }
            set { _CurrentNum = value; }
        }

        string _CurrentCAP = "";
        public string CurrentCAP
        {
            get { return _CurrentCAP; }
            set { _CurrentCAP = value; }
        }

        int _CurrentDUG = 0;
        public int CurrentDUG
        {
            get { return _CurrentDUG; }
            set { _CurrentDUG = value; }
        }

        // dati inseriti da utente nel controllo indirizzo

        public string inputComuneId
        {
            get
            {
                return IdComuneHide.Value;
            }
        }
        public string inputSiglaProv
        {
            get
            {
                return txtProv.Text;
            }
        }

        public string inputVia
        {
            get
            {
                return txtVia.Text;
            }
        }
        public string inputNum
        {
            get
            {
                return txtNum.Text;
            }
        }
        public string inputCAP
        {
            get
            {
                return txtCAP.Text;
            }
        }

        public int inputDUG
        {
            get
            {
                if (cmbDUG.SelectedIndex > 0) return int.Parse(cmbDUG.SelectedValue);
                else return 0;
            }
        }

        public void clearForm()
        {
            cmbComune.Text = string.Empty;
            txtProv.Text = string.Empty;
            txtCAP.Text = string.Empty;
            IdComuneHide.Value = string.Empty;
            cmbDUG.SelectedIndex = -1;
            txtVia.Text = string.Empty;
            txtNum.Text = string.Empty;
        }

        public void loadLocalizzazione(SiarLibrary.LocalizzazioneProgetto l, SiarLibrary.Comuni c)
        {
            if (c != null && c.IdComune > 0)
            {
                cmbComune.Text = c.Denominazione;
                IdComuneHide.Value = c.IdComune;
                txtProv.Text = c.Sigla;
            }
            txtVia.Text = l.Via;
            txtCAP.Text = l.Cap;
            cmbDUG.SelectedValue = l.Dug.ToString();
            txtNum.Text = l.Num;         
        }
    }
}