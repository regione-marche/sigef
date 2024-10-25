CREATE PROCEDURE [dbo].[ZPrioritaXInvestimentiFindSelect]
(
	@IdPrioritaequalthis INT, 
	@IdInvestimentoequalthis INT, 
	@IdValoreequalthis INT, 
	@Sceltoequalthis BIT, 
	@Valoreequalthis DECIMAL(18,2), 
	@ValDataequalthis DATETIME, 
	@ValTestoequalthis VARCHAR(500)
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
	IF (@Valoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VALORE = @Valoreequalthis)'; set @lensql=@lensql+len(@Valoreequalthis);end;
	IF (@ValDataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VAL_DATA = @ValDataequalthis)'; set @lensql=@lensql+len(@ValDataequalthis);end;
	IF (@ValTestoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VAL_TESTO = @ValTestoequalthis)'; set @lensql=@lensql+len(@ValTestoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdPrioritaequalthis INT, @IdInvestimentoequalthis INT, @IdValoreequalthis INT, @Sceltoequalthis BIT, @Valoreequalthis DECIMAL(18,2), @ValDataequalthis DATETIME, @ValTestoequalthis VARCHAR(500)',@IdPrioritaequalthis , @IdInvestimentoequalthis , @IdValoreequalthis , @Sceltoequalthis , @Valoreequalthis , @ValDataequalthis , @ValTestoequalthis ;
	else
		SELECT ID_PRIORITA, ID_INVESTIMENTO, ID_VALORE, SCELTO, DESCRIZIONE, VALORE_PUNTEGGIO, VALORE, VAL_DATA, VAL_TESTO
		FROM vPRIORITA_X_INVESTIMENTI
		WHERE 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis) AND 
			((@IdInvestimentoequalthis IS NULL) OR ID_INVESTIMENTO = @IdInvestimentoequalthis) AND 
			((@IdValoreequalthis IS NULL) OR ID_VALORE = @IdValoreequalthis) AND 
			((@Sceltoequalthis IS NULL) OR SCELTO = @Sceltoequalthis) AND 
			((@Valoreequalthis IS NULL) OR VALORE = @Valoreequalthis) AND 
			((@ValDataequalthis IS NULL) OR VAL_DATA = @ValDataequalthis) AND 
			((@ValTestoequalthis IS NULL) OR VAL_TESTO = @ValTestoequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZPrioritaXInvestimentiFindSelect]
(
	@IdPrioritaequalthis INT, 
	@IdInvestimentoequalthis INT, 
	@IdValoreequalthis INT, 
	@Sceltoequalthis BIT, 
	@Valoreequalthis DECIMAL(18,2)
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
	IF (@Valoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (VALORE = @Valoreequalthis)''; set @lensql=@lensql+len(@Valoreequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdPrioritaequalthis INT, @IdInvestimentoequalthis INT, @IdValoreequalthis INT, @Sceltoequalthis BIT, @Valoreequalthis DECIMAL(18,2)'',@IdPrioritaequalthis , @IdInvestimentoequalthis , @IdValoreequalthis , @Sceltoequalthis , @Valoreequalthis ;
	else
		SELECT ID_PRIORITA, ID_INVESTIMENTO, ID_VALORE, SCELTO, DESCRIZIONE, VALORE_PUNTEGGIO, VALORE
		FROM vPRIORITA_X_INVESTIMENTI
		WHERE 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis) AND 
			((@IdInvestimentoequalthis IS NULL) OR ID_INVESTIMENTO = @IdInvestimentoequalthis) AND 
			((@IdValoreequalthis IS NULL) OR ID_VALORE = @IdValoreequalthis) AND 
			((@Sceltoequalthis IS NULL) OR SCELTO = @Sceltoequalthis) AND 
			((@Valoreequalthis IS NULL) OR VALORE = @Valoreequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPrioritaXInvestimentiFindSelect';

