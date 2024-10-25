CREATE PROCEDURE [dbo].[ZManifestazioneEsitiStepInsert]
(
	@IdManifestazione INT, 
	@IdStep INT, 
	@CodEsito CHAR(2), 
	@Data DATETIME, 
	@CfOperatore VARCHAR(16), 
	@Note NTEXT
)
AS
	INSERT INTO MANIFESTAZIONE_ESITI_STEP
	(
		ID_MANIFESTAZIONE, 
		ID_STEP, 
		COD_ESITO, 
		DATA, 
		CF_OPERATORE, 
		NOTE
	)
	VALUES
	(
		@IdManifestazione, 
		@IdStep, 
		@CodEsito, 
		@Data, 
		@CfOperatore, 
		@Note
	)
