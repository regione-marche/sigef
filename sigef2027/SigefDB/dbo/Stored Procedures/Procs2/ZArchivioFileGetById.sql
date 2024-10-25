CREATE PROCEDURE [dbo].[ZArchivioFileGetById]
(
	@Id INT
)
AS
	SELECT *
	FROM ARCHIVIO_FILE
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'
CREATE PROCEDURE [dbo].[ZArchivioFileGetById]
(
	@Id INT
)
AS
	SELECT *
	FROM ARCHIVIO_FILE
	WHERE 
		(ID = @Id)


', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZArchivioFileGetById';

