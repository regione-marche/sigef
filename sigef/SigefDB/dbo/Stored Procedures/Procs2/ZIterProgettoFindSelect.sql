CREATE PROCEDURE [dbo].[ZIterProgettoFindSelect]
(
	@IdProgettoequalthis INT, 
	@IdStepequalthis INT, 
	@CodEsitoequalthis CHAR(2), 
	@Dataequalthis DATETIME, 
	@CfOperatoreequalthis VARCHAR(16), 
	@CodEsitoRevisoreequalthis CHAR(2), 
	@DataRevisoreequalthis DATETIME, 
	@Revisoreequalthis VARCHAR(16)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PROGETTO, ID_STEP, COD_ESITO, DATA, CF_OPERATORE, NOTE, COD_ESITO_REVISORE, DATA_REVISORE, REVISORE, NOTE_REVISORE, ESITO_ISTRUTTORE, ESITO_POSITIVO_ISTRUTTORE, ESITO_REVISORE, ESITO_POSITIVO_REVISORE, ID_BANDO, SELEZIONATA_X_REVISIONE, ID_CHECK_LIST, COD_FASE, ORDINE, OBBLIGATORIO, STEP, AUTOMATICO, QUERY_SQL, QUERY_SQL_POST, CODE_METHOD, URL, VAL_MINIMO, VAL_MASSIMO, MISURA FROM vITER_PROGETTO WHERE 1=1';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdStepequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_STEP = @IdStepequalthis)'; set @lensql=@lensql+len(@IdStepequalthis);end;
	IF (@CodEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ESITO = @CodEsitoequalthis)'; set @lensql=@lensql+len(@CodEsitoequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@CfOperatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_OPERATORE = @CfOperatoreequalthis)'; set @lensql=@lensql+len(@CfOperatoreequalthis);end;
	IF (@CodEsitoRevisoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ESITO_REVISORE = @CodEsitoRevisoreequalthis)'; set @lensql=@lensql+len(@CodEsitoRevisoreequalthis);end;
	IF (@DataRevisoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_REVISORE = @DataRevisoreequalthis)'; set @lensql=@lensql+len(@DataRevisoreequalthis);end;
	IF (@Revisoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (REVISORE = @Revisoreequalthis)'; set @lensql=@lensql+len(@Revisoreequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProgettoequalthis INT, @IdStepequalthis INT, @CodEsitoequalthis CHAR(2), @Dataequalthis DATETIME, @CfOperatoreequalthis VARCHAR(16), @CodEsitoRevisoreequalthis CHAR(2), @DataRevisoreequalthis DATETIME, @Revisoreequalthis VARCHAR(16)',@IdProgettoequalthis , @IdStepequalthis , @CodEsitoequalthis , @Dataequalthis , @CfOperatoreequalthis , @CodEsitoRevisoreequalthis , @DataRevisoreequalthis , @Revisoreequalthis ;
	else
		SELECT ID_PROGETTO, ID_STEP, COD_ESITO, DATA, CF_OPERATORE, NOTE, COD_ESITO_REVISORE, DATA_REVISORE, REVISORE, NOTE_REVISORE, ESITO_ISTRUTTORE, ESITO_POSITIVO_ISTRUTTORE, ESITO_REVISORE, ESITO_POSITIVO_REVISORE, ID_BANDO, SELEZIONATA_X_REVISIONE, ID_CHECK_LIST, COD_FASE, ORDINE, OBBLIGATORIO, STEP, AUTOMATICO, QUERY_SQL, QUERY_SQL_POST, CODE_METHOD, URL, VAL_MINIMO, VAL_MASSIMO, MISURA
		FROM vITER_PROGETTO
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdStepequalthis IS NULL) OR ID_STEP = @IdStepequalthis) AND 
			((@CodEsitoequalthis IS NULL) OR COD_ESITO = @CodEsitoequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@CfOperatoreequalthis IS NULL) OR CF_OPERATORE = @CfOperatoreequalthis) AND 
			((@CodEsitoRevisoreequalthis IS NULL) OR COD_ESITO_REVISORE = @CodEsitoRevisoreequalthis) AND 
			((@DataRevisoreequalthis IS NULL) OR DATA_REVISORE = @DataRevisoreequalthis) AND 
			((@Revisoreequalthis IS NULL) OR REVISORE = @Revisoreequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZIterProgettoFindSelect]
(
	@IdProgettoequalthis INT, 
	@IdStepequalthis INT, 
	@CodEsitoequalthis CHAR(2), 
	@Dataequalthis DATETIME, 
	@CfOperatoreequalthis VARCHAR(16), 
	@Revisioneequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_PROGETTO, ID_STEP, COD_ESITO, DATA, CF_OPERATORE, NOTE, REVISIONE, ESITO, ESITO_POSITIVO FROM vITER_PROGETTO WHERE 1=1'';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdStepequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_STEP = @IdStepequalthis)''; set @lensql=@lensql+len(@IdStepequalthis);end;
	IF (@CodEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_ESITO = @CodEsitoequalthis)''; set @lensql=@lensql+len(@CodEsitoequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA = @Dataequalthis)''; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@CfOperatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CF_OPERATORE = @CfOperatoreequalthis)''; set @lensql=@lensql+len(@CfOperatoreequalthis);end;
	IF (@Revisioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (REVISIONE = @Revisioneequalthis)''; set @lensql=@lensql+len(@Revisioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdProgettoequalthis INT, @IdStepequalthis INT, @CodEsitoequalthis CHAR(2), @Dataequalthis DATETIME, @CfOperatoreequalthis VARCHAR(16), @Revisioneequalthis BIT'',@IdProgettoequalthis , @IdStepequalthis , @CodEsitoequalthis , @Dataequalthis , @CfOperatoreequalthis , @Revisioneequalthis ;
	else
		SELECT ID_PROGETTO, ID_STEP, COD_ESITO, DATA, CF_OPERATORE, NOTE, REVISIONE, ESITO, ESITO_POSITIVO
		FROM vITER_PROGETTO
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdStepequalthis IS NULL) OR ID_STEP = @IdStepequalthis) AND 
			((@CodEsitoequalthis IS NULL) OR COD_ESITO = @CodEsitoequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@CfOperatoreequalthis IS NULL) OR CF_OPERATORE = @CfOperatoreequalthis) AND 
			((@Revisioneequalthis IS NULL) OR REVISIONE = @Revisioneequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIterProgettoFindSelect';

