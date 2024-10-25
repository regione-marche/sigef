CREATE PROCEDURE [dbo].[ZControlliLocoLottoDelete]
(
	@IdLotto INT
)
AS
	DELETE CONTROLLI_LOCO_LOTTO
	WHERE 
		(ID_LOTTO = @IdLotto)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZControlliLocoLottoDelete]
(
	@IdLotto INT
)
AS
	DELETE CONTROLLI_LOCO_LOTTO
	WHERE 
		(ID_LOTTO = @IdLotto)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZControlliLocoLottoDelete';

