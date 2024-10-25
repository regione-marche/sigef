CREATE PROCEDURE [dbo].[ZErroreAllegatiDelete]
(
	@IdErroreAllegati INT
)
AS
	DELETE ERRORE_ALLEGATI
	WHERE 
		(ID_ERRORE_ALLEGATI = @IdErroreAllegati)

GO