CREATE PROCEDURE [dbo].[ZDomandaDiPagamentoEsportazioneFindSelect]
(
	@IdDomandaPagamentoequalthis INT, 
	@IdProgettoequalthis INT, 
	@Barcodeequalthis VARCHAR(255), 
	@MisuraPrevalenteequalthis BIT, 
	@ImportoAmmissibileequalthis DECIMAL(18,2), 
	@ImportoSanzioneequalthis DECIMAL(18,2), 
	@ImportoRecuperoAnticipoequalthis DECIMAL(18,2), 
	@ImportoAmmessoequalthis DECIMAL(18,2), 
	@ImportoLiquidatoequalthis DECIMAL(18,2), 
	@FlagLiquidatoequalthis BIT, 
	@IdDecretoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_DOMANDA_PAGAMENTO, ID_PROGETTO, BARCODE, MISURA_PREVALENTE, IMPORTO_AMMISSIBILE, IMPORTO_SANZIONE, IMPORTO_RECUPERO_ANTICIPO, IMPORTO_AMMESSO, IMPORTO_LIQUIDATO, FLAG_LIQUIDATO, ID_DECRETO, COD_TIPO, DATA_INSERIMENTO, CF_OPERATORE, DATA_MODIFICA, COD_ENTE, SEGNATURA, SEGNATURA_ALLEGATI, ID_FIDEJUSSIONE, DATA_CERTIFICAZIONE_ANTIMAFIA, APPROVATA, SEGNATURA_APPROVAZIONE, SEGNATURA_SECONDA_APPROVAZIONE, CF_ISTRUTTORE, DATA_APPROVAZIONE, VALUTAZIONE_ISTRUTTORE, ANNULLATA, SEGNATURA_ANNULLAMENTO, CF_OPERATORE_ANNULLAMENTO, DATA_ANNULLAMENTO, VALIDITA_VERSIONE_ADC, ID_VARIAZIONE_ACCERTATA, PREDISPOSTA_A_CONTROLLO, DATA_PREDISPOSIZIONE_A_CONTROLLO, VISITA_INSITU_ESITO, VISITA_INSITU_NOTE, CONTROLLO_INLOCO_ESITO, CONTROLLO_INLOCO_NOTE, VERIFICA_PAGAMENTI_ESITO, VERIFICA_PAGAMENTI_MESSAGGIO, VERIFICA_PAGAMENTI_DATA, FIRMA_PREDISPOSTA, IN_INTEGRAZIONE FROM VDOMANDA_DI_PAGAMENTO_ESPORTAZIONE WHERE 1=1';
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@Barcodeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (BARCODE = @Barcodeequalthis)'; set @lensql=@lensql+len(@Barcodeequalthis);end;
	IF (@MisuraPrevalenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MISURA_PREVALENTE = @MisuraPrevalenteequalthis)'; set @lensql=@lensql+len(@MisuraPrevalenteequalthis);end;
	IF (@ImportoAmmissibileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_AMMISSIBILE = @ImportoAmmissibileequalthis)'; set @lensql=@lensql+len(@ImportoAmmissibileequalthis);end;
	IF (@ImportoSanzioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_SANZIONE = @ImportoSanzioneequalthis)'; set @lensql=@lensql+len(@ImportoSanzioneequalthis);end;
	IF (@ImportoRecuperoAnticipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_RECUPERO_ANTICIPO = @ImportoRecuperoAnticipoequalthis)'; set @lensql=@lensql+len(@ImportoRecuperoAnticipoequalthis);end;
	IF (@ImportoAmmessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_AMMESSO = @ImportoAmmessoequalthis)'; set @lensql=@lensql+len(@ImportoAmmessoequalthis);end;
	IF (@ImportoLiquidatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_LIQUIDATO = @ImportoLiquidatoequalthis)'; set @lensql=@lensql+len(@ImportoLiquidatoequalthis);end;
	IF (@FlagLiquidatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FLAG_LIQUIDATO = @FlagLiquidatoequalthis)'; set @lensql=@lensql+len(@FlagLiquidatoequalthis);end;
	IF (@IdDecretoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DECRETO = @IdDecretoequalthis)'; set @lensql=@lensql+len(@IdDecretoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdDomandaPagamentoequalthis INT, @IdProgettoequalthis INT, @Barcodeequalthis VARCHAR(255), @MisuraPrevalenteequalthis BIT, @ImportoAmmissibileequalthis DECIMAL(18,2), @ImportoSanzioneequalthis DECIMAL(18,2), @ImportoRecuperoAnticipoequalthis DECIMAL(18,2), @ImportoAmmessoequalthis DECIMAL(18,2), @ImportoLiquidatoequalthis DECIMAL(18,2), @FlagLiquidatoequalthis BIT, @IdDecretoequalthis INT',@IdDomandaPagamentoequalthis , @IdProgettoequalthis , @Barcodeequalthis , @MisuraPrevalenteequalthis , @ImportoAmmissibileequalthis , @ImportoSanzioneequalthis , @ImportoRecuperoAnticipoequalthis , @ImportoAmmessoequalthis , @ImportoLiquidatoequalthis , @FlagLiquidatoequalthis , @IdDecretoequalthis ;
	else
		SELECT ID_DOMANDA_PAGAMENTO, ID_PROGETTO, BARCODE, MISURA_PREVALENTE, IMPORTO_AMMISSIBILE, IMPORTO_SANZIONE, IMPORTO_RECUPERO_ANTICIPO, IMPORTO_AMMESSO, IMPORTO_LIQUIDATO, FLAG_LIQUIDATO, ID_DECRETO, COD_TIPO, DATA_INSERIMENTO, CF_OPERATORE, DATA_MODIFICA, COD_ENTE, SEGNATURA, SEGNATURA_ALLEGATI, ID_FIDEJUSSIONE, DATA_CERTIFICAZIONE_ANTIMAFIA, APPROVATA, SEGNATURA_APPROVAZIONE, SEGNATURA_SECONDA_APPROVAZIONE, CF_ISTRUTTORE, DATA_APPROVAZIONE, VALUTAZIONE_ISTRUTTORE, ANNULLATA, SEGNATURA_ANNULLAMENTO, CF_OPERATORE_ANNULLAMENTO, DATA_ANNULLAMENTO, VALIDITA_VERSIONE_ADC, ID_VARIAZIONE_ACCERTATA, PREDISPOSTA_A_CONTROLLO, DATA_PREDISPOSIZIONE_A_CONTROLLO, VISITA_INSITU_ESITO, VISITA_INSITU_NOTE, CONTROLLO_INLOCO_ESITO, CONTROLLO_INLOCO_NOTE, VERIFICA_PAGAMENTI_ESITO, VERIFICA_PAGAMENTI_MESSAGGIO, VERIFICA_PAGAMENTI_DATA, FIRMA_PREDISPOSTA, IN_INTEGRAZIONE
		FROM VDOMANDA_DI_PAGAMENTO_ESPORTAZIONE
		WHERE 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@Barcodeequalthis IS NULL) OR BARCODE = @Barcodeequalthis) AND 
			((@MisuraPrevalenteequalthis IS NULL) OR MISURA_PREVALENTE = @MisuraPrevalenteequalthis) AND 
			((@ImportoAmmissibileequalthis IS NULL) OR IMPORTO_AMMISSIBILE = @ImportoAmmissibileequalthis) AND 
			((@ImportoSanzioneequalthis IS NULL) OR IMPORTO_SANZIONE = @ImportoSanzioneequalthis) AND 
			((@ImportoRecuperoAnticipoequalthis IS NULL) OR IMPORTO_RECUPERO_ANTICIPO = @ImportoRecuperoAnticipoequalthis) AND 
			((@ImportoAmmessoequalthis IS NULL) OR IMPORTO_AMMESSO = @ImportoAmmessoequalthis) AND 
			((@ImportoLiquidatoequalthis IS NULL) OR IMPORTO_LIQUIDATO = @ImportoLiquidatoequalthis) AND 
			((@FlagLiquidatoequalthis IS NULL) OR FLAG_LIQUIDATO = @FlagLiquidatoequalthis) AND 
			((@IdDecretoequalthis IS NULL) OR ID_DECRETO = @IdDecretoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZDomandaDiPagamentoEsportazioneFindSelect]
(
	@IdDomandaPagamentoequalthis INT, 
	@IdProgettoequalthis INT, 
	@Barcodeequalthis VARCHAR(255), 
	@MisuraPrevalenteequalthis BIT, 
	@ImportoAmmissibileequalthis DECIMAL(18,2), 
	@ImportoSanzioneequalthis DECIMAL(18,2), 
	@ImportoRecuperoAnticipoequalthis DECIMAL(18,2), 
	@ImportoAmmessoequalthis DECIMAL(18,2), 
	@ImportoLiquidatoequalthis DECIMAL(18,2), 
	@FlagLiquidatoequalthis BIT, 
	@IdDecretoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_DOMANDA_PAGAMENTO, ID_PROGETTO, BARCODE, MISURA_PREVALENTE, IMPORTO_AMMISSIBILE, IMPORTO_SANZIONE, IMPORTO_RECUPERO_ANTICIPO, IMPORTO_AMMESSO, IMPORTO_LIQUIDATO, FLAG_LIQUIDATO, ID_DECRETO, COD_TIPO, DATA_INSERIMENTO, CF_OPERATORE, DATA_MODIFICA, COD_ENTE, SEGNATURA, SEGNATURA_ALLEGATI, ID_FIDEJUSSIONE, DATA_CERTIFICAZIONE_ANTIMAFIA, APPROVATA, SEGNATURA_APPROVAZIONE, SEGNATURA_SECONDA_APPROVAZIONE, CF_ISTRUTTORE, DATA_APPROVAZIONE, VALUTAZIONE_ISTRUTTORE, ANNULLATA, SEGNATURA_ANNULLAMENTO, CF_OPERATORE_ANNULLAMENTO, DATA_ANNULLAMENTO, VALIDITA_VERSIONE_ADC, ID_VARIAZIONE_ACCERTATA, PREDISPOSTA_A_CONTROLLO, DATA_PREDISPOSIZIONE_A_CONTROLLO, VISITA_INSITU_ESITO, VISITA_INSITU_NOTE, CONTROLLO_INLOCO_ESITO, CONTROLLO_INLOCO_NOTE, VERIFICA_PAGAMENTI_ESITO, VERIFICA_PAGAMENTI_MESSAGGIO, VERIFICA_PAGAMENTI_DATA, FIRMA_PREDISPOSTA, IN_INTEGRAZIONE FROM VDOMANDA_DI_PAGAMENTO_ESPORTAZIONE WHERE 1=1'';
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)''; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@Barcodeequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (BARCODE = @Barcodeequalthis)''; set @lensql=@lensql+len(@Barcodeequalthis);end;
	IF (@MisuraPrevalenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (MISURA_PREVALENTE = @MisuraPrevalenteequalthis)''; set @lensql=@lensql+len(@MisuraPrevalenteequalthis);end;
	IF (@ImportoAmmissibileequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IMPORTO_AMMISSIBILE = @ImportoAmmissibileequalthis)''; set @lensql=@lensql+len(@ImportoAmmissibileequalthis);end;
	IF (@ImportoSanzioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IMPORTO_SANZIONE = @ImportoSanzioneequalthis)''; set @lensql=@lensql+len(@ImportoSanzioneequalthis);end;
	IF (@ImportoRecuperoAnticipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IMPORTO_RECUPERO_ANTICIPO = @ImportoRecuperoAnticipoequalthis)''; set @lensql=@lensql+len(@ImportoRecuperoAnticipoequalthis);end;
	IF (@ImportoAmmessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IMPORTO_AMMESSO = @ImportoAmmessoequalthis)''; set @lensql=@lensql+len(@ImportoAmmessoequalthis);end;
	IF (@ImportoLiquidatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IMPORTO_LIQUIDATO = @ImportoLiquidatoequalthis)''; set @lensql=@lensql+len(@ImportoLiquidatoequalthis);end;
	IF (@FlagLiquidatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (FLAG_LIQUIDATO = @FlagLiquidatoequalthis)''; set @lensql=@lensql+len(@FlagLiquidatoequalthis);end;
	IF (@IdDecretoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DECRETO = @IdDecretoequalthis)''; set @lensql=@lensql+len(@IdDecretoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdDomandaPagamentoequalthis INT, @IdProgettoequalthis INT, @Barcodeequalthis VARCHAR(255), @MisuraPrevalenteequalthis BIT, @ImportoAmmissibileequalthis DECIMAL(18,2), @ImportoSanzioneequalthis DECIMAL(18,2), @ImportoRecuperoAnticipoequalthis DECIMAL(18,2), @ImportoAmmessoequalthis DECIMAL(18,2), @ImportoLiquidatoequalthis DECIMAL(18,2), @FlagLiquidatoequalthis BIT, @IdDecretoequalthis INT'',@IdDomandaPagamentoequalthis , @IdProgettoequalthis , @Barcodeequa', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDomandaDiPagamentoEsportazioneFindSelect';

