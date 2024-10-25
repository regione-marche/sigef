CREATE PROCEDURE [dbo].[ZGraduatoriaProgettiFindFind]
(
	@IdBandoequalthis INT, 
	@IdProgettoequalthis INT, 
	@Finanziabilitaequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, ID_PROGETTO, PUNTEGGIO, DATA_VALUTAZIONE, OPERATORE, ORDINE, COSTO_TOTALE, CONTRIBUTO_TOTALE, CONTRIBUTO_RIMANENTE, FINANZIABILITA, UTILIZZA_FONDI_RISERVA, AMMONTARE_FONDI_RISERVA_UTILIZZATO FROM GRADUATORIA_PROGETTI WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@Finanziabilitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FINANZIABILITA = @Finanziabilitaequalthis)'; set @lensql=@lensql+len(@Finanziabilitaequalthis);end;
	set @sql = @sql + 'ORDER BY ORDINE, PUNTEGGIO DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @IdProgettoequalthis INT, @Finanziabilitaequalthis VARCHAR(255)',@IdBandoequalthis , @IdProgettoequalthis , @Finanziabilitaequalthis ;
	else
		SELECT ID_BANDO, ID_PROGETTO, PUNTEGGIO, DATA_VALUTAZIONE, OPERATORE, ORDINE, COSTO_TOTALE, CONTRIBUTO_TOTALE, CONTRIBUTO_RIMANENTE, FINANZIABILITA, UTILIZZA_FONDI_RISERVA, AMMONTARE_FONDI_RISERVA_UTILIZZATO
		FROM GRADUATORIA_PROGETTI
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@Finanziabilitaequalthis IS NULL) OR FINANZIABILITA = @Finanziabilitaequalthis)
		ORDER BY ORDINE, PUNTEGGIO DESC

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZGraduatoriaProgettiFindFind]
(
	@IdBandoequalthis INT, 
	@IdProgettoequalthis INT, 
	@Finanziabilitaequalthis CHAR(1)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_BANDO, ID_PROGETTO, PUNTEGGIO, DATA_VALUTAZIONE, OPERATORE, ORDINE, COSTO_TOTALE, CONTRIBUTO_TOTALE, CONTRIBUTO_RIMANENTE, FINANZIABILITA, UTILIZZA_FONDI_RISERVA, AMMONTARE_FONDI_RISERVA_UTILIZZATO FROM GRADUATORIA_PROGETTI WHERE 1=1'';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@Finanziabilitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (FINANZIABILITA = @Finanziabilitaequalthis)''; set @lensql=@lensql+len(@Finanziabilitaequalthis);end;
	set @sql = @sql + ''ORDER BY ORDINE, PUNTEGGIO DESC'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdBandoequalthis INT, @IdProgettoequalthis INT, @Finanziabilitaequalthis CHAR(1)'',@IdBandoequalthis , @IdProgettoequalthis , @Finanziabilitaequalthis ;
	else
		SELECT ID_BANDO, ID_PROGETTO, PUNTEGGIO, DATA_VALUTAZIONE, OPERATORE, ORDINE, COSTO_TOTALE, CONTRIBUTO_TOTALE, CONTRIBUTO_RIMANENTE, FINANZIABILITA, UTILIZZA_FONDI_RISERVA, AMMONTARE_FONDI_RISERVA_UTILIZZATO
		FROM GRADUATORIA_PROGETTI
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@Finanziabilitaequalthis IS NULL) OR FINANZIABILITA = @Finanziabilitaequalthis)
		ORDER BY ORDINE, PUNTEGGIO DESC

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZGraduatoriaProgettiFindFind';

