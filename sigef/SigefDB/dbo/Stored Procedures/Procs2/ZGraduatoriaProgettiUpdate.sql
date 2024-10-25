CREATE PROCEDURE [dbo].[ZGraduatoriaProgettiUpdate]
(
	@IdBando INT, 
	@IdProgetto INT, 
	@Punteggio DECIMAL(10,6), 
	@DataValutazione DATETIME, 
	@Operatore VARCHAR(255), 
	@Ordine INT, 
	@CostoTotale DECIMAL(18,2), 
	@ContributoTotale DECIMAL(18,2), 
	@ContributoRimanente DECIMAL(18,2), 
	@Finanziabilita VARCHAR(255), 
	@UtilizzaFondiRiserva BIT, 
	@AmmontareFondiRiservaUtilizzato DECIMAL(18,2)
)
AS
	UPDATE GRADUATORIA_PROGETTI
	SET
		PUNTEGGIO = @Punteggio, 
		DATA_VALUTAZIONE = @DataValutazione, 
		OPERATORE = @Operatore, 
		ORDINE = @Ordine, 
		COSTO_TOTALE = @CostoTotale, 
		CONTRIBUTO_TOTALE = @ContributoTotale, 
		CONTRIBUTO_RIMANENTE = @ContributoRimanente, 
		FINANZIABILITA = @Finanziabilita, 
		UTILIZZA_FONDI_RISERVA = @UtilizzaFondiRiserva, 
		AMMONTARE_FONDI_RISERVA_UTILIZZATO = @AmmontareFondiRiservaUtilizzato
	WHERE 
		(ID_BANDO = @IdBando) AND 
		(ID_PROGETTO = @IdProgetto)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZGraduatoriaProgettiUpdate]
(
	@IdBando INT, 
	@IdProgetto INT, 
	@Punteggio DECIMAL(10,6), 
	@DataValutazione DATETIME, 
	@Operatore VARCHAR(16), 
	@Ordine INT, 
	@CostoTotale DECIMAL(18,2), 
	@ContributoTotale DECIMAL(18,2), 
	@ContributoRimanente DECIMAL(18,2), 
	@Finanziabilita CHAR(1), 
	@UtilizzaFondiRiserva BIT, 
	@AmmontareFondiRiservaUtilizzato DECIMAL(18,2)
)
AS
	UPDATE GRADUATORIA_PROGETTI
	SET
		PUNTEGGIO = @Punteggio, 
		DATA_VALUTAZIONE = @DataValutazione, 
		OPERATORE = @Operatore, 
		ORDINE = @Ordine, 
		COSTO_TOTALE = @CostoTotale, 
		CONTRIBUTO_TOTALE = @ContributoTotale, 
		CONTRIBUTO_RIMANENTE = @ContributoRimanente, 
		FINANZIABILITA = @Finanziabilita, 
		UTILIZZA_FONDI_RISERVA = @UtilizzaFondiRiserva, 
		AMMONTARE_FONDI_RISERVA_UTILIZZATO = @AmmontareFondiRiservaUtilizzato
	WHERE 
		(ID_BANDO = @IdBando) AND 
		(ID_PROGETTO = @IdProgetto)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZGraduatoriaProgettiUpdate';

