CREATE PROCEDURE ZRnaLogVisureFindFind
(
	@IdRnaLogVisuraequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdImpresaequalthis INT, 
	@IdRichiestaequalthis VARCHAR(255), 
	@TipoVisuraequalthis VARCHAR(255), 
	@CodiceEsitoequalthis INT, 
	@DescrizioneEsitoequalthis NVARCHAR(max), 
	@DescrizioneStatoRichiestaequalthis NVARCHAR(max), 
	@CodiceStatoRichiestaequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_RNA_LOG_VISURA, ID_PROGETTO, ID_IMPRESA, ID_FISCALE_IMPRESA, ID_RICHIESTA, TIPO_VISURA, CODICE_ESITO, DESCRIZIONE_ESITO, DATA_RICHIESTA, CODICE_STATO_RICHIESTA, DESCRIZIONE_STATO_RICHIESTA, DATA_STATO_RICHIESTA, ID_OPERATORE, DATA_INSERIMENTO, DATA_AGGIORNAMENTO, PAYLOAD FROM RNA_LOG_VISURE WHERE 1=1';
	IF (@IdRnaLogVisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_RNA_LOG_VISURA = @IdRnaLogVisuraequalthis)'; set @lensql=@lensql+len(@IdRnaLogVisuraequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_RICHIESTA = @IdRichiestaequalthis)'; set @lensql=@lensql+len(@IdRichiestaequalthis);end;
	IF (@TipoVisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIPO_VISURA = @TipoVisuraequalthis)'; set @lensql=@lensql+len(@TipoVisuraequalthis);end;
	IF (@CodiceEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_ESITO = @CodiceEsitoequalthis)'; set @lensql=@lensql+len(@CodiceEsitoequalthis);end;
	IF (@DescrizioneEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE_ESITO = @DescrizioneEsitoequalthis)'; set @lensql=@lensql+len(@DescrizioneEsitoequalthis);end;
	IF (@DescrizioneStatoRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE_STATO_RICHIESTA = @DescrizioneStatoRichiestaequalthis)'; set @lensql=@lensql+len(@DescrizioneStatoRichiestaequalthis);end;
	IF (@CodiceStatoRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_STATO_RICHIESTA = @CodiceStatoRichiestaequalthis)'; set @lensql=@lensql+len(@CodiceStatoRichiestaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdRnaLogVisuraequalthis INT, @IdProgettoequalthis INT, @IdImpresaequalthis INT, @IdRichiestaequalthis VARCHAR(255), @TipoVisuraequalthis VARCHAR(255), @CodiceEsitoequalthis INT, @DescrizioneEsitoequalthis NVARCHAR(max), @DescrizioneStatoRichiestaequalthis NVARCHAR(max), @CodiceStatoRichiestaequalthis INT',@IdRnaLogVisuraequalthis , @IdProgettoequalthis , @IdImpresaequalthis , @IdRichiestaequalthis , @TipoVisuraequalthis , @CodiceEsitoequalthis , @DescrizioneEsitoequalthis , @DescrizioneStatoRichiestaequalthis , @CodiceStatoRichiestaequalthis ;
	else
		SELECT ID_RNA_LOG_VISURA, ID_PROGETTO, ID_IMPRESA, ID_FISCALE_IMPRESA, ID_RICHIESTA, TIPO_VISURA, CODICE_ESITO, DESCRIZIONE_ESITO, DATA_RICHIESTA, CODICE_STATO_RICHIESTA, DESCRIZIONE_STATO_RICHIESTA, DATA_STATO_RICHIESTA, ID_OPERATORE, DATA_INSERIMENTO, DATA_AGGIORNAMENTO, PAYLOAD
		FROM RNA_LOG_VISURE
		WHERE 
			((@IdRnaLogVisuraequalthis IS NULL) OR ID_RNA_LOG_VISURA = @IdRnaLogVisuraequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdRichiestaequalthis IS NULL) OR ID_RICHIESTA = @IdRichiestaequalthis) AND 
			((@TipoVisuraequalthis IS NULL) OR TIPO_VISURA = @TipoVisuraequalthis) AND 
			((@CodiceEsitoequalthis IS NULL) OR CODICE_ESITO = @CodiceEsitoequalthis) AND 
			((@DescrizioneEsitoequalthis IS NULL) OR DESCRIZIONE_ESITO = @DescrizioneEsitoequalthis) AND 
			((@DescrizioneStatoRichiestaequalthis IS NULL) OR DESCRIZIONE_STATO_RICHIESTA = @DescrizioneStatoRichiestaequalthis) AND 
			((@CodiceStatoRichiestaequalthis IS NULL) OR CODICE_STATO_RICHIESTA = @CodiceStatoRichiestaequalthis)
		

GO