CREATE PROCEDURE [dbo].[ZProgettoDelete]
(
	@IdProgetto INT
)
AS
	DELETE PROGETTO
	WHERE 
		(ID_PROGETTO = @IdProgetto)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoDelete]
(
	@IdProgetto INT
)
AS
	DELETE PROGETTO
	WHERE 
		(ID_PROGETTO = @IdProgetto)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoDelete';

