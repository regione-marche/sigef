CREATE PROCEDURE [dbo].[ZControlliLocoLottoUpdate]
(
	@IdLotto INT, 
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
	UPDATE CONTROLLI_LOCO_LOTTO
	SET
		DATA_CREAZIONE = @DataCreazione, 
		DATA_MODIFICA = @DataModifica, 
		OPERATORE = @Operatore, 
		NUMERO_ESTRAZIONI = @NumeroEstrazioni, 
		CONTROLLO_CONCLUSO = @ControlloConcluso, 
		SEGNATURA = @Segnatura, 
		DATA_ESTRAZIONE = @DataEstrazione, 
		ID_PROGRAMMAZIONE = @IdProgrammazione
	WHERE 
		(ID_LOTTO = @IdLotto)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZControlliLocoLottoUpdate]
(
	@IdLotto INT, 
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
	UPDATE CONTROLLI_LOCO_LOTTO
	SET
		DATA_CREAZIONE = @DataCreazione, 
		DATA_MODIFICA = @DataModifica, 
		OPERATORE = @Operatore, 
		NUMERO_ESTRAZIONI = @NumeroEstrazioni, 
		CONTROLLO_CONCLUSO = @ControlloConcluso, 
		SEGNATURA = @Segnatura, 
		DATA_ESTRAZIONE = @DataEstrazione, 
		ID_PROGRAMMAZIONE = @IdProgrammazione
	WHERE 
		(ID_LOTTO = @IdLotto)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZControlliLocoLottoUpdate';

