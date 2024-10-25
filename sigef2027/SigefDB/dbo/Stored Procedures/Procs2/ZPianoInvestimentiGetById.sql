CREATE PROCEDURE [dbo].[ZPianoInvestimentiGetById]
(
	@IdInvestimento INT
)
AS
	SELECT *
	FROM vPIANO_INVESTIMENTI
	WHERE 
		(ID_INVESTIMENTO = @IdInvestimento)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZPianoInvestimentiGetById]
(
	@IdInvestimento INT
)
AS
	SELECT *
	FROM vPIANO_INVESTIMENTI
	WHERE 
		(ID_INVESTIMENTO = @IdInvestimento)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPianoInvestimentiGetById';

