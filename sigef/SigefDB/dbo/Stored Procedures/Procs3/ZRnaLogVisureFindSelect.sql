CREATE PROCEDURE ZRnaLogVisureFindSelect
(
	@IdRnaLogVisuraequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdImpresaequalthis INT, 
	@IdFiscaleImpresaequalthis VARCHAR(255), 
	@IdRichiestaequalthis VARCHAR(255), 
	@TipoVisuraequalthis VARCHAR(255), 
	@CodiceEsitoequalthis INT, 
	@DescrizioneEsitoequalthis NVARCHAR(max), 
	@DataRichiestaequalthis DATETIME, 
	@CodiceStatoRichiestaequalthis INT, 
	@DescrizioneStatoRichiestaequalthis NVARCHAR(max), 
	@DataStatoRichiestaequalthis DATETIME, 
	@IdOperatoreequalthis INT, 
	@DataInserimentoequalthis DATETIME, 
	@DataAggiornamentoequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_RNA_LOG_VISURA, ID_PROGETTO, ID_IMPRESA, ID_FISCALE_IMPRESA, ID_RICHIESTA, TIPO_VISURA, CODICE_ESITO, DESCRIZIONE_ESITO, DATA_RICHIESTA, CODICE_STATO_RICHIESTA, DESCRIZIONE_STATO_RICHIESTA, DATA_STATO_RICHIESTA, ID_OPERATORE, DATA_INSERIMENTO, DATA_AGGIORNAMENTO, PAYLOAD FROM RNA_LOG_VISURE WHERE 1=1';
	IF (@IdRnaLogVisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_RNA_LOG_VISURA = @IdRnaLogVisuraequalthis)'; set @lensql=@lensql+len(@IdRnaLogVisuraequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdFiscaleImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FISCALE_IMPRESA = @IdFiscaleImpresaequalthis)'; set @lensql=@lensql+len(@IdFiscaleImpresaequalthis);end;
	IF (@IdRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_RICHIESTA = @IdRichiestaequalthis)'; set @lensql=@lensql+len(@IdRichiestaequalthis);end;
	IF (@TipoVisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIPO_VISURA = @TipoVisuraequalthis)'; set @lensql=@lensql+len(@TipoVisuraequalthis);end;
	IF (@CodiceEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_ESITO = @CodiceEsitoequalthis)'; set @lensql=@lensql+len(@CodiceEsitoequalthis);end;
	IF (@DescrizioneEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE_ESITO = @DescrizioneEsitoequalthis)'; set @lensql=@lensql+len(@DescrizioneEsitoequalthis);end;
	IF (@DataRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_RICHIESTA = @DataRichiestaequalthis)'; set @lensql=@lensql+len(@DataRichiestaequalthis);end;
	IF (@CodiceStatoRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_STATO_RICHIESTA = @CodiceStatoRichiestaequalthis)'; set @lensql=@lensql+len(@CodiceStatoRichiestaequalthis);end;
	IF (@DescrizioneStatoRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE_STATO_RICHIESTA = @DescrizioneStatoRichiestaequalthis)'; set @lensql=@lensql+len(@DescrizioneStatoRichiestaequalthis);end;
	IF (@DataStatoRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_STATO_RICHIESTA = @DataStatoRichiestaequalthis)'; set @lensql=@lensql+len(@DataStatoRichiestaequalthis);end;
	IF (@IdOperatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_OPERATORE = @IdOperatoreequalthis)'; set @lensql=@lensql+len(@IdOperatoreequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@DataAggiornamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_AGGIORNAMENTO = @DataAggiornamentoequalthis)'; set @lensql=@lensql+len(@DataAggiornamentoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdRnaLogVisuraequalthis INT, @IdProgettoequalthis INT, @IdImpresaequalthis INT, @IdFiscaleImpresaequalthis VARCHAR(255), @IdRichiestaequalthis VARCHAR(255), @TipoVisuraequalthis VARCHAR(255), @CodiceEsitoequalthis INT, @DescrizioneEsitoequalthis NVARCHAR(max), @DataRichiestaequalthis DATETIME, @CodiceStatoRichiestaequalthis INT, @DescrizioneStatoRichiestaequalthis NVARCHAR(max), @DataStatoRichiestaequalthis DATETIME, @IdOperatoreequalthis INT, @DataInserimentoequalthis DATETIME, @DataAggiornamentoequalthis DATETIME',@IdRnaLogVisuraequalthis , @IdProgettoequalthis , @IdImpresaequalthis , @IdFiscaleImpresaequalthis , @IdRichiestaequalthis , @TipoVisuraequalthis , @CodiceEsitoequalthis , @DescrizioneEsitoequalthis , @DataRichiestaequalthis , @CodiceStatoRichiestaequalthis , @DescrizioneStatoRichiestaequalthis , @DataStatoRichiestaequalthis , @IdOperatoreequalthis , @DataInserimentoequalthis , @DataAggiornamentoequalthis ;
	else
		SELECT ID_RNA_LOG_VISURA, ID_PROGETTO, ID_IMPRESA, ID_FISCALE_IMPRESA, ID_RICHIESTA, TIPO_VISURA, CODICE_ESITO, DESCRIZIONE_ESITO, DATA_RICHIESTA, CODICE_STATO_RICHIESTA, DESCRIZIONE_STATO_RICHIESTA, DATA_STATO_RICHIESTA, ID_OPERATORE, DATA_INSERIMENTO, DATA_AGGIORNAMENTO, PAYLOAD
		FROM RNA_LOG_VISURE
		WHERE 
			((@IdRnaLogVisuraequalthis IS NULL) OR ID_RNA_LOG_VISURA = @IdRnaLogVisuraequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdFiscaleImpresaequalthis IS NULL) OR ID_FISCALE_IMPRESA = @IdFiscaleImpresaequalthis) AND 
			((@IdRichiestaequalthis IS NULL) OR ID_RICHIESTA = @IdRichiestaequalthis) AND 
			((@TipoVisuraequalthis IS NULL) OR TIPO_VISURA = @TipoVisuraequalthis) AND 
			((@CodiceEsitoequalthis IS NULL) OR CODICE_ESITO = @CodiceEsitoequalthis) AND 
			((@DescrizioneEsitoequalthis IS NULL) OR DESCRIZIONE_ESITO = @DescrizioneEsitoequalthis) AND 
			((@DataRichiestaequalthis IS NULL) OR DATA_RICHIESTA = @DataRichiestaequalthis) AND 
			((@CodiceStatoRichiestaequalthis IS NULL) OR CODICE_STATO_RICHIESTA = @CodiceStatoRichiestaequalthis) AND 
			((@DescrizioneStatoRichiestaequalthis IS NULL) OR DESCRIZIONE_STATO_RICHIESTA = @DescrizioneStatoRichiestaequalthis) AND 
			((@DataStatoRichiestaequalthis IS NULL) OR DATA_STATO_RICHIESTA = @DataStatoRichiestaequalthis) AND 
			((@IdOperatoreequalthis IS NULL) OR ID_OPERATORE = @IdOperatoreequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@DataAggiornamentoequalthis IS NULL) OR DATA_AGGIORNAMENTO = @DataAggiornamentoequalthis)
		

GO