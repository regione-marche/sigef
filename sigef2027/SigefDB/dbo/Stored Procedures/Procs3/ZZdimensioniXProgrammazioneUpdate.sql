
CREATE PROCEDURE [dbo].[ZZdimensioniXProgrammazioneUpdate]
(
	@IdProgrammazione INT, 
	@IdDimensione INT, 
	@IdDimXProgrammazione INT
)
AS
	UPDATE zDIMENSIONI_X_PROGRAMMAZIONE
	SET
		ID_PROGRAMMAZIONE = @IdProgrammazione, 
		ID_DIMENSIONE = @IdDimensione
	WHERE 
		(ID_DIM_X_PROGRAMMAZIONE = @IdDimXProgrammazione)

