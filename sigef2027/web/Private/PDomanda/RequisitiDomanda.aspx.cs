using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.PDomanda
{
    public partial class RequisitiDomanda : SiarLibrary.Web.ProgettoPage
    {
        SiarBLL.BandoProgrammazioneCollectionProvider bp_provider;
        SiarLibrary.BandoProgrammazioneCollection disposizioni_attuative;

        protected void Page_Load(object sender, EventArgs e)
        {
            bp_provider = new SiarBLL.BandoProgrammazioneCollectionProvider(ProgettoProvider.DbProviderObj);
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (Bando.Aggregazione)
            {
                //btnPrev.Value = "<<< (2/7)";
                //btnCurrent.Value = "(3/7)";
                //btnGo.Value = "(4/7) >>>";
                btnGo.Attributes.Add("onclick", "location='RequisitiImpresa.aspx'");
                btnGoUp.Attributes.Add("onclick", "location='RequisitiImpresa.aspx'");
                tdAggregazione.Visible = true;
            }
            else
            {
                btnGo.Attributes.Add("onclick", "location='RelazioneTecnica.aspx'");
                btnGoUp.Attributes.Add("onclick", "location='RelazioneTecnica.aspx'");
                tdAggregazione.Visible = false;
            }
            // seleziono le diverse misure del bando per il piano investimenti. in generale ognuna di esse avra' delle impostazioni diverse
            disposizioni_attuative = bp_provider.GetDispAttuativeBando(Progetto.IdBando, Progetto.IdProgetto);
            foreach (SiarLibrary.BandoProgrammazione d in disposizioni_attuative)
            {
                Control c = LoadControl("~/CONTROLS/RequisitiMisura.ascx");
                System.Reflection.PropertyInfo progi = c.GetType().GetProperty("IdProgIntegrato");
                progi.SetValue(c, Progetto.IdProgetto, null);
                System.Reflection.PropertyInfo pi = c.GetType().GetProperty("DisposizioniAttuative");
                pi.SetValue(c, d, null);
                System.Reflection.PropertyInfo fasei = c.GetType().GetProperty("fase_istruttoria");
                fasei.SetValue(c, false, null);
                tdControls.Controls.Add(c);
            }
            base.OnPreRender(e);
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                disposizioni_attuative = bp_provider.GetDispAttuativeBando(Progetto.IdBando, Progetto.IdProgetto);

                SiarBLL.PrioritaXProgettoCollectionProvider priorita_provider = new SiarBLL.PrioritaXProgettoCollectionProvider(ProgettoProvider.DbProviderObj);

                ProgettoProvider.DbProviderObj.BeginTran();

                ListItemCollection licoll = new ListItemCollection();
                foreach (SiarLibrary.BandoProgrammazione d in disposizioni_attuative)
                {
                    SiarLibrary.NullTypes.IntNT IdProgetto = new SiarLibrary.NullTypes.IntNT(d.AdditionalAttributes["IdProgetto"]);
                    if (IdProgetto == null) IdProgetto = inserisciProgettoCorrelato(d.IdDisposizioniAttuative);
                    else priorita_provider.DeleteCollection(priorita_provider.Find(IdProgetto, null, null));

                    SiarLibrary.PrioritaXProgettoCollection priorita_progetto = priorita_provider.GetPrioritaDisposizioniAttuative(
                        d.IdDisposizioniAttuative, "D", IdProgetto);

                    foreach (SiarLibrary.PrioritaXProgetto pp in priorita_progetto)
                    {
                        if (pp.InputNumerico)
                        {
                            decimal valore;
                            if (decimal.TryParse(Request.Form["txtPriorita" + pp.IdPriorita + "_" + d.IdDisposizioniAttuative + "_text"], out valore))
                            {
                                SiarLibrary.PrioritaXProgetto pp_new = new SiarLibrary.PrioritaXProgetto();
                                pp_new.IdProgetto = IdProgetto;
                                pp_new.IdPriorita = pp.IdPriorita;
                                pp_new.Valore = valore;
                                priorita_provider.Save(pp_new);
                            }
                        }
                        else if (pp.PluriValore)
                        {
                            int id_valore_priorita, id_disposizione_attuativa_check;
                            foreach (string s in Request.Form.AllKeys)
                            {
                                if (s.EndsWith("hdnPlurivaloreSelezionatoDisposizione" + pp.IdPriorita) && int.TryParse(Request.Form[s],
                                    out id_disposizione_attuativa_check) && id_disposizione_attuativa_check == d.IdDisposizioniAttuative &&
                                    int.TryParse(Request.Form[s.Replace("hdnPlurivaloreSelezionatoDisposizione", "hdnPlurivaloreSelezionato")], out id_valore_priorita))
                                {
                                    SiarLibrary.PrioritaXProgetto pp_new = new SiarLibrary.PrioritaXProgetto();
                                    pp_new.IdProgetto = IdProgetto;
                                    pp_new.IdPriorita = pp.IdPriorita;
                                    pp_new.IdValore = id_valore_priorita;
                                    priorita_provider.Save(pp_new);
                                    break;
                                }
                            }
                        }
                        else if (pp.PluriValoreSql)
                        {
                            int id_disposizione_attuativa_check;
                            foreach (string s in Request.Form.AllKeys)
                            {
                                if (s.EndsWith("hdnPlurivaloreSelezionatoDisposizioneSql" + pp.IdPriorita) &&
                                    int.TryParse(Request.Form[s], out id_disposizione_attuativa_check) &&
                                    id_disposizione_attuativa_check == d.IdDisposizioniAttuative)
                                {
                                    string id_valore_priorita = Request.Form[s.Replace("hdnPlurivaloreSelezionatoDisposizioneSql", "hdnPlurivaloreSelezionatoSql")];
                                    if (!string.IsNullOrEmpty(id_valore_priorita))
                                    {
                                        SiarLibrary.PrioritaXProgetto pp_new = new SiarLibrary.PrioritaXProgetto();
                                        pp_new.IdProgetto = IdProgetto;
                                        pp_new.IdPriorita = pp.IdPriorita;
                                        pp_new.ValTesto = id_valore_priorita;
                                        priorita_provider.Save(pp_new);
                                        break;
                                    }
                                }
                            }
                        }
                        else if (pp.Datetime)
                        {
                            DateTime data;
                            if (DateTime.TryParse(Request.Form["txtPriorita" + pp.IdPriorita + "_" + d.IdDisposizioniAttuative + "_text"], out data))
                            {
                                SiarLibrary.PrioritaXProgetto pp_new = new SiarLibrary.PrioritaXProgetto();
                                pp_new.IdProgetto = IdProgetto;
                                pp_new.IdPriorita = pp.IdPriorita;
                                pp_new.ValData = data;
                                priorita_provider.Save(pp_new);
                            }

                        }
                        else if (pp.TestoSemplice || pp.TestoArea)
                        {
                            string testoIn = Request.Form["txtPriorita" + pp.IdPriorita + "_" + d.IdDisposizioniAttuative + "_text"];
                            if (!string.IsNullOrEmpty(Request.Form["txtPriorita" + pp.IdPriorita + "_" + d.IdDisposizioniAttuative + "_text"]))
                            {
                                SiarLibrary.PrioritaXProgetto pp_new = new SiarLibrary.PrioritaXProgetto();
                                pp_new.IdProgetto = IdProgetto;
                                pp_new.IdPriorita = pp.IdPriorita;
                                pp_new.ValTesto = testoIn;
                                priorita_provider.Save(pp_new);
                            }

                        }
                        else if (!string.IsNullOrEmpty(Request.Form["chkPriorita"]))
                        {
                            string[] priorita_selezionate = Request.Form["chkPriorita"].Split(',');
                            foreach (string s in priorita_selezionate)
                            {
                                if (pp.IdPriorita == int.Parse(s))
                                {
                                    SiarLibrary.PrioritaXProgetto pp_new = new SiarLibrary.PrioritaXProgetto();
                                    pp_new.IdProgetto = IdProgetto;
                                    pp_new.IdPriorita = pp.IdPriorita;
                                    priorita_provider.Save(pp_new);
                                    break;
                                }
                            }
                        }
                    }
                }

                // ricalcolo il contributo degli investimenti in caso di variazioni delle priorita con aiuto addizionale
                SiarBLL.PianoInvestimentiCollectionProvider investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider(ProgettoProvider.DbProviderObj);
                foreach (SiarLibrary.PianoInvestimenti i in investimenti_provider.GetSituazionePianoInvestimenti(Progetto.IdProgetto))
                {
                    SiarLibrary.PianoInvestimenti investimento = i;
                    if (!investimento.NonCofinanziato)
                    {
                        // salvo contributo e quota
                        investimenti_provider.CalcoloContributoInvestimento(ref investimento, "PDOMANDA", null);
                        investimenti_provider.Save(investimento);
                    }
                }
                ProgettoProvider.AggiornaProgetto(Progetto, Operatore.Utente.IdUtente);
                ProgettoProvider.DbProviderObj.Commit();
                ShowMessage("Requisiti salvati correttamente.");
            }
            catch (Exception exc) { ProgettoProvider.DbProviderObj.Rollback(); ShowError(exc); }
        }

        private SiarLibrary.NullTypes.IntNT inserisciProgettoCorrelato(int id_disposizioni)
        {
            // inserisco la domanda che risponde alle disposizioni attuative
            SiarLibrary.Progetto p = new SiarLibrary.Progetto();
            p.FlagDefinitivo = false;
            p.FlagPreadesione = false;
            p.IdImpresa = Progetto.IdImpresa;
            p.IdBando = id_disposizioni;
            p.DataCreazione = DateTime.Now;
            p.OperatoreCreazione = Operatore.Utente.IdUtente;
            p.IdProgIntegrato = Progetto.IdProgetto;
            p.IdFascicolo = Progetto.IdFascicolo;
            ProgettoProvider.Save(p);

            SiarLibrary.ProgettoStorico s = new SiarLibrary.ProgettoStorico();
            s.IdProgetto = p.IdProgetto;
            s.CodStato = "P";
            s.Data = DateTime.Now;
            s.Operatore = Operatore.Utente.IdUtente;
            new SiarBLL.ProgettoStoricoCollectionProvider(ProgettoProvider.DbProviderObj).Save(s);

            p.IdStoricoUltimo = s.Id;
            ProgettoProvider.Save(p);
            return p.IdProgetto;
        }
    }
}
