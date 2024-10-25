CREATE PROCEDURE [dbo].[ZTipoRataFindFind]
(
	@Descrizionelikethis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_TIPO_RATA, DESCRIZIONE FROM VTIPO_RATA WHERE 1=1';
	IF (@Descrizionelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE LIKE @Descrizionelikethis)'; set @lensql=@lensql+len(@Descrizionelikethis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Descrizionelikethis VARCHAR(255)',@Descrizionelikethis ;
	else
		SELECT ID_TIPO_RATA, DESCRIZIONE
		FROM VTIPO_RATA
		WHERE 
			((@Descrizionelikethis IS NULL) OR DESCRIZIONE LIKE @Descrizionelikethis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTipoRataFindFind';

