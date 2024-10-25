CREATE PROCEDURE [dbo].[ZTipoIntegrazioneDomandaUpdate]
(
	@CodTipo VARCHAR(255), 
	@Descrizione VARCHAR(255)
)
AS
	UPDATE TIPO_INTEGRAZIONE_DOMANDA
	SET
		DESCRIZIONE = @Descrizione
	WHERE 
		(COD_TIPO = @CodTipo)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTipoIntegrazioneDomandaUpdate';

