CREATE PROCEDURE [dbo].[ZGraduatoriaProgettiFinanziabilitaFindSelect]
(
	@IdBandoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdProgIntegratoequalthis INT, 
	@CostoTotaleequalthis DECIMAL(18,2), 
	@ContributoDiMisuraequalthis DECIMAL(18,2), 
	@ContributoRimanenteequalthis DECIMAL(18,2), 
	@Misuraequalthis VARCHAR(10), 
	@MisuraPrevalenteequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, ID_PROGETTO, ID_PROG_INTEGRATO, COSTO_TOTALE, CONTRIBUTO_DI_MISURA, CONTRIBUTO_RIMANENTE, MISURA, MISURA_PREVALENTE FROM GRADUATORIA_PROGETTI_FINANZIABILITA WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdProgIntegratoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROG_INTEGRATO = @IdProgIntegratoequalthis)'; set @lensql=@lensql+len(@IdProgIntegratoequalthis);end;
	IF (@CostoTotaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COSTO_TOTALE = @CostoTotaleequalthis)'; set @lensql=@lensql+len(@CostoTotaleequalthis);end;
	IF (@ContributoDiMisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTRIBUTO_DI_MISURA = @ContributoDiMisuraequalthis)'; set @lensql=@lensql+len(@ContributoDiMisuraequalthis);end;
	IF (@ContributoRimanenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTRIBUTO_RIMANENTE = @ContributoRimanenteequalthis)'; set @lensql=@lensql+len(@ContributoRimanenteequalthis);end;
	IF (@Misuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MISURA = @Misuraequalthis)'; set @lensql=@lensql+len(@Misuraequalthis);end;
	IF (@MisuraPrevalenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MISURA_PREVALENTE = @MisuraPrevalenteequalthis)'; set @lensql=@lensql+len(@MisuraPrevalenteequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @IdProgettoequalthis INT, @IdProgIntegratoequalthis INT, @CostoTotaleequalthis DECIMAL(18,2), @ContributoDiMisuraequalthis DECIMAL(18,2), @ContributoRimanenteequalthis DECIMAL(18,2), @Misuraequalthis VARCHAR(10), @MisuraPrevalenteequalthis BIT',@IdBandoequalthis , @IdProgettoequalthis , @IdProgIntegratoequalthis , @CostoTotaleequalthis , @ContributoDiMisuraequalthis , @ContributoRimanenteequalthis , @Misuraequalthis , @MisuraPrevalenteequalthis ;
	else
		SELECT ID_BANDO, ID_PROGETTO, ID_PROG_INTEGRATO, COSTO_TOTALE, CONTRIBUTO_DI_MISURA, CONTRIBUTO_RIMANENTE, MISURA, MISURA_PREVALENTE
		FROM GRADUATORIA_PROGETTI_FINANZIABILITA
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdProgIntegratoequalthis IS NULL) OR ID_PROG_INTEGRATO = @IdProgIntegratoequalthis) AND 
			((@CostoTotaleequalthis IS NULL) OR COSTO_TOTALE = @CostoTotaleequalthis) AND 
			((@ContributoDiMisuraequalthis IS NULL) OR CONTRIBUTO_DI_MISURA = @ContributoDiMisuraequalthis) AND 
			((@ContributoRimanenteequalthis IS NULL) OR CONTRIBUTO_RIMANENTE = @ContributoRimanenteequalthis) AND 
			((@Misuraequalthis IS NULL) OR MISURA = @Misuraequalthis) AND 
			((@MisuraPrevalenteequalthis IS NULL) OR MISURA_PREVALENTE = @MisuraPrevalenteequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZGraduatoriaProgettiFinanziabilitaFindSelect';

