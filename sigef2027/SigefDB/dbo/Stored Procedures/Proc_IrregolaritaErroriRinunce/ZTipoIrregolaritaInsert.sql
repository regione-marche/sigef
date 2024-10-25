CREATE PROCEDURE [dbo].[ZTipoIrregolaritaInsert]
(
	@Tipo VARCHAR(max), 
	@Attivo BIT
)
AS
	SET @Attivo = ISNULL(@Attivo,((1)))
	INSERT INTO TIPO_IRREGOLARITA
	(
		TIPO, 
		ATTIVO
	)
	VALUES
	(
		@Tipo, 
		@Attivo
	)
	SELECT SCOPE_IDENTITY() AS ID_TIPO, @Attivo AS ATTIVO

GO