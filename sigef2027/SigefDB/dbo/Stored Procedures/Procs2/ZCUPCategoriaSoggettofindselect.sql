



CREATE PROCEDURE [dbo].ZCUPCategoriaSoggettofindselect
(
	@IdCUPCategoriaSoggettoequalthis char(6), 
	@Descrizioneequalthis varchar(500)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT COD_CUP_CATEGORIE_SOGGETTI, CodiceCategoria, CodiceSottocategoria, Descrizione FROM TIPO_CUP_CATEGORIE_SOGGETTI WHERE 1=1';
	IF (@IdCUPCategoriaSoggettoEqualThis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_CUP_CATEGORIE_SOGGETTI = @IdCUPCategoriaSoggettoEqualThis)'; set @lensql=@lensql+len(@IdCUPCategoriaSoggettoEqualThis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Descrizione = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
  	  exec sp_executesql @sql,N'@IdCUPCategoriaSoggettoEqualThis INT, @Descrizioneequalthis varchar(255)',@IdCUPCategoriaSoggettoEqualThis, @Descrizioneequalthis;
	else
		SELECT COD_CUP_CATEGORIE_SOGGETTI, CodiceCategoria, CodiceSottocategoria, Descrizione FROM TIPO_CUP_CATEGORIE_SOGGETTI
		WHERE 
			((@IdCUPCategoriaSoggettoEqualThis IS NULL) OR COD_CUP_CATEGORIE_SOGGETTI = @IdCUPCategoriaSoggettoEqualThis) AND 
			((@Descrizioneequalthis IS NULL) OR Descrizione = @Descrizioneequalthis)




