CREATE PROCEDURE [dbo].[ZRevisioneDpagamentoEsitoFindSelect]
(
	@Idequalthis INT, 
	@IdLottoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdVldStepequalthis INT, 
	@CodEsitoequalthis VARCHAR(255), 
	@Dataequalthis DATETIME, 
	@Operatoreequalthis INT, 
	@Noteequalthis VARCHAR(5000), 
	@EscludiDaComunicazioneequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_LOTTO, ID_DOMANDA_PAGAMENTO, ID_VLD_STEP, COD_ESITO, DATA, OPERATORE, NOTE, ESCLUDI_DA_COMUNICAZIONE, DESCRIZIONE, AUTOMATICO, ESITO_POSITIVO, Ordine FROM vREVISIONE_DPAGAMENTO_ESITO WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdLottoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_LOTTO = @IdLottoequalthis)'; set @lensql=@lensql+len(@IdLottoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdVldStepequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VLD_STEP = @IdVldStepequalthis)'; set @lensql=@lensql+len(@IdVldStepequalthis);end;
	IF (@CodEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ESITO = @CodEsitoequalthis)'; set @lensql=@lensql+len(@CodEsitoequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@Noteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOTE = @Noteequalthis)'; set @lensql=@lensql+len(@Noteequalthis);end;
	IF (@EscludiDaComunicazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ESCLUDI_DA_COMUNICAZIONE = @EscludiDaComunicazioneequalthis)'; set @lensql=@lensql+len(@EscludiDaComunicazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @IdLottoequalthis INT, @IdDomandaPagamentoequalthis INT, @IdVldStepequalthis INT, @CodEsitoequalthis VARCHAR(255), @Dataequalthis DATETIME, @Operatoreequalthis INT, @Noteequalthis VARCHAR(5000), @EscludiDaComunicazioneequalthis BIT',@Idequalthis , @IdLottoequalthis , @IdDomandaPagamentoequalthis , @IdVldStepequalthis , @CodEsitoequalthis , @Dataequalthis , @Operatoreequalthis , @Noteequalthis , @EscludiDaComunicazioneequalthis ;
	else
		SELECT ID, ID_LOTTO, ID_DOMANDA_PAGAMENTO, ID_VLD_STEP, COD_ESITO, DATA, OPERATORE, NOTE, ESCLUDI_DA_COMUNICAZIONE, DESCRIZIONE, AUTOMATICO, ESITO_POSITIVO, Ordine
		FROM vREVISIONE_DPAGAMENTO_ESITO
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdLottoequalthis IS NULL) OR ID_LOTTO = @IdLottoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdVldStepequalthis IS NULL) OR ID_VLD_STEP = @IdVldStepequalthis) AND 
			((@CodEsitoequalthis IS NULL) OR COD_ESITO = @CodEsitoequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@Noteequalthis IS NULL) OR NOTE = @Noteequalthis) AND 
			((@EscludiDaComunicazioneequalthis IS NULL) OR ESCLUDI_DA_COMUNICAZIONE = @EscludiDaComunicazioneequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRevisioneDpagamentoEsitoFindSelect';

