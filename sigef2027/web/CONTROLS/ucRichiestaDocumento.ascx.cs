using System;

namespace web.CONTROLS
{
    public partial class ucRichiestaDocumento : System.Web.UI.UserControl
    {
        private SiarLibrary.ProgettoComunicazioniAllegati _allegato;
        public SiarLibrary.ProgettoComunicazioniAllegati Allegato
        {
            get { return _allegato; }
            set { _allegato = value; }
        }

        public int Width
        {
            set
            {
                tbMain.Width = value + "px";
                txtCategoria.Width = txtDescrizione.Width = txtNoteIstruttore.Width = new System.Web.UI.WebControls.Unit(value - 50);
            }
        }

        public int NrDoc { set { lblNrDoc.Text = value.ToString(); } }

        private bool _eliminaDocumentoAbilitato = false;
        public bool EliminaDocumentoAbilitato { set { _eliminaDocumentoAbilitato = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            if (_allegato != null)
            {
                if (_allegato.CodTipo == "S")
                {
                    trEstremiDocumento.Visible = true;
                    txtNrDocumento.Text = _allegato.Numero;
                    txtDataDocumento.Text = _allegato.Data;
                    txtEnteDocumento.Text = _allegato.Ente;
                }
                txtCategoria.Text = _allegato.Allegato;
                txtDescrizione.Text = _allegato.DescrizioneBreve;
                txtNoteIstruttore.Text = _allegato.Note;
                if (_eliminaDocumentoAbilitato)
                {
                    spEliminaDocumento.Visible = true;
                    spEliminaDocumento.Attributes.Add("onclick", "ucRDocElimina(" + _allegato.Id + ");");
                }
            }
            base.OnPreRender(e);
        }
    }
}