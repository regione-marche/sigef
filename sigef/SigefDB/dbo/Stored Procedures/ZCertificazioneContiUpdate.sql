CREATE PROCEDURE [dbo].[ZCertificazioneContiUpdate]
(
	@IdCertificazioneConti INT, 
	@AnnoContabileDa DATETIME, 
	@AnnoContabileA DATETIME, 
	@DataPresentazioneConti DATETIME, 
	@IstanzaCertificazioneConti XML, 
	@CfOperatore VARCHAR(255), 
	@FlagDefinitivo BIT, 
	@DataInserimento DATETIME, 
	@DataModifica DATETIME
)
AS
	SET @DataModifica=getdate()
	UPDATE CERTIFICAZIONE_CONTI
	SET
		ANNO_CONTABILE_DA = @AnnoContabileDa, 
		ANNO_CONTABILE_A = @AnnoContabileA, 
		DATA_PRESENTAZIONE_CONTI = @DataPresentazioneConti, 
		ISTANZA_CERTIFICAZIONE_CONTI = @IstanzaCertificazioneConti, 
		CF_OPERATORE = @CfOperatore, 
		FLAG_DEFINITIVO = @FlagDefinitivo, 
		--DATA_INSERIMENTO = @DataInserimento, 
		DATA_MODIFICA = @DataModifica
	WHERE 
		(ID_CERTIFICAZIONE_CONTI = @IdCertificazioneConti)
	SELECT @DataModifica;
