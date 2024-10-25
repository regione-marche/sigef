CREATE PROCEDURE [dbo].[ZProgettoComunicazioniAllegatiFindFind]
(
	@IdComunicazioneequalthis INT, 
	@IdProgettoAllegatiequalthis INT, 
	@IdAllegatoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_COMUNICAZIONE, ID_PROGETTO_ALLEGATI, ID_ALLEGATO, ID_NOTE, NOTE, DESCRIZIONE_BREVE, NUMERO, DATA, ENTE, ID_PROGETTO, ID_COMUNE, COD_ENTE_EMETTITORE, ALLEGATO, COD_TIPO FROM vPROGETTO_COMUNICAZIONI_ALLEGATI WHERE 1=1';
	IF (@IdComunicazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COMUNICAZIONE = @IdComunicazioneequalthis)'; set @lensql=@lensql+len(@IdComunicazioneequalthis);end;
	IF (@IdProgettoAllegatiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO_ALLEGATI = @IdProgettoAllegatiequalthis)'; set @lensql=@lensql+len(@IdProgettoAllegatiequalthis);end;
	IF (@IdAllegatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ALLEGATO = @IdAllegatoequalthis)'; set @lensql=@lensql+len(@IdAllegatoequalthis);end;
	set @sql = @sql + 'ORDER BY ID';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdComunicazioneequalthis INT, @IdProgettoAllegatiequalthis INT, @IdAllegatoequalthis INT',@IdComunicazioneequalthis , @IdProgettoAllegatiequalthis , @IdAllegatoequalthis ;
	else
		SELECT ID, ID_COMUNICAZIONE, ID_PROGETTO_ALLEGATI, ID_ALLEGATO, ID_NOTE, NOTE, DESCRIZIONE_BREVE, NUMERO, DATA, ENTE, ID_PROGETTO, ID_COMUNE, COD_ENTE_EMETTITORE, ALLEGATO, COD_TIPO
		FROM vPROGETTO_COMUNICAZIONI_ALLEGATI
		WHERE 
			((@IdComunicazioneequalthis IS NULL) OR ID_COMUNICAZIONE = @IdComunicazioneequalthis) AND 
			((@IdProgettoAllegatiequalthis IS NULL) OR ID_PROGETTO_ALLEGATI = @IdProgettoAllegatiequalthis) AND 
			((@IdAllegatoequalthis IS NULL) OR ID_ALLEGATO = @IdAllegatoequalthis)
		ORDER BY ID


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoComunicazioniAllegatiFindFind';

