CREATE PROCEDURE [dbo].[ZTipoRataGetById]
(
	@IdTipoRata INT
)
AS
	SELECT *
	FROM VTIPO_RATA
	WHERE 
		(ID_TIPO_RATA = @IdTipoRata)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTipoRataGetById';

