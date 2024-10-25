using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarLibrary;
using SiarBLL;
using SiarLibrary.Extensions;

namespace web.Private.PPagamento
{
    public partial class VisualizzaModifica : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "progetto_gestione";
            if (Operatore != null && Operatore.Utente.CodTipoEnte.FindValueIn("RM", "AdC", "%"))
                FunzioneMenu = "igestione_lavori";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var modifica_dati = (ModificaDatiGenerale)Session["_modificaDati"];
            ucVisualizzaModifica.ModificaDati = modifica_dati;
        }
    }
}