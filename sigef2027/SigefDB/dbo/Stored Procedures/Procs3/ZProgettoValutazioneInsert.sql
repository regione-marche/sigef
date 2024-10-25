CREATE PROCEDURE [dbo].[ZProgettoValutazioneInsert]
(
	@IdProgetto INT, 
	@IdVariante INT, 
	@IdFile INT, 
	@OrdineFirma INT, 
	@Segnatura VARCHAR(255), 
	@IdNote INT, 
	@Operatore INT, 
	@DataModifica DATETIME, 
	@Annullato BIT
)
AS
	SET @OrdineFirma = ISNULL(@OrdineFirma,((0)))
	SET @Annullato = ISNULL(@Annullato,((0)))
	INSERT INTO PROGETTO_VALUTAZIONE
	(
		ID_PROGETTO, 
		ID_VARIANTE, 
		ID_FILE, 
		ORDINE_FIRMA, 
		SEGNATURA, 
		ID_NOTE, 
		OPERATORE, 
		DATA_MODIFICA, 
		ANNULLATO
	)
	VALUES
	(
		@IdProgetto, 
		@IdVariante, 
		@IdFile, 
		@OrdineFirma, 
		@Segnatura, 
		@IdNote, 
		@Operatore, 
		@DataModifica, 
		@Annullato
	)
	SELECT SCOPE_IDENTITY() AS ID, @OrdineFirma AS ORDINE_FIRMA, @Annullato AS ANNULLATO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoValutazioneInsert]
(
	@IdProgetto INT, 
	@IdVariante INT, 
	@IdFile INT, 
	@OrdineFirma INT, 
	@Segnatura VARCHAR(255), 
	@IdNote INT, 
	@Operatore INT, 
	@DataModifica DATETIME, 
	@Annullato BIT
)
AS
	SET @OrdineFirma = ISNULL(@OrdineFirma,((0)))
	SET @Annullato = ISNULL(@Annullato,((0)))
	INSERT INTO PROGETTO_VALUTAZIONE
	(
		ID_PROGETTO, 
		ID_VARIANTE, 
		ID_FILE, 
		ORDINE_FIRMA, 
		SEGNATURA, 
		ID_NOTE, 
		OPERATORE, 
		DATA_MODIFICA, 
		ANNULLATO
	)
	VALUES
	(
		@IdProgetto, 
		@IdVariante, 
		@IdFile, 
		@OrdineFirma, 
		@Segnatura, 
		@IdNote, 
		@Operatore, 
		@DataModifica, 
		@Annullato
	)
	SELECT SCOPE_IDENTITY() AS ID, @OrdineFirma AS ORDINE_FIRMA, @Annullato AS ANNULLATO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoValutazioneInsert';

