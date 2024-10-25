CREATE PROCEDURE [dbo].[ZUtentiStoricoInsert]
(
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
	SET @Attivo = ISNULL(@Attivo,((1)))
	INSERT INTO UTENTI_STORICO
	(
		ID_UTENTE, 
		ID_PROFILO, 
		COD_ENTE, 
		PROVINCIA, 
		EMAIL, 
		ATTIVO, 
		DATA, 
		OPERATORE
	)
	VALUES
	(
		@IdUtente, 
		@IdProfilo, 
		@CodEnte, 
		@Provincia, 
		@Email, 
		@Attivo, 
		@Data, 
		@Operatore
	)
	SELECT SCOPE_IDENTITY() AS ID, @Attivo AS ATTIVO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZUtentiStoricoInsert]
(
	@IdUtente INT, 
	@IdProfilo INT, 
	@CodEnte VARCHAR(10), 
	@Provincia CHAR(2), 
	@Attivo BIT, 
	@Data DATETIME, 
	@Operatore INT
)
AS
	INSERT INTO UTENTI_STORICO
	(
		ID_UTENTE, 
		ID_PROFILO, 
		COD_ENTE, 
		PROVINCIA, 
		ATTIVO, 
		DATA, 
		OPERATORE
	)
	VALUES
	(
		@IdUtente, 
		@IdProfilo, 
		@CodEnte, 
		@Provincia, 
		@Attivo, 
		@Data, 
		@Operatore
	)
	SELECT SCOPE_IDENTITY() AS ID
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZUtentiStoricoInsert';

