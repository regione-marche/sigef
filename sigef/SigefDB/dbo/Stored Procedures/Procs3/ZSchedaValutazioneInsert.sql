CREATE PROCEDURE [dbo].[ZSchedaValutazioneInsert]
(
	@Descrizione VARCHAR(255), 
	@FlagTemplate BIT, 
	@ValoreMax DECIMAL(10,2), 
	@ValoreMin DECIMAL(10,2), 
	@ParoleChiave VARCHAR(50), 
	@DataModifica DATETIME
)
AS
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	INSERT INTO SCHEDA_VALUTAZIONE
	(
		DESCRIZIONE, 
		FLAG_TEMPLATE, 
		VALORE_MAX, 
		VALORE_MIN, 
		PAROLE_CHIAVE, 
		DATA_MODIFICA
	)
	VALUES
	(
		@Descrizione, 
		@FlagTemplate, 
		@ValoreMax, 
		@ValoreMin, 
		@ParoleChiave, 
		@DataModifica
	)
	SELECT SCOPE_IDENTITY() AS ID_SCHEDA_VALUTAZIONE, @DataModifica AS DATA_MODIFICA

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZSchedaValutazioneInsert]
(
	@Descrizione VARCHAR(255), 
	@FlagTemplate BIT, 
	@ValoreMax DECIMAL(10,2), 
	@ValoreMin DECIMAL(10,2), 
	@ParoleChiave VARCHAR(50), 
	@DataModifica DATETIME
)
AS
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	INSERT INTO SCHEDA_VALUTAZIONE
	(
		DESCRIZIONE, 
		FLAG_TEMPLATE, 
		VALORE_MAX, 
		VALORE_MIN, 
		PAROLE_CHIAVE, 
		DATA_MODIFICA
	)
	VALUES
	(
		@Descrizione, 
		@FlagTemplate, 
		@ValoreMax, 
		@ValoreMin, 
		@ParoleChiave, 
		@DataModifica
	)
	SELECT SCOPE_IDENTITY() AS ID_SCHEDA_VALUTAZIONE, @DataModifica AS DATA_MODIFICA

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSchedaValutazioneInsert';

