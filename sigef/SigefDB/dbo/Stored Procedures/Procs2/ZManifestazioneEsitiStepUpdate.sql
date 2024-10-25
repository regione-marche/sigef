CREATE PROCEDURE [dbo].[ZManifestazioneEsitiStepUpdate]
(
	@IdManifestazione INT, 
	@IdStep INT, 
	@CodEsito CHAR(2), 
	@Data DATETIME, 
	@CfOperatore VARCHAR(16), 
	@Note NTEXT
)
AS
	UPDATE MANIFESTAZIONE_ESITI_STEP
	SET
		COD_ESITO = @CodEsito, 
		DATA = @Data, 
		CF_OPERATORE = @CfOperatore, 
		NOTE = @Note
	WHERE 
		(ID_MANIFESTAZIONE = @IdManifestazione) AND 
		(ID_STEP = @IdStep)
