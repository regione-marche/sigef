using System;
using System.Web;
using System.Web.UI.WebControls;
using SiarLibrary;
using SiarBLL;
using System.Web.UI;
using System.Linq;
using SiarLibrary.Extensions;

namespace web.Private.ModificaDati
{
    public partial class ModificaVariante : SiarLibrary.Web.ModificaPage
    {
        DomandaPagamentoRequisitiCollectionProvider requisiti_provider;
        BandoProgrammazioneCollectionProvider bando_prog_provider;
        PrioritaXProgettoCollectionProvider priorita_prog_provider;
        ModificaDatiGeneraleCollectionProvider modifica_dati_provider;
        PrioritaXProgettoCollectionProvider priorita_provider;

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ucRiepilogoDomandaPagamento.Progetto = Progetto;
            ucRiepilogoDomandaPagamento.Variante = Variante;
        }

        protected override void OnPreRender(EventArgs e)
        {
            InizializzaProvider();
            PopolaImmagini();

            CaricaRequisitiVariante();
            CaricaVarianteIndicatori();

            base.OnPreRender(e);
        }

        private void InizializzaProvider()
        {
            requisiti_provider = new DomandaPagamentoRequisitiCollectionProvider(ProgettoProvider.DbProviderObj);
            bando_prog_provider = new BandoProgrammazioneCollectionProvider(ProgettoProvider.DbProviderObj);
            priorita_prog_provider = new PrioritaXProgettoCollectionProvider(ProgettoProvider.DbProviderObj);
            modifica_dati_provider = new ModificaDatiGeneraleCollectionProvider(ProgettoProvider.DbProviderObj);
            priorita_provider = new PrioritaXProgettoCollectionProvider(ProgettoProvider.DbProviderObj);
        }

        private void PopolaImmagini()
        {
            imgMostraRequisitiVariante.Attributes.Add("src", PATH_IMAGES + "ArrowUpSolid.png");
            imgMostraVarianteIndicatori.Attributes.Add("src", PATH_IMAGES + "ArrowUpSolid.png");
        }

        private void CaricaRequisitiVariante()
        {
            txtNoteRequisitiVariante.Text = null;
            var disposizioni_attuative = bando_prog_provider.GetDispAttuativeBando(Progetto.IdBando, Progetto.IdProgetto);

            foreach (BandoProgrammazione d in disposizioni_attuative)
            {
                Control c = LoadControl(PATH_CONTROLS + "RequisitiMisura.ascx");
                System.Reflection.PropertyInfo pi = c.GetType().GetProperty("DisposizioniAttuative");
                pi.SetValue(c, d, null);
                System.Reflection.PropertyInfo fasei = c.GetType().GetProperty("fase_istruttoria");
                fasei.SetValue(c, true, null);
                divDisposizioniAttuative.Controls.Add(c);
            }

            if (disposizioni_attuative.Count == 0)
            {
                txtNoteRequisitiVariante.Enabled = false;
                btnSalvaRequisitiVariante.Visible = false;
            }
        }

        private void CaricaVarianteIndicatori()
        {
            txtNoteIndicatoriVariante.Text = null;
            var monitoraggio_selezionato = false;

            var bp_coll = new BusinessPlanCollectionProvider().GetBusinessPlanBando(Progetto.IdBando);
            foreach (BusinessPlan bp in bp_coll)
            {
                if (bp.IdBando == Progetto.IdBando
                    && bp.Quadro.Contains("Dati di Monitoraggio"))
                    monitoraggio_selezionato = true;
            }

            if (monitoraggio_selezionato)
            {
                ucVarianteInd.Progetto = Progetto;
                ucVarianteInd.Istruttoria = CONTROLS.ProgettoIndicatori.eIstruttoria.Si;
                ucVarianteInd.StatoProgetto = CONTROLS.ProgettoIndicatori.eStato.Variante;
                ucVarianteInd.Operatore = Operatore.Utente.IdUtente;
                ucVarianteInd.IdVariante = Variante.IdVariante;
                ucVarianteInd.ModificaDatiGenerale = true;
                ucVarianteInd.DataBind();
            }
            else
                ucVarianteInd.Visible = false;
        }

        #region Button event

        protected void btnSalvaRequisitiVariante_Click(object sender, EventArgs e)
        {
            try
            {
                ProgettoProvider.DbProviderObj.BeginTran();
                InizializzaProvider();

                var priorita_nuove_coll = new PrioritaXProgettoCollection();

                var modifica_dati = new ModificaDatiGenerale(); 
                modifica_dati.IdUtenteModifica = Operatore.Utente.IdUtente;
                modifica_dati.DataModifica = DateTime.Now;
                modifica_dati.Note = txtNoteRequisitiVariante.Text;
                modifica_dati.IdProgetto = Progetto.IdProgetto;
                modifica_dati.IdVariante = Variante.IdVariante;
                modifica_dati.CodTipoModifica = new TipoModificaGeneraleCollectionProvider().Find(null, ModificaDatiGenerale.eTipoModifica.Priorita.ToString(), true)[0].IdTipoModifica;

                var disposizioni_attuative = bando_prog_provider.GetDispAttuativeBando(Progetto.IdBando, Progetto.IdProgetto);
                foreach (BandoProgrammazione d in disposizioni_attuative)
                {
                    SiarLibrary.NullTypes.IntNT IdProgetto = new SiarLibrary.NullTypes.IntNT(d.AdditionalAttributes["IdProgetto"]);
                    if (IdProgetto != null) // se non c'e' il progetto correlato non modifico nulla
                    {
                        var priorita_vecchie_coll = priorita_provider.Find(IdProgetto, null, null);
                        var istanza_priorita = new IstanzaPrioritaXProgetto(priorita_vecchie_coll);
                        modifica_dati.IstanzaPrecedente = istanza_priorita.Serialize();
                        priorita_provider.DeleteCollection(priorita_vecchie_coll);

                        var priorita_progetto = priorita_provider.GetPrioritaDisposizioniAttuative(d.IdDisposizioniAttuative, "D", IdProgetto);
                        foreach (PrioritaXProgetto pp in priorita_progetto)
                        {
                            if (pp.InputNumerico)
                            {
                                decimal valore;
                                if (decimal.TryParse(Request.Form["txtPriorita" + pp.IdPriorita + "_" + d.IdDisposizioniAttuative + "_text"],
                                                     out valore))
                                {
                                    PrioritaXProgetto pp_new = new PrioritaXProgetto();
                                    pp_new.IdProgetto = IdProgetto;
                                    pp_new.IdPriorita = pp.IdPriorita;
                                    pp_new.Valore = valore;
                                    priorita_provider.Save(pp_new);
                                    priorita_nuove_coll.Add(pp_new);
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
                                        int.TryParse(Request.Form[s.Replace("hdnPlurivaloreSelezionatoDisposizione", "hdnPlurivaloreSelezionato")], out id_valore_priorita))
                                    {
                                        PrioritaXProgetto pp_new = new PrioritaXProgetto();
                                        pp_new.IdProgetto = IdProgetto;
                                        pp_new.IdPriorita = pp.IdPriorita;
                                        pp_new.IdValore = id_valore_priorita;
                                        priorita_provider.Save(pp_new);
                                        priorita_nuove_coll.Add(pp_new);
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
                                            PrioritaXProgetto pp_new = new PrioritaXProgetto();
                                            pp_new.IdProgetto = IdProgetto;
                                            pp_new.IdPriorita = pp.IdPriorita;
                                            pp_new.ValTesto = id_valore_priorita;
                                            priorita_provider.Save(pp_new);
                                            priorita_nuove_coll.Add(pp_new);
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
                                    PrioritaXProgetto pp_new = new PrioritaXProgetto();
                                    pp_new.IdProgetto = IdProgetto;
                                    pp_new.IdPriorita = pp.IdPriorita;
                                    pp_new.ValData = data;
                                    priorita_provider.Save(pp_new);
                                    priorita_nuove_coll.Add(pp_new);
                                }

                            }
                            else if (pp.TestoSemplice || pp.TestoArea)
                            {
                                if (!string.IsNullOrEmpty(Request.Form["txtPriorita" + pp.IdPriorita + "_" + d.IdDisposizioniAttuative + "_text"]))
                                {
                                    PrioritaXProgetto pp_new = new PrioritaXProgetto();
                                    pp_new.IdProgetto = IdProgetto;
                                    pp_new.IdPriorita = pp.IdPriorita;
                                    pp_new.ValTesto = Request.Form["txtPriorita" + pp.IdPriorita + "_" + d.IdDisposizioniAttuative + "_text"];
                                    priorita_provider.Save(pp_new);
                                    priorita_nuove_coll.Add(pp_new);
                                }

                            }
                            else if (!string.IsNullOrEmpty(Request.Form["chkPriorita"]))
                            {
                                string[] priorita_selezionate = Request.Form["chkPriorita"].Split(',');
                                foreach (string s in priorita_selezionate)
                                {
                                    if (pp.IdPriorita == int.Parse(s))
                                    {
                                        PrioritaXProgetto pp_new = new PrioritaXProgetto();
                                        pp_new.IdProgetto = IdProgetto;
                                        pp_new.IdPriorita = pp.IdPriorita;
                                        priorita_provider.Save(pp_new);
                                        priorita_nuove_coll.Add(pp_new);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                var istanza_priorita_nuova = new IstanzaPrioritaXProgetto(priorita_nuove_coll);
                modifica_dati.IstanzaNuovo = istanza_priorita_nuova.Serialize();
                modifica_dati_provider.Save(modifica_dati);

                ProgettoProvider.DbProviderObj.Commit();

                ShowMessage("Requisiti soggettivi salvati correttamente.");
            }
            catch (Exception exc)
            {
                requisiti_provider.DbProviderObj.Rollback();
                ShowError(exc);
            }
        }

        protected void btnSalvaIndicatoriVariante_Click(object sender, EventArgs e)
        {
            try
            {
                ucVarianteInd.Progetto = Progetto;
                ucVarianteInd.Istruttoria = CONTROLS.ProgettoIndicatori.eIstruttoria.Si;
                ucVarianteInd.StatoProgetto = CONTROLS.ProgettoIndicatori.eStato.Variante;
                ucVarianteInd.Operatore = Operatore.Utente.IdUtente;
                ucVarianteInd.IdVariante = Variante.IdVariante;
                ucVarianteInd.ModificaDatiGenerale = true;
                ucVarianteInd.SalvaModificaDatiGenerale(txtNoteIndicatoriVariante.Text);

                ShowMessage("Indicatori salvati correttamente.");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        #endregion
    }
}