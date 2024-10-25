CREATE PROCEDURE [dbo].[ZDocumentiGetById]
(
	@IdDocumento INT
)
AS
	SELECT *
	FROM DOCUMENTI
	WHERE 
		(ID_DOCUMENTO = @IdDocumento)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZDocumentiGetById]
(
	@IdDocumento INT
)
AS
	SELECT *
	FROM DOCUMENTI
	WHERE 
		(ID_DOCUMENTO = @IdDocumento)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDocumentiGetById';

