CREATE PROCEDURE [dbo].[ZArchivioFileFindSelect]
(
	@Idequalthis INT, 
	@Tipoequalthis VARCHAR(255), 
	@NomeFileequalthis VARCHAR(255), 
	@NomeCompletoequalthis VARCHAR(510), 
	@Dimensioneequalthis INT, 
	@HashCodeequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, TIPO, NOME_FILE, NOME_COMPLETO, CONTENUTO, DIMENSIONE, HASH_CODE FROM ARCHIVIO_FILE WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@Tipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIPO = @Tipoequalthis)'; set @lensql=@lensql+len(@Tipoequalthis);end;
	IF (@NomeFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOME_FILE = @NomeFileequalthis)'; set @lensql=@lensql+len(@NomeFileequalthis);end;
	IF (@NomeCompletoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOME_COMPLETO = @NomeCompletoequalthis)'; set @lensql=@lensql+len(@NomeCompletoequalthis);end;
	IF (@Dimensioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DIMENSIONE = @Dimensioneequalthis)'; set @lensql=@lensql+len(@Dimensioneequalthis);end;
	IF (@HashCodeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (HASH_CODE = @HashCodeequalthis)'; set @lensql=@lensql+len(@HashCodeequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @Tipoequalthis VARCHAR(255), @NomeFileequalthis VARCHAR(255), @NomeCompletoequalthis VARCHAR(510), @Dimensioneequalthis INT, @HashCodeequalthis VARCHAR(255)',@Idequalthis , @Tipoequalthis , @NomeFileequalthis , @NomeCompletoequalthis , @Dimensioneequalthis , @HashCodeequalthis ;
	else
		SELECT ID, TIPO, NOME_FILE, NOME_COMPLETO, CONTENUTO, DIMENSIONE, HASH_CODE
		FROM ARCHIVIO_FILE
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@Tipoequalthis IS NULL) OR TIPO = @Tipoequalthis) AND 
			((@NomeFileequalthis IS NULL) OR NOME_FILE = @NomeFileequalthis) AND 
			((@NomeCompletoequalthis IS NULL) OR NOME_COMPLETO = @NomeCompletoequalthis) AND 
			((@Dimensioneequalthis IS NULL) OR DIMENSIONE = @Dimensioneequalthis) AND 
			((@HashCodeequalthis IS NULL) OR HASH_CODE = @HashCodeequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'
CREATE PROCEDURE [dbo].[ZArchivioFileFindSelect]
(
	@Idequalthis INT, 
	@Tipoequalthis VARCHAR(50), 
	@NomeFileequalthis VARCHAR(255), 
	@NomeCompletoequalthis VARCHAR(510), 
	@Dimensioneequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, TIPO, NOME_FILE, NOME_COMPLETO, CONTENUTO, DIMENSIONE FROM ARCHIVIO_FILE WHERE 1=1'';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID = @Idequalthis)''; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@Tipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TIPO = @Tipoequalthis)''; set @lensql=@lensql+len(@Tipoequalthis);end;
	IF (@NomeFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (NOME_FILE = @NomeFileequalthis)''; set @lensql=@lensql+len(@NomeFileequalthis);end;
	IF (@NomeCompletoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (NOME_COMPLETO = @NomeCompletoequalthis)''; set @lensql=@lensql+len(@NomeCompletoequalthis);end;
	IF (@Dimensioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DIMENSIONE = @Dimensioneequalthis)''; set @lensql=@lensql+len(@Dimensioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@Idequalthis INT, @Tipoequalthis VARCHAR(50), @NomeFileequalthis VARCHAR(255), @NomeCompletoequalthis VARCHAR(510), @Dimensioneequalthis INT'',@Idequalthis , @Tipoequalthis , @NomeFileequalthis , @NomeCompletoequalthis , @Dimensioneequalthis ;
	else
		SELECT ID, TIPO, NOME_FILE, NOME_COMPLETO, CONTENUTO, DIMENSIONE
		FROM ARCHIVIO_FILE
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@Tipoequalthis IS NULL) OR TIPO = @Tipoequalthis) AND 
			((@NomeFileequalthis IS NULL) OR NOME_FILE = @NomeFileequalthis) AND 
			((@NomeCompletoequalthis IS NULL) OR NOME_COMPLETO = @NomeCompletoequalthis) AND 
			((@Dimensioneequalthis IS NULL) OR DIMENSIONE = @Dimensioneequalthis)
		


', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZArchivioFileFindSelect';

