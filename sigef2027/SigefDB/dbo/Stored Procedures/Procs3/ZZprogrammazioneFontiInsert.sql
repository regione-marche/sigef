CREATE PROCEDURE [dbo].[ZZprogrammazioneFontiInsert]
(
	@IdProgrammazione INT, 
	@IdFonte INT, 
	@Percentuale DECIMAL(10,2), 
	@DataInizio DATETIME, 
	@OperatoreInizio INT, 
	@DataFine DATETIME, 
	@OperatoreFine INT, 
	@Attiva BIT
)
AS
	SET @Attiva = ISNULL(@Attiva,((0)))
	INSERT INTO zPROGRAMMAZIONE_FONTI
	(
		ID_PROGRAMMAZIONE, 
		ID_FONTE, 
		PERCENTUALE, 
		DATA_INIZIO, 
		OPERATORE_INIZIO, 
		DATA_FINE, 
		OPERATORE_FINE, 
		ATTIVA
	)
	VALUES
	(
		@IdProgrammazione, 
		@IdFonte, 
		@Percentuale, 
		@DataInizio, 
		@OperatoreInizio, 
		@DataFine, 
		@OperatoreFine, 
		@Attiva
	)
	SELECT SCOPE_IDENTITY() AS ID, @Attiva AS ATTIVA


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZprogrammazioneFontiInsert';

