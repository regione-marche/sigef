CREATE PROCEDURE [dbo].[ZPrioritaXInvestimentiDelete]
(
	@IdPriorita INT, 
	@IdInvestimento INT
)
AS
	DELETE PRIORITA_X_INVESTIMENTI
	WHERE 
		(ID_PRIORITA = @IdPriorita) AND 
		(ID_INVESTIMENTO = @IdInvestimento)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZPrioritaXInvestimentiDelete]
(
	@IdPriorita INT, 
	@IdInvestimento INT
)
AS
	DELETE PRIORITA_X_INVESTIMENTI
	WHERE 
		(ID_PRIORITA = @IdPriorita) AND 
		(ID_INVESTIMENTO = @IdInvestimento)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPrioritaXInvestimentiDelete';

