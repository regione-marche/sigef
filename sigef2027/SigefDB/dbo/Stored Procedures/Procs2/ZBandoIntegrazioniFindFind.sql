CREATE PROCEDURE [dbo].[ZBandoIntegrazioniFindFind]
(
	@IdBandoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_BANDO, DATA, OPERATORE, DATA_SCADENZA, IMPORTO, IMPORTO_DI_MISURA, QUOTA_RISERVA, ID_ATTO FROM BANDO_INTEGRAZIONI WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	set @sql = @sql + 'ORDER BY DATA DESC, ID DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT',@IdBandoequalthis ;
	else
		SELECT ID, ID_BANDO, DATA, OPERATORE, DATA_SCADENZA, IMPORTO, IMPORTO_DI_MISURA, QUOTA_RISERVA, ID_ATTO
		FROM BANDO_INTEGRAZIONI
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis)
		ORDER BY DATA DESC, ID DESC

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'
CREATE PROCEDURE [dbo].[ZBandoIntegrazioniFindFind]
(
	@IdBandoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_BANDO, DATA, OPERATORE, DATA_SCADENZA, IMPORTO, IMPORTO_DI_MISURA, QUOTA_RISERVA, ID_ATTO FROM BANDO_INTEGRAZIONI WHERE 1=1'';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	set @sql = @sql + ''ORDER BY DATA DESC, ID DESC'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdBandoequalthis INT'',@IdBandoequalthis ;
	else
		SELECT ID, ID_BANDO, DATA, OPERATORE, DATA_SCADENZA, IMPORTO, IMPORTO_DI_MISURA, QUOTA_RISERVA, ID_ATTO
		FROM BANDO_INTEGRAZIONI
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis)
		ORDER BY DATA DESC, ID DESC


', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoIntegrazioniFindFind';

