CREATE PROCEDURE [dbo].[ZGraduatoriaProgettiDettaglioUpdate]
(
	@IdPriorita INT, 
	@IdProgetto INT, 
	@Punteggio DECIMAL(10,6), 
	@DataValutazione DATETIME, 
	@Operatore VARCHAR(255), 
	@ModificaManuale BIT
)
AS
	UPDATE GRADUATORIA_PROGETTI_DETTAGLIO
	SET
		PUNTEGGIO = @Punteggio, 
		DATA_VALUTAZIONE = @DataValutazione, 
		OPERATORE = @Operatore, 
		MODIFICA_MANUALE = @ModificaManuale
	WHERE 
		(ID_PRIORITA = @IdPriorita) AND 
		(ID_PROGETTO = @IdProgetto)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZGraduatoriaProgettiDettaglioUpdate]
(
	@IdPriorita INT, 
	@IdProgetto INT, 
	@Punteggio DECIMAL(10,6), 
	@DataValutazione DATETIME, 
	@Operatore VARCHAR(16), 
	@ModificaManuale BIT
)
AS
	UPDATE GRADUATORIA_PROGETTI_DETTAGLIO
	SET
		PUNTEGGIO = @Punteggio, 
		DATA_VALUTAZIONE = @DataValutazione, 
		OPERATORE = @Operatore, 
		MODIFICA_MANUALE = @ModificaManuale
	WHERE 
		(ID_PRIORITA = @IdPriorita) AND 
		(ID_PROGETTO = @IdProgetto)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZGraduatoriaProgettiDettaglioUpdate';

