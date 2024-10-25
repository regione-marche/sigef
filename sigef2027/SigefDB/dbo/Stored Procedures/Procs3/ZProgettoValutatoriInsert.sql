CREATE PROCEDURE [dbo].[ZProgettoValutatoriInsert]
(
	@IdProgettoValutazione INT, 
	@IdValutatore INT, 
	@Presente BIT, 
	@Ordine INT
)
AS
	SET @Presente = ISNULL(@Presente,((1)))
	INSERT INTO PROGETTO_VALUTATORI
	(
		ID_PROGETTO_VALUTAZIONE, 
		ID_VALUTATORE, 
		PRESENTE, 
		ORDINE
	)
	VALUES
	(
		@IdProgettoValutazione, 
		@IdValutatore, 
		@Presente, 
		@Ordine
	)
	SELECT SCOPE_IDENTITY() AS ID, @Presente AS PRESENTE


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoValutatoriInsert]
(
	@IdProgettoValutazione INT, 
	@IdValutatore INT, 
	@Presente BIT, 
	@Ordine INT
)
AS
	SET @Presente = ISNULL(@Presente,((1)))
	INSERT INTO PROGETTO_VALUTATORI
	(
		ID_PROGETTO_VALUTAZIONE, 
		ID_VALUTATORE, 
		PRESENTE, 
		ORDINE
	)
	VALUES
	(
		@IdProgettoValutazione, 
		@IdValutatore, 
		@Presente, 
		@Ordine
	)
	SELECT SCOPE_IDENTITY() AS ID, @Presente AS PRESENTE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoValutatoriInsert';

