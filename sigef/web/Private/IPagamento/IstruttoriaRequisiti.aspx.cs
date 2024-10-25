using System;
using System.Web.UI;
using web.CONTROLS;

namespace web.Private.IPagamento
{
    public partial class IstruttoriaRequisiti : SiarLibrary.Web.IstruttoriaPagamentoPage
    {
        SiarLibrary.BandoProgrammazioneCollection disposizioni_attuative;
        SiarBLL.DomandaPagamentoRequisitiCollectionProvider requisiti_provider;
        SiarLibrary.DomandaPagamentoRequisitiCollection requisiti_inseriti;
        SiarBLL.BandoRequisitiPagamentoCollectionProvider bando_requisiti_provider;

        protected void Page_Load(object sender, EventArgs e)
        {
            requisiti_provider = new SiarBLL.DomandaPagamentoRequisitiCollectionProvider(PagamentoProvider.DbProviderObj);
            disposizioni_attuative = new SiarBLL.BandoProgrammazioneCollectionProvider().GetDispAttuativeBando(Progetto.IdBando, Progetto.IdProgetto);

            ucProgettoInd.Progetto = Progetto;
            ucProgettoInd.Istruttoria = ProgettoIndicatori.eIstruttoria.Si;
            ucProgettoInd.StatoProgetto = ProgettoIndicatori.eStato.Pagamento;
            ucProgettoInd.Operatore = Operatore.Utente.IdUtente;
            ucProgettoInd.IdDomanda = DomandaPagamento.IdDomandaPagamento;
            ucProgettoInd.DataBind();
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (Request.QueryString["redir"] == "revisione")
            {
                btnBack.Attributes["onclick"] = "location='Revisionedomande.aspx?&idpag=" + DomandaPagamento.IdDomandaPagamento + "'";
            }

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

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            bando_requisiti_provider = new SiarBLL.BandoRequisitiPagamentoCollectionProvider();
            try
            {
                PagamentoProvider.DbProviderObj.BeginTran();
                requisiti_inseriti = requisiti_provider.Find(DomandaPagamento.IdDomandaPagamento, null, null);
                SiarLibrary.BandoRequisitiPagamentoCollection br_coll;
                SiarLibrary.DomandaPagamentoRequisiti requisito;

                foreach (SiarLibrary.BandoProgrammazione d in disposizioni_attuative)
                {
                    //requisiti bando per disposizioni
                    br_coll = bando_requisiti_provider.Find(d.IdDisposizioniAttuative, DomandaPagamento.CodTipo, null).FiltroDiInserimento(true);
                    foreach (SiarLibrary.BandoRequisitiPagamento br in br_coll)
                    {
                        if (br.Plurivalore)
                        {
                            requisito = requisiti_inseriti.CollectionGetById(DomandaPagamento.IdDomandaPagamento, br.IdRequisito);

                            int id_valore_requisito, id_disposizione_attuativa_check;
                            foreach (string s in Request.Form.AllKeys)
                            {
                                if (s.EndsWith("hdnPlurivaloreSelezionatoDisposizione" + br.IdRequisito) &&
                                    int.TryParse(Request.Form[s], out id_disposizione_attuativa_check) &&
                                    id_disposizione_attuativa_check == d.IdDisposizioniAttuative)
                                {
                                    if (int.TryParse(Request.Form[s.Replace("hdnPlurivaloreSelezionatoDisposizione", "hdnPlurivaloreSelezionato")],
                                                     out id_valore_requisito))
                                    {
                                        if (requisito == null)
                                        {
                                            requisito = new SiarLibrary.DomandaPagamentoRequisiti();
                                            requisito.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                                            requisito.IdRequisito = br.IdRequisito;
                                        }
                                        requisito.IdValore = id_valore_requisito;
                                        break;
                                    }
                                    else if (requisito != null)
                                    {
                                        requisito.IdValore = null; break;
                                    }
                                }
                            }
                            if (requisito != null)
                            {
                                requisiti_provider.Save(requisito);
                                requisiti_inseriti.Remove(requisito);
                            }
                        }
                        else if (br.Numerico)
                        {
                            requisito = requisiti_inseriti.CollectionGetById(DomandaPagamento.IdDomandaPagamento, br.IdRequisito);
                            decimal valore;
                            if (decimal.TryParse(Request.Form["txtRequisitoNumerico" + br.IdRequisito + "_" + d.IdDisposizioniAttuative + "_text"], 
                                                 out valore))
                            {
                                if (requisito == null)
                                {
                                    requisito = new SiarLibrary.DomandaPagamentoRequisiti();
                                    requisito.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                                    requisito.IdRequisito = br.IdRequisito;
                                }
                                requisito.ValNumerico = valore;
                            }
                            else if (requisito != null)
                            {
                                requisito.ValNumerico = null;
                            }

                            if (requisito != null)
                            {
                                requisiti_provider.Save(requisito);
                                requisiti_inseriti.Remove(requisito);
                            }
                        }
                        else if (br.Datetime)
                        {
                            requisito = requisiti_inseriti.CollectionGetById(DomandaPagamento.IdDomandaPagamento, br.IdRequisito);
                            DateTime data;
                            if (DateTime.TryParse(Request.Form["txtRequisitoDatetime" + br.IdRequisito + "_" + d.IdDisposizioniAttuative + "_text"], 
                                                  out data))
                            {
                                if (requisito == null)
                                {
                                    requisito = new SiarLibrary.DomandaPagamentoRequisiti();
                                    requisito.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                                    requisito.IdRequisito = br.IdRequisito;
                                }
                                requisito.ValData = data;
                            }
                            else if (requisito != null)
                            {
                                requisito.ValData = null;
                            }

                            if (requisito != null)
                            {
                                requisiti_provider.Save(requisito);
                                requisiti_inseriti.Remove(requisito);
                            }
                        }
                        else if (br.TestoSemplice)
                        {
                            requisito = requisiti_inseriti.CollectionGetById(DomandaPagamento.IdDomandaPagamento, br.IdRequisito);
                            if (!string.IsNullOrEmpty(Request.Form["txtRequisitoTestoSemplice" + br.IdRequisito + "_" + d.IdDisposizioniAttuative + "_text"]))
                            {
                                if (requisito == null)
                                {
                                    requisito = new SiarLibrary.DomandaPagamentoRequisiti();
                                    requisito.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                                    requisito.IdRequisito = br.IdRequisito;
                                }
                                requisito.ValTesto = Request.Form["txtRequisitoTestoSemplice" + br.IdRequisito + "_" + d.IdDisposizioniAttuative + "_text"];
                            }
                            else if (requisito != null)
                            {
                                requisito.ValTesto = null;
                            }

                            if (requisito != null)
                            {
                                requisiti_provider.Save(requisito);
                                requisiti_inseriti.Remove(requisito);
                            }
                        }
                        else if (br.TestoArea)
                        {
                            requisito = requisiti_inseriti.CollectionGetById(DomandaPagamento.IdDomandaPagamento, br.IdRequisito);
                            if (!string.IsNullOrEmpty(Request.Form["txtRequisitoTestoArea" + br.IdRequisito + "_" + d.IdDisposizioniAttuative + "_text"]))
                            {
                                if (requisito == null)
                                {
                                    requisito = new SiarLibrary.DomandaPagamentoRequisiti();
                                    requisito.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                                    requisito.IdRequisito = br.IdRequisito;
                                }
                                requisito.ValTesto = Request.Form["txtRequisitoTestoArea" + br.IdRequisito + "_" + d.IdDisposizioniAttuative + "_text"];
                            }
                            else if (requisito != null)
                            {
                                requisito.ValTesto = null;
                            }
                            if (requisito != null)
                            {
                                requisiti_provider.Save(requisito);
                                requisiti_inseriti.Remove(requisito);
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
                        requisito = requisiti_inseriti.CollectionGetById(DomandaPagamento.IdDomandaPagamento, req);
                        if (requisito == null)
                        {
                            requisito = new SiarLibrary.DomandaPagamentoRequisiti();
                            requisito.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                            requisito.IdRequisito = req;
                        }
                        requisito.Selezionato = true;
                        requisiti_provider.Save(requisito);
                        requisiti_inseriti.Remove(requisito);
                    }
                }
                //pulisco gli altri rimasti
                foreach (SiarLibrary.DomandaPagamentoRequisiti r in requisiti_inseriti)
                {
                    if (r.Selezionato)
                    {
                        r.Selezionato = false;
                        requisiti_provider.Save(r);
                    }
                }

                PagamentoProvider.AggiornaDomandaDiPagamentoIstruttore(DomandaPagamento, Operatore);
                PagamentoProvider.DbProviderObj.Commit();

                ucProgettoInd.Salva();

                ShowMessage("Requisiti salvati correttamente.");
                requisiti_inseriti = requisiti_provider.Find(DomandaPagamento.IdDomandaPagamento, null, null);
            }
            catch (Exception exc) 
            { 
                PagamentoProvider.DbProviderObj.Rollback(); 
                ShowError(exc); 
            }
        }
    }
}