CREATE PROCEDURE [dbo].[ZIgrueLogErroriFindSelect]
(
	@IdIgrueLogErroriequalthis INT, 
	@IdInvioequalthis INT, 
	@IdTicketequalthis VARCHAR(255), 
	@DataRichiestaequalthis DATETIME, 
	@IdOperatoreequalthis INT, 
	@CodiceEsitoequalthis INT, 
	@DescrizioneEsitoequalthis NVARCHAR(max), 
	@DettaglioEsitoequalthis NVARCHAR(max), 
	@TimestampEsitoequalthis DATETIME, 
	@TipoFileequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_IGRUE_LOG_ERRORI, ID_INVIO, ID_TICKET, DATA_RICHIESTA, FILE_ERRORI, ISTANZA_ERRORI, ID_OPERATORE, CODICE_ESITO, DESCRIZIONE_ESITO, DETTAGLIO_ESITO, TIMESTAMP_ESITO, TIPO_FILE FROM VIGRUE_LOG_ERRORI WHERE 1=1';
	IF (@IdIgrueLogErroriequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IGRUE_LOG_ERRORI = @IdIgrueLogErroriequalthis)'; set @lensql=@lensql+len(@IdIgrueLogErroriequalthis);end;
	IF (@IdInvioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INVIO = @IdInvioequalthis)'; set @lensql=@lensql+len(@IdInvioequalthis);end;
	IF (@IdTicketequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_TICKET = @IdTicketequalthis)'; set @lensql=@lensql+len(@IdTicketequalthis);end;
	IF (@DataRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_RICHIESTA = @DataRichiestaequalthis)'; set @lensql=@lensql+len(@DataRichiestaequalthis);end;
	IF (@IdOperatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_OPERATORE = @IdOperatoreequalthis)'; set @lensql=@lensql+len(@IdOperatoreequalthis);end;
	IF (@CodiceEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_ESITO = @CodiceEsitoequalthis)'; set @lensql=@lensql+len(@CodiceEsitoequalthis);end;
	IF (@DescrizioneEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE_ESITO = @DescrizioneEsitoequalthis)'; set @lensql=@lensql+len(@DescrizioneEsitoequalthis);end;
	IF (@DettaglioEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DETTAGLIO_ESITO = @DettaglioEsitoequalthis)'; set @lensql=@lensql+len(@DettaglioEsitoequalthis);end;
	IF (@TimestampEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIMESTAMP_ESITO = @TimestampEsitoequalthis)'; set @lensql=@lensql+len(@TimestampEsitoequalthis);end;
	IF (@TipoFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIPO_FILE = @TipoFileequalthis)'; set @lensql=@lensql+len(@TipoFileequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdIgrueLogErroriequalthis INT, @IdInvioequalthis INT, @IdTicketequalthis VARCHAR(255), @DataRichiestaequalthis DATETIME, @IdOperatoreequalthis INT, @CodiceEsitoequalthis INT, @DescrizioneEsitoequalthis NVARCHAR(max), @DettaglioEsitoequalthis NVARCHAR(max), @TimestampEsitoequalthis DATETIME, @TipoFileequalthis VARCHAR(255)',@IdIgrueLogErroriequalthis , @IdInvioequalthis , @IdTicketequalthis , @DataRichiestaequalthis , @IdOperatoreequalthis , @CodiceEsitoequalthis , @DescrizioneEsitoequalthis , @DettaglioEsitoequalthis , @TimestampEsitoequalthis , @TipoFileequalthis ;
	else
		SELECT ID_IGRUE_LOG_ERRORI, ID_INVIO, ID_TICKET, DATA_RICHIESTA, FILE_ERRORI, ISTANZA_ERRORI, ID_OPERATORE, CODICE_ESITO, DESCRIZIONE_ESITO, DETTAGLIO_ESITO, TIMESTAMP_ESITO, TIPO_FILE
		FROM VIGRUE_LOG_ERRORI
		WHERE 
			((@IdIgrueLogErroriequalthis IS NULL) OR ID_IGRUE_LOG_ERRORI = @IdIgrueLogErroriequalthis) AND 
			((@IdInvioequalthis IS NULL) OR ID_INVIO = @IdInvioequalthis) AND 
			((@IdTicketequalthis IS NULL) OR ID_TICKET = @IdTicketequalthis) AND 
			((@DataRichiestaequalthis IS NULL) OR DATA_RICHIESTA = @DataRichiestaequalthis) AND 
			((@IdOperatoreequalthis IS NULL) OR ID_OPERATORE = @IdOperatoreequalthis) AND 
			((@CodiceEsitoequalthis IS NULL) OR CODICE_ESITO = @CodiceEsitoequalthis) AND 
			((@DescrizioneEsitoequalthis IS NULL) OR DESCRIZIONE_ESITO = @DescrizioneEsitoequalthis) AND 
			((@DettaglioEsitoequalthis IS NULL) OR DETTAGLIO_ESITO = @DettaglioEsitoequalthis) AND 
			((@TimestampEsitoequalthis IS NULL) OR TIMESTAMP_ESITO = @TimestampEsitoequalthis) AND 
			((@TipoFileequalthis IS NULL) OR TIPO_FILE = @TipoFileequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIgrueLogErroriFindSelect';

