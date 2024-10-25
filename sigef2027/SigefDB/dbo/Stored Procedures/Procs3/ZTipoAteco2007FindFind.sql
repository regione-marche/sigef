CREATE PROCEDURE [dbo].[ZTipoAteco2007FindFind]
(
	@Sottocategorialikethis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT COD_TIPO_ATECO2007, Sezione, Divisione, Classe, Gruppo, Categoria, Sottocategoria, Descrizione, ELIMINATO FROM vTIPO_ATECO2007 WHERE 1=1';
	IF (@Sottocategorialikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Sottocategoria LIKE @Sottocategorialikethis)'; set @lensql=@lensql+len(@Sottocategorialikethis);end;
	set @sql = @sql + 'ORDER BY Sottocategoria';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Sottocategorialikethis VARCHAR(255)',@Sottocategorialikethis ;
	else
		SELECT COD_TIPO_ATECO2007, Sezione, Divisione, Classe, Gruppo, Categoria, Sottocategoria, Descrizione, ELIMINATO
		FROM vTIPO_ATECO2007
		WHERE 
			((@Sottocategorialikethis IS NULL) OR Sottocategoria LIKE @Sottocategorialikethis)
		ORDER BY Sottocategoria


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTipoAteco2007FindFind';

