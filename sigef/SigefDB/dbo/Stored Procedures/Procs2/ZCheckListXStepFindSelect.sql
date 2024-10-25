CREATE PROCEDURE [dbo].[ZCheckListXStepFindSelect]
(
	@IdCheckListequalthis INT, 
	@IdStepequalthis INT, 
	@Ordineequalthis INT, 
	@Obbligatorioequalthis BIT, 
	@Pesoequalthis DECIMAL(10,2), 
	@IncludiVerbaleVisequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_STEP, ORDINE, OBBLIGATORIO, PESO, STEP, AUTOMATICO, QUERY_SQL, CHECK_LIST, FLAG_TEMPLATE, ID_CHECK_LIST, CODE_METHOD, URL, VAL_MASSIMO, VAL_MINIMO, QUERY_SQL_POST, FASE_PROCEDURALE, ORDINE_FASE_PROCEDURALE, COD_FASE, MISURA, INCLUDI_VERBALE_VIS FROM vCHECKLIST WHERE 1=1';
	IF (@IdCheckListequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CHECK_LIST = @IdCheckListequalthis)'; set @lensql=@lensql+len(@IdCheckListequalthis);end;
	IF (@IdStepequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_STEP = @IdStepequalthis)'; set @lensql=@lensql+len(@IdStepequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE = @Ordineequalthis)'; set @lensql=@lensql+len(@Ordineequalthis);end;
	IF (@Obbligatorioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OBBLIGATORIO = @Obbligatorioequalthis)'; set @lensql=@lensql+len(@Obbligatorioequalthis);end;
	IF (@Pesoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PESO = @Pesoequalthis)'; set @lensql=@lensql+len(@Pesoequalthis);end;
	IF (@IncludiVerbaleVisequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (INCLUDI_VERBALE_VIS = @IncludiVerbaleVisequalthis)'; set @lensql=@lensql+len(@IncludiVerbaleVisequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdCheckListequalthis INT, @IdStepequalthis INT, @Ordineequalthis INT, @Obbligatorioequalthis BIT, @Pesoequalthis DECIMAL(10,2), @IncludiVerbaleVisequalthis BIT',@IdCheckListequalthis , @IdStepequalthis , @Ordineequalthis , @Obbligatorioequalthis , @Pesoequalthis , @IncludiVerbaleVisequalthis ;
	else
		SELECT ID_STEP, ORDINE, OBBLIGATORIO, PESO, STEP, AUTOMATICO, QUERY_SQL, CHECK_LIST, FLAG_TEMPLATE, ID_CHECK_LIST, CODE_METHOD, URL, VAL_MASSIMO, VAL_MINIMO, QUERY_SQL_POST, FASE_PROCEDURALE, ORDINE_FASE_PROCEDURALE, COD_FASE, MISURA, INCLUDI_VERBALE_VIS
		FROM vCHECKLIST
		WHERE 
			((@IdCheckListequalthis IS NULL) OR ID_CHECK_LIST = @IdCheckListequalthis) AND 
			((@IdStepequalthis IS NULL) OR ID_STEP = @IdStepequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis) AND 
			((@Obbligatorioequalthis IS NULL) OR OBBLIGATORIO = @Obbligatorioequalthis) AND 
			((@Pesoequalthis IS NULL) OR PESO = @Pesoequalthis) AND 
			((@IncludiVerbaleVisequalthis IS NULL) OR INCLUDI_VERBALE_VIS = @IncludiVerbaleVisequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZCheckListXStepFindSelect]
(
	@IdCheckListequalthis INT, 
	@IdStepequalthis INT, 
	@Ordineequalthis INT, 
	@Obbligatorioequalthis BIT, 
	@Pesoequalthis DECIMAL(10,2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_STEP, ORDINE, OBBLIGATORIO, PESO, STEP, AUTOMATICO, QUERY_SQL, CHECK_LIST, FLAG_TEMPLATE, ID_CHECK_LIST, CODE_METHOD, URL, VAL_MASSIMO, VAL_MINIMO, QUERY_SQL_POST, FASE_PROCEDURALE, ORDINE_FASE_PROCEDURALE, COD_FASE, MISURA FROM vCHECKLIST WHERE 1=1'';
	IF (@IdCheckListequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_CHECK_LIST = @IdCheckListequalthis)''; set @lensql=@lensql+len(@IdCheckListequalthis);end;
	IF (@IdStepequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_STEP = @IdStepequalthis)''; set @lensql=@lensql+len(@IdStepequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ORDINE = @Ordineequalthis)''; set @lensql=@lensql+len(@Ordineequalthis);end;
	IF (@Obbligatorioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (OBBLIGATORIO = @Obbligatorioequalthis)''; set @lensql=@lensql+len(@Obbligatorioequalthis);end;
	IF (@Pesoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PESO = @Pesoequalthis)''; set @lensql=@lensql+len(@Pesoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdCheckListequalthis INT, @IdStepequalthis INT, @Ordineequalthis INT, @Obbligatorioequalthis BIT, @Pesoequalthis DECIMAL(10,2)'',@IdCheckListequalthis , @IdStepequalthis , @Ordineequalthis , @Obbligatorioequalthis , @Pesoequalthis ;
	else
		SELECT ID_STEP, ORDINE, OBBLIGATORIO, PESO, STEP, AUTOMATICO, QUERY_SQL, CHECK_LIST, FLAG_TEMPLATE, ID_CHECK_LIST, CODE_METHOD, URL, VAL_MASSIMO, VAL_MINIMO, QUERY_SQL_POST, FASE_PROCEDURALE, ORDINE_FASE_PROCEDURALE, COD_FASE, MISURA
		FROM vCHECKLIST
		WHERE 
			((@IdCheckListequalthis IS NULL) OR ID_CHECK_LIST = @IdCheckListequalthis) AND 
			((@IdStepequalthis IS NULL) OR ID_STEP = @IdStepequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis) AND 
			((@Obbligatorioequalthis IS NULL) OR OBBLIGATORIO = @Obbligatorioequalthis) AND 
			((@Pesoequalthis IS NULL) OR PESO = @Pesoequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCheckListXStepFindSelect';

