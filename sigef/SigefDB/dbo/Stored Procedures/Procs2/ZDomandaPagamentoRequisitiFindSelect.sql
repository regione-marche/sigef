CREATE PROCEDURE [dbo].[ZDomandaPagamentoRequisitiFindSelect]
(
	@IdDomandaPagamentoequalthis INT, 
	@IdRequisitoequalthis INT, 
	@IdValoreequalthis INT, 
	@ValNumericoequalthis DECIMAL(18,2), 
	@ValDataequalthis DATETIME, 
	@ValTestoequalthis VARCHAR(500), 
	@Esitoequalthis CHAR(2), 
	@DataEsitoequalthis DATETIME, 
	@Selezionatoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_DOMANDA_PAGAMENTO, ID_REQUISITO, ID_VALORE, VAL_NUMERICO, VAL_DATA, VAL_TESTO, ESITO, DATA_ESITO, DESCRIZIONE, PLURIVALORE, NUMERICO, DATETIME, TESTO_SEMPLICE, TESTO_AREA, URL, QUERY_EVAL, QUERY_INSERT, MISURA, CODICE_VALORE, DESCRIZIONE_VALORE, SELEZIONATO FROM vDOMANDA_REQUISITI_PAGAMENTO WHERE 1=1';
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdRequisitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_REQUISITO = @IdRequisitoequalthis)'; set @lensql=@lensql+len(@IdRequisitoequalthis);end;
	IF (@IdValoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VALORE = @IdValoreequalthis)'; set @lensql=@lensql+len(@IdValoreequalthis);end;
	IF (@ValNumericoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VAL_NUMERICO = @ValNumericoequalthis)'; set @lensql=@lensql+len(@ValNumericoequalthis);end;
	IF (@ValDataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VAL_DATA = @ValDataequalthis)'; set @lensql=@lensql+len(@ValDataequalthis);end;
	IF (@ValTestoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VAL_TESTO = @ValTestoequalthis)'; set @lensql=@lensql+len(@ValTestoequalthis);end;
	IF (@Esitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ESITO = @Esitoequalthis)'; set @lensql=@lensql+len(@Esitoequalthis);end;
	IF (@DataEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_ESITO = @DataEsitoequalthis)'; set @lensql=@lensql+len(@DataEsitoequalthis);end;
	IF (@Selezionatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SELEZIONATO = @Selezionatoequalthis)'; set @lensql=@lensql+len(@Selezionatoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdDomandaPagamentoequalthis INT, @IdRequisitoequalthis INT, @IdValoreequalthis INT, @ValNumericoequalthis DECIMAL(18,2), @ValDataequalthis DATETIME, @ValTestoequalthis VARCHAR(500), @Esitoequalthis CHAR(2), @DataEsitoequalthis DATETIME, @Selezionatoequalthis BIT',@IdDomandaPagamentoequalthis , @IdRequisitoequalthis , @IdValoreequalthis , @ValNumericoequalthis , @ValDataequalthis , @ValTestoequalthis , @Esitoequalthis , @DataEsitoequalthis , @Selezionatoequalthis ;
	else
		SELECT ID_DOMANDA_PAGAMENTO, ID_REQUISITO, ID_VALORE, VAL_NUMERICO, VAL_DATA, VAL_TESTO, ESITO, DATA_ESITO, DESCRIZIONE, PLURIVALORE, NUMERICO, DATETIME, TESTO_SEMPLICE, TESTO_AREA, URL, QUERY_EVAL, QUERY_INSERT, MISURA, CODICE_VALORE, DESCRIZIONE_VALORE, SELEZIONATO
		FROM vDOMANDA_REQUISITI_PAGAMENTO
		WHERE 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdRequisitoequalthis IS NULL) OR ID_REQUISITO = @IdRequisitoequalthis) AND 
			((@IdValoreequalthis IS NULL) OR ID_VALORE = @IdValoreequalthis) AND 
			((@ValNumericoequalthis IS NULL) OR VAL_NUMERICO = @ValNumericoequalthis) AND 
			((@ValDataequalthis IS NULL) OR VAL_DATA = @ValDataequalthis) AND 
			((@ValTestoequalthis IS NULL) OR VAL_TESTO = @ValTestoequalthis) AND 
			((@Esitoequalthis IS NULL) OR ESITO = @Esitoequalthis) AND 
			((@DataEsitoequalthis IS NULL) OR DATA_ESITO = @DataEsitoequalthis) AND 
			((@Selezionatoequalthis IS NULL) OR SELEZIONATO = @Selezionatoequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZDomandaPagamentoRequisitiFindSelect]
(
	@IdDomandaPagamentoequalthis INT, 
	@IdRequisitoequalthis INT, 
	@IdValoreequalthis INT, 
	@ValNumericoequalthis DECIMAL(18,2), 
	@ValDataequalthis DATETIME, 
	@ValTestoequalthis VARCHAR(500), 
	@Esitoequalthis CHAR(2), 
	@DataEsitoequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_DOMANDA_PAGAMENTO, ID_REQUISITO, ID_VALORE, VAL_NUMERICO, VAL_DATA, VAL_TESTO, ESITO, DATA_ESITO, DESCRIZIONE, PLURIVALORE, NUMERICO, DATETIME, TESTO_SEMPLICE, TESTO_AREA, URL, QUERY_EVAL, QUERY_INSERT, MISURA, CODICE_VALORE, DESCRIZIONE_VALORE FROM vDOMANDA_REQUISITI_PAGAMENTO WHERE 1=1'';
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)''; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdRequisitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_REQUISITO = @IdRequisitoequalthis)''; set @lensql=@lensql+len(@IdRequisitoequalthis);end;
	IF (@IdValoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_VALORE = @IdValoreequalthis)''; set @lensql=@lensql+len(@IdValoreequalthis);end;
	IF (@ValNumericoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (VAL_NUMERICO = @ValNumericoequalthis)''; set @lensql=@lensql+len(@ValNumericoequalthis);end;
	IF (@ValDataequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (VAL_DATA = @ValDataequalthis)''; set @lensql=@lensql+len(@ValDataequalthis);end;
	IF (@ValTestoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (VAL_TESTO = @ValTestoequalthis)''; set @lensql=@lensql+len(@ValTestoequalthis);end;
	IF (@Esitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ESITO = @Esitoequalthis)''; set @lensql=@lensql+len(@Esitoequalthis);end;
	IF (@DataEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_ESITO = @DataEsitoequalthis)''; set @lensql=@lensql+len(@DataEsitoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdDomandaPagamentoequalthis INT, @IdRequisitoequalthis INT, @IdValoreequalthis INT, @ValNumericoequalthis DECIMAL(18,2), @ValDataequalthis DATETIME, @ValTestoequalthis VARCHAR(500), @Esitoequalthis CHAR(2), @DataEsitoequalthis DATETIME'',@IdDomandaPagamentoequalthis , @IdRequisitoequalthis , @IdValoreequalthis , @ValNumericoequalthis , @ValDataequalthis , @ValTestoequalthis , @Esitoequalthis , @DataEsitoequalthis ;
	else
		SELECT ID_DOMANDA_PAGAMENTO, ID_REQUISITO, ID_VALORE, VAL_NUMERICO, VAL_DATA, VAL_TESTO, ESITO, DATA_ESITO, DESCRIZIONE, PLURIVALORE, NUMERICO, DATETIME, TESTO_SEMPLICE, TESTO_AREA, URL, QUERY_EVAL, QUERY_INSERT, MISURA, CODICE_VALORE, DESCRIZIONE_VALORE
		FROM vDOMANDA_REQUISITI_PAGAMENTO
		WHERE 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdRequisitoequalthis IS NULL) OR ID_REQUISITO = @IdRequisitoequalthis) AND 
			((@IdValoreequalthis IS NULL) OR ID_VALORE = @IdValoreequalthis) AND 
			((@ValNumericoequalthis IS NULL) OR VAL_NUMERICO = @ValNumericoequalthis) AND 
			((@ValDataequalthis IS NULL) OR VAL_DATA = @ValDataequalthis) AND 
			((@ValTestoequalthis IS NULL) OR VAL_TESTO = @ValTestoequalthis) AND 
			((@Esitoequalthis IS NULL) OR ESITO = @Esitoequalthis) AND 
			((@DataEsitoequalthis IS NULL) OR DATA_ESITO = @DataEsitoequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDomandaPagamentoRequisitiFindSelect';

