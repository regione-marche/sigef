CREATE PROCEDURE [dbo].[ZProfiloxfunzioniGetById]
(
	@IdProfilo INT, 
	@CodFunzione INT
)
AS
	SELECT *
	FROM vPROFILO_X_FUNZIONI
	WHERE 
		(ID_PROFILO = @IdProfilo) AND 
		(COD_FUNZIONE = @CodFunzione)
