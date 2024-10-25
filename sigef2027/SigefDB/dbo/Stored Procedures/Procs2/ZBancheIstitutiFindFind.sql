CREATE PROCEDURE [dbo].[ZBancheIstitutiFindFind]
(
	@Abiequalthis VARCHAR(255), 
	@Denominazionelikethis VARCHAR(255), 
	@Attivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ABI, DENOMINAZIONE, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, ATTIVO FROM BANCHE_ISTITUTI WHERE 1=1';
	IF (@Abiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ABI = @Abiequalthis)'; set @lensql=@lensql+len(@Abiequalthis);end;
	IF (@Denominazionelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DENOMINAZIONE LIKE @Denominazionelikethis)'; set @lensql=@lensql+len(@Denominazionelikethis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	set @sql = @sql + 'ORDER BY ABI';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Abiequalthis VARCHAR(255), @Denominazionelikethis VARCHAR(255), @Attivoequalthis BIT',@Abiequalthis , @Denominazionelikethis , @Attivoequalthis ;
	else
		SELECT ABI, DENOMINAZIONE, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, ATTIVO
		FROM BANCHE_ISTITUTI
		WHERE 
			((@Abiequalthis IS NULL) OR ABI = @Abiequalthis) AND 
			((@Denominazionelikethis IS NULL) OR DENOMINAZIONE LIKE @Denominazionelikethis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis)
		ORDER BY ABI


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBancheIstitutiFindFind';

