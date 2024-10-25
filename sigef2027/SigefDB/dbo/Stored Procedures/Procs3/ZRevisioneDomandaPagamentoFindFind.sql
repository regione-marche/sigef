CREATE PROCEDURE [dbo].[ZRevisioneDomandaPagamentoFindFind]
(
	@IdLottoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@SelezionataXRevisioneequalthis BIT, 
	@Approvataequalthis BIT, 
	@IdBandoequalthis INT, 
	@ProvinciaDiPresentazioneequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_DOMANDA_PAGAMENTO, TIPO_DOMANDA_PAGAMENTO, COD_FASE, DATA_PRESENTAZIONE_DOMANDA_PAGAMENTO, DOMANDA_APPROVATA, ID_PROGETTO, ID_LOTTO, DATA_INSERIMENTO, DATA_MODIFICA, CF_OPERATORE, SELEZIONATA_X_REVISIONE, APPROVATA, NUMERO_ESTRAZIONE, ORDINE, SEGNATURA_REVISIONE, SEGNATURA_SECONDA_REVISIONE, DATA_VALIDAZIONE, COD_TIPO, DATA_APPROVAZIONE, ID_BANDO, PROVINCIA_DI_PRESENTAZIONE FROM vREVISIONE_DOMANDA_PAGAMENTO WHERE 1=1';
	IF (@IdLottoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_LOTTO = @IdLottoequalthis)'; set @lensql=@lensql+len(@IdLottoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@SelezionataXRevisioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SELEZIONATA_X_REVISIONE = @SelezionataXRevisioneequalthis)'; set @lensql=@lensql+len(@SelezionataXRevisioneequalthis);end;
	IF (@Approvataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (APPROVATA = @Approvataequalthis)'; set @lensql=@lensql+len(@Approvataequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@ProvinciaDiPresentazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROVINCIA_DI_PRESENTAZIONE = @ProvinciaDiPresentazioneequalthis)'; set @lensql=@lensql+len(@ProvinciaDiPresentazioneequalthis);end;
	set @sql = @sql + 'ORDER BY SELEZIONATA_X_REVISIONE DESC, NUMERO_ESTRAZIONE, ID_DOMANDA_PAGAMENTO';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdLottoequalthis INT, @IdDomandaPagamentoequalthis INT, @SelezionataXRevisioneequalthis BIT, @Approvataequalthis BIT, @IdBandoequalthis INT, @ProvinciaDiPresentazioneequalthis VARCHAR(255)',@IdLottoequalthis , @IdDomandaPagamentoequalthis , @SelezionataXRevisioneequalthis , @Approvataequalthis , @IdBandoequalthis , @ProvinciaDiPresentazioneequalthis ;
	else
		SELECT ID_DOMANDA_PAGAMENTO, TIPO_DOMANDA_PAGAMENTO, COD_FASE, DATA_PRESENTAZIONE_DOMANDA_PAGAMENTO, DOMANDA_APPROVATA, ID_PROGETTO, ID_LOTTO, DATA_INSERIMENTO, DATA_MODIFICA, CF_OPERATORE, SELEZIONATA_X_REVISIONE, APPROVATA, NUMERO_ESTRAZIONE, ORDINE, SEGNATURA_REVISIONE, SEGNATURA_SECONDA_REVISIONE, DATA_VALIDAZIONE, COD_TIPO, DATA_APPROVAZIONE, ID_BANDO, PROVINCIA_DI_PRESENTAZIONE
		FROM vREVISIONE_DOMANDA_PAGAMENTO
		WHERE 
			((@IdLottoequalthis IS NULL) OR ID_LOTTO = @IdLottoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@SelezionataXRevisioneequalthis IS NULL) OR SELEZIONATA_X_REVISIONE = @SelezionataXRevisioneequalthis) AND 
			((@Approvataequalthis IS NULL) OR APPROVATA = @Approvataequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@ProvinciaDiPresentazioneequalthis IS NULL) OR PROVINCIA_DI_PRESENTAZIONE = @ProvinciaDiPresentazioneequalthis)
		ORDER BY SELEZIONATA_X_REVISIONE DESC, NUMERO_ESTRAZIONE, ID_DOMANDA_PAGAMENTO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZRevisioneDomandaPagamentoFindFind]
(
	@IdLottoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@SelezionataXRevisioneequalthis BIT, 
	@Approvataequalthis BIT, 
	@IdBandoequalthis INT, 
	@ProvinciaDiPresentazioneequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_DOMANDA_PAGAMENTO, TIPO_DOMANDA_PAGAMENTO, COD_FASE, DATA_PRESENTAZIONE_DOMANDA_PAGAMENTO, DOMANDA_APPROVATA, ID_PROGETTO, ID_LOTTO, DATA_INSERIMENTO, DATA_MODIFICA, CF_OPERATORE, SELEZIONATA_X_REVISIONE, APPROVATA, NUMERO_ESTRAZIONE, ORDINE, SEGNATURA_REVISIONE, SEGNATURA_SECONDA_REVISIONE, COD_TIPO, DATA_APPROVAZIONE, ID_BANDO, PROVINCIA_DI_PRESENTAZIONE FROM vREVISIONE_DOMANDA_PAGAMENTO WHERE 1=1'';
	IF (@IdLottoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_LOTTO = @IdLottoequalthis)''; set @lensql=@lensql+len(@IdLottoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)''; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@SelezionataXRevisioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SELEZIONATA_X_REVISIONE = @SelezionataXRevisioneequalthis)''; set @lensql=@lensql+len(@SelezionataXRevisioneequalthis);end;
	IF (@Approvataequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (APPROVATA = @Approvataequalthis)''; set @lensql=@lensql+len(@Approvataequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@ProvinciaDiPresentazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PROVINCIA_DI_PRESENTAZIONE = @ProvinciaDiPresentazioneequalthis)''; set @lensql=@lensql+len(@ProvinciaDiPresentazioneequalthis);end;
	set @sql = @sql + ''ORDER BY SELEZIONATA_X_REVISIONE DESC, NUMERO_ESTRAZIONE, ID_DOMANDA_PAGAMENTO'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdLottoequalthis INT, @IdDomandaPagamentoequalthis INT, @SelezionataXRevisioneequalthis BIT, @Approvataequalthis BIT, @IdBandoequalthis INT, @ProvinciaDiPresentazioneequalthis VARCHAR(255)'',@IdLottoequalthis , @IdDomandaPagamentoequalthis , @SelezionataXRevisioneequalthis , @Approvataequalthis , @IdBandoequalthis , @ProvinciaDiPresentazioneequalthis ;
	else
		SELECT ID_DOMANDA_PAGAMENTO, TIPO_DOMANDA_PAGAMENTO, COD_FASE, DATA_PRESENTAZIONE_DOMANDA_PAGAMENTO, DOMANDA_APPROVATA, ID_PROGETTO, ID_LOTTO, DATA_INSERIMENTO, DATA_MODIFICA, CF_OPERATORE, SELEZIONATA_X_REVISIONE, APPROVATA, NUMERO_ESTRAZIONE, ORDINE, SEGNATURA_REVISIONE, SEGNATURA_SECONDA_REVISIONE, COD_TIPO, DATA_APPROVAZIONE, ID_BANDO, PROVINCIA_DI_PRESENTAZIONE
		FROM vREVISIONE_DOMANDA_PAGAMENTO
		WHERE 
			((@IdLottoequalthis IS NULL) OR ID_LOTTO = @IdLottoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@SelezionataXRevisioneequalthis IS NULL) OR SELEZIONATA_X_REVISIONE = @SelezionataXRevisioneequalthis) AND 
			((@Approvataequalthis IS NULL) OR APPROVATA = @Approvataequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@ProvinciaDiPresentazioneequalthis IS NULL) OR PROVINCIA_DI_PRESENTAZIONE = @ProvinciaDiPresentazioneequalthis)
		ORDER BY SELEZIONATA_X_REVISIONE DESC, NUMERO_ESTRAZIONE, ID_DOMANDA_PAGAMENTO
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRevisioneDomandaPagamentoFindFind';

