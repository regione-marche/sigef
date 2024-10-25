CREATE PROCEDURE [dbo].[ZProgettoComunicazioneInsert]
(
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
	SET @DataInserimento = ISNULL(@DataInserimento,(getdate()))
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	INSERT INTO PROGETTO_COMUNICAZIONE
	(
		ID_PROGETTO, 
		ID_COMUNICAZIONE_REF, 
		OGGETTO, 
		TESTO, 
		COD_TIPO, 
		DATA_INSERIMENTO, 
		DATA_MODIFICA, 
		OPERATORE, 
		SEGNATURA, 
		SEGNATURA_ESTERNA, 
		IN_ENTRATA, 
		ID_NOTE
	)
	VALUES
	(
		@IdProgetto, 
		@IdComunicazioneRef, 
		@Oggetto, 
		@Testo, 
		@CodTipo, 
		@DataInserimento, 
		@DataModifica, 
		@Operatore, 
		@Segnatura, 
		@SegnaturaEsterna, 
		@InEntrata, 
		@IdNote
	)
	SELECT SCOPE_IDENTITY() AS ID_COMUNICAZIONE, @DataInserimento AS DATA_INSERIMENTO, @DataModifica AS DATA_MODIFICA


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoComunicazioneInsert';

