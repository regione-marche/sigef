CREATE PROCEDURE [dbo].[ZStepxbandoDelete]
(
	@IdBando INT, 
	@IdCheckList INT
)
AS
	DELETE STEP_X_BANDO
	WHERE 
		(ID_BANDO = @IdBando) AND 
		(ID_CHECK_LIST = @IdCheckList)
