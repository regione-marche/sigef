using System;


namespace web.Private.PDomanda
{
    public partial class ImpresaDescrizione : SiarLibrary.Web.ProgettoPage
    {
        SiarLibrary.Impresa impresa;
        protected void Page_Load(object sender, EventArgs e)
        {
            impresa = new SiarBLL.ImpresaCollectionProvider().GetById(Progetto.IdImpresa);    
        }
      
        protected override void OnPreRender(EventArgs e)
        {
            if (impresa.Presentazione != null) txtNoteLunga.Text = impresa.Presentazione;
            else txtNoteLunga.Text = "Inserire la presentazione...";
            if (impresa.Descrizione != null) txtDescrizioneLunga.Text = impresa.Descrizione;
            else txtDescrizioneLunga.Text = "Inserire la descrizione..."; 
            base.OnPreRender(e);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                impresa.Descrizione = txtDescrizioneLunga.Text;
                impresa.Presentazione = txtNoteLunga.Text;
                new SiarBLL.ImpresaCollectionProvider().Save(impresa);
                ShowMessage("Descrizioni salvate correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}
