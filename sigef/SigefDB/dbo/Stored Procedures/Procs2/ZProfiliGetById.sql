CREATE PROCEDURE [dbo].[ZProfiliGetById]
(
	@IdProfilo INT
)
AS
	SELECT *
	FROM PROFILI
	WHERE 
		(ID_PROFILO = @IdProfilo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZProfiliGetById]
(
	@IdProfilo INT
)
AS
	SELECT *
	FROM PROFILI
	WHERE 
		(ID_PROFILO = @IdProfilo)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProfiliGetById';

