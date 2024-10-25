CREATE PROCEDURE ZRnaLogConcessioniUpdate
(
	@IdRnaLogConcessione INT, 
	@IdProgetto INT, 
	@IdProgettoRna VARCHAR(255), 
	@IdImpresa INT, 
	@IdFiscaleImpresa VARCHAR(255), 
	@IdRichiesta VARCHAR(255), 
	@DataRichiesta DATETIME, 
	@IdOperatoreRegAiuto INT, 
	@IstanzaRichiesta XML, 
	@IstanzaRisposta XML, 
	@Cor VARCHAR(255), 
	@CodiceEsito INT, 
	@DescrizioneEsito NVARCHAR(max), 
	@CodiceEsitoStatoRichiesta INT, 
	@DescrizioneEsitoStatoRichiesta NVARCHAR(max), 
	@IdOperatoreStatoRichiesta INT, 
	@DataStatoRichiesta DATETIME, 
	@Errore NVARCHAR(max), 
	@DataInserimento DATETIME, 
	@DataAggiornamento DATETIME
)
AS
	UPDATE RNA_LOG_CONCESSIONI
	SET
		ID_PROGETTO = @IdProgetto, 
		ID_PROGETTO_RNA = @IdProgettoRna, 
		ID_IMPRESA = @IdImpresa, 
		ID_FISCALE_IMPRESA = @IdFiscaleImpresa, 
		ID_RICHIESTA = @IdRichiesta, 
		DATA_RICHIESTA = @DataRichiesta, 
		ID_OPERATORE_REG_AIUTO = @IdOperatoreRegAiuto, 
		ISTANZA_RICHIESTA = @IstanzaRichiesta, 
		ISTANZA_RISPOSTA = @IstanzaRisposta, 
		COR = @Cor, 
		CODICE_ESITO = @CodiceEsito, 
		DESCRIZIONE_ESITO = @DescrizioneEsito, 
		CODICE_ESITO_STATO_RICHIESTA = @CodiceEsitoStatoRichiesta, 
		DESCRIZIONE_ESITO_STATO_RICHIESTA = @DescrizioneEsitoStatoRichiesta, 
		ID_OPERATORE_STATO_RICHIESTA = @IdOperatoreStatoRichiesta, 
		DATA_STATO_RICHIESTA = @DataStatoRichiesta, 
		ERRORE = @Errore, 
		DATA_INSERIMENTO = @DataInserimento, 
		DATA_AGGIORNAMENTO = @DataAggiornamento
	WHERE 
		(ID_RNA_LOG_CONCESSIONE = @IdRnaLogConcessione)

GO