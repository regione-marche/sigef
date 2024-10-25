CREATE PROCEDURE [dbo].[ZManifestazioneIstruttoriaFindSelect]
(
	@IdManifestazioneequalthis INT, 
	@Ricevibilitaequalthis CHAR(1), 
	@RicevibilitaDataequalthis DATETIME, 
	@RicevibilitaOperatoreequalthis VARCHAR(16), 
	@RicevibilitaSegnaturaequalthis VARCHAR(100), 
	@Ammissibilitaequalthis CHAR(1), 
	@AmmissibilitaDataequalthis DATETIME, 
	@AmmissibilitaOperatoreequalthis VARCHAR(16), 
	@AmmissibilitaSegnaturaequalthis VARCHAR(100), 
	@Rinunciaequalthis CHAR(1), 
	@RinunciaDataequalthis DATETIME, 
	@RinunciaOperatoreequalthis VARCHAR(16), 
	@RinunciaSegnaturaequalthis VARCHAR(100)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_MANIFESTAZIONE, RICEVIBILITA, RICEVIBILITA_DATA, RICEVIBILITA_OPERATORE, PROFILO, ENTE, ID_UTENTE, ID_PROFILO, NOMINATIVO, COD_ENTE, PROVINCIA, RICEVIBILITA_SEGNATURA, AMMISSIBILITA, AMMISSIBILITA_DATA, AMMISSIBILITA_OPERATORE, PROFILO_A, ENTE_A, ID_PROFILO_A, NOMINATIVO_A, COD_ENTE_A, PROVINCIA_A, AMMISSIBILITA_SEGNATURA, RINUNCIA, RINUNCIA_DATA, RINUNCIA_OPERATORE, RINUNCIA_SEGNATURA, PROFILO_RIN, ENTE_RIN, ID_PROFILO_RIN, NOMINATIVO_RIN, COD_ENTE_RIN, PROVINCIA_RIN, STATO_R, FASE_R, STATO_A, FASE_A, CF_COLLABORATORE, ID_BANDO, CUAA, PARTITA_IVA, RAGIONE_SOCIALE, COMUNE, SIGLA, CAP, VIA, NOMINATIVO_ISTRUTTORE, ID_MANIFESTAZIONE_COLLABORATORE FROM vMANIFESTAZIONE_ISTRUTTORIA WHERE 1=1';
	IF (@IdManifestazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_MANIFESTAZIONE = @IdManifestazioneequalthis)'; set @lensql=@lensql+len(@IdManifestazioneequalthis);end;
	IF (@Ricevibilitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RICEVIBILITA = @Ricevibilitaequalthis)'; set @lensql=@lensql+len(@Ricevibilitaequalthis);end;
	IF (@RicevibilitaDataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RICEVIBILITA_DATA = @RicevibilitaDataequalthis)'; set @lensql=@lensql+len(@RicevibilitaDataequalthis);end;
	IF (@RicevibilitaOperatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RICEVIBILITA_OPERATORE = @RicevibilitaOperatoreequalthis)'; set @lensql=@lensql+len(@RicevibilitaOperatoreequalthis);end;
	IF (@RicevibilitaSegnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RICEVIBILITA_SEGNATURA = @RicevibilitaSegnaturaequalthis)'; set @lensql=@lensql+len(@RicevibilitaSegnaturaequalthis);end;
	IF (@Ammissibilitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AMMISSIBILITA = @Ammissibilitaequalthis)'; set @lensql=@lensql+len(@Ammissibilitaequalthis);end;
	IF (@AmmissibilitaDataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AMMISSIBILITA_DATA = @AmmissibilitaDataequalthis)'; set @lensql=@lensql+len(@AmmissibilitaDataequalthis);end;
	IF (@AmmissibilitaOperatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AMMISSIBILITA_OPERATORE = @AmmissibilitaOperatoreequalthis)'; set @lensql=@lensql+len(@AmmissibilitaOperatoreequalthis);end;
	IF (@AmmissibilitaSegnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AMMISSIBILITA_SEGNATURA = @AmmissibilitaSegnaturaequalthis)'; set @lensql=@lensql+len(@AmmissibilitaSegnaturaequalthis);end;
	IF (@Rinunciaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RINUNCIA = @Rinunciaequalthis)'; set @lensql=@lensql+len(@Rinunciaequalthis);end;
	IF (@RinunciaDataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RINUNCIA_DATA = @RinunciaDataequalthis)'; set @lensql=@lensql+len(@RinunciaDataequalthis);end;
	IF (@RinunciaOperatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RINUNCIA_OPERATORE = @RinunciaOperatoreequalthis)'; set @lensql=@lensql+len(@RinunciaOperatoreequalthis);end;
	IF (@RinunciaSegnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RINUNCIA_SEGNATURA = @RinunciaSegnaturaequalthis)'; set @lensql=@lensql+len(@RinunciaSegnaturaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdManifestazioneequalthis INT, @Ricevibilitaequalthis CHAR(1), @RicevibilitaDataequalthis DATETIME, @RicevibilitaOperatoreequalthis VARCHAR(16), @RicevibilitaSegnaturaequalthis VARCHAR(100), @Ammissibilitaequalthis CHAR(1), @AmmissibilitaDataequalthis DATETIME, @AmmissibilitaOperatoreequalthis VARCHAR(16), @AmmissibilitaSegnaturaequalthis VARCHAR(100), @Rinunciaequalthis CHAR(1), @RinunciaDataequalthis DATETIME, @RinunciaOperatoreequalthis VARCHAR(16), @RinunciaSegnaturaequalthis VARCHAR(100)',@IdManifestazioneequalthis , @Ricevibilitaequalthis , @RicevibilitaDataequalthis , @RicevibilitaOperatoreequalthis , @RicevibilitaSegnaturaequalthis , @Ammissibilitaequalthis , @AmmissibilitaDataequalthis , @AmmissibilitaOperatoreequalthis , @AmmissibilitaSegnaturaequalthis , @Rinunciaequalthis , @RinunciaDataequalthis , @RinunciaOperatoreequalthis , @RinunciaSegnaturaequalthis ;
	else
		SELECT ID_MANIFESTAZIONE, RICEVIBILITA, RICEVIBILITA_DATA, RICEVIBILITA_OPERATORE, PROFILO, ENTE, ID_UTENTE, ID_PROFILO, NOMINATIVO, COD_ENTE, PROVINCIA, RICEVIBILITA_SEGNATURA, AMMISSIBILITA, AMMISSIBILITA_DATA, AMMISSIBILITA_OPERATORE, PROFILO_A, ENTE_A, ID_PROFILO_A, NOMINATIVO_A, COD_ENTE_A, PROVINCIA_A, AMMISSIBILITA_SEGNATURA, RINUNCIA, RINUNCIA_DATA, RINUNCIA_OPERATORE, RINUNCIA_SEGNATURA, PROFILO_RIN, ENTE_RIN, ID_PROFILO_RIN, NOMINATIVO_RIN, COD_ENTE_RIN, PROVINCIA_RIN, STATO_R, FASE_R, STATO_A, FASE_A, CF_COLLABORATORE, ID_BANDO, CUAA, PARTITA_IVA, RAGIONE_SOCIALE, COMUNE, SIGLA, CAP, VIA, NOMINATIVO_ISTRUTTORE, ID_MANIFESTAZIONE_COLLABORATORE
		FROM vMANIFESTAZIONE_ISTRUTTORIA
		WHERE 
			((@IdManifestazioneequalthis IS NULL) OR ID_MANIFESTAZIONE = @IdManifestazioneequalthis) AND 
			((@Ricevibilitaequalthis IS NULL) OR RICEVIBILITA = @Ricevibilitaequalthis) AND 
			((@RicevibilitaDataequalthis IS NULL) OR RICEVIBILITA_DATA = @RicevibilitaDataequalthis) AND 
			((@RicevibilitaOperatoreequalthis IS NULL) OR RICEVIBILITA_OPERATORE = @RicevibilitaOperatoreequalthis) AND 
			((@RicevibilitaSegnaturaequalthis IS NULL) OR RICEVIBILITA_SEGNATURA = @RicevibilitaSegnaturaequalthis) AND 
			((@Ammissibilitaequalthis IS NULL) OR AMMISSIBILITA = @Ammissibilitaequalthis) AND 
			((@AmmissibilitaDataequalthis IS NULL) OR AMMISSIBILITA_DATA = @AmmissibilitaDataequalthis) AND 
			((@AmmissibilitaOperatoreequalthis IS NULL) OR AMMISSIBILITA_OPERATORE = @AmmissibilitaOperatoreequalthis) AND 
			((@AmmissibilitaSegnaturaequalthis IS NULL) OR AMMISSIBILITA_SEGNATURA = @AmmissibilitaSegnaturaequalthis) AND 
			((@Rinunciaequalthis IS NULL) OR RINUNCIA = @Rinunciaequalthis) AND 
			((@RinunciaDataequalthis IS NULL) OR RINUNCIA_DATA = @RinunciaDataequalthis) AND 
			((@RinunciaOperatoreequalthis IS NULL) OR RINUNCIA_OPERATORE = @RinunciaOperatoreequalthis) AND 
			((@RinunciaSegnaturaequalthis IS NULL) OR RINUNCIA_SEGNATURA = @RinunciaSegnaturaequalthis)
