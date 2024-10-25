CREATE PROCEDURE [dbo].[ZCertspRecuperiGetById]
(
	@IdRecupero INT
)
AS
	SELECT *
	FROM CERTSP_RECUPERI
	WHERE 
		(Id_Recupero = @IdRecupero)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCertspRecuperiGetById';

