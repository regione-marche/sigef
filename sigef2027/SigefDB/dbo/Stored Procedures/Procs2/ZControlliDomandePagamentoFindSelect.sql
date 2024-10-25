CREATE PROCEDURE [dbo].[ZControlliDomandePagamentoFindSelect]
(
	@IdLottoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@OperatoreAssegnatoequalthis VARCHAR(16), 
	@SelezionataXControlloequalthis BIT, 
	@TipoEstrazioneequalthis CHAR(1), 
	@ValoreDiRischioequalthis DECIMAL(10,4), 
	@ClasseDiRischioequalthis CHAR(1), 
	@OrdineClasseDiRischioequalthis INT, 
	@ContributoRichiestoequalthis DECIMAL(18,2), 
	@DataModificaequalthis DATETIME, 
	@Operatoreequalthis VARCHAR(16), 
	@ControlloConclusoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_LOTTO, ID_DOMANDA_PAGAMENTO, OPERATORE_ASSEGNATO, SELEZIONATA_X_CONTROLLO, TIPO_ESTRAZIONE, CONTROLLO_CONCLUSO, VALORE_DI_RISCHIO, CONTRIBUTO_RICHIESTO, COD_TIPO, ID_PROGETTO, DESCRIZIONE, DATA_MODIFICA, OPERATORE, DATA_PRESENTAZIONE_DOMANDA_PAGAMENTO, CLASSE_DI_RISCHIO, ORDINE_CLASSE_DI_RISCHIO FROM vCONTROLLI_DOMANDE_PAGAMENTO WHERE 1=1';
	IF (@IdLottoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_LOTTO = @IdLottoequalthis)'; set @lensql=@lensql+len(@IdLottoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@OperatoreAssegnatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_ASSEGNATO = @OperatoreAssegnatoequalthis)'; set @lensql=@lensql+len(@OperatoreAssegnatoequalthis);end;
	IF (@SelezionataXControlloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SELEZIONATA_X_CONTROLLO = @SelezionataXControlloequalthis)'; set @lensql=@lensql+len(@SelezionataXControlloequalthis);end;
	IF (@TipoEstrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIPO_ESTRAZIONE = @TipoEstrazioneequalthis)'; set @lensql=@lensql+len(@TipoEstrazioneequalthis);end;
	IF (@ValoreDiRischioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VALORE_DI_RISCHIO = @ValoreDiRischioequalthis)'; set @lensql=@lensql+len(@ValoreDiRischioequalthis);end;
	IF (@ClasseDiRischioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CLASSE_DI_RISCHIO = @ClasseDiRischioequalthis)'; set @lensql=@lensql+len(@ClasseDiRischioequalthis);end;
	IF (@OrdineClasseDiRischioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE_CLASSE_DI_RISCHIO = @OrdineClasseDiRischioequalthis)'; set @lensql=@lensql+len(@OrdineClasseDiRischioequalthis);end;
	IF (@ContributoRichiestoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTRIBUTO_RICHIESTO = @ContributoRichiestoequalthis)'; set @lensql=@lensql+len(@ContributoRichiestoequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@ControlloConclusoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTROLLO_CONCLUSO = @ControlloConclusoequalthis)'; set @lensql=@lensql+len(@ControlloConclusoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdLottoequalthis INT, @IdDomandaPagamentoequalthis INT, @OperatoreAssegnatoequalthis VARCHAR(16), @SelezionataXControlloequalthis BIT, @TipoEstrazioneequalthis CHAR(1), @ValoreDiRischioequalthis DECIMAL(10,4), @ClasseDiRischioequalthis CHAR(1), @OrdineClasseDiRischioequalthis INT, @ContributoRichiestoequalthis DECIMAL(18,2), @DataModificaequalthis DATETIME, @Operatoreequalthis VARCHAR(16), @ControlloConclusoequalthis BIT',@IdLottoequalthis , @IdDomandaPagamentoequalthis , @OperatoreAssegnatoequalthis , @SelezionataXControlloequalthis , @TipoEstrazioneequalthis , @ValoreDiRischioequalthis , @ClasseDiRischioequalthis , @OrdineClasseDiRischioequalthis , @ContributoRichiestoequalthis , @DataModificaequalthis , @Operatoreequalthis , @ControlloConclusoequalthis ;
	else
		SELECT ID_LOTTO, ID_DOMANDA_PAGAMENTO, OPERATORE_ASSEGNATO, SELEZIONATA_X_CONTROLLO, TIPO_ESTRAZIONE, CONTROLLO_CONCLUSO, VALORE_DI_RISCHIO, CONTRIBUTO_RICHIESTO, COD_TIPO, ID_PROGETTO, DESCRIZIONE, DATA_MODIFICA, OPERATORE, DATA_PRESENTAZIONE_DOMANDA_PAGAMENTO, CLASSE_DI_RISCHIO, ORDINE_CLASSE_DI_RISCHIO
		FROM vCONTROLLI_DOMANDE_PAGAMENTO
		WHERE 
			((@IdLottoequalthis IS NULL) OR ID_LOTTO = @IdLottoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@OperatoreAssegnatoequalthis IS NULL) OR OPERATORE_ASSEGNATO = @OperatoreAssegnatoequalthis) AND 
			((@SelezionataXControlloequalthis IS NULL) OR SELEZIONATA_X_CONTROLLO = @SelezionataXControlloequalthis) AND 
			((@TipoEstrazioneequalthis IS NULL) OR TIPO_ESTRAZIONE = @TipoEstrazioneequalthis) AND 
			((@ValoreDiRischioequalthis IS NULL) OR VALORE_DI_RISCHIO = @ValoreDiRischioequalthis) AND 
			((@ClasseDiRischioequalthis IS NULL) OR CLASSE_DI_RISCHIO = @ClasseDiRischioequalthis) AND 
			((@OrdineClasseDiRischioequalthis IS NULL) OR ORDINE_CLASSE_DI_RISCHIO = @OrdineClasseDiRischioequalthis) AND 
			((@ContributoRichiestoequalthis IS NULL) OR CONTRIBUTO_RICHIESTO = @ContributoRichiestoequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@ControlloConclusoequalthis IS NULL) OR CONTROLLO_CONCLUSO = @ControlloConclusoequalthis)
