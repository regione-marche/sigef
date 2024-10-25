CREATE PROCEDURE [dbo].[ZDomandaPagamentoRequisitiInsert]
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
	SET @Selezionato = ISNULL(@Selezionato,((0)))
	INSERT INTO DOMANDA_PAGAMENTO_REQUISITI
	(
		ID_DOMANDA_PAGAMENTO, 
		ID_REQUISITO, 
		ID_VALORE, 
		VAL_NUMERICO, 
		VAL_DATA, 
		VAL_TESTO, 
		ESITO, 
		DATA_ESITO, 
		SELEZIONATO
	)
	VALUES
	(
		@IdDomandaPagamento, 
		@IdRequisito, 
		@IdValore, 
		@ValNumerico, 
		@ValData, 
		@ValTesto, 
		@Esito, 
		@DataEsito, 
		@Selezionato
	)
	SELECT @Selezionato AS SELEZIONATO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZDomandaPagamentoRequisitiInsert]
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
	INSERT INTO DOMANDA_PAGAMENTO_REQUISITI
	(
		ID_DOMANDA_PAGAMENTO, 
		ID_REQUISITO, 
		ID_VALORE, 
		VAL_NUMERICO, 
		VAL_DATA, 
		VAL_TESTO, 
		ESITO, 
		DATA_ESITO
	)
	VALUES
	(
		@IdDomandaPagamento, 
		@IdRequisito, 
		@IdValore, 
		@ValNumerico, 
		@ValData, 
		@ValTesto, 
		@Esito, 
		@DataEsito
	)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDomandaPagamentoRequisitiInsert';

