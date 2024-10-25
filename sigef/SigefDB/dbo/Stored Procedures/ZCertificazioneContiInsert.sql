CREATE PROCEDURE [dbo].[ZCertificazioneContiInsert]
(
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
	INSERT INTO CERTIFICAZIONE_CONTI
	(
		ANNO_CONTABILE_DA, 
		ANNO_CONTABILE_A, 
		DATA_PRESENTAZIONE_CONTI, 
		ISTANZA_CERTIFICAZIONE_CONTI, 
		CF_OPERATORE, 
		FLAG_DEFINITIVO, 
		DATA_INSERIMENTO, 
		DATA_MODIFICA
	)
	VALUES
	(
		@AnnoContabileDa, 
		@AnnoContabileA, 
		@DataPresentazioneConti, 
		@IstanzaCertificazioneConti, 
		@CfOperatore, 
		@FlagDefinitivo, 
		GETDATE(), 
		@DataModifica
	)
	SELECT SCOPE_IDENTITY() AS ID_CERTIFICAZIONE_CONTI

