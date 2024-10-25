CREATE PROCEDURE [dbo].[ZPrioritaXProgettoGetById]
(
	@IdProgetto INT, 
	@IdPriorita INT
)
AS
	SELECT *
	FROM vPRIORITA_X_PROGETTO
	WHERE 
		(ID_PROGETTO = @IdProgetto) AND 
		(ID_PRIORITA = @IdPriorita)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZPrioritaXProgettoGetById]
(
	@IdProgetto INT, 
	@IdPriorita INT
)
AS
	SELECT *
	FROM vPRIORITA_X_PROGETTO
	WHERE 
		(ID_PROGETTO = @IdProgetto) AND 
		(ID_PRIORITA = @IdPriorita)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPrioritaXProgettoGetById';

