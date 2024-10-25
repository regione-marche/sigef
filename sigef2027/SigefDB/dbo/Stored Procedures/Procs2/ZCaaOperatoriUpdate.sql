CREATE PROCEDURE [dbo].[ZCaaOperatoriUpdate]
(
	@Id INT, 
	@CodiceSportello VARCHAR(255), 
	@IdUtente INT, 
	@IdStoricoUltimo INT
)
AS
	UPDATE CAA_OPERATORI
	SET
		CODICE_SPORTELLO = @CodiceSportello, 
		ID_UTENTE = @IdUtente, 
		ID_STORICO_ULTIMO = @IdStoricoUltimo
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCaaOperatoriUpdate';

