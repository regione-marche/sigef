CREATE PROCEDURE [dbo].[ZEnteDelete]
(
	@CodEnte VARCHAR(10)
)
AS
	DELETE ENTE
	WHERE 
		(COD_ENTE = @CodEnte)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'

CREATE PROCEDURE [dbo].[ZEnteDelete]
(
	@CodEnte VARCHAR(10)
)
AS
	DELETE ENTE
	WHERE 
		(COD_ENTE = @CodEnte)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZEnteDelete';

