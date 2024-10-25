CREATE PROCEDURE [dbo].[ZPrioritaXInvestimentiUpdate]
(
	@IdPriorita INT, 
	@IdInvestimento INT, 
	@IdValore INT, 
	@Scelto BIT, 
	@Valore DECIMAL(18,2), 
	@ValData DATETIME, 
	@ValTesto VARCHAR(500)
)
AS
	UPDATE PRIORITA_X_INVESTIMENTI
	SET
		ID_VALORE = @IdValore, 
		SCELTO = @Scelto, 
		VALORE = @Valore, 
		VAL_DATA = @ValData, 
		VAL_TESTO = @ValTesto
	WHERE 
		(ID_PRIORITA = @IdPriorita) AND 
		(ID_INVESTIMENTO = @IdInvestimento)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZPrioritaXInvestimentiUpdate]
(
	@IdPriorita INT, 
	@IdInvestimento INT, 
	@IdValore INT, 
	@Scelto BIT, 
	@Valore DECIMAL(18,2)
)
AS
	UPDATE PRIORITA_X_INVESTIMENTI
	SET
		ID_VALORE = @IdValore, 
		SCELTO = @Scelto, 
		VALORE = @Valore
	WHERE 
		(ID_PRIORITA = @IdPriorita) AND 
		(ID_INVESTIMENTO = @IdInvestimento)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPrioritaXInvestimentiUpdate';

