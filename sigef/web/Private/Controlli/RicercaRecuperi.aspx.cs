using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;

namespace web.Private.Controlli
{
    public partial class RicercaRecuperi : SiarLibrary.Web.ControlliIrregolaritaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "recuperi";
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

            if (!IsPostBack) tdDomanda.InnerHtml = "<div class=testo_pagina><b>Ricercare per domanda di aiuto.</b></div>";
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
                        allegatiProtocollatiOk = new SiarBLL.AllegatiProtocollatiCollectionProvider().CheckAllegatiProtocollati(SiarBLL.AllegatiProtocollatiCollectionProvider.TipoCheck.Progetto, p.IdProgetto, s.Segnatura);
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

                    if (b.AbilitaValutazione && p.CodStato == "I" && (Operatore.Utente.CodTipoEnte.FindValueIn("RM", "%", "AdC") ||
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

                    #region controlli irregolarita

                    tbRecuperi.Visible = true;

                    var registro_recuperi_provider = new SiarBLL.RegistroRecuperoCollectionProvider();
                    var recuperi_collection = registro_recuperi_provider.GetByIdProgetto(p.IdProgetto, false);

                    dgRegistroRecuperi.DataSource = recuperi_collection;
                    dgRegistroRecuperi.SetTitoloNrElementi();
                    dgRegistroRecuperi.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgRegistroRecuperi_ItemDataBound);
                    dgRegistroRecuperi.DataBind();

                    #endregion
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

        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.Progetto prog = null;
                int id_progetto;

                if (int.TryParse(txtNumDomanda.Text, out id_progetto))
                    prog = new SiarBLL.ProgettoCollectionProvider().GetById(id_progetto);

                if (prog == null)
                    throw new Exception("Nessun progetto selezionata.");

                Progetto = prog;
                Response.Redirect("../Controlli/RegistroRecuperi.aspx?idprog=" + Progetto.IdProgetto);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnCaricaRecupero_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.RegistroRecupero registro_recupero_selezionato = null;
                int id_recupero;

                if (int.TryParse(hdnIdRecupero.Value, out id_recupero))
                    registro_recupero_selezionato = new SiarBLL.RegistroRecuperoCollectionProvider().GetById(id_recupero);

                if (registro_recupero_selezionato == null)
                    throw new Exception("Nessun registro recupero o ritiro selezionato.");

                Recupero = registro_recupero_selezionato;
                Response.Redirect("../Controlli/RegistroRecuperi.aspx?idrec=" + registro_recupero_selezionato.IdRegistroRecupero);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        void dgRegistroRecuperi_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.RegistroRecupero rec = (SiarLibrary.RegistroRecupero)e.Item.DataItem;
                SiarLibrary.CodificaGenericaCollectionProvider codifica_provider = new SiarLibrary.CodificaGenericaCollectionProvider();

                if (rec.IdTipoRecupero != null)
                {
                    var codifica = codifica_provider.GetById(rec.IdTipoRecupero);
                    if (codifica != null)
                        e.Item.Cells[1].Text = codifica.Descrizione;
                }

                if (rec.IdProcedureAvviate != null)
                {
                    var codifica = codifica_provider.GetById(rec.IdProcedureAvviate);
                    if (codifica != null)
                        e.Item.Cells[4].Text = codifica.Descrizione;
                }

                if (rec.IdTipoProcedureAvviate != null)
                {
                    var codifica = codifica_provider.GetById(rec.IdTipoProcedureAvviate);
                    if (codifica != null)
                        e.Item.Cells[5].Text = codifica.Descrizione;
                }

                if (rec.Recuperabile != null && rec.Recuperabile)
                    e.Item.Cells[6].Text = e.Item.Cells[6].Text.Replace("<input", "<input checked");
                else
                    e.Item.Cells[6].Text = e.Item.Cells[6].Text.Replace("<input checked", "<input");
            }
        }
    }
}