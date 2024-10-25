CREATE PROCEDURE [dbo].[ZPrioritaSpecialeInsert]
(
	@IdSchedaValutazione INT, 
	@IdPriorita INT, 
	@IdPrioritaSelezionata INT, 
	@IsMax BIT
)
AS
	INSERT INTO PRIORITA_SPECIALE
	(
		ID_SCHEDA_VALUTAZIONE, 
		ID_PRIORITA, 
		ID_PRIORITA_SELEZIONATA, 
		IS_MAX
	)
	VALUES
	(
		@IdSchedaValutazione, 
		@IdPriorita, 
		@IdPrioritaSelezionata, 
		@IsMax
	)
