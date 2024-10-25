CREATE PROCEDURE [dbo].[ZBandoDelete]
(
	@IdBando INT
)
AS
	DELETE BANDO
	WHERE 
		(ID_BANDO = @IdBando)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZBandoDelete]
(
	@IdBando INT
)
AS
	DELETE BANDO
	WHERE 
		(ID_BANDO = @IdBando)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoDelete';

