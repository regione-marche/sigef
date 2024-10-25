using System;
using System.Data;
using System.Web.UI.WebControls;

namespace web.Private.PPagamento
{
    public partial class DatiAnagrafici : SiarLibrary.Web.DomandaPagamentoPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ucImpresaControl.AbilitaModifica = AbilitaModifica;
            ucImpresaControl.Impresa = new SiarBLL.ImpresaCollectionProvider().GetById(Progetto.IdImpresa);
            ucWorkflowPagamento.ProseguiMessaggio = "L`impresa non possiede un conto corrente valido. Impossibile continuare.";
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (ucImpresaControl.Impresa.IdContoCorrenteUltimo == null) ucWorkflowPagamento.ProseguiAbilitato = false;
            //riepilogo sanzioni ed elenco di pagamento
            tableSanzioni.Visible = false;
            tableElencoPagamento.Visible = false;
            tableElenchiPagamentoLegenda.Visible = false;
            /* commentata in attesa implementazione
            if (DomandaPagamento.SegnaturaApprovazione != null)
            {
                //sanzioni
                SiarLibrary.SanzioniCollection sanzioni = new SiarBLL.SanzioniCollectionProvider().RilevaSanzioniXDomandaPagamento(
                    DomandaPagamento.IdDomandaPagamento);
                if (sanzioni.Count > 0)
                {
                    dgSanzioni.ItemDataBound += new DataGridItemEventHandler(dgSanzioni_ItemDataBound);
                    dgSanzioni.DataSource = sanzioni;
                    dgSanzioni.Titolo = "Elementi trovati: " + sanzioni.Count.ToString();
                    dgSanzioni.DataBind();
                    tableSanzioni.Visible = true;
                }
                //elenco di pagamento
                SiarLibrary.ElencoDiPagamentoCollection elenchi = new SiarBLL.ElencoDiPagamentoCollectionProvider().GetLiquidazioniDomandaPagamento(
                    DomandaPagamento.IdDomandaPagamento);
                if (elenchi.Count == 0) dgElencoPagamento.Titolo = "La presente domanda non è ancora stata inclusa in un elenco di pagamento.";
                else
                {
                    tableElenchiPagamentoLegenda.Visible = true;
                    dgElencoPagamento.DataSource = elenchi;
                    dgElencoPagamento.ItemDataBound += new DataGridItemEventHandler(dgElencoPagamento_ItemDataBound);
                }
                dgElencoPagamento.DataBind();
                tableElencoPagamento.Visible = true;
            }*/
            base.OnPreRender(e);
        }

        //void dgElencoPagamento_ItemDataBound(object sender, DataGridItemEventArgs e)
        //{
        //    if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
        //    {
        //        SiarLibrary.ElencoDiPagamento el = (SiarLibrary.ElencoDiPagamento)e.Item.DataItem;
        //        e.Item.Cells[0].Text = el.AdditionalAttributes["Programmazione"];
        //        if (!string.IsNullOrEmpty(el.AdditionalAttributes["ImportoAmmesso"]))
        //        {
        //            e.Item.Cells[2].Text = el.AdditionalAttributes["Barcode"];
        //            e.Item.Cells[3].Text = string.Format("{0:c}", new SiarLibrary.NullTypes.DecimalNT(el.AdditionalAttributes["ImportoAmmesso"]));
        //        }
        //        else { e.Item.BackColor = System.Drawing.Color.FromArgb(204, 204, 179); e.Item.Cells[4].Text = e.Item.Cells[5].Text = ""; }
        //        e.Item.Cells[6].Text = el.AdditionalAttributes["NumDecretoAgea"];
        //        e.Item.Cells[7].Text = el.AdditionalAttributes["DataDecretoAgea"];
        //        e.Item.Cells[8].Text = string.Format("{0:c}", new SiarLibrary.NullTypes.DecimalNT(el.AdditionalAttributes["ImportoLiquidato"]));
        //    }
        //}

        void dgSanzioni_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                SiarLibrary.Sanzioni s = (SiarLibrary.Sanzioni)e.Item.DataItem;
                //ho memorizzato il numero di investimenti in cui ho rilevato la sanzione nel campo idinvestimento
                //per non dover definire un altro campo
                if (s.Livello == "O") e.Item.Cells[2].Text = "nr. " + s.IdInvestimento + " investimenti interessati";
            }
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (DomandaPagamento.Segnatura != null) throw new Exception("Non è possibile eliminare una domanda di pagamento già resa definitiva.");
                PagamentoProvider.DbProviderObj.BeginTran();

                //DECRETI PAGAMENTO E LIQUIDAZIONI
                SiarBLL.DomandaPagamentoLiquidazioneCollectionProvider liquidazioni_provider = new SiarBLL.DomandaPagamentoLiquidazioneCollectionProvider(PagamentoProvider.DbProviderObj);
                liquidazioni_provider.DeleteCollection(liquidazioni_provider.Find(DomandaPagamento.IdDomandaPagamento, null, null, null));
                SiarBLL.DecretiXDomPagEsportazioneCollectionProvider decreti_provider = new SiarBLL.DecretiXDomPagEsportazioneCollectionProvider(PagamentoProvider.DbProviderObj);
                decreti_provider.DeleteCollection(decreti_provider.Find(DomandaPagamento.IdDomandaPagamento, null, null));

                // ESPORTAZIONE DOMANDA PAGAMENTO
                SiarBLL.DomandaDiPagamentoEsportazioneCollectionProvider esportazione_provider = new SiarBLL.DomandaDiPagamentoEsportazioneCollectionProvider(PagamentoProvider.DbProviderObj);
                esportazione_provider.DeleteCollection(esportazione_provider.Find(DomandaPagamento.IdDomandaPagamento, null, null));

                // REQUISITI PAGAMENTO DOMANDA
                SiarBLL.DomandaPagamentoRequisitiCollectionProvider dprequisiti_provider = new SiarBLL.DomandaPagamentoRequisitiCollectionProvider(PagamentoProvider.DbProviderObj);
                dprequisiti_provider.DeleteCollection(dprequisiti_provider.Find(DomandaPagamento.IdDomandaPagamento, null, null));

                //ALLEGATI
                SiarBLL.DomandaPagamentoAllegatiCollectionProvider allegati_provider = new SiarBLL.DomandaPagamentoAllegatiCollectionProvider(PagamentoProvider.DbProviderObj);
                allegati_provider.DeleteCollection(allegati_provider.Find(DomandaPagamento.IdDomandaPagamento, null, null));
                //ANTICIPI RICHIESTI
                SiarBLL.AnticipiRichiestiCollectionProvider anticipi_provider = new SiarBLL.AnticipiRichiestiCollectionProvider(PagamentoProvider.DbProviderObj);
                anticipi_provider.DeleteCollection(anticipi_provider.Find(null, DomandaPagamento.IdDomandaPagamento, null));

                //PAGAMENTI BENEFICIARIO E RICHIESTI
                SiarBLL.PagamentiRichiestiCollectionProvider prichiesti_provider = new SiarBLL.PagamentiRichiestiCollectionProvider(PagamentoProvider.DbProviderObj);
                SiarBLL.PagamentiBeneficiarioCollectionProvider pagben_provider = new SiarBLL.PagamentiBeneficiarioCollectionProvider(PagamentoProvider.DbProviderObj);
                SiarLibrary.PagamentiRichiestiCollection pagamenti_richiesti = prichiesti_provider.Find(null, null, null, DomandaPagamento.IdDomandaPagamento);
                foreach (SiarLibrary.PagamentiRichiesti p in pagamenti_richiesti)
                    pagben_provider.DeleteCollection(pagben_provider.Find(p.IdPagamentoRichiesto, null, null, null, null, null));
                prichiesti_provider.DeleteCollection(pagamenti_richiesti);

                //SPESE SOSTENUTE E SPESE SOSTENUTE FILE
                SiarBLL.SpeseSostenuteCollectionProvider spese_provider = new SiarBLL.SpeseSostenuteCollectionProvider(PagamentoProvider.DbProviderObj);
                SiarBLL.SpeseSostenuteFileCollectionProvider spese_file_provider = new SiarBLL.SpeseSostenuteFileCollectionProvider(PagamentoProvider.DbProviderObj);
                var spese_collection = spese_provider.Find(DomandaPagamento.IdDomandaPagamento, null, null);
                foreach (SiarLibrary.SpeseSostenute spesa in spese_collection)
                    spese_file_provider.DeleteCollection(spese_file_provider.GetByIdSpesa(spesa.IdSpesa, null));
                spese_provider.DeleteCollection(spese_collection);

                //INTEGRAZIONI E INTEGRAZIONI SINGOLE
                var integrazioni_provider = new SiarBLL.IntegrazioniPerDomandaDiPagamentoCollectionProvider(PagamentoProvider.DbProviderObj);
                var integrazioni_singole_provider = new SiarBLL.IntegrazioneSingolaDiDomandaCollectionProvider(PagamentoProvider.DbProviderObj);
                var integrazioni_coll = integrazioni_provider.Find(null, DomandaPagamento.IdDomandaPagamento, null, null);
                foreach (SiarLibrary.IntegrazioniPerDomandaDiPagamento integrazione in integrazioni_coll)
                    integrazioni_singole_provider.DeleteCollection(integrazioni_singole_provider.Find(null, integrazione.IdIntegrazioneDomandaDiPagamento, null, null, null, null));
                integrazioni_provider.DeleteCollection(integrazioni_coll);

                //GIUSTIFICATIVI
                /* commentata per problemi su referenza ad altre domande di pagamento, inoltre tenerci i giustificativi non e' un problema
                 * SiarBLL.GiustificativiCollectionProvider giusto_provider = new SiarBLL.GiustificativiCollectionProvider(PagamentoProvider.DbProviderObj);
                SiarLibrary.GiustificativiCollection giustificativi = giusto_provider.Find(null, ucWorkflowPagamento.Progetto.IdProgetto, null, null);
                foreach (SiarLibrary.Giustificativi g in giustificativi)
                {
                    if (spese_provider.Find(null, null, g.IdGiustificativo, null).Count == 0)
                        giusto_provider.Delete(g);                        
                } */

                //PIANO DI SVILUPPO
                SiarBLL.PianoDiSviluppoDomandaPagamentoCollectionProvider piano_provider = new SiarBLL.PianoDiSviluppoDomandaPagamentoCollectionProvider(PagamentoProvider.DbProviderObj);
                piano_provider.DeleteCollection(piano_provider.Find(null, DomandaPagamento.IdDomandaPagamento, null, null));

                //FIDEJIUSSIONI
                if (DomandaPagamento.IdFidejussione != null)
                {
                    SiarBLL.DomandaPagamentoFidejussioneImpresaCollectionProvider fidej_impresa = new SiarBLL.DomandaPagamentoFidejussioneImpresaCollectionProvider(PagamentoProvider.DbProviderObj);
                    fidej_impresa.DeleteCollection(fidej_impresa.Find(DomandaPagamento.IdFidejussione, DomandaPagamento.IdDomandaPagamento, null, null));

                    SiarBLL.DomandaPagamentoFidejussioneCollectionProvider fidej = new SiarBLL.DomandaPagamentoFidejussioneCollectionProvider(PagamentoProvider.DbProviderObj);
                    fidej.Delete(fidej.GetById(DomandaPagamento.IdFidejussione));
                }

                //PROGETTO INDICATORI
                SiarBLL.ProgettoIndicatoriCollectionProvider indicatori_provider = new SiarBLL.ProgettoIndicatoriCollectionProvider(PagamentoProvider.DbProviderObj);
                indicatori_provider.DeleteCollection(indicatori_provider.Find(null, DomandaPagamento.IdDomandaPagamento, null));

                //TESTATA_VALIDAZIONE
                SiarBLL.TestataValidazioneCollectionProvider testata_provider = new SiarBLL.TestataValidazioneCollectionProvider(PagamentoProvider.DbProviderObj);
                SiarBLL.TestataValidazioneXIstanzaCollectionProvider testata_istanza_provider = new SiarBLL.TestataValidazioneXIstanzaCollectionProvider(PagamentoProvider.DbProviderObj);
                var testate_coll = testata_provider.FindRevisione(null, DomandaPagamento.IdDomandaPagamento, null, null, null, null, null, null);
                for (int i = 0; i < testate_coll.Count; i++)
                {
                    var testata = testate_coll[i];
                    if (testata != null && testata.IdTestata != null)
                    {
                        string esito = testata_provider.EliminaTestataACascata(PagamentoProvider.DbProviderObj, ref testata, null);

                        if (esito == null || esito != "")
                            throw new Exception(esito);
                    }
                }

                //MODIFICA DATI GENERALI
                SiarBLL.ModificaDatiGeneraleCollectionProvider modifica_provider = new SiarBLL.ModificaDatiGeneraleCollectionProvider(PagamentoProvider.DbProviderObj);
                modifica_provider.DeleteCollection(modifica_provider.Find(null, DomandaPagamento.IdDomandaPagamento, null, null, null, null));

                PagamentoProvider.Delete(DomandaPagamento);

                PagamentoProvider.DbProviderObj.Commit();
                Redirect("GestioneLavori.aspx", "Domanda di pagamento eliminata correttamente.", false);
            }
            catch (Exception ex) { PagamentoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }
    }
}
