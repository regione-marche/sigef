CREATE PROCEDURE [dbo].[ZTipoRataDelete]
(
	@IdTipoRata INT
)
AS
	DELETE TIPO_RATA
	WHERE 
		(ID_TIPO_RATA = @IdTipoRata)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTipoRataDelete';

