using SiarDAL;
using SiarLibrary;
using SiarLibrary.NullTypes;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace SiarBLL
{
    public partial class RegistroModificheAutorizzateCollectionProvider : IRegistroModificheAutorizzateProvider
    {
        public enum EnumTipoModificaAutorizzata
        {
            RiaperturaIstruttoriaPagamento = 1,    // Riapertura istruttoria domanda di pagamento
            RiaperturaBeneficiarioPagamento = 2,    // Riapertura presentazione domanda di pagamento a beneficiario
            RiaperturaIstruttoriaVariante = 3,    // Riapertura istruttoria variante
            RiaperturaBeneficiarioVariante = 4,    // Riapertura presentazione variante a beneficiario
            EliminazioneSingolaValidazione = 5,    // Eliminazione di una singola validazione con struttura sottostante
            EliminazioneMandatiLiquidazionePagamento = 6,    // Eliminazione dei mandati di liquidazione di una domanda di pagamento
            AnnullamentoIstruttoriaAmmissibilitaProgetto = 7,    // Annullare l’istruttoria di ammissibilità di un progetto 
            AnnullamentoPresentazioneProgetto = 8, // Annullare la presentazione di un progetto che passa da stato I a L e infine P
            EliminazioneDecretiMandatiLiquidazionePagamento = 9, // Eliminazione dei decreti e dei mandati di liquidazione di una domanda di pagamento
            RiaperturaLottoCertificazioneSpesa = 10 // Riapertura del lotto di certificazione di spesa
        }

        public RegistroModificheAutorizzateCollection RicercaModifiche(EnumTipoModificaAutorizzata? enumTipoModifica, string pass, IntNT idRiferimento)
        {
            throw new Exception("Funzione ricerca ancora non provata");
            RegistroModificheAutorizzate modifica = null;
            RegistroModificheAutorizzateCollection modificheCollection = new RegistroModificheAutorizzateCollection();

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpRicercaModificheAutorizzate";
            cmd.Parameters.Add(new SqlParameter("@IdTipoModifica", enumTipoModifica));
            cmd.Parameters.Add(new SqlParameter("@Pass", pass));
            cmd.Parameters.Add(new SqlParameter("@IdRiferimento", idRiferimento));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                modifica = (RegistroModificheAutorizzateDAL.GetFromDatareader(dbPro));
                modificheCollection.Add(modifica);
            }
            dbPro.Close();
            return modificheCollection;
        }

        //public void CopyProperties(BaseObject source, BaseObject destination)
        //{
        //    // Iterate the Properties of the destination instance and  
        //    // populate them from their source counterparts  
        //    //PropertyInfo[] destinationProperties = destination.GetType().GetProperties();
        //    //foreach (PropertyInfo destinationPi in destinationProperties)
        //    //{
        //    //    if (!destinationPi.Name.Contains("rovider")) //escludo il provider dalla copia
        //    //    {
        //    //        PropertyInfo sourcePi = source.GetType().GetProperty(destinationPi.Name);
        //    //        destinationPi.SetValue(destination, sourcePi.GetValue(source, null), null);
        //    //    }
        //    //}

        //    PropertyInfo[] sourceProperties = source.GetType().GetProperties();
        //    foreach (PropertyInfo sourcePi in sourceProperties)
        //    {
        //        if (!sourcePi.Name.Contains("rovider") //escludo il provider dalla copia
        //            && sourcePi.CanWrite) //e posso settare
        //        {
        //            PropertyInfo destinationPi = source.GetType().GetProperty(sourcePi.Name);
        //            sourcePi.SetValue(destination, sourcePi.GetValue(source, null), null);
        //        }
        //    }
        //}

        #region Copia OGGETTO in OGGETTO_MODIFICHE

        protected void CopiaDomandaPagamento(DomandaDiPagamento domandaDiPagamento, DomandaDiPagamentoModifiche domandaDiPagamentoModifiche)
        {
            domandaDiPagamentoModifiche.IdDomandaPagamento = domandaDiPagamento.IdDomandaPagamento;
            domandaDiPagamentoModifiche.CodTipo = domandaDiPagamento.CodTipo;
            domandaDiPagamentoModifiche.IdProgetto = domandaDiPagamento.IdProgetto;
            domandaDiPagamentoModifiche.DataInserimento = domandaDiPagamento.DataInserimento;
            domandaDiPagamentoModifiche.DataModifica = domandaDiPagamento.DataModifica;
            domandaDiPagamentoModifiche.CodEnte = domandaDiPagamento.CodEnte;
            domandaDiPagamentoModifiche.Segnatura = domandaDiPagamento.Segnatura;
            domandaDiPagamentoModifiche.Descrizione = domandaDiPagamento.Descrizione;
            domandaDiPagamentoModifiche.CodFase = domandaDiPagamento.CodFase;
            domandaDiPagamentoModifiche.Fase = domandaDiPagamento.Fase;
            domandaDiPagamentoModifiche.Ordine = domandaDiPagamento.Ordine;
            domandaDiPagamentoModifiche.IdFidejussione = domandaDiPagamento.IdFidejussione;
            domandaDiPagamentoModifiche.Operatore = domandaDiPagamento.Operatore;
            domandaDiPagamentoModifiche.CfOperatore = domandaDiPagamento.CfOperatore;
            domandaDiPagamentoModifiche.SegnaturaAllegati = domandaDiPagamento.SegnaturaAllegati;
            domandaDiPagamentoModifiche.DataCertificazioneAntimafia = domandaDiPagamento.DataCertificazioneAntimafia;
            domandaDiPagamentoModifiche.Approvata = domandaDiPagamento.Approvata;
            domandaDiPagamentoModifiche.SegnaturaApprovazione = domandaDiPagamento.SegnaturaApprovazione;
            domandaDiPagamentoModifiche.CfIstruttore = domandaDiPagamento.CfIstruttore;
            domandaDiPagamentoModifiche.DataApprovazione = domandaDiPagamento.DataApprovazione;
            domandaDiPagamentoModifiche.SegnaturaSecondaApprovazione = domandaDiPagamento.SegnaturaSecondaApprovazione;
            domandaDiPagamentoModifiche.Annullata = domandaDiPagamento.Annullata;
            domandaDiPagamentoModifiche.SegnaturaAnnullamento = domandaDiPagamento.SegnaturaAnnullamento;
            domandaDiPagamentoModifiche.CfOperatoreAnnullamento = domandaDiPagamento.CfOperatoreAnnullamento;
            domandaDiPagamentoModifiche.DataAnnullamento = domandaDiPagamento.DataAnnullamento;
            domandaDiPagamentoModifiche.ValiditaVersioneAdc = domandaDiPagamento.ValiditaVersioneAdc;
            domandaDiPagamentoModifiche.IdVariazioneAccertata = domandaDiPagamento.IdVariazioneAccertata;
            domandaDiPagamentoModifiche.PredispostaAControllo = domandaDiPagamento.PredispostaAControllo;
            domandaDiPagamentoModifiche.VisitaInsituEsito = domandaDiPagamento.VisitaInsituEsito;
            domandaDiPagamentoModifiche.VisitaInsituNote = domandaDiPagamento.VisitaInsituNote;
            domandaDiPagamentoModifiche.ControlloInlocoEsito = domandaDiPagamento.ControlloInlocoEsito;
            domandaDiPagamentoModifiche.ControlloInlocoNote = domandaDiPagamento.ControlloInlocoNote;
            domandaDiPagamentoModifiche.ValutazioneIstruttore = domandaDiPagamento.ValutazioneIstruttore;
            domandaDiPagamentoModifiche.VerificaPagamentiEsito = domandaDiPagamento.VerificaPagamentiEsito;
            domandaDiPagamentoModifiche.VerificaPagamentiMessaggio = domandaDiPagamento.VerificaPagamentiMessaggio;
            domandaDiPagamentoModifiche.VerificaPagamentiData = domandaDiPagamento.VerificaPagamentiData;
            domandaDiPagamentoModifiche.DataPredisposizioneAControllo = domandaDiPagamento.DataPredisposizioneAControllo;
            domandaDiPagamentoModifiche.NominativoOperatoreAnnullamento = domandaDiPagamento.NominativoOperatoreAnnullamento;
            domandaDiPagamentoModifiche.Istruttore = domandaDiPagamento.Istruttore;
            domandaDiPagamentoModifiche.FirmaPredisposta = domandaDiPagamento.FirmaPredisposta;
            domandaDiPagamentoModifiche.InIntegrazione = domandaDiPagamento.InIntegrazione;
            domandaDiPagamentoModifiche.FirmaPredispostaRup = domandaDiPagamento.FirmaPredispostaRup;
        }

        protected void CopiaAllegatoProtocollato(AllegatiProtocollati allegatoProtocollato, AllegatiProtocollatiModifiche allegatProtocollatoModifiche)
        {
            allegatProtocollatoModifiche.IdAllegatoProtocollato = allegatoProtocollato.IdAllegatoProtocollato;
            allegatProtocollatoModifiche.IdProgetto = allegatoProtocollato.IdProgetto;
            allegatProtocollatoModifiche.IdDomandaPagamento = allegatoProtocollato.IdDomandaPagamento;
            allegatProtocollatoModifiche.IdVariante = allegatoProtocollato.IdVariante;
            allegatProtocollatoModifiche.IdIntegrazione = allegatoProtocollato.IdIntegrazione;
            allegatProtocollatoModifiche.IdComunicazione = allegatoProtocollato.IdComunicazione;
            allegatProtocollatoModifiche.IdFile = allegatoProtocollato.IdFile;
            allegatProtocollatoModifiche.Protocollato = allegatoProtocollato.Protocollato;
            allegatProtocollatoModifiche.Protocollo = allegatoProtocollato.Protocollo;
            allegatProtocollatoModifiche.DataInserimento = allegatoProtocollato.DataInserimento;
            allegatProtocollatoModifiche.DataModifica = allegatoProtocollato.DataModifica;
        }

        protected void CopiaVariante(Varianti variante, VariantiModifiche varianteModifiche)
        {
            varianteModifiche.IdVariante = variante.IdVariante;
            varianteModifiche.IdProgetto = variante.IdProgetto;
            varianteModifiche.CodTipo = variante.CodTipo;
            varianteModifiche.DataInserimento = variante.DataInserimento;
            varianteModifiche.CodEnte = variante.CodEnte;
            varianteModifiche.Operatore = variante.Operatore;
            varianteModifiche.DataModifica = variante.DataModifica;
            varianteModifiche.Segnatura = variante.Segnatura;
            varianteModifiche.SegnaturaAllegati = variante.SegnaturaAllegati;
            varianteModifiche.SegnaturaApprovazione = variante.SegnaturaApprovazione;
            varianteModifiche.Approvata = variante.Approvata;
            varianteModifiche.Istruttore = variante.Istruttore;
            varianteModifiche.NoteIstruttore = variante.NoteIstruttore;
            varianteModifiche.TipoVariante = variante.TipoVariante;
            varianteModifiche.Nominativo = variante.Nominativo;
            varianteModifiche.Profilo = variante.Profilo;
            varianteModifiche.Ente = variante.Ente;
            varianteModifiche.DataApprovazione = variante.DataApprovazione;
            varianteModifiche.Provincia = variante.Provincia;
            varianteModifiche.Descrizione = variante.Descrizione;
            varianteModifiche.Annullata = variante.Annullata;
            varianteModifiche.SegnaturaAnnullamento = variante.SegnaturaAnnullamento;
            varianteModifiche.CfOperatoreAnnullamento = variante.CfOperatoreAnnullamento;
            varianteModifiche.DataAnnullamento = variante.DataAnnullamento;
            varianteModifiche.NominativoOperatoreAnnullamento = variante.NominativoOperatoreAnnullamento;
            varianteModifiche.NominativoIstruttore = variante.NominativoIstruttore;
            varianteModifiche.CuaaEntrante = variante.CuaaEntrante;
            varianteModifiche.IdFascicoloEntrante = variante.IdFascicoloEntrante;
            varianteModifiche.CuaaUscente = variante.CuaaUscente;
            varianteModifiche.IdFascicoloUscente = variante.IdFascicoloUscente;
            varianteModifiche.RagsocUscente = variante.RagsocUscente;
            varianteModifiche.IdAttoApprovazione = variante.IdAttoApprovazione;
            varianteModifiche.AwDocnumber = variante.AwDocnumber;
            varianteModifiche.CodDefinizione = variante.CodDefinizione;
            varianteModifiche.AwDocnumberNuovo = variante.AwDocnumberNuovo;
            varianteModifiche.FirmaPredispostaRup = variante.FirmaPredispostaRup;
            varianteModifiche.FirmaPredisposta = variante.FirmaPredisposta;
        }

        public void CopiaEsitoIstanzaChecklistGenerico(EsitoIstanzaChecklistGenerico esito, EsitoIstanzaChecklistGenericoModifiche esitoModifiche)
        {
            esitoModifiche.IdEsitoGenerico = esito.IdEsitoGenerico;
            esitoModifiche.IdVoceGenerica = esito.IdVoceGenerica;
            esitoModifiche.IdIstanzaGenerica = esito.IdIstanzaGenerica;
            esitoModifiche.CodEsito = esito.CodEsito;
            esitoModifiche.DataInserimento = esito.DataInserimento;
            esitoModifiche.CfInserimento = esito.CfInserimento;
            esitoModifiche.DataModifica = esito.DataModifica;
            esitoModifiche.CfModifica = esito.CfModifica;
            esitoModifiche.Note = esito.Note;
            esitoModifiche.CodEsitoRevisore = esito.CodEsitoRevisore;
            esitoModifiche.DataRevisore = esito.DataRevisore;
            esitoModifiche.Revisore = esito.Revisore;
            esitoModifiche.NoteRevisore = esito.NoteRevisore;
            esitoModifiche.EscludiDaComunicazione = esito.EscludiDaComunicazione;
            esitoModifiche.Descrizione = esito.Descrizione;
            esitoModifiche.EsitoPositivo = esito.EsitoPositivo;
            esitoModifiche.DescrizioneEsitoRevisore = esito.DescrizioneEsitoRevisore;
            esitoModifiche.EsitoPositivoRevisore = esito.EsitoPositivoRevisore;
            esitoModifiche.DescrizioneVoceGenerica = esito.DescrizioneVoceGenerica;
            esitoModifiche.Automatico = esito.Automatico;
            esitoModifiche.QuerySql = esito.QuerySql;
            esitoModifiche.QuerySqlPost = esito.QuerySqlPost;
            esitoModifiche.CodeMethod = esito.CodeMethod;
            esitoModifiche.Url = esito.Url;
            esitoModifiche.ValMinimo = esito.ValMinimo;
            esitoModifiche.ValMassimo = esito.ValMassimo;
            esitoModifiche.Ordine = esito.Ordine;
            esitoModifiche.Obbligatorio = esito.Obbligatorio;
            esitoModifiche.Peso = esito.Peso;
            esitoModifiche.IdChecklistGenerica = esito.IdChecklistGenerica;
            esitoModifiche.DescrizioneChecklistGenerica = esito.DescrizioneChecklistGenerica;
            esitoModifiche.Valore = esito.Valore;
            esitoModifiche.ValEsitoNegativo = esito.ValEsitoNegativo;
            esitoModifiche.Misura = esito.Misura;
            esitoModifiche.IdVoceXChecklistGenerica = esito.IdVoceXChecklistGenerica;
        }

        public void CopiaIstanzaChecklistGenerica(IstanzaChecklistGenerica istanzaChecklistGenerica, IstanzaChecklistGenericaModifiche istanzaChecklistGenericaModifiche)
        {
            istanzaChecklistGenericaModifiche.IdIstanzaGenerica = istanzaChecklistGenerica.IdIstanzaGenerica;
            istanzaChecklistGenericaModifiche.IdChecklistGenerica = istanzaChecklistGenerica.IdChecklistGenerica;
            istanzaChecklistGenericaModifiche.DataInserimento = istanzaChecklistGenerica.DataInserimento;
            istanzaChecklistGenericaModifiche.CfInserimento = istanzaChecklistGenerica.CfInserimento;
            istanzaChecklistGenericaModifiche.DataModifica = istanzaChecklistGenerica.DataModifica;
            istanzaChecklistGenericaModifiche.CfModifica = istanzaChecklistGenerica.CfModifica;
            istanzaChecklistGenericaModifiche.Descrizione = istanzaChecklistGenerica.Descrizione;
            istanzaChecklistGenericaModifiche.FlagTemplate = istanzaChecklistGenerica.FlagTemplate;
            istanzaChecklistGenericaModifiche.CodFase = istanzaChecklistGenerica.CodFase;
            istanzaChecklistGenericaModifiche.IdChecklistPadre = istanzaChecklistGenerica.IdChecklistPadre;
            istanzaChecklistGenericaModifiche.IdSchedaXChecklist = istanzaChecklistGenerica.IdSchedaXChecklist;
        }

        public void CopiaSchedaXChecklistGenerico(SchedaXChecklist schedaXChecklist, SchedaXChecklistModifiche schedaXChecklistModifiche)
        {
            schedaXChecklistModifiche.IdSchedaXChecklist = schedaXChecklist.IdSchedaXChecklist;
            schedaXChecklistModifiche.CfInserimento = schedaXChecklist.CfInserimento;
            schedaXChecklistModifiche.DataInserimento = schedaXChecklist.DataInserimento;
            schedaXChecklistModifiche.CfModifica = schedaXChecklist.CfModifica;
            schedaXChecklistModifiche.DataModifica = schedaXChecklist.DataModifica;
            schedaXChecklistModifiche.IdChecklistPadre = schedaXChecklist.IdChecklistPadre;
            schedaXChecklistModifiche.IdChecklistFiglio = schedaXChecklist.IdChecklistFiglio;
            schedaXChecklistModifiche.Ordine = schedaXChecklist.Ordine;
            schedaXChecklistModifiche.Obbligatorio = schedaXChecklist.Obbligatorio;
            schedaXChecklistModifiche.Peso = schedaXChecklist.Peso;
            schedaXChecklistModifiche.DescrizioneChecklist = schedaXChecklist.DescrizioneChecklist;
            schedaXChecklistModifiche.FlagTemplateChecklist = schedaXChecklist.FlagTemplateChecklist;
            schedaXChecklistModifiche.IdTipoChecklist = schedaXChecklist.IdTipoChecklist;
            schedaXChecklistModifiche.DescrizioneTipoChecklist = schedaXChecklist.DescrizioneTipoChecklist;
            schedaXChecklistModifiche.ContieneVociChecklist = schedaXChecklist.ContieneVociChecklist;
            schedaXChecklistModifiche.SchedaChecklist = schedaXChecklist.SchedaChecklist;
            schedaXChecklistModifiche.IdFiltroChecklist = schedaXChecklist.IdFiltroChecklist;
            schedaXChecklistModifiche.DescrizioneFiltroChecklist = schedaXChecklist.DescrizioneFiltroChecklist;
            schedaXChecklistModifiche.OrdineFiltroChecklist = schedaXChecklist.OrdineFiltroChecklist;
            schedaXChecklistModifiche.IdTipoScheda = schedaXChecklist.IdTipoScheda;
            schedaXChecklistModifiche.DescrizioneTipoScheda = schedaXChecklist.DescrizioneTipoScheda;
            schedaXChecklistModifiche.ContieneVociScheda = schedaXChecklist.ContieneVociScheda;
            schedaXChecklistModifiche.SchedaScheda = schedaXChecklist.SchedaScheda;
            schedaXChecklistModifiche.IdFiltroScheda = schedaXChecklist.IdFiltroScheda;
            schedaXChecklistModifiche.DescrizioneFiltroScheda = schedaXChecklist.DescrizioneFiltroScheda;
            schedaXChecklistModifiche.OrdineFiltroScheda = schedaXChecklist.OrdineFiltroScheda;
        }

        public void CopiaTestataValidazioneXIstanza(TestataValidazioneXIstanza testataValidazioneXIstanza, TestataValidazioneXIstanzaModifiche testataValidazioneXIstanzaModifiche)
        {
            testataValidazioneXIstanzaModifiche.IdTestataValidazioneXIstanza = testataValidazioneXIstanza.IdTestataValidazioneXIstanza;
            testataValidazioneXIstanzaModifiche.CfInserimento = testataValidazioneXIstanza.CfInserimento;
            testataValidazioneXIstanzaModifiche.DataInserimento = testataValidazioneXIstanza.DataInserimento;
            testataValidazioneXIstanzaModifiche.CfModifica = testataValidazioneXIstanza.CfModifica;
            testataValidazioneXIstanzaModifiche.DataModifica = testataValidazioneXIstanza.DataModifica;
            testataValidazioneXIstanzaModifiche.IdTestataValidazione = testataValidazioneXIstanza.IdTestataValidazione;
            testataValidazioneXIstanzaModifiche.IdIstanzaChecklistGenerica = testataValidazioneXIstanza.IdIstanzaChecklistGenerica;
            testataValidazioneXIstanzaModifiche.Ordine = testataValidazioneXIstanza.Ordine;
            testataValidazioneXIstanzaModifiche.Note = testataValidazioneXIstanza.Note;
            testataValidazioneXIstanzaModifiche.Autovalutazione = testataValidazioneXIstanza.Autovalutazione;
            testataValidazioneXIstanzaModifiche.Approvata = testataValidazioneXIstanza.Approvata;
            testataValidazioneXIstanzaModifiche.DataValidazione = testataValidazioneXIstanza.DataValidazione;
            testataValidazioneXIstanzaModifiche.CfValidatore = testataValidazioneXIstanza.CfValidatore;
            testataValidazioneXIstanzaModifiche.NominativoValidatore = testataValidazioneXIstanza.NominativoValidatore;
            testataValidazioneXIstanzaModifiche.IdChecklistGenerica = testataValidazioneXIstanza.IdChecklistGenerica;
            testataValidazioneXIstanzaModifiche.CodFaseIstanza = testataValidazioneXIstanza.CodFaseIstanza;
            testataValidazioneXIstanzaModifiche.DescrizioneChecklist = testataValidazioneXIstanza.DescrizioneChecklist;
            testataValidazioneXIstanzaModifiche.FlagTemplateChecklist = testataValidazioneXIstanza.FlagTemplateChecklist;
            testataValidazioneXIstanzaModifiche.IdFiltroChecklist = testataValidazioneXIstanza.IdFiltroChecklist;
            testataValidazioneXIstanzaModifiche.IdTipoChecklist = testataValidazioneXIstanza.IdTipoChecklist;
        }

        public void CopiaChecklistGenerica(ChecklistGenerica checklistGenerica, ChecklistGenericaModifiche checklistGenericaModifiche)
        {
            checklistGenericaModifiche.IdChecklistGenerica = checklistGenerica.IdChecklistGenerica;
            checklistGenericaModifiche.Descrizione = checklistGenerica.Descrizione;
            checklistGenericaModifiche.FlagTemplate = checklistGenerica.FlagTemplate;
            checklistGenericaModifiche.DataInserimento = checklistGenerica.DataInserimento;
            checklistGenericaModifiche.CfInserimento = checklistGenerica.CfInserimento;
            checklistGenericaModifiche.DataModifica = checklistGenerica.DataModifica;
            checklistGenericaModifiche.CfModifica = checklistGenerica.CfModifica;
            checklistGenericaModifiche.IdTipo = checklistGenerica.IdTipo;
            checklistGenericaModifiche.IdFiltro = checklistGenerica.IdFiltro;
            checklistGenericaModifiche.DescrizioneTipo = checklistGenerica.DescrizioneTipo;
            checklistGenericaModifiche.ContieneVociTipo = checklistGenerica.ContieneVociTipo;
            checklistGenericaModifiche.SchedaTipo = checklistGenerica.SchedaTipo;
            checklistGenericaModifiche.DescrizioneFiltro = checklistGenerica.DescrizioneFiltro;
            checklistGenericaModifiche.OrdineFiltro = checklistGenerica.OrdineFiltro;
        }

        public void CopiaTestataValidazione(TestataValidazione testataValidazione, TestataValidazioneModifiche testataValidazioneModifiche)
        {
            testataValidazioneModifiche.IdTestata = testataValidazione.IdTestata;
            testataValidazioneModifiche.IdDomandaPagamento = testataValidazione.IdDomandaPagamento;
            testataValidazioneModifiche.TipoDomandaPagamento = testataValidazione.TipoDomandaPagamento;
            testataValidazioneModifiche.CodFase = testataValidazione.CodFase;
            testataValidazioneModifiche.DataPresentazioneDomandaPagamento = testataValidazione.DataPresentazioneDomandaPagamento;
            testataValidazioneModifiche.DomandaApprovata = testataValidazione.DomandaApprovata;
            testataValidazioneModifiche.SegnaturaApprovazioneDomanda = testataValidazione.SegnaturaApprovazioneDomanda;
            testataValidazioneModifiche.IdProgetto = testataValidazione.IdProgetto;
            testataValidazioneModifiche.IdLotto = testataValidazione.IdLotto;
            testataValidazioneModifiche.CfInserimento = testataValidazione.CfInserimento;
            testataValidazioneModifiche.DataInserimento = testataValidazione.DataInserimento;
            testataValidazioneModifiche.CfModifica = testataValidazione.CfModifica;
            testataValidazioneModifiche.DataModifica = testataValidazione.DataModifica;
            testataValidazioneModifiche.CfValidatore = testataValidazione.CfValidatore;
            testataValidazioneModifiche.NominativoValidatore = testataValidazione.NominativoValidatore;
            testataValidazioneModifiche.SelezionataXRevisione = testataValidazione.SelezionataXRevisione;
            testataValidazioneModifiche.Approvata = testataValidazione.Approvata;
            testataValidazioneModifiche.NumeroEstrazione = testataValidazione.NumeroEstrazione;
            testataValidazioneModifiche.Ordine = testataValidazione.Ordine;
            testataValidazioneModifiche.SegnaturaRevisione = testataValidazione.SegnaturaRevisione;
            testataValidazioneModifiche.SegnaturaSecondaRevisione = testataValidazione.SegnaturaSecondaRevisione;
            testataValidazioneModifiche.DataValidazione = testataValidazione.DataValidazione;
            testataValidazioneModifiche.Autovalutazione = testataValidazione.Autovalutazione;
            testataValidazioneModifiche.CodTipo = testataValidazione.CodTipo;
            testataValidazioneModifiche.DataApprovazione = testataValidazione.DataApprovazione;
            testataValidazioneModifiche.IdBando = testataValidazione.IdBando;
            testataValidazioneModifiche.ProvinciaDiPresentazione = testataValidazione.ProvinciaDiPresentazione;
        }

        public void CopiaDomandaPagamentoLiquidazione(DomandaPagamentoLiquidazione domandaPagamentoLiquidazione, DomandaPagamentoLiquidazioneModifiche domandaPagamentoLiquidazioneModifiche)
        {
            domandaPagamentoLiquidazioneModifiche.Id = domandaPagamentoLiquidazione.Id;
            domandaPagamentoLiquidazioneModifiche.IdDomandaPagamento = domandaPagamentoLiquidazione.IdDomandaPagamento;
            domandaPagamentoLiquidazioneModifiche.IdProgetto = domandaPagamentoLiquidazione.IdProgetto;
            domandaPagamentoLiquidazioneModifiche.IdImpresaBeneficiaria = domandaPagamentoLiquidazione.IdImpresaBeneficiaria;
            domandaPagamentoLiquidazioneModifiche.IdDecreto = domandaPagamentoLiquidazione.IdDecreto;
            domandaPagamentoLiquidazioneModifiche.RichiestaMandatoImporto = domandaPagamentoLiquidazione.RichiestaMandatoImporto;
            domandaPagamentoLiquidazioneModifiche.RichiestaMandatoSegnatura = domandaPagamentoLiquidazione.RichiestaMandatoSegnatura;
            domandaPagamentoLiquidazioneModifiche.RichiestaMandatoData = domandaPagamentoLiquidazione.RichiestaMandatoData;
            domandaPagamentoLiquidazioneModifiche.MandatoNumero = domandaPagamentoLiquidazione.MandatoNumero;
            domandaPagamentoLiquidazioneModifiche.MandatoData = domandaPagamentoLiquidazione.MandatoData;
            domandaPagamentoLiquidazioneModifiche.MandatoImporto = domandaPagamentoLiquidazione.MandatoImporto;
            domandaPagamentoLiquidazioneModifiche.MandatoIdFile = domandaPagamentoLiquidazione.MandatoIdFile;
            domandaPagamentoLiquidazioneModifiche.QuietanzaData = domandaPagamentoLiquidazione.QuietanzaData;
            domandaPagamentoLiquidazioneModifiche.QuietanzaImporto = domandaPagamentoLiquidazione.QuietanzaImporto;
            domandaPagamentoLiquidazioneModifiche.Liquidato = domandaPagamentoLiquidazione.Liquidato;
        }

        public void CopiaProgetto(Progetto progetto, ProgettoModifiche progettoModifiche)
        {
            progettoModifiche.IdProgetto = progetto.IdProgetto;
            progettoModifiche.IdBando = progetto.IdBando;
            progettoModifiche.CodAgea = progetto.CodAgea;
            progettoModifiche.SegnaturaAllegati = progetto.SegnaturaAllegati;
            progettoModifiche.CodStato = progetto.CodStato;
            progettoModifiche.Data = progetto.Data;
            progettoModifiche.Operatore = progetto.Operatore;
            progettoModifiche.Segnatura = progetto.Segnatura;
            progettoModifiche.Revisione = progetto.Revisione;
            progettoModifiche.Riesame = progetto.Riesame;
            progettoModifiche.Ricorso = progetto.Ricorso;
            progettoModifiche.DataRi = progetto.DataRi;
            progettoModifiche.OperatoreRi = progetto.OperatoreRi;
            progettoModifiche.SegnaturaRi = progetto.SegnaturaRi;
            progettoModifiche.Stato = progetto.Stato;
            progettoModifiche.CodFase = progetto.CodFase;
            progettoModifiche.OrdineStato = progetto.OrdineStato;
            progettoModifiche.Fase = progetto.Fase;
            progettoModifiche.OrdineFase = progetto.OrdineFase;
            progettoModifiche.IdProgIntegrato = progetto.IdProgIntegrato;
            progettoModifiche.FlagPreadesione = progetto.FlagPreadesione;
            progettoModifiche.FlagDefinitivo = progetto.FlagDefinitivo;
            progettoModifiche.IdFascicolo = progetto.IdFascicolo;
            progettoModifiche.ProvinciaDiPresentazione = progetto.ProvinciaDiPresentazione;
            progettoModifiche.SelezionataXRevisione = progetto.SelezionataXRevisione;
            progettoModifiche.IdImpresa = progetto.IdImpresa;
            progettoModifiche.IdStoricoUltimo = progetto.IdStoricoUltimo;
            progettoModifiche.DataCreazione = progetto.DataCreazione;
            progettoModifiche.OperatoreCreazione = progetto.OperatoreCreazione;
            progettoModifiche.Nominativo = progetto.Nominativo;
            progettoModifiche.Ente = progetto.Ente;
            progettoModifiche.CodEnte = progetto.CodEnte;
            progettoModifiche.Provincia = progetto.Provincia;
            progettoModifiche.CodTipoEnte = progetto.CodTipoEnte;
            progettoModifiche.RiaperturaProvinciale = progetto.RiaperturaProvinciale;
            progettoModifiche.FirmaPredisposta = progetto.FirmaPredisposta;
            progettoModifiche.IdAtto = progetto.IdAtto;
        }

        public void CopiaProgettoStorico(ProgettoStorico progettoStorico, ProgettoStoricoModifiche progettoStoricoModifiche)
        {
            progettoStoricoModifiche.IdProgettoStorico = progettoStorico.Id;
            progettoStoricoModifiche.IdProgetto = progettoStorico.IdProgetto;
            progettoStoricoModifiche.CodStato = progettoStorico.CodStato;
            progettoStoricoModifiche.Data = progettoStorico.Data;
            progettoStoricoModifiche.Operatore = progettoStorico.Operatore;
            progettoStoricoModifiche.Segnatura = progettoStorico.Segnatura;
            progettoStoricoModifiche.Revisione = progettoStorico.Revisione;
            progettoStoricoModifiche.Riesame = progettoStorico.Riesame;
            progettoStoricoModifiche.Ricorso = progettoStorico.Ricorso;
            progettoStoricoModifiche.RiaperturaProvinciale = progettoStorico.RiaperturaProvinciale;
            progettoStoricoModifiche.DataRi = progettoStorico.DataRi;
            progettoStoricoModifiche.OperatoreRi = progettoStorico.OperatoreRi;
            progettoStoricoModifiche.SegnaturaRi = progettoStorico.SegnaturaRi;
            progettoStoricoModifiche.Stato = progettoStorico.Stato;
            progettoStoricoModifiche.CodFase = progettoStorico.CodFase;
            progettoStoricoModifiche.OrdineStato = progettoStorico.OrdineStato;
            progettoStoricoModifiche.Fase = progettoStorico.Fase;
            progettoStoricoModifiche.OrdineFase = progettoStorico.OrdineFase;
            progettoStoricoModifiche.Nominativo = progettoStorico.Nominativo;
            progettoStoricoModifiche.CodEnte = progettoStorico.CodEnte;
            progettoStoricoModifiche.Provincia = progettoStorico.Provincia;
            progettoStoricoModifiche.IdProfilo = progettoStorico.IdProfilo;
            progettoStoricoModifiche.Profilo = progettoStorico.Profilo;
            progettoStoricoModifiche.Ente = progettoStorico.Ente;
            progettoStoricoModifiche.CodTipoEnte = progettoStorico.CodTipoEnte;
            progettoStoricoModifiche.IdAtto = progettoStorico.IdAtto;
        }

        public void CopiaIterProgetto(IterProgetto iterProgetto, IterProgettoModifiche iterProgettoModifiche)
        {
            iterProgettoModifiche.IdProgetto = iterProgetto.IdProgetto;
            iterProgettoModifiche.IdStep = iterProgetto.IdStep;
            iterProgettoModifiche.CodEsito = iterProgetto.CodEsito;
            iterProgettoModifiche.Data = iterProgetto.Data;
            iterProgettoModifiche.CfOperatore = iterProgetto.CfOperatore;
            iterProgettoModifiche.Note = iterProgetto.Note;
            iterProgettoModifiche.CodEsitoRevisore = iterProgetto.CodEsitoRevisore;
            iterProgettoModifiche.DataRevisore = iterProgetto.DataRevisore;
            iterProgettoModifiche.Revisore = iterProgetto.Revisore;
            iterProgettoModifiche.NoteRevisore = iterProgetto.NoteRevisore;
            iterProgettoModifiche.EsitoIstruttore = iterProgetto.EsitoIstruttore;
            iterProgettoModifiche.EsitoPositivoIstruttore = iterProgetto.EsitoPositivoIstruttore;
            iterProgettoModifiche.EsitoRevisore = iterProgetto.EsitoRevisore;
            iterProgettoModifiche.EsitoPositivoRevisore = iterProgetto.EsitoPositivoRevisore;
            iterProgettoModifiche.IdBando = iterProgetto.IdBando;
            iterProgettoModifiche.SelezionataXRevisione = iterProgetto.SelezionataXRevisione;
            iterProgettoModifiche.IdCheckList = iterProgetto.IdCheckList;
            iterProgettoModifiche.CodFase = iterProgetto.CodFase;
            iterProgettoModifiche.Ordine = iterProgetto.Ordine;
            iterProgettoModifiche.Obbligatorio = iterProgetto.Obbligatorio;
            iterProgettoModifiche.Step = iterProgetto.Step;
            iterProgettoModifiche.Automatico = iterProgetto.Automatico;
            iterProgettoModifiche.QuerySql = iterProgetto.QuerySql;
            iterProgettoModifiche.QuerySqlPost = iterProgetto.QuerySqlPost;
            iterProgettoModifiche.CodeMethod = iterProgetto.CodeMethod;
            iterProgettoModifiche.Url = iterProgetto.Url;
            iterProgettoModifiche.ValMinimo = iterProgetto.ValMinimo;
            iterProgettoModifiche.ValMassimo = iterProgetto.ValMassimo;
            iterProgettoModifiche.Misura = iterProgetto.Misura;
            // queste due non sono presenti sull'oggetto originale ma sono solo su db come facciamo??
            iterProgettoModifiche.EscludiDaComunicazione = null;
            iterProgettoModifiche.IncludiVerbaleVis = null;
        }

        public void CopiaPianoInvestimenti(PianoInvestimenti pianoInvestimenti, PianoInvestimentiModifiche pianoInvestimentiModifiche)
        {
            pianoInvestimentiModifiche.IdImpresaAggregazione = pianoInvestimenti.IdImpresaAggregazione;
            pianoInvestimentiModifiche.IdInvestimento = pianoInvestimenti.IdInvestimento;
            pianoInvestimentiModifiche.IdProgetto = pianoInvestimenti.IdProgetto;
            pianoInvestimentiModifiche.IdProgrammazione = pianoInvestimenti.IdProgrammazione;
            pianoInvestimentiModifiche.Descrizione = pianoInvestimenti.Descrizione;
            pianoInvestimentiModifiche.DataVariazione = pianoInvestimenti.DataVariazione;
            pianoInvestimentiModifiche.OperatoreVariazione = pianoInvestimenti.OperatoreVariazione;
            pianoInvestimentiModifiche.CodStp = pianoInvestimenti.CodStp;
            pianoInvestimentiModifiche.IdUnitaMisura = pianoInvestimenti.IdUnitaMisura;
            pianoInvestimentiModifiche.Quantita = pianoInvestimenti.Quantita;
            pianoInvestimentiModifiche.CostoInvestimento = pianoInvestimenti.CostoInvestimento;
            pianoInvestimentiModifiche.SpeseGenerali = pianoInvestimenti.SpeseGenerali;
            pianoInvestimentiModifiche.ContributoRichiesto = pianoInvestimenti.ContributoRichiesto;
            pianoInvestimentiModifiche.QuotaContributoRichiesto = pianoInvestimenti.QuotaContributoRichiesto;
            pianoInvestimentiModifiche.IdSettoreProduttivo = pianoInvestimenti.IdSettoreProduttivo;
            pianoInvestimentiModifiche.IdPrioritaSettoriale = pianoInvestimenti.IdPrioritaSettoriale;
            pianoInvestimentiModifiche.IdObiettivoMisura = pianoInvestimenti.IdObiettivoMisura;
            pianoInvestimentiModifiche.Ammesso = pianoInvestimenti.Ammesso;
            pianoInvestimentiModifiche.Istruttore = pianoInvestimenti.Istruttore;
            pianoInvestimentiModifiche.IdInvestimentoOriginale = pianoInvestimenti.IdInvestimentoOriginale;
            pianoInvestimentiModifiche.DataValutazione = pianoInvestimenti.DataValutazione;
            pianoInvestimentiModifiche.IdCodificaInvestimento = pianoInvestimenti.IdCodificaInvestimento;
            pianoInvestimentiModifiche.IdDettaglioInvestimento = pianoInvestimenti.IdDettaglioInvestimento;
            pianoInvestimentiModifiche.IdSpecificaInvestimento = pianoInvestimenti.IdSpecificaInvestimento;
            pianoInvestimentiModifiche.CodTp = pianoInvestimenti.CodTp;
            pianoInvestimentiModifiche.CodificaInvestimento = pianoInvestimenti.CodificaInvestimento;
            pianoInvestimentiModifiche.AiutoMinimo = pianoInvestimenti.AiutoMinimo;
            pianoInvestimentiModifiche.Codice = pianoInvestimenti.Codice;
            pianoInvestimentiModifiche.CodSpecifica = pianoInvestimenti.CodSpecifica;
            pianoInvestimentiModifiche.SpecificaInvestimenti = pianoInvestimenti.SpecificaInvestimenti;
            pianoInvestimentiModifiche.DettaglioInvestimenti = pianoInvestimenti.DettaglioInvestimenti;
            pianoInvestimentiModifiche.Mobile = pianoInvestimenti.Mobile;
            pianoInvestimentiModifiche.QuotaSpeseGenerali = pianoInvestimenti.QuotaSpeseGenerali;
            pianoInvestimentiModifiche.CodTipoInvestimento = pianoInvestimenti.CodTipoInvestimento;
            pianoInvestimentiModifiche.RichiediParticella = pianoInvestimenti.RichiediParticella;
            pianoInvestimentiModifiche.ValutazioneInvestimento = pianoInvestimenti.ValutazioneInvestimento;
            pianoInvestimentiModifiche.IdVariante = pianoInvestimenti.IdVariante;
            pianoInvestimentiModifiche.CodVariazione = pianoInvestimenti.CodVariazione;
            pianoInvestimentiModifiche.TassoAbbuono = pianoInvestimenti.TassoAbbuono;
            pianoInvestimentiModifiche.Misura = pianoInvestimenti.Misura;
            pianoInvestimentiModifiche.Misura = pianoInvestimenti.Misura;
            pianoInvestimentiModifiche.IdMisura = pianoInvestimenti.IdMisura;
            pianoInvestimentiModifiche.NonCofinanziato = pianoInvestimenti.NonCofinanziato;
            pianoInvestimentiModifiche.IsMax = pianoInvestimenti.IsMax;
            pianoInvestimentiModifiche.ContributoAltreFonti = pianoInvestimenti.ContributoAltreFonti;
            pianoInvestimentiModifiche.QuotaContributoAltreFonti = pianoInvestimenti.QuotaContributoAltreFonti;
            pianoInvestimentiModifiche.IdImpresaAggregazione = pianoInvestimenti.IdImpresaAggregazione;

        }

        public void CopiaPrioritaXinvestimenti(PrioritaXInvestimenti prioritaXInvestimenti, PrioritaXInvestimentiModifiche prioritaXInvestimentiModifiche)
        {
            prioritaXInvestimentiModifiche.IdPriorita = prioritaXInvestimenti.IdPriorita;
            prioritaXInvestimentiModifiche.IdInvestimento = prioritaXInvestimenti.IdInvestimento;
            prioritaXInvestimentiModifiche.IdValore = prioritaXInvestimenti.IdValore;
            prioritaXInvestimentiModifiche.Scelto = prioritaXInvestimenti.Scelto;
            prioritaXInvestimentiModifiche.Descrizione = prioritaXInvestimenti.Descrizione;
            prioritaXInvestimentiModifiche.ValorePunteggio = prioritaXInvestimenti.ValorePunteggio;
            prioritaXInvestimentiModifiche.Valore = prioritaXInvestimenti.Valore;
            prioritaXInvestimentiModifiche.ValData = prioritaXInvestimenti.ValData;
            prioritaXInvestimentiModifiche.ValTesto = prioritaXInvestimenti.ValTesto;

        }

        public void CopiaDecretiXDomPagEsportazione(DecretiXDomPagEsportazione decreto, DecretiXDomPagEsportazioneModifiche decretoModifiche)
        {
            decretoModifiche.IdDecretiXDomPagEsportazione = decreto.IdDecretiXDomPagEsportazione;
            decretoModifiche.IdDomandaPagamento = decreto.IdDomandaPagamento;
            decretoModifiche.IdProgetto = decreto.IdProgetto;
            decretoModifiche.IdDecreto = decreto.IdDecreto;
            decretoModifiche.Importo = decreto.Importo;
            decretoModifiche.DataInserimento = decreto.DataInserimento;
            decretoModifiche.DataModifica = decreto.DataModifica;
            decretoModifiche.IdAtto = decreto.IdAtto;
            decretoModifiche.Numero = decreto.Numero;
            decretoModifiche.Data = decreto.Data;
            decretoModifiche.Descrizione = decreto.Descrizione;
            decretoModifiche.Servizio = decreto.Servizio;
            decretoModifiche.Registro = decreto.Registro;
            decretoModifiche.CodTipo = decreto.CodTipo;
            decretoModifiche.CodDefinizione = decreto.CodDefinizione;
            decretoModifiche.CodOrganoIstituzionale = decreto.CodOrganoIstituzionale;
            decretoModifiche.DataBur = decreto.DataBur;
            decretoModifiche.NumeroBur = decreto.NumeroBur;
            decretoModifiche.AwDocnumber = decreto.AwDocnumber;
            decretoModifiche.AwDocnumberNuovo = decreto.AwDocnumberNuovo;
            decretoModifiche.DefinizioneAtto = decreto.DefinizioneAtto;
            decretoModifiche.TipoAtto = decreto.TipoAtto;
            decretoModifiche.OrganoIstituzionale = decreto.OrganoIstituzionale;
            decretoModifiche.LinkEsterno = decreto.LinkEsterno;
        }

        public void CopiaCertSpTesta(CertspTesta certSpTesta, CertspTestaModifiche certSpTestaModifiche)
        {
            certSpTestaModifiche.Idcertsp = certSpTesta.Idcertsp;
            certSpTestaModifiche.Codpsr = certSpTesta.Codpsr;
            certSpTestaModifiche.Datainizio = certSpTesta.Datainizio;
            certSpTestaModifiche.Datafine = certSpTesta.Datafine;
            certSpTestaModifiche.IdFile = certSpTesta.IdFile;
            certSpTestaModifiche.Note = certSpTesta.Note;
            certSpTestaModifiche.Definitivo = certSpTesta.Definitivo;
            certSpTestaModifiche.Tipo = certSpTesta.Tipo;
            certSpTestaModifiche.Datainserimento = certSpTesta.Datainserimento;
            certSpTestaModifiche.Datamodifica = certSpTesta.Datamodifica;
            certSpTestaModifiche.Operatore = certSpTesta.Operatore;
            certSpTestaModifiche.Datasegnatura = certSpTesta.Datasegnatura;
            certSpTestaModifiche.Segnatura = certSpTesta.Segnatura;
            certSpTestaModifiche.SegnaturaCertificazione = certSpTesta.SegnaturaCertificazione;
        }

        public void CopiaCertDecertificazione(CertDecertificazione certDecertificazione, CertDecertificazioneModifiche certDecertificazioneModifiche)
        {
            certDecertificazioneModifiche.IdCertDecertificazione = certDecertificazione.IdCertDecertificazione;
            certDecertificazioneModifiche.IdProgetto = certDecertificazione.IdProgetto;
            certDecertificazioneModifiche.IdDomandaPagamento = certDecertificazione.IdDomandaPagamento;
            certDecertificazioneModifiche.IdDecertificazione = certDecertificazione.IdDecertificazione;
            certDecertificazioneModifiche.TipoDecertificazione = certDecertificazione.TipoDecertificazione;
            certDecertificazioneModifiche.ImportoDecertificazioneAmmesso = certDecertificazione.ImportoDecertificazioneAmmesso;
            certDecertificazioneModifiche.ImportoDecertificazioneConcesso = certDecertificazione.ImportoDecertificazioneConcesso;
            certDecertificazioneModifiche.DataConstatazioneAmministrativa = certDecertificazione.DataConstatazioneAmministrativa;
            certDecertificazioneModifiche.IdCertificazioneSpesa = certDecertificazione.IdCertificazioneSpesa;
            certDecertificazioneModifiche.IdCertificazioneConti = certDecertificazione.IdCertificazioneConti;
            certDecertificazioneModifiche.Assegnata = certDecertificazione.Assegnata;
            certDecertificazioneModifiche.Definitiva = certDecertificazione.Definitiva;
            certDecertificazioneModifiche.IdCertificazioneSpesaEffettiva = certDecertificazione.IdCertificazioneSpesaEffettiva;
        }

        #endregion Copia OGGETTO in OGGETTO_MODIFICHE

        public string RiaperturaIstruttoriaPagamento(int idModifica, int idDomandaPagamento, bool ignoraControlli)
        {
            string esito = "OK";
            var registroModificheCollectionProvider = new RegistroModificheAutorizzateCollectionProvider();

            try
            {
                registroModificheCollectionProvider.DbProviderObj.BeginTran();

                var domandaPagamentoProvider = new DomandaDiPagamentoCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var domandaPagamentoModificaProvider = new DomandaDiPagamentoModificheCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var domandaPagamento = domandaPagamentoProvider.GetById(idDomandaPagamento);
                if (domandaPagamento == null)
                    throw new Exception("Domanda di pagamento " + idDomandaPagamento + " non trovata");

                if (idModifica == null)
                    throw new Exception("Modifica senza ID");

                if (!ignoraControlli)
                {
                    var eccezione = "";

                    // verifico che esista il progetto
                    var progetto = new ProgettoCollectionProvider(registroModificheCollectionProvider.DbProviderObj).GetById(domandaPagamento.IdProgetto);
                    if (progetto == null)
                        eccezione += "Progetto " + domandaPagamento.IdProgetto + " non trovato \r\n";

                    DateTime dataRilascio;
                    if (domandaPagamento.Segnatura == null)
                        dataRilascio = domandaPagamento.DataModifica;
                    else
                        dataRilascio = new Protocollo().getDataSegnaturaProtocollo(domandaPagamento.Segnatura);

                    // verifico che la domanda non sia in certificazione
                    var certspDettList = new CertspDettaglioCollectionProvider(registroModificheCollectionProvider.DbProviderObj)
                        .FindDefinitiviSelezionatiXProgetto(progetto.IdProgetto)
                        .ToArrayList<CertspDettaglio>();
                    var certspDettDomandaList = certspDettList
                        .Where(c => c.IdDomandaPagamento == idDomandaPagamento)
                        .ToList();
                    if (certspDettDomandaList.Count > 0)
                        eccezione += "La domanda di pagamento " + idDomandaPagamento + " risulta già certificata. " +
                                "Se si è sicuri di voler apportare la modifica rilanciarla ignorando i controlli \r\n";

                    // verifico che la domanda di pagamento non sia già aperta per l'istruttore
                    if (domandaPagamento.SegnaturaApprovazione == null)
                        eccezione += "La domanda di pagamento " + idDomandaPagamento + " risulta già aperta in istruttoria (senza segnatura approvazione). " +
                                "Se si è sicuri di voler apportare la modifica rilanciarla ignorando i controlli \r\n";

                    if (eccezione != "")
                        throw new Exception(eccezione);
                }

                //salvo il backup
                var domandaPagamentoModifica = new DomandaDiPagamentoModifiche();
                CopiaDomandaPagamento(domandaPagamento, domandaPagamentoModifica);
                domandaPagamentoModifica.IdModifica = idModifica;
                domandaPagamentoModificaProvider.Save(domandaPagamentoModifica);

                //tolgo la segnatura dell'istruttoria e la data istruttoria
                domandaPagamento.SegnaturaApprovazione = null;
                domandaPagamento.Approvata = null;
                domandaPagamento.DataApprovazione = null;
                domandaPagamentoProvider.Save(domandaPagamento);

                registroModificheCollectionProvider.DbProviderObj.Commit();
            }
            catch (Exception ex)
            {
                esito = ex.Message;
                registroModificheCollectionProvider.DbProviderObj.Rollback();
            }

            return esito;
        }

        public string RiaperturaBeneficiarioPagamento(int idModifica, int idDomandaPagamento, bool ignoraControlli, bool riapriLatoIstruttore)
        {
            string esito = "OK";
            var registroModificheCollectionProvider = new RegistroModificheAutorizzateCollectionProvider();

            try
            {
                registroModificheCollectionProvider.DbProviderObj.BeginTran();

                var domandaPagamentoProvider = new DomandaDiPagamentoCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var domandaPagamentoModificaProvider = new DomandaDiPagamentoModificheCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var domandaPagamento = domandaPagamentoProvider.GetById(idDomandaPagamento);
                if (domandaPagamento == null)
                    throw new Exception("Domanda di pagamento " + idDomandaPagamento + " non trovata");

                if (!ignoraControlli)
                {
                    var eccezione = "";

                    // verifico che esista il progetto
                    var progetto = new ProgettoCollectionProvider(registroModificheCollectionProvider.DbProviderObj).GetById(domandaPagamento.IdProgetto);
                    if (progetto == null)
                        eccezione += "Progetto " + domandaPagamento.IdProgetto + " non trovato \r\n";

                    DateTime dataRilascio;
                    // verifico che la domanda di pagamento non sia già aperta per il beneficiario
                    if (domandaPagamento.Segnatura == null)
                    {
                        dataRilascio = domandaPagamento.DataModifica;
                        eccezione += "La domanda di pagamento " + idDomandaPagamento + " risulta già aperta per il beneficiario (senza segnatura). " +
                                "Se si è sicuri di voler apportare la modifica rilanciarla ignorando i controlli \r\n";
                    }
                    else
                        dataRilascio = new Protocollo().getDataSegnaturaProtocollo(domandaPagamento.Segnatura);

                    // verifico che la domanda non sia in certificazione
                    var certspDettList = new CertspDettaglioCollectionProvider(registroModificheCollectionProvider.DbProviderObj)
                        .FindDefinitiviSelezionatiXProgetto(progetto.IdProgetto)
                        .ToArrayList<CertspDettaglio>();
                    var certspDettDomandaList = certspDettList
                        .Where(c => c.IdDomandaPagamento == idDomandaPagamento)
                        .ToList();
                    if (certspDettDomandaList.Count > 0)
                        eccezione += "La domanda di pagamento " + idDomandaPagamento + " risulta già certificata. " +
                                "Se si è sicuri di voler apportare la modifica rilanciarla ignorando i controlli \r\n";

                    // verifico che la domanda non abbia un integrazione in corso
                    var integrazioniCollection = new IntegrazioniPerDomandaDiPagamentoCollectionProvider(registroModificheCollectionProvider.DbProviderObj)
                        .Find(null, idDomandaPagamento, false, null);
                    if (integrazioniCollection.Count > 0)
                        eccezione += "La domanda di pagamento " + idDomandaPagamento + " risulta in integrazione. " +
                                "Se si è sicuri di voler apportare la modifica rilanciarla ignorando i controlli \r\n";

                    // verifico che non siano state inserite varianti dopo la domanda di pagamento
                    var variantiList = new VariantiCollectionProvider(registroModificheCollectionProvider.DbProviderObj)
                        .Find(null, domandaPagamento.IdProgetto, null)
                        .ToArrayList<Varianti>();
                    var variantiPostDomandaList = variantiList
                        .Where(v => v.DataInserimento > domandaPagamento.DataModifica
                            || v.DataModifica > domandaPagamento.DataModifica) //prendo la data modifica come data di rilascio
                        .ToList();
                    if (variantiPostDomandaList.Count > 0)
                        eccezione += "Una o più varianti sono state inserite dopo la domanda di pagamento " + idDomandaPagamento +
                                ". Se si è sicuri di voler apportare la modifica rilanciarla ignorando i controlli \r\n";

                    if (eccezione != "")
                        throw new Exception(eccezione);
                }

                var allegatiProtocollatiCollectionProvider = new AllegatiProtocollatiCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var allegatiProtocollatiModificheCollectionProvider = new AllegatiProtocollatiModificheCollectionProvider(registroModificheCollectionProvider.DbProviderObj);

                //salvo il backup
                var allegatiProtocollatiCollection = allegatiProtocollatiCollectionProvider.Find(null, idDomandaPagamento, null, null, null, null, null, domandaPagamento.Segnatura);
                var allegatiProtocollatiModificheCollection = new AllegatiProtocollatiModificheCollection();
                foreach (AllegatiProtocollati allegatoProtocollato in allegatiProtocollatiCollection)
                {
                    var allegatoModifiche = new AllegatiProtocollatiModifiche();
                    CopiaAllegatoProtocollato(allegatoProtocollato, allegatoModifiche);
                    allegatoModifiche.IdModifica = idModifica;
                    allegatiProtocollatiModificheCollection.Add(allegatoModifiche);
                }
                allegatiProtocollatiModificheCollectionProvider.SaveCollection(allegatiProtocollatiModificheCollection);

                var domandaPagamentoModifica = new DomandaDiPagamentoModifiche();
                CopiaDomandaPagamento(domandaPagamento, domandaPagamentoModifica);
                domandaPagamentoModifica.IdModifica = idModifica;
                domandaPagamentoModificaProvider.Save(domandaPagamentoModifica);

                //elimino gli allegati protocollati
                allegatiProtocollatiCollectionProvider.DeleteCollection(allegatiProtocollatiCollection);

                //tolgo la segnatura di presentazione e la data istruttoria
                domandaPagamento.Segnatura = null;
                if (riapriLatoIstruttore) //se è stato spuntata la riapertura lato istruttore
                {
                    domandaPagamento.SegnaturaApprovazione = null;
                    domandaPagamento.Approvata = null;
                }
                domandaPagamento.DataApprovazione = null;
                domandaPagamentoProvider.Save(domandaPagamento);

                registroModificheCollectionProvider.DbProviderObj.Commit();
            }
            catch (Exception ex)
            {
                esito = ex.Message;
                registroModificheCollectionProvider.DbProviderObj.Rollback();
            }


            return esito;
        }

        public string RiaperturaIstruttoriaVariante(int idModifica, int idVariante, bool ignoraControlli)
        {
            string esito = "OK";
            var registroModificheCollectionProvider = new RegistroModificheAutorizzateCollectionProvider();

            try
            {
                registroModificheCollectionProvider.DbProviderObj.BeginTran();

                var varianteProvider = new VariantiCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var variantiModificaProvider = new VariantiModificheCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var variante = varianteProvider.GetById(idVariante);
                if (variante == null)
                    throw new Exception("Variante " + idVariante + " non trovata");

                if (idModifica == null)
                    throw new Exception("Modifica senza ID");

                if (!ignoraControlli)
                {
                    var eccezione = "";

                    // verifico che esista il progetto
                    var progetto = new ProgettoCollectionProvider(registroModificheCollectionProvider.DbProviderObj).GetById(variante.IdProgetto);
                    if (progetto == null)
                        eccezione += "Progetto " + variante.IdProgetto + " non trovato \r\n";

                    DateTime dataRilascio;
                    if (variante.Segnatura == null)
                        dataRilascio = variante.DataModifica;
                    else
                        dataRilascio = new Protocollo().getDataSegnaturaProtocollo(variante.Segnatura);

                    // verifico che non siano state inserite domande di pagamento dopo la variante
                    var domandePagamentoList = new DomandaDiPagamentoCollectionProvider(registroModificheCollectionProvider.DbProviderObj)
                        .Find(null, null, variante.IdProgetto, null)
                        .ToArrayList<DomandaDiPagamento>();
                    var domandePostVarianteList = domandePagamentoList
                        .Where(d => d.DataInserimento > dataRilascio
                            || d.DataModifica > dataRilascio)
                        .ToList();
                    if (domandePostVarianteList.Count > 0)
                        eccezione += "Una o più domande di pagamento sono state inserite dopo la variante " + idVariante +
                                ". Se si è sicuri di voler apportare la modifica rilanciarla ignorando i controlli \r\n";

                    // verifico che la variante non sia già aperta per l'istruttore
                    if (variante.SegnaturaApprovazione == null)
                        eccezione += "La variante " + idVariante + " risulta già aperta in istruttoria (senza segnatura approvazione). " +
                                "Se si è sicuri di voler apportare la modifica rilanciarla ignorando i controlli \r\n";

                    if (eccezione != "")
                        throw new Exception(eccezione);
                }

                //salvo il backup
                var varianteModifiche = new VariantiModifiche();
                CopiaVariante(variante, varianteModifiche);
                varianteModifiche.IdModifica = idModifica;
                variantiModificaProvider.Save(varianteModifiche);

                //tolgo la segnatura dell'istruttoria e la data istruttoria
                variante.SegnaturaApprovazione = null;
                variante.Approvata = null;
                variante.DataApprovazione = null;
                varianteProvider.Save(variante);

                registroModificheCollectionProvider.DbProviderObj.Commit();
            }
            catch (Exception ex)
            {
                esito = ex.Message;
                registroModificheCollectionProvider.DbProviderObj.Rollback();
            }

            return esito;
        }

        public string RiaperturaBeneficiarioVariante(int idModifica, int idVariante, bool ignoraControlli, bool riapriLatoIstruttore)
        {
            string esito = "OK";
            var registroModificheCollectionProvider = new RegistroModificheAutorizzateCollectionProvider();

            try
            {
                registroModificheCollectionProvider.DbProviderObj.BeginTran();

                var varianteProvider = new VariantiCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var variantiModificaProvider = new VariantiModificheCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var variante = varianteProvider.GetById(idVariante);
                if (variante == null)
                    throw new Exception("Variante " + idVariante + " non trovata");

                if (idModifica == null)
                    throw new Exception("Modifica senza ID");

                if (!ignoraControlli)
                {
                    var eccezione = "";

                    // verifico che esista il progetto
                    var progetto = new ProgettoCollectionProvider(registroModificheCollectionProvider.DbProviderObj).GetById(variante.IdProgetto);
                    if (progetto == null)
                        eccezione += "Progetto " + variante.IdProgetto + " non trovato \r\n";

                    DateTime dataRilascio;
                    // verifico che la variante non sia già aperta per il beneficiario
                    if (variante.Segnatura == null)
                    {
                        dataRilascio = variante.DataModifica;
                        eccezione += "La variante " + idVariante + " risulta già aperta per il beneficiario (senza segnatura). " +
                               "Se si è sicuri di voler apportare la modifica rilanciarla ignorando i controlli \r\n";
                    }
                    else
                        dataRilascio = new Protocollo().getDataSegnaturaProtocollo(variante.Segnatura);

                    // verifico che non siano state inserite domande di pagamento dopo la variante
                    var domandePagamentoList = new DomandaDiPagamentoCollectionProvider(registroModificheCollectionProvider.DbProviderObj)
                        .Find(null, null, variante.IdProgetto, null)
                        .ToArrayList<DomandaDiPagamento>();
                    var domandePostVarianteList = domandePagamentoList
                        .Where(d => d.DataInserimento > dataRilascio
                            || d.DataModifica > dataRilascio)
                        .ToList();
                    if (domandePostVarianteList.Count > 0)
                        eccezione += "Una o più domande di pagamento sono state inserite dopo la variante " + idVariante +
                                ". Se si è sicuri di voler apportare la modifica rilanciarla ignorando i controlli \r\n";

                    if (eccezione != "")
                        throw new Exception(eccezione);
                }

                var allegatiProtocollatiCollectionProvider = new AllegatiProtocollatiCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var allegatiProtocollatiModificheCollectionProvider = new AllegatiProtocollatiModificheCollectionProvider(registroModificheCollectionProvider.DbProviderObj);

                //salvo il backup
                var allegatiProtocollatiCollection = allegatiProtocollatiCollectionProvider.Find(null, null, idVariante, null, null, null, null, variante.Segnatura);
                var allegatiProtocollatiModificheCollection = new AllegatiProtocollatiModificheCollection();
                foreach (AllegatiProtocollati allegatoProtocollato in allegatiProtocollatiCollection)
                {
                    var allegatoModifiche = new AllegatiProtocollatiModifiche();
                    CopiaAllegatoProtocollato(allegatoProtocollato, allegatoModifiche);
                    allegatoModifiche.IdModifica = idModifica;
                    allegatiProtocollatiModificheCollection.Add(allegatoModifiche);
                }
                allegatiProtocollatiModificheCollectionProvider.SaveCollection(allegatiProtocollatiModificheCollection);

                var varianteModifiche = new VariantiModifiche();
                CopiaVariante(variante, varianteModifiche);
                varianteModifiche.IdModifica = idModifica;
                variantiModificaProvider.Save(varianteModifiche);

                //elimino gli allegati protocollati
                allegatiProtocollatiCollectionProvider.DeleteCollection(allegatiProtocollatiCollection);

                //tolgo la segnatura di presentazione e la data istruttoria
                variante.Segnatura = null;
                if (riapriLatoIstruttore) //se è stato spuntata la riapertura lato istruttore
                {
                    variante.SegnaturaApprovazione = null;
                    variante.Approvata = null;
                }
                variante.DataApprovazione = null;
                varianteProvider.Save(variante);

                registroModificheCollectionProvider.DbProviderObj.Commit();
            }
            catch (Exception ex)
            {
                esito = ex.Message;
                registroModificheCollectionProvider.DbProviderObj.Rollback();
            }

            return esito;
        }

        public string EliminazioneSingolaValidazione(int idModifica, int idTestataValidazione, bool ignoraControlli)
        {
            string esito = "OK";
            var registroModificheCollectionProvider = new RegistroModificheAutorizzateCollectionProvider();

            try
            {
                registroModificheCollectionProvider.DbProviderObj.BeginTran();

                var testataValidazioneProvider = new TestataValidazioneCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var testata = testataValidazioneProvider.GetById(idTestataValidazione);
                if (testata == null)
                    throw new Exception("Testata " + idTestataValidazione + " non trovata");

                if (idModifica == null)
                    throw new Exception("Modifica senza ID");

                if (!ignoraControlli)
                {
                    var eccezione = "";

                    // verifico che esista il progetto
                    var progetto = new ProgettoCollectionProvider(registroModificheCollectionProvider.DbProviderObj).GetById(testata.IdProgetto);
                    if (progetto == null)
                        eccezione += "Progetto " + testata.IdProgetto + " non trovato \r\n";

                    // verifico che esista la domanda di pagamento
                    var domanda = new DomandaDiPagamentoCollectionProvider(registroModificheCollectionProvider.DbProviderObj).GetById(testata.IdDomandaPagamento);
                    if (domanda == null)
                        eccezione += "Domanda di pagamento " + testata.IdDomandaPagamento + " non trovata \r\n";

                    // verifico se la testata è già stata firmata
                    if (testata.SegnaturaRevisione != null)
                        eccezione += "La testata " + idTestataValidazione + " risulta già firmata (con segnatura revisione). " +
                                "Se si è sicuri di voler apportare la modifica rilanciarla ignorando i controlli \r\n";

                    if (eccezione != "")
                        throw new Exception(eccezione);
                }

                //salvo il backup all'interno del metodo
                var esitoEliminazione = testataValidazioneProvider.EliminaTestataACascata(registroModificheCollectionProvider.DbProviderObj, ref testata, idModifica);
                if (esitoEliminazione == null || esitoEliminazione != "")
                    throw new Exception(esitoEliminazione);

                registroModificheCollectionProvider.DbProviderObj.Commit();
            }
            catch (Exception ex)
            {
                esito = ex.Message;
                registroModificheCollectionProvider.DbProviderObj.Rollback();
            }

            return esito;
        }

        public string EliminazioneMandatiLiquidazionePagamento(int idModifica, int idDomandaPagamento, bool ignoraControlli)
        {
            string esito = "OK";
            var registroModificheCollectionProvider = new RegistroModificheAutorizzateCollectionProvider();

            try
            {
                registroModificheCollectionProvider.DbProviderObj.BeginTran();

                var domandaPagamentoLiquidazioneProvider = new DomandaPagamentoLiquidazioneCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var domandaPagamentoLiquidazioneModificheProvider = new DomandaPagamentoLiquidazioneModificheCollectionProvider(registroModificheCollectionProvider.DbProviderObj);

                // verifico che esista la domanda di pagamento
                var domanda = new DomandaDiPagamentoCollectionProvider(registroModificheCollectionProvider.DbProviderObj).GetById(idDomandaPagamento);
                if (domanda == null)
                    throw new Exception("Domanda di pagamento " + idDomandaPagamento + " non trovata");

                if (idModifica == null)
                    throw new Exception("Modifica senza ID");

                if (!ignoraControlli)
                {
                    var eccezione = "";

                    // verifico che esista il progetto
                    var progetto = new ProgettoCollectionProvider(registroModificheCollectionProvider.DbProviderObj).GetById(domanda.IdProgetto);
                    if (progetto == null)
                        eccezione += "Progetto " + domanda.IdProgetto + " non trovato \r\n";

                    // verifico se la testata è già stata firmata
                    var testataValidazioneProvider = new TestataValidazioneCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                    var testata = testataValidazioneProvider.GetTestataValidazioneDaCte(idDomandaPagamento);
                    if (testata != null)
                    {
                        if (testata.SegnaturaRevisione != null)
                            eccezione += "La testata validazione " + testata.IdTestata + " risulta già firmata (con segnatura revisione). " +
                                    "Se si è sicuri di voler apportare la modifica rilanciarla ignorando i controlli \r\n";
                    }

                    if (eccezione != "")
                        throw new Exception(eccezione);
                }

                //salvo il backup
                var liquidazioniCollection = domandaPagamentoLiquidazioneProvider.FindByDecreto(idDomandaPagamento, null, null, null, null);
                var liquidazioniModificheCollection = new DomandaPagamentoLiquidazioneModificheCollection();
                foreach (DomandaPagamentoLiquidazione liquidazione in liquidazioniCollection)
                {
                    var liquidazioneModifiche = new DomandaPagamentoLiquidazioneModifiche();
                    CopiaDomandaPagamentoLiquidazione(liquidazione, liquidazioneModifiche);
                    liquidazioneModifiche.IdModifica = idModifica;
                    liquidazioniModificheCollection.Add(liquidazioneModifiche);
                }
                domandaPagamentoLiquidazioneModificheProvider.SaveCollection(liquidazioniModificheCollection);

                //elimino le liquidazioni
                domandaPagamentoLiquidazioneProvider.DeleteCollection(liquidazioniCollection);

                registroModificheCollectionProvider.DbProviderObj.Commit();
            }
            catch (Exception ex)
            {
                esito = ex.Message;
                registroModificheCollectionProvider.DbProviderObj.Rollback();
            }

            return esito;
        }

        public string AnnullamentoIstruttoriaAmmissibilitaProgetto(int idModifica, int idProgetto, bool ignoraControlli)
        {
            string esito = "OK";
            var registroModificheCollectionProvider = new RegistroModificheAutorizzateCollectionProvider();

            try
            {
                registroModificheCollectionProvider.DbProviderObj.BeginTran();

                var progettoProvider = new ProgettoCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var progettoStoricoProvider = new ProgettoStoricoCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var progettoModificheProvider = new ProgettoModificheCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var progettoStoricoModificheProvider = new ProgettoStoricoModificheCollectionProvider(registroModificheCollectionProvider.DbProviderObj);

                // verifico che esista il progetto
                var progetto = progettoProvider.GetById(idProgetto);
                if (progetto == null)
                    throw new Exception("Progetto " + idProgetto + " non trovato");

                if (idModifica == null)
                    throw new Exception("Modifica senza ID");

                if (!ignoraControlli)
                {
                    var eccezione = "";

                    // verifico se il progetto è in uno stato avanzato
                    if (progetto.CodStato == "C"    // Concluso
                        || progetto.CodStato == "O" // Secondo SAL 
                        || progetto.CodStato == "S" // SAL
                        || progetto.CodStato == "T" // Rendicontato
                        )
                    {
                        eccezione += "Il progetto " + idProgetto + " risulta in uno stato avanzato (" + progetto.CodStato + " - " + progetto.Stato + "). " +
                                    "Se si è sicuri di voler apportare la modifica rilanciarla ignorando i controlli \r\n";
                    }

                    if (eccezione != "")
                        throw new Exception(eccezione);
                }

                //salvo il backup
                var progettoModifiche = new ProgettoModifiche();
                CopiaProgetto(progetto, progettoModifiche);
                progettoModifiche.IdModifica = idModifica;
                progettoModificheProvider.Save(progettoModifiche);

                var progettoStoricoCollection = progettoStoricoProvider.Find(idProgetto, null, null);
                var progettoStoricoModificheCollection = new ProgettoStoricoModificheCollection();
                foreach (ProgettoStorico progettoStorico in progettoStoricoCollection)
                {
                    var progettoStoricoModifiche = new ProgettoStoricoModifiche();
                    CopiaProgettoStorico(progettoStorico, progettoStoricoModifiche);
                    progettoStoricoModifiche.IdModifica = idModifica;
                    progettoStoricoModificheCollection.Add(progettoStoricoModifiche);
                }
                progettoStoricoModificheProvider.SaveCollection(progettoStoricoModificheCollection);

                //elimino gli stati successivi all'ultimo stato I Acquisito e cambio l'ultimo id progetto storico su progetto
                var progettoStoricoList = progettoStoricoCollection.ToArrayList<ProgettoStorico>();
                var ultimoStatoAcquisito = progettoStoricoList
                    .Where(p => p.CodStato == "I")
                    .OrderByDescending(p => p.Id)
                    .FirstOrDefault();

                if (ultimoStatoAcquisito == null)
                    throw new Exception("Il progetto " + idProgetto + " non ha nessun progetto storico con stato I");

                var storiciDaEliminareList = progettoStoricoList
                    .Where(p => p.Id > ultimoStatoAcquisito.Id)
                    .ToList<ProgettoStorico>();

                progetto.IdStoricoUltimo = ultimoStatoAcquisito.Id;
                progettoProvider.Save(progetto);
                foreach (ProgettoStorico daEliminare in storiciDaEliminareList)
                    progettoStoricoProvider.Delete(daEliminare);

                registroModificheCollectionProvider.DbProviderObj.Commit();
            }
            catch (Exception ex)
            {
                esito = ex.Message;
                registroModificheCollectionProvider.DbProviderObj.Rollback();
            }

            return esito;
        }

        public string AnnullamentoPresentazioneProgetto(int idModifica, int idProgetto, bool ignoraControlli)
        {
            string esito = "OK";
            var registroModificheCollectionProvider = new RegistroModificheAutorizzateCollectionProvider();

            try
            {
                registroModificheCollectionProvider.DbProviderObj.BeginTran();

                var progettoProvider = new ProgettoCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var progettoStoricoProvider = new ProgettoStoricoCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var progettoModificheProvider = new ProgettoModificheCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var progettoStoricoModificheProvider = new ProgettoStoricoModificheCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var allegatiProtocollatiCollectionProvider = new AllegatiProtocollatiCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var allegatiProtocollatiModificheCollectionProvider = new AllegatiProtocollatiModificheCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var iterProgettoCollectionProvider = new IterProgettoCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var iterProgettoModificheCollectionProvider = new IterProgettoModificheCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var pianoInvestimentiCollectionProvider = new PianoInvestimentiCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var pianoInvestimentiModificheCollectionProvider = new PianoInvestimentiModificheCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var prioritaXinvestimentiCollectionProvider = new PrioritaXInvestimentiCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var prioritaXinvestimentiModificheCollectionProvider = new PrioritaXInvestimentiModificheCollectionProvider(registroModificheCollectionProvider.DbProviderObj);

                // verifico che esista il progetto
                var progetto = progettoProvider.GetById(idProgetto);
                if (progetto == null)
                    throw new Exception("Progetto " + idProgetto + " non trovato");

                if (idModifica == null)
                    throw new Exception("Modifica senza ID");

                switch (progetto.CodStato)
                {
                    case "P":
                        throw new Exception("Il progetto " + idProgetto + " risulta in uno stato precedente (" + progetto.CodStato + " - " + progetto.Stato + ") rispetto allo stato di Aquisito. " +
                                    "Non è quindi possibile riportarlo allo stato di lavorazione \r\n");
                    case "L":
                        throw new Exception("Il progetto " + idProgetto + " risulta in uno stato precedente (" + progetto.CodStato + " - " + progetto.Stato + ") rispetto allo stato di Aquisito. " +
                                    "Non è quindi possibile riportarlo allo stato di lavorazione \r\n");
                    case "I":
                        break;
                    default:
                        throw new Exception("Il progetto " + idProgetto + " risulta in uno stato avanzato (" + progetto.CodStato + " - " + progetto.Stato + "). rispetto allo stato di Aquisito." +
                                    "Non è quindi possibile riportarlo allo stato di lavorazione \r\n");
                }

                if (!ignoraControlli)
                {
                    var eccezione = "";

                    // verifico che esista il bando e e che non sia scaduto
                    var bando = new BandoCollectionProvider(registroModificheCollectionProvider.DbProviderObj).GetById(progetto.IdBando);
                    if (bando == null)
                        eccezione += "Bando " + progetto.IdBando + " non trovato \r\n";

                    if (bando.DataScadenza <= DateTime.Now)
                        eccezione += "Bando " + progetto.IdBando + " scaduto \r\n";

                    if (eccezione != "")
                        throw new Exception(eccezione);
                }

                //salvo il backup del progetto
                var progettoModifiche = new ProgettoModifiche();
                CopiaProgetto(progetto, progettoModifiche);
                progettoModifiche.IdModifica = idModifica;
                progettoModificheProvider.Save(progettoModifiche);

                //salvo il backup del progetto storico
                var progettoStoricoCollection = progettoStoricoProvider.Find(idProgetto, null, null);
                var progettoStoricoModificheCollection = new ProgettoStoricoModificheCollection();

                var listaProgettiStorico = new List<ProgettoStorico>();
                foreach (ProgettoStorico progettoStorico in progettoStoricoCollection)
                {
                    var progettoStoricoModifiche = new ProgettoStoricoModifiche();
                    CopiaProgettoStorico(progettoStorico, progettoStoricoModifiche);
                    progettoStoricoModifiche.IdModifica = idModifica;
                    progettoStoricoModificheCollection.Add(progettoStoricoModifiche);
                    listaProgettiStorico.Add(progettoStorico);
                }

                if (listaProgettiStorico.Where(x=> x.CodStato == "I").Count() > 1)
                    throw new Exception("Il progetto " + idProgetto + " risulta avere delle anomalie nello storico presentando un numero di stati Acquisito maggiore di 1. " +
                                    "Non è quindi possibile riportarlo allo stato di lavorazione \r\n");

                progettoStoricoModificheProvider.SaveCollection(progettoStoricoModificheCollection);

                //salvo il backup degli allegati protocollati
                var allegatiProtocollatiCollection = allegatiProtocollatiCollectionProvider.Find(idProgetto, null, null, null, null, null, null, progetto.Segnatura);
                var allegatiProtocollatiModificheCollection = new AllegatiProtocollatiModificheCollection();
                foreach (AllegatiProtocollati allegatoProtocollato in allegatiProtocollatiCollection)
                {
                    var allegatoModifiche = new AllegatiProtocollatiModifiche();
                    CopiaAllegatoProtocollato(allegatoProtocollato, allegatoModifiche);
                    allegatoModifiche.IdModifica = idModifica;
                    allegatiProtocollatiModificheCollection.Add(allegatoModifiche);
                }
                allegatiProtocollatiModificheCollectionProvider.SaveCollection(allegatiProtocollatiModificheCollection);

                //salvo il backup dell'iter del progetto
                var iterProgettoCollection = iterProgettoCollectionProvider.Find(progetto.IdProgetto, null, null, null, null, null, null);
                var iterProgettoModificheCollection = new IterProgettoModificheCollection();
                foreach (IterProgetto iter in iterProgettoCollection)
                {
                    var iterProgettoModifiche = new IterProgettoModifiche();
                    CopiaIterProgetto(iter, iterProgettoModifiche);
                    iterProgettoModifiche.IdModifica = idModifica;
                    iterProgettoModificheCollection.Add(iterProgettoModifiche);
                }
                iterProgettoModificheCollectionProvider.SaveCollection(iterProgettoModificheCollection);

                //salvo il backup del piano investimenti ma solo delle righe con id investimento originale != null in quanto sono gli unici ad essere cancellati successivamente
                var pianoInvestimentiCollection = pianoInvestimentiCollectionProvider.Find(null, progetto.IdProgetto, null, null, null, null, null);
                var pianoInvestimentiModificheCollection = new PianoInvestimentiModificheCollection();
                PrioritaXInvestimentiCollection prioritaXinvestimentiToDeleteCollection = new PrioritaXInvestimentiCollection();
                PianoInvestimentiCollection pianoInvestimentiToDelete = new PianoInvestimentiCollection();
                foreach (PianoInvestimenti piano in pianoInvestimentiCollection)
                {
                    if (piano.IdInvestimentoOriginale != null)
                    {
                        pianoInvestimentiToDelete.Add(piano);
                        var pianoInvestimentiModifiche = new PianoInvestimentiModifiche();
                        CopiaPianoInvestimenti(piano, pianoInvestimentiModifiche);
                        pianoInvestimentiModifiche.IdModifica = idModifica;
                        pianoInvestimentiModificheCollection.Add(pianoInvestimentiModifiche);

                        //salvo il backup delle priorità x investimenti
                        var prioritaXinvestimentiCollection = prioritaXinvestimentiCollectionProvider.Find(null, piano.IdInvestimento, null, null);
                        prioritaXinvestimentiToDeleteCollection.AddCollection(prioritaXinvestimentiCollection);
                        if (prioritaXinvestimentiCollection != null && prioritaXinvestimentiCollection.Count != 0)
                        {
                            var prioritaXinvestimentiModificheCollection = new PrioritaXInvestimentiModificheCollection();
                            foreach (PrioritaXInvestimenti priorita in prioritaXinvestimentiCollection)
                            {
                                var prioritaXinvestimentiModifiche = new PrioritaXInvestimentiModifiche();
                                CopiaPrioritaXinvestimenti(priorita, prioritaXinvestimentiModifiche);
                                prioritaXinvestimentiModifiche.IdModifica = idModifica;
                                prioritaXinvestimentiModificheCollection.Add(prioritaXinvestimentiModifiche);
                            }
                            prioritaXinvestimentiModificheCollectionProvider.SaveCollection(prioritaXinvestimentiModificheCollection);
                        }
                    }
                }
                pianoInvestimentiModificheCollectionProvider.SaveCollection(pianoInvestimentiModificheCollection);

                // inizio ad eliminare
                // passo 1 aggiorno il progetto con l'id storico in stato P
                ProgettoStorico storicoStatoLavorazione = listaProgettiStorico.Where(x => x.CodStato == "P").FirstOrDefault();
                progetto.IdStoricoUltimo = storicoStatoLavorazione.Id;
                progettoProvider.Save(progetto);

                // cancello da progetto storico tutti quelli che sono in stato =! P
                foreach (ProgettoStorico p in listaProgettiStorico.Where(x => x.CodStato != "P"))
                {
                    progettoStoricoProvider.Delete(p);
                }

                //a questo punto cancelliamo le priorità per investimenti, gli investimenti con id investimento originale nulle, l'iter progetto e allegati protocollati
                prioritaXinvestimentiCollectionProvider.DeleteCollection(prioritaXinvestimentiToDeleteCollection);
                pianoInvestimentiCollectionProvider.DeleteCollection(pianoInvestimentiToDelete);
                iterProgettoCollectionProvider.DeleteCollection(iterProgettoCollection);
                allegatiProtocollatiCollectionProvider.DeleteCollection(allegatiProtocollatiCollection);

                registroModificheCollectionProvider.DbProviderObj.Commit();
            }
            catch (Exception ex)
            {
                esito = ex.Message;
                registroModificheCollectionProvider.DbProviderObj.Rollback();
            }

            return esito;
        }

        public string EliminazioneDecretiMandatiLiquidazionePagamento(int idModifica, int idDomandaPagamento, bool ignoraControlli)
        {
            string esito = "OK";
            var registroModificheCollectionProvider = new RegistroModificheAutorizzateCollectionProvider();

            try
            {
                registroModificheCollectionProvider.DbProviderObj.BeginTran();

                var domandaPagamentoLiquidazioneProvider = new DomandaPagamentoLiquidazioneCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var domandaPagamentoLiquidazioneModificheProvider = new DomandaPagamentoLiquidazioneModificheCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var decretiXDomPagEsportazioneProvider = new DecretiXDomPagEsportazioneCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var decretiXDomPagEsportazioneModificheProvider = new DecretiXDomPagEsportazioneModificheCollectionProvider(registroModificheCollectionProvider.DbProviderObj);

                // verifico che esista la domanda di pagamento
                var domanda = new DomandaDiPagamentoCollectionProvider(registroModificheCollectionProvider.DbProviderObj).GetById(idDomandaPagamento);
                if (domanda == null)
                    throw new Exception("Domanda di pagamento " + idDomandaPagamento + " non trovata");

                if (idModifica == null)
                    throw new Exception("Modifica senza ID");

                if (!ignoraControlli)
                {
                    var eccezione = "";

                    // verifico che esista il progetto
                    var progetto = new ProgettoCollectionProvider(registroModificheCollectionProvider.DbProviderObj).GetById(domanda.IdProgetto);
                    if (progetto == null)
                        eccezione += "Progetto " + domanda.IdProgetto + " non trovato \r\n";

                    // verifico se la testata è già stata firmata
                    var testataValidazioneProvider = new TestataValidazioneCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                    var testata = testataValidazioneProvider.GetTestataValidazioneDaCte(idDomandaPagamento);
                    if (testata != null)
                    {
                        if (testata.SegnaturaRevisione != null)
                            eccezione += "La testata validazione " + testata.IdTestata + " risulta già firmata (con segnatura revisione). " +
                                    "Se si è sicuri di voler apportare la modifica rilanciarla ignorando i controlli \r\n";
                    }

                    if (eccezione != "")
                        throw new Exception(eccezione);
                }

                //salvo i backup
                var liquidazioniCollection = domandaPagamentoLiquidazioneProvider.FindByDecreto(idDomandaPagamento, null, null, null, null);
                var liquidazioniModificheCollection = new DomandaPagamentoLiquidazioneModificheCollection();
                foreach (DomandaPagamentoLiquidazione liquidazione in liquidazioniCollection)
                {
                    var liquidazioneModifiche = new DomandaPagamentoLiquidazioneModifiche();
                    CopiaDomandaPagamentoLiquidazione(liquidazione, liquidazioneModifiche);
                    liquidazioneModifiche.IdModifica = idModifica;
                    liquidazioniModificheCollection.Add(liquidazioneModifiche);
                }
                domandaPagamentoLiquidazioneModificheProvider.SaveCollection(liquidazioniModificheCollection);

                var decretiCollection = decretiXDomPagEsportazioneProvider.Find(idDomandaPagamento, null, null);
                var decretiModificheCollection = new DecretiXDomPagEsportazioneModificheCollection();
                foreach (DecretiXDomPagEsportazione decreto in decretiCollection)
                {
                    var decretoModifiche = new DecretiXDomPagEsportazioneModifiche();
                    CopiaDecretiXDomPagEsportazione(decreto, decretoModifiche);
                    decretoModifiche.IdModifica = idModifica;
                    decretiModificheCollection.Add(decretoModifiche);
                }
                decretiXDomPagEsportazioneModificheProvider.SaveCollection(decretiModificheCollection);

                //elimino le liquidazioni e i decreti
                domandaPagamentoLiquidazioneProvider.DeleteCollection(liquidazioniCollection);
                decretiXDomPagEsportazioneProvider.DeleteCollection(decretiCollection);

                registroModificheCollectionProvider.DbProviderObj.Commit();
            }
            catch (Exception ex)
            {
                esito = ex.Message;
                registroModificheCollectionProvider.DbProviderObj.Rollback();
            }

            return esito;
        }

        public string RiaperturaLottoCertificazioneSpesa(int idModifica, int idCertSp, bool ignoraControlli)
        {
            string esito = "OK";
            var registroModificheCollectionProvider = new RegistroModificheAutorizzateCollectionProvider();

            try
            {
                registroModificheCollectionProvider.DbProviderObj.BeginTran();

                var certSpTestaCollectionProvider = new CertspTestaCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var certSpTestaModificheCollectionProvider = new CertspTestaModificheCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var certDecertificazioneCollectionProvider = new CertDecertificazioneCollectionProvider(registroModificheCollectionProvider.DbProviderObj);
                var certDecertificazioneModificheCollectionProvider = new CertDecertificazioneModificheCollectionProvider(registroModificheCollectionProvider.DbProviderObj);

                // verifico che esista il lotto di certificazione
                var lottoCert = certSpTestaCollectionProvider.GetById(idCertSp);
                if (lottoCert == null)
                    throw new Exception("Lotto di certificazione " + idCertSp + " non trovato");

                if (idModifica == null)
                    throw new Exception("Modifica senza ID");

                if (!ignoraControlli)
                {
                    var eccezione = "";

                    // verifico che il lotto sia veramente chiuso
                    if (!lottoCert.Definitivo)
                        eccezione += "Lotto di certificazione " + idCertSp + " già aperto \r\n";

                    if (eccezione != "")
                        throw new Exception(eccezione);
                }

                //salvo i backup
                var certSpModifica = new CertspTestaModifiche();
                CopiaCertSpTesta(lottoCert, certSpModifica);
                certSpModifica.IdModifica = idModifica;
                certSpTestaModificheCollectionProvider.Save(certSpModifica);

                var decertificazioniCollection = certDecertificazioneCollectionProvider.Find(null, null, null, null, null, null, null, true, true, null, null, idCertSp);
                var decertificazioniModificheCollection = new CertDecertificazioneModificheCollection();
                foreach (CertDecertificazione decertificazione in decertificazioniCollection)
                {
                    var decertificazioneModifiche = new CertDecertificazioneModifiche();
                    CopiaCertDecertificazione(decertificazione, decertificazioneModifiche);
                    decertificazioneModifiche.IdModifica = idModifica;
                    decertificazioniModificheCollection.Add(decertificazioneModifiche);
                }
                certDecertificazioneModificheCollectionProvider.SaveCollection(decertificazioniModificheCollection);

                //rendo non definitivi la certificazione e tutte le decertificazioni applicate 
                lottoCert.Definitivo = false;
                certSpTestaCollectionProvider.Save(lottoCert);

                foreach (CertDecertificazione decertificazione in decertificazioniCollection)
                {
                    decertificazione.Definitiva = false;
                    certDecertificazioneCollectionProvider.Save(decertificazione);
                }

                registroModificheCollectionProvider.DbProviderObj.Commit();
            }
            catch (Exception ex)
            {
                esito = ex.Message;
                registroModificheCollectionProvider.DbProviderObj.Rollback();
            }

            return esito;
        }
    }
}
