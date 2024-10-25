CREATE PROCEDURE [dbo].[ZArchivioFileInsert]
(
	@Tipo VARCHAR(255), 
	@NomeFile VARCHAR(255), 
	@NomeCompleto VARCHAR(510), 
	@Contenuto VARBINARY(max), 
	@Dimensione INT, 
	@HashCode VARCHAR(255)
)
AS
	INSERT INTO ARCHIVIO_FILE
	(
		TIPO, 
		NOME_FILE, 
		NOME_COMPLETO, 
		CONTENUTO, 
		DIMENSIONE, 
		HASH_CODE
	)
	VALUES
	(
		@Tipo, 
		@NomeFile, 
		@NomeCompleto, 
		@Contenuto, 
		@Dimensione, 
		@HashCode
	)
	SELECT SCOPE_IDENTITY() AS ID

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'
CREATE PROCEDURE [dbo].[ZArchivioFileInsert]
(
	@Tipo VARCHAR(50), 
	@NomeFile VARCHAR(255), 
	@NomeCompleto VARCHAR(510), 
	@Contenuto VARBINARY(MAX), 
	@Dimensione INT
)
AS
	INSERT INTO ARCHIVIO_FILE
	(
		TIPO, 
		NOME_FILE, 
		NOME_COMPLETO, 
		CONTENUTO, 
		DIMENSIONE
	)
	VALUES
	(
		@Tipo, 
		@NomeFile, 
		@NomeCompleto, 
		@Contenuto, 
		@Dimensione
	)
	SELECT SCOPE_IDENTITY() AS ID


', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZArchivioFileInsert';

