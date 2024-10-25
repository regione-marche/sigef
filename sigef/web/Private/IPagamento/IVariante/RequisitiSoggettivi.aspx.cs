using System;
using System.Web.UI.WebControls;
using web.CONTROLS;

namespace web.Private.IPagamento.IVariante
{
    public partial class RequisitiSoggettivi : SiarLibrary.Web.IstruttoriaVariantePage
    {
        SiarBLL.BandoProgrammazioneCollectionProvider bp_provider = new SiarBLL.BandoProgrammazioneCollectionProvider();
        SiarLibrary.BandoProgrammazioneCollection disposizioni_attuative;

        protected void Page_Load(object sender, EventArgs e)
        {
            disposizioni_attuative = bp_provider.GetDispAttuativeBando(Progetto.IdBando, Progetto.IdProgetto);

            ucProgettoInd.Progetto = Progetto;
            ucProgettoInd.Istruttoria = ProgettoIndicatori.eIstruttoria.Si;
            ucProgettoInd.StatoProgetto = ProgettoIndicatori.eStato.Variante;
            ucProgettoInd.Operatore = Operatore.Utente.IdUtente;
            ucProgettoInd.IdVariante = Variante.IdVariante;
            ucProgettoInd.DataBind();
        }

        protected override void OnPreRender(EventArgs e)
        {
            foreach (SiarLibrary.BandoProgrammazione d in disposizioni_attuative)
            {
                System.Web.UI.Control c = LoadControl("~/CONTROLS/RequisitiMisura.ascx");
                System.Reflection.PropertyInfo progi = c.GetType().GetProperty("IdProgIntegrato");
                progi.SetValue(c, Progetto.IdProgetto, null);
                System.Reflection.PropertyInfo pi = c.GetType().GetProperty("DisposizioniAttuative");
                pi.SetValue(c, d, null);
                System.Reflection.PropertyInfo fasei = c.GetType().GetProperty("fase_istruttoria");
                fasei.SetValue(c, true, null);
                rowControls.Controls.Add(c);
            }
            base.OnPreRender(e);
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica)
                {
                    throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                }
                SiarBLL.PrioritaXProgettoCollectionProvider priorita_provider = new SiarBLL.PrioritaXProgettoCollectionProvider(VarianteProvider.DbProviderObj);
                VarianteProvider.DbProviderObj.BeginTran();

                foreach (SiarLibrary.BandoProgrammazione d in disposizioni_attuative)
                {
                    SiarLibrary.NullTypes.IntNT IdProgetto = new SiarLibrary.NullTypes.IntNT(d.AdditionalAttributes["IdProgetto"]);
                    if (IdProgetto != null) // se non c'e' il progetto correlato non modifico nulla
                    {
                        priorita_provider.DeleteCollection(priorita_provider.Find(IdProgetto, null, null));

                        SiarLibrary.PrioritaXProgettoCollection priorita_progetto = 
                            priorita_provider.GetPrioritaDisposizioniAttuative(d.IdDisposizioniAttuative, "D", IdProgetto);
                        foreach (SiarLibrary.PrioritaXProgetto pp in priorita_progetto)
                        {
                            if (pp.InputNumerico)
                            {
                                decimal valore;
                                if (decimal.TryParse(Request.Form["txtPriorita" + pp.IdPriorita + "_" + d.IdDisposizioniAttuative + "_text"], 
                                                     out valore))
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
                                int id_valore_priorita, 
                                    id_disposizione_attuativa_check;
                                foreach (string s in Request.Form.AllKeys)
                                {
                                    if (s.EndsWith("hdnPlurivaloreSelezionatoDisposizione" + pp.IdPriorita) && 
                                        int.TryParse(Request.Form[s], out id_disposizione_attuativa_check) && 
                                        id_disposizione_attuativa_check == d.IdDisposizioniAttuative &&
                                        int.TryParse(Request.Form[s.Replace("hdnPlurivaloreSelezionatoDisposizione", "hdnPlurivaloreSelezionato")], 
                                                     out id_valore_priorita))
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
                                if (DateTime.TryParse(Request.Form["txtPriorita" + pp.IdPriorita + "_" + d.IdDisposizioniAttuative + "_text"], 
                                                      out data))
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
                                if (!string.IsNullOrEmpty(Request.Form["txtPriorita" + pp.IdPriorita + "_" + d.IdDisposizioniAttuative + "_text"]))
                                {
                                    SiarLibrary.PrioritaXProgetto pp_new = new SiarLibrary.PrioritaXProgetto();
                                    pp_new.IdProgetto = IdProgetto;
                                    pp_new.IdPriorita = pp.IdPriorita;
                                    pp_new.ValTesto = Request.Form["txtPriorita" + pp.IdPriorita + "_" + d.IdDisposizioniAttuative + "_text"];
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
                }

                VarianteProvider.AggiornaVarianteIstruttoria(Variante, Operatore);
                VarianteProvider.DbProviderObj.Commit();

                ucProgettoInd.Salva();

                ShowMessage("Requisiti soggettivi salvati correttamente.");
            }
            catch (Exception exc) { VarianteProvider.DbProviderObj.Rollback(); ShowError(exc); }
        }
    }
}
