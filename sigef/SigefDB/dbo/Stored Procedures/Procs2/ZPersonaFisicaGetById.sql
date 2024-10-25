CREATE PROCEDURE [dbo].[ZPersonaFisicaGetById]
(
	@IdPersona INT
)
AS
	SELECT *
	FROM vPERSONA_FISICA
	WHERE 
		(ID_PERSONA = @IdPersona)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'

CREATE PROCEDURE [dbo].[ZPersonafisicaGetById]
(
	@ID_PERSONA INT
)
AS
	SELECT *
	FROM vPersonaFisica
	WHERE 
		(ID_PERSONA = @ID_PERSONA)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPersonaFisicaGetById';

