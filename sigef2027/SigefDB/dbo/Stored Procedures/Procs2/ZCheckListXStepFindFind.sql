CREATE PROCEDURE [dbo].[ZCheckListXStepFindFind]
(
	@IdCheckListequalthis INT, 
	@IdStepequalthis INT, 
	@FlagTemplateequalthis BIT, 
	@Ordineequalthis INT, 
	@Obbligatorioequalthis BIT, 
	@Automaticoequalthis BIT, 
	@CodFaseequalthis CHAR(1)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_STEP, ORDINE, OBBLIGATORIO, PESO, STEP, AUTOMATICO, QUERY_SQL, CHECK_LIST, FLAG_TEMPLATE, ID_CHECK_LIST, CODE_METHOD, URL, VAL_MASSIMO, VAL_MINIMO, QUERY_SQL_POST, FASE_PROCEDURALE, ORDINE_FASE_PROCEDURALE, COD_FASE, MISURA, INCLUDI_VERBALE_VIS FROM vCHECKLIST WHERE 1=1';
	IF (@IdCheckListequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CHECK_LIST = @IdCheckListequalthis)'; set @lensql=@lensql+len(@IdCheckListequalthis);end;
	IF (@IdStepequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_STEP = @IdStepequalthis)'; set @lensql=@lensql+len(@IdStepequalthis);end;
	IF (@FlagTemplateequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FLAG_TEMPLATE = @FlagTemplateequalthis)'; set @lensql=@lensql+len(@FlagTemplateequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE = @Ordineequalthis)'; set @lensql=@lensql+len(@Ordineequalthis);end;
	IF (@Obbligatorioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OBBLIGATORIO = @Obbligatorioequalthis)'; set @lensql=@lensql+len(@Obbligatorioequalthis);end;
	IF (@Automaticoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AUTOMATICO = @Automaticoequalthis)'; set @lensql=@lensql+len(@Automaticoequalthis);end;
	IF (@CodFaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_FASE = @CodFaseequalthis)'; set @lensql=@lensql+len(@CodFaseequalthis);end;
	set @sql = @sql + 'ORDER BY ORDINE';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdCheckListequalthis INT, @IdStepequalthis INT, @FlagTemplateequalthis BIT, @Ordineequalthis INT, @Obbligatorioequalthis BIT, @Automaticoequalthis BIT, @CodFaseequalthis CHAR(1)',@IdCheckListequalthis , @IdStepequalthis , @FlagTemplateequalthis , @Ordineequalthis , @Obbligatorioequalthis , @Automaticoequalthis , @CodFaseequalthis ;
	else
		SELECT ID_STEP, ORDINE, OBBLIGATORIO, PESO, STEP, AUTOMATICO, QUERY_SQL, CHECK_LIST, FLAG_TEMPLATE, ID_CHECK_LIST, CODE_METHOD, URL, VAL_MASSIMO, VAL_MINIMO, QUERY_SQL_POST, FASE_PROCEDURALE, ORDINE_FASE_PROCEDURALE, COD_FASE, MISURA, INCLUDI_VERBALE_VIS
		FROM vCHECKLIST
		WHERE 
			((@IdCheckListequalthis IS NULL) OR ID_CHECK_LIST = @IdCheckListequalthis) AND 
			((@IdStepequalthis IS NULL) OR ID_STEP = @IdStepequalthis) AND 
			((@FlagTemplateequalthis IS NULL) OR FLAG_TEMPLATE = @FlagTemplateequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis) AND 
			((@Obbligatorioequalthis IS NULL) OR OBBLIGATORIO = @Obbligatorioequalthis) AND 
			((@Automaticoequalthis IS NULL) OR AUTOMATICO = @Automaticoequalthis) AND 
			((@CodFaseequalthis IS NULL) OR COD_FASE = @CodFaseequalthis)
		ORDER BY ORDINE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZCheckListXStepFindFind]
(
	@IdCheckListequalthis INT, 
	@IdStepequalthis INT, 
	@FlagTemplateequalthis BIT, 
	@Ordineequalthis INT, 
	@Obbligatorioequalthis BIT, 
	@Automaticoequalthis BIT, 
	@CodFaseequalthis CHAR(1)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_STEP, ORDINE, OBBLIGATORIO, PESO, STEP, AUTOMATICO, QUERY_SQL, CHECK_LIST, FLAG_TEMPLATE, ID_CHECK_LIST, CODE_METHOD, URL, VAL_MASSIMO, VAL_MINIMO, QUERY_SQL_POST, FASE_PROCEDURALE, ORDINE_FASE_PROCEDURALE, COD_FASE, MISURA FROM vCHECKLIST WHERE 1=1'';
	IF (@IdCheckListequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_CHECK_LIST = @IdCheckListequalthis)''; set @lensql=@lensql+len(@IdCheckListequalthis);end;
	IF (@IdStepequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_STEP = @IdStepequalthis)''; set @lensql=@lensql+len(@IdStepequalthis);end;
	IF (@FlagTemplateequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (FLAG_TEMPLATE = @FlagTemplateequalthis)''; set @lensql=@lensql+len(@FlagTemplateequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ORDINE = @Ordineequalthis)''; set @lensql=@lensql+len(@Ordineequalthis);end;
	IF (@Obbligatorioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (OBBLIGATORIO = @Obbligatorioequalthis)''; set @lensql=@lensql+len(@Obbligatorioequalthis);end;
	IF (@Automaticoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (AUTOMATICO = @Automaticoequalthis)''; set @lensql=@lensql+len(@Automaticoequalthis);end;
	IF (@CodFaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_FASE = @CodFaseequalthis)''; set @lensql=@lensql+len(@CodFaseequalthis);end;
	set @sql = @sql + ''ORDER BY ORDINE'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdCheckListequalthis INT, @IdStepequalthis INT, @FlagTemplateequalthis BIT, @Ordineequalthis INT, @Obbligatorioequalthis BIT, @Automaticoequalthis BIT, @CodFaseequalthis CHAR(1)'',@IdCheckListequalthis , @IdStepequalthis , @FlagTemplateequalthis , @Ordineequalthis , @Obbligatorioequalthis , @Automaticoequalthis , @CodFaseequalthis ;
	else
		SELECT ID_STEP, ORDINE, OBBLIGATORIO, PESO, STEP, AUTOMATICO, QUERY_SQL, CHECK_LIST, FLAG_TEMPLATE, ID_CHECK_LIST, CODE_METHOD, URL, VAL_MASSIMO, VAL_MINIMO, QUERY_SQL_POST, FASE_PROCEDURALE, ORDINE_FASE_PROCEDURALE, COD_FASE, MISURA
		FROM vCHECKLIST
		WHERE 
			((@IdCheckListequalthis IS NULL) OR ID_CHECK_LIST = @IdCheckListequalthis) AND 
			((@IdStepequalthis IS NULL) OR ID_STEP = @IdStepequalthis) AND 
			((@FlagTemplateequalthis IS NULL) OR FLAG_TEMPLATE = @FlagTemplateequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis) AND 
			((@Obbligatorioequalthis IS NULL) OR OBBLIGATORIO = @Obbligatorioequalthis) AND 
			((@Automaticoequalthis IS NULL) OR AUTOMATICO = @Automaticoequalthis) AND 
			((@CodFaseequalthis IS NULL) OR COD_FASE = @CodFaseequalthis)
		ORDER BY ORDINE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCheckListXStepFindFind';

