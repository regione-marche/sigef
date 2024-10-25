CREATE PROCEDURE [dbo].[ZErroreDelete]
(
	@IdErrore INT
)
AS
	DELETE ERRORE
	WHERE 
		(ID_ERRORE = @IdErrore)

GO