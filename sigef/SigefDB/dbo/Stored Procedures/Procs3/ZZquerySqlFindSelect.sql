CREATE PROCEDURE [dbo].[ZZquerySqlFindSelect]
(
	@Idequalthis INT, 
	@Nomeequalthis NVARCHAR(255), 
	@Testoequalthis NVARCHAR(max)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, NOME, TESTO FROM zQUERY_SQL WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@Nomeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOME = @Nomeequalthis)'; set @lensql=@lensql+len(@Nomeequalthis);end;
	IF (@Testoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TESTO = @Testoequalthis)'; set @lensql=@lensql+len(@Testoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @Nomeequalthis NVARCHAR(255), @Testoequalthis NVARCHAR(max)',@Idequalthis , @Nomeequalthis , @Testoequalthis ;
	else
		SELECT ID, NOME, TESTO
		FROM zQUERY_SQL
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@Nomeequalthis IS NULL) OR NOME = @Nomeequalthis) AND 
			((@Testoequalthis IS NULL) OR TESTO = @Testoequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZquerySqlFindSelect';

