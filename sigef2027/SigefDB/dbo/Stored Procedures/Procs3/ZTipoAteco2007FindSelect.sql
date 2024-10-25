CREATE PROCEDURE [dbo].[ZTipoAteco2007FindSelect]
(
	@CodTipoAteco2007equalthis VARCHAR(255), 
	@Sezioneequalthis VARCHAR(255), 
	@Divisioneequalthis VARCHAR(255), 
	@Gruppoequalthis VARCHAR(255), 
	@Classeequalthis VARCHAR(255), 
	@Categoriaequalthis VARCHAR(255), 
	@Sottocategoriaequalthis VARCHAR(255), 
	@Descrizioneequalthis NVARCHAR(255), 
	@Eliminatoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT COD_TIPO_ATECO2007, Sezione, Divisione, Classe, Gruppo, Categoria, Sottocategoria, Descrizione, ELIMINATO FROM vTIPO_ATECO2007 WHERE 1=1';
	IF (@CodTipoAteco2007equalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_ATECO2007 = @CodTipoAteco2007equalthis)'; set @lensql=@lensql+len(@CodTipoAteco2007equalthis);end;
	IF (@Sezioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Sezione = @Sezioneequalthis)'; set @lensql=@lensql+len(@Sezioneequalthis);end;
	IF (@Divisioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Divisione = @Divisioneequalthis)'; set @lensql=@lensql+len(@Divisioneequalthis);end;
	IF (@Gruppoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Gruppo = @Gruppoequalthis)'; set @lensql=@lensql+len(@Gruppoequalthis);end;
	IF (@Classeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Classe = @Classeequalthis)'; set @lensql=@lensql+len(@Classeequalthis);end;
	IF (@Categoriaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Categoria = @Categoriaequalthis)'; set @lensql=@lensql+len(@Categoriaequalthis);end;
	IF (@Sottocategoriaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Sottocategoria = @Sottocategoriaequalthis)'; set @lensql=@lensql+len(@Sottocategoriaequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Descrizione = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@Eliminatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ELIMINATO = @Eliminatoequalthis)'; set @lensql=@lensql+len(@Eliminatoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodTipoAteco2007equalthis VARCHAR(255), @Sezioneequalthis VARCHAR(255), @Divisioneequalthis VARCHAR(255), @Gruppoequalthis VARCHAR(255), @Classeequalthis VARCHAR(255), @Categoriaequalthis VARCHAR(255), @Sottocategoriaequalthis VARCHAR(255), @Descrizioneequalthis NVARCHAR(255), @Eliminatoequalthis BIT',@CodTipoAteco2007equalthis , @Sezioneequalthis , @Divisioneequalthis , @Gruppoequalthis , @Classeequalthis , @Categoriaequalthis , @Sottocategoriaequalthis , @Descrizioneequalthis , @Eliminatoequalthis ;
	else
		SELECT COD_TIPO_ATECO2007, Sezione, Divisione, Classe, Gruppo, Categoria, Sottocategoria, Descrizione, ELIMINATO
		FROM vTIPO_ATECO2007
		WHERE 
			((@CodTipoAteco2007equalthis IS NULL) OR COD_TIPO_ATECO2007 = @CodTipoAteco2007equalthis) AND 
			((@Sezioneequalthis IS NULL) OR Sezione = @Sezioneequalthis) AND 
			((@Divisioneequalthis IS NULL) OR Divisione = @Divisioneequalthis) AND 
			((@Gruppoequalthis IS NULL) OR Gruppo = @Gruppoequalthis) AND 
			((@Classeequalthis IS NULL) OR Classe = @Classeequalthis) AND 
			((@Categoriaequalthis IS NULL) OR Categoria = @Categoriaequalthis) AND 
			((@Sottocategoriaequalthis IS NULL) OR Sottocategoria = @Sottocategoriaequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR Descrizione = @Descrizioneequalthis) AND 
			((@Eliminatoequalthis IS NULL) OR ELIMINATO = @Eliminatoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTipoAteco2007FindSelect';

