CREATE PROCEDURE [dbo].[ZVariantiXPrioritaDelete]
(
	@IdVariante INT, 
	@IdPriorita INT
)
AS
	DELETE VARIANTI_X_PRIORITA
	WHERE 
		(ID_VARIANTE = @IdVariante) AND 
		(ID_PRIORITA = @IdPriorita)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVariantiXPrioritaDelete';

