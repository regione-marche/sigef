CREATE PROCEDURE [dbo].[ZRevisioneDomandaPagamentoUpdate]
(
	@IdDomandaPagamento INT, 
	@IdLotto INT, 
	@DataInserimento DATETIME, 
	@DataModifica DATETIME, 
	@CfOperatore VARCHAR(255), 
	@SelezionataXRevisione BIT, 
	@Approvata BIT, 
	@NumeroEstrazione INT, 
	@Ordine INT, 
	@SegnaturaRevisione VARCHAR(255), 
	@SegnaturaSecondaRevisione VARCHAR(255), 
	@DataValidazione DATETIME
)
AS
	SET @DataModifica=getdate()
	UPDATE REVISIONE_DOMANDA_PAGAMENTO
	SET
		DATA_INSERIMENTO = @DataInserimento, 
		DATA_MODIFICA = @DataModifica, 
		CF_OPERATORE = @CfOperatore, 
		SELEZIONATA_X_REVISIONE = @SelezionataXRevisione, 
		APPROVATA = @Approvata, 
		NUMERO_ESTRAZIONE = @NumeroEstrazione, 
		ORDINE = @Ordine, 
		SEGNATURA_REVISIONE = @SegnaturaRevisione, 
		SEGNATURA_SECONDA_REVISIONE = @SegnaturaSecondaRevisione, 
		DATA_VALIDAZIONE = @DataValidazione
	WHERE 
		(ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento) AND 
		(ID_LOTTO = @IdLotto)
	SELECT @DataModifica;


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZRevisioneDomandaPagamentoUpdate]
(
	@IdDomandaPagamento INT, 
	@IdLotto INT, 
	@DataInserimento DATETIME, 
	@DataModifica DATETIME, 
	@CfOperatore VARCHAR(255), 
	@SelezionataXRevisione BIT, 
	@Approvata BIT, 
	@NumeroEstrazione INT, 
	@Ordine INT, 
	@SegnaturaRevisione VARCHAR(255), 
	@SegnaturaSecondaRevisione VARCHAR(255)
)
AS
	SET @DataModifica=getdate()
	UPDATE REVISIONE_DOMANDA_PAGAMENTO
	SET
		DATA_INSERIMENTO = @DataInserimento, 
		DATA_MODIFICA = @DataModifica, 
		CF_OPERATORE = @CfOperatore, 
		SELEZIONATA_X_REVISIONE = @SelezionataXRevisione, 
		APPROVATA = @Approvata, 
		NUMERO_ESTRAZIONE = @NumeroEstrazione, 
		ORDINE = @Ordine, 
		SEGNATURA_REVISIONE = @SegnaturaRevisione, 
		SEGNATURA_SECONDA_REVISIONE = @SegnaturaSecondaRevisione
	WHERE 
		(ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento) AND 
		(ID_LOTTO = @IdLotto)
	SELECT @DataModifica;
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRevisioneDomandaPagamentoUpdate';

