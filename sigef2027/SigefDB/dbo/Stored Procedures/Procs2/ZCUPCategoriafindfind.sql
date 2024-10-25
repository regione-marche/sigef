



CREATE PROCEDURE [dbo].[ZCUPCategoriafindfind]
(
	@IdCUPCategoriaequalthis char(7), 
	@Descrizionelikethis varchar(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT COD_CUP_CATEGORIE, Settore, Sottosettore, Categoria, Descrizione FROM TIPO_CUP_CATEGORIE WHERE 1=1';
	IF (@IdCUPCategoriaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_CUP_CATEGORIE = @IdCUPCategoriaequalthis)'; set @lensql=@lensql+len(@IdCUPCategoriaequalthis);end;
	IF (@Descrizionelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Descrizione Like @Descrizionelikethis)'; set @lensql=@lensql+len(@Descrizionelikethis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
  	  exec sp_executesql @sql,N'@IdCUPCategoriaequalthis INT, @Descrizionelikethis varchar(255)',@IdCUPCategoriaequalthis, @Descrizionelikethis;
	else
		SELECT COD_CUP_CATEGORIE, Settore, Sottosettore, Categoria, Descrizione
		FROM TIPO_CUP_CATEGORIE
		WHERE 
			((@IdCUPCategoriaequalthis IS NULL) OR COD_CUP_CATEGORIE = @IdCUPCategoriaequalthis) AND 
			((@Descrizionelikethis IS NULL) OR Descrizione Like @Descrizionelikethis)



