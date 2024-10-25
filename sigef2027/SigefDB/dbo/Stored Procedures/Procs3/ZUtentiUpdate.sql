CREATE PROCEDURE [dbo].[ZUtentiUpdate]
(
	@IdUtente INT, 
	@IdPersonaFisica INT, 
	@IdStoricoUltimo INT, 
	@UltimoAccesso DATETIME
)
AS
	UPDATE UTENTI
	SET
		ID_PERSONA_FISICA = @IdPersonaFisica, 
		ID_STORICO_ULTIMO = @IdStoricoUltimo, 
		ULTIMO_ACCESSO = @UltimoAccesso
	WHERE 
		(ID_UTENTE = @IdUtente)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZUtentiUpdate]
(
	@IdUtente INT, 
	@IdPersonaFisica INT, 
	@IdStoricoUltimo INT, 
	@UltimoAccesso DATETIME
)
AS
	UPDATE UTENTI
	SET
		ID_PERSONA_FISICA = @IdPersonaFisica, 
		ID_STORICO_ULTIMO = @IdStoricoUltimo, 
		ULTIMO_ACCESSO = @UltimoAccesso
	WHERE 
		(ID_UTENTE = @IdUtente)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZUtentiUpdate';

