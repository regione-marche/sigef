CREATE PROCEDURE [dbo].[ZProfiloxfunzioniInsert]
(
	@IdProfilo INT, 
	@CodFunzione INT, 
	@Modifica BIT
)
AS
	INSERT INTO PROFILO_X_FUNZIONI
	(
		ID_PROFILO, 
		COD_FUNZIONE, 
		MODIFICA
	)
	VALUES
	(
		@IdProfilo, 
		@CodFunzione, 
		@Modifica
	)
