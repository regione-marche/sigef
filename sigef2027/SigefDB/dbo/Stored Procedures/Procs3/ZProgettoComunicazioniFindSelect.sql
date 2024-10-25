CREATE PROCEDURE [dbo].[ZProgettoComunicazioniFindSelect]
(
	@Idequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdVarianteequalthis INT, 
	@CodTipoequalthis VARCHAR(255), 
	@Dataequalthis DATETIME, 
	@CodEnteEmettitoreequalthis VARCHAR(255), 
	@IdComuneequalthis INT, 
	@Operatoreequalthis INT, 
	@PredispostaAllaFirmaequalthis BIT, 
	@Segnaturaequalthis VARCHAR(255), 
	@IdNoteequalthis INT, 
	@Istruttoreequalthis INT, 
	@DataIstruttoriaequalthis DATETIME, 
	@SegnaturaIstruttoriaequalthis VARCHAR(255), 
	@IdNoteIstruttoriaequalthis INT, 
	@Esitoequalthis VARCHAR(255), 
	@IdDecretoequalthis INT, 
	@IdComunicazioneRiferimentoequalthis INT, 
	@Direzioneequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_PROGETTO, ID_DOMANDA_PAGAMENTO, ID_VARIANTE, COD_TIPO, DATA, SEGNATURA, OPERATORE, ID_NOTE, ISTRUTTORE, ESITO, ID_DECRETO, ID_COMUNICAZIONE_RIFERIMENTO, DIREZIONE, TIPO_SEGNATURA, GIORNI_PREVISTI, FLAG_DOMANDA_AIUTO, FLAG_DOMANDA_PAGAMENTO, FLAG_VARIANTE, NOMINATIVO_OPERATORE, CF_OPERATORE, CF_ISTRUTTORE, NOMINATIVO_ISTRUTTORE, NUM_ATTO, DATA_ATTO, DESCRIZIONE_ATTO, ID_BANDO, CUAA, CODICE_FISCALE, RAGIONE_SOCIALE, PREDISPOSTA_ALLA_FIRMA, DATA_ISTRUTTORIA, SEGNATURA_ISTRUTTORIA, ID_NOTE_ISTRUTTORIA, COD_ENTE_EMETTITORE, ID_COMUNE, ENTE, COD_TIPO_ENTE FROM vPROGETTO_COMUNICAZIONI WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VARIANTE = @IdVarianteequalthis)'; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@CodEnteEmettitoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ENTE_EMETTITORE = @CodEnteEmettitoreequalthis)'; set @lensql=@lensql+len(@CodEnteEmettitoreequalthis);end;
	IF (@IdComuneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COMUNE = @IdComuneequalthis)'; set @lensql=@lensql+len(@IdComuneequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@PredispostaAllaFirmaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PREDISPOSTA_ALLA_FIRMA = @PredispostaAllaFirmaequalthis)'; set @lensql=@lensql+len(@PredispostaAllaFirmaequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA = @Segnaturaequalthis)'; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	IF (@IdNoteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_NOTE = @IdNoteequalthis)'; set @lensql=@lensql+len(@IdNoteequalthis);end;
	IF (@Istruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ISTRUTTORE = @Istruttoreequalthis)'; set @lensql=@lensql+len(@Istruttoreequalthis);end;
	IF (@DataIstruttoriaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_ISTRUTTORIA = @DataIstruttoriaequalthis)'; set @lensql=@lensql+len(@DataIstruttoriaequalthis);end;
	IF (@SegnaturaIstruttoriaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_ISTRUTTORIA = @SegnaturaIstruttoriaequalthis)'; set @lensql=@lensql+len(@SegnaturaIstruttoriaequalthis);end;
	IF (@IdNoteIstruttoriaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_NOTE_ISTRUTTORIA = @IdNoteIstruttoriaequalthis)'; set @lensql=@lensql+len(@IdNoteIstruttoriaequalthis);end;
	IF (@Esitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ESITO = @Esitoequalthis)'; set @lensql=@lensql+len(@Esitoequalthis);end;
	IF (@IdDecretoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DECRETO = @IdDecretoequalthis)'; set @lensql=@lensql+len(@IdDecretoequalthis);end;
	IF (@IdComunicazioneRiferimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COMUNICAZIONE_RIFERIMENTO = @IdComunicazioneRiferimentoequalthis)'; set @lensql=@lensql+len(@IdComunicazioneRiferimentoequalthis);end;
	IF (@Direzioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DIREZIONE = @Direzioneequalthis)'; set @lensql=@lensql+len(@Direzioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @IdProgettoequalthis INT, @IdDomandaPagamentoequalthis INT, @IdVarianteequalthis INT, @CodTipoequalthis VARCHAR(255), @Dataequalthis DATETIME, @CodEnteEmettitoreequalthis VARCHAR(255), @IdComuneequalthis INT, @Operatoreequalthis INT, @PredispostaAllaFirmaequalthis BIT, @Segnaturaequalthis VARCHAR(255), @IdNoteequalthis INT, @Istruttoreequalthis INT, @DataIstruttoriaequalthis DATETIME, @SegnaturaIstruttoriaequalthis VARCHAR(255), @IdNoteIstruttoriaequalthis INT, @Esitoequalthis VARCHAR(255), @IdDecretoequalthis INT, @IdComunicazioneRiferimentoequalthis INT, @Direzioneequalthis VARCHAR(255)',@Idequalthis , @IdProgettoequalthis , @IdDomandaPagamentoequalthis , @IdVarianteequalthis , @CodTipoequalthis , @Dataequalthis , @CodEnteEmettitoreequalthis , @IdComuneequalthis , @Operatoreequalthis , @PredispostaAllaFirmaequalthis , @Segnaturaequalthis , @IdNoteequalthis , @Istruttoreequalthis , @DataIstruttoriaequalthis , @SegnaturaIstruttoriaequalthis , @IdNoteIstruttoriaequalthis , @Esitoequalthis , @IdDecretoequalthis , @IdComunicazioneRiferimentoequalthis , @Direzioneequalthis ;
	else
		SELECT ID, ID_PROGETTO, ID_DOMANDA_PAGAMENTO, ID_VARIANTE, COD_TIPO, DATA, SEGNATURA, OPERATORE, ID_NOTE, ISTRUTTORE, ESITO, ID_DECRETO, ID_COMUNICAZIONE_RIFERIMENTO, DIREZIONE, TIPO_SEGNATURA, GIORNI_PREVISTI, FLAG_DOMANDA_AIUTO, FLAG_DOMANDA_PAGAMENTO, FLAG_VARIANTE, NOMINATIVO_OPERATORE, CF_OPERATORE, CF_ISTRUTTORE, NOMINATIVO_ISTRUTTORE, NUM_ATTO, DATA_ATTO, DESCRIZIONE_ATTO, ID_BANDO, CUAA, CODICE_FISCALE, RAGIONE_SOCIALE, PREDISPOSTA_ALLA_FIRMA, DATA_ISTRUTTORIA, SEGNATURA_ISTRUTTORIA, ID_NOTE_ISTRUTTORIA, COD_ENTE_EMETTITORE, ID_COMUNE, ENTE, COD_TIPO_ENTE
		FROM vPROGETTO_COMUNICAZIONI
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@CodEnteEmettitoreequalthis IS NULL) OR COD_ENTE_EMETTITORE = @CodEnteEmettitoreequalthis) AND 
			((@IdComuneequalthis IS NULL) OR ID_COMUNE = @IdComuneequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@PredispostaAllaFirmaequalthis IS NULL) OR PREDISPOSTA_ALLA_FIRMA = @PredispostaAllaFirmaequalthis) AND 
			((@Segnaturaequalthis IS NULL) OR SEGNATURA = @Segnaturaequalthis) AND 
			((@IdNoteequalthis IS NULL) OR ID_NOTE = @IdNoteequalthis) AND 
			((@Istruttoreequalthis IS NULL) OR ISTRUTTORE = @Istruttoreequalthis) AND 
			((@DataIstruttoriaequalthis IS NULL) OR DATA_ISTRUTTORIA = @DataIstruttoriaequalthis) AND 
			((@SegnaturaIstruttoriaequalthis IS NULL) OR SEGNATURA_ISTRUTTORIA = @SegnaturaIstruttoriaequalthis) AND 
			((@IdNoteIstruttoriaequalthis IS NULL) OR ID_NOTE_ISTRUTTORIA = @IdNoteIstruttoriaequalthis) AND 
			((@Esitoequalthis IS NULL) OR ESITO = @Esitoequalthis) AND 
			((@IdDecretoequalthis IS NULL) OR ID_DECRETO = @IdDecretoequalthis) AND 
			((@IdComunicazioneRiferimentoequalthis IS NULL) OR ID_COMUNICAZIONE_RIFERIMENTO = @IdComunicazioneRiferimentoequalthis) AND 
			((@Direzioneequalthis IS NULL) OR DIREZIONE = @Direzioneequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoComunicazioniFindSelect]
(
	@Idequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdVarianteequalthis INT, 
	@CodTipoequalthis VARCHAR(255), 
	@Dataequalthis DATETIME, 
	@CodEnteEmettitoreequalthis VARCHAR(255), 
	@IdComuneequalthis INT, 
	@Operatoreequalthis INT, 
	@PredispostaAllaFirmaequalthis BIT, 
	@Segnaturaequalthis VARCHAR(255), 
	@IdNoteequalthis INT, 
	@Istruttoreequalthis INT, 
	@DataIstruttoriaequalthis DATETIME, 
	@SegnaturaIstruttoriaequalthis VARCHAR(255), 
	@IdNoteIstruttoriaequalthis INT, 
	@Esitoequalthis VARCHAR(255), 
	@IdDecretoequalthis INT, 
	@IdComunicazioneRiferimentoequalthis INT, 
	@Direzioneequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_PROGETTO, ID_DOMANDA_PAGAMENTO, ID_VARIANTE, COD_TIPO, DATA, SEGNATURA, OPERATORE, ID_NOTE, ISTRUTTORE, ESITO, ID_DECRETO, ID_COMUNICAZIONE_RIFERIMENTO, DIREZIONE, TIPO_SEGNATURA, GIORNI_PREVISTI, FLAG_DOMANDA_AIUTO, FLAG_DOMANDA_PAGAMENTO, FLAG_VARIANTE, NOMINATIVO_OPERATORE, CF_OPERATORE, CF_ISTRUTTORE, NOMINATIVO_ISTRUTTORE, NUM_ATTO, DATA_ATTO, DESCRIZIONE_ATTO, ID_BANDO, CUAA, CODICE_FISCALE, RAGIONE_SOCIALE, PREDISPOSTA_ALLA_FIRMA, DATA_ISTRUTTORIA, SEGNATURA_ISTRUTTORIA, ID_NOTE_ISTRUTTORIA, COD_ENTE_EMETTITORE, ID_COMUNE, ENTE, COD_TIPO_ENTE FROM vPROGETTO_COMUNICAZIONI WHERE 1=1'';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID = @Idequalthis)''; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)''; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_VARIANTE = @IdVarianteequalthis)''; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO = @CodTipoequalthis)''; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA = @Dataequalthis)''; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@CodEnteEmettitoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_ENTE_EMETTITORE = @CodEnteEmettitoreequalthis)''; set @lensql=@lensql+len(@CodEnteEmettitoreequalthis);end;
	IF (@IdComuneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_COMUNE = @IdComuneequalthis)''; set @lensql=@lensql+len(@IdComuneequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (OPERATORE = @Operatoreequalthis)''; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@PredispostaAllaFirmaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PREDISPOSTA_ALLA_FIRMA = @PredispostaAllaFirmaequalthis)''; set @lensql=@lensql+len(@PredispostaAllaFirmaequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SEGNATURA = @Segnaturaequalthis)''; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	IF (@IdNoteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_NOTE = @IdNoteequalthis)''; set @lensql=@lensql+len(@IdNoteequalthis);end;
	IF (@Istruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ISTRUTTORE = @Istruttoreequalthis)''; set @lensql=@lensql+len(@Istruttoreequalthis);end;
	IF (@DataIstruttoriaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_ISTRUTTORIA = @DataIstruttoriaequalthis)''; set @lensql=@lensql+len(@DataIstruttoriaequalthis);end;
	IF (@SegnaturaIstruttoriaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SEGNATURA_ISTRUTTORIA = @SegnaturaIstruttoriaequalthis)''; set @lensql=@lensql+len(@SegnaturaIstruttoriaequalthis);end;
	IF (@IdNoteIstruttoriaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_NOTE_ISTRUTTORIA = @IdNo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoComunicazioniFindSelect';

