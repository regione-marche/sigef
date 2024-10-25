CREATE PROCEDURE [dbo].[ZTipoModificaGeneraleInsert]
(
	@Descrizione VARCHAR(max), 
	@Attivo BIT
)
AS
	SET @Attivo = ISNULL(@Attivo,((1)))
	INSERT INTO TIPO_MODIFICA_GENERALE
	(
		DESCRIZIONE, 
		ATTIVO
	)
	VALUES
	(
		@Descrizione, 
		@Attivo
	)
	SELECT SCOPE_IDENTITY() AS ID_TIPO_MODIFICA, @Attivo AS ATTIVO

GO