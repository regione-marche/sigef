CREATE PROCEDURE [dbo].[ZZquerySqlFindFind]
(
	@Nomelikethis NVARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, NOME, TESTO FROM zQUERY_SQL WHERE 1=1';
	IF (@Nomelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOME LIKE @Nomelikethis)'; set @lensql=@lensql+len(@Nomelikethis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Nomelikethis NVARCHAR(255)',@Nomelikethis ;
	else
		SELECT ID, NOME, TESTO
		FROM zQUERY_SQL
		WHERE 
			((@Nomelikethis IS NULL) OR NOME LIKE @Nomelikethis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZquerySqlFindFind';

