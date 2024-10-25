CREATE PROCEDURE [dbo].[ZUtentiStoricoUpdate]
(
	@Id INT, 
	@IdUtente INT, 
	@IdProfilo INT, 
	@CodEnte VARCHAR(255), 
	@Provincia VARCHAR(255), 
	@Email VARCHAR(255), 
	@Attivo BIT, 
	@Data DATETIME, 
	@Operatore INT
)
AS
	UPDATE UTENTI_STORICO
	SET
		ID_UTENTE = @IdUtente, 
		ID_PROFILO = @IdProfilo, 
		COD_ENTE = @CodEnte, 
		PROVINCIA = @Provincia, 
		EMAIL = @Email, 
		ATTIVO = @Attivo, 
		DATA = @Data, 
		OPERATORE = @Operatore
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZUtentiStoricoUpdate]
(
	@Id INT, 
	@IdUtente INT, 
	@IdProfilo INT, 
	@CodEnte VARCHAR(10), 
	@Provincia CHAR(2), 
	@Attivo BIT, 
	@Data DATETIME, 
	@Operatore INT
)
AS
	UPDATE UTENTI_STORICO
	SET
		ID_UTENTE = @IdUtente, 
		ID_PROFILO = @IdProfilo, 
		COD_ENTE = @CodEnte, 
		PROVINCIA = @Provincia, 
		ATTIVO = @Attivo, 
		DATA = @Data, 
		OPERATORE = @Operatore
	WHERE 
		(ID = @Id)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZUtentiStoricoUpdate';

