CREATE PROCEDURE [dbo].[ZAutModificaPercAiutoDelete]
(
	@IdAutorizzazione INT
)
AS
	DELETE AUT_MODIFICA_PERC_AIUTO
	WHERE 
		(ID_AUTORIZZAZIONE = @IdAutorizzazione)

GO