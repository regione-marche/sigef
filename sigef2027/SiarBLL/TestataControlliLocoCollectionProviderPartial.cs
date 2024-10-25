using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class TestataControlliLocoCollectionProvider : ITestataControlliLocoProvider
    {
        public TestataControlliLoco generaTestataEChecklistPerDettaglio(CntrlocoDettaglio cntr_dettaglio, string cf_operatore_inserimento)
        {
            TestataControlliLoco nuova_testata = null; 
            IstanzaChecklistGenerica nuova_istanza_generica = null; 

            if (cntr_dettaglio != null && cntr_dettaglio.IdProgetto != null)
            {
                var progetto = new ProgettoCollectionProvider().GetById(cntr_dettaglio.IdProgetto);
                if (progetto != null && progetto.IdBando != null)
                {
                    string errore = "";

                    errore = generaIstanzaPerDettaglio(cntr_dettaglio, ref nuova_istanza_generica, cf_operatore_inserimento);

                    if (errore != null && !errore.Equals(""))
                    {
                        nuova_testata = null; //ShowError(errore);
                    }
                    else
                    {
                        errore = generaTestataPerDettaglio(cntr_dettaglio, ref nuova_testata, nuova_istanza_generica, cf_operatore_inserimento);

                        if (errore != null && !errore.Equals(""))
                            nuova_testata = null; //ShowError(errore);
                        //else
                        //    ShowMessage("Checklist creata correttamente.");
                    }
                }
                //else
                //    ShowError("Progetto non trovato o progetto con bando non associato.");

            }
            //else
            //    ShowError("Nessun dettaglio selezionato o dettaglio senza progetto associato.");

            return nuova_testata;
        }

        protected string generaIstanzaPerDettaglio(CntrlocoDettaglio cntr_dettaglio, 
                                                    ref IstanzaChecklistGenerica nuova_istanza_generica, 
                                                    string cf_operatore_inserimento)
        {
            string errore = "";

            if (cntr_dettaglio != null && cntr_dettaglio.IdlocoDettaglio != null 
                && cf_operatore_inserimento != null && !cf_operatore_inserimento.Equals(""))
            {
                try
                {
                    var chklst_provider = new ChecklistGenericaCollectionProvider();
                    var clsP = new VldCheckListStepCollectionProvider();
                    var progetto = new ProgettoCollectionProvider().GetById(cntr_dettaglio.IdProgetto);
                    string tpAppalto = clsP.Get_TpAppalto(progetto.IdBando);

                    nuova_istanza_generica = new IstanzaChecklistGenerica();
                    nuova_istanza_generica.CfInserimento = cf_operatore_inserimento;
                    nuova_istanza_generica.DataInserimento = DateTime.Now;

                    switch (tpAppalto)
                    {
                        case "AIUTI": // Aiuti
                            var checklist_aiuti = chklst_provider.Find("Controlli in loco - aiuti", false)[0];
                            nuova_istanza_generica.IdChecklistGenerica = checklist_aiuti.IdChecklistGenerica;
                            //nuova_istanza_generica.CodFase = checklist_aiuti.CodFase;
                            break;
                        case "APPAL": // Appalti
                            var checklist_appalti = chklst_provider.Find("Controlli in loco - appalti", false)[0];
                            nuova_istanza_generica.IdChecklistGenerica = checklist_appalti.IdChecklistGenerica;
                            //nuova_istanza_generica.CodFase = checklist_appalti.CodFase;
                            break;
                        case "STRFI": // Strumenti finanziari
                            break;
                    }

                    new IstanzaChecklistGenericaCollectionProvider().Save(nuova_istanza_generica);
                }
                catch (Exception ex) { errore = ex.Message; }
            }
            else
                errore = "Errore nei parametri nella generazione dell'istanza.";

            return errore;
        }

        protected string generaTestataPerDettaglio(CntrlocoDettaglio cntr_dettaglio, 
                                                ref TestataControlliLoco testata_selezionata, 
                                                IstanzaChecklistGenerica istanza_checklist, 
                                                string cf_operatore_inserimento)
        {
            string errore = "";

            if (cntr_dettaglio != null && cntr_dettaglio.IdlocoDettaglio != null
                && istanza_checklist != null && istanza_checklist.IdIstanzaGenerica != null
                && cf_operatore_inserimento != null && !cf_operatore_inserimento.Equals(""))
            {
                try
                {
                    testata_selezionata = new TestataControlliLoco();
                    testata_selezionata.CfInserimento = cf_operatore_inserimento;
                    testata_selezionata.DataInserimento = DateTime.Now;
                    testata_selezionata.IdlocoDettaglio = cntr_dettaglio.IdlocoDettaglio;
                    testata_selezionata.IdIstanzaChecklistGenerica = istanza_checklist.IdIstanzaGenerica;
                    new SiarBLL.TestataControlliLocoCollectionProvider().Save(testata_selezionata);
                }
                catch (Exception ex) { errore = ex.Message; }
            }
            else
                errore = "Errore nei parametri nella generazione della testata.";

            return errore;
        }
    }
}
