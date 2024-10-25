


CREATE PROCEDURE [dbo].[ZCUPCategoriaFindSelect]
(
	@IdCUPCategoriaequalthis char(7), 
	@Descrizioneequalthis varchar(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT COD_CUP_CATEGORIE, Settore, Sottosettore, Categoria, Descrizione FROM TIPO_CUP_CATEGORIE WHERE 1=1';
	IF (@IdCUPCategoriaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_CUP_CATEGORIE = @IdCUPCategoriaequalthis)'; set @lensql=@lensql+len(@IdCUPCategoriaequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Descrizione = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
  	  exec sp_executesql @sql,N'@IdCUPCategoriaequalthis INT, @Descrizioneequalthis varchar(255)',@IdCUPCategoriaequalthis, @Descrizioneequalthis;
	else
		SELECT COD_CUP_CATEGORIE, Settore, Sottosettore, Categoria, Descrizione
		FROM TIPO_CUP_CATEGORIE
		WHERE 
			((@IdCUPCategoriaequalthis IS NULL) OR COD_CUP_CATEGORIE = @IdCUPCategoriaequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR Descrizione = @Descrizioneequalthis)


