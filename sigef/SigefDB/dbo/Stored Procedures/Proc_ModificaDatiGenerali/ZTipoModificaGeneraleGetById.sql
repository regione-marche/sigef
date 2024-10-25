CREATE PROCEDURE [dbo].[ZTipoModificaGeneraleGetById]
(
	@IdTipoModifica INT
)
AS
	SELECT *
	FROM VTIPO_MODIFICA_GENERALE
	WHERE 
		(ID_TIPO_MODIFICA = @IdTipoModifica)

GO