CREATE PROCEDURE [dbo].[ZProgettoValutazioneFindFind]
(
	@IdProgettoequalthis INT, 
	@IdVarianteequalthis INT, 
	@IdVarianteisnull bit, 
	@Operatoreequalthis INT, 
	@Annullatoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_PROGETTO, ID_VARIANTE, ID_FILE, ORDINE_FIRMA, SEGNATURA, ID_NOTE, OPERATORE, DATA_MODIFICA, ANNULLATO FROM PROGETTO_VALUTAZIONE WHERE 1=1';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VARIANTE = @IdVarianteequalthis)'; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	IF (@IdVarianteisnull IS NOT NULL) BEGIN SET @sql = @sql + ' AND (((CASE WHEN (ID_VARIANTE IS NULL) THEN 1 ELSE 0 END) = @IdVarianteisnull))'; set @lensql=@lensql+len(@IdVarianteisnull);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@Annullatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNULLATO = @Annullatoequalthis)'; set @lensql=@lensql+len(@Annullatoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProgettoequalthis INT, @IdVarianteequalthis INT, @IdVarianteisnull bit, @Operatoreequalthis INT, @Annullatoequalthis BIT',@IdProgettoequalthis , @IdVarianteequalthis , @IdVarianteisnull , @Operatoreequalthis , @Annullatoequalthis ;
	else
		SELECT ID, ID_PROGETTO, ID_VARIANTE, ID_FILE, ORDINE_FIRMA, SEGNATURA, ID_NOTE, OPERATORE, DATA_MODIFICA, ANNULLATO
		FROM PROGETTO_VALUTAZIONE
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis) AND 
			((@IdVarianteisnull IS NULL) OR ((CASE WHEN (ID_VARIANTE IS NULL) THEN 1 ELSE 0 END) = @IdVarianteisnull)) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@Annullatoequalthis IS NULL) OR ANNULLATO = @Annullatoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoValutazioneFindFind]
(
	@IdProgettoequalthis INT, 
	@IdVarianteequalthis INT, 
	@IdVarianteisnull bit, 
	@Operatoreequalthis INT, 
	@Annullatoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_PROGETTO, ID_VARIANTE, ID_FILE, ORDINE_FIRMA, SEGNATURA, ID_NOTE, OPERATORE, DATA_MODIFICA, ANNULLATO FROM PROGETTO_VALUTAZIONE WHERE 1=1'';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_VARIANTE = @IdVarianteequalthis)''; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	IF (@IdVarianteisnull IS NOT NULL) BEGIN SET @sql = @sql + '' AND (((CASE WHEN (ID_VARIANTE IS NULL) THEN 1 ELSE 0 END) = @IdVarianteisnull))''; set @lensql=@lensql+len(@IdVarianteisnull);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (OPERATORE = @Operatoreequalthis)''; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@Annullatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ANNULLATO = @Annullatoequalthis)''; set @lensql=@lensql+len(@Annullatoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdProgettoequalthis INT, @IdVarianteequalthis INT, @IdVarianteisnull bit, @Operatoreequalthis INT, @Annullatoequalthis BIT'',@IdProgettoequalthis , @IdVarianteequalthis , @IdVarianteisnull , @Operatoreequalthis , @Annullatoequalthis ;
	else
		SELECT ID, ID_PROGETTO, ID_VARIANTE, ID_FILE, ORDINE_FIRMA, SEGNATURA, ID_NOTE, OPERATORE, DATA_MODIFICA, ANNULLATO
		FROM PROGETTO_VALUTAZIONE
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis) AND 
			((@IdVarianteisnull IS NULL) OR ((CASE WHEN (ID_VARIANTE IS NULL) THEN 1 ELSE 0 END) = @IdVarianteisnull)) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@Annullatoequalthis IS NULL) OR ANNULLATO = @Annullatoequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoValutazioneFindFind';

