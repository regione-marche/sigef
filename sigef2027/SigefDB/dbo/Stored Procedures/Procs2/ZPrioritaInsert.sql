CREATE PROCEDURE [dbo].[ZPrioritaInsert]
(
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
	SET @Datetime = ISNULL(@Datetime,((0)))
	SET @TestoSemplice = ISNULL(@TestoSemplice,((0)))
	SET @TestoArea = ISNULL(@TestoArea,((0)))
	SET @PluriValoreSql = ISNULL(@PluriValoreSql,((0)))
	INSERT INTO PRIORITA
	(
		DESCRIZIONE, 
		COD_LIVELLO, 
		PLURI_VALORE, 
		EVAL, 
		FLAG_MANUALE, 
		INPUT_NUMERICO, 
		MISURA, 
		DATETIME, 
		TESTO_SEMPLICE, 
		TESTO_AREA, 
		PLURI_VALORE_SQL, 
		QUERY_PLURIVALORE
	)
	VALUES
	(
		@Descrizione, 
		@CodLivello, 
		@PluriValore, 
		@Eval, 
		@FlagManuale, 
		@InputNumerico, 
		@Misura, 
		@Datetime, 
		@TestoSemplice, 
		@TestoArea, 
		@PluriValoreSql, 
		@QueryPlurivalore
	)
	SELECT SCOPE_IDENTITY() AS ID_PRIORITA, @Datetime AS DATETIME, @TestoSemplice AS TESTO_SEMPLICE, @TestoArea AS TESTO_AREA, @PluriValoreSql AS PLURI_VALORE_SQL


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZPrioritaInsert]
(
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
	INSERT INTO PRIORITA
	(
		DESCRIZIONE, 
		COD_LIVELLO, 
		PLURI_VALORE, 
		EVAL, 
		FLAG_MANUALE, 
		INPUT_NUMERICO, 
		MISURA, 
		DATETIME, 
		TESTO_SEMPLICE, 
		TESTO_AREA
	)
	VALUES
	(
		@Descrizione, 
		@CodLivello, 
		@PluriValore, 
		@Eval, 
		@FlagManuale, 
		@InputNumerico, 
		@Misura, 
		@Datetime, 
		@TestoSemplice, 
		@TestoArea
	)
	SELECT SCOPE_IDENTITY() AS ID_PRIORITA
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPrioritaInsert';

