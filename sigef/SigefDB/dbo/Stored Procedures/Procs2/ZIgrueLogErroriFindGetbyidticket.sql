CREATE PROCEDURE [dbo].[ZIgrueLogErroriFindGetbyidticket]
(
	@IdTicketequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_IGRUE_LOG_ERRORI, ID_INVIO, ID_TICKET, DATA_RICHIESTA, FILE_ERRORI, ISTANZA_ERRORI, ID_OPERATORE, CODICE_ESITO, DESCRIZIONE_ESITO, DETTAGLIO_ESITO, TIMESTAMP_ESITO, TIPO_FILE FROM VIGRUE_LOG_ERRORI WHERE 1=1';
	IF (@IdTicketequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_TICKET = @IdTicketequalthis)'; set @lensql=@lensql+len(@IdTicketequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdTicketequalthis VARCHAR(255)',@IdTicketequalthis ;
	else
		SELECT ID_IGRUE_LOG_ERRORI, ID_INVIO, ID_TICKET, DATA_RICHIESTA, FILE_ERRORI, ISTANZA_ERRORI, ID_OPERATORE, CODICE_ESITO, DESCRIZIONE_ESITO, DETTAGLIO_ESITO, TIMESTAMP_ESITO, TIPO_FILE
		FROM VIGRUE_LOG_ERRORI
		WHERE 
			((@IdTicketequalthis IS NULL) OR ID_TICKET = @IdTicketequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIgrueLogErroriFindGetbyidticket';

