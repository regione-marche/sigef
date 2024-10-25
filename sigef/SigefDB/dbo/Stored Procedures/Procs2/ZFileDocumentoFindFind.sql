CREATE PROCEDURE [dbo].[ZFileDocumentoFindFind]
(
	@IdDocumentoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_FILE, ID_DOCUMENTO, NOME, TIPO, SIZE_FILE, DESCRIZIONE, ID_ARCHIVIO_FILE FROM FILE_DOCUMENTO WHERE 1=1';
	IF (@IdDocumentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOCUMENTO = @IdDocumentoequalthis)'; set @lensql=@lensql+len(@IdDocumentoequalthis);end;
	set @sql = @sql + 'ORDER BY DESCRIZIONE';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdDocumentoequalthis INT',@IdDocumentoequalthis ;
	else
		SELECT ID_FILE, ID_DOCUMENTO, NOME, TIPO, SIZE_FILE, DESCRIZIONE, ID_ARCHIVIO_FILE
		FROM FILE_DOCUMENTO
		WHERE 
			((@IdDocumentoequalthis IS NULL) OR ID_DOCUMENTO = @IdDocumentoequalthis)
		ORDER BY DESCRIZIONE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZFileDocumentoFindFind]
(
	@IdFileequalthis INT, 
	@IdDocumentoequalthis INT, 
	@Tipoequalthis VARCHAR(10)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_FILE, ID_DOCUMENTO, NOME, TIPO, SIZE_FILE, DESCRIZIONE FROM FILE_DOCUMENTO WHERE 1=1'';
	IF (@IdFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_FILE = @IdFileequalthis)''; set @lensql=@lensql+len(@IdFileequalthis);end;
	IF (@IdDocumentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DOCUMENTO = @IdDocumentoequalthis)''; set @lensql=@lensql+len(@IdDocumentoequalthis);end;
	IF (@Tipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TIPO = @Tipoequalthis)''; set @lensql=@lensql+len(@Tipoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdFileequalthis INT, @IdDocumentoequalthis INT, @Tipoequalthis VARCHAR(10)'',@IdFileequalthis , @IdDocumentoequalthis , @Tipoequalthis ;
	else
		SELECT ID_FILE, ID_DOCUMENTO, NOME, TIPO, SIZE_FILE, DESCRIZIONE
		FROM FILE_DOCUMENTO
		WHERE 
			((@IdFileequalthis IS NULL) OR ID_FILE = @IdFileequalthis) AND 
			((@IdDocumentoequalthis IS NULL) OR ID_DOCUMENTO = @IdDocumentoequalthis) AND 
			((@Tipoequalthis IS NULL) OR TIPO = @Tipoequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZFileDocumentoFindFind';

