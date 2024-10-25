CREATE PROCEDURE [dbo].[ZManifestazionePlvDelete]
(
	@IdPlv INT
)
AS
	DELETE MANIFESTAZIONE_PLV
	WHERE 
		(ID_PLV = @IdPlv)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZManifestazionePlvDelete';

