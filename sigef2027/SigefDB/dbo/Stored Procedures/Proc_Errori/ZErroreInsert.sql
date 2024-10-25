CREATE PROCEDURE [dbo].[ZErroreInsert]
(
	@IdProgetto INT, 
	@IdDomandaPagamento INT, 
	@CfInserimento VARCHAR(255), 
	@DataInserimento DATETIME, 
	@CfModifica VARCHAR(255), 
	@DataModifica DATETIME, 
	@DataRilevazione DATETIME, 
	@ImpreseBeneficiari VARCHAR(max), 
	@SoggettoRilevazione VARCHAR(max), 
	@Certificato BIT, 
	@IdLottoCertificazione INT, 
	@DataInizioCertificazione DATETIME, 
	@SpesaAmmessaErrore DECIMAL(18,2), 
	@ContributoPubblicoErrore DECIMAL(18,2), 
	@DaRecuperare BIT, 
	@Recuperato BIT, 
	@AzioneCertificazione VARCHAR(255), 
	@IdLottoImpattato INT, 
	@Note VARCHAR(max), 
	@DataFineCertificazione DATETIME
)
AS
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	INSERT INTO ERRORE
	(
		ID_PROGETTO, 
		ID_DOMANDA_PAGAMENTO, 
		CF_INSERIMENTO, 
		DATA_INSERIMENTO, 
		CF_MODIFICA, 
		DATA_MODIFICA, 
		DATA_RILEVAZIONE, 
		IMPRESE_BENEFICIARI, 
		SOGGETTO_RILEVAZIONE, 
		CERTIFICATO, 
		ID_LOTTO_CERTIFICAZIONE, 
		DATA_INIZIO_CERTIFICAZIONE, 
		SPESA_AMMESSA_ERRORE, 
		CONTRIBUTO_PUBBLICO_ERRORE, 
		DA_RECUPERARE, 
		RECUPERATO, 
		AZIONE_CERTIFICAZIONE, 
		ID_LOTTO_IMPATTATO, 
		NOTE, 
		DATA_FINE_CERTIFICAZIONE
	)
	VALUES
	(
		@IdProgetto, 
		@IdDomandaPagamento, 
		@CfInserimento, 
		@DataInserimento, 
		@CfModifica, 
		@DataModifica, 
		@DataRilevazione, 
		@ImpreseBeneficiari, 
		@SoggettoRilevazione, 
		@Certificato, 
		@IdLottoCertificazione, 
		@DataInizioCertificazione, 
		@SpesaAmmessaErrore, 
		@ContributoPubblicoErrore, 
		@DaRecuperare, 
		@Recuperato, 
		@AzioneCertificazione, 
		@IdLottoImpattato, 
		@Note, 
		@DataFineCertificazione
	)
	SELECT SCOPE_IDENTITY() AS ID_ERRORE, @DataModifica AS DATA_MODIFICA

GO