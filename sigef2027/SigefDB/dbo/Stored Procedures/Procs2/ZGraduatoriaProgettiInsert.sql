CREATE PROCEDURE [dbo].[ZGraduatoriaProgettiInsert]
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
	SET @Punteggio = ISNULL(@Punteggio,((0)))
	SET @UtilizzaFondiRiserva = ISNULL(@UtilizzaFondiRiserva,((0)))
	INSERT INTO GRADUATORIA_PROGETTI
	(
		ID_BANDO, 
		ID_PROGETTO, 
		PUNTEGGIO, 
		DATA_VALUTAZIONE, 
		OPERATORE, 
		ORDINE, 
		COSTO_TOTALE, 
		CONTRIBUTO_TOTALE, 
		CONTRIBUTO_RIMANENTE, 
		FINANZIABILITA, 
		UTILIZZA_FONDI_RISERVA, 
		AMMONTARE_FONDI_RISERVA_UTILIZZATO
	)
	VALUES
	(
		@IdBando, 
		@IdProgetto, 
		@Punteggio, 
		@DataValutazione, 
		@Operatore, 
		@Ordine, 
		@CostoTotale, 
		@ContributoTotale, 
		@ContributoRimanente, 
		@Finanziabilita, 
		@UtilizzaFondiRiserva, 
		@AmmontareFondiRiservaUtilizzato
	)
	SELECT @Punteggio AS PUNTEGGIO, @UtilizzaFondiRiserva AS UTILIZZA_FONDI_RISERVA

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZGraduatoriaProgettiInsert]
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
	SET @UtilizzaFondiRiserva = ISNULL(@UtilizzaFondiRiserva,((0)))
	INSERT INTO GRADUATORIA_PROGETTI
	(
		ID_BANDO, 
		ID_PROGETTO, 
		PUNTEGGIO, 
		DATA_VALUTAZIONE, 
		OPERATORE, 
		ORDINE, 
		COSTO_TOTALE, 
		CONTRIBUTO_TOTALE, 
		CONTRIBUTO_RIMANENTE, 
		FINANZIABILITA, 
		UTILIZZA_FONDI_RISERVA, 
		AMMONTARE_FONDI_RISERVA_UTILIZZATO
	)
	VALUES
	(
		@IdBando, 
		@IdProgetto, 
		@Punteggio, 
		@DataValutazione, 
		@Operatore, 
		@Ordine, 
		@CostoTotale, 
		@ContributoTotale, 
		@ContributoRimanente, 
		@Finanziabilita, 
		@UtilizzaFondiRiserva, 
		@AmmontareFondiRiservaUtilizzato
	)
	SELECT @UtilizzaFondiRiserva AS UTILIZZA_FONDI_RISERVA

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZGraduatoriaProgettiInsert';

