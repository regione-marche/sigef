using System;

namespace web.CONTROLS
{
    public partial class SiarNewZoomPunteggio : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public string GetOpenZoomJsFunction(SiarLibrary.NullTypes.IntNT id_progetto)
        {
            string url = "alert('Attenzione! La domanda di aiuto selezionata non è valida. Impossibile continuare.');";
            if (id_progetto != null && id_progetto > 0) url = "snzpShowDiv(" + id_progetto + ",'');";
            return url;
        }
        public string GetOpenZoomVarianteJsFunction(SiarLibrary.NullTypes.IntNT id_progetto, SiarLibrary.NullTypes.IntNT id_variante)
        {
            string url = "alert('Attenzione! La domanda di aiuto selezionata non è valida. Impossibile continuare.');";
            if (id_progetto != null && id_progetto > 0 && id_variante != null && id_variante > 0) url = "snzpShowDiv(" + id_progetto + "," + id_variante + ");";
            return url;
        }
    }
}