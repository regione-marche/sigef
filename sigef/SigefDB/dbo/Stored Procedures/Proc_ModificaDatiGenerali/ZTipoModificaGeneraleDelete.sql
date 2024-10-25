CREATE PROCEDURE [dbo].[ZTipoModificaGeneraleDelete]
(
	@IdTipoModifica INT
)
AS
	DELETE TIPO_MODIFICA_GENERALE
	WHERE 
		(ID_TIPO_MODIFICA = @IdTipoModifica)

GO
