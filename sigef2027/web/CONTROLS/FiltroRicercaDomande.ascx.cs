using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.CONTROLS
{
    public partial class FiltroRicercaDomande : System.Web.UI.UserControl
    {
        private SiarLibrary.NullTypes.IntNT _idBando;
        public SiarLibrary.NullTypes.IntNT IdBando
        {
            get { return _idBando; }
            set { _idBando = value; }
        }

        public SiarLibrary.NullTypes.IntNT IdProgetto
        {
            get { return new SiarLibrary.NullTypes.IntNT(txtNumero.Text); }
        }
        public SiarLibrary.NullTypes.StringNT StatoDomanda
        {
            get { return lstStato.SelectedValue; }
        }
        public SiarLibrary.NullTypes.StringNT Cuaa
        {
            get { return txtCuaa.Text; }
        }
        public SiarLibrary.NullTypes.StringNT RagioneSociale
        {
            get { return txtRagsoc.Text; }
        }
        public SiarLibrary.NullTypes.IntNT Operatore
        {
            get { return lstOperatore.SelectedValue; }
            set { lstOperatore.SelectedValue = value; }
        }

        public SiarLibrary.NullTypes.StringNT Provincia
        {
            get { return lstProvince.SelectedValue; }
            set { lstProvince.SelectedValue = value; }
        }
        public SiarLibrary.NullTypes.BoolNT ProvinciaEnabled
        {
            set { lstProvince.Enabled = value; }
        }
        public SiarLibrary.NullTypes.BoolNT OperatoreEnabled
        {
            set { lstOperatore.Enabled = value; }
        }

        public bool EsportaEnabled
        {
            set { rowEsporta.Visible = value; }
        }

        public ListItemCollection ValoriStato = new ListItemCollection();

        private void lstStato_DataBind(object sender, EventArgs e)
        {
            lstStato.Items.Clear();
            foreach (ListItem li in ValoriStato)
            {
                if (li.Value == lstStato.SelectedValue) li.Selected = true;
                lstStato.Items.Add(li);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lstOperatore.IdBando = IdBando;
            lstOperatore.DataBind();
            lstStato.DataBinding += new EventHandler(lstStato_DataBind);
            lstStato.DataBind();
            lstProvince.CodRegione = "11";
            lstProvince.DataBind();
        }

        protected void btnCerca_Click(object sender, EventArgs e)
        {

        }

        protected void btnEsportazione_Click(object sender, EventArgs e)
        {
            ((SiarLibrary.Web.PrivatePage)Page).RegisterClientScriptBlock("SNCVisualizzaReport('rptIstruttoriaDomande',2,'"
                + "IdBando=" + IdBando + "|stato=" + (!string.IsNullOrEmpty(lstStato.SelectedValue) ? lstStato.SelectedValue :
                    (Page.AppRelativeVirtualPath.IndexOf("Ammissibilita") >= 0 ? "I" : "L"))
                  + (string.IsNullOrEmpty(txtNumero.Text) ? "" : "|IdProgetto=" + txtNumero.Text)
                  + (string.IsNullOrEmpty(lstProvince.SelectedValue) ? "" : "|Provincia=" + lstProvince.SelectedValue)
                  + (string.IsNullOrEmpty(lstOperatore.SelectedValue) ? "" : "|Operatore=" + lstOperatore.SelectedValue)
                  + (string.IsNullOrEmpty(txtCuaa.Text) ? "" : "|Cuaa=" + txtCuaa.Text)
                  + (string.IsNullOrEmpty(txtRagsoc.Text) ? "" : "|Ragsoc=" + txtRagsoc.Text) +
                "');");
        }
    }
}