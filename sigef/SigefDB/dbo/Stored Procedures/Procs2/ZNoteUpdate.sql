CREATE PROCEDURE [dbo].[ZNoteUpdate]
(
	@Id INT, 
	@Testo NVARCHAR(MAX)
)
AS
	UPDATE NOTE
	SET
		TESTO = @Testo
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZNoteUpdate]
(
	@Id INT, 
	@Testo NVARCHAR
)
AS
	UPDATE NOTE
	SET
		TESTO = @Testo
	WHERE 
		(ID = @Id)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZNoteUpdate';

