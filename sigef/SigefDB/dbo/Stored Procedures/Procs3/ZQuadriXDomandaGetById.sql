CREATE PROCEDURE [dbo].[ZQuadriXDomandaGetById]
(
	@IdQuadro INT, 
	@IdDomanda INT
)
AS
	SELECT *
	FROM vQUADRIDOMANDA
	WHERE 
		(ID_QUADRO = @IdQuadro) AND 
		(ID_DOMANDA = @IdDomanda)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'

CREATE PROCEDURE [dbo].[ZQuadrixdomandaGetById]
(
	@ID_QUADRO INT, 
	@ID_DOMANDA INT
)
AS
	SELECT *
	FROM vQUADRIDOMANDA
	WHERE 
		(ID_QUADRO = @ID_QUADRO) AND 
		(ID_DOMANDA = @ID_DOMANDA)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZQuadriXDomandaGetById';

