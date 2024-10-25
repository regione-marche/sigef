CREATE PROCEDURE [dbo].[ZControlliLocoLottoGetById]
(
	@IdLotto INT
)
AS
	SELECT *
	FROM vCONTROLLI_LOCO_LOTTO
	WHERE 
		(ID_LOTTO = @IdLotto)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZControlliLocoLottoGetById';

