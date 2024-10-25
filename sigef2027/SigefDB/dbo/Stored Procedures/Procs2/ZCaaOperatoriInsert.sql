CREATE PROCEDURE [dbo].[ZCaaOperatoriInsert]
(
	@CodiceSportello VARCHAR(255), 
	@IdUtente INT, 
	@IdStoricoUltimo INT
)
AS
	INSERT INTO CAA_OPERATORI
	(
		CODICE_SPORTELLO, 
		ID_UTENTE, 
		ID_STORICO_ULTIMO
	)
	VALUES
	(
		@CodiceSportello, 
		@IdUtente, 
		@IdStoricoUltimo
	)
	SELECT SCOPE_IDENTITY() AS ID

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCaaOperatoriInsert';

