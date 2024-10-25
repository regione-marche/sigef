CREATE PROCEDURE [dbo].[ZBandoValidatoriFindSelect]
(
	@Idequalthis INT, 
	@IdBandoequalthis INT, 
	@IdUtenteequalthis INT, 
	@Responsabileequalthis BIT, 
	@Attivoequalthis BIT, 
	@DataInizioequalthis DATETIME, 
	@OperatoreInizioequalthis INT, 
	@DataFineequalthis DATETIME, 
	@OperatoreFineequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_BANDO, ID_UTENTE, RESPONSABILE, ATTIVO, DATA_INIZIO, OPERATORE_INIZIO, DATA_FINE, OPERATORE_FINE, NOMINATIVO, PROFILO, ENTE, COD_ENTE FROM vBANDO_VALIDATORI WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdUtenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE = @IdUtenteequalthis)'; set @lensql=@lensql+len(@IdUtenteequalthis);end;
	IF (@Responsabileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RESPONSABILE = @Responsabileequalthis)'; set @lensql=@lensql+len(@Responsabileequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@DataInizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INIZIO = @DataInizioequalthis)'; set @lensql=@lensql+len(@DataInizioequalthis);end;
	IF (@OperatoreInizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_INIZIO = @OperatoreInizioequalthis)'; set @lensql=@lensql+len(@OperatoreInizioequalthis);end;
	IF (@DataFineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE = @DataFineequalthis)'; set @lensql=@lensql+len(@DataFineequalthis);end;
	IF (@OperatoreFineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_FINE = @OperatoreFineequalthis)'; set @lensql=@lensql+len(@OperatoreFineequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @IdBandoequalthis INT, @IdUtenteequalthis INT, @Responsabileequalthis BIT, @Attivoequalthis BIT, @DataInizioequalthis DATETIME, @OperatoreInizioequalthis INT, @DataFineequalthis DATETIME, @OperatoreFineequalthis INT',@Idequalthis , @IdBandoequalthis , @IdUtenteequalthis , @Responsabileequalthis , @Attivoequalthis , @DataInizioequalthis , @OperatoreInizioequalthis , @DataFineequalthis , @OperatoreFineequalthis ;
	else
		SELECT ID, ID_BANDO, ID_UTENTE, RESPONSABILE, ATTIVO, DATA_INIZIO, OPERATORE_INIZIO, DATA_FINE, OPERATORE_FINE, NOMINATIVO, PROFILO, ENTE, COD_ENTE
		FROM vBANDO_VALIDATORI
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdUtenteequalthis IS NULL) OR ID_UTENTE = @IdUtenteequalthis) AND 
			((@Responsabileequalthis IS NULL) OR RESPONSABILE = @Responsabileequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis) AND 
			((@DataInizioequalthis IS NULL) OR DATA_INIZIO = @DataInizioequalthis) AND 
			((@OperatoreInizioequalthis IS NULL) OR OPERATORE_INIZIO = @OperatoreInizioequalthis) AND 
			((@DataFineequalthis IS NULL) OR DATA_FINE = @DataFineequalthis) AND 
			((@OperatoreFineequalthis IS NULL) OR OPERATORE_FINE = @OperatoreFineequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoValidatoriFindSelect';

