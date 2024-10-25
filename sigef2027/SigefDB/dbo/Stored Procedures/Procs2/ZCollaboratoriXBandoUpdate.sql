CREATE PROCEDURE [dbo].[ZCollaboratoriXBandoUpdate]
(
	@IdCollaboratore INT, 
	@IdBando INT, 
	@IdProgetto INT, 
	@Provincia CHAR(2), 
	@DataInserimento DATETIME, 
	@DataFineValidita DATETIME, 
	@IdUtente INT, 
	@OperatoreInserimento INT, 
	@OperatoreFineValidita INT, 
	@Attivo BIT
)
AS
	UPDATE COLLABORATORI_X_BANDO
	SET
		ID_BANDO = @IdBando, 
		ID_PROGETTO = @IdProgetto, 
		PROVINCIA = @Provincia, 
		DATA_INSERIMENTO = @DataInserimento, 
		DATA_FINE_VALIDITA = @DataFineValidita, 
		ID_UTENTE = @IdUtente, 
		OPERATORE_INSERIMENTO = @OperatoreInserimento, 
		OPERATORE_FINE_VALIDITA = @OperatoreFineValidita, 
		ATTIVO = @Attivo
	WHERE 
		(ID_COLLABORATORE = @IdCollaboratore)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZCollaboratoriXBandoUpdate]
(
	@IdCollaboratore INT, 
	@IdBando INT, 
	@IdProgetto INT, 
	@CfUtente VARCHAR(16), 
	@Provincia CHAR(2), 
	@Operatore VARCHAR(16), 
	@DataInserimento DATETIME, 
	@DataFineValidita DATETIME
)
AS
	UPDATE COLLABORATORI_X_BANDO
	SET
		ID_BANDO = @IdBando, 
		ID_PROGETTO = @IdProgetto, 
		CF_UTENTE = @CfUtente, 
		PROVINCIA = @Provincia, 
		OPERATORE = @Operatore, 
		DATA_INSERIMENTO = @DataInserimento, 
		DATA_FINE_VALIDITA = @DataFineValidita
	WHERE 
		(ID_COLLABORATORE = @IdCollaboratore)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCollaboratoriXBandoUpdate';

