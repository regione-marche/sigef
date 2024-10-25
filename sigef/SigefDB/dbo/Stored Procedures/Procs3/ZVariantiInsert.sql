CREATE PROCEDURE [dbo].[ZVariantiInsert]
(
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
	SET @Annullata = ISNULL(@Annullata,((0)))
	INSERT INTO VARIANTI
	(
		ID_PROGETTO, 
		COD_TIPO, 
		DATA_INSERIMENTO, 
		COD_ENTE, 
		OPERATORE, 
		DATA_MODIFICA, 
		SEGNATURA, 
		SEGNATURA_ALLEGATI, 
		SEGNATURA_APPROVAZIONE, 
		APPROVATA, 
		ISTRUTTORE, 
		NOTE_ISTRUTTORE, 
		DATA_APPROVAZIONE, 
		DESCRIZIONE, 
		ANNULLATA, 
		SEGNATURA_ANNULLAMENTO, 
		CF_OPERATORE_ANNULLAMENTO, 
		DATA_ANNULLAMENTO, 
		CUAA_ENTRANTE, 
		ID_FASCICOLO_ENTRANTE, 
		CUAA_USCENTE, 
		ID_FASCICOLO_USCENTE, 
		RAGSOC_USCENTE, 
		ID_ATTO_APPROVAZIONE
	)
	VALUES
	(
		@IdProgetto, 
		@CodTipo, 
		@DataInserimento, 
		@CodEnte, 
		@Operatore, 
		@DataModifica, 
		@Segnatura, 
		@SegnaturaAllegati, 
		@SegnaturaApprovazione, 
		@Approvata, 
		@Istruttore, 
		@NoteIstruttore, 
		@DataApprovazione, 
		@Descrizione, 
		@Annullata, 
		@SegnaturaAnnullamento, 
		@CfOperatoreAnnullamento, 
		@DataAnnullamento, 
		@CuaaEntrante, 
		@IdFascicoloEntrante, 
		@CuaaUscente, 
		@IdFascicoloUscente, 
		@RagsocUscente, 
		@IdAttoApprovazione
	)
	SELECT SCOPE_IDENTITY() AS ID_VARIANTE, @Annullata AS ANNULLATA

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZVariantiInsert]
(
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
	SET @Annullata = ISNULL(@Annullata,((0)))
	INSERT INTO VARIANTI
	(
		ID_PROGETTO, 
		COD_TIPO, 
		DATA_INSERIMENTO, 
		COD_ENTE, 
		OPERATORE, 
		DATA_MODIFICA, 
		SEGNATURA, 
		SEGNATURA_ALLEGATI, 
		SEGNATURA_APPROVAZIONE, 
		APPROVATA, 
		ISTRUTTORE, 
		NOTE_ISTRUTTORE, 
		DATA_APPROVAZIONE, 
		DESCRIZIONE, 
		ANNULLATA, 
		SEGNATURA_ANNULLAMENTO, 
		CF_OPERATORE_ANNULLAMENTO, 
		DATA_ANNULLAMENTO, 
		CUAA_ENTRANTE, 
		ID_FASCICOLO_ENTRANTE, 
		CUAA_USCENTE, 
		ID_FASCICOLO_USCENTE, 
		RAGSOC_USCENTE, 
		ID_ATTO_APPROVAZIONE
	)
	VALUES
	(
		@IdProgetto, 
		@CodTipo, 
		@DataInserimento, 
		@CodEnte, 
		@Operatore, 
		@DataModifica, 
		@Segnatura, 
		@SegnaturaAllegati, 
		@SegnaturaApprovazione, 
		@Approvata, 
		@Istruttore, 
		@NoteIstruttore, 
		@DataApprovazione, 
		@Descrizione, 
		@Annullata, 
		@SegnaturaAnnullamento, 
		@CfOperatoreAnnullamento, 
		@DataAnnullamento, 
		@CuaaEntrante, 
		@IdFascicoloEntrante, 
		@CuaaUscente, 
		@IdFascicoloUscente, 
		@RagsocUscente, 
		@IdAttoApprovazione
	)
	SELECT SCOPE_IDENTITY() AS ID_VARIANTE, @Annullata AS ANNULLATA

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVariantiInsert';

