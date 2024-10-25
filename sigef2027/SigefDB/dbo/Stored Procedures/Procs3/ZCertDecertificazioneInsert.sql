CREATE PROCEDURE [dbo].[ZCertDecertificazioneInsert]
(
	@IdProgetto INT, 
	@IdDomandaPagamento INT, 
	@IdDecertificazione INT, 
	@TipoDecertificazione VARCHAR(255), 
	@ImportoDecertificazioneAmmesso DECIMAL(15,2), 
	@ImportoDecertificazioneConcesso DECIMAL(15,2), 
	@DataConstatazioneAmministrativa DATETIME, 
	@IdCertificazioneSpesa INT, 
	@IdCertificazioneConti INT, 
	@Assegnata BIT, 
	@Definitiva BIT
)
AS
	INSERT INTO CERT_DECERTIFICAZIONE
	(
		ID_PROGETTO, 
		ID_DOMANDA_PAGAMENTO, 
		ID_DECERTIFICAZIONE, 
		TIPO_DECERTIFICAZIONE, 
		IMPORTO_DECERTIFICAZIONE_AMMESSO, 
		IMPORTO_DECERTIFICAZIONE_CONCESSO, 
		DATA_CONSTATAZIONE_AMMINISTRATIVA, 
		ID_CERTIFICAZIONE_SPESA, 
		ID_CERTIFICAZIONE_CONTI, 
		ASSEGNATA, 
		DEFINITIVA
	)
	VALUES
	(
		@IdProgetto, 
		@IdDomandaPagamento, 
		@IdDecertificazione, 
		@TipoDecertificazione, 
		@ImportoDecertificazioneAmmesso, 
		@ImportoDecertificazioneConcesso, 
		@DataConstatazioneAmministrativa, 
		@IdCertificazioneSpesa, 
		@IdCertificazioneConti, 
		@Assegnata, 
		@Definitiva
	)
	SELECT SCOPE_IDENTITY() AS ID_CERT_DECERTIFICAZIONE