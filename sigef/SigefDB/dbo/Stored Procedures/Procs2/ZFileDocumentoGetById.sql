CREATE PROCEDURE [dbo].[ZFileDocumentoGetById]
(
	@IdFile INT
)
AS
	SELECT *
	FROM FILE_DOCUMENTO
	WHERE 
		(ID_FILE = @IdFile)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZFileDocumentoGetById]
(
	@IdFile INT
)
AS
	SELECT *
	FROM FILE_DOCUMENTO
	WHERE 
		(ID_FILE = @IdFile)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZFileDocumentoGetById';

