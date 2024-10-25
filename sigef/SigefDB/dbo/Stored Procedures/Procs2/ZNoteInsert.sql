CREATE PROCEDURE [dbo].[ZNoteInsert]
(
	@Testo NVARCHAR(MAX)
)
AS
	INSERT INTO NOTE
	(
		TESTO
	)
	VALUES
	(
		@Testo
	)
	SELECT SCOPE_IDENTITY() AS ID

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZNoteInsert]
(
	@Testo NVARCHAR
)
AS
	INSERT INTO NOTE
	(
		TESTO
	)
	VALUES
	(
		@Testo
	)
	SELECT SCOPE_IDENTITY() AS ID

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZNoteInsert';

