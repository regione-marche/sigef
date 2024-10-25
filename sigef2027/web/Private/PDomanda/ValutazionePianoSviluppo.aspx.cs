using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace web.Private.PDomanda
{
    public partial class ValutazionePianoSviluppo : SiarLibrary.Web.ProgettoPage
    {
        /// <summary>
        /// Periodo (anni) previsto dal piano della copertura finanziaria 
        /// </summary>
        private const int _anni = 5;
        private SiarBLL.PianoDiSviluppoCollectionProvider pianoSviluppoCollectionProvider = new SiarBLL.PianoDiSviluppoCollectionProvider();

        #region Page Events

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
                    inputControl.Attributes.Add("onblur", "calc_totals('" + inputControl.ID.Substring(inputControl.ID.IndexOf("Anno")).Replace("_text", string.Empty) + "');TotaleRiga('" + inputControl.ID.Substring(0, inputControl.ID.IndexOf("Anno")).Replace("txt", string.Empty) + "')");
                }
                else
                {
                    if (control is SiarLibrary.Web.TextBox)
                    {
                        SiarLibrary.Web.TextBox text_box = control as SiarLibrary.Web.TextBox;
                        HtmlInputControl inputControl = (HtmlInputControl)text_box.Controls[0];

                        // funzione javascript controlloAnno('AnnoX');
                        inputControl.Attributes.Add("onblur", "controlloAnno('" + inputControl.ID.Substring(inputControl.ID.IndexOf("anno")).Replace("_text", string.Empty) + "',event)");
                    }

                }
            }

            #endregion

            InitializePianiSviluppo();

            base.OnPreRender(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Versione deploy
            if (Progetto == null) Redirect("RicercaDomanda.aspx", "Per proseguire è necessario selezionare la domanda.", true);
        }

        #endregion

        /// <summary>
        /// Inizializza il piano di sviluppo per il periodo di riferimento
        /// </summary>
        private void InitializePianiSviluppo()
        {
            // Un solo accesso al DB
            SiarLibrary.PianoDiSviluppoCollection pianiSviluppoXProgetto = pianoSviluppoCollectionProvider.Find(null, null, Progetto.IdProgetto, null);
            try
            {
                if (pianiSviluppoXProgetto.Count > 5)
                { throw new Exception("Attenzione! Si è verificato un errore. Se la situazione persiste si prega<br />di segnalare il problema all'helpdesk."); }


                pianiSviluppoXProgetto.Sort("Anno");
                decimal A1 = 0,
                     B1 = 0, B2 = 0, B3 = 0,
                     C1 = 0, C2 = 0, D1 = 0,
                     D2 = 0, TotFabb = 0,
                     TotCop = 0, TotSaldoNetto = 0;
                int i = 1;
                foreach (SiarLibrary.PianoDiSviluppo piano_sviluppo in pianiSviluppoXProgetto)
                {
                    ((SiarLibrary.Web.TextBox)(TAB1.FindControl("txtanno" + i))).Text = piano_sviluppo.Anno.ToString();

                    ((SiarLibrary.Web.Hidden)(TAB1.FindControl("hdnIdPiano" + i))).Text = piano_sviluppo.IdPiano.ToString();
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

                    //TOTALI RIGA
                    A1 += piano_sviluppo.CostoInvestimento;
                    B1 += piano_sviluppo.MezziPropri;
                    B2 += piano_sviluppo.RisorseTerzi;
                    B3 += piano_sviluppo.ContributiPubblici;
                    C1 += piano_sviluppo.SpeseGestione;
                    C2 += piano_sviluppo.RimborsoDebito;
                    D1 += piano_sviluppo.EntrataGestione;
                    D2 += piano_sviluppo.AltreCoperture;
                    TotFabb += TotaleFabbisogno;
                    TotCop += TotaleCopertura;
                    TotSaldoNetto += SaldoNetto;
                    i++;
                }
                //}
                lblA1Anno.Text = SiarLibrary.DbStaticProvider.getCurrencyFormat(A1.ToString());
                lblB1Anno.Text = SiarLibrary.DbStaticProvider.getCurrencyFormat(B1.ToString());
                lblB2Anno.Text = SiarLibrary.DbStaticProvider.getCurrencyFormat(B2.ToString());
                lblB3Anno.Text = SiarLibrary.DbStaticProvider.getCurrencyFormat(B3.ToString());
                lblC1Anno.Text = SiarLibrary.DbStaticProvider.getCurrencyFormat(C1.ToString());
                lblC2Anno.Text = SiarLibrary.DbStaticProvider.getCurrencyFormat(C2.ToString());
                lblD1Anno.Text = SiarLibrary.DbStaticProvider.getCurrencyFormat(D1.ToString());
                lblD2Anno.Text = SiarLibrary.DbStaticProvider.getCurrencyFormat(D2.ToString());

                lblEAnno.Text = SiarLibrary.DbStaticProvider.getCurrencyFormat(TotFabb.ToString());
                lblFAnno.Text = SiarLibrary.DbStaticProvider.getCurrencyFormat(TotCop.ToString());
                lblIAnno.Text = SiarLibrary.DbStaticProvider.getCurrencyFormat(TotSaldoNetto.ToString());

            }
            catch (Exception ex) {  btnSalva.Enabled = false; ShowError(ex); }
        }

        /// <summary>
        /// Salva il piano di sviluppo
        /// </summary>
        private void SavePianiSviluppo()
        {
            // Un solo accesso al DB
            SiarLibrary.PianoDiSviluppoCollection pianiSviluppoXProgetto = pianoSviluppoCollectionProvider.Find(null, null, Progetto.IdProgetto, null);
            pianoSviluppoCollectionProvider.DbProviderObj.BeginTran();
            for (int i = 1; i <= _anni; i++)
            {
                //int anno = Convert.ToInt32(((SiarLibrary.Web.Label)(TAB1.FindControl("lblAnno" + i))).Text);
                if (!string.IsNullOrEmpty(((SiarLibrary.Web.TextBox)(TAB1.FindControl("txtanno" + i))).Text))
                {
                    int anno = Convert.ToInt32(((SiarLibrary.Web.TextBox)(TAB1.FindControl("txtanno" + i))).Text);
                    SiarLibrary.NullTypes.IntNT idPiano;
                    SiarLibrary.PianoDiSviluppo piano_sviluppo;
                    if (!string.IsNullOrEmpty(((SiarLibrary.Web.Hidden)(TAB1.FindControl("hdnIdPiano" + i))).Text))
                    {
                        // Seleziono il piano di sviluppo relativo ad un anno tra quelli disponibili per il progetto

                        idPiano = Convert.ToInt32(((SiarLibrary.Web.Hidden)(TAB1.FindControl("hdnIdPiano" + i))).Text);
                        piano_sviluppo = pianiSviluppoXProgetto.SubSelect(idPiano, null, null, Progetto.IdProgetto, null, null, null, null, null, null, null, null)[0];
                    }
                    else piano_sviluppo = new SiarLibrary.PianoDiSviluppo();

                    piano_sviluppo.Anno = anno;
                    piano_sviluppo.IdProgetto = Progetto.IdProgetto;
                    piano_sviluppo.IdImpresa = Progetto.IdImpresa;

                    // Valorizzare ID_IMPRESA!!!
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
            }
            new SiarBLL.ProgettoCollectionProvider(pianoSviluppoCollectionProvider.DbProviderObj).
                AggiornaProgetto(Progetto, Operatore.Utente.IdUtente);
            ShowMessage("Il piano della copertura finanziaria è stato salvato correttamente.");
            pianoSviluppoCollectionProvider.DbProviderObj.Commit();
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                SavePianiSviluppo();
            }
            catch
            {
                pianoSviluppoCollectionProvider.DbProviderObj.Rollback();
                ShowError("Impossibile salvare il piano di sviluppo.");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Redirect("BusinessPlan.aspx");
        }
    }
}
