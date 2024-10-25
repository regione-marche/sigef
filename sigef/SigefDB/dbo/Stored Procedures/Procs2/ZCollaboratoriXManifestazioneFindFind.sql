CREATE PROCEDURE [dbo].[ZCollaboratoriXManifestazioneFindFind]
(
	@IdBandoequalthis INT, 
	@IdManifestazioneequalthis INT, 
	@CfUtenteequalthis VARCHAR(16), 
	@Cuaalikethis VARCHAR(16), 
	@RagioneSocialelikethis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_COLLABORATORE, ID_BANDO, ID_MANIFESTAZIONE, ID_UTENTE, CF_UTENTE, OPERATORE, DATA_INSERIMENTO, CUAA, RAGIONE_SOCIALE, VIA, COMUNE, CAP, SIGLA, DATA_ULTIMA_MODIFICA, NOMINATIVO, COD_ENTE, PROVINCIA, SEGNATURA FROM vCOLLABORATORI_X_MANIFESTAZIONE WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdManifestazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_MANIFESTAZIONE = @IdManifestazioneequalthis)'; set @lensql=@lensql+len(@IdManifestazioneequalthis);end;
	IF (@CfUtenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_UTENTE = @CfUtenteequalthis)'; set @lensql=@lensql+len(@CfUtenteequalthis);end;
	IF (@Cuaalikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CUAA LIKE @Cuaalikethis)'; set @lensql=@lensql+len(@Cuaalikethis);end;
	IF (@RagioneSocialelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RAGIONE_SOCIALE LIKE @RagioneSocialelikethis)'; set @lensql=@lensql+len(@RagioneSocialelikethis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @IdManifestazioneequalthis INT, @CfUtenteequalthis VARCHAR(16), @Cuaalikethis VARCHAR(16), @RagioneSocialelikethis VARCHAR(255)',@IdBandoequalthis , @IdManifestazioneequalthis , @CfUtenteequalthis , @Cuaalikethis , @RagioneSocialelikethis ;
	else
		SELECT ID_COLLABORATORE, ID_BANDO, ID_MANIFESTAZIONE, ID_UTENTE, CF_UTENTE, OPERATORE, DATA_INSERIMENTO, CUAA, RAGIONE_SOCIALE, VIA, COMUNE, CAP, SIGLA, DATA_ULTIMA_MODIFICA, NOMINATIVO, COD_ENTE, PROVINCIA, SEGNATURA
		FROM vCOLLABORATORI_X_MANIFESTAZIONE
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdManifestazioneequalthis IS NULL) OR ID_MANIFESTAZIONE = @IdManifestazioneequalthis) AND 
			((@CfUtenteequalthis IS NULL) OR CF_UTENTE = @CfUtenteequalthis) AND 
			((@Cuaalikethis IS NULL) OR CUAA LIKE @Cuaalikethis) AND 
			((@RagioneSocialelikethis IS NULL) OR RAGIONE_SOCIALE LIKE @RagioneSocialelikethis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCollaboratoriXManifestazioneFindFind';

