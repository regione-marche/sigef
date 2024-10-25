CREATE PROCEDURE [dbo].[ZTipoModificaGeneraleUpdate]
(
	@IdTipoModifica INT, 
	@Descrizione VARCHAR(max), 
	@Attivo BIT
)
AS
	UPDATE TIPO_MODIFICA_GENERALE
	SET
		DESCRIZIONE = @Descrizione, 
		ATTIVO = @Attivo
	WHERE 
		(ID_TIPO_MODIFICA = @IdTipoModifica)

GO