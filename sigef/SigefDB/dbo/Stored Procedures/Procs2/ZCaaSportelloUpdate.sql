CREATE PROCEDURE [dbo].[ZCaaSportelloUpdate]
(
	@Codice VARCHAR(255), 
	@CodiceCaa VARCHAR(255), 
	@CodiceProvincia VARCHAR(255), 
	@CodiceUfficio VARCHAR(255), 
	@CodEnte VARCHAR(255), 
	@IdStoricoUltimo INT
)
AS
	UPDATE CAA_SPORTELLO
	SET
		CODICE_CAA = @CodiceCaa, 
		CODICE_PROVINCIA = @CodiceProvincia, 
		CODICE_UFFICIO = @CodiceUfficio, 
		COD_ENTE = @CodEnte, 
		ID_STORICO_ULTIMO = @IdStoricoUltimo
	WHERE 
		(CODICE = @Codice)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCaaSportelloUpdate';

