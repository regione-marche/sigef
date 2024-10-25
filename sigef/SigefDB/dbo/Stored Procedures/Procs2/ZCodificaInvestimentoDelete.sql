CREATE PROCEDURE [dbo].[ZCodificaInvestimentoDelete]
(
	@IdCodificaInvestimento INT
)
AS
	DELETE CODIFICA_INVESTIMENTO
	WHERE 
		(ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimento)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZCodificaInvestimentoDelete]
(
	@IdCodificaInvestimento INT
)
AS
	DELETE CODIFICA_INVESTIMENTO
	WHERE 
		(ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimento)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCodificaInvestimentoDelete';

