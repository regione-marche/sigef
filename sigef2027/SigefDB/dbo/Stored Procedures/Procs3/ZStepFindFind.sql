CREATE PROCEDURE [dbo].[ZStepFindFind]
(
	@IdStepequalthis INT, 
	@Automaticoequalthis BIT, 
	@CodFaseequalthis CHAR(1)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_STEP, DESCRIZIONE, AUTOMATICO, QUERY_SQL, CODE_METHOD, URL, VAL_MASSIMO, VAL_MINIMO, QUERY_SQL_POST, FASE_PROCEDURALE, ORDINE, COD_FASE, MISURA FROM vSTEP WHERE 1=1';
	IF (@IdStepequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_STEP = @IdStepequalthis)'; set @lensql=@lensql+len(@IdStepequalthis);end;
	IF (@Automaticoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AUTOMATICO = @Automaticoequalthis)'; set @lensql=@lensql+len(@Automaticoequalthis);end;
	IF (@CodFaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_FASE = @CodFaseequalthis)'; set @lensql=@lensql+len(@CodFaseequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdStepequalthis INT, @Automaticoequalthis BIT, @CodFaseequalthis CHAR(1)',@IdStepequalthis , @Automaticoequalthis , @CodFaseequalthis ;
	else
		SELECT ID_STEP, DESCRIZIONE, AUTOMATICO, QUERY_SQL, CODE_METHOD, URL, VAL_MASSIMO, VAL_MINIMO, QUERY_SQL_POST, FASE_PROCEDURALE, ORDINE, COD_FASE, MISURA
		FROM vSTEP
		WHERE 
			((@IdStepequalthis IS NULL) OR ID_STEP = @IdStepequalthis) AND 
			((@Automaticoequalthis IS NULL) OR AUTOMATICO = @Automaticoequalthis) AND 
			((@CodFaseequalthis IS NULL) OR COD_FASE = @CodFaseequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZStepFindFind]
(
	@IdStepequalthis INT, 
	@Automaticoequalthis BIT, 
	@CodFaseequalthis CHAR(1)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_STEP, DESCRIZIONE, AUTOMATICO, QUERY_SQL, CODE_METHOD, URL, VAL_MASSIMO, VAL_MINIMO, QUERY_SQL_POST, FASE_PROCEDURALE, ORDINE, COD_FASE, MISURA FROM vSTEP WHERE 1=1'';
	IF (@IdStepequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_STEP = @IdStepequalthis)''; set @lensql=@lensql+len(@IdStepequalthis);end;
	IF (@Automaticoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (AUTOMATICO = @Automaticoequalthis)''; set @lensql=@lensql+len(@Automaticoequalthis);end;
	IF (@CodFaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_FASE = @CodFaseequalthis)''; set @lensql=@lensql+len(@CodFaseequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdStepequalthis INT, @Automaticoequalthis BIT, @CodFaseequalthis CHAR(1)'',@IdStepequalthis , @Automaticoequalthis , @CodFaseequalthis ;
	else
		SELECT ID_STEP, DESCRIZIONE, AUTOMATICO, QUERY_SQL, CODE_METHOD, URL, VAL_MASSIMO, VAL_MINIMO, QUERY_SQL_POST, FASE_PROCEDURALE, ORDINE, COD_FASE, MISURA
		FROM vSTEP
		WHERE 
			((@IdStepequalthis IS NULL) OR ID_STEP = @IdStepequalthis) AND 
			((@Automaticoequalthis IS NULL) OR AUTOMATICO = @Automaticoequalthis) AND 
			((@CodFaseequalthis IS NULL) OR COD_FASE = @CodFaseequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZStepFindFind';

