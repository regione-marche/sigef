using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class RegistroRecuperoCollectionProvider : IRegistroRecuperoProvider
    {
        public RegistroRecupero DeepCopy(RegistroRecupero registro_vecchio)
        {
            RegistroRecupero registro_nuovo = new RegistroRecupero();

            registro_nuovo.DataInserimento = registro_vecchio.DataInserimento;
            registro_nuovo.CfInserimento = registro_vecchio.CfInserimento;
            registro_nuovo.DataModifica = registro_vecchio.DataModifica;
            registro_nuovo.CfModifica = registro_vecchio.CfModifica;
            registro_nuovo.IdRegistroIrregolarita = registro_vecchio.IdRegistroIrregolarita;
            registro_nuovo.DataAvvio = registro_vecchio.DataAvvio;
            registro_nuovo.DataProbabileConclusione = registro_vecchio.DataProbabileConclusione;
            registro_nuovo.ImportoDaRecuperareUe = registro_vecchio.ImportoDaRecuperareUe;
            registro_nuovo.ImportoDaRecuperareNazionale = registro_vecchio.ImportoDaRecuperareNazionale;
            registro_nuovo.ImportoDaRecuperarePubblico = registro_vecchio.ImportoDaRecuperarePubblico;
            registro_nuovo.ImportoDaRecuperarePrivato = registro_vecchio.ImportoDaRecuperarePrivato;
            registro_nuovo.ImportoDaRecuperareTotale = registro_vecchio.ImportoDaRecuperareTotale;
            registro_nuovo.ImportoDetrattoUe = registro_vecchio.ImportoDetrattoUe;
            registro_nuovo.ImportoDetrattoNazionale = registro_vecchio.ImportoDetrattoNazionale;
            registro_nuovo.ImportoDetrattoPubblico = registro_vecchio.ImportoDetrattoPubblico;
            registro_nuovo.ImportoDetrattoPrivato = registro_vecchio.ImportoDetrattoPrivato;
            registro_nuovo.ImportoDetrattoTotale = registro_vecchio.ImportoDetrattoTotale;
            registro_nuovo.ImportoRecuperatoUe = registro_vecchio.ImportoRecuperatoUe;
            registro_nuovo.ImportoRecuperatoNazionale = registro_vecchio.ImportoRecuperatoNazionale;
            registro_nuovo.ImportoRecuperatoPubblico = registro_vecchio.ImportoRecuperatoPubblico;
            registro_nuovo.ImportoRecuperatoPrivato = registro_vecchio.ImportoRecuperatoPrivato;
            registro_nuovo.ImportoRecuperatoTotale = registro_vecchio.ImportoRecuperatoTotale;
            registro_nuovo.SaldoDaRecuperareUe = registro_vecchio.SaldoDaRecuperareUe;
            registro_nuovo.SaldoDaRecuperareNazionale = registro_vecchio.SaldoDaRecuperareNazionale;
            registro_nuovo.SaldoDaRecuperarePubblico = registro_vecchio.SaldoDaRecuperarePubblico;
            registro_nuovo.SaldoDaRecuperarePrivato = registro_vecchio.SaldoDaRecuperarePrivato;
            registro_nuovo.SaldoDaRecuperareTotale = registro_vecchio.SaldoDaRecuperareTotale;
            registro_nuovo.ImportoVersatoUe = registro_vecchio.ImportoVersatoUe;
            registro_nuovo.ImportoRitenutoStato = registro_vecchio.ImportoRitenutoStato;
            registro_nuovo.ImportoInteressiLegali = registro_vecchio.ImportoInteressiLegali;
            registro_nuovo.ImportoInteressiMora = registro_vecchio.ImportoInteressiMora;
            registro_nuovo.DataConclusione = registro_vecchio.DataConclusione;
            registro_nuovo.IdProcedureAvviate = registro_vecchio.IdProcedureAvviate;
            registro_nuovo.IdTipoProcedureAvviate = registro_vecchio.IdTipoProcedureAvviate;
            registro_nuovo.DataAvvioProcedure = registro_vecchio.DataAvvioProcedure;
            registro_nuovo.DataProbabileConclusioneProcedure = registro_vecchio.DataProbabileConclusioneProcedure;
            registro_nuovo.IdTipoRecupero = registro_vecchio.IdTipoRecupero;
            registro_nuovo.IdOrigineRecupero = registro_vecchio.IdOrigineRecupero;
            registro_nuovo.IdStoricoRecuperoPrecedente = registro_vecchio.IdStoricoRecuperoPrecedente;
            registro_nuovo.IdProgetto = registro_vecchio.IdProgetto;
            registro_nuovo.IdBando = registro_vecchio.IdBando;
            registro_nuovo.IdImpresa = registro_vecchio.IdImpresa;
            registro_nuovo.CodAgea = registro_vecchio.CodAgea;
            registro_nuovo.SegnaturaAllegati = registro_vecchio.SegnaturaAllegati;
            registro_nuovo.IdProgIntegrato = registro_vecchio.IdProgIntegrato;
            registro_nuovo.FlagPreadesione = registro_vecchio.FlagPreadesione;
            registro_nuovo.FlagDefinitivo = registro_vecchio.FlagDefinitivo;
            registro_nuovo.IdFascicolo = registro_vecchio.IdFascicolo;
            registro_nuovo.ProvinciaDiPresentazione = registro_vecchio.ProvinciaDiPresentazione;
            registro_nuovo.SelezionataXRevisione = registro_vecchio.SelezionataXRevisione;
            registro_nuovo.IdStoricoUltimo = registro_vecchio.IdStoricoUltimo;
            registro_nuovo.DataCreazione = registro_vecchio.DataCreazione;
            registro_nuovo.OperatoreCreazione = registro_vecchio.OperatoreCreazione;
            registro_nuovo.FirmaPredisposta = registro_vecchio.FirmaPredisposta;
            registro_nuovo.Storico = registro_vecchio.Storico;
            registro_nuovo.DataRegistrazioneRitiro = registro_vecchio.DataRegistrazioneRitiro;
            registro_nuovo.DataCertificazioneRecupero = registro_vecchio.DataCertificazioneRecupero;
            registro_nuovo.DataCertificazioneRitiro = registro_vecchio.DataCertificazioneRitiro;
            registro_nuovo.ImportoGestionePratica = registro_vecchio.ImportoGestionePratica;
            registro_nuovo.IdAttoRecupero = registro_vecchio.IdAttoRecupero;
            registro_nuovo.IdAttoRitiro = registro_vecchio.IdAttoRitiro;
            registro_nuovo.IdAttoNonRecuperabilita = registro_vecchio.IdAttoNonRecuperabilita;
            registro_nuovo.SoggettoRevocaFinanziamento = registro_vecchio.SoggettoRevocaFinanziamento;
            registro_nuovo.Recuperabile = registro_vecchio.Recuperabile;

            return registro_nuovo;
        }
    }
}
