using System;
using System.Web;
using System.Web.UI;

namespace web.CONTROLS
{
    public partial class DatiBandoCovid : SiarLibrary.Web.SigefUserControl
    {
        //private SiarLibrary.Bando _bando;
        //public SiarLibrary.Bando Bando
        //{
        //    get { return _bando; }
        //    set { _bando = value; }
        //}

        //private SiarLibrary.Progetto _progetto;
        //public SiarLibrary.Progetto Progetto
        //{
        //    get { return _progetto; }
        //    set { _progetto = value; }
        //}

        //private SiarLibrary.Impresa _impresa;
        //public SiarLibrary.Impresa Impresa
        //{
        //    get { return _impresa; }
        //    //set { _impresa = value; }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            loadData();
        }

        public void loadData()
        {
            //int id_bando;
            if (Session["id_bando_covid"] != null)
            {
                //int id_bando = Convert.ToInt32()
                SiarLibrary.Bando bando = new  SiarBLL.BandoCollectionProvider().GetById(Convert.ToInt32((string)Session["id_bando_covid"]));
                lbBando.Text = bando.Descrizione;
                //lbDataScadenza.Text = bando.DataScadenza;
            }
        }
    }
}