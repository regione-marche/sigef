CREATE PROCEDURE [dbo].[ZTipoComunicazioneInsert]
(
	@CodTipo VARCHAR(255), 
	@Descrizione VARCHAR(255), 
	@InEntrata BIT, 
	@InUscita BIT
)
AS
	INSERT INTO TIPO_COMUNICAZIONE
	(
		COD_TIPO, 
		DESCRIZIONE, 
		IN_ENTRATA, 
		IN_USCITA
	)
	VALUES
	(
		@CodTipo, 
		@Descrizione, 
		@InEntrata, 
		@InUscita
	)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTipoComunicazioneInsert';

