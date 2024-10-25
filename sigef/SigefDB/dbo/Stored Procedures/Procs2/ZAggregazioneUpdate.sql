CREATE PROCEDURE [dbo].[ZAggregazioneUpdate]
(
	@Id INT, 
	@Denominazione VARCHAR(2000), 
	@CodTipoAggregazione VARCHAR(255), 
	@DataInizio DATETIME, 
	@Attivo BIT, 
	@DataFine DATETIME, 
	@OperatoreInizio INT, 
	@OperatoreFine INT
)
AS
	UPDATE AGGREGAZIONE
	SET
		DENOMINAZIONE = @Denominazione, 
		COD_TIPO_AGGREGAZIONE = @CodTipoAggregazione, 
		DATA_INIZIO = @DataInizio, 
		ATTIVO = @Attivo, 
		DATA_FINE = @DataFine, 
		OPERATORE_INIZIO = @OperatoreInizio, 
		OPERATORE_FINE = @OperatoreFine
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZAggregazioneUpdate';

