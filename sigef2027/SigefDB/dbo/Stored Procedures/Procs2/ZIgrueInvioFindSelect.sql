CREATE PROCEDURE [dbo].[ZIgrueInvioFindSelect]
(
	@IdInvioequalthis INT, 
	@IdTicketequalthis VARCHAR(255), 
	@DataInvioequalthis DATETIME, 
	@DataDaequalthis DATE, 
	@DataAequalthis DATE, 
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
	SET @sql = 'SELECT ID_INVIO, ID_TICKET, DATA_INVIO, DATA_DA, DATA_A, FILE_INVIO, ID_OPERATORE, CODICE_ESITO, DESCRIZIONE_ESITO, DETTAGLIO_ESITO, TIMESTAMP_ESITO, TIPO_FILE, ID_IGRUE_LOG_ERRORI, DATA_RICHIESTA, FILE_ERRORI, ISTANZA_ERRORI, ID_OPERATORE_LOG, CODICE_ESITO_LOG, DESCRIZIONE_ESITO_LOG, DETTAGLIO_ESITO_LOG, TIMESTAMP_ESITO_LOG, TIPO_FILE_LOG FROM VIGRUE_INVIO WHERE 1=1';
	IF (@IdInvioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INVIO = @IdInvioequalthis)'; set @lensql=@lensql+len(@IdInvioequalthis);end;
	IF (@IdTicketequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_TICKET = @IdTicketequalthis)'; set @lensql=@lensql+len(@IdTicketequalthis);end;
	IF (@DataInvioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INVIO = @DataInvioequalthis)'; set @lensql=@lensql+len(@DataInvioequalthis);end;
	IF (@DataDaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_DA = @DataDaequalthis)'; set @lensql=@lensql+len(@DataDaequalthis);end;
	IF (@DataAequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_A = @DataAequalthis)'; set @lensql=@lensql+len(@DataAequalthis);end;
	IF (@IdOperatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_OPERATORE = @IdOperatoreequalthis)'; set @lensql=@lensql+len(@IdOperatoreequalthis);end;
	IF (@CodiceEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_ESITO = @CodiceEsitoequalthis)'; set @lensql=@lensql+len(@CodiceEsitoequalthis);end;
	IF (@DescrizioneEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE_ESITO = @DescrizioneEsitoequalthis)'; set @lensql=@lensql+len(@DescrizioneEsitoequalthis);end;
	IF (@DettaglioEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DETTAGLIO_ESITO = @DettaglioEsitoequalthis)'; set @lensql=@lensql+len(@DettaglioEsitoequalthis);end;
	IF (@TimestampEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIMESTAMP_ESITO = @TimestampEsitoequalthis)'; set @lensql=@lensql+len(@TimestampEsitoequalthis);end;
	IF (@TipoFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIPO_FILE = @TipoFileequalthis)'; set @lensql=@lensql+len(@TipoFileequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdInvioequalthis INT, @IdTicketequalthis VARCHAR(255), @DataInvioequalthis DATETIME, @DataDaequalthis DATE, @DataAequalthis DATE, @IdOperatoreequalthis INT, @CodiceEsitoequalthis INT, @DescrizioneEsitoequalthis NVARCHAR(max), @DettaglioEsitoequalthis NVARCHAR(max), @TimestampEsitoequalthis DATETIME, @TipoFileequalthis VARCHAR(255)',@IdInvioequalthis , @IdTicketequalthis , @DataInvioequalthis , @DataDaequalthis , @DataAequalthis , @IdOperatoreequalthis , @CodiceEsitoequalthis , @DescrizioneEsitoequalthis , @DettaglioEsitoequalthis , @TimestampEsitoequalthis , @TipoFileequalthis ;
	else
		SELECT ID_INVIO, ID_TICKET, DATA_INVIO, DATA_DA, DATA_A, FILE_INVIO, ID_OPERATORE, CODICE_ESITO, DESCRIZIONE_ESITO, DETTAGLIO_ESITO, TIMESTAMP_ESITO, TIPO_FILE, ID_IGRUE_LOG_ERRORI, DATA_RICHIESTA, FILE_ERRORI, ISTANZA_ERRORI, ID_OPERATORE_LOG, CODICE_ESITO_LOG, DESCRIZIONE_ESITO_LOG, DETTAGLIO_ESITO_LOG, TIMESTAMP_ESITO_LOG, TIPO_FILE_LOG
		FROM VIGRUE_INVIO
		WHERE 
			((@IdInvioequalthis IS NULL) OR ID_INVIO = @IdInvioequalthis) AND 
			((@IdTicketequalthis IS NULL) OR ID_TICKET = @IdTicketequalthis) AND 
			((@DataInvioequalthis IS NULL) OR DATA_INVIO = @DataInvioequalthis) AND 
			((@DataDaequalthis IS NULL) OR DATA_DA = @DataDaequalthis) AND 
			((@DataAequalthis IS NULL) OR DATA_A = @DataAequalthis) AND 
			((@IdOperatoreequalthis IS NULL) OR ID_OPERATORE = @IdOperatoreequalthis) AND 
			((@CodiceEsitoequalthis IS NULL) OR CODICE_ESITO = @CodiceEsitoequalthis) AND 
			((@DescrizioneEsitoequalthis IS NULL) OR DESCRIZIONE_ESITO = @DescrizioneEsitoequalthis) AND 
			((@DettaglioEsitoequalthis IS NULL) OR DETTAGLIO_ESITO = @DettaglioEsitoequalthis) AND 
			((@TimestampEsitoequalthis IS NULL) OR TIMESTAMP_ESITO = @TimestampEsitoequalthis) AND 
			((@TipoFileequalthis IS NULL) OR TIPO_FILE = @TipoFileequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZIgrueInvioFindSelect]
(
	@IdInvioequalthis INT, 
	@IdTicketequalthis VARCHAR(255), 
	@DataInvioequalthis DATETIME, 
	@DataDaequalthis DATE, 
	@DataAequalthis DATE, 
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
	SET @sql = ''SELECT ID_INVIO, ID_TICKET, DATA_INVIO, DATA_DA, DATA_A, FILE_INVIO, ID_OPERATORE, CODICE_ESITO, DESCRIZIONE_ESITO, DETTAGLIO_ESITO, TIMESTAMP_ESITO, TIPO_FILE FROM VIGRUE_INVIO WHERE 1=1'';
	IF (@IdInvioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_INVIO = @IdInvioequalthis)''; set @lensql=@lensql+len(@IdInvioequalthis);end;
	IF (@IdTicketequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_TICKET = @IdTicketequalthis)''; set @lensql=@lensql+len(@IdTicketequalthis);end;
	IF (@DataInvioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_INVIO = @DataInvioequalthis)''; set @lensql=@lensql+len(@DataInvioequalthis);end;
	IF (@DataDaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_DA = @DataDaequalthis)''; set @lensql=@lensql+len(@DataDaequalthis);end;
	IF (@DataAequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_A = @DataAequalthis)''; set @lensql=@lensql+len(@DataAequalthis);end;
	IF (@IdOperatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_OPERATORE = @IdOperatoreequalthis)''; set @lensql=@lensql+len(@IdOperatoreequalthis);end;
	IF (@CodiceEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CODICE_ESITO = @CodiceEsitoequalthis)''; set @lensql=@lensql+len(@CodiceEsitoequalthis);end;
	IF (@DescrizioneEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE_ESITO = @DescrizioneEsitoequalthis)''; set @lensql=@lensql+len(@DescrizioneEsitoequalthis);end;
	IF (@DettaglioEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DETTAGLIO_ESITO = @DettaglioEsitoequalthis)''; set @lensql=@lensql+len(@DettaglioEsitoequalthis);end;
	IF (@TimestampEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TIMESTAMP_ESITO = @TimestampEsitoequalthis)''; set @lensql=@lensql+len(@TimestampEsitoequalthis);end;
	IF (@TipoFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TIPO_FILE = @TipoFileequalthis)''; set @lensql=@lensql+len(@TipoFileequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdInvioequalthis INT, @IdTicketequalthis VARCHAR(255), @DataInvioequalthis DATETIME, @DataDaequalthis DATE, @DataAequalthis DATE, @IdOperatoreequalthis INT, @CodiceEsitoequalthis INT, @DescrizioneEsitoequalthis NVARCHAR(max), @DettaglioEsitoequalthis NVARCHAR(max), @TimestampEsitoequalthis DATETIME, @TipoFileequalthis VARCHAR(255)'',@IdInvioequalthis , @IdTicketequalthis , @DataInvioequalthis , @DataDaequalthis , @DataAequalthis , @IdOperatoreequalthis , @CodiceEsitoequalthis , @DescrizioneEsitoequalthis , @DettaglioEsitoequalthis , @TimestampEsitoequalthis , @TipoFileequalthis ;
	else
		SELECT ID_INVIO, ID_TICKET, DATA_INVIO, DATA_DA, DATA_A, FILE_INVIO, ID_OPERATORE, CODICE_ESITO, DESCRIZIONE_ESITO, DETTAGLIO_ESITO, TIMESTAMP_ESITO, TIPO_FILE
		FROM VIGRUE_INVIO
		WHERE 
			((@IdInvioequalthis IS NULL) OR ID_INVIO = @IdInvioequalthis) AND 
			((@IdTicketequalthis IS NULL) OR ID_TICKET = @IdTicketequalthis) AND 
			((@DataInvioequalthis IS NULL) OR DATA_INVIO = @DataInvioequalthis) AND 
			((@DataDaequalthis IS NULL) OR DATA_DA = @DataDaequalthis) AND 
			((@DataAequalthis IS NULL) OR DATA_A = @DataAequalthis) AND 
			((@IdOperatoreequalthis IS NULL) OR ID_OPERATORE = @IdOperatoreequalthis) AND 
			((@CodiceEsitoequalthis IS NULL) OR CODICE_ESITO = @CodiceEsitoequalthis) AND 
			((@DescrizioneEsitoequalthis IS NULL) OR DESCRIZIONE_ESITO = @DescrizioneEsitoequalthis) AND 
			((@DettaglioEsitoequalthis IS NULL) OR DETTAGLIO_ESITO', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIgrueInvioFindSelect';

