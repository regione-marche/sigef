create PROCEDURE [dbo].[ZStepXBandoUpdate]
(
	@IdBando INT, 
	@IdCheckList INT, 
	@CodFase CHAR(1)
)
AS
	UPDATE STEP_X_BANDO
	SET
		COD_FASE = @CodFase
	WHERE 
		(ID_BANDO = @IdBando) AND 
		(ID_CHECK_LIST = @IdCheckList)
