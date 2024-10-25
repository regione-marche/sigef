CREATE PROCEDURE [dbo].[ZBandoValidatoriUpdate]
(
	@Id INT, 
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
	UPDATE BANDO_VALIDATORI
	SET
		ID_BANDO = @IdBando, 
		ID_UTENTE = @IdUtente, 
		RESPONSABILE = @Responsabile, 
		ATTIVO = @Attivo, 
		DATA_INIZIO = @DataInizio, 
		OPERATORE_INIZIO = @OperatoreInizio, 
		DATA_FINE = @DataFine, 
		OPERATORE_FINE = @OperatoreFine
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoValidatoriUpdate';

