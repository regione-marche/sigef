CREATE PROCEDURE [dbo].[ZIgrueInvioFindGetbyidinvio]
(
	@IdInvioequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_INVIO, ID_TICKET, DATA_INVIO, DATA_DA, DATA_A, FILE_INVIO, ID_OPERATORE, CODICE_ESITO, DESCRIZIONE_ESITO, DETTAGLIO_ESITO, TIMESTAMP_ESITO, TIPO_FILE, ID_IGRUE_LOG_ERRORI, DATA_RICHIESTA, FILE_ERRORI, ISTANZA_ERRORI, ID_OPERATORE_LOG, CODICE_ESITO_LOG, DESCRIZIONE_ESITO_LOG, DETTAGLIO_ESITO_LOG, TIMESTAMP_ESITO_LOG, TIPO_FILE_LOG FROM VIGRUE_INVIO WHERE 1=1';
	IF (@IdInvioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INVIO = @IdInvioequalthis)'; set @lensql=@lensql+len(@IdInvioequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdInvioequalthis INT',@IdInvioequalthis ;
	else
		SELECT ID_INVIO, ID_TICKET, DATA_INVIO, DATA_DA, DATA_A, FILE_INVIO, ID_OPERATORE, CODICE_ESITO, DESCRIZIONE_ESITO, DETTAGLIO_ESITO, TIMESTAMP_ESITO, TIPO_FILE, ID_IGRUE_LOG_ERRORI, DATA_RICHIESTA, FILE_ERRORI, ISTANZA_ERRORI, ID_OPERATORE_LOG, CODICE_ESITO_LOG, DESCRIZIONE_ESITO_LOG, DETTAGLIO_ESITO_LOG, TIMESTAMP_ESITO_LOG, TIPO_FILE_LOG
		FROM VIGRUE_INVIO
		WHERE 
			((@IdInvioequalthis IS NULL) OR ID_INVIO = @IdInvioequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZIgrueInvioFindGetbyidinvio]
(
	@IdInvioequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_INVIO, ID_TICKET, DATA_INVIO, DATA_DA, DATA_A, FILE_INVIO, ID_OPERATORE, CODICE_ESITO, DESCRIZIONE_ESITO, DETTAGLIO_ESITO, TIMESTAMP_ESITO, TIPO_FILE FROM VIGRUE_INVIO WHERE 1=1'';
	IF (@IdInvioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_INVIO = @IdInvioequalthis)''; set @lensql=@lensql+len(@IdInvioequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdInvioequalthis INT'',@IdInvioequalthis ;
	else
		SELECT ID_INVIO, ID_TICKET, DATA_INVIO, DATA_DA, DATA_A, FILE_INVIO, ID_OPERATORE, CODICE_ESITO, DESCRIZIONE_ESITO, DETTAGLIO_ESITO, TIMESTAMP_ESITO, TIPO_FILE
		FROM VIGRUE_INVIO
		WHERE 
			((@IdInvioequalthis IS NULL) OR ID_INVIO = @IdInvioequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIgrueInvioFindGetbyidinvio';

