CREATE PROCEDURE [dbo].[ZIterProgettoFindFind]
(
	@IdProgettoequalthis INT, 
	@IdStepequalthis INT, 
	@CodEsitoequalthis CHAR(2), 
	@CodEsitoRevisoreequalthis CHAR(2), 
	@IdBandoequalthis INT, 
	@CodFaseequalthis CHAR(1), 
	@IdCheckListequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PROGETTO, ID_STEP, COD_ESITO, DATA, CF_OPERATORE, NOTE, COD_ESITO_REVISORE, DATA_REVISORE, REVISORE, NOTE_REVISORE, ESITO_ISTRUTTORE, ESITO_POSITIVO_ISTRUTTORE, ESITO_REVISORE, ESITO_POSITIVO_REVISORE, ID_BANDO, SELEZIONATA_X_REVISIONE, ID_CHECK_LIST, COD_FASE, ORDINE, OBBLIGATORIO, STEP, AUTOMATICO, QUERY_SQL, QUERY_SQL_POST, CODE_METHOD, URL, VAL_MINIMO, VAL_MASSIMO, MISURA FROM vITER_PROGETTO WHERE 1=1';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdStepequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_STEP = @IdStepequalthis)'; set @lensql=@lensql+len(@IdStepequalthis);end;
	IF (@CodEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ESITO = @CodEsitoequalthis)'; set @lensql=@lensql+len(@CodEsitoequalthis);end;
	IF (@CodEsitoRevisoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ESITO_REVISORE = @CodEsitoRevisoreequalthis)'; set @lensql=@lensql+len(@CodEsitoRevisoreequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CodFaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_FASE = @CodFaseequalthis)'; set @lensql=@lensql+len(@CodFaseequalthis);end;
	IF (@IdCheckListequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CHECK_LIST = @IdCheckListequalthis)'; set @lensql=@lensql+len(@IdCheckListequalthis);end;
	set @sql = @sql + 'ORDER BY ORDINE';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProgettoequalthis INT, @IdStepequalthis INT, @CodEsitoequalthis CHAR(2), @CodEsitoRevisoreequalthis CHAR(2), @IdBandoequalthis INT, @CodFaseequalthis CHAR(1), @IdCheckListequalthis INT',@IdProgettoequalthis , @IdStepequalthis , @CodEsitoequalthis , @CodEsitoRevisoreequalthis , @IdBandoequalthis , @CodFaseequalthis , @IdCheckListequalthis ;
	else
		SELECT ID_PROGETTO, ID_STEP, COD_ESITO, DATA, CF_OPERATORE, NOTE, COD_ESITO_REVISORE, DATA_REVISORE, REVISORE, NOTE_REVISORE, ESITO_ISTRUTTORE, ESITO_POSITIVO_ISTRUTTORE, ESITO_REVISORE, ESITO_POSITIVO_REVISORE, ID_BANDO, SELEZIONATA_X_REVISIONE, ID_CHECK_LIST, COD_FASE, ORDINE, OBBLIGATORIO, STEP, AUTOMATICO, QUERY_SQL, QUERY_SQL_POST, CODE_METHOD, URL, VAL_MINIMO, VAL_MASSIMO, MISURA
		FROM vITER_PROGETTO
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdStepequalthis IS NULL) OR ID_STEP = @IdStepequalthis) AND 
			((@CodEsitoequalthis IS NULL) OR COD_ESITO = @CodEsitoequalthis) AND 
			((@CodEsitoRevisoreequalthis IS NULL) OR COD_ESITO_REVISORE = @CodEsitoRevisoreequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@CodFaseequalthis IS NULL) OR COD_FASE = @CodFaseequalthis) AND 
			((@IdCheckListequalthis IS NULL) OR ID_CHECK_LIST = @IdCheckListequalthis)
		ORDER BY ORDINE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZIterProgettoFindFind]
(
	@IdProgettoequalthis INT, 
	@IdStepequalthis INT, 
	@CodEsitoequalthis CHAR(2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_PROGETTO, ID_STEP, COD_ESITO, DATA, CF_OPERATORE, NOTE, REVISIONE, ESITO, ESITO_POSITIVO FROM vITER_PROGETTO WHERE 1=1'';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdStepequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_STEP = @IdStepequalthis)''; set @lensql=@lensql+len(@IdStepequalthis);end;
	IF (@CodEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_ESITO = @CodEsitoequalthis)''; set @lensql=@lensql+len(@CodEsitoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdProgettoequalthis INT, @IdStepequalthis INT, @CodEsitoequalthis CHAR(2)'',@IdProgettoequalthis , @IdStepequalthis , @CodEsitoequalthis ;
	else
		SELECT ID_PROGETTO, ID_STEP, COD_ESITO, DATA, CF_OPERATORE, NOTE, REVISIONE, ESITO, ESITO_POSITIVO
		FROM vITER_PROGETTO
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdStepequalthis IS NULL) OR ID_STEP = @IdStepequalthis) AND 
			((@CodEsitoequalthis IS NULL) OR COD_ESITO = @CodEsitoequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIterProgettoFindFind';

