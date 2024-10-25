CREATE PROCEDURE [dbo].[ZUtentiInsert]
(
	@IdPersonaFisica INT, 
	@IdStoricoUltimo INT, 
	@UltimoAccesso DATETIME
)
AS
	INSERT INTO UTENTI
	(
		ID_PERSONA_FISICA, 
		ID_STORICO_ULTIMO, 
		ULTIMO_ACCESSO
	)
	VALUES
	(
		@IdPersonaFisica, 
		@IdStoricoUltimo, 
		@UltimoAccesso
	)
	SELECT SCOPE_IDENTITY() AS ID_UTENTE


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZUtentiInsert]
(
	@IdPersonaFisica INT, 
	@IdStoricoUltimo INT, 
	@UltimoAccesso DATETIME
)
AS
	IF(SELECT COUNT(*) FROM UTENTI WHERE ID_PERSONA_FISICA=@IdPersonaFisica)>0
	BEGIN 
		RAISERROR(''L`utente è già presente nel database come operatore.'',16,1)
		RETURN
	END
	INSERT INTO UTENTI
	(
		ID_PERSONA_FISICA, 
		ID_STORICO_ULTIMO, 
		ULTIMO_ACCESSO
	)
	VALUES
	(
		@IdPersonaFisica, 
		@IdStoricoUltimo, 
		@UltimoAccesso
	)
	SELECT SCOPE_IDENTITY() AS ID_UTENTE
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZUtentiInsert';

