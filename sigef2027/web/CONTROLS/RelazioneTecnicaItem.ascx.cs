using System;

namespace web.CONTROLS
{
    public partial class RelazioneTecnicaItem : System.Web.UI.UserControl
    {
        public int IdRelazioneTecnicaItem
        {
            set { txtRTTesto.ID = "txtRTTesto" + value.ToString(); }
        }

        public string Titolo
        {
            set { tdRTTitolo.InnerHtml = value.ToUpper(); }
        }

        public string Descrizione
        {
            set { tdRTDescrizione.InnerHtml = " - " + value; }
        }

        public string Testo
        {
            set { txtRTTesto.Text = value; }
        }
        private bool _obbligatorio;
        public bool Obbligatorio
        {
            set
            {
                _obbligatorio = value;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (_obbligatorio) tdRTTitolo.InnerHtml += " <b>(OBBLIGATORIO)</b>";
            base.OnPreRender(e);
        }
    }
}