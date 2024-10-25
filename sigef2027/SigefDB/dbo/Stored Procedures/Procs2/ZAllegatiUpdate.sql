CREATE PROCEDURE [dbo].[ZAllegatiUpdate]
(
	@IdAllegato INT, 
	@Descrizione VARCHAR(1000), 
	@Misura VARCHAR(255), 
	@CodTipo VARCHAR(255), 
	@CodTipoEnteEmettitore VARCHAR(255)
)
AS
	UPDATE ALLEGATI
	SET
		DESCRIZIONE = @Descrizione, 
		MISURA = @Misura, 
		COD_TIPO = @CodTipo, 
		COD_TIPO_ENTE_EMETTITORE = @CodTipoEnteEmettitore
	WHERE 
		(ID_ALLEGATO = @IdAllegato)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZAllegatiUpdate]
(
	@IdAllegato INT, 
	@Descrizione VARCHAR(1000), 
	@Misura VARCHAR(255), 
	@CodTipo VARCHAR(255)
)
AS
	UPDATE ALLEGATI
	SET
		DESCRIZIONE = @Descrizione, 
		MISURA = @Misura, 
		COD_TIPO = @CodTipo
	WHERE 
		(ID_ALLEGATO = @IdAllegato)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZAllegatiUpdate';

