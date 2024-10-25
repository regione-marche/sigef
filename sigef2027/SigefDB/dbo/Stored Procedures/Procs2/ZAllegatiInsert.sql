CREATE PROCEDURE [dbo].[ZAllegatiInsert]
(
	@Descrizione VARCHAR(1000), 
	@Misura VARCHAR(255), 
	@CodTipo VARCHAR(255), 
	@CodTipoEnteEmettitore VARCHAR(255)
)
AS
	INSERT INTO ALLEGATI
	(
		DESCRIZIONE, 
		MISURA, 
		COD_TIPO, 
		COD_TIPO_ENTE_EMETTITORE
	)
	VALUES
	(
		@Descrizione, 
		@Misura, 
		@CodTipo, 
		@CodTipoEnteEmettitore
	)
	SELECT SCOPE_IDENTITY() AS ID_ALLEGATO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZAllegatiInsert]
(
	@Descrizione VARCHAR(1000), 
	@Misura VARCHAR(255), 
	@CodTipo VARCHAR(255)
)
AS
	INSERT INTO ALLEGATI
	(
		DESCRIZIONE, 
		MISURA, 
		COD_TIPO
	)
	VALUES
	(
		@Descrizione, 
		@Misura, 
		@CodTipo
	)
	SELECT SCOPE_IDENTITY() AS ID_ALLEGATO
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZAllegatiInsert';

