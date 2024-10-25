CREATE PROCEDURE [dbo].[ZBandoTipoInvestimentiGetById]
(
	@IdTipoInvestimento INT
)
AS
	SELECT *
	FROM vBANDO_TIPO_INVESTIMENTI
	WHERE 
		(ID_TIPO_INVESTIMENTO = @IdTipoInvestimento)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'

CREATE PROCEDURE [dbo].[ZBandoTipoInvestimentiGetById]
(
	@IdTipoInvestimento INT
)
AS
	SELECT *
	FROM vBANDO_TIPO_INVESTIMENTO
	WHERE 
		(ID_TIPO_INVESTIMENTO = @IdTipoInvestimento)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoTipoInvestimentiGetById';

