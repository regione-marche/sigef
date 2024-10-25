CREATE PROCEDURE [dbo].[ZVariantiUpdate]
(
	@IdVariante INT, 
	@IdProgetto INT, 
	@CodTipo VARCHAR(255), 
	@DataInserimento DATETIME, 
	@CodEnte VARCHAR(255), 
	@Operatore VARCHAR(255), 
	@DataModifica DATETIME, 
	@Segnatura VARCHAR(255), 
	@SegnaturaAllegati VARCHAR(255), 
	@SegnaturaApprovazione VARCHAR(255), 
	@Approvata BIT, 
	@Istruttore VARCHAR(255), 
	@NoteIstruttore NTEXT, 
	@DataApprovazione DATETIME, 
	@Descrizione VARCHAR(1000), 
	@Annullata BIT, 
	@SegnaturaAnnullamento VARCHAR(255), 
	@CfOperatoreAnnullamento VARCHAR(255), 
	@DataAnnullamento DATETIME, 
	@CuaaEntrante VARCHAR(255), 
	@IdFascicoloEntrante INT, 
	@CuaaUscente VARCHAR(255), 
	@IdFascicoloUscente INT, 
	@RagsocUscente VARCHAR(255), 
	@IdAttoApprovazione INT
)
AS
	UPDATE VARIANTI
	SET
		ID_PROGETTO = @IdProgetto, 
		COD_TIPO = @CodTipo, 
		DATA_INSERIMENTO = @DataInserimento, 
		COD_ENTE = @CodEnte, 
		OPERATORE = @Operatore, 
		DATA_MODIFICA = @DataModifica, 
		SEGNATURA = @Segnatura, 
		SEGNATURA_ALLEGATI = @SegnaturaAllegati, 
		SEGNATURA_APPROVAZIONE = @SegnaturaApprovazione, 
		APPROVATA = @Approvata, 
		ISTRUTTORE = @Istruttore, 
		NOTE_ISTRUTTORE = @NoteIstruttore, 
		DATA_APPROVAZIONE = @DataApprovazione, 
		DESCRIZIONE = @Descrizione, 
		ANNULLATA = @Annullata, 
		SEGNATURA_ANNULLAMENTO = @SegnaturaAnnullamento, 
		CF_OPERATORE_ANNULLAMENTO = @CfOperatoreAnnullamento, 
		DATA_ANNULLAMENTO = @DataAnnullamento, 
		CUAA_ENTRANTE = @CuaaEntrante, 
		ID_FASCICOLO_ENTRANTE = @IdFascicoloEntrante, 
		CUAA_USCENTE = @CuaaUscente, 
		ID_FASCICOLO_USCENTE = @IdFascicoloUscente, 
		RAGSOC_USCENTE = @RagsocUscente, 
		ID_ATTO_APPROVAZIONE = @IdAttoApprovazione
	WHERE 
		(ID_VARIANTE = @IdVariante)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZVariantiUpdate]
(
	@IdVariante INT, 
	@IdProgetto INT, 
	@CodTipo CHAR(2), 
	@DataInserimento DATETIME, 
	@CodEnte VARCHAR(10), 
	@Operatore VARCHAR(16), 
	@DataModifica DATETIME, 
	@Segnatura VARCHAR(100), 
	@SegnaturaAllegati VARCHAR(100), 
	@SegnaturaApprovazione VARCHAR(100), 
	@Approvata BIT, 
	@Istruttore VARCHAR(16), 
	@NoteIstruttore NTEXT, 
	@DataApprovazione DATETIME, 
	@Descrizione VARCHAR(1000), 
	@Annullata BIT, 
	@SegnaturaAnnullamento VARCHAR(100), 
	@CfOperatoreAnnullamento VARCHAR(16), 
	@DataAnnullamento DATETIME, 
	@CuaaEntrante VARCHAR(16), 
	@IdFascicoloEntrante INT, 
	@CuaaUscente VARCHAR(16), 
	@IdFascicoloUscente INT, 
	@RagsocUscente VARCHAR(255), 
	@IdAttoApprovazione INT
)
AS
	UPDATE VARIANTI
	SET
		ID_PROGETTO = @IdProgetto, 
		COD_TIPO = @CodTipo, 
		DATA_INSERIMENTO = @DataInserimento, 
		COD_ENTE = @CodEnte, 
		OPERATORE = @Operatore, 
		DATA_MODIFICA = @DataModifica, 
		SEGNATURA = @Segnatura, 
		SEGNATURA_ALLEGATI = @SegnaturaAllegati, 
		SEGNATURA_APPROVAZIONE = @SegnaturaApprovazione, 
		APPROVATA = @Approvata, 
		ISTRUTTORE = @Istruttore, 
		NOTE_ISTRUTTORE = @NoteIstruttore, 
		DATA_APPROVAZIONE = @DataApprovazione, 
		DESCRIZIONE = @Descrizione, 
		ANNULLATA = @Annullata, 
		SEGNATURA_ANNULLAMENTO = @SegnaturaAnnullamento, 
		CF_OPERATORE_ANNULLAMENTO = @CfOperatoreAnnullamento, 
		DATA_ANNULLAMENTO = @DataAnnullamento, 
		CUAA_ENTRANTE = @CuaaEntrante, 
		ID_FASCICOLO_ENTRANTE = @IdFascicoloEntrante, 
		CUAA_USCENTE = @CuaaUscente, 
		ID_FASCICOLO_USCENTE = @IdFascicoloUscente, 
		RAGSOC_USCENTE = @RagsocUscente, 
		ID_ATTO_APPROVAZIONE = @IdAttoApprovazione
	WHERE 
		(ID_VARIANTE = @IdVariante)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVariantiUpdate';

