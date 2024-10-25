CREATE PROCEDURE [dbo].[ZNoteFindSelect]
(
	@Idequalthis INT, 
	@Testoequalthis NVARCHAR
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, TESTO FROM NOTE WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@Testoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TESTO = @Testoequalthis)'; set @lensql=@lensql+len(@Testoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @Testoequalthis NVARCHAR',@Idequalthis , @Testoequalthis ;
	else
		SELECT ID, TESTO
		FROM NOTE
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@Testoequalthis IS NULL) OR TESTO = @Testoequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZNoteFindSelect]
(
	@Idequalthis INT, 
	@Testoequalthis NVARCHAR
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, TESTO FROM NOTE WHERE 1=1'';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID = @Idequalthis)''; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@Testoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TESTO = @Testoequalthis)''; set @lensql=@lensql+len(@Testoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@Idequalthis INT, @Testoequalthis NVARCHAR'',@Idequalthis , @Testoequalthis ;
	else
		SELECT ID, TESTO
		FROM NOTE
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@Testoequalthis IS NULL) OR TESTO = @Testoequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZNoteFindSelect';

