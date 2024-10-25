CREATE PROCEDURE [dbo].[ZStepxbandoGetById]
(
	@IdBando INT, 
	@IdCheckList INT
)
AS
	SELECT *
	FROM vSTEP_X_BANDO
	WHERE 
		(ID_BANDO = @IdBando) AND 
		(ID_CHECK_LIST = @IdCheckList)
