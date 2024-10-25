using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

/* STORIA
 * Data: 2016-05-24; Statoo: Creazione; Autore: 
*/

namespace web.CONTROLS
{
    public partial class AdminCUPCategoria : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cmbSettore.DataBind();
            cmbSottoSettore.DataBind();
            cmbCategoria.DataBind();
            if (Page is SiarLibrary.Web.ProgettoPage)
                _progetto = ((SiarLibrary.Web.ProgettoPage)Page).Progetto;
            if (Page is SiarLibrary.Web.PrivatePage)
                _progetto = (SiarLibrary.Progetto)(Session["_progetto"]);

            ((SiarLibrary.Web.PrivatePage)Page).RegisterClientScriptBlock(@"
                $('[id$=btnSalvaMonitoraggio]').click(function(){$('[id$=hdnsavedatimonitoraggioCategoria]').val('ON');});
            ");

            ((SiarLibrary.Web.PrivatePage)Page).RegisterClientScriptBlock(@"
                $('" + cmbSottoSettore.ClientID + @"').filtraComboOptByComboVal('" + cmbSettore.ClientID + @"', false, true, 2, true, false); 
                $('" + cmbCategoria.ClientID + @"').filtraComboOptByComboVal('" + cmbSottoSettore.ClientID + @"', false, true, 4, true, false); 
            ");

            if (_progetto != null  &&  hdnsavedatimonitoraggioCategoria.Value == "") 
            {
                if (_progetto.IdProgetto != null && _CUPCategoriaCurrent != null && _CUPCategoriaCurrent.IdCategoria != "")
                {  // se il progetto non e' nullo ed ho il codice
                    ((SiarLibrary.Web.PrivatePage)Page).RegisterClientScriptBlock(@"
                        comboInizializza('" + cmbSettore.ClientID + "', '" + _CUPCategoriaCurrent.Settore + @"00000');
                        comboInizializza('" + cmbSottoSettore.ClientID + "', '" + _CUPCategoriaCurrent.Settore + _CUPCategoriaCurrent.SottoSettore + @"000');
                        comboInizializza('" + cmbCategoria.ClientID + "', '" + _CUPCategoriaCurrent.IdCategoria + @"');
                        "
                    );
                }
            }
            else
            {
                hdnsavedatimonitoraggioCategoria.Value = "";
                ((SiarLibrary.Web.PrivatePage)Page).RegisterClientScriptBlock(@"
                    comboInizializza('" + cmbSettore.ClientID + "', '" + cmbSettore.SelectedValue + @"');
                    comboInizializza('" + cmbSottoSettore.ClientID + "', '" + cmbSottoSettore.SelectedValue + @"');
                    comboInizializza('" + cmbCategoria.ClientID + "', '" + cmbCategoria.SelectedValue + @"');
                    "
                );
            }
        }

        private SiarLibrary.Progetto _progetto;
        public SiarLibrary.Progetto Progetto
        {
            get { return _progetto; }
            set { _progetto = value; }
        }


        private SiarLibrary.CUPCategoria _CUPCategoriaCurrent;
        public SiarLibrary.CUPCategoria CUPCategoriaCurrent
        {
            get { return _CUPCategoriaCurrent; }
            set { _CUPCategoriaCurrent = value; }
        }

        public string IdCategoriaSelezionato
        {
            get {
                return cmbCategoria.SelectedValue;
            }
        }        
        
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

    }
}