CREATE PROCEDURE [dbo].[ZTipoDocumentoInsert]
(
	@Codice VARCHAR(255), 
	@Formato VARCHAR(255), 
	@Descrizione VARCHAR(255), 
	@Attivo BIT
)
AS
	SET @Attivo = ISNULL(@Attivo,((1)))
	INSERT INTO TIPO_DOCUMENTO
	(
		CODICE, 
		FORMATO, 
		DESCRIZIONE, 
		ATTIVO
	)
	VALUES
	(
		@Codice, 
		@Formato, 
		@Descrizione, 
		@Attivo
	)
	SELECT @Attivo AS ATTIVO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTipoDocumentoInsert';

