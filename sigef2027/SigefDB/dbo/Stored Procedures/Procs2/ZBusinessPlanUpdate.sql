CREATE PROCEDURE [dbo].[ZBusinessPlanUpdate]
(
	@IdBando INT, 
	@IdQuadro INT, 
	@Ordine INT
)
AS
	UPDATE BUSINESS_PLAN
	SET
		ORDINE = @Ordine
	WHERE 
		(ID_BANDO = @IdBando) AND 
		(ID_QUADRO = @IdQuadro)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZBusinessPlanUpdate]
(
	@IdBando INT, 
	@IdQuadro INT, 
	@Ordine INT
)
AS
	UPDATE BUSINESS_PLAN
	SET
		ORDINE = @Ordine
	WHERE 
		(ID_BANDO = @IdBando) AND 
		(ID_QUADRO = @IdQuadro)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBusinessPlanUpdate';

