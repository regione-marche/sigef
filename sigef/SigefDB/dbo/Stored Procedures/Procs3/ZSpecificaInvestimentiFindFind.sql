CREATE PROCEDURE [dbo].[ZSpecificaInvestimentiFindFind]
(
	@IdDettaglioInvestimentoequalthis INT, 
	@CodSpecificaequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_SPECIFICA_INVESTIMENTO, ID_DETTAGLIO_INVESTIMENTO, COD_SPECIFICA, DESCRIZIONE FROM SPECIFICA_INVESTIMENTI WHERE 1=1';
	IF (@IdDettaglioInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DETTAGLIO_INVESTIMENTO = @IdDettaglioInvestimentoequalthis)'; set @lensql=@lensql+len(@IdDettaglioInvestimentoequalthis);end;
	IF (@CodSpecificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_SPECIFICA = @CodSpecificaequalthis)'; set @lensql=@lensql+len(@CodSpecificaequalthis);end;
	set @sql = @sql + 'ORDER BY ID_DETTAGLIO_INVESTIMENTO';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdDettaglioInvestimentoequalthis INT, @CodSpecificaequalthis VARCHAR(255)',@IdDettaglioInvestimentoequalthis , @CodSpecificaequalthis ;
	else
		SELECT ID_SPECIFICA_INVESTIMENTO, ID_DETTAGLIO_INVESTIMENTO, COD_SPECIFICA, DESCRIZIONE
		FROM SPECIFICA_INVESTIMENTI
		WHERE 
			((@IdDettaglioInvestimentoequalthis IS NULL) OR ID_DETTAGLIO_INVESTIMENTO = @IdDettaglioInvestimentoequalthis) AND 
			((@CodSpecificaequalthis IS NULL) OR COD_SPECIFICA = @CodSpecificaequalthis)
		ORDER BY ID_DETTAGLIO_INVESTIMENTO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZSpecificaInvestimentiFindFind]
(
	@IdSpecificaInvestimentoequalthis INT, 
	@IdDettaglioInvestimentoequalthis INT, 
	@CodSpecificaequalthis CHAR(2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_SPECIFICA_INVESTIMENTO, ID_DETTAGLIO_INVESTIMENTO, COD_SPECIFICA, DESCRIZIONE FROM SPECIFICA_INVESTIMENTI WHERE 1=1'';
	IF (@IdSpecificaInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_SPECIFICA_INVESTIMENTO = @IdSpecificaInvestimentoequalthis)''; set @lensql=@lensql+len(@IdSpecificaInvestimentoequalthis);end;
	IF (@IdDettaglioInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DETTAGLIO_INVESTIMENTO = @IdDettaglioInvestimentoequalthis)''; set @lensql=@lensql+len(@IdDettaglioInvestimentoequalthis);end;
	IF (@CodSpecificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_SPECIFICA = @CodSpecificaequalthis)''; set @lensql=@lensql+len(@CodSpecificaequalthis);end;
	--	@sql = @sql + '' order by ecc.ecc.''
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdSpecificaInvestimentoequalthis INT, @IdDettaglioInvestimentoequalthis INT, @CodSpecificaequalthis CHAR(2)'',@IdSpecificaInvestimentoequalthis , @IdDettaglioInvestimentoequalthis , @CodSpecificaequalthis ;
	else
		SELECT ID_SPECIFICA_INVESTIMENTO, ID_DETTAGLIO_INVESTIMENTO, COD_SPECIFICA, DESCRIZIONE
		FROM SPECIFICA_INVESTIMENTI
		WHERE 
			((@IdSpecificaInvestimentoequalthis IS NULL) OR ID_SPECIFICA_INVESTIMENTO = @IdSpecificaInvestimentoequalthis) AND 
			((@IdDettaglioInvestimentoequalthis IS NULL) OR ID_DETTAGLIO_INVESTIMENTO = @IdDettaglioInvestimentoequalthis) AND 
			((@CodSpecificaequalthis IS NULL) OR COD_SPECIFICA = @CodSpecificaequalthis)
		-- order by ecc.ecc.
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSpecificaInvestimentiFindFind';

