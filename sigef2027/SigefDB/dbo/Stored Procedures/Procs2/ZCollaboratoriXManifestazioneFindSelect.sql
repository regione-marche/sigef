CREATE PROCEDURE [dbo].[ZCollaboratoriXManifestazioneFindSelect]
(
	@IdCollaboratoreequalthis INT, 
	@IdBandoequalthis INT, 
	@IdManifestazioneequalthis INT, 
	@CfUtenteequalthis VARCHAR(16), 
	@Operatoreequalthis VARCHAR(16), 
	@DataInserimentoequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_COLLABORATORE, ID_BANDO, ID_MANIFESTAZIONE, ID_UTENTE, CF_UTENTE, OPERATORE, DATA_INSERIMENTO, CUAA, RAGIONE_SOCIALE, VIA, COMUNE, CAP, SIGLA, DATA_ULTIMA_MODIFICA, NOMINATIVO, COD_ENTE, PROVINCIA, SEGNATURA FROM vCOLLABORATORI_X_MANIFESTAZIONE WHERE 1=1';
	IF (@IdCollaboratoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COLLABORATORE = @IdCollaboratoreequalthis)'; set @lensql=@lensql+len(@IdCollaboratoreequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdManifestazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_MANIFESTAZIONE = @IdManifestazioneequalthis)'; set @lensql=@lensql+len(@IdManifestazioneequalthis);end;
	IF (@CfUtenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_UTENTE = @CfUtenteequalthis)'; set @lensql=@lensql+len(@CfUtenteequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdCollaboratoreequalthis INT, @IdBandoequalthis INT, @IdManifestazioneequalthis INT, @CfUtenteequalthis VARCHAR(16), @Operatoreequalthis VARCHAR(16), @DataInserimentoequalthis DATETIME',@IdCollaboratoreequalthis , @IdBandoequalthis , @IdManifestazioneequalthis , @CfUtenteequalthis , @Operatoreequalthis , @DataInserimentoequalthis ;
	else
		SELECT ID_COLLABORATORE, ID_BANDO, ID_MANIFESTAZIONE, ID_UTENTE, CF_UTENTE, OPERATORE, DATA_INSERIMENTO, CUAA, RAGIONE_SOCIALE, VIA, COMUNE, CAP, SIGLA, DATA_ULTIMA_MODIFICA, NOMINATIVO, COD_ENTE, PROVINCIA, SEGNATURA
		FROM vCOLLABORATORI_X_MANIFESTAZIONE
		WHERE 
			((@IdCollaboratoreequalthis IS NULL) OR ID_COLLABORATORE = @IdCollaboratoreequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdManifestazioneequalthis IS NULL) OR ID_MANIFESTAZIONE = @IdManifestazioneequalthis) AND 
			((@CfUtenteequalthis IS NULL) OR CF_UTENTE = @CfUtenteequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCollaboratoriXManifestazioneFindSelect';

