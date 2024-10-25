CREATE PROCEDURE [dbo].[ZCodificaInvestimentoGetById]
(
	@IdCodificaInvestimento INT
)
AS
	SELECT *
	FROM CODIFICA_INVESTIMENTO
	WHERE 
		(ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimento)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZCodificaInvestimentoGetById]
(
	@IdCodificaInvestimento INT
)
AS
	SELECT *
	FROM CODIFICA_INVESTIMENTO
	WHERE 
		(ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimento)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCodificaInvestimentoGetById';

