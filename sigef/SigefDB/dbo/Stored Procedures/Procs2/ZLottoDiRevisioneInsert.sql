CREATE PROCEDURE [dbo].[ZLottoDiRevisioneInsert]
(
	@IdBando INT, 
	@Provincia VARCHAR(255), 
	@DataCreazione DATETIME, 
	@CfOperatore VARCHAR(255), 
	@DataModifica DATETIME, 
	@NumeroEstrazioni INT, 
	@RevisioneConclusa BIT
)
AS
	SET @NumeroEstrazioni = ISNULL(@NumeroEstrazioni,((0)))
	SET @RevisioneConclusa = ISNULL(@RevisioneConclusa,((0)))
	INSERT INTO LOTTO_DI_REVISIONE
	(
		ID_BANDO, 
		PROVINCIA, 
		DATA_CREAZIONE, 
		CF_OPERATORE, 
		DATA_MODIFICA, 
		NUMERO_ESTRAZIONI, 
		REVISIONE_CONCLUSA
	)
	VALUES
	(
		@IdBando, 
		@Provincia, 
		@DataCreazione, 
		@CfOperatore, 
		@DataModifica, 
		@NumeroEstrazioni, 
		@RevisioneConclusa
	)
	SELECT SCOPE_IDENTITY() AS ID_LOTTO, @NumeroEstrazioni AS NUMERO_ESTRAZIONI, @RevisioneConclusa AS REVISIONE_CONCLUSA

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZLottoDiRevisioneInsert]
(
	@IdBando INT, 
	@Provincia CHAR(2), 
	@DataCreazione DATETIME, 
	@CfOperatore VARCHAR(16), 
	@DataModifica DATETIME, 
	@NumeroEstrazioni INT, 
	@RevisioneConclusa BIT
)
AS
	SET @NumeroEstrazioni = ISNULL(@NumeroEstrazioni,((0)))
	SET @RevisioneConclusa = ISNULL(@RevisioneConclusa,((0)))
	INSERT INTO LOTTO_DI_REVISIONE
	(
		ID_BANDO, 
		PROVINCIA, 
		DATA_CREAZIONE, 
		CF_OPERATORE, 
		DATA_MODIFICA, 
		NUMERO_ESTRAZIONI, 
		REVISIONE_CONCLUSA
	)
	VALUES
	(
		@IdBando, 
		@Provincia, 
		@DataCreazione, 
		@CfOperatore, 
		@DataModifica, 
		@NumeroEstrazioni, 
		@RevisioneConclusa
	)
	SELECT SCOPE_IDENTITY() AS ID_LOTTO, @NumeroEstrazioni AS NUMERO_ESTRAZIONI, @RevisioneConclusa AS REVISIONE_CONCLUSA

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZLottoDiRevisioneInsert';

