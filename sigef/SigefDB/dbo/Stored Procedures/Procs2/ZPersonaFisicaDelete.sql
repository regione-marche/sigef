CREATE PROCEDURE [dbo].[ZPersonaFisicaDelete]
(
	@IdPersona INT
)
AS
	DELETE PERSONA_FISICA
	WHERE 
		(ID_PERSONA = @IdPersona)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'

CREATE PROCEDURE [dbo].[ZPersonafisicaDelete]
(
	@ID_PERSONA INT
)
AS
	DELETE PERSONA_FISICA
	WHERE 
		(ID_PERSONA = @ID_PERSONA)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPersonaFisicaDelete';

