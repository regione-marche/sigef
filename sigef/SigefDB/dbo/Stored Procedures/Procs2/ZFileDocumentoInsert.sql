CREATE PROCEDURE [dbo].[ZFileDocumentoInsert]
(
	@IdDocumento INT, 
	@Nome VARCHAR(80), 
	@Tipo VARCHAR(10), 
	@SizeFile INT, 
	@Descrizione VARCHAR(100), 
	@IdArchivioFile INT
)
AS
	INSERT INTO FILE_DOCUMENTO
	(
		ID_DOCUMENTO, 
		NOME, 
		TIPO, 
		SIZE_FILE, 
		DESCRIZIONE, 
		ID_ARCHIVIO_FILE
	)
	VALUES
	(
		@IdDocumento, 
		@Nome, 
		@Tipo, 
		@SizeFile, 
		@Descrizione, 
		@IdArchivioFile
	)
	SELECT SCOPE_IDENTITY() AS ID_FILE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZFileDocumentoInsert]
(
	@IdDocumento INT, 
	@Nome VARCHAR(80), 
	@Tipo VARCHAR(10), 
	@SizeFile INT, 
	@Descrizione VARCHAR(100)
)
AS
	INSERT INTO FILE_DOCUMENTO
	(
		ID_DOCUMENTO, 
		NOME, 
		TIPO, 
		SIZE_FILE, 
		DESCRIZIONE
	)
	VALUES
	(
		@IdDocumento, 
		@Nome, 
		@Tipo, 
		@SizeFile, 
		@Descrizione
	)
	SELECT SCOPE_IDENTITY() AS ID_FILE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZFileDocumentoInsert';

