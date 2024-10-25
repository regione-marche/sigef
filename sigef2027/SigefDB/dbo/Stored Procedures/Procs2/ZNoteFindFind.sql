CREATE PROCEDURE [dbo].[ZNoteFindFind]
(
	@Idequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, TESTO FROM NOTE WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT',@Idequalthis ;
	else
		SELECT ID, TESTO
		FROM NOTE
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZNoteFindFind]
(
	@Idequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, TESTO FROM NOTE WHERE 1=1'';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID = @Idequalthis)''; set @lensql=@lensql+len(@Idequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@Idequalthis INT'',@Idequalthis ;
	else
		SELECT ID, TESTO
		FROM NOTE
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZNoteFindFind';

