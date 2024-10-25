CREATE PROCEDURE [dbo].[ZSpeseSostenuteFileGetById]
(
	@IdFileSpeseSostenute INT
)
AS
	SELECT *
	FROM VSPESE_SOSTENUTE_FILE
	WHERE 
		(ID_FILE_SPESE_SOSTENUTE = @IdFileSpeseSostenute)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSpeseSostenuteFileGetById';

