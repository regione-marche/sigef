using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

/* STORIA
 * Data: 2016-05-24; Statoo: Creazione; Autore: 
*/

namespace web.CONTROLS
{
    public partial class Ateco2007 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page is SiarLibrary.Web.ProgettoPage)
            {
                _progetto = ((SiarLibrary.Web.ProgettoPage)Page).Progetto;
            }
            else if (Page is SiarLibrary.Web.PrivatePage)
            {
                _progetto = (SiarLibrary.Progetto)(Session["_progetto"]);
            }
            if (!IsPostBack)
            {
                if (_progetto != null)
                {
                    if (_progetto.IdProgetto != null && AtecoCurrent != null && AtecoCurrent.IdAteco2007 != "")
                    {
                        cmbAteco.Text = AtecoCurrent.CodiceAteco + " - " + AtecoCurrent.Descrizione;
                        IDAtecoHide.Value = AtecoCurrent.IdAteco2007;
                    }
                }
            }
            ((SiarLibrary.Web.PrivatePage)Page).RegisterClientScriptBlock(@"
                $('" + cmbAteco.ClientID + @"').impostaAutoComplete('getATECO2007Bando', " + idBando + @", 4, 22, '" + IDAtecoHide.ClientID + @"', 'ATECO');
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
        public string IdAteco2007Selezionato
        {
            get
            {
                return IDAtecoHide.Value;
            }
        }

        private SiarLibrary.Ateco2007 _AtecoCurrent;
        public SiarLibrary.Ateco2007 AtecoCurrent
        {
            get { return _AtecoCurrent; }
            set { _AtecoCurrent = value; }
        }
    }
}