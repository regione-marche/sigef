CREATE PROCEDURE [dbo].[ZZprogrammazioneSanzioniInsert]
(
	@IdProgrammazione INT, 
	@CodSanzione VARCHAR(255), 
	@Attiva BIT, 
	@DataInizio DATETIME, 
	@OperatoreInizio INT, 
	@DataFine DATETIME, 
	@OperatoreFine INT, 
	@Ordine INT
)
AS
	SET @Attiva = ISNULL(@Attiva,((0)))
	INSERT INTO zPROGRAMMAZIONE_SANZIONI
	(
		ID_PROGRAMMAZIONE, 
		COD_SANZIONE, 
		ATTIVA, 
		DATA_INIZIO, 
		OPERATORE_INIZIO, 
		DATA_FINE, 
		OPERATORE_FINE, 
		ORDINE
	)
	VALUES
	(
		@IdProgrammazione, 
		@CodSanzione, 
		@Attiva, 
		@DataInizio, 
		@OperatoreInizio, 
		@DataFine, 
		@OperatoreFine, 
		@Ordine
	)
	SELECT SCOPE_IDENTITY() AS ID, @Attiva AS ATTIVA


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZprogrammazioneSanzioniInsert';

