CREATE PROCEDURE [dbo].[ZSanzioniFindFind]
(
	@IdSanzioneequalthis INT, 
	@CodTipoequalthis VARCHAR(255), 
	@IdDomandaPagamentoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdInvestimentoequalthis INT, 
	@Livelloequalthis VARCHAR(255)
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
	IF (@IdInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INVESTIMENTO = @IdInvestimentoequalthis)'; set @lensql=@lensql+len(@IdInvestimentoequalthis);end;
	IF (@Livelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (LIVELLO = @Livelloequalthis)'; set @lensql=@lensql+len(@Livelloequalthis);end;
	set @sql = @sql + 'ORDER BY ID_SANZIONE';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdSanzioneequalthis INT, @CodTipoequalthis VARCHAR(255), @IdDomandaPagamentoequalthis INT, @IdProgettoequalthis INT, @IdInvestimentoequalthis INT, @Livelloequalthis VARCHAR(255)',@IdSanzioneequalthis , @CodTipoequalthis , @IdDomandaPagamentoequalthis , @IdProgettoequalthis , @IdInvestimentoequalthis , @Livelloequalthis ;
	else
		SELECT ID_SANZIONE, COD_TIPO, ID_DOMANDA_PAGAMENTO, ID_PROGETTO, DATA_APPLICAZIONE, OPERATORE, AMMONTARE, ID_INVESTIMENTO, DURATA, VALORE_DURATA, GRAVITA, VALORE_GRAVITA, ENTITA, VALORE_ENTITA, TITOLO, DESCRIZIONE, QUERY_SQL, LIVELLO, ISTRUTTORIA, CONTROLLO_IN_LOCO, EX_POST, DESCRIZIONE_ENTITA, DESCRIZIONE_GRAVITA, DESCRIZIONE_DURATA, DURATA_SELEZIONATO, DURATA_NUMERICO, DURATA_TOOLTIP, GRAVITA_SELEZIONATO, GRAVITA_NUMERICO, GRAVITA_TOOLTIP, ENTITA_SELEZIONATO, ENTITA_NUMERICO, ENTITA_TOOLTIP, AUTOMATICO, MOTIVAZIONE
		FROM vSANZIONI
		WHERE 
			((@IdSanzioneequalthis IS NULL) OR ID_SANZIONE = @IdSanzioneequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdInvestimentoequalthis IS NULL) OR ID_INVESTIMENTO = @IdInvestimentoequalthis) AND 
			((@Livelloequalthis IS NULL) OR LIVELLO = @Livelloequalthis)
		ORDER BY ID_SANZIONE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZSanzioniFindFind]
(
	@IdSanzioneequalthis INT, 
	@CodTipoequalthis VARCHAR(10), 
	@IdDomandaPagamentoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdInvestimentoequalthis INT, 
	@Livelloequalthis CHAR(1)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_SANZIONE, COD_TIPO, ID_DOMANDA_PAGAMENTO, ID_PROGETTO, DATA_APPLICAZIONE, OPERATORE, AMMONTARE, ID_INVESTIMENTO, DURATA, VALORE_DURATA, GRAVITA, VALORE_GRAVITA, ENTITA, VALORE_ENTITA, TITOLO, DESCRIZIONE, QUERY_SQL, LIVELLO, ISTRUTTORIA, CONTROLLO_IN_LOCO, EX_POST, DESCRIZIONE_ENTITA, DESCRIZIONE_GRAVITA, DESCRIZIONE_DURATA, DURATA_SELEZIONATO, DURATA_NUMERICO, DURATA_TOOLTIP, GRAVITA_SELEZIONATO, GRAVITA_NUMERICO, GRAVITA_TOOLTIP, ENTITA_SELEZIONATO, ENTITA_NUMERICO, ENTITA_TOOLTIP, AUTOMATICO, MOTIVAZIONE FROM vSANZIONI WHERE 1=1'';
	IF (@IdSanzioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_SANZIONE = @IdSanzioneequalthis)''; set @lensql=@lensql+len(@IdSanzioneequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO = @CodTipoequalthis)''; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)''; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_INVESTIMENTO = @IdInvestimentoequalthis)''; set @lensql=@lensql+len(@IdInvestimentoequalthis);end;
	IF (@Livelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (LIVELLO = @Livelloequalthis)''; set @lensql=@lensql+len(@Livelloequalthis);end;
	set @sql = @sql + ''ORDER BY ID_SANZIONE'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdSanzioneequalthis INT, @CodTipoequalthis VARCHAR(10), @IdDomandaPagamentoequalthis INT, @IdProgettoequalthis INT, @IdInvestimentoequalthis INT, @Livelloequalthis CHAR(1)'',@IdSanzioneequalthis , @CodTipoequalthis , @IdDomandaPagamentoequalthis , @IdProgettoequalthis , @IdInvestimentoequalthis , @Livelloequalthis ;
	else
		SELECT ID_SANZIONE, COD_TIPO, ID_DOMANDA_PAGAMENTO, ID_PROGETTO, DATA_APPLICAZIONE, OPERATORE, AMMONTARE, ID_INVESTIMENTO, DURATA, VALORE_DURATA, GRAVITA, VALORE_GRAVITA, ENTITA, VALORE_ENTITA, TITOLO, DESCRIZIONE, QUERY_SQL, LIVELLO, ISTRUTTORIA, CONTROLLO_IN_LOCO, EX_POST, DESCRIZIONE_ENTITA, DESCRIZIONE_GRAVITA, DESCRIZIONE_DURATA, DURATA_SELEZIONATO, DURATA_NUMERICO, DURATA_TOOLTIP, GRAVITA_SELEZIONATO, GRAVITA_NUMERICO, GRAVITA_TOOLTIP, ENTITA_SELEZIONATO, ENTITA_NUMERICO, ENTITA_TOOLTIP, AUTOMATICO, MOTIVAZIONE
		FROM vSANZIONI
		WHERE 
			((@IdSanzioneequalthis IS NULL) OR ID_SANZIONE = @IdSanzioneequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdInvestimentoequalthis IS NULL) OR ID_INVESTIMENTO = @IdInvestimentoequalthis) AND 
			((@Livelloequalthis IS NULL) OR LIVELLO = @Livelloequalthis)
		ORDER BY ID_SANZIONE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSanzioniFindFind';

