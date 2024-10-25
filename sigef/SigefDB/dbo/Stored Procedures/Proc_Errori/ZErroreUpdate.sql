CREATE PROCEDURE [dbo].[ZErroreUpdate]
(
	@IdErrore INT, 
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
	SET @DataModifica=getdate()
	UPDATE ERRORE
	SET
		ID_PROGETTO = @IdProgetto, 
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento, 
		CF_INSERIMENTO = @CfInserimento, 
		DATA_INSERIMENTO = @DataInserimento, 
		CF_MODIFICA = @CfModifica, 
		DATA_MODIFICA = @DataModifica, 
		DATA_RILEVAZIONE = @DataRilevazione, 
		IMPRESE_BENEFICIARI = @ImpreseBeneficiari, 
		SOGGETTO_RILEVAZIONE = @SoggettoRilevazione, 
		CERTIFICATO = @Certificato, 
		ID_LOTTO_CERTIFICAZIONE = @IdLottoCertificazione, 
		DATA_INIZIO_CERTIFICAZIONE = @DataInizioCertificazione, 
		SPESA_AMMESSA_ERRORE = @SpesaAmmessaErrore, 
		CONTRIBUTO_PUBBLICO_ERRORE = @ContributoPubblicoErrore, 
		DA_RECUPERARE = @DaRecuperare, 
		RECUPERATO = @Recuperato, 
		AZIONE_CERTIFICAZIONE = @AzioneCertificazione, 
		ID_LOTTO_IMPATTATO = @IdLottoImpattato, 
		NOTE = @Note, 
		DATA_FINE_CERTIFICAZIONE = @DataFineCertificazione
	WHERE 
		(ID_ERRORE = @IdErrore)
	SELECT @DataModifica;

GO