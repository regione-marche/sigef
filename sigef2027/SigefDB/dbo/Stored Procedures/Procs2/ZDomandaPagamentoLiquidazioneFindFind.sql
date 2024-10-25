CREATE PROCEDURE [dbo].[ZDomandaPagamentoLiquidazioneFindFind]
(
	@IdDomandaPagamentoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdImpresaBeneficiariaequalthis INT, 
	@Liquidatoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_DOMANDA_PAGAMENTO, ID_PROGETTO, ID_IMPRESA_BENEFICIARIA, ID_DECRETO, RICHIESTA_MANDATO_IMPORTO, RICHIESTA_MANDATO_SEGNATURA, RICHIESTA_MANDATO_DATA, MANDATO_NUMERO, MANDATO_DATA, MANDATO_IMPORTO, MANDATO_ID_FILE, QUIETANZA_DATA, QUIETANZA_IMPORTO, LIQUIDATO FROM DOMANDA_PAGAMENTO_LIQUIDAZIONE WHERE 1=1';
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdImpresaBeneficiariaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA_BENEFICIARIA = @IdImpresaBeneficiariaequalthis)'; set @lensql=@lensql+len(@IdImpresaBeneficiariaequalthis);end;
	IF (@Liquidatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (LIQUIDATO = @Liquidatoequalthis)'; set @lensql=@lensql+len(@Liquidatoequalthis);end;
	set @sql = @sql + 'ORDER BY ID';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdDomandaPagamentoequalthis INT, @IdProgettoequalthis INT, @IdImpresaBeneficiariaequalthis INT, @Liquidatoequalthis BIT',@IdDomandaPagamentoequalthis , @IdProgettoequalthis , @IdImpresaBeneficiariaequalthis , @Liquidatoequalthis ;
	else
		SELECT ID, ID_DOMANDA_PAGAMENTO, ID_PROGETTO, ID_IMPRESA_BENEFICIARIA, ID_DECRETO, RICHIESTA_MANDATO_IMPORTO, RICHIESTA_MANDATO_SEGNATURA, RICHIESTA_MANDATO_DATA, MANDATO_NUMERO, MANDATO_DATA, MANDATO_IMPORTO, MANDATO_ID_FILE, QUIETANZA_DATA, QUIETANZA_IMPORTO, LIQUIDATO
		FROM DOMANDA_PAGAMENTO_LIQUIDAZIONE
		WHERE 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdImpresaBeneficiariaequalthis IS NULL) OR ID_IMPRESA_BENEFICIARIA = @IdImpresaBeneficiariaequalthis) AND 
			((@Liquidatoequalthis IS NULL) OR LIQUIDATO = @Liquidatoequalthis)
		ORDER BY ID


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZDomandaPagamentoLiquidazioneFindFind]
(
	@IdDomandaPagamentoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdImpresaBeneficiariaequalthis INT, 
	@Liquidatoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_DOMANDA_PAGAMENTO, ID_PROGETTO, ID_IMPRESA_BENEFICIARIA, ID_DECRETO, RICHIESTA_MANDATO_IMPORTO, RICHIESTA_MANDATO_SEGNATURA, RICHIESTA_MANDATO_DATA, MANDATO_NUMERO, MANDATO_DATA, MANDATO_IMPORTO, MANDATO_ID_FILE, QUIETANZA_DATA, QUIETANZA_IMPORTO, LIQUIDATO FROM DOMANDA_PAGAMENTO_LIQUIDAZIONE WHERE 1=1'';
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)''; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdImpresaBeneficiariaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_IMPRESA_BENEFICIARIA = @IdImpresaBeneficiariaequalthis)''; set @lensql=@lensql+len(@IdImpresaBeneficiariaequalthis);end;
	IF (@Liquidatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (LIQUIDATO = @Liquidatoequalthis)''; set @lensql=@lensql+len(@Liquidatoequalthis);end;
	set @sql = @sql + ''ORDER BY ID'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdDomandaPagamentoequalthis INT, @IdProgettoequalthis INT, @IdImpresaBeneficiariaequalthis INT, @Liquidatoequalthis BIT'',@IdDomandaPagamentoequalthis , @IdProgettoequalthis , @IdImpresaBeneficiariaequalthis , @Liquidatoequalthis ;
	else
		SELECT ID, ID_DOMANDA_PAGAMENTO, ID_PROGETTO, ID_IMPRESA_BENEFICIARIA, ID_DECRETO, RICHIESTA_MANDATO_IMPORTO, RICHIESTA_MANDATO_SEGNATURA, RICHIESTA_MANDATO_DATA, MANDATO_NUMERO, MANDATO_DATA, MANDATO_IMPORTO, MANDATO_ID_FILE, QUIETANZA_DATA, QUIETANZA_IMPORTO, LIQUIDATO
		FROM DOMANDA_PAGAMENTO_LIQUIDAZIONE
		WHERE 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdImpresaBeneficiariaequalthis IS NULL) OR ID_IMPRESA_BENEFICIARIA = @IdImpresaBeneficiariaequalthis) AND 
			((@Liquidatoequalthis IS NULL) OR LIQUIDATO = @Liquidatoequalthis)
		ORDER BY ID

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDomandaPagamentoLiquidazioneFindFind';

