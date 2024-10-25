CREATE PROCEDURE [dbo].[ZProgettoComunicazioneUpdate]
(
	@IdComunicazione INT, 
	@IdProgetto INT, 
	@IdComunicazioneRef INT, 
	@Oggetto VARCHAR(255), 
	@Testo VARCHAR(max), 
	@CodTipo VARCHAR(255), 
	@DataInserimento DATETIME, 
	@DataModifica DATETIME, 
	@Operatore INT, 
	@Segnatura VARCHAR(255), 
	@SegnaturaEsterna BIT, 
	@InEntrata BIT, 
	@IdNote INT
)
AS
	UPDATE PROGETTO_COMUNICAZIONE
	SET
		ID_PROGETTO = @IdProgetto, 
		ID_COMUNICAZIONE_REF = @IdComunicazioneRef, 
		OGGETTO = @Oggetto, 
		TESTO = @Testo, 
		COD_TIPO = @CodTipo, 
		DATA_INSERIMENTO = @DataInserimento, 
		DATA_MODIFICA = @DataModifica, 
		OPERATORE = @Operatore, 
		SEGNATURA = @Segnatura, 
		SEGNATURA_ESTERNA = @SegnaturaEsterna, 
		IN_ENTRATA = @InEntrata, 
		ID_NOTE = @IdNote
	WHERE 
		(ID_COMUNICAZIONE = @IdComunicazione)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoComunicazioneUpdate';

