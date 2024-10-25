CREATE PROCEDURE [dbo].[ZProgettoComunicazioniInsert]
(
	@IdProgetto INT, 
	@IdDomandaPagamento INT, 
	@IdVariante INT, 
	@CodTipo VARCHAR(255), 
	@Data DATETIME, 
	@Segnatura VARCHAR(255), 
	@Operatore INT, 
	@IdNote INT, 
	@Istruttore INT, 
	@Esito VARCHAR(255), 
	@IdDecreto INT, 
	@IdComunicazioneRiferimento INT, 
	@Direzione VARCHAR(255), 
	@PredispostaAllaFirma BIT, 
	@DataIstruttoria DATETIME, 
	@SegnaturaIstruttoria VARCHAR(255), 
	@IdNoteIstruttoria INT, 
	@CodEnteEmettitore VARCHAR(255), 
	@IdComune INT
)
AS
	SET @PredispostaAllaFirma = ISNULL(@PredispostaAllaFirma,((0)))
	INSERT INTO PROGETTO_COMUNICAZIONI
	(
		ID_PROGETTO, 
		ID_DOMANDA_PAGAMENTO, 
		ID_VARIANTE, 
		COD_TIPO, 
		DATA, 
		SEGNATURA, 
		OPERATORE, 
		ID_NOTE, 
		ISTRUTTORE, 
		ESITO, 
		ID_DECRETO, 
		ID_COMUNICAZIONE_RIFERIMENTO, 
		DIREZIONE, 
		PREDISPOSTA_ALLA_FIRMA, 
		DATA_ISTRUTTORIA, 
		SEGNATURA_ISTRUTTORIA, 
		ID_NOTE_ISTRUTTORIA, 
		COD_ENTE_EMETTITORE, 
		ID_COMUNE
	)
	VALUES
	(
		@IdProgetto, 
		@IdDomandaPagamento, 
		@IdVariante, 
		@CodTipo, 
		@Data, 
		@Segnatura, 
		@Operatore, 
		@IdNote, 
		@Istruttore, 
		@Esito, 
		@IdDecreto, 
		@IdComunicazioneRiferimento, 
		@Direzione, 
		@PredispostaAllaFirma, 
		@DataIstruttoria, 
		@SegnaturaIstruttoria, 
		@IdNoteIstruttoria, 
		@CodEnteEmettitore, 
		@IdComune
	)
	SELECT SCOPE_IDENTITY() AS ID, @PredispostaAllaFirma AS PREDISPOSTA_ALLA_FIRMA


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoComunicazioniInsert]
(
	@IdProgetto INT, 
	@IdDomandaPagamento INT, 
	@IdVariante INT, 
	@CodTipo VARCHAR(255), 
	@Data DATETIME, 
	@Segnatura VARCHAR(255), 
	@Operatore INT, 
	@IdNote INT, 
	@Istruttore INT, 
	@Esito VARCHAR(255), 
	@IdDecreto INT, 
	@IdComunicazioneRiferimento INT, 
	@Direzione VARCHAR(255), 
	@PredispostaAllaFirma BIT, 
	@DataIstruttoria DATETIME, 
	@SegnaturaIstruttoria VARCHAR(255), 
	@IdNoteIstruttoria INT, 
	@CodEnteEmettitore VARCHAR(255), 
	@IdComune INT
)
AS
	SET @PredispostaAllaFirma = ISNULL(@PredispostaAllaFirma,((0)))
	INSERT INTO PROGETTO_COMUNICAZIONI
	(
		ID_PROGETTO, 
		ID_DOMANDA_PAGAMENTO, 
		ID_VARIANTE, 
		COD_TIPO, 
		DATA, 
		SEGNATURA, 
		OPERATORE, 
		ID_NOTE, 
		ISTRUTTORE, 
		ESITO, 
		ID_DECRETO, 
		ID_COMUNICAZIONE_RIFERIMENTO, 
		DIREZIONE, 
		PREDISPOSTA_ALLA_FIRMA, 
		DATA_ISTRUTTORIA, 
		SEGNATURA_ISTRUTTORIA, 
		ID_NOTE_ISTRUTTORIA, 
		COD_ENTE_EMETTITORE, 
		ID_COMUNE
	)
	VALUES
	(
		@IdProgetto, 
		@IdDomandaPagamento, 
		@IdVariante, 
		@CodTipo, 
		@Data, 
		@Segnatura, 
		@Operatore, 
		@IdNote, 
		@Istruttore, 
		@Esito, 
		@IdDecreto, 
		@IdComunicazioneRiferimento, 
		@Direzione, 
		@PredispostaAllaFirma, 
		@DataIstruttoria, 
		@SegnaturaIstruttoria, 
		@IdNoteIstruttoria, 
		@CodEnteEmettitore, 
		@IdComune
	)
	SELECT SCOPE_IDENTITY() AS ID, @PredispostaAllaFirma AS PREDISPOSTA_ALLA_FIRMA

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoComunicazioniInsert';

