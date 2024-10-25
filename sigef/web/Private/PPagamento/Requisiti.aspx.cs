using System;
using System.Web.UI;
using web.CONTROLS;

namespace web.Private.PPagamento
{
    public partial class Requisiti : SiarLibrary.Web.DomandaPagamentoPage
    {

        SiarBLL.DomandaPagamentoRequisitiCollectionProvider requisiti_provider;
        SiarLibrary.DomandaPagamentoRequisitiCollection requisiti_inseriti;
        SiarLibrary.BandoProgrammazioneCollection disposizioni_attuative;

        protected void Page_Load(object sender, EventArgs e)
        {
            requisiti_provider = new SiarBLL.DomandaPagamentoRequisitiCollectionProvider(PagamentoProvider.DbProviderObj);
            disposizioni_attuative = new SiarBLL.BandoProgrammazioneCollectionProvider().GetDispAttuativeBando(Progetto.IdBando, Progetto.IdProgetto);
            AbilitaModifica = AbilitaModifica && DomandaPagamento.IdFidejussione == null;

            ucProgettoInd.Progetto = Progetto;
            ucProgettoInd.Istruttoria = ProgettoIndicatori.eIstruttoria.No;
            ucProgettoInd.StatoProgetto = ProgettoIndicatori.eStato.Pagamento;
            ucProgettoInd.Operatore = Operatore.Utente.IdUtente;
            ucProgettoInd.IdDomanda = DomandaPagamento.IdDomandaPagamento;
            ucProgettoInd.DataBind();
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (requisiti_inseriti == null)
            {
                requisiti_inseriti = requisiti_provider.Find(DomandaPagamento.IdDomandaPagamento, null, null);
            }

            foreach (SiarLibrary.BandoProgrammazione d in disposizioni_attuative)
            {
                Control c = LoadControl("~/CONTROLS/RequisitiMisuraPagamento.ascx");
                System.Reflection.PropertyInfo pi = c.GetType().GetProperty("DisposizioniAttuative");
                pi.SetValue(c, d, null);
                pi = c.GetType().GetProperty("Domanda");
                pi.SetValue(c, DomandaPagamento, null);
                pi = c.GetType().GetProperty("RequisitiInseriti");
                pi.SetValue(c, requisiti_inseriti, null);
                tdControls.Controls.Add(c);
            }
            base.OnPreRender(e);
        }

        protected override void OnPreRenderComplete(EventArgs e)
        {
            ControlCollection requisiti_misure = tdControls.Controls;
            foreach (Control c in tdControls.Controls)
            {
                System.Reflection.PropertyInfo pi = c.GetType().GetProperty("RequisitiObbligatoriInseriti");
                if (pi != null)
                {
                    bool b = (bool)pi.GetValue(c, null);
                    if (!b)
                    {
                        ucWorkflowPagamento.ProseguiMessaggio = "Attenzione! Per proseguire occorre inserire tutti i requisiti OBBLIGATORI.";
                        ucWorkflowPagamento.ProseguiAbilitato = b;
                        break;
                    }
                }
            }
            base.OnPreRenderComplete(e);
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                SiarBLL.BandoRequisitiPagamentoCollectionProvider bando_requisiti_provider = new SiarBLL.BandoRequisitiPagamentoCollectionProvider();
                //Elenco requisiti Pagamento in Presentazione
                SiarLibrary.BandoRequisitiPagamentoCollection br_coll;
                PagamentoProvider.DbProviderObj.BeginTran();
                requisiti_inseriti = requisiti_provider.Find(DomandaPagamento.IdDomandaPagamento, null, null);
                requisiti_provider.DeleteCollection(requisiti_inseriti);
                SiarLibrary.DomandaPagamentoRequisiti requisito;

                foreach (SiarLibrary.BandoProgrammazione d in disposizioni_attuative)
                {
                    //requisiti bando per disposizioni
                    br_coll = bando_requisiti_provider.Find(d.IdDisposizioniAttuative, DomandaPagamento.CodTipo, null).FiltroDiInserimento(true);

                    foreach (SiarLibrary.BandoRequisitiPagamento br in br_coll)
                    {
                        requisito = new SiarLibrary.DomandaPagamentoRequisiti();
                        if (br.Plurivalore)
                        {
                            requisito.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
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
                                requisito.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                                requisito.IdRequisito = br.IdRequisito;
                                requisito.ValNumerico = valore;
                                requisiti_provider.Save(requisito);
                            }
                        }
                        else if (br.Datetime)
                        {
                            DateTime data;
                            if (DateTime.TryParse(Request.Form["txtRequisitoDatetime" + br.IdRequisito + "_" + d.IdDisposizioniAttuative + "_text"], 
                                                  out data))
                            {
                                requisito.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                                requisito.IdRequisito = br.IdRequisito;
                                requisito.ValData = data;
                                requisiti_provider.Save(requisito);
                            }

                        }
                        else if (br.TestoSemplice)
                        {
                            if (!string.IsNullOrEmpty(Request.Form["txtRequisitoTestoSemplice" + br.IdRequisito + "_" + d.IdDisposizioniAttuative + "_text"]))
                            {
                                requisito.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                                requisito.IdRequisito = br.IdRequisito;
                                requisito.ValTesto = Request.Form["txtRequisitoTestoSemplice" + br.IdRequisito + "_" + d.IdDisposizioniAttuative + "_text"];
                                requisiti_provider.Save(requisito);

                            }
                        }
                        else if (br.TestoArea)
                        {
                            if (!string.IsNullOrEmpty(Request.Form["txtRequisitoTestoArea" + br.IdRequisito + "_" + d.IdDisposizioniAttuative + "_text"]))
                            {
                                requisito.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                                requisito.IdRequisito = br.IdRequisito;
                                requisito.ValTesto = Request.Form["txtRequisitoTestoArea" + br.IdRequisito + "_" + d.IdDisposizioniAttuative + "_text"];
                                requisiti_provider.Save(requisito);
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
                        requisito = new SiarLibrary.DomandaPagamentoRequisiti();
                        requisito.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                        requisito.IdRequisito = req;
                        requisito.Selezionato = true;
                        requisiti_provider.Save(requisito);
                    }
                }

                PagamentoProvider.AggiornaDomandaDiPagamento(DomandaPagamento, Operatore);
                requisiti_provider.DbProviderObj.Commit();

                ucProgettoInd.Salva();

                ShowMessage("Requisiti salvati correttamente.");
                requisiti_inseriti = requisiti_provider.Find(DomandaPagamento.IdDomandaPagamento, null, null);
            }
            catch (Exception exc) 
            { 
                requisiti_provider.DbProviderObj.Rollback(); 
                ShowError(exc); 
            }
        }
    }
}