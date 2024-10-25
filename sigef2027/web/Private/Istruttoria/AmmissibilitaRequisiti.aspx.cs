using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.Istruttoria
{
    public partial class AmmissibilitaRequisiti : SiarLibrary.Web.IstruttoriaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "ammissibilita_domande";
            base.OnPreInit(e);
        }

        //SiarLibrary.DbProvider db = new SiarLibrary.DbProvider();
        //SiarBLL.PrioritaXProgettoCollectionProvider pxpprovider = new SiarBLL.PrioritaXProgettoCollectionProvider();
        //SiarLibrary.PrioritaCollection prioritacoll = new SiarLibrary.PrioritaCollection();
        //SiarLibrary.Impresa impresa = new SiarLibrary.Impresa();
    
        SiarLibrary.Progetto p;
        SiarLibrary.BandoProgrammazioneCollection disposizioni_attuative;

        protected void Page_Load(object sender, EventArgs e)
        {
            int idProgetto;
         
       
            if (!int.TryParse(Request.QueryString["iddom"], out idProgetto)) Redirect("Ammissibilita.aspx");
            else
            {
                p = new SiarBLL.ProgettoCollectionProvider().GetById(idProgetto);
                ucInfoDomanda.Progetto = p;
                controlloOperatoreStatoProgetto();
                // seleziono le diverse misure del bando per il piano investimenti. in generale ognuna di esse avra' delle impostazioni diverse
                if (disposizioni_attuative == null) disposizioni_attuative = new SiarBLL.BandoProgrammazioneCollectionProvider().GetDispAttuativeBando(p.IdBando, p.IdProgetto);
               
                btnBack.Attributes.Add("onclick", "location='ChecklistAmmissibilita.aspx?iddom=" + ucInfoDomanda.Progetto.IdProgetto + "'");
                btnBackDown.Attributes.Add("onclick", "location='ChecklistAmmissibilita.aspx?iddom=" + ucInfoDomanda.Progetto.IdProgetto + "'");
                linkBreadcrumb.Attributes.Add("onclick", "location='ChecklistAmmissibilita.aspx?iddom=" + ucInfoDomanda.Progetto.IdProgetto + "'");
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            foreach (SiarLibrary.BandoProgrammazione d in disposizioni_attuative)
            { 
                Control c = LoadControl("~/CONTROLS/RequisitiMisura.ascx");
                System.Reflection.PropertyInfo pi = c.GetType().GetProperty("DisposizioniAttuative");
                pi.SetValue(c, d, null);
                System.Reflection.PropertyInfo fasei = c.GetType().GetProperty("fase_istruttoria");
                fasei.SetValue(c, true, null);
       
                System.Reflection.PropertyInfo idProg = c.GetType().GetProperty("IdProgIntegrato");
                idProg.SetValue(c, (SiarLibrary.NullTypes.IntNT)Convert.ToInt32(Request.QueryString["iddom"]), null);
                tdControls.Controls.Add(c);
            }
            base.OnPreRender(e);
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            SiarBLL.PrioritaXProgettoCollectionProvider priorita_provider = new SiarBLL.PrioritaXProgettoCollectionProvider();
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                priorita_provider.DbProviderObj.BeginTran();
                foreach  (SiarLibrary.BandoProgrammazione d in disposizioni_attuative)
                {
                    SiarLibrary.NullTypes.IntNT IdProgetto = new SiarLibrary.NullTypes.IntNT(d.AdditionalAttributes["IdProgetto"]);
                    if (IdProgetto != null) // se non c'e' il progetto correlato non modifico nulla
                    {
                        priorita_provider.DeleteCollection(priorita_provider.Find(IdProgetto, null, null));

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
                                if (!string.IsNullOrEmpty(Request.Form["txtPriorita" + pp.IdPriorita + "_" + d.IdDisposizioniAttuative + "_text"]))
                                {
                                    SiarLibrary.PrioritaXProgetto pp_new = new SiarLibrary.PrioritaXProgetto();
                                    pp_new.IdProgetto =  IdProgetto;
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
                priorita_provider.DbProviderObj.Commit();
                ShowMessage("Requisiti salvati correttamente.");
            }
            catch (Exception exc) { priorita_provider.DbProviderObj.Rollback(); ShowError(exc); }
        }

        private void controlloOperatoreStatoProgetto()
        {
            if (AbilitaModifica)
            {
                if (ucInfoDomanda.Progetto.CodStato != "I" && !ucInfoDomanda.DomandaInRiesame && !ucInfoDomanda.DomandaInRevisione
                    && !ucInfoDomanda.DomandaInRicorso) AbilitaModifica = false;
                else if (new SiarBLL.CollaboratoriXBandoCollectionProvider().Find(Bando.IdBando, ucInfoDomanda.Progetto.IdProgetto,
                        Operatore.Utente.IdUtente, null, true).Count == 0) AbilitaModifica = false;
            }
        }
    }
}
