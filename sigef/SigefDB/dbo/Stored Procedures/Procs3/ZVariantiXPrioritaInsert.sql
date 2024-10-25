CREATE PROCEDURE [dbo].[ZVariantiXPrioritaInsert]
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
	SET @FlagDefinitivo = ISNULL(@FlagDefinitivo,((0)))
	INSERT INTO VARIANTI_X_PRIORITA
	(
		ID_VARIANTE, 
		ID_PRIORITA, 
		ID_PROGETTO, 
		PUNTEGGIO, 
		DATA_VALUTAZIONE, 
		OPERATORE, 
		FLAG_DEFINITIVO
	)
	VALUES
	(
		@IdVariante, 
		@IdPriorita, 
		@IdProgetto, 
		@Punteggio, 
		@DataValutazione, 
		@Operatore, 
		@FlagDefinitivo
	)
	SELECT @FlagDefinitivo AS FLAG_DEFINITIVO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVariantiXPrioritaInsert';

