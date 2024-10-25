CREATE PROCEDURE [dbo].[ZLottoDiRevisioneDelete]
(
	@IdLotto INT
)
AS
	DELETE LOTTO_DI_REVISIONE
	WHERE 
		(ID_LOTTO = @IdLotto)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZLottoDiRevisioneDelete]
(
	@IdLotto INT
)
AS
	DELETE LOTTO_DI_REVISIONE
	WHERE 
		(ID_LOTTO = @IdLotto)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZLottoDiRevisioneDelete';

