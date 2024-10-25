CREATE PROCEDURE [dbo].[ZCatalogoDichiarazioniFindFind]
(
	@IdDichiarazioneequalthis INT, 
	@Misuralikethis VARCHAR(10), 
	@Descrizionelikethis VARCHAR(1000)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_DICHIARAZIONE, DESCRIZIONE, MISURA FROM CATALOGO_DICHIARAZIONI WHERE 1=1';
	IF (@IdDichiarazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DICHIARAZIONE = @IdDichiarazioneequalthis)'; set @lensql=@lensql+len(@IdDichiarazioneequalthis);end;
	IF (@Misuralikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MISURA LIKE @Misuralikethis)'; set @lensql=@lensql+len(@Misuralikethis);end;
	IF (@Descrizionelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE LIKE @Descrizionelikethis)'; set @lensql=@lensql+len(@Descrizionelikethis);end;
	set @sql = @sql + 'ORDER BY ID_DICHIARAZIONE';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdDichiarazioneequalthis INT, @Misuralikethis VARCHAR(10), @Descrizionelikethis VARCHAR(1000)',@IdDichiarazioneequalthis , @Misuralikethis , @Descrizionelikethis ;
	else
		SELECT ID_DICHIARAZIONE, DESCRIZIONE, MISURA
		FROM CATALOGO_DICHIARAZIONI
		WHERE 
			((@IdDichiarazioneequalthis IS NULL) OR ID_DICHIARAZIONE = @IdDichiarazioneequalthis) AND 
			((@Misuralikethis IS NULL) OR MISURA LIKE @Misuralikethis) AND 
			((@Descrizionelikethis IS NULL) OR DESCRIZIONE LIKE @Descrizionelikethis)
		ORDER BY ID_DICHIARAZIONE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZCatalogoDichiarazioniFindFind]
(
	@IdDichiarazioneequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_DICHIARAZIONE, DESCRIZIONE, MISURA FROM CATALOGO_DICHIARAZIONI WHERE 1=1'';
	IF (@IdDichiarazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DICHIARAZIONE = @IdDichiarazioneequalthis)''; set @lensql=@lensql+len(@IdDichiarazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdDichiarazioneequalthis INT'',@IdDichiarazioneequalthis ;
	else
		SELECT ID_DICHIARAZIONE, DESCRIZIONE, MISURA
		FROM CATALOGO_DICHIARAZIONI
		WHERE 
			((@IdDichiarazioneequalthis IS NULL) OR ID_DICHIARAZIONE = @IdDichiarazioneequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCatalogoDichiarazioniFindFind';

