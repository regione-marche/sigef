CREATE PROCEDURE [dbo].[ZCollaboratoriXBandoFindSelect]
(
	@IdCollaboratoreequalthis INT, 
	@IdBandoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdUtenteequalthis INT, 
	@Provinciaequalthis CHAR(2), 
	@OperatoreInserimentoequalthis INT, 
	@DataInserimentoequalthis DATETIME, 
	@OperatoreFineValiditaequalthis INT, 
	@DataFineValiditaequalthis DATETIME, 
	@Attivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_COLLABORATORE, ID_BANDO, ID_PROGETTO, PROVINCIA, DATA_INSERIMENTO, DATA_FINE_VALIDITA, NOMINATIVO, COD_ENTE, PROVINCIA_UTENTE, ID_UTENTE, OPERATORE_INSERIMENTO, OPERATORE_FINE_VALIDITA, ATTIVO FROM vCOLLABORATORI_X_BANDO WHERE 1=1';
	IF (@IdCollaboratoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COLLABORATORE = @IdCollaboratoreequalthis)'; set @lensql=@lensql+len(@IdCollaboratoreequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdUtenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE = @IdUtenteequalthis)'; set @lensql=@lensql+len(@IdUtenteequalthis);end;
	IF (@Provinciaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROVINCIA = @Provinciaequalthis)'; set @lensql=@lensql+len(@Provinciaequalthis);end;
	IF (@OperatoreInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_INSERIMENTO = @OperatoreInserimentoequalthis)'; set @lensql=@lensql+len(@OperatoreInserimentoequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@OperatoreFineValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_FINE_VALIDITA = @OperatoreFineValiditaequalthis)'; set @lensql=@lensql+len(@OperatoreFineValiditaequalthis);end;
	IF (@DataFineValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE_VALIDITA = @DataFineValiditaequalthis)'; set @lensql=@lensql+len(@DataFineValiditaequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdCollaboratoreequalthis INT, @IdBandoequalthis INT, @IdProgettoequalthis INT, @IdUtenteequalthis INT, @Provinciaequalthis CHAR(2), @OperatoreInserimentoequalthis INT, @DataInserimentoequalthis DATETIME, @OperatoreFineValiditaequalthis INT, @DataFineValiditaequalthis DATETIME, @Attivoequalthis BIT',@IdCollaboratoreequalthis , @IdBandoequalthis , @IdProgettoequalthis , @IdUtenteequalthis , @Provinciaequalthis , @OperatoreInserimentoequalthis , @DataInserimentoequalthis , @OperatoreFineValiditaequalthis , @DataFineValiditaequalthis , @Attivoequalthis ;
	else
		SELECT ID_COLLABORATORE, ID_BANDO, ID_PROGETTO, PROVINCIA, DATA_INSERIMENTO, DATA_FINE_VALIDITA, NOMINATIVO, COD_ENTE, PROVINCIA_UTENTE, ID_UTENTE, OPERATORE_INSERIMENTO, OPERATORE_FINE_VALIDITA, ATTIVO
		FROM vCOLLABORATORI_X_BANDO
		WHERE 
			((@IdCollaboratoreequalthis IS NULL) OR ID_COLLABORATORE = @IdCollaboratoreequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdUtenteequalthis IS NULL) OR ID_UTENTE = @IdUtenteequalthis) AND 
			((@Provinciaequalthis IS NULL) OR PROVINCIA = @Provinciaequalthis) AND 
			((@OperatoreInserimentoequalthis IS NULL) OR OPERATORE_INSERIMENTO = @OperatoreInserimentoequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@OperatoreFineValiditaequalthis IS NULL) OR OPERATORE_FINE_VALIDITA = @OperatoreFineValiditaequalthis) AND 
			((@DataFineValiditaequalthis IS NULL) OR DATA_FINE_VALIDITA = @DataFineValiditaequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis)
