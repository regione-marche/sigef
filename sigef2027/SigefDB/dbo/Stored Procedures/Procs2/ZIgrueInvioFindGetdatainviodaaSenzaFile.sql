CREATE PROCEDURE [dbo].[ZIgrueInvioFindGetdatainviodaaSenzaFile]
(
	@DataInvioeqgreaterthanthis DATETIME = NULL, 
	@DataInvioeqlessthanthis DATETIME = NULL,
	@CodiceFondoEqualThis VARCHAR(20) = NULL
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_INVIO, ID_TICKET, DATA_INVIO, DATA_DA, DATA_A, NULL AS FILE_INVIO, ID_OPERATORE, CODICE_ESITO, DESCRIZIONE_ESITO, DETTAGLIO_ESITO, TIMESTAMP_ESITO, TIPO_FILE, CODICE_FONDO, ID_IGRUE_LOG_ERRORI, DATA_RICHIESTA, NULL AS FILE_ERRORI, ISTANZA_ERRORI, ID_OPERATORE_LOG, CODICE_ESITO_LOG, DESCRIZIONE_ESITO_LOG, DETTAGLIO_ESITO_LOG, TIMESTAMP_ESITO_LOG, TIPO_FILE_LOG, CODICE_FONDO_ERRORE FROM VIGRUE_INVIO WHERE 1=1';
	IF (@DataInvioeqgreaterthanthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INVIO >= @DataInvioeqgreaterthanthis)'; set @lensql=@lensql+len(@DataInvioeqgreaterthanthis);end;
	IF (@DataInvioeqlessthanthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INVIO <= @DataInvioeqlessthanthis)'; set @lensql=@lensql+len(@DataInvioeqlessthanthis);end;
	IF (@CodiceFondoEqualThis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_FONDO = @CodiceFondoEqualThis)'; set @lensql=@lensql+len(@CodiceFondoEqualThis);end;
	set @sql = @sql + 'ORDER BY DATA_INVIO DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@DataInvioeqgreaterthanthis DATETIME, @DataInvioeqlessthanthis DATETIME, @CodiceFondoEqualThis VARCHAR(20)',@DataInvioeqgreaterthanthis , @DataInvioeqlessthanthis, @CodiceFondoEqualThis ;
	else
		SELECT ID_INVIO, ID_TICKET, DATA_INVIO, DATA_DA, DATA_A, NULL AS FILE_INVIO, ID_OPERATORE, CODICE_ESITO, DESCRIZIONE_ESITO, DETTAGLIO_ESITO, TIMESTAMP_ESITO, TIPO_FILE, CODICE_FONDO, ID_IGRUE_LOG_ERRORI, DATA_RICHIESTA, NULL AS FILE_ERRORI, ISTANZA_ERRORI, ID_OPERATORE_LOG, CODICE_ESITO_LOG, DESCRIZIONE_ESITO_LOG, DETTAGLIO_ESITO_LOG, TIMESTAMP_ESITO_LOG, TIPO_FILE_LOG, CODICE_FONDO_ERRORE
		FROM VIGRUE_INVIO
		WHERE 
			((@DataInvioeqgreaterthanthis IS NULL) OR DATA_INVIO >= @DataInvioeqgreaterthanthis) AND 
			((@DataInvioeqlessthanthis IS NULL) OR DATA_INVIO <= @DataInvioeqlessthanthis) AND
			((@CodiceFondoEqualThis IS NULL) OR CODICE_FONDO = @CodiceFondoEqualThis)
		ORDER BY DATA_INVIO DESC

GO