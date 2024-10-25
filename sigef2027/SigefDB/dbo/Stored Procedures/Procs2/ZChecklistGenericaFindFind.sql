CREATE PROCEDURE [dbo].[ZChecklistGenericaFindFind]
(
	@Descrizionelikethis VARCHAR(255), 
	@FlagTemplateequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_CHECKLIST_GENERICA, DESCRIZIONE, FLAG_TEMPLATE, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, ID_VOCE_X_CHECKLIST_GENERICA, ID_VOCE_GENERICA, ORDINE, OBBLIGATORIO, PESO, DESCRIZIONE_FASE, ORDINE_VOCE_GENERICA, COD_FASE, DESCRIZIONE_VOCE_GENERICA, AUTOMATICO, QUERY_SQL, QUERY_SQL_POST, CODE_METHOD, URL, VAL_MINIMO, VAL_MASSIMO FROM VCHECKLIST_GENERICA WHERE 1=1';
	IF (@Descrizionelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE LIKE @Descrizionelikethis)'; set @lensql=@lensql+len(@Descrizionelikethis);end;
	IF (@FlagTemplateequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FLAG_TEMPLATE = @FlagTemplateequalthis)'; set @lensql=@lensql+len(@FlagTemplateequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Descrizionelikethis VARCHAR(255), @FlagTemplateequalthis BIT',@Descrizionelikethis , @FlagTemplateequalthis ;
	else
		SELECT ID_CHECKLIST_GENERICA, DESCRIZIONE, FLAG_TEMPLATE, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, ID_VOCE_X_CHECKLIST_GENERICA, ID_VOCE_GENERICA, ORDINE, OBBLIGATORIO, PESO, DESCRIZIONE_FASE, ORDINE_VOCE_GENERICA, COD_FASE, DESCRIZIONE_VOCE_GENERICA, AUTOMATICO, QUERY_SQL, QUERY_SQL_POST, CODE_METHOD, URL, VAL_MINIMO, VAL_MASSIMO
		FROM VCHECKLIST_GENERICA
		WHERE 
			((@Descrizionelikethis IS NULL) OR DESCRIZIONE LIKE @Descrizionelikethis) AND 
			((@FlagTemplateequalthis IS NULL) OR FLAG_TEMPLATE = @FlagTemplateequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZChecklistGenericaFindFind';

