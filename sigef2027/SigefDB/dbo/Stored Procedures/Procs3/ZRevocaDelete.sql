CREATE PROCEDURE [dbo].[ZRevocaDelete]
(
	@IdRevoca INT
)
AS
	DELETE REVOCA
	WHERE 
		(ID_REVOCA = @IdRevoca)