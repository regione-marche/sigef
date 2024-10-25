using System;
using SiarLibrary;
using SiarLibrary.NullTypes;

namespace SiarBLL
{
    public static class IntegrazioniDomandaPagamentoUtility
    {
        #region Crea nuova integrazione
        public static string creaNuovaIntegrazione(DomandaDiPagamento domandaPagamento, string tipoGenerico, Utenti utente, string noteIntegrazioneRichiesta, string dataIntegrazioneRichiesta)
        {
            try
            {
                return creaNuovaIntegrazioneBase(domandaPagamento, tipoGenerico, utente, noteIntegrazioneRichiesta, dataIntegrazioneRichiesta, null);
            }
            catch (Exception ex) { return ex.ToString(); }
        }

        public static string creaNuovaIntegrazione(DomandaDiPagamento domandaPagamento, Giustificativi giustificativo, Utenti utente, string noteIntegrazioneRichiesta, string dataIntegrazioneRichiesta, int id_giustificativo)
        {
            try
            {
                string error = creaNuovaIntegrazioneBase(domandaPagamento, "GIU", utente, noteIntegrazioneRichiesta, dataIntegrazioneRichiesta, id_giustificativo);

                if (error != null && error.Equals(""))
                {
                    var giustificativi_provider = new GiustificativiCollectionProvider();
                    giustificativo.InIntegrazione = true;
                    giustificativi_provider.Save(giustificativo);
                }

                return error;
            }
            catch (Exception ex) { return ex.ToString(); }
        }

        public static string creaNuovaIntegrazione(DomandaDiPagamento domandaPagamento, SpeseSostenute spesa, Utenti utente, string noteIntegrazioneRichiesta, string dataIntegrazioneRichiesta, int id_spesa)
        {
            try
            {
                string error = creaNuovaIntegrazioneBase(domandaPagamento, "PAG", utente, noteIntegrazioneRichiesta, dataIntegrazioneRichiesta, id_spesa);

                if (error != null && error.Equals(""))
                {
                    var spese_provider = new SpeseSostenuteCollectionProvider();
                    spesa.InIntegrazione = true;
                    spese_provider.Save(spesa);
                }

                return error;
            }
            catch (Exception ex) { return ex.ToString(); }
        }

        private static string creaNuovaIntegrazioneBase(DomandaDiPagamento domandaPagamento, string tipoIntegrazione, Utenti utente, string noteIntegrazioneRichiesta, string dataIntegrazioneRichiesta, Nullable<int> id_spesa_giustificativo)
        {
            if (domandaPagamento == null || tipoIntegrazione == null || tipoIntegrazione.Equals("") || utente == null
                || noteIntegrazioneRichiesta == null || noteIntegrazioneRichiesta.Equals("") || dataIntegrazioneRichiesta == null || dataIntegrazioneRichiesta.Equals(""))
                return "Richiesta di creazione mal compilata.";
            else
            {
                try
                {
                    //Se non esiste il contenitore di integrazioni richieste lo creo
                    var integrazione_singola_provider = new IntegrazioneSingolaDiDomandaCollectionProvider();
                    var integrazione_provider = new IntegrazioniPerDomandaDiPagamentoCollectionProvider();
                    var integrazioni_collection = integrazione_provider.Find(null, domandaPagamento.IdDomandaPagamento, false, null);
                    IntegrazioniPerDomandaDiPagamento integrazione = null;

                    if (integrazioni_collection.Count > 0)
                    {
                        integrazione = integrazioni_collection[0];
                    }
                    else
                    {
                        integrazione = new IntegrazioniPerDomandaDiPagamento();
                        integrazione.IdDomandaPagamento = domandaPagamento.IdDomandaPagamento;
                        integrazione.DataInserimento = DateTime.Now;
                        integrazione.DataRichiestaIntegrazioneDomanda = dataIntegrazioneRichiesta;
                        integrazione.CfIstruttore = utente.CfUtente;
                        integrazione.IntegrazioneCompleta = false;
                        var istanza_domanda = new DomandaPagamento(domandaPagamento);
                        integrazione.IstanzaDomandaPagamento = istanza_domanda.Serialize();
                        integrazione_provider.Save(integrazione);
                    }

                    var integrazione_singola = new IntegrazioneSingolaDiDomanda();
                    integrazione_singola.IdIntegrazioneDomanda = integrazione.IdIntegrazioneDomandaDiPagamento;
                    integrazione_singola.CodTipoIntegrazione = tipoIntegrazione;
                    if (tipoIntegrazione.Equals("GIU"))
                        integrazione_singola.IdGiustificativo = id_spesa_giustificativo;
                    else if (tipoIntegrazione.Equals("PAG"))
                        integrazione_singola.IdSpesa = id_spesa_giustificativo;
                    integrazione_singola.CfIstruttoreSingolaIntegrazione = utente.CfUtente;
                    integrazione_singola.DataInserimento = DateTime.Now;
                    integrazione_singola.DataRichiestaIntegrazioneIstruttore = dataIntegrazioneRichiesta;
                    integrazione_singola.SingolaIntegrazioneCompletataIstruttore = false;
                    integrazione_singola.SingolaIntegrazioneCompletataBeneficiario = false;
                    integrazione_singola.NoteIntegrazioneIstruttore = noteIntegrazioneRichiesta;
                    integrazione_singola_provider.Save(integrazione_singola);

                    //Verifico se la domanda di pagamento è da flaggare come "in integrazione"
                    if (domandaPagamento.InIntegrazione == null || domandaPagamento.InIntegrazione == false)
                    {
                        domandaPagamento.InIntegrazione = true;
                        DomandaDiPagamentoCollectionProvider domanda_pagamento_provider = new DomandaDiPagamentoCollectionProvider();
                        domanda_pagamento_provider.Save(domandaPagamento);
                    }

                    return "";
                }
                catch (Exception ex) { return ex.ToString(); }
            }
        }
        #endregion

        public static string salvaSingolaIntegrazioneBeneficiario(IntegrazioneSingolaDiDomanda integrazione_singola, BoolNT newValueBeneficiario,
            string noteIntegrazione, string dataRilascio)
        {
            if (integrazione_singola == null || newValueBeneficiario == null
                || noteIntegrazione == null || noteIntegrazione.Equals("") || dataRilascio == null || dataRilascio.Equals(""))
                return "Richiesta di salvataggio mal compilata.";
            else
            {
                try
                {
                    var integrazione_singola_provider = new IntegrazioneSingolaDiDomandaCollectionProvider();
                    integrazione_singola.SingolaIntegrazioneCompletataBeneficiario = newValueBeneficiario;
                    integrazione_singola.NoteIntegrazioneBeneficiario = noteIntegrazione;

                    if (newValueBeneficiario)
                        integrazione_singola.DataRilascioIntegrazioneBeneficiario = dataRilascio;

                    integrazione_singola_provider.Save(integrazione_singola);

                    return "Integrazione aggiornata.";
                }
                catch (Exception ex) { return ex.ToString(); }
            }
        }

        public static string salvaInteraIntegrazioneIstruttore(IntegrazioniPerDomandaDiPagamento integrazione, string noteIntegrazione, BoolNT newValueCompletata, string dataConclusione)
        {
            if (integrazione == null  || newValueCompletata == null
                || noteIntegrazione == null || noteIntegrazione.Equals("") || dataConclusione == null || dataConclusione.Equals("") )
                return "Richiesta di salvataggio mal compilata.";
            else
            {
                try
                {
                    var integrazione_provider = new IntegrazioniPerDomandaDiPagamentoCollectionProvider();

                    integrazione.IntegrazioneCompleta = newValueCompletata;
                    integrazione.NoteIntegrazioneDomanda = noteIntegrazione;

                    if (newValueCompletata)
                    {
                        integrazione.DataConclusioneIntegrazione = dataConclusione;

                        //Tutte le integrazioni singole sono complete per l'istruttore
                        var integrazione_singola_provider = new IntegrazioneSingolaDiDomandaCollectionProvider();
                        var integrazioni_singole_collection = integrazione_singola_provider.Find(null, integrazione.IdIntegrazioneDomandaDiPagamento, null, false, null, null);
                        foreach (IntegrazioneSingolaDiDomanda single in integrazioni_singole_collection)
                        {
                            //single.SingolaIntegrazioneCompletataBeneficiario = true;
                            single.DataConclusioneIstruttore = dataConclusione;
                            single.SingolaIntegrazioneCompletataIstruttore = true;
                            integrazione_singola_provider.Save(single);
                        }

                        //La domanda di pagamento, i giustificativi e le spese non sono più in integrazione
                        var pagamento_provider = new DomandaDiPagamentoCollectionProvider();
                        string error = togliTuttiFlagInIntegrazione(pagamento_provider.GetById(integrazione.IdDomandaPagamento));
                        if (error != null && !error.Equals(""))
                            return error;
                    }

                    integrazione_provider.Save(integrazione);
                    return "Integrazione aggiornata.";
                }
                catch (Exception ex) { return ex.ToString(); }
            }
        }

        public static string salvaSingolaIntegrazioneIstruttore(IntegrazioneSingolaDiDomanda integrazione_singola,
            BoolNT newValueIstruttore, BoolNT newValueBeneficiario, string noteIntegrazione, string dataConclusione)
        {
            if (integrazione_singola == null || newValueIstruttore == null || newValueBeneficiario == null
                || noteIntegrazione == null || noteIntegrazione.Equals("") || dataConclusione == null || dataConclusione.Equals(""))
                return "Richiesta di salvataggio mal compilata.";
            else
            {
                try
                {
                    string messaggio = "Integrazione aggiornata.";
                    var integrazione_singola_provider = new IntegrazioneSingolaDiDomandaCollectionProvider();
                    integrazione_singola.NoteIntegrazioneIstruttore = noteIntegrazione;
                    integrazione_singola.SingolaIntegrazioneCompletataIstruttore = newValueIstruttore;
                    integrazione_singola.SingolaIntegrazioneCompletataBeneficiario = newValueBeneficiario;
                    integrazione_singola_provider.Save(integrazione_singola);

                    if (newValueIstruttore)
                    {
                        integrazione_singola.SingolaIntegrazioneCompletataBeneficiario = newValueIstruttore;
                        integrazione_singola.DataConclusioneIstruttore = dataConclusione;

                        if(integrazione_singola.CodTipoIntegrazione.Equals("PAG") && integrazione_singola.IdSpesa != null)
                        {
                            var spese_provider = new SpeseSostenuteCollectionProvider();
                            var spesa = spese_provider.GetById(integrazione_singola.IdSpesa);
                            spesa.InIntegrazione = false;
                            spese_provider.Save(spesa);

                            var file_spese_provider = new SpeseSostenuteFileCollectionProvider();
                            foreach (SpeseSostenuteFile ssf in file_spese_provider.GetByIdSpesa(spesa.IdSpesa, null))
                            {
                                if (ssf.InIntegrazione != null && ssf.InIntegrazione)
                                {
                                    ssf.InIntegrazione = false;
                                    file_spese_provider.Save(ssf);
                                }
                            }
                        }

                        if (integrazione_singola.CodTipoIntegrazione.Equals("GIU") && integrazione_singola.IdGiustificativo != null)
                        {
                            var giustificativi_provider = new GiustificativiCollectionProvider();
                            var giustificativo = giustificativi_provider.GetById(integrazione_singola.IdGiustificativo);
                            giustificativo.InIntegrazione = false;
                            giustificativi_provider.Save(giustificativo);
                        }

                        integrazione_singola_provider.Save(integrazione_singola);

                        bool tutteComplete = true;
                        if (integrazione_singola_provider.Find(null, integrazione_singola.IdIntegrazioneDomanda, null, false, null, null).Count > 0)
                            tutteComplete = false;

                        if (tutteComplete)
                        {
                            var integrazione_provider = new IntegrazioniPerDomandaDiPagamentoCollectionProvider();
                            var integrazione = integrazione_provider.GetById(integrazione_singola.IdIntegrazioneDomanda);

                            messaggio = verificaSeIntegrazioneChiudibile(integrazione);
                            if (messaggio.Equals(""))
                            {
                                integrazione.IntegrazioneCompleta = true;
                                integrazione.DataConclusioneIntegrazione = DateTime.Now;
                                integrazione_provider.Save(integrazione);
                                messaggio = "Integrazione aggiornata e blocco completamente concluso.";

                                var domanda_pagamento_provider = new DomandaDiPagamentoCollectionProvider();
                                string error = togliTuttiFlagInIntegrazione(domanda_pagamento_provider.GetById(integrazione.IdDomandaPagamento));
                                if (error != null && !error.Equals(""))
                                    messaggio = error;
                            }
                        }
                    }

                    return messaggio;
                }
                catch (Exception ex) { return ex.ToString(); }
            }
        }

        public static string togliTuttiFlagInIntegrazione(DomandaDiPagamento domandaPagamento)
        {
            if (domandaPagamento == null)
                return "Domanda di pagamento non passata";
            else
            {
                try
                {
                    var pagamento_provider = new DomandaDiPagamentoCollectionProvider();
                    domandaPagamento.InIntegrazione = false;
                    pagamento_provider.Save(domandaPagamento);

                    var spese_provider = new SpeseSostenuteCollectionProvider();
                    var file_spese_provider = new SpeseSostenuteFileCollectionProvider();
                    foreach (SpeseSostenute spesa in spese_provider.Find(domandaPagamento.IdDomandaPagamento, null, domandaPagamento.IdProgetto))
                    {
                        if (spesa.InIntegrazione != null && spesa.InIntegrazione)
                        {
                            spesa.InIntegrazione = false;
                            spesa.IdFileModificatoIntegrazione = false;
                            spese_provider.Save(spesa);
                        }

                        foreach (SpeseSostenuteFile ssf in file_spese_provider.GetByIdSpesa(spesa.IdSpesa, null))
                        {
                            if (ssf.InIntegrazione != null && ssf.InIntegrazione)
                            {
                                ssf.InIntegrazione = false;
                                file_spese_provider.Save(ssf);
                            }
                        }
                    }

                    var giustificiativi_provider = new GiustificativiCollectionProvider();
                    foreach (Giustificativi giustificativo in giustificiativi_provider.GetGiustificativiDomandaPagamento(domandaPagamento.IdDomandaPagamento, null, null))
                    {
                        if (giustificativo.InIntegrazione != null && giustificativo.InIntegrazione)
                        {
                            giustificativo.InIntegrazione = false;
                            giustificativo.IdFileModificatoIntegrazione = false;
                            giustificiativi_provider.Save(giustificativo);
                        }
                    }

                    var allegati_provider = new DomandaPagamentoAllegatiCollectionProvider();
                    foreach (DomandaPagamentoAllegati allegato in allegati_provider.GetAllegatiDomandaInIntegrazione(domandaPagamento.IdDomandaPagamento, true))
                    {
                        allegato.InIntegrazione = false;
                        allegati_provider.Save(allegato);
                    }

                    return "";
                }
                catch (Exception ex) { return ex.ToString(); }
            }
        }

        public static string eliminaIntegrazioneSingola(IntegrazioneSingolaDiDomanda integrazione_singola)
        {
            if (integrazione_singola == null)
                return "Singola integrazione non passata";
            else
            {
                try
                {
                    if (integrazione_singola.SegnaturaIstruttore != null)
                        return "Non è possibile rimuovere l'integrazione in quanto già inviata al beneficiario";

                    if (integrazione_singola.CodTipoIntegrazione.Equals("GIU") && integrazione_singola.IdGiustificativo != null)
                    {
                        GiustificativiCollectionProvider giustificativi_provider = new GiustificativiCollectionProvider();
                        var giustificativo = giustificativi_provider.GetById(integrazione_singola.IdGiustificativo);
                        giustificativo.InIntegrazione = false;
                        giustificativi_provider.Save(giustificativo);
                    }
                    else if (integrazione_singola.CodTipoIntegrazione.Equals("PAG") && integrazione_singola.IdSpesa != null)
                    {
                        SpeseSostenuteCollectionProvider spese_provider = new SpeseSostenuteCollectionProvider();
                        var spesa = spese_provider.GetById(integrazione_singola.IdSpesa);
                        spesa.InIntegrazione = false;
                        spese_provider.Save(spesa);
                    }

                    IntegrazioneSingolaDiDomandaCollectionProvider integrazione_singola_provider = new IntegrazioneSingolaDiDomandaCollectionProvider();
                    integrazione_singola_provider.Delete(integrazione_singola);

                    return "Integrazione rimossa";
                }
                catch (Exception ex) { return ex.ToString(); }
            }
        }

        public static string eliminaIntegrazioneIntera(IntegrazioniPerDomandaDiPagamento integrazione_domanda_pagamento)
        {
            if (integrazione_domanda_pagamento == null)
                return "Gruppo integrazione non passata";
            else
            {
                try
                {
                    if (integrazione_domanda_pagamento.SegnaturaIstruttore != null)
                        return "Non è possibile rimuovere l'integrazione in quanto già inviata al beneficiario";

                    var integrazione_singola_provider = new IntegrazioneSingolaDiDomandaCollectionProvider();
                    var integrazioni_singole_collection = integrazione_singola_provider.Find(null, integrazione_domanda_pagamento.IdIntegrazioneDomandaDiPagamento, null, null, null, null);
                    integrazione_singola_provider.DeleteCollection(integrazioni_singole_collection);

                    var integrazione_domanda_provider = new IntegrazioniPerDomandaDiPagamentoCollectionProvider();
                    integrazione_domanda_provider.Delete(integrazione_domanda_pagamento);

                    var error = togliTuttiFlagInIntegrazione(new DomandaDiPagamentoCollectionProvider().GetById(integrazione_domanda_pagamento.IdDomandaPagamento));
                    if (error != null && !error.Equals(""))
                        return error;

                    return "Integrazione rimossa";
                }
                catch (Exception ex) { return ex.ToString(); }
            }
        }

        public static string verificaSeIntegrazioneChiudibile(IntegrazioniPerDomandaDiPagamento integrazione_domanda)
        {
            string errore = "";

            try
            {
                if (integrazione_domanda != null && integrazione_domanda.IdIntegrazioneDomandaDiPagamento != null)
                {
                    var integrazioni_singole_provider = new IntegrazioneSingolaDiDomandaCollectionProvider();
                    var integrazioni_singole_collection_completate_ben = integrazioni_singole_provider.Find(null, integrazione_domanda.IdIntegrazioneDomandaDiPagamento, null, null, true, null);

                    // Se il beneficiario ha almeno iniziato a completare le singole integrazioni 
                    // ma non ha protocollato la risposta non posso chiudere l'integrazione
                    if (integrazione_domanda.SegnaturaBeneficiario == null
                        && integrazioni_singole_collection_completate_ben.Count > 0)
                        errore = "Non è possibile chiudere l'integrazione perché non completata dal beneficiario o perché manca il protocollo di risposta.";
                }
                else
                    errore = "Informazioni integrazione non corrette.";

            }
            catch (Exception ex) { errore = ex.ToString(); }

            return errore;
        }
    }
}
