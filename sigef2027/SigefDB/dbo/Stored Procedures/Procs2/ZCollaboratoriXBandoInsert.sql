CREATE PROCEDURE [dbo].[ZCollaboratoriXBandoInsert]
(
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
	SET @Attivo = ISNULL(@Attivo,((0)))
	INSERT INTO COLLABORATORI_X_BANDO
	(
		ID_BANDO, 
		ID_PROGETTO, 
		PROVINCIA, 
		DATA_INSERIMENTO, 
		DATA_FINE_VALIDITA, 
		ID_UTENTE, 
		OPERATORE_INSERIMENTO, 
		OPERATORE_FINE_VALIDITA, 
		ATTIVO
	)
	VALUES
	(
		@IdBando, 
		@IdProgetto, 
		@Provincia, 
		@DataInserimento, 
		@DataFineValidita, 
		@IdUtente, 
		@OperatoreInserimento, 
		@OperatoreFineValidita, 
		@Attivo
	)
	SELECT SCOPE_IDENTITY() AS ID_COLLABORATORE, @Attivo AS ATTIVO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZCollaboratoriXBandoInsert]
(
	@IdBando INT, 
	@IdProgetto INT, 
	@CfUtente VARCHAR(16), 
	@Provincia CHAR(2), 
	@Operatore VARCHAR(16), 
	@DataInserimento DATETIME, 
	@DataFineValidita DATETIME
)
AS
	INSERT INTO COLLABORATORI_X_BANDO
	(
		ID_BANDO, 
		ID_PROGETTO, 
		CF_UTENTE, 
		PROVINCIA, 
		OPERATORE, 
		DATA_INSERIMENTO, 
		DATA_FINE_VALIDITA
	)
	VALUES
	(
		@IdBando, 
		@IdProgetto, 
		@CfUtente, 
		@Provincia, 
		@Operatore, 
		@DataInserimento, 
		@DataFineValidita
	)
	SELECT SCOPE_IDENTITY() AS ID_COLLABORATORE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCollaboratoriXBandoInsert';

