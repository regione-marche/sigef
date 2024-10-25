CREATE PROCEDURE [dbo].[ZFileDocumentoFindSelect]
(
	@IdFileequalthis INT, 
	@IdDocumentoequalthis INT, 
	@Nomeequalthis VARCHAR(80), 
	@Tipoequalthis VARCHAR(10), 
	@SizeFileequalthis INT, 
	@Descrizioneequalthis VARCHAR(100), 
	@IdArchivioFileequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_FILE, ID_DOCUMENTO, NOME, TIPO, SIZE_FILE, DESCRIZIONE, ID_ARCHIVIO_FILE FROM FILE_DOCUMENTO WHERE 1=1';
	IF (@IdFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FILE = @IdFileequalthis)'; set @lensql=@lensql+len(@IdFileequalthis);end;
	IF (@IdDocumentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOCUMENTO = @IdDocumentoequalthis)'; set @lensql=@lensql+len(@IdDocumentoequalthis);end;
	IF (@Nomeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOME = @Nomeequalthis)'; set @lensql=@lensql+len(@Nomeequalthis);end;
	IF (@Tipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIPO = @Tipoequalthis)'; set @lensql=@lensql+len(@Tipoequalthis);end;
	IF (@SizeFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SIZE_FILE = @SizeFileequalthis)'; set @lensql=@lensql+len(@SizeFileequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@IdArchivioFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ARCHIVIO_FILE = @IdArchivioFileequalthis)'; set @lensql=@lensql+len(@IdArchivioFileequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdFileequalthis INT, @IdDocumentoequalthis INT, @Nomeequalthis VARCHAR(80), @Tipoequalthis VARCHAR(10), @SizeFileequalthis INT, @Descrizioneequalthis VARCHAR(100), @IdArchivioFileequalthis INT',@IdFileequalthis , @IdDocumentoequalthis , @Nomeequalthis , @Tipoequalthis , @SizeFileequalthis , @Descrizioneequalthis , @IdArchivioFileequalthis ;
	else
		SELECT ID_FILE, ID_DOCUMENTO, NOME, TIPO, SIZE_FILE, DESCRIZIONE, ID_ARCHIVIO_FILE
		FROM FILE_DOCUMENTO
		WHERE 
			((@IdFileequalthis IS NULL) OR ID_FILE = @IdFileequalthis) AND 
			((@IdDocumentoequalthis IS NULL) OR ID_DOCUMENTO = @IdDocumentoequalthis) AND 
			((@Nomeequalthis IS NULL) OR NOME = @Nomeequalthis) AND 
			((@Tipoequalthis IS NULL) OR TIPO = @Tipoequalthis) AND 
			((@SizeFileequalthis IS NULL) OR SIZE_FILE = @SizeFileequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@IdArchivioFileequalthis IS NULL) OR ID_ARCHIVIO_FILE = @IdArchivioFileequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZFileDocumentoFindSelect]
(
	@IdFileequalthis INT, 
	@IdDocumentoequalthis INT, 
	@Nomeequalthis VARCHAR(80), 
	@Tipoequalthis VARCHAR(10), 
	@SizeFileequalthis INT, 
	@Descrizioneequalthis VARCHAR(100)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_FILE, ID_DOCUMENTO, NOME, TIPO, SIZE_FILE, DESCRIZIONE FROM FILE_DOCUMENTO WHERE 1=1'';
	IF (@IdFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_FILE = @IdFileequalthis)''; set @lensql=@lensql+len(@IdFileequalthis);end;
	IF (@IdDocumentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DOCUMENTO = @IdDocumentoequalthis)''; set @lensql=@lensql+len(@IdDocumentoequalthis);end;
	IF (@Nomeequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (NOME = @Nomeequalthis)''; set @lensql=@lensql+len(@Nomeequalthis);end;
	IF (@Tipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TIPO = @Tipoequalthis)''; set @lensql=@lensql+len(@Tipoequalthis);end;
	IF (@SizeFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SIZE_FILE = @SizeFileequalthis)''; set @lensql=@lensql+len(@SizeFileequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE = @Descrizioneequalthis)''; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdFileequalthis INT, @IdDocumentoequalthis INT, @Nomeequalthis VARCHAR(80), @Tipoequalthis VARCHAR(10), @SizeFileequalthis INT, @Descrizioneequalthis VARCHAR(100)'',@IdFileequalthis , @IdDocumentoequalthis , @Nomeequalthis , @Tipoequalthis , @SizeFileequalthis , @Descrizioneequalthis ;
	else
		SELECT ID_FILE, ID_DOCUMENTO, NOME, TIPO, SIZE_FILE, DESCRIZIONE
		FROM FILE_DOCUMENTO
		WHERE 
			((@IdFileequalthis IS NULL) OR ID_FILE = @IdFileequalthis) AND 
			((@IdDocumentoequalthis IS NULL) OR ID_DOCUMENTO = @IdDocumentoequalthis) AND 
			((@Nomeequalthis IS NULL) OR NOME = @Nomeequalthis) AND 
			((@Tipoequalthis IS NULL) OR TIPO = @Tipoequalthis) AND 
			((@SizeFileequalthis IS NULL) OR SIZE_FILE = @SizeFileequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZFileDocumentoFindSelect';

