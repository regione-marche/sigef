CREATE PROCEDURE [dbo].[ZCaaSportelloInsert]
(
	@Codice VARCHAR(255), 
	@CodiceCaa VARCHAR(255), 
	@CodiceProvincia VARCHAR(255), 
	@CodiceUfficio VARCHAR(255), 
	@CodEnte VARCHAR(255), 
	@IdStoricoUltimo INT
)
AS
	INSERT INTO CAA_SPORTELLO
	(
		CODICE, 
		CODICE_CAA, 
		CODICE_PROVINCIA, 
		CODICE_UFFICIO, 
		COD_ENTE, 
		ID_STORICO_ULTIMO
	)
	VALUES
	(
		@Codice, 
		@CodiceCaa, 
		@CodiceProvincia, 
		@CodiceUfficio, 
		@CodEnte, 
		@IdStoricoUltimo
	)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCaaSportelloInsert';

