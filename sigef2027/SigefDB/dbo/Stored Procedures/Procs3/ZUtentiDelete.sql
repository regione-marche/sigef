CREATE PROCEDURE [dbo].[ZUtentiDelete]
(
	@IdUtente INT
)
AS
	DELETE UTENTI
	WHERE 
		(ID_UTENTE = @IdUtente)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZUtentiDelete]
(
	@IdUtente INT
)
AS
	DELETE UTENTI
	WHERE 
		(ID_UTENTE = @IdUtente)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZUtentiDelete';

