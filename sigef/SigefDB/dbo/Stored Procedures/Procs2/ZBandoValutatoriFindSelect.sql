CREATE PROCEDURE [dbo].[ZBandoValutatoriFindSelect]
(
	@IdValutatoreequalthis INT, 
	@IdBandoequalthis INT, 
	@IdUtenteequalthis INT, 
	@Presidenteequalthis BIT, 
	@Attivoequalthis BIT, 
	@DataInizioequalthis DATETIME, 
	@DataFineequalthis DATETIME, 
	@Ordineequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_UTENTE, ID_VALUTATORE, ID_BANDO, PRESIDENTE, ATTIVO, DATA_INIZIO, DATA_FINE, ORDINE, ENTE, NOMINATIVO, COD_ENTE FROM vBANDO_VALUTATORI WHERE 1=1';
	IF (@IdValutatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VALUTATORE = @IdValutatoreequalthis)'; set @lensql=@lensql+len(@IdValutatoreequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdUtenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE = @IdUtenteequalthis)'; set @lensql=@lensql+len(@IdUtenteequalthis);end;
	IF (@Presidenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PRESIDENTE = @Presidenteequalthis)'; set @lensql=@lensql+len(@Presidenteequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@DataInizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INIZIO = @DataInizioequalthis)'; set @lensql=@lensql+len(@DataInizioequalthis);end;
	IF (@DataFineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE = @DataFineequalthis)'; set @lensql=@lensql+len(@DataFineequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE = @Ordineequalthis)'; set @lensql=@lensql+len(@Ordineequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdValutatoreequalthis INT, @IdBandoequalthis INT, @IdUtenteequalthis INT, @Presidenteequalthis BIT, @Attivoequalthis BIT, @DataInizioequalthis DATETIME, @DataFineequalthis DATETIME, @Ordineequalthis INT',@IdValutatoreequalthis , @IdBandoequalthis , @IdUtenteequalthis , @Presidenteequalthis , @Attivoequalthis , @DataInizioequalthis , @DataFineequalthis , @Ordineequalthis ;
	else
		SELECT ID_UTENTE, ID_VALUTATORE, ID_BANDO, PRESIDENTE, ATTIVO, DATA_INIZIO, DATA_FINE, ORDINE, ENTE, NOMINATIVO, COD_ENTE
		FROM vBANDO_VALUTATORI
		WHERE 
			((@IdValutatoreequalthis IS NULL) OR ID_VALUTATORE = @IdValutatoreequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdUtenteequalthis IS NULL) OR ID_UTENTE = @IdUtenteequalthis) AND 
			((@Presidenteequalthis IS NULL) OR PRESIDENTE = @Presidenteequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis) AND 
			((@DataInizioequalthis IS NULL) OR DATA_INIZIO = @DataInizioequalthis) AND 
			((@DataFineequalthis IS NULL) OR DATA_FINE = @DataFineequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZBandoValutatoriFindSelect]
(
	@IdValutatoreequalthis INT, 
	@IdBandoequalthis INT, 
	@IdUtenteequalthis INT, 
	@Presidenteequalthis BIT, 
	@Attivoequalthis BIT, 
	@DataInizioequalthis DATETIME, 
	@DataFineequalthis DATETIME, 
	@Ordineequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_VALUTATORE, ID_BANDO, ID_UTENTE, PRESIDENTE, ATTIVO, DATA_INIZIO, DATA_FINE, ORDINE FROM BANDO_VALUTATORI WHERE 1=1'';
	IF (@IdValutatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_VALUTATORE = @IdValutatoreequalthis)''; set @lensql=@lensql+len(@IdValutatoreequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdUtenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_UTENTE = @IdUtenteequalthis)''; set @lensql=@lensql+len(@IdUtenteequalthis);end;
	IF (@Presidenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PRESIDENTE = @Presidenteequalthis)''; set @lensql=@lensql+len(@Presidenteequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ATTIVO = @Attivoequalthis)''; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@DataInizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_INIZIO = @DataInizioequalthis)''; set @lensql=@lensql+len(@DataInizioequalthis);end;
	IF (@DataFineequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_FINE = @DataFineequalthis)''; set @lensql=@lensql+len(@DataFineequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ORDINE = @Ordineequalthis)''; set @lensql=@lensql+len(@Ordineequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdValutatoreequalthis INT, @IdBandoequalthis INT, @IdUtenteequalthis INT, @Presidenteequalthis BIT, @Attivoequalthis BIT, @DataInizioequalthis DATETIME, @DataFineequalthis DATETIME, @Ordineequalthis INT'',@IdValutatoreequalthis , @IdBandoequalthis , @IdUtenteequalthis , @Presidenteequalthis , @Attivoequalthis , @DataInizioequalthis , @DataFineequalthis , @Ordineequalthis ;
	else
		SELECT ID_VALUTATORE, ID_BANDO, ID_UTENTE, PRESIDENTE, ATTIVO, DATA_INIZIO, DATA_FINE, ORDINE
		FROM BANDO_VALUTATORI
		WHERE 
			((@IdValutatoreequalthis IS NULL) OR ID_VALUTATORE = @IdValutatoreequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdUtenteequalthis IS NULL) OR ID_UTENTE = @IdUtenteequalthis) AND 
			((@Presidenteequalthis IS NULL) OR PRESIDENTE = @Presidenteequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis) AND 
			((@DataInizioequalthis IS NULL) OR DATA_INIZIO = @DataInizioequalthis) AND 
			((@DataFineequalthis IS NULL) OR DATA_FINE = @DataFineequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoValutatoriFindSelect';

