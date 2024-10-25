CREATE PROCEDURE [dbo].[ZQuadriXDomandaInsert]
(
	@IdQuadro INT, 
	@IdDomanda INT, 
	@Ordine INT
)
AS
	INSERT INTO QUADRI_X_DOMANDA
	(
		ID_QUADRO, 
		ID_DOMANDA, 
		ORDINE
	)
	VALUES
	(
		@IdQuadro, 
		@IdDomanda, 
		@Ordine
	)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZQuadrixdomandaInsert]
(
	@ID_QUADRO INT, 
	@ID_DOMANDA INT, 
	@ORDINE INT
)
AS
	INSERT INTO QUADRI_X_DOMANDA
	(
		ID_QUADRO, 
		ID_DOMANDA, 
		ORDINE
	)
	VALUES
	(
		@ID_QUADRO, 
		@ID_DOMANDA, 
		@ORDINE
	)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZQuadriXDomandaInsert';

