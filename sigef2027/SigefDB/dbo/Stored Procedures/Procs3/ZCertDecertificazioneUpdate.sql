CREATE PROCEDURE [dbo].[ZCertDecertificazioneUpdate]
(
	@IdCertDecertificazione INT, 
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
	UPDATE CERT_DECERTIFICAZIONE
	SET
		ID_PROGETTO = @IdProgetto, 
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento, 
		ID_DECERTIFICAZIONE = @IdDecertificazione, 
		TIPO_DECERTIFICAZIONE = @TipoDecertificazione, 
		IMPORTO_DECERTIFICAZIONE_AMMESSO = @ImportoDecertificazioneAmmesso, 
		IMPORTO_DECERTIFICAZIONE_CONCESSO = @ImportoDecertificazioneConcesso, 
		DATA_CONSTATAZIONE_AMMINISTRATIVA = @DataConstatazioneAmministrativa, 
		ID_CERTIFICAZIONE_SPESA = @IdCertificazioneSpesa, 
		ID_CERTIFICAZIONE_CONTI = @IdCertificazioneConti, 
		ASSEGNATA = @Assegnata, 
		DEFINITIVA = @Definitiva
	WHERE 
		(ID_CERT_DECERTIFICAZIONE = @IdCertDecertificazione)