CREATE PROCEDURE [dbo].[ZProgettoComunicazioniAllegatiFindSelect]
(
	@Idequalthis INT, 
	@IdComunicazioneequalthis INT, 
	@IdProgettoAllegatiequalthis INT, 
	@IdAllegatoequalthis INT, 
	@IdNoteequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_COMUNICAZIONE, ID_PROGETTO_ALLEGATI, ID_ALLEGATO, ID_NOTE, NOTE, DESCRIZIONE_BREVE, NUMERO, DATA, ENTE, ID_PROGETTO, ID_COMUNE, COD_ENTE_EMETTITORE, ALLEGATO, COD_TIPO FROM vPROGETTO_COMUNICAZIONI_ALLEGATI WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdComunicazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COMUNICAZIONE = @IdComunicazioneequalthis)'; set @lensql=@lensql+len(@IdComunicazioneequalthis);end;
	IF (@IdProgettoAllegatiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO_ALLEGATI = @IdProgettoAllegatiequalthis)'; set @lensql=@lensql+len(@IdProgettoAllegatiequalthis);end;
	IF (@IdAllegatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ALLEGATO = @IdAllegatoequalthis)'; set @lensql=@lensql+len(@IdAllegatoequalthis);end;
	IF (@IdNoteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_NOTE = @IdNoteequalthis)'; set @lensql=@lensql+len(@IdNoteequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @IdComunicazioneequalthis INT, @IdProgettoAllegatiequalthis INT, @IdAllegatoequalthis INT, @IdNoteequalthis INT',@Idequalthis , @IdComunicazioneequalthis , @IdProgettoAllegatiequalthis , @IdAllegatoequalthis , @IdNoteequalthis ;
	else
		SELECT ID, ID_COMUNICAZIONE, ID_PROGETTO_ALLEGATI, ID_ALLEGATO, ID_NOTE, NOTE, DESCRIZIONE_BREVE, NUMERO, DATA, ENTE, ID_PROGETTO, ID_COMUNE, COD_ENTE_EMETTITORE, ALLEGATO, COD_TIPO
		FROM vPROGETTO_COMUNICAZIONI_ALLEGATI
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdComunicazioneequalthis IS NULL) OR ID_COMUNICAZIONE = @IdComunicazioneequalthis) AND 
			((@IdProgettoAllegatiequalthis IS NULL) OR ID_PROGETTO_ALLEGATI = @IdProgettoAllegatiequalthis) AND 
			((@IdAllegatoequalthis IS NULL) OR ID_ALLEGATO = @IdAllegatoequalthis) AND 
			((@IdNoteequalthis IS NULL) OR ID_NOTE = @IdNoteequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoComunicazioniAllegatiFindSelect';

