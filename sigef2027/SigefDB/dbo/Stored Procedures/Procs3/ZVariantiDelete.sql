CREATE PROCEDURE [dbo].[ZVariantiDelete]
(
	@IdVariante INT
)
AS
	DELETE VARIANTI
	WHERE 
		(ID_VARIANTE = @IdVariante)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZVariantiDelete]
(
	@IdVariante INT
)
AS
	DELETE VARIANTI
	WHERE 
		(ID_VARIANTE = @IdVariante)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVariantiDelete';

