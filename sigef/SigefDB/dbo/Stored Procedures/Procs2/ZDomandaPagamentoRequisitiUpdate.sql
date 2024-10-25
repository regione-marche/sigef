CREATE PROCEDURE [dbo].[ZDomandaPagamentoRequisitiUpdate]
(
	@IdDomandaPagamento INT, 
	@IdRequisito INT, 
	@IdValore INT, 
	@ValNumerico DECIMAL(18,2), 
	@ValData DATETIME, 
	@ValTesto VARCHAR(500), 
	@Esito CHAR(2), 
	@DataEsito DATETIME, 
	@Selezionato BIT
)
AS
	UPDATE DOMANDA_PAGAMENTO_REQUISITI
	SET
		ID_VALORE = @IdValore, 
		VAL_NUMERICO = @ValNumerico, 
		VAL_DATA = @ValData, 
		VAL_TESTO = @ValTesto, 
		ESITO = @Esito, 
		DATA_ESITO = @DataEsito, 
		SELEZIONATO = @Selezionato
	WHERE 
		(ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento) AND 
		(ID_REQUISITO = @IdRequisito)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZDomandaPagamentoRequisitiUpdate]
(
	@IdDomandaPagamento INT, 
	@IdRequisito INT, 
	@IdValore INT, 
	@ValNumerico DECIMAL(18,2), 
	@ValData DATETIME, 
	@ValTesto VARCHAR(500), 
	@Esito CHAR(2), 
	@DataEsito DATETIME
)
AS
	UPDATE DOMANDA_PAGAMENTO_REQUISITI
	SET
		ID_VALORE = @IdValore, 
		VAL_NUMERICO = @ValNumerico, 
		VAL_DATA = @ValData, 
		VAL_TESTO = @ValTesto, 
		ESITO = @Esito, 
		DATA_ESITO = @DataEsito
	WHERE 
		(ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento) AND 
		(ID_REQUISITO = @IdRequisito)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDomandaPagamentoRequisitiUpdate';

