CREATE PROCEDURE [dbo].[ZProgettoGetById]
(
	@IdProgetto INT
)
AS
	SELECT *
	FROM vPROGETTO
	WHERE 
		(ID_PROGETTO = @IdProgetto)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoGetById]
(
	@IdProgetto INT
)
AS
	SELECT *
	FROM vPROGETTO
	WHERE 
		(ID_PROGETTO = @IdProgetto)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoGetById';

