CREATE PROCEDURE [dbo].[ZTipoComunicazioneGetById]
(
	@CodTipo VARCHAR(255)
)
AS
	SELECT *
	FROM TIPO_COMUNICAZIONE
	WHERE 
		(COD_TIPO = @CodTipo)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTipoComunicazioneGetById';

