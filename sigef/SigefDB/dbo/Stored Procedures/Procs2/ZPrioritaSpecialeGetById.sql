CREATE PROCEDURE [dbo].[ZPrioritaSpecialeGetById]
(
	@IdSchedaValutazione INT, 
	@IdPriorita INT, 
	@IdPrioritaSelezionata INT
)
AS
	SELECT *
	FROM PRIORITA_SPECIALE
	WHERE 
		(ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione) AND 
		(ID_PRIORITA = @IdPriorita) AND 
		(ID_PRIORITA_SELEZIONATA = @IdPrioritaSelezionata)
