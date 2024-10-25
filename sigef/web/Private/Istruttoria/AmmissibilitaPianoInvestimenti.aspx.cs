using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI;


namespace web.Private.Istruttoria
{
    public partial class AmmissibilitaPianoInvestimenti : SiarLibrary.Web.IstruttoriaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "ammissibilita_domande";
            base.OnPreInit(e);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            int iddomanda;
            if (int.TryParse(Request.QueryString["iddom"], out iddomanda))
            {
                ucInfoDomanda.Progetto = new SiarBLL.ProgettoCollectionProvider().GetById(iddomanda);
                if (AbilitaModifica)
                {
                    if (ucInfoDomanda.Progetto.CodStato != "I" && !ucInfoDomanda.DomandaInRiesame && !ucInfoDomanda.DomandaInRevisione
                        && !ucInfoDomanda.DomandaInRicorso) AbilitaModifica = false;
                    else if (new SiarBLL.CollaboratoriXBandoCollectionProvider().Find(Bando.IdBando, ucInfoDomanda.Progetto.IdProgetto,
                            Operatore.Utente.IdUtente, null, true).Count == 0) AbilitaModifica = false;
                }
            }

            //Bottone indietro
            HtmlInputButton btnback = new HtmlInputButton();
            btnback.Attributes.Add("class", "Button");
            string url_indietro = "ChecklistAmmissibilita.aspx?iddom=" + ucInfoDomanda.Progetto.IdProgetto.ToString();
            btnback.Attributes.Add("onclick", "location='" + url_indietro + "'");
            btnback.Style.Add("width", "120px");
            btnback.Value = "Indietro";
            tdButtoniPage.Controls.Add(btnback);

            SiarLibrary.Web.Button btnEstrai = new SiarLibrary.Web.Button();
            btnEstrai.Style.Add("margin-right", "20px");
            btnEstrai.Text = "Estrai in XLS";
            btnEstrai.Width = new Unit(140);
            btnEstrai.CausesValidation = false;
            btnEstrai.Click += new EventHandler(btnEstrai_Click);
            tdButtoniPage.Controls.Add(btnEstrai);

            string nascodiDiv = "";
            nascodiDiv = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_NascondiPInv(ucInfoDomanda.Progetto.IdBando);
            if (nascodiDiv == "True")
            {
                PianoInvestimentiAggregazione.Visible = false;
                PianoInvestimentiCodifica.Visible = false;
            }

            int idIntervento = ucPianoInvestimenti.GetIntervento();
            PianoInvestimentiCodifica.id_intervento = idIntervento;
            PianoInvestimentiAggregazione.id_intervento = idIntervento;
            PianoInvestimentiIntervento.id_intervento = idIntervento;
        }

        protected void btnEstrai_Click(object sender, EventArgs e)
        {
            try
            {
                string parametri = "";
                parametri += "IdProgetto=" + ucInfoDomanda.Progetto.IdProgetto;
                parametri += "|CodQuery=" + "PIANO_INVESTIMENTI_ISTRUTTORIA";

                string jsFunction = "SNCVisualizzaReport('rptPianoInvestimenti', 2, '" + parametri + "');";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "myJsFn", jsFunction, true);
            }
            catch (Exception ex) { ((SiarLibrary.Web.PrivatePage)Page).ShowError(ex); }
        }
    }
}
