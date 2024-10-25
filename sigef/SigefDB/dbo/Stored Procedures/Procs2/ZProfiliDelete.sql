CREATE PROCEDURE [dbo].[ZProfiliDelete]
(
	@IdProfilo INT
)
AS
	DELETE PROFILI
	WHERE 
		(ID_PROFILO = @IdProfilo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZProfiliDelete]
(
	@IdProfilo INT
)
AS
	DELETE PROFILI
	WHERE 
		(ID_PROFILO = @IdProfilo)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProfiliDelete';

