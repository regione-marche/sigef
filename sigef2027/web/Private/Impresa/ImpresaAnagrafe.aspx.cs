using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.Impresa
{
    public partial class ImpresaAnagrafe : SiarLibrary.Web.ImpresaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "impresa_anagrafe";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            ucImpresaControl.AbilitaModifica = AbilitaModifica;
            ucImpresaControl.AnagrafeEdit = true;
            ucImpresaControl.Impresa = new SiarBLL.ImpresaCollectionProvider().GetById(Azienda.IdImpresa);
            if (Operatore.Utente.Profilo == "Amministratore")
                ucImpresaControl.AnagrafeEdit = true;
        }

        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    tbSituazioneAttuale.Visible = false;
                    #region storico
                    //storico impresa
                    SiarLibrary.ImpresaStoricoCollection storico = new SiarBLL.ImpresaStoricoCollectionProvider().Find(Azienda.IdImpresa);
                    if (storico.Count == 0) dgStoricoImpresa.Titolo = "<b><em>Nessuno storico dell'impresa presente.</em></b>";
                    dgStoricoImpresa.DataSource = storico;
                    dgStoricoImpresa.DataBind();

                    //Conto Corrente 
                    SiarLibrary.ContoCorrenteCollection cc = new SiarBLL.ContoCorrenteCollectionProvider().Find(null, Azienda.IdImpresa, null, null, null, null);
                    if (cc.Count == 0) dgConto.Titolo = "<b><em>Nessun Conto Corrente storicizzato.</em></b>";
                    dgConto.DataSource = cc;
                    dgConto.DataBind();

                    //Rappresentante Legale
                    SiarLibrary.PersoneXImpreseCollection rlegali = new SiarBLL.PersoneXImpreseCollectionProvider().Find(null, null, Azienda.IdImpresa,
                        "R", null, null);
                    if (rlegali.Count == 0) dgPersonale.Titolo = "<b><em>Nessun Rappresentante Legale storicizzato.</em></b>";
                    dgPersonale.DataSource = rlegali;
                    dgPersonale.DataBind();

                    //Sede Legale
                    SiarLibrary.IndirizzarioCollection sedi_legali = new SiarBLL.IndirizzarioCollectionProvider().Find(null, null, Azienda.IdImpresa, "S", null, null);
                    if (sedi_legali.Count == 0) dgSedeLegale.Titolo = "<b><em>Nessuna Sede Legale storicizzata.</em></b>";
                    dgSedeLegale.DataSource = sedi_legali;
                    dgSedeLegale.DataBind();

                    // domicilio
                    SiarLibrary.IndirizzarioCollection domicili = new SiarBLL.IndirizzarioCollectionProvider().Find(null, null, Azienda.IdImpresa, "D", null, null);
                    if (domicili.Count == 0) dgDomicilio.Titolo = "<b><em>Nessun domicilio storicizzato.</em></b>";
                    dgDomicilio.DataSource = domicili;
                    dgDomicilio.DataBind();

                    #endregion
                    break;
                default:
                    tbStorico.Visible = false;
                    break;
            }
            base.OnPreRender(e);
        }
    }
}
