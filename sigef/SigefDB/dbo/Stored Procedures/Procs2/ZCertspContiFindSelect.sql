CREATE PROCEDURE [dbo].[ZCertspContiFindSelect]
(
	@IdContoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdAttoequalthis INT, 
	@DataPresContabequalthis DATETIME, 
	@DataPresContiequalthis DATETIME, 
	@TotRegistrateequalthis DECIMAL(18,2), 
	@TotSpesapubRegistrateequalthis DECIMAL(18,2), 
	@TotPagamentiRegistrateequalthis DECIMAL(18,2), 
	@TotRitirataequalthis DECIMAL(18,2), 
	@TotSpesapubRitirataequalthis DECIMAL(18,2), 
	@TotRecuperataequalthis DECIMAL(18,2), 
	@TotSpesapubRecuperataequalthis DECIMAL(18,2), 
	@TotDarecuperareequalthis DECIMAL(18,2), 
	@TotSpesapubDarecuperareequalthis DECIMAL(18,2), 
	@TotNonrecuperabequalthis DECIMAL(18,2), 
	@TotSpesapubNonrecuperabequalthis DECIMAL(18,2), 
	@RecuperatoArt71equalthis DECIMAL(18,2), 
	@RecuperatoArt71Pubblicaequalthis DECIMAL(18,2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_CONTO, ID_PROGETTO, ID_ATTO, DATA_PRES_CONTAB, DATA_PRES_CONTI, TOT_REGISTRATE, TOT_SPESAPUB_REGISTRATE, TOT_PAGAMENTI_REGISTRATE, TOT_RITIRATA, TOT_SPESAPUB_RITIRATA, TOT_RECUPERATA, TOT_SPESAPUB_RECUPERATA, TOT_DARECUPERARE, TOT_SPESAPUB_DARECUPERARE, TOT_NONRECUPERAB, TOT_SPESAPUB_NONRECUPERAB, RECUPERATO_ART71, RECUPERATO_ART71_PUBBLICA FROM CERTSP_CONTI WHERE 1=1';
	IF (@IdContoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CONTO = @IdContoequalthis)'; set @lensql=@lensql+len(@IdContoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdAttoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ATTO = @IdAttoequalthis)'; set @lensql=@lensql+len(@IdAttoequalthis);end;
	IF (@DataPresContabequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_PRES_CONTAB = @DataPresContabequalthis)'; set @lensql=@lensql+len(@DataPresContabequalthis);end;
	IF (@DataPresContiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_PRES_CONTI = @DataPresContiequalthis)'; set @lensql=@lensql+len(@DataPresContiequalthis);end;
	IF (@TotRegistrateequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TOT_REGISTRATE = @TotRegistrateequalthis)'; set @lensql=@lensql+len(@TotRegistrateequalthis);end;
	IF (@TotSpesapubRegistrateequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TOT_SPESAPUB_REGISTRATE = @TotSpesapubRegistrateequalthis)'; set @lensql=@lensql+len(@TotSpesapubRegistrateequalthis);end;
	IF (@TotPagamentiRegistrateequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TOT_PAGAMENTI_REGISTRATE = @TotPagamentiRegistrateequalthis)'; set @lensql=@lensql+len(@TotPagamentiRegistrateequalthis);end;
	IF (@TotRitirataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TOT_RITIRATA = @TotRitirataequalthis)'; set @lensql=@lensql+len(@TotRitirataequalthis);end;
	IF (@TotSpesapubRitirataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TOT_SPESAPUB_RITIRATA = @TotSpesapubRitirataequalthis)'; set @lensql=@lensql+len(@TotSpesapubRitirataequalthis);end;
	IF (@TotRecuperataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TOT_RECUPERATA = @TotRecuperataequalthis)'; set @lensql=@lensql+len(@TotRecuperataequalthis);end;
	IF (@TotSpesapubRecuperataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TOT_SPESAPUB_RECUPERATA = @TotSpesapubRecuperataequalthis)'; set @lensql=@lensql+len(@TotSpesapubRecuperataequalthis);end;
	IF (@TotDarecuperareequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TOT_DARECUPERARE = @TotDarecuperareequalthis)'; set @lensql=@lensql+len(@TotDarecuperareequalthis);end;
	IF (@TotSpesapubDarecuperareequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TOT_SPESAPUB_DARECUPERARE = @TotSpesapubDarecuperareequalthis)'; set @lensql=@lensql+len(@TotSpesapubDarecuperareequalthis);end;
	IF (@TotNonrecuperabequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TOT_NONRECUPERAB = @TotNonrecuperabequalthis)'; set @lensql=@lensql+len(@TotNonrecuperabequalthis);end;
	IF (@TotSpesapubNonrecuperabequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TOT_SPESAPUB_NONRECUPERAB = @TotSpesapubNonrecuperabequalthis)'; set @lensql=@lensql+len(@TotSpesapubNonrecuperabequalthis);end;
	IF (@RecuperatoArt71equalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RECUPERATO_ART71 = @RecuperatoArt71equalthis)'; set @lensql=@lensql+len(@RecuperatoArt71equalthis);end;
	IF (@RecuperatoArt71Pubblicaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RECUPERATO_ART71_PUBBLICA = @RecuperatoArt71Pubblicaequalthis)'; set @lensql=@lensql+len(@RecuperatoArt71Pubblicaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdContoequalthis INT, @IdProgettoequalthis INT, @IdAttoequalthis INT, @DataPresContabequalthis DATETIME, @DataPresContiequalthis DATETIME, @TotRegistrateequalthis DECIMAL(18,2), @TotSpesapubRegistrateequalthis DECIMAL(18,2), @TotPagamentiRegistrateequalthis DECIMAL(18,2), @TotRitirataequalthis DECIMAL(18,2), @TotSpesapubRitirataequalthis DECIMAL(18,2), @TotRecuperataequalthis DECIMAL(18,2), @TotSpesapubRecuperataequalthis DECIMAL(18,2), @TotDarecuperareequalthis DECIMAL(18,2), @TotSpesapubDarecuperareequalthis DECIMAL(18,2), @TotNonrecuperabequalthis DECIMAL(18,2), @TotSpesapubNonrecuperabequalthis DECIMAL(18,2), @RecuperatoArt71equalthis DECIMAL(18,2), @RecuperatoArt71Pubblicaequalthis DECIMAL(18,2)',@IdContoequalthis , @IdProgettoequalthis , @IdAttoequalthis , @DataPresContabequalthis , @DataPresContiequalthis , @TotRegistrateequalthis , @TotSpesapubRegistrateequalthis , @TotPagamentiRegistrateequalthis , @TotRitirataequalthis , @TotSpesapubRitirataequalthis , @TotRecuperataequalthis , @TotSpesapubRecuperataequalthis , @TotDarecuperareequalthis , @TotSpesapubDarecuperareequalthis , @TotNonrecuperabequalthis , @TotSpesapubNonrecuperabequalthis , @RecuperatoArt71equalthis , @RecuperatoArt71Pubblicaequalthis ;
	else
		SELECT ID_CONTO, ID_PROGETTO, ID_ATTO, DATA_PRES_CONTAB, DATA_PRES_CONTI, TOT_REGISTRATE, TOT_SPESAPUB_REGISTRATE, TOT_PAGAMENTI_REGISTRATE, TOT_RITIRATA, TOT_SPESAPUB_RITIRATA, TOT_RECUPERATA, TOT_SPESAPUB_RECUPERATA, TOT_DARECUPERARE, TOT_SPESAPUB_DARECUPERARE, TOT_NONRECUPERAB, TOT_SPESAPUB_NONRECUPERAB, RECUPERATO_ART71, RECUPERATO_ART71_PUBBLICA
		FROM CERTSP_CONTI
		WHERE 
			((@IdContoequalthis IS NULL) OR ID_CONTO = @IdContoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdAttoequalthis IS NULL) OR ID_ATTO = @IdAttoequalthis) AND 
			((@DataPresContabequalthis IS NULL) OR DATA_PRES_CONTAB = @DataPresContabequalthis) AND 
			((@DataPresContiequalthis IS NULL) OR DATA_PRES_CONTI = @DataPresContiequalthis) AND 
			((@TotRegistrateequalthis IS NULL) OR TOT_REGISTRATE = @TotRegistrateequalthis) AND 
			((@TotSpesapubRegistrateequalthis IS NULL) OR TOT_SPESAPUB_REGISTRATE = @TotSpesapubRegistrateequalthis) AND 
			((@TotPagamentiRegistrateequalthis IS NULL) OR TOT_PAGAMENTI_REGISTRATE = @TotPagamentiRegistrateequalthis) AND 
			((@TotRitirataequalthis IS NULL) OR TOT_RITIRATA = @TotRitirataequalthis) AND 
			((@TotSpesapubRitirataequalthis IS NULL) OR TOT_SPESAPUB_RITIRATA = @TotSpesapubRitirataequalthis) AND 
			((@TotRecuperataequalthis IS NULL) OR TOT_RECUPERATA = @TotRecuperataequalthis) AND 
			((@TotSpesapubRecuperataequalthis IS NULL) OR TOT_SPESAPUB_RECUPERATA = @TotSpesapubRecuperataequalthis) AND 
			((@TotDarecuperareequalthis IS NULL) OR TOT_DARECUPERARE = @TotDarecuperareequalthis) AND 
			((@TotSpesapubDarecuperareequalthis IS NULL) OR TOT_SPESAPUB_DARECUPERARE = @TotSpesapubDarecuperareequalthis) AND 
			((@TotNonrecuperabequalthis IS NULL) OR TOT_NONRECUPERAB = @TotNonrecuperabequalthis) AND 
			((@TotSpesapubNonrecuperabequalthis IS NULL) OR TOT_SPESAPUB_NONRECUPERAB = @TotSpesapubNonrecuperabequalthis) AND 
			((@RecuperatoArt71equalthis IS NULL) OR RECUPERATO_ART71 = @RecuperatoArt71equalthis) AND 
			((@RecuperatoArt71Pubblicaequalthis IS NULL) OR RECUPERATO_ART71_PUBBLICA = @RecuperatoArt71Pubblicaequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZCertspContiFindSelect]
(
	@IdContoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdAttoequalthis INT, 
	@DataPresContabequalthis DATETIME, 
	@DataPresContiequalthis DATETIME, 
	@TotRegistrateequalthis DECIMAL(18,2), 
	@TotSpesapubRegistrateequalthis DECIMAL(18,2), 
	@TotPagamentiRegistrateequalthis DECIMAL(18,2), 
	@TotRitirataequalthis DECIMAL(18,2), 
	@TotSpesapubRitirataequalthis DECIMAL(18,2), 
	@TotRecuperataequalthis DECIMAL(18,2), 
	@TotSpesapubRecuperataequalthis DECIMAL(18,2), 
	@TotDarecuperareequalthis DECIMAL(18,2), 
	@TotSpesapubDarecuperareequalthis DECIMAL(18,2), 
	@RecuperatoArt71equalthis BIT, 
	@TotNonrecuperabequalthis DECIMAL(18,2), 
	@TotSpesapubNonrecuperabequalthis DECIMAL(18,2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_CONTO, ID_PROGETTO, ID_ATTO, DATA_PRES_CONTAB, DATA_PRES_CONTI, TOT_REGISTRATE, TOT_SPESAPUB_REGISTRATE, TOT_PAGAMENTI_REGISTRATE, TOT_RITIRATA, TOT_SPESAPUB_RITIRATA, TOT_RECUPERATA, TOT_SPESAPUB_RECUPERATA, TOT_DARECUPERARE, TOT_SPESAPUB_DARECUPERARE, RECUPERATO_ART71, TOT_NONRECUPERAB, TOT_SPESAPUB_NONRECUPERAB FROM CERTSP_CONTI WHERE 1=1'';
	IF (@IdContoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_CONTO = @IdContoequalthis)''; set @lensql=@lensql+len(@IdContoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdAttoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_ATTO = @IdAttoequalthis)''; set @lensql=@lensql+len(@IdAttoequalthis);end;
	IF (@DataPresContabequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_PRES_CONTAB = @DataPresContabequalthis)''; set @lensql=@lensql+len(@DataPresContabequalthis);end;
	IF (@DataPresContiequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_PRES_CONTI = @DataPresContiequalthis)''; set @lensql=@lensql+len(@DataPresContiequalthis);end;
	IF (@TotRegistrateequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TOT_REGISTRATE = @TotRegistrateequalthis)''; set @lensql=@lensql+len(@TotRegistrateequalthis);end;
	IF (@TotSpesapubRegistrateequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TOT_SPESAPUB_REGISTRATE = @TotSpesapubRegistrateequalthis)''; set @lensql=@lensql+len(@TotSpesapubRegistrateequalthis);end;
	IF (@TotPagamentiRegistrateequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TOT_PAGAMENTI_REGISTRATE = @TotPagamentiRegistrateequalthis)''; set @lensql=@lensql+len(@TotPagamentiRegistrateequalthis);end;
	IF (@TotRitirataequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TOT_RITIRATA = @TotRitirataequalthis)''; set @lensql=@lensql+len(@TotRitirataequalthis);end;
	IF (@TotSpesapubRitirataequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TOT_SPESAPUB_RITIRATA = @TotSpesapubRitirataequalthis)''; set @lensql=@lensql+len(@TotSpesapubRitirataequalthis);end;
	IF (@TotRecuperataequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TOT_RECUPERATA = @TotRecuperataequalthis)''; set @lensql=@lensql+len(@TotRecuperataequalthis);end;
	IF (@TotSpesapubRecuperataequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TOT_SPESAPUB_RECUPERATA = @TotSpesapubRecuperataequalthis)''; set @lensql=@lensql+len(@TotSpesapubRecuperataequalthis);end;
	IF (@TotDarecuperareequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TOT_DARECUPERARE = @TotDarecuperareequalthis)''; set @lensql=@lensql+len(@TotDarecuperareequalthis);end;
	IF (@TotSpesapubDarecuperareequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TOT_SPESAPUB_DARECUPERARE = @TotSpesapubDarecuperareequalthis)''; set @lensql=@lensql+len(@TotSpesapubDarecuperareequalthis);end;
	IF (@RecuperatoArt71equalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (RECUPERATO_ART71 = @RecuperatoArt71equalthis)''; set @lensql=@lensql+len(@RecuperatoArt71equalthis);end;
	IF (@TotNonrecuperabequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TOT_NONRECUPERAB = @TotN', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCertspContiFindSelect';

