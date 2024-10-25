CREATE PROCEDURE [dbo].[ZPersoneXImpreseDelete]
(
	@IdPersoneXImprese INT
)
AS
	DELETE PERSONE_X_IMPRESE
	WHERE 
		(ID_PERSONE_X_IMPRESE = @IdPersoneXImprese)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZPersoneXImpreseDelete]
(
	@IdPersoneXImprese INT
)
AS
	DELETE PERSONE_X_IMPRESE
	WHERE 
		(ID_PERSONE_X_IMPRESE = @IdPersoneXImprese)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPersoneXImpreseDelete';

