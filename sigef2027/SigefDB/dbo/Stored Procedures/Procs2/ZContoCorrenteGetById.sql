CREATE PROCEDURE [dbo].[ZContoCorrenteGetById]
(
	@IdContoCorrente INT
)
AS
	SELECT *
	FROM vCONTO_CORRENTE
	WHERE 
		(ID_CONTO_CORRENTE = @IdContoCorrente)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZContoCorrenteGetById]
(
	@IdContoCorrente INT
)
AS
	SELECT *
	FROM vCONTO_CORRENTE
	WHERE 
		(ID_CONTO_CORRENTE = @IdContoCorrente)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZContoCorrenteGetById';

