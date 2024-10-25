CREATE PROCEDURE [dbo].[ZZprogrammazioneFontiUpdate]
(
	@Id INT, 
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
	UPDATE zPROGRAMMAZIONE_FONTI
	SET
		ID_PROGRAMMAZIONE = @IdProgrammazione, 
		ID_FONTE = @IdFonte, 
		PERCENTUALE = @Percentuale, 
		DATA_INIZIO = @DataInizio, 
		OPERATORE_INIZIO = @OperatoreInizio, 
		DATA_FINE = @DataFine, 
		OPERATORE_FINE = @OperatoreFine, 
		ATTIVA = @Attiva
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZprogrammazioneFontiUpdate';

