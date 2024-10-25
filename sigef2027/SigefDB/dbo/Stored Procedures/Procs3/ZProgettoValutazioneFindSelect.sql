CREATE PROCEDURE [dbo].[ZProgettoValutazioneFindSelect]
(
	@Idequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdVarianteequalthis INT, 
	@IdFileequalthis INT, 
	@OrdineFirmaequalthis INT, 
	@Segnaturaequalthis VARCHAR(255), 
	@IdNoteequalthis INT, 
	@Operatoreequalthis INT, 
	@DataModificaequalthis DATETIME, 
	@Annullatoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_PROGETTO, ID_VARIANTE, ID_FILE, ORDINE_FIRMA, SEGNATURA, ID_NOTE, OPERATORE, DATA_MODIFICA, ANNULLATO FROM PROGETTO_VALUTAZIONE WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VARIANTE = @IdVarianteequalthis)'; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	IF (@IdFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FILE = @IdFileequalthis)'; set @lensql=@lensql+len(@IdFileequalthis);end;
	IF (@OrdineFirmaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE_FIRMA = @OrdineFirmaequalthis)'; set @lensql=@lensql+len(@OrdineFirmaequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA = @Segnaturaequalthis)'; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	IF (@IdNoteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_NOTE = @IdNoteequalthis)'; set @lensql=@lensql+len(@IdNoteequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@Annullatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNULLATO = @Annullatoequalthis)'; set @lensql=@lensql+len(@Annullatoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @IdProgettoequalthis INT, @IdVarianteequalthis INT, @IdFileequalthis INT, @OrdineFirmaequalthis INT, @Segnaturaequalthis VARCHAR(255), @IdNoteequalthis INT, @Operatoreequalthis INT, @DataModificaequalthis DATETIME, @Annullatoequalthis BIT',@Idequalthis , @IdProgettoequalthis , @IdVarianteequalthis , @IdFileequalthis , @OrdineFirmaequalthis , @Segnaturaequalthis , @IdNoteequalthis , @Operatoreequalthis , @DataModificaequalthis , @Annullatoequalthis ;
	else
		SELECT ID, ID_PROGETTO, ID_VARIANTE, ID_FILE, ORDINE_FIRMA, SEGNATURA, ID_NOTE, OPERATORE, DATA_MODIFICA, ANNULLATO
		FROM PROGETTO_VALUTAZIONE
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis) AND 
			((@IdFileequalthis IS NULL) OR ID_FILE = @IdFileequalthis) AND 
			((@OrdineFirmaequalthis IS NULL) OR ORDINE_FIRMA = @OrdineFirmaequalthis) AND 
			((@Segnaturaequalthis IS NULL) OR SEGNATURA = @Segnaturaequalthis) AND 
			((@IdNoteequalthis IS NULL) OR ID_NOTE = @IdNoteequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@Annullatoequalthis IS NULL) OR ANNULLATO = @Annullatoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoValutazioneFindSelect]
(
	@Idequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdVarianteequalthis INT, 
	@IdFileequalthis INT, 
	@OrdineFirmaequalthis INT, 
	@Segnaturaequalthis VARCHAR(255), 
	@IdNoteequalthis INT, 
	@Operatoreequalthis INT, 
	@DataModificaequalthis DATETIME, 
	@Annullatoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_PROGETTO, ID_VARIANTE, ID_FILE, ORDINE_FIRMA, SEGNATURA, ID_NOTE, OPERATORE, DATA_MODIFICA, ANNULLATO FROM PROGETTO_VALUTAZIONE WHERE 1=1'';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID = @Idequalthis)''; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_VARIANTE = @IdVarianteequalthis)''; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	IF (@IdFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_FILE = @IdFileequalthis)''; set @lensql=@lensql+len(@IdFileequalthis);end;
	IF (@OrdineFirmaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ORDINE_FIRMA = @OrdineFirmaequalthis)''; set @lensql=@lensql+len(@OrdineFirmaequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SEGNATURA = @Segnaturaequalthis)''; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	IF (@IdNoteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_NOTE = @IdNoteequalthis)''; set @lensql=@lensql+len(@IdNoteequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (OPERATORE = @Operatoreequalthis)''; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_MODIFICA = @DataModificaequalthis)''; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@Annullatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ANNULLATO = @Annullatoequalthis)''; set @lensql=@lensql+len(@Annullatoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@Idequalthis INT, @IdProgettoequalthis INT, @IdVarianteequalthis INT, @IdFileequalthis INT, @OrdineFirmaequalthis INT, @Segnaturaequalthis VARCHAR(255), @IdNoteequalthis INT, @Operatoreequalthis INT, @DataModificaequalthis DATETIME, @Annullatoequalthis BIT'',@Idequalthis , @IdProgettoequalthis , @IdVarianteequalthis , @IdFileequalthis , @OrdineFirmaequalthis , @Segnaturaequalthis , @IdNoteequalthis , @Operatoreequalthis , @DataModificaequalthis , @Annullatoequalthis ;
	else
		SELECT ID, ID_PROGETTO, ID_VARIANTE, ID_FILE, ORDINE_FIRMA, SEGNATURA, ID_NOTE, OPERATORE, DATA_MODIFICA, ANNULLATO
		FROM PROGETTO_VALUTAZIONE
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis) AND 
			((@IdFileequalthis IS NULL) OR ID_FILE = @IdFileequalthis) AND 
			((@OrdineFirmaequalthis IS NULL) OR ORDINE_FIRMA = @OrdineFirmaequalthis) AND 
			((@Segnaturaequalthis IS NULL) OR SEGNATURA = @Segnaturaequalthis) AND 
			((@IdNoteequalthis IS NULL) OR ID_NOTE = @IdNoteequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@Annullatoequalthis IS NULL) OR ANNULLATO = @Annullatoequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoValutazioneFindSelect';

