CREATE PROCEDURE [dbo].[ZTipoComunicazioneUpdate]
(
	@CodTipo VARCHAR(255), 
	@Descrizione VARCHAR(255), 
	@InEntrata BIT, 
	@InUscita BIT
)
AS
	UPDATE TIPO_COMUNICAZIONE
	SET
		DESCRIZIONE = @Descrizione, 
		IN_ENTRATA = @InEntrata, 
		IN_USCITA = @InUscita
	WHERE 
		(COD_TIPO = @CodTipo)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTipoComunicazioneUpdate';

