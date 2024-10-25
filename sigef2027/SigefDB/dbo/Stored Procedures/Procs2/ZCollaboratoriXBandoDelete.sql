CREATE PROCEDURE [dbo].[ZCollaboratoriXBandoDelete]
(
	@IdCollaboratore INT
)
AS
	DELETE COLLABORATORI_X_BANDO
	WHERE 
		(ID_COLLABORATORE = @IdCollaboratore)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZCollaboratoriXBandoDelete]
(
	@IdCollaboratore INT
)
AS
	DELETE COLLABORATORI_X_BANDO
	WHERE 
		(ID_COLLABORATORE = @IdCollaboratore)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCollaboratoriXBandoDelete';

