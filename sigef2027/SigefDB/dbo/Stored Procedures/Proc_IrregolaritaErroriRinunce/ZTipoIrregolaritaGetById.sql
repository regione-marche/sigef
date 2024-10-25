CREATE PROCEDURE [dbo].[ZTipoIrregolaritaGetById]
(
	@IdTipo INT
)
AS
	SELECT *
	FROM VTIPO_IRREGOLARITA
	WHERE 
		(ID_TIPO = @IdTipo)

GO