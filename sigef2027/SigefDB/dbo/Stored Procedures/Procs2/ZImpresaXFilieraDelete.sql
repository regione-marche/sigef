CREATE PROCEDURE [dbo].[ZImpresaXFilieraDelete]
(
	@IdImpresaXFiliera INT
)
AS
	DELETE IMPRESA_X_FILIERA
	WHERE 
		(ID_IMPRESA_X_FILIERA = @IdImpresaXFiliera)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZImpresaXFilieraDelete]
(
	@IdImpresaXFiliera INT
)
AS
	DELETE IMPRESA_X_FILIERA
	WHERE 
		(ID_IMPRESA_X_FILIERA = @IdImpresaXFiliera)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZImpresaXFilieraDelete';

