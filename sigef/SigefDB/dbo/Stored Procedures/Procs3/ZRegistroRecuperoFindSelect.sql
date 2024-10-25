CREATE PROCEDURE [dbo].[ZRegistroRecuperoFindSelect]
(
	@IdRegistroRecuperoequalthis INT, 
	@DataInserimentoequalthis DATETIME, 
	@CfInserimentoequalthis VARCHAR(255), 
	@DataModificaequalthis DATETIME, 
	@CfModificaequalthis VARCHAR(255), 
	@IdRegistroIrregolaritaequalthis INT, 
	@DataAvvioequalthis DATETIME, 
	@DataProbabileConclusioneequalthis DATETIME, 
	@ImportoDaRecuperareUeequalthis DECIMAL(15,2), 
	@ImportoDaRecuperareNazionaleequalthis DECIMAL(15,2), 
	@ImportoDaRecuperarePubblicoequalthis DECIMAL(15,2), 
	@ImportoDaRecuperarePrivatoequalthis DECIMAL(15,2), 
	@ImportoDaRecuperareTotaleequalthis DECIMAL(15,2), 
	@ImportoDetrattoUeequalthis DECIMAL(15,2), 
	@ImportoDetrattoNazionaleequalthis DECIMAL(15,2), 
	@ImportoDetrattoPubblicoequalthis DECIMAL(15,2), 
	@ImportoDetrattoPrivatoequalthis DECIMAL(15,2), 
	@ImportoDetrattoTotaleequalthis DECIMAL(15,2), 
	@ImportoRecuperatoUeequalthis DECIMAL(15,2), 
	@ImportoRecuperatoNazionaleequalthis DECIMAL(15,2), 
	@ImportoRecuperatoPubblicoequalthis DECIMAL(15,2), 
	@ImportoRecuperatoPrivatoequalthis DECIMAL(15,2), 
	@ImportoRecuperatoTotaleequalthis DECIMAL(15,2), 
	@SaldoDaRecuperareUeequalthis DECIMAL(15,2), 
	@SaldoDaRecuperareNazionaleequalthis DECIMAL(15,2), 
	@SaldoDaRecuperarePubblicoequalthis DECIMAL(15,2), 
	@SaldoDaRecuperarePrivatoequalthis DECIMAL(15,2), 
	@SaldoDaRecuperareTotaleequalthis DECIMAL(15,2), 
	@ImportoVersatoUeequalthis DECIMAL(15,2), 
	@ImportoRitenutoStatoequalthis DECIMAL(15,2), 
	@ImportoInteressiMoraequalthis DECIMAL(15,2), 
	@ImportoInteressiLegaliequalthis DECIMAL(15,2), 
	@ImportoGestionePraticaequalthis DECIMAL(15,2), 
	@DataConclusioneequalthis DATETIME, 
	@IdProcedureAvviateequalthis INT, 
	@IdTipoProcedureAvviateequalthis INT, 
	@DataAvvioProcedureequalthis DATETIME, 
	@DataProbabileConclusioneProcedureequalthis DATETIME, 
	@IdTipoRecuperoequalthis INT, 
	@IdOrigineRecuperoequalthis INT, 
	@IdStoricoRecuperoPrecedenteequalthis INT, 
	@IdProgettoequalthis INT, 
	@Storicoequalthis BIT, 
	@DataRegistrazioneRitiroequalthis DATETIME, 
	@DataCertificazioneRecuperoequalthis DATETIME, 
	@DataCertificazioneRitiroequalthis DATETIME, 
	@DataCertificazioneNonRecuperabilitaequalthis DATETIME, 
	@GestioneRateequalthis BIT, 
	@NumeroRateequalthis INT, 
	@IntervalloRateMesiequalthis INT, 
	@DataInizioRateequalthis DATETIME, 
	@ImportoRataequalthis DECIMAL(15,2), 
	@SoggettoRevocaFinanziamentoequalthis VARCHAR(2000), 
	@IdAttoRecuperoequalthis INT, 
	@IdAttoRitiroequalthis INT, 
	@IdAttoNonRecuperabilitaequalthis INT, 
	@Recuperabileequalthis BIT, 
	@DataRegistrazioneNonRecuperabilitaequalthis DATETIME, 
	@DataSegnaturaequalthis DATETIME, 
	@Segnaturaequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_REGISTRO_RECUPERO, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, ID_REGISTRO_IRREGOLARITA, DATA_AVVIO, DATA_PROBABILE_CONCLUSIONE, IMPORTO_DA_RECUPERARE_UE, IMPORTO_DA_RECUPERARE_NAZIONALE, IMPORTO_DA_RECUPERARE_PUBBLICO, IMPORTO_DETRATTO_UE, IMPORTO_DETRATTO_NAZIONALE, IMPORTO_DETRATTO_PUBBLICO, IMPORTO_RECUPERATO_UE, IMPORTO_RECUPERATO_PUBBLICO, IMPORTO_RECUPERATO_NAZIONALE, SALDO_DA_RECUPERARE_UE, SALDO_DA_RECUPERARE_NAZIONALE, SALDO_DA_RECUPERARE_PUBBLICO, IMPORTO_VERSATO_UE, IMPORTO_RITENUTO_STATO, DATA_CONCLUSIONE, ID_PROCEDURE_AVVIATE, ID_TIPO_PROCEDURE_AVVIATE, DATA_AVVIO_PROCEDURE, DATA_PROBABILE_CONCLUSIONE_PROCEDURE, ID_TIPO_RECUPERO, ID_ORIGINE_RECUPERO, ID_STORICO_RECUPERO_PRECEDENTE, ID_PROGETTO, ID_BANDO, ID_IMPRESA, COD_AGEA, SEGNATURA_ALLEGATI, ID_PROG_INTEGRATO, FLAG_PREADESIONE, FLAG_DEFINITIVO, ID_FASCICOLO, PROVINCIA_DI_PRESENTAZIONE, SELEZIONATA_X_REVISIONE, ID_STORICO_ULTIMO, DATA_CREAZIONE, OPERATORE_CREAZIONE, FIRMA_PREDISPOSTA, STORICO, IMPORTO_INTERESSI_LEGALI, IMPORTO_INTERESSI_MORA, IMPORTO_GESTIONE_PRATICA, DATA_REGISTRAZIONE_RITIRO, DATA_CERTIFICAZIONE_RECUPERO, DATA_CERTIFICAZIONE_RITIRO, GESTIONE_RATE, NUMERO_RATE, DATA_INIZIO_RATE, IMPORTO_RATA, INTERVALLO_RATE_MESI, ID_PROGRAMMAZIONE, PROGRAMMAZIONE, IMPORTO_DA_RECUPERARE_PRIVATO, IMPORTO_DA_RECUPERARE_TOTALE, IMPORTO_DETRATTO_PRIVATO, IMPORTO_RECUPERATO_PRIVATO, IMPORTO_RECUPERATO_TOTALE, SALDO_DA_RECUPERARE_PRIVATO, SALDO_DA_RECUPERARE_TOTALE, SOGGETTO_REVOCA_FINANZIAMENTO, ID_ATTO_RECUPERO, ID_ATTO_RITIRO, ID_ATTO_NON_RECUPERABILITA, RECUPERABILE, IMPORTO_DETRATTO_TOTALE, DATA_CERTIFICAZIONE_NON_RECUPERABILITA, DATA_REGISTRAZIONE_NON_RECUPERABILITA, COD_ASSE, DESC_AZIONE, DATA_SEGNATURA, SEGNATURA FROM VREGISTRO_RECUPERO WHERE 1=1';
	IF (@IdRegistroRecuperoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_REGISTRO_RECUPERO = @IdRegistroRecuperoequalthis)'; set @lensql=@lensql+len(@IdRegistroRecuperoequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@CfInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_INSERIMENTO = @CfInserimentoequalthis)'; set @lensql=@lensql+len(@CfInserimentoequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@CfModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_MODIFICA = @CfModificaequalthis)'; set @lensql=@lensql+len(@CfModificaequalthis);end;
	IF (@IdRegistroIrregolaritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_REGISTRO_IRREGOLARITA = @IdRegistroIrregolaritaequalthis)'; set @lensql=@lensql+len(@IdRegistroIrregolaritaequalthis);end;
	IF (@DataAvvioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_AVVIO = @DataAvvioequalthis)'; set @lensql=@lensql+len(@DataAvvioequalthis);end;
	IF (@DataProbabileConclusioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_PROBABILE_CONCLUSIONE = @DataProbabileConclusioneequalthis)'; set @lensql=@lensql+len(@DataProbabileConclusioneequalthis);end;
	IF (@ImportoDaRecuperareUeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_DA_RECUPERARE_UE = @ImportoDaRecuperareUeequalthis)'; set @lensql=@lensql+len(@ImportoDaRecuperareUeequalthis);end;
	IF (@ImportoDaRecuperareNazionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_DA_RECUPERARE_NAZIONALE = @ImportoDaRecuperareNazionaleequalthis)'; set @lensql=@lensql+len(@ImportoDaRecuperareNazionaleequalthis);end;
	IF (@ImportoDaRecuperarePubblicoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_DA_RECUPERARE_PUBBLICO = @ImportoDaRecuperarePubblicoequalthis)'; set @lensql=@lensql+len(@ImportoDaRecuperarePubblicoequalthis);end;
	IF (@ImportoDaRecuperarePrivatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_DA_RECUPERARE_PRIVATO = @ImportoDaRecuperarePrivatoequalthis)'; set @lensql=@lensql+len(@ImportoDaRecuperarePrivatoequalthis);end;
	IF (@ImportoDaRecuperareTotaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_DA_RECUPERARE_TOTALE = @ImportoDaRecuperareTotaleequalthis)'; set @lensql=@lensql+len(@ImportoDaRecuperareTotaleequalthis);end;
	IF (@ImportoDetrattoUeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_DETRATTO_UE = @ImportoDetrattoUeequalthis)'; set @lensql=@lensql+len(@ImportoDetrattoUeequalthis);end;
	IF (@ImportoDetrattoNazionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_DETRATTO_NAZIONALE = @ImportoDetrattoNazionaleequalthis)'; set @lensql=@lensql+len(@ImportoDetrattoNazionaleequalthis);end;
	IF (@ImportoDetrattoPubblicoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_DETRATTO_PUBBLICO = @ImportoDetrattoPubblicoequalthis)'; set @lensql=@lensql+len(@ImportoDetrattoPubblicoequalthis);end;
	IF (@ImportoDetrattoPrivatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_DETRATTO_PRIVATO = @ImportoDetrattoPrivatoequalthis)'; set @lensql=@lensql+len(@ImportoDetrattoPrivatoequalthis);end;
	IF (@ImportoDetrattoTotaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_DETRATTO_TOTALE = @ImportoDetrattoTotaleequalthis)'; set @lensql=@lensql+len(@ImportoDetrattoTotaleequalthis);end;
	IF (@ImportoRecuperatoUeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_RECUPERATO_UE = @ImportoRecuperatoUeequalthis)'; set @lensql=@lensql+len(@ImportoRecuperatoUeequalthis);end;
	IF (@ImportoRecuperatoNazionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_RECUPERATO_NAZIONALE = @ImportoRecuperatoNazionaleequalthis)'; set @lensql=@lensql+len(@ImportoRecuperatoNazionaleequalthis);end;
	IF (@ImportoRecuperatoPubblicoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_RECUPERATO_PUBBLICO = @ImportoRecuperatoPubblicoequalthis)'; set @lensql=@lensql+len(@ImportoRecuperatoPubblicoequalthis);end;
	IF (@ImportoRecuperatoPrivatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_RECUPERATO_PRIVATO = @ImportoRecuperatoPrivatoequalthis)'; set @lensql=@lensql+len(@ImportoRecuperatoPrivatoequalthis);end;
	IF (@ImportoRecuperatoTotaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_RECUPERATO_TOTALE = @ImportoRecuperatoTotaleequalthis)'; set @lensql=@lensql+len(@ImportoRecuperatoTotaleequalthis);end;
	IF (@SaldoDaRecuperareUeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SALDO_DA_RECUPERARE_UE = @SaldoDaRecuperareUeequalthis)'; set @lensql=@lensql+len(@SaldoDaRecuperareUeequalthis);end;
	IF (@SaldoDaRecuperareNazionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SALDO_DA_RECUPERARE_NAZIONALE = @SaldoDaRecuperareNazionaleequalthis)'; set @lensql=@lensql+len(@SaldoDaRecuperareNazionaleequalthis);end;
	IF (@SaldoDaRecuperarePubblicoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SALDO_DA_RECUPERARE_PUBBLICO = @SaldoDaRecuperarePubblicoequalthis)'; set @lensql=@lensql+len(@SaldoDaRecuperarePubblicoequalthis);end;
	IF (@SaldoDaRecuperarePrivatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SALDO_DA_RECUPERARE_PRIVATO = @SaldoDaRecuperarePrivatoequalthis)'; set @lensql=@lensql+len(@SaldoDaRecuperarePrivatoequalthis);end;
	IF (@SaldoDaRecuperareTotaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SALDO_DA_RECUPERARE_TOTALE = @SaldoDaRecuperareTotaleequalthis)'; set @lensql=@lensql+len(@SaldoDaRecuperareTotaleequalthis);end;
	IF (@ImportoVersatoUeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_VERSATO_UE = @ImportoVersatoUeequalthis)'; set @lensql=@lensql+len(@ImportoVersatoUeequalthis);end;
	IF (@ImportoRitenutoStatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_RITENUTO_STATO = @ImportoRitenutoStatoequalthis)'; set @lensql=@lensql+len(@ImportoRitenutoStatoequalthis);end;
	IF (@ImportoInteressiMoraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_INTERESSI_MORA = @ImportoInteressiMoraequalthis)'; set @lensql=@lensql+len(@ImportoInteressiMoraequalthis);end;
	IF (@ImportoInteressiLegaliequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_INTERESSI_LEGALI = @ImportoInteressiLegaliequalthis)'; set @lensql=@lensql+len(@ImportoInteressiLegaliequalthis);end;
	IF (@ImportoGestionePraticaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_GESTIONE_PRATICA = @ImportoGestionePraticaequalthis)'; set @lensql=@lensql+len(@ImportoGestionePraticaequalthis);end;
	IF (@DataConclusioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_CONCLUSIONE = @DataConclusioneequalthis)'; set @lensql=@lensql+len(@DataConclusioneequalthis);end;
	IF (@IdProcedureAvviateequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROCEDURE_AVVIATE = @IdProcedureAvviateequalthis)'; set @lensql=@lensql+len(@IdProcedureAvviateequalthis);end;
	IF (@IdTipoProcedureAvviateequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_TIPO_PROCEDURE_AVVIATE = @IdTipoProcedureAvviateequalthis)'; set @lensql=@lensql+len(@IdTipoProcedureAvviateequalthis);end;
	IF (@DataAvvioProcedureequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_AVVIO_PROCEDURE = @DataAvvioProcedureequalthis)'; set @lensql=@lensql+len(@DataAvvioProcedureequalthis);end;
	IF (@DataProbabileConclusioneProcedureequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_PROBABILE_CONCLUSIONE_PROCEDURE = @DataProbabileConclusioneProcedureequalthis)'; set @lensql=@lensql+len(@DataProbabileConclusioneProcedureequalthis);end;
	IF (@IdTipoRecuperoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_TIPO_RECUPERO = @IdTipoRecuperoequalthis)'; set @lensql=@lensql+len(@IdTipoRecuperoequalthis);end;
	IF (@IdOrigineRecuperoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ORIGINE_RECUPERO = @IdOrigineRecuperoequalthis)'; set @lensql=@lensql+len(@IdOrigineRecuperoequalthis);end;
	IF (@IdStoricoRecuperoPrecedenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_STORICO_RECUPERO_PRECEDENTE = @IdStoricoRecuperoPrecedenteequalthis)'; set @lensql=@lensql+len(@IdStoricoRecuperoPrecedenteequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@Storicoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (STORICO = @Storicoequalthis)'; set @lensql=@lensql+len(@Storicoequalthis);end;
	IF (@DataRegistrazioneRitiroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_REGISTRAZIONE_RITIRO = @DataRegistrazioneRitiroequalthis)'; set @lensql=@lensql+len(@DataRegistrazioneRitiroequalthis);end;
	IF (@DataCertificazioneRecuperoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_CERTIFICAZIONE_RECUPERO = @DataCertificazioneRecuperoequalthis)'; set @lensql=@lensql+len(@DataCertificazioneRecuperoequalthis);end;
	IF (@DataCertificazioneRitiroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_CERTIFICAZIONE_RITIRO = @DataCertificazioneRitiroequalthis)'; set @lensql=@lensql+len(@DataCertificazioneRitiroequalthis);end;
	IF (@DataCertificazioneNonRecuperabilitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_CERTIFICAZIONE_NON_RECUPERABILITA = @DataCertificazioneNonRecuperabilitaequalthis)'; set @lensql=@lensql+len(@DataCertificazioneNonRecuperabilitaequalthis);end;
	IF (@GestioneRateequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (GESTIONE_RATE = @GestioneRateequalthis)'; set @lensql=@lensql+len(@GestioneRateequalthis);end;
	IF (@NumeroRateequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO_RATE = @NumeroRateequalthis)'; set @lensql=@lensql+len(@NumeroRateequalthis);end;
	IF (@IntervalloRateMesiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (INTERVALLO_RATE_MESI = @IntervalloRateMesiequalthis)'; set @lensql=@lensql+len(@IntervalloRateMesiequalthis);end;
	IF (@DataInizioRateequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INIZIO_RATE = @DataInizioRateequalthis)'; set @lensql=@lensql+len(@DataInizioRateequalthis);end;
	IF (@ImportoRataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_RATA = @ImportoRataequalthis)'; set @lensql=@lensql+len(@ImportoRataequalthis);end;
	IF (@SoggettoRevocaFinanziamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SOGGETTO_REVOCA_FINANZIAMENTO = @SoggettoRevocaFinanziamentoequalthis)'; set @lensql=@lensql+len(@SoggettoRevocaFinanziamentoequalthis);end;
	IF (@IdAttoRecuperoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ATTO_RECUPERO = @IdAttoRecuperoequalthis)'; set @lensql=@lensql+len(@IdAttoRecuperoequalthis);end;
	IF (@IdAttoRitiroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ATTO_RITIRO = @IdAttoRitiroequalthis)'; set @lensql=@lensql+len(@IdAttoRitiroequalthis);end;
	IF (@IdAttoNonRecuperabilitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ATTO_NON_RECUPERABILITA = @IdAttoNonRecuperabilitaequalthis)'; set @lensql=@lensql+len(@IdAttoNonRecuperabilitaequalthis);end;
	IF (@Recuperabileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RECUPERABILE = @Recuperabileequalthis)'; set @lensql=@lensql+len(@Recuperabileequalthis);end;
	IF (@DataRegistrazioneNonRecuperabilitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_REGISTRAZIONE_NON_RECUPERABILITA = @DataRegistrazioneNonRecuperabilitaequalthis)'; set @lensql=@lensql+len(@DataRegistrazioneNonRecuperabilitaequalthis);end;
	IF (@DataSegnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_SEGNATURA = @DataSegnaturaequalthis)'; set @lensql=@lensql+len(@DataSegnaturaequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA = @Segnaturaequalthis)'; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdRegistroRecuperoequalthis INT, @DataInserimentoequalthis DATETIME, @CfInserimentoequalthis VARCHAR(255), @DataModificaequalthis DATETIME, @CfModificaequalthis VARCHAR(255), @IdRegistroIrregolaritaequalthis INT, @DataAvvioequalthis DATETIME, @DataProbabileConclusioneequalthis DATETIME, @ImportoDaRecuperareUeequalthis DECIMAL(15,2), @ImportoDaRecuperareNazionaleequalthis DECIMAL(15,2), @ImportoDaRecuperarePubblicoequalthis DECIMAL(15,2), @ImportoDaRecuperarePrivatoequalthis DECIMAL(15,2), @ImportoDaRecuperareTotaleequalthis DECIMAL(15,2), @ImportoDetrattoUeequalthis DECIMAL(15,2), @ImportoDetrattoNazionaleequalthis DECIMAL(15,2), @ImportoDetrattoPubblicoequalthis DECIMAL(15,2), @ImportoDetrattoPrivatoequalthis DECIMAL(15,2), @ImportoDetrattoTotaleequalthis DECIMAL(15,2), @ImportoRecuperatoUeequalthis DECIMAL(15,2), @ImportoRecuperatoNazionaleequalthis DECIMAL(15,2), @ImportoRecuperatoPubblicoequalthis DECIMAL(15,2), @ImportoRecuperatoPrivatoequalthis DECIMAL(15,2), @ImportoRecuperatoTotaleequalthis DECIMAL(15,2), @SaldoDaRecuperareUeequalthis DECIMAL(15,2), @SaldoDaRecuperareNazionaleequalthis DECIMAL(15,2), @SaldoDaRecuperarePubblicoequalthis DECIMAL(15,2), @SaldoDaRecuperarePrivatoequalthis DECIMAL(15,2), @SaldoDaRecuperareTotaleequalthis DECIMAL(15,2), @ImportoVersatoUeequalthis DECIMAL(15,2), @ImportoRitenutoStatoequalthis DECIMAL(15,2), @ImportoInteressiMoraequalthis DECIMAL(15,2), @ImportoInteressiLegaliequalthis DECIMAL(15,2), @ImportoGestionePraticaequalthis DECIMAL(15,2), @DataConclusioneequalthis DATETIME, @IdProcedureAvviateequalthis INT, @IdTipoProcedureAvviateequalthis INT, @DataAvvioProcedureequalthis DATETIME, @DataProbabileConclusioneProcedureequalthis DATETIME, @IdTipoRecuperoequalthis INT, @IdOrigineRecuperoequalthis INT, @IdStoricoRecuperoPrecedenteequalthis INT, @IdProgettoequalthis INT, @Storicoequalthis BIT, @DataRegistrazioneRitiroequalthis DATETIME, @DataCertificazioneRecuperoequalthis DATETIME, @DataCertificazioneRitiroequalthis DATETIME, @DataCertificazioneNonRecuperabilitaequalthis DATETIME, @GestioneRateequalthis BIT, @NumeroRateequalthis INT, @IntervalloRateMesiequalthis INT, @DataInizioRateequalthis DATETIME, @ImportoRataequalthis DECIMAL(15,2), @SoggettoRevocaFinanziamentoequalthis VARCHAR(2000), @IdAttoRecuperoequalthis INT, @IdAttoRitiroequalthis INT, @IdAttoNonRecuperabilitaequalthis INT, @Recuperabileequalthis BIT, @DataRegistrazioneNonRecuperabilitaequalthis DATETIME, @DataSegnaturaequalthis DATETIME, @Segnaturaequalthis VARCHAR(255)',@IdRegistroRecuperoequalthis , @DataInserimentoequalthis , @CfInserimentoequalthis , @DataModificaequalthis , @CfModificaequalthis , @IdRegistroIrregolaritaequalthis , @DataAvvioequalthis , @DataProbabileConclusioneequalthis , @ImportoDaRecuperareUeequalthis , @ImportoDaRecuperareNazionaleequalthis , @ImportoDaRecuperarePubblicoequalthis , @ImportoDaRecuperarePrivatoequalthis , @ImportoDaRecuperareTotaleequalthis , @ImportoDetrattoUeequalthis , @ImportoDetrattoNazionaleequalthis , @ImportoDetrattoPubblicoequalthis , @ImportoDetrattoPrivatoequalthis , @ImportoDetrattoTotaleequalthis , @ImportoRecuperatoUeequalthis , @ImportoRecuperatoNazionaleequalthis , @ImportoRecuperatoPubblicoequalthis , @ImportoRecuperatoPrivatoequalthis , @ImportoRecuperatoTotaleequalthis , @SaldoDaRecuperareUeequalthis , @SaldoDaRecuperareNazionaleequalthis , @SaldoDaRecuperarePubblicoequalthis , @SaldoDaRecuperarePrivatoequalthis , @SaldoDaRecuperareTotaleequalthis , @ImportoVersatoUeequalthis , @ImportoRitenutoStatoequalthis , @ImportoInteressiMoraequalthis , @ImportoInteressiLegaliequalthis , @ImportoGestionePraticaequalthis , @DataConclusioneequalthis , @IdProcedureAvviateequalthis , @IdTipoProcedureAvviateequalthis , @DataAvvioProcedureequalthis , @DataProbabileConclusioneProcedureequalthis , @IdTipoRecuperoequalthis , @IdOrigineRecuperoequalthis , @IdStoricoRecuperoPrecedenteequalthis , @IdProgettoequalthis , @Storicoequalthis , @DataRegistrazioneRitiroequalthis , @DataCertificazioneRecuperoequalthis , @DataCertificazioneRitiroequalthis , @DataCertificazioneNonRecuperabilitaequalthis , @GestioneRateequalthis , @NumeroRateequalthis , @IntervalloRateMesiequalthis , @DataInizioRateequalthis , @ImportoRataequalthis , @SoggettoRevocaFinanziamentoequalthis , @IdAttoRecuperoequalthis , @IdAttoRitiroequalthis , @IdAttoNonRecuperabilitaequalthis , @Recuperabileequalthis , @DataRegistrazioneNonRecuperabilitaequalthis , @DataSegnaturaequalthis , @Segnaturaequalthis ;
	else
		SELECT ID_REGISTRO_RECUPERO, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, ID_REGISTRO_IRREGOLARITA, DATA_AVVIO, DATA_PROBABILE_CONCLUSIONE, IMPORTO_DA_RECUPERARE_UE, IMPORTO_DA_RECUPERARE_NAZIONALE, IMPORTO_DA_RECUPERARE_PUBBLICO, IMPORTO_DETRATTO_UE, IMPORTO_DETRATTO_NAZIONALE, IMPORTO_DETRATTO_PUBBLICO, IMPORTO_RECUPERATO_UE, IMPORTO_RECUPERATO_PUBBLICO, IMPORTO_RECUPERATO_NAZIONALE, SALDO_DA_RECUPERARE_UE, SALDO_DA_RECUPERARE_NAZIONALE, SALDO_DA_RECUPERARE_PUBBLICO, IMPORTO_VERSATO_UE, IMPORTO_RITENUTO_STATO, DATA_CONCLUSIONE, ID_PROCEDURE_AVVIATE, ID_TIPO_PROCEDURE_AVVIATE, DATA_AVVIO_PROCEDURE, DATA_PROBABILE_CONCLUSIONE_PROCEDURE, ID_TIPO_RECUPERO, ID_ORIGINE_RECUPERO, ID_STORICO_RECUPERO_PRECEDENTE, ID_PROGETTO, ID_BANDO, ID_IMPRESA, COD_AGEA, SEGNATURA_ALLEGATI, ID_PROG_INTEGRATO, FLAG_PREADESIONE, FLAG_DEFINITIVO, ID_FASCICOLO, PROVINCIA_DI_PRESENTAZIONE, SELEZIONATA_X_REVISIONE, ID_STORICO_ULTIMO, DATA_CREAZIONE, OPERATORE_CREAZIONE, FIRMA_PREDISPOSTA, STORICO, IMPORTO_INTERESSI_LEGALI, IMPORTO_INTERESSI_MORA, IMPORTO_GESTIONE_PRATICA, DATA_REGISTRAZIONE_RITIRO, DATA_CERTIFICAZIONE_RECUPERO, DATA_CERTIFICAZIONE_RITIRO, GESTIONE_RATE, NUMERO_RATE, DATA_INIZIO_RATE, IMPORTO_RATA, INTERVALLO_RATE_MESI, ID_PROGRAMMAZIONE, PROGRAMMAZIONE, IMPORTO_DA_RECUPERARE_PRIVATO, IMPORTO_DA_RECUPERARE_TOTALE, IMPORTO_DETRATTO_PRIVATO, IMPORTO_RECUPERATO_PRIVATO, IMPORTO_RECUPERATO_TOTALE, SALDO_DA_RECUPERARE_PRIVATO, SALDO_DA_RECUPERARE_TOTALE, SOGGETTO_REVOCA_FINANZIAMENTO, ID_ATTO_RECUPERO, ID_ATTO_RITIRO, ID_ATTO_NON_RECUPERABILITA, RECUPERABILE, IMPORTO_DETRATTO_TOTALE, DATA_CERTIFICAZIONE_NON_RECUPERABILITA, DATA_REGISTRAZIONE_NON_RECUPERABILITA, COD_ASSE, DESC_AZIONE, DATA_SEGNATURA, SEGNATURA
		FROM VREGISTRO_RECUPERO
		WHERE 
			((@IdRegistroRecuperoequalthis IS NULL) OR ID_REGISTRO_RECUPERO = @IdRegistroRecuperoequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@CfInserimentoequalthis IS NULL) OR CF_INSERIMENTO = @CfInserimentoequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@CfModificaequalthis IS NULL) OR CF_MODIFICA = @CfModificaequalthis) AND 
			((@IdRegistroIrregolaritaequalthis IS NULL) OR ID_REGISTRO_IRREGOLARITA = @IdRegistroIrregolaritaequalthis) AND 
			((@DataAvvioequalthis IS NULL) OR DATA_AVVIO = @DataAvvioequalthis) AND 
			((@DataProbabileConclusioneequalthis IS NULL) OR DATA_PROBABILE_CONCLUSIONE = @DataProbabileConclusioneequalthis) AND 
			((@ImportoDaRecuperareUeequalthis IS NULL) OR IMPORTO_DA_RECUPERARE_UE = @ImportoDaRecuperareUeequalthis) AND 
			((@ImportoDaRecuperareNazionaleequalthis IS NULL) OR IMPORTO_DA_RECUPERARE_NAZIONALE = @ImportoDaRecuperareNazionaleequalthis) AND 
			((@ImportoDaRecuperarePubblicoequalthis IS NULL) OR IMPORTO_DA_RECUPERARE_PUBBLICO = @ImportoDaRecuperarePubblicoequalthis) AND 
			((@ImportoDaRecuperarePrivatoequalthis IS NULL) OR IMPORTO_DA_RECUPERARE_PRIVATO = @ImportoDaRecuperarePrivatoequalthis) AND 
			((@ImportoDaRecuperareTotaleequalthis IS NULL) OR IMPORTO_DA_RECUPERARE_TOTALE = @ImportoDaRecuperareTotaleequalthis) AND 
			((@ImportoDetrattoUeequalthis IS NULL) OR IMPORTO_DETRATTO_UE = @ImportoDetrattoUeequalthis) AND 
			((@ImportoDetrattoNazionaleequalthis IS NULL) OR IMPORTO_DETRATTO_NAZIONALE = @ImportoDetrattoNazionaleequalthis) AND 
			((@ImportoDetrattoPubblicoequalthis IS NULL) OR IMPORTO_DETRATTO_PUBBLICO = @ImportoDetrattoPubblicoequalthis) AND 
			((@ImportoDetrattoPrivatoequalthis IS NULL) OR IMPORTO_DETRATTO_PRIVATO = @ImportoDetrattoPrivatoequalthis) AND 
			((@ImportoDetrattoTotaleequalthis IS NULL) OR IMPORTO_DETRATTO_TOTALE = @ImportoDetrattoTotaleequalthis) AND 
			((@ImportoRecuperatoUeequalthis IS NULL) OR IMPORTO_RECUPERATO_UE = @ImportoRecuperatoUeequalthis) AND 
			((@ImportoRecuperatoNazionaleequalthis IS NULL) OR IMPORTO_RECUPERATO_NAZIONALE = @ImportoRecuperatoNazionaleequalthis) AND 
			((@ImportoRecuperatoPubblicoequalthis IS NULL) OR IMPORTO_RECUPERATO_PUBBLICO = @ImportoRecuperatoPubblicoequalthis) AND 
			((@ImportoRecuperatoPrivatoequalthis IS NULL) OR IMPORTO_RECUPERATO_PRIVATO = @ImportoRecuperatoPrivatoequalthis) AND 
			((@ImportoRecuperatoTotaleequalthis IS NULL) OR IMPORTO_RECUPERATO_TOTALE = @ImportoRecuperatoTotaleequalthis) AND 
			((@SaldoDaRecuperareUeequalthis IS NULL) OR SALDO_DA_RECUPERARE_UE = @SaldoDaRecuperareUeequalthis) AND 
			((@SaldoDaRecuperareNazionaleequalthis IS NULL) OR SALDO_DA_RECUPERARE_NAZIONALE = @SaldoDaRecuperareNazionaleequalthis) AND 
			((@SaldoDaRecuperarePubblicoequalthis IS NULL) OR SALDO_DA_RECUPERARE_PUBBLICO = @SaldoDaRecuperarePubblicoequalthis) AND 
			((@SaldoDaRecuperarePrivatoequalthis IS NULL) OR SALDO_DA_RECUPERARE_PRIVATO = @SaldoDaRecuperarePrivatoequalthis) AND 
			((@SaldoDaRecuperareTotaleequalthis IS NULL) OR SALDO_DA_RECUPERARE_TOTALE = @SaldoDaRecuperareTotaleequalthis) AND 
			((@ImportoVersatoUeequalthis IS NULL) OR IMPORTO_VERSATO_UE = @ImportoVersatoUeequalthis) AND 
			((@ImportoRitenutoStatoequalthis IS NULL) OR IMPORTO_RITENUTO_STATO = @ImportoRitenutoStatoequalthis) AND 
			((@ImportoInteressiMoraequalthis IS NULL) OR IMPORTO_INTERESSI_MORA = @ImportoInteressiMoraequalthis) AND 
			((@ImportoInteressiLegaliequalthis IS NULL) OR IMPORTO_INTERESSI_LEGALI = @ImportoInteressiLegaliequalthis) AND 
			((@ImportoGestionePraticaequalthis IS NULL) OR IMPORTO_GESTIONE_PRATICA = @ImportoGestionePraticaequalthis) AND 
			((@DataConclusioneequalthis IS NULL) OR DATA_CONCLUSIONE = @DataConclusioneequalthis) AND 
			((@IdProcedureAvviateequalthis IS NULL) OR ID_PROCEDURE_AVVIATE = @IdProcedureAvviateequalthis) AND 
			((@IdTipoProcedureAvviateequalthis IS NULL) OR ID_TIPO_PROCEDURE_AVVIATE = @IdTipoProcedureAvviateequalthis) AND 
			((@DataAvvioProcedureequalthis IS NULL) OR DATA_AVVIO_PROCEDURE = @DataAvvioProcedureequalthis) AND 
			((@DataProbabileConclusioneProcedureequalthis IS NULL) OR DATA_PROBABILE_CONCLUSIONE_PROCEDURE = @DataProbabileConclusioneProcedureequalthis) AND 
			((@IdTipoRecuperoequalthis IS NULL) OR ID_TIPO_RECUPERO = @IdTipoRecuperoequalthis) AND 
			((@IdOrigineRecuperoequalthis IS NULL) OR ID_ORIGINE_RECUPERO = @IdOrigineRecuperoequalthis) AND 
			((@IdStoricoRecuperoPrecedenteequalthis IS NULL) OR ID_STORICO_RECUPERO_PRECEDENTE = @IdStoricoRecuperoPrecedenteequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@Storicoequalthis IS NULL) OR STORICO = @Storicoequalthis) AND 
			((@DataRegistrazioneRitiroequalthis IS NULL) OR DATA_REGISTRAZIONE_RITIRO = @DataRegistrazioneRitiroequalthis) AND 
			((@DataCertificazioneRecuperoequalthis IS NULL) OR DATA_CERTIFICAZIONE_RECUPERO = @DataCertificazioneRecuperoequalthis) AND 
			((@DataCertificazioneRitiroequalthis IS NULL) OR DATA_CERTIFICAZIONE_RITIRO = @DataCertificazioneRitiroequalthis) AND 
			((@DataCertificazioneNonRecuperabilitaequalthis IS NULL) OR DATA_CERTIFICAZIONE_NON_RECUPERABILITA = @DataCertificazioneNonRecuperabilitaequalthis) AND 
			((@GestioneRateequalthis IS NULL) OR GESTIONE_RATE = @GestioneRateequalthis) AND 
			((@NumeroRateequalthis IS NULL) OR NUMERO_RATE = @NumeroRateequalthis) AND 
			((@IntervalloRateMesiequalthis IS NULL) OR INTERVALLO_RATE_MESI = @IntervalloRateMesiequalthis) AND 
			((@DataInizioRateequalthis IS NULL) OR DATA_INIZIO_RATE = @DataInizioRateequalthis) AND 
			((@ImportoRataequalthis IS NULL) OR IMPORTO_RATA = @ImportoRataequalthis) AND 
			((@SoggettoRevocaFinanziamentoequalthis IS NULL) OR SOGGETTO_REVOCA_FINANZIAMENTO = @SoggettoRevocaFinanziamentoequalthis) AND 
			((@IdAttoRecuperoequalthis IS NULL) OR ID_ATTO_RECUPERO = @IdAttoRecuperoequalthis) AND 
			((@IdAttoRitiroequalthis IS NULL) OR ID_ATTO_RITIRO = @IdAttoRitiroequalthis) AND 
			((@IdAttoNonRecuperabilitaequalthis IS NULL) OR ID_ATTO_NON_RECUPERABILITA = @IdAttoNonRecuperabilitaequalthis) AND 
			((@Recuperabileequalthis IS NULL) OR RECUPERABILE = @Recuperabileequalthis) AND 
			((@DataRegistrazioneNonRecuperabilitaequalthis IS NULL) OR DATA_REGISTRAZIONE_NON_RECUPERABILITA = @DataRegistrazioneNonRecuperabilitaequalthis) AND 
			((@DataSegnaturaequalthis IS NULL) OR DATA_SEGNATURA = @DataSegnaturaequalthis) AND 
			((@Segnaturaequalthis IS NULL) OR SEGNATURA = @Segnaturaequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZRegistroRecuperoFindSelect]
(
	@IdRegistroRecuperoequalthis INT, 
	@DataInserimentoequalthis DATETIME, 
	@CfInserimentoequalthis VARCHAR(255), 
	@DataModificaequalthis DATETIME, 
	@CfModificaequalthis VARCHAR(255), 
	@IdRegistroIrregolaritaequalthis INT, 
	@DataAvvioequalthis DATETIME, 
	@DataProbabileConclusioneequalthis DATETIME, 
	@ImportoDaRecuperareUeequalthis DECIMAL(15,2), 
	@ImportoDaRecuperareNazionaleequalthis DECIMAL(15,2), 
	@ImportoDaRecuperarePubblicoequalthis DECIMAL(15,2), 
	@ImportoDaRecuperarePrivatoequalthis DECIMAL(15,2), 
	@ImportoDaRecuperareTotaleequalthis DECIMAL(15,2), 
	@ImportoDetrattoUeequalthis DECIMAL(15,2), 
	@ImportoDetrattoNazionaleequalthis DECIMAL(15,2), 
	@ImportoDetrattoPubblicoequalthis DECIMAL(15,2), 
	@ImportoDetrattoPrivatoequalthis DECIMAL(15,2), 
	@ImportoDetrattoTotaleequalthis DECIMAL(15,2), 
	@ImportoRecuperatoUeequalthis DECIMAL(15,2), 
	@ImportoRecuperatoNazionaleequalthis DECIMAL(15,2), 
	@ImportoRecuperatoPubblicoequalthis DECIMAL(15,2), 
	@ImportoRecuperatoPrivatoequalthis DECIMAL(15,2), 
	@ImportoRecuperatoTotaleequalthis DECIMAL(15,2), 
	@SaldoDaRecuperareUeequalthis DECIMAL(15,2), 
	@SaldoDaRecuperareNazionaleequalthis DECIMAL(15,2), 
	@SaldoDaRecuperarePubblicoequalthis DECIMAL(15,2), 
	@SaldoDaRecuperarePrivatoequalthis DECIMAL(15,2), 
	@SaldoDaRecuperareTotaleequalthis DECIMAL(15,2), 
	@ImportoVersatoUeequalthis DECIMAL(15,2), 
	@ImportoRitenutoStatoequalthis DECIMAL(15,2), 
	@ImportoInteressiMoraequalthis DECIMAL(15,2), 
	@ImportoInteressiLegaliequalthis DECIMAL(15,2), 
	@ImportoGestionePraticaequalthis DECIMAL(15,2), 
	@DataConclusioneequalthis DATETIME, 
	@IdProcedureAvviateequalthis INT, 
	@IdTipoProcedureAvviateequalthis INT, 
	@DataAvvioProcedureequalthis DATETIME, 
	@DataProbabileConclusioneProcedureequalthis DATETIME, 
	@IdTipoRecuperoequalthis INT, 
	@IdOrigineRecuperoequalthis INT, 
	@IdStoricoRecuperoPrecedenteequalthis INT, 
	@IdProgettoequalthis INT, 
	@Storicoequalthis BIT, 
	@DataRegistrazioneRitiroequalthis DATETIME, 
	@DataCertificazioneRecuperoequalthis DATETIME, 
	@DataCertificazioneRitiroequalthis DATETIME, 
	@DataCertificazioneNonRecuperabilitaequalthis DATETIME, 
	@GestioneRateequalthis BIT, 
	@NumeroRateequalthis INT, 
	@IntervalloRateMesiequalthis INT, 
	@DataInizioRateequalthis DATETIME, 
	@ImportoRataequalthis DECIMAL(15,2), 
	@SoggettoRevocaFinanziamentoequalthis VARCHAR(2000), 
	@IdAttoRecuperoequalthis INT, 
	@IdAttoRitiroequalthis INT, 
	@IdAttoNonRecuperabilitaequalthis INT, 
	@Recuperabileequalthis BIT, 
	@DataRegistrazioneNonRecuperabilitaequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_REGISTRO_RECUPERO, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, ID_REGISTRO_IRREGOLARITA, DATA_AVVIO, DATA_PROBABILE_CONCLUSIONE, IMPORTO_DA_RECUPERARE_UE, IMPORTO_DA_RECUPERARE_NAZIONALE, IMPORTO_DA_RECUPERARE_PUBBLICO, IMPORTO_DETRATTO_UE, IMPORTO_DETRATTO_NAZIONALE, IMPORTO_DETRATTO_PUBBLICO, IMPORTO_RECUPERATO_UE, IMPORTO_RECUPERATO_PUBBLICO, IMPORTO_RECUPERATO_NAZIONALE, SALDO_DA_RECUPERARE_UE, SALDO_DA_RECUPERARE_NAZIONALE, SALDO_DA_RECUPERARE_PUBBLICO, IMPORTO_VERSATO_UE, IMPORTO_RITENUTO_STATO, DATA_CONCLUSIONE, ID_PROCEDURE_AVVIATE, ID_TIPO_PROCEDURE_AVVIATE, DATA_AVVIO_PROCEDURE, DATA_PROBABILE_CONCLUSIONE_PROCEDURE, ID_TIPO_RECUPERO, ID_ORIGINE_RECUPERO, ID_STORICO_RECUPERO_PRECEDENTE, ID_PROGETTO, ID_BANDO, ID_IMPRESA, COD_AGEA, SEGNATURA_ALLEGATI, ID_PROG_INTEGRATO, FLAG_PREADESIONE, FLAG_DEFINITIVO, ID_FASCICOLO, PROVINCIA_DI_PRESENTAZIONE, SELEZIONATA_X_REVISIONE, ID_STORICO_ULTIMO, DATA_CREAZIONE, OPERATORE_CREAZIONE, FIRMA_PREDISPOSTA, STORICO, IMPORTO_INTERESSI_LEGALI, IMPORTO_INTERESSI_MORA, IMPORTO_GESTIONE_PRATICA, DATA_REGISTRAZIONE_RITIRO, DATA_CERTIFICAZIONE_RECUPERO, DATA_CERTIFICAZIONE_RITIRO, GESTIONE_RATE, NUMERO_RATE, DATA_INIZIO_RATE, IMPORTO_RATA, INTERVAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRegistroRecuperoFindSelect';

