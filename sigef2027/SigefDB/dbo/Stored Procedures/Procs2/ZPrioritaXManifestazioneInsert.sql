create PROCEDURE [dbo].[ZPrioritaXManifestazioneInsert]
(
	@IdManifestazione INT, 
	@IdPriorita INT, 
	@IdValore INT, 
	@Valore DECIMAL(18,2), 
	@DataValutazione DATETIME, 
	@OperatoreValutazione VARCHAR(16), 
	@ModificaManuale BIT, 
	@Punteggio DECIMAL(18,6)
)
AS
	INSERT INTO PRIORITA_X_MANIFESTAZIONE
	(
		ID_MANIFESTAZIONE, 
		ID_PRIORITA, 
		ID_VALORE, 
		VALORE, 
		DATA_VALUTAZIONE, 
		OPERATORE_VALUTAZIONE, 
		MODIFICA_MANUALE, 
		PUNTEGGIO
	)
	VALUES
	(
		@IdManifestazione, 
		@IdPriorita, 
		@IdValore, 
		@Valore, 
		@DataValutazione, 
		@OperatoreValutazione, 
		@ModificaManuale, 
		@Punteggio
	)
