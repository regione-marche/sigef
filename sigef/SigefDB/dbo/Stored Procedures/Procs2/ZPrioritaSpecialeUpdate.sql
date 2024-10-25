CREATE PROCEDURE [dbo].[ZPrioritaSpecialeUpdate]
(
	@IdSchedaValutazione INT, 
	@IdPriorita INT, 
	@IdPrioritaSelezionata INT, 
	@IsMax BIT
)
AS
	UPDATE PRIORITA_SPECIALE
	SET
		IS_MAX = @IsMax
	WHERE 
		(ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione) AND 
		(ID_PRIORITA = @IdPriorita) AND 
		(ID_PRIORITA_SELEZIONATA = @IdPrioritaSelezionata)
