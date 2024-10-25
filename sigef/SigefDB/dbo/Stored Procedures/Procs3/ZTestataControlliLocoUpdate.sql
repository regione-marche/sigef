CREATE PROCEDURE [dbo].[ZTestataControlliLocoUpdate]
(
	@IdTestata INT, 
	@DataInserimento DATETIME, 
	@CfInserimento VARCHAR(255), 
	@DataModifica DATETIME, 
	@CfModifica VARCHAR(255), 
	@DataSopralluogo DATETIME, 
	@LuogoSopralluogo VARCHAR(3000), 
	@IdIstanzaChecklistGenerica INT, 
	@IdlocoDettaglio INT, 
	@EsitoTestata BIT, 
	@IdFileVerbale INT, 
	@IdFileAttestazione INT, 
	@SegnaturaTestata VARCHAR(1000), 
	@DataVerbale DATETIME, 
	@DataAttestazione DATETIME, 
	@DataSegnatura DATETIME, 
	@IdUtenteCompilatore INT, 
	@IdUtenteValidatore INT
)
AS
	SET @DataModifica=getdate()
	UPDATE TESTATA_CONTROLLI_LOCO
	SET
		DATA_INSERIMENTO = @DataInserimento, 
		CF_INSERIMENTO = @CfInserimento, 
		DATA_MODIFICA = @DataModifica, 
		CF_MODIFICA = @CfModifica, 
		DATA_SOPRALLUOGO = @DataSopralluogo, 
		LUOGO_SOPRALLUOGO = @LuogoSopralluogo, 
		ID_ISTANZA_CHECKLIST_GENERICA = @IdIstanzaChecklistGenerica, 
		IDLOCO_DETTAGLIO = @IdlocoDettaglio, 
		ESITO_TESTATA = @EsitoTestata, 
		ID_FILE_VERBALE = @IdFileVerbale, 
		ID_FILE_ATTESTAZIONE = @IdFileAttestazione, 
		SEGNATURA_TESTATA = @SegnaturaTestata, 
		DATA_VERBALE = @DataVerbale, 
		DATA_ATTESTAZIONE = @DataAttestazione, 
		DATA_SEGNATURA = @DataSegnatura, 
		ID_UTENTE_COMPILATORE = @IdUtenteCompilatore, 
		ID_UTENTE_VALIDATORE = @IdUtenteValidatore
	WHERE 
		(ID_TESTATA = @IdTestata)
	SELECT @DataModifica;


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTestataControlliLocoUpdate';

