CREATE PROCEDURE [dbo].[ZTipoRataFindSelect]
(
	@IdTipoRataequalthis INT, 
	@Descrizioneequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_TIPO_RATA, DESCRIZIONE FROM VTIPO_RATA WHERE 1=1';
	IF (@IdTipoRataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_TIPO_RATA = @IdTipoRataequalthis)'; set @lensql=@lensql+len(@IdTipoRataequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdTipoRataequalthis INT, @Descrizioneequalthis VARCHAR(255)',@IdTipoRataequalthis , @Descrizioneequalthis ;
	else
		SELECT ID_TIPO_RATA, DESCRIZIONE
		FROM VTIPO_RATA
		WHERE 
			((@IdTipoRataequalthis IS NULL) OR ID_TIPO_RATA = @IdTipoRataequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTipoRataFindSelect';

