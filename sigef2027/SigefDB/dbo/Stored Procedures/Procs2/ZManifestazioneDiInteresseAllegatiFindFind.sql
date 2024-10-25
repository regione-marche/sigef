CREATE PROCEDURE [dbo].[ZManifestazioneDiInteresseAllegatiFindFind]
(
	@IdAllegatoequalthis INT, 
	@IdManifestazioneequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ALLEGATO, ID_MANIFESTAZIONE, DESCRIZIONE, COD_ESITO, NOTE_ISTRUTTORE FROM MANIFESTAZIONE_DI_INTERESSE_ALLEGATI WHERE 1=1';
	IF (@IdAllegatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ALLEGATO = @IdAllegatoequalthis)'; set @lensql=@lensql+len(@IdAllegatoequalthis);end;
	IF (@IdManifestazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_MANIFESTAZIONE = @IdManifestazioneequalthis)'; set @lensql=@lensql+len(@IdManifestazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdAllegatoequalthis INT, @IdManifestazioneequalthis INT',@IdAllegatoequalthis , @IdManifestazioneequalthis ;
	else
		SELECT ID_ALLEGATO, ID_MANIFESTAZIONE, DESCRIZIONE, COD_ESITO, NOTE_ISTRUTTORE
		FROM MANIFESTAZIONE_DI_INTERESSE_ALLEGATI
		WHERE 
			((@IdAllegatoequalthis IS NULL) OR ID_ALLEGATO = @IdAllegatoequalthis) AND 
			((@IdManifestazioneequalthis IS NULL) OR ID_MANIFESTAZIONE = @IdManifestazioneequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZManifestazioneDiInteresseAllegatiFindFind';

