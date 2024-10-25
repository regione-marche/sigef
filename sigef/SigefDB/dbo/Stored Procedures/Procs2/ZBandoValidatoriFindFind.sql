CREATE PROCEDURE [dbo].[ZBandoValidatoriFindFind]
(
	@IdBandoequalthis INT, 
	@IdUtenteequalthis INT, 
	@Responsabileequalthis BIT, 
	@Attivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_BANDO, ID_UTENTE, RESPONSABILE, ATTIVO, DATA_INIZIO, OPERATORE_INIZIO, DATA_FINE, OPERATORE_FINE, NOMINATIVO, PROFILO, ENTE, COD_ENTE FROM vBANDO_VALIDATORI WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdUtenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE = @IdUtenteequalthis)'; set @lensql=@lensql+len(@IdUtenteequalthis);end;
	IF (@Responsabileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RESPONSABILE = @Responsabileequalthis)'; set @lensql=@lensql+len(@Responsabileequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	set @sql = @sql + 'ORDER BY ATTIVO DESC, RESPONSABILE DESC, DATA_INIZIO DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @IdUtenteequalthis INT, @Responsabileequalthis BIT, @Attivoequalthis BIT',@IdBandoequalthis , @IdUtenteequalthis , @Responsabileequalthis , @Attivoequalthis ;
	else
		SELECT ID, ID_BANDO, ID_UTENTE, RESPONSABILE, ATTIVO, DATA_INIZIO, OPERATORE_INIZIO, DATA_FINE, OPERATORE_FINE, NOMINATIVO, PROFILO, ENTE, COD_ENTE
		FROM vBANDO_VALIDATORI
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdUtenteequalthis IS NULL) OR ID_UTENTE = @IdUtenteequalthis) AND 
			((@Responsabileequalthis IS NULL) OR RESPONSABILE = @Responsabileequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis)
		ORDER BY ATTIVO DESC, RESPONSABILE DESC, DATA_INIZIO DESC


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoValidatoriFindFind';

