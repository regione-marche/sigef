CREATE PROCEDURE [dbo].[ZZdimensioniEstrazioniTFindFind]
(
	@CodPsrequalthis VARCHAR(255), 
	@Annoequalthis INT, 
	@TipoIndicatoriequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ESTRAZIONE, DATA_INIZIO, DATA_FINE, COD_PSR, BLOCCATO, TIPO_INDICATORI, ANNO FROM vzDIMENSIONI_ESTRAZIONI_T WHERE 1=1';
	IF (@CodPsrequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_PSR = @CodPsrequalthis)'; set @lensql=@lensql+len(@CodPsrequalthis);end;
	IF (@Annoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNO = @Annoequalthis)'; set @lensql=@lensql+len(@Annoequalthis);end;
	IF (@TipoIndicatoriequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIPO_INDICATORI = @TipoIndicatoriequalthis)'; set @lensql=@lensql+len(@TipoIndicatoriequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodPsrequalthis VARCHAR(255), @Annoequalthis INT, @TipoIndicatoriequalthis VARCHAR(255)',@CodPsrequalthis , @Annoequalthis , @TipoIndicatoriequalthis ;
	else
		SELECT ID_ESTRAZIONE, DATA_INIZIO, DATA_FINE, COD_PSR, BLOCCATO, TIPO_INDICATORI, ANNO
		FROM vzDIMENSIONI_ESTRAZIONI_T
		WHERE 
			((@CodPsrequalthis IS NULL) OR COD_PSR = @CodPsrequalthis) AND 
			((@Annoequalthis IS NULL) OR ANNO = @Annoequalthis) AND 
			((@TipoIndicatoriequalthis IS NULL) OR TIPO_INDICATORI = @TipoIndicatoriequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZdimensioniEstrazioniTFindFind';

