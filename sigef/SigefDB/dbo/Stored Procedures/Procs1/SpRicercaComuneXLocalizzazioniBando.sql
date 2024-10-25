






CREATE PROCEDURE [dbo].[SpRicercaComuneXLocalizzazioniBando]
(
	@idBandoequalthis int,
	@CodBelfioreequalthis CHAR(4)=NULL,
	@CodProvinciaequalthis VARCHAR(255) = NULL, 
	@CodRegioneequalthis VARCHAR(255) = NULL, 
	@SiglaProvinciaequalthis CHAR(2)=NULL,
	@Capequalthis CHAR(5)=NULL,
	@Istatequalthis CHAR(3)=NULL,
	@Attivoequalthis BIT=0, 
	@Denominazionelikethis VARCHAR(255)=NULL
)
AS

	declare @filtraComuni int;
	set @filtraComuni = (select COUNT(ID_COMUNE) from BANDO_COMUNI_LOCALIZZAZIONI where ID_BANDO=@idBandoequalthis);

	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT vCOMUNI.ID_COMUNE, COD_BELFIORE, DENOMINAZIONE, COD_PROVINCIA, SIGLA, CAP, ISTAT, TIPO_AREA, COD_RUBRICA_PALEO, vCOMUNI.ATTIVO, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, ID_OPERATORE_INIZIO, ID_OPERATORE_FINE, COD_CITTA_METROPOLITANA, PROVINCIA, COD_REGIONE, REGIONE FROM vCOMUNI'
	IF (@filtraComuni > 0) SET @sql = @sql + '  inner join BANDO_COMUNI_LOCALIZZAZIONI on vCOMUNI.ID_COMUNE = BANDO_COMUNI_LOCALIZZAZIONI.ID_COMUNE'
	SET @sql = @sql + '  WHERE 1=1';
	IF (@filtraComuni > 0) SET @sql = @sql + '  AND (ID_BANDO = @idBandoequalthis AND BANDO_COMUNI_LOCALIZZAZIONI.IS_ATTIVO=1)'; set @lensql=@lensql+len(@idBandoequalthis);
	IF (@CodBelfioreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_BELFIORE = @CodBelfioreequalthis)'; set @lensql=@lensql+len(@CodBelfioreequalthis);end;
	IF (@CodProvinciaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_PROVINCIA = @CodProvinciaequalthis)'; set @lensql=@lensql+len(@CodProvinciaequalthis);end;
	IF (@CodRegioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_REGIONE = @CodRegioneequalthis)'; set @lensql=@lensql+len(@CodRegioneequalthis);end;
	IF (@SiglaProvinciaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SIGLA = @SiglaProvinciaequalthis)'; set @lensql=@lensql+len(@SiglaProvinciaequalthis);end;
	IF (@Capequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CAP = @Capequalthis)'; set @lensql=@lensql+len(@Capequalthis);end;
	IF (@Istatequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ISTAT = @Istatequalthis)'; set @lensql=@lensql+len(@Istatequalthis);end;
	IF (@Attivoequalthis <> 0) BEGIN SET @sql = @sql + ' AND (vCOMUNI.ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@Denominazionelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DENOMINAZIONE LIKE ''%' + @Denominazionelikethis + '%'')'; set @lensql=@lensql+len(@Denominazionelikethis);end;
	set @sql = @sql + 'ORDER BY vCOMUNI.ATTIVO DESC, DENOMINAZIONE, DATA_INIZIO_VALIDITA DESC';
	set @lensql=@lensql+len(@sql);
	exec sp_executesql @sql,N'@idBandoequalthis int,@CodBelfioreequalthis CHAR(4), @CodProvinciaequalthis VARCHAR(255), @CodRegioneequalthis VARCHAR(255), @SiglaProvinciaequalthis CHAR(2), @Capequalthis CHAR(5), @Istatequalthis CHAR(3), @Attivoequalthis BIT, @Denominazionelikethis VARCHAR(255)',@idBandoequalthis,@CodBelfioreequalthis , @CodProvinciaequalthis , @CodRegioneequalthis , @SiglaProvinciaequalthis , @Capequalthis , @Istatequalthis , @Attivoequalthis , @Denominazionelikethis ;








