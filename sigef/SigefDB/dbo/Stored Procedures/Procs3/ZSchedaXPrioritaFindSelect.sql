CREATE PROCEDURE [dbo].[ZSchedaXPrioritaFindSelect]
(
	@IdSchedaValutazioneequalthis INT, 
	@IdPrioritaequalthis INT, 
	@Ordineequalthis INT, 
	@Pesoequalthis DECIMAL(10,2), 
	@AiutoAddizionaleequalthis DECIMAL(10,2), 
	@Selezionabileequalthis BIT, 
	@IsMaxequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_SCHEDA_VALUTAZIONE, DESCRIZIONE, FLAG_TEMPLATE, ID_PRIORITA, PRIORITA, COD_LIVELLO, ORDINE, PESO, VALORE_MAX, VALORE_MIN, AIUTO_ADDIZIONALE, SELEZIONABILE, PLURI_VALORE, EVAL, FLAG_MANUALE, IS_MAX, INPUT_NUMERICO, MISURA, DATETIME, TESTO_SEMPLICE, TESTO_AREA, PLURI_VALORE_SQL, QUERY_PLURIVALORE FROM vSCHEDA_X_PRIORITA WHERE 1=1';
	IF (@IdSchedaValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazioneequalthis)'; set @lensql=@lensql+len(@IdSchedaValutazioneequalthis);end;
	IF (@IdPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PRIORITA = @IdPrioritaequalthis)'; set @lensql=@lensql+len(@IdPrioritaequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE = @Ordineequalthis)'; set @lensql=@lensql+len(@Ordineequalthis);end;
	IF (@Pesoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PESO = @Pesoequalthis)'; set @lensql=@lensql+len(@Pesoequalthis);end;
	IF (@AiutoAddizionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AIUTO_ADDIZIONALE = @AiutoAddizionaleequalthis)'; set @lensql=@lensql+len(@AiutoAddizionaleequalthis);end;
	IF (@Selezionabileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SELEZIONABILE = @Selezionabileequalthis)'; set @lensql=@lensql+len(@Selezionabileequalthis);end;
	IF (@IsMaxequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IS_MAX = @IsMaxequalthis)'; set @lensql=@lensql+len(@IsMaxequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdSchedaValutazioneequalthis INT, @IdPrioritaequalthis INT, @Ordineequalthis INT, @Pesoequalthis DECIMAL(10,2), @AiutoAddizionaleequalthis DECIMAL(10,2), @Selezionabileequalthis BIT, @IsMaxequalthis BIT',@IdSchedaValutazioneequalthis , @IdPrioritaequalthis , @Ordineequalthis , @Pesoequalthis , @AiutoAddizionaleequalthis , @Selezionabileequalthis , @IsMaxequalthis ;
	else
		SELECT ID_SCHEDA_VALUTAZIONE, DESCRIZIONE, FLAG_TEMPLATE, ID_PRIORITA, PRIORITA, COD_LIVELLO, ORDINE, PESO, VALORE_MAX, VALORE_MIN, AIUTO_ADDIZIONALE, SELEZIONABILE, PLURI_VALORE, EVAL, FLAG_MANUALE, IS_MAX, INPUT_NUMERICO, MISURA, DATETIME, TESTO_SEMPLICE, TESTO_AREA, PLURI_VALORE_SQL, QUERY_PLURIVALORE
		FROM vSCHEDA_X_PRIORITA
		WHERE 
			((@IdSchedaValutazioneequalthis IS NULL) OR ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazioneequalthis) AND 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis) AND 
			((@Pesoequalthis IS NULL) OR PESO = @Pesoequalthis) AND 
			((@AiutoAddizionaleequalthis IS NULL) OR AIUTO_ADDIZIONALE = @AiutoAddizionaleequalthis) AND 
			((@Selezionabileequalthis IS NULL) OR SELEZIONABILE = @Selezionabileequalthis) AND 
			((@IsMaxequalthis IS NULL) OR IS_MAX = @IsMaxequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZSchedaXPrioritaFindSelect]
(
	@IdSchedaValutazioneequalthis INT, 
	@IdPrioritaequalthis INT, 
	@Ordineequalthis INT, 
	@Pesoequalthis DECIMAL(10,2), 
	@AiutoAddizionaleequalthis DECIMAL(10,2), 
	@Selezionabileequalthis BIT, 
	@IsMaxequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_SCHEDA_VALUTAZIONE, DESCRIZIONE, FLAG_TEMPLATE, ID_PRIORITA, PRIORITA, COD_LIVELLO, ORDINE, PESO, VALORE_MAX, VALORE_MIN, AIUTO_ADDIZIONALE, SELEZIONABILE, PLURI_VALORE, EVAL, FLAG_MANUALE, IS_MAX, INPUT_NUMERICO, MISURA, DATETIME, TESTO_SEMPLICE, TESTO_AREA FROM vSCHEDA_X_PRIORITA WHERE 1=1'';
	IF (@IdSchedaValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazioneequalthis)''; set @lensql=@lensql+len(@IdSchedaValutazioneequalthis);end;
	IF (@IdPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PRIORITA = @IdPrioritaequalthis)''; set @lensql=@lensql+len(@IdPrioritaequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ORDINE = @Ordineequalthis)''; set @lensql=@lensql+len(@Ordineequalthis);end;
	IF (@Pesoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PESO = @Pesoequalthis)''; set @lensql=@lensql+len(@Pesoequalthis);end;
	IF (@AiutoAddizionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (AIUTO_ADDIZIONALE = @AiutoAddizionaleequalthis)''; set @lensql=@lensql+len(@AiutoAddizionaleequalthis);end;
	IF (@Selezionabileequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SELEZIONABILE = @Selezionabileequalthis)''; set @lensql=@lensql+len(@Selezionabileequalthis);end;
	IF (@IsMaxequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IS_MAX = @IsMaxequalthis)''; set @lensql=@lensql+len(@IsMaxequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdSchedaValutazioneequalthis INT, @IdPrioritaequalthis INT, @Ordineequalthis INT, @Pesoequalthis DECIMAL(10,2), @AiutoAddizionaleequalthis DECIMAL(10,2), @Selezionabileequalthis BIT, @IsMaxequalthis BIT'',@IdSchedaValutazioneequalthis , @IdPrioritaequalthis , @Ordineequalthis , @Pesoequalthis , @AiutoAddizionaleequalthis , @Selezionabileequalthis , @IsMaxequalthis ;
	else
		SELECT ID_SCHEDA_VALUTAZIONE, DESCRIZIONE, FLAG_TEMPLATE, ID_PRIORITA, PRIORITA, COD_LIVELLO, ORDINE, PESO, VALORE_MAX, VALORE_MIN, AIUTO_ADDIZIONALE, SELEZIONABILE, PLURI_VALORE, EVAL, FLAG_MANUALE, IS_MAX, INPUT_NUMERICO, MISURA, DATETIME, TESTO_SEMPLICE, TESTO_AREA
		FROM vSCHEDA_X_PRIORITA
		WHERE 
			((@IdSchedaValutazioneequalthis IS NULL) OR ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazioneequalthis) AND 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis) AND 
			((@Pesoequalthis IS NULL) OR PESO = @Pesoequalthis) AND 
			((@AiutoAddizionaleequalthis IS NULL) OR AIUTO_ADDIZIONALE = @AiutoAddizionaleequalthis) AND 
			((@Selezionabileequalthis IS NULL) OR SELEZIONABILE = @Selezionabileequalthis) AND 
			((@IsMaxequalthis IS NULL) OR IS_MAX = @IsMaxequalthis)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSchedaXPrioritaFindSelect';

