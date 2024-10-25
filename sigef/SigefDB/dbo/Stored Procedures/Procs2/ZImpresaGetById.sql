CREATE PROCEDURE [dbo].[ZImpresaGetById]
(
	@IdImpresa INT
)
AS
	SELECT *
	FROM vIMPRESA
	WHERE 
		(ID_IMPRESA = @IdImpresa)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZImpresaGetById]
(
	@IdImpresa INT
)
AS
	SELECT *
	FROM vIMPRESA
	WHERE 
		(ID_IMPRESA = @IdImpresa)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZImpresaGetById';

