CREATE PROCEDURE [dbo].[ZRevisioneDomandaPagamentoInsert]
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
	SET @SelezionataXRevisione = ISNULL(@SelezionataXRevisione,((0)))
	SET @NumeroEstrazione = ISNULL(@NumeroEstrazione,((0)))
	INSERT INTO REVISIONE_DOMANDA_PAGAMENTO
	(
		ID_DOMANDA_PAGAMENTO, 
		ID_LOTTO, 
		DATA_INSERIMENTO, 
		DATA_MODIFICA, 
		CF_OPERATORE, 
		SELEZIONATA_X_REVISIONE, 
		APPROVATA, 
		NUMERO_ESTRAZIONE, 
		ORDINE, 
		SEGNATURA_REVISIONE, 
		SEGNATURA_SECONDA_REVISIONE, 
		DATA_VALIDAZIONE
	)
	VALUES
	(
		@IdDomandaPagamento, 
		@IdLotto, 
		@DataInserimento, 
		@DataModifica, 
		@CfOperatore, 
		@SelezionataXRevisione, 
		@Approvata, 
		@NumeroEstrazione, 
		@Ordine, 
		@SegnaturaRevisione, 
		@SegnaturaSecondaRevisione, 
		@DataValidazione
	)
	SELECT @SelezionataXRevisione AS SELEZIONATA_X_REVISIONE, @NumeroEstrazione AS NUMERO_ESTRAZIONE


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZRevisioneDomandaPagamentoInsert]
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
	SET @SelezionataXRevisione = ISNULL(@SelezionataXRevisione,((0)))
	SET @NumeroEstrazione = ISNULL(@NumeroEstrazione,((0)))
	INSERT INTO REVISIONE_DOMANDA_PAGAMENTO
	(
		ID_DOMANDA_PAGAMENTO, 
		ID_LOTTO, 
		DATA_INSERIMENTO, 
		DATA_MODIFICA, 
		CF_OPERATORE, 
		SELEZIONATA_X_REVISIONE, 
		APPROVATA, 
		NUMERO_ESTRAZIONE, 
		ORDINE, 
		SEGNATURA_REVISIONE, 
		SEGNATURA_SECONDA_REVISIONE
	)
	VALUES
	(
		@IdDomandaPagamento, 
		@IdLotto, 
		@DataInserimento, 
		@DataModifica, 
		@CfOperatore, 
		@SelezionataXRevisione, 
		@Approvata, 
		@NumeroEstrazione, 
		@Ordine, 
		@SegnaturaRevisione, 
		@SegnaturaSecondaRevisione
	)
	SELECT @SelezionataXRevisione AS SELEZIONATA_X_REVISIONE, @NumeroEstrazione AS NUMERO_ESTRAZIONE
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRevisioneDomandaPagamentoInsert';

