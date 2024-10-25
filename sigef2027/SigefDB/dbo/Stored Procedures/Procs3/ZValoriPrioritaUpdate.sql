CREATE PROCEDURE [dbo].[ZValoriPrioritaUpdate]
(
	@IdValore INT, 
	@IdPriorita INT, 
	@Descrizione VARCHAR(500), 
	@Codice VARCHAR(255), 
	@Punteggio DECIMAL(10,2)
)
AS
	UPDATE VALORI_PRIORITA
	SET
		ID_PRIORITA = @IdPriorita, 
		DESCRIZIONE = @Descrizione, 
		CODICE = @Codice, 
		PUNTEGGIO = @Punteggio
	WHERE 
		(ID_VALORE = @IdValore)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZValoriPrioritaUpdate]
(
	@IdValore INT, 
	@IdPriorita INT, 
	@Descrizione VARCHAR(500), 
	@Codice VARCHAR(10), 
	@Punteggio DECIMAL(10,2)
)
AS
	UPDATE VALORI_PRIORITA
	SET
		ID_PRIORITA = @IdPriorita, 
		DESCRIZIONE = @Descrizione, 
		CODICE = @Codice, 
		PUNTEGGIO = @Punteggio
	WHERE 
		(ID_VALORE = @IdValore)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZValoriPrioritaUpdate';

