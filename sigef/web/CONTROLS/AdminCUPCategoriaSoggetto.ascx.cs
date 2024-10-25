using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

/* STORIA
 * Data: 2016-05-24; Statoo: Creazione; Autore: 
*/

namespace web.CONTROLS
{
    public partial class AdminCUPCategoriaSoggetto : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cmbCategoria.DataBind();
            cmbCategoriaSub.DataBind();

            if (Page is SiarLibrary.Web.ProgettoPage)
                _progetto = ((SiarLibrary.Web.ProgettoPage)Page).Progetto;
            if (Page is SiarLibrary.Web.PrivatePage)
                _progetto = (SiarLibrary.Progetto)(Session["_progetto"]);
            ((SiarLibrary.Web.PrivatePage)Page).RegisterClientScriptBlock(@"
                    $('" + cmbCategoriaSub.ClientID + @"').filtraComboOptByComboVal('" + cmbCategoria.ClientID + @"', false, true, 2, true, false); 
             ");
            ((SiarLibrary.Web.PrivatePage)Page).RegisterClientScriptBlock(@"
                $('[id$=btnSalvaMonitoraggio]').click(function(){$('[id$=hdnsavedatimonitoraggioCategoriaSub]').val('ON');});
            ");
            if (_progetto != null && hdnsavedatimonitoraggioCategoriaSub.Value == "")
            {
                if (_progetto.IdProgetto != null && _CUPCategoriaCurrent != null && _CUPCategoriaCurrent.IdCategoria != "")
                {  // se il progetto non e' nullo ed ho il codice
                    ((SiarLibrary.Web.PrivatePage)Page).RegisterClientScriptBlock(@"
                        comboInizializza('" + cmbCategoria.ClientID + "', '" + _CUPCategoriaCurrent.CodiceCategoria + @"0000');
                        comboInizializza('" + cmbCategoriaSub.ClientID + "', '" + _CUPCategoriaCurrent.IdCategoria  + @"');
                        "
                    );
                    //((SiarLibrary.Web.PrivatePage)Page).RegisterClientScriptBlock(@"comboInizializza('" + cmbCategoriaSub.ClientID + "', '" + _CUPCategoriaCurrent.IdCategoria  + "');");
                }
            }
            else {
                hdnsavedatimonitoraggioCategoriaSub.Value = "";
               ((SiarLibrary.Web.PrivatePage)Page).RegisterClientScriptBlock(@"
                        comboInizializza('" + cmbCategoria.ClientID + "', '" + cmbCategoria.SelectedValue + @"');
                        comboInizializza('" + cmbCategoriaSub.ClientID + "', '" + cmbCategoriaSub.SelectedValue + @"');
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


        private SiarLibrary.CUPCategoriaSoggetto _CUPCategoriaCurrent;
        public SiarLibrary.CUPCategoriaSoggetto CUPCategoriaCurrent
        {
            get { return _CUPCategoriaCurrent; }
            set { _CUPCategoriaCurrent = value; }
        }

        public string IdCategoriaSelezionato
        {
            get {
                return cmbCategoriaSub.SelectedValue;
            }
        }        

        protected override void OnPreRender(EventArgs e)
        {
            //cmbCategoria.DataBind();
            //cmbCategoriaSub.DataBind();

//            if (_progetto.IdProgetto != null && _CUPCategoriaCurrent != null && _CUPCategoriaCurrent.IdCategoria != "")  // se il progetto non e' nullo ed ho il codice
//            {
//                ((SiarLibrary.Web.PrivatePage)Page).RegisterClientScriptBlock(@"filtraComboOptInizializza('" + cmbCategoriaSub.ClientID + "', '" + _CUPCategoriaCurrent.IdCategoria + "', '" + cmbCategoria.ClientID + "', '" + _CUPCategoriaCurrent.CodiceCategoria + "0000');");

////                ((SiarLibrary.Web.PrivatePage)Page).RegisterClientScriptBlock("CUPCategoriaSoggetto_SetCmb", @"
////                <script>
////                    $(document).ready(function(){
////                        $('#" + cmbCategoria.ClientID + @"').val('" + _CUPCategoriaCurrent.CodiceCategoria + @"0000');
////                        $('#" + cmbCategoria.ClientID + @"').trigger('change');
////                        $('#" + cmbCategoriaSub.ClientID + @"').val('" + _CUPCategoriaCurrent.IdCategoria + @"');
////                    });
////                </script>
////                ");
//                // cmbCategoria.SelectedValue = _CUPCategoriaCurrent.CodiceCategoria + "0000";
//                // cmbCategoriaSub.SelectedValue = _CUPCategoriaCurrent.CodiceCategoria;
//            }
            base.OnPreRender(e);
        }

    }
}