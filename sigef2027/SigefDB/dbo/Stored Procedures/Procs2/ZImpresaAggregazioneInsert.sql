CREATE PROCEDURE [dbo].[ZImpresaAggregazioneInsert]
(
	@IdAggregazione INT, 
	@CodRuolo VARCHAR(255), 
	@IdImpresa INT, 
	@Percentuale DECIMAL(10,4), 
	@DataInizio DATETIME, 
	@OperatoreInizio INT, 
	@Attivo BIT, 
	@DataFine DATETIME, 
	@OperatoreFine INT
)
AS
	INSERT INTO IMPRESA_AGGREGAZIONE
	(
		ID_AGGREGAZIONE, 
		COD_RUOLO, 
		ID_IMPRESA, 
		PERCENTUALE, 
		DATA_INIZIO, 
		OPERATORE_INIZIO, 
		ATTIVO, 
		DATA_FINE, 
		OPERATORE_FINE
	)
	VALUES
	(
		@IdAggregazione, 
		@CodRuolo, 
		@IdImpresa, 
		@Percentuale, 
		@DataInizio, 
		@OperatoreInizio, 
		@Attivo, 
		@DataFine, 
		@OperatoreFine
	)
	SELECT SCOPE_IDENTITY() AS ID


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZImpresaAggregazioneInsert]
(
	@IdAggregazione INT, 
	@CodRuolo VARCHAR(255), 
	@IdImpresa INT, 
	@Percentuale DECIMAL(10,4), 
	@DataInizio DATETIME, 
	@OperatoreInizio INT, 
	@Attivo BIT, 
	@DataFine DATETIME, 
	@OperatoreFine INT
)
AS
	INSERT INTO IMPRESA_AGGREGAZIONE
	(
		ID_AGGREGAZIONE, 
		COD_RUOLO, 
		ID_IMPRESA, 
		PERCENTUALE, 
		DATA_INIZIO, 
		OPERATORE_INIZIO, 
		ATTIVO, 
		DATA_FINE, 
		OPERATORE_FINE
	)
	VALUES
	(
		@IdAggregazione, 
		@CodRuolo, 
		@IdImpresa, 
		@Percentuale, 
		@DataInizio, 
		@OperatoreInizio, 
		@Attivo, 
		@DataFine, 
		@OperatoreFine
	)
	SELECT SCOPE_IDENTITY() AS ID

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZImpresaAggregazioneInsert';

