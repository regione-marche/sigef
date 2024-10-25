CREATE PROCEDURE [dbo].[ZPrioritaSpecialeDelete]
(
	@IdSchedaValutazione INT, 
	@IdPriorita INT, 
	@IdPrioritaSelezionata INT
)
AS
	DELETE PRIORITA_SPECIALE
	WHERE 
		(ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione) AND 
		(ID_PRIORITA = @IdPriorita) AND 
		(ID_PRIORITA_SELEZIONATA = @IdPrioritaSelezionata)
