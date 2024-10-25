CREATE PROCEDURE [dbo].[ZSanzioniRecuperoInsert]
(
	@DataInserimento DATETIME, 
	@CfInserimento VARCHAR(255), 
	@DataModifica DATETIME, 
	@CfModifica VARCHAR(255), 
	@IdRegistroRecupero INT, 
	@IdCategoriaSanzione INT, 
	@IdTipoSanzione INT, 
	@ImportoSanzione DECIMAL(15,2), 
	@DataConclusione DATETIME, 
	@IdStatoSanzione INT
)
AS
	INSERT INTO SANZIONI_RECUPERO
	(
		DATA_INSERIMENTO, 
		CF_INSERIMENTO, 
		DATA_MODIFICA, 
		CF_MODIFICA, 
		ID_REGISTRO_RECUPERO, 
		ID_CATEGORIA_SANZIONE, 
		ID_TIPO_SANZIONE, 
		IMPORTO_SANZIONE, 
		DATA_CONCLUSIONE, 
		ID_STATO_SANZIONE
	)
	VALUES
	(
		@DataInserimento, 
		@CfInserimento, 
		@DataModifica, 
		@CfModifica, 
		@IdRegistroRecupero, 
		@IdCategoriaSanzione, 
		@IdTipoSanzione, 
		@ImportoSanzione, 
		@DataConclusione, 
		@IdStatoSanzione
	)
	SELECT SCOPE_IDENTITY() AS ID_SANZIONE_RECUPERO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSanzioniRecuperoInsert';

