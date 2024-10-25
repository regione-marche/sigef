CREATE PROCEDURE [dbo].[ZZpsrAlberoInsert]
(
	@Codice VARCHAR(255), 
	@CodPsr VARCHAR(255), 
	@Descrizione VARCHAR(255), 
	@Livello INT, 
	@AttivazioneBandi BIT, 
	@AttivazioneFa BIT, 
	@AttivazioneObMisura BIT, 
	@AttivazioneInvestimenti BIT, 
	@AttivazioneFf BIT
)
AS
	SET @AttivazioneBandi = ISNULL(@AttivazioneBandi,((0)))
	SET @AttivazioneFa = ISNULL(@AttivazioneFa,((0)))
	SET @AttivazioneObMisura = ISNULL(@AttivazioneObMisura,((0)))
	SET @AttivazioneInvestimenti = ISNULL(@AttivazioneInvestimenti,((0)))
	SET @AttivazioneFf = ISNULL(@AttivazioneFf,((0)))
	INSERT INTO zPSR_ALBERO
	(
		CODICE, 
		COD_PSR, 
		DESCRIZIONE, 
		LIVELLO, 
		ATTIVAZIONE_BANDI, 
		ATTIVAZIONE_FA, 
		ATTIVAZIONE_OB_MISURA, 
		ATTIVAZIONE_INVESTIMENTI, 
		ATTIVAZIONE_FF
	)
	VALUES
	(
		@Codice, 
		@CodPsr, 
		@Descrizione, 
		@Livello, 
		@AttivazioneBandi, 
		@AttivazioneFa, 
		@AttivazioneObMisura, 
		@AttivazioneInvestimenti, 
		@AttivazioneFf
	)
	SELECT @AttivazioneBandi AS ATTIVAZIONE_BANDI, @AttivazioneFa AS ATTIVAZIONE_FA, @AttivazioneObMisura AS ATTIVAZIONE_OB_MISURA, @AttivazioneInvestimenti AS ATTIVAZIONE_INVESTIMENTI, @AttivazioneFf AS ATTIVAZIONE_FF

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZZpsrAlberoInsert]
(
	@Codice VARCHAR(255), 
	@CodPsr VARCHAR(255), 
	@Descrizione VARCHAR(255), 
	@Livello INT, 
	@AttivazioneBandi BIT, 
	@AttivazioneFa BIT, 
	@AttivazioneObMisura BIT
)
AS
	SET @AttivazioneBandi = ISNULL(@AttivazioneBandi,((0)))
	SET @AttivazioneFa = ISNULL(@AttivazioneFa,((0)))
	SET @AttivazioneObMisura = ISNULL(@AttivazioneObMisura,((0)))
	INSERT INTO zPSR_ALBERO
	(
		CODICE, 
		COD_PSR, 
		DESCRIZIONE, 
		LIVELLO, 
		ATTIVAZIONE_BANDI, 
		ATTIVAZIONE_FA, 
		ATTIVAZIONE_OB_MISURA
	)
	VALUES
	(
		@Codice, 
		@CodPsr, 
		@Descrizione, 
		@Livello, 
		@AttivazioneBandi, 
		@AttivazioneFa, 
		@AttivazioneObMisura
	)
	SELECT @AttivazioneBandi AS ATTIVAZIONE_BANDI, @AttivazioneFa AS ATTIVAZIONE_FA, @AttivazioneObMisura AS ATTIVAZIONE_OB_MISURA

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZpsrAlberoInsert';

