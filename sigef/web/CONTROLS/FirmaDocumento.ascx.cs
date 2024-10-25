using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace web.CONTROLS
{
    public partial class FirmaDocumento : System.Web.UI.UserControl
    {
        public EventHandler DocumentoFirmatoEvent { get; set; }
        public bool DoppiaFirma { get; set; } = false;
        public string FileFirmato { get; set; }
        public bool FirmaObbligatoria { get; set; } = true;
        public int IdFileFirmato { get; set; } = 0;
        public string TipoDocumento { get; set; }
        public string Titolo { get; set; }
        public bool Preview { get; set; } = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["SignatureType"] == "applet")
            {
                ucFirmaDocumentoCalamaio.Visible = false;
                ucFirmaDocumentoCalamaio.Dispose();

                ucFirmaDocumentoApplet.DoppiaFirma = this.DoppiaFirma;
                ucFirmaDocumentoApplet.TipoDocumento = this.TipoDocumento;
                ucFirmaDocumentoApplet.Titolo = this.Titolo;
                this.FileFirmato = ucFirmaDocumentoApplet.GetFileFirmato();
                ucFirmaDocumentoApplet.DocumentoFirmatoEvent = this.DocumentoFirmatoEvent;
                ucFirmaDocumentoApplet.FirmaObbligatoria = this.FirmaObbligatoria;
                ucFirmaDocumentoApplet.IdFileFirmato = this.IdFileFirmato;
                ucFirmaDocumentoApplet.Preview = this.Preview;

            }
            else
            {
                ucFirmaDocumentoApplet.Visible = false;
                ucFirmaDocumentoApplet.Dispose();

                ucFirmaDocumentoCalamaio.DoppiaFirma = this.DoppiaFirma;
                ucFirmaDocumentoCalamaio.TipoDocumento = this.TipoDocumento;
                ucFirmaDocumentoCalamaio.Titolo = this.Titolo;
                this.FileFirmato = ucFirmaDocumentoCalamaio.GetFileFirmato();
                ucFirmaDocumentoCalamaio.DocumentoFirmatoEvent = this.DocumentoFirmatoEvent;
                ucFirmaDocumentoCalamaio.FirmaObbligatoria = this.FirmaObbligatoria;
                ucFirmaDocumentoCalamaio.IdFileFirmato = this.IdFileFirmato;
                ucFirmaDocumentoCalamaio.Preview = this.Preview;
            }

        }


        public void loadDocumento(string _cf_firmatario, params string[] _parametri)
        {
            if (ConfigurationManager.AppSettings["SignatureType"] == "applet")
            {
                ucFirmaDocumentoApplet.DoppiaFirma = this.DoppiaFirma;
                ucFirmaDocumentoApplet.TipoDocumento = this.TipoDocumento;
                ucFirmaDocumentoApplet.Titolo = this.Titolo;
                ucFirmaDocumentoApplet.DocumentoFirmatoEvent = this.DocumentoFirmatoEvent;
                ucFirmaDocumentoApplet.FirmaObbligatoria = this.FirmaObbligatoria;
                ucFirmaDocumentoApplet.IdFileFirmato = this.IdFileFirmato;
                ucFirmaDocumentoApplet.Preview = this.Preview;

                ucFirmaDocumentoApplet.loadDocumento(_cf_firmatario, _parametri);

                if (ucFirmaDocumentoApplet.FileFirmato != null)
                    this.FileFirmato = ucFirmaDocumentoApplet.GetFileFirmato();

            }
            else
            {
                ucFirmaDocumentoCalamaio.DoppiaFirma = this.DoppiaFirma;
                ucFirmaDocumentoCalamaio.TipoDocumento = this.TipoDocumento;
                ucFirmaDocumentoCalamaio.Titolo = this.Titolo;
                ucFirmaDocumentoCalamaio.DocumentoFirmatoEvent = this.DocumentoFirmatoEvent;
                ucFirmaDocumentoCalamaio.FirmaObbligatoria = this.FirmaObbligatoria;
                ucFirmaDocumentoCalamaio.IdFileFirmato = this.IdFileFirmato;
                ucFirmaDocumentoCalamaio.Preview = this.Preview;

                ucFirmaDocumentoCalamaio.loadDocumento(_cf_firmatario, _parametri);

                if (ucFirmaDocumentoCalamaio.FileFirmato != null)
                    this.FileFirmato = ucFirmaDocumentoCalamaio.GetFileFirmato();
            }
        }


        public void loadDocumentoSenzaFirma(string _cf_firmatario, params string[] _parametri)
        {
            if (ConfigurationManager.AppSettings["SignatureType"] == "applet")
            {
                ucFirmaDocumentoApplet.DoppiaFirma = this.DoppiaFirma;
                ucFirmaDocumentoApplet.TipoDocumento = this.TipoDocumento;
                ucFirmaDocumentoApplet.Titolo = this.Titolo;
                ucFirmaDocumentoApplet.DocumentoFirmatoEvent = this.DocumentoFirmatoEvent;
                ucFirmaDocumentoApplet.FirmaObbligatoria = this.FirmaObbligatoria;
                ucFirmaDocumentoApplet.IdFileFirmato = this.IdFileFirmato;
                ucFirmaDocumentoApplet.Preview = this.Preview;

                ucFirmaDocumentoApplet.loadDocumentoSenzaFirma(_cf_firmatario, _parametri);

                if (ucFirmaDocumentoApplet.FileFirmato != null)
                    this.FileFirmato = ucFirmaDocumentoApplet.GetFileFirmato();

            }
            else
            {
                ucFirmaDocumentoCalamaio.DoppiaFirma = this.DoppiaFirma;
                ucFirmaDocumentoCalamaio.TipoDocumento = this.TipoDocumento;
                ucFirmaDocumentoCalamaio.Titolo = this.Titolo;
                ucFirmaDocumentoCalamaio.DocumentoFirmatoEvent = this.DocumentoFirmatoEvent;
                ucFirmaDocumentoCalamaio.FirmaObbligatoria = this.FirmaObbligatoria;
                ucFirmaDocumentoCalamaio.IdFileFirmato = this.IdFileFirmato;
                ucFirmaDocumentoCalamaio.Preview = this.Preview;

                ucFirmaDocumentoCalamaio.loadDocumentoSenzaFirma(_cf_firmatario, _parametri);

                if (ucFirmaDocumentoCalamaio.FileFirmato != null)
                    this.FileFirmato = ucFirmaDocumentoCalamaio.GetFileFirmato();
            }
        }

    }
}