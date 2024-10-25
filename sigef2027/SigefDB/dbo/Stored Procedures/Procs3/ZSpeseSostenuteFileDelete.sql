CREATE PROCEDURE [dbo].[ZSpeseSostenuteFileDelete]
(
	@IdFileSpeseSostenute INT
)
AS
	DELETE SPESE_SOSTENUTE_FILE
	WHERE 
		(ID_FILE_SPESE_SOSTENUTE = @IdFileSpeseSostenute)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSpeseSostenuteFileDelete';

