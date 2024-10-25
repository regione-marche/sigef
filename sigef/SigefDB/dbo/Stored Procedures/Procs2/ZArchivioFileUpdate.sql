CREATE PROCEDURE [dbo].[ZArchivioFileUpdate]
(
	@Id INT, 
	@Tipo VARCHAR(255), 
	@NomeFile VARCHAR(255), 
	@NomeCompleto VARCHAR(510), 
	@Contenuto VARBINARY(max), 
	@Dimensione INT, 
	@HashCode VARCHAR(255)
)
AS
	UPDATE ARCHIVIO_FILE
	SET
		TIPO = @Tipo, 
		NOME_FILE = @NomeFile, 
		NOME_COMPLETO = @NomeCompleto, 
		CONTENUTO = @Contenuto, 
		DIMENSIONE = @Dimensione, 
		HASH_CODE = @HashCode
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'
CREATE PROCEDURE [dbo].[ZArchivioFileUpdate]
(
	@Id INT, 
	@Tipo VARCHAR(50), 
	@NomeFile VARCHAR(255), 
	@NomeCompleto VARCHAR(510), 
	@Contenuto VARBINARY(MAX), 
	@Dimensione INT
)
AS
	UPDATE ARCHIVIO_FILE
	SET
		TIPO = @Tipo, 
		NOME_FILE = @NomeFile, 
		NOME_COMPLETO = @NomeCompleto, 
		CONTENUTO = @Contenuto, 
		DIMENSIONE = @Dimensione
	WHERE 
		(ID = @Id)


', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZArchivioFileUpdate';

