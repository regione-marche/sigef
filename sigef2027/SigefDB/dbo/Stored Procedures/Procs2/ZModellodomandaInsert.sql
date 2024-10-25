CREATE PROCEDURE [dbo].[ZModellodomandaInsert]
(
	@IdBando INT, 
	@Definitivo BIT, 
	@Operatore VARCHAR(16), 
	@Denominazione VARCHAR(50), 
	@Descrizione VARCHAR(1000)
)
AS
	INSERT INTO MODELLO_DOMANDA
	(
		ID_BANDO, 
		DEFINITIVO, 
		OPERATORE, 
		DENOMINAZIONE, 
		DESCRIZIONE
	)
	VALUES
	(
		@IdBando, 
		@Definitivo, 
		@Operatore, 
		@Denominazione, 
		@Descrizione
	)
	SELECT SCOPE_IDENTITY() AS ID_DOMANDA
