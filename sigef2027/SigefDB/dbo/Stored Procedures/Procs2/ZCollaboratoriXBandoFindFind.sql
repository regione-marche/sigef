CREATE PROCEDURE [dbo].[ZCollaboratoriXBandoFindFind]
(
	@IdBandoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdUtenteequalthis INT, 
	@Provinciaequalthis CHAR(2), 
	@Attivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_COLLABORATORE, ID_BANDO, ID_PROGETTO, PROVINCIA, DATA_INSERIMENTO, DATA_FINE_VALIDITA, NOMINATIVO, COD_ENTE, PROVINCIA_UTENTE, ID_UTENTE, OPERATORE_INSERIMENTO, OPERATORE_FINE_VALIDITA, ATTIVO FROM vCOLLABORATORI_X_BANDO WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdUtenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE = @IdUtenteequalthis)'; set @lensql=@lensql+len(@IdUtenteequalthis);end;
	IF (@Provinciaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROVINCIA = @Provinciaequalthis)'; set @lensql=@lensql+len(@Provinciaequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	set @sql = @sql + 'ORDER BY ID_PROGETTO';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @IdProgettoequalthis INT, @IdUtenteequalthis INT, @Provinciaequalthis CHAR(2), @Attivoequalthis BIT',@IdBandoequalthis , @IdProgettoequalthis , @IdUtenteequalthis , @Provinciaequalthis , @Attivoequalthis ;
	else
		SELECT ID_COLLABORATORE, ID_BANDO, ID_PROGETTO, PROVINCIA, DATA_INSERIMENTO, DATA_FINE_VALIDITA, NOMINATIVO, COD_ENTE, PROVINCIA_UTENTE, ID_UTENTE, OPERATORE_INSERIMENTO, OPERATORE_FINE_VALIDITA, ATTIVO
		FROM vCOLLABORATORI_X_BANDO
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdUtenteequalthis IS NULL) OR ID_UTENTE = @IdUtenteequalthis) AND 
			((@Provinciaequalthis IS NULL) OR PROVINCIA = @Provinciaequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis)
		ORDER BY ID_PROGETTO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZCollaboratoriXBandoFindFind]
(
	@IdCollaboratoreequalthis INT, 
	@IdBandoequalthis INT, 
	@CfUtenteequalthis VARCHAR(16), 
	@IdProgettoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_COLLABORATORE, ID_BANDO, ID_PROGETTO, CF_UTENTE, PROVINCIA, OPERATORE, DATA_INSERIMENTO, DATA_FINE_VALIDITA, NOMINATIVO, COD_ENTE, PROVINCIA_UTENTE, ID_PROG_INTEGRATO, DATA_ULTIMA_MODIFICA, FLAG_PREADESIONE, FLAG_DEFINITIVO, CUAA, OPERATORE_DI_PRESENTAZIONE, DATA_INIZIO, DATA_FINE, OPERATORE_STATO_PROGETTO, STATO, COD_STATO, SEGNATURA, ORDINE, PROVINCIA_DI_PRESENTAZIONE, SEGNATURA_STATO, DESCRIZIONE, ID_IMPRESA, CODICE_FISCALE, RAGIONE_SOCIALE, COMUNE, CAP, SIGLA, SELEZIONATA_X_REVISIONE, REVISIONE, RICORSO, ID_MON_STATO_PROGETTO, SEGNATURA_RI, OPERATORE_RI, DATA_RI, RIESAME FROM vCOLLABORATORI_X_BANDO WHERE 1=1'';
	IF (@IdCollaboratoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_COLLABORATORE = @IdCollaboratoreequalthis)''; set @lensql=@lensql+len(@IdCollaboratoreequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CfUtenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CF_UTENTE = @CfUtenteequalthis)''; set @lensql=@lensql+len(@CfUtenteequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	set @sql = @sql + ''ORDER BY ID_PROGETTO'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdCollaboratoreequalthis INT, @IdBandoequalthis INT, @CfUtenteequalthis VARCHAR(16), @IdProgettoequalthis INT'',@IdCollaboratoreequalthis , @IdBandoequalthis , @CfUtenteequalthis , @IdProgettoequalthis ;
	else
		SELECT ID_COLLABORATORE, ID_BANDO, ID_PROGETTO, CF_UTENTE, PROVINCIA, OPERATORE, DATA_INSERIMENTO, DATA_FINE_VALIDITA, NOMINATIVO, COD_ENTE, PROVINCIA_UTENTE, ID_PROG_INTEGRATO, DATA_ULTIMA_MODIFICA, FLAG_PREADESIONE, FLAG_DEFINITIVO, CUAA, OPERATORE_DI_PRESENTAZIONE, DATA_INIZIO, DATA_FINE, OPERATORE_STATO_PROGETTO, STATO, COD_STATO, SEGNATURA, ORDINE, PROVINCIA_DI_PRESENTAZIONE, SEGNATURA_STATO, DESCRIZIONE, ID_IMPRESA, CODICE_FISCALE, RAGIONE_SOCIALE, COMUNE, CAP, SIGLA, SELEZIONATA_X_REVISIONE, REVISIONE, RICORSO, ID_MON_STATO_PROGETTO, SEGNATURA_RI, OPERATORE_RI, DATA_RI, RIESAME
		FROM vCOLLABORATORI_X_BANDO
		WHERE 
			((@IdCollaboratoreequalthis IS NULL) OR ID_COLLABORATORE = @IdCollaboratoreequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@CfUtenteequalthis IS NULL) OR CF_UTENTE = @CfUtenteequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis)
		ORDER BY ID_PROGETTO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCollaboratoriXBandoFindFind';

