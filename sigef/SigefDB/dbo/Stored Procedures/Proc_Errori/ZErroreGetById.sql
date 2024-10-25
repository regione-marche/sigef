CREATE PROCEDURE [dbo].[ZErroreGetById]
(
	@IdErrore INT
)
AS
	SELECT *
	FROM VERRORE
	WHERE 
		(ID_ERRORE = @IdErrore)

GO