CREATE PROCEDURE [dbo].[ZDocumentiFindSelect]
(
	@IdDocumentoequalthis INT, 
	@Titoloequalthis VARCHAR(500), 
	@Descrizioneequalthis VARCHAR(1000), 
	@DataModificaequalthis DATETIME, 
	@Operatoreequalthis VARCHAR(16), 
	@DataFineValiditaequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_DOCUMENTO, TITOLO, DESCRIZIONE, DATA_MODIFICA, OPERATORE, DATA_FINE_VALIDITA FROM DOCUMENTI WHERE 1=1';
	IF (@IdDocumentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOCUMENTO = @IdDocumentoequalthis)'; set @lensql=@lensql+len(@IdDocumentoequalthis);end;
	IF (@Titoloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TITOLO = @Titoloequalthis)'; set @lensql=@lensql+len(@Titoloequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@DataFineValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE_VALIDITA = @DataFineValiditaequalthis)'; set @lensql=@lensql+len(@DataFineValiditaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdDocumentoequalthis INT, @Titoloequalthis VARCHAR(500), @Descrizioneequalthis VARCHAR(1000), @DataModificaequalthis DATETIME, @Operatoreequalthis VARCHAR(16), @DataFineValiditaequalthis DATETIME',@IdDocumentoequalthis , @Titoloequalthis , @Descrizioneequalthis , @DataModificaequalthis , @Operatoreequalthis , @DataFineValiditaequalthis ;
	else
		SELECT ID_DOCUMENTO, TITOLO, DESCRIZIONE, DATA_MODIFICA, OPERATORE, DATA_FINE_VALIDITA
		FROM DOCUMENTI
		WHERE 
			((@IdDocumentoequalthis IS NULL) OR ID_DOCUMENTO = @IdDocumentoequalthis) AND 
			((@Titoloequalthis IS NULL) OR TITOLO = @Titoloequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@DataFineValiditaequalthis IS NULL) OR DATA_FINE_VALIDITA = @DataFineValiditaequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZDocumentiFindSelect]
(
	@IdDocumentoequalthis INT, 
	@Titoloequalthis VARCHAR(500), 
	@Descrizioneequalthis VARCHAR(1000), 
	@DataModificaequalthis DATETIME, 
	@Operatoreequalthis VARCHAR(16), 
	@DataFineValiditaequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_DOCUMENTO, TITOLO, DESCRIZIONE, DATA_MODIFICA, OPERATORE, DATA_FINE_VALIDITA FROM DOCUMENTI WHERE 1=1'';
	IF (@IdDocumentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DOCUMENTO = @IdDocumentoequalthis)''; set @lensql=@lensql+len(@IdDocumentoequalthis);end;
	IF (@Titoloequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TITOLO = @Titoloequalthis)''; set @lensql=@lensql+len(@Titoloequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE = @Descrizioneequalthis)''; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_MODIFICA = @DataModificaequalthis)''; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (OPERATORE = @Operatoreequalthis)''; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@DataFineValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_FINE_VALIDITA = @DataFineValiditaequalthis)''; set @lensql=@lensql+len(@DataFineValiditaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdDocumentoequalthis INT, @Titoloequalthis VARCHAR(500), @Descrizioneequalthis VARCHAR(1000), @DataModificaequalthis DATETIME, @Operatoreequalthis VARCHAR(16), @DataFineValiditaequalthis DATETIME'',@IdDocumentoequalthis , @Titoloequalthis , @Descrizioneequalthis , @DataModificaequalthis , @Operatoreequalthis , @DataFineValiditaequalthis ;
	else
		SELECT ID_DOCUMENTO, TITOLO, DESCRIZIONE, DATA_MODIFICA, OPERATORE, DATA_FINE_VALIDITA
		FROM DOCUMENTI
		WHERE 
			((@IdDocumentoequalthis IS NULL) OR ID_DOCUMENTO = @IdDocumentoequalthis) AND 
			((@Titoloequalthis IS NULL) OR TITOLO = @Titoloequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@DataFineValiditaequalthis IS NULL) OR DATA_FINE_VALIDITA = @DataFineValiditaequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDocumentiFindSelect';

