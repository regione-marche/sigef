CREATE PROCEDURE [dbo].[ZPrioritaXInvestimentiFindFind]
(
	@IdPrioritaequalthis INT, 
	@IdInvestimentoequalthis INT, 
	@IdValoreequalthis INT, 
	@Sceltoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PRIORITA, ID_INVESTIMENTO, ID_VALORE, SCELTO, DESCRIZIONE, VALORE_PUNTEGGIO, VALORE, VAL_DATA, VAL_TESTO FROM vPRIORITA_X_INVESTIMENTI WHERE 1=1';
	IF (@IdPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PRIORITA = @IdPrioritaequalthis)'; set @lensql=@lensql+len(@IdPrioritaequalthis);end;
	IF (@IdInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INVESTIMENTO = @IdInvestimentoequalthis)'; set @lensql=@lensql+len(@IdInvestimentoequalthis);end;
	IF (@IdValoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VALORE = @IdValoreequalthis)'; set @lensql=@lensql+len(@IdValoreequalthis);end;
	IF (@Sceltoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SCELTO = @Sceltoequalthis)'; set @lensql=@lensql+len(@Sceltoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdPrioritaequalthis INT, @IdInvestimentoequalthis INT, @IdValoreequalthis INT, @Sceltoequalthis BIT',@IdPrioritaequalthis , @IdInvestimentoequalthis , @IdValoreequalthis , @Sceltoequalthis ;
	else
		SELECT ID_PRIORITA, ID_INVESTIMENTO, ID_VALORE, SCELTO, DESCRIZIONE, VALORE_PUNTEGGIO, VALORE, VAL_DATA, VAL_TESTO
		FROM vPRIORITA_X_INVESTIMENTI
		WHERE 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis) AND 
			((@IdInvestimentoequalthis IS NULL) OR ID_INVESTIMENTO = @IdInvestimentoequalthis) AND 
			((@IdValoreequalthis IS NULL) OR ID_VALORE = @IdValoreequalthis) AND 
			((@Sceltoequalthis IS NULL) OR SCELTO = @Sceltoequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZPrioritaXInvestimentiFindFind]
(
	@IdPrioritaequalthis INT, 
	@IdInvestimentoequalthis INT, 
	@IdValoreequalthis INT, 
	@Sceltoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_PRIORITA, ID_INVESTIMENTO, ID_VALORE, SCELTO, DESCRIZIONE, VALORE_PUNTEGGIO, VALORE FROM vPRIORITA_X_INVESTIMENTI WHERE 1=1'';
	IF (@IdPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PRIORITA = @IdPrioritaequalthis)''; set @lensql=@lensql+len(@IdPrioritaequalthis);end;
	IF (@IdInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_INVESTIMENTO = @IdInvestimentoequalthis)''; set @lensql=@lensql+len(@IdInvestimentoequalthis);end;
	IF (@IdValoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_VALORE = @IdValoreequalthis)''; set @lensql=@lensql+len(@IdValoreequalthis);end;
	IF (@Sceltoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SCELTO = @Sceltoequalthis)''; set @lensql=@lensql+len(@Sceltoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdPrioritaequalthis INT, @IdInvestimentoequalthis INT, @IdValoreequalthis INT, @Sceltoequalthis BIT'',@IdPrioritaequalthis , @IdInvestimentoequalthis , @IdValoreequalthis , @Sceltoequalthis ;
	else
		SELECT ID_PRIORITA, ID_INVESTIMENTO, ID_VALORE, SCELTO, DESCRIZIONE, VALORE_PUNTEGGIO, VALORE
		FROM vPRIORITA_X_INVESTIMENTI
		WHERE 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis) AND 
			((@IdInvestimentoequalthis IS NULL) OR ID_INVESTIMENTO = @IdInvestimentoequalthis) AND 
			((@IdValoreequalthis IS NULL) OR ID_VALORE = @IdValoreequalthis) AND 
			((@Sceltoequalthis IS NULL) OR SCELTO = @Sceltoequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPrioritaXInvestimentiFindFind';

