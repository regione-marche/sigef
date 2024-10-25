CREATE PROCEDURE [dbo].[ZLottoDiRevisioneGetById]
(
	@IdLotto INT
)
AS
	SELECT *
	FROM vLOTTO_DI_REVISIONE
	WHERE 
		(ID_LOTTO = @IdLotto)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZLottoDiRevisioneGetById]
(
	@IdLotto INT
)
AS
	SELECT *
	FROM vLOTTO_DI_REVISIONE
	WHERE 
		(ID_LOTTO = @IdLotto)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZLottoDiRevisioneGetById';

