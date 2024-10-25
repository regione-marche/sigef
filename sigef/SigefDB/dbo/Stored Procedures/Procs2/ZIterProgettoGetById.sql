CREATE PROCEDURE [dbo].[ZIterProgettoGetById]
(
	@IdProgetto INT, 
	@IdStep INT
)
AS
	SELECT *
	FROM vITER_PROGETTO
	WHERE 
		(ID_PROGETTO = @IdProgetto) AND 
		(ID_STEP = @IdStep)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZIterProgettoGetById]
(
	@IdProgetto INT, 
	@IdStep INT
)
AS
	SELECT *
	FROM vITER_PROGETTO
	WHERE 
		(ID_PROGETTO = @IdProgetto) AND 
		(ID_STEP = @IdStep)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIterProgettoGetById';

