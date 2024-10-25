using System;

namespace web.CONTROLS
{
    public partial class SNCPlurivaloreSql : System.Web.UI.UserControl
    {
        private int _idProgetto;
        public int IdProgetto { set { _idProgetto = value; } }

        private bool _faseIstruttoria;
        public bool FaseIstruttoria { set { _faseIstruttoria = value; } }

        private int _idRequisito;
        public int IdRequisito { set { _idRequisito = value; } }

        /// <summary>
        /// funzione lato server da implementare su ajaxrequest.aspx
        /// </summary> 
        private string _searchFunction;
        public string SearchFunction { set { _searchFunction = value; } }
        /// <summary>
        /// funzione lato client da implementare per gestire la selezione dell'elemento
        /// </summary> 
        private string _selectJsFunction;
        public string SelectJsFunction { set { _selectJsFunction = value; } }

        /// <summary>
        /// funzione lato client da implementare per pulire il valore selezionato
        /// </summary>
        private string _clearJsFunction;
        public string ClearJsFunction { set { _clearJsFunction = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            imgSNCSelezionaPlurivalore.Src = Request.ApplicationPath + "/images/folderopen.png";
            imgSNCSelezionaPlurivalore.Attributes.Add("onclick", "SNCZoomPlurivaloreSql(" + _idProgetto + "," + _faseIstruttoria.ToString().ToLower() + "," + _idRequisito + ",'" + _searchFunction + "'," + _selectJsFunction + ",0);");
            imgSNCDeselezionaPlurivalore.Src = Request.ApplicationPath + "/images/xdel.gif";
            imgSNCDeselezionaPlurivalore.Attributes.Add("onclick", _clearJsFunction + "(" + _idRequisito + ");");
        }
    }
}