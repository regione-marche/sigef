CREATE PROCEDURE [dbo].[ZBusinessPlanGetById]
(
	@IdBando INT, 
	@IdQuadro INT
)
AS
	SELECT *
	FROM vBUSINESS_PLAN
	WHERE 
		(ID_BANDO = @IdBando) AND 
		(ID_QUADRO = @IdQuadro)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZBusinessPlanGetById]
(
	@IdBando INT, 
	@IdQuadro INT
)
AS
	SELECT *
	FROM vBUSINESS_PLAN
	WHERE 
		(ID_BANDO = @IdBando) AND 
		(ID_QUADRO = @IdQuadro)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBusinessPlanGetById';

