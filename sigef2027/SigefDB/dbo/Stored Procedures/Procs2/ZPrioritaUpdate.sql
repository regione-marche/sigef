CREATE PROCEDURE [dbo].[ZPrioritaUpdate]
(
	@IdPriorita INT, 
	@Descrizione VARCHAR(1000), 
	@CodLivello VARCHAR(255), 
	@PluriValore BIT, 
	@Eval VARCHAR(3000), 
	@FlagManuale BIT, 
	@InputNumerico BIT, 
	@Misura VARCHAR(255), 
	@Datetime BIT, 
	@TestoSemplice BIT, 
	@TestoArea BIT, 
	@PluriValoreSql BIT, 
	@QueryPlurivalore VARCHAR(255)
)
AS
	UPDATE PRIORITA
	SET
		DESCRIZIONE = @Descrizione, 
		COD_LIVELLO = @CodLivello, 
		PLURI_VALORE = @PluriValore, 
		EVAL = @Eval, 
		FLAG_MANUALE = @FlagManuale, 
		INPUT_NUMERICO = @InputNumerico, 
		MISURA = @Misura, 
		DATETIME = @Datetime, 
		TESTO_SEMPLICE = @TestoSemplice, 
		TESTO_AREA = @TestoArea, 
		PLURI_VALORE_SQL = @PluriValoreSql, 
		QUERY_PLURIVALORE = @QueryPlurivalore
	WHERE 
		(ID_PRIORITA = @IdPriorita)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZPrioritaUpdate]
(
	@IdPriorita INT, 
	@Descrizione VARCHAR(1000), 
	@CodLivello VARCHAR(255), 
	@PluriValore BIT, 
	@Eval VARCHAR(3000), 
	@FlagManuale BIT, 
	@InputNumerico BIT, 
	@Misura VARCHAR(255), 
	@Datetime BIT, 
	@TestoSemplice BIT, 
	@TestoArea BIT
)
AS
	UPDATE PRIORITA
	SET
		DESCRIZIONE = @Descrizione, 
		COD_LIVELLO = @CodLivello, 
		PLURI_VALORE = @PluriValore, 
		EVAL = @Eval, 
		FLAG_MANUALE = @FlagManuale, 
		INPUT_NUMERICO = @InputNumerico, 
		MISURA = @Misura, 
		DATETIME = @Datetime, 
		TESTO_SEMPLICE = @TestoSemplice, 
		TESTO_AREA = @TestoArea
	WHERE 
		(ID_PRIORITA = @IdPriorita)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPrioritaUpdate';

