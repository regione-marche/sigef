using System;


namespace web.CONTROLS
{
    public partial class ucRichiestaDocumentoPagamento : System.Web.UI.UserControl
    {
        private SiarLibrary.ProgettoComunicazioniDocumenti _documento;
        public SiarLibrary.ProgettoComunicazioniDocumenti Documento
        {
            get { return _documento; }
            set { _documento = value; }
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


        protected void Page_Load(object sender, EventArgs e) { }

        protected override void OnPreRender(EventArgs e)
        {
            if (_documento != null)
            {
                if (_documento.Formato == "S")
                {
                    trEstremiDocumento.Visible = true;
                    txtNrDocumento.Text = _documento.Numero;
                    txtDataDocumento.Text = _documento.Data;
                    txtEnteDocumento.Text = _documento.Ente;
                }
                txtCategoria.Text = _documento.DescrizioneDocumento;
                txtDescrizione.Text = _documento.Descrizione;
                txtNoteIstruttore.Text = _documento.Note;
                if (_eliminaDocumentoAbilitato)
                {
                    spEliminaDocumento.Visible = true;
                    spEliminaDocumento.Attributes.Add("onclick", "ucRDocElimina(" + _documento.Id + ");");
                }
            }
            base.OnPreRender(e);
        }
    }
}