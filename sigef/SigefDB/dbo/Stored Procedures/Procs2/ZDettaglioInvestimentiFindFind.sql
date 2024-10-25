CREATE PROCEDURE [dbo].[ZDettaglioInvestimentiFindFind]
(
	@IdCodificaInvestimentoequalthis INT, 
	@CodDettaglioequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_DETTAGLIO_INVESTIMENTO, ID_CODIFICA_INVESTIMENTO, COD_DETTAGLIO, DESCRIZIONE, MOBILE, QUOTA_SPESE_GENERALI, RICHIEDI_PARTICELLA, ID_UDM FROM DETTAGLIO_INVESTIMENTI WHERE 1=1';
	IF (@IdCodificaInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimentoequalthis)'; set @lensql=@lensql+len(@IdCodificaInvestimentoequalthis);end;
	IF (@CodDettaglioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_DETTAGLIO = @CodDettaglioequalthis)'; set @lensql=@lensql+len(@CodDettaglioequalthis);end;
	set @sql = @sql + 'ORDER BY ID_DETTAGLIO_INVESTIMENTO';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdCodificaInvestimentoequalthis INT, @CodDettaglioequalthis VARCHAR(255)',@IdCodificaInvestimentoequalthis , @CodDettaglioequalthis ;
	else
		SELECT ID_DETTAGLIO_INVESTIMENTO, ID_CODIFICA_INVESTIMENTO, COD_DETTAGLIO, DESCRIZIONE, MOBILE, QUOTA_SPESE_GENERALI, RICHIEDI_PARTICELLA, ID_UDM
		FROM DETTAGLIO_INVESTIMENTI
		WHERE 
			((@IdCodificaInvestimentoequalthis IS NULL) OR ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimentoequalthis) AND 
			((@CodDettaglioequalthis IS NULL) OR COD_DETTAGLIO = @CodDettaglioequalthis)
		ORDER BY ID_DETTAGLIO_INVESTIMENTO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZDettaglioInvestimentiFindFind]
(
	@IdDettaglioInvestimentoequalthis INT, 
	@IdCodificaInvestimentoequalthis INT, 
	@CodDettaglioequalthis CHAR(2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_DETTAGLIO_INVESTIMENTO, ID_CODIFICA_INVESTIMENTO, COD_DETTAGLIO, DESCRIZIONE, MOBILE, QUOTA_SPESE_GENERALI, RICHIEDI_PARTICELLA FROM DETTAGLIO_INVESTIMENTI WHERE 1=1'';
	IF (@IdDettaglioInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DETTAGLIO_INVESTIMENTO = @IdDettaglioInvestimentoequalthis)''; set @lensql=@lensql+len(@IdDettaglioInvestimentoequalthis);end;
	IF (@IdCodificaInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimentoequalthis)''; set @lensql=@lensql+len(@IdCodificaInvestimentoequalthis);end;
	IF (@CodDettaglioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_DETTAGLIO = @CodDettaglioequalthis)''; set @lensql=@lensql+len(@CodDettaglioequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdDettaglioInvestimentoequalthis INT, @IdCodificaInvestimentoequalthis INT, @CodDettaglioequalthis CHAR(2)'',@IdDettaglioInvestimentoequalthis , @IdCodificaInvestimentoequalthis , @CodDettaglioequalthis ;
	else
		SELECT ID_DETTAGLIO_INVESTIMENTO, ID_CODIFICA_INVESTIMENTO, COD_DETTAGLIO, DESCRIZIONE, MOBILE, QUOTA_SPESE_GENERALI, RICHIEDI_PARTICELLA
		FROM DETTAGLIO_INVESTIMENTI
		WHERE 
			((@IdDettaglioInvestimentoequalthis IS NULL) OR ID_DETTAGLIO_INVESTIMENTO = @IdDettaglioInvestimentoequalthis) AND 
			((@IdCodificaInvestimentoequalthis IS NULL) OR ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimentoequalthis) AND 
			((@CodDettaglioequalthis IS NULL) OR COD_DETTAGLIO = @CodDettaglioequalthis)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDettaglioInvestimentiFindFind';

