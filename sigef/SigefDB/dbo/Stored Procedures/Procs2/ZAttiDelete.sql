CREATE PROCEDURE [dbo].[ZAttiDelete]
(
	@IdAtto INT
)
AS
	DELETE ATTI
	WHERE 
		(ID_ATTO = @IdAtto)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZAttiDelete]
(
	@IdAtto INT
)
AS
	DELETE ATTI
	WHERE 
		(ID_ATTO = @IdAtto)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZAttiDelete';

