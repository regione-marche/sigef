CREATE PROCEDURE [dbo].[ZSchedaValutazioneUpdate]
(
	@IdSchedaValutazione INT, 
	@Descrizione VARCHAR(255), 
	@FlagTemplate BIT, 
	@ValoreMax DECIMAL(10,2), 
	@ValoreMin DECIMAL(10,2), 
	@ParoleChiave VARCHAR(50), 
	@DataModifica DATETIME
)
AS
	SET @DataModifica=getdate()
	UPDATE SCHEDA_VALUTAZIONE
	SET
		DESCRIZIONE = @Descrizione, 
		FLAG_TEMPLATE = @FlagTemplate, 
		VALORE_MAX = @ValoreMax, 
		VALORE_MIN = @ValoreMin, 
		PAROLE_CHIAVE = @ParoleChiave, 
		DATA_MODIFICA = @DataModifica
	WHERE 
		(ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
	SELECT @DataModifica;

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZSchedaValutazioneUpdate]
(
	@IdSchedaValutazione INT, 
	@Descrizione VARCHAR(255), 
	@FlagTemplate BIT, 
	@ValoreMax DECIMAL(10,2), 
	@ValoreMin DECIMAL(10,2), 
	@ParoleChiave VARCHAR(50), 
	@DataModifica DATETIME
)
AS
	SET @DataModifica=getdate()
	UPDATE SCHEDA_VALUTAZIONE
	SET
		DESCRIZIONE = @Descrizione, 
		FLAG_TEMPLATE = @FlagTemplate, 
		VALORE_MAX = @ValoreMax, 
		VALORE_MIN = @ValoreMin, 
		PAROLE_CHIAVE = @ParoleChiave, 
		DATA_MODIFICA = @DataModifica
	WHERE 
		(ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
	SELECT @DataModifica;

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSchedaValutazioneUpdate';

