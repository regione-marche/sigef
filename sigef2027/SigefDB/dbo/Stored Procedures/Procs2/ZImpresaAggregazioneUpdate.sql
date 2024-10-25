CREATE PROCEDURE [dbo].[ZImpresaAggregazioneUpdate]
(
	@Id INT, 
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
	UPDATE IMPRESA_AGGREGAZIONE
	SET
		ID_AGGREGAZIONE = @IdAggregazione, 
		COD_RUOLO = @CodRuolo, 
		ID_IMPRESA = @IdImpresa, 
		PERCENTUALE = @Percentuale, 
		DATA_INIZIO = @DataInizio, 
		OPERATORE_INIZIO = @OperatoreInizio, 
		ATTIVO = @Attivo, 
		DATA_FINE = @DataFine, 
		OPERATORE_FINE = @OperatoreFine
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZImpresaAggregazioneUpdate]
(
	@Id INT, 
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
	UPDATE IMPRESA_AGGREGAZIONE
	SET
		ID_AGGREGAZIONE = @IdAggregazione, 
		COD_RUOLO = @CodRuolo, 
		ID_IMPRESA = @IdImpresa, 
		PERCENTUALE = @Percentuale, 
		DATA_INIZIO = @DataInizio, 
		OPERATORE_INIZIO = @OperatoreInizio, 
		ATTIVO = @Attivo, 
		DATA_FINE = @DataFine, 
		OPERATORE_FINE = @OperatoreFine
	WHERE 
		(ID = @Id)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZImpresaAggregazioneUpdate';

