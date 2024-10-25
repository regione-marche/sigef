CREATE PROCEDURE [dbo].[ZBandoValidatoriInsert]
(
	@IdBando INT, 
	@IdUtente INT, 
	@Responsabile BIT, 
	@Attivo BIT, 
	@DataInizio DATETIME, 
	@OperatoreInizio INT, 
	@DataFine DATETIME, 
	@OperatoreFine INT
)
AS
	SET @Responsabile = ISNULL(@Responsabile,((0)))
	SET @Attivo = ISNULL(@Attivo,((1)))
	INSERT INTO BANDO_VALIDATORI
	(
		ID_BANDO, 
		ID_UTENTE, 
		RESPONSABILE, 
		ATTIVO, 
		DATA_INIZIO, 
		OPERATORE_INIZIO, 
		DATA_FINE, 
		OPERATORE_FINE
	)
	VALUES
	(
		@IdBando, 
		@IdUtente, 
		@Responsabile, 
		@Attivo, 
		@DataInizio, 
		@OperatoreInizio, 
		@DataFine, 
		@OperatoreFine
	)
	SELECT SCOPE_IDENTITY() AS ID, @Responsabile AS RESPONSABILE, @Attivo AS ATTIVO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoValidatoriInsert';

