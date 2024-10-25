CREATE PROCEDURE [dbo].[ZGraduatoriaProgettiFindSelect]
(
	@IdBandoequalthis INT, 
	@IdProgettoequalthis INT, 
	@Punteggioequalthis DECIMAL(10,6), 
	@DataValutazioneequalthis DATETIME, 
	@Operatoreequalthis VARCHAR(255), 
	@Ordineequalthis INT, 
	@CostoTotaleequalthis DECIMAL(18,2), 
	@ContributoTotaleequalthis DECIMAL(18,2), 
	@ContributoRimanenteequalthis DECIMAL(18,2), 
	@Finanziabilitaequalthis VARCHAR(255), 
	@UtilizzaFondiRiservaequalthis BIT, 
	@AmmontareFondiRiservaUtilizzatoequalthis DECIMAL(18,2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, ID_PROGETTO, PUNTEGGIO, DATA_VALUTAZIONE, OPERATORE, ORDINE, COSTO_TOTALE, CONTRIBUTO_TOTALE, CONTRIBUTO_RIMANENTE, FINANZIABILITA, UTILIZZA_FONDI_RISERVA, AMMONTARE_FONDI_RISERVA_UTILIZZATO FROM GRADUATORIA_PROGETTI WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@Punteggioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PUNTEGGIO = @Punteggioequalthis)'; set @lensql=@lensql+len(@Punteggioequalthis);end;
	IF (@DataValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_VALUTAZIONE = @DataValutazioneequalthis)'; set @lensql=@lensql+len(@DataValutazioneequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE = @Ordineequalthis)'; set @lensql=@lensql+len(@Ordineequalthis);end;
	IF (@CostoTotaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COSTO_TOTALE = @CostoTotaleequalthis)'; set @lensql=@lensql+len(@CostoTotaleequalthis);end;
	IF (@ContributoTotaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTRIBUTO_TOTALE = @ContributoTotaleequalthis)'; set @lensql=@lensql+len(@ContributoTotaleequalthis);end;
	IF (@ContributoRimanenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTRIBUTO_RIMANENTE = @ContributoRimanenteequalthis)'; set @lensql=@lensql+len(@ContributoRimanenteequalthis);end;
	IF (@Finanziabilitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FINANZIABILITA = @Finanziabilitaequalthis)'; set @lensql=@lensql+len(@Finanziabilitaequalthis);end;
	IF (@UtilizzaFondiRiservaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (UTILIZZA_FONDI_RISERVA = @UtilizzaFondiRiservaequalthis)'; set @lensql=@lensql+len(@UtilizzaFondiRiservaequalthis);end;
	IF (@AmmontareFondiRiservaUtilizzatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AMMONTARE_FONDI_RISERVA_UTILIZZATO = @AmmontareFondiRiservaUtilizzatoequalthis)'; set @lensql=@lensql+len(@AmmontareFondiRiservaUtilizzatoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @IdProgettoequalthis INT, @Punteggioequalthis DECIMAL(10,6), @DataValutazioneequalthis DATETIME, @Operatoreequalthis VARCHAR(255), @Ordineequalthis INT, @CostoTotaleequalthis DECIMAL(18,2), @ContributoTotaleequalthis DECIMAL(18,2), @ContributoRimanenteequalthis DECIMAL(18,2), @Finanziabilitaequalthis VARCHAR(255), @UtilizzaFondiRiservaequalthis BIT, @AmmontareFondiRiservaUtilizzatoequalthis DECIMAL(18,2)',@IdBandoequalthis , @IdProgettoequalthis , @Punteggioequalthis , @DataValutazioneequalthis , @Operatoreequalthis , @Ordineequalthis , @CostoTotaleequalthis , @ContributoTotaleequalthis , @ContributoRimanenteequalthis , @Finanziabilitaequalthis , @UtilizzaFondiRiservaequalthis , @AmmontareFondiRiservaUtilizzatoequalthis ;
	else
		SELECT ID_BANDO, ID_PROGETTO, PUNTEGGIO, DATA_VALUTAZIONE, OPERATORE, ORDINE, COSTO_TOTALE, CONTRIBUTO_TOTALE, CONTRIBUTO_RIMANENTE, FINANZIABILITA, UTILIZZA_FONDI_RISERVA, AMMONTARE_FONDI_RISERVA_UTILIZZATO
		FROM GRADUATORIA_PROGETTI
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@Punteggioequalthis IS NULL) OR PUNTEGGIO = @Punteggioequalthis) AND 
			((@DataValutazioneequalthis IS NULL) OR DATA_VALUTAZIONE = @DataValutazioneequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis) AND 
			((@CostoTotaleequalthis IS NULL) OR COSTO_TOTALE = @CostoTotaleequalthis) AND 
			((@ContributoTotaleequalthis IS NULL) OR CONTRIBUTO_TOTALE = @ContributoTotaleequalthis) AND 
			((@ContributoRimanenteequalthis IS NULL) OR CONTRIBUTO_RIMANENTE = @ContributoRimanenteequalthis) AND 
			((@Finanziabilitaequalthis IS NULL) OR FINANZIABILITA = @Finanziabilitaequalthis) AND 
			((@UtilizzaFondiRiservaequalthis IS NULL) OR UTILIZZA_FONDI_RISERVA = @UtilizzaFondiRiservaequalthis) AND 
			((@AmmontareFondiRiservaUtilizzatoequalthis IS NULL) OR AMMONTARE_FONDI_RISERVA_UTILIZZATO = @AmmontareFondiRiservaUtilizzatoequalthis)
