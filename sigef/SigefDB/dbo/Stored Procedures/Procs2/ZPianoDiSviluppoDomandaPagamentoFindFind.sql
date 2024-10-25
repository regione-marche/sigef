CREATE PROCEDURE [dbo].[ZPianoDiSviluppoDomandaPagamentoFindFind]
(
	@Annoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdImpresaequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PIANO, ANNO, ID_DOMANDA_PAGAMENTO, ID_IMPRESA, ID_PROGETTO, COSTO_INVESTIMENTO, MEZZI_PROPRI, RISORSE_TERZI, CONTRIBUTI_PUBBLICI, SPESE_GESTIONE, RIMBORSO_DEBITO, ENTRATA_GESTIONE, ALTRE_COPERTURE FROM PIANO_DI_SVILUPPO_DOMANDA_PAGAMENTO WHERE 1=1';
	IF (@Annoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNO = @Annoequalthis)'; set @lensql=@lensql+len(@Annoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	set @sql = @sql + 'ORDER BY ANNO ASC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Annoequalthis INT, @IdDomandaPagamentoequalthis INT, @IdProgettoequalthis INT, @IdImpresaequalthis INT',@Annoequalthis , @IdDomandaPagamentoequalthis , @IdProgettoequalthis , @IdImpresaequalthis ;
	else
		SELECT ID_PIANO, ANNO, ID_DOMANDA_PAGAMENTO, ID_IMPRESA, ID_PROGETTO, COSTO_INVESTIMENTO, MEZZI_PROPRI, RISORSE_TERZI, CONTRIBUTI_PUBBLICI, SPESE_GESTIONE, RIMBORSO_DEBITO, ENTRATA_GESTIONE, ALTRE_COPERTURE
		FROM PIANO_DI_SVILUPPO_DOMANDA_PAGAMENTO
		WHERE 
			((@Annoequalthis IS NULL) OR ANNO = @Annoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis)
		ORDER BY ANNO ASC

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPianoDiSviluppoDomandaPagamentoFindFind';

