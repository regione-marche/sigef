CREATE PROCEDURE [dbo].[ZTipoIntegrazioneDomandaInsert]
(
	@CodTipo VARCHAR(255), 
	@Descrizione VARCHAR(255)
)
AS
	INSERT INTO TIPO_INTEGRAZIONE_DOMANDA
	(
		COD_TIPO, 
		DESCRIZIONE
	)
	VALUES
	(
		@CodTipo, 
		@Descrizione
	)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTipoIntegrazioneDomandaInsert';

