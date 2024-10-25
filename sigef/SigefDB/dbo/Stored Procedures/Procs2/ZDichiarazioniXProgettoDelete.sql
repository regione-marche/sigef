CREATE PROCEDURE [dbo].[ZDichiarazioniXProgettoDelete]
(
	@IdDichiarazione INT, 
	@IdProgetto INT
)
AS
	DELETE DICHIARAZIONI_X_PROGETTO
	WHERE 
		(ID_DICHIARAZIONE = @IdDichiarazione) AND 
		(ID_PROGETTO = @IdProgetto)
