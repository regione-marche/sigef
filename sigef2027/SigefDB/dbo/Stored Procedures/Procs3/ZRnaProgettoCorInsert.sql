CREATE PROCEDURE ZRnaProgettoCorInsert
(
	@IdProgetto INT, 
	@IdProgettoRna VARCHAR(255), 
	@IdRichiesta VARCHAR(255), 
	@IdImpresa INT, 
	@IdFiscaleImpresa VARCHAR(255), 
	@IdOperatoreAssegnazioneCor INT, 
	@Cor VARCHAR(255), 
	@StatoConcessione VARCHAR(255), 
	@DataAssegnazioneCor DATETIME, 
	@Confermato BIT, 
	@IdOperatoreConfermaConcessione INT, 
	@DataConfermaConcessione DATETIME, 
	@Annullato BIT, 
	@IdOperatoreAnnullamento INT, 
	@DataAnnullamento DATETIME, 
	@DataInserimento DATETIME, 
	@DataAggiornamento DATETIME
)
AS
	SET @Confermato = ISNULL(@Confermato,((0)))
	SET @Annullato = ISNULL(@Annullato,((0)))
	SET @DataInserimento = ISNULL(@DataInserimento,(getdate()))
	SET @DataAggiornamento = ISNULL(@DataAggiornamento,(getdate()))
	INSERT INTO RNA_PROGETTO_COR
	(
		ID_PROGETTO, 
		ID_PROGETTO_RNA, 
		ID_RICHIESTA, 
		ID_IMPRESA, 
		ID_FISCALE_IMPRESA, 
		ID_OPERATORE_ASSEGNAZIONE_COR, 
		COR, 
		STATO_CONCESSIONE, 
		DATA_ASSEGNAZIONE_COR, 
		CONFERMATO, 
		ID_OPERATORE_CONFERMA_CONCESSIONE, 
		DATA_CONFERMA_CONCESSIONE, 
		ANNULLATO, 
		ID_OPERATORE_ANNULLAMENTO, 
		DATA_ANNULLAMENTO, 
		DATA_INSERIMENTO, 
		DATA_AGGIORNAMENTO
	)
	VALUES
	(
		@IdProgetto, 
		@IdProgettoRna, 
		@IdRichiesta, 
		@IdImpresa, 
		@IdFiscaleImpresa, 
		@IdOperatoreAssegnazioneCor, 
		@Cor, 
		@StatoConcessione, 
		@DataAssegnazioneCor, 
		@Confermato, 
		@IdOperatoreConfermaConcessione, 
		@DataConfermaConcessione, 
		@Annullato, 
		@IdOperatoreAnnullamento, 
		@DataAnnullamento, 
		@DataInserimento, 
		@DataAggiornamento
	)
	SELECT SCOPE_IDENTITY() AS ID_RNA_PROGETTO_COR, @Confermato AS CONFERMATO, @Annullato AS ANNULLATO, @DataInserimento AS DATA_INSERIMENTO, @DataAggiornamento AS DATA_AGGIORNAMENTO

GO