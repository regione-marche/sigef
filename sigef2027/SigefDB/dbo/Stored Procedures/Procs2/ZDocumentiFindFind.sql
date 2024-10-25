CREATE PROCEDURE [dbo].[ZDocumentiFindFind]
(
	@Titololikethis VARCHAR(500), 
	@Descrizionelikethis VARCHAR(1000), 
	@DataFineValiditaeqgreaterthanthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_DOCUMENTO, TITOLO, DESCRIZIONE, DATA_MODIFICA, OPERATORE, DATA_FINE_VALIDITA FROM DOCUMENTI WHERE 1=1';
	IF (@Titololikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TITOLO LIKE @Titololikethis)'; set @lensql=@lensql+len(@Titololikethis);end;
	IF (@Descrizionelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE LIKE @Descrizionelikethis)'; set @lensql=@lensql+len(@Descrizionelikethis);end;
	IF (@DataFineValiditaeqgreaterthanthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE_VALIDITA >= @DataFineValiditaeqgreaterthanthis)'; set @lensql=@lensql+len(@DataFineValiditaeqgreaterthanthis);end;
	set @sql = @sql + 'ORDER BY DATA_MODIFICA DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Titololikethis VARCHAR(500), @Descrizionelikethis VARCHAR(1000), @DataFineValiditaeqgreaterthanthis DATETIME',@Titololikethis , @Descrizionelikethis , @DataFineValiditaeqgreaterthanthis ;
	else
		SELECT ID_DOCUMENTO, TITOLO, DESCRIZIONE, DATA_MODIFICA, OPERATORE, DATA_FINE_VALIDITA
		FROM DOCUMENTI
		WHERE 
			((@Titololikethis IS NULL) OR TITOLO LIKE @Titololikethis) AND 
			((@Descrizionelikethis IS NULL) OR DESCRIZIONE LIKE @Descrizionelikethis) AND 
			((@DataFineValiditaeqgreaterthanthis IS NULL) OR DATA_FINE_VALIDITA >= @DataFineValiditaeqgreaterthanthis)
		ORDER BY DATA_MODIFICA DESC

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZDocumentiFindFind]
(
	@IdDocumentoequalthis INT, 
	@Operatoreequalthis VARCHAR(16), 
	@DataFineValiditaeqgreaterthanthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_DOCUMENTO, TITOLO, DESCRIZIONE, DATA_MODIFICA, OPERATORE, DATA_FINE_VALIDITA FROM DOCUMENTI WHERE 1=1'';
	IF (@IdDocumentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DOCUMENTO = @IdDocumentoequalthis)''; set @lensql=@lensql+len(@IdDocumentoequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (OPERATORE = @Operatoreequalthis)''; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@DataFineValiditaeqgreaterthanthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_FINE_VALIDITA >= @DataFineValiditaeqgreaterthanthis)''; set @lensql=@lensql+len(@DataFineValiditaeqgreaterthanthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdDocumentoequalthis INT, @Operatoreequalthis VARCHAR(16), @DataFineValiditaeqgreaterthanthis DATETIME'',@IdDocumentoequalthis , @Operatoreequalthis , @DataFineValiditaeqgreaterthanthis ;
	else
		SELECT ID_DOCUMENTO, TITOLO, DESCRIZIONE, DATA_MODIFICA, OPERATORE, DATA_FINE_VALIDITA
		FROM DOCUMENTI
		WHERE 
			((@IdDocumentoequalthis IS NULL) OR ID_DOCUMENTO = @IdDocumentoequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@DataFineValiditaeqgreaterthanthis IS NULL) OR DATA_FINE_VALIDITA >= @DataFineValiditaeqgreaterthanthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDocumentiFindFind';

