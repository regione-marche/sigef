CREATE PROCEDURE [dbo].[ZIgrueLogErroriFindGetbyidinvioSenzaFile]
(
	@IdInvioequalthis INT,
	@CodiceFondoEqualThis VARCHAR(20)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_IGRUE_LOG_ERRORI, ID_INVIO, ID_TICKET, DATA_RICHIESTA, NULL AS FILE_ERRORI, ISTANZA_ERRORI, ID_OPERATORE, CODICE_ESITO, DESCRIZIONE_ESITO, DETTAGLIO_ESITO, TIMESTAMP_ESITO, TIPO_FILE, CODICE_FONDO FROM VIGRUE_LOG_ERRORI WHERE 1=1';
	IF (@IdInvioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INVIO = @IdInvioequalthis)'; set @lensql=@lensql+len(@IdInvioequalthis);end;
	IF (@CodiceFondoEqualThis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_FONDO = @CodiceFondoEqualThis)'; set @lensql=@lensql+len(@CodiceFondoEqualThis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdInvioequalthis INT, @CodiceFondoEqualThis VARCHAR(20)',@IdInvioequalthis, @CodiceFondoEqualThis ;
	else
		SELECT ID_IGRUE_LOG_ERRORI, ID_INVIO, ID_TICKET, DATA_RICHIESTA, NULL AS FILE_ERRORI, ISTANZA_ERRORI, ID_OPERATORE, CODICE_ESITO, DESCRIZIONE_ESITO, DETTAGLIO_ESITO, TIMESTAMP_ESITO, TIPO_FILE, CODICE_FONDO
		FROM VIGRUE_LOG_ERRORI
		WHERE 
			((@IdInvioequalthis IS NULL) OR ID_INVIO = @IdInvioequalthis) AND
			((@CodiceFondoEqualThis IS NULL) OR CODICE_FONDO = @CodiceFondoEqualThis)
		

GO
