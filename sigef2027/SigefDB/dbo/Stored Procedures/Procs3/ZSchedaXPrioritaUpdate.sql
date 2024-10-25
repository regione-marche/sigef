CREATE PROCEDURE [dbo].[ZSchedaXPrioritaUpdate]
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
	UPDATE SCHEDA_X_PRIORITA
	SET
		ORDINE = @Ordine, 
		PESO = @Peso, 
		AIUTO_ADDIZIONALE = @AiutoAddizionale, 
		SELEZIONABILE = @Selezionabile, 
		IS_MAX = @IsMax
	WHERE 
		(ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione) AND 
		(ID_PRIORITA = @IdPriorita)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZSchedaXPrioritaUpdate]
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
	UPDATE SCHEDA_X_PRIORITA
	SET
		ORDINE = @Ordine, 
		PESO = @Peso, 
		AIUTO_ADDIZIONALE = @AiutoAddizionale, 
		SELEZIONABILE = @Selezionabile, 
		IS_MAX = @IsMax
	WHERE 
		(ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione) AND 
		(ID_PRIORITA = @IdPriorita)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSchedaXPrioritaUpdate';

