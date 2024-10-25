CREATE PROCEDURE [dbo].[ZDichiarazioniXProgettoGetById]
(
	@IdDichiarazione INT, 
	@IdProgetto INT
)
AS
	SELECT *
	FROM DICHIARAZIONI_X_PROGETTO
	WHERE 
		(ID_DICHIARAZIONE = @IdDichiarazione) AND 
		(ID_PROGETTO = @IdProgetto)
