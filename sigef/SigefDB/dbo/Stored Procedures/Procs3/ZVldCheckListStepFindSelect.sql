CREATE PROCEDURE [dbo].[ZVldCheckListStepFindSelect]
(
	@IdVldCheckListequalthis INT, 
	@IdVldStepequalthis INT, 
	@Ordineequalthis INT, 
	@Obbligatorioequalthis BIT, 
	@IncludiVerbaleVisequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_VLD_CHECK_LIST, ID_VLD_STEP, Ordine, OBBLIGATORIO, INCLUDI_VERBALE_VIS, DESCRIZIONE, AUTOMATICO FROM vVLD_CHECK_LIST_STEP WHERE 1=1';
	IF (@IdVldCheckListequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VLD_CHECK_LIST = @IdVldCheckListequalthis)'; set @lensql=@lensql+len(@IdVldCheckListequalthis);end;
	IF (@IdVldStepequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VLD_STEP = @IdVldStepequalthis)'; set @lensql=@lensql+len(@IdVldStepequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE = @Ordineequalthis)'; set @lensql=@lensql+len(@Ordineequalthis);end;
	IF (@Obbligatorioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OBBLIGATORIO = @Obbligatorioequalthis)'; set @lensql=@lensql+len(@Obbligatorioequalthis);end;
	IF (@IncludiVerbaleVisequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (INCLUDI_VERBALE_VIS = @IncludiVerbaleVisequalthis)'; set @lensql=@lensql+len(@IncludiVerbaleVisequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdVldCheckListequalthis INT, @IdVldStepequalthis INT, @Ordineequalthis INT, @Obbligatorioequalthis BIT, @IncludiVerbaleVisequalthis BIT',@IdVldCheckListequalthis , @IdVldStepequalthis , @Ordineequalthis , @Obbligatorioequalthis , @IncludiVerbaleVisequalthis ;
	else
		SELECT ID_VLD_CHECK_LIST, ID_VLD_STEP, Ordine, OBBLIGATORIO, INCLUDI_VERBALE_VIS, DESCRIZIONE, AUTOMATICO
		FROM vVLD_CHECK_LIST_STEP
		WHERE 
			((@IdVldCheckListequalthis IS NULL) OR ID_VLD_CHECK_LIST = @IdVldCheckListequalthis) AND 
			((@IdVldStepequalthis IS NULL) OR ID_VLD_STEP = @IdVldStepequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis) AND 
			((@Obbligatorioequalthis IS NULL) OR OBBLIGATORIO = @Obbligatorioequalthis) AND 
			((@IncludiVerbaleVisequalthis IS NULL) OR INCLUDI_VERBALE_VIS = @IncludiVerbaleVisequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVldCheckListStepFindSelect';

