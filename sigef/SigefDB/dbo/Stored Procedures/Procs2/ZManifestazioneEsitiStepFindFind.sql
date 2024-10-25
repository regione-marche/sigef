CREATE PROCEDURE [dbo].[ZManifestazioneEsitiStepFindFind]
(
	@IdManifestazioneequalthis INT, 
	@IdStepequalthis INT, 
	@CodEsitoequalthis CHAR(2), 
	@IdBandoequalthis INT, 
	@CodFaseequalthis CHAR(1), 
	@IdCheckListequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_MANIFESTAZIONE, ID_STEP, COD_ESITO, DATA, CF_OPERATORE, NOTE, ID_BANDO, ID_CHECK_LIST, COD_FASE, ORDINE, OBBLIGATORIO, DESCRIZIONE, AUTOMATICO, QUERY_SQL, QUERY_SQL_POST, CODE_METHOD, URL, VAL_MINIMO, VAL_MASSIMO, MISURA, ESITO_ISTRUTTORE, ESITO_POSITIVO_ISTRUTTORE FROM vMANIFESTAZIONE_ESITI_STEP WHERE 1=1';
	IF (@IdManifestazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_MANIFESTAZIONE = @IdManifestazioneequalthis)'; set @lensql=@lensql+len(@IdManifestazioneequalthis);end;
	IF (@IdStepequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_STEP = @IdStepequalthis)'; set @lensql=@lensql+len(@IdStepequalthis);end;
	IF (@CodEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ESITO = @CodEsitoequalthis)'; set @lensql=@lensql+len(@CodEsitoequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CodFaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_FASE = @CodFaseequalthis)'; set @lensql=@lensql+len(@CodFaseequalthis);end;
	IF (@IdCheckListequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CHECK_LIST = @IdCheckListequalthis)'; set @lensql=@lensql+len(@IdCheckListequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdManifestazioneequalthis INT, @IdStepequalthis INT, @CodEsitoequalthis CHAR(2), @IdBandoequalthis INT, @CodFaseequalthis CHAR(1), @IdCheckListequalthis INT',@IdManifestazioneequalthis , @IdStepequalthis , @CodEsitoequalthis , @IdBandoequalthis , @CodFaseequalthis , @IdCheckListequalthis ;
	else
		SELECT ID_MANIFESTAZIONE, ID_STEP, COD_ESITO, DATA, CF_OPERATORE, NOTE, ID_BANDO, ID_CHECK_LIST, COD_FASE, ORDINE, OBBLIGATORIO, DESCRIZIONE, AUTOMATICO, QUERY_SQL, QUERY_SQL_POST, CODE_METHOD, URL, VAL_MINIMO, VAL_MASSIMO, MISURA, ESITO_ISTRUTTORE, ESITO_POSITIVO_ISTRUTTORE
		FROM vMANIFESTAZIONE_ESITI_STEP
		WHERE 
			((@IdManifestazioneequalthis IS NULL) OR ID_MANIFESTAZIONE = @IdManifestazioneequalthis) AND 
			((@IdStepequalthis IS NULL) OR ID_STEP = @IdStepequalthis) AND 
			((@CodEsitoequalthis IS NULL) OR COD_ESITO = @CodEsitoequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@CodFaseequalthis IS NULL) OR COD_FASE = @CodFaseequalthis) AND 
			((@IdCheckListequalthis IS NULL) OR ID_CHECK_LIST = @IdCheckListequalthis)
