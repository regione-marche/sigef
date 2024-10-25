CREATE PROCEDURE [dbo].[ZComuniGetById]
(
	@IdComune INT
)
AS
	SELECT *
	FROM vCOMUNI
	WHERE 
		(ID_COMUNE = @IdComune)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZComuniGetById';

