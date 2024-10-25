CREATE PROCEDURE [dbo].[ZLocalizzazioneInvestimentoFindFind]
(
	@IdLocalizzazioneequalthis INT, 
	@IdInvestimentoequalthis INT, 
	@IdCatastoequalthis INT, 
	@IdComuneequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_LOCALIZZAZIONE, ID_INVESTIMENTO, ID_CATASTO, ID_COMUNE, FOGLIO_CATASTALE, PARTICELLA, SEZIONE, SUBALTERNO, SUPERFICIE_CATASTALE, SVANTAGGIO FROM vLOCALIZZAZIONE_INVESTIMENTO WHERE 1=1';
	IF (@IdLocalizzazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_LOCALIZZAZIONE = @IdLocalizzazioneequalthis)'; set @lensql=@lensql+len(@IdLocalizzazioneequalthis);end;
	IF (@IdInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INVESTIMENTO = @IdInvestimentoequalthis)'; set @lensql=@lensql+len(@IdInvestimentoequalthis);end;
	IF (@IdCatastoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CATASTO = @IdCatastoequalthis)'; set @lensql=@lensql+len(@IdCatastoequalthis);end;
	IF (@IdComuneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COMUNE = @IdComuneequalthis)'; set @lensql=@lensql+len(@IdComuneequalthis);end;
	--	@sql = @sql + ' order by ecc.ecc.'
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdLocalizzazioneequalthis INT, @IdInvestimentoequalthis INT, @IdCatastoequalthis INT, @IdComuneequalthis INT',@IdLocalizzazioneequalthis , @IdInvestimentoequalthis , @IdCatastoequalthis , @IdComuneequalthis ;
	else
		SELECT ID_LOCALIZZAZIONE, ID_INVESTIMENTO, ID_CATASTO, ID_COMUNE, FOGLIO_CATASTALE, PARTICELLA, SEZIONE, SUBALTERNO, SUPERFICIE_CATASTALE, SVANTAGGIO
		FROM vLOCALIZZAZIONE_INVESTIMENTO
		WHERE 
			((@IdLocalizzazioneequalthis IS NULL) OR ID_LOCALIZZAZIONE = @IdLocalizzazioneequalthis) AND 
			((@IdInvestimentoequalthis IS NULL) OR ID_INVESTIMENTO = @IdInvestimentoequalthis) AND 
			((@IdCatastoequalthis IS NULL) OR ID_CATASTO = @IdCatastoequalthis) AND 
			((@IdComuneequalthis IS NULL) OR ID_COMUNE = @IdComuneequalthis)
		-- order by ecc.ecc.
