CREATE PROCEDURE [dbo].[ZBusinessPlanInsert]
(
	@IdBando INT, 
	@IdQuadro INT, 
	@Ordine INT
)
AS
	INSERT INTO BUSINESS_PLAN
	(
		ID_BANDO, 
		ID_QUADRO, 
		ORDINE
	)
	VALUES
	(
		@IdBando, 
		@IdQuadro, 
		@Ordine
	)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZBusinessPlanInsert]
(
	@IdBando INT, 
	@IdQuadro INT, 
	@Ordine INT
)
AS
	INSERT INTO BUSINESS_PLAN
	(
		ID_BANDO, 
		ID_QUADRO, 
		ORDINE
	)
	VALUES
	(
		@IdBando, 
		@IdQuadro, 
		@Ordine
	)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBusinessPlanInsert';

