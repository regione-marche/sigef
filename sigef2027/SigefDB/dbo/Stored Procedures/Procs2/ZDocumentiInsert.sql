CREATE PROCEDURE [dbo].[ZDocumentiInsert]
(
	@Titolo VARCHAR(500), 
	@Descrizione VARCHAR(1000), 
	@DataModifica DATETIME, 
	@Operatore VARCHAR(16), 
	@DataFineValidita DATETIME
)
AS
	INSERT INTO DOCUMENTI
	(
		TITOLO, 
		DESCRIZIONE, 
		DATA_MODIFICA, 
		OPERATORE, 
		DATA_FINE_VALIDITA
	)
	VALUES
	(
		@Titolo, 
		@Descrizione, 
		@DataModifica, 
		@Operatore, 
		@DataFineValidita
	)
	SELECT SCOPE_IDENTITY() AS ID_DOCUMENTO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'
CREATE PROCEDURE [dbo].[ZDocumentiInsert]
(
	@Titolo VARCHAR(500), 
	@Descrizione VARCHAR(1000), 
	@DataModifica DATETIME, 
	@Operatore VARCHAR(16), 
	@DataFineValidita DATETIME
)
AS
	IF (@DataModifica IS NULL) SET @DataModifica=getdate()
	INSERT INTO DOCUMENTI
	(
		TITOLO, 
		DESCRIZIONE, 
		DATA_MODIFICA, 
		OPERATORE, 
		DATA_FINE_VALIDITA
	)
	VALUES
	(
		@Titolo, 
		@Descrizione, 
		@DataModifica, 
		@Operatore, 
		@DataFineValidita
	)
	SELECT SCOPE_IDENTITY() AS ID_DOCUMENTO


', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDocumentiInsert';

