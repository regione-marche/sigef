CREATE PROCEDURE [dbo].[ZCertspDomandeFindSelect]
(
	@IdDomandaequalthis INT, 
	@IdAttoequalthis INT, 
	@DataPresequalthis DATETIME, 
	@SpeseAmmequalthis DECIMAL(18,2), 
	@SpesaPubbequalthis DECIMAL(18,2), 
	@SfTotequalthis DECIMAL(18,2), 
	@SfSpesaPubbequalthis DECIMAL(18,2), 
	@SfSpeseAmmequalthis DECIMAL(18,2), 
	@SfSpesaPubbAmmequalthis DECIMAL(18,2), 
	@AsTotequalthis DECIMAL(18,2), 
	@AsCopertoequalthis DECIMAL(18,2), 
	@AsNonCopertoequalthis DECIMAL(18,2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_DOMANDA, ID_ATTO, DATA_PRES, SPESE_AMM, SPESA_PUBB, SF_TOT, SF_SPESA_PUBB, SF_SPESE_AMM, SF_SPESA_PUBB_AMM, AS_TOT, AS_COPERTO, AS_NON_COPERTO FROM CERTSP_DOMANDE WHERE 1=1';
	IF (@IdDomandaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA = @IdDomandaequalthis)'; set @lensql=@lensql+len(@IdDomandaequalthis);end;
	IF (@IdAttoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ATTO = @IdAttoequalthis)'; set @lensql=@lensql+len(@IdAttoequalthis);end;
	IF (@DataPresequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_PRES = @DataPresequalthis)'; set @lensql=@lensql+len(@DataPresequalthis);end;
	IF (@SpeseAmmequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SPESE_AMM = @SpeseAmmequalthis)'; set @lensql=@lensql+len(@SpeseAmmequalthis);end;
	IF (@SpesaPubbequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SPESA_PUBB = @SpesaPubbequalthis)'; set @lensql=@lensql+len(@SpesaPubbequalthis);end;
	IF (@SfTotequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SF_TOT = @SfTotequalthis)'; set @lensql=@lensql+len(@SfTotequalthis);end;
	IF (@SfSpesaPubbequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SF_SPESA_PUBB = @SfSpesaPubbequalthis)'; set @lensql=@lensql+len(@SfSpesaPubbequalthis);end;
	IF (@SfSpeseAmmequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SF_SPESE_AMM = @SfSpeseAmmequalthis)'; set @lensql=@lensql+len(@SfSpeseAmmequalthis);end;
	IF (@SfSpesaPubbAmmequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SF_SPESA_PUBB_AMM = @SfSpesaPubbAmmequalthis)'; set @lensql=@lensql+len(@SfSpesaPubbAmmequalthis);end;
	IF (@AsTotequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AS_TOT = @AsTotequalthis)'; set @lensql=@lensql+len(@AsTotequalthis);end;
	IF (@AsCopertoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AS_COPERTO = @AsCopertoequalthis)'; set @lensql=@lensql+len(@AsCopertoequalthis);end;
	IF (@AsNonCopertoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AS_NON_COPERTO = @AsNonCopertoequalthis)'; set @lensql=@lensql+len(@AsNonCopertoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdDomandaequalthis INT, @IdAttoequalthis INT, @DataPresequalthis DATETIME, @SpeseAmmequalthis DECIMAL(18,2), @SpesaPubbequalthis DECIMAL(18,2), @SfTotequalthis DECIMAL(18,2), @SfSpesaPubbequalthis DECIMAL(18,2), @SfSpeseAmmequalthis DECIMAL(18,2), @SfSpesaPubbAmmequalthis DECIMAL(18,2), @AsTotequalthis DECIMAL(18,2), @AsCopertoequalthis DECIMAL(18,2), @AsNonCopertoequalthis DECIMAL(18,2)',@IdDomandaequalthis , @IdAttoequalthis , @DataPresequalthis , @SpeseAmmequalthis , @SpesaPubbequalthis , @SfTotequalthis , @SfSpesaPubbequalthis , @SfSpeseAmmequalthis , @SfSpesaPubbAmmequalthis , @AsTotequalthis , @AsCopertoequalthis , @AsNonCopertoequalthis ;
	else
		SELECT ID_DOMANDA, ID_ATTO, DATA_PRES, SPESE_AMM, SPESA_PUBB, SF_TOT, SF_SPESA_PUBB, SF_SPESE_AMM, SF_SPESA_PUBB_AMM, AS_TOT, AS_COPERTO, AS_NON_COPERTO
		FROM CERTSP_DOMANDE
		WHERE 
			((@IdDomandaequalthis IS NULL) OR ID_DOMANDA = @IdDomandaequalthis) AND 
			((@IdAttoequalthis IS NULL) OR ID_ATTO = @IdAttoequalthis) AND 
			((@DataPresequalthis IS NULL) OR DATA_PRES = @DataPresequalthis) AND 
			((@SpeseAmmequalthis IS NULL) OR SPESE_AMM = @SpeseAmmequalthis) AND 
			((@SpesaPubbequalthis IS NULL) OR SPESA_PUBB = @SpesaPubbequalthis) AND 
			((@SfTotequalthis IS NULL) OR SF_TOT = @SfTotequalthis) AND 
			((@SfSpesaPubbequalthis IS NULL) OR SF_SPESA_PUBB = @SfSpesaPubbequalthis) AND 
			((@SfSpeseAmmequalthis IS NULL) OR SF_SPESE_AMM = @SfSpeseAmmequalthis) AND 
			((@SfSpesaPubbAmmequalthis IS NULL) OR SF_SPESA_PUBB_AMM = @SfSpesaPubbAmmequalthis) AND 
			((@AsTotequalthis IS NULL) OR AS_TOT = @AsTotequalthis) AND 
			((@AsCopertoequalthis IS NULL) OR AS_COPERTO = @AsCopertoequalthis) AND 
			((@AsNonCopertoequalthis IS NULL) OR AS_NON_COPERTO = @AsNonCopertoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCertspDomandeFindSelect';

