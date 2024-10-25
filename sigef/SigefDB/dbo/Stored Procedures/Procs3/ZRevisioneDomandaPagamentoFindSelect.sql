CREATE PROCEDURE [dbo].[ZRevisioneDomandaPagamentoFindSelect]
(
	@IdLottoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@DataInserimentoequalthis DATETIME, 
	@DataModificaequalthis DATETIME, 
	@CfOperatoreequalthis VARCHAR(255), 
	@SelezionataXRevisioneequalthis BIT, 
	@Approvataequalthis BIT, 
	@NumeroEstrazioneequalthis INT, 
	@Ordineequalthis INT, 
	@SegnaturaRevisioneequalthis VARCHAR(255), 
	@SegnaturaSecondaRevisioneequalthis VARCHAR(255), 
	@DataValidazioneequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_DOMANDA_PAGAMENTO, TIPO_DOMANDA_PAGAMENTO, COD_FASE, DATA_PRESENTAZIONE_DOMANDA_PAGAMENTO, DOMANDA_APPROVATA, ID_PROGETTO, ID_LOTTO, DATA_INSERIMENTO, DATA_MODIFICA, CF_OPERATORE, SELEZIONATA_X_REVISIONE, APPROVATA, NUMERO_ESTRAZIONE, ORDINE, SEGNATURA_REVISIONE, SEGNATURA_SECONDA_REVISIONE, DATA_VALIDAZIONE, COD_TIPO, DATA_APPROVAZIONE, ID_BANDO, PROVINCIA_DI_PRESENTAZIONE FROM vREVISIONE_DOMANDA_PAGAMENTO WHERE 1=1';
	IF (@IdLottoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_LOTTO = @IdLottoequalthis)'; set @lensql=@lensql+len(@IdLottoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@CfOperatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_OPERATORE = @CfOperatoreequalthis)'; set @lensql=@lensql+len(@CfOperatoreequalthis);end;
	IF (@SelezionataXRevisioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SELEZIONATA_X_REVISIONE = @SelezionataXRevisioneequalthis)'; set @lensql=@lensql+len(@SelezionataXRevisioneequalthis);end;
	IF (@Approvataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (APPROVATA = @Approvataequalthis)'; set @lensql=@lensql+len(@Approvataequalthis);end;
	IF (@NumeroEstrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO_ESTRAZIONE = @NumeroEstrazioneequalthis)'; set @lensql=@lensql+len(@NumeroEstrazioneequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE = @Ordineequalthis)'; set @lensql=@lensql+len(@Ordineequalthis);end;
	IF (@SegnaturaRevisioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_REVISIONE = @SegnaturaRevisioneequalthis)'; set @lensql=@lensql+len(@SegnaturaRevisioneequalthis);end;
	IF (@SegnaturaSecondaRevisioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_SECONDA_REVISIONE = @SegnaturaSecondaRevisioneequalthis)'; set @lensql=@lensql+len(@SegnaturaSecondaRevisioneequalthis);end;
	IF (@DataValidazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_VALIDAZIONE = @DataValidazioneequalthis)'; set @lensql=@lensql+len(@DataValidazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdLottoequalthis INT, @IdDomandaPagamentoequalthis INT, @DataInserimentoequalthis DATETIME, @DataModificaequalthis DATETIME, @CfOperatoreequalthis VARCHAR(255), @SelezionataXRevisioneequalthis BIT, @Approvataequalthis BIT, @NumeroEstrazioneequalthis INT, @Ordineequalthis INT, @SegnaturaRevisioneequalthis VARCHAR(255), @SegnaturaSecondaRevisioneequalthis VARCHAR(255), @DataValidazioneequalthis DATETIME',@IdLottoequalthis , @IdDomandaPagamentoequalthis , @DataInserimentoequalthis , @DataModificaequalthis , @CfOperatoreequalthis , @SelezionataXRevisioneequalthis , @Approvataequalthis , @NumeroEstrazioneequalthis , @Ordineequalthis , @SegnaturaRevisioneequalthis , @SegnaturaSecondaRevisioneequalthis , @DataValidazioneequalthis ;
	else
		SELECT ID_DOMANDA_PAGAMENTO, TIPO_DOMANDA_PAGAMENTO, COD_FASE, DATA_PRESENTAZIONE_DOMANDA_PAGAMENTO, DOMANDA_APPROVATA, ID_PROGETTO, ID_LOTTO, DATA_INSERIMENTO, DATA_MODIFICA, CF_OPERATORE, SELEZIONATA_X_REVISIONE, APPROVATA, NUMERO_ESTRAZIONE, ORDINE, SEGNATURA_REVISIONE, SEGNATURA_SECONDA_REVISIONE, DATA_VALIDAZIONE, COD_TIPO, DATA_APPROVAZIONE, ID_BANDO, PROVINCIA_DI_PRESENTAZIONE
		FROM vREVISIONE_DOMANDA_PAGAMENTO
		WHERE 
			((@IdLottoequalthis IS NULL) OR ID_LOTTO = @IdLottoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@CfOperatoreequalthis IS NULL) OR CF_OPERATORE = @CfOperatoreequalthis) AND 
			((@SelezionataXRevisioneequalthis IS NULL) OR SELEZIONATA_X_REVISIONE = @SelezionataXRevisioneequalthis) AND 
			((@Approvataequalthis IS NULL) OR APPROVATA = @Approvataequalthis) AND 
			((@NumeroEstrazioneequalthis IS NULL) OR NUMERO_ESTRAZIONE = @NumeroEstrazioneequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis) AND 
			((@SegnaturaRevisioneequalthis IS NULL) OR SEGNATURA_REVISIONE = @SegnaturaRevisioneequalthis) AND 
			((@SegnaturaSecondaRevisioneequalthis IS NULL) OR SEGNATURA_SECONDA_REVISIONE = @SegnaturaSecondaRevisioneequalthis) AND 
			((@DataValidazioneequalthis IS NULL) OR DATA_VALIDAZIONE = @DataValidazioneequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZRevisioneDomandaPagamentoFindSelect]
(
	@IdLottoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@DataInserimentoequalthis DATETIME, 
	@DataModificaequalthis DATETIME, 
	@CfOperatoreequalthis VARCHAR(255), 
	@SelezionataXRevisioneequalthis BIT, 
	@Approvataequalthis BIT, 
	@NumeroEstrazioneequalthis INT, 
	@Ordineequalthis INT, 
	@SegnaturaRevisioneequalthis VARCHAR(255), 
	@SegnaturaSecondaRevisioneequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_DOMANDA_PAGAMENTO, TIPO_DOMANDA_PAGAMENTO, COD_FASE, DATA_PRESENTAZIONE_DOMANDA_PAGAMENTO, DOMANDA_APPROVATA, ID_PROGETTO, ID_LOTTO, DATA_INSERIMENTO, DATA_MODIFICA, CF_OPERATORE, SELEZIONATA_X_REVISIONE, APPROVATA, NUMERO_ESTRAZIONE, ORDINE, SEGNATURA_REVISIONE, SEGNATURA_SECONDA_REVISIONE, COD_TIPO, DATA_APPROVAZIONE, ID_BANDO, PROVINCIA_DI_PRESENTAZIONE FROM vREVISIONE_DOMANDA_PAGAMENTO WHERE 1=1'';
	IF (@IdLottoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_LOTTO = @IdLottoequalthis)''; set @lensql=@lensql+len(@IdLottoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)''; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)''; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_MODIFICA = @DataModificaequalthis)''; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@CfOperatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CF_OPERATORE = @CfOperatoreequalthis)''; set @lensql=@lensql+len(@CfOperatoreequalthis);end;
	IF (@SelezionataXRevisioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SELEZIONATA_X_REVISIONE = @SelezionataXRevisioneequalthis)''; set @lensql=@lensql+len(@SelezionataXRevisioneequalthis);end;
	IF (@Approvataequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (APPROVATA = @Approvataequalthis)''; set @lensql=@lensql+len(@Approvataequalthis);end;
	IF (@NumeroEstrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (NUMERO_ESTRAZIONE = @NumeroEstrazioneequalthis)''; set @lensql=@lensql+len(@NumeroEstrazioneequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ORDINE = @Ordineequalthis)''; set @lensql=@lensql+len(@Ordineequalthis);end;
	IF (@SegnaturaRevisioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SEGNATURA_REVISIONE = @SegnaturaRevisioneequalthis)''; set @lensql=@lensql+len(@SegnaturaRevisioneequalthis);end;
	IF (@SegnaturaSecondaRevisioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SEGNATURA_SECONDA_REVISIONE = @SegnaturaSecondaRevisioneequalthis)''; set @lensql=@lensql+len(@SegnaturaSecondaRevisioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdLottoequalthis INT, @IdDomandaPagamentoequalthis INT, @DataInserimentoequalthis DATETIME, @DataModificaequalthis DATETIME, @CfOperatoreequalthis VARCHAR(255), @SelezionataXRevisioneequalthis BIT, @Approvataequalthis BIT, @NumeroEstrazioneequalthis INT, @Ordineequalthis INT, @SegnaturaRevisioneequalthis VARCHAR(255), @SegnaturaSecondaRevisioneequalthis VARCHAR(255)'',@IdLottoequalthis , @IdDomandaPagamentoequalthis , @DataInserimentoequalthis , @DataModificaequalthis , @CfOperatoreequalthis , @SelezionataXRevisioneequalthis , @Approvataequalthis , @NumeroEstrazioneequalthis , @Ordineequalthis , @SegnaturaRevisioneequalthis , @SegnaturaSecondaRevisioneequalthis ;
	else
		SELECT ID_DOMANDA_PAGAMENTO, TIPO_DOMANDA_PAGAMENTO, COD_FASE, DATA_PRESENTAZIONE_DOMANDA_PAGAMENTO, DOMANDA_APPROVATA, ID_PROGETTO, ID_LOTTO, DATA_INSERIMENTO, DATA_MODIFICA, CF_OPERATORE, SELEZIONATA_X_REVISIONE, APPROVATA, NUMERO_ESTRAZIONE, ORDINE, SEGNATURA_REVISIONE, SEGNATURA_SECONDA_REVISIONE, COD_TIP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRevisioneDomandaPagamentoFindSelect';

