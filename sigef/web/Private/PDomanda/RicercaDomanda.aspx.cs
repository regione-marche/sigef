using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using SiarLibrary.Extensions;
using web.CONTROLS;

namespace web.Private.PDomanda
{
    public partial class RicercaDomanda : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "progetto_ricerca";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Form.DefaultButton = btnCerca.UniqueID;
            Form.DefaultFocus = txtNumDomanda.ClientID;
        }

        protected override void OnPreRender(EventArgs e)
        {
            int id_progetto;
            if (!IsPostBack) tdDomanda.InnerHtml = "<div class=testo_pagina><b>Ricercare una domanda.</b></div>";
            else if (int.TryParse(txtNumDomanda.Text, out id_progetto))
            {
                SiarBLL.ProgettoCollectionProvider progProvider = new SiarBLL.ProgettoCollectionProvider();
                SiarLibrary.Progetto p = null;
                try
                {
                    p = progProvider.GetById(id_progetto);
                    if (p != null && p.IdProgIntegrato != null && p.IdProgIntegrato != p.IdProgetto)
                        p = progProvider.GetById(p.IdProgIntegrato);
                    if (p == null || p.FlagPreadesione) throw new Exception("Nessuna domanda trovata. Il codice inserito potrebbe essere errato.");

                    // controllo i permessi dell'operatore
                    int risultato = SiarLibrary.DbStaticProvider.GetPermessiOperatoreSuProgetto(p.IdProgetto, Operatore.Utente.IdUtente,
                        progProvider.DbProviderObj);
                    if (risultato == 0) throw new Exception("Nessuna domanda trovata. Il codice inserito potrebbe essere errato.");

                    AbilitaModifica = (risultato == 2);
                    //if (p.Segnatura == null && risultato == 1) ShowError("L'utente è abilitato alla sola visualizzazione della domanda.");
                    SiarLibrary.Bando b = new SiarBLL.BandoCollectionProvider().GetById(p.IdBando);

                    Control c = LoadControl("../../CONTROLS/DatiDomanda.ascx");
                    System.Type t = c.GetType();
                    t.GetProperty("Progetto").SetValue(c, p, null);
                    t.GetProperty("Bando").SetValue(c, b, null);
                    tdDomanda.Controls.Add(c);
                    Session["_progetto"] = p;
                    Session["_bando"] = b;

                    // per controllare gli allegati devo prendere la segnatura della firma di presentazione
                    SiarLibrary.ProgettoStoricoCollection psc = new SiarBLL.ProgettoStoricoCollectionProvider().Find(p.IdProgetto, "L", null);
                    
                    bool allegatiProtocollatiOk = true;

                    if (psc.Count > 0)
                    {
                        SiarLibrary.ProgettoStorico s = psc[0];
                        //SiarLibrary.AllegatiProtocollatiCollection allegati = new SiarBLL.AllegatiProtocollatiCollectionProvider().Find(p.IdProgetto, null, null, null, null, null, null, null);
                        //int numeroAllegati = allegati.Count;
                        //allegatiProtocollatiOk = checkAllegatiProtocollati(s, numeroAllegati);   
                        allegatiProtocollatiOk = new SiarBLL.AllegatiProtocollatiCollectionProvider().CheckAllegatiProtocollati(SiarBLL.AllegatiProtocollatiCollectionProvider.TipoCheck.Progetto, s.IdProgetto, s.Segnatura);
                    }

                    #region pulsanti bando

                    if (p.CodStato != "P" && Operatore.Utente.CodTipoEnte.FindValueIn("RM", "%", "AdC"))
                    {
                        
                        if (allegatiProtocollatiOk)
                        {
                            HtmlInputButton btnRiepilogoBando = new HtmlInputButton();
                            btnRiepilogoBando.Value = "Sezione Dettaglio Bando";
                            btnRiepilogoBando.Attributes.Add("class", "Button");
                            btnRiepilogoBando.Attributes.Add("onclick", "location='../psr/bandi/dettaglio.aspx'");
                            btnRiepilogoBando.Style.Add("margin-right", "20px");
                            btnRiepilogoBando.Style.Add("width", "200px");

                            HtmlInputButton btnIstruttoriaBando = new HtmlInputButton();
                            btnIstruttoriaBando.Value = "Sezione Istruttoria Bando";
                            btnIstruttoriaBando.Attributes.Add("class", "Button");
                            btnIstruttoriaBando.Attributes.Add("onclick", "location='../istruttoria/statistiche.aspx'");
                            btnIstruttoriaBando.Style.Add("margin-right", "20px");
                            btnIstruttoriaBando.Style.Add("width", "200px");

                            HtmlInputButton btnIstruttoriaDomandePagamento = new HtmlInputButton();
                            btnIstruttoriaDomandePagamento.Value = "Checklist di istruttoria ammissibilità";
                            btnIstruttoriaDomandePagamento.Attributes.Add("class", "Button");
                            btnIstruttoriaDomandePagamento.Attributes.Add("onclick", "location='../istruttoria/ChecklistAmmissibilita.aspx?iddom="
                                + p.IdProgetto + "'");
                            btnIstruttoriaDomandePagamento.Style.Add("width", "230px");

                            tdPulsantiBando.Controls.Add(btnRiepilogoBando);
                            tdPulsantiBando.Controls.Add(btnIstruttoriaBando);
                            tdPulsantiBando.Controls.Add(btnIstruttoriaDomandePagamento);
                            tdPulsantiBando.Style.Add("height", "50px");
                        }
                    }

                    if (b.AbilitaValutazione && (p.CodStato == "I" || ((DatiDomanda)c).DomandaInRevisione || ((DatiDomanda)c).DomandaInRicorso || ((DatiDomanda)c).DomandaInRiesame)  && (Operatore.Utente.CodTipoEnte.FindValueIn("RM", "%", "AdC") ||
                        Operatore.Utente.Profilo == "Membro del comitato di valutazione"))
                    {
                        HtmlInputButton btnIValutazioneProgetto = new HtmlInputButton();
                        btnIValutazioneProgetto.Value = "Valutazione bando";
                        btnIValutazioneProgetto.Attributes.Add("class", "Button");
                        btnIValutazioneProgetto.Attributes.Add("onclick", "location='../istruttoria/Valutazione.aspx?iddom="
                            + p.IdProgetto + "&idb=" + p.IdBando + "'");
                        btnIValutazioneProgetto.Style.Add("width", "200px");
                        btnIValutazioneProgetto.Style.Add("margin-top", "10px");
                        btnIValutazioneProgetto.Style.Add("margin-left", "-30px");

                        tdPulsantiBando.Controls.Add(btnIValutazioneProgetto);
                        tdPulsantiBando.Style.Add("height", "50px");
                    }

                    if (((p.CodStato == "L") || (p.CodStato == "I")) && !allegatiProtocollatiOk)
                    {
                        HtmlInputButton btnProtocollaAllegati = new HtmlInputButton();
                        btnProtocollaAllegati.Value = "Protocolla gli allegati";
                        btnProtocollaAllegati.Attributes.Add("class", "Button");
                        btnProtocollaAllegati.Attributes.Add("onclick", "location='../PDomanda/RiepilogoDomanda.aspx'");
                        btnProtocollaAllegati.Style.Add("margin-right", "20px");
                        btnProtocollaAllegati.Style.Add("width", "200px");

                        tdPulsantiBando.Controls.Add(btnProtocollaAllegati);
                        tdPulsantiBando.Style.Add("height", "50px");
                    }

                    #endregion

                    if (p.OrdineFase != null && p.OrdineFase > 3 && p.CodStato != "N")
                    {
                        Control c1 = LoadControl("../../CONTROLS/AZDomanda.ascx");
                        System.Type t1 = c1.GetType();
                        t1.GetProperty("Progetto").SetValue(c1, p, null);
                        tdFase2.Controls.Add(c1);
                    }
                }
                catch (Exception ex)
                {
                    ShowError(ex); Session.Remove("_progetto");
                    tdDomanda.InnerHtml = "<div class=testo_pagina><b>" + ex.Message + "</b></div>";
                }
            }
            base.OnPreRender(e);
        }

        protected void btnCerca_Click(object sender, EventArgs e) { }
    }
}
