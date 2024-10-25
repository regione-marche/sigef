CREATE PROCEDURE [dbo].[ZIgrueInvioDelete]
(
	@IdInvio INT
)
AS
	DELETE IGRUE_INVIO
	WHERE 
		(ID_INVIO = @IdInvio)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZIgrueInvioDelete]
(
	@IdInvio INT
)
AS
	DELETE IGRUE_INVIO
	WHERE 
		(ID_INVIO = @IdInvio)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIgrueInvioDelete';

