CREATE PROCEDURE [dbo].[ZGraduatoriaProgettiFinanziabilitaFindFind]
(
	@IdBandoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdProgIntegratoequalthis INT, 
	@Misuraequalthis VARCHAR(10)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, ID_PROGETTO, ID_PROG_INTEGRATO, COSTO_TOTALE, CONTRIBUTO_DI_MISURA, CONTRIBUTO_RIMANENTE, MISURA, MISURA_PREVALENTE FROM GRADUATORIA_PROGETTI_FINANZIABILITA WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdProgIntegratoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROG_INTEGRATO = @IdProgIntegratoequalthis)'; set @lensql=@lensql+len(@IdProgIntegratoequalthis);end;
	IF (@Misuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MISURA = @Misuraequalthis)'; set @lensql=@lensql+len(@Misuraequalthis);end;
	set @sql = @sql + 'ORDER BY MISURA_PREVALENTE DESC, MISURA';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @IdProgettoequalthis INT, @IdProgIntegratoequalthis INT, @Misuraequalthis VARCHAR(10)',@IdBandoequalthis , @IdProgettoequalthis , @IdProgIntegratoequalthis , @Misuraequalthis ;
	else
		SELECT ID_BANDO, ID_PROGETTO, ID_PROG_INTEGRATO, COSTO_TOTALE, CONTRIBUTO_DI_MISURA, CONTRIBUTO_RIMANENTE, MISURA, MISURA_PREVALENTE
		FROM GRADUATORIA_PROGETTI_FINANZIABILITA
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdProgIntegratoequalthis IS NULL) OR ID_PROG_INTEGRATO = @IdProgIntegratoequalthis) AND 
			((@Misuraequalthis IS NULL) OR MISURA = @Misuraequalthis)
		ORDER BY MISURA_PREVALENTE DESC, MISURA

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZGraduatoriaProgettiFinanziabilitaFindFind';

