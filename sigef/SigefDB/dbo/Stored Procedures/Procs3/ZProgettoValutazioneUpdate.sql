CREATE PROCEDURE [dbo].[ZProgettoValutazioneUpdate]
(
	@Id INT, 
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
	SET @DataModifica=getdate()
	UPDATE PROGETTO_VALUTAZIONE
	SET
		ID_PROGETTO = @IdProgetto, 
		ID_VARIANTE = @IdVariante, 
		ID_FILE = @IdFile, 
		ORDINE_FIRMA = @OrdineFirma, 
		SEGNATURA = @Segnatura, 
		ID_NOTE = @IdNote, 
		OPERATORE = @Operatore, 
		DATA_MODIFICA = @DataModifica, 
		ANNULLATO = @Annullato
	WHERE 
		(ID = @Id)
	SELECT @DataModifica;


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoValutazioneUpdate]
(
	@Id INT, 
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
	SET @DataModifica=getdate()
	UPDATE PROGETTO_VALUTAZIONE
	SET
		ID_PROGETTO = @IdProgetto, 
		ID_VARIANTE = @IdVariante, 
		ID_FILE = @IdFile, 
		ORDINE_FIRMA = @OrdineFirma, 
		SEGNATURA = @Segnatura, 
		ID_NOTE = @IdNote, 
		OPERATORE = @Operatore, 
		DATA_MODIFICA = @DataModifica, 
		ANNULLATO = @Annullato
	WHERE 
		(ID = @Id)
	SELECT @DataModifica;

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoValutazioneUpdate';

