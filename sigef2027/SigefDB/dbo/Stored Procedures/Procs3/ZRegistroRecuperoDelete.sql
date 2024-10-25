CREATE PROCEDURE [dbo].[ZRegistroRecuperoDelete]
(
	@IdRegistroRecupero INT
)
AS
	DELETE REGISTRO_RECUPERO
	WHERE 
		(ID_REGISTRO_RECUPERO = @IdRegistroRecupero)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZRegistroRecuperoDelete]
(
	@IdRegistroRecupero INT
)
AS
	DELETE REGISTRO_RECUPERO
	WHERE 
		(ID_REGISTRO_RECUPERO = @IdRegistroRecupero)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRegistroRecuperoDelete';

