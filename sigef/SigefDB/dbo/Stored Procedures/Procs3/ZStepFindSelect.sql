CREATE PROCEDURE [dbo].[ZStepFindSelect]
(
	@IdStepequalthis INT, 
	@CodFaseequalthis CHAR(1), 
	@Descrizioneequalthis VARCHAR(255), 
	@Automaticoequalthis BIT, 
	@QuerySqlequalthis VARCHAR(3000), 
	@QuerySqlPostequalthis VARCHAR(300), 
	@CodeMethodequalthis VARCHAR(30), 
	@Urlequalthis VARCHAR(100), 
	@ValMinimoequalthis VARCHAR(20), 
	@ValMassimoequalthis VARCHAR(20), 
	@Misuraequalthis VARCHAR(20)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_STEP, DESCRIZIONE, AUTOMATICO, QUERY_SQL, CODE_METHOD, URL, VAL_MASSIMO, VAL_MINIMO, QUERY_SQL_POST, FASE_PROCEDURALE, ORDINE, COD_FASE, MISURA FROM vSTEP WHERE 1=1';
	IF (@IdStepequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_STEP = @IdStepequalthis)'; set @lensql=@lensql+len(@IdStepequalthis);end;
	IF (@CodFaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_FASE = @CodFaseequalthis)'; set @lensql=@lensql+len(@CodFaseequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@Automaticoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AUTOMATICO = @Automaticoequalthis)'; set @lensql=@lensql+len(@Automaticoequalthis);end;
	IF (@QuerySqlequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUERY_SQL = @QuerySqlequalthis)'; set @lensql=@lensql+len(@QuerySqlequalthis);end;
	IF (@QuerySqlPostequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUERY_SQL_POST = @QuerySqlPostequalthis)'; set @lensql=@lensql+len(@QuerySqlPostequalthis);end;
	IF (@CodeMethodequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODE_METHOD = @CodeMethodequalthis)'; set @lensql=@lensql+len(@CodeMethodequalthis);end;
	IF (@Urlequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (URL = @Urlequalthis)'; set @lensql=@lensql+len(@Urlequalthis);end;
	IF (@ValMinimoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VAL_MINIMO = @ValMinimoequalthis)'; set @lensql=@lensql+len(@ValMinimoequalthis);end;
	IF (@ValMassimoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VAL_MASSIMO = @ValMassimoequalthis)'; set @lensql=@lensql+len(@ValMassimoequalthis);end;
	IF (@Misuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MISURA = @Misuraequalthis)'; set @lensql=@lensql+len(@Misuraequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdStepequalthis INT, @CodFaseequalthis CHAR(1), @Descrizioneequalthis VARCHAR(255), @Automaticoequalthis BIT, @QuerySqlequalthis VARCHAR(3000), @QuerySqlPostequalthis VARCHAR(300), @CodeMethodequalthis VARCHAR(30), @Urlequalthis VARCHAR(100), @ValMinimoequalthis VARCHAR(20), @ValMassimoequalthis VARCHAR(20), @Misuraequalthis VARCHAR(20)',@IdStepequalthis , @CodFaseequalthis , @Descrizioneequalthis , @Automaticoequalthis , @QuerySqlequalthis , @QuerySqlPostequalthis , @CodeMethodequalthis , @Urlequalthis , @ValMinimoequalthis , @ValMassimoequalthis , @Misuraequalthis ;
	else
		SELECT ID_STEP, DESCRIZIONE, AUTOMATICO, QUERY_SQL, CODE_METHOD, URL, VAL_MASSIMO, VAL_MINIMO, QUERY_SQL_POST, FASE_PROCEDURALE, ORDINE, COD_FASE, MISURA
		FROM vSTEP
		WHERE 
			((@IdStepequalthis IS NULL) OR ID_STEP = @IdStepequalthis) AND 
			((@CodFaseequalthis IS NULL) OR COD_FASE = @CodFaseequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@Automaticoequalthis IS NULL) OR AUTOMATICO = @Automaticoequalthis) AND 
			((@QuerySqlequalthis IS NULL) OR QUERY_SQL = @QuerySqlequalthis) AND 
			((@QuerySqlPostequalthis IS NULL) OR QUERY_SQL_POST = @QuerySqlPostequalthis) AND 
			((@CodeMethodequalthis IS NULL) OR CODE_METHOD = @CodeMethodequalthis) AND 
			((@Urlequalthis IS NULL) OR URL = @Urlequalthis) AND 
			((@ValMinimoequalthis IS NULL) OR VAL_MINIMO = @ValMinimoequalthis) AND 
			((@ValMassimoequalthis IS NULL) OR VAL_MASSIMO = @ValMassimoequalthis) AND 
			((@Misuraequalthis IS NULL) OR MISURA = @Misuraequalthis)
