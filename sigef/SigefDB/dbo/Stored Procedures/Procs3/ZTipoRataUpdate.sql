CREATE PROCEDURE [dbo].[ZTipoRataUpdate]
(
	@IdTipoRata INT, 
	@Descrizione VARCHAR(255)
)
AS
	UPDATE TIPO_RATA
	SET
		DESCRIZIONE = @Descrizione
	WHERE 
		(ID_TIPO_RATA = @IdTipoRata)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTipoRataUpdate';

