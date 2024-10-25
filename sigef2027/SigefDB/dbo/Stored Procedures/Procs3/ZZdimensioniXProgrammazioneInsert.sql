
CREATE PROCEDURE [dbo].[ZZdimensioniXProgrammazioneInsert]
(
	@IdProgrammazione INT, 
	@IdDimensione INT
)
AS
	INSERT INTO zDIMENSIONI_X_PROGRAMMAZIONE
	(
		ID_PROGRAMMAZIONE, 
		ID_DIMENSIONE
	)
	VALUES
	(
		@IdProgrammazione, 
		@IdDimensione
	)
	SELECT SCOPE_IDENTITY() AS ID_DIM_X_PROGRAMMAZIONE

