CREATE PROCEDURE [dbo].[ZZobMisuraUpdate]
(
	@Id INT, 
	@IdProgrammazione INT, 
	@Codice VARCHAR(255), 
	@Descrizione VARCHAR(500)
)
AS
	UPDATE zOB_MISURA
	SET
		ID_PROGRAMMAZIONE = @IdProgrammazione, 
		CODICE = @Codice, 
		DESCRIZIONE = @Descrizione
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZZobMisuraUpdate]
(
	@Id INT, 
	@IdProgrammazione INT, 
	@Codice VARCHAR(255), 
	@Descrizione VARCHAR(500)
)
AS
	UPDATE zOB_MISURA
	SET
		ID_PROGRAMMAZIONE = @IdProgrammazione, 
		CODICE = @Codice, 
		DESCRIZIONE = @Descrizione
	WHERE 
		(ID = @Id)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZobMisuraUpdate';

