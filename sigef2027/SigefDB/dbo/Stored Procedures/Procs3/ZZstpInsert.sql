CREATE PROCEDURE [dbo].[ZZstpInsert]
(
	@IdProgrammazione INT, 
	@Codice VARCHAR(255), 
	@Descrizione VARCHAR(255)
)
AS
	INSERT INTO zSTP
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
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZstpInsert';

