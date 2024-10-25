CREATE PROCEDURE ZRnaProgettoCorUpdate
(
	@IdRnaProgettoCor INT, 
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
	UPDATE RNA_PROGETTO_COR
	SET
		ID_PROGETTO = @IdProgetto, 
		ID_PROGETTO_RNA = @IdProgettoRna, 
		ID_RICHIESTA = @IdRichiesta, 
		ID_IMPRESA = @IdImpresa, 
		ID_FISCALE_IMPRESA = @IdFiscaleImpresa, 
		ID_OPERATORE_ASSEGNAZIONE_COR = @IdOperatoreAssegnazioneCor, 
		COR = @Cor, 
		STATO_CONCESSIONE = @StatoConcessione, 
		DATA_ASSEGNAZIONE_COR = @DataAssegnazioneCor, 
		CONFERMATO = @Confermato, 
		ID_OPERATORE_CONFERMA_CONCESSIONE = @IdOperatoreConfermaConcessione, 
		DATA_CONFERMA_CONCESSIONE = @DataConfermaConcessione, 
		ANNULLATO = @Annullato, 
		ID_OPERATORE_ANNULLAMENTO = @IdOperatoreAnnullamento, 
		DATA_ANNULLAMENTO = @DataAnnullamento, 
		DATA_INSERIMENTO = @DataInserimento, 
		DATA_AGGIORNAMENTO = @DataAggiornamento
	WHERE 
		(ID_RNA_PROGETTO_COR = @IdRnaProgettoCor)

GO