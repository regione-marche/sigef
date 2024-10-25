CREATE PROCEDURE [dbo].[ZProgettoValutatoriUpdate]
(
	@Id INT, 
	@IdProgettoValutazione INT, 
	@IdValutatore INT, 
	@Presente BIT, 
	@Ordine INT
)
AS
	UPDATE PROGETTO_VALUTATORI
	SET
		ID_PROGETTO_VALUTAZIONE = @IdProgettoValutazione, 
		ID_VALUTATORE = @IdValutatore, 
		PRESENTE = @Presente, 
		ORDINE = @Ordine
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoValutatoriUpdate]
(
	@Id INT, 
	@IdProgettoValutazione INT, 
	@IdValutatore INT, 
	@Presente BIT, 
	@Ordine INT
)
AS
	UPDATE PROGETTO_VALUTATORI
	SET
		ID_PROGETTO_VALUTAZIONE = @IdProgettoValutazione, 
		ID_VALUTATORE = @IdValutatore, 
		PRESENTE = @Presente, 
		ORDINE = @Ordine
	WHERE 
		(ID = @Id)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoValutatoriUpdate';

