CREATE PROCEDURE [dbo].[ZZobMisuraInsert]
(
	@IdProgrammazione INT, 
	@Codice VARCHAR(255), 
	@Descrizione VARCHAR(500)
)
AS
	INSERT INTO zOB_MISURA
	(
		ID_PROGRAMMAZIONE, 
		CODICE, 
		DESCRIZIONE
	)
	VALUES
	(
		@IdProgrammazione, 
		@Codice, 
		@Descrizione
	)
	SELECT SCOPE_IDENTITY() AS ID

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZZobMisuraInsert]
(
	@IdProgrammazione INT, 
	@Codice VARCHAR(255), 
	@Descrizione VARCHAR(500)
)
AS
	INSERT INTO zOB_MISURA
	(
		ID_PROGRAMMAZIONE, 
		CODICE, 
		DESCRIZIONE
	)
	VALUES
	(
		@IdProgrammazione, 
		@Codice, 
		@Descrizione
	)
	SELECT SCOPE_IDENTITY() AS ID

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZobMisuraInsert';

