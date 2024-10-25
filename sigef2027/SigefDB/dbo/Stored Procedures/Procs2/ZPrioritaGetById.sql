CREATE PROCEDURE [dbo].[ZPrioritaGetById]
(
	@IdPriorita INT
)
AS
	SELECT *
	FROM PRIORITA
	WHERE 
		(ID_PRIORITA = @IdPriorita)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZPrioritaGetById]
(
	@IdPriorita INT
)
AS
	SELECT *
	FROM PRIORITA
	WHERE 
		(ID_PRIORITA = @IdPriorita)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPrioritaGetById';

