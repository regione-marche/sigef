CREATE PROCEDURE [dbo].[ZQuadriXDomandaUpdate]
(
	@IdQuadro INT, 
	@IdDomanda INT, 
	@Ordine INT
)
AS
	UPDATE QUADRI_X_DOMANDA
	SET
		ORDINE = @Ordine
	WHERE 
		(ID_QUADRO = @IdQuadro) AND 
		(ID_DOMANDA = @IdDomanda)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'

CREATE PROCEDURE [dbo].[ZQuadrixdomandaUpdate]
(
	@ID_QUADRO INT, 
	@ID_DOMANDA INT, 
	@ORDINE INT
)
AS
	UPDATE QUADRI_X_DOMANDA
	SET
		ORDINE = @ORDINE
	WHERE 
		(ID_QUADRO = @ID_QUADRO) AND 
		(ID_DOMANDA = @ID_DOMANDA)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZQuadriXDomandaUpdate';

