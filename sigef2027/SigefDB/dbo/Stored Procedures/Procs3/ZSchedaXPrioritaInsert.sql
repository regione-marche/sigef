CREATE PROCEDURE [dbo].[ZSchedaXPrioritaInsert]
(
	@IdSchedaValutazione INT, 
	@IdPriorita INT, 
	@Ordine INT, 
	@Peso DECIMAL(10,2), 
	@AiutoAddizionale DECIMAL(10,2), 
	@Selezionabile BIT, 
	@IsMax BIT
)
AS
	SET @Ordine = ISNULL(@Ordine,((0)))
	INSERT INTO SCHEDA_X_PRIORITA
	(
		ID_SCHEDA_VALUTAZIONE, 
		ID_PRIORITA, 
		ORDINE, 
		PESO, 
		AIUTO_ADDIZIONALE, 
		SELEZIONABILE, 
		IS_MAX
	)
	VALUES
	(
		@IdSchedaValutazione, 
		@IdPriorita, 
		@Ordine, 
		@Peso, 
		@AiutoAddizionale, 
		@Selezionabile, 
		@IsMax
	)
	SELECT @Ordine AS ORDINE


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZSchedaXPrioritaInsert]
(
	@IdSchedaValutazione INT, 
	@IdPriorita INT, 
	@Ordine INT, 
	@Peso DECIMAL(10,2), 
	@AiutoAddizionale DECIMAL(10,2), 
	@Selezionabile BIT, 
	@IsMax BIT
)
AS
	SET @Ordine = ISNULL(@Ordine,((0)))
	INSERT INTO SCHEDA_X_PRIORITA
	(
		ID_SCHEDA_VALUTAZIONE, 
		ID_PRIORITA, 
		ORDINE, 
		PESO, 
		AIUTO_ADDIZIONALE, 
		SELEZIONABILE, 
		IS_MAX
	)
	VALUES
	(
		@IdSchedaValutazione, 
		@IdPriorita, 
		@Ordine, 
		@Peso, 
		@AiutoAddizionale, 
		@Selezionabile, 
		@IsMax
	)
	SELECT @Ordine AS ORDINE
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSchedaXPrioritaInsert';

