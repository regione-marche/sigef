CREATE PROCEDURE [dbo].[zCUPUpdateProgetto] 
	(
		@IdProgetto INT,
		@CodiceCup VARCHAR(50)
	)
AS
BEGIN
	
	UPDATE PROGETTO SET COD_AGEA = @CodiceCup WHERE ID_PROGETTO = @IdProgetto
	
END
