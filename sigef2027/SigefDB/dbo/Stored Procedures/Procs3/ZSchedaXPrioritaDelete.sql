CREATE PROCEDURE [dbo].[ZSchedaXPrioritaDelete]
(
	@IdSchedaValutazione INT, 
	@IdPriorita INT
)
AS
	DELETE SCHEDA_X_PRIORITA
	WHERE 
		(ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione) AND 
		(ID_PRIORITA = @IdPriorita)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZSchedaXPrioritaDelete]
(
	@IdSchedaValutazione INT, 
	@IdPriorita INT
)
AS
	DELETE SCHEDA_X_PRIORITA
	WHERE 
		(ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione) AND 
		(ID_PRIORITA = @IdPriorita)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSchedaXPrioritaDelete';

