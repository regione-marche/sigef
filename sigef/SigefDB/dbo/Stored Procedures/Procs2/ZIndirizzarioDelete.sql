CREATE PROCEDURE [dbo].[ZIndirizzarioDelete]
(
	@IdIndirizzario INT
)
AS
	DELETE INDIRIZZARIO
	WHERE 
		(ID_INDIRIZZARIO = @IdIndirizzario)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZIndirizzarioDelete]
(
	@IdIndirizzario INT
)
AS
	DELETE INDIRIZZARIO
	WHERE 
		(ID_INDIRIZZARIO = @IdIndirizzario)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIndirizzarioDelete';

