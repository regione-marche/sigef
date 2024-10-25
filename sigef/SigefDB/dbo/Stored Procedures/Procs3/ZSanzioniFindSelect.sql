CREATE PROCEDURE [dbo].[ZSanzioniFindSelect]
(
	@IdSanzioneequalthis INT, 
	@CodTipoequalthis VARCHAR(255), 
	@IdDomandaPagamentoequalthis INT, 
	@IdProgettoequalthis INT, 
	@DataApplicazioneequalthis DATETIME, 
	@Operatoreequalthis VARCHAR(255), 
	@Ammontareequalthis DECIMAL(18,2), 
	@IdInvestimentoequalthis INT, 
	@Durataequalthis INT, 
	@ValoreDurataequalthis DECIMAL(18,2), 
	@Gravitaequalthis INT, 
	@ValoreGravitaequalthis DECIMAL(18,2), 
	@Entitaequalthis INT, 
	@ValoreEntitaequalthis DECIMAL(18,2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_SANZIONE, COD_TIPO, ID_DOMANDA_PAGAMENTO, ID_PROGETTO, DATA_APPLICAZIONE, OPERATORE, AMMONTARE, ID_INVESTIMENTO, DURATA, VALORE_DURATA, GRAVITA, VALORE_GRAVITA, ENTITA, VALORE_ENTITA, TITOLO, DESCRIZIONE, QUERY_SQL, LIVELLO, ISTRUTTORIA, CONTROLLO_IN_LOCO, EX_POST, DESCRIZIONE_ENTITA, DESCRIZIONE_GRAVITA, DESCRIZIONE_DURATA, DURATA_SELEZIONATO, DURATA_NUMERICO, DURATA_TOOLTIP, GRAVITA_SELEZIONATO, GRAVITA_NUMERICO, GRAVITA_TOOLTIP, ENTITA_SELEZIONATO, ENTITA_NUMERICO, ENTITA_TOOLTIP, AUTOMATICO, MOTIVAZIONE FROM vSANZIONI WHERE 1=1';
	IF (@IdSanzioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SANZIONE = @IdSanzioneequalthis)'; set @lensql=@lensql+len(@IdSanzioneequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@DataApplicazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_APPLICAZIONE = @DataApplicazioneequalthis)'; set @lensql=@lensql+len(@DataApplicazioneequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@Ammontareequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AMMONTARE = @Ammontareequalthis)'; set @lensql=@lensql+len(@Ammontareequalthis);end;
	IF (@IdInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INVESTIMENTO = @IdInvestimentoequalthis)'; set @lensql=@lensql+len(@IdInvestimentoequalthis);end;
	IF (@Durataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DURATA = @Durataequalthis)'; set @lensql=@lensql+len(@Durataequalthis);end;
	IF (@ValoreDurataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VALORE_DURATA = @ValoreDurataequalthis)'; set @lensql=@lensql+len(@ValoreDurataequalthis);end;
	IF (@Gravitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (GRAVITA = @Gravitaequalthis)'; set @lensql=@lensql+len(@Gravitaequalthis);end;
	IF (@ValoreGravitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VALORE_GRAVITA = @ValoreGravitaequalthis)'; set @lensql=@lensql+len(@ValoreGravitaequalthis);end;
	IF (@Entitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ENTITA = @Entitaequalthis)'; set @lensql=@lensql+len(@Entitaequalthis);end;
	IF (@ValoreEntitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VALORE_ENTITA = @ValoreEntitaequalthis)'; set @lensql=@lensql+len(@ValoreEntitaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdSanzioneequalthis INT, @CodTipoequalthis VARCHAR(255), @IdDomandaPagamentoequalthis INT, @IdProgettoequalthis INT, @DataApplicazioneequalthis DATETIME, @Operatoreequalthis VARCHAR(255), @Ammontareequalthis DECIMAL(18,2), @IdInvestimentoequalthis INT, @Durataequalthis INT, @ValoreDurataequalthis DECIMAL(18,2), @Gravitaequalthis INT, @ValoreGravitaequalthis DECIMAL(18,2), @Entitaequalthis INT, @ValoreEntitaequalthis DECIMAL(18,2)',@IdSanzioneequalthis , @CodTipoequalthis , @IdDomandaPagamentoequalthis , @IdProgettoequalthis , @DataApplicazioneequalthis , @Operatoreequalthis , @Ammontareequalthis , @IdInvestimentoequalthis , @Durataequalthis , @ValoreDurataequalthis , @Gravitaequalthis , @ValoreGravitaequalthis , @Entitaequalthis , @ValoreEntitaequalthis ;
	else
		SELECT ID_SANZIONE, COD_TIPO, ID_DOMANDA_PAGAMENTO, ID_PROGETTO, DATA_APPLICAZIONE, OPERATORE, AMMONTARE, ID_INVESTIMENTO, DURATA, VALORE_DURATA, GRAVITA, VALORE_GRAVITA, ENTITA, VALORE_ENTITA, TITOLO, DESCRIZIONE, QUERY_SQL, LIVELLO, ISTRUTTORIA, CONTROLLO_IN_LOCO, EX_POST, DESCRIZIONE_ENTITA, DESCRIZIONE_GRAVITA, DESCRIZIONE_DURATA, DURATA_SELEZIONATO, DURATA_NUMERICO, DURATA_TOOLTIP, GRAVITA_SELEZIONATO, GRAVITA_NUMERICO, GRAVITA_TOOLTIP, ENTITA_SELEZIONATO, ENTITA_NUMERICO, ENTITA_TOOLTIP, AUTOMATICO, MOTIVAZIONE
		FROM vSANZIONI
		WHERE 
			((@IdSanzioneequalthis IS NULL) OR ID_SANZIONE = @IdSanzioneequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@DataApplicazioneequalthis IS NULL) OR DATA_APPLICAZIONE = @DataApplicazioneequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@Ammontareequalthis IS NULL) OR AMMONTARE = @Ammontareequalthis) AND 
			((@IdInvestimentoequalthis IS NULL) OR ID_INVESTIMENTO = @IdInvestimentoequalthis) AND 
			((@Durataequalthis IS NULL) OR DURATA = @Durataequalthis) AND 
			((@ValoreDurataequalthis IS NULL) OR VALORE_DURATA = @ValoreDurataequalthis) AND 
			((@Gravitaequalthis IS NULL) OR GRAVITA = @Gravitaequalthis) AND 
			((@ValoreGravitaequalthis IS NULL) OR VALORE_GRAVITA = @ValoreGravitaequalthis) AND 
			((@Entitaequalthis IS NULL) OR ENTITA = @Entitaequalthis) AND 
			((@ValoreEntitaequalthis IS NULL) OR VALORE_ENTITA = @ValoreEntitaequalthis)
