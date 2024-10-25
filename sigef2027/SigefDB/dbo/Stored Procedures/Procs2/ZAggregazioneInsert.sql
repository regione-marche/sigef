CREATE PROCEDURE [dbo].[ZAggregazioneInsert]
(
	@Denominazione VARCHAR(2000), 
	@CodTipoAggregazione VARCHAR(255), 
	@DataInizio DATETIME, 
	@Attivo BIT, 
	@DataFine DATETIME, 
	@OperatoreInizio INT, 
	@OperatoreFine INT
)
AS
	INSERT INTO AGGREGAZIONE
	(
		DENOMINAZIONE, 
		COD_TIPO_AGGREGAZIONE, 
		DATA_INIZIO, 
		ATTIVO, 
		DATA_FINE, 
		OPERATORE_INIZIO, 
		OPERATORE_FINE
	)
	VALUES
	(
		@Denominazione, 
		@CodTipoAggregazione, 
		@DataInizio, 
		@Attivo, 
		@DataFine, 
		@OperatoreInizio, 
		@OperatoreFine
	)
	SELECT SCOPE_IDENTITY() AS ID


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZAggregazioneInsert';

