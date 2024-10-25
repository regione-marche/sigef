CREATE PROCEDURE [dbo].[ZProfiloxfunzioniDelete]
(
	@IdProfilo INT, 
	@CodFunzione INT
)
AS
	DELETE PROFILO_X_FUNZIONI
	WHERE 
		(ID_PROFILO = @IdProfilo) AND 
		(COD_FUNZIONE = @CodFunzione)
