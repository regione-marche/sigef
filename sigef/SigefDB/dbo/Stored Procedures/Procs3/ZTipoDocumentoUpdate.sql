CREATE PROCEDURE [dbo].[ZTipoDocumentoUpdate]
(
	@Codice VARCHAR(255), 
	@Formato VARCHAR(255), 
	@Descrizione VARCHAR(255), 
	@Attivo BIT
)
AS
	UPDATE TIPO_DOCUMENTO
	SET
		FORMATO = @Formato, 
		DESCRIZIONE = @Descrizione, 
		ATTIVO = @Attivo
	WHERE 
		(CODICE = @Codice)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTipoDocumentoUpdate';

