CREATE PROCEDURE [dbo].[ZIgrueInvioGetById]
(
	@IdInvio INT
)
AS
	SELECT *
	FROM VIGRUE_INVIO
	WHERE 
		(ID_INVIO = @IdInvio)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZIgrueInvioGetById]
(
	@IdInvio INT
)
AS
	SELECT *
	FROM VIGRUE_INVIO
	WHERE 
		(ID_INVIO = @IdInvio)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIgrueInvioGetById';

