using System;

namespace web.CONTROLS
{
    public partial class AZDomanda : System.Web.UI.UserControl
    {
        private SiarLibrary.Progetto _progetto;
        public SiarLibrary.Progetto Progetto
        {
            get { return _progetto; }
            set { _progetto = value; }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            if (_progetto != null)
            {
                btnProsegui.Disabled = !(_progetto.OrdineFase > 3 && _progetto.CodStato != "N");
                btnProsegui.Attributes.Add("onclick", "location='../PPagamento/GestioneLavori.aspx'");
            }
            else btnProsegui.Attributes.Add("onclick", "alert('Nessuna domanda in memoria, occorre disconnettersi ed effettuare nuovamente l`accesso.')");
        }
    }
}