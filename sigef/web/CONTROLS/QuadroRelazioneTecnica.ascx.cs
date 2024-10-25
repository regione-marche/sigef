using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace web.CONTROLS
{
    public partial class QuadroRelazioneTecnica : System.Web.UI.UserControl
    {
        private SiarLibrary.BandoRelazioneTecnica paragrafo;
        public SiarLibrary.BandoRelazioneTecnica Paragrafo
        {
            get { return paragrafo; }
            set { paragrafo = value; }
        }

        private string _testo;
        public string Testo
        {
            get { return _testo; }
            set { _testo = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            tdTitolo.InnerText              = paragrafo.Titolo;
            tdDescrizione.InnerText         = paragrafo.Descrizione;
            txtDescrizioneLunga.Text        = Testo;
            txtDescrizioneLunga.NomeCampo   = "Testo " + paragrafo.Titolo;
        }
    }
}