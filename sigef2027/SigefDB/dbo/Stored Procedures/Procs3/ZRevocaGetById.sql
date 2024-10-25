CREATE PROCEDURE [dbo].[ZRevocaGetById]
(
	@IdRevoca INT
)
AS
	SELECT *
	FROM REVOCA
	WHERE 
		(ID_REVOCA = @IdRevoca)