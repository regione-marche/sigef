CREATE PROCEDURE [dbo].[ZCatalogoDichiarazioniFindSelect]
(
	@IdDichiarazioneequalthis INT, 
	@Descrizioneequalthis VARCHAR(1000), 
	@Misuraequalthis VARCHAR(10)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_DICHIARAZIONE, DESCRIZIONE, MISURA FROM CATALOGO_DICHIARAZIONI WHERE 1=1';
	IF (@IdDichiarazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DICHIARAZIONE = @IdDichiarazioneequalthis)'; set @lensql=@lensql+len(@IdDichiarazioneequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@Misuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MISURA = @Misuraequalthis)'; set @lensql=@lensql+len(@Misuraequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdDichiarazioneequalthis INT, @Descrizioneequalthis VARCHAR(1000), @Misuraequalthis VARCHAR(10)',@IdDichiarazioneequalthis , @Descrizioneequalthis , @Misuraequalthis ;
	else
		SELECT ID_DICHIARAZIONE, DESCRIZIONE, MISURA
		FROM CATALOGO_DICHIARAZIONI
		WHERE 
			((@IdDichiarazioneequalthis IS NULL) OR ID_DICHIARAZIONE = @IdDichiarazioneequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@Misuraequalthis IS NULL) OR MISURA = @Misuraequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZCatalogoDichiarazioniFindSelect]
(
	@IdDichiarazioneequalthis INT, 
	@Descrizioneequalthis VARCHAR(1000), 
	@Misuraequalthis VARCHAR(10)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_DICHIARAZIONE, DESCRIZIONE, MISURA FROM CATALOGO_DICHIARAZIONI WHERE 1=1'';
	IF (@IdDichiarazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DICHIARAZIONE = @IdDichiarazioneequalthis)''; set @lensql=@lensql+len(@IdDichiarazioneequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE = @Descrizioneequalthis)''; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@Misuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (MISURA = @Misuraequalthis)''; set @lensql=@lensql+len(@Misuraequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdDichiarazioneequalthis INT, @Descrizioneequalthis VARCHAR(1000), @Misuraequalthis VARCHAR(10)'',@IdDichiarazioneequalthis , @Descrizioneequalthis , @Misuraequalthis ;
	else
		SELECT ID_DICHIARAZIONE, DESCRIZIONE, MISURA
		FROM CATALOGO_DICHIARAZIONI
		WHERE 
			((@IdDichiarazioneequalthis IS NULL) OR ID_DICHIARAZIONE = @IdDichiarazioneequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@Misuraequalthis IS NULL) OR MISURA = @Misuraequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCatalogoDichiarazioniFindSelect';

