CREATE PROCEDURE [dbo].[ZVrnaCostiXCodificaFindSelect]
(
	@IdCostiXCodificaequalthis INT, 
	@CodTipoSpesaequalthis INT, 
	@IdCodificaInvestimentoequalthis INT, 
	@IdBandoequalthis INT, 
	@Spesaequalthis VARCHAR(500), 
	@DescrizioneInvestimentoequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_COSTI_X_CODIFICA, COD_TIPO_SPESA, ID_CODIFICA_INVESTIMENTO, ID_BANDO, SPESA, DESCRIZIONE_INVESTIMENTO FROM VRNA_COSTI_X_CODIFICA WHERE 1=1';
	IF (@IdCostiXCodificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COSTI_X_CODIFICA = @IdCostiXCodificaequalthis)'; set @lensql=@lensql+len(@IdCostiXCodificaequalthis);end;
	IF (@CodTipoSpesaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_SPESA = @CodTipoSpesaequalthis)'; set @lensql=@lensql+len(@CodTipoSpesaequalthis);end;
	IF (@IdCodificaInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimentoequalthis)'; set @lensql=@lensql+len(@IdCodificaInvestimentoequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@Spesaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SPESA = @Spesaequalthis)'; set @lensql=@lensql+len(@Spesaequalthis);end;
	IF (@DescrizioneInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE_INVESTIMENTO = @DescrizioneInvestimentoequalthis)'; set @lensql=@lensql+len(@DescrizioneInvestimentoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdCostiXCodificaequalthis INT, @CodTipoSpesaequalthis INT, @IdCodificaInvestimentoequalthis INT, @IdBandoequalthis INT, @Spesaequalthis VARCHAR(500), @DescrizioneInvestimentoequalthis VARCHAR(255)',@IdCostiXCodificaequalthis , @CodTipoSpesaequalthis , @IdCodificaInvestimentoequalthis , @IdBandoequalthis , @Spesaequalthis , @DescrizioneInvestimentoequalthis ;
	else
		SELECT ID_COSTI_X_CODIFICA, COD_TIPO_SPESA, ID_CODIFICA_INVESTIMENTO, ID_BANDO, SPESA, DESCRIZIONE_INVESTIMENTO
		FROM VRNA_COSTI_X_CODIFICA
		WHERE 
			((@IdCostiXCodificaequalthis IS NULL) OR ID_COSTI_X_CODIFICA = @IdCostiXCodificaequalthis) AND 
			((@CodTipoSpesaequalthis IS NULL) OR COD_TIPO_SPESA = @CodTipoSpesaequalthis) AND 
			((@IdCodificaInvestimentoequalthis IS NULL) OR ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimentoequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@Spesaequalthis IS NULL) OR SPESA = @Spesaequalthis) AND 
			((@DescrizioneInvestimentoequalthis IS NULL) OR DESCRIZIONE_INVESTIMENTO = @DescrizioneInvestimentoequalthis)