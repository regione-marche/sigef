CREATE PROCEDURE [dbo].[ZBandoComunicazioniDelete]
(
	@CodTipo VARCHAR(255), 
	@IdBando INT
)
AS
	DELETE BANDO_COMUNICAZIONI
	WHERE 
		(COD_TIPO = @CodTipo) AND 
		(ID_BANDO = @IdBando)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoComunicazioniDelete';

