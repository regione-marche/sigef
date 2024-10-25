CREATE PROCEDURE [dbo].[ZSchedaXPrioritaFindFind]
(
	@IdSchedaValutazioneequalthis INT, 
	@IdPrioritaequalthis INT, 
	@FlagTemplateequalthis BIT, 
	@CodLivelloequalthis VARCHAR(255), 
	@FlagManualeequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_SCHEDA_VALUTAZIONE, DESCRIZIONE, FLAG_TEMPLATE, ID_PRIORITA, PRIORITA, COD_LIVELLO, ORDINE, PESO, VALORE_MAX, VALORE_MIN, AIUTO_ADDIZIONALE, SELEZIONABILE, PLURI_VALORE, EVAL, FLAG_MANUALE, IS_MAX, INPUT_NUMERICO, MISURA, DATETIME, TESTO_SEMPLICE, TESTO_AREA, PLURI_VALORE_SQL, QUERY_PLURIVALORE FROM vSCHEDA_X_PRIORITA WHERE 1=1';
	IF (@IdSchedaValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazioneequalthis)'; set @lensql=@lensql+len(@IdSchedaValutazioneequalthis);end;
	IF (@IdPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PRIORITA = @IdPrioritaequalthis)'; set @lensql=@lensql+len(@IdPrioritaequalthis);end;
	IF (@FlagTemplateequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FLAG_TEMPLATE = @FlagTemplateequalthis)'; set @lensql=@lensql+len(@FlagTemplateequalthis);end;
	IF (@CodLivelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_LIVELLO = @CodLivelloequalthis)'; set @lensql=@lensql+len(@CodLivelloequalthis);end;
	IF (@FlagManualeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FLAG_MANUALE = @FlagManualeequalthis)'; set @lensql=@lensql+len(@FlagManualeequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdSchedaValutazioneequalthis INT, @IdPrioritaequalthis INT, @FlagTemplateequalthis BIT, @CodLivelloequalthis VARCHAR(255), @FlagManualeequalthis BIT',@IdSchedaValutazioneequalthis , @IdPrioritaequalthis , @FlagTemplateequalthis , @CodLivelloequalthis , @FlagManualeequalthis ;
	else
		SELECT ID_SCHEDA_VALUTAZIONE, DESCRIZIONE, FLAG_TEMPLATE, ID_PRIORITA, PRIORITA, COD_LIVELLO, ORDINE, PESO, VALORE_MAX, VALORE_MIN, AIUTO_ADDIZIONALE, SELEZIONABILE, PLURI_VALORE, EVAL, FLAG_MANUALE, IS_MAX, INPUT_NUMERICO, MISURA, DATETIME, TESTO_SEMPLICE, TESTO_AREA, PLURI_VALORE_SQL, QUERY_PLURIVALORE
		FROM vSCHEDA_X_PRIORITA
		WHERE 
			((@IdSchedaValutazioneequalthis IS NULL) OR ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazioneequalthis) AND 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis) AND 
			((@FlagTemplateequalthis IS NULL) OR FLAG_TEMPLATE = @FlagTemplateequalthis) AND 
			((@CodLivelloequalthis IS NULL) OR COD_LIVELLO = @CodLivelloequalthis) AND 
			((@FlagManualeequalthis IS NULL) OR FLAG_MANUALE = @FlagManualeequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZSchedaXPrioritaFindFind]
(
	@IdSchedaValutazioneequalthis INT, 
	@IdPrioritaequalthis INT, 
	@FlagTemplateequalthis BIT, 
	@CodLivelloequalthis VARCHAR(255), 
	@FlagManualeequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_SCHEDA_VALUTAZIONE, DESCRIZIONE, FLAG_TEMPLATE, ID_PRIORITA, PRIORITA, COD_LIVELLO, ORDINE, PESO, VALORE_MAX, VALORE_MIN, AIUTO_ADDIZIONALE, SELEZIONABILE, PLURI_VALORE, EVAL, FLAG_MANUALE, IS_MAX, INPUT_NUMERICO, MISURA, DATETIME, TESTO_SEMPLICE, TESTO_AREA FROM vSCHEDA_X_PRIORITA WHERE 1=1'';
	IF (@IdSchedaValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazioneequalthis)''; set @lensql=@lensql+len(@IdSchedaValutazioneequalthis);end;
	IF (@IdPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PRIORITA = @IdPrioritaequalthis)''; set @lensql=@lensql+len(@IdPrioritaequalthis);end;
	IF (@FlagTemplateequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (FLAG_TEMPLATE = @FlagTemplateequalthis)''; set @lensql=@lensql+len(@FlagTemplateequalthis);end;
	IF (@CodLivelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_LIVELLO = @CodLivelloequalthis)''; set @lensql=@lensql+len(@CodLivelloequalthis);end;
	IF (@FlagManualeequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (FLAG_MANUALE = @FlagManualeequalthis)''; set @lensql=@lensql+len(@FlagManualeequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdSchedaValutazioneequalthis INT, @IdPrioritaequalthis INT, @FlagTemplateequalthis BIT, @CodLivelloequalthis VARCHAR(255), @FlagManualeequalthis BIT'',@IdSchedaValutazioneequalthis , @IdPrioritaequalthis , @FlagTemplateequalthis , @CodLivelloequalthis , @FlagManualeequalthis ;
	else
		SELECT ID_SCHEDA_VALUTAZIONE, DESCRIZIONE, FLAG_TEMPLATE, ID_PRIORITA, PRIORITA, COD_LIVELLO, ORDINE, PESO, VALORE_MAX, VALORE_MIN, AIUTO_ADDIZIONALE, SELEZIONABILE, PLURI_VALORE, EVAL, FLAG_MANUALE, IS_MAX, INPUT_NUMERICO, MISURA, DATETIME, TESTO_SEMPLICE, TESTO_AREA
		FROM vSCHEDA_X_PRIORITA
		WHERE 
			((@IdSchedaValutazioneequalthis IS NULL) OR ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazioneequalthis) AND 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis) AND 
			((@FlagTemplateequalthis IS NULL) OR FLAG_TEMPLATE = @FlagTemplateequalthis) AND 
			((@CodLivelloequalthis IS NULL) OR COD_LIVELLO = @CodLivelloequalthis) AND 
			((@FlagManualeequalthis IS NULL) OR FLAG_MANUALE = @FlagManualeequalthis)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSchedaXPrioritaFindFind';

