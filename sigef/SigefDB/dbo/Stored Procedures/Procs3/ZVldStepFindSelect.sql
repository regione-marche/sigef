CREATE PROCEDURE [dbo].[ZVldStepFindSelect]
(
	@Idequalthis INT, 
	@Descrizioneequalthis VARCHAR(500), 
	@Automaticoequalthis BIT, 
	@QuerySqlequalthis VARCHAR(3000), 
	@QuerySqlPostequalthis VARCHAR(300), 
	@CodeMethodequalthis VARCHAR(255), 
	@Urlequalthis VARCHAR(255), 
	@ValMinimoequalthis VARCHAR(255), 
	@ValMassimoequalthis VARCHAR(255), 
	@Misuraequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, DESCRIZIONE, AUTOMATICO, QUERY_SQL, QUERY_SQL_POST, CODE_METHOD, URL, VAL_MINIMO, VAL_MASSIMO, MISURA FROM VLD_STEP WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
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
	exec sp_executesql @sql,N'@Idequalthis INT, @Descrizioneequalthis VARCHAR(500), @Automaticoequalthis BIT, @QuerySqlequalthis VARCHAR(3000), @QuerySqlPostequalthis VARCHAR(300), @CodeMethodequalthis VARCHAR(255), @Urlequalthis VARCHAR(255), @ValMinimoequalthis VARCHAR(255), @ValMassimoequalthis VARCHAR(255), @Misuraequalthis VARCHAR(255)',@Idequalthis , @Descrizioneequalthis , @Automaticoequalthis , @QuerySqlequalthis , @QuerySqlPostequalthis , @CodeMethodequalthis , @Urlequalthis , @ValMinimoequalthis , @ValMassimoequalthis , @Misuraequalthis ;
	else
		SELECT ID, DESCRIZIONE, AUTOMATICO, QUERY_SQL, QUERY_SQL_POST, CODE_METHOD, URL, VAL_MINIMO, VAL_MASSIMO, MISURA
		FROM VLD_STEP
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@Automaticoequalthis IS NULL) OR AUTOMATICO = @Automaticoequalthis) AND 
			((@QuerySqlequalthis IS NULL) OR QUERY_SQL = @QuerySqlequalthis) AND 
			((@QuerySqlPostequalthis IS NULL) OR QUERY_SQL_POST = @QuerySqlPostequalthis) AND 
			((@CodeMethodequalthis IS NULL) OR CODE_METHOD = @CodeMethodequalthis) AND 
			((@Urlequalthis IS NULL) OR URL = @Urlequalthis) AND 
			((@ValMinimoequalthis IS NULL) OR VAL_MINIMO = @ValMinimoequalthis) AND 
			((@ValMassimoequalthis IS NULL) OR VAL_MASSIMO = @ValMassimoequalthis) AND 
			((@Misuraequalthis IS NULL) OR MISURA = @Misuraequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVldStepFindSelect';

