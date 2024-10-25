using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;

namespace web.Private.PDomanda
{
    public partial class DatiGenerali : SiarLibrary.Web.ProgettoPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            if (Bando.Aggregazione)
            {
                btnCurrent.Value = "(1/8)";
                btnGo.Value = "(2/8) >>>";
            }

            dg.DataSource = new SiarBLL.ProgettoStoricoCollectionProvider().Find(Progetto.IdProgetto, null, null);
            dg.ItemDataBound += new DataGridItemEventHandler(dg_ItemDataBound);
            dg.DataBind();
            SiarBLL.ProgettoSegnatureCollectionProvider psegnature_provider = new SiarBLL.ProgettoSegnatureCollectionProvider();
            SiarLibrary.ProgettoSegnatureCollection segnature = psegnature_provider.Find(Progetto.IdProgetto, null, null, null);
            dgSegnature.DataSource = segnature;
            dgSegnature.ItemDataBound += new DataGridItemEventHandler(dgSegnature_ItemDataBound);
            if (segnature.Count == 0) dgSegnature.Titolo = "&nbsp;&nbsp;&nbsp;<em><b>Nessuna comunicazione effettuata.</b></em>";
            dgSegnature.DataBind();

            SiarLibrary.ProgettoSegnatureCollection segnature_pagamento = psegnature_provider.FindSegnatureDomandePagamento(Progetto.IdProgetto);
            dgDomandePagamento.DataSource = segnature_pagamento;
            dgDomandePagamento.ItemDataBound += new DataGridItemEventHandler(dgDomandePagamento_ItemDataBound);
            if (segnature_pagamento.Count == 0) dgDomandePagamento.Titolo = "&nbsp;&nbsp;&nbsp;<em><b>Nessuna domanda di pagamento presentata.</b></em>";
            dgDomandePagamento.DataBind();

            SiarLibrary.ProgettoSegnatureCollection segnature_varianti = psegnature_provider.FindSegnatureVarianti(Progetto.IdProgetto);
            dgVarianti.DataSource = segnature_varianti;
            dgVarianti.ItemDataBound += new DataGridItemEventHandler(dgVarianti_ItemDataBound);
            if (segnature_varianti.Count == 0) dgVarianti.Titolo = "&nbsp;&nbsp;&nbsp;<em><b>Nessuna domanda di variante/a.t. presentata.</b></em>";
            dgVarianti.DataBind();

            if (Progetto.OrdineFase != null && Progetto.OrdineFase > 3)
            {
                Control c1 = LoadControl("../../CONTROLS/AZDomanda.ascx");
                System.Type t1 = c1.GetType();
                t1.GetProperty("Progetto").SetValue(c1, Progetto, null);
                tdFase2.Controls.Add(c1);
            }

            Boolean EntePubblico = new SiarBLL.ImpresaCollectionProvider().VerificaBeneficiarioEntePubblico(Progetto.IdImpresa);
            if (EntePubblico)
            {
                trButtonPec.Visible = true;
                trSeparPec.Visible = true;
                trPec.Visible = true;
                SiarBLL.ProgettoPecCollectionProvider pec_prov = new SiarBLL.ProgettoPecCollectionProvider();
                SiarLibrary.ProgettoPecCollection pec_coll = pec_prov.Find(null, Progetto.IdProgetto, null);
                if (pec_coll.Count > 0)
                    txtPecUfficio.Text = pec_coll[0].Pec;
                bool rappr_legale = false, persXimp = false, consulente = false;
                if(Progetto.OrdineStato == 1 )
                {
                    //rappresentante legale
                    SiarLibrary.Impresa i = new SiarBLL.ImpresaCollectionProvider().GetById(Progetto.IdImpresa);
                    SiarLibrary.PersoneXImprese rlegale = new SiarBLL.PersoneXImpreseCollectionProvider().GetById(i.IdRapprlegaleUltimo);
                    if (rlegale.IdPersona == Operatore.Utente.IdPersonaFisica)
                        rappr_legale = true;

                    //procuratori
                    SiarLibrary.PersoneXImpreseCollection pXi_coll = new SiarBLL.PersoneXImpreseCollectionProvider().Find(Operatore.Utente.IdPersonaFisica, null, Progetto.IdImpresa, null, true, null);
                    if (pXi_coll.Count > 0)
                        persXimp = true;

                    //consulente
                    SiarLibrary.MandatiImpresaCollection mandati_coll = new SiarBLL.MandatiImpresaCollectionProvider().Find(Progetto.IdProgetto, null, null, null, Operatore.Utente.IdUtente, null, null, null, true);
                    if(mandati_coll.Count > 0)
                        consulente = true;

                    if (rappr_legale || persXimp || consulente)
                        btnAggiungiPec.Enabled = true;
                }
            }
            base.OnPreRender(e);
        }

        void dgVarianti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                SiarLibrary.ProgettoSegnature s = (SiarLibrary.ProgettoSegnature)e.Item.DataItem;
                if (s.CodTipo == "RIV")
                {
                    e.Item.Cells[2].CssClass = "selectable";
                    e.Item.Cells[2].Attributes.Add("onclick", "dettaglioRiesame(this," + s.RiapriDomanda.ToJsonString() + ",'" + s.Motivazione.ToCleanJsString() + "');");
                    e.Item.Cells[2].Text = "<img src='../../images/domande.ico' alt='Visualizza esito della richiesta' />";
                }
            }
        }

        void dgDomandePagamento_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                SiarLibrary.ProgettoSegnature s = (SiarLibrary.ProgettoSegnature)e.Item.DataItem;
                if (s.CodTipo == "RIP")
                {
                    e.Item.Cells[2].CssClass = "selectable";
                    e.Item.Cells[2].Attributes.Add("onclick", "dettaglioRiesame(this," + s.RiapriDomanda.ToJsonString() + ",'" + s.Motivazione.ToCleanJsString() + "');");
                    e.Item.Cells[2].Text = "<img src='../../images/domande.ico' alt='Visualizza esito della richiesta' />";
                }
            }
        }

        void dgSegnature_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                DataGridItem dgi = (DataGridItem)e.Item;
                SiarLibrary.ProgettoSegnature s = (SiarLibrary.ProgettoSegnature)dgi.DataItem;
                if (s.CodTipo == "RID")
                {
                    dgi.Cells[2].CssClass = "selectable";
                    string click_fn = "alert('Attenzione! Le motivazioni dell`esito di tale richiesta saranno accessibili a graduatoria definitiva.');";
                    if (new SiarBLL.BandoCollectionProvider().GetById(Progetto.IdBando).OrdineStato > 4/* graduatoria definitiva */)
                        click_fn = "dettaglioRiesame(this," + s.RiapriDomanda.ToJsonString() + ",'" + s.Motivazione.ToCleanJsString() + "');";
                    dgi.Cells[2].Attributes.Add("onclick", click_fn);
                    dgi.Cells[2].Text = "<img src='../../images/domande.ico' alt='Visualizza esito della richiesta' />";
                }
            }
        }

        void dg_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                DataGridItem dgi = (DataGridItem)e.Item;
                SiarLibrary.ProgettoStorico mon = (SiarLibrary.ProgettoStorico)dgi.DataItem;
                dgi.Cells[2].Text = (mon.Riesame ? "Riesame" : (mon.Revisione ? "Revisione" : (mon.Ricorso ? "Ricorso" : "")));
                if (mon.CodStato == "V") dgi.Cells[2].Text = "Domanda di ANTICIPO";
                else if (mon.CodStato == "S") dgi.Cells[2].Text = "Domanda di SAL";
                else if (mon.CodStato == "T") dgi.Cells[2].Text = "Domanda di SALDO";
            }
        }

        protected void btnAggiungiPec_Click(object sender, EventArgs e)
        {
            try
            {
                SiarBLL.ProgettoPecCollectionProvider pec_prov = new SiarBLL.ProgettoPecCollectionProvider();
                SiarLibrary.ProgettoPecCollection pec_coll = pec_prov.Find(null, Progetto.IdProgetto, null);
                SiarLibrary.ProgettoPec pec = null;
                if (pec_coll.Count == 0)
                {
                    pec = new SiarLibrary.ProgettoPec();
                    pec.IdProgetto = Progetto.IdProgetto;
                    pec.OperatoreCreazione = Operatore.Utente.IdUtente;
                    pec.DataCreazione = DateTime.Now;
                    pec.Pec = txtPecUfficio.Text;
                    pec_prov.Save(pec);
                }
                else
                {
                    pec = pec_coll[0];
                    if (pec.Pec != txtPecUfficio.Text)
                    {
                        pec.Pec = txtPecUfficio.Text;
                        pec.OperatoreModifica = Operatore.Utente.IdUtente;
                        pec.DataModifica = DateTime.Now;
                        pec_prov.Save(pec);
                    }
                }
                ShowMessage("La PEC inserita è stata associata correttamente al progetto.");
            }
            catch (Exception ex) { ShowError(ex); }
        }



            protected void btnElimina_Click(object sender, EventArgs e)
        {
            SiarLibrary.ProgettoCollection progetti_correlati = new SiarLibrary.ProgettoCollection();

            try
            {
                int id_impresa = Progetto.IdImpresa;
                var autodichiarazioni_coll = new SiarBLL.CovidAutodichiarazioneCollectionProvider().Find(null, Progetto.IdProgetto, null, null, null, null, null);
                var graduatoriaAtti = new SiarBLL.GraduatoriaProgettiAttiCollectionProvider().Find(null, Progetto.IdProgetto, null, null);

                if (Progetto.CodStato != "P") 
                    throw new Exception("Non è possibile annullare una domanda di aiuto resa definitiva.");
                if (autodichiarazioni_coll.Count > 0)
                    throw new Exception("Non è possibile annullare una domanda di aiuto collegata ad una richiesta contributo Covid.");
                if (graduatoriaAtti.Count > 0)
                    throw new Exception("Non è possibile annullare una domanda di aiuto a cui risultano associati degli atti in graduatoria.");

                if (IsProgettoIntegrato) 
                    progetti_correlati = ProgettoProvider.Find(null, null, Progetto.IdProgetto, null, null, null, null);
                else 
                    progetti_correlati.Add(Progetto);

                ProgettoProvider.DbProviderObj.BeginTran();

                foreach (SiarLibrary.Progetto prog in progetti_correlati)
                {
                    // Graduatoria
                    var graduatoriaProvider = new SiarBLL.GraduatoriaProgettiCollectionProvider(ProgettoProvider.DbProviderObj);
                    graduatoriaProvider.DeleteCollection(graduatoriaProvider.Find(null, prog.IdProgetto, null));

                    // allegati
                    SiarBLL.ProgettoAllegatiCollectionProvider allegati_provider = new SiarBLL.ProgettoAllegatiCollectionProvider(ProgettoProvider.DbProviderObj);
                    allegati_provider.DeleteCollection(allegati_provider.Find(prog.IdProgetto, null));

                    // Dichiarazioni
                    SiarBLL.DichiarazioniXProgettoCollectionProvider dichiarazioniprovider = new SiarBLL.DichiarazioniXProgettoCollectionProvider(ProgettoProvider.DbProviderObj);
                    dichiarazioniprovider.DeleteCollection(dichiarazioniprovider.Find(null, prog.IdProgetto));

                    // Requisiti Soggettivi (PrioritaXprogetto)
                    SiarBLL.PrioritaXProgettoCollectionProvider prioXproProvider = new SiarBLL.PrioritaXProgettoCollectionProvider(ProgettoProvider.DbProviderObj);
                    prioXproProvider.DeleteCollection(prioXproProvider.Find(prog.IdProgetto, null, null));

                    // Dati monitoraggio
                    SiarBLL.DatiMonitoraggioFESRCollectionProvider dtMonProv = new SiarBLL.DatiMonitoraggioFESRCollectionProvider(ProgettoProvider.DbProviderObj);
                    dtMonProv.DeleteCollection(dtMonProv.Find(null, prog.IdProgetto));

                    // Localizzazione progetto
                    SiarBLL.LocalizzazioneProgettoCollectionProvider dtLocProv = new SiarBLL.LocalizzazioneProgettoCollectionProvider(ProgettoProvider.DbProviderObj);
                    dtLocProv.DeleteCollection(dtLocProv.Find(null, prog.IdProgetto, null, null));

                    // CollaboratoriXprogetto
                    // commentata perche' dati non ancora presenti in questa fase
                    //SiarBLL.CollaboratoriXBandoCollectionProvider collaboratoriprovider = new SiarBLL.CollaboratoriXBandoCollectionProvider(ProgettoProvider.DbProviderObj);
                    //collaboratoriprovider.DeleteCollection(collaboratoriprovider.Find(null, null, null, prog.IdProgetto));

                    // Piano investimenti
                    SiarBLL.PianoInvestimentiCollectionProvider pianoinvestimentiprovider = new SiarBLL.PianoInvestimentiCollectionProvider(ProgettoProvider.DbProviderObj);
                    SiarLibrary.PianoInvestimentiCollection pianocoll = pianoinvestimentiprovider.Find(null, prog.IdProgetto, null, null, null, null, null);

                    // priorita x investimenti
                    SiarBLL.PrioritaXInvestimentiCollectionProvider prioXinvestimentiProvider = new SiarBLL.PrioritaXInvestimentiCollectionProvider(ProgettoProvider.DbProviderObj);
                    foreach (SiarLibrary.PianoInvestimenti piano in pianocoll)
                    {
                        // Localizzazione Investimento
                        //localprovider.DeleteCollection(localprovider.Find(null, piano.IdInvestimento, null, null));
                        // Priorita per investimento
                        prioXinvestimentiProvider.DeleteCollection(prioXinvestimentiProvider.Find(null, piano.IdInvestimento, null, null));
                    }
                    pianoinvestimentiprovider.DeleteCollection(pianocoll);

                    //Natura soggetto Aggregazione
                    SiarBLL.ProgettoNaturaSoggettoCollectionProvider progettonaturasoggettoprovider = new SiarBLL.ProgettoNaturaSoggettoCollectionProvider(ProgettoProvider.DbProviderObj);
                    progettonaturasoggettoprovider.DeleteCollection(progettonaturasoggettoprovider.Find(prog.IdProgetto, null, null));

                    //priorita x imprese
                    SiarBLL.PrioritaXImpresaCollectionProvider prioritaximpreseprovider = new SiarBLL.PrioritaXImpresaCollectionProvider(ProgettoProvider.DbProviderObj);
                    prioritaximpreseprovider.DeleteCollection(prioritaximpreseprovider.Find(null, null, prog.IdProgetto, null, null));

                    // Piano Di sviluppo
                    SiarBLL.PianoDiSviluppoCollectionProvider pianodisviluppoprovider = new SiarBLL.PianoDiSviluppoCollectionProvider(ProgettoProvider.DbProviderObj);
                    pianodisviluppoprovider.DeleteCollection(pianodisviluppoprovider.Find(null, null, prog.IdProgetto, null));

                    // Bilanci
                    SiarBLL.BilancioAgricoloCollectionProvider bilagriprov = new SiarBLL.BilancioAgricoloCollectionProvider(ProgettoProvider.DbProviderObj);
                    bilagriprov.DeleteCollection(bilagriprov.Find(null, null, prog.IdProgetto, null, null, null));
                    SiarBLL.BilancioIndustrialeCollectionProvider bilindprov = new SiarBLL.BilancioIndustrialeCollectionProvider(ProgettoProvider.DbProviderObj);
                    bilindprov.DeleteCollection(bilindprov.Find(null, null, prog.IdProgetto, null, null, null));                   

                    // RelazioneTecnica
                    SiarBLL.ProgettoRelazioneTecnicaCollectionProvider relazionetecnicaprovider = new SiarBLL.ProgettoRelazioneTecnicaCollectionProvider(ProgettoProvider.DbProviderObj);
                    relazionetecnicaprovider.DeleteCollection(relazionetecnicaprovider.Find(Progetto.IdProgetto, null));

                    // graduatoria Progetto
                    // commentata perche' dati non ancora presenti in questa fase
                    //SiarBLL.GraduatoriaProgettiCollectionProvider graduatoriaprogetto = new SiarBLL.GraduatoriaProgettiCollectionProvider(ProgettoProvider.DbProviderObj);
                    //graduatoriaprogetto.DeleteCollection(graduatoriaprogetto.Find(null, prog.IdProgetto));

                    // progetto segnature
                    //non implementata perche' non sono ancora presenti in questa fase                    

                    // Progetti filiera
                    //SiarBLL.PartecipantiXFilieraCollectionProvider partecipantiprovider = new SiarBLL.PartecipantiXFilieraCollectionProvider(ProgettoProvider.DbProviderObj);
                    //partecipantiprovider.DeleteCollection(partecipantiprovider.Find(null, null, null, Progetto.IdProgetto));

                    // Collaboratori x bando
                    SiarBLL.CollaboratoriXBandoCollectionProvider collaboratoriProvider = new SiarBLL.CollaboratoriXBandoCollectionProvider(ProgettoProvider.DbProviderObj);
                    collaboratoriProvider.DeleteCollection(collaboratoriProvider.Find(null, Progetto.IdProgetto, null, null, null));

                    // Giustificativi -> non vengono eliminati eliminando le domande di pagamento ma potrebbero rimanere
                    SiarBLL.GiustificativiCollectionProvider giustificativiProvider = new SiarBLL.GiustificativiCollectionProvider(ProgettoProvider.DbProviderObj);
                    giustificativiProvider.DeleteCollection(giustificativiProvider.Find(Progetto.IdProgetto, null, null, null));

                    // Modifica dati generali progetto
                    SiarBLL.ModificaDatiGeneraleCollectionProvider modificaProvider = new SiarBLL.ModificaDatiGeneraleCollectionProvider(ProgettoProvider.DbProviderObj);
                    modificaProvider.DeleteCollection(modificaProvider.Find(Progetto.IdProgetto, null, null, null, null, null));

                    // Indicatori
                    SiarBLL.ProgettoIndicatoriCollectionProvider indicatoriprovider = new SiarBLL.ProgettoIndicatoriCollectionProvider(ProgettoProvider.DbProviderObj);
                    indicatoriprovider.DeleteCollection(indicatoriprovider.Find(Progetto.IdProgetto, null,null));

                    // Iter StatoProgetto
                    SiarBLL.IterProgettoCollectionProvider iterprogettoprovider = new SiarBLL.IterProgettoCollectionProvider(ProgettoProvider.DbProviderObj);
                    iterprogettoprovider.DeleteCollection(iterprogettoprovider.Find(prog.IdProgetto, null, null, null, null, null, null));

                    // storico progetto
                    SiarBLL.ProgettoStoricoCollectionProvider storico_provider = new SiarBLL.ProgettoStoricoCollectionProvider(ProgettoProvider.DbProviderObj);
                    storico_provider.DeleteCollection(storico_provider.Find(prog.IdProgetto, null, null));

                    ProgettoProvider.Delete(prog);
                }
                ProgettoProvider.DbProviderObj.Commit();

                Progetto = null;
                Redirect("../Impresa/ImpresaDomande.aspx?idimp=" + id_impresa, "Domanda di aiuto eliminata correttamente.", false);
            }
            catch (Exception ex) { ProgettoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }
    }
}