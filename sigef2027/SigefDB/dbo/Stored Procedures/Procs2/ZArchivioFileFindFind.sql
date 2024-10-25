CREATE PROCEDURE [dbo].[ZArchivioFileFindFind]
(
	@Tipolikethis VARCHAR(255), 
	@NomeFilelikethis VARCHAR(255), 
	@HashCodeequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, TIPO, NOME_FILE, NOME_COMPLETO, CONTENUTO, DIMENSIONE, HASH_CODE FROM ARCHIVIO_FILE WHERE 1=1';
	IF (@Tipolikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIPO LIKE @Tipolikethis)'; set @lensql=@lensql+len(@Tipolikethis);end;
	IF (@NomeFilelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOME_FILE LIKE @NomeFilelikethis)'; set @lensql=@lensql+len(@NomeFilelikethis);end;
	IF (@HashCodeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (HASH_CODE = @HashCodeequalthis)'; set @lensql=@lensql+len(@HashCodeequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Tipolikethis VARCHAR(255), @NomeFilelikethis VARCHAR(255), @HashCodeequalthis VARCHAR(255)',@Tipolikethis , @NomeFilelikethis , @HashCodeequalthis ;
	else
		SELECT ID, TIPO, NOME_FILE, NOME_COMPLETO, CONTENUTO, DIMENSIONE, HASH_CODE
		FROM ARCHIVIO_FILE
		WHERE 
			((@Tipolikethis IS NULL) OR TIPO LIKE @Tipolikethis) AND 
			((@NomeFilelikethis IS NULL) OR NOME_FILE LIKE @NomeFilelikethis) AND 
			((@HashCodeequalthis IS NULL) OR HASH_CODE = @HashCodeequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'
CREATE PROCEDURE [dbo].[ZArchivioFileFindFind]
(
	@Tipolikethis VARCHAR(50), 
	@NomeFilelikethis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, TIPO, NOME_FILE, NOME_COMPLETO, CONTENUTO, DIMENSIONE FROM ARCHIVIO_FILE WHERE 1=1'';
	IF (@Tipolikethis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TIPO LIKE @Tipolikethis)''; set @lensql=@lensql+len(@Tipolikethis);end;
	IF (@NomeFilelikethis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (NOME_FILE LIKE @NomeFilelikethis)''; set @lensql=@lensql+len(@NomeFilelikethis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@Tipolikethis VARCHAR(50), @NomeFilelikethis VARCHAR(255)'',@Tipolikethis , @NomeFilelikethis ;
	else
		SELECT ID, TIPO, NOME_FILE, NOME_COMPLETO, CONTENUTO, DIMENSIONE
		FROM ARCHIVIO_FILE
		WHERE 
			((@Tipolikethis IS NULL) OR TIPO LIKE @Tipolikethis) AND 
			((@NomeFilelikethis IS NULL) OR NOME_FILE LIKE @NomeFilelikethis)
		


', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZArchivioFileFindFind';

