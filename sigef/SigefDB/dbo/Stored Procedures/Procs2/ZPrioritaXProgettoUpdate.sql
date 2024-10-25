CREATE PROCEDURE [dbo].[ZPrioritaXProgettoUpdate]
(
	@IdProgetto INT, 
	@IdPriorita INT, 
	@Valore DECIMAL(18,2), 
	@DataValutazione DATETIME, 
	@OperatoreValutazione VARCHAR(255), 
	@ModificaManuale BIT, 
	@IdValore INT, 
	@Punteggio DECIMAL(18,6), 
	@ValData DATETIME, 
	@ValTesto VARCHAR(500)
)
AS
	UPDATE PRIORITA_X_PROGETTO
	SET
		VALORE = @Valore, 
		DATA_VALUTAZIONE = @DataValutazione, 
		OPERATORE_VALUTAZIONE = @OperatoreValutazione, 
		MODIFICA_MANUALE = @ModificaManuale, 
		ID_VALORE = @IdValore, 
		PUNTEGGIO = @Punteggio, 
		VAL_DATA = @ValData, 
		VAL_TESTO = @ValTesto
	WHERE 
		(ID_PROGETTO = @IdProgetto) AND 
		(ID_PRIORITA = @IdPriorita)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZPrioritaXProgettoUpdate]
(
	@IdProgetto INT, 
	@IdPriorita INT, 
	@Valore DECIMAL(18,2), 
	@DataValutazione DATETIME, 
	@OperatoreValutazione VARCHAR(255), 
	@ModificaManuale BIT, 
	@IdValore INT, 
	@Punteggio DECIMAL(18,6), 
	@ValData DATETIME, 
	@ValTesto VARCHAR(500)
)
AS
	UPDATE PRIORITA_X_PROGETTO
	SET
		VALORE = @Valore, 
		DATA_VALUTAZIONE = @DataValutazione, 
		OPERATORE_VALUTAZIONE = @OperatoreValutazione, 
		MODIFICA_MANUALE = @ModificaManuale, 
		ID_VALORE = @IdValore, 
		PUNTEGGIO = @Punteggio, 
		VAL_DATA = @ValData, 
		VAL_TESTO = @ValTesto
	WHERE 
		(ID_PROGETTO = @IdProgetto) AND 
		(ID_PRIORITA = @IdPriorita)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPrioritaXProgettoUpdate';

