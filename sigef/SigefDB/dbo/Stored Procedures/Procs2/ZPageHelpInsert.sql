CREATE PROCEDURE [dbo].[ZPageHelpInsert]
(
	@Page VARCHAR(255), 
	@Parametri VARCHAR(255), 
	@IdDoc INT, 
	@IdPdf INT, 
	@Operatore INT, 
	@Data DATETIME, 
	@Attivo BIT
)
AS
	SET @Attivo = ISNULL(@Attivo,((1)))
	INSERT INTO PAGE_HELP
	(
		PAGE, 
		PARAMETRI, 
		ID_DOC, 
		ID_PDF, 
		OPERATORE, 
		DATA, 
		ATTIVO
	)
	VALUES
	(
		@Page, 
		@Parametri, 
		@IdDoc, 
		@IdPdf, 
		@Operatore, 
		@Data, 
		@Attivo
	)
	SELECT SCOPE_IDENTITY() AS ID, @Attivo AS ATTIVO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPageHelpInsert';

