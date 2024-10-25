CREATE PROCEDURE [dbo].[ZComuniFindFind]
(
	@CodBelfioreequalthis VARCHAR(255), 
	@CodProvinciaequalthis VARCHAR(255), 
	@CodRegioneequalthis VARCHAR(255), 
	@Siglaequalthis VARCHAR(255), 
	@Capequalthis VARCHAR(255), 
	@Istatequalthis VARCHAR(255), 
	@Attivoequalthis BIT, 
	@Denominazionelikethis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_COMUNE, COD_BELFIORE, DENOMINAZIONE, COD_PROVINCIA, SIGLA, CAP, ISTAT, TIPO_AREA, COD_RUBRICA_PALEO, ATTIVO, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, ID_OPERATORE_INIZIO, ID_OPERATORE_FINE, COD_CITTA_METROPOLITANA, PROVINCIA, COD_REGIONE, REGIONE FROM vCOMUNI WHERE 1=1';
	IF (@CodBelfioreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_BELFIORE = @CodBelfioreequalthis)'; set @lensql=@lensql+len(@CodBelfioreequalthis);end;
	IF (@CodProvinciaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_PROVINCIA = @CodProvinciaequalthis)'; set @lensql=@lensql+len(@CodProvinciaequalthis);end;
	IF (@CodRegioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_REGIONE = @CodRegioneequalthis)'; set @lensql=@lensql+len(@CodRegioneequalthis);end;
	IF (@Siglaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SIGLA = @Siglaequalthis)'; set @lensql=@lensql+len(@Siglaequalthis);end;
	IF (@Capequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CAP = @Capequalthis)'; set @lensql=@lensql+len(@Capequalthis);end;
	IF (@Istatequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ISTAT = @Istatequalthis)'; set @lensql=@lensql+len(@Istatequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@Denominazionelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DENOMINAZIONE LIKE @Denominazionelikethis)'; set @lensql=@lensql+len(@Denominazionelikethis);end;
	set @sql = @sql + 'ORDER BY ATTIVO DESC, DENOMINAZIONE, DATA_INIZIO_VALIDITA DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodBelfioreequalthis VARCHAR(255), @CodProvinciaequalthis VARCHAR(255), @CodRegioneequalthis VARCHAR(255), @Siglaequalthis VARCHAR(255), @Capequalthis VARCHAR(255), @Istatequalthis VARCHAR(255), @Attivoequalthis BIT, @Denominazionelikethis VARCHAR(255)',@CodBelfioreequalthis , @CodProvinciaequalthis , @CodRegioneequalthis , @Siglaequalthis , @Capequalthis , @Istatequalthis , @Attivoequalthis , @Denominazionelikethis ;
	else
		SELECT ID_COMUNE, COD_BELFIORE, DENOMINAZIONE, COD_PROVINCIA, SIGLA, CAP, ISTAT, TIPO_AREA, COD_RUBRICA_PALEO, ATTIVO, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, ID_OPERATORE_INIZIO, ID_OPERATORE_FINE, COD_CITTA_METROPOLITANA, PROVINCIA, COD_REGIONE, REGIONE
		FROM vCOMUNI
		WHERE 
			((@CodBelfioreequalthis IS NULL) OR COD_BELFIORE = @CodBelfioreequalthis) AND 
			((@CodProvinciaequalthis IS NULL) OR COD_PROVINCIA = @CodProvinciaequalthis) AND 
			((@CodRegioneequalthis IS NULL) OR COD_REGIONE = @CodRegioneequalthis) AND 
			((@Siglaequalthis IS NULL) OR SIGLA = @Siglaequalthis) AND 
			((@Capequalthis IS NULL) OR CAP = @Capequalthis) AND 
			((@Istatequalthis IS NULL) OR ISTAT = @Istatequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis) AND 
			((@Denominazionelikethis IS NULL) OR DENOMINAZIONE LIKE @Denominazionelikethis)
		ORDER BY ATTIVO DESC, DENOMINAZIONE, DATA_INIZIO_VALIDITA DESC

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZComuniFindFind';

