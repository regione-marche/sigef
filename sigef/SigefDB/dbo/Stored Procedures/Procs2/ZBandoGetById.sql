CREATE PROCEDURE [dbo].[ZBandoGetById]
(
	@IdBando INT
)
AS
	SELECT *
	FROM vBANDO
	WHERE 
		(ID_BANDO = @IdBando)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZBandoGetById]
(
	@IdBando INT
)
AS
	SELECT *
	FROM vBANDO
	WHERE 
		(ID_BANDO = @IdBando)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoGetById';

