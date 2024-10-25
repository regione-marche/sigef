CREATE PROCEDURE [dbo].[ZControlliParametriXLottoGetById]
(
	@IdLotto INT, 
	@IdParametro INT
)
AS
	SELECT *
	FROM vCONTROLLI_PARAMETRI_X_LOTTO
	WHERE 
		(ID_LOTTO = @IdLotto) AND 
		(ID_PARAMETRO = @IdParametro)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZControlliParametriXLottoGetById';

