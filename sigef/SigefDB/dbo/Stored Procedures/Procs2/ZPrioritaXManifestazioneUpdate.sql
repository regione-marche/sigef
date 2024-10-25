create PROCEDURE [dbo].[ZPrioritaXManifestazioneUpdate]
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
	UPDATE PRIORITA_X_MANIFESTAZIONE
	SET
		ID_VALORE = @IdValore, 
		VALORE = @Valore, 
		DATA_VALUTAZIONE = @DataValutazione, 
		OPERATORE_VALUTAZIONE = @OperatoreValutazione, 
		MODIFICA_MANUALE = @ModificaManuale, 
		PUNTEGGIO = @Punteggio
	WHERE 
		(ID_MANIFESTAZIONE = @IdManifestazione) AND 
		(ID_PRIORITA = @IdPriorita)
