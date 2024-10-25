CREATE PROCEDURE [dbo].[ZTipoDocumentoDelete]
(
	@Codice VARCHAR(255)
)
AS
	DELETE TIPO_DOCUMENTO
	WHERE 
		(CODICE = @Codice)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTipoDocumentoDelete';

