CREATE PROCEDURE [dbo].[ZSpeseSostenuteDelete]
(
	@IdSpesa INT
)
AS
	DELETE SPESE_SOSTENUTE
	WHERE 
		(ID_SPESA = @IdSpesa)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZSpeseSostenuteDelete]
(
	@IdSpesa INT
)
AS
	DELETE SPESE_SOSTENUTE
	WHERE 
		(ID_SPESA = @IdSpesa)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSpeseSostenuteDelete';

