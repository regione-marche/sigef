CREATE PROCEDURE [dbo].[ZDomandaPagamentoRequisitiFindFind]
(
	@IdDomandaPagamentoequalthis INT, 
	@IdRequisitoequalthis INT, 
	@Misuralikethis VARCHAR(10)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_DOMANDA_PAGAMENTO, ID_REQUISITO, ID_VALORE, VAL_NUMERICO, VAL_DATA, VAL_TESTO, ESITO, DATA_ESITO, DESCRIZIONE, PLURIVALORE, NUMERICO, DATETIME, TESTO_SEMPLICE, TESTO_AREA, URL, QUERY_EVAL, QUERY_INSERT, MISURA, CODICE_VALORE, DESCRIZIONE_VALORE, SELEZIONATO FROM vDOMANDA_REQUISITI_PAGAMENTO WHERE 1=1';
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdRequisitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_REQUISITO = @IdRequisitoequalthis)'; set @lensql=@lensql+len(@IdRequisitoequalthis);end;
	IF (@Misuralikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MISURA LIKE @Misuralikethis)'; set @lensql=@lensql+len(@Misuralikethis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdDomandaPagamentoequalthis INT, @IdRequisitoequalthis INT, @Misuralikethis VARCHAR(10)',@IdDomandaPagamentoequalthis , @IdRequisitoequalthis , @Misuralikethis ;
	else
		SELECT ID_DOMANDA_PAGAMENTO, ID_REQUISITO, ID_VALORE, VAL_NUMERICO, VAL_DATA, VAL_TESTO, ESITO, DATA_ESITO, DESCRIZIONE, PLURIVALORE, NUMERICO, DATETIME, TESTO_SEMPLICE, TESTO_AREA, URL, QUERY_EVAL, QUERY_INSERT, MISURA, CODICE_VALORE, DESCRIZIONE_VALORE, SELEZIONATO
		FROM vDOMANDA_REQUISITI_PAGAMENTO
		WHERE 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdRequisitoequalthis IS NULL) OR ID_REQUISITO = @IdRequisitoequalthis) AND 
			((@Misuralikethis IS NULL) OR MISURA LIKE @Misuralikethis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZDomandaPagamentoRequisitiFindFind]
(
	@IdDomandaPagamentoequalthis INT, 
	@IdRequisitoequalthis INT, 
	@Misuralikethis VARCHAR(10)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_DOMANDA_PAGAMENTO, ID_REQUISITO, ID_VALORE, VAL_NUMERICO, VAL_DATA, VAL_TESTO, ESITO, DATA_ESITO, DESCRIZIONE, PLURIVALORE, NUMERICO, DATETIME, TESTO_SEMPLICE, TESTO_AREA, URL, QUERY_EVAL, QUERY_INSERT, MISURA, CODICE_VALORE, DESCRIZIONE_VALORE FROM vDOMANDA_REQUISITI_PAGAMENTO WHERE 1=1'';
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)''; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdRequisitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_REQUISITO = @IdRequisitoequalthis)''; set @lensql=@lensql+len(@IdRequisitoequalthis);end;
	IF (@Misuralikethis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (MISURA LIKE @Misuralikethis)''; set @lensql=@lensql+len(@Misuralikethis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdDomandaPagamentoequalthis INT, @IdRequisitoequalthis INT, @Misuralikethis VARCHAR(10)'',@IdDomandaPagamentoequalthis , @IdRequisitoequalthis , @Misuralikethis ;
	else
		SELECT ID_DOMANDA_PAGAMENTO, ID_REQUISITO, ID_VALORE, VAL_NUMERICO, VAL_DATA, VAL_TESTO, ESITO, DATA_ESITO, DESCRIZIONE, PLURIVALORE, NUMERICO, DATETIME, TESTO_SEMPLICE, TESTO_AREA, URL, QUERY_EVAL, QUERY_INSERT, MISURA, CODICE_VALORE, DESCRIZIONE_VALORE
		FROM vDOMANDA_REQUISITI_PAGAMENTO
		WHERE 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdRequisitoequalthis IS NULL) OR ID_REQUISITO = @IdRequisitoequalthis) AND 
			((@Misuralikethis IS NULL) OR MISURA LIKE @Misuralikethis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDomandaPagamentoRequisitiFindFind';

