CREATE PROCEDURE [dbo].[ZQuadriXDomandaDelete]
(
	@IdQuadro INT, 
	@IdDomanda INT
)
AS
	DELETE QUADRI_X_DOMANDA
	WHERE 
		(ID_QUADRO = @IdQuadro) AND 
		(ID_DOMANDA = @IdDomanda)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'

CREATE PROCEDURE [dbo].[ZQuadrixdomandaDelete]
(
	@ID_QUADRO INT, 
	@ID_DOMANDA INT
)
AS
	DELETE QUADRI_X_DOMANDA
	WHERE 
		(ID_QUADRO = @ID_QUADRO) AND 
		(ID_DOMANDA = @ID_DOMANDA)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZQuadriXDomandaDelete';

