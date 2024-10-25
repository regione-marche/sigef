CREATE PROCEDURE [dbo].[ZEsitoIstanzaChecklistGenericoGetById]
(
	@IdEsitoGenerico INT
)
AS
	SELECT *
	FROM VESITO_ISTANZA_CHECKLIST_GENERICO
	WHERE 
		(ID_ESITO_GENERICO = @IdEsitoGenerico)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZEsitoIstanzaChecklistGenericoGetById]
(
	@IdEsitoGenerico INT
)
AS
	SELECT *
	FROM VESITO_ISTANZA_CHECKLIST_GENERICO
	WHERE 
		(ID_ESITO_GENERICO = @IdEsitoGenerico)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZEsitoIstanzaChecklistGenericoGetById';

