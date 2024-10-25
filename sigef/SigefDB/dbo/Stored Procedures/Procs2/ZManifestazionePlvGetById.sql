CREATE PROCEDURE [dbo].[ZManifestazionePlvGetById]
(
	@IdPlv INT
)
AS
	SELECT *
	FROM vMANIFESTAZIONE_PLV
	WHERE 
		(ID_PLV = @IdPlv)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZManifestazionePlvGetById';

