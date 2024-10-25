
CREATE PROCEDURE [dbo].[ZZdimensioniXProgrammazioneDelete]
(
	@IdDimXProgrammazione INT
)
AS
	DELETE zDIMENSIONI_X_PROGRAMMAZIONE
	WHERE 
		(ID_DIM_X_PROGRAMMAZIONE = @IdDimXProgrammazione)

