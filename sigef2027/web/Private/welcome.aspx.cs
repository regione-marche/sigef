using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private
{
    public partial class Welcome : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "Welcome";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
                ShowMessage("Autenticazione corretta per l'operatore " + Operatore.Utente.Nominativo);

            //if (Operatore.Utente.Profilo.Equals("Amministratore"))
            //{
            //    divOperatoreAlias.Visible = true;
            //    txtOperatoreAlias.AddJSAttribute("onkeydown", "SNCVolatileZoom(this,event,'SNCVZCercaUtenti');");
            //}
        }

        //protected void btnAlias_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (Operatore.Utente.CodEnte != "%")
        //            throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.UtenteSenzaPermessi);
        //        SiarLibrary.Utenti alias = new SiarBLL.UtentiCollectionProvider().GetById(hdnIdUtenteAlias.Value);
        //        ((SiarLibrary.Web.MasterPage)Master).SetOperatoreAlias(alias);
        //        Session["FUNZIONALITA_OPERATORE"] = null;
        //        Redirect("welcome.aspx");
        //    }
        //    catch (Exception ex) { ShowError(ex); }
        //}

    }
}
