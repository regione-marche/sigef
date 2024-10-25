CREATE PROCEDURE [dbo].[ZRequisitiPagamentoUpdate]
(
	@IdRequisito INT, 
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
	UPDATE REQUISITI_PAGAMENTO
	SET
		DESCRIZIONE = @Descrizione, 
		PLURIVALORE = @Plurivalore, 
		NUMERICO = @Numerico, 
		DATETIME = @Datetime, 
		TESTO_SEMPLICE = @TestoSemplice, 
		TESTO_AREA = @TestoArea, 
		URL = @Url, 
		QUERY_EVAL = @QueryEval, 
		QUERY_INSERT = @QueryInsert, 
		MISURA = @Misura
	WHERE 
		(ID_REQUISITO = @IdRequisito)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRequisitiPagamentoUpdate';

