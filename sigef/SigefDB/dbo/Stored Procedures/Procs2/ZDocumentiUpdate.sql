CREATE PROCEDURE [dbo].[ZDocumentiUpdate]
(
	@IdDocumento INT, 
	@Titolo VARCHAR(500), 
	@Descrizione VARCHAR(1000), 
	@DataModifica DATETIME, 
	@Operatore VARCHAR(16), 
	@DataFineValidita DATETIME
)
AS
	UPDATE DOCUMENTI
	SET
		TITOLO = @Titolo, 
		DESCRIZIONE = @Descrizione, 
		DATA_MODIFICA = @DataModifica, 
		OPERATORE = @Operatore, 
		DATA_FINE_VALIDITA = @DataFineValidita
	WHERE 
		(ID_DOCUMENTO = @IdDocumento)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZDocumentiUpdate]
(
	@IdDocumento INT, 
	@Titolo VARCHAR(500), 
	@Descrizione VARCHAR(1000), 
	@DataModifica DATETIME, 
	@Operatore VARCHAR(16), 
	@DataFineValidita DATETIME
)
AS
	SET @DataModifica=getdate()
	UPDATE DOCUMENTI
	SET
		TITOLO = @Titolo, 
		DESCRIZIONE = @Descrizione, 
		DATA_MODIFICA = @DataModifica, 
		OPERATORE = @Operatore, 
		DATA_FINE_VALIDITA = @DataFineValidita
	WHERE 
		(ID_DOCUMENTO = @IdDocumento)
	SELECT @DataModifica;

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDocumentiUpdate';

