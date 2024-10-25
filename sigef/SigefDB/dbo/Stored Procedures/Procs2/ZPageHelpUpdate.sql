CREATE PROCEDURE [dbo].[ZPageHelpUpdate]
(
	@Id INT, 
	@Page VARCHAR(255), 
	@Parametri VARCHAR(255), 
	@IdDoc INT, 
	@IdPdf INT, 
	@Operatore INT, 
	@Data DATETIME, 
	@Attivo BIT
)
AS
	UPDATE PAGE_HELP
	SET
		PAGE = @Page, 
		PARAMETRI = @Parametri, 
		ID_DOC = @IdDoc, 
		ID_PDF = @IdPdf, 
		OPERATORE = @Operatore, 
		DATA = @Data, 
		ATTIVO = @Attivo
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPageHelpUpdate';

