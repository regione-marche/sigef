CREATE PROCEDURE [dbo].[ZProfiloxfunzioniUpdate]
(
	@IdProfilo INT, 
	@CodFunzione INT, 
	@Modifica BIT
)
AS
	UPDATE PROFILO_X_FUNZIONI
	SET
		MODIFICA = @Modifica
	WHERE 
		(ID_PROFILO = @IdProfilo) AND 
		(COD_FUNZIONE = @CodFunzione)
