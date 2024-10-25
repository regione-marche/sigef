CREATE PROCEDURE [dbo].[ZBandoValutatoriFindFind]
(
	@IdValutatoreequalthis INT, 
	@IdBandoequalthis INT, 
	@IdUtenteequalthis INT, 
	@Attivoequalthis BIT, 
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
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE = @Ordineequalthis)'; set @lensql=@lensql+len(@Ordineequalthis);end;
	set @sql = @sql + 'ORDER BY ATTIVO DESC, ORDINE';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdValutatoreequalthis INT, @IdBandoequalthis INT, @IdUtenteequalthis INT, @Attivoequalthis BIT, @Ordineequalthis INT',@IdValutatoreequalthis , @IdBandoequalthis , @IdUtenteequalthis , @Attivoequalthis , @Ordineequalthis ;
	else
		SELECT ID_UTENTE, ID_VALUTATORE, ID_BANDO, PRESIDENTE, ATTIVO, DATA_INIZIO, DATA_FINE, ORDINE, ENTE, NOMINATIVO, COD_ENTE
		FROM vBANDO_VALUTATORI
		WHERE 
			((@IdValutatoreequalthis IS NULL) OR ID_VALUTATORE = @IdValutatoreequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdUtenteequalthis IS NULL) OR ID_UTENTE = @IdUtenteequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis)
		ORDER BY ATTIVO DESC, ORDINE


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZBandoValutatoriFindFind]
(
	@IdValutatoreequalthis INT, 
	@IdBandoequalthis INT, 
	@IdUtenteequalthis INT, 
	@Attivoequalthis BIT, 
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
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ATTIVO = @Attivoequalthis)''; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ORDINE = @Ordineequalthis)''; set @lensql=@lensql+len(@Ordineequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdValutatoreequalthis INT, @IdBandoequalthis INT, @IdUtenteequalthis INT, @Attivoequalthis BIT, @Ordineequalthis INT'',@IdValutatoreequalthis , @IdBandoequalthis , @IdUtenteequalthis , @Attivoequalthis , @Ordineequalthis ;
	else
		SELECT ID_VALUTATORE, ID_BANDO, ID_UTENTE, PRESIDENTE, ATTIVO, DATA_INIZIO, DATA_FINE, ORDINE
		FROM BANDO_VALUTATORI
		WHERE 
			((@IdValutatoreequalthis IS NULL) OR ID_VALUTATORE = @IdValutatoreequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdUtenteequalthis IS NULL) OR ID_UTENTE = @IdUtenteequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoValutatoriFindFind';

