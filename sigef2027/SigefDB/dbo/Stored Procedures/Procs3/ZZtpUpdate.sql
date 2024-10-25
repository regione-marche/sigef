CREATE PROCEDURE [dbo].[ZZtpUpdate]
(
	@Id INT, 
	@IdProgrammazione INT, 
	@Codice VARCHAR(255), 
	@Descrizione VARCHAR(255)
)
AS
	UPDATE zTP
	SET
		ID_PROGRAMMAZIONE = @IdProgrammazione, 
		CODICE = @Codice, 
		DESCRIZIONE = @Descrizione
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZtpUpdate';

