using System;
using System.Web.UI;


namespace web.Private.PPagamento
{
    public partial class PianoSviluppo : SiarLibrary.Web.DomandaPagamentoPage
    {
        private const int _anni = 5;        
        private SiarBLL.PianoDiSviluppoDomandaPagamentoCollectionProvider psprovider = new SiarBLL.PianoDiSviluppoDomandaPagamentoCollectionProvider();

        protected void Page_Load(object sender, EventArgs e)
        {
            SiarLibrary.VworkflowPagamentoCollection workflow = new SiarBLL.VworkflowPagamentoCollectionProvider().Find(null, null, null, "Business Plan");
            ucWorkflowPagamento.WorkflowCorrente = workflow[0];            
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scrptblurtxt", "$(document).ready(function() { $('[id*=annoPiano]').blur(function(event) {  controlloAnno(); }); $('[id*=Anno1]').blur(function(event) { calc_totals('Anno1'); }); $('[id*=Anno2]').blur(function(event) { calc_totals('Anno2'); }); $('[id*=Anno3]').blur(function(event) { calc_totals('Anno3'); });$('[id*=Anno4]').blur(function(event) { calc_totals('Anno4'); }); $('[id*=Anno5]').blur(function(event) { calc_totals('Anno5'); });$('[id*=A1]').blur(function(event) { TotaleRiga('A1'); });$('[id*=B1]').blur(function(event) { TotaleRiga('B1'); });$('[id*=B2]').blur(function(event) { TotaleRiga('B2'); });$('[id*=B3]').blur(function(event) { TotaleRiga('B3'); });$('[id*=C1]').blur(function(event) { TotaleRiga('C1'); });$('[id*=C2]').blur(function(event) { TotaleRiga('C2'); });$('[id*=D1]').blur(function(event){TotaleRiga('D1'); });$('[id*=D2]').blur(function(event){TotaleRiga('D2'); });});", true);
        }
        /// <summary>
        /// Periodo (anni) previsto dal piano della copertura finanziaria 
        /// </summary>
        #region Page Events
        protected override void OnPreRender(EventArgs e)
        {
            InitializePianiSviluppo();
            base.OnPreRender(e);
        }
        #endregion
        /// <summary>
        /// Inizializza il piano di sviluppo per il periodo di riferimento
        /// </summary>
        private void InitializePianiSviluppo()
        {
            // Un solo accesso al DB
            SiarLibrary.PianoDiSviluppoDomandaPagamentoCollection psdomanda = psprovider.Find(null, DomandaPagamento.IdDomandaPagamento, Progetto.IdProgetto, null);
            if (psdomanda.Count ==0 && AbilitaModifica) 
            {
                SiarLibrary.PianoDiSviluppoCollection pianiSviluppoXProgetto = new SiarBLL.PianoDiSviluppoCollectionProvider().Find (null, null, Progetto.IdProgetto, null);
                foreach (SiarLibrary.PianoDiSviluppo p in pianiSviluppoXProgetto) 
                {
                    SiarLibrary.PianoDiSviluppoDomandaPagamento pd = new SiarLibrary.PianoDiSviluppoDomandaPagamento();
                    pd.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                    pd.IdProgetto = p.IdProgetto;
                    pd.IdImpresa = p.IdImpresa;
                    pd.Anno =p.Anno;
                    pd.CostoInvestimento = p.CostoInvestimento;
                    pd.MezziPropri = p.MezziPropri;
                    pd.RisorseTerzi =p.RisorseTerzi;
                    pd.ContributiPubblici = p.ContributiPubblici;
                    pd.SpeseGestione = p.SpeseGestione;
                    pd.RimborsoDebito =p.RimborsoDebito;
                    pd.EntrataGestione = p.EntrataGestione;
                    pd.AltreCoperture = p.AltreCoperture;
                    psprovider.Save(pd);
                    psdomanda.Add(pd);
                }
                psdomanda.Sort("Anno");
            }
            if (psdomanda != null && psdomanda.Count > 0)
            {
                decimal A1 = 0,
                        B1 = 0, B2 = 0, B3 = 0,
                        C1 = 0, C2 = 0, D1 = 0,
                        D2 = 0, TotFabb = 0,
                        TotCop = 0, TotSaldoNetto = 0;
                int i = 1;
                foreach (SiarLibrary.PianoDiSviluppoDomandaPagamento piano_sviluppo in psdomanda)
                {
                    ((SiarLibrary.Web.TextBox)(tbValutazione.FindControl("txtannoPiano" + i))).Text = piano_sviluppo.Anno.ToString();
                    ((SiarLibrary.Web.Hidden)(tbValutazione.FindControl("hdnIdPiano" + i))).Text = piano_sviluppo.IdPiano.ToString();
                    ((SiarLibrary.Web.CurrencyBox)(tbValutazione.FindControl("txtA1Anno" + i))).Text = piano_sviluppo.CostoInvestimento.ToString();
                    ((SiarLibrary.Web.CurrencyBox)(tbValutazione.FindControl("txtB1Anno" + i))).Text = piano_sviluppo.MezziPropri.ToString();
                    ((SiarLibrary.Web.CurrencyBox)(tbValutazione.FindControl("txtB2Anno" + i))).Text = piano_sviluppo.RisorseTerzi.ToString();
                    ((SiarLibrary.Web.CurrencyBox)(tbValutazione.FindControl("txtB3Anno" + i))).Text = piano_sviluppo.ContributiPubblici.ToString();
                    ((SiarLibrary.Web.CurrencyBox)(tbValutazione.FindControl("txtC1Anno" + i))).Text = piano_sviluppo.SpeseGestione.ToString();
                    ((SiarLibrary.Web.CurrencyBox)(tbValutazione.FindControl("txtC2Anno" + i))).Text = piano_sviluppo.RimborsoDebito.ToString();
                    ((SiarLibrary.Web.CurrencyBox)(tbValutazione.FindControl("txtD1Anno" + i))).Text = piano_sviluppo.EntrataGestione.ToString();
                    ((SiarLibrary.Web.CurrencyBox)(tbValutazione.FindControl("txtD2Anno" + i))).Text = piano_sviluppo.AltreCoperture.ToString();

                    // E) Totale fabbisogno
                    decimal TotaleFabbisogno = piano_sviluppo.CostoInvestimento.Value
                                               + piano_sviluppo.SpeseGestione.Value
                                               + piano_sviluppo.RimborsoDebito.Value;

                    ((SiarLibrary.Web.CurrencyBox)(tbValutazione.FindControl("txtEAnno" + i))).Text = TotaleFabbisogno.ToString();

                    // F) Totale Copertura
                    decimal TotaleCopertura = piano_sviluppo.MezziPropri.Value
                                             + piano_sviluppo.RisorseTerzi.Value
                                             + piano_sviluppo.ContributiPubblici.Value
                                             + piano_sviluppo.EntrataGestione.Value
                                             + piano_sviluppo.AltreCoperture.Value;

                    ((SiarLibrary.Web.CurrencyBox)(tbValutazione.FindControl("txtFAnno" + i))).Text = TotaleCopertura.ToString();

                    // I) Saldo netto
                    decimal SaldoNetto = TotaleCopertura - TotaleFabbisogno;

                    ((SiarLibrary.Web.CurrencyBox)(tbValutazione.FindControl("txtIAnno" + i))).Text = SaldoNetto.ToString();

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
        }
        /// <summary>
        /// Salva il piano di sviluppo
        /// </summary>
        private void SavePianiSviluppo()
        {
            // Un solo accesso al DB
           
            SiarLibrary.PianoDiSviluppoDomandaPagamentoCollection piano_pag = psprovider.Find(null, DomandaPagamento.IdDomandaPagamento, Progetto.IdProgetto, null);
            psprovider.DbProviderObj.BeginTran();
            for (int i = 1; i <= _anni; i++)
            {
                 if (!string.IsNullOrEmpty(((SiarLibrary.Web.TextBox)(tbValutazione.FindControl("txtannoPiano" + i))).Text))
                {
                    int anno = Convert.ToInt32(((SiarLibrary.Web.TextBox)(tbValutazione.FindControl("txtannoPiano" + i))).Text);
                    SiarLibrary.NullTypes.IntNT idPiano;
                    SiarLibrary.PianoDiSviluppoDomandaPagamento piano_sviluppo;
                    if (!string.IsNullOrEmpty(((SiarLibrary.Web.Hidden)(tbValutazione.FindControl("hdnIdPiano" + i))).Text))
                    {
                        // Seleziono il piano di sviluppo relativo ad un anno tra quelli disponibili per il progetto
                        idPiano = Convert.ToInt32(((SiarLibrary.Web.Hidden)(tbValutazione.FindControl("hdnIdPiano" + i))).Text);
                        piano_sviluppo = piano_pag.SubSelect(idPiano, null, null, null, Progetto.IdProgetto, null, null, null, null, null, null, null, null)[0];
                    }
                    else piano_sviluppo = new SiarLibrary.PianoDiSviluppoDomandaPagamento();

                    piano_sviluppo.Anno = anno;
                    piano_sviluppo.IdProgetto = Progetto.IdProgetto;
                    piano_sviluppo.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                    piano_sviluppo.IdImpresa = Progetto.IdImpresa;

                    piano_sviluppo.CostoInvestimento = Convert.ToDecimal(((SiarLibrary.Web.CurrencyBox)(tbValutazione.FindControl("txtA1Anno" + i))).Text);
                    piano_sviluppo.MezziPropri = Convert.ToDecimal(((SiarLibrary.Web.CurrencyBox)(tbValutazione.FindControl("txtB1Anno" + i))).Text);
                    piano_sviluppo.RisorseTerzi = Convert.ToDecimal(((SiarLibrary.Web.CurrencyBox)(tbValutazione.FindControl("txtB2Anno" + i))).Text);
                    piano_sviluppo.ContributiPubblici = Convert.ToDecimal(((SiarLibrary.Web.CurrencyBox)(tbValutazione.FindControl("txtB3Anno" + i))).Text);
                    piano_sviluppo.SpeseGestione = Convert.ToDecimal(((SiarLibrary.Web.CurrencyBox)(tbValutazione.FindControl("txtC1Anno" + i))).Text);
                    piano_sviluppo.RimborsoDebito = Convert.ToDecimal(((SiarLibrary.Web.CurrencyBox)(tbValutazione.FindControl("txtC2Anno" + i))).Text);
                    piano_sviluppo.EntrataGestione = Convert.ToDecimal(((SiarLibrary.Web.CurrencyBox)(tbValutazione.FindControl("txtD1Anno" + i))).Text);
                    piano_sviluppo.AltreCoperture = Convert.ToDecimal(((SiarLibrary.Web.CurrencyBox)(tbValutazione.FindControl("txtD2Anno" + i))).Text);

                    psprovider.Save(piano_sviluppo);
                }
            }
       
            ShowMessage("Il piano della copertura finanziaria è stato salvato correttamente.");
            psprovider.DbProviderObj.Commit();
        }
        #region Events Handling
        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                SavePianiSviluppo();
            }
            catch
            {
                psprovider.DbProviderObj.Rollback();
                ShowError("Attenzione!", "Impossibile salvare il piano di sviluppo.");
            }
        }
        protected void btnBack_Click(object sender, EventArgs e){Redirect("BusinessPlan.aspx");}
        #endregion
    }
}
