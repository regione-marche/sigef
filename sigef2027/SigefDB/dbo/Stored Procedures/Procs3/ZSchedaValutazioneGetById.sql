CREATE PROCEDURE [dbo].[ZSchedaValutazioneGetById]
(
	@IdSchedaValutazione INT
)
AS
	SELECT *
	FROM SCHEDA_VALUTAZIONE
	WHERE 
		(ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'
CREATE PROCEDURE [dbo].[ZSchedaValutazioneGetById]
(
	@IdSchedaValutazione INT
)
AS
	SELECT *
	FROM SCHEDA_VALUTAZIONE
	WHERE 
		(ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)


', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSchedaValutazioneGetById';

