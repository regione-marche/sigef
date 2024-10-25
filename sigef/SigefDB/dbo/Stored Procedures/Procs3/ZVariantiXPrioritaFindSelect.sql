CREATE PROCEDURE [dbo].[ZVariantiXPrioritaFindSelect]
(
	@IdVarianteequalthis INT, 
	@IdPrioritaequalthis INT, 
	@IdProgettoequalthis INT, 
	@Punteggioequalthis DECIMAL(10,6), 
	@DataValutazioneequalthis DATETIME, 
	@Operatoreequalthis VARCHAR(16), 
	@FlagDefinitivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_VARIANTE, ID_PRIORITA, ID_PROGETTO, PUNTEGGIO, DATA_VALUTAZIONE, OPERATORE, DESCRIZIONE, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, INPUT_NUMERICO, MISURA, FLAG_DEFINITIVO FROM vVARIANTI_X_PRIORITA WHERE 1=1';
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VARIANTE = @IdVarianteequalthis)'; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	IF (@IdPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PRIORITA = @IdPrioritaequalthis)'; set @lensql=@lensql+len(@IdPrioritaequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@Punteggioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PUNTEGGIO = @Punteggioequalthis)'; set @lensql=@lensql+len(@Punteggioequalthis);end;
	IF (@DataValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_VALUTAZIONE = @DataValutazioneequalthis)'; set @lensql=@lensql+len(@DataValutazioneequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@FlagDefinitivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FLAG_DEFINITIVO = @FlagDefinitivoequalthis)'; set @lensql=@lensql+len(@FlagDefinitivoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdVarianteequalthis INT, @IdPrioritaequalthis INT, @IdProgettoequalthis INT, @Punteggioequalthis DECIMAL(10,6), @DataValutazioneequalthis DATETIME, @Operatoreequalthis VARCHAR(16), @FlagDefinitivoequalthis BIT',@IdVarianteequalthis , @IdPrioritaequalthis , @IdProgettoequalthis , @Punteggioequalthis , @DataValutazioneequalthis , @Operatoreequalthis , @FlagDefinitivoequalthis ;
	else
		SELECT ID_VARIANTE, ID_PRIORITA, ID_PROGETTO, PUNTEGGIO, DATA_VALUTAZIONE, OPERATORE, DESCRIZIONE, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, INPUT_NUMERICO, MISURA, FLAG_DEFINITIVO
		FROM vVARIANTI_X_PRIORITA
		WHERE 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis) AND 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@Punteggioequalthis IS NULL) OR PUNTEGGIO = @Punteggioequalthis) AND 
			((@DataValutazioneequalthis IS NULL) OR DATA_VALUTAZIONE = @DataValutazioneequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@FlagDefinitivoequalthis IS NULL) OR FLAG_DEFINITIVO = @FlagDefinitivoequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVariantiXPrioritaFindSelect';

