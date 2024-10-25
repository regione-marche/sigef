CREATE PROCEDURE [dbo].[ZTipoIrregolaritaDelete]
(
	@IdTipo INT
)
AS
	DELETE TIPO_IRREGOLARITA
	WHERE 
		(ID_TIPO = @IdTipo)

GO