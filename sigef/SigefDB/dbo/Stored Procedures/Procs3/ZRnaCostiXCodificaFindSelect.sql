CREATE PROCEDURE [dbo].[ZRnaCostiXCodificaFindSelect]
(
	@IdCostiXCodificaequalthis INT, 
	@IdCodificaInvestimentoequalthis INT, 
	@CodTipoSpesaequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_COSTI_X_CODIFICA, ID_CODIFICA_INVESTIMENTO, COD_TIPO_SPESA FROM RNA_COSTI_X_CODIFICA WHERE 1=1';
	IF (@IdCostiXCodificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COSTI_X_CODIFICA = @IdCostiXCodificaequalthis)'; set @lensql=@lensql+len(@IdCostiXCodificaequalthis);end;
	IF (@IdCodificaInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimentoequalthis)'; set @lensql=@lensql+len(@IdCodificaInvestimentoequalthis);end;
	IF (@CodTipoSpesaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_SPESA = @CodTipoSpesaequalthis)'; set @lensql=@lensql+len(@CodTipoSpesaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdCostiXCodificaequalthis INT, @IdCodificaInvestimentoequalthis INT, @CodTipoSpesaequalthis INT',@IdCostiXCodificaequalthis , @IdCodificaInvestimentoequalthis , @CodTipoSpesaequalthis ;
	else
		SELECT ID_COSTI_X_CODIFICA, ID_CODIFICA_INVESTIMENTO, COD_TIPO_SPESA
		FROM RNA_COSTI_X_CODIFICA
		WHERE 
			((@IdCostiXCodificaequalthis IS NULL) OR ID_COSTI_X_CODIFICA = @IdCostiXCodificaequalthis) AND 
			((@IdCodificaInvestimentoequalthis IS NULL) OR ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimentoequalthis) AND 
			((@CodTipoSpesaequalthis IS NULL) OR COD_TIPO_SPESA = @CodTipoSpesaequalthis)