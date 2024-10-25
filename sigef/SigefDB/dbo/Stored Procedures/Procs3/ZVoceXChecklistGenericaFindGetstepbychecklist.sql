CREATE PROCEDURE [dbo].[ZVoceXChecklistGenericaFindGetstepbychecklist]
(
	@IdChecklistGenericaequalthis INT, 
	@CodFaseequalthis VARCHAR(255), 
	@Misuraequalthis VARCHAR(255), 
	@DescrizioneChecklistGenericalikethis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_VOCE_X_CHECKLIST_GENERICA, ID_CHECKLIST_GENERICA, ID_VOCE_GENERICA, ORDINE, OBBLIGATORIO, PESO, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, MISURA, COD_FASE, DESCRIZIONE, AUTOMATICO, QUERY_SQL, QUERY_SQL_POST, CODE_METHOD, URL, VAL_MINIMO, VAL_MASSIMO, DESCRIZIONE_CHECKLIST_GENERICA, FLAG_TEMPLATE, VAL_ESITO_NEGATIVO FROM VVOCE_X_CHECKLIST_GENERICA WHERE 1=1';
	IF (@IdChecklistGenericaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CHECKLIST_GENERICA = @IdChecklistGenericaequalthis)'; set @lensql=@lensql+len(@IdChecklistGenericaequalthis);end;
	IF (@CodFaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_FASE = @CodFaseequalthis)'; set @lensql=@lensql+len(@CodFaseequalthis);end;
	IF (@Misuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MISURA = @Misuraequalthis)'; set @lensql=@lensql+len(@Misuraequalthis);end;
	IF (@DescrizioneChecklistGenericalikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE_CHECKLIST_GENERICA LIKE @DescrizioneChecklistGenericalikethis)'; set @lensql=@lensql+len(@DescrizioneChecklistGenericalikethis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdChecklistGenericaequalthis INT, @CodFaseequalthis VARCHAR(255), @Misuraequalthis VARCHAR(255), @DescrizioneChecklistGenericalikethis VARCHAR(255)',@IdChecklistGenericaequalthis , @CodFaseequalthis , @Misuraequalthis , @DescrizioneChecklistGenericalikethis ;
	else
		SELECT ID_VOCE_X_CHECKLIST_GENERICA, ID_CHECKLIST_GENERICA, ID_VOCE_GENERICA, ORDINE, OBBLIGATORIO, PESO, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, MISURA, COD_FASE, DESCRIZIONE, AUTOMATICO, QUERY_SQL, QUERY_SQL_POST, CODE_METHOD, URL, VAL_MINIMO, VAL_MASSIMO, DESCRIZIONE_CHECKLIST_GENERICA, FLAG_TEMPLATE, VAL_ESITO_NEGATIVO
		FROM VVOCE_X_CHECKLIST_GENERICA
		WHERE 
			((@IdChecklistGenericaequalthis IS NULL) OR ID_CHECKLIST_GENERICA = @IdChecklistGenericaequalthis) AND 
			((@CodFaseequalthis IS NULL) OR COD_FASE = @CodFaseequalthis) AND 
			((@Misuraequalthis IS NULL) OR MISURA = @Misuraequalthis) AND 
			((@DescrizioneChecklistGenericalikethis IS NULL) OR DESCRIZIONE_CHECKLIST_GENERICA LIKE @DescrizioneChecklistGenericalikethis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVoceXChecklistGenericaFindGetstepbychecklist';

