CREATE PROCEDURE [dbo].[ZPrioritaXProgettoInsert]
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
	INSERT INTO PRIORITA_X_PROGETTO
	(
		ID_PROGETTO, 
		ID_PRIORITA, 
		VALORE, 
		DATA_VALUTAZIONE, 
		OPERATORE_VALUTAZIONE, 
		MODIFICA_MANUALE, 
		ID_VALORE, 
		PUNTEGGIO, 
		VAL_DATA, 
		VAL_TESTO
	)
	VALUES
	(
		@IdProgetto, 
		@IdPriorita, 
		@Valore, 
		@DataValutazione, 
		@OperatoreValutazione, 
		@ModificaManuale, 
		@IdValore, 
		@Punteggio, 
		@ValData, 
		@ValTesto
	)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZPrioritaXProgettoInsert]
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
	INSERT INTO PRIORITA_X_PROGETTO
	(
		ID_PROGETTO, 
		ID_PRIORITA, 
		VALORE, 
		DATA_VALUTAZIONE, 
		OPERATORE_VALUTAZIONE, 
		MODIFICA_MANUALE, 
		ID_VALORE, 
		PUNTEGGIO, 
		VAL_DATA, 
		VAL_TESTO
	)
	VALUES
	(
		@IdProgetto, 
		@IdPriorita, 
		@Valore, 
		@DataValutazione, 
		@OperatoreValutazione, 
		@ModificaManuale, 
		@IdValore, 
		@Punteggio, 
		@ValData, 
		@ValTesto
	)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPrioritaXProgettoInsert';

