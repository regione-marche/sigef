CREATE PROCEDURE [dbo].[ZSanzioniRecuperoUpdate]
(
	@IdSanzioneRecupero INT, 
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
	SET @DataModifica=getdate()
	UPDATE SANZIONI_RECUPERO
	SET
		DATA_INSERIMENTO = @DataInserimento, 
		CF_INSERIMENTO = @CfInserimento, 
		DATA_MODIFICA = @DataModifica, 
		CF_MODIFICA = @CfModifica, 
		ID_REGISTRO_RECUPERO = @IdRegistroRecupero, 
		ID_CATEGORIA_SANZIONE = @IdCategoriaSanzione, 
		ID_TIPO_SANZIONE = @IdTipoSanzione, 
		IMPORTO_SANZIONE = @ImportoSanzione, 
		DATA_CONCLUSIONE = @DataConclusione, 
		ID_STATO_SANZIONE = @IdStatoSanzione
	WHERE 
		(ID_SANZIONE_RECUPERO = @IdSanzioneRecupero)
	SELECT @DataModifica;


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSanzioniRecuperoUpdate';

