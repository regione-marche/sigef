
CREATE PROCEDURE [dbo].[ZZdimensioniXProgrammazioneGetById]
(
	@IdDimXProgrammazione INT
)
AS
	SELECT *
	FROM vzDIMENSIONI_X_PROGRAMMAZIONE
	WHERE 
		(ID_DIM_X_PROGRAMMAZIONE = @IdDimXProgrammazione)


