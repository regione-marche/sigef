CREATE PROCEDURE [dbo].[ZValoriPrioritaInsert]
(
	@IdPriorita INT, 
	@Descrizione VARCHAR(500), 
	@Codice VARCHAR(255), 
	@Punteggio DECIMAL(10,2)
)
AS
	INSERT INTO VALORI_PRIORITA
	(
		ID_PRIORITA, 
		DESCRIZIONE, 
		CODICE, 
		PUNTEGGIO
	)
	VALUES
	(
		@IdPriorita, 
		@Descrizione, 
		@Codice, 
		@Punteggio
	)
	SELECT SCOPE_IDENTITY() AS ID_VALORE


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZValoriPrioritaInsert]
(
	@IdPriorita INT, 
	@Descrizione VARCHAR(500), 
	@Codice VARCHAR(10), 
	@Punteggio DECIMAL(10,2)
)
AS
	INSERT INTO VALORI_PRIORITA
	(
		ID_PRIORITA, 
		DESCRIZIONE, 
		CODICE, 
		PUNTEGGIO
	)
	VALUES
	(
		@IdPriorita, 
		@Descrizione, 
		@Codice, 
		@Punteggio
	)
	SELECT SCOPE_IDENTITY() AS ID_VALORE
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZValoriPrioritaInsert';

