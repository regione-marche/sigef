CREATE PROCEDURE [dbo].[ZManifestazioneDiInteresseAllegatiFindSelect]
(
	@IdAllegatoequalthis INT, 
	@IdManifestazioneequalthis INT, 
	@Descrizioneequalthis VARCHAR(255), 
	@CodEsitoequalthis CHAR(2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ALLEGATO, ID_MANIFESTAZIONE, DESCRIZIONE, COD_ESITO, NOTE_ISTRUTTORE FROM MANIFESTAZIONE_DI_INTERESSE_ALLEGATI WHERE 1=1';
	IF (@IdAllegatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ALLEGATO = @IdAllegatoequalthis)'; set @lensql=@lensql+len(@IdAllegatoequalthis);end;
	IF (@IdManifestazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_MANIFESTAZIONE = @IdManifestazioneequalthis)'; set @lensql=@lensql+len(@IdManifestazioneequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@CodEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ESITO = @CodEsitoequalthis)'; set @lensql=@lensql+len(@CodEsitoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdAllegatoequalthis INT, @IdManifestazioneequalthis INT, @Descrizioneequalthis VARCHAR(255), @CodEsitoequalthis CHAR(2)',@IdAllegatoequalthis , @IdManifestazioneequalthis , @Descrizioneequalthis , @CodEsitoequalthis ;
	else
		SELECT ID_ALLEGATO, ID_MANIFESTAZIONE, DESCRIZIONE, COD_ESITO, NOTE_ISTRUTTORE
		FROM MANIFESTAZIONE_DI_INTERESSE_ALLEGATI
		WHERE 
			((@IdAllegatoequalthis IS NULL) OR ID_ALLEGATO = @IdAllegatoequalthis) AND 
			((@IdManifestazioneequalthis IS NULL) OR ID_MANIFESTAZIONE = @IdManifestazioneequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@CodEsitoequalthis IS NULL) OR COD_ESITO = @CodEsitoequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZManifestazioneDiInteresseAllegatiFindSelect';

