CREATE PROCEDURE [dbo].[ZControlliParametriXDomandaFindFind]
(
	@IdDomandaPagamentoequalthis INT, 
	@IdParametroequalthis INT, 
	@IdLottoequalthis INT, 
	@Manualeequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_DOMANDA_PAGAMENTO, ID_PARAMETRO, ID_LOTTO, PUNTEGGIO, DATA_VALUTAZIONE, OPERATORE, DESCRIZIONE, MANUALE, QUERY_SQL FROM vCONTROLLI_PARAMETRI_X_DOMANDA WHERE 1=1';
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdParametroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PARAMETRO = @IdParametroequalthis)'; set @lensql=@lensql+len(@IdParametroequalthis);end;
	IF (@IdLottoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_LOTTO = @IdLottoequalthis)'; set @lensql=@lensql+len(@IdLottoequalthis);end;
	IF (@Manualeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MANUALE = @Manualeequalthis)'; set @lensql=@lensql+len(@Manualeequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdDomandaPagamentoequalthis INT, @IdParametroequalthis INT, @IdLottoequalthis INT, @Manualeequalthis BIT',@IdDomandaPagamentoequalthis , @IdParametroequalthis , @IdLottoequalthis , @Manualeequalthis ;
	else
		SELECT ID_DOMANDA_PAGAMENTO, ID_PARAMETRO, ID_LOTTO, PUNTEGGIO, DATA_VALUTAZIONE, OPERATORE, DESCRIZIONE, MANUALE, QUERY_SQL
		FROM vCONTROLLI_PARAMETRI_X_DOMANDA
		WHERE 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdParametroequalthis IS NULL) OR ID_PARAMETRO = @IdParametroequalthis) AND 
			((@IdLottoequalthis IS NULL) OR ID_LOTTO = @IdLottoequalthis) AND 
			((@Manualeequalthis IS NULL) OR MANUALE = @Manualeequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZControlliParametriXDomandaFindFind';

