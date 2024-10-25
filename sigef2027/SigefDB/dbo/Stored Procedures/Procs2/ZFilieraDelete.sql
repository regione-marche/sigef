CREATE PROCEDURE [dbo].[ZFilieraDelete]
(
	@IdFiliera INT
)
AS
	DELETE FILIERA
	WHERE 
		(ID_FILIERA = @IdFiliera)
