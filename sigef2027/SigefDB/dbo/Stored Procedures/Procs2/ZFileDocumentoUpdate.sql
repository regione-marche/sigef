CREATE PROCEDURE [dbo].[ZFileDocumentoUpdate]
(
	@IdFile INT, 
	@IdDocumento INT, 
	@Nome VARCHAR(80), 
	@Tipo VARCHAR(10), 
	@SizeFile INT, 
	@Descrizione VARCHAR(100), 
	@IdArchivioFile INT
)
AS
	UPDATE FILE_DOCUMENTO
	SET
		ID_DOCUMENTO = @IdDocumento, 
		NOME = @Nome, 
		TIPO = @Tipo, 
		SIZE_FILE = @SizeFile, 
		DESCRIZIONE = @Descrizione, 
		ID_ARCHIVIO_FILE = @IdArchivioFile
	WHERE 
		(ID_FILE = @IdFile)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZFileDocumentoUpdate]
(
	@IdFile INT, 
	@IdDocumento INT, 
	@Nome VARCHAR(80), 
	@Tipo VARCHAR(10), 
	@SizeFile INT, 
	@Descrizione VARCHAR(100)
)
AS
	UPDATE FILE_DOCUMENTO
	SET
		ID_DOCUMENTO = @IdDocumento, 
		NOME = @Nome, 
		TIPO = @Tipo, 
		SIZE_FILE = @SizeFile, 
		DESCRIZIONE = @Descrizione
	WHERE 
		(ID_FILE = @IdFile)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZFileDocumentoUpdate';

