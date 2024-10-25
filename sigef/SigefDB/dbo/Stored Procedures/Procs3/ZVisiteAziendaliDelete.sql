CREATE PROCEDURE [dbo].[ZVisiteAziendaliDelete]
(
	@IdVisita INT
)
AS
	DELETE VISITE_AZIENDALI
	WHERE 
		(ID_VISITA = @IdVisita)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZVisiteAziendaliDelete]
(
	@IdVisita INT
)
AS
	DELETE VISITE_AZIENDALI
	WHERE 
		(ID_VISITA = @IdVisita)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVisiteAziendaliDelete';

