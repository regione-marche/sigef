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
    public partial class ModificaDomanda : SiarLibrary.Web.ModificaPage
    {
        DomandaPagamentoRequisitiCollectionProvider requisiti_provider;
        BandoProgrammazioneCollectionProvider bando_prog_provider;
        PrioritaXProgettoCollectionProvider priorita_prog_provider;
        ModificaDatiGeneraleCollectionProvider modifica_dati_provider;

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ucRiepilogoDomandaPagamento.Progetto = Progetto;
            ucRiepilogoDomandaPagamento.DomandaPagamento = Domanda;
        }

        protected override void OnPreRender(EventArgs e)
        {
            InizializzaProvider();
            PopolaImmagini();

            CaricaRequisiti();
            CaricaProgettoIndicatori();

            base.OnPreRender(e);
        }

        private void InizializzaProvider()
        {
            requisiti_provider = new DomandaPagamentoRequisitiCollectionProvider(ProgettoProvider.DbProviderObj);
            bando_prog_provider = new BandoProgrammazioneCollectionProvider(ProgettoProvider.DbProviderObj);
            priorita_prog_provider = new PrioritaXProgettoCollectionProvider(ProgettoProvider.DbProviderObj);
            modifica_dati_provider = new ModificaDatiGeneraleCollectionProvider(ProgettoProvider.DbProviderObj);
        }

        private void PopolaImmagini()
        {
            //imgMostraRequisitiSoggettivi.Attributes.Add("src", PATH_IMAGES + "ArrowUpSolid.png");
            //imgMostraDomandaIndicatori.Attributes.Add("src", PATH_IMAGES + "ArrowUpSolid.png");
        }

        private void CaricaRequisiti()
        {
            txtNoteRequisitiDomanda.Text = null;
            var disposizioni_attuative = bando_prog_provider.GetDispAttuativeBando(Progetto.IdBando, Progetto.IdProgetto);
            var requisiti_inseriti = requisiti_provider.Find(Domanda.IdDomandaPagamento, null, null);

            foreach (BandoProgrammazione d in disposizioni_attuative)
            {
                Control c = LoadControl(PATH_CONTROLS + "RequisitiMisuraPagamento.ascx");
                System.Reflection.PropertyInfo pi = c.GetType().GetProperty("DisposizioniAttuative");
                pi.SetValue(c, d, null);
                pi = c.GetType().GetProperty("Domanda");
                pi.SetValue(c, Domanda, null);
                pi = c.GetType().GetProperty("RequisitiInseriti");
                pi.SetValue(c, requisiti_inseriti, null);
                divDisposizioniAttuative.Controls.Add(c);
            }

            if (requisiti_inseriti.Count == 0)
            {
                txtNoteRequisitiDomanda.Enabled = false;
                btnSalvaRequisitiDomanda.Visible = false;
            }
        }

        private void CaricaProgettoIndicatori()
        {
            txtNoteIndicatoriDomanda.Text = null;
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
                ucDomandaInd.Progetto = Progetto;
                ucDomandaInd.IdDomanda = Domanda.IdDomandaPagamento;
                ucDomandaInd.Istruttoria = CONTROLS.ProgettoIndicatori.eIstruttoria.Si;
                ucDomandaInd.StatoProgetto = CONTROLS.ProgettoIndicatori.eStato.Pagamento;
                ucDomandaInd.Operatore = Operatore.Utente.IdUtente;
                ucDomandaInd.ModificaDatiGenerale = true;
                ucDomandaInd.DataBind();
            }
            else
            {
                ucDomandaInd.Visible = false;
                txtNoteIndicatoriDomanda.Enabled = false;
                btnSalvaIndicatoriDomanda.Visible = false;
            }
        }

        private SiarLibrary.NullTypes.IntNT InserisciProgettoCorrelato(int id_disposizioni)
        {
            // inserisco la domanda che risponde alle disposizioni attuative
            Progetto p = new Progetto();
            p.FlagDefinitivo = false;
            p.FlagPreadesione = false;
            p.IdImpresa = Progetto.IdImpresa;
            p.IdBando = id_disposizioni;
            p.DataCreazione = DateTime.Now;
            p.OperatoreCreazione = Operatore.Utente.IdUtente;
            p.IdProgIntegrato = Progetto.IdProgetto;
            p.IdFascicolo = Progetto.IdFascicolo;
            ProgettoProvider.Save(p);

            ProgettoStorico s = new ProgettoStorico();
            s.IdProgetto = p.IdProgetto;
            s.CodStato = "P";
            s.Data = DateTime.Now;
            s.Operatore = Operatore.Utente.IdUtente;
            new ProgettoStoricoCollectionProvider(ProgettoProvider.DbProviderObj).Save(s);

            p.IdStoricoUltimo = s.Id;
            ProgettoProvider.Save(p);
            return p.IdProgetto;
        }

        #region Button event

        protected void btnSalvaRequisitiDomanda_Click(object sender, EventArgs e)
        {
            try
            {
                var bando_requisiti_provider = new BandoRequisitiPagamentoCollectionProvider();

                //Elenco requisiti Pagamento in Presentazione
                BandoRequisitiPagamentoCollection br_coll;
                var requisiti_new_coll = new DomandaPagamentoRequisitiCollection();
                ProgettoProvider.DbProviderObj.BeginTran();
                InizializzaProvider();

                var modifica_dati = new ModificaDatiGenerale();
                modifica_dati.IdUtenteModifica = Operatore.Utente.IdUtente;
                modifica_dati.DataModifica = DateTime.Now;
                modifica_dati.Note = txtNoteRequisitiDomanda.Text;
                modifica_dati.IdProgetto = Progetto.IdProgetto;
                modifica_dati.IdDomanda = Domanda.IdDomandaPagamento;
                modifica_dati.CodTipoModifica = new TipoModificaGeneraleCollectionProvider().Find(null, ModificaDatiGenerale.eTipoModifica.Requisiti.ToString(), true)[0].IdTipoModifica;

                var requisiti_inseriti = requisiti_provider.Find(Domanda.IdDomandaPagamento, null, null);
                var istanza_priorita = new IstanzaDomandaPagamentoRequisiti(requisiti_inseriti);
                modifica_dati.IstanzaPrecedente = istanza_priorita.Serialize();
                requisiti_provider.DeleteCollection(requisiti_inseriti);

                DomandaPagamentoRequisiti requisito;

                var disposizioni_attuative = bando_prog_provider.GetDispAttuativeBando(Progetto.IdBando, Progetto.IdProgetto);
                foreach (BandoProgrammazione d in disposizioni_attuative)
                {
                    //requisiti bando per disposizioni
                    br_coll = bando_requisiti_provider.Find(d.IdDisposizioniAttuative, Domanda.CodTipo, null).FiltroDiInserimento(true);

                    foreach (BandoRequisitiPagamento br in br_coll)
                    {
                        requisito = new DomandaPagamentoRequisiti();
                        if (br.Plurivalore)
                        {
                            requisito.IdDomandaPagamento = Domanda.IdDomandaPagamento;
                            int id_valore_requisito, id_disposizione_attuativa_check;
                            foreach (string s in Request.Form.AllKeys)
                            {
                                if (s.EndsWith("hdnPlurivaloreSelezionatoDisposizione" + br.IdRequisito) &&
                                    int.TryParse(Request.Form[s], out id_disposizione_attuativa_check) &&
                                    id_disposizione_attuativa_check == d.IdDisposizioniAttuative &&
                                    int.TryParse(Request.Form[s.Replace("hdnPlurivaloreSelezionatoDisposizione", "hdnPlurivaloreSelezionato")],
                                                 out id_valore_requisito)
                                   )
                                {
                                    requisito.IdRequisito = br.IdRequisito;
                                    requisito.IdValore = id_valore_requisito;
                                    requisiti_provider.Save(requisito);
                                    requisiti_new_coll.Add(requisito);
                                    break;
                                }
                            }
                        }
                        else if (br.Numerico)
                        {
                            decimal valore;
                            if (decimal.TryParse(Request.Form["txtRequisitoNumerico" + br.IdRequisito + "_" + d.IdDisposizioniAttuative + "_text"],
                                                 out valore))
                            {
                                requisito.IdDomandaPagamento = Domanda.IdDomandaPagamento;
                                requisito.IdRequisito = br.IdRequisito;
                                requisito.ValNumerico = valore;
                                requisiti_provider.Save(requisito);
                                requisiti_new_coll.Add(requisito);
                            }
                        }
                        else if (br.Datetime)
                        {
                            DateTime data;
                            if (DateTime.TryParse(Request.Form["txtRequisitoDatetime" + br.IdRequisito + "_" + d.IdDisposizioniAttuative + "_text"],
                                                  out data))
                            {
                                requisito.IdDomandaPagamento = Domanda.IdDomandaPagamento;
                                requisito.IdRequisito = br.IdRequisito;
                                requisito.ValData = data;
                                requisiti_provider.Save(requisito);
                                requisiti_new_coll.Add(requisito);
                            }

                        }
                        else if (br.TestoSemplice)
                        {
                            if (!string.IsNullOrEmpty(Request.Form["txtRequisitoTestoSemplice" + br.IdRequisito + "_" + d.IdDisposizioniAttuative + "_text"]))
                            {
                                requisito.IdDomandaPagamento = Domanda.IdDomandaPagamento;
                                requisito.IdRequisito = br.IdRequisito;
                                requisito.ValTesto = Request.Form["txtRequisitoTestoSemplice" + br.IdRequisito + "_" + d.IdDisposizioniAttuative + "_text"];
                                requisiti_provider.Save(requisito);
                                requisiti_new_coll.Add(requisito);

                            }
                        }
                        else if (br.TestoArea)
                        {
                            if (!string.IsNullOrEmpty(Request.Form["txtRequisitoTestoArea" + br.IdRequisito + "_" + d.IdDisposizioniAttuative + "_text"]))
                            {
                                requisito.IdDomandaPagamento = Domanda.IdDomandaPagamento;
                                requisito.IdRequisito = br.IdRequisito;
                                requisito.ValTesto = Request.Form["txtRequisitoTestoArea" + br.IdRequisito + "_" + d.IdDisposizioniAttuative + "_text"];
                                requisiti_provider.Save(requisito);
                                requisiti_new_coll.Add(requisito);
                            }
                        }
                    }
                }

                string req_form = Request.Form["chkRequisito"];
                if (req_form != null)
                {
                    string[] requisiti_selezionati = req_form.Split(',');
                    foreach (string req in requisiti_selezionati)
                    {
                        requisito = new DomandaPagamentoRequisiti();
                        requisito.IdDomandaPagamento = Domanda.IdDomandaPagamento;
                        requisito.IdRequisito = req;
                        requisito.Selezionato = true;
                        requisiti_provider.Save(requisito);
                        requisiti_new_coll.Add(requisito);
                    }
                }

                requisiti_provider.DbProviderObj.Commit();

                requisiti_provider.DbProviderObj.BeginTran();
                requisiti_new_coll = requisiti_provider.Find(Domanda.IdDomandaPagamento, null, null);
                var istanza_priorita_nuova = new IstanzaDomandaPagamentoRequisiti(requisiti_new_coll);
                modifica_dati.IstanzaNuovo = istanza_priorita_nuova.Serialize();
                modifica_dati_provider.Save(modifica_dati);
                requisiti_provider.DbProviderObj.Commit();

                ShowMessage("Requisiti salvati correttamente.");
            }
            catch (Exception exc)
            {
                requisiti_provider.DbProviderObj.Rollback();
                ShowError(exc);
            }
        }

        protected void btnSalvaIndicatoriDomanda_Click(object sender, EventArgs e)
        {
            try
            {
                ucDomandaInd.Progetto = Progetto;
                ucDomandaInd.IdDomanda = Domanda.IdDomandaPagamento;
                ucDomandaInd.Istruttoria = CONTROLS.ProgettoIndicatori.eIstruttoria.Si;
                ucDomandaInd.StatoProgetto = CONTROLS.ProgettoIndicatori.eStato.Pagamento;
                ucDomandaInd.Operatore = Operatore.Utente.IdUtente;
                ucDomandaInd.ModificaDatiGenerale = true;
                ucDomandaInd.SalvaModificaDatiGenerale(txtNoteIndicatoriDomanda.Text);

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