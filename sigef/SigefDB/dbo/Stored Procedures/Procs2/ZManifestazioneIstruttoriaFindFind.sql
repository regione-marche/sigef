CREATE PROCEDURE [dbo].[ZManifestazioneIstruttoriaFindFind]
(
	@IdManifestazioneCollaboratoreequalthis INT, 
	@Ricevibilitaequalthis CHAR(1), 
	@Ammissibilitaequalthis CHAR(1), 
	@Rinunciaequalthis CHAR(1), 
	@FaseRequalthis CHAR(1), 
	@FaseAequalthis CHAR(1), 
	@CfCollaboratoreequalthis VARCHAR(16), 
	@IdBandoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_MANIFESTAZIONE, RICEVIBILITA, RICEVIBILITA_DATA, RICEVIBILITA_OPERATORE, PROFILO, ENTE, ID_UTENTE, ID_PROFILO, NOMINATIVO, COD_ENTE, PROVINCIA, RICEVIBILITA_SEGNATURA, AMMISSIBILITA, AMMISSIBILITA_DATA, AMMISSIBILITA_OPERATORE, PROFILO_A, ENTE_A, ID_PROFILO_A, NOMINATIVO_A, COD_ENTE_A, PROVINCIA_A, AMMISSIBILITA_SEGNATURA, RINUNCIA, RINUNCIA_DATA, RINUNCIA_OPERATORE, RINUNCIA_SEGNATURA, PROFILO_RIN, ENTE_RIN, ID_PROFILO_RIN, NOMINATIVO_RIN, COD_ENTE_RIN, PROVINCIA_RIN, STATO_R, FASE_R, STATO_A, FASE_A, CF_COLLABORATORE, ID_BANDO, CUAA, PARTITA_IVA, RAGIONE_SOCIALE, COMUNE, SIGLA, CAP, VIA, NOMINATIVO_ISTRUTTORE, ID_MANIFESTAZIONE_COLLABORATORE FROM vMANIFESTAZIONE_ISTRUTTORIA WHERE 1=1';
	IF (@IdManifestazioneCollaboratoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_MANIFESTAZIONE_COLLABORATORE = @IdManifestazioneCollaboratoreequalthis)'; set @lensql=@lensql+len(@IdManifestazioneCollaboratoreequalthis);end;
	IF (@Ricevibilitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RICEVIBILITA = @Ricevibilitaequalthis)'; set @lensql=@lensql+len(@Ricevibilitaequalthis);end;
	IF (@Ammissibilitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AMMISSIBILITA = @Ammissibilitaequalthis)'; set @lensql=@lensql+len(@Ammissibilitaequalthis);end;
	IF (@Rinunciaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RINUNCIA = @Rinunciaequalthis)'; set @lensql=@lensql+len(@Rinunciaequalthis);end;
	IF (@FaseRequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FASE_R = @FaseRequalthis)'; set @lensql=@lensql+len(@FaseRequalthis);end;
	IF (@FaseAequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FASE_A = @FaseAequalthis)'; set @lensql=@lensql+len(@FaseAequalthis);end;
	IF (@CfCollaboratoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_COLLABORATORE = @CfCollaboratoreequalthis)'; set @lensql=@lensql+len(@CfCollaboratoreequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdManifestazioneCollaboratoreequalthis INT, @Ricevibilitaequalthis CHAR(1), @Ammissibilitaequalthis CHAR(1), @Rinunciaequalthis CHAR(1), @FaseRequalthis CHAR(1), @FaseAequalthis CHAR(1), @CfCollaboratoreequalthis VARCHAR(16), @IdBandoequalthis INT',@IdManifestazioneCollaboratoreequalthis , @Ricevibilitaequalthis , @Ammissibilitaequalthis , @Rinunciaequalthis , @FaseRequalthis , @FaseAequalthis , @CfCollaboratoreequalthis , @IdBandoequalthis ;
	else
		SELECT ID_MANIFESTAZIONE, RICEVIBILITA, RICEVIBILITA_DATA, RICEVIBILITA_OPERATORE, PROFILO, ENTE, ID_UTENTE, ID_PROFILO, NOMINATIVO, COD_ENTE, PROVINCIA, RICEVIBILITA_SEGNATURA, AMMISSIBILITA, AMMISSIBILITA_DATA, AMMISSIBILITA_OPERATORE, PROFILO_A, ENTE_A, ID_PROFILO_A, NOMINATIVO_A, COD_ENTE_A, PROVINCIA_A, AMMISSIBILITA_SEGNATURA, RINUNCIA, RINUNCIA_DATA, RINUNCIA_OPERATORE, RINUNCIA_SEGNATURA, PROFILO_RIN, ENTE_RIN, ID_PROFILO_RIN, NOMINATIVO_RIN, COD_ENTE_RIN, PROVINCIA_RIN, STATO_R, FASE_R, STATO_A, FASE_A, CF_COLLABORATORE, ID_BANDO, CUAA, PARTITA_IVA, RAGIONE_SOCIALE, COMUNE, SIGLA, CAP, VIA, NOMINATIVO_ISTRUTTORE, ID_MANIFESTAZIONE_COLLABORATORE
		FROM vMANIFESTAZIONE_ISTRUTTORIA
		WHERE 
			((@IdManifestazioneCollaboratoreequalthis IS NULL) OR ID_MANIFESTAZIONE_COLLABORATORE = @IdManifestazioneCollaboratoreequalthis) AND 
			((@Ricevibilitaequalthis IS NULL) OR RICEVIBILITA = @Ricevibilitaequalthis) AND 
			((@Ammissibilitaequalthis IS NULL) OR AMMISSIBILITA = @Ammissibilitaequalthis) AND 
			((@Rinunciaequalthis IS NULL) OR RINUNCIA = @Rinunciaequalthis) AND 
			((@FaseRequalthis IS NULL) OR FASE_R = @FaseRequalthis) AND 
			((@FaseAequalthis IS NULL) OR FASE_A = @FaseAequalthis) AND 
			((@CfCollaboratoreequalthis IS NULL) OR CF_COLLABORATORE = @CfCollaboratoreequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis)
