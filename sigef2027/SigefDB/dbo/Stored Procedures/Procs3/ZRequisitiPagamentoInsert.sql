CREATE PROCEDURE [dbo].[ZRequisitiPagamentoInsert]
(
	@Descrizione VARCHAR(500), 
	@Plurivalore BIT, 
	@Numerico BIT, 
	@Datetime BIT, 
	@TestoSemplice BIT, 
	@TestoArea BIT, 
	@Url VARCHAR(100), 
	@QueryEval VARCHAR(3000), 
	@QueryInsert VARCHAR(3000), 
	@Misura VARCHAR(10)
)
AS
	SET @Plurivalore = ISNULL(@Plurivalore,((0)))
	SET @Numerico = ISNULL(@Numerico,((0)))
	SET @Datetime = ISNULL(@Datetime,((0)))
	SET @TestoSemplice = ISNULL(@TestoSemplice,((0)))
	SET @TestoArea = ISNULL(@TestoArea,((0)))
	INSERT INTO REQUISITI_PAGAMENTO
	(
		DESCRIZIONE, 
		PLURIVALORE, 
		NUMERICO, 
		DATETIME, 
		TESTO_SEMPLICE, 
		TESTO_AREA, 
		URL, 
		QUERY_EVAL, 
		QUERY_INSERT, 
		MISURA
	)
	VALUES
	(
		@Descrizione, 
		@Plurivalore, 
		@Numerico, 
		@Datetime, 
		@TestoSemplice, 
		@TestoArea, 
		@Url, 
		@QueryEval, 
		@QueryInsert, 
		@Misura
	)
	SELECT SCOPE_IDENTITY() AS ID_REQUISITO, @Plurivalore AS PLURIVALORE, @Numerico AS NUMERICO, @Datetime AS DATETIME, @TestoSemplice AS TESTO_SEMPLICE, @TestoArea AS TESTO_AREA

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRequisitiPagamentoInsert';

