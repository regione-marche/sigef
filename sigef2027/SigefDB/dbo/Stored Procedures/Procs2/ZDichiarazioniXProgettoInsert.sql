CREATE PROCEDURE [dbo].[ZDichiarazioniXProgettoInsert]
(
	@IdDichiarazione INT, 
	@IdProgetto INT
)
AS
	INSERT INTO DICHIARAZIONI_X_PROGETTO
	(
		ID_DICHIARAZIONE, 
		ID_PROGETTO
	)
	VALUES
	(
		@IdDichiarazione, 
		@IdProgetto
	)
