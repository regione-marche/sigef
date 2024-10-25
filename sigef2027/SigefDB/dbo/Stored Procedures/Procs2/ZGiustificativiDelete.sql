CREATE PROCEDURE [dbo].[ZGiustificativiDelete]
(
	@IdGiustificativo INT
)
AS
	DELETE GIUSTIFICATIVI
	WHERE 
		(ID_GIUSTIFICATIVO = @IdGiustificativo)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZGiustificativiDelete]
(
	@IdGiustificativo INT
)
AS
	DELETE GIUSTIFICATIVI
	WHERE 
		(ID_GIUSTIFICATIVO = @IdGiustificativo)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZGiustificativiDelete';

