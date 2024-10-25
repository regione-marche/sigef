


CREATE PROCEDURE [dbo].[ZAteco2007findfind]
(
	@IdAteco2007StartWithThis VARCHAR(500), 
	@DescrizioneLikeThis VARCHAR(500),
	@idBandoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	declare @filtraAteco int;
	set @filtraAteco = (select COUNT(ID_ATECO2007) from BANDO_ATECO2007 where ID_BANDO=@idBandoequalthis);	
	if (@filtraAteco is null OR @filtraAteco = 0) SET @idBandoequalthis = null;
	
	SET @sql = 'SELECT COD_TIPO_ATECO2007, Sezione, Divisione, Gruppo, Classe, Categoria, Sottocategoria, Descrizione FROM TIPO_ATECO2007 ';
	IF (@idBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' INNER JOIN BANDO_ATECO2007 on TIPO_ATECO2007.COD_TIPO_ATECO2007 = BANDO_ATECO2007.ID_ATECO2007 ';end;
	SET @sql = @sql + ' WHERE 1=1';
	IF (@IdAteco2007StartWithThis IS NOT NULL) BEGIN 
		SET @sql = @sql + ' AND (COD_TIPO_ATECO2007 LIKE ''_' + @IdAteco2007StartWithThis + '%'')'; 
		set @lensql=@lensql+len(@IdAteco2007StartWithThis);
	end;
	IF (@Descrizionelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE LIKE ''%' + @Descrizionelikethis + '%'')'; set @lensql=@lensql+len(@Descrizionelikethis);end;
	IF (@idBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @idBandoequalthis)'; set @lensql=@lensql+len(@idBandoequalthis);end;
	set @sql = @sql + ' ORDER BY Sezione, Divisione, Gruppo, Classe, Categoria, Sottocategoria';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdAteco2007StartWithThis VARCHAR(500), @Descrizionelikethis VARCHAR(500), @idBandoequalthis INT',@IdAteco2007StartWithThis , @Descrizionelikethis, @idBandoequalthis;
	else
		SELECT COD_TIPO_ATECO2007, Sezione, Divisione, Gruppo, Classe, Categoria, Sottocategoria, Descrizione
		FROM TIPO_ATECO2007
		WHERE 
			((@IdAteco2007StartWithThis IS NULL) OR COD_TIPO_ATECO2007 Like @IdAteco2007StartWithThis + '%') AND 
			((@Descrizionelikethis IS NULL) OR DESCRIZIONE LIKE '%' + @Descrizionelikethis + '%')
		ORDER BY Sezione, Divisione, Gruppo, Classe, Categoria, Sottocategoria
	







