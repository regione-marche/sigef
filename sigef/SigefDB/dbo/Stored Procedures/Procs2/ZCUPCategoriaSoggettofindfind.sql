




CREATE PROCEDURE [dbo].[ZCUPCategoriaSoggettofindfind]
(
	@IdCUPCategoriaSoggettoEqualThis char(6), 
	@Descrizionelikethis varchar(500)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT COD_CUP_CATEGORIE_SOGGETTI, CodiceCategoria, CodiceSottocategoria, Descrizione FROM TIPO_CUP_CATEGORIE_SOGGETTI WHERE 1=1';
	IF (@IdCUPCategoriaSoggettoEqualThis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_CUP_CATEGORIE_SOGGETTI = @IdCUPCategoriaSoggettoEqualThis)'; set @lensql=@lensql+len(@IdCUPCategoriaSoggettoEqualThis);end;
	IF (@Descrizionelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Descrizione Like @Descrizionelikethis)'; set @lensql=@lensql+len(@Descrizionelikethis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
  	  exec sp_executesql @sql,N'@IdCUPCategoriaSoggettoEqualThis INT, @Descrizionelikethis varchar(255)',@IdCUPCategoriaSoggettoEqualThis, @Descrizionelikethis;
	else
		SELECT COD_CUP_CATEGORIE_SOGGETTI, CodiceCategoria, CodiceSottocategoria, Descrizione FROM TIPO_CUP_CATEGORIE_SOGGETTI
		WHERE 
			((@IdCUPCategoriaSoggettoEqualThis IS NULL) OR COD_CUP_CATEGORIE_SOGGETTI = @IdCUPCategoriaSoggettoEqualThis) AND 
			((@Descrizionelikethis IS NULL) OR Descrizione Like @Descrizionelikethis)




