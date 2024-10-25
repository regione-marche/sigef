CREATE PROCEDURE [dbo].[ZZprogrammazioneFontiGetById]
(
	@Id INT
)
AS
	SELECT *
	FROM vzPROGRAMMAZIONE_FONTI
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZprogrammazioneFontiGetById';

