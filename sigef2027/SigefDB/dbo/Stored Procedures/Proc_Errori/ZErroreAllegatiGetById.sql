CREATE PROCEDURE [dbo].[ZErroreAllegatiGetById]
(
	@IdErroreAllegati INT
)
AS
	SELECT *
	FROM VERRORE_ALLEGATI
	WHERE 
		(ID_ERRORE_ALLEGATI = @IdErroreAllegati)

GO