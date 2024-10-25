CREATE PROCEDURE [dbo].[ZIgrueInvioFindGetdatainviodaa]
(
	@DataInvioeqgreaterthanthis DATETIME, 
	@DataInvioeqlessthanthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_INVIO, ID_TICKET, DATA_INVIO, DATA_DA, DATA_A, FILE_INVIO, ID_OPERATORE, CODICE_ESITO, DESCRIZIONE_ESITO, DETTAGLIO_ESITO, TIMESTAMP_ESITO, TIPO_FILE, ID_IGRUE_LOG_ERRORI, DATA_RICHIESTA, FILE_ERRORI, ISTANZA_ERRORI, ID_OPERATORE_LOG, CODICE_ESITO_LOG, DESCRIZIONE_ESITO_LOG, DETTAGLIO_ESITO_LOG, TIMESTAMP_ESITO_LOG, TIPO_FILE_LOG FROM VIGRUE_INVIO WHERE 1=1';
	IF (@DataInvioeqgreaterthanthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INVIO >= @DataInvioeqgreaterthanthis)'; set @lensql=@lensql+len(@DataInvioeqgreaterthanthis);end;
	IF (@DataInvioeqlessthanthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INVIO <= @DataInvioeqlessthanthis)'; set @lensql=@lensql+len(@DataInvioeqlessthanthis);end;
	set @sql = @sql + 'ORDER BY DATA_INVIO DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@DataInvioeqgreaterthanthis DATETIME, @DataInvioeqlessthanthis DATETIME',@DataInvioeqgreaterthanthis , @DataInvioeqlessthanthis ;
	else
		SELECT ID_INVIO, ID_TICKET, DATA_INVIO, DATA_DA, DATA_A, FILE_INVIO, ID_OPERATORE, CODICE_ESITO, DESCRIZIONE_ESITO, DETTAGLIO_ESITO, TIMESTAMP_ESITO, TIPO_FILE, ID_IGRUE_LOG_ERRORI, DATA_RICHIESTA, FILE_ERRORI, ISTANZA_ERRORI, ID_OPERATORE_LOG, CODICE_ESITO_LOG, DESCRIZIONE_ESITO_LOG, DETTAGLIO_ESITO_LOG, TIMESTAMP_ESITO_LOG, TIPO_FILE_LOG
		FROM VIGRUE_INVIO
		WHERE 
			((@DataInvioeqgreaterthanthis IS NULL) OR DATA_INVIO >= @DataInvioeqgreaterthanthis) AND 
			((@DataInvioeqlessthanthis IS NULL) OR DATA_INVIO <= @DataInvioeqlessthanthis)
		ORDER BY DATA_INVIO DESC


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZIgrueInvioFindGetdatainviodaa]
(
	@DataInvioeqgreaterthanthis DATETIME, 
	@DataInvioeqlessthanthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_INVIO, ID_TICKET, DATA_INVIO, DATA_DA, DATA_A, FILE_INVIO, ID_OPERATORE, CODICE_ESITO, DESCRIZIONE_ESITO, DETTAGLIO_ESITO, TIMESTAMP_ESITO, TIPO_FILE FROM VIGRUE_INVIO WHERE 1=1'';
	IF (@DataInvioeqgreaterthanthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_INVIO >= @DataInvioeqgreaterthanthis)''; set @lensql=@lensql+len(@DataInvioeqgreaterthanthis);end;
	IF (@DataInvioeqlessthanthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_INVIO <= @DataInvioeqlessthanthis)''; set @lensql=@lensql+len(@DataInvioeqlessthanthis);end;
	set @sql = @sql + ''ORDER BY DATA_INVIO DESC'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@DataInvioeqgreaterthanthis DATETIME, @DataInvioeqlessthanthis DATETIME'',@DataInvioeqgreaterthanthis , @DataInvioeqlessthanthis ;
	else
		SELECT ID_INVIO, ID_TICKET, DATA_INVIO, DATA_DA, DATA_A, FILE_INVIO, ID_OPERATORE, CODICE_ESITO, DESCRIZIONE_ESITO, DETTAGLIO_ESITO, TIMESTAMP_ESITO, TIPO_FILE
		FROM VIGRUE_INVIO
		WHERE 
			((@DataInvioeqgreaterthanthis IS NULL) OR DATA_INVIO >= @DataInvioeqgreaterthanthis) AND 
			((@DataInvioeqlessthanthis IS NULL) OR DATA_INVIO <= @DataInvioeqlessthanthis)
		ORDER BY DATA_INVIO DESC

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIgrueInvioFindGetdatainviodaa';

