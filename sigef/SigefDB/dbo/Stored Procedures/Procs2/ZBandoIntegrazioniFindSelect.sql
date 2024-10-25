CREATE PROCEDURE [dbo].[ZBandoIntegrazioniFindSelect]
(
	@Idequalthis INT, 
	@IdBandoequalthis INT, 
	@Dataequalthis DATETIME, 
	@Operatoreequalthis INT, 
	@DataScadenzaequalthis DATETIME, 
	@Importoequalthis DECIMAL(18,2), 
	@ImportoDiMisuraequalthis DECIMAL(18,2), 
	@QuotaRiservaequalthis DECIMAL(10,2), 
	@IdAttoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_BANDO, DATA, OPERATORE, DATA_SCADENZA, IMPORTO, IMPORTO_DI_MISURA, QUOTA_RISERVA, ID_ATTO FROM BANDO_INTEGRAZIONI WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@DataScadenzaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_SCADENZA = @DataScadenzaequalthis)'; set @lensql=@lensql+len(@DataScadenzaequalthis);end;
	IF (@Importoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO = @Importoequalthis)'; set @lensql=@lensql+len(@Importoequalthis);end;
	IF (@ImportoDiMisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_DI_MISURA = @ImportoDiMisuraequalthis)'; set @lensql=@lensql+len(@ImportoDiMisuraequalthis);end;
	IF (@QuotaRiservaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUOTA_RISERVA = @QuotaRiservaequalthis)'; set @lensql=@lensql+len(@QuotaRiservaequalthis);end;
	IF (@IdAttoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ATTO = @IdAttoequalthis)'; set @lensql=@lensql+len(@IdAttoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @IdBandoequalthis INT, @Dataequalthis DATETIME, @Operatoreequalthis INT, @DataScadenzaequalthis DATETIME, @Importoequalthis DECIMAL(18,2), @ImportoDiMisuraequalthis DECIMAL(18,2), @QuotaRiservaequalthis DECIMAL(10,2), @IdAttoequalthis INT',@Idequalthis , @IdBandoequalthis , @Dataequalthis , @Operatoreequalthis , @DataScadenzaequalthis , @Importoequalthis , @ImportoDiMisuraequalthis , @QuotaRiservaequalthis , @IdAttoequalthis ;
	else
		SELECT ID, ID_BANDO, DATA, OPERATORE, DATA_SCADENZA, IMPORTO, IMPORTO_DI_MISURA, QUOTA_RISERVA, ID_ATTO
		FROM BANDO_INTEGRAZIONI
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@DataScadenzaequalthis IS NULL) OR DATA_SCADENZA = @DataScadenzaequalthis) AND 
			((@Importoequalthis IS NULL) OR IMPORTO = @Importoequalthis) AND 
			((@ImportoDiMisuraequalthis IS NULL) OR IMPORTO_DI_MISURA = @ImportoDiMisuraequalthis) AND 
			((@QuotaRiservaequalthis IS NULL) OR QUOTA_RISERVA = @QuotaRiservaequalthis) AND 
			((@IdAttoequalthis IS NULL) OR ID_ATTO = @IdAttoequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'
CREATE PROCEDURE [dbo].[ZBandoIntegrazioniFindSelect]
(
	@Idequalthis INT, 
	@IdBandoequalthis INT, 
	@Dataequalthis DATETIME, 
	@Operatoreequalthis INT, 
	@DataScadenzaequalthis DATETIME, 
	@Importoequalthis DECIMAL(18,2), 
	@ImportoDiMisuraequalthis DECIMAL(18,2), 
	@QuotaRiservaequalthis DECIMAL(10,2), 
	@IdAttoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_BANDO, DATA, OPERATORE, DATA_SCADENZA, IMPORTO, IMPORTO_DI_MISURA, QUOTA_RISERVA, ID_ATTO FROM BANDO_INTEGRAZIONI WHERE 1=1'';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID = @Idequalthis)''; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA = @Dataequalthis)''; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (OPERATORE = @Operatoreequalthis)''; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@DataScadenzaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_SCADENZA = @DataScadenzaequalthis)''; set @lensql=@lensql+len(@DataScadenzaequalthis);end;
	IF (@Importoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IMPORTO = @Importoequalthis)''; set @lensql=@lensql+len(@Importoequalthis);end;
	IF (@ImportoDiMisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IMPORTO_DI_MISURA = @ImportoDiMisuraequalthis)''; set @lensql=@lensql+len(@ImportoDiMisuraequalthis);end;
	IF (@QuotaRiservaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (QUOTA_RISERVA = @QuotaRiservaequalthis)''; set @lensql=@lensql+len(@QuotaRiservaequalthis);end;
	IF (@IdAttoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_ATTO = @IdAttoequalthis)''; set @lensql=@lensql+len(@IdAttoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@Idequalthis INT, @IdBandoequalthis INT, @Dataequalthis DATETIME, @Operatoreequalthis INT, @DataScadenzaequalthis DATETIME, @Importoequalthis DECIMAL(18,2), @ImportoDiMisuraequalthis DECIMAL(18,2), @QuotaRiservaequalthis DECIMAL(10,2), @IdAttoequalthis INT'',@Idequalthis , @IdBandoequalthis , @Dataequalthis , @Operatoreequalthis , @DataScadenzaequalthis , @Importoequalthis , @ImportoDiMisuraequalthis , @QuotaRiservaequalthis , @IdAttoequalthis ;
	else
		SELECT ID, ID_BANDO, DATA, OPERATORE, DATA_SCADENZA, IMPORTO, IMPORTO_DI_MISURA, QUOTA_RISERVA, ID_ATTO
		FROM BANDO_INTEGRAZIONI
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@DataScadenzaequalthis IS NULL) OR DATA_SCADENZA = @DataScadenzaequalthis) AND 
			((@Importoequalthis IS NULL) OR IMPORTO = @Importoequalthis) AND 
			((@ImportoDiMisuraequalthis IS NULL) OR IMPORTO_DI_MISURA = @ImportoDiMisuraequalthis) AND 
			((@QuotaRiservaequalthis IS NULL) OR QUOTA_RISERVA = @QuotaRiservaequalthis) AND 
			((@IdAttoequalthis IS NULL) OR ID_ATTO = @IdAttoequalthis)
		


', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoIntegrazioniFindSelect';

