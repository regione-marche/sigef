CREATE PROCEDURE [dbo].[ZZprogrammazioneGetById]
(
	@Id INT
)
AS
	SELECT *
	FROM vzPROGRAMMAZIONE
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZZprogrammazioneGetById]
(
	@Id INT
)
AS
	SELECT *
	FROM vzPROGRAMMAZIONE
	WHERE 
		(ID = @Id)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZprogrammazioneGetById';

