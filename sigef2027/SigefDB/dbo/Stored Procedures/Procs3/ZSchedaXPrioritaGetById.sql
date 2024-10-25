CREATE PROCEDURE [dbo].[ZSchedaXPrioritaGetById]
(
	@IdSchedaValutazione INT, 
	@IdPriorita INT
)
AS
	SELECT *
	FROM vSCHEDA_X_PRIORITA
	WHERE 
		(ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione) AND 
		(ID_PRIORITA = @IdPriorita)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZSchedaXPrioritaGetById]
(
	@IdSchedaValutazione INT, 
	@IdPriorita INT
)
AS
	SELECT *
	FROM vSCHEDA_X_PRIORITA
	WHERE 
		(ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione) AND 
		(ID_PRIORITA = @IdPriorita)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSchedaXPrioritaGetById';

