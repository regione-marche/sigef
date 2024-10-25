CREATE PROCEDURE [dbo].[ZLottoDiRevisioneUpdate]
(
	@IdLotto INT, 
	@IdBando INT, 
	@Provincia VARCHAR(255), 
	@DataCreazione DATETIME, 
	@CfOperatore VARCHAR(255), 
	@DataModifica DATETIME, 
	@NumeroEstrazioni INT, 
	@RevisioneConclusa BIT
)
AS
	SET @DataModifica=getdate()
	UPDATE LOTTO_DI_REVISIONE
	SET
		ID_BANDO = @IdBando, 
		PROVINCIA = @Provincia, 
		DATA_CREAZIONE = @DataCreazione, 
		CF_OPERATORE = @CfOperatore, 
		DATA_MODIFICA = @DataModifica, 
		NUMERO_ESTRAZIONI = @NumeroEstrazioni, 
		REVISIONE_CONCLUSA = @RevisioneConclusa
	WHERE 
		(ID_LOTTO = @IdLotto)
	SELECT @DataModifica;

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZLottoDiRevisioneUpdate]
(
	@IdLotto INT, 
	@IdBando INT, 
	@Provincia CHAR(2), 
	@DataCreazione DATETIME, 
	@CfOperatore VARCHAR(16), 
	@DataModifica DATETIME, 
	@NumeroEstrazioni INT, 
	@RevisioneConclusa BIT
)
AS
	SET @DataModifica=getdate()
	UPDATE LOTTO_DI_REVISIONE
	SET
		ID_BANDO = @IdBando, 
		PROVINCIA = @Provincia, 
		DATA_CREAZIONE = @DataCreazione, 
		CF_OPERATORE = @CfOperatore, 
		DATA_MODIFICA = @DataModifica, 
		NUMERO_ESTRAZIONI = @NumeroEstrazioni, 
		REVISIONE_CONCLUSA = @RevisioneConclusa
	WHERE 
		(ID_LOTTO = @IdLotto)
	SELECT @DataModifica;

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZLottoDiRevisioneUpdate';

