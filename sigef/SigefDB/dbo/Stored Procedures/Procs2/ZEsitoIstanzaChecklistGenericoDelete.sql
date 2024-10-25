CREATE PROCEDURE [dbo].[ZEsitoIstanzaChecklistGenericoDelete]
(
	@IdEsitoGenerico INT
)
AS
	DELETE ESITO_ISTANZA_CHECKLIST_GENERICO
	WHERE 
		(ID_ESITO_GENERICO = @IdEsitoGenerico)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZEsitoIstanzaChecklistGenericoDelete]
(
	@IdEsitoGenerico INT
)
AS
	DELETE ESITO_ISTANZA_CHECKLIST_GENERICO
	WHERE 
		(ID_ESITO_GENERICO = @IdEsitoGenerico)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZEsitoIstanzaChecklistGenericoDelete';

