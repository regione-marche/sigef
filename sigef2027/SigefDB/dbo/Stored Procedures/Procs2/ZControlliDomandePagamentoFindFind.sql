CREATE PROCEDURE [dbo].[ZControlliDomandePagamentoFindFind]
(
	@IdLottoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdProgettoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_LOTTO, ID_DOMANDA_PAGAMENTO, OPERATORE_ASSEGNATO, SELEZIONATA_X_CONTROLLO, TIPO_ESTRAZIONE, CONTROLLO_CONCLUSO, VALORE_DI_RISCHIO, CONTRIBUTO_RICHIESTO, COD_TIPO, ID_PROGETTO, DESCRIZIONE, DATA_MODIFICA, OPERATORE, DATA_PRESENTAZIONE_DOMANDA_PAGAMENTO, CLASSE_DI_RISCHIO, ORDINE_CLASSE_DI_RISCHIO FROM vCONTROLLI_DOMANDE_PAGAMENTO WHERE 1=1';
	IF (@IdLottoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_LOTTO = @IdLottoequalthis)'; set @lensql=@lensql+len(@IdLottoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	set @sql = @sql + 'ORDER BY SELEZIONATA_X_CONTROLLO DESC, TIPO_ESTRAZIONE, COD_TIPO DESC, VALORE_DI_RISCHIO DESC, CONTRIBUTO_RICHIESTO DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdLottoequalthis INT, @IdDomandaPagamentoequalthis INT, @IdProgettoequalthis INT',@IdLottoequalthis , @IdDomandaPagamentoequalthis , @IdProgettoequalthis ;
	else
		SELECT ID_LOTTO, ID_DOMANDA_PAGAMENTO, OPERATORE_ASSEGNATO, SELEZIONATA_X_CONTROLLO, TIPO_ESTRAZIONE, CONTROLLO_CONCLUSO, VALORE_DI_RISCHIO, CONTRIBUTO_RICHIESTO, COD_TIPO, ID_PROGETTO, DESCRIZIONE, DATA_MODIFICA, OPERATORE, DATA_PRESENTAZIONE_DOMANDA_PAGAMENTO, CLASSE_DI_RISCHIO, ORDINE_CLASSE_DI_RISCHIO
		FROM vCONTROLLI_DOMANDE_PAGAMENTO
		WHERE 
			((@IdLottoequalthis IS NULL) OR ID_LOTTO = @IdLottoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis)
		ORDER BY SELEZIONATA_X_CONTROLLO DESC, TIPO_ESTRAZIONE, COD_TIPO DESC, VALORE_DI_RISCHIO DESC, CONTRIBUTO_RICHIESTO DESC

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZControlliDomandePagamentoFindFind]
(
	@IdLottoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdProgettoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_LOTTO, ID_DOMANDA_PAGAMENTO, OPERATORE_ASSEGNATO, SELEZIONATA_X_CONTROLLO, TIPO_ESTRAZIONE, CONTROLLO_CONCLUSO, VALORE_DI_RISCHIO, CONTRIBUTO_RICHIESTO, COD_TIPO, ID_PROGETTO, DESCRIZIONE, DATA_MODIFICA, OPERATORE, DATA_PRESENTAZIONE_DOMANDA_PAGAMENTO FROM vCONTROLLI_DOMANDE_PAGAMENTO WHERE 1=1'';
	IF (@IdLottoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_LOTTO = @IdLottoequalthis)''; set @lensql=@lensql+len(@IdLottoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)''; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	set @sql = @sql + ''ORDER BY 
SELEZIONATA_X_CONTROLLO DESC, TIPO_ESTRAZIONE, COD_TIPO DESC, VALORE_DI_RISCHIO DESC, CONTRIBUTO_RICHIESTO DESC'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdLottoequalthis INT, @IdDomandaPagamentoequalthis INT, @IdProgettoequalthis INT'',@IdLottoequalthis , @IdDomandaPagamentoequalthis , @IdProgettoequalthis ;
	else
		SELECT ID_LOTTO, ID_DOMANDA_PAGAMENTO, OPERATORE_ASSEGNATO, SELEZIONATA_X_CONTROLLO, TIPO_ESTRAZIONE, CONTROLLO_CONCLUSO, VALORE_DI_RISCHIO, CONTRIBUTO_RICHIESTO, COD_TIPO, ID_PROGETTO, DESCRIZIONE, DATA_MODIFICA, OPERATORE, DATA_PRESENTAZIONE_DOMANDA_PAGAMENTO
		FROM vCONTROLLI_DOMANDE_PAGAMENTO
		WHERE 
			((@IdLottoequalthis IS NULL) OR ID_LOTTO = @IdLottoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis)
		ORDER BY 
SELEZIONATA_X_CONTROLLO DESC, TIPO_ESTRAZIONE, COD_TIPO DESC, VALORE_DI_RISCHIO DESC, CONTRIBUTO_RICHIESTO DESC

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZControlliDomandePagamentoFindFind';

