CREATE PROCEDURE [dbo].[ZProgettoComunicazioniUpdate]
(
	@Id INT, 
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
	UPDATE PROGETTO_COMUNICAZIONI
	SET
		ID_PROGETTO = @IdProgetto, 
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento, 
		ID_VARIANTE = @IdVariante, 
		COD_TIPO = @CodTipo, 
		DATA = @Data, 
		SEGNATURA = @Segnatura, 
		OPERATORE = @Operatore, 
		ID_NOTE = @IdNote, 
		ISTRUTTORE = @Istruttore, 
		ESITO = @Esito, 
		ID_DECRETO = @IdDecreto, 
		ID_COMUNICAZIONE_RIFERIMENTO = @IdComunicazioneRiferimento, 
		DIREZIONE = @Direzione, 
		PREDISPOSTA_ALLA_FIRMA = @PredispostaAllaFirma, 
		DATA_ISTRUTTORIA = @DataIstruttoria, 
		SEGNATURA_ISTRUTTORIA = @SegnaturaIstruttoria, 
		ID_NOTE_ISTRUTTORIA = @IdNoteIstruttoria, 
		COD_ENTE_EMETTITORE = @CodEnteEmettitore, 
		ID_COMUNE = @IdComune
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoComunicazioniUpdate]
(
	@Id INT, 
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
	UPDATE PROGETTO_COMUNICAZIONI
	SET
		ID_PROGETTO = @IdProgetto, 
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento, 
		ID_VARIANTE = @IdVariante, 
		COD_TIPO = @CodTipo, 
		DATA = @Data, 
		SEGNATURA = @Segnatura, 
		OPERATORE = @Operatore, 
		ID_NOTE = @IdNote, 
		ISTRUTTORE = @Istruttore, 
		ESITO = @Esito, 
		ID_DECRETO = @IdDecreto, 
		ID_COMUNICAZIONE_RIFERIMENTO = @IdComunicazioneRiferimento, 
		DIREZIONE = @Direzione, 
		PREDISPOSTA_ALLA_FIRMA = @PredispostaAllaFirma, 
		DATA_ISTRUTTORIA = @DataIstruttoria, 
		SEGNATURA_ISTRUTTORIA = @SegnaturaIstruttoria, 
		ID_NOTE_ISTRUTTORIA = @IdNoteIstruttoria, 
		COD_ENTE_EMETTITORE = @CodEnteEmettitore, 
		ID_COMUNE = @IdComune
	WHERE 
		(ID = @Id)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoComunicazioniUpdate';

