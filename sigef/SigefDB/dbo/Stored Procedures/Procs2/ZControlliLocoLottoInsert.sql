CREATE PROCEDURE [dbo].[ZControlliLocoLottoInsert]
(
	@DataCreazione DATETIME, 
	@DataModifica DATETIME, 
	@Operatore VARCHAR(255), 
	@NumeroEstrazioni INT, 
	@ControlloConcluso BIT, 
	@Segnatura VARCHAR(255), 
	@DataEstrazione DATETIME, 
	@IdProgrammazione INT
)
AS
	SET @NumeroEstrazioni = ISNULL(@NumeroEstrazioni,((0)))
	SET @ControlloConcluso = ISNULL(@ControlloConcluso,((0)))
	INSERT INTO CONTROLLI_LOCO_LOTTO
	(
		DATA_CREAZIONE, 
		DATA_MODIFICA, 
		OPERATORE, 
		NUMERO_ESTRAZIONI, 
		CONTROLLO_CONCLUSO, 
		SEGNATURA, 
		DATA_ESTRAZIONE, 
		ID_PROGRAMMAZIONE
	)
	VALUES
	(
		@DataCreazione, 
		@DataModifica, 
		@Operatore, 
		@NumeroEstrazioni, 
		@ControlloConcluso, 
		@Segnatura, 
		@DataEstrazione, 
		@IdProgrammazione
	)
	SELECT SCOPE_IDENTITY() AS ID_LOTTO, @NumeroEstrazioni AS NUMERO_ESTRAZIONI, @ControlloConcluso AS CONTROLLO_CONCLUSO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZControlliLocoLottoInsert]
(
	@DataCreazione DATETIME, 
	@DataModifica DATETIME, 
	@Operatore VARCHAR(255), 
	@NumeroEstrazioni INT, 
	@ControlloConcluso BIT, 
	@Segnatura VARCHAR(255), 
	@DataEstrazione DATETIME, 
	@IdProgrammazione INT
)
AS
	SET @NumeroEstrazioni = ISNULL(@NumeroEstrazioni,((0)))
	SET @ControlloConcluso = ISNULL(@ControlloConcluso,((0)))
	INSERT INTO CONTROLLI_LOCO_LOTTO
	(
		DATA_CREAZIONE, 
		DATA_MODIFICA, 
		OPERATORE, 
		NUMERO_ESTRAZIONI, 
		CONTROLLO_CONCLUSO, 
		SEGNATURA, 
		DATA_ESTRAZIONE, 
		ID_PROGRAMMAZIONE
	)
	VALUES
	(
		@DataCreazione, 
		@DataModifica, 
		@Operatore, 
		@NumeroEstrazioni, 
		@ControlloConcluso, 
		@Segnatura, 
		@DataEstrazione, 
		@IdProgrammazione
	)
	SELECT SCOPE_IDENTITY() AS ID_LOTTO, @NumeroEstrazioni AS NUMERO_ESTRAZIONI, @ControlloConcluso AS CONTROLLO_CONCLUSO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZControlliLocoLottoInsert';

