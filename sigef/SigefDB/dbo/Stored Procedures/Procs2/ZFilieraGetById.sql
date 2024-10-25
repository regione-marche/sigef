create PROCEDURE [dbo].[ZFilieraGetById]
(
	@IdFiliera INT
)
AS
	SELECT *
	FROM FILIERA
	WHERE 
		(ID_FILIERA = @IdFiliera)
