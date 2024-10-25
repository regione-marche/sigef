using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace web.Private.Impresa
{
    public partial class ValutazionePianoSviluppo : SiarLibrary.Web.ImpresaPage
    {
        /// <summary>
        /// Periodo (anni) previsto dal piano della copertura finanziaria 
        /// </summary>
        private const int _anni = 5;
        private SiarBLL.PianoDiSviluppoCollectionProvider pianoSviluppoCollectionProvider = new SiarBLL.PianoDiSviluppoCollectionProvider();

        #region Page Events

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "impresa_business_plan";
            base.OnPreInit(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            #region Settaggio degli attributi 'onblur' alle CurrencyBox per il calcolo automatico durante l'inserimento dei valori da parte dell'utente

            foreach (Control control in TAB1.Controls)
            {
                if (control is SiarLibrary.Web.CurrencyBox)
                {
                    SiarLibrary.Web.CurrencyBox currency_box = control as SiarLibrary.Web.CurrencyBox;
                    HtmlInputControl inputControl = (HtmlInputControl)currency_box.Controls[0];

                    // funzione javascript calc_totals('AnnoX');
                    inputControl.Attributes.Add("onblur", "calc_totals('" + inputControl.ID.Substring(inputControl.ID.IndexOf("Anno")).Replace("_text", string.Empty) + "')");
                }
            }

            #endregion

            InitializePianiSviluppo();

            base.OnPreRender(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Versione deploy
            if (Azienda == null) Redirect("ImpresaFind.aspx");

            if (!IsPostBack) hdnCurrentYear.Value = DateTime.Now.Year.ToString();
        }

        #endregion

        /// <summary>
        /// Inizializza il piano di sviluppo per il periodo di riferimento
        /// </summary>
        private void InitializePianiSviluppo()
        {
            // Un solo accesso al DB
            SiarLibrary.PianoDiSviluppoCollection pianiSviluppoXProgetto = pianoSviluppoCollectionProvider.Find(null, null, null, Azienda.IdImpresa);
            pianiSviluppoXProgetto = pianiSviluppoXProgetto.FiltroAttuale(true);

            for (int i = 1; i <= _anni; i++)
            {
                int anno = Convert.ToInt32(hdnCurrentYear.Value) + i; // Dall'anno successivo in avanti

                // Inizializzazione Label Anno
                ((SiarLibrary.Web.Label)(TAB1.FindControl("lblAnno" + i))).Text = anno.ToString();

                // Seleziono il piano di sviluppo relativo ad un anno tra quelli disponibili per il progetto
                SiarLibrary.PianoDiSviluppoCollection piano_sviluppoColl = pianiSviluppoXProgetto.SubSelect(null, anno, Azienda.IdImpresa, null, null, null, null, null, null, null, null, null);
                if (piano_sviluppoColl.Count > 0)
                {
                    SiarLibrary.PianoDiSviluppo piano_sviluppo = piano_sviluppoColl[0];

                    ((SiarLibrary.Web.CurrencyBox)(TAB1.FindControl("txtA1Anno" + i))).Text = piano_sviluppo.CostoInvestimento.ToString();
                    ((SiarLibrary.Web.CurrencyBox)(TAB1.FindControl("txtB1Anno" + i))).Text = piano_sviluppo.MezziPropri.ToString();
                    ((SiarLibrary.Web.CurrencyBox)(TAB1.FindControl("txtB2Anno" + i))).Text = piano_sviluppo.RisorseTerzi.ToString();
                    ((SiarLibrary.Web.CurrencyBox)(TAB1.FindControl("txtB3Anno" + i))).Text = piano_sviluppo.ContributiPubblici.ToString();
                    ((SiarLibrary.Web.CurrencyBox)(TAB1.FindControl("txtC1Anno" + i))).Text = piano_sviluppo.SpeseGestione.ToString();
                    ((SiarLibrary.Web.CurrencyBox)(TAB1.FindControl("txtC2Anno" + i))).Text = piano_sviluppo.RimborsoDebito.ToString();
                    ((SiarLibrary.Web.CurrencyBox)(TAB1.FindControl("txtD1Anno" + i))).Text = piano_sviluppo.EntrataGestione.ToString();
                    ((SiarLibrary.Web.CurrencyBox)(TAB1.FindControl("txtD2Anno" + i))).Text = piano_sviluppo.AltreCoperture.ToString();

                    // E) Totale fabbisogno
                    decimal TotaleFabbisogno = piano_sviluppo.CostoInvestimento.Value
                                               + piano_sviluppo.SpeseGestione.Value
                                               + piano_sviluppo.RimborsoDebito.Value;

                    ((SiarLibrary.Web.CurrencyBox)(TAB1.FindControl("txtEAnno" + i))).Text = TotaleFabbisogno.ToString();

                    // F) Totale Copertura
                    decimal TotaleCopertura = piano_sviluppo.MezziPropri.Value
                                             + piano_sviluppo.RisorseTerzi.Value
                                             + piano_sviluppo.ContributiPubblici.Value
                                             + piano_sviluppo.EntrataGestione.Value
                                             + piano_sviluppo.AltreCoperture.Value;

                    ((SiarLibrary.Web.CurrencyBox)(TAB1.FindControl("txtFAnno" + i))).Text = TotaleCopertura.ToString();

                    // I) Saldo netto
                    decimal SaldoNetto = TotaleCopertura - TotaleFabbisogno;

                    ((SiarLibrary.Web.CurrencyBox)(TAB1.FindControl("txtIAnno" + i))).Text = SaldoNetto.ToString();
                }
            }
        }

        /// <summary>
        /// Salva il piano di sviluppo
        /// </summary>
        private void SavePianiSviluppo()
        {
            // Un solo accesso al DB
            SiarLibrary.PianoDiSviluppoCollection pianiSviluppoXProgetto = pianoSviluppoCollectionProvider.Find(null, null, null, Azienda.IdImpresa);
            pianiSviluppoXProgetto = pianiSviluppoXProgetto.FiltroAttuale(true);            

            for (int i = 1; i <= _anni; i++)
            {
                int anno = Convert.ToInt32(((SiarLibrary.Web.Label)(TAB1.FindControl("lblAnno" + i))).Text);

                // Seleziono il piano di sviluppo relativo ad un anno tra quelli disponibili per il progetto
                SiarLibrary.PianoDiSviluppoCollection piano_sviluppoColl = pianiSviluppoXProgetto.SubSelect(null, anno, Azienda.IdImpresa, null, null, null, null, null, null, null, null, null);
                SiarLibrary.PianoDiSviluppo piano_sviluppo;

                if (piano_sviluppoColl.Count == 0) piano_sviluppo = new SiarLibrary.PianoDiSviluppo();
                else piano_sviluppo = piano_sviluppoColl[0];

                piano_sviluppo.Anno = anno;
                piano_sviluppo.IdImpresa = Azienda.IdImpresa;
                piano_sviluppo.CostoInvestimento = Convert.ToDecimal(((SiarLibrary.Web.CurrencyBox)(TAB1.FindControl("txtA1Anno" + i))).Text);
                piano_sviluppo.MezziPropri = Convert.ToDecimal(((SiarLibrary.Web.CurrencyBox)(TAB1.FindControl("txtB1Anno" + i))).Text);
                piano_sviluppo.RisorseTerzi = Convert.ToDecimal(((SiarLibrary.Web.CurrencyBox)(TAB1.FindControl("txtB2Anno" + i))).Text);
                piano_sviluppo.ContributiPubblici = Convert.ToDecimal(((SiarLibrary.Web.CurrencyBox)(TAB1.FindControl("txtB3Anno" + i))).Text);
                piano_sviluppo.SpeseGestione = Convert.ToDecimal(((SiarLibrary.Web.CurrencyBox)(TAB1.FindControl("txtC1Anno" + i))).Text);
                piano_sviluppo.RimborsoDebito = Convert.ToDecimal(((SiarLibrary.Web.CurrencyBox)(TAB1.FindControl("txtC2Anno" + i))).Text);
                piano_sviluppo.EntrataGestione = Convert.ToDecimal(((SiarLibrary.Web.CurrencyBox)(TAB1.FindControl("txtD1Anno" + i))).Text);
                piano_sviluppo.AltreCoperture = Convert.ToDecimal(((SiarLibrary.Web.CurrencyBox)(TAB1.FindControl("txtD2Anno" + i))).Text);

                pianoSviluppoCollectionProvider.Save(piano_sviluppo);
            }

            ShowMessage("Il piano della copertura finanziaria è stato salvato correttamente.");
        }

        #region Events Handling

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            SavePianiSviluppo();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Redirect("ImpresaBusinessPlan.aspx");
        }

        protected void lnkPrev_Click(object sender, EventArgs e)
        {
            int prevYear = (Convert.ToInt32(hdnCurrentYear.Value) - 1);
            hdnCurrentYear.Value = prevYear.ToString();
        }

        protected void lnkNext_Click(object sender, EventArgs e)
        {
            int nextYear = (Convert.ToInt32(hdnCurrentYear.Value) + 1);
            hdnCurrentYear.Value = nextYear.ToString();
        }

        #endregion

    }
}
