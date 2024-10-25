CREATE PROCEDURE [dbo].[ZAutModificaPercAiutoGetById]
(
	@IdAutorizzazione INT
)
AS
	SELECT *
	FROM VAUT_MODIFICA_PERC_AUTO
	WHERE 
		(ID_AUTORIZZAZIONE = @IdAutorizzazione)

GO