CREATE PROCEDURE [dbo].[ZTestataControlliLocoInsert]
(
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
	SET @DataInserimento = ISNULL(@DataInserimento,(getdate()))
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	SET @DataSopralluogo = ISNULL(@DataSopralluogo,(getdate()))
	INSERT INTO TESTATA_CONTROLLI_LOCO
	(
		DATA_INSERIMENTO, 
		CF_INSERIMENTO, 
		DATA_MODIFICA, 
		CF_MODIFICA, 
		DATA_SOPRALLUOGO, 
		LUOGO_SOPRALLUOGO, 
		ID_ISTANZA_CHECKLIST_GENERICA, 
		IDLOCO_DETTAGLIO, 
		ESITO_TESTATA, 
		ID_FILE_VERBALE, 
		ID_FILE_ATTESTAZIONE, 
		SEGNATURA_TESTATA, 
		DATA_VERBALE, 
		DATA_ATTESTAZIONE, 
		DATA_SEGNATURA, 
		ID_UTENTE_COMPILATORE, 
		ID_UTENTE_VALIDATORE
	)
	VALUES
	(
		@DataInserimento, 
		@CfInserimento, 
		@DataModifica, 
		@CfModifica, 
		@DataSopralluogo, 
		@LuogoSopralluogo, 
		@IdIstanzaChecklistGenerica, 
		@IdlocoDettaglio, 
		@EsitoTestata, 
		@IdFileVerbale, 
		@IdFileAttestazione, 
		@SegnaturaTestata, 
		@DataVerbale, 
		@DataAttestazione, 
		@DataSegnatura, 
		@IdUtenteCompilatore, 
		@IdUtenteValidatore
	)
	SELECT SCOPE_IDENTITY() AS ID_TESTATA, @DataInserimento AS DATA_INSERIMENTO, @DataModifica AS DATA_MODIFICA, @DataSopralluogo AS DATA_SOPRALLUOGO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTestataControlliLocoInsert';

