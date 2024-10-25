CREATE PROCEDURE [dbo].[ZLocalizzazioneInvestimentoFindSelect]
(
	@IdLocalizzazioneequalthis INT, 
	@IdInvestimentoequalthis INT, 
	@IdCatastoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_LOCALIZZAZIONE, ID_INVESTIMENTO, ID_CATASTO, ID_COMUNE, FOGLIO_CATASTALE, PARTICELLA, SEZIONE, SUBALTERNO, SUPERFICIE_CATASTALE, SVANTAGGIO FROM vLOCALIZZAZIONE_INVESTIMENTO WHERE 1=1';
	IF (@IdLocalizzazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_LOCALIZZAZIONE = @IdLocalizzazioneequalthis)'; set @lensql=@lensql+len(@IdLocalizzazioneequalthis);end;
	IF (@IdInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INVESTIMENTO = @IdInvestimentoequalthis)'; set @lensql=@lensql+len(@IdInvestimentoequalthis);end;
	IF (@IdCatastoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CATASTO = @IdCatastoequalthis)'; set @lensql=@lensql+len(@IdCatastoequalthis);end;
	--	@sql = @sql + ' order by ecc.ecc.'
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdLocalizzazioneequalthis INT, @IdInvestimentoequalthis INT, @IdCatastoequalthis INT',@IdLocalizzazioneequalthis , @IdInvestimentoequalthis , @IdCatastoequalthis ;
	else
		SELECT ID_LOCALIZZAZIONE, ID_INVESTIMENTO, ID_CATASTO, ID_COMUNE, FOGLIO_CATASTALE, PARTICELLA, SEZIONE, SUBALTERNO, SUPERFICIE_CATASTALE, SVANTAGGIO
		FROM vLOCALIZZAZIONE_INVESTIMENTO
		WHERE 
			((@IdLocalizzazioneequalthis IS NULL) OR ID_LOCALIZZAZIONE = @IdLocalizzazioneequalthis) AND 
			((@IdInvestimentoequalthis IS NULL) OR ID_INVESTIMENTO = @IdInvestimentoequalthis) AND 
			((@IdCatastoequalthis IS NULL) OR ID_CATASTO = @IdCatastoequalthis)
		-- order by ecc.ecc.
