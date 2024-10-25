CREATE PROCEDURE [dbo].[ZTipoIrregolaritaUpdate]
(
	@IdTipo INT, 
	@Tipo VARCHAR(max), 
	@Attivo BIT
)
AS
	UPDATE TIPO_IRREGOLARITA
	SET
		TIPO = @Tipo, 
		ATTIVO = @Attivo
	WHERE 
		(ID_TIPO = @IdTipo)

GO