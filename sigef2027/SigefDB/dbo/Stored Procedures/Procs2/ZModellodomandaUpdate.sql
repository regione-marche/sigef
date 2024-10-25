CREATE PROCEDURE [dbo].[ZModellodomandaUpdate]
(
	@IdDomanda INT, 
	@IdBando INT, 
	@Definitivo BIT, 
	@Operatore VARCHAR(16), 
	@Denominazione VARCHAR(50), 
	@Descrizione VARCHAR(1000)
)
AS
	UPDATE MODELLO_DOMANDA
	SET
		ID_BANDO = @IdBando, 
		DEFINITIVO = @Definitivo, 
		OPERATORE = @Operatore, 
		DENOMINAZIONE = @Denominazione, 
		DESCRIZIONE = @Descrizione
	WHERE 
		(ID_DOMANDA = @IdDomanda)
