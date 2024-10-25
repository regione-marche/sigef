CREATE PROCEDURE [dbo].[ZZpsrAlberoUpdate]
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
	UPDATE zPSR_ALBERO
	SET
		COD_PSR = @CodPsr, 
		DESCRIZIONE = @Descrizione, 
		LIVELLO = @Livello, 
		ATTIVAZIONE_BANDI = @AttivazioneBandi, 
		ATTIVAZIONE_FA = @AttivazioneFa, 
		ATTIVAZIONE_OB_MISURA = @AttivazioneObMisura, 
		ATTIVAZIONE_INVESTIMENTI = @AttivazioneInvestimenti, 
		ATTIVAZIONE_FF = @AttivazioneFf
	WHERE 
		(CODICE = @Codice)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZZpsrAlberoUpdate]
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
	UPDATE zPSR_ALBERO
	SET
		COD_PSR = @CodPsr, 
		DESCRIZIONE = @Descrizione, 
		LIVELLO = @Livello, 
		ATTIVAZIONE_BANDI = @AttivazioneBandi, 
		ATTIVAZIONE_FA = @AttivazioneFa, 
		ATTIVAZIONE_OB_MISURA = @AttivazioneObMisura
	WHERE 
		(CODICE = @Codice)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZpsrAlberoUpdate';

