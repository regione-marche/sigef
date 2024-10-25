CREATE PROCEDURE [dbo].[ZProgettoComunicazioniFindFind]
(
	@IdBandoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdVarianteequalthis INT, 
	@CodTipoequalthis VARCHAR(255), 
	@Direzioneequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_PROGETTO, ID_DOMANDA_PAGAMENTO, ID_VARIANTE, COD_TIPO, DATA, SEGNATURA, OPERATORE, ID_NOTE, ISTRUTTORE, ESITO, ID_DECRETO, ID_COMUNICAZIONE_RIFERIMENTO, DIREZIONE, TIPO_SEGNATURA, GIORNI_PREVISTI, FLAG_DOMANDA_AIUTO, FLAG_DOMANDA_PAGAMENTO, FLAG_VARIANTE, NOMINATIVO_OPERATORE, CF_OPERATORE, CF_ISTRUTTORE, NOMINATIVO_ISTRUTTORE, NUM_ATTO, DATA_ATTO, DESCRIZIONE_ATTO, ID_BANDO, CUAA, CODICE_FISCALE, RAGIONE_SOCIALE, PREDISPOSTA_ALLA_FIRMA, DATA_ISTRUTTORIA, SEGNATURA_ISTRUTTORIA, ID_NOTE_ISTRUTTORIA, COD_ENTE_EMETTITORE, ID_COMUNE, ENTE, COD_TIPO_ENTE FROM vPROGETTO_COMUNICAZIONI WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VARIANTE = @IdVarianteequalthis)'; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@Direzioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DIREZIONE = @Direzioneequalthis)'; set @lensql=@lensql+len(@Direzioneequalthis);end;
	set @sql = @sql + 'ORDER BY ID DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @IdProgettoequalthis INT, @IdDomandaPagamentoequalthis INT, @IdVarianteequalthis INT, @CodTipoequalthis VARCHAR(255), @Direzioneequalthis VARCHAR(255)',@IdBandoequalthis , @IdProgettoequalthis , @IdDomandaPagamentoequalthis , @IdVarianteequalthis , @CodTipoequalthis , @Direzioneequalthis ;
	else
		SELECT ID, ID_PROGETTO, ID_DOMANDA_PAGAMENTO, ID_VARIANTE, COD_TIPO, DATA, SEGNATURA, OPERATORE, ID_NOTE, ISTRUTTORE, ESITO, ID_DECRETO, ID_COMUNICAZIONE_RIFERIMENTO, DIREZIONE, TIPO_SEGNATURA, GIORNI_PREVISTI, FLAG_DOMANDA_AIUTO, FLAG_DOMANDA_PAGAMENTO, FLAG_VARIANTE, NOMINATIVO_OPERATORE, CF_OPERATORE, CF_ISTRUTTORE, NOMINATIVO_ISTRUTTORE, NUM_ATTO, DATA_ATTO, DESCRIZIONE_ATTO, ID_BANDO, CUAA, CODICE_FISCALE, RAGIONE_SOCIALE, PREDISPOSTA_ALLA_FIRMA, DATA_ISTRUTTORIA, SEGNATURA_ISTRUTTORIA, ID_NOTE_ISTRUTTORIA, COD_ENTE_EMETTITORE, ID_COMUNE, ENTE, COD_TIPO_ENTE
		FROM vPROGETTO_COMUNICAZIONI
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@Direzioneequalthis IS NULL) OR DIREZIONE = @Direzioneequalthis)
		ORDER BY ID DESC


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoComunicazioniFindFind]
(
	@IdBandoequalthis INT, 
	@IdProgettoequalthis INT, 
	@CodTipoequalthis VARCHAR(255), 
	@Direzioneequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_PROGETTO, ID_DOMANDA_PAGAMENTO, ID_VARIANTE, COD_TIPO, DATA, SEGNATURA, OPERATORE, ID_NOTE, ISTRUTTORE, ESITO, ID_DECRETO, ID_COMUNICAZIONE_RIFERIMENTO, DIREZIONE, TIPO_SEGNATURA, GIORNI_PREVISTI, FLAG_DOMANDA_AIUTO, FLAG_DOMANDA_PAGAMENTO, FLAG_VARIANTE, NOMINATIVO_OPERATORE, CF_OPERATORE, CF_ISTRUTTORE, NOMINATIVO_ISTRUTTORE, NUM_ATTO, DATA_ATTO, DESCRIZIONE_ATTO, ID_BANDO, CUAA, CODICE_FISCALE, RAGIONE_SOCIALE, PREDISPOSTA_ALLA_FIRMA, DATA_ISTRUTTORIA, SEGNATURA_ISTRUTTORIA, ID_NOTE_ISTRUTTORIA, COD_ENTE_EMETTITORE, ID_COMUNE, ENTE, COD_TIPO_ENTE FROM vPROGETTO_COMUNICAZIONI WHERE 1=1'';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO = @CodTipoequalthis)''; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@Direzioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DIREZIONE = @Direzioneequalthis)''; set @lensql=@lensql+len(@Direzioneequalthis);end;
	set @sql = @sql + ''ORDER BY ID DESC'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdBandoequalthis INT, @IdProgettoequalthis INT, @CodTipoequalthis VARCHAR(255), @Direzioneequalthis VARCHAR(255)'',@IdBandoequalthis , @IdProgettoequalthis , @CodTipoequalthis , @Direzioneequalthis ;
	else
		SELECT ID, ID_PROGETTO, ID_DOMANDA_PAGAMENTO, ID_VARIANTE, COD_TIPO, DATA, SEGNATURA, OPERATORE, ID_NOTE, ISTRUTTORE, ESITO, ID_DECRETO, ID_COMUNICAZIONE_RIFERIMENTO, DIREZIONE, TIPO_SEGNATURA, GIORNI_PREVISTI, FLAG_DOMANDA_AIUTO, FLAG_DOMANDA_PAGAMENTO, FLAG_VARIANTE, NOMINATIVO_OPERATORE, CF_OPERATORE, CF_ISTRUTTORE, NOMINATIVO_ISTRUTTORE, NUM_ATTO, DATA_ATTO, DESCRIZIONE_ATTO, ID_BANDO, CUAA, CODICE_FISCALE, RAGIONE_SOCIALE, PREDISPOSTA_ALLA_FIRMA, DATA_ISTRUTTORIA, SEGNATURA_ISTRUTTORIA, ID_NOTE_ISTRUTTORIA, COD_ENTE_EMETTITORE, ID_COMUNE, ENTE, COD_TIPO_ENTE
		FROM vPROGETTO_COMUNICAZIONI
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@Direzioneequalthis IS NULL) OR DIREZIONE = @Direzioneequalthis)
		ORDER BY ID DESC

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoComunicazioniFindFind';

