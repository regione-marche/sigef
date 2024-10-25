CREATE PROCEDURE [dbo].[ZZprogrammazioneSanzioniUpdate]
(
	@Id INT, 
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
	UPDATE zPROGRAMMAZIONE_SANZIONI
	SET
		ID_PROGRAMMAZIONE = @IdProgrammazione, 
		COD_SANZIONE = @CodSanzione, 
		ATTIVA = @Attiva, 
		DATA_INIZIO = @DataInizio, 
		OPERATORE_INIZIO = @OperatoreInizio, 
		DATA_FINE = @DataFine, 
		OPERATORE_FINE = @OperatoreFine, 
		ORDINE = @Ordine
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZprogrammazioneSanzioniUpdate';

