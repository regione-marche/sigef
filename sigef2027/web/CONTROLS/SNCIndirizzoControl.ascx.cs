using System;

namespace web.CONTROLS
{
    public partial class SNCIndirizzoControl : System.Web.UI.UserControl
    {
        public SiarLibrary.NullTypes.IntNT IdIndirizzo
        {
            get { return new SiarLibrary.NullTypes.IntNT(hdnIdIndirizzo.Value); }
            set { hdnIdIndirizzo.Value = value; }
        }

        private bool _obbligatorio = false;
        public bool Obbligatorio { set { _obbligatorio = value; } }

        SiarBLL.IndirizzoCollectionProvider indirizzo_provider = new SiarBLL.IndirizzoCollectionProvider();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            int id_indirizzo;
            if (int.TryParse(hdnIdIndirizzo.Value, out id_indirizzo))
            {
                SiarLibrary.Indirizzo i = indirizzo_provider.GetById(id_indirizzo);
                if (i != null)
                {
                    txtSNCINDVia.Text = i.Via;
                    txtSNCINDLocalita.Text = i.Localita;
                    if (i.IdComune != null)
                    {
                        SiarLibrary.Comuni c = new SiarBLL.ComuniCollectionProvider().GetById(i.IdComune);
                        if (c != null)
                        {
                            ucSNCComuniControl.IdComune = i.IdComune;
                            ucSNCComuniControl.Denominazione = c.Denominazione;
                            ucSNCComuniControl.Cap = c.Cap;
                            ucSNCComuniControl.Provincia = c.Sigla;
                        }
                    }
                }
            }
            base.OnPreRender(e);
        }

        public void SalvaIndirizzo()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSNCINDVia.Text) && ucSNCComuniControl.IdComune != null)
                {
                    SiarLibrary.IndirizzoCollection indirizzi_esistenti = indirizzo_provider.Find(null, ucSNCComuniControl.IdComune, txtSNCINDVia.Text);
                    if (indirizzi_esistenti.Count > 0) hdnIdIndirizzo.Value = indirizzi_esistenti[0].IdIndirizzo;
                    else
                    {
                        SiarLibrary.Indirizzo i = new SiarLibrary.Indirizzo();
                        i.Via = txtSNCINDVia.Text;
                        i.Localita = txtSNCINDLocalita.Text;
                        i.IdComune = ucSNCComuniControl.IdComune;
                        indirizzo_provider.Save(i);
                        hdnIdIndirizzo.Value = i.IdIndirizzo;
                    }
                }
                else if (_obbligatorio) throw new Exception("E' necessario specificare sia la via che il comune.");
            }
            catch { throw; }
        }
    }
}