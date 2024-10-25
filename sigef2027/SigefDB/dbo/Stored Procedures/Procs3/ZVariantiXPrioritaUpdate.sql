CREATE PROCEDURE [dbo].[ZVariantiXPrioritaUpdate]
(
	@IdVariante INT, 
	@IdPriorita INT, 
	@IdProgetto INT, 
	@Punteggio DECIMAL(10,6), 
	@DataValutazione DATETIME, 
	@Operatore VARCHAR(16), 
	@FlagDefinitivo BIT
)
AS
	UPDATE VARIANTI_X_PRIORITA
	SET
		ID_PROGETTO = @IdProgetto, 
		PUNTEGGIO = @Punteggio, 
		DATA_VALUTAZIONE = @DataValutazione, 
		OPERATORE = @Operatore, 
		FLAG_DEFINITIVO = @FlagDefinitivo
	WHERE 
		(ID_VARIANTE = @IdVariante) AND 
		(ID_PRIORITA = @IdPriorita)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVariantiXPrioritaUpdate';

