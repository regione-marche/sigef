CREATE PROCEDURE [dbo].[ZIgrueLogErroriGetById]
(
	@IdIgrueLogErrori INT
)
AS
	SELECT *
	FROM VIGRUE_LOG_ERRORI
	WHERE 
		(ID_IGRUE_LOG_ERRORI = @IdIgrueLogErrori)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIgrueLogErroriGetById';

