using System;
using SiarLibrary;
using System.Linq;

namespace SiarBLL
{
    public static class AccorpamentoInvestimentiUtility
    {
        public static string RecuperaVociAccorpamento(DomandaDiPagamento domanda_pagamento, int indiceX, int indiceY, ref PianoInvestimenti voceX, ref PianoInvestimenti voceY)
        {
            if (domanda_pagamento == null || domanda_pagamento.IdProgetto == null || domanda_pagamento.IdDomandaPagamento == null)
            {
                return "Domanda di pagamento vuota o senza ID.";
            }
            else
            {
                PianoInvestimentiCollectionProvider investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider();
                PianoInvestimentiCollection investimenti = investimenti_provider.GetPianoInvestimentiDomandaPagamento(domanda_pagamento.IdProgetto, domanda_pagamento.IdDomandaPagamento);
                int numero_investimenti = investimenti.Count;

                if (numero_investimenti > 0)
                {
                    if (indiceX > 0 && indiceX < (numero_investimenti + 1)
                        && indiceY > 0 && indiceY < (numero_investimenti + 1)
                        && indiceX != indiceY)
                    {
                        voceX = investimenti[indiceX - 1];
                        voceY = investimenti[indiceY - 1];

                        return VerificaAccorpabilitaVociPiano(domanda_pagamento, voceX, voceY);
                    }
                    else
                        return "Numeri voci inseriti non corretti.";
                }
                else
                    return "Il piano degli investimenti non ha voci da unire.";
            }
        }

        public static string VerificaAccorpabilitaVociPiano(DomandaDiPagamento domanda_pagamento, PianoInvestimenti voceX, PianoInvestimenti voceY)
        {
            string errore = "";

            if (voceX == null || voceX.DettaglioInvestimenti.Equals(""))
                errore += "Voce X vuota o senza dettaglio investimenti. ";

            if (voceY == null || voceY.DettaglioInvestimenti.Equals(""))
                errore += "Voce Y vuota o senza dettaglio investimenti. ";

            if (domanda_pagamento == null || domanda_pagamento.IdDomandaPagamento == null || domanda_pagamento.IdProgetto == null)
                errore += "Domanda di pagamento vuota o senza ID. ";
            else
            {
                var domande_provider = new DomandaDiPagamentoCollectionProvider();
                var anticipi_progetto_collection = domande_provider.Find(null, "ANT", domanda_pagamento.IdProgetto, null);
                var domande_progetto_collection = domande_provider.Find(null, null, domanda_pagamento.IdProgetto, null);

                // se non c'è una sola domanda di pagamento (non l'anticipo) lo blocco
                if (!(  // quelle sotto sono le casistiche per cui l'accorpamento sarebbe fattibile
                        (anticipi_progetto_collection.Count == 0 && domande_progetto_collection.Count == 1) // se non c'è l'anticipo e c'è una sola domanda di pagamento
                        || (anticipi_progetto_collection.Count == 1 && domande_progetto_collection.Count == 2))) // o c'è l'anticipo e due domande di pagamento (compreso l'anticipo)
                    errore += "Non è possibile applicare la variante correttiva perché è presente un altra domanda di pagamento. ";
            }

            if (voceX != null && !voceX.DettaglioInvestimenti.Equals("")
                && voceY != null && !voceY.DettaglioInvestimenti.Equals("")
                && !voceX.DettaglioInvestimenti.Equals(voceY.DettaglioInvestimenti))
                errore += "Le voci X e Y hanno tipologia di investimento differenti.";

            //DA VERIFICARE PER ACCORPARE VOCI CON DETTAGLI DIFFERENTI
            //btnAccorporaVociPiano_Click(null, EventArgs.Empty);
            // LINK: https://forums.asp.net/t/1340333.aspx?Programmatically+fire+a+button+s+click+event
            // RICERCA: https://forums.asp.net/t/1340333.aspx?Programmatically+fire+a+button+s+click+event

            return errore;
        }

        public static string GeneraAccorpamentoInvestimenti(DomandaDiPagamento domanda_pagamento, PianoInvestimenti voceX, PianoInvestimenti voceY, Utenti utente_creazione)
        {
            if (domanda_pagamento == null || domanda_pagamento.IdDomandaPagamento == null || domanda_pagamento.IdProgetto == null
                || utente_creazione == null || utente_creazione.CfUtente == null
                || voceX == null || voceX.IdInvestimento == null
                || voceY == null || voceY.IdInvestimento == null)
            {
                return "Domanda di pagamento o voci di investimento vuoti o senza ID o utente vuoto o senza codice fiscale.";
            }
            else
            {
                try
                {
                    var accorpamento_investimenti_provider = new AccorpamentoInvestimentiCollectionProvider();
                    var accorpamento_investimenti = new AccorpamentoInvestimenti();

                    accorpamento_investimenti.CfCreazione = utente_creazione.CfUtente;
                    accorpamento_investimenti.DataCreazione = DateTime.Now;
                    accorpamento_investimenti.CfModifica = utente_creazione.CfUtente;
                    accorpamento_investimenti.DataModifica = DateTime.Now;
                    accorpamento_investimenti.IdDomandaPagamento = domanda_pagamento.IdDomandaPagamento;
                    accorpamento_investimenti.IdInvestimentoX = voceX.IdInvestimento;
                    accorpamento_investimenti.IdInvestimentoY = voceY.IdInvestimento;
                    var istanza_piano_investimenti = new IstanzaPianoInvestimenti(domanda_pagamento);
                    accorpamento_investimenti.IstanzaPianoInvestimenti = istanza_piano_investimenti.Serialize();
                    accorpamento_investimenti.IdProgetto = domanda_pagamento.IdProgetto;

                    accorpamento_investimenti_provider.Save(accorpamento_investimenti);

                    return "";
                }
                catch (Exception ex) { return ex.ToString(); }
            }
        }

        public static string AccorpaVociPiano(DomandaDiPagamento domanda_pagamento, ref PianoInvestimenti voceX, ref PianoInvestimenti voceY, string nuova_descrizione)
        {
            if (domanda_pagamento == null || domanda_pagamento.IdDomandaPagamento == null || domanda_pagamento.IdProgetto == null
                || voceX == null || voceX.IdInvestimento == null
                || voceY == null || voceY.IdInvestimento == null)
            {
                return "Domanda di pagamento o voci di investimento vuoti o senza ID.";
            }
            else
            {
                try
                {
                    var piano_investimenti_provider = new PianoInvestimentiCollectionProvider();
                    string errore = AccorpaImportiPiano(ref voceX, ref voceY);

                    if (errore != null && errore.Equals(""))
                    {
                        errore = AccorpaPagamenti(domanda_pagamento, ref voceX, ref voceY);

                        if (errore != null && errore.Equals(""))
                        {
                            errore = EliminaVocePiano(domanda_pagamento, ref voceY);

                            if (errore != null && errore.Equals(""))
                            {
                                //modifica la descrizione solo se inserita
                                if (nuova_descrizione != null && !nuova_descrizione.Equals(""))
                                    voceX.Descrizione = nuova_descrizione;

                                piano_investimenti_provider.Save(voceX);
                            }
                        }
                    }

                    return errore;
                }
                catch (Exception ex) { return ex.ToString(); }
            }
        }

        public static string AccorpaPagamenti(DomandaDiPagamento domanda_pagamento, ref PianoInvestimenti voceX, ref PianoInvestimenti voceY)
        {
            if (domanda_pagamento == null || domanda_pagamento.IdDomandaPagamento == null || domanda_pagamento.IdProgetto == null
                || voceX == null || voceX.IdInvestimento == null
                || voceY == null || voceY.IdInvestimento == null)
            {
                return "Domanda di pagamento o voci di investimento vuoti o senza ID.";
            }
            else
            {
                try
                {
                    var pagamenti_richiesti_provider = new PagamentiRichiestiCollectionProvider();
                    var pagamenti_beneficiario_provider = new PagamentiBeneficiarioCollectionProvider();
                    var pagamenti_richiesti_x = pagamenti_richiesti_provider.Find(null, voceX.IdInvestimento, domanda_pagamento.IdProgetto, domanda_pagamento.IdDomandaPagamento);
                    var pagamenti_richiesti_y = pagamenti_richiesti_provider.Find(null, voceY.IdInvestimento, domanda_pagamento.IdProgetto, domanda_pagamento.IdDomandaPagamento);

                    // se non ci sono pagamenti richiesti associati alla voce Y non ho bisogno di portarli alla voce X
                    if (pagamenti_richiesti_y != null && pagamenti_richiesti_y.Count == 1)
                    {
                        if (pagamenti_richiesti_x != null && pagamenti_richiesti_x.Count == 1)
                        {
                            var pagamentoRichiestoX = pagamenti_richiesti_x[0];
                            var pagamentoRichiestoY = pagamenti_richiesti_y[0];

                            //collego tutti i pagamenti beneficiari associati al pagamento richiesto della voce Y al pagamento richiesto della della voce X 
                            var pagamenti_beneficiario_y_collection = pagamenti_beneficiario_provider.Find(pagamentoRichiestoY.IdPagamentoRichiesto, null, domanda_pagamento.IdProgetto, null, null, null);
                            foreach (PagamentiBeneficiario pagamento_beneficiario_y in pagamenti_beneficiario_y_collection)
                            {
                                pagamento_beneficiario_y.IdPagamentoRichiesto = pagamentoRichiestoX.IdPagamentoRichiesto;
                                pagamenti_beneficiario_provider.Save(pagamento_beneficiario_y);
                            }

                            return SommaPagamentiRichiesti(ref voceX, ref pagamentoRichiestoX, ref pagamentoRichiestoY);
                        }
                        else
                            return "Numero di pagamenti richiesti della voce x errati";
                    }
                    else if (pagamenti_richiesti_y != null && pagamenti_richiesti_y.Count > 1)
                        return "Numero di pagamenti richiesti della voce y errati";
                    else
                        return "";
                }
                catch (Exception ex) { return ex.ToString(); }
            }
        }

        public static string SommaPagamentiRichiesti(ref PianoInvestimenti voceX, ref PagamentiRichiesti pagamentoRichiestoX, ref PagamentiRichiesti pagamentoRichiestoY)
        {
            if (pagamentoRichiestoX == null || pagamentoRichiestoX.IdPagamentoRichiesto == null
                || pagamentoRichiestoY == null || pagamentoRichiestoY.IdPagamentoRichiesto == null)
                return "Pagamenti richiesti vuoti o senza ID.";
            else
            {
                try
                {
                    //aggiorno gli importi del pagamento richiesto X comprendendo quelli di Y
                    if (pagamentoRichiestoX.ImportoComputoMetrico != null && pagamentoRichiestoY.ImportoComputoMetrico != null)
                        pagamentoRichiestoX.ImportoComputoMetrico = (decimal)(pagamentoRichiestoX.ImportoComputoMetrico ?? 0.00) + (decimal)(pagamentoRichiestoY.ImportoComputoMetrico ?? 0.00);
                    
                    pagamentoRichiestoX.ImportoRichiesto = (decimal)(pagamentoRichiestoX.ImportoRichiesto ?? 0.00) + (decimal)(pagamentoRichiestoY.ImportoRichiesto ?? 0.00);

                    // il contributo del pagamento è al massimo il contributo del piano
                    // il contributo è la perc dell'importo richiesto/costo investimento, quindi prendo la perc dal minore
                    if (pagamentoRichiestoX.ImportoRichiesto > voceX.CostoInvestimento)
                        pagamentoRichiestoX.ContributoRichiesto = voceX.ContributoRichiesto;
                    else
                        pagamentoRichiestoX.ContributoRichiesto = pagamentoRichiestoX.ImportoRichiesto * voceX.QuotaContributoRichiesto / 100;

                    if (pagamentoRichiestoX.ContributoRichiestoAltreFonti != null && pagamentoRichiestoY.ContributoRichiestoAltreFonti != null)
                        pagamentoRichiestoX.ContributoRichiestoAltreFonti = (decimal)(pagamentoRichiestoX.ContributoRichiestoAltreFonti ?? 0.00) + (decimal)(pagamentoRichiestoY.ContributoRichiestoAltreFonti ?? 0.00);

                    if (pagamentoRichiestoX.ImportoDisavanzoCostiAmmessi != null && pagamentoRichiestoY.ImportoDisavanzoCostiAmmessi != null)
                        pagamentoRichiestoX.ImportoDisavanzoCostiAmmessi = (decimal)(pagamentoRichiestoX.ImportoDisavanzoCostiAmmessi ?? 0.00) + (decimal)(pagamentoRichiestoY.ImportoDisavanzoCostiAmmessi ?? 0.00);
                    if (pagamentoRichiestoX.ContributoDisavanzoCostiAmmessi != null && pagamentoRichiestoY.ContributoDisavanzoCostiAmmessi != null)
                        pagamentoRichiestoX.ContributoDisavanzoCostiAmmessi = (decimal)(pagamentoRichiestoX.ContributoDisavanzoCostiAmmessi ?? 0.00) + (decimal)(pagamentoRichiestoY.ContributoDisavanzoCostiAmmessi ?? 0.00);

                    if (pagamentoRichiestoX.ContributoRichiestoRecuperoAnticipo != null && pagamentoRichiestoY.ContributoRichiestoRecuperoAnticipo != null)
                        pagamentoRichiestoX.ContributoRichiestoRecuperoAnticipo = (decimal)(pagamentoRichiestoX.ContributoRichiestoRecuperoAnticipo ?? 0.00) + (decimal)(pagamentoRichiestoY.ContributoRichiestoRecuperoAnticipo ?? 0.00);

                    if (pagamentoRichiestoX.ImportoComputoMetricoAmmesso != null && pagamentoRichiestoY.ImportoComputoMetricoAmmesso != null)
                        pagamentoRichiestoX.ImportoComputoMetricoAmmesso = (decimal)(pagamentoRichiestoX.ImportoComputoMetricoAmmesso ?? 0.00) + (decimal)(pagamentoRichiestoY.ImportoComputoMetricoAmmesso ?? 0.00);

                    //calcolo l'importo e il contributo ammesso come somma degli importi e contributi ammessi dei pagamenti beneficiari
                    var pagamenti_beneficiario_x_list = new PagamentiBeneficiarioCollectionProvider().Find(pagamentoRichiestoX.IdPagamentoRichiesto, null, pagamentoRichiestoX.IdProgetto, null, null, null)
                            .ToArrayList<PagamentiBeneficiario>();
                    pagamentoRichiestoX.ImportoAmmesso = pagamenti_beneficiario_x_list.Sum(p => p.ImportoAmmesso ?? 0);
                    pagamentoRichiestoX.ContributoAmmesso = pagamenti_beneficiario_x_list.Sum(p => p.ContributoAmmesso ?? 0);
                    //il contributo ammesso è al massimo il contributo richiesto
                    if (pagamentoRichiestoX.ContributoAmmesso > pagamentoRichiestoX.ContributoRichiesto)
                        pagamentoRichiestoX.ContributoAmmesso = pagamentoRichiestoX.ContributoRichiesto;

                    if (pagamentoRichiestoX.ContributoAmmessoAltreFonti != null && pagamentoRichiestoY.ContributoAmmessoAltreFonti != null)
                        pagamentoRichiestoX.ContributoAmmessoAltreFonti = (decimal)(pagamentoRichiestoX.ContributoAmmessoAltreFonti ?? 0.00) + (decimal)(pagamentoRichiestoY.ContributoAmmessoAltreFonti ?? 0.00);

                    if (pagamentoRichiestoX.ContributoAmmessoRecuperoAnticipo != null && pagamentoRichiestoY.ContributoAmmessoRecuperoAnticipo != null)
                        pagamentoRichiestoX.ContributoAmmessoRecuperoAnticipo = (decimal)(pagamentoRichiestoX.ContributoAmmessoRecuperoAnticipo ?? 0.00) + (decimal)(pagamentoRichiestoY.ContributoAmmessoRecuperoAnticipo ?? 0.00);

                    //salvo i nuovi importi
                    new PagamentiRichiestiCollectionProvider().Save(pagamentoRichiestoX);

                    return "";
                }
                catch (Exception ex) { return ex.ToString(); }
            }
        }

        public static string AccorpaImportiPiano(ref PianoInvestimenti voceX, ref PianoInvestimenti voceY)
        {
            if (voceX == null || voceX.IdInvestimento == null
                || voceY == null || voceY.IdInvestimento == null)
            {
                return "Voci di investimento vuoti o senza ID.";
            }
            else
            {
                try
                {
                    voceX.CostoInvestimento = (decimal)(voceX.CostoInvestimento ?? 0.00) + (decimal)(voceY.CostoInvestimento ?? 0.00);
                    voceX.SpeseGenerali = (decimal)(voceX.SpeseGenerali ?? 0.00) + (decimal)(voceY.SpeseGenerali ?? 0.00);
                    voceX.ContributoRichiesto = voceX.CostoInvestimento * voceX.QuotaContributoRichiesto / 100;
                    if(voceX.ContributoAltreFonti != null && voceY.ContributoAltreFonti != null)
                        voceX.ContributoAltreFonti = (decimal)(voceX.ContributoAltreFonti ?? 0.00) + (decimal)(voceY.ContributoAltreFonti ?? 0.00);

                    return "";
                }
                catch (Exception ex) { return ex.ToString(); }
            }
        }

        public static string EliminaVocePiano(DomandaDiPagamento domanda_pagamento, ref PianoInvestimenti voceY)
        {
            if (voceY == null || voceY.IdInvestimento == null)
                return "Voce del piano investimenti vuota o senza ID.";
            else
            {
                try
                {
                    //CERCO LE CORRETTIVE DI RENDICONTAZIONE SPOSTAMENTI
                    var correttive_rendicontazione_spostamenti_provider = new CorrettivaRendicontazioneSpostamentiCollectionProvider();
                    var correttive_rendicontazione_spostamenti_collection = correttive_rendicontazione_spostamenti_provider.Find(null, voceY.IdInvestimento, null, null, null);
                    correttive_rendicontazione_spostamenti_collection.AddCollection(correttive_rendicontazione_spostamenti_provider.Find(null, null, voceY.IdInvestimento, null, null));
                    if (correttive_rendicontazione_spostamenti_collection.Count > 0)
                        correttive_rendicontazione_spostamenti_provider.DeleteCollection(correttive_rendicontazione_spostamenti_collection);

                    //CERCO LE PRIORITA' X INVESTIMENTO
                    var priorita_x_investimenti_provider = new PrioritaXInvestimentiCollectionProvider();
                    var priorita_x_investimento_collection = priorita_x_investimenti_provider.Find(null, voceY.IdInvestimento, null, null);
                    if (priorita_x_investimento_collection.Count > 0)
                        priorita_x_investimenti_provider.DeleteCollection(priorita_x_investimento_collection);

                    //CERCO LE AUTORIZZAZIONI PER MODIFICA PERCENTUALE DI AIUTO
                    var aut_mod_perc_aiuto_provider = new AutModificaPercAiutoCollectionProvider();
                    var autorizazzioni_modifica_perc_aiuto_collection = aut_mod_perc_aiuto_provider.Select(null, null, null, null, null, voceY.IdInvestimento, null, null, null, null, null, null);
                    if (autorizazzioni_modifica_perc_aiuto_collection.Count > 0)
                        aut_mod_perc_aiuto_provider.DeleteCollection(autorizazzioni_modifica_perc_aiuto_collection);

                    //CERCO I PAGAMENTI RICHIESTI
                    var pagamenti_richiesti_provider = new PagamentiRichiestiCollectionProvider();
                    var pagamenti_richiesti_collection = pagamenti_richiesti_provider.Find(null, voceY.IdInvestimento, domanda_pagamento.IdProgetto, domanda_pagamento.IdDomandaPagamento);
                    if (pagamenti_richiesti_collection.Count > 0)
                        pagamenti_richiesti_provider.DeleteCollection(pagamenti_richiesti_collection);

                    //ELIMINO ALLA FINE LA VOCE DEL PIANO
                    new PianoInvestimentiCollectionProvider().Delete(voceY);

                    return "";
                }
                catch (Exception ex) { return ex.ToString(); }
            }
        }
    }
}
