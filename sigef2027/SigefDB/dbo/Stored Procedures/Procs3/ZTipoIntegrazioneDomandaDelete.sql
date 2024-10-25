CREATE PROCEDURE [dbo].[ZTipoIntegrazioneDomandaDelete]
(
	@CodTipo VARCHAR(255)
)
AS
	DELETE TIPO_INTEGRAZIONE_DOMANDA
	WHERE 
		(COD_TIPO = @CodTipo)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTipoIntegrazioneDomandaDelete';

